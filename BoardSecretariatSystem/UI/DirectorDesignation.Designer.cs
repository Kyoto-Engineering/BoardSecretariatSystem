namespace BoardSecretariatSystem.UI
{
    partial class DirectorDesignation
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
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.comboBoxWithGrid1 = new BoardSecretariatSystem.ComboBoxWithGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtResignation = new System.Windows.Forms.TextBox();
            this.buttonDone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(321, 29);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(371, 68);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.comboBoxWithGrid1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(71, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Director Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(58, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(254, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Select Resignation Date";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(321, 125);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(371, 29);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(71, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(233, 26);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cause Of Resignation";
            // 
            // txtResignation
            // 
            this.txtResignation.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResignation.Location = new System.Drawing.Point(321, 181);
            this.txtResignation.Name = "txtResignation";
            this.txtResignation.Size = new System.Drawing.Size(371, 32);
            this.txtResignation.TabIndex = 5;
            // 
            // buttonDone
            // 
            this.buttonDone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.buttonDone.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDone.ForeColor = System.Drawing.Color.Blue;
            this.buttonDone.Location = new System.Drawing.Point(442, 253);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(182, 51);
            this.buttonDone.TabIndex = 6;
            this.buttonDone.Text = "Done";
            this.buttonDone.UseVisualStyleBackColor = false;
            // 
            // DirectorDesignation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 351);
            this.Controls.Add(this.buttonDone);
            this.Controls.Add(this.txtResignation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.elementHost1);
            this.Name = "DirectorDesignation";
            this.Text = "DirectorDesignation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private ComboBoxWithGrid comboBoxWithGrid1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtResignation;
        private System.Windows.Forms.Button buttonDone;
    }
}