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
        public decimal meetingId;
        public string status;

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

        private void CheckMeeting()
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string qry = "SELECT IDENT_CURRENT ('Meeting')";
            cmd = new SqlCommand(qry, con);
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                meetingId = (rdr.GetDecimal(0));
            }
            con.Close();

            con = new SqlConnection(cs.DBConn);
            con.Open();
            string qry2 = "SELECT Meeting.Statuss from  Meeting  where  Meeting.MeetingId='" + meetingId + "' ";
            cmd = new SqlCommand(qry2, con);
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                status = (rdr.GetString(0));
            }
            con.Close();
            if (status == "Open")
            {
                MessageBox.Show("Please Complete the current meeting before creating a new  meeting.", "error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                this.Hide();
                MeetingCreation frm = new MeetingCreation();
                frm.Show();
            }

        }
        private void buttonMeetingCreate_Click(object sender, EventArgs e)
        {

           //CheckMeeting();
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
        { con = new SqlConnection(cs.DBConn);
            con.Open();
            string query = "SELECT        MeetingId FROM            Meeting where  MeetingTypeId=1 and  Statuss='Open'";
            cmd = new SqlCommand(query, con);
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {

                         
            BoardMemoManagement frm =new BoardMemoManagement();
            //frm.FormClosed += new FormClosedEventHandler(frm2_FormClosed);
            //this.Hide();
                         //frm.Show();
                         frm.ShowDialog();
            }


            else
            {

                MessageBox.Show("Theere is no opened meeting", "Report",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);


            }

        }

        private void buttonMeetingInvitation_Click(object sender, EventArgs e)
        {
                     this.Hide();
            MeetingConsole3 frm=new MeetingConsole3();
                     frm.Show();
        }

        private void buttonCancelMeeting_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string query = "SELECT        MeetingId FROM            Meeting where  MeetingTypeId=1 and  Statuss='Open'";
            cmd = new SqlCommand(query, con);
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {



               
                
                MeetingConsole4 frm = new MeetingConsole4();
                //frm.FormClosed += new FormClosedEventHandler(frm2_FormClosed);
                frm.ShowDialog();


                 
                }


            else
            {

                MessageBox.Show("Theere is no opened meeting", "Report",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                    

            }
          
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

        private void frm2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
