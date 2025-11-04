using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PNChat
{
    public class PeerDiscovery
    {
        public event Action<string, string>? PeerFound = delegate { };

        private UdpClient udpClient = new UdpClient();
        private const int DiscoveryPort = 12456;
        private bool listening = false;

        public void Start(string? softwareId)
        {
            if (string.IsNullOrEmpty(softwareId)) return;

            if (!listening)
            {
                listening = true;
                Task.Run(() => ListenForPeers());
            }

            BroadcastDiscovery(softwareId);
        }

        private async Task ListenForPeers()
        {
            try
            {
                udpClient = new UdpClient(DiscoveryPort);
                while (listening)
                {
                    var result = await udpClient.ReceiveAsync();
                    string message = Encoding.UTF8.GetString(result.Buffer);
                    PeerFound?.Invoke(message, result.RemoteEndPoint.Address.ToString());
                }
            }
            catch
            {
                // kezelni kell a hibákat pl. logolás, újraindítás, stb.
            }
        }

        private void BroadcastDiscovery(string softwareId)
        {
            try
            {
                var message = Encoding.UTF8.GetBytes(softwareId);
                udpClient.Send(message, message.Length, new IPEndPoint(IPAddress.Broadcast, DiscoveryPort));
            }
            catch
            {
                // kezelés, például log
            }
        }
    }
}
