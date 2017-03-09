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
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.locationTextBox = new System.Windows.Forms.TextBox();
            this.meetingDatePicker = new System.Windows.Forms.DateTimePicker();
            this.saveButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.companyNameComboBox = new System.Windows.Forms.ComboBox();
            this.boardNameComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.meetingNameTextBox = new System.Windows.Forms.TextBox();
            this.meetingListGroupBox = new System.Windows.Forms.GroupBox();
            this.meetingListGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Company Name :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(50, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(165, 26);
            this.label5.TabIndex = 4;
            this.label5.Text = "Meeting Date :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(93, 188);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 26);
            this.label7.TabIndex = 6;
            this.label7.Text = "Location  :";
            // 
            // locationTextBox
            // 
            this.locationTextBox.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locationTextBox.Location = new System.Drawing.Point(227, 188);
            this.locationTextBox.Name = "locationTextBox";
            this.locationTextBox.Size = new System.Drawing.Size(324, 35);
            this.locationTextBox.TabIndex = 13;
            // 
            // meetingDatePicker
            // 
            this.meetingDatePicker.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.meetingDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.meetingDatePicker.Location = new System.Drawing.Point(227, 237);
            this.meetingDatePicker.Name = "meetingDatePicker";
            this.meetingDatePicker.Size = new System.Drawing.Size(324, 35);
            this.meetingDatePicker.TabIndex = 16;
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.saveButton.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(439, 286);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(112, 64);
            this.saveButton.TabIndex = 18;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(63, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 26);
            this.label2.TabIndex = 20;
            this.label2.Text = "Board Name :";
            // 
            // companyNameComboBox
            // 
            this.companyNameComboBox.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.companyNameComboBox.FormattingEnabled = true;
            this.companyNameComboBox.Location = new System.Drawing.Point(227, 54);
            this.companyNameComboBox.Name = "companyNameComboBox";
            this.companyNameComboBox.Size = new System.Drawing.Size(324, 34);
            this.companyNameComboBox.TabIndex = 22;
            this.companyNameComboBox.SelectedIndexChanged += new System.EventHandler(this.companyNameComboBox_SelectedIndexChanged);
            // 
            // boardNameComboBox
            // 
            this.boardNameComboBox.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boardNameComboBox.FormattingEnabled = true;
            this.boardNameComboBox.Location = new System.Drawing.Point(227, 99);
            this.boardNameComboBox.Name = "boardNameComboBox";
            this.boardNameComboBox.Size = new System.Drawing.Size(324, 35);
            this.boardNameComboBox.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(41, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 26);
            this.label3.TabIndex = 24;
            this.label3.Text = "Meeting Name :";
            // 
            // meetingNameTextBox
            // 
            this.meetingNameTextBox.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.meetingNameTextBox.Location = new System.Drawing.Point(227, 144);
            this.meetingNameTextBox.Name = "meetingNameTextBox";
            this.meetingNameTextBox.Size = new System.Drawing.Size(324, 35);
            this.meetingNameTextBox.TabIndex = 25;
            // 
            // meetingListGroupBox
            // 
            this.meetingListGroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.meetingListGroupBox.Controls.Add(this.meetingNameTextBox);
            this.meetingListGroupBox.Controls.Add(this.label1);
            this.meetingListGroupBox.Controls.Add(this.label3);
            this.meetingListGroupBox.Controls.Add(this.label5);
            this.meetingListGroupBox.Controls.Add(this.boardNameComboBox);
            this.meetingListGroupBox.Controls.Add(this.label7);
            this.meetingListGroupBox.Controls.Add(this.companyNameComboBox);
            this.meetingListGroupBox.Controls.Add(this.locationTextBox);
            this.meetingListGroupBox.Controls.Add(this.label2);
            this.meetingListGroupBox.Controls.Add(this.meetingDatePicker);
            this.meetingListGroupBox.Controls.Add(this.saveButton);
            this.meetingListGroupBox.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.meetingListGroupBox.ForeColor = System.Drawing.Color.Blue;
            this.meetingListGroupBox.Location = new System.Drawing.Point(10, 4);
            this.meetingListGroupBox.Name = "meetingListGroupBox";
            this.meetingListGroupBox.Size = new System.Drawing.Size(590, 370);
            this.meetingListGroupBox.TabIndex = 26;
            this.meetingListGroupBox.TabStop = false;
            this.meetingListGroupBox.Text = "Meeting Entry";
            // 
            // MeetingEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(610, 379);
            this.Controls.Add(this.meetingListGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "MeetingEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MeetingEntryUI";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MeetingEntry_FormClosed);
            this.Load += new System.EventHandler(this.MeetingEntry_Load);
            this.meetingListGroupBox.ResumeLayout(false);
            this.meetingListGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox locationTextBox;
        private System.Windows.Forms.DateTimePicker meetingDatePicker;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox companyNameComboBox;
        private System.Windows.Forms.ComboBox boardNameComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox meetingNameTextBox;
        private System.Windows.Forms.GroupBox meetingListGroupBox;
    }
}

