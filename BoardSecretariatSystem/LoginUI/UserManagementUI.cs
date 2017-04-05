using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoardSecretariatSystem.LoginUI
{
    public partial class UserManagementUI : Form
    {
        public UserManagementUI()
        {
            InitializeComponent();
        }

        private void buttonRegistration_Click(object sender, EventArgs e)
        {
             this.Hide();
            registrationByAdmin frm=new registrationByAdmin();
             frm.Show();
        }

        private void UserManagementUI_FormClosed(object sender, FormClosedEventArgs e)
        {
               this.Hide();
            MainUI  frm=new MainUI();
                 frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
              this.Hide();
            Reset frm=new Reset();
              frm.Show();
        }
    }
}
