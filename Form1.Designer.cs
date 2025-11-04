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
        private System.Windows.Forms.RichTextBox chatRichTextBox;
        private System.Windows.Forms.TextBox txtNewPinBox;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.TextBox txtMessageBox;
        private System.Windows.Forms.Label lblSoftwareId;
        private System.Windows.Forms.Label lblPeers;
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
            this.txtPinBox = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnRefreshPeers = new System.Windows.Forms.Button();
            this.peerListBox = new System.Windows.Forms.ListBox();
            this.chatRichTextBox = new System.Windows.Forms.RichTextBox();
            this.txtNewPinBox = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.txtMessageBox = new System.Windows.Forms.TextBox();
            this.lblSoftwareId = new System.Windows.Forms.Label();
            this.lblPeers = new System.Windows.Forms.Label();
            this.lblChat = new System.Windows.Forms.Label();
            this.lblUserNameLabel = new System.Windows.Forms.Label();
            this.lblNewPinLabel = new System.Windows.Forms.Label();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();

            // txtPinBox
            this.txtPinBox.Location = new System.Drawing.Point(20, 20);
            this.txtPinBox.MaxLength = 4;
            this.txtPinBox.Name = "txtPinBox";
            this.txtPinBox.Size = new System.Drawing.Size(100, 22);

            // btnLogin
            this.btnLogin.Location = new System.Drawing.Point(130, 18);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(100, 25);
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // btnRefreshPeers
            this.btnRefreshPeers.Location = new System.Drawing.Point(20, 60);
            this.btnRefreshPeers.Name = "btnRefreshPeers";
            this.btnRefreshPeers.Size = new System.Drawing.Size(210, 25);
            this.btnRefreshPeers.Text = "Refresh Peers";
            this.btnRefreshPeers.UseVisualStyleBackColor = true;
            this.btnRefreshPeers.Click += new System.EventHandler(this.btnRefreshPeers_Click);

            // peerListBox
            this.peerListBox.Location = new System.Drawing.Point(250, 40);
            this.peerListBox.Name = "peerListBox";
            this.peerListBox.Size = new System.Drawing.Size(250, 110);

            // chatRichTextBox
            this.chatRichTextBox.Location = new System.Drawing.Point(250, 180);
            this.chatRichTextBox.Name = "chatRichTextBox";
            this.chatRichTextBox.ReadOnly = true;
            this.chatRichTextBox.Size = new System.Drawing.Size(400, 105);
            this.chatRichTextBox.TabStop = false;

            // txtNewPinBox
            this.txtNewPinBox.Location = new System.Drawing.Point(20, 190);
            this.txtNewPinBox.MaxLength = 4;
            this.txtNewPinBox.Name = "txtNewPinBox";
            this.txtNewPinBox.Size = new System.Drawing.Size(210, 22);
            this.txtNewPinBox.Visible = false;

            // txtUserName
            this.txtUserName.Location = new System.Drawing.Point(20, 140);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(210, 22);
            this.txtUserName.Visible = false;

            // btnSendMessage
            this.btnSendMessage.Location = new System.Drawing.Point(560, 300);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(90, 25);
            this.btnSendMessage.Text = "Send Message";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);

            // btnSaveSettings
            this.btnSaveSettings.Location = new System.Drawing.Point(20, 220);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(210, 25);
            this.btnSaveSettings.Text = "Save";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Visible = false;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);

            // txtMessageBox
            this.txtMessageBox.Location = new System.Drawing.Point(250, 300);
            this.txtMessageBox.Name = "txtMessageBox";
            this.txtMessageBox.Size = new System.Drawing.Size(300, 22);

            // lblSoftwareId
            this.lblSoftwareId.AutoSize = true;
            this.lblSoftwareId.Location = new System.Drawing.Point(10, 10);
            this.lblSoftwareId.Name = "lblSoftwareId";

            // lblPeers
            this.lblPeers.Location = new System.Drawing.Point(250, 20);
            this.lblPeers.Name = "lblPeers";
            this.lblPeers.Size = new System.Drawing.Size(250, 20);
            this.lblPeers.Text = "Peers Found";

            // lblChat
            this.lblChat.Location = new System.Drawing.Point(250, 160);
            this.lblChat.Name = "lblChat";
            this.lblChat.Size = new System.Drawing.Size(250, 20);
            this.lblChat.Text = "Chat Messages";

            // lblUserNameLabel
            this.lblUserNameLabel.AutoSize = true;
            this.lblUserNameLabel.Location = new System.Drawing.Point(20, 120);
            this.lblUserNameLabel.Name = "lblUserNameLabel";
            this.lblUserNameLabel.Size = new System.Drawing.Size(44, 16);
            this.lblUserNameLabel.Text = "Name:";
            this.lblUserNameLabel.Visible = false;

            // lblNewPinLabel
            this.lblNewPinLabel.AutoSize = true;
            this.lblNewPinLabel.Location = new System.Drawing.Point(20, 170);
            this.lblNewPinLabel.Name = "lblNewPinLabel";
            this.lblNewPinLabel.Size = new System.Drawing.Size(55, 16);
            this.lblNewPinLabel.Text = "New PIN:";
            this.lblNewPinLabel.Visible = false;

            // bottomPanel
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Height = 40;
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Controls.Add(this.lblSoftwareId);
            this.bottomPanel.Controls.Add(this.btnExit);

            // btnExit
            this.btnExit.Location = new System.Drawing.Point(550, 7);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 25);
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);

            // Controls hozzáadása
            this.Controls.Add(this.txtPinBox);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnRefreshPeers);
            this.Controls.Add(this.peerListBox);
            this.Controls.Add(this.chatRichTextBox);
            this.Controls.Add(this.txtNewPinBox);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.btnSaveSettings);
            this.Controls.Add(this.txtMessageBox);
            this.Controls.Add(this.lblUserNameLabel);
            this.Controls.Add(this.lblNewPinLabel);
            this.Controls.Add(this.bottomPanel);

            this.ClientSize = new System.Drawing.Size(670, 380);
            this.Name = "Form1";
            this.Text = "PNChat";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
