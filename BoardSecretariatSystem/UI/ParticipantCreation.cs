using System;
using System.Collections;
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

namespace BoardSecretariatSystem.UI
{

    public partial class ParticipantCreation : Form
    {
        SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();

        public string countryid,

            nUserId,
            divisionId,
            divisionIdP,
            districtId,
            districtIdP,
            thanaId,
            thanaIdP,
            postofficeId,
            postofficeIdP,
            memberTypeId;

        public int affectedRows1,
            affectedRows2,
            affectedRows3,
            currentPerticipantId,
            currentShareHolderId,
            bankEmailId,
            boardMemberId,
            availableIssuedShare,
            availableIssuedShare1,
            genderId,
            companyId, diff, certificateRange, start, end;

        private List<int> shares = new List<int>();
        private List<int> availableShares = new List<int>();
        private bool companyCreated;

        public ParticipantCreation()
        {
            InitializeComponent();
        }

        private bool LoadCompany()
        {
            bool x = false;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string query = "SELECT CompanyId, CertificateRange FROM Company";
            cmd = new SqlCommand(query, con);
            rdr = cmd.ExecuteReader();
            if (rdr.Read() && !rdr.IsDBNull(0))
            {
                companyId = Convert.ToInt32(rdr["CompanyId"]);
                certificateRange = Convert.ToInt32(rdr["CertificateRange"]);
                x = true;
            }
            return x;


        }

        public void FillPermanantDivisionCombo()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Divisions.Division) from Divisions  order by Divisions.Division_ID desc ";
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

        public void FillPresentDivisionCombo()
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
                    cmbPDivision.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void FillCertificate()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "SELECT        CertificateNumber FROM Certificate WHERE        (ShareholderId IS NULL) order by CertificateNumber asc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    int cert = Convert.ToInt32(rdr[0]);
                    certificateStartComboBox.Items.Add(cert);
                    CertificateEndComboBox.Items.Add(cert);
                    availableShares.Add(cert);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateAvailableIssuedShare()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string qry2 = "SELECT Company.AvailableIssuedShare from  Company";
                cmd = new SqlCommand(qry2, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {                   
                    //int k = 0;

                    int k = Convert.ToInt32(txtCurrentShareHolding.Text);
                    //int.TryParse(txtCurrentShareHolding.Text, out k);
                    availableIssuedShare = (rdr.GetInt32(0));
                    availableIssuedShare1 = availableIssuedShare - k;
                }
                con.Close();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string qry = "Update Company Set AvailableIssuedShare=@d1 where Company.CompanyId='" + companyId + "'";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@d1", availableIssuedShare1);
                cmd.ExecuteReader();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void GetGender()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctt = "select GenderName from Gender";
                cmd = new SqlCommand(ctt);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbGender.Items.Add(rdr.GetValue(0).ToString());
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void FillCountry()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctx = "select RTRIM(Countries.CountryName) from Countries  order by Countries.CountryId";
                cmd = new SqlCommand(ctx);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    CountryNamecomboBox.Items.Add(rdr[0]);
                }

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctt = "select RTRIM(CountryId) from Countries  where  Countries.CountryName='" +
                             CountryNamecomboBox.Text + "' ";
                cmd = new SqlCommand(ctt);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    countryid = (rdr.GetString(0));


                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ParticipantCreation_Load(object sender, EventArgs e)
        {
            FillCountry();
            CountryNamecomboBox.SelectedItem = "Bangladesh";
            nUserId = frmLogin.uId.ToString();
            companyCreated = LoadCompany();
            GetGender();
            FillPresentDivisionCombo();
            FillPermanantDivisionCombo();
            groupBox6.Hide();
            button1.Location = new Point(871, 570);
            FillCertificate();
        }

