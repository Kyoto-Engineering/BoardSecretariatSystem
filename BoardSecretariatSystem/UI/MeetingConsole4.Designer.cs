namespace BoardSecretariatSystem.UI
{
    partial class MeetingConsole4
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cancelationNoticeDataGridView = new System.Windows.Forms.DataGridView();
            this.cancelButton = new System.Windows.Forms.Button();
            this.deleteAllButton = new System.Windows.Forms.Button();
            this.sendNoticeButton = new System.Windows.Forms.Button();
            this.meetingNumIDTextBox = new System.Windows.Forms.TextBox();
            this.probableNextMeetingDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.reasonForCancelRichTextBox = new System.Windows.Forms.RichTextBox();
            this.comboBoxWithGrid_WinformsHost1 = new BoardSecretariatSystem.ComboBoxWithGrid_WinformsHost();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.cancelationNoticeDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(355, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(426, 62);
            this.label1.TabIndex = 0;
            this.label1.Text = "             Meeting Console 4\r\nCancel a Meeting (After Invitation)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Magenta;
            this.label3.Location = new System.Drawing.Point(89, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(240, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "Meeting Number/ ID :\r\n";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Magenta;
            this.label4.Location = new System.Drawing.Point(100, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(229, 26);
            this.label4.TabIndex = 3;
            this.label4.Text = "Reason for Postpone:\r\n";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Magenta;
            this.label5.Location = new System.Drawing.Point(100, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(224, 26);
            this.label5.TabIndex = 4;
            this.label5.Text = "Postpone Order By :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Magenta;
            this.label6.Location = new System.Drawing.Point(4, 275);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(325, 26);
            this.label6.TabIndex = 5;
            this.label6.Text = "Probable Next Meeting Date : \r\n";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(104, 357);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(296, 26);
            this.label7.TabIndex = 6;
            this.label7.Text = "Postpone  Notice Recipients\r\n";
            // 
            // cancelationNoticeDataGridView
            // 
            this.cancelationNoticeDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cancelationNoticeDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.cancelationNoticeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cancelationNoticeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3});
            this.cancelationNoticeDataGridView.Location = new System.Drawing.Point(51, 395);
            this.cancelationNoticeDataGridView.Name = "cancelationNoticeDataGridView";
            this.cancelationNoticeDataGridView.Size = new System.Drawing.Size(495, 150);
            this.cancelationNoticeDataGridView.TabIndex = 7;
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(552, 496);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(229, 49);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Postpone This Meeting ";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // deleteAllButton
            // 
            this.deleteAllButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteAllButton.Location = new System.Drawing.Point(802, 496);
            this.deleteAllButton.Name = "deleteAllButton";
            this.deleteAllButton.Size = new System.Drawing.Size(129, 49);
            this.deleteAllButton.TabIndex = 9;
            this.deleteAllButton.Text = "Delete All";
            this.deleteAllButton.UseVisualStyleBackColor = true;
            // 
            // sendNoticeButton
            // 
            this.sendNoticeButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendNoticeButton.Location = new System.Drawing.Point(937, 496);
            this.sendNoticeButton.Name = "sendNoticeButton";
            this.sendNoticeButton.Size = new System.Drawing.Size(137, 49);
            this.sendNoticeButton.TabIndex = 10;
            this.sendNoticeButton.Text = "Send Notice\r\n";
            this.sendNoticeButton.UseVisualStyleBackColor = true;
            // 
            // meetingNumIDTextBox
            // 
            this.meetingNumIDTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.meetingNumIDTextBox.Location = new System.Drawing.Point(335, 113);
            this.meetingNumIDTextBox.Name = "meetingNumIDTextBox";
            this.meetingNumIDTextBox.ReadOnly = true;
            this.meetingNumIDTextBox.Size = new System.Drawing.Size(200, 26);
            this.meetingNumIDTextBox.TabIndex = 11;
            // 
            // probableNextMeetingDateTimePicker
            // 
            this.probableNextMeetingDateTimePicker.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.probableNextMeetingDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.probableNextMeetingDateTimePicker.Location = new System.Drawing.Point(335, 275);
            this.probableNextMeetingDateTimePicker.Name = "probableNextMeetingDateTimePicker";
            this.probableNextMeetingDateTimePicker.Size = new System.Drawing.Size(211, 26);
            this.probableNextMeetingDateTimePicker.TabIndex = 14;
            // 
            // reasonForCancelRichTextBox
            // 
            this.reasonForCancelRichTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reasonForCancelRichTextBox.Location = new System.Drawing.Point(335, 149);
            this.reasonForCancelRichTextBox.Name = "reasonForCancelRichTextBox";
            this.reasonForCancelRichTextBox.Size = new System.Drawing.Size(322, 72);
            this.reasonForCancelRichTextBox.TabIndex = 16;
            this.reasonForCancelRichTextBox.Text = "";
            // 
            // comboBoxWithGrid_WinformsHost1
            // 
            this.comboBoxWithGrid_WinformsHost1.Employee2s = null;
            this.comboBoxWithGrid_WinformsHost1.Location = new System.Drawing.Point(330, 227);
            this.comboBoxWithGrid_WinformsHost1.Name = "comboBoxWithGrid_WinformsHost1";
            this.comboBoxWithGrid_WinformsHost1.SelectedIndex = -1;
            this.comboBoxWithGrid_WinformsHost1.SelectedItem = null;
            this.comboBoxWithGrid_WinformsHost1.Size = new System.Drawing.Size(430, 38);
            this.comboBoxWithGrid_WinformsHost1.TabIndex = 17;
            this.comboBoxWithGrid_WinformsHost1.Text = "comboBoxWithGrid_WinformsHost1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Participant Name";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Participant Title";
            this.Column3.Name = "Column3";
            // 
            // MeetingConsole4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 566);
            this.Controls.Add(this.comboBoxWithGrid_WinformsHost1);
            this.Controls.Add(this.reasonForCancelRichTextBox);
            this.Controls.Add(this.probableNextMeetingDateTimePicker);
            this.Controls.Add(this.meetingNumIDTextBox);
            this.Controls.Add(this.sendNoticeButton);
            this.Controls.Add(this.deleteAllButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.cancelationNoticeDataGridView);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "MeetingConsole4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MeetingConsole4";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MeetingConsole4_FormClosed);
            this.Load += new System.EventHandler(this.MeetingConsole4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cancelationNoticeDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView cancelationNoticeDataGridView;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button deleteAllButton;
        private System.Windows.Forms.Button sendNoticeButton;
        private System.Windows.Forms.TextBox meetingNumIDTextBox;
        private System.Windows.Forms.DateTimePicker probableNextMeetingDateTimePicker;
        private System.Windows.Forms.RichTextBox reasonForCancelRichTextBox;
        private ComboBoxWithGrid_WinformsHost comboBoxWithGrid_WinformsHost1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}