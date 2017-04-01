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
            this.label3 = new System.Windows.Forms.Label();
            this.agendaSaveButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.txtAgendaHeader = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbAgendaType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAgendaTitle = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Magenta;
            this.label3.Location = new System.Drawing.Point(27, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 26);
            this.label3.TabIndex = 28;
            this.label3.Text = "Agenda Header :";
            // 
            // agendaSaveButton
            // 
            this.agendaSaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.agendaSaveButton.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.agendaSaveButton.ForeColor = System.Drawing.Color.Blue;
            this.agendaSaveButton.Location = new System.Drawing.Point(1001, 515);
            this.agendaSaveButton.Name = "agendaSaveButton";
            this.agendaSaveButton.Size = new System.Drawing.Size(160, 91);
            this.agendaSaveButton.TabIndex = 30;
            this.agendaSaveButton.Text = "Save";
            this.agendaSaveButton.UseVisualStyleBackColor = false;
            this.agendaSaveButton.Click += new System.EventHandler(this.agendaSaveButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(514, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(363, 32);
            this.label4.TabIndex = 31;
            this.label4.Text = "Agenda Template  Creation  ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Location = new System.Drawing.Point(16, 216);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(753, 398);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " ";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader5,
            this.columnHeader6});
            this.listView1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(9, 19);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(727, 359);
            this.listView1.TabIndex = 38;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Agenda Header";
            this.columnHeader2.Width = 144;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Agenda Title";
            this.columnHeader3.Width = 355;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Agenda Type";
            this.columnHeader5.Width = 178;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "AT Id";
            this.columnHeader6.Width = 97;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.button1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Yellow;
            this.button1.Location = new System.Drawing.Point(614, 106);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 51);
            this.button1.TabIndex = 44;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // txtAgendaHeader
            // 
            this.txtAgendaHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtAgendaHeader.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAgendaHeader.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAgendaHeader.ForeColor = System.Drawing.Color.Blue;
            this.txtAgendaHeader.Location = new System.Drawing.Point(220, 68);
            this.txtAgendaHeader.Name = "txtAgendaHeader";
            this.txtAgendaHeader.ReadOnly = true;
            this.txtAgendaHeader.Size = new System.Drawing.Size(377, 28);
            this.txtAgendaHeader.TabIndex = 48;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Magenta;
            this.label2.Location = new System.Drawing.Point(43, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 26);
            this.label2.TabIndex = 49;
            this.label2.Text = "Agenda  Type :";
            // 
            // cmbAgendaType
            // 
            this.cmbAgendaType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAgendaType.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAgendaType.FormattingEnabled = true;
            this.cmbAgendaType.Location = new System.Drawing.Point(220, 157);
            this.cmbAgendaType.Name = "cmbAgendaType";
            this.cmbAgendaType.Size = new System.Drawing.Size(377, 32);
            this.cmbAgendaType.TabIndex = 50;
            this.cmbAgendaType.SelectedIndexChanged += new System.EventHandler(this.cmbAgendaType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Magenta;
            this.label5.Location = new System.Drawing.Point(52, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 26);
            this.label5.TabIndex = 51;
            this.label5.Text = "Agenda Title :";
            // 
            // txtAgendaTitle
            // 
            this.txtAgendaTitle.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAgendaTitle.Location = new System.Drawing.Point(220, 111);
            this.txtAgendaTitle.Name = "txtAgendaTitle";
            this.txtAgendaTitle.Size = new System.Drawing.Size(377, 32);
            this.txtAgendaTitle.TabIndex = 52;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(775, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(556, 422);
            this.groupBox2.TabIndex = 53;
            this.groupBox2.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView1.Location = new System.Drawing.Point(18, 34);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(523, 373);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(769, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 31);
            this.label1.TabIndex = 54;
            this.label1.Text = "Agenda Bank";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Agenda Id";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Agenda Title";
            this.Column2.Name = "Column2";
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Agenda Type";
            this.Column3.Name = "Column3";
            this.Column3.Width = 180;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "AT Id";
            this.Column4.Name = "Column4";
            this.Column4.Width = 5;
            // 
            // AgendaEntryUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1334, 626);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtAgendaTitle);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbAgendaType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAgendaHeader);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.agendaSaveButton);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "AgendaEntryUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AgendaEntryUI";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AgendaEntryUI_FormClosed);
            this.Load += new System.EventHandler(this.AgendaEntryUI_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button agendaSaveButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtAgendaHeader;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbAgendaType;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAgendaTitle;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}