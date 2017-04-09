namespace BoardSecretariatSystem.UI
{
    partial class MailSend
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBody = new System.Windows.Forms.RichTextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cmbDomainHostName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(85, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sender  Mail";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(175, 367);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "To";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(136, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Subject";
            // 
            // txtFrom
            // 
            this.txtFrom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFrom.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFrom.Location = new System.Drawing.Point(219, 33);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.ReadOnly = true;
            this.txtFrom.Size = new System.Drawing.Size(457, 32);
            this.txtFrom.TabIndex = 3;
            this.txtFrom.TextChanged += new System.EventHandler(this.txtFrom_TextChanged);
            // 
            // txtSubject
            // 
            this.txtSubject.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubject.Location = new System.Drawing.Point(219, 171);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.ReadOnly = true;
            this.txtSubject.Size = new System.Drawing.Size(457, 39);
            this.txtSubject.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Yellow;
            this.label4.Location = new System.Drawing.Point(146, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "Body";
            // 
            // txtBody
            // 
            this.txtBody.Location = new System.Drawing.Point(217, 226);
            this.txtBody.Name = "txtBody";
            this.txtBody.Size = new System.Drawing.Size(529, 118);
            this.txtBody.TabIndex = 9;
            this.txtBody.Text = "";
            // 
            // sendButton
            // 
            this.sendButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.sendButton.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendButton.ForeColor = System.Drawing.Color.Blue;
            this.sendButton.Location = new System.Drawing.Point(582, 580);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(147, 52);
            this.sendButton.TabIndex = 10;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = false;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Yellow;
            this.label7.Location = new System.Drawing.Point(6, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(195, 22);
            this.label7.TabIndex = 11;
            this.label7.Text = "Sender Mail Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(219, 72);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(457, 35);
            this.txtPassword.TabIndex = 12;
            // 
            // cmbDomainHostName
            // 
            this.cmbDomainHostName.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDomainHostName.FormattingEnabled = true;
            this.cmbDomainHostName.Location = new System.Drawing.Point(219, 113);
            this.cmbDomainHostName.Name = "cmbDomainHostName";
            this.cmbDomainHostName.Size = new System.Drawing.Size(397, 39);
            this.cmbDomainHostName.TabIndex = 14;
            this.cmbDomainHostName.SelectedIndexChanged += new System.EventHandler(this.cmbDomainHostName_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Yellow;
            this.label5.Location = new System.Drawing.Point(0, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(211, 22);
            this.label5.TabIndex = 15;
            this.label5.Text = "Sender Mail Host Name:";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.Location = new System.Drawing.Point(216, 364);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(458, 208);
            this.listView1.TabIndex = 16;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 9;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "BankEmailId";
            this.columnHeader2.Width = 140;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "EmailAddress";
            this.columnHeader3.Width = 252;
            // 
            // MailSend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.ClientSize = new System.Drawing.Size(758, 644);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbDomainHostName);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.txtBody);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MinimizeBox = false;
            this.Name = "MailSend";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MailSend";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MailSend_FormClosed);
            this.Load += new System.EventHandler(this.MailSend_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox txtBody;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ComboBox cmbDomainHostName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}