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

        public int company_id, meeting_id, board_id, agenda_id;
        public string user_id, boardId,companyId,meetingId;
        public MeetingExecutionUI()
        {
            InitializeComponent();
            user_id = frmLogin.uId.ToString();
        }

        private void MeetingExecutionUI_Load(object sender, EventArgs e)
        {
            CompanyNameLoad();
        }
        public void CompanyNameLoad()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "SELECT CompanyName FROM t_company order by  t_company.CompanyId  desc";
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
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(t_company.CompanyId)  from  t_company  WHERE t_company.CompanyName=@find";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "t_company"));
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
                string ct = "select RTRIM(t_board.BoardName) from t_board  Where t_board.CompanyId = '" + companyId + "' order by t_board.BoardId desc";
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


        private void saveButton_Click(object sender, EventArgs e)
        {
            SelectBoardId();

            //select Meeting ID
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

            //select Agenda ID
            con = new SqlConnection(cs.DBConn);
            con.Open();
            cmd = con.CreateCommand();

            cmd.CommandText = "select AgendaId from t_agenda WHERE BoardId= '" + board_id + "'";

            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                agenda_id = rdr.GetInt32(0);
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query1 =
                    "insert into t_meetingExecution (AgendaId,Discussion,Resulation,Decision,MeetingId,UserId,DateTime) values (@d1,@d2,@d3,@d4,@d5,@d6,@d7)" +
                    "SELECT CONVERT(int, SCOPE_IDENTITY())";
                cmd = new SqlCommand(query1, con);
                cmd.Parameters.AddWithValue("@d1", agenda_id);
                cmd.Parameters.AddWithValue("@d2", discussionRichTextBox.Text);
                cmd.Parameters.AddWithValue("@d3", resulationRichTextBox.Text);
                cmd.Parameters.AddWithValue("@d4", decisionRichTextBox.Text);
                cmd.Parameters.AddWithValue("@d5", meeting_id); 
                cmd.Parameters.AddWithValue("@d6", user_id);
                cmd.Parameters.AddWithValue("@d7", DateTime.UtcNow.ToLocalTime());
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Saved Sucessfully", "", MessageBoxButtons.OK, MessageBoxIcon.None);
                companyNameComboBox.ResetText();
                companyNameComboBox.SelectedIndex = -1;
                boardNameComboBox.ResetText();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MeetingExecutionUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            MainUI mainUi=new MainUI();
            mainUi.Show();
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
                meetingComboBox.Items.Clear();
                meetingComboBox.SelectedIndex = -1;
                meetingComboBox.Enabled = true;
                meetingComboBox.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(t_meeting.MeetingName) from t_meeting  Where t_meeting.BoardId = '" + boardId + "' order by t_meeting.MeetingId desc";
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
                string ctk = "SELECT  RTRIM(t_meeting.MeetingId)  from  t_meeting  WHERE t_meeting.MeetingName=@find";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "Division"));
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
                string ct = "select RTRIM(t_agenda.AgendaTopics) from t_agenda  Where t_agenda.MeetingId = '" + meetingId + "' order by t_agenda.MeetingId desc";
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
        
    }
}
