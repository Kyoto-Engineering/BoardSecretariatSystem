namespace BoardSecretariatSystem
{
    partial class MainUI
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
            this.companyCreateButton = new System.Windows.Forms.Button();
            this.boardCreateButton = new System.Windows.Forms.Button();
            this.agendaCreateButton = new System.Windows.Forms.Button();
            this.meetingCreateButton = new System.Windows.Forms.Button();
            this.meetingExecutionButton = new System.Windows.Forms.Button();
            this.participantCreateButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // companyCreateButton
            // 
            this.companyCreateButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.companyCreateButton.Location = new System.Drawing.Point(33, 24);
            this.companyCreateButton.Name = "companyCreateButton";
            this.companyCreateButton.Size = new System.Drawing.Size(123, 57);
            this.companyCreateButton.TabIndex = 0;
            this.companyCreateButton.Text = "Company Creation";
            this.companyCreateButton.UseVisualStyleBackColor = true;
            this.companyCreateButton.Click += new System.EventHandler(this.companyCreateButton_Click);
            // 
            // boardCreateButton
            // 
            this.boardCreateButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boardCreateButton.Location = new System.Drawing.Point(33, 93);
            this.boardCreateButton.Name = "boardCreateButton";
            this.boardCreateButton.Size = new System.Drawing.Size(123, 56);
            this.boardCreateButton.TabIndex = 1;
            this.boardCreateButton.Text = "Board Creation";
            this.boardCreateButton.UseVisualStyleBackColor = true;
            this.boardCreateButton.Click += new System.EventHandler(this.boardCreateButton_Click);
            // 
            // agendaCreateButton
            // 
            this.agendaCreateButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.agendaCreateButton.Location = new System.Drawing.Point(33, 238);
            this.agendaCreateButton.Name = "agendaCreateButton";
            this.agendaCreateButton.Size = new System.Drawing.Size(123, 60);
            this.agendaCreateButton.TabIndex = 3;
            this.agendaCreateButton.Text = "Agenda Creation";
            this.agendaCreateButton.UseVisualStyleBackColor = true;
            this.agendaCreateButton.Click += new System.EventHandler(this.agendaCreateButton_Click);
            // 
            // meetingCreateButton
            // 
            this.meetingCreateButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.meetingCreateButton.Location = new System.Drawing.Point(33, 161);
            this.meetingCreateButton.Name = "meetingCreateButton";
            this.meetingCreateButton.Size = new System.Drawing.Size(123, 65);
            this.meetingCreateButton.TabIndex = 2;
            this.meetingCreateButton.Text = "Meeting Creation";
            this.meetingCreateButton.UseVisualStyleBackColor = true;
            this.meetingCreateButton.Click += new System.EventHandler(this.meetingCreateButton_Click);
            // 
            // meetingExecutionButton
            // 
            this.meetingExecutionButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.meetingExecutionButton.Location = new System.Drawing.Point(33, 381);
            this.meetingExecutionButton.Name = "meetingExecutionButton";
            this.meetingExecutionButton.Size = new System.Drawing.Size(123, 60);
            this.meetingExecutionButton.TabIndex = 5;
            this.meetingExecutionButton.Text = "Meeting Execution";
            this.meetingExecutionButton.UseVisualStyleBackColor = true;
            this.meetingExecutionButton.Click += new System.EventHandler(this.meetingExecutionButton_Click);
            // 
            // participantCreateButton
            // 
            this.participantCreateButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.participantCreateButton.Location = new System.Drawing.Point(33, 310);
            this.participantCreateButton.Name = "participantCreateButton";
            this.participantCreateButton.Size = new System.Drawing.Size(123, 59);
            this.participantCreateButton.TabIndex = 4;
            this.participantCreateButton.Text = "Participant Creation";
            this.participantCreateButton.UseVisualStyleBackColor = true;
            this.participantCreateButton.Click += new System.EventHandler(this.participantCreateButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(242, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(525, 54);
            this.label1.TabIndex = 6;
            this.label1.Text = "Board Secretariat System";
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(985, 506);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.meetingExecutionButton);
            this.Controls.Add(this.participantCreateButton);
            this.Controls.Add(this.agendaCreateButton);
            this.Controls.Add(this.meetingCreateButton);
            this.Controls.Add(this.boardCreateButton);
            this.Controls.Add(this.companyCreateButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "MainUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainUI";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainUI_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button companyCreateButton;
        private System.Windows.Forms.Button boardCreateButton;
        private System.Windows.Forms.Button agendaCreateButton;
        private System.Windows.Forms.Button meetingCreateButton;
        private System.Windows.Forms.Button meetingExecutionButton;
        private System.Windows.Forms.Button participantCreateButton;
        private System.Windows.Forms.Label label1;
    }
}