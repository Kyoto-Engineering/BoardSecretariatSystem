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
    public partial class BoardMemoManagement : Form
    {
        public BoardMemoManagement()
        {
            InitializeComponent();
        }

        private void BoardMemoManagement_FormClosed(object sender, FormClosedEventArgs e)
        {
                            this.Hide();
            MeetingManagementUI frm=new MeetingManagementUI();
                             frm.Show();
        }
    }
}
