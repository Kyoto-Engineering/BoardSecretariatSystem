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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.comboBoxWithGrid1 = new BoardSecretariatSystem.ComboBoxWithGrid();
            this.SuspendLayout();
            // 
            // buttonDone
            // 
            this.buttonDone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.buttonDone.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDone.ForeColor = System.Drawing.Color.Blue;
            this.buttonDone.Location = new System.Drawing.Point(414, 284);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(182, 71);
            this.buttonDone.TabIndex = 13;
            this.buttonDone.Text = "Done";
            this.buttonDone.UseVisualStyleBackColor = false;
            this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
            // 
            // txtResignationCause
            // 
            this.txtResignationCause.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResignationCause.Location = new System.Drawing.Point(328, 212);
            this.txtResignationCause.Name = "txtResignationCause";
            this.txtResignationCause.Size = new System.Drawing.Size(427, 39);
            this.txtResignationCause.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(37, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(269, 31);
            this.label3.TabIndex = 11;
            this.label3.Text = "Cause Of Resignation";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(326, 156);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(427, 39);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(290, 31);
            this.label2.TabIndex = 9;
            this.label2.Text = "Select Resignation Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(284, 31);
            this.label1.TabIndex = 8;
            this.label1.Text = "Select Chairman Name";
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(326, 60);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(427, 68);
            this.elementHost1.TabIndex = 7;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.comboBoxWithGrid1;
            // 
            // ChairmanResignation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 395);
            this.Controls.Add(this.buttonDone);
            this.Controls.Add(this.txtResignationCause);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.elementHost1);
            this.Name = "ChairmanResignation";
            this.Text = "ChairmanResignation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDone;
        private System.Windows.Forms.TextBox txtResignationCause;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private ComboBoxWithGrid comboBoxWithGrid1;
    }
}