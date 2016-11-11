namespace OpenTale.Client.Forms
{
    partial class ChannelSelection
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.serverListBox = new System.Windows.Forms.ListBox();
            this.channelListBox = new System.Windows.Forms.ListBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // serverListBox
            // 
            this.serverListBox.FormattingEnabled = true;
            this.serverListBox.ItemHeight = 20;
            this.serverListBox.Location = new System.Drawing.Point(12, 12);
            this.serverListBox.Name = "serverListBox";
            this.serverListBox.Size = new System.Drawing.Size(243, 244);
            this.serverListBox.TabIndex = 1;
            this.serverListBox.SelectedIndexChanged += new System.EventHandler(this.serverListBox_SelectedIndexChanged);
            // 
            // channelListBox
            // 
            this.channelListBox.FormattingEnabled = true;
            this.channelListBox.ItemHeight = 20;
            this.channelListBox.Location = new System.Drawing.Point(261, 12);
            this.channelListBox.Name = "channelListBox";
            this.channelListBox.Size = new System.Drawing.Size(202, 244);
            this.channelListBox.TabIndex = 2;
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(12, 262);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(451, 75);
            this.connectButton.TabIndex = 3;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // ChannelSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 349);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.channelListBox);
            this.Controls.Add(this.serverListBox);
            this.Name = "ChannelSelection";
            this.Text = "ChannelSelection";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox serverListBox;
        private System.Windows.Forms.ListBox channelListBox;
        private System.Windows.Forms.Button connectButton;
    }
}