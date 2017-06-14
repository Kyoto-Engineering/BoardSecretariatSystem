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
        public int metingTypeId, meetingNum, meetingNum1, currentMeetingminutesId, meetingId, agendaSerialForMeeting;
        public string userId, labelk, labelg, agendaSl, meetingAgendaId,memo;
        private DataTable dt;
         DataGridViewRow dr=new DataGridViewRow();

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
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Participant.ParticipantId,Participant.ParticipantName, Participant.Designation FROM   Participant where  Participant.ParticipantId not in (Select Shareholder.ParticipantId from Shareholder)", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.Rows.Clear();
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();                    
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
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Agenda.AgendaNo, Agenda.AgendaTitle,SelectedAgenda.MeetingAgendaId,Agenda.Memo FROM   Meeting INNER JOIN SelectedAgenda ON Meeting.MeetingId = SelectedAgenda.MeetingId INNER JOIN Agenda ON SelectedAgenda.AgendaId = Agenda.AgendaId  where SelectedAgenda.MeetingAgendaId not in(Select MeetingMinutes.MeetingAgendaId from MeetingMinutes)  order by  SelectedAgenda.MeetingAgendaId asc", con);
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
            try
            {
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
                   string qr2 = "SELECT MAX(MeetingMinutes.AgendaSerialForMeeting)  FROM MeetingMinutes where MeetingMinutes.MeetingId='" + meetingId + "'";
                   cmd = new SqlCommand(qr2, con);
                   rdr = cmd.ExecuteReader();
                   if (rdr.Read())
                   {
                        if (!(rdr.IsDBNull(0)))
                       {
                           agendaSerialForMeeting = (rdr.GetInt32(0));
                           agendaSerialForMeeting = agendaSerialForMeeting + 1;

                       }
                       else
                       {
                           agendaSerialForMeeting = 1;
                       }
                   }
                   else
                   {
                       agendaSerialForMeeting = 1;
                   }
                  con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void ListOfMinutedAgenda()
        {
            listView1.View = View.Details;
            con = new SqlConnection(cs.DBConn);
            string qry = "SELECT  MeetingMinutes.AgendaSerialForMeeting, Agenda.AgendaTitle, MeetingMinutes.Discussion, MeetingMinutes.Resolution FROM  Agenda INNER JOIN SelectedAgenda ON Agenda.AgendaId = SelectedAgenda.AgendaId INNER JOIN MeetingMinutes ON SelectedAgenda.MeetingAgendaId = MeetingMinutes.MeetingAgendaId";
            ada = new SqlDataAdapter(qry, con);
            dt = new DataTable();
            ada.Fill(dt);
            for (int b = 0; b < dt.Rows.Count; b++)
            {
                DataRow dr = dt.Rows[b];
                ListViewItem listitem1 = new ListViewItem();
                listitem1.SubItems.Add(dr[0].ToString());
                listitem1.SubItems.Add(dr[1].ToString());
                listitem1.SubItems.Add(dr[2].ToString());
                listitem1.SubItems.Add(dr[3].ToString());               
                listView1.Items.Add(listitem1);
            }
        }
        private void MeetingConsole6UI_Load(object sender, EventArgs e)
        {
            ListOfMinutedAgenda();
            GetAllSelectedAgenda();
            userId = frmLogin.uId.ToString();
            GetMeetingNumber();
        }
        private void SaveMeetingMinutes()
        {
            try
            {                
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateMeetingStarted()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query2 = "Update  Meeting Set MeetingStarted=@d1 where  Meeting.MeetingId='" + meetingId + "' ";
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
        private void addToListButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAgendaTitle.Text))
            {
                MessageBox.Show("Please select agenda title from the Grid.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDiscussion.Text))
            {
                MessageBox.Show("Please type discussion", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDraftResolution.Text))
            {
                MessageBox.Show("Please type draft resolution", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {               
                if (listView1.Items.Count == 0)
                {
                    GetSerialNumber();
                    SaveMeetingMinutes();
                    UpdateMeetingStarted();
                    ListViewItem lst = new ListViewItem();
                    lst.SubItems.Add(agendaSerialForMeeting.ToString());
                    lst.SubItems.Add(txtAgendaTitle.Text);                   
                    lst.SubItems.Add(txtDiscussion.Text);
                    lst.SubItems.Add(txtDraftResolution.Text); 
                                     
                    listView1.Items.Add(lst);                    
                    txtAgendaTitle.Clear();
                    txtDiscussion.Text=string.Empty;
                    txtDraftResolution.Text=String.Empty;
                    dataGridView1.Rows.Remove(dr);
                    return;
                }

                ListViewItem lst1 = new ListViewItem();
                GetSerialNumber();
                SaveMeetingMinutes();
                lst1.SubItems.Add(agendaSerialForMeeting.ToString());
                lst1.SubItems.Add(txtAgendaTitle.Text);
                lst1.SubItems.Add(txtDiscussion.Text);
                lst1.SubItems.Add(txtDraftResolution.Text);

                listView1.Items.Add(lst1);                
                txtAgendaTitle.Clear();
                txtDiscussion.Text=String.Empty;
                txtDraftResolution.Text=String.Empty;
                dataGridView1.Rows.Remove(dr);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
               
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
               dr = dataGridView1.CurrentRow;
                 agendaSl = dr.Cells[0].Value.ToString();             
                 txtAgendaTitle.Text = dr.Cells[1].Value.ToString();
                 meetingAgendaId = dr.Cells[2].Value.ToString();
                 memo = dr.Cells[3].Value.ToString();
                 labelg = labelk;
                 //ClearDiscussedAgenda();
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
                string query2 = "Update  Meeting Set AllDiscussionCompleted=@d1 where  Meeting.MeetingId='"+meetingId+"' ";
                cmd = new SqlCommand(query2, con);
                cmd.Parameters.AddWithValue("@d1", 1);
                cmd.ExecuteReader();
                MessageBox.Show(@"Successfully Saved");
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

        private void txtMeetingNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAgendaTitle.Focus();
                e.Handled = true;
            }
        }

        private void txtAgendaTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addToListButton.Focus();
                e.Handled = true;
            }
        }

        private void addToListButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                saveAllButton.Focus();
                e.Handled = true;
            }
        }
    }
}
