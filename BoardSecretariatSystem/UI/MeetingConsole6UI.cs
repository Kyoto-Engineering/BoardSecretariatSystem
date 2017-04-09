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
    public partial class MeetingConsole6UI : Form
    {
        private SqlCommand cmd;
        private SqlConnection con;
        private SqlDataReader rdr;
        private SqlDataAdapter ada;
        ConnectionString cs=new ConnectionString();
        public int metingTypeId, meetingNum, meetingNum1,currentMeetingminutesId;
        public string userId;


        public MeetingConsole6UI()
        {
            InitializeComponent();
        }

        private void MeetingConsole6UI_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MeetingManagementUI frm = new MeetingManagementUI();
            frm.Show();
        }
        private void GetMeetingNumber()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "Select MeetingTypeId From Meeting where MeetingTypeId=1";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    metingTypeId = (rdr.GetInt32(0));
                }

                if (metingTypeId == 1)
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string qr2 = "SELECT MAX(Meeting.MeetingNo) FROM Meeting where Meeting.MeetingTypeId='" + metingTypeId + "'";
                    cmd = new SqlCommand(qr2, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        meetingNum = (rdr.GetInt32(0));
                        if (meetingNum == 1)
                        {
                            meetingNum1 = meetingNum;
                            txtMeetingNumber.Text = meetingNum1.ToString();
                            //txtMeetingTitle.Text = "1st Board Meeting";
                        }
                        else if (meetingNum == 2)
                        {
                            meetingNum1 = meetingNum;
                            txtMeetingNumber.Text = meetingNum1.ToString();
                           // txtMeetingTitle.Text = "2nd Board Meeting";
                        }

                        else if (meetingNum == 3)
                        {
                            meetingNum1 = meetingNum;
                            txtMeetingNumber.Text = meetingNum1.ToString();
                           // txtMeetingTitle.Text = "3rd Board Meeting";
                        }

                        else if (meetingNum >= 4)
                        {
                            meetingNum1 = meetingNum;
                            txtMeetingNumber.Text = meetingNum1.ToString();
                           // txtMeetingTitle.Text = meetingNum + "th Board Meeting";
                        }

                    }
                }
                else
                {
                    MessageBox.Show("You need to Create or Schedule a new Meeting", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //meetingNum1 = meetingNum;
                    //txtMeetingNumber.Text = meetingNum1.ToString();
                    //txtMeetingTitle.Text = "1st Board Meeting";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void GetAdditionalParticipant()
        {

            try
            {
                con = new SqlConnection(cs.DBConn);
                SqlDataAdapter sda = new SqlDataAdapter("SELECT  Participant.ParticipantId,Participant.ParticipantName, Participant.Designation FROM   Participant where  Participant.ParticipantId not in (Select Shareholder.ParticipantId from Shareholder)", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.Rows.Clear();
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                    // dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void MeetingConsole6UI_Load(object sender, EventArgs e)
        {
            userId = frmLogin.uId.ToString();
            GetMeetingNumber();
        }
        private void SaveSelectedAgenda()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query2 = "insert into MeetingMinutes(MeetingId,MeetingAgendaId,AgendaSerialForMeeting,Memo,Discussion,Resolution,UserId,DateAndTime) values(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                cmd = new SqlCommand(query2, con);
                cmd.Parameters.AddWithValue("@d1", txtMeetingNumber.Text);
                //cmd.Parameters.AddWithValue("@d2", tAgendaId);
               // cmd.Parameters.AddWithValue("@d3", tAgendaId);
               // cmd.Parameters.AddWithValue("@d4", tAgendaId);
                cmd.Parameters.AddWithValue("@d5", txtDiscussion.Text);
                cmd.Parameters.AddWithValue("@d6", txtDraftResolution.Text);
                cmd.Parameters.AddWithValue("@d7", userId);
                cmd.Parameters.AddWithValue("@d8", DateTime.UtcNow.ToLocalTime());               
                currentMeetingminutesId = (int)cmd.ExecuteScalar();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void addToListButton_Click(object sender, EventArgs e)
        {

        }
    }
}
