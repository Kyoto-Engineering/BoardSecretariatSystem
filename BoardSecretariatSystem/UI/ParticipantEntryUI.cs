﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoardSecretariatSystem
{
    public partial class ParticipantEntryUI : Form
    {
        public ParticipantEntryUI()
        {
            InitializeComponent();
        }

        private void ParticipantEntryUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            MainUI mainUI = new MainUI();
            mainUI.Show();
        }
    }
}