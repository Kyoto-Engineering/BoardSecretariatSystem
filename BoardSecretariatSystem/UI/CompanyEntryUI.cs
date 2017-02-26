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
    public partial class CompanyEntryUI : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        private ConnectionString cs = new ConnectionString();
        public string user_id;

        public CompanyEntryUI()
        {
            InitializeComponent();
            user_id = frmLogin.uId.ToString();
        }
        private void CompanyEntryUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            MainUI mainUI = new MainUI();
            mainUI.Show();
        }
        private void CompanyEntryUI_Load(object sender, EventArgs e)
        {
            GetAllCompany();
        }

        public void GetAllCompany()
        {
         
            try
            {
                con = new SqlConnection(cs.DBConn);
                SqlDataAdapter sda = new SqlDataAdapter("SELECT CompanyId,CompanyName,CompanyAddress,RegiNumber,DateTime FROM t_company", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                allCompanyListDataGridView.Rows.Clear();
                foreach (DataRow item in dt.Rows)
                {
                    int n = allCompanyListDataGridView.Rows.Add();
                    allCompanyListDataGridView.Rows[n].Cells[0].Value = item[0].ToString();
                    allCompanyListDataGridView.Rows[n].Cells[1].Value = item[1].ToString();
                    allCompanyListDataGridView.Rows[n].Cells[2].Value = item[2].ToString();
                    allCompanyListDataGridView.Rows[n].Cells[3].Value = item[3].ToString();
                    allCompanyListDataGridView.Rows[n].Cells[4].Value = item[4].ToString();
                    
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        
        public void CompanyEntryUIClear()
        {
            companyNameTextBox.Clear();
            companyAddTextBox.Clear();
            regNoTextBox.Clear();
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(companyNameTextBox.Text))
            {
                MessageBox.Show("Please enter company name", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
            else if (string.IsNullOrEmpty(companyAddTextBox.Text))
            {
                MessageBox.Show("Please enter company address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            else
            {
                if (!string.IsNullOrEmpty(companyNameTextBox.Text))
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct3 = "select CompanyName from t_company where CompanyName='" + companyNameTextBox.Text + "'";
                    cmd = new SqlCommand(ct3, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() && !rdr.IsDBNull(0))
                    {
                        MessageBox.Show("This Company Name Already Exists,Please Input another one", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        companyNameTextBox.ResetText();
                        companyNameTextBox.Focus();
                        con.Close();

                    }


                    else
                    {
                        try
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string query1 =
                                "insert into t_company (CompanyName,CompanyAddress,RegiNumber,UserId,DateTime) values (@d1,@d2,@d3,@d4,@d5)" +
                                "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            cmd = new SqlCommand(query1, con);
                            cmd.Parameters.AddWithValue("@d1", companyNameTextBox.Text);
                            cmd.Parameters.AddWithValue("@d2", companyAddTextBox.Text);
                            cmd.Parameters.AddWithValue("@d3", regNoTextBox.Text);
                            cmd.Parameters.AddWithValue("@d4", user_id);
                            cmd.Parameters.AddWithValue("@d5", creatinDateTimePicker.Value);
                            cmd.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Saved Sucessfully", "", MessageBoxButtons.OK, MessageBoxIcon.None);
                            CompanyEntryUIClear();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        GetAllCompany();
                    }

                } 
            }
            
        }

        private void contactNoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //char ch = e.KeyChar;
            //decimal x;
            //if (ch == (char)Keys.Back)
            //{
            //    e.Handled = false;
            //}
            //else if (!char.IsDigit(ch) && ch != '.' || !Decimal.TryParse(regNoTextBox.Text + ch, out x))
            //{
            //    e.Handled = true;
            //}
        }

        private void creatinDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (creatinDateTimePicker.Value>DateTime.UtcNow.ToLocalTime())
            {
                MessageBox.Show("Creation Date Time should not excced from current date time", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                creatinDateTimePicker.ResetText(); 
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT CompanyId,CompanyName,CompanyAddress,RegiNumber,DateTime FROM t_company WHERE (CompanyName LIKE '" + searchTextBox.Text + "%')", con);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            allCompanyListDataGridView.Rows.Clear();
            foreach (DataRow item in dataTable.Rows)
            {
                int n = allCompanyListDataGridView.Rows.Add();
                allCompanyListDataGridView.Rows[n].Cells[0].Value = item[0].ToString();
                allCompanyListDataGridView.Rows[n].Cells[1].Value = item[1].ToString();
                allCompanyListDataGridView.Rows[n].Cells[2].Value = item[2].ToString();
                allCompanyListDataGridView.Rows[n].Cells[3].Value = item[3].ToString();
                allCompanyListDataGridView.Rows[n].Cells[4].Value = item[4].ToString();
            }
        }

          
    }
}
