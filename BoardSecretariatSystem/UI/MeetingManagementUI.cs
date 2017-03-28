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
    public partial class MeetingManagementUI : Form
    {
        public MeetingManagementUI()
        {
            InitializeComponent();
        }

        private void buttonAgendaSelection_Click(object sender, EventArgs e)
        {
                      this.Hide();
            MeetingEntry frm=new MeetingEntry();    
                       frm.Show();
        }

        private void buttonMeetingCreate_Click(object sender, EventArgs e)
        {
            this.Hide();
            MeetingCreation frm = new MeetingCreation();
            frm.Show();
        }

        private void MeetingManagementUI_FormClosed(object sender, FormClosedEventArgs e)
        {
               this.Hide();
            MainUI frm=new MainUI();
                frm.Show();
        }

        private void buttonBoardMemo_Click(object sender, EventArgs e)
        {
                         this.Hide();
            BoardMemoManagement frm =new BoardMemoManagement();
                         frm.Show();
        }
    }
}
