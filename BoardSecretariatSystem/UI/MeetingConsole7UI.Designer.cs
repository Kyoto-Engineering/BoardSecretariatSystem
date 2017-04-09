namespace BoardSecretariatSystem.UI
{
    partial class MeetingConsole7UI
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.resolvedDataGridView = new System.Windows.Forms.DataGridView();
            this.minutedDataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addToListButton = new System.Windows.Forms.Button();
            this.saveAllButton = new System.Windows.Forms.Button();
            this.meetingNumOrIDTextBox = new System.Windows.Forms.TextBox();
            this.agendumTextBox = new System.Windows.Forms.TextBox();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.textWithSpellCheck1 = new BoardSecretariatSystem.TextWithSpellCheck();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.resolvedDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minutedDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(248, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(485, 62);
            this.label1.TabIndex = 0;
            this.label1.Text = "                   Meeting Console 7  \r\nResolution Management (After Meeting)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Magenta;
            this.label2.Location = new System.Drawing.Point(12, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Meeting Number/ ID :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Magenta;
            this.label3.Location = new System.Drawing.Point(32, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "Agendum #\r\n";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Magenta;
            this.label4.Location = new System.Drawing.Point(23, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 26);
            this.label4.TabIndex = 3;
            this.label4.Text = "Resolution :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(948, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(189, 26);
            this.label5.TabIndex = 4;
            this.label5.Text = "Minuted Agenda \r\n";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(144, 410);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(186, 26);
            this.label6.TabIndex = 5;
            this.label6.Text = "Resolved Agenda";
            // 
            // resolvedDataGridView
            // 
            this.resolvedDataGridView.AllowUserToAddRows = false;
            this.resolvedDataGridView.AllowUserToDeleteRows = false;
            this.resolvedDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.resolvedDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.resolvedDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resolvedDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.resolvedDataGridView.Location = new System.Drawing.Point(12, 444);
            this.resolvedDataGridView.Name = "resolvedDataGridView";
            this.resolvedDataGridView.ReadOnly = true;
            this.resolvedDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.resolvedDataGridView.Size = new System.Drawing.Size(1015, 150);
            this.resolvedDataGridView.TabIndex = 6;
            // 
            // minutedDataGridView
            // 
            this.minutedDataGridView.AllowUserToAddRows = false;
            this.minutedDataGridView.AllowUserToDeleteRows = false;
            this.minutedDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.minutedDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.minutedDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.minutedDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column7,
            this.Column8});
            this.minutedDataGridView.Location = new System.Drawing.Point(748, 108);
            this.minutedDataGridView.Name = "minutedDataGridView";
            this.minutedDataGridView.ReadOnly = true;
            this.minutedDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.minutedDataGridView.Size = new System.Drawing.Size(404, 150);
            this.minutedDataGridView.TabIndex = 7;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Agendum Sl";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Agendum Title";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Column7";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Visible = false;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Column8";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Visible = false;
            // 
            // addToListButton
            // 
            this.addToListButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addToListButton.ForeColor = System.Drawing.Color.Fuchsia;
            this.addToListButton.Location = new System.Drawing.Point(409, 138);
            this.addToListButton.Name = "addToListButton";
            this.addToListButton.Size = new System.Drawing.Size(124, 37);
            this.addToListButton.TabIndex = 8;
            this.addToListButton.Text = "Add to List\r\n";
            this.addToListButton.UseVisualStyleBackColor = true;
            // 
            // saveAllButton
            // 
            this.saveAllButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveAllButton.ForeColor = System.Drawing.Color.Fuchsia;
            this.saveAllButton.Location = new System.Drawing.Point(1049, 546);
            this.saveAllButton.Name = "saveAllButton";
            this.saveAllButton.Size = new System.Drawing.Size(103, 32);
            this.saveAllButton.TabIndex = 9;
            this.saveAllButton.Text = "Save All\r\n";
            this.saveAllButton.UseVisualStyleBackColor = true;
            // 
            // meetingNumOrIDTextBox
            // 
            this.meetingNumOrIDTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.meetingNumOrIDTextBox.Location = new System.Drawing.Point(258, 108);
            this.meetingNumOrIDTextBox.Name = "meetingNumOrIDTextBox";
            this.meetingNumOrIDTextBox.ReadOnly = true;
            this.meetingNumOrIDTextBox.Size = new System.Drawing.Size(255, 26);
            this.meetingNumOrIDTextBox.TabIndex = 10;
            // 
            // agendumTextBox
            // 
            this.agendumTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.agendumTextBox.Location = new System.Drawing.Point(186, 140);
            this.agendumTextBox.Name = "agendumTextBox";
            this.agendumTextBox.ReadOnly = true;
            this.agendumTextBox.Size = new System.Drawing.Size(182, 26);
            this.agendumTextBox.TabIndex = 11;
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(164, 181);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(569, 207);
            this.elementHost1.TabIndex = 12;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.textWithSpellCheck1;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 203.0457F;
            this.Column3.HeaderText = "Agendum Sl";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.FillWeight = 65.65144F;
            this.Column4.HeaderText = "Agendum Title";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.FillWeight = 65.65144F;
            this.Column5.HeaderText = "Discussion";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.FillWeight = 65.65144F;
            this.Column6.HeaderText = "Resolution";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // MeetingConsole7UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 606);
            this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.agendumTextBox);
            this.Controls.Add(this.meetingNumOrIDTextBox);
            this.Controls.Add(this.saveAllButton);
            this.Controls.Add(this.addToListButton);
            this.Controls.Add(this.minutedDataGridView);
            this.Controls.Add(this.resolvedDataGridView);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "MeetingConsole7UI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MeetingConsole7";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MeetingConsole7UI_FormClosed);
            this.Load += new System.EventHandler(this.MeetingConsole7UI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.resolvedDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minutedDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView resolvedDataGridView;
        private System.Windows.Forms.DataGridView minutedDataGridView;
        private System.Windows.Forms.Button addToListButton;
        private System.Windows.Forms.Button saveAllButton;
        private System.Windows.Forms.TextBox meetingNumOrIDTextBox;
        private System.Windows.Forms.TextBox agendumTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private TextWithSpellCheck textWithSpellCheck1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}