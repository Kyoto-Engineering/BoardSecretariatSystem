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
    public partial class MeetingExecutionUI : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        private ConnectionString cs = new ConnectionString();

        private delegate void ChangeFocusDelegate(Control ctl);

        public int company_id, meeting_id, board_id, agendaId,participantId;
        public string userId, boardId, companyId, meetingId,nParticipantId,participantId2,mPId;
        public string labelv, labelg;

        public MeetingExecutionUI()
        {
            InitializeComponent();

        }
        private void GetBoardMemberDetails()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT Participant.ParticipantName, EmailBank.Email, Participant.ContactNumber FROM  Participant INNER JOIN EmailBank ON Participant.EmailBankId = EmailBank.EmailBankId", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1],rdr[2]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void MeetingExecutionUI_Load(object sender, EventArgs e)
        {
            CompanyNameLoad();
            GetBoardMemberDetails();
            userId = frmLogin.uId.ToString();
        }

        public void CompanyNameLoad()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "SELECT CompanyName FROM Company order by  Company.CompanyId  desc";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    companyNameComboBox.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void GetAllBoardByCompanyId()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();

                cmd.CommandText = "select CompanyId from Company WHERE CompanyName= '" + companyNameComboBox.Text +"'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    company_id = rdr.GetInt32(0);
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            if (!string.IsNullOrWhiteSpace(companyNameComboBox.Text))
            {

                boardNameComboBox.Items.Clear();
                boardNameComboBox.ResetText();
                boardNameComboBox.SelectedIndex = -1;
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = con.CreateCommand();
                    string query = "SELECT BoardName from Board where CompanyId= '" + company_id + "'";

                    cmd = new SqlCommand(query, con);
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        boardNameComboBox.Items.Add(rdr.GetValue(0).ToString());
                    }

                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void companyNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Company.CompanyId)  from  Company  WHERE Company.CompanyName=@find";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "Company"));
                cmd.Parameters["@find"].Value = companyNameComboBox.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    companyId = (rdr.GetString(0));

                }

                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }


                companyNameComboBox.Text = companyNameComboBox.Text.Trim();
                boardNameComboBox.Items.Clear();
                boardNameComboBox.SelectedIndex = -1;
                boardNameComboBox.Enabled = true;
                boardNameComboBox.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Board.BoardName) from Board  Where Board.CompanyId = '" + companyId + "' order by Board.BoardId desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    boardNameComboBox.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Reset()
        {
            companyNameComboBox.SelectedIndex = -1;
            boardNameComboBox.SelectedIndex = -1;
            meetingComboBox.SelectedIndex = -1;
            cmbTopics.SelectedIndex = -1;
            txtDiscussion.Clear();
            txtResulation.Clear();
            txtDecision.Clear();

        }

        private void SaveMeetingAttendence()
        {
            try
            {
                for (int i = 0; i < listView1.Items.Count - 1; i++)
                {

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "insert into AttendenceMeeting(MeetingExecutionId,MPId) VALUES(@d1,@d2)";
                    cmd = new SqlCommand(cb, con);
                    cmd.Parameters.AddWithValue("d1", meetingId);
                    cmd.Parameters.AddWithValue("d2", mPId);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
          
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(companyNameComboBox.Text))
            {
                MessageBox.Show("Please select company name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
             if (string.IsNullOrEmpty(boardNameComboBox.Text))
            {
                MessageBox.Show("Please select board name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 return;
            }
             if (string.IsNullOrEmpty(meetingComboBox.Text))
            {
                MessageBox.Show("Please select Meeting name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 return;
            }
             if (string.IsNullOrEmpty(cmbTopics.Text))
            {
                MessageBox.Show("Please select Topics/Agenda", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
             if (string.IsNullOrEmpty(txtDiscussion.Text))
            {
                MessageBox.Show("Please type Discussion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 return;
            }
             if (string.IsNullOrEmpty(txtResulation.Text))
            {
                MessageBox.Show("Please type Resolution.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 return;
            }
             if (string.IsNullOrEmpty(txtDecision.Text))
            {
                MessageBox.Show("Please type decision", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 return;
            }

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query1 ="insert into MeetingExecution (AgendaId,Discussion,Resulation,Decision,UserId,DateTime) values (@d1,@d2,@d3,@d4,@d7,@d8)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                cmd = new SqlCommand(query1, con);
                cmd.Parameters.AddWithValue("@d1", agendaId);
                cmd.Parameters.AddWithValue("@d2", txtDiscussion.Text);
                cmd.Parameters.AddWithValue("@d3", txtResulation.Text);
                cmd.Parameters.AddWithValue("@d4", txtDecision.Text);
               // cmd.Parameters.AddWithValue("@d5", meetingId);
               // cmd.Parameters.AddWithValue("@d6", boardId);
                cmd.Parameters.AddWithValue("@d7", userId);
                cmd.Parameters.AddWithValue("@d8", DateTime.UtcNow.ToLocalTime());
                cmd.ExecuteNonQuery();
                con.Close();
                SaveMeetingAttendence();
                MessageBox.Show("Saved Sucessfully", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MeetingExecutionUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            MainUI mainUi = new MainUI();
            mainUi.Show();
        }

        private void boardNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Board.BoardId)  from  Board  WHERE Board.BoardName=@find";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "Division"));
                cmd.Parameters["@find"].Value = boardNameComboBox.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    boardId = (rdr.GetString(0));

                }

                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }


                boardNameComboBox.Text = boardNameComboBox.Text.Trim();
                meetingComboBox.Items.Clear();
                meetingComboBox.SelectedIndex = -1;
                meetingComboBox.Enabled = true;
                meetingComboBox.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Meeting.MeetingName) from Meeting  Where Meeting.BoardId = '" + boardId +"' order by Meeting.MeetingId desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    meetingComboBox.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetMPId()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = "select MeetingParticipant.MPId from MeetingParticipant where  MeetingParticipant.ParticipantId='" + nParticipantId + "'";
                cmd = new SqlCommand(ct2, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read() && !rdr.IsDBNull(0))
                {
                    mPId = (rdr.GetString(0));
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void meetingComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Meeting.MeetingId)  from  Meeting  WHERE Meeting.MeetingName=@find";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "Meeting"));
                cmd.Parameters["@find"].Value = meetingComboBox.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    meetingId = (rdr.GetString(0));

                }

                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                GetMPId();

                meetingComboBox.Text = meetingComboBox.Text.Trim();
                cmbTopics.Items.Clear();
                cmbTopics.SelectedIndex = -1;
                cmbTopics.Enabled = true;
                cmbTopics.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Agenda.AgendaTopics) from Agenda  Where Agenda.MeetingId = '" + meetingId + "' order by Agenda.MeetingId desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbTopics.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisableCBM()
        {
            companyNameComboBox.Enabled = false;
            boardNameComboBox.Enabled = false;
            meetingComboBox.Enabled = false;
        }
        private void cmbTopics_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Agenda.AgendaId)  from  Agenda  WHERE Agenda.AgendaTopics=@find";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "Agenda"));
                cmd.Parameters["@find"].Value = meetingComboBox.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    agendaId = (rdr.GetInt32(0));
                }

                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                DisableCBM();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {            
        }

        private void cmbParticipantName_SelectedIndexChanged(object sender, EventArgs e)
        {           
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.CurrentRow;
               txtBoardMemberName.Text = dr.Cells[0].Value.ToString();
                txtEmail.Text = dr.Cells[1].Value.ToString();
                txtCellNumber.Text = dr.Cells[2].Value.ToString();
                labelv = labelg;             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addButton_Click_1(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)
            {
                ListViewItem lst = new ListViewItem();
                lst.SubItems.Add(txtBoardMemberName.Text);
                lst.SubItems.Add(txtEmail.Text);
                lst.SubItems.Add(txtCellNumber.Text);
                lst.SubItems.Add(mPId);
                listView1.Items.Add(lst);
                txtBoardMemberName.Clear();
                txtEmail.Clear();
                txtCellNumber.Clear();
                return;
            }

            ListViewItem lst1 = new ListViewItem();
            lst1.SubItems.Add(txtBoardMemberName.Text);
            lst1.SubItems.Add(txtEmail.Text);
            lst1.SubItems.Add(txtCellNumber.Text);
            lst1.SubItems.Add(mPId);
            listView1.Items.Add(lst1);
            txtBoardMemberName.Clear();
            txtEmail.Clear();
            txtCellNumber.Clear();
            return;

        }

        private void txtCellNumber_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Participant.ParticipantId)  from  Participant  WHERE Participant.ContactNumber=@find";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "Participant"));
                cmd.Parameters["@find"].Value = txtCellNumber.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    nParticipantId = (rdr.GetString(0));
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                GetMPId();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView2.Items.Count == 0)
            {
                ListViewItem list = new ListViewItem();
                list.SubItems.Add(cmbTopics.Text);
                listView2.Items.Add(list);
                cmbTopics.SelectedIndex = -1;
                return;
            }
            ListViewItem list1 = new ListViewItem();
            list1.SubItems.Add(cmbTopics.Text);
            listView2.Items.Add(list1);
            cmbTopics.SelectedIndex = -1;
            return;
        }
    }
}
