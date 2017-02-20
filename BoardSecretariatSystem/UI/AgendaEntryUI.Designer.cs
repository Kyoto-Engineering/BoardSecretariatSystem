namespace BoardSecretariatSystem
{
    partial class AgendaEntryUI
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
            this.boardNameComboBox = new System.Windows.Forms.ComboBox();
            this.companyNameComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.topicsTextBox = new System.Windows.Forms.TextBox();
            this.agendaSaveButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // boardNameComboBox
            // 
            this.boardNameComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.boardNameComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.boardNameComboBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boardNameComboBox.FormattingEnabled = true;
            this.boardNameComboBox.Location = new System.Drawing.Point(236, 114);
            this.boardNameComboBox.Name = "boardNameComboBox";
            this.boardNameComboBox.Size = new System.Drawing.Size(238, 27);
            this.boardNameComboBox.TabIndex = 27;
            this.boardNameComboBox.Leave += new System.EventHandler(this.boardNameComboBox_Leave);
            // 
            // companyNameComboBox
            // 
            this.companyNameComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.companyNameComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.companyNameComboBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.companyNameComboBox.FormattingEnabled = true;
            this.companyNameComboBox.Location = new System.Drawing.Point(236, 69);
            this.companyNameComboBox.Name = "companyNameComboBox";
            this.companyNameComboBox.Size = new System.Drawing.Size(238, 27);
            this.companyNameComboBox.TabIndex = 26;
            this.companyNameComboBox.SelectedIndexChanged += new System.EventHandler(this.companyNameComboBox_SelectedIndexChanged);
            this.companyNameComboBox.Leave += new System.EventHandler(this.companyNameComboBox_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(106, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 22);
            this.label2.TabIndex = 25;
            this.label2.Text = "Board Name :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(79, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 22);
            this.label1.TabIndex = 24;
            this.label1.Text = "Company Name :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(157, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 22);
            this.label3.TabIndex = 28;
            this.label3.Text = "Topics :";
            // 
            // topicsTextBox
            // 
            this.topicsTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topicsTextBox.Location = new System.Drawing.Point(236, 160);
            this.topicsTextBox.Multiline = true;
            this.topicsTextBox.Name = "topicsTextBox";
            this.topicsTextBox.Size = new System.Drawing.Size(238, 113);
            this.topicsTextBox.TabIndex = 29;
            // 
            // agendaSaveButton
            // 
            this.agendaSaveButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.agendaSaveButton.Location = new System.Drawing.Point(399, 291);
            this.agendaSaveButton.Name = "agendaSaveButton";
            this.agendaSaveButton.Size = new System.Drawing.Size(75, 33);
            this.agendaSaveButton.TabIndex = 30;
            this.agendaSaveButton.Text = "Save";
            this.agendaSaveButton.UseVisualStyleBackColor = true;
            this.agendaSaveButton.Click += new System.EventHandler(this.agendaSaveButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(240, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 28);
            this.label4.TabIndex = 31;
            this.label4.Text = "Topics Entry";
            // 
            // AgendaEntryUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(657, 399);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.agendaSaveButton);
            this.Controls.Add(this.topicsTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.boardNameComboBox);
            this.Controls.Add(this.companyNameComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "AgendaEntryUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AgendaEntryUI";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AgendaEntryUI_FormClosed);
            this.Load += new System.EventHandler(this.AgendaEntryUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox boardNameComboBox;
        private System.Windows.Forms.ComboBox companyNameComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox topicsTextBox;
        private System.Windows.Forms.Button agendaSaveButton;
        private System.Windows.Forms.Label label4;
    }
}