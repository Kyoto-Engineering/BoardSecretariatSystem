namespace BoardSecretariatSystem.UI
{
    partial class MeetingConsole5UI
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
            this.label4 = new System.Windows.Forms.Label();
            this.attendedParticipantDataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invitedParticipantDataGridView = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.meetingNumOrIDTextBox = new System.Windows.Forms.TextBox();
            this.addToListButton = new System.Windows.Forms.Button();
            this.saveAllButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.attendedParticipantDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invitedParticipantDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(222, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(507, 62);
            this.label1.TabIndex = 0;
            this.label1.Text = "                      Meeting Console 5  \r\nAttendance Management (Before Meeting)" +
    "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Magenta;
            this.label2.Location = new System.Drawing.Point(32, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Meeting Number/ ID :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(662, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "Invited Partipent \r\n";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(142, 327);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(229, 26);
            this.label4.TabIndex = 3;
            this.label4.Text = "Attended Participant\r\n";
            // 
            // attendedParticipantDataGridView
            // 
            this.attendedParticipantDataGridView.AllowUserToAddRows = false;
            this.attendedParticipantDataGridView.AllowUserToDeleteRows = false;
            this.attendedParticipantDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.attendedParticipantDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.attendedParticipantDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.attendedParticipantDataGridView.Location = new System.Drawing.Point(29, 367);
            this.attendedParticipantDataGridView.Name = "attendedParticipantDataGridView";
            this.attendedParticipantDataGridView.ReadOnly = true;
            this.attendedParticipantDataGridView.Size = new System.Drawing.Size(490, 150);
            this.attendedParticipantDataGridView.TabIndex = 4;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Sl";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Name";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Type";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // invitedParticipantDataGridView
            // 
            this.invitedParticipantDataGridView.AllowUserToAddRows = false;
            this.invitedParticipantDataGridView.AllowUserToDeleteRows = false;
            this.invitedParticipantDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.invitedParticipantDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.invitedParticipantDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column5,
            this.Column6});
            this.invitedParticipantDataGridView.Location = new System.Drawing.Point(549, 141);
            this.invitedParticipantDataGridView.Name = "invitedParticipantDataGridView";
            this.invitedParticipantDataGridView.ReadOnly = true;
            this.invitedParticipantDataGridView.Size = new System.Drawing.Size(404, 150);
            this.invitedParticipantDataGridView.TabIndex = 5;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Sl";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Name";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Type";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // meetingNumOrIDTextBox
            // 
            this.meetingNumOrIDTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.meetingNumOrIDTextBox.Location = new System.Drawing.Point(228, 142);
            this.meetingNumOrIDTextBox.Name = "meetingNumOrIDTextBox";
            this.meetingNumOrIDTextBox.Size = new System.Drawing.Size(193, 26);
            this.meetingNumOrIDTextBox.TabIndex = 12;
            // 
            // addToListButton
            // 
            this.addToListButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addToListButton.ForeColor = System.Drawing.Color.Magenta;
            this.addToListButton.Location = new System.Drawing.Point(406, 298);
            this.addToListButton.Name = "addToListButton";
            this.addToListButton.Size = new System.Drawing.Size(113, 32);
            this.addToListButton.TabIndex = 13;
            this.addToListButton.Text = "Add To List";
            this.addToListButton.UseVisualStyleBackColor = true;
            // 
            // saveAllButton
            // 
            this.saveAllButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveAllButton.ForeColor = System.Drawing.Color.Magenta;
            this.saveAllButton.Location = new System.Drawing.Point(826, 482);
            this.saveAllButton.Name = "saveAllButton";
            this.saveAllButton.Size = new System.Drawing.Size(127, 35);
            this.saveAllButton.TabIndex = 14;
            this.saveAllButton.Text = "Save All";
            this.saveAllButton.UseVisualStyleBackColor = true;
            // 
            // MeetingConsole5UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 532);
            this.Controls.Add(this.saveAllButton);
            this.Controls.Add(this.addToListButton);
            this.Controls.Add(this.meetingNumOrIDTextBox);
            this.Controls.Add(this.invitedParticipantDataGridView);
            this.Controls.Add(this.attendedParticipantDataGridView);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "MeetingConsole5UI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MeetingConsole5";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MeetingConsole5UI_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.attendedParticipantDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invitedParticipantDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView attendedParticipantDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridView invitedParticipantDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.TextBox meetingNumOrIDTextBox;
        private System.Windows.Forms.Button addToListButton;
        private System.Windows.Forms.Button saveAllButton;
    }
}