namespace TerminalDecay5Client
{
    partial class Messages
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
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lstMessages = new System.Windows.Forms.ListBox();
            this.btnRefreshMessages = new System.Windows.Forms.Button();
            this.ListContacts = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(942, 487);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(96, 23);
            this.btnSendMessage.TabIndex = 179;
            this.btnSendMessage.Text = "Send Message";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(525, 115);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(513, 354);
            this.txtMessage.TabIndex = 178;
            this.txtMessage.Text = "Message";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(525, 75);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(513, 20);
            this.txtTitle.TabIndex = 177;
            this.txtTitle.Text = "Title";
            // 
            // lstMessages
            // 
            this.lstMessages.FormattingEnabled = true;
            this.lstMessages.Location = new System.Drawing.Point(21, 75);
            this.lstMessages.Name = "lstMessages";
            this.lstMessages.Size = new System.Drawing.Size(485, 433);
            this.lstMessages.TabIndex = 180;
            // 
            // btnRefreshMessages
            // 
            this.btnRefreshMessages.Location = new System.Drawing.Point(157, 27);
            this.btnRefreshMessages.Name = "btnRefreshMessages";
            this.btnRefreshMessages.Size = new System.Drawing.Size(96, 23);
            this.btnRefreshMessages.TabIndex = 181;
            this.btnRefreshMessages.Text = "Refresh";
            this.btnRefreshMessages.UseVisualStyleBackColor = true;
            this.btnRefreshMessages.Click += new System.EventHandler(this.btnRefreshMessages_Click);
            // 
            // ListContacts
            // 
            this.ListContacts.FormattingEnabled = true;
            this.ListContacts.Location = new System.Drawing.Point(601, 27);
            this.ListContacts.Name = "ListContacts";
            this.ListContacts.Size = new System.Drawing.Size(423, 21);
            this.ListContacts.TabIndex = 182;
            // 
            // Messages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 522);
            this.Controls.Add(this.ListContacts);
            this.Controls.Add(this.btnRefreshMessages);
            this.Controls.Add(this.lstMessages);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtTitle);
            this.Name = "Messages";
            this.Text = "Messages";
            this.Load += new System.EventHandler(this.Messages_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.ListBox lstMessages;
        private System.Windows.Forms.Button btnRefreshMessages;
        private System.Windows.Forms.ComboBox ListContacts;
    }
}