using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BoardSecretariatSystem.DBGateway;

namespace BoardSecretariatSystem.UI
{
    public partial class MeetingManagementUI : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();

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
            con=new SqlConnection(cs.DBConn);
            con.Open();
            string qry = "Select Statuss  from  Meeting  where ";

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

        private void buttonMeetingInvitation_Click(object sender, EventArgs e)
        {
                     this.Hide();
            MeetingConsole3 frm=new MeetingConsole3();
                     frm.Show();
        }

        private void buttonCancelMeeting_Click(object sender, EventArgs e)
        {
            this.Hide();
            MeetingConsole4 frm = new MeetingConsole4();
            frm.Show();
        }

        private void buttonAttendance_Click(object sender, EventArgs e)
        {
            this.Hide();
            MeetingConsole5UI frm = new MeetingConsole5UI();
            frm.Show();
        }

        private void buttonMinutesManagement_Click(object sender, EventArgs e)
        {
            this.Hide();
            MeetingConsole6UI frm = new MeetingConsole6UI();
            frm.Show();
        }

        private void buttonResolutionManagement_Click(object sender, EventArgs e)
        {
            this.Hide();
            MeetingConsole7UI frm = new MeetingConsole7UI();
            frm.Show();
        }
    }
}
