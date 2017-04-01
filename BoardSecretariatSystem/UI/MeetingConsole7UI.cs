using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoardSecretariatSystem.UI
{
    public partial class MeetingConsole7UI : Form
    {
        public MeetingConsole7UI()
        {
            InitializeComponent();
        }

        private void MeetingConsole7UI_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MeetingManagementUI frm = new MeetingManagementUI();
            frm.Show();
        }

   

       
    }
}