        private void ParticipantCreation_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MainUI frm = new MainUI();
            frm.Show();
        }

        private void PermanantSameAsPresent(string tblName1)
        {
            string tableName = tblName1;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string Qry = "insert into " + tableName +
                         "(PostOfficeId,PFlatNo,PHouseNo,PRoadNo,PBlock,PArea,PContactNo,ParticipantId) Values(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)" +
                         "SELECT CONVERT(int, SCOPE_IDENTITY())";
            cmd = new SqlCommand(Qry, con);
            cmd.Parameters.Add(new SqlParameter("@d1",
                string.IsNullOrEmpty(postofficeIdP) ? (object)DBNull.Value : postofficeIdP));
            cmd.Parameters.Add(new SqlParameter("@d2",
                string.IsNullOrEmpty(txtPFlatName.Text) ? (object)DBNull.Value : txtPFlatName.Text));
            cmd.Parameters.Add(new SqlParameter("@d3",
                string.IsNullOrEmpty(txtPHouseName.Text) ? (object)DBNull.Value : txtPHouseName.Text));
            cmd.Parameters.Add(new SqlParameter("@d4",
                string.IsNullOrEmpty(txtPRoadNo.Text) ? (object)DBNull.Value : txtPRoadNo.Text));
            cmd.Parameters.Add(new SqlParameter("@d5",
                string.IsNullOrEmpty(txtPBlock.Text) ? (object)DBNull.Value : txtPBlock.Text));
            cmd.Parameters.Add(new SqlParameter("@d6",
                string.IsNullOrEmpty(txtPArea.Text) ? (object)DBNull.Value : txtPArea.Text));
            cmd.Parameters.Add(new SqlParameter("@d7",
                string.IsNullOrEmpty(txtPContactNo.Text) ? (object)DBNull.Value : txtPContactNo.Text));
            cmd.Parameters.AddWithValue("@d8", currentPerticipantId);
            affectedRows2 = (int)cmd.ExecuteScalar();
            con.Close();
        }

        private void SaveParticipantAddress(string tblName1)
        {
            string tableName = tblName1;

            if (tableName == "PPresentAddresses")
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string insertQ = "insert into " + tableName +
                                 "(PostOfficeId,PFlatNo,PHouseNo,PRoadNo,PBlock,PArea,PContactNo,ParticipantId) Values(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)" +
                                 "SELECT CONVERT(int, SCOPE_IDENTITY())";
                cmd = new SqlCommand(insertQ, con);
                cmd.Parameters.Add(new SqlParameter("@d1",
                    string.IsNullOrEmpty(postofficeIdP) ? (object)DBNull.Value : postofficeIdP));
                cmd.Parameters.Add(new SqlParameter("@d2",
                    string.IsNullOrEmpty(txtPFlatName.Text) ? (object)DBNull.Value : txtPFlatName.Text));
                cmd.Parameters.Add(new SqlParameter("@d3",
                    string.IsNullOrEmpty(txtPHouseName.Text) ? (object)DBNull.Value : txtPHouseName.Text));
                cmd.Parameters.Add(new SqlParameter("@d4",
                    string.IsNullOrEmpty(txtPRoadNo.Text) ? (object)DBNull.Value : txtPRoadNo.Text));
                cmd.Parameters.Add(new SqlParameter("@d5",
                    string.IsNullOrEmpty(txtPBlock.Text) ? (object)DBNull.Value : txtPBlock.Text));
                cmd.Parameters.Add(new SqlParameter("@d6",
                    string.IsNullOrEmpty(txtPArea.Text) ? (object)DBNull.Value : txtPArea.Text));
                cmd.Parameters.Add(new SqlParameter("@d7",
                    string.IsNullOrEmpty(txtPContactNo.Text) ? (object)DBNull.Value : txtPContactNo.Text));
                cmd.Parameters.AddWithValue("@d8", currentPerticipantId);
                affectedRows1 = (int)cmd.ExecuteScalar();
                con.Close();
            }
            else if (tableName == "PPermanantAddresses")
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string insertQ = "insert into " + tableName +
                                 "(PostOfficeId,FlatNo,HouseNo,RoadNo,Block,Area,ContactNo,ParticipantId) Values(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)" +
                                 "SELECT CONVERT(int, SCOPE_IDENTITY())";
                cmd = new SqlCommand(insertQ, con);
                cmd.Parameters.Add(new SqlParameter("@d1",
                    string.IsNullOrEmpty(postofficeId) ? (object)DBNull.Value : postofficeId));
                cmd.Parameters.Add(new SqlParameter("@d2",
                    string.IsNullOrEmpty(txtFlatNo.Text) ? (object)DBNull.Value : txtFlatNo.Text));
                cmd.Parameters.Add(new SqlParameter("@d3",
                    string.IsNullOrEmpty(txtHouseNo.Text) ? (object)DBNull.Value : txtHouseNo.Text));
                cmd.Parameters.Add(new SqlParameter("@d4",
                    string.IsNullOrEmpty(txtRoadNo.Text) ? (object)DBNull.Value : txtRoadNo.Text));
                cmd.Parameters.Add(new SqlParameter("@d5",
                    string.IsNullOrEmpty(txtBlock.Text) ? (object)DBNull.Value : txtBlock.Text));
                cmd.Parameters.Add(new SqlParameter("@d6",
                    string.IsNullOrEmpty(txtArea.Text) ? (object)DBNull.Value : txtArea.Text));
                cmd.Parameters.Add(new SqlParameter("@d7",
                    string.IsNullOrEmpty(txtContactNo.Text) ? (object)DBNull.Value : txtContactNo.Text));
                cmd.Parameters.AddWithValue("@d8", currentPerticipantId);
                affectedRows1 = (int)cmd.ExecuteScalar();
                con.Close();
            }
        }

        private void ForeignAddresses(string tblName1)
        {
            string tableName = tblName1;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string Qury = "insert into " + tableName + "(ParticipantId,Street,State,PostalCode) Values(@d1,@d2,@d3,@d4)" +
                          "SELECT CONVERT(int, SCOPE_IDENTITY())";
            cmd = new SqlCommand(Qury);
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@d1", currentPerticipantId);
            cmd.Parameters.Add(new SqlParameter("@d2",
                string.IsNullOrEmpty(StreettextBox.Text) ? (object)DBNull.Value : StreettextBox.Text));
            cmd.Parameters.Add(new SqlParameter("@d3",
                string.IsNullOrEmpty(StatetextBox.Text) ? (object)DBNull.Value : StatetextBox.Text));
            cmd.Parameters.Add(new SqlParameter("@d4",
                string.IsNullOrEmpty(PostalCodetextBox.Text) ? (object)DBNull.Value : PostalCodetextBox.Text));
            affectedRows3 = (int)cmd.ExecuteScalar();
            con.Close();
        }


        private void Reset()
        {
            CountryNamecomboBox.SelectedIndex = -1;
            CountryCodetextBox.Clear();
            txtShareHolderName.Clear();
            txtCurrentShareHolding.Clear();
            txtFatherName.Clear();
            txtMotherName.Clear();
            txtCellNumber.Clear();
            txtProfession.Clear();
            cmbGender.SelectedIndex = -1;
            txtBirthCertificateNo.Clear();
            //txtDateOfBirth.Value = DateTime.Today;
            txtDateOfBirth.ResetText();
            txtCurrentShareHolding.Clear();
            txtPassportNo.Clear();
            txtTINNumber.Clear();
            txtNationalId.Clear();
            CountryNamecomboBox.SelectedIndex = -1;
            txtEmailAd.Clear();
            certificateStartComboBox.SelectedIndex = -1;
            certificateStartComboBox.Items.Clear();
            CertificateEndComboBox.SelectedIndex = -1;
            CertificateEndComboBox.Items.Clear();
            FillCertificate();
            if (unKnownRA.Checked)
            {
                unKnownRA.CheckedChanged -= unKnownRA_CheckedChanged;
                unKnownRA.Checked = false;
                unKnownRA.CheckedChanged += unKnownRA_CheckedChanged;
            }
            else
            {
                ResetPresentAddress();
            }

            if (unKnownCheckBox.Checked)
            {
                unKnownCheckBox.CheckedChanged -= unKnownCheckBox_CheckedChanged;
                unKnownCheckBox.Checked = false;
                unKnownCheckBox.CheckedChanged += unKnownCheckBox_CheckedChanged;
            }
            else if (sameAsRACheckBox.Checked)
            {
                sameAsRACheckBox.CheckedChanged -= sameAsRACheckBox_CheckedChanged;
                sameAsRACheckBox.Checked = false;
                sameAsRACheckBox.CheckedChanged += sameAsRACheckBox_CheckedChanged;
            }
            else
            {
                ResetPermanantAddress();
            }
        }

        private void Reset2()
        {
            CountryNamecomboBox.SelectedIndex = -1;
            CountryCodetextBox.Clear();
            txtShareHolderName.Clear();
            txtCurrentShareHolding.Clear();
            txtFatherName.Clear();
            txtMotherName.Clear();
            txtCellNumber.Clear();
            txtProfession.Clear();
            cmbGender.SelectedIndex = -1;
            txtBirthCertificateNo.Clear();
            txtDateOfBirth.Value = DateTime.Today;
            txtCurrentShareHolding.Clear();
            txtPassportNo.Clear();
            txtTINNumber.Clear();
            txtNationalId.Clear();
            ResetForeignAddress();
        }


        public void ResetPermanantAddress()
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

        public void ResetPresentAddress()
        {
            txtPFlatName.Clear();
            txtPHouseName.Clear();
            txtPRoadNo.Clear();
            txtPBlock.Clear();
            txtPArea.Clear();
            txtPContactNo.Clear();
            txtPPostCode.Clear();
            cmbPPost.SelectedIndex = -1;
            cmbPThana.SelectedIndex = -1;
            cmbPDistrict.SelectedIndex = -1;
            cmbPDivision.SelectedIndex = -1;


        }

        public void ResetForeignAddress()
        {
            StreettextBox.Clear();
            StatetextBox.Clear();
            PostalCodetextBox.Clear();
        }

        private void SaveShareHolder()
        {
            try
            {
                UpdateAvailableIssuedShare();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query1 = "insert into Shareholder(ParticipantId,NumberOfCurrentShareHolding) values (@d1,@d3)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                cmd = new SqlCommand(query1, con);
                cmd.Parameters.AddWithValue("@d1", currentPerticipantId);
                //cmd.Parameters.AddWithValue("@d2", txtShareHolderName.Text);
                cmd.Parameters.AddWithValue("@d3", txtCurrentShareHolding.Text);
                currentShareHolderId = (int)cmd.ExecuteScalar();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveParticipant()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query1 = "insert into Participant(ParticipantName,MotherName,FatherName,DateOfBirth,Profession,BoardMemberTypeId,ContactNumber,NationalId,BirthCertificateNumber,PassportNumber,TIN,EmailBankId,CompanyId,GenderId,CountryId,UserId,DateTime) values (@d1,@d2,@d3,@d4,@d5,4,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                cmd = new SqlCommand(query1, con);
                cmd.Parameters.AddWithValue("@d1", txtShareHolderName.Text);
                cmd.Parameters.Add(new SqlParameter("@d2", string.IsNullOrEmpty(txtMotherName.Text) ? (object)DBNull.Value : txtMotherName.Text));
                cmd.Parameters.Add(new SqlParameter("@d3", string.IsNullOrEmpty(txtFatherName.Text) ? (object)DBNull.Value : txtFatherName.Text));

                cmd.Parameters.Add(new SqlParameter("@d4",
                    !txtDateOfBirth.Checked ? (object)DBNull.Value : txtDateOfBirth.Value));
                //cmd.Parameters.AddWithValue("@d4", Convert.ToDateTime(txtDateOfBirth.Value, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat));
                cmd.Parameters.Add(new SqlParameter("@d5", string.IsNullOrEmpty(txtProfession.Text) ? (object)DBNull.Value : txtProfession.Text));
                //cmd.Parameters.Add(new SqlParameter("@d6",string.IsNullOrEmpty(boardMemberId.ToString()) ? (object) DBNull.Value : boardMemberId.ToString()));
                if (!string.IsNullOrEmpty(txtCellNumber.Text))
                {
                    cmd.Parameters.Add(new SqlParameter("@d7", string.IsNullOrEmpty(CountryCodetextBox.Text) && string.IsNullOrEmpty(txtCellNumber.Text) ? (object)DBNull.Value : CountryCodetextBox.Text + txtCellNumber.Text));
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@d7", (object)DBNull.Value));
                }
                
                cmd.Parameters.Add(new SqlParameter("@d8", string.IsNullOrEmpty(txtNationalId.Text) ? (object)DBNull.Value : txtNationalId.Text));
                cmd.Parameters.Add(new SqlParameter("@d9", string.IsNullOrEmpty(txtBirthCertificateNo.Text) ? (object)DBNull.Value : txtBirthCertificateNo.Text));
                cmd.Parameters.Add(new SqlParameter("@d10", string.IsNullOrEmpty(txtPassportNo.Text) ? (object)DBNull.Value : txtPassportNo.Text));
                cmd.Parameters.Add(new SqlParameter("@d11", string.IsNullOrEmpty(txtTINNumber.Text) ? (object)DBNull.Value : txtTINNumber.Text));
                cmd.Parameters.AddWithValue("@d12", bankEmailId);
                cmd.Parameters.AddWithValue("@d13", companyId);
                cmd.Parameters.AddWithValue("@d14", genderId);
                cmd.Parameters.AddWithValue("@d15", countryid);
                cmd.Parameters.AddWithValue("@d16", nUserId);
                cmd.Parameters.AddWithValue("@d17", DateTime.UtcNow.ToLocalTime());
                currentPerticipantId = (int)cmd.ExecuteScalar();
                con.Close();
                SaveShareHolder();
                UpdateShareCertificates();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateShareCertificates()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string qry =
                    "UPDATE       Certificate SET ShareholderId =@si WHERE        CertificateNumber between @st and @ed";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@si", currentShareHolderId);
                cmd.Parameters.AddWithValue("@st", start);
                cmd.Parameters.AddWithValue("@ed", end);
                cmd.ExecuteReader();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckAvailableIssuedShare()
        {

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string qry2 = "SELECT Company.AvailableIssuedShare from  Company";
                cmd = new SqlCommand(qry2, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    availableIssuedShare = (rdr.GetInt32(0));
                }
                con.Close();
                if (availableIssuedShare == 0)
                {
                    MessageBox.Show("There is no Available Issued Share", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private bool ValidateControlls()
        {
            bool validate = true;

            if (string.IsNullOrEmpty(txtShareHolderName.Text))
            {
                MessageBox.Show(@"Please Enter Share Holder Name", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                validate = false;
                txtShareHolderName.Focus();
            }

            else if (string.IsNullOrEmpty(certificateStartComboBox.Text))
            {
                MessageBox.Show(@"Please select Start Certificate", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                validate = false;
                certificateStartComboBox.Focus();
            }

            else if (string.IsNullOrEmpty(CertificateEndComboBox.Text))
            {
                MessageBox.Show(@"Please select End Certificate", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                validate = false;
                CertificateEndComboBox.Focus();
            }

            else if (string.IsNullOrEmpty(txtFatherName.Text))
            {
                MessageBox.Show(@"Please Enter Father Name", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                validate = false;
                txtFatherName.Focus();
            }

            else if (string.IsNullOrEmpty(txtMotherName.Text))
            {
                MessageBox.Show(@"Please Enter Mother Name", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                validate = false;
                txtMotherName.Focus();
            }

            else if (string.IsNullOrEmpty(cmbGender.Text))
            {
                MessageBox.Show(@"Please Select Gender", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                validate = false;
                cmbGender.Focus();
            }

            else if (CountryNamecomboBox.Text == "Bangladesh")
            {
                if (string.IsNullOrWhiteSpace(txtNationalId.Text))
                {
                    MessageBox.Show(@"Please Enter National ID Number", @"Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    validate = false;
                    txtNationalId.Focus();
                }

                if (unKnownRA.Checked == false)
                {
                    if (string.IsNullOrWhiteSpace(cmbPDivision.Text))
                    {
                        MessageBox.Show("Please select Present Address division", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        validate = false;
                        cmbPDivision.Focus();
                    }
                    else if (string.IsNullOrWhiteSpace(cmbPDistrict.Text))
                    {
                        MessageBox.Show("Please Select Present Address district", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        validate = false;
                        cmbPDistrict.Focus();
                    }
                    else if (string.IsNullOrWhiteSpace(cmbPThana.Text))
                    {
                        MessageBox.Show("Please select Present Address Thana", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        validate = false;
                        cmbPThana.Focus();
                    }
                    else  if (string.IsNullOrWhiteSpace(cmbPPost.Text))
                    {
                        MessageBox.Show("Please Select Present Address Post Name", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        validate = false;
                        cmbPPost.Focus();
                    }
                    
                }
                if (unKnownCheckBox.Checked == false && sameAsRACheckBox.Checked == false)
                {
                    if (string.IsNullOrWhiteSpace(cmbDivision.Text))
                    {
                        MessageBox.Show("Please select Permanant Address division", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        validate = false;
                        cmbDivision.Focus();
                    }
                    else if (string.IsNullOrWhiteSpace(cmbDistrict.Text))
                    {
                        MessageBox.Show("Please Select Permanant Address district", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        validate = false;
                        cmbDistrict.Focus();
                    }
                    else if (string.IsNullOrWhiteSpace(cmbThana.Text))
                    {
                        MessageBox.Show("Please select Permanant Address Thana", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        validate = false;
                        cmbThana.Focus();
                    }
                    else if (string.IsNullOrWhiteSpace(cmbPost.Text))
                    {
                        MessageBox.Show("Please Select Permanant Address Post Name", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        validate = false;
                        cmbPost.Focus();
                    }
                }
            }

            else if (CountryNamecomboBox.Text != "Bangladesh")
            {

                if (string.IsNullOrWhiteSpace(txtPassportNo.Text))
                {
                    MessageBox.Show(@"Please enter Passport Number!", @"Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    validate = false;
                    txtPassportNo.Focus();
                }

                else if (string.IsNullOrWhiteSpace(StreettextBox.Text) && string.IsNullOrWhiteSpace(StatetextBox.Text) && string.IsNullOrWhiteSpace(PostalCodetextBox.Text))
                {
                    MessageBox.Show(@"Please enter Addresses!", @"Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    validate = false;
                    StreettextBox.Focus();

                }
            }

            else if (ValidateShareHolder())
            {
                validate = false;
            }

            return validate;
        }


        private bool ValidateShareHolder()
        {
            List<Participant> participants = new List<Participant>();

            con = new SqlConnection(cs.DBConn);
            con.Open();
            string ct3 =
                "SELECT ParticipantName, MotherName, FatherName FROM Participant where  Participant.ParticipantName='" + txtShareHolderName.Text + "'";
            cmd = new SqlCommand(ct3, con);
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                if (rdr.HasRows)
                {
                    Participant x = new Participant();
                    x.Name = rdr.GetString(0);

                    if (!DBNull.Value.Equals(rdr["MotherName"]))
                    {
                        x.MotherName = rdr.GetString(1);
                    }
                    else
                    {
                        x.MotherName = null;
                    }

                    if (!DBNull.Value.Equals(rdr["FatherName"]))
                    {
                        x.FatherName = rdr.GetString(2);
                    }
                    else
                    {
                        x.FatherName = null;
                    }

                    //if (!DBNull.Value.Equals(rdr["DateOfBirth"]))
                    //{
                    //    x.DateofBirth = rdr.GetDateTime(3);
                    //}
                    //else
                    //{
                    //    x.DateofBirth = DateTime.Parse(null);
                    //}

                    //if (!DBNull.Value.Equals(rdr["Email"]))
                    //{
                    //    x.Email = rdr.GetString(4);
                    //}
                    //else
                    //{
                    //    x.Email = null;
                    //}

                    participants.Add(x);
                }
            }
            foreach (Participant p in participants)
            {
                if (p.Name == txtShareHolderName.Text && p.FatherName == txtFatherName.Text && p.MotherName == txtMotherName.Text)
                {
                    MessageBox.Show(@"This Share Holder Name Or Father Name Or Mother Name Exists,Please Input another one",
                        "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtShareHolderName.Clear();
                    txtFatherName.Clear();
                    txtMotherName.Clear();
                    con.Close();
                    return true;
                }

                //if (p.Name == txtShareHolderName.Text && p.MotherName == txtMotherName.Text)
                //{
                //    MessageBox.Show(@"This Share Holder Name Or Mother Name Exists,Please Input another one",
                //        "Error",
                //        MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    txtShareHolderName.Clear();
                //    txtMotherName.Clear();
                //    con.Close();
                //    return true;
                //}

               

                //if (p.Name == txtShareHolderName.Text && p.DateofBirth == DateTime.Parse(txtDateOfBirth.ToString()))
                //{
                //    MessageBox.Show(@"This Share Holder Name Or Date Of Birth Exists,Please Input another one",
                //        "Error",
                //        MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    txtShareHolderName.Clear();
                //    txtDateOfBirth.ResetText();
                //    con.Close();
                //    return true;
                //}

                //if (p.Name == txtShareHolderName.Text && p.Email == txtEmailAd.Text)
                //{
                //    MessageBox.Show(
                //        @"This Share Holder Name Or Email Exists,Please Input another one",
                //        "Error",
                //        MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    txtShareHolderName.Clear();
                //    txtEmailAd.Clear();
                //    con.Close();
                //    return true;
                //}
            }
            return false;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            AvailableIssuedShare();
            if (availableIssuedShare == 0)
            {
                MessageBox.Show(@"There is no Available Issued Share", @"error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                
            }



            //else if (!string.IsNullOrEmpty(txtShareHolderName.Text) && string.IsNullOrEmpty(txtFatherName.Text) &&
            //         string.IsNullOrEmpty(txtMotherName.Text))

            //{
            //    MessageBox.Show(@"Please insert Father Name OR Mother Name", @"Error",
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtFatherName.Focus();
            //}


            else if (ValidateControlls())
            {


                if (CountryNamecomboBox.Text == "Bangladesh")
                {

                    try
                    {
                        //    con = new SqlConnection(cs.DBConn);
                        //    con.Open();
                        //    string ct3 =
                        //        "select Participant.ParticipantName from Participant where  Participant.ParticipantName='" +
                        //        txtShareHolderName.Text + "'";
                        //    cmd = new SqlCommand(ct3, con);
                        //    rdr = cmd.ExecuteReader();
                        //    if (rdr.Read() && !rdr.IsDBNull(0))
                        //    {
                        //        MessageBox.Show("This Share Holder Already Exists,Please Input another one", "Error",
                        //            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //        con.Close();
                        //        return;

                        //    }
                        //1. Both Not Applicable
                        if (unKnownRA.Checked && unKnownCheckBox.Checked)
                        {
                            SaveParticipant();
                        }
                        //2.Present Address  Applicable & Permanant Address not  Applicable
                        if (unKnownRA.Checked == false && unKnownCheckBox.Checked)
                        {
                            SaveParticipant();
                            SaveParticipantAddress("PPresentAddresses");
                        }
                        //3.Permanant Address Applicable  & Present Address  Applicable
                        if (sameAsRACheckBox.Checked == false && unKnownCheckBox.Checked == false)
                        {
                            SaveParticipant();
                            SaveParticipantAddress("PPermanantAddresses");
                            SaveParticipantAddress("PPresentAddresses");
                        }
                        //4.Permanant Address Applicable  & Present Address Same as Permanant Address                                        
                        if (sameAsRACheckBox.Checked && unKnownRA.Checked == false && unKnownCheckBox.Checked == false)
                        {
                            SaveParticipant();
                            SaveParticipantAddress("PPermanantAddresses");
                            PermanantSameAsPresent("PPresentAddresses");
                        }
                        //5.Present Address not  Applicable  & Permanant Address  Applicable
                        if (unKnownRA.Checked && sameAsRACheckBox.Checked == false && unKnownCheckBox.Checked == false)
                        {
                            SaveParticipant();
                            SaveParticipantAddress("PPermanantAddresses");
                        }
                        MessageBox.Show("Successfully Created", "Record", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        Reset();
                        CountryNamecomboBox.SelectedItem = "Bangladesh";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }


                else 
                {
                    try
                    {
                        //if (CountryNamecomboBox.Text != "Bangladesh")
                        //{
                        //    if (string.IsNullOrWhiteSpace(StreettextBox.Text) &&
                        //        string.IsNullOrWhiteSpace(StatetextBox.Text) &&
                        //        string.IsNullOrWhiteSpace(PostalCodetextBox.Text))
                        //    {
                        //        MessageBox.Show("Please enter Addresses!", "Error", MessageBoxButtons.OK,
                        //            MessageBoxIcon.Error);
                        //        return;

                        //    }
                        //}

                        SaveParticipant();
                        ForeignAddresses("ForeignAddress");
                        MessageBox.Show("Successfully Created", "Record", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        Reset2();
                        CountryNamecomboBox.SelectedItem = "Bangladesh";

                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void AvailableIssuedShare()
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string qry2 = "SELECT Company.AvailableIssuedShare from  Company";
            cmd = new SqlCommand(qry2, con);
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                availableIssuedShare = (rdr.GetInt32(0));
            }
            con.Close();
        }

        private void boardNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cmbRADivision_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cmbRADistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cmbRAThana_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cmbRAPost_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cmbWAPost_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cmbWAThana_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cmbWADistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cmbWADivision_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void unKnownCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (unKnownCheckBox.Checked)
            {

                if (sameAsRACheckBox.Checked)
                {
                    sameAsRACheckBox.CheckedChanged -= sameAsRACheckBox_CheckedChanged;
                    sameAsRACheckBox.Checked = false;
                    sameAsRACheckBox.CheckedChanged += sameAsRACheckBox_CheckedChanged;
                    groupBox4.Enabled = false;
                    ResetPermanantAddress();
                    ResetPStar();
                }
                else
                {

                    groupBox4.Enabled = false;
                    ResetPermanantAddress();
                    ResetPStar();
                }

            }
            else
            {
                if (sameAsRACheckBox.Checked)
                {
                    groupBox4.Enabled = false;
                    ResetPermanantAddress();
                    ResetPStar();
                }
                else
                {

                    groupBox4.Enabled = true;
                    ResetPermanantAddress();
                    FillPStar();
                }
            }
        }

        private void txtPContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void txtContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void FillStar()
        {
            label37.Visible = true;
            label35.Visible = true;
            label39.Visible = true;
            label40.Visible = true;
            label45.Visible = true;
        }

        private void ResetStar()
        {
            label37.Visible = false;
            label35.Visible = false;
            label39.Visible = false;
            label40.Visible = false;
            label45.Visible = false;
        }

        private void sameAsRACheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sameAsRACheckBox.Checked)
            {

                if (unKnownCheckBox.Checked)
                {
                    unKnownCheckBox.CheckedChanged -= unKnownCheckBox_CheckedChanged;
                    unKnownCheckBox.Checked = false;
                    unKnownCheckBox.CheckedChanged += unKnownCheckBox_CheckedChanged;
                    groupBox4.Enabled = false;
                    ResetPermanantAddress();
                    ResetPStar();
                }
                else
                {

                    groupBox4.Enabled = false;
                    ResetPermanantAddress();
                    ResetPStar();
                }

            }
            else
            {
                if (unKnownCheckBox.Checked)
                {
                    groupBox4.Enabled = false;
                    ResetPermanantAddress();
                    ResetPStar();
                }
                else
                {

                    groupBox4.Enabled = true;
                    ResetPermanantAddress();
                    FillPStar();
                }
            }
        }

        private void participantContactNoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void ResetPStar()
        {
            label32.Visible = false;
            label33.Visible = false;
            label34.Visible = false;
            label42.Visible = false;
            label44.Visible = false;
        }

        private void FillPStar()
        {
            label32.Visible = true;
            label33.Visible = true;
            label34.Visible = true;
            label42.Visible = true;
            label44.Visible = true;
        }

        private void unKnownRA_CheckedChanged(object sender, EventArgs e)
        {
            if (unKnownRA.Checked == true)
            {
                ResetStar();
                groupBox5.Enabled = false;
                sameAsRACheckBox.Visible = false;
                ResetPresentAddress();

            }
            else
            {
                FillStar();
                groupBox5.Enabled = true;
                sameAsRACheckBox.Visible = true;
            }
        }

        private void unKnownRA_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void boardNameComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void cmbPDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Divisions.Division_ID)  from Divisions WHERE Divisions.Division=@find";

                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "Division"));
                cmd.Parameters["@find"].Value = cmbPDivision.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    divisionIdP = (rdr.GetString(0));

                }

                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }


                cmbPDivision.Text = cmbPDivision.Text.Trim();
                cmbPDistrict.Items.Clear();
                cmbPDistrict.Text = "";
                cmbPThana.SelectedIndex = -1;
                cmbPPost.SelectedIndex = -1;
                txtPPostCode.Clear();
                cmbPDistrict.Enabled = true;
                cmbPDistrict.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Districts.District) from Districts  Where Districts.Division_ID = '" +
                            divisionIdP + "' order by Districts.Division_ID desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbPDistrict.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbPDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Districts.D_ID)  from Districts WHERE Districts.District=@find";

                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "District"));
                cmd.Parameters["@find"].Value = cmbPDistrict.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    districtIdP = (rdr.GetString(0));

                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                cmbPDistrict.Text = cmbPDistrict.Text.Trim();
                cmbPThana.Items.Clear();
                cmbPThana.Text = "";
                cmbPPost.SelectedIndex = -1;
                txtPPostCode.Clear();
                cmbPThana.Enabled = true;
                cmbPThana.Focus();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Thanas.Thana) from Thanas  Where Thanas.D_ID = '" + districtIdP +
                            "' order by Thanas.D_ID desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbPThana.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbPThana_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Thanas.T_ID)  from Thanas WHERE Thanas.Thana=@find and Thanas.D_ID=@d2 ";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "Thana"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NVarChar, 50, "D_ID"));
                cmd.Parameters["@find"].Value = cmbPThana.Text;
                cmd.Parameters["@d2"].Value = districtIdP;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    thanaIdP = (rdr.GetString(0));

                }

                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }


                cmbPThana.Text = cmbPThana.Text.Trim();
                cmbPPost.Items.Clear();
                cmbPPost.Text = "";
                txtPPostCode.Clear();
                cmbPPost.Enabled = true;
                cmbPPost.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(PostOffice.PostOfficeName) from PostOffice  Where PostOffice.T_ID = '" +
                            thanaIdP + "' order by PostOffice.T_ID desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbPPost.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbPPost_SelectedIndexChanged(object sender, EventArgs e)
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
                cmd.Parameters["@find"].Value = cmbPPost.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    postofficeIdP = (rdr.GetString(0));
                    txtPPostCode.Text = (rdr.GetString(1));

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
                cmbDistrict.Items.Clear();
                cmbDistrict.Text = "";
                cmbThana.SelectedIndex = -1;
                cmbPost.SelectedIndex = -1;
                txtPostCode.Clear();
                cmbDistrict.Enabled = true;
                cmbDistrict.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Districts.District) from Districts  Where Districts.Division_ID = '" +
                            divisionId + "' order by Districts.Division_ID desc";
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
                cmbThana.Items.Clear();
                cmbThana.Text = "";
                cmbPost.SelectedIndex = -1;
                txtPostCode.Clear();
                cmbThana.Enabled = true;
                cmbThana.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Thanas.Thana) from Thanas  Where Thanas.D_ID = '" + districtId +
                            "' order by Thanas.D_ID desc";
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
                string ctk = "SELECT  RTRIM(Thanas.T_ID)  from Thanas WHERE Thanas.Thana=@find and  Thanas.D_ID=@d2";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "Thana"));
                cmd.Parameters.Add(new SqlParameter("@d2", System.Data.SqlDbType.NVarChar, 50, "D_ID"));
                cmd.Parameters["@find"].Value = cmbThana.Text;
                cmd.Parameters["@d2"].Value = districtId;
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
                cmbPost.Items.Clear();
                cmbPost.Text = "";
                txtPostCode.Clear();
                cmbPost.Enabled = true;
                cmbPost.Focus();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(PostOffice.PostOfficeName) from PostOffice  Where PostOffice.T_ID = '" +
                            thanaId + "' order by PostOffice.T_ID desc";
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

        private void txtPContactNo_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void txtContactNo_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void txtCellNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;

            if (!string.IsNullOrEmpty(txtCellNumber.Text))
            {
                decimal sum = 0;
                decimal num;
                num = Convert.ToDecimal(txtCellNumber.Text);
                while (num > 0)
                {
                    sum = sum + (num / 10);
                    num = num / 10;
                }

                if (sum == 0)
                {
                    txtCellNumber.Clear();
                }
            }
        }

        private void cmbGender_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT GenderId from Gender WHERE GenderName= '" + cmbGender.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    genderId = rdr.GetInt32(0);
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



        private void CountryNamecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (CountryNamecomboBox.Text == "Bangladesh")
            {

                groupBox6.Hide();
                groupBox2.Show();
                groupBox3.Show();
                button1.Location = new Point(871, 570);
            }
            else
            {

                groupBox2.Hide();
                groupBox3.Hide();
                groupBox6.Show();
                groupBox6.Location = new Point(566, 18);
                button1.Location = new Point(780, 157);
            }

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Countries.CountryId),RTRIM(Countries.CountryCode) from Countries WHERE Countries.CountryName=@find";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "CountryName"));
                cmd.Parameters["@find"].Value = CountryNamecomboBox.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    countryid = (rdr.GetString(0));
                    CountryCodetextBox.Text = (rdr.GetString(1));
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

        private void CountryNamecomboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CountryCodetextBox.Focus();
                e.Handled = true;
            }
        }

        private void CountryCodetextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtShareHolderName.Focus();
                e.Handled = true;
            }
        }

        private void txtShareHolderName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCurrentShareHolding.Focus();
                e.Handled = true;
            }
        }

        private void txtCurrentShareHolding_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtFatherName.Focus();
                e.Handled = true;
            }
        }

        private void txtFatherName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMotherName.Focus();
                e.Handled = true;
            }
        }

        private void txtMotherName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDateOfBirth.Focus();
                e.Handled = true;
            }
        }

        private void txtDateOfBirth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtProfession.Focus();
                e.Handled = true;
            }
        }

        private void txtProfession_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCellNumber.Focus();
                e.Handled = true;
            }
        }

        private void txtCellNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNationalId.Focus();
                e.Handled = true;
            }
        }

        private void txtNationalId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBirthCertificateNo.Focus();
                e.Handled = true;
            }
        }

        private void txtBirthCertificateNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassportNo.Focus();
                e.Handled = true;
            }
        }

        private void txtPassportNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTINNumber.Focus();
                e.Handled = true;
            }
        }

        private void txtTINNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEmailAd.Focus();
                e.Handled = true;
            }
        }

        private void cmbEmailAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbGender.Focus();
                e.Handled = true;
            }
        }

        private void cmbGender_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPFlatName.Focus();
                e.Handled = true;
            }
        }

        private void txtPFlatName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPHouseName.Focus();
                e.Handled = true;
            }
        }

        private void txtPHouseName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPRoadNo.Focus();
                e.Handled = true;
            }
        }

        private void txtPRoadNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPBlock.Focus();
                e.Handled = true;
            }
        }

        private void txtPBlock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPArea.Focus();
                e.Handled = true;
            }
        }

        private void txtPArea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPContactNo.Focus();
                e.Handled = true;
            }
        }

        private void txtPContactNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbPDivision.Focus();
                e.Handled = true;
            }
        }

        private void cmbPDivision_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbPDistrict.Focus();
                e.Handled = true;
            }
        }

        private void cmbPDistrict_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbThana.Focus();
                e.Handled = true;
            }
        }

        private void cmbPThana_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbPPost.Focus();
                e.Handled = true;
            }
        }

        private void cmbPPost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPPostCode.Focus();
                e.Handled = true;
            }
        }

        private void txtPPostCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtFlatNo.Focus();
                e.Handled = true;
            }
        }

        private void txtFlatNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtHouseNo.Focus();
                e.Handled = true;
            }
        }

        private void txtHouseNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRoadNo.Focus();
                e.Handled = true;
            }
        }

        private void txtRoadNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBlock.Focus();
                e.Handled = true;
            }
        }

        private void txtBlock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtArea.Focus();
                e.Handled = true;
            }
        }

        private void txtArea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtContactNo.Focus();
                e.Handled = true;
            }
        }

        private void txtContactNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbDivision.Focus();
                e.Handled = true;
            }
        }

        private void cmbDivision_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbDistrict.Focus();
                e.Handled = true;
            }
        }

        private void cmbDistrict_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbThana.Focus();
                e.Handled = true;
            }
        }

        private void cmbThana_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbPost.Focus();
                e.Handled = true;
            }
        }

        private void cmbPost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPostCode.Focus();
                e.Handled = true;
            }
        }

        private void txtPostCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                StreettextBox.Focus();
                e.Handled = true;
            }
        }

        private void StreettextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                StatetextBox.Focus();
                e.Handled = true;
            }
        }

        private void StatetextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PostalCodetextBox.Focus();
                e.Handled = true;
            }
        }

        private void PostalCodetextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Focus();
                e.Handled = true;
            }
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }


        private void certificateStartComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //foreach (var x in certificateStartComboBox.Items)
            //{
            //    if (!CertificateEndComboBox.Items.Contains(x))
            //    {
            //        CertificateEndComboBox.Items.Add(x);
            //    }
            //}

            //if ( certificateStartComboBox.SelectedIndex != -1 && certificateStartComboBox.SelectedItem!=CertificateEndComboBox.SelectedItem && CertificateEndComboBox.Items.Contains(certificateStartComboBox.SelectedItem))
            //{
            //    CertificateEndComboBox.Items.Remove(certificateStartComboBox.SelectedItem);
            //}
            if (CertificateEndComboBox.SelectedIndex != -1 && certificateStartComboBox.SelectedIndex != -1)
            {
                if (Convert.ToUInt64(CertificateEndComboBox.Text) < Convert.ToUInt64(certificateStartComboBox.Text))
                {
                    MessageBox.Show(@"You Can not Select More Than Ending Cerificate");
                    certificateStartComboBox.SelectedIndex = -1;
                }
                else
                {
                    start = Convert.ToInt32(certificateStartComboBox.Text);
                    end = Convert.ToInt32(CertificateEndComboBox.Text);
                    shares.Clear();
                    for (int i = start; i <= end; i++)
                    {

                        shares.Add(i);
                    }

                    if (ValidateShares())
                    {

                        diff = end - start + 1;
                        txtCurrentShareHolding.Text = (diff * certificateRange).ToString();
                    }

                }
            }

        }

        private void CertificateEndComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CertificateEndComboBox.SelectedIndex != -1 && certificateStartComboBox.SelectedIndex != -1)
            {
                if (Convert.ToUInt64(CertificateEndComboBox.Text) < Convert.ToUInt64(certificateStartComboBox.Text))
                {
                    MessageBox.Show(@"You Can not Select Less Than Starting Cerificate");
                    CertificateEndComboBox.SelectedIndex = -1;
                }
                else
                {
                    start = Convert.ToInt32(certificateStartComboBox.Text);
                    end = Convert.ToInt32(CertificateEndComboBox.Text);
                    shares.Clear();
                    for (int i = start; i <= end; i++)
                    {

                        shares.Add(i);
                    }

                    if (ValidateShares())
                    {

                        diff = end - start + 1;
                        txtCurrentShareHolding.Text = (diff * certificateRange).ToString();
                    }


                }
            }
        }
        private bool ValidateShares()
        {
            bool validate = true;
            foreach (int certShare in shares)
            {
                if (!availableShares.Contains(certShare))
                {
                    validate = false;
                    MessageBox.Show(@"You Can Not Select Distinct Shares");
                    CertificateEndComboBox.SelectedIndex = -1;
                    certificateStartComboBox.SelectedIndex = -1;
                    break;
                }
            }
            return validate;
        }

        private void txtEmailAd_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtEmailAd.Text))
            {


                string emailId = txtEmailAd.Text.Trim();
                Regex mRegxExpression;
                mRegxExpression =
                    new Regex(
                        @"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");
                if (!mRegxExpression.IsMatch(emailId))
                {

                    MessageBox.Show("Please type a valid email Address.", "MojoCRM", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    txtEmailAd.Clear();
                    txtEmailAd.Focus();

                }
                else
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 = "select Email from EmailBank where Email='" + txtEmailAd.Text + "'";
                    cmd = new SqlCommand(ct2, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() && !rdr.IsDBNull(0))
                    {
                        MessageBox.Show("This Email  Already Exists, Please Enter New Email Address", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                        txtEmailAd.Clear();
                        txtEmailAd.Focus();
                    }
                    else
                    {
                        try
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string query1 = "insert into EmailBank (Email, UserId,DateAndTime) values (@d1,@d2,@d3)" +
                                            "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            cmd = new SqlCommand(query1, con);
                            cmd.Parameters.AddWithValue("@d1", txtEmailAd.Text);
                            cmd.Parameters.AddWithValue("@d2", nUserId);
                            cmd.Parameters.AddWithValue("@d3", DateTime.UtcNow.ToLocalTime());
                            bankEmailId = (int)cmd.ExecuteScalar();
                            con.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void txtEmailAd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbGender.Focus();
                e.Handled = true;
            }
        }

        private void txtNationalId_Leave(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = "select NationalId from Participant where NationalId='" + txtNationalId.Text + "'";
                cmd = new SqlCommand(ct2, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read() && !rdr.IsDBNull(0))
                {
                    MessageBox.Show(@"This National ID Already Exists, Please Enter Another One", @"Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                    txtNationalId.Clear();
                    txtNationalId.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPassportNo_Leave(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = "select PassportNumber from Participant where PassportNumber='" + txtPassportNo.Text + "'";
                cmd = new SqlCommand(ct2, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read() && !rdr.IsDBNull(0))
                {
                    MessageBox.Show(@"This Passport Number Already Exists, Please input Another One", @"Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                    txtPassportNo.Clear();
                    txtPassportNo.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
