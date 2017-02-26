namespace BoardSecretariatSystem
{
    partial class CompanyEntryUI
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
            this.companyNameTextBox = new System.Windows.Forms.TextBox();
            this.regNoTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.companyAddTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.creatinDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.allCompanyListDataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.allCompanyListGroupBox = new System.Windows.Forms.GroupBox();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.allCompanyListDataGridView)).BeginInit();
            this.allCompanyListGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(70, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Company Name :";
            // 
            // companyNameTextBox
            // 
            this.companyNameTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.companyNameTextBox.Location = new System.Drawing.Point(227, 68);
            this.companyNameTextBox.Name = "companyNameTextBox";
            this.companyNameTextBox.Size = new System.Drawing.Size(194, 26);
            this.companyNameTextBox.TabIndex = 0;
            // 
            // regNoTextBox
            // 
            this.regNoTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regNoTextBox.Location = new System.Drawing.Point(227, 249);
            this.regNoTextBox.Name = "regNoTextBox";
            this.regNoTextBox.Size = new System.Drawing.Size(194, 26);
            this.regNoTextBox.TabIndex = 2;
            this.regNoTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.contactNoTextBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 253);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Registration Number :";
            // 
            // companyAddTextBox
            // 
            this.companyAddTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.companyAddTextBox.Location = new System.Drawing.Point(227, 115);
            this.companyAddTextBox.Multiline = true;
            this.companyAddTextBox.Name = "companyAddTextBox";
            this.companyAddTextBox.Size = new System.Drawing.Size(194, 119);
            this.companyAddTextBox.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(56, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "Company Address :";
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(340, 355);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(81, 32);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label4.Location = new System.Drawing.Point(222, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(199, 28);
            this.label4.TabIndex = 7;
            this.label4.Text = "Company Creation";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(64, 301);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(157, 22);
            this.label5.TabIndex = 9;
            this.label5.Text = "Date of Creation :";
            // 
            // creatinDateTimePicker
            // 
            this.creatinDateTimePicker.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creatinDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.creatinDateTimePicker.Location = new System.Drawing.Point(228, 302);
            this.creatinDateTimePicker.Name = "creatinDateTimePicker";
            this.creatinDateTimePicker.Size = new System.Drawing.Size(193, 26);
            this.creatinDateTimePicker.TabIndex = 10;
            this.creatinDateTimePicker.ValueChanged += new System.EventHandler(this.creatinDateTimePicker_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(230, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(186, 28);
            this.label6.TabIndex = 11;
            this.label6.Text = "All Company List";
            // 
            // allCompanyListDataGridView
            // 
            this.allCompanyListDataGridView.AllowUserToAddRows = false;
            this.allCompanyListDataGridView.AllowUserToDeleteRows = false;
            this.allCompanyListDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.allCompanyListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.allCompanyListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.allCompanyListDataGridView.Location = new System.Drawing.Point(16, 112);
            this.allCompanyListDataGridView.Name = "allCompanyListDataGridView";
            this.allCompanyListDataGridView.ReadOnly = true;
            this.allCompanyListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.allCompanyListDataGridView.Size = new System.Drawing.Size(619, 272);
            this.allCompanyListDataGridView.TabIndex = 12;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Serial Number";
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
            this.Column3.HeaderText = "Company Address";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = " Regitration Number";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Creation Date";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // allCompanyListGroupBox
            // 
            this.allCompanyListGroupBox.Controls.Add(this.label7);
            this.allCompanyListGroupBox.Controls.Add(this.searchTextBox);
            this.allCompanyListGroupBox.Controls.Add(this.label6);
            this.allCompanyListGroupBox.Controls.Add(this.allCompanyListDataGridView);
            this.allCompanyListGroupBox.Location = new System.Drawing.Point(450, 48);
            this.allCompanyListGroupBox.Name = "allCompanyListGroupBox";
            this.allCompanyListGroupBox.Size = new System.Drawing.Size(641, 400);
            this.allCompanyListGroupBox.TabIndex = 13;
            this.allCompanyListGroupBox.TabStop = false;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTextBox.Location = new System.Drawing.Point(302, 63);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(165, 26);
            this.searchTextBox.TabIndex = 13;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(116, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(180, 22);
            this.label7.TabIndex = 14;
            this.label7.Text = "Search by Company :";
            // 
            // CompanyEntryUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1103, 491);
            this.Controls.Add(this.allCompanyListGroupBox);
            this.Controls.Add(this.creatinDateTimePicker);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.companyAddTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.regNoTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.companyNameTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "CompanyEntryUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CompanyEntryUI";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CompanyEntryUI_FormClosed);
            this.Load += new System.EventHandler(this.CompanyEntryUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.allCompanyListDataGridView)).EndInit();
            this.allCompanyListGroupBox.ResumeLayout(false);
            this.allCompanyListGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox companyNameTextBox;
        private System.Windows.Forms.TextBox regNoTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox companyAddTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker creatinDateTimePicker;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView allCompanyListDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.GroupBox allCompanyListGroupBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox searchTextBox;
    }
}