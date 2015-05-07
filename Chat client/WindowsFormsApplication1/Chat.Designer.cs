namespace Chat_client
{
    partial class Chat
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
            this.connBtn = new System.Windows.Forms.Button();
            this.sendBtn = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // connBtn
            // 
            this.connBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.connBtn.Location = new System.Drawing.Point(528, 47);
            this.connBtn.Name = "connBtn";
            this.connBtn.Size = new System.Drawing.Size(75, 24);
            this.connBtn.TabIndex = 0;
            this.connBtn.Text = "Connect";
            this.connBtn.UseVisualStyleBackColor = true;
            this.connBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // sendBtn
            // 
            this.sendBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sendBtn.Location = new System.Drawing.Point(528, 426);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(75, 25);
            this.sendBtn.TabIndex = 1;
            this.sendBtn.Text = "Send";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox3
            // 
            this.textBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox3.Location = new System.Drawing.Point(12, 21);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(591, 20);
            this.textBox3.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox2.Location = new System.Drawing.Point(12, 77);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(591, 250);
            this.textBox2.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox1.Location = new System.Drawing.Point(12, 345);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(591, 75);
            this.textBox1.TabIndex = 4;
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 461);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.connBtn);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Chat";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Chat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connBtn;
        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
    }
}

