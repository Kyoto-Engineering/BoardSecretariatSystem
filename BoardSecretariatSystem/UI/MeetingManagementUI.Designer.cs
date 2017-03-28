namespace BoardSecretariatSystem.UI
{
    partial class MeetingManagementUI
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonMeetingCreate = new System.Windows.Forms.Button();
            this.buttonAgendaSelection = new System.Windows.Forms.Button();
            this.buttonBoardMemo = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(436, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Meeting Management UI";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonBoardMemo);
            this.groupBox1.Controls.Add(this.buttonAgendaSelection);
            this.groupBox1.Controls.Add(this.buttonMeetingCreate);
            this.groupBox1.Location = new System.Drawing.Point(12, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(141, 516);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // buttonMeetingCreate
            // 
            this.buttonMeetingCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.buttonMeetingCreate.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMeetingCreate.ForeColor = System.Drawing.Color.Blue;
            this.buttonMeetingCreate.Location = new System.Drawing.Point(18, 19);
            this.buttonMeetingCreate.Name = "buttonMeetingCreate";
            this.buttonMeetingCreate.Size = new System.Drawing.Size(101, 62);
            this.buttonMeetingCreate.TabIndex = 0;
            this.buttonMeetingCreate.Text = "Create Meeting";
            this.buttonMeetingCreate.UseVisualStyleBackColor = false;
            this.buttonMeetingCreate.Click += new System.EventHandler(this.buttonMeetingCreate_Click);
            // 
            // buttonAgendaSelection
            // 
            this.buttonAgendaSelection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.buttonAgendaSelection.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAgendaSelection.ForeColor = System.Drawing.Color.Blue;
            this.buttonAgendaSelection.Location = new System.Drawing.Point(18, 87);
            this.buttonAgendaSelection.Name = "buttonAgendaSelection";
            this.buttonAgendaSelection.Size = new System.Drawing.Size(99, 64);
            this.buttonAgendaSelection.TabIndex = 1;
            this.buttonAgendaSelection.Text = "Agenda Selection";
            this.buttonAgendaSelection.UseVisualStyleBackColor = false;
            this.buttonAgendaSelection.Click += new System.EventHandler(this.buttonAgendaSelection_Click);
            // 
            // buttonBoardMemo
            // 
            this.buttonBoardMemo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.buttonBoardMemo.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBoardMemo.ForeColor = System.Drawing.Color.Blue;
            this.buttonBoardMemo.Location = new System.Drawing.Point(18, 157);
            this.buttonBoardMemo.Name = "buttonBoardMemo";
            this.buttonBoardMemo.Size = new System.Drawing.Size(101, 68);
            this.buttonBoardMemo.TabIndex = 2;
            this.buttonBoardMemo.Text = "Board Memo";
            this.buttonBoardMemo.UseVisualStyleBackColor = false;
            this.buttonBoardMemo.Click += new System.EventHandler(this.buttonBoardMemo_Click);
            // 
            // MeetingManagementUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1028, 596);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "MeetingManagementUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MeetingManagementUI";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MeetingManagementUI_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonMeetingCreate;
        private System.Windows.Forms.Button buttonAgendaSelection;
        private System.Windows.Forms.Button buttonBoardMemo;
    }
}