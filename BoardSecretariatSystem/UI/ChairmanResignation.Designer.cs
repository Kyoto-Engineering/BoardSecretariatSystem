namespace BoardSecretariatSystem.UI
{
    partial class ChairmanResignation
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
            this.textChairmanId = new System.Windows.Forms.TextBox();
            this.textChairmanName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonDone
            // 
            this.buttonDone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.buttonDone.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDone.ForeColor = System.Drawing.Color.Blue;
            this.buttonDone.Location = new System.Drawing.Point(612, 313);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(143, 82);
            this.buttonDone.TabIndex = 13;
            this.buttonDone.Text = "Done";
            this.buttonDone.UseVisualStyleBackColor = false;
            this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
            // 
            // txtResignationCause
            // 
            this.txtResignationCause.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResignationCause.Location = new System.Drawing.Point(328, 244);
            this.txtResignationCause.Name = "txtResignationCause";
            this.txtResignationCause.Size = new System.Drawing.Size(427, 39);
            this.txtResignationCause.TabIndex = 12;
            this.txtResignationCause.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtResignationCause_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(269, 31);
            this.label3.TabIndex = 11;
            this.label3.Text = "Cause Of Resignation";
            // 
            // txtDateOfRetirement
            // 
            this.txtDateOfRetirement.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateOfRetirement.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDateOfRetirement.Location = new System.Drawing.Point(328, 66);
            this.txtDateOfRetirement.Name = "txtDateOfRetirement";
            this.txtDateOfRetirement.Size = new System.Drawing.Size(427, 39);
            this.txtDateOfRetirement.TabIndex = 10;
            this.txtDateOfRetirement.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDateOfRetirement_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(290, 31);
            this.label2.TabIndex = 9;
            this.label2.Text = "Select Resignation Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(96, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 31);
            this.label1.TabIndex = 8;
            this.label1.Text = " Chairman Name";
            // 
            // textChairmanId
            // 
            this.textChairmanId.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textChairmanId.Location = new System.Drawing.Point(328, 122);
            this.textChairmanId.Name = "textChairmanId";
            this.textChairmanId.Size = new System.Drawing.Size(427, 39);
            this.textChairmanId.TabIndex = 14;
            this.textChairmanId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textChairmanId_KeyDown);
            // 
            // textChairmanName
            // 
            this.textChairmanName.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textChairmanName.Location = new System.Drawing.Point(328, 181);
            this.textChairmanName.Name = "textChairmanName";
            this.textChairmanName.Size = new System.Drawing.Size(427, 39);
            this.textChairmanName.TabIndex = 15;
            this.textChairmanName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textChairmanName_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(132, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 31);
            this.label4.TabIndex = 16;
            this.label4.Text = " Chairman Id";
            // 
            // ChairmanResignation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 442);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textChairmanName);
            this.Controls.Add(this.textChairmanId);
            this.Controls.Add(this.buttonDone);
            this.Controls.Add(this.txtResignationCause);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDateOfRetirement);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ChairmanResignation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChairmanResignation";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ChairmanResignation_FormClosed);
            this.Load += new System.EventHandler(this.ChairmanResignation_Load);
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
        public  System.Windows.Forms.TextBox textChairmanId;
        public  System.Windows.Forms.TextBox textChairmanName;
        private System.Windows.Forms.Label label4;
    }
}