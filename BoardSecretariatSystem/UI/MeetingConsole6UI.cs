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
        public int metingTypeId, meetingNum, meetingNum1,currentMeetingminutesId,meetingId;
        public string userId, labelk, labelg, agendaSl, meetingAgendaId, agendaSerialForMeeting,memo;


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
                //con = new SqlConnection(cs.DBConn);
                //con.Open();
                //string query = "Select MeetingTypeId From Meeting where MeetingTypeId=1";
                //cmd = new SqlCommand(query, con);
                //rdr = cmd.ExecuteReader();
                //if (rdr.Read())
                //{
                //    metingTypeId = (rdr.GetInt32(0));
                //}

                //if (metingTypeId == 1)
                //{
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                   // string qr2 = "SELECT MAX(Meeting.MeetingNo) FROM Meeting where Meeting.MeetingTypeId='" + metingTypeId + "'";
                    string qr2 = "SELECT MAX(Meeting.MeetingNo) FROM Meeting";
                    cmd = new SqlCommand(qr2, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        if (!rdr.IsDBNull(0))
                        {
                            meetingNum = (rdr.GetInt32(0));
                            if (meetingNum == 1)
                            {
                                meetingNum1 = meetingNum;
                                txtMeetingNumber.Text = meetingNum1.ToString();                                
                            }
                            else if (meetingNum == 2)
                            {
                                meetingNum1 = meetingNum;
                                txtMeetingNumber.Text = meetingNum1.ToString();
                            }

                            else if (meetingNum == 3)
                            {
                                meetingNum1 = meetingNum;
                                txtMeetingNumber.Text = meetingNum1.ToString();
                            }

                            else if (meetingNum >= 4)
                            {
                                meetingNum1 = meetingNum;
                                txtMeetingNumber.Text = meetingNum1.ToString();                               
                            }
                        }
                        else
                        {
                            MessageBox.Show("You need to Create or Schedule a new Meeting", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        

                    }
                //}
                //else
                //{
                //    MessageBox.Show("You need to Create or Schedule a new Meeting", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    //meetingNum1 = meetingNum;
                //    //txtMeetingNumber.Text = meetingNum1.ToString();
                //    //txtMeetingTitle.Text = "1st Board Meeting";
                //}
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

        public void GetAllSelectedAgenda()
        {

            try
            {
                con = new SqlConnection(cs.DBConn);
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Agenda.AgendaNo, Agenda.AgendaTitle,SelectedAgenda.MeetingAgendaId,Agenda.Memo FROM   Meeting INNER JOIN SelectedAgenda ON Meeting.MeetingId = SelectedAgenda.MeetingId INNER JOIN Agenda ON SelectedAgenda.AgendaId = Agenda.AgendaId  order by  SelectedAgenda.MeetingAgendaId asc", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.Rows.Clear();
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = item[3].ToString(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void GetSerialNumber()
        {
            //try
            //{
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string qr = "SELECT MAX(Meeting.MeetingId) FROM Meeting where Meeting.MeetingNo='" +meetingNum + "'";
                    cmd = new SqlCommand(qr, con);
                    rdr = cmd.ExecuteReader();
                   if (rdr.Read())
                   {
                      meetingId = (rdr.GetInt32(0));
                   }
                   con.Close();
                   con = new SqlConnection(cs.DBConn);
                   con.Open();
                   string qr2 = "SELECT MAX(SelectedAgenda.AgendaSerialForMeeting) FROM MeetingMinutes where MeetingMinutes.MeetingId='" + meetingId + "'";
                   cmd = new SqlCommand(qr2, con);
                   rdr = cmd.ExecuteReader();
                   if (rdr.Read())
                   {
                       if (!(rdr.IsDBNull(0)))
                       {
                           agendaSerialForMeeting = (rdr.GetString(0));
                       }
                       else
                       {
                           agendaSerialForMeeting = 1.ToString();
                       }
                   }
                   else
                   {
                       agendaSerialForMeeting = 1.ToString();
                   }
                  con.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void ResetDBNull()
        {
            if (!rdr.IsDBNull(0))
            {


                MessageBox.Show("The Balance Carry Forwarding is Already has  Approved  for this Year", "Report",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {

                this.Hide();
               

            }
        }
        private void MeetingConsole6UI_Load(object sender, EventArgs e)
        {
            GetAllSelectedAgenda();
            userId = frmLogin.uId.ToString();
            GetMeetingNumber();
        }
        private void SaveSelectedAgenda()
        {
            //try
            //{
                GetSerialNumber();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query2 = "insert into MeetingMinutes(MeetingId,MeetingAgendaId,AgendaSerialForMeeting,Memo,Discussion,Resolution,UserId,DateAndTime) values(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                cmd = new SqlCommand(query2, con);
                cmd.Parameters.AddWithValue("@d1",txtMeetingNumber.Text);
                cmd.Parameters.AddWithValue("@d2",meetingAgendaId);
                cmd.Parameters.AddWithValue("@d3",agendaSerialForMeeting);
                cmd.Parameters.AddWithValue("@d4",memo);
                cmd.Parameters.AddWithValue("@d5", txtDiscussion.Text);
                cmd.Parameters.AddWithValue("@d6", txtDraftResolution.Text);
                cmd.Parameters.AddWithValue("@d7", userId);
                cmd.Parameters.AddWithValue("@d8", DateTime.UtcNow.ToLocalTime());               
                currentMeetingminutesId = (int)cmd.ExecuteScalar();
                con.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
        private void addToListButton_Click(object sender, EventArgs e)
        {
            //try
            //{               
                if (listView1.Items.Count == 0)
                {
                    ListViewItem lst = new ListViewItem();
                    lst.SubItems.Add(agendaSl);
                    lst.SubItems.Add(txtAgendaTitle.Text);                   
                    lst.SubItems.Add(txtDiscussion.Text);
                    lst.SubItems.Add(txtDraftResolution.Text); 
                                     
                    listView1.Items.Add(lst);
                    SaveSelectedAgenda();
                    txtAgendaTitle.Clear();
                    txtDiscussion.Clear();
                    txtDraftResolution.Clear();
                    
                    return;
                }

                ListViewItem lst1 = new ListViewItem();
                lst1.SubItems.Add(agendaSl);
                lst1.SubItems.Add(txtAgendaTitle.Text);
                lst1.SubItems.Add(txtDiscussion.Text);
                lst1.SubItems.Add(txtDraftResolution.Text);

                listView1.Items.Add(lst1);
                SaveSelectedAgenda();
                txtAgendaTitle.Clear();
                txtDiscussion.Clear();
                txtDraftResolution.Clear();                
                return;
              
               
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
               
        }
        public void ClearDiscussedAgenda()
        {

            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {
                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                }

            }
            dataGridView1.Refresh();
        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.CurrentRow;
                 agendaSl = dr.Cells[0].Value.ToString();             
                 txtAgendaTitle.Text = dr.Cells[1].Value.ToString();
                 meetingAgendaId = dr.Cells[2].Value.ToString();
                 memo = dr.Cells[3].Value.ToString();
                 labelg = labelk;
                 ClearDiscussedAgenda();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetStatusForMeetingMinutes()
        {
            try
            {
               
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query2 = "Update  Meeting Set AllDiscussionCompleted=@d1 where  Meeting.MeetingId='"+meetingId+"' )";
                cmd = new SqlCommand(query2, con);
                cmd.Parameters.AddWithValue("@d1", 1);
                cmd.ExecuteReader();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void saveAllButton_Click(object sender, EventArgs e)
        {
            SetStatusForMeetingMinutes();
        }
    }
}
