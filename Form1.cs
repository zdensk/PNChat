using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PNChat
{
    public partial class Form1 : Form
    {
        private const string ConfigFile = "config.dat";

        private string softwareId = string.Empty;
        private string pinHash = string.Empty;
        private string userName = string.Empty;

        private PeerDiscovery discovery;
        private ChatServer server;
        private ChatClient client;
        private System.Windows.Forms.Timer discoveryTimer;

        private class PeerInfo
        {
            public string Name { get; set; }
            public string Id { get; set; }
            public string Ip { get; set; }
            public string ActiveWindowTitle { get; set; }
            public DateTime LastSeen { get; set; }

            public PeerInfo(string name, string id, string ip, string activeWindowTitle)
            {
                Name = name;
                Id = id;
                Ip = ip;
                ActiveWindowTitle = activeWindowTitle;
                LastSeen = DateTime.Now;
            }
        }

        private Dictionary<string, PeerInfo> peers = new();

        private readonly SoundPlayer notifyPlayer = new SoundPlayer("notify.wav");

        private bool isLoggedIn = false;

        public Form1()
        {
            InitializeComponent();
            LoadOrCreateConfig();

            try
            {
                var iconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app.ico");
                if (File.Exists(iconPath))
                {
                    this.Icon = new System.Drawing.Icon(iconPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Icon loading failed: {ex.Message}");
            }

            discovery = new PeerDiscovery();
            server = new ChatServer(12456);
            client = new ChatClient(12456);

            discovery.PeerFound += async (msg, ip) => await OnPeerFound(msg, ip);
            server.MessageReceived += OnMessageReceived;

            lblSoftwareId.Text = $"Software ID: {softwareId}";
            Text = $"Private Network Chat v0.7 | zdnsk";

            if (!string.IsNullOrEmpty(softwareId) && !string.IsNullOrEmpty(userName))
                discovery.Start($"{userName}|{softwareId}|{GetActiveWindowTitle()}");

            discoveryTimer = new System.Windows.Forms.Timer { Interval = 10000 };
            discoveryTimer.Tick += (s, e) =>
            {
                if (!string.IsNullOrEmpty(softwareId) && !string.IsNullOrEmpty(userName))
                    discovery.Start($"{userName}|{softwareId}|{GetActiveWindowTitle()}");
                CleanUpPeers();
                RefreshPeerListBox();
                RefreshActiveWindowListBox();
            };
            discoveryTimer.Start();

            txtMessageBox.KeyDown += TxtMessageBox_KeyDown;

            SetLoggedInState(false);

            FormClosing += async (sender, e) =>
            {
                if (isLoggedIn) await SendLogoutMessage();
            };
        }

        private async Task OnPeerFound(string rawData, string ip)
        {
            var parts = rawData.Split('|');
            if (parts.Length < 3) return;

            string name = parts[0];
            string id = parts[1];
            string activeWindowTitle = parts[2];

            if (peers.ContainsKey(id))
            {
                var peer = peers[id];
                peer.LastSeen = DateTime.Now;
                peer.Ip = ip;
                peer.Name = name;
                peer.ActiveWindowTitle = activeWindowTitle;
            }
            else
            {
                peers[id] = new PeerInfo(name, id, ip, activeWindowTitle);
            }
            RefreshPeerListBox();
            RefreshActiveWindowListBox();
            await Task.CompletedTask;
        }

        private void RefreshPeerListBox()
        {
            if (peerListBox.InvokeRequired)
            {
                peerListBox.Invoke(new Action(RefreshPeerListBox));
                return;
            }

            // Előzőleg kiválasztott peer Id eltárolása
            string? selectedId = null;
            if (peerListBox.SelectedItem != null)
            {
                var parts = peerListBox.SelectedItem.ToString()?.Split(new[] { " - " }, StringSplitOptions.None);
                if (parts != null && parts.Length >= 2)
                    selectedId = parts[1];
            }

            peerListBox.Items.Clear();
            int toSelectIndex = -1;
            int index = 0;

            // Lista feltöltése, és azonosító keresése index alapján
            foreach (var p in peers.Values)
            {
                string item = $"{p.Name} - {p.Id} - {p.Ip}";
                peerListBox.Items.Add(item);
                if (selectedId != null && p.Id == selectedId)
                {
                    toSelectIndex = index;
                }
                index++;
            }

            // Kiválasztás visszaállítása
            if (toSelectIndex >= 0 && toSelectIndex < peerListBox.Items.Count)
            {
                peerListBox.SelectedIndex = toSelectIndex;
            }
        }


        private void RefreshActiveWindowListBox()
        {
            if (activeWindowsListBox.InvokeRequired)
            {
                activeWindowsListBox.Invoke(new Action(RefreshActiveWindowListBox));
                return;
            }
            activeWindowsListBox.Items.Clear();
            foreach (var peer in peers.Values)
                activeWindowsListBox.Items.Add(WrapText(peer.ActiveWindowTitle, 40));
        }


        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        private string GetActiveWindowTitle()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return string.Empty;
        }

        private string WrapText(string text, int maxLineLength)
        {
            if (string.IsNullOrEmpty(text))
                return "";

            var words = text.Split(' ');
            var lines = new List<string>();
            var currentLine = new StringBuilder();

            foreach (var word in words)
            {
                if (currentLine.Length + word.Length + 1 > maxLineLength)
                {
                    lines.Add(currentLine.ToString());
                    currentLine.Clear();
                }
                if (currentLine.Length > 0)
                    currentLine.Append(' ');
                currentLine.Append(word);
            }
            if (currentLine.Length > 0)
                lines.Add(currentLine.ToString());

            return string.Join(Environment.NewLine, lines);
        }

        private void LoadOrCreateConfig()
        {
            if (File.Exists(ConfigFile))
            {
                var lines = File.ReadAllLines(ConfigFile);
                if (lines.Length >= 3)
                {
                    softwareId = lines[0];
                    pinHash = lines[1];
                    userName = lines[2];
                    txtUserName.Text = userName;
                    return;
                }
            }
            string ipLastSegment = "000";
            try
            {
                foreach (var ni in System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces())
                {
                    var props = ni.GetIPProperties();
                    foreach (var addr in props.UnicastAddresses)
                    {
                        if (addr.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork
                            && !IPAddress.IsLoopback(addr.Address))
                        {
                            var segments = addr.Address.ToString().Split('.');
                            ipLastSegment = segments[^1];
                            break;
                        }
                    }
                    if (ipLastSegment != "000")
                        break;
                }
            }
            catch
            {
                ipLastSegment = "000";
            }
            var rnd = new Random();
            var randomPart = rnd.Next(10, 99);
            softwareId = $"{ipLastSegment}{randomPart}";
            pinHash = Hash("1234");
            userName = "User";
            txtUserName.Text = userName;
            SaveConfig();
        }

        private void SaveConfig()
        {
            File.WriteAllLines(ConfigFile, new[] { softwareId, pinHash, userName });
        }

        private void SavePin(string newPin)
        {
            pinHash = Hash(newPin);
            SaveConfig();
        }

        private string Hash(string input)
        {
            using var sha = System.Security.Cryptography.SHA256.Create();
            return Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(input)));
        }

        private bool ValidatePin(string pin)
        {
            return Hash(pin) == pinHash;
        }

        private void SetLoggedInState(bool loggedIn)
        {
            isLoggedIn = loggedIn;
            txtMessageBox.Enabled = loggedIn;
            btnSendMessage.Enabled = loggedIn;
            peerListBox.Enabled = loggedIn;
            btnRefreshPeers.Enabled = loggedIn;
            txtNewPinBox.Enabled = loggedIn;
            txtNewPinBox.Visible = loggedIn;
            btnSaveSettings.Enabled = loggedIn;
            btnSaveSettings.Visible = loggedIn;
            txtUserName.Enabled = loggedIn;
            txtUserName.Visible = loggedIn;
            lblUserNameLabel.Visible = loggedIn;
            lblNewPinLabel.Visible = loggedIn;
        }

        private void TxtMessageBox_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && isLoggedIn)
            {
                e.SuppressKeyPress = true;
                btnSendMessage_Click(sender!, e);
            }
        }

        private void CleanUpPeers()
        {
            var now = DateTime.Now;
            var toRemove = new List<string>();
            foreach (var peer in peers)
            {
                if (now - peer.Value.LastSeen > TimeSpan.FromMinutes(3))
                    toRemove.Add(peer.Key);
            }
            foreach (var key in toRemove)
            {
                peers.Remove(key);
            }
        }

        private async Task RefreshPeersWithCheckAsync()
        {
            var alivePeers = new Dictionary<string, PeerInfo>();
            foreach (var p in peers)
            {
                if (await IsPeerAlive(p.Value.Ip))
                    alivePeers[p.Key] = p.Value;
            }
            peers = alivePeers;
            if (!string.IsNullOrEmpty(softwareId) && !string.IsNullOrEmpty(userName))
                discovery.Start($"{userName}|{softwareId}|{GetActiveWindowTitle()}");
            RefreshPeerListBox();
        }

        private async Task<bool> IsPeerAlive(string ip, int port = 12456, int timeout = 1000)
        {
            try
            {
                using TcpClient client = new();
                var connectTask = client.ConnectAsync(ip, port);
                return await Task.WhenAny(connectTask, Task.Delay(timeout)) == connectTask && client.Connected;
            }
            catch
            {
                return false;
            }
        }

        private void btnRefreshPeers_Click(object? sender, EventArgs e)
        {
            if (!isLoggedIn)
            {
                MessageBox.Show("Please login first.");
                return;
            }
            _ = RefreshPeersWithCheckAsync();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (ValidatePin(txtPinBox.Text))
            {
                SetLoggedInState(true);
                MessageBox.Show("Login successful!");
                txtPinBox.Text = "";
                txtPinBox.Visible = false;
                btnLogin.Visible = false;
                if (string.IsNullOrWhiteSpace(txtUserName.Text))
                    txtUserName.Text = "User";
            }
            else
            {
                MessageBox.Show("Incorrect PIN!");
            }
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            if (!isLoggedIn)
            {
                MessageBox.Show("Please login first.");
                return;
            }
            string newName = txtUserName.Text.Trim();
            if (string.IsNullOrEmpty(newName))
            {
                MessageBox.Show("User name cannot be empty.");
                return;
            }
            userName = newName;
            string newPin = txtNewPinBox.Text.Trim();
            if (!string.IsNullOrEmpty(newPin))
            {
                if (newPin.Length == 4)
                {
                    SavePin(newPin);
                    MessageBox.Show("PIN changed!");
                    txtNewPinBox.Text = "";
                }
                else
                {
                    MessageBox.Show("PIN must be exactly 4 digits!");
                    return;
                }
            }
            SaveConfig();
            MessageBox.Show("Settings saved!");
        }

        private async Task SendLogoutMessage()
        {
            if (!isLoggedIn) return;
            string logoutMsg = $"SYSTEM|{userName}|LOGOUT";
            foreach (var peer in peers.Values)
            {
                try
                {
                    await client.SendMessage(peer.Ip, logoutMsg);
                }
                catch
                {
                    // hibakezelés
                }
            }
        }

        private async void btnExit_Click(object sender, EventArgs e)
        {
            if (isLoggedIn)
            {
                await SendLogoutMessage();
            }
            Application.Exit();
        }

        private async void btnSendMessage_Click(object sender, EventArgs e)
        {
            if (!isLoggedIn)
            {
                MessageBox.Show("Please login first.");
                return;
            }
            if (string.IsNullOrWhiteSpace(userName))
            {
                MessageBox.Show("Please save your user name before sending messages.");
                return;
            }
            var selectedItem = peerListBox.SelectedItem;
            if (selectedItem == null)
            {
                MessageBox.Show("Select a peer from the list!");
                return;
            }
            string selected = selectedItem.ToString() ?? "";
            string[] parts = selected.Split(new string[] { " - " }, StringSplitOptions.None);
            if (parts.Length < 3)
            {
                MessageBox.Show("Invalid peer format.");
                return;
            }
            string name = parts[0];
            string id = parts[1];
            string ip = parts[2];
            if (id == softwareId)
            {
                MessageBox.Show("You cannot send a message to yourself.");
                return;
            }
            string message = txtMessageBox?.Text?.Trim() ?? "";
            if (string.IsNullOrEmpty(message))
            {
                MessageBox.Show("Enter a message!");
                return;
            }
            try
            {
                string fullMsg = $"{userName} ({softwareId}) -> {message}";
                await client.SendMessage(ip, $"{userName}|{softwareId}|{message}");
                txtMessageBox.Text = "";
                uiShowChat(fullMsg, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Send failure: {ex.Message}");
            }
        }

        private void OnMessageReceived(string rawMessage)
        {
            if (!isLoggedIn) return;
            try
            {
                notifyPlayer.Play();
            }
            catch { }
            var parts = rawMessage.Split(new char[] { '|' }, 3);
            if (parts.Length < 3) return;
            if (parts[0] == "SYSTEM" && parts[2] == "LOGOUT")
            {
                RemovePeerByName(parts[1]);
                return;
            }
            string senderName = parts[0];
            string senderId = parts[1];
            string message = parts[2];
            string displayMessage = $"{senderName} ({senderId}) -> {message}";
            uiShowChat(displayMessage, false);
        }

        private void RemovePeerByName(string name)
        {
            string keyToRemove = null;
            foreach (var kvp in peers)
            {
                if (kvp.Value.Name == name)
                {
                    keyToRemove = kvp.Key;
                    break;
                }
            }
            if (keyToRemove != null)
            {
                peers.Remove(keyToRemove);
                RefreshPeerListBox();
            }
        }

        private void uiShowChat(string msg, bool isSent)
        {
            chatRichTextBox.Invoke((Action)(() =>
            {
                int start = chatRichTextBox.TextLength;
                chatRichTextBox.AppendText(msg + Environment.NewLine);
                int end = chatRichTextBox.TextLength;
                chatRichTextBox.Select(start, end - start);
                chatRichTextBox.SelectionBackColor = isSent ? System.Drawing.Color.LightGray : System.Drawing.Color.White;
                chatRichTextBox.SelectionLength = 0;
                chatRichTextBox.ScrollToCaret();
            }));
        }


    }
}
