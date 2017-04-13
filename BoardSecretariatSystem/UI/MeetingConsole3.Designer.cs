namespace BoardSecretariatSystem.UI
{
    partial class MeetingConsole3
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMeetingNumber = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonAdditionalParticipant = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.buttonComplete = new System.Windows.Forms.Button();
            this.buttonInvitation = new System.Windows.Forms.Button();
            this.txtMeetingTitle = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(299, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(529, 93);
            this.label1.TabIndex = 0;
            this.label1.Text = "                     Meeting Console 3\r\nMeeting Notice and Invitation Management " +
    "\r\n                     (During Invitation)\r\n";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Magenta;
            this.label2.Location = new System.Drawing.Point(27, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Meeting Number/ ID :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(15, 394);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(207, 26);
            this.label3.TabIndex = 3;
            this.label3.Text = "List Of Participant";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(709, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(296, 26);
            this.label4.TabIndex = 2;
            this.label4.Text = "Additional  Participant List\r\n";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Magenta;
            this.label8.Location = new System.Drawing.Point(-3, 196);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 26);
            this.label8.TabIndex = 6;
            // 
            // txtMeetingNumber
            // 
            this.txtMeetingNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtMeetingNumber.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMeetingNumber.ForeColor = System.Drawing.Color.Blue;
            this.txtMeetingNumber.Location = new System.Drawing.Point(279, 128);
            this.txtMeetingNumber.Name = "txtMeetingNumber";
            this.txtMeetingNumber.Size = new System.Drawing.Size(316, 29);
            this.txtMeetingNumber.TabIndex = 8;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column5,
            this.Column1});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dataGridView1.Location = new System.Drawing.Point(644, 178);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(533, 302);
            this.dataGridView1.TabIndex = 15;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Id";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 5;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Name";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 290;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Type/Title";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 160;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(14, 431);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(565, 219);
            this.listView1.TabIndex = 16;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Participant Id";
            this.columnHeader1.Width = 143;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Participant Name";
            this.columnHeader2.Width = 235;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Participant Type";
            this.columnHeader3.Width = 179;
            // 
            // buttonAdditionalParticipant
            // 
            this.buttonAdditionalParticipant.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonAdditionalParticipant.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdditionalParticipant.ForeColor = System.Drawing.Color.Fuchsia;
            this.buttonAdditionalParticipant.Location = new System.Drawing.Point(279, 201);
            this.buttonAdditionalParticipant.Name = "buttonAdditionalParticipant";
            this.buttonAdditionalParticipant.Size = new System.Drawing.Size(316, 41);
            this.buttonAdditionalParticipant.TabIndex = 17;
            this.buttonAdditionalParticipant.Text = "Additional Participant";
            this.buttonAdditionalParticipant.UseVisualStyleBackColor = false;
            this.buttonAdditionalParticipant.Click += new System.EventHandler(this.buttonAdditionalParticipant_Click);
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.addButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.ForeColor = System.Drawing.Color.Blue;
            this.addButton.Location = new System.Drawing.Point(279, 249);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(316, 45);
            this.addButton.TabIndex = 18;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonComplete
            // 
            this.buttonComplete.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonComplete.Location = new System.Drawing.Point(279, 304);
            this.buttonComplete.Name = "buttonComplete";
            this.buttonComplete.Size = new System.Drawing.Size(316, 41);
            this.buttonComplete.TabIndex = 19;
            this.buttonComplete.Text = "Complete";
            this.buttonComplete.UseVisualStyleBackColor = true;
            this.buttonComplete.Click += new System.EventHandler(this.buttonComplete_Click);
            // 
            // buttonInvitation
            // 
            this.buttonInvitation.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInvitation.Location = new System.Drawing.Point(279, 351);
            this.buttonInvitation.Name = "buttonInvitation";
            this.buttonInvitation.Size = new System.Drawing.Size(316, 41);
            this.buttonInvitation.TabIndex = 20;
            this.buttonInvitation.Text = "MailSend";
            this.buttonInvitation.UseVisualStyleBackColor = true;
            this.buttonInvitation.Click += new System.EventHandler(this.buttonInvitation_Click);
            // 
            // txtMeetingTitle
            // 
            this.txtMeetingTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtMeetingTitle.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMeetingTitle.ForeColor = System.Drawing.Color.Blue;
            this.txtMeetingTitle.Location = new System.Drawing.Point(279, 166);
            this.txtMeetingTitle.Name = "txtMeetingTitle";
            this.txtMeetingTitle.Size = new System.Drawing.Size(316, 29);
            this.txtMeetingTitle.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Magenta;
            this.label5.Location = new System.Drawing.Point(109, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 26);
            this.label5.TabIndex = 21;
            this.label5.Text = "Meeting Title";
            // 
            // MeetingConsole3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Olive;
            this.ClientSize = new System.Drawing.Size(1232, 674);
            this.Controls.Add(this.txtMeetingTitle);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonInvitation);
            this.Controls.Add(this.buttonComplete);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.buttonAdditionalParticipant);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtMeetingNumber);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "MeetingConsole3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Meeting Invitation";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MeetingConsole3_FormClosed);
            this.Load += new System.EventHandler(this.MeetingConsole3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMeetingNumber;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button buttonAdditionalParticipant;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Button buttonComplete;
        private System.Windows.Forms.Button buttonInvitation;
        public  System.Windows.Forms.TextBox txtMeetingTitle;
        private System.Windows.Forms.Label label5;
    }
}