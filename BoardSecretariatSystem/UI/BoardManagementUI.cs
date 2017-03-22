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
    public partial class BoardManagementUI : Form
    {
        public BoardManagementUI()
        {
            InitializeComponent();
        }

        private void buttonMultiCombo_Click(object sender, EventArgs e)
        {
            this.Hide();
            GridForShareHolder frm = new GridForShareHolder();
            frm.Show();
        }

        private void buttonMD_Click(object sender, EventArgs e)
        {
                   this.Hide();
                   ListOfDirector frm = new ListOfDirector();
                    frm.Show();
        }

        private void buttonChairman_Click(object sender, EventArgs e)
        {
                   this.Hide();
            ListofDirector2 frm=new ListofDirector2();
                  frm.Show();
        }

        private void BoardManagementUI_FormClosed(object sender, FormClosedEventArgs e)
        {
               this.Hide();
            MainUI frm=new MainUI();
                 frm.Show();
        }
    }
}
