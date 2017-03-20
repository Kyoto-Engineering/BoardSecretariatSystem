namespace BoardSecretariatSystem.UI
{
    partial class DirectorCreation
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbDirectorName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbDirectorName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(583, 127);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cmbDirectorName
            // 
            this.cmbDirectorName.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDirectorName.FormattingEnabled = true;
            this.cmbDirectorName.Location = new System.Drawing.Point(262, 43);
            this.cmbDirectorName.Name = "cmbDirectorName";
            this.cmbDirectorName.Size = new System.Drawing.Size(299, 34);
            this.cmbDirectorName.TabIndex = 43;
            this.cmbDirectorName.SelectedIndexChanged += new System.EventHandler(this.cmbDirectorName_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(250, 26);
            this.label2.TabIndex = 41;
            this.label2.Text = "Select Derector Name :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Fuchsia;
            this.label3.Location = new System.Drawing.Point(172, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(258, 31);
            this.label3.TabIndex = 1;
            this.label3.Text = "Appoint the Director";
            // 
            // buttonCreate
            // 
            this.buttonCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonCreate.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCreate.ForeColor = System.Drawing.Color.Blue;
            this.buttonCreate.Location = new System.Drawing.Point(430, 185);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(131, 76);
            this.buttonCreate.TabIndex = 2;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseVisualStyleBackColor = false;
            this.buttonCreate.Click += new System.EventHandler(this.button1_Click);
            // 
            // DirectorCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(607, 287);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "DirectorCreation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DirectorCreation";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DirectorCreation_FormClosed);
            this.Load += new System.EventHandler(this.DirectorCreation_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbDirectorName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonCreate;
    }
}