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
        public string user_id;
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
                cmd.Parameters.AddWithValue("@d2", discussionSmryTextBox.Text);
                cmd.Parameters.AddWithValue("@d3", resolutionTextBox.Text);
                cmd.Parameters.AddWithValue("@d4", decisionTextBox.Text);
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

        
    }
}
