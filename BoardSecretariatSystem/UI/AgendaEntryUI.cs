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

        public string user_id;

        public int company_id, board_id, agenda_id;
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
        private void AgendaEntryUI_Load(object sender, EventArgs e)
        {
            CompanyNameLoad();
        }

        private void companyNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetAllBoardByCompanyId();
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

        private void agendaSaveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(companyNameComboBox.Text))
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
                    string query1 =
                        "insert into t_agenda (AgendaTopics,BoardId,UserId,DateTime) values (@d1,@d2,@d3,@d4)" +
                        "SELECT CONVERT(int, SCOPE_IDENTITY())";
                    cmd = new SqlCommand(query1, con);
                    cmd.Parameters.AddWithValue("@d1", topicsTextBox.Text);
                    cmd.Parameters.AddWithValue("@d2", board_id);
                    cmd.Parameters.AddWithValue("@d3", user_id);
                    cmd.Parameters.AddWithValue("@d4", DateTime.UtcNow.ToLocalTime());
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Saved Sucessfully", "", MessageBoxButtons.OK, MessageBoxIcon.None);
                    companyNameComboBox.ResetText();
                    companyNameComboBox.SelectedIndex = -1;
                    boardNameComboBox.ResetText();
                    boardNameComboBox.SelectedIndex = -1;
                    topicsTextBox.Clear();
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
                MessageBox.Show("Please Select A Valid Board Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                boardNameComboBox.ResetText();
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus), boardNameComboBox);
            }
        }
    }
}




