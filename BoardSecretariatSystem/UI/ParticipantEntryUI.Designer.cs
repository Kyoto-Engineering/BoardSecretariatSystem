namespace BoardSecretariatSystem
{
    partial class ParticipantEntryUI
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
            this.SaveButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.boardNameComboBox = new System.Windows.Forms.ComboBox();
            this.companyNameComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.participantNameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.participantDesignationTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.participantEmailTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.participantContactNoTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.participantListGroupBox = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.participantListDataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.participantListGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.participantListDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.Location = new System.Drawing.Point(399, 339);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 33);
            this.SaveButton.TabIndex = 37;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(66, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 22);
            this.label3.TabIndex = 35;
            this.label3.Text = "Participant Name :";
            // 
            // boardNameComboBox
            // 
            this.boardNameComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.boardNameComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.boardNameComboBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boardNameComboBox.FormattingEnabled = true;
            this.boardNameComboBox.Location = new System.Drawing.Point(237, 118);
            this.boardNameComboBox.Name = "boardNameComboBox";
            this.boardNameComboBox.Size = new System.Drawing.Size(238, 27);
            this.boardNameComboBox.TabIndex = 34;
            this.boardNameComboBox.Leave += new System.EventHandler(this.boardNameComboBox_Leave);
            // 
            // companyNameComboBox
            // 
            this.companyNameComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.companyNameComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.companyNameComboBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.companyNameComboBox.FormattingEnabled = true;
            this.companyNameComboBox.Location = new System.Drawing.Point(237, 70);
            this.companyNameComboBox.Name = "companyNameComboBox";
            this.companyNameComboBox.Size = new System.Drawing.Size(238, 27);
            this.companyNameComboBox.TabIndex = 33;
            this.companyNameComboBox.SelectedIndexChanged += new System.EventHandler(this.companyNameComboBox_SelectedIndexChanged);
            this.companyNameComboBox.Leave += new System.EventHandler(this.companyNameComboBox_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(106, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 22);
            this.label2.TabIndex = 32;
            this.label2.Text = "Board Name :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(79, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 22);
            this.label1.TabIndex = 31;
            this.label1.Text = "Company Name :";
            // 
            // participantNameTextBox
            // 
            this.participantNameTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.participantNameTextBox.Location = new System.Drawing.Point(237, 166);
            this.participantNameTextBox.Name = "participantNameTextBox";
            this.participantNameTextBox.Size = new System.Drawing.Size(237, 26);
            this.participantNameTextBox.TabIndex = 38;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(213, 22);
            this.label4.TabIndex = 39;
            this.label4.Text = "Participant Designation :";
            // 
            // participantDesignationTextBox
            // 
            this.participantDesignationTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.participantDesignationTextBox.Location = new System.Drawing.Point(237, 207);
            this.participantDesignationTextBox.Name = "participantDesignationTextBox";
            this.participantDesignationTextBox.Size = new System.Drawing.Size(237, 26);
            this.participantDesignationTextBox.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(232, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(200, 28);
            this.label5.TabIndex = 41;
            this.label5.Text = "Participant Details";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(164, 254);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 42;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(164, 298);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 13);
            this.label7.TabIndex = 45;
            // 
            // participantEmailTextBox
            // 
            this.participantEmailTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.participantEmailTextBox.Location = new System.Drawing.Point(237, 251);
            this.participantEmailTextBox.Name = "participantEmailTextBox";
            this.participantEmailTextBox.Size = new System.Drawing.Size(237, 26);
            this.participantEmailTextBox.TabIndex = 44;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(157, 255);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 22);
            this.label8.TabIndex = 43;
            this.label8.Text = "Email  :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(164, 342);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 13);
            this.label9.TabIndex = 48;
            // 
            // participantContactNoTextBox
            // 
            this.participantContactNoTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.participantContactNoTextBox.Location = new System.Drawing.Point(237, 295);
            this.participantContactNoTextBox.Name = "participantContactNoTextBox";
            this.participantContactNoTextBox.Size = new System.Drawing.Size(237, 26);
            this.participantContactNoTextBox.TabIndex = 47;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(106, 299);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(124, 22);
            this.label10.TabIndex = 46;
            this.label10.Text = "Cell Number :";
            // 
            // participantListGroupBox
            // 
            this.participantListGroupBox.Controls.Add(this.label12);
            this.participantListGroupBox.Controls.Add(this.textBox1);
            this.participantListGroupBox.Controls.Add(this.label11);
            this.participantListGroupBox.Controls.Add(this.participantListDataGridView);
            this.participantListGroupBox.Location = new System.Drawing.Point(493, 20);
            this.participantListGroupBox.Name = "participantListGroupBox";
            this.participantListGroupBox.Size = new System.Drawing.Size(601, 425);
            this.participantListGroupBox.TabIndex = 49;
            this.participantListGroupBox.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(220, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(177, 28);
            this.label11.TabIndex = 1;
            this.label11.Text = "Participants List";
            // 
            // participantListDataGridView
            // 
            this.participantListDataGridView.AllowUserToAddRows = false;
            this.participantListDataGridView.AllowUserToDeleteRows = false;
            this.participantListDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.participantListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.participantListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.participantListDataGridView.Location = new System.Drawing.Point(17, 143);
            this.participantListDataGridView.Name = "participantListDataGridView";
            this.participantListDataGridView.ReadOnly = true;
            this.participantListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.participantListDataGridView.Size = new System.Drawing.Size(578, 273);
            this.participantListDataGridView.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Participant Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Company Name";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Board Name";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Meeting Name";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Eamil";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Cell Number";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(341, 83);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(131, 83);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "Search by ";
            // 
            // ParticipantEntryUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1106, 485);
            this.Controls.Add(this.participantListGroupBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.participantContactNoTextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.participantEmailTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.participantDesignationTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.participantNameTextBox);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.boardNameComboBox);
            this.Controls.Add(this.companyNameComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "ParticipantEntryUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ParticipantEntryUI";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ParticipantEntryUI_FormClosed);
            this.Load += new System.EventHandler(this.ParticipantEntryUI_Load);
            this.participantListGroupBox.ResumeLayout(false);
            this.participantListGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.participantListDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox boardNameComboBox;
        private System.Windows.Forms.ComboBox companyNameComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox participantNameTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox participantDesignationTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox participantEmailTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox participantContactNoTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox participantListGroupBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView participantListDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox1;
    }
}