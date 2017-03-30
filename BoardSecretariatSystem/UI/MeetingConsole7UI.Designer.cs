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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.resolvedDataGridView = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.minutedDataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addToListButton = new System.Windows.Forms.Button();
            this.saveAllButton = new System.Windows.Forms.Button();
            this.meetingNumOrIDTextBox = new System.Windows.Forms.TextBox();
            this.agendumTextBox = new System.Windows.Forms.TextBox();
            this.resolutionRichTextBox = new System.Windows.Forms.RichTextBox();
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
            this.label2.Location = new System.Drawing.Point(32, 129);
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
            this.label3.Location = new System.Drawing.Point(32, 162);
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
            this.label4.Location = new System.Drawing.Point(32, 208);
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
            this.label5.Location = new System.Drawing.Point(659, 101);
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
            this.label6.Location = new System.Drawing.Point(50, 274);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(483, 52);
            this.label6.TabIndex = 5;
            this.label6.Text = "                         Resolved Agenda\r\n(List of all Discussed Agenda for viewi" +
    "ng only)\r\n";
            // 
            // resolvedDataGridView
            // 
            this.resolvedDataGridView.AllowUserToAddRows = false;
            this.resolvedDataGridView.AllowUserToDeleteRows = false;
            this.resolvedDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.resolvedDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.resolvedDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resolvedDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.resolvedDataGridView.Location = new System.Drawing.Point(37, 338);
            this.resolvedDataGridView.Name = "resolvedDataGridView";
            this.resolvedDataGridView.ReadOnly = true;
            this.resolvedDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.resolvedDataGridView.Size = new System.Drawing.Size(496, 150);
            this.resolvedDataGridView.TabIndex = 6;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Agendum Sl";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Agendum Title";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Discussion";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Resolution";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // minutedDataGridView
            // 
            this.minutedDataGridView.AllowUserToAddRows = false;
            this.minutedDataGridView.AllowUserToDeleteRows = false;
            this.minutedDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.minutedDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.minutedDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.minutedDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.minutedDataGridView.Location = new System.Drawing.Point(554, 143);
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
            // addToListButton
            // 
            this.addToListButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addToListButton.ForeColor = System.Drawing.Color.Fuchsia;
            this.addToListButton.Location = new System.Drawing.Point(552, 299);
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
            this.saveAllButton.Location = new System.Drawing.Point(855, 456);
            this.saveAllButton.Name = "saveAllButton";
            this.saveAllButton.Size = new System.Drawing.Size(103, 32);
            this.saveAllButton.TabIndex = 9;
            this.saveAllButton.Text = "Save All\r\n";
            this.saveAllButton.UseVisualStyleBackColor = true;
            // 
            // meetingNumOrIDTextBox
            // 
            this.meetingNumOrIDTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.meetingNumOrIDTextBox.Location = new System.Drawing.Point(278, 135);
            this.meetingNumOrIDTextBox.Name = "meetingNumOrIDTextBox";
            this.meetingNumOrIDTextBox.Size = new System.Drawing.Size(255, 26);
            this.meetingNumOrIDTextBox.TabIndex = 10;
            // 
            // agendumTextBox
            // 
            this.agendumTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.agendumTextBox.Location = new System.Drawing.Point(186, 167);
            this.agendumTextBox.Name = "agendumTextBox";
            this.agendumTextBox.Size = new System.Drawing.Size(347, 26);
            this.agendumTextBox.TabIndex = 11;
            // 
            // resolutionRichTextBox
            // 
            this.resolutionRichTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resolutionRichTextBox.Location = new System.Drawing.Point(186, 208);
            this.resolutionRichTextBox.Name = "resolutionRichTextBox";
            this.resolutionRichTextBox.Size = new System.Drawing.Size(347, 63);
            this.resolutionRichTextBox.TabIndex = 12;
            this.resolutionRichTextBox.Text = "";
            // 
            // MeetingConsole7UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 500);
            this.Controls.Add(this.resolutionRichTextBox);
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
            this.Name = "MeetingConsole7UI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MeetingConsole7";
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.TextBox meetingNumOrIDTextBox;
        private System.Windows.Forms.TextBox agendumTextBox;
        private System.Windows.Forms.RichTextBox resolutionRichTextBox;
    }
}