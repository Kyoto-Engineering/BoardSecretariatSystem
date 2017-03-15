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
        public string userId, boardId, companyId, meetingId;

        public MeetingExecutionUI()
        {
            InitializeComponent();

        }

        public void ParticipantNameLoad()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "SELECT  BoardMember.BMemberName  FROM  BoardMember  order by  BoardMember.ParticipantId  desc";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbBoardMemberName.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void MeetingExecutionUI_Load(object sender, EventArgs e)
        {
            CompanyNameLoad();
            ParticipantNameLoad();
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

        private void SaveMeetingParticipant()
        {
            try
            {
                for (int i = 0; i <= listView1.Items.Count - 1; i++)
                {
                   

                    con = new SqlConnection(cs.DBConn);
                    string cb = "insert into MeetingParticipant(MeetingId,ParticipantId) VALUES(@d1,@d2)";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("d1", meetingId);
                    cmd.Parameters.AddWithValue("d2", listView1.Items[i].SubItems[2].Text);                  
                    cmd.ExecuteNonQuery();
                    con.Open();
                   
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
                SaveMeetingParticipant();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)
            {
                ListViewItem lst = new ListViewItem();
                lst.SubItems.Add(cmbBoardMemberName.Text);
                lst.SubItems.Add(participantId.ToString());
                listView1.Items.Add(lst);
                cmbBoardMemberName.SelectedIndex = -1;
                return;
            }

            ListViewItem lst1 = new ListViewItem();
            lst1.SubItems.Add(cmbBoardMemberName.Text);
            lst1.SubItems.Add(participantId.ToString());
            listView1.Items.Add(lst1);
            cmbBoardMemberName.SelectedIndex = -1;
            return;

        }

        private void cmbParticipantName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT BoardMember.ParticipantId FROM BoardMember where BoardMember.BMemberName='" + cmbBoardMemberName.Text + "'";
                cmd = new SqlCommand(ctk,con);                             
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    participantId = (rdr.GetInt32(0));
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
}
