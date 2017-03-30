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
    public partial class MeetingCreation : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        ConnectionString cs=new ConnectionString();
        private SqlDataReader rdr;
        public Nullable<decimal> aId, aId1;
        public decimal addHId;
        public int affectedRows1, currentMeetingId, boardId, count, companyId;
        public string serialNo, divisionId, districtId, thanaId, postofficeId, userId;


        public MeetingCreation()
        {
            InitializeComponent();
        }


        public void BoardNameLoad()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "SELECT BoardName FROM Board ";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtBoardName.Text = (rdr.GetString(0));
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void AgendaHeaderLoad()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "SELECT  AHeaderName  FROM  AddressHeader";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbVenue.Items.Add(rdr.GetValue(0).ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GetMeetingTitle()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctt = "SELECT IDENT_CURRENT ('Meeting')";
                cmd = new SqlCommand(ctt);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    aId = (rdr.GetDecimal(0));

                    if (aId == 0)
                    {
                        aId1 = aId+1;
                        txtMeetingName.Text = "1st Board Meeting";
                    }
                    else if (aId == 1)
                    {
                        aId1 = aId+1;
                        txtMeetingName.Text = "2nd Board Meeting";
                    }
                    else if (aId ==2)
                    {
                        aId1 = aId + 2;
                        txtMeetingName.Text = "3rd Board Meeting";
                    }
                    else if (aId == 3)
                    {
                        txtMeetingName.Text = "4rth Board Meeting";
                    }

                    else if (aId >= 4)
                    {
                        aId1 = aId + 1;
                        txtMeetingName.Text = aId1 + "th Board Meeting";
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void CompanyNameLoad()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "SELECT CompanyName FROM Company ";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtCompanyName.Text = (rdr.GetString(0));
                }

                con.Close();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query2 = "SELECT CompanyId FROM Company where  Company.CompanyName='" + txtCompanyName.Text + "' ";
                cmd = new SqlCommand(query2, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    companyId = (rdr.GetInt32(0));
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChangedPositioned()
        {
            label7.Visible = false;
           // textBox1.Visible = false;
           // textBox1.Clear();
            label7.Location = new Point(46, 444);
           // textBox1.Location = new Point(200, 437);

            label12.Location = new Point(81, 217);
           // txtC1DM2Particulars.Location = new Point(200, 217);
            label13.Location = new Point(56, 397);
           // txtC1DM2DebitBalance.Location = new Point(200, 394);
        }
        public void MeetingVanueLoad()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "SELECT AddressHeader.AHeaderName FROM AddressHeader order by  AddressHeader.AHeaderId desc";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbVenue.Items.Add(rdr[0]);
                }
                con.Close();
                cmbVenue.Items.Add("Not In The List");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    cmbDivision.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MeetingCreation_Load(object sender, EventArgs e)
        {
            userId = frmLogin.uId.ToString();
            groupBox2.Visible = false;
            label4.Visible = false;
            label9.Visible = false;
            this.MaximumSize = new Size(700, 1080);
            GetMeetingTitle();
            BoardNameLoad();
            CompanyNameLoad();
            MeetingVanueLoad();
            FillHQDivisionCombo();
            GenerateSerialNumberForMeeting();
        }
        private void GenerateSerialNumberForMeeting()
        {
            String sDate = DateTime.Now.ToString();
            DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));
            String dy = datevalue.Day.ToString();
            String mn = datevalue.Month.ToString();
            String yy = datevalue.Year.ToString();
           con=new SqlConnection(cs.DBConn);
           con.Open();
           string qry = "Select Count(MeetingId) from Meeting";
           cmd=new SqlCommand(qry,con);
           rdr=cmd.ExecuteReader();
            if (rdr.Read())
            {
                count = (rdr.GetInt32(0));
            }
            if (count == 0)
            {
                currentMeetingId = 1;
                count = 1;
                serialNo = yy + "-" + boardId + "-" + count + "-" + currentMeetingId;
            }
            else
            {
                serialNo = yy + "-" + boardId + "-" + count + "-" + currentMeetingId;
            }
            
        }

        private void SaveAddressHeader()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query2 = "insert into AddressHeader(AHeaderName) values (@d1)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                cmd = new SqlCommand(query2, con);
                cmd.Parameters.AddWithValue("@d1", txtNAddressHeader.Text);               
                addHId = (int)cmd.ExecuteScalar();
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        private void SaveMeetingAddress()
        {
                SaveAddressHeader();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string insertQ = "insert into CompanyAddresses(AHeaderId,PostOfficeId,FlatNo,HouseNo,RoadNo,Block,Area,ContactNo,CompanyId) Values(@d1,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                cmd = new SqlCommand(insertQ);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", string.IsNullOrEmpty(addHId.ToString()) ? (object)DBNull.Value : addHId.ToString()));
                cmd.Parameters.Add(new SqlParameter("@d4", string.IsNullOrEmpty(postofficeId) ? (object)DBNull.Value : postofficeId));
                cmd.Parameters.Add(new SqlParameter("@d5", string.IsNullOrEmpty(txtFlatNo.Text) ? (object)DBNull.Value : txtFlatNo.Text));
                cmd.Parameters.Add(new SqlParameter("@d6", string.IsNullOrEmpty(txtHouseNo.Text) ? (object)DBNull.Value : txtHouseNo.Text));
                cmd.Parameters.Add(new SqlParameter("@d7", string.IsNullOrEmpty(txtRoadNo.Text) ? (object)DBNull.Value : txtRoadNo.Text));
                cmd.Parameters.Add(new SqlParameter("@d8", string.IsNullOrEmpty(txtBlock.Text) ? (object)DBNull.Value : txtBlock.Text));
                cmd.Parameters.Add(new SqlParameter("@d9", string.IsNullOrEmpty(txtArea.Text) ? (object)DBNull.Value : txtArea.Text));
                cmd.Parameters.Add(new SqlParameter("@d10", string.IsNullOrEmpty(txtContactNo.Text) ? (object)DBNull.Value : txtContactNo.Text));
                cmd.Parameters.AddWithValue("@d11", companyId);
                affectedRows1 = (int)cmd.ExecuteScalar();
                con.Close();
        }

        private void ResetAddress()
        {
            txtFlatNo.Clear();
            txtHouseNo.Clear();
            txtRoadNo.Clear();
            txtBlock.Clear();
            txtArea.Clear();
            txtContactNo.Clear();
            txtPostCode.Clear();
            cmbPost.SelectedIndex = -1;
            cmbThana.SelectedIndex = -1;
            cmbDistrict.SelectedIndex = -1;
            cmbDivision.SelectedIndex = -1;
        }
        private void Reset()
        {
            txtCompanyName.Clear();
            txtBoardName.Clear();
            txtMeetingName.Clear();
            cmbVenue.SelectedIndex = -1;
            txtMeetingDate.Value=DateTime.Today;

            if (!string.IsNullOrEmpty(txtNAddressHeader.Text))
            {
                ResetAddress();
            }
           
        }
        private void buttonMeetingCreation_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(cmbVenue.Text))
            {
                MessageBox.Show("Please Select Vanue for the Meeting", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbVenue.Text == "Not In The List")
            {
                if (string.IsNullOrEmpty(txtNAddressHeader.Text))
                {
                    MessageBox.Show("Please enter Address Header for the Meeting", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrEmpty(cmbDivision.Text))
                {
                    MessageBox.Show("Please Select division of Address", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrEmpty(cmbDistrict.Text))
                {
                    MessageBox.Show("Please Select district of Address", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrEmpty(cmbThana.Text))
                {
                    MessageBox.Show("Please Select thana of Address", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrEmpty(cmbPost.Text))
                {
                    MessageBox.Show("Please Select Post Office of Address", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
            }
           
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query2 = "insert into Meeting(AHeaderId,MeetingName,MeetingDate,SerialNumber,UserId,DateTime,Statuss) values (@d1,@d2,@d3,@d4,@d5,@d6,@d7)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                cmd = new SqlCommand(query2, con);
                cmd.Parameters.AddWithValue("@d1", addHId);
                cmd.Parameters.AddWithValue("@d2", aId1);               
                cmd.Parameters.AddWithValue("@d3", Convert.ToDateTime(txtMeetingDate.Value, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat));
                cmd.Parameters.AddWithValue("@d4", serialNo);
                cmd.Parameters.AddWithValue("@d5", userId);
                cmd.Parameters.AddWithValue("@d6", DateTime.UtcNow.ToLocalTime());
                cmd.Parameters.AddWithValue("@d7", "Open");
                currentMeetingId = (int)cmd.ExecuteScalar();
                con.Close();
                if (!string.IsNullOrEmpty(txtNAddressHeader.Text))
                {
                    SaveMeetingAddress();
                }
                MessageBox.Show("Meeting Created Successfully", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MeetingCreation_FormClosed(object sender, FormClosedEventArgs e)
        {
                       this.Hide();
            MeetingManagementUI frm=new MeetingManagementUI();
                          frm.Show();

        }

        private void VisibleAddressHeader()
        {
            if (cmbVenue.Text == "Not In The List")
            {
                groupBox2.Visible = true;
                label4.Visible = true;
                label9.Visible = true;
                this.MaximumSize = new Size(1400, 1080);
               
            }
            else
            {
                groupBox2.Visible = false;
                label9.Visible = false;
                label4.Visible = false;
                this.MaximumSize = new Size(700, 1080);
            }
            
        }
       
        private void cmbVenue_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT AddressHeader.AHeaderId from AddressHeader where  AddressHeader.AHeaderName= '" + cmbVenue.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    addHId = rdr.GetInt32(0);
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                VisibleAddressHeader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBoardName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT BoardId from Board WHERE BoardName= '" + txtBoardName.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    boardId = rdr.GetInt32(0);
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

        private void cmbDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Divisions.Division_ID)  from Divisions WHERE Divisions.Division=@find";

                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "Division"));
                cmd.Parameters["@find"].Value = cmbDivision.Text;
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


                cmbDivision.Text = cmbDivision.Text.Trim();
                cmbDistrict.SelectedIndex = -1;
                cmbDistrict.Items.Clear();
                cmbThana.SelectedIndex = -1;
                cmbThana.Items.Clear();
                cmbPost.SelectedIndex = -1;
                cmbPost.Items.Clear();
                txtPostCode.Clear();
                cmbDistrict.Enabled = true;
                cmbDistrict.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Districts.District) from Districts  Where Districts.Division_ID = '" + divisionId + "' order by Districts.Division_ID desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbDistrict.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Districts.D_ID)  from Districts WHERE Districts.District=@find";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "District"));
                cmd.Parameters["@find"].Value = cmbDistrict.Text;
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
                cmbDistrict.Text = cmbDistrict.Text.Trim();
                cmbThana.SelectedIndex = -1;
                cmbThana.Items.Clear();
                cmbPost.SelectedIndex = -1;
                cmbPost.Items.Clear();
                txtPostCode.Clear();
                cmbThana.Enabled = true;
                cmbThana.Focus();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Thanas.Thana) from Thanas  Where Thanas.D_ID = '" + districtId + "' order by Thanas.D_ID desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbThana.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbThana_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Thanas.T_ID)  from Thanas WHERE Thanas.Thana=@find";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "Thana"));
                cmd.Parameters["@find"].Value = cmbThana.Text;
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
                cmbThana.Text = cmbThana.Text.Trim();
                cmbPost.SelectedIndex = -1;
                cmbPost.Items.Clear();
                txtPostCode.Clear();
                cmbPost.Enabled = true;
                cmbPost.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(PostOffice.PostOfficeName) from PostOffice  Where PostOffice.T_ID = '" + thanaId + "' order by PostOffice.T_ID desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbPost.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbPost_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(PostOffice.PostOfficeId),RTRIM(PostOffice.PostCode) from PostOffice WHERE PostOffice.PostOfficeName=@find";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "PostOfficeName"));
                cmd.Parameters["@find"].Value = cmbPost.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    postofficeId = (rdr.GetString(0));
                    txtPostCode.Text = (rdr.GetString(1));
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
}
