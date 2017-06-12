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
            groupBox5.Enabled = false;
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
                    "insert into CompanyAddresses(AHeaderId,Address,CompanyId) Values(@d1,@d2,@d9)" +
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

        private void SaveCompanyAddress(int addHeaderId,string address)
        {


            if (addHeaderId == 1)
            {
                SaveRegAddressHeader();
            }
            if (addHeaderId == 2)
            {
                SaveCorporatHQAddHeader();
            }
          
              con = new SqlConnection(cs.DBConn);
                con.Open();
                string insertQ =
                    "insert into CompanyAddresses(AHeaderId,Address,CompanyId) Values(@d1,@d2,@d9)" +
                    "SELECT CONVERT(int, SCOPE_IDENTITY())";
                cmd = new SqlCommand(insertQ);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1",
                    string.IsNullOrEmpty(addHeaderId.ToString()) ? (object) DBNull.Value : addHeaderId));
                cmd.Parameters.Add(new SqlParameter("@d2",
                    string.IsNullOrEmpty(address) ? (object) DBNull.Value : address));
                cmd.Parameters.AddWithValue("@d9", currentCompanyId);
                affectedRows1 = (int) cmd.ExecuteScalar();
                con.Close();
         
            
        }

        private void ResetHQAddress()
        {
          corporateRichTextBox.Clear();
      
        }

        private void ResetOtherAddress()
        {
            oherRichTextBox.Clear();
        }

        private void ResetRegisteredAddress()
        {
            registrationrichTextBox.Clear();
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

            if (string.IsNullOrWhiteSpace(registrationrichTextBox.Text))
            {
                MessageBox.Show("Please select company Registration Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProgressbarOff(saveButton);
                return;
            }
            if (string.IsNullOrWhiteSpace(corporateRichTextBox.Text))
            {
                MessageBox.Show("Please Select Corporate Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (otherAddress.Checked&& (!string.IsNullOrEmpty(oherRichTextBox.Text)||cmbAddressHeader.SelectedIndex!=-1))
            {
                MessageBox.Show(@"Please Add Other Addres to list before saving", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                "insert into Company(CompanyName,TotalAuthorizedShare,AvailableAuthorizedShare,ValueofEachShare,TotalIssuedShare,AvailableIssuedShare,Corum,NumberOfDirector,VacantPostofDirector,VacantPostofMDirector,VacantPostofChairman,RegiNumber,MeetingAllowance,UserId,DateTime,CertificateRange) values (@d1,@d2,@d3,@d4,@d5,@d5,@d6,@d7,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14)" +
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
            cmd.Parameters.AddWithValue("@d14", certificateNoTextBox.Text);
            currentCompanyId = (int) cmd.ExecuteScalar();
            con.Close();
            SaveCompanyAddress(1,registrationrichTextBox.Text);
            SaveCompanyAddress(2,corporateRichTextBox.Text);
            if (otherAddress.Checked)
            {
                for (int i = 0; i < listView1.Items.Count - 1; i++)
                {
                    SaveCompanyAddress(Convert.ToInt32(listView1.Items[i].SubItems[2].Text), listView1.Items[i].SubItems[3].Text);
                }
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



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (otherAddress.Checked)
            {
                groupBox5.Enabled = true;
             
                cmbAddressHeader.Focus();

            }
            else
            {
                groupBox5.Enabled = false;
            
                ResetOtherAddress();
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
           
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (cmbAddressHeader.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select an Address header");
            }
            else if (string.IsNullOrWhiteSpace(oherRichTextBox.Text))
            {
                MessageBox.Show("PleaseWrite an Address");
            }
            else
            {


                if (listView1.Items.Count == 0)
                {
                    ListViewItem list = new ListViewItem();
                    list.SubItems.Add(cmbAddressHeader.Text);
                    list.SubItems.Add(addHeaderId.ToString());
                    list.SubItems.Add(oherRichTextBox.Text);
                    listView1.Items.Add(list);
                    cmbAddressHeader.SelectedIndex = -1;
                    oherRichTextBox.Clear();
                    return;
                }
                ListViewItem list1 = new ListViewItem();
                list1.SubItems.Add(cmbAddressHeader.Text);
                list1.SubItems.Add(addHeaderId.ToString());
                list1.SubItems.Add(oherRichTextBox.Text);
                list1.SubItems.Add(postofficeIdO);
                listView1.Items.Add(list1);
                cmbAddressHeader.SelectedIndex = -1;
                oherRichTextBox.Clear();
                return;

            }
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
              registrationrichTextBox.Focus();
                e.Handled = true;
            }
        }


        private void groupBox3_Enter(object sender, EventArgs e)
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


        private void addButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                saveButton_Click(this, new EventArgs());
                
            }
        }

        private void txtValueOfEachShare_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char) Keys.Back)))
                e.Handled = true;
        }

        private void txtMeetingAlowance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
         }

        private void txtTotalIssuedShare_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char) Keys.Back)))
                e.Handled = true;
        }

        private void txtCorum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char) Keys.Back)))
                e.Handled = true;
        }

        private void txtTotalAuthorizedShare_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char) Keys.Back)))
                e.Handled = true;
        }

        private void txtNumberOfDirector_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char) Keys.Back)))
                e.Handled = true;
        }

        private void certificateNoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char) Keys.Back)))
                e.Handled = true;
        }

        

    }
}