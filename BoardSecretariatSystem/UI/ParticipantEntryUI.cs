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
    public partial class ParticipantEntryUI : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        private ConnectionString cs = new ConnectionString();
        private delegate void ChangeFocusDelegate(Control ctl);

        public int company_id, board_id, meeting_id;
        public string user_id;
        public ParticipantEntryUI()
        {
            user_id = frmLogin.uId.ToString();
            InitializeComponent();
        }
        private void changeFocus(Control ctl)
        {
            ctl.Focus();
        }
        private void ParticipantEntryUI_Load(object sender, EventArgs e)
        {
            CompanyNameLoad();
            GetAllMeetingList();
            GetAllParticipantAndMeetingName();
        }
        private void ParticipantEntryUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            MainUI mainUI = new MainUI();
            mainUI.Show();
        }

        public void GetAllMeetingList()
        {

            try
            {
                con = new SqlConnection(cs.DBConn);
                SqlDataAdapter sda = new SqlDataAdapter("SELECT t_company.CompanyName, t_board.BoardName, t_meeting.MeetingName, t_meeting.MeetingLocation, t_meeting.MeetingDate FROM t_company INNER JOIN t_board ON t_company.CompanyId = t_board.CompanyId INNER JOIN t_meeting ON t_board.BoardId = t_meeting.BoardId", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                meetingListdataGridView.Rows.Clear();
                foreach (DataRow item in dt.Rows)
                {
                    int n = meetingListdataGridView.Rows.Add();
                    meetingListdataGridView.Rows[n].Cells[0].Value = item[0].ToString();
                    meetingListdataGridView.Rows[n].Cells[1].Value = item[1].ToString();
                    meetingListdataGridView.Rows[n].Cells[2].Value = item[2].ToString();
                    meetingListdataGridView.Rows[n].Cells[3].Value = item[3].ToString();
                    meetingListdataGridView.Rows[n].Cells[4].Value = item[4].ToString();


                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void GetAllParticipantAndMeetingName()
        {
            meetingAndParticipantDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;
            meetingAndParticipantDataGridView.EnableHeadersVisualStyles = false;

            try
            {
                con = new SqlConnection(cs.DBConn);
                SqlDataAdapter sda = new SqlDataAdapter("SELECT t_participant.ParticipantName, t_meeting.MeetingName FROM t_participant INNER JOIN t_meeting ON t_participant.MeetingId = t_meeting.MeetingId", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                meetingAndParticipantDataGridView.Rows.Clear();
                foreach (DataRow item in dt.Rows)
                {
                    int n = meetingAndParticipantDataGridView.Rows.Add();
                    meetingAndParticipantDataGridView.Rows[n].Cells[0].Value = item[0].ToString();
                    meetingAndParticipantDataGridView.Rows[n].Cells[1].Value = item[1].ToString();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void CompanyNameLoad()
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();


            string query = "SELECT CompanyName FROM t_company ";

            cmd = new SqlCommand(query, con);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                companyNameComboBox.Items.Add(rdr[0]);
            }
            con.Close();

        }
        public void GetAllBoardByCompanyId()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();

                cmd.CommandText = "select CompanyId from t_company WHERE CompanyName= '" + companyNameComboBox.Text + "'";

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
                    string query = "SELECT BoardName from t_board where CompanyId= '" + company_id + "'";

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
            GetAllBoardByCompanyId();
        }
        public void SelectBoardId()
        {

            con = new SqlConnection(cs.DBConn);
            con.Open();
            cmd = con.CreateCommand();

            cmd.CommandText = "select BoardId from t_board WHERE CompanyId= '" + company_id + "'";

            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                board_id = rdr.GetInt32(0);

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
        public void SelectMeetingId()
        {

            con = new SqlConnection(cs.DBConn);
            con.Open();
            cmd = con.CreateCommand();

            cmd.CommandText = "select MeetingId from t_meeting WHERE BoardId= '" + board_id + "'";

            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                meeting_id = rdr.GetInt32(0);

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
        private void SaveButton_Click(object sender, EventArgs e)
        {
            SelectBoardId();
            SelectMeetingId();

            if (string.IsNullOrEmpty(companyNameComboBox.Text))
            {
                MessageBox.Show("Please select company name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(boardNameComboBox.Text))
            {
                MessageBox.Show("Please select board name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(participantNameTextBox.Text))
            {
                MessageBox.Show("Please input participant name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                if (!string.IsNullOrEmpty(companyNameComboBox.Text))
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct3 = "select Email,BoardId from t_participant where Email='" + participantEmailTextBox.Text + "' AND BoardId='"+board_id+"'";
                    cmd = new SqlCommand(ct3, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() && !rdr.IsDBNull(0))
                    {
                        MessageBox.Show("This Person Already Exists,Please Input another one", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        companyNameComboBox.ResetText();
                        companyNameComboBox.Focus();
                        con.Close();

                    }


                    else
                    {
                        try
                        {
                            
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string query1 =
                                "insert into t_participant (ParticipantName,ContactNumber,Designation,Email,BoardId,MeetingId,UserId,DateTime) values (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)" +
                                "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            cmd = new SqlCommand(query1, con);
                            cmd.Parameters.AddWithValue("@d1",participantNameTextBox.Text);
                            cmd.Parameters.AddWithValue("@d2", participantContactNoTextBox.Text);
                            cmd.Parameters.AddWithValue("@d3", participantDesignationTextBox.Text);
                            cmd.Parameters.AddWithValue("@d4", participantEmailTextBox.Text);
                            cmd.Parameters.AddWithValue("@d5", board_id);
                            cmd.Parameters.AddWithValue("@d6", meeting_id);
                            cmd.Parameters.AddWithValue("@d7", user_id);
                            cmd.Parameters.AddWithValue("@d8", DateTime.UtcNow.ToLocalTime());
                            cmd.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Saved Sucessfully", "", MessageBoxButtons.OK, MessageBoxIcon.None);
                           
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        GetAllParticipantAndMeetingName();
                    }

                }
            }
        }

        private void companyNameComboBox_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(companyNameComboBox.Text) && !companyNameComboBox.Items.Contains(companyNameComboBox.Text))
            {
                MessageBox.Show("Please Select A Valid Company Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                companyNameComboBox.ResetText();
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus), companyNameComboBox);
            }
        }

        private void boardNameComboBox_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(boardNameComboBox.Text) && !boardNameComboBox.Items.Contains(boardNameComboBox.Text))
            {
                MessageBox.Show("Please Select A Valid borad Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                boardNameComboBox.ResetText();
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus), boardNameComboBox);
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT t_company.CompanyName, t_board.BoardName, t_meeting.MeetingName, t_meeting.MeetingLocation, t_meeting.MeetingDate FROM t_company INNER JOIN t_board ON t_company.CompanyId = t_board.CompanyId INNER JOIN t_meeting ON t_board.BoardId = t_meeting.BoardId WHERE (t_company.CompanyName LIKE '" + searchTextBox.Text + "%') or(t_board.BoardName LIKE '" + searchTextBox.Text + "%') or (t_meeting.MeetingName LIKE '" + searchTextBox.Text + "%')", con);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            meetingListdataGridView.Rows.Clear();
            foreach (DataRow item in dataTable.Rows)
            {
                int n = meetingListdataGridView.Rows.Add();
                meetingListdataGridView.Rows[n].Cells[0].Value = item[0].ToString();
                meetingListdataGridView.Rows[n].Cells[1].Value = item[1].ToString();
                meetingListdataGridView.Rows[n].Cells[2].Value = item[2].ToString();
                meetingListdataGridView.Rows[n].Cells[3].Value = item[3].ToString();
                meetingListdataGridView.Rows[n].Cells[4].Value = item[4].ToString();
            }
        }

       
        
    }
}
