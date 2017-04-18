namespace BoardSecretariatSystem.UI
{
    partial class MDirectorResignation
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
            this.buttonDone = new System.Windows.Forms.Button();
            this.txtResignationCause = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDateOfRetirement = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtManagingDirectorId = new System.Windows.Forms.TextBox();
            this.txtManagingDirectorName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonDone
            // 
            this.buttonDone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.buttonDone.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDone.ForeColor = System.Drawing.Color.Blue;
            this.buttonDone.Location = new System.Drawing.Point(473, 361);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(182, 71);
            this.buttonDone.TabIndex = 20;
            this.buttonDone.Text = "Done";
            this.buttonDone.UseVisualStyleBackColor = false;
            this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
            // 
            // txtResignationCause
            // 
            this.txtResignationCause.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResignationCause.Location = new System.Drawing.Point(363, 282);
            this.txtResignationCause.Name = "txtResignationCause";
            this.txtResignationCause.Size = new System.Drawing.Size(410, 39);
            this.txtResignationCause.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(51, 282);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(269, 31);
            this.label3.TabIndex = 18;
            this.label3.Text = "Cause Of Resignation";
            // 
            // txtDateOfRetirement
            // 
            this.txtDateOfRetirement.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateOfRetirement.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDateOfRetirement.Location = new System.Drawing.Point(363, 81);
            this.txtDateOfRetirement.Name = "txtDateOfRetirement";
            this.txtDateOfRetirement.Size = new System.Drawing.Size(410, 39);
            this.txtDateOfRetirement.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(290, 31);
            this.label2.TabIndex = 16;
            this.label2.Text = "Select Resignation Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 229);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(326, 31);
            this.label1.TabIndex = 15;
            this.label1.Text = " Managing Director  Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(283, 31);
            this.label4.TabIndex = 21;
            this.label4.Text = " Managing Director  Id";
            // 
            // txtManagingDirectorId
            // 
            this.txtManagingDirectorId.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtManagingDirectorId.Location = new System.Drawing.Point(363, 158);
            this.txtManagingDirectorId.Name = "txtManagingDirectorId";
            this.txtManagingDirectorId.Size = new System.Drawing.Size(410, 39);
            this.txtManagingDirectorId.TabIndex = 22;
            // 
            // txtManagingDirectorName
            // 
            this.txtManagingDirectorName.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtManagingDirectorName.Location = new System.Drawing.Point(363, 226);
            this.txtManagingDirectorName.Name = "txtManagingDirectorName";
            this.txtManagingDirectorName.Size = new System.Drawing.Size(410, 39);
            this.txtManagingDirectorName.TabIndex = 23;
            // 
            // MDirectorResignation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 472);
            this.Controls.Add(this.txtManagingDirectorName);
            this.Controls.Add(this.txtManagingDirectorId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonDone);
            this.Controls.Add(this.txtResignationCause);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDateOfRetirement);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "MDirectorResignation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MDirectorResignation";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MDirectorResignation_FormClosed);
            this.Load += new System.EventHandler(this.MDirectorResignation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDone;
        private System.Windows.Forms.TextBox txtResignationCause;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker txtDateOfRetirement;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        public  System.Windows.Forms.TextBox txtManagingDirectorId;
        public  System.Windows.Forms.TextBox txtManagingDirectorName;
    }
}