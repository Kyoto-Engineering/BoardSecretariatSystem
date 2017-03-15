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
    public partial class BoardEntryUI : Form 
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        private ConnectionString cs = new ConnectionString();
        private delegate void ChangeFocusDelegate(Control ctl);
        public int company_id;
        public string user_id;

        public BoardEntryUI()
        {
            InitializeComponent();
            CompanyNameLoad();
            user_id = frmLogin.uId.ToString();
        }

        private void changeFocus(Control ctl)
        {
            ctl.Focus();
        }
        private void BoardEntryUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            MainUI mainUI = new MainUI();
            mainUI.Show();
        }

        public void CompanyNameLoad()
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();


            string query = "SELECT CompanyName FROM Company ";

            cmd = new SqlCommand(query, con);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                companyNameComboBox.Items.Add(rdr[0]);
            }
            con.Close();

        }

        private void saveButton_Click(object sender, EventArgs e)
        {           
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

        private void saveButton_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(companyNameComboBox.Text))
            {
                MessageBox.Show("Please Select company name", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(BoardNameTextBox.Text))
            {
                MessageBox.Show("Please enter board name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                if (!string.IsNullOrEmpty(companyNameComboBox.Text))
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 = "select CompanyId from Company where CompanyName='" + companyNameComboBox.Text + "'";
                    cmd = new SqlCommand(ct2, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() && !rdr.IsDBNull(0))
                    {
                        company_id = rdr.GetInt32(0);

                    }                   
                    con.Close();
                }
                if (!string.IsNullOrEmpty(BoardNameTextBox.Text))
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct1 = "select BoardName,CompanyId from Board where BoardName='" + BoardNameTextBox.Text + "' AND CompanyId='" + company_id + "'";
                    cmd = new SqlCommand(ct1, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() && !rdr.IsDBNull(0))
                    {
                        MessageBox.Show("This Board Name Already Exists,Please Input another one", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                        BoardNameTextBox.ResetText();
                        BoardNameTextBox.Focus();
                        con.Close();

                    }                
                        try
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string query1 ="insert into Board (BoardName,CompanyId,UserId,DateTime) values (@d1,@d2,@d3,@d4)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            cmd = new SqlCommand(query1, con);
                            cmd.Parameters.AddWithValue("@d1", BoardNameTextBox.Text);
                            cmd.Parameters.AddWithValue("@d2", company_id);
                            cmd.Parameters.AddWithValue("@d3", user_id);
                            cmd.Parameters.AddWithValue("@d4", DateTime.UtcNow.ToLocalTime());
                            cmd.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Saved Sucessfully", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            companyNameComboBox.ResetText();
                            companyNameComboBox.SelectedIndex = -1;
                            BoardNameTextBox.Clear();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                  

                }
            }
        }


    }
}










