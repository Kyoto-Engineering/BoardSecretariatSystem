namespace BoardSecretariatSystem.UI
{
    partial class ReportMainUI
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
            this.Report_Label = new System.Windows.Forms.Label();
            this.attendenceSlipButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Report_Label
            // 
            this.Report_Label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Report_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Report_Label.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.Report_Label.Location = new System.Drawing.Point(236, 9);
            this.Report_Label.Name = "Report_Label";
            this.Report_Label.Size = new System.Drawing.Size(229, 35);
            this.Report_Label.TabIndex = 0;
            this.Report_Label.Text = "REPORTS";
            this.Report_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // attendenceSlipButton
            // 
            this.attendenceSlipButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.attendenceSlipButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attendenceSlipButton.Location = new System.Drawing.Point(244, 105);
            this.attendenceSlipButton.Name = "attendenceSlipButton";
            this.attendenceSlipButton.Size = new System.Drawing.Size(213, 58);
            this.attendenceSlipButton.TabIndex = 1;
            this.attendenceSlipButton.Text = "Meeting No Selected Reports";
            this.attendenceSlipButton.UseVisualStyleBackColor = false;
            this.attendenceSlipButton.Click += new System.EventHandler(this.attendenceSlipButton_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(244, 169);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(213, 58);
            this.button1.TabIndex = 2;
            this.button1.Text = "Forms";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(244, 233);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(213, 58);
            this.button2.TabIndex = 3;
            this.button2.Text = "SheduleX";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(244, 297);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(213, 58);
            this.button3.TabIndex = 4;
            this.button3.Text = "Posponed Reports";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ReportMainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 416);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.attendenceSlipButton);
            this.Controls.Add(this.Report_Label);
            this.Name = "ReportMainUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportMainUI";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Report_Label;
        private System.Windows.Forms.Button attendenceSlipButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}