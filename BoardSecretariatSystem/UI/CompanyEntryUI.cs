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
        public string userId, postofficeId, thanaId, districtId, divisionId, districtIdC, districtIdO,districtIdHQ, divisionIdC, divisionIdO,divisionIdHQ, thanaIdC, thanaIdC2, thanaIdO,thanaIdHQ, postofficeIdC, postofficeIdO, postofficeIdHQ;
        public int currentCompanyId, affectedRows1,affectedRows2, addHeaderId;

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
        public void FillODivisionCombo()
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
                    cmbODivision.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void FillHQDivisionCombo()
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
                    cmbHQDivision.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddressHeader()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctt = "select AHeaderName from AddressHeader";
                cmd = new SqlCommand(ctt);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbAddressHeader.Items.Add(rdr.GetValue(0).ToString());
                }
                cmbAddressHeader.Items.Add("Not In The List");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CompanyEntryUI_Load(object sender, EventArgs e)
        {
            userId = frmLogin.uId.ToString();
            FillHQDivisionCombo();
            FillODivisionCombo();
            groupBox5.Enabled = false;
           // GetAllCompany();
            FillDivisionCombo();
            AddressHeader();
        }


        
        public void CompanyEntryUIClear()
        {
            companyNameTextBox.Clear();         
            regNoTextBox.Clear();
        }

        private void SaveOtherAddress(string  tableName)
        {
            string tableName1 = tableName;

            if (tableName1 == "OtherAddresses")
            {
                for (int i = 0; i < listView1.Items.Count-1; i++)
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string insertQ = "insert into " + tableName1 + "(PostOfficeId,OFlatNo,OHouseNo,ORoadNo,OBlock,OArea,OContactNo,CompanyId) Values(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                    cmd = new SqlCommand(insertQ);
                    cmd.Connection = con;
                    cmd.Parameters.Add(new SqlParameter("@d1", string.IsNullOrEmpty(listView1.Items[i].SubItems[9].Text) ? (object)DBNull.Value : listView1.Items[i].SubItems[9].Text));
                    cmd.Parameters.Add(new SqlParameter("@d2", string.IsNullOrEmpty(listView1.Items[i].SubItems[3].Text) ? (object)DBNull.Value : listView1.Items[i].SubItems[3].Text));
                    cmd.Parameters.Add(new SqlParameter("@d3", string.IsNullOrEmpty(listView1.Items[i].SubItems[4].Text) ? (object)DBNull.Value : listView1.Items[i].SubItems[4].Text));
                    cmd.Parameters.Add(new SqlParameter("@d4", string.IsNullOrEmpty(listView1.Items[i].SubItems[5].Text) ? (object)DBNull.Value : listView1.Items[i].SubItems[5].Text));
                    cmd.Parameters.Add(new SqlParameter("@d5", string.IsNullOrEmpty(listView1.Items[i].SubItems[6].Text) ? (object)DBNull.Value : listView1.Items[i].SubItems[6].Text));
                    cmd.Parameters.Add(new SqlParameter("@d6", string.IsNullOrEmpty(listView1.Items[i].SubItems[7].Text) ? (object)DBNull.Value : listView1.Items[i].SubItems[7].Text));
                    cmd.Parameters.Add(new SqlParameter("@d7", string.IsNullOrEmpty(listView1.Items[i].SubItems[8].Text) ? (object)DBNull.Value : listView1.Items[i].SubItems[8].Text));
                    cmd.Parameters.AddWithValue("@d8", currentCompanyId);
                    affectedRows1 = (int)cmd.ExecuteScalar();
                    con.Close();
                }
            }
        }
        private void SaveCompanyAddress(string tableName)
        {
            string tableName1 = tableName;

            if (tableName1 == "RegisteredAddresses")
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string insertQ = "insert into " + tableName1 + "(PostOfficeId,RgFlatNo,RgHouseNo,RgRoadNo,RgBlock,RgArea,RgContactNo,CompanyId) Values(@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
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
            if (tableName1 == "CorporateHQAddresses")
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string insertQ = "insert into " + tableName1 + "(PostOfficeId,CHQFlatNo,CHQHouseNo,CHQRoadNo,CHQBlock,CHQArea,CHQContactNo,CompanyId) Values(@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                cmd = new SqlCommand(insertQ);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d4", string.IsNullOrEmpty(postofficeId) ? (object)DBNull.Value : postofficeId));
                cmd.Parameters.Add(new SqlParameter("@d5", string.IsNullOrEmpty(txtHQFlatNo.Text) ? (object)DBNull.Value : txtHQFlatNo.Text));
                cmd.Parameters.Add(new SqlParameter("@d6", string.IsNullOrEmpty(txtHQHouseNo.Text) ? (object)DBNull.Value : txtHQHouseNo.Text));
                cmd.Parameters.Add(new SqlParameter("@d7", string.IsNullOrEmpty(txtHQRoadNo.Text) ? (object)DBNull.Value : txtHQRoadNo.Text));
                cmd.Parameters.Add(new SqlParameter("@d8", string.IsNullOrEmpty(txtHQBlock.Text) ? (object)DBNull.Value : txtHQBlock.Text));
                cmd.Parameters.Add(new SqlParameter("@d9", string.IsNullOrEmpty(txtHQArea.Text) ? (object)DBNull.Value : txtHQArea.Text));
                cmd.Parameters.Add(new SqlParameter("@d10", string.IsNullOrEmpty(txtHQContactNo.Text) ? (object)DBNull.Value : txtHQContactNo.Text));
                cmd.Parameters.AddWithValue("@d11", currentCompanyId);
                affectedRows1 = (int)cmd.ExecuteScalar();
                con.Close();
            }
            
            
        }

        private void ResetHQAddress()
        {
            txtHQFlatNo.Clear();
            txtHQHouseNo.Clear();
            txtHQRoadNo.Clear();
            txtHQBlock.Clear();
            txtHQArea.Clear();
            txtHQContactNo.Clear();
            txtHQPostCode.Clear();
            cmbHQPost.SelectedIndex = -1;
            cmbHQThana.SelectedIndex = -1;
            cmbHQDistrict.SelectedIndex = -1;
            cmbHQDivision.SelectedIndex = -1;
        }
        private void ResetOtherAddress()
        {
            txtOFlat.Clear();
            txtOHouse.Clear();
            txtORoad.Clear();
            txtOBlock.Clear();
            txtOArea.Clear();
            txtOContactNo.Clear();
            txtOPostCode.Clear();
            cmbOPost.SelectedIndex = -1;
            cmbOThana.SelectedIndex = -1;
            cmbODistrict.SelectedIndex = -1;
            cmbODivision.SelectedIndex = -1;
        }

        private void ResetRegisteredAddress()
        {
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
        }
        private void FillStar()
        {
            label38.Visible = true;
            label46.Visible = true;
            label45.Visible = true;
            label6.Visible = true;
            label40.Visible = true;
        }
        private void ResetStar()
        {
            label38.Visible = false;
            label46.Visible = false;
            label45.Visible = false;
            label6.Visible = false;
            label40.Visible = false;
        }
        private void Reset()
        {  
            companyNameTextBox.Clear();
            txtValueOfEachShare.Clear();
            txtTotalIssuedShare.Clear();
            txtTotalAuthorizedShare.Clear();
            regNoTextBox.Clear();
            creatingDateTimePicker.Value=DateTime.Today.ToLocalTime();
            otherAddress.CheckedChanged -= checkBox1_CheckedChanged;
            otherAddress.Checked = false;
            otherAddress.CheckedChanged += checkBox1_CheckedChanged;
            ResetRegisteredAddress();
            ResetHQAddress();

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
                            string query1 = "insert into Company(CompanyName,TotalAuthorizedShare,ValueofEachShare,TotalIssuedShare,RegiNumber,UserId,DateTime) values (@d1,@d2,@d3,@d4,@d5,@d6,@d7)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            cmd = new SqlCommand(query1, con);
                            cmd.Parameters.AddWithValue("@d1", companyNameTextBox.Text);
                            cmd.Parameters.AddWithValue("@d2", txtValueOfEachShare.Text);
                            cmd.Parameters.AddWithValue("@d3", txtTotalIssuedShare.Text);
                            cmd.Parameters.AddWithValue("@d4", txtTotalAuthorizedShare.Text);    
                            cmd.Parameters.AddWithValue("@d5", regNoTextBox.Text);
                            cmd.Parameters.AddWithValue("@d6", userId);
                            cmd.Parameters.AddWithValue("@d7", creatingDateTimePicker.Value);
                            currentCompanyId = (int) cmd.ExecuteScalar();
                            con.Close();
                            SaveCompanyAddress("RegisteredAddresses");
                            SaveCompanyAddress("CorporateHQAddresses");
                            if (otherAddress.Checked)
                            {
                                SaveOtherAddress("OtherAddress");
                            }
                           
                            MessageBox.Show("Saved Sucessfully", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);                            
                            Reset();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                       // GetAllCompany();
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
            //SqlDataAdapter sda = new SqlDataAdapter("SELECT CompanyId,CompanyName,CompanyAddress,RegiNumber,DateTime FROM Company WHERE (CompanyName LIKE '" + searchTextBox.Text + "%')", con);
            //DataTable dataTable = new DataTable();
            //sda.Fill(dataTable);
            //allCompanyListDataGridView.Rows.Clear();
            //foreach (DataRow item in dataTable.Rows)
            //{
            //    int n = allCompanyListDataGridView.Rows.Add();
            //    allCompanyListDataGridView.Rows[n].Cells[0].Value = item[0].ToString();
            //    allCompanyListDataGridView.Rows[n].Cells[1].Value = item[1].ToString();
            //    allCompanyListDataGridView.Rows[n].Cells[2].Value = item[2].ToString();
            //    allCompanyListDataGridView.Rows[n].Cells[3].Value = item[3].ToString();
            //    allCompanyListDataGridView.Rows[n].Cells[4].Value = item[4].ToString();
            //}
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

        private void cmbHQDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Divisions.Division_ID)  from Divisions WHERE Divisions.Division=@find";

                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "Division"));
                cmd.Parameters["@find"].Value = cmbHQDivision.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    divisionIdHQ = (rdr.GetString(0));

                }

                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }


                cmbHQDivision.Text = cmbHQDivision.Text.Trim();                
                cmbHQDistrict.SelectedIndex = -1;
                cmbHQDistrict.Items.Clear();
                cmbHQThana.SelectedIndex = -1;
                cmbHQThana.Items.Clear();
                cmbHQPost.SelectedIndex = -1;
                cmbHQPost.Items.Clear();
                txtHQPostCode.Clear();
                cmbHQDistrict.Enabled = true;
                cmbHQDistrict.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Districts.District) from Districts  Where Districts.Division_ID = '" + divisionIdHQ + "' order by Districts.Division_ID desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbHQDistrict.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbHQDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Districts.D_ID)  from Districts WHERE Districts.District=@find";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "District"));
                cmd.Parameters["@find"].Value = cmbHQDistrict.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    districtIdHQ = (rdr.GetString(0));
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                cmbHQDistrict.Text = cmbHQDistrict.Text.Trim();                
                cmbHQThana.SelectedIndex = -1;
                cmbHQThana.Items.Clear();
                cmbHQPost.SelectedIndex = -1;
                cmbHQPost.Items.Clear();
                txtHQPostCode.Clear();
                cmbHQThana.Enabled = true;
                cmbHQThana.Focus();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Thanas.Thana) from Thanas  Where Thanas.D_ID = '" + districtIdHQ + "' order by Thanas.D_ID desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbHQThana.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbHQThana_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Thanas.T_ID)  from Thanas WHERE Thanas.Thana=@find";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "Thana"));
                cmd.Parameters["@find"].Value = cmbHQThana.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    thanaIdHQ = (rdr.GetString(0));
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                cmbHQThana.Text = cmbHQThana.Text.Trim();                
                cmbHQPost.SelectedIndex=-1;
                cmbHQPost.Items.Clear();
                txtHQPostCode.Clear();
                cmbHQPost.Enabled = true;
                cmbHQPost.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(PostOffice.PostOfficeName) from PostOffice  Where PostOffice.T_ID = '" + thanaIdHQ + "' order by PostOffice.T_ID desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbHQPost.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbHQPost_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(PostOffice.PostOfficeId),RTRIM(PostOffice.PostCode) from PostOffice WHERE PostOffice.PostOfficeName=@find";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "PostOfficeName"));
                cmd.Parameters["@find"].Value = cmbHQPost.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    postofficeIdHQ = (rdr.GetString(0));
                    txtHQPostCode.Text = (rdr.GetString(1));
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (otherAddress.Checked)
            {
                groupBox5.Enabled = true;
                FillStar();
            }
            else
            {
                groupBox5.Enabled = false;
                ResetStar();
                ResetOtherAddress();
            }
        }

        private void cmbODivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Divisions.Division_ID)  from Divisions WHERE Divisions.Division=@find";

                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "Division"));
                cmd.Parameters["@find"].Value = cmbODivision.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    divisionIdO= (rdr.GetString(0));

                }

                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }


                cmbODivision.Text = cmbODivision.Text.Trim();
                cmbODistrict.SelectedIndex = -1;
                cmbODistrict.Items.Clear();
                cmbOThana.SelectedIndex = -1;
                cmbOThana.Items.Clear();
                cmbOPost.SelectedIndex = -1;
                cmbOPost.Items.Clear();
                txtOPostCode.Clear();
                cmbODistrict.Enabled = true;
                cmbODistrict.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Districts.District) from Districts  Where Districts.Division_ID = '" + divisionIdO + "' order by Districts.Division_ID desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbODistrict.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbODistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Districts.D_ID)  from Districts WHERE Districts.District=@find";

                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "District"));
                cmd.Parameters["@find"].Value = cmbODistrict.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    districtIdO= (rdr.GetString(0));

                }

                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }


                cmbODistrict.Text = cmbODistrict.Text.Trim();
                cmbOThana.SelectedIndex = -1;
                cmbOThana.Items.Clear();
                cmbOPost.SelectedIndex = -1;
                cmbOPost.Items.Clear();
                txtOPostCode.Clear();
                cmbOThana.Enabled = true;
                cmbOThana.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Thanas.Thana) from Thanas  Where Thanas.D_ID = '" + districtIdO + "' order by Thanas.D_ID desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbOThana.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbOThana_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Thanas.T_ID)  from Thanas WHERE Thanas.Thana=@find";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "Thana"));
                cmd.Parameters["@find"].Value = cmbOThana.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    thanaIdO = (rdr.GetString(0));

                }

                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }


                cmbOThana.Text = cmbOThana.Text.Trim();               
                cmbOPost.SelectedIndex = -1;
                cmbOPost.Items.Clear();
                txtOPostCode.Clear();
                cmbOPost.Enabled = true;
                cmbOPost.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(PostOffice.PostOfficeName) from PostOffice  Where PostOffice.T_ID = '" + thanaIdO + "' order by PostOffice.T_ID desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbOPost.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbOPost_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(PostOffice.PostOfficeId),RTRIM(PostOffice.PostCode) from PostOffice WHERE PostOffice.PostOfficeName=@find";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "PostOfficeName"));
                cmd.Parameters["@find"].Value = cmbOPost.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    postofficeIdO = (rdr.GetString(0));
                    txtOPostCode.Text = (rdr.GetString(1));

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

        private void cmbEmailAddress_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbAddressHeader_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAddressHeader.Text == "Not In The List")
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Please Input Address Header  Here", "Input Here", "", -1, -1);
                if (string.IsNullOrWhiteSpace(input))
                {
                    cmbAddressHeader.SelectedIndex = -1;
                }

                else
                {                   
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 = "select AHeaderName from AddressHeader where AHeaderName='" + input + "'";
                    cmd = new SqlCommand(ct2, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() && !rdr.IsDBNull(0))
                    {
                        MessageBox.Show("This Address Header  Already Exists,Please Select From List", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                        cmbAddressHeader.SelectedIndex = -1;
                    }
                    else
                    {
                        try
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string query1 = "insert into AddressHeader(AHeaderName) values (@d1)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            cmd = new SqlCommand(query1, con);
                            cmd.Parameters.AddWithValue("@d1", input);                           
                            cmd.ExecuteNonQuery();
                            con.Close();
                            cmbAddressHeader.Items.Clear();
                            AddressHeader();
                            cmbAddressHeader.SelectedText = input;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT AHeaderId from AddressHeader WHERE AHeaderName= '" + cmbAddressHeader.Text + "'";

                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        addHeaderId = rdr.GetInt32(0);
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
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)
            {
                ListViewItem list=new ListViewItem();
                list.SubItems.Add(cmbAddressHeader.Text);
                list.SubItems.Add(addHeaderId.ToString());                
                list.SubItems.Add(txtOFlat.Text);
                list.SubItems.Add(txtOHouse.Text);
                list.SubItems.Add(txtORoad.Text);
                list.SubItems.Add(txtOBlock.Text);
                list.SubItems.Add(txtOArea.Text);
                list.SubItems.Add(txtOContactNo.Text);
                list.SubItems.Add(postofficeIdO);
                listView1.Items.Add(list);
                cmbAddressHeader.SelectedIndex = -1;
                txtOFlat.Clear();
                txtOHouse.Clear();
                txtORoad.Clear();
                txtOBlock.Clear();
                txtOArea.Clear();
                txtOContactNo.Clear();
                postofficeIdO="";               
                return;                           
            }
            ListViewItem list1 = new ListViewItem();
            list1.SubItems.Add(cmbAddressHeader.Text);
            list1.SubItems.Add(addHeaderId.ToString());
            list1.SubItems.Add(txtOFlat.Text);
            list1.SubItems.Add(txtOHouse.Text);
            list1.SubItems.Add(txtORoad.Text);
            list1.SubItems.Add(txtOBlock.Text);
            list1.SubItems.Add(txtOArea.Text);
            list1.SubItems.Add(txtOContactNo.Text);
            list1.SubItems.Add(postofficeIdO);
            listView1.Items.Add(list1);
            cmbAddressHeader.SelectedIndex = -1;
            txtOFlat.Clear();
            txtOHouse.Clear();
            txtORoad.Clear();
            txtOBlock.Clear();
            txtOArea.Clear();
            txtOContactNo.Clear();
            postofficeIdO = "";
            return;

        }

          
    }
}
