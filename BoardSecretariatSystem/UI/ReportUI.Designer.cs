namespace BoardSecretariatSystem.UI
{
    partial class ReportUI
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
            this.attendenceSlipButton = new System.Windows.Forms.Button();
            this.noticeOfAMeetingButton = new System.Windows.Forms.Button();
            this.meetingPostponedButton = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.boardMeetingFeeButton = new System.Windows.Forms.Button();
            this.participantAttendenceReportButton = new System.Windows.Forms.Button();
            this.meetingMinutesButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // attendenceSlipButton
            // 
            this.attendenceSlipButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attendenceSlipButton.Location = new System.Drawing.Point(84, 57);
            this.attendenceSlipButton.Name = "attendenceSlipButton";
            this.attendenceSlipButton.Size = new System.Drawing.Size(223, 82);
            this.attendenceSlipButton.TabIndex = 0;
            this.attendenceSlipButton.Text = "Attendence Slip";
            this.attendenceSlipButton.UseVisualStyleBackColor = true;
            this.attendenceSlipButton.Click += new System.EventHandler(this.attendenceSlipButton_Click);
            // 
            // noticeOfAMeetingButton
            // 
            this.noticeOfAMeetingButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noticeOfAMeetingButton.Location = new System.Drawing.Point(84, 145);
            this.noticeOfAMeetingButton.Name = "noticeOfAMeetingButton";
            this.noticeOfAMeetingButton.Size = new System.Drawing.Size(223, 82);
            this.noticeOfAMeetingButton.TabIndex = 1;
            this.noticeOfAMeetingButton.Text = "Notice of A Meeting";
            this.noticeOfAMeetingButton.UseVisualStyleBackColor = true;
            this.noticeOfAMeetingButton.Click += new System.EventHandler(this.noticeOfAMeetingButton_Click);
            // 
            // meetingPostponedButton
            // 
            this.meetingPostponedButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.meetingPostponedButton.Location = new System.Drawing.Point(316, 145);
            this.meetingPostponedButton.Name = "meetingPostponedButton";
            this.meetingPostponedButton.Size = new System.Drawing.Size(223, 82);
            this.meetingPostponedButton.TabIndex = 2;
            this.meetingPostponedButton.Text = "Meeting Postponed";
            this.meetingPostponedButton.UseVisualStyleBackColor = true;
            this.meetingPostponedButton.Click += new System.EventHandler(this.meetingPostponedButton_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(84, 245);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(223, 82);
            this.button4.TabIndex = 3;
            this.button4.Text = "Memo of Agenda";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // boardMeetingFeeButton
            // 
            this.boardMeetingFeeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boardMeetingFeeButton.Location = new System.Drawing.Point(316, 57);
            this.boardMeetingFeeButton.Name = "boardMeetingFeeButton";
            this.boardMeetingFeeButton.Size = new System.Drawing.Size(223, 82);
            this.boardMeetingFeeButton.TabIndex = 4;
            this.boardMeetingFeeButton.Text = "Board Meeting Fee";
            this.boardMeetingFeeButton.UseVisualStyleBackColor = true;
            this.boardMeetingFeeButton.Click += new System.EventHandler(this.boardMeetingFeeButton_Click);
            // 
            // participantAttendenceReportButton
            // 
            this.participantAttendenceReportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.participantAttendenceReportButton.Location = new System.Drawing.Point(545, 57);
            this.participantAttendenceReportButton.Name = "participantAttendenceReportButton";
            this.participantAttendenceReportButton.Size = new System.Drawing.Size(223, 82);
            this.participantAttendenceReportButton.TabIndex = 5;
            this.participantAttendenceReportButton.Text = "Participant Attendence";
            this.participantAttendenceReportButton.UseVisualStyleBackColor = true;
            this.participantAttendenceReportButton.Click += new System.EventHandler(this.participantAttendenceReportButton_Click);
            // 
            // meetingMinutesButton
            // 
            this.meetingMinutesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.meetingMinutesButton.Location = new System.Drawing.Point(545, 145);
            this.meetingMinutesButton.Name = "meetingMinutesButton";
            this.meetingMinutesButton.Size = new System.Drawing.Size(223, 82);
            this.meetingMinutesButton.TabIndex = 6;
            this.meetingMinutesButton.Text = "Meeting Minutes";
            this.meetingMinutesButton.UseVisualStyleBackColor = true;
            // 
            // ReportUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 493);
            this.Controls.Add(this.meetingMinutesButton);
            this.Controls.Add(this.participantAttendenceReportButton);
            this.Controls.Add(this.boardMeetingFeeButton);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.meetingPostponedButton);
            this.Controls.Add(this.noticeOfAMeetingButton);
            this.Controls.Add(this.attendenceSlipButton);
            this.Name = "ReportUI";
            this.Text = "ReportUI";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button attendenceSlipButton;
        private System.Windows.Forms.Button noticeOfAMeetingButton;
        private System.Windows.Forms.Button meetingPostponedButton;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button boardMeetingFeeButton;
        private System.Windows.Forms.Button participantAttendenceReportButton;
        private System.Windows.Forms.Button meetingMinutesButton;
    }
}