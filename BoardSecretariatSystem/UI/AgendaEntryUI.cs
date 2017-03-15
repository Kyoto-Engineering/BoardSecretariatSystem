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

namespace BoardSecretariatSystem
{

    public partial class AgendaEntryUI : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        private ConnectionString cs = new ConnectionString();
        private delegate void ChangeFocusDelegate(Control ctl);

        public string userId, boardId, companyId;

        public int agendaId, meetingId, participantId;
        public AgendaEntryUI()
        {
            
            InitializeComponent();
        }
        private void changeFocus(Control ctl)
        {
            ctl.Focus();
        }
        private void AgendaEntryUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            MainUI mainUI = new MainUI();
            mainUI.Show();
        }
        public void CompanyNameLoad()
        {

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "SELECT RTRIM(Company.CompanyName) FROM  Company  order by Company.CompanyId desc";
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
        private void SaveMeetingParticipant()
        {
            try
            {
                for (int i = 0; i <= listView2.Items.Count - 1; i++)
                {


                    con = new SqlConnection(cs.DBConn);
                    string cb = "insert into MeetingParticipant(MeetingId,ParticipantId) VALUES(@d1,@d2)";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("d1", meetingId);
                    cmd.Parameters.AddWithValue("d2", listView2.Items[i].SubItems[2].Text);
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
        public void ParticipantNameLoad()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "SELECT Participant.ParticipantName FROM Participant order by  Participant.ParticipantId  desc";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbParticipantName.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void AgendaEntryUI_Load(object sender, EventArgs e)
        {
            userId = frmLogin.uId.ToString();
            CompanyNameLoad();
            ParticipantNameLoad();


        }      
        private void companyNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = "select MeetingId from Meeting where  Meeting.MeetingName='" + meetingNameComboBox.Text + "'";
                cmd = new SqlCommand(ct2, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read() && !rdr.IsDBNull(0))
                {
                    meetingId = rdr.GetInt32(0);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Reset()
        {
            companyNameComboBox.SelectedIndex = -1;
            boardNameComboBox.SelectedIndex = -1;
            meetingNameComboBox.SelectedIndex = -1;
            listView1.Items.Clear();
        }
        private void agendaSaveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(companyNameComboBox.Text))
            {
                MessageBox.Show("Please Select company name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(meetingNameComboBox.Text))
            {
                MessageBox.Show("Please Select company name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(boardNameComboBox.Text))
            {
                MessageBox.Show("Please enter board name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
                      
               try
                {
                    for (int i = 0; i < listView1.Items.Count - 1; i++)
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string query1 = "insert into Agenda (AgendaTopics,MeetingId,UserId,DateTime) values (@d1,@d2,@d3,@d4)";
                        cmd = new SqlCommand(query1, con);
                        cmd.Parameters.AddWithValue("@d1", listView1.Items[i].SubItems[1].Text);                       
                        cmd.Parameters.AddWithValue("@d2", meetingId);
                        cmd.Parameters.AddWithValue("@d3", userId);
                        cmd.Parameters.AddWithValue("@d4", DateTime.UtcNow.ToLocalTime());
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    SaveMeetingParticipant();
                    MessageBox.Show("Saved Sucessfully", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
           
        }

        private void companyNameComboBox_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(meetingNameComboBox.Text) && !meetingNameComboBox.Items.Contains(meetingNameComboBox.Text))
            {
                MessageBox.Show("Please Select A Valid Company Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                meetingNameComboBox.ResetText();
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus), meetingNameComboBox);
            }
        }

        private void boardNameComboBox_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(boardNameComboBox.Text) && !boardNameComboBox.Items.Contains(boardNameComboBox.Text))
            {
                MessageBox.Show("Please Select A Valid Board Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                boardNameComboBox.ResetText();
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus), boardNameComboBox);
            }
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
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "Board"));
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
                meetingNameComboBox.Items.Clear();
                meetingNameComboBox.SelectedIndex = -1;                              
                meetingNameComboBox.Enabled = true;
                meetingNameComboBox.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Meeting.MeetingName) from Meeting  Where Meeting.BoardId = '" + boardId + "' order by Meeting.MeetingId desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    meetingNameComboBox.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)
            {
                ListViewItem list =new ListViewItem();
                list.SubItems.Add(txtTopics.Text);
                listView1.Items.Add(list);
                txtTopics.Clear();
                return;
            }
            ListViewItem list1 = new ListViewItem();
            list1.SubItems.Add(txtTopics.Text);
            listView1.Items.Add(list1);
            txtTopics.Clear();
            return;
        }

        private void companyNameComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView2.Items.Count == 0)
            {
                ListViewItem lst = new ListViewItem();
                lst.SubItems.Add(cmbParticipantName.Text);
                lst.SubItems.Add(participantId.ToString());
                listView2.Items.Add(lst);
                cmbParticipantName.SelectedIndex = -1;
                return;
            }

            ListViewItem lst1 = new ListViewItem();
            lst1.SubItems.Add(cmbParticipantName.Text);
            lst1.SubItems.Add(participantId.ToString());
            listView2.Items.Add(lst1);
            cmbParticipantName.SelectedIndex = -1;
            return;
        }

        private void cmbParticipantName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT Participant.ParticipantId FROM Participant where Participant.ParticipantName='" + cmbParticipantName.Text + "'";
                cmd = new SqlCommand(ctk, con);
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




