namespace BoardSecretariatSystem.UI
{
    partial class BoardManagementUI
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
            this.buttonChairman = new System.Windows.Forms.Button();
            this.buttonMD = new System.Windows.Forms.Button();
            this.buttonDirector = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(402, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Board Management UI";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonChairman);
            this.groupBox1.Controls.Add(this.buttonMD);
            this.groupBox1.Controls.Add(this.buttonDirector);
            this.groupBox1.Location = new System.Drawing.Point(28, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(171, 452);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // buttonChairman
            // 
            this.buttonChairman.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.buttonChairman.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonChairman.ForeColor = System.Drawing.Color.Blue;
            this.buttonChairman.Location = new System.Drawing.Point(12, 175);
            this.buttonChairman.Name = "buttonChairman";
            this.buttonChairman.Size = new System.Drawing.Size(143, 65);
            this.buttonChairman.TabIndex = 10;
            this.buttonChairman.Text = "Chairman";
            this.buttonChairman.UseVisualStyleBackColor = false;
            this.buttonChairman.Click += new System.EventHandler(this.buttonChairman_Click);
            // 
            // buttonMD
            // 
            this.buttonMD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.buttonMD.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMD.ForeColor = System.Drawing.Color.Blue;
            this.buttonMD.Location = new System.Drawing.Point(11, 89);
            this.buttonMD.Name = "buttonMD";
            this.buttonMD.Size = new System.Drawing.Size(144, 66);
            this.buttonMD.TabIndex = 9;
            this.buttonMD.Text = "Managing Director";
            this.buttonMD.UseVisualStyleBackColor = false;
            this.buttonMD.Click += new System.EventHandler(this.buttonMD_Click);
            // 
            // buttonDirector
            // 
            this.buttonDirector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.buttonDirector.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDirector.ForeColor = System.Drawing.Color.Blue;
            this.buttonDirector.Location = new System.Drawing.Point(12, 19);
            this.buttonDirector.Name = "buttonDirector";
            this.buttonDirector.Size = new System.Drawing.Size(144, 60);
            this.buttonDirector.TabIndex = 8;
            this.buttonDirector.Text = "Director";
            this.buttonDirector.UseVisualStyleBackColor = false;
            this.buttonDirector.Click += new System.EventHandler(this.buttonMultiCombo_Click);
            // 
            // BoardManagementUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.BackgroundImage = global::BoardSecretariatSystem.Properties.Resources.background_6677;
            this.ClientSize = new System.Drawing.Size(971, 583);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "BoardManagementUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BoardManagementUI";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BoardManagementUI_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonMD;
        private System.Windows.Forms.Button buttonDirector;
        private System.Windows.Forms.Button buttonChairman;
    }
}