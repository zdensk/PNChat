namespace PNChat
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtPinBox;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnRefreshPeers;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ListBox peerListBox;
        private System.Windows.Forms.ListBox activeWindowsListBox; // Új listbox
        private System.Windows.Forms.RichTextBox chatRichTextBox;
        private System.Windows.Forms.TextBox txtNewPinBox;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.TextBox txtMessageBox;
        private System.Windows.Forms.Label lblSoftwareId;
        private System.Windows.Forms.Label lblPeers;
        private System.Windows.Forms.Label lblActiveWindows; // Új címke
        private System.Windows.Forms.Label lblChat;
        private System.Windows.Forms.Label lblUserNameLabel;
        private System.Windows.Forms.Label lblNewPinLabel;
        private System.Windows.Forms.Panel bottomPanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtPinBox = new TextBox();
            btnLogin = new Button();
            btnRefreshPeers = new Button();
            peerListBox = new ListBox();
            activeWindowsListBox = new ListBox();
            chatRichTextBox = new RichTextBox();
            txtNewPinBox = new TextBox();
            txtUserName = new TextBox();
            btnSendMessage = new Button();
            btnSaveSettings = new Button();
            txtMessageBox = new TextBox();
            lblSoftwareId = new Label();
            lblPeers = new Label();
            lblActiveWindows = new Label();
            lblChat = new Label();
            lblUserNameLabel = new Label();
            lblNewPinLabel = new Label();
            bottomPanel = new Panel();
            btnExit = new Button();
            bottomPanel.SuspendLayout();
            SuspendLayout();
            // 
            // txtPinBox
            // 
            txtPinBox.Location = new Point(20, 40);
            txtPinBox.MaxLength = 4;
            txtPinBox.Name = "txtPinBox";
            txtPinBox.Size = new Size(100, 23);
            txtPinBox.TabIndex = 0;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(130, 38);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(100, 25);
            btnLogin.TabIndex = 1;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnRefreshPeers
            // 
            btnRefreshPeers.Location = new Point(20, 78);
            btnRefreshPeers.Name = "btnRefreshPeers";
            btnRefreshPeers.Size = new Size(210, 25);
            btnRefreshPeers.TabIndex = 2;
            btnRefreshPeers.Text = "Refresh Peers";
            btnRefreshPeers.UseVisualStyleBackColor = true;
            btnRefreshPeers.Click += btnRefreshPeers_Click;
            // 
            // peerListBox
            // 
            peerListBox.ItemHeight = 15;
            peerListBox.Location = new Point(250, 40);
            peerListBox.Name = "peerListBox";
            peerListBox.Size = new Size(250, 109);
            peerListBox.TabIndex = 3;
            // 
            // activeWindowsListBox
            // 
            activeWindowsListBox.ItemHeight = 15;
            activeWindowsListBox.Location = new Point(520, 40);
            activeWindowsListBox.Name = "activeWindowsListBox";
            activeWindowsListBox.Size = new Size(433, 109);
            activeWindowsListBox.TabIndex = 4;
            // 
            // chatRichTextBox
            // 
            chatRichTextBox.Location = new Point(250, 180);
            chatRichTextBox.Name = "chatRichTextBox";
            chatRichTextBox.ReadOnly = true;
            chatRichTextBox.Size = new Size(703, 105);
            chatRichTextBox.TabIndex = 5;
            chatRichTextBox.TabStop = false;
            chatRichTextBox.Text = "";
            // 
            // txtNewPinBox
            // 
            txtNewPinBox.Location = new Point(20, 237);
            txtNewPinBox.MaxLength = 4;
            txtNewPinBox.Name = "txtNewPinBox";
            txtNewPinBox.Size = new Size(210, 23);
            txtNewPinBox.TabIndex = 6;
            txtNewPinBox.Visible = false;
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(20, 180);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(210, 23);
            txtUserName.TabIndex = 7;
            txtUserName.Visible = false;
            // 
            // btnSendMessage
            // 
            btnSendMessage.Location = new Point(863, 300);
            btnSendMessage.Name = "btnSendMessage";
            btnSendMessage.Size = new Size(90, 23);
            btnSendMessage.TabIndex = 8;
            btnSendMessage.Text = "Send Message";
            btnSendMessage.UseVisualStyleBackColor = true;
            btnSendMessage.Click += btnSendMessage_Click;
            // 
            // btnSaveSettings
            // 
            btnSaveSettings.Location = new Point(20, 298);
            btnSaveSettings.Name = "btnSaveSettings";
            btnSaveSettings.Size = new Size(210, 25);
            btnSaveSettings.TabIndex = 9;
            btnSaveSettings.Text = "Save";
            btnSaveSettings.UseVisualStyleBackColor = true;
            btnSaveSettings.Visible = false;
            btnSaveSettings.Click += btnSaveSettings_Click;
            // 
            // txtMessageBox
            // 
            txtMessageBox.Location = new Point(250, 300);
            txtMessageBox.Name = "txtMessageBox";
            txtMessageBox.Size = new Size(607, 23);
            txtMessageBox.TabIndex = 10;
            // 
            // lblSoftwareId
            // 
            lblSoftwareId.AutoSize = true;
            lblSoftwareId.Location = new Point(10, 10);
            lblSoftwareId.Name = "lblSoftwareId";
            lblSoftwareId.Size = new Size(0, 15);
            lblSoftwareId.TabIndex = 0;
            // 
            // lblPeers
            // 
            lblPeers.Location = new Point(250, 20);
            lblPeers.Name = "lblPeers";
            lblPeers.Size = new Size(250, 20);
            lblPeers.TabIndex = 13;
            lblPeers.Text = "Peers Found";
            // 
            // lblActiveWindows
            // 
            lblActiveWindows.Location = new Point(520, 20);
            lblActiveWindows.Name = "lblActiveWindows";
            lblActiveWindows.Size = new Size(250, 20);
            lblActiveWindows.TabIndex = 14;
            lblActiveWindows.Text = "Active Windows";
            // 
            // lblChat
            // 
            lblChat.Location = new Point(250, 160);
            lblChat.Name = "lblChat";
            lblChat.Size = new Size(250, 20);
            lblChat.TabIndex = 15;
            lblChat.Text = "Chat Messages";
            // 
            // lblUserNameLabel
            // 
            lblUserNameLabel.AutoSize = true;
            lblUserNameLabel.Location = new Point(20, 160);
            lblUserNameLabel.Name = "lblUserNameLabel";
            lblUserNameLabel.Size = new Size(42, 15);
            lblUserNameLabel.TabIndex = 11;
            lblUserNameLabel.Text = "Name:";
            lblUserNameLabel.Visible = false;
            // 
            // lblNewPinLabel
            // 
            lblNewPinLabel.AutoSize = true;
            lblNewPinLabel.Location = new Point(20, 219);
            lblNewPinLabel.Name = "lblNewPinLabel";
            lblNewPinLabel.Size = new Size(56, 15);
            lblNewPinLabel.TabIndex = 12;
            lblNewPinLabel.Text = "New PIN:";
            lblNewPinLabel.Visible = false;
            // 
            // bottomPanel
            // 
            bottomPanel.Controls.Add(lblSoftwareId);
            bottomPanel.Controls.Add(btnExit);
            bottomPanel.Dock = DockStyle.Bottom;
            bottomPanel.Location = new Point(0, 357);
            bottomPanel.Name = "bottomPanel";
            bottomPanel.Size = new Size(1034, 40);
            bottomPanel.TabIndex = 16;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(863, 10);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(90, 20);
            btnExit.TabIndex = 1;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // Form1
            // 
            ClientSize = new Size(1034, 397);
            Controls.Add(txtPinBox);
            Controls.Add(btnLogin);
            Controls.Add(btnRefreshPeers);
            Controls.Add(peerListBox);
            Controls.Add(activeWindowsListBox);
            Controls.Add(chatRichTextBox);
            Controls.Add(txtNewPinBox);
            Controls.Add(txtUserName);
            Controls.Add(btnSendMessage);
            Controls.Add(btnSaveSettings);
            Controls.Add(txtMessageBox);
            Controls.Add(lblUserNameLabel);
            Controls.Add(lblNewPinLabel);
            Controls.Add(lblPeers);
            Controls.Add(lblActiveWindows);
            Controls.Add(lblChat);
            Controls.Add(bottomPanel);
            Name = "Form1";
            Text = "PNChat";
            bottomPanel.ResumeLayout(false);
            bottomPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
