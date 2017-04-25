using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BoardSecretariatSystem.DBGateway;
using CrystalDecisions.Shared;

namespace BoardSecretariatSystem
{
    public partial class CompanyEntryUI : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        private ConnectionString cs = new ConnectionString();

        public string userId,
            postofficeId,
            thanaId,
            districtId,
            divisionId,
            districtIdC,
            districtIdO,
            districtIdHQ,
            divisionIdC,
            divisionIdO,
            divisionIdHQ,
            thanaIdC,
            thanaIdC2,
            thanaIdO,
            thanaIdHQ,
            postofficeIdC,
            postofficeIdO,
            postofficeIdHQ;

        public int currentCompanyId,
            affectedRows1,
            affectedRows2,
            addHeaderId,
            availableAuthorizedShare,
            companyId,
            totalCertificates;

        private bool companyCreated;
        string x = null;
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
            companyCreated = LoadCompany();
            FillHQDivisionCombo();
            FillODivisionCombo();
            groupBox5.Enabled = false;
            FillDivisionCombo();
            AddressHeader();
        }

        public void CompanyEntryUIClear()
        {
            companyNameTextBox.Clear();
            regNoTextBox.Clear();
        }

        private void SaveOtherAddress()
        {
            for (int i = 0; i < listView1.Items.Count - 1; i++)
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string insertQ =
                    "insert into CompanyAddresses(AHeaderId,PostOfficeId,FlatNo,HouseNo,RoadNo,Block,Area,ContactNo,CompanyId) Values(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9)" +
                    "SELECT CONVERT(int, SCOPE_IDENTITY())";
                cmd = new SqlCommand(insertQ);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1",
                    string.IsNullOrEmpty(listView1.Items[i].SubItems[2].Text)
                        ? (object) DBNull.Value
                        : listView1.Items[i].SubItems[2].Text));
                cmd.Parameters.Add(new SqlParameter("@d2",
                    string.IsNullOrEmpty(listView1.Items[i].SubItems[9].Text)
                        ? (object) DBNull.Value
                        : listView1.Items[i].SubItems[9].Text));
                cmd.Parameters.Add(new SqlParameter("@d3",
                    string.IsNullOrEmpty(listView1.Items[i].SubItems[3].Text)
                        ? (object) DBNull.Value
                        : listView1.Items[i].SubItems[3].Text));
                cmd.Parameters.Add(new SqlParameter("@d4",
                    string.IsNullOrEmpty(listView1.Items[i].SubItems[4].Text)
                        ? (object) DBNull.Value
                        : listView1.Items[i].SubItems[4].Text));
                cmd.Parameters.Add(new SqlParameter("@d5",
                    string.IsNullOrEmpty(listView1.Items[i].SubItems[5].Text)
                        ? (object) DBNull.Value
                        : listView1.Items[i].SubItems[5].Text));
                cmd.Parameters.Add(new SqlParameter("@d6",
                    string.IsNullOrEmpty(listView1.Items[i].SubItems[6].Text)
                        ? (object) DBNull.Value
                        : listView1.Items[i].SubItems[6].Text));
                cmd.Parameters.Add(new SqlParameter("@d7",
                    string.IsNullOrEmpty(listView1.Items[i].SubItems[7].Text)
                        ? (object) DBNull.Value
                        : listView1.Items[i].SubItems[7].Text));
                cmd.Parameters.Add(new SqlParameter("@d8",
                    string.IsNullOrEmpty(listView1.Items[i].SubItems[8].Text)
                        ? (object) DBNull.Value
                        : listView1.Items[i].SubItems[8].Text));
                cmd.Parameters.AddWithValue("@d9", currentCompanyId);
                affectedRows1 = (int) cmd.ExecuteScalar();
                con.Close();
            }
        }

        private void SaveCompanyAddress(int addHeaderId)
        {
            int aHeaderId = addHeaderId;

            if (aHeaderId == 1)
            {
                SaveRegAddressHeader();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string insertQ =
                    "insert into CompanyAddresses(AHeaderId,PostOfficeId,FlatNo,HouseNo,RoadNo,Block,Area,ContactNo,CompanyId) Values(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9)" +
                    "SELECT CONVERT(int, SCOPE_IDENTITY())";
                cmd = new SqlCommand(insertQ);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1",
                    string.IsNullOrEmpty(aHeaderId.ToString()) ? (object) DBNull.Value : aHeaderId));
                cmd.Parameters.Add(new SqlParameter("@d2",
                    string.IsNullOrEmpty(postofficeId) ? (object) DBNull.Value : postofficeId));
                cmd.Parameters.Add(new SqlParameter("@d3",
                    string.IsNullOrEmpty(flatNoTextBox.Text) ? (object) DBNull.Value : flatNoTextBox.Text));
                cmd.Parameters.Add(new SqlParameter("@d4",
                    string.IsNullOrEmpty(houseNoTextBox.Text) ? (object) DBNull.Value : houseNoTextBox.Text));
                cmd.Parameters.Add(new SqlParameter("@d5",
                    string.IsNullOrEmpty(roadNoTextBox.Text) ? (object) DBNull.Value : roadNoTextBox.Text));
                cmd.Parameters.Add(new SqlParameter("@d6",
                    string.IsNullOrEmpty(blockTextBox.Text) ? (object) DBNull.Value : blockTextBox.Text));
                cmd.Parameters.Add(new SqlParameter("@d7",
                    string.IsNullOrEmpty(areaTextBox.Text) ? (object) DBNull.Value : areaTextBox.Text));
                cmd.Parameters.Add(new SqlParameter("@d8",
                    string.IsNullOrEmpty(contactNoTextBox.Text) ? (object) DBNull.Value : contactNoTextBox.Text));
                cmd.Parameters.AddWithValue("@d9", currentCompanyId);
                affectedRows1 = (int) cmd.ExecuteScalar();
                con.Close();
            }
            if (aHeaderId == 2)
            {
                SaveCorporatHQAddHeader();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string insertQ =
                    "insert into CompanyAddresses(AHeaderId,PostOfficeId,FlatNo,HouseNo,RoadNo,Block,Area,ContactNo,CompanyId) Values(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9)" +
                    "SELECT CONVERT(int, SCOPE_IDENTITY())";
                cmd = new SqlCommand(insertQ);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1",
                    string.IsNullOrEmpty(aHeaderId.ToString()) ? (object) DBNull.Value : aHeaderId));
                cmd.Parameters.Add(new SqlParameter("@d2",
                    string.IsNullOrEmpty(postofficeIdHQ) ? (object) DBNull.Value : postofficeIdHQ));
                cmd.Parameters.Add(new SqlParameter("@d3",
                    string.IsNullOrEmpty(txtHQFlatNo.Text) ? (object) DBNull.Value : txtHQFlatNo.Text));
                cmd.Parameters.Add(new SqlParameter("@d4",
                    string.IsNullOrEmpty(txtHQHouseNo.Text) ? (object) DBNull.Value : txtHQHouseNo.Text));
                cmd.Parameters.Add(new SqlParameter("@d5",
                    string.IsNullOrEmpty(txtHQRoadNo.Text) ? (object) DBNull.Value : txtHQRoadNo.Text));
                cmd.Parameters.Add(new SqlParameter("@d6",
                    string.IsNullOrEmpty(txtHQBlock.Text) ? (object) DBNull.Value : txtHQBlock.Text));
                cmd.Parameters.Add(new SqlParameter("@d7",
                    string.IsNullOrEmpty(txtHQArea.Text) ? (object) DBNull.Value : txtHQArea.Text));
                cmd.Parameters.Add(new SqlParameter("@d8",
                    string.IsNullOrEmpty(txtHQContactNo.Text) ? (object) DBNull.Value : txtHQContactNo.Text));
                cmd.Parameters.AddWithValue("@d9", currentCompanyId);
                affectedRows1 = (int) cmd.ExecuteScalar();
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
            txtCorum.Clear();
            txtNumberOfDirector.Clear();
            creatingDateTimePicker.Value = DateTime.Today.ToLocalTime();
            otherAddress.CheckedChanged -= checkBox1_CheckedChanged;
            otherAddress.Checked = false;
            otherAddress.CheckedChanged += checkBox1_CheckedChanged;
            ResetRegisteredAddress();
            ResetHQAddress();
            listView1.Items.Clear();
        }

        private void SaveCorporatHQAddHeader()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query2 = "insert into AddressHeader(AHeaderName) values (@d1)";
                cmd = new SqlCommand(query2, con);
                cmd.Parameters.AddWithValue("@d1", "Corporate HQ Address");
                cmd.ExecuteReader();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveRegAddressHeader()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query2 = "insert into AddressHeader(AHeaderName) values (@d1)";
                cmd = new SqlCommand(query2, con);
                cmd.Parameters.AddWithValue("@d1", "Registered Address");
                cmd.ExecuteReader();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            ProgressbarStart(saveButton);
            if (companyCreated)
            {
                MessageBox.Show(@"Already a Company Created", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProgressbarOff(saveButton);
                return;
            }
            if (string.IsNullOrEmpty(companyNameTextBox.Text))
            {
                MessageBox.Show("Please enter company name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProgressbarOff(saveButton);
                return;
            }

            if (string.IsNullOrWhiteSpace(divisionCombo.Text))
            {
                MessageBox.Show("Please select company division", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProgressbarOff(saveButton);
                return;
            }
            if (string.IsNullOrWhiteSpace(distCombo.Text))
            {
                MessageBox.Show("Please Select company district", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProgressbarOff(saveButton);
                return;
            }
            if (string.IsNullOrWhiteSpace(thanaCombo.Text))
            {
                MessageBox.Show("Please select company Thana", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProgressbarOff(saveButton);
                return;
            }
            if (string.IsNullOrWhiteSpace(postOfficeCombo.Text))
            {
                MessageBox.Show("Please Select company Post Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProgressbarOff(saveButton);
                return;
            }
            if (string.IsNullOrWhiteSpace(postCodeTextBox.Text))
            {
                MessageBox.Show("Please select company Post Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProgressbarOff(saveButton);
                return;
            }
            if (string.IsNullOrWhiteSpace(regNoTextBox.Text))
            {
                MessageBox.Show("Please type Registration No:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProgressbarOff(saveButton);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtCorum.Text))
            {
                MessageBox.Show(@"Please type Corum Value:", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProgressbarOff(saveButton);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtMeetingAlowance.Text))
            {
                MessageBox.Show(@"Please type Meeting Allowance:", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProgressbarOff(saveButton);
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
                    MessageBox.Show(@"This Company Name Already Exists,Please Input another one", @"Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    companyNameTextBox.ResetText();
                    companyNameTextBox.Focus();
                    con.Close();

                }
                else
                {
                 
                    
                    try
                    {
                        RunTask();
                        //SaveTODataBase();
                        
                      
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }

        }

        private async void RunTask()
        {
           
            using (Task<string> task = new Task<string>(new Func<object, string>(SaveTODataBase), x))
            {
                //lblStatus.Text = "Started Calculation..."; //Set the status label to signal starting the operation
                //btnStart.Enabled = false; //Disable the Start button
               

                try
                {
                    task.Start(); //Start the execution of the task
                    await task; // wait for the task to finish, without blocking the main thread
                    if (task.IsCompleted)
                    {

                        //btnStart.Enabled = true; //Re-enable the Start button
                        Reset();
                        MessageBox.Show(@"Saved Successfully", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ProgressbarOff(saveButton);
                        //MessageBox.Show(task.Result, "error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                        //        //at this point, the task has finished its background work, and we can take the result
                        //lblStatus.Text = "Completed."; //Signal the completion of the task
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                  
                } 

           
                
            }
        }

        private string SaveTODataBase( object state)
        {
            int x = Convert.ToInt32(txtTotalAuthorizedShare.Text);
            int y = Convert.ToInt32(txtTotalIssuedShare.Text);
            availableAuthorizedShare = x - y;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string query1 =
                "insert into Company(CompanyName,TotalAuthorizedShare,AvailableAuthorizedShare,ValueofEachShare,TotalIssuedShare,AvailableIssuedShare,Corum,NumberOfDirector,VacantPostofDirector,VacantPostofMDirector,VacantPostofChairman,RegiNumber,MeetingAllowance,UserId,DateTime) values (@d1,@d2,@d3,@d4,@d5,@d5,@d6,@d7,@d7,@d8,@d9,@d10,@d11,@d12,@d13)" +
                "SELECT CONVERT(int, SCOPE_IDENTITY())";
            cmd = new SqlCommand(query1, con);
            cmd.Parameters.AddWithValue("@d1", companyNameTextBox.Text);
            cmd.Parameters.AddWithValue("@d2", txtTotalAuthorizedShare.Text);
            cmd.Parameters.AddWithValue("@d3", availableAuthorizedShare);
            cmd.Parameters.AddWithValue("@d4", txtValueOfEachShare.Text);
            cmd.Parameters.AddWithValue("@d5", txtTotalIssuedShare.Text);
            cmd.Parameters.AddWithValue("@d6", txtCorum.Text);
            cmd.Parameters.AddWithValue("@d7", txtNumberOfDirector.Text);
            cmd.Parameters.AddWithValue("@d8", "1");
            cmd.Parameters.AddWithValue("@d9", "1");
            cmd.Parameters.AddWithValue("@d10", regNoTextBox.Text);
            cmd.Parameters.AddWithValue("@d11", txtMeetingAlowance.Text);
            cmd.Parameters.AddWithValue("@d12", userId);
            cmd.Parameters.AddWithValue("@d13", creatingDateTimePicker.Value.ToUniversalTime().ToLocalTime());
            currentCompanyId = (int) cmd.ExecuteScalar();
            con.Close();
            SaveCompanyAddress(1);
            SaveCompanyAddress(2);
            if (otherAddress.Checked)
            {
                SaveOtherAddress();
            }
            SaveShare();
            return null;
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
            if (creatingDateTimePicker.Value > DateTime.UtcNow.ToLocalTime())
            {
                MessageBox.Show("Creation Date Time should not excced from current date time", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                creatingDateTimePicker.ResetText();
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
                string ct = "select RTRIM(Districts.District) from Districts  Where Districts.Division_ID = '" +
                            divisionId + "' order by Districts.Division_ID desc";
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
                    districtId = (rdr.GetString(0));

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
                string ct = "select RTRIM(Thanas.Thana) from Thanas  Where Thanas.D_ID = '" + districtId +
                            "' order by Thanas.D_ID desc";
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
                    thanaId = (rdr.GetString(0));

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
                string ct = "select RTRIM(PostOffice.PostOfficeName) from PostOffice  Where PostOffice.T_ID = '" +
                            thanaId + "' order by PostOffice.T_ID desc";
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
                string ctk =
                    "SELECT  RTRIM(PostOffice.PostOfficeId),RTRIM(PostOffice.PostCode) from PostOffice WHERE PostOffice.PostOfficeName=@find";
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
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char) Keys.Back)))
                e.Handled = true;
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
                string ct = "select RTRIM(Districts.District) from Districts  Where Districts.Division_ID = '" +
                            divisionIdHQ + "' order by Districts.Division_ID desc";
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
                string ct = "select RTRIM(Thanas.Thana) from Thanas  Where Thanas.D_ID = '" + districtIdHQ +
                            "' order by Thanas.D_ID desc";
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
                cmbHQPost.SelectedIndex = -1;
                cmbHQPost.Items.Clear();
                txtHQPostCode.Clear();
                cmbHQPost.Enabled = true;
                cmbHQPost.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(PostOffice.PostOfficeName) from PostOffice  Where PostOffice.T_ID = '" +
                            thanaIdHQ + "' order by PostOffice.T_ID desc";
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
                string ctk =
                    "SELECT  RTRIM(PostOffice.PostOfficeId),RTRIM(PostOffice.PostCode) from PostOffice WHERE PostOffice.PostOfficeName=@find";
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
                cmbAddressHeader.Focus();

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
                    divisionIdO = (rdr.GetString(0));

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
                string ct = "select RTRIM(Districts.District) from Districts  Where Districts.Division_ID = '" +
                            divisionIdO + "' order by Districts.Division_ID desc";
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
                    districtIdO = (rdr.GetString(0));

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
                string ct = "select RTRIM(Thanas.Thana) from Thanas  Where Thanas.D_ID = '" + districtIdO +
                            "' order by Thanas.D_ID desc";
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
                string ct = "select RTRIM(PostOffice.PostOfficeName) from PostOffice  Where PostOffice.T_ID = '" +
                            thanaIdO + "' order by PostOffice.T_ID desc";
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
                string ctk =
                    "SELECT  RTRIM(PostOffice.PostOfficeId),RTRIM(PostOffice.PostCode) from PostOffice WHERE PostOffice.PostOfficeName=@find";
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



        private void cmbAddressHeader_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAddressHeader.Text == "Not In The List")
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Please Input Address Header  Here",
                    "Input Here", "", -1, -1);
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
                        MessageBox.Show("This Address Header  Already Exists,Please Select From List", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                        cmbAddressHeader.SelectedIndex = -1;
                    }
                    else
                    {
                        try
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string query1 = "insert into AddressHeader(AHeaderName) values (@d1)" +
                                            "SELECT CONVERT(int, SCOPE_IDENTITY())";
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
                    cmd.CommandText = "SELECT AHeaderId from AddressHeader WHERE AHeaderName= '" + cmbAddressHeader.Text +
                                      "'";

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
            txtOFlat.Focus();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)
            {
                ListViewItem list = new ListViewItem();
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
                txtOPostCode.Clear();
                cmbOPost.SelectedIndex = -1;
                cmbOThana.SelectedIndex = -1;
                cmbODistrict.SelectedIndex = -1;
                cmbODivision.SelectedIndex = -1;
                postofficeIdO = "";
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
            txtOContactNo.Clear();
            txtOPostCode.Clear();
            cmbOPost.SelectedIndex = -1;
            cmbOThana.SelectedIndex = -1;
            cmbODistrict.SelectedIndex = -1;
            cmbODivision.SelectedIndex = -1;
            postofficeIdO = "";
            return;

        }

        private bool LoadCompany()
        {
            bool x = false;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string query = "SELECT CompanyId FROM Company";
            cmd = new SqlCommand(query, con);
            rdr = cmd.ExecuteReader();

            if (rdr.Read() && !rdr.IsDBNull(0))
            {
                companyId = Convert.ToInt32(rdr["CompanyId"]);
                x = true;
            }
            return x;


        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            for (int i = listView1.Items.Count - 1; i >= 0; i--)
            {
                if (listView1.Items[i].Selected)
                {
                    listView1.Items[i].Remove();
                }
            }
        }

        private void txtValueOfEachShare_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void companyNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtValueOfEachShare.Focus();
                e.Handled = true;
            }
        }

        private void txtValueOfEachShare_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMeetingAlowance.Focus();
                e.Handled = true;
            }
        }

        private void txtMeetingAlowance_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTotalIssuedShare.Focus();
                e.Handled = true;
            }
        }

        private void txtTotalIssuedShare_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCorum.Focus();
                e.Handled = true;
            }
        }

        private void txtCorum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTotalAuthorizedShare.Focus();
                e.Handled = true;
            }
        }

        private void txtTotalAuthorizedShare_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                regNoTextBox.Focus();
                e.Handled = true;
            }
        }

        private void regNoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                creatingDateTimePicker.Focus();
                e.Handled = true;
            }
        }

        private void creatingDateTimePicker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNumberOfDirector.Focus();
                e.Handled = true;
            }
        }

        private void txtNumberOfDirector_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                certificateNoTextBox.Focus();
                e.Handled = true;
            }
        }


        private void certificateNoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                flatNoTextBox.Focus();
                e.Handled = true;
            }
        }
        private void flatNoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                houseNoTextBox.Focus();
                e.Handled = true;
            }
        }

        private void houseNoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                roadNoTextBox.Focus();
                e.Handled = true;
            }
        }

        private void roadNoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                blockTextBox.Focus();
                e.Handled = true;
            }
        }

        private void blockTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                areaTextBox.Focus();
                e.Handled = true;
            }
        }

        private void areaTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                contactNoTextBox.Focus();
                e.Handled = true;
            }
        }

        private void contactNoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                divisionCombo.Focus();
                e.Handled = true;
            }
        }

        private void divisionCombo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                distCombo.Focus();
                e.Handled = true;
            }
        }

        private void distCombo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                thanaCombo.Focus();
                e.Handled = true;
            }
        }

        private void thanaCombo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                postOfficeCombo.Focus();
                e.Handled = true;
            }
        }

        private void postOfficeCombo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                postCodeTextBox.Focus();
                e.Handled = true;
            }
        }

        private void postCodeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtHQFlatNo.Focus();
                e.Handled = true;
            }
        }

        private void txtHQFlatNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtHQHouseNo.Focus();
                e.Handled = true;
            }
        }

        private void txtHQHouseNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtHQRoadNo.Focus();
                e.Handled = true;
            }
        }

        private void txtHQRoadNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtHQBlock.Focus();
                e.Handled = true;
            }
        }

        private void txtHQBlock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtHQArea.Focus();
                e.Handled = true;
            }
        }

        private void txtHQArea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtHQContactNo.Focus();
                e.Handled = true;
            }
        }

        private void txtHQContactNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbHQDivision.Focus();
                e.Handled = true;
            }
        }

        private void cmbHQDivision_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbHQDistrict.Focus();
                e.Handled = true;
            }
        }

        private void cmbHQDistrict_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbHQThana.Focus();
                e.Handled = true;
            }
        }

        private void cmbHQThana_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbHQPost.Focus();
                e.Handled = true;
            }
        }

        private void cmbHQPost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtHQPostCode.Focus();
                e.Handled = true;
            }
        }

        private void txtHQPostCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtOFlat.Focus();
                e.Handled = true;
            }
        }

        private void txtOFlat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtOHouse.Focus();
                e.Handled = true;
            }
        }

        private void txtOHouse_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtORoad.Focus();
                e.Handled = true;
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void txtORoad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtOBlock.Focus();
                e.Handled = true;
            }
        }

        private void txtOBlock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtOArea.Focus();
                e.Handled = true;
            }
        }

        private void txtOArea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtOContactNo.Focus();
                e.Handled = true;
            }
        }

        private void txtOContactNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbODivision.Focus();
                e.Handled = true;
            }
        }

        private void cmbODivision_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbODistrict.Focus();
                e.Handled = true;
            }
        }

        private void cmbODistrict_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbOThana.Focus();
                e.Handled = true;
            }
        }

        private void cmbOThana_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbOPost.Focus();
                e.Handled = true;
            }
        }

        private void cmbOPost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtOPostCode.Focus();
                e.Handled = true;
            }
        }

        private void txtOPostCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addButton.Focus();
                e.Handled = true;
            }
        }

        private void certificateNoTextBox_Validating(object sender, CancelEventArgs e)
        {


        }

        private int Certificates(int issuedshare, int certificaterange)
        {
            return issuedshare/certificaterange;
        }

        private void SaveShare()
        {
            totalCertificates = Certificates(int.Parse(txtTotalIssuedShare.Text), int.Parse(certificateNoTextBox.Text));
            int shareno = 1;
            int sharerange = int.Parse(certificateNoTextBox.Text);
            for (int i = 1; i <= totalCertificates; i++)
            {
                int shareid;

                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string query1 = "INSERT INTO Certificate (CertificateNumber) VALUES (@d1)" +
                                    "SELECT CONVERT(int, SCOPE_IDENTITY())";
                    cmd = new SqlCommand(query1, con);
                    cmd.Parameters.AddWithValue("@d1", i);
                    shareid = (int) cmd.ExecuteScalar();
                    con.Close();
                    for (int j = 0; j < sharerange; j++)
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string query2 = "INSERT INTO Share (ShareNumber, CertificateId) VALUES (@d1,@d2)" +
                                        "SELECT CONVERT(int, SCOPE_IDENTITY())";
                        cmd = new SqlCommand(query2, con);
                        cmd.Parameters.AddWithValue("@d1", shareno);
                        cmd.Parameters.AddWithValue("@d2", i);
                        cmd.ExecuteScalar();

                        con.Close();
                        shareno++;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 20; i++)
            {
                // Report progress to 'UI' thread
                backgroundWorker1.ReportProgress(i);
                // Simulate long task
                System.Threading.Thread.Sleep(100);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void ProgressbarStart(Button button)
        {
            backgroundWorker1.RunWorkerAsync();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
            button.Enabled = false;
            button.Visible = false;
            listView1.Visible = false;
            removeButton.Visible = false;
            label61.BringToFront();
            label61.Visible = true;
            label62.Visible = true;
            label62.BringToFront();
            progressBar1.Visible = true;
            progressBar1.BringToFront();
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox6.Visible = false;
        }

        private void ProgressbarOff(Button button)
        {
            backgroundWorker1.CancelAsync();
            backgroundWorker1.Dispose();
            progressBar1.Visible = false;
            progressBar1.SendToBack();
            listView1.Visible = true;
            removeButton.Visible = true;
            label61.SendToBack();
            label61.Visible = false;
            label62.Visible = false;
            button.Visible = true;
            button.Enabled = true;
            groupBox1.Visible = true;
            groupBox2.Visible = true;
            groupBox3.Visible = true;
            groupBox4.Visible = true;
            groupBox5.Visible = true;
            groupBox6.Visible = true;
        }

        private void certificateNoTextBox_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtTotalIssuedShare.Text))
            {
                MessageBox.Show(@"Enter Total Issued Share first");
            }
            else if (string.IsNullOrWhiteSpace(certificateNoTextBox.Text))
            {
                MessageBox.Show(@"Enter Certificate Per Share first");
            }
            else
            {
                decimal share = decimal.Parse(txtTotalIssuedShare.Text);
                decimal certificate = decimal.Parse(certificateNoTextBox.Text);
                if (share%certificate != 0m)
                {
                    MessageBox.Show(@"Share and Certificate are not multiple of each other Please check and correct");
                    certificateNoTextBox.Clear();
                    certificateNoTextBox.Focus();
                }
            }
        }

        private void txtHQContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void txtOContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void addButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                saveButton.Focus();
                e.Handled = true;
            }
        }

        

    }
}