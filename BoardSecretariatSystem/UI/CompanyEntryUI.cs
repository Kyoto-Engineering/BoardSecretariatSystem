using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public string userId, postofficeId,thanaId,districtId,divisionId;
        public int currentCompanyId, affectedRows1, addHeaderId;

        public CompanyEntryUI()
        {
            InitializeComponent();
           
        }
        private void CompanyEntryUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            MainUI mainUI = new MainUI();
            mainUI.Show();
        }
        public void FillDivisionCombo()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Divisions.Division) from Divisions  order by Divisions.Division_ID desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    divisionCombo.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CompanyEntryUI_Load(object sender, EventArgs e)
        {
            userId = frmLogin.uId.ToString();
            GetAllCompany();
            FillDivisionCombo();
        }

        public void GetAllCompany()
        {
         
            try
            {
                con = new SqlConnection(cs.DBConn);
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Company.CompanyName,CompanyAddresses.FlatNo,CompanyAddresses.HouseNo,CompanyAddresses.RoadNo,CompanyAddresses.Block,CompanyAddresses.Area,CompanyAddresses.ContactNo,PostOffice.PostOfficeName, PostOffice.PostCode FROM  Company INNER JOIN CompanyAddresses ON Company.CompanyId = CompanyAddresses.CompanyId  INNER JOIN PostOffice ON CompanyAddresses.PostOfficeId = PostOffice.PostOfficeId INNER JOIN Thanas ON PostOffice.T_ID = Thanas.T_ID  INNER JOIN Districts ON Thanas.D_ID = Districts.D_ID  INNER JOIN Divisions ON Districts.Division_ID = Divisions.Division_ID", con);
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
                    allCompanyListDataGridView.Rows[n].Cells[5].Value = item[5].ToString();
                    allCompanyListDataGridView.Rows[n].Cells[6].Value = item[6].ToString();
                    allCompanyListDataGridView.Rows[n].Cells[7].Value = item[7].ToString();
                    allCompanyListDataGridView.Rows[n].Cells[8].Value = item[8].ToString();
                    
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
            regNoTextBox.Clear();
        }

        private void SaveCompanyAddress(string tableName)
        {
            string tableName1 = tableName;
           
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string insertQ = "insert into " + tableName1 + "(PostOfficeId,FlatNo,HouseNo,RoadNo,Block,Area,ContactNo,CompanyId) Values(@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                cmd = new SqlCommand(insertQ);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d4", string.IsNullOrEmpty(postofficeId) ? (object)DBNull.Value : postofficeId));
                cmd.Parameters.Add(new SqlParameter("@d5", string.IsNullOrEmpty(flatNoTextBox.Text) ? (object)DBNull.Value : flatNoTextBox.Text));
                cmd.Parameters.Add(new SqlParameter("@d6", string.IsNullOrEmpty(houseNoTextBox.Text) ? (object)DBNull.Value : houseNoTextBox.Text));
                cmd.Parameters.Add(new SqlParameter("@d7", string.IsNullOrEmpty(roadNoTextBox.Text) ? (object)DBNull.Value : roadNoTextBox.Text));
                cmd.Parameters.Add(new SqlParameter("@d8", string.IsNullOrEmpty(blockTextBox.Text) ? (object)DBNull.Value : blockTextBox.Text));
                cmd.Parameters.Add(new SqlParameter("@d9", string.IsNullOrEmpty(areaTextBox.Text) ? (object)DBNull.Value : areaTextBox.Text));
                cmd.Parameters.Add(new SqlParameter("@d10", string.IsNullOrEmpty(contactNoTextBox.Text) ? (object)DBNull.Value : contactNoTextBox.Text));
                cmd.Parameters.AddWithValue("@d11", currentCompanyId);
                affectedRows1 = (int)cmd.ExecuteScalar();
                con.Close();
            
        }

        private void Reset()
        {  
            companyNameTextBox.Clear();
            flatNoTextBox.Clear();
            houseNoTextBox.Clear();
            roadNoTextBox.Clear();
            blockTextBox.Clear();
            areaTextBox.Clear();
            contactNoTextBox.Clear();
            postCodeTextBox.Clear();
            postOfficeCombo.SelectedIndex = -1;
            thanaCombo.SelectedIndex = -1;
            distCombo.SelectedIndex = -1;
            divisionCombo.SelectedIndex = -1;
            regNoTextBox.Clear();
            creatingDateTimePicker.Value=DateTime.Today.ToLocalTime();
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(companyNameTextBox.Text))
            {
                MessageBox.Show("Please enter company name", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }

            if (string.IsNullOrWhiteSpace(divisionCombo.Text))
            {
                MessageBox.Show("Please select company division", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(distCombo.Text))
            {
                MessageBox.Show("Please Select company district", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(thanaCombo.Text))
            {
                MessageBox.Show("Please select company Thana", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(postOfficeCombo.Text))
            {
                MessageBox.Show("Please Select company Post Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(postCodeTextBox.Text))
            {
                MessageBox.Show("Please select company Post Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(regNoTextBox.Text))
            {
                MessageBox.Show("Please type Registration No:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                if (!string.IsNullOrEmpty(companyNameTextBox.Text))
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct3 = "select CompanyName from Company where CompanyName='" + companyNameTextBox.Text + "'";
                    cmd = new SqlCommand(ct3, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() && !rdr.IsDBNull(0))
                    {
                        MessageBox.Show("This Company Name Already Exists,Please Input another one", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            string query1 = "insert into Company(CompanyName,RegiNumber,UserId,DateTime) values (@d1,@d2,@d3,@d4)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            cmd = new SqlCommand(query1, con);
                            cmd.Parameters.AddWithValue("@d1", companyNameTextBox.Text);                          
                            cmd.Parameters.AddWithValue("@d2", regNoTextBox.Text);
                            cmd.Parameters.AddWithValue("@d3", userId);
                            cmd.Parameters.AddWithValue("@d4", creatingDateTimePicker.Value);
                            currentCompanyId = (int) cmd.ExecuteScalar();
                            con.Close();
                            SaveCompanyAddress("CompanyAddresses");
                            MessageBox.Show("Saved Sucessfully", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);                            
                            Reset();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        GetAllCompany();
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
            if (creatingDateTimePicker.Value>DateTime.UtcNow.ToLocalTime())
            {
                MessageBox.Show("Creation Date Time should not excced from current date time", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                creatingDateTimePicker.ResetText(); 
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT CompanyId,CompanyName,CompanyAddress,RegiNumber,DateTime FROM Company WHERE (CompanyName LIKE '" + searchTextBox.Text + "%')", con);
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

        private void divisionCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Divisions.Division_ID)  from Divisions WHERE Divisions.Division=@find";

                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "Division"));
                cmd.Parameters["@find"].Value = divisionCombo.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    divisionId = (rdr.GetString(0));

                }

                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }


                divisionCombo.Text = divisionCombo.Text.Trim();             
                distCombo.SelectedIndex = -1;
                distCombo.Items.Clear();
                thanaCombo.SelectedIndex = -1;
                thanaCombo.Items.Clear();
                postOfficeCombo.SelectedIndex = -1;
                postOfficeCombo.Items.Clear();
                postCodeTextBox.Clear();
                distCombo.Enabled = true;
                distCombo.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Districts.District) from Districts  Where Districts.Division_ID = '" + divisionId + "' order by Districts.Division_ID desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    distCombo.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void distCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Districts.D_ID)  from Districts WHERE Districts.District=@find";

                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "District"));
                cmd.Parameters["@find"].Value = distCombo.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    districtId= (rdr.GetString(0));

                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                distCombo.Text = distCombo.Text.Trim();               
                thanaCombo.SelectedIndex = -1;
                thanaCombo.Items.Clear();
                postOfficeCombo.SelectedIndex = -1;
                postOfficeCombo.Items.Clear();
                postCodeTextBox.Clear();
                thanaCombo.Enabled = true;
                thanaCombo.Focus();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Thanas.Thana) from Thanas  Where Thanas.D_ID = '" + districtId + "' order by Thanas.D_ID desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    thanaCombo.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void thanaCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Thanas.T_ID)  from Thanas WHERE Thanas.Thana=@find";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "Thana"));
                cmd.Parameters["@find"].Value = thanaCombo.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    thanaId= (rdr.GetString(0));

                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                thanaCombo.Text = thanaCombo.Text.Trim();               
                postOfficeCombo.SelectedIndex = -1;
                postOfficeCombo.Items.Clear();
                postCodeTextBox.Clear();
                postOfficeCombo.Enabled = true;
                postOfficeCombo.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(PostOffice.PostOfficeName) from PostOffice  Where PostOffice.T_ID = '" + thanaId + "' order by PostOffice.T_ID desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    postOfficeCombo.Items.Add(rdr[0]);
                }
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void postOfficeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(PostOffice.PostOfficeId),RTRIM(PostOffice.PostCode) from PostOffice WHERE PostOffice.PostOfficeName=@find";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "PostOfficeName"));
                cmd.Parameters["@find"].Value = postOfficeCombo.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    postofficeId = (rdr.GetString(0));
                    postCodeTextBox.Text = (rdr.GetString(1));

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
        }

        private void contactNoTextBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }
        
        private void cmbAddressHeadline_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

          
    }
}
