namespace BoardSecretariatSystem
{
    partial class MeetingEntry
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
            this.saveButton = new System.Windows.Forms.Button();
            this.meetingListGroupBox = new System.Windows.Forms.GroupBox();
            this.txtMeetingTitle = new System.Windows.Forms.TextBox();
            this.txtMeetingNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.removeButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.meetingListGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.saveButton.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(818, 537);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(190, 69);
            this.saveButton.TabIndex = 18;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // meetingListGroupBox
            // 
            this.meetingListGroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.meetingListGroupBox.Controls.Add(this.txtMeetingTitle);
            this.meetingListGroupBox.Controls.Add(this.txtMeetingNumber);
            this.meetingListGroupBox.Controls.Add(this.label2);
            this.meetingListGroupBox.Controls.Add(this.label1);
            this.meetingListGroupBox.Controls.Add(this.removeButton);
            this.meetingListGroupBox.Controls.Add(this.label8);
            this.meetingListGroupBox.Controls.Add(this.label6);
            this.meetingListGroupBox.Controls.Add(this.groupBox1);
            this.meetingListGroupBox.Controls.Add(this.addButton);
            this.meetingListGroupBox.Controls.Add(this.groupBox2);
            this.meetingListGroupBox.Controls.Add(this.saveButton);
            this.meetingListGroupBox.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.meetingListGroupBox.ForeColor = System.Drawing.Color.Blue;
            this.meetingListGroupBox.Location = new System.Drawing.Point(10, -6);
            this.meetingListGroupBox.Name = "meetingListGroupBox";
            this.meetingListGroupBox.Size = new System.Drawing.Size(1338, 798);
            this.meetingListGroupBox.TabIndex = 26;
            this.meetingListGroupBox.TabStop = false;
            this.meetingListGroupBox.Enter += new System.EventHandler(this.meetingListGroupBox_Enter);
            // 
            // txtMeetingTitle
            // 
            this.txtMeetingTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtMeetingTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMeetingTitle.ForeColor = System.Drawing.Color.Blue;
            this.txtMeetingTitle.Location = new System.Drawing.Point(226, 108);
            this.txtMeetingTitle.Name = "txtMeetingTitle";
            this.txtMeetingTitle.ReadOnly = true;
            this.txtMeetingTitle.Size = new System.Drawing.Size(294, 32);
            this.txtMeetingTitle.TabIndex = 65;
            // 
            // txtMeetingNumber
            // 
            this.txtMeetingNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtMeetingNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMeetingNumber.ForeColor = System.Drawing.Color.Blue;
            this.txtMeetingNumber.Location = new System.Drawing.Point(228, 59);
            this.txtMeetingNumber.Name = "txtMeetingNumber";
            this.txtMeetingNumber.ReadOnly = true;
            this.txtMeetingNumber.Size = new System.Drawing.Size(292, 32);
            this.txtMeetingNumber.TabIndex = 64;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 31);
            this.label2.TabIndex = 63;
            this.label2.Text = "Meeting Title:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 31);
            this.label1.TabIndex = 62;
            this.label1.Text = "Meeting Number:";
            // 
            // removeButton
            // 
            this.removeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.removeButton.ForeColor = System.Drawing.Color.Blue;
            this.removeButton.Location = new System.Drawing.Point(574, 185);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(118, 48);
            this.removeButton.TabIndex = 61;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = false;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(538, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(251, 36);
            this.label8.TabIndex = 56;
            this.label8.Text = "Agenda Selection";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Magenta;
            this.label6.Location = new System.Drawing.Point(713, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 24);
            this.label6.TabIndex = 55;
            this.label6.Text = "Agenda Bank";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 248);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(676, 358);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader5,
            this.columnHeader6});
            this.listView1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(12, 21);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(650, 331);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 6;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Agenda Header";
            this.columnHeader2.Width = 124;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Agenda Title";
            this.columnHeader3.Width = 203;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "AgendaType";
            this.columnHeader5.Width = 191;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "AgendaTypeId";
            this.columnHeader6.Width = 121;
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.addButton.Location = new System.Drawing.Point(570, 110);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(124, 52);
            this.addButton.TabIndex = 51;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(707, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(619, 417);
            this.groupBox2.TabIndex = 48;
            this.groupBox2.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column5,
            this.Column6});
            this.dataGridView1.Location = new System.Drawing.Point(19, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(574, 369);
            this.dataGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Agenda SL";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Agenda Header";
            this.Column2.Name = "Column2";
            this.Column2.Width = 5;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "AgendaTitle";
            this.Column3.Name = "Column3";
            this.Column3.Width = 220;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "AgendaType";
            this.Column5.Name = "Column5";
            this.Column5.Width = 200;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "AgendaTypeId";
            this.Column6.Name = "Column6";
            this.Column6.Width = 5;
            // 
            // MeetingEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1358, 612);
            this.Controls.Add(this.meetingListGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "MeetingEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MeetingEntryUI";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MeetingEntry_FormClosed);
            this.Load += new System.EventHandler(this.MeetingEntry_Load);
            this.meetingListGroupBox.ResumeLayout(false);
            this.meetingListGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.GroupBox meetingListGroupBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.TextBox txtMeetingTitle;
        private System.Windows.Forms.TextBox txtMeetingNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}

