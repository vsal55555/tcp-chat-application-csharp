namespace ClientApp
{
    partial class frmChat
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
            lstUsers = new ListBox();
            rtfLog = new RichTextBox();
            txtMessage = new TextBox();
            btnSend = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // lstUsers
            // 
            lstUsers.FormattingEnabled = true;
            lstUsers.Location = new Point(12, 27);
            lstUsers.Name = "lstUsers";
            lstUsers.Size = new Size(222, 409);
            lstUsers.TabIndex = 0;
            // 
            // rtfLog
            // 
            rtfLog.Location = new Point(252, 27);
            rtfLog.Name = "rtfLog";
            rtfLog.ReadOnly = true;
            rtfLog.Size = new Size(536, 380);
            rtfLog.TabIndex = 1;
            rtfLog.Text = "";
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(252, 415);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(455, 23);
            txtMessage.TabIndex = 2;
            // 
            // btnSend
            // 
            btnSend.Enabled = false;
            btnSend.Location = new Point(713, 413);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(75, 23);
            btnSend.TabIndex = 3;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(35, 15);
            label1.TabIndex = 4;
            label1.Text = "Users";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(252, 9);
            label2.Name = "label2";
            label2.Size = new Size(32, 15);
            label2.TabIndex = 4;
            label2.Text = "Chat";
            // 
            // frmChat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnSend);
            Controls.Add(txtMessage);
            Controls.Add(rtfLog);
            Controls.Add(lstUsers);
            MinimizeBox = false;
            Name = "frmChat";
            StartPosition = FormStartPosition.CenterParent;
            Text = "frmChat";
            Load += frmChat_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstUsers;
        private RichTextBox rtfLog;
        private TextBox txtMessage;
        private Button btnSend;
        private Label label1;
        private Label label2;
    }
}