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
            this.bmFeeButton = new System.Windows.Forms.Button();
            this.attendenceSlipButton = new System.Windows.Forms.Button();
            this.meetingMinutesButton = new System.Windows.Forms.Button();
            this.participantAttenButton = new System.Windows.Forms.Button();
            this.noticeButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bmFeeButton
            // 
            this.bmFeeButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bmFeeButton.Location = new System.Drawing.Point(61, 235);
            this.bmFeeButton.Name = "bmFeeButton";
            this.bmFeeButton.Size = new System.Drawing.Size(159, 47);
            this.bmFeeButton.TabIndex = 0;
            this.bmFeeButton.Text = "Board Member Fee";
            this.bmFeeButton.UseVisualStyleBackColor = true;
            this.bmFeeButton.Click += new System.EventHandler(this.bmFeeButton_Click);
            // 
            // attendenceSlipButton
            // 
            this.attendenceSlipButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attendenceSlipButton.Location = new System.Drawing.Point(61, 163);
            this.attendenceSlipButton.Name = "attendenceSlipButton";
            this.attendenceSlipButton.Size = new System.Drawing.Size(159, 47);
            this.attendenceSlipButton.TabIndex = 1;
            this.attendenceSlipButton.Text = "Attendence Slip";
            this.attendenceSlipButton.UseVisualStyleBackColor = true;
            // 
            // meetingMinutesButton
            // 
            this.meetingMinutesButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.meetingMinutesButton.Location = new System.Drawing.Point(61, 307);
            this.meetingMinutesButton.Name = "meetingMinutesButton";
            this.meetingMinutesButton.Size = new System.Drawing.Size(159, 47);
            this.meetingMinutesButton.TabIndex = 2;
            this.meetingMinutesButton.Text = "Meeting Minutes";
            this.meetingMinutesButton.UseVisualStyleBackColor = true;
            this.meetingMinutesButton.Click += new System.EventHandler(this.meetingMinutesButton_Click);
            // 
            // participantAttenButton
            // 
            this.participantAttenButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.participantAttenButton.Location = new System.Drawing.Point(61, 91);
            this.participantAttenButton.Name = "participantAttenButton";
            this.participantAttenButton.Size = new System.Drawing.Size(159, 47);
            this.participantAttenButton.TabIndex = 3;
            this.participantAttenButton.Text = "Participant Attendence";
            this.participantAttenButton.UseVisualStyleBackColor = true;
            this.participantAttenButton.Click += new System.EventHandler(this.participantAttenButton_Click);
            // 
            // noticeButton
            // 
            this.noticeButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noticeButton.Location = new System.Drawing.Point(61, 19);
            this.noticeButton.Name = "noticeButton";
            this.noticeButton.Size = new System.Drawing.Size(159, 47);
            this.noticeButton.TabIndex = 4;
            this.noticeButton.Text = "Notice of Meeting";
            this.noticeButton.UseVisualStyleBackColor = true;
            this.noticeButton.Click += new System.EventHandler(this.noticeButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.noticeButton);
            this.groupBox1.Controls.Add(this.bmFeeButton);
            this.groupBox1.Controls.Add(this.participantAttenButton);
            this.groupBox1.Controls.Add(this.attendenceSlipButton);
            this.groupBox1.Controls.Add(this.meetingMinutesButton);
            this.groupBox1.Location = new System.Drawing.Point(146, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 377);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // ReportUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 438);
            this.Controls.Add(this.groupBox1);
            this.Name = "ReportUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportUI";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bmFeeButton;
        private System.Windows.Forms.Button attendenceSlipButton;
        private System.Windows.Forms.Button meetingMinutesButton;
        private System.Windows.Forms.Button participantAttenButton;
        private System.Windows.Forms.Button noticeButton;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}