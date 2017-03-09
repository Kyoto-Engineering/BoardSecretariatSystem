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

        public string user_id,boardId;

        public int company_id, board_id, agenda_id,meetingId;
        public AgendaEntryUI()
        {
            user_id = frmLogin.uId.ToString();
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
        public void BoardNameLoad()
        {

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "SELECT RTRIM(t_board.BoardName) FROM  t_board  order by t_board.BoardId desc";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    boardNameComboBox.Items.Add(rdr[0]);
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
            BoardNameLoad();
            
        }

       
        private void companyNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        public void GetAllMeetingByMeetingId()
        {
            
        }
        private void agendaSaveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(meetingNameComboBox.Text))
            {
                MessageBox.Show("Please Select company name", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(boardNameComboBox.Text))
            {
                MessageBox.Show("Please enter board name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                if (!string.IsNullOrEmpty(boardNameComboBox.Text))
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 = "select BoardId from t_board where CompanyId ='" + company_id + "' AND BoardName='"+boardNameComboBox.Text+"'";
                    cmd = new SqlCommand(ct2, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() && !rdr.IsDBNull(0))
                    {
                        board_id = rdr.GetInt32(0);

                    }
                    rdr.Close();
                    con.Close();
                }
                //if (!string.IsNullOrEmpty(topicsTextBox.Text))
                //{
                //    con = new SqlConnection(cs.DBConn);
                //    con.Open();
                //    string ct2 = "select AgendaId from t_agenda where AgendaTopics ='" + topicsTextBox.Text + "'";
                //    cmd = new SqlCommand(ct2, con);
                //    rdr = cmd.ExecuteReader();
                //    if (rdr.Read() && !rdr.IsDBNull(0))
                //    {
                //        agenda_id = rdr.GetInt32(0);

                //    }
                //    rdr.Close();
                //    con.Close();
                //}


                //if (!string.IsNullOrEmpty(boardNameComboBox.Text))
                //{
                //    con = new SqlConnection(cs.DBConn);
                //    con.Open();
                //    string ct1 = "select AgendaId from t_agenda where AgendaId='" + board_id + "'";
                //    cmd = new SqlCommand(ct1, con);
                //    rdr = cmd.ExecuteReader();
                //    if (rdr.Read() && !rdr.IsDBNull(0))
                //    {
                //        MessageBox.Show("This Topics Already Exists,Please Input another one", "Error",
                //            MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        boardNameComboBox.ResetText();
                //        boardNameComboBox.Focus();
                //        con.Close();

                //   }


                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string query1 ="insert into t_agenda (AgendaTopics,BoardId,UserId,DateTime) values (@d1,@d2,@d3,@d4)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                    cmd = new SqlCommand(query1, con);
                    cmd.Parameters.AddWithValue("@d1", topicsRichTextBox.Text);
                    cmd.Parameters.AddWithValue("@d2", board_id);
                    cmd.Parameters.AddWithValue("@d3", user_id);
                    cmd.Parameters.AddWithValue("@d4", DateTime.UtcNow.ToLocalTime());
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Saved Sucessfully", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    meetingNameComboBox.ResetText();
                    meetingNameComboBox.SelectedIndex = -1;
                    boardNameComboBox.ResetText();
                    boardNameComboBox.SelectedIndex = -1;
                    topicsRichTextBox.ResetText();
                    //CompanyNameLoad();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                string ctk = "SELECT  RTRIM(t_board.BoardId)  from  t_board  WHERE t_board.BoardName=@find";
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
                meetingNameComboBox.Items.Clear();
                meetingNameComboBox.SelectedIndex = -1;                              
                meetingNameComboBox.Enabled = true;
                meetingNameComboBox.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(t_meeting.MeetingName) from t_meeting  Where t_meeting.BoardId = '" +boardId + "' order by t_meeting.MeetingId desc";
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
    }
}




