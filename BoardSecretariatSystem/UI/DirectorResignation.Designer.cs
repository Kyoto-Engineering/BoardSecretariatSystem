namespace BoardSecretariatSystem.UI
{
    partial class DirectorResignation
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtCauseOfResignation = new System.Windows.Forms.TextBox();
            this.buttonDone = new System.Windows.Forms.Button();
            this.textDirectorName = new System.Windows.Forms.TextBox();
            this.textDirectorId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtResignationDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(134, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Director Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(71, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(233, 26);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cause Of Resignation";
            // 
            // txtCauseOfResignation
            // 
            this.txtCauseOfResignation.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCauseOfResignation.Location = new System.Drawing.Point(321, 163);
            this.txtCauseOfResignation.Name = "txtCauseOfResignation";
            this.txtCauseOfResignation.Size = new System.Drawing.Size(371, 32);
            this.txtCauseOfResignation.TabIndex = 5;
            this.txtCauseOfResignation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCauseOfResignation_KeyDown);
            // 
            // buttonDone
            // 
            this.buttonDone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.buttonDone.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDone.ForeColor = System.Drawing.Color.Blue;
            this.buttonDone.Location = new System.Drawing.Point(551, 253);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(141, 73);
            this.buttonDone.TabIndex = 6;
            this.buttonDone.Text = "Done";
            this.buttonDone.UseVisualStyleBackColor = false;
            this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
            // 
            // textDirectorName
            // 
            this.textDirectorName.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDirectorName.Location = new System.Drawing.Point(321, 115);
            this.textDirectorName.Name = "textDirectorName";
            this.textDirectorName.ReadOnly = true;
            this.textDirectorName.Size = new System.Drawing.Size(371, 32);
            this.textDirectorName.TabIndex = 7;
            this.textDirectorName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textDirectorName_KeyDown);
            // 
            // textDirectorId
            // 
            this.textDirectorId.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDirectorId.Location = new System.Drawing.Point(321, 73);
            this.textDirectorId.Name = "textDirectorId";
            this.textDirectorId.ReadOnly = true;
            this.textDirectorId.Size = new System.Drawing.Size(371, 32);
            this.textDirectorId.TabIndex = 9;
            this.textDirectorId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textDirectorId_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(165, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 26);
            this.label4.TabIndex = 8;
            this.label4.Text = "Director  Id";
            // 
            // txtResignationDate
            // 
            this.txtResignationDate.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResignationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtResignationDate.Location = new System.Drawing.Point(321, 23);
            this.txtResignationDate.Name = "txtResignationDate";
            this.txtResignationDate.Size = new System.Drawing.Size(371, 29);
            this.txtResignationDate.TabIndex = 11;
            this.txtResignationDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtResignationDate_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(110, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 26);
            this.label2.TabIndex = 10;
            this.label2.Text = " Resignation date";
            // 
            // DirectorResignation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 351);
            this.Controls.Add(this.txtResignationDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textDirectorId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textDirectorName);
            this.Controls.Add(this.buttonDone);
            this.Controls.Add(this.txtCauseOfResignation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "DirectorResignation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DirectorDesignation";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DirectorResignation_FormClosed);
            this.Load += new System.EventHandler(this.DirectorResignation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCauseOfResignation;
        private System.Windows.Forms.Button buttonDone;
        public  System.Windows.Forms.TextBox textDirectorName;
        public  System.Windows.Forms.TextBox textDirectorId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker txtResignationDate;
        private System.Windows.Forms.Label label2;
    }
}