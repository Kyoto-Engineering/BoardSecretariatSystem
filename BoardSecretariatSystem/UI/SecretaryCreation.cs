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
using System.Windows.Documents;
using System.Windows.Forms;
using BoardSecretariatSystem.DBGateway;

namespace BoardSecretariatSystem.UI
{

    public partial class SecretaryCreation : Form
    {
        SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();

        public string nUserId,
            divisionId,
            divisionIdP,
            districtId,
            districtIdP,
            thanaId,
            thanaIdP,
            postofficeId,
            postofficeIdP,
            memberTypeId,
            countryid;

        public int companyId,
            affectedRows1,
            affectedRows2,
            affectedRows3,
            currentPerticipantId,
            currentShareHolderId,
            bankEmailId,
            nationalityId,
            boardMemberId,
            availableIssuedShare,
            availableIssuedShare1,
            genderId;

        private bool companyCreated, secretaryExist;

        public SecretaryCreation()
        {
            InitializeComponent();
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
        private void NationalityLoad()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctt = "select Nationality from Nationalitys";
                cmd = new SqlCommand(ctt);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbNationality.Items.Add(rdr.GetValue(0).ToString());
                }
                cmbNationality.Items.Add("Not In The List");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    //countryid = rdr.GetInt32(0);

                }


                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void SecretaryCreation_Load(object sender, EventArgs e)
        {
            FillCountry();
            CountryNamecomboBox.SelectedItem = "Bangladesh";
            nUserId = frmLogin.uId.ToString();
            companyCreated = LoadCompany();
            GetGender();
            FillPresentDivisionCombo();
            FillPermanantDivisionCombo();
            NationalityLoad();
            secretaryExist = LoadSecretary();
            groupBox6.Hide();
            button1.Location = new Point(871, 570);
        }

        private bool LoadSecretary()
        {
            bool x = false;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string query = "SELECT  ParticipantId FROM Secretary WHERE DateOfResign IS NULL";
            cmd = new SqlCommand(query, con);
            rdr = cmd.ExecuteReader();
            if (rdr.Read() && !rdr.IsDBNull(0))
            {

                x = true;
            }
            return x;
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


        private void SecretaryCreation_FormClosed(object sender, FormClosedEventArgs e)
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

            txtFatherName.Clear();
            txtMotherName.Clear();

            txtCellNumber.Clear();

            cmbGender.SelectedIndex = -1;
            txtBirthCertificateNo.Clear();
            txtDateOfBirth.Value = DateTime.Today;

            txtPassportNo.Clear();
            txtTINNumber.Clear();
            txtNationalId.Clear();
            cmbNationality.SelectedIndex = -1;
            cmbEmailAddress.Clear();

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

            txtFatherName.Clear();
            txtMotherName.Clear();

            txtCellNumber.Clear();

            cmbGender.SelectedIndex = -1;
            txtBirthCertificateNo.Clear();
            txtDateOfBirth.Value = DateTime.Today;

            txtPassportNo.Clear();
            txtTINNumber.Clear();
            txtNationalId.Clear();
            cmbNationality.SelectedIndex = -1;
            cmbEmailAddress.Clear();
            ResetForeignAddress();
        }


        public void ResetForeignAddress()
        {
            StreettextBox.Clear();
            StatetextBox.Clear();
            PostalCodetextBox.Clear();
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

        private void SaveParticipant()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query1 = "insert into Participant(ParticipantName,MotherName,FatherName,DateOfBirth,BoardMemberTypeId,ContactNumber,NationalityId,NationalId,BirthCertificateNumber,PassportNumber,TIN,EmailBankId,CompanyId,GenderId,CountryId,UserId,DateTime) values (@d1,@d2,@d3,@d4,2,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                cmd = new SqlCommand(query1, con);
                cmd.Parameters.AddWithValue("@d1", txtShareHolderName.Text);
                cmd.Parameters.Add(new SqlParameter("@d2", string.IsNullOrEmpty(txtMotherName.Text) ? (object)DBNull.Value : txtMotherName.Text));
                cmd.Parameters.Add(new SqlParameter("@d3", string.IsNullOrEmpty(txtFatherName.Text) ? (object)DBNull.Value : txtFatherName.Text));
                cmd.Parameters.AddWithValue("@d4", Convert.ToDateTime(txtDateOfBirth.Value, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat));
                cmd.Parameters.Add(new SqlParameter("@d7", string.IsNullOrEmpty(txtCellNumber.Text) ? (object)DBNull.Value : txtCellNumber.Text));
                cmd.Parameters.Add(new SqlParameter("@d8", string.IsNullOrEmpty(nationalityId.ToString()) ? (object)DBNull.Value : nationalityId));
                cmd.Parameters.Add(new SqlParameter("@d9", string.IsNullOrEmpty(txtNationalId.Text) ? (object)DBNull.Value : txtNationalId.Text));
                cmd.Parameters.Add(new SqlParameter("@d10", string.IsNullOrEmpty(txtBirthCertificateNo.Text) ? (object)DBNull.Value : txtBirthCertificateNo.Text));
                cmd.Parameters.Add(new SqlParameter("@d11", string.IsNullOrEmpty(txtPassportNo.Text) ? (object)DBNull.Value : txtPassportNo.Text));
                cmd.Parameters.Add(new SqlParameter("@d12", string.IsNullOrEmpty(txtTINNumber.Text) ? (object)DBNull.Value : txtTINNumber.Text));
                cmd.Parameters.AddWithValue("@d13", bankEmailId);
                cmd.Parameters.AddWithValue("@d14", companyId);
                cmd.Parameters.AddWithValue("@d15", genderId);
                cmd.Parameters.AddWithValue("@d16", countryid);
                cmd.Parameters.AddWithValue("@d17", nUserId);
                cmd.Parameters.AddWithValue("@d18", DateTime.UtcNow.ToLocalTime());
                currentPerticipantId = (int)cmd.ExecuteScalar();
                con.Close();
                SaveSecretary();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CountryNamecomboBox.Text == "Bangladesh")
            {
                if (ValidateControlls())
                {

                    try
                    {


                        //1. Both Not Applicable
                        if (unKnownRA.Checked && unKnownCheckBox.Checked)
                        {
                            SaveParticipant();
                        }
                        //2.Present Address  Applicable & Permanant Address not  Applicable
                        if (unKnownRA.Checked == false & unKnownCheckBox.Checked)
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
                        if (sameAsRACheckBox.Checked & unKnownRA.Checked == false & unKnownCheckBox.Checked == false)
                        {
                            SaveParticipant();
                            SaveParticipantAddress("PPermanantAddresses");
                            PermanantSameAsPresent("PPresentAddresses");
                        }
                        //5.Present Address not  Applicable  & Permanant Address  Applicable
                        if (unKnownRA.Checked & sameAsRACheckBox.Checked == false & unKnownCheckBox.Checked == false)
                        {
                            SaveParticipant();
                            SaveParticipantAddress("PPermanantAddresses");
                        }
                        MessageBox.Show(@"Successfully Created", "Record", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        Reset();
                        CountryNamecomboBox.SelectedItem = "Bangladesh";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, @"error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                try
                {
                    //if (CountryNamecomboBox.Text != "Bangladesh")
                    //{
                        if (ValidateControlls2())
                        {
                            if (string.IsNullOrWhiteSpace(StreettextBox.Text) &&
                                string.IsNullOrWhiteSpace(StatetextBox.Text) &&
                                string.IsNullOrWhiteSpace(PostalCodetextBox.Text))
                            {
                                MessageBox.Show("Please enter Addresses!", "Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                                return;

                            }
                        //}
                        else
                        {
                            
                       
                        SaveParticipant();
                        ForeignAddresses("ForeignAddress");
                        MessageBox.Show("Saved successfully", "Record", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        Reset2();
                        CountryNamecomboBox.SelectedItem = "Bangladesh";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidateParticipant()
        {
            List<Participant> participants = new List<Participant>();

            con = new SqlConnection(cs.DBConn);
            con.Open();
            string ct3 =
                "SELECT Participant.ParticipantName, Participant.MotherName, Participant.FatherName, Participant.DateOfBirth, EmailBank.Email FROM Participant INNER JOIN EmailBank ON Participant.EmailBankId = EmailBank.EmailBankId where  Participant.ParticipantName='" +
                txtShareHolderName.Text + "'";
            cmd = new SqlCommand(ct3, con);
            rdr = cmd.ExecuteReader();
            if (rdr.Read() && !rdr.IsDBNull(0))
            {
                while (rdr.Read())
                {
                    Participant x = new Participant();
                    x.Name = rdr.GetString(0);
                    x.MotherName = rdr.GetString(1);
                    x.FatherName = rdr.GetString(2);
                    x.DateofBirth = rdr.GetDateTime(3);
                    x.Email = rdr.GetString(4);
                    participants.Add(x);
                }
            }
            foreach (Participant p in participants)
            {
                if (p.Name == txtShareHolderName.Text && p.Email == cmbEmailAddress.Text)
                {
                    MessageBox.Show(@"This Person Exists,Please Input another one" + "\n" + @"Or Use another Email", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                    return true;
                }
            }
            return false;
        }

        private bool ValidateControlls2()
        {
            bool validate = true;

            if (!companyCreated)
            {
                MessageBox.Show(@"Company is not created Yet" + "\n" + @"Please Create Company First", @"Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                validate = false;
            }
            else if (secretaryExist)
            {
                MessageBox.Show(@"Already One Secretary Exist" + "\n" + @"Retire The Existing  One then Create New Secretary", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                validate = false;
            }
            else if (string.IsNullOrEmpty(txtShareHolderName.Text))
            {
                MessageBox.Show(@"Please enter Secretary  name", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                validate = false;
                txtShareHolderName.Focus();
            }
            else if (string.IsNullOrEmpty(txtFatherName.Text))
            {
                MessageBox.Show(@"Please enter Secretary's Father Name", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                validate = false;
                txtFatherName.Focus();
            }
            else if (string.IsNullOrEmpty(txtMotherName.Text))
            {
                MessageBox.Show(@"Please enter Secretary's Mother Name", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                validate = false;
                txtMotherName.Focus();
            }
            else if (cmbGender.SelectedIndex == -1)
            {
                MessageBox.Show(@"Select Gender", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                validate = false;
                cmbGender.Focus();
            }
            return validate;
        }


        private bool ValidateControlls()
        {
            bool validate = true;

            if (!companyCreated)
            {
                MessageBox.Show(@"Company is not created Yet" + "\n" + @"Please Create Company First", @"Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                validate = false;
            }
            else if (secretaryExist)
            {
                MessageBox.Show(@"Already One Secretary Exist" + "\n" + @"Retire The Existing  One then Create New Secretary", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                validate = false;
            }
            else if (string.IsNullOrEmpty(txtShareHolderName.Text))
            {
                MessageBox.Show(@"Please enter Secretary  name", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                validate = false;
                txtShareHolderName.Focus();
            }
            else if (string.IsNullOrEmpty(txtFatherName.Text))
            {
                MessageBox.Show(@"Please enter Secretary's Father Name", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                validate = false;
                txtFatherName.Focus();
            }
            else if (string.IsNullOrEmpty(txtMotherName.Text))
            {
                MessageBox.Show(@"Please enter Secretary's Mother Name", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                validate = false;
                txtMotherName.Focus();
            }
            else if (cmbGender.SelectedIndex == -1)
            {
                MessageBox.Show(@"Select Gender", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                validate = false;
                cmbGender.Focus();
            }

            else if (!unKnownRA.Checked && string.IsNullOrWhiteSpace(cmbPDivision.Text))
            {
                MessageBox.Show(@"Please select Present Address division", @"Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                validate = false;
            }
            else if (!unKnownRA.Checked && string.IsNullOrWhiteSpace(cmbPDistrict.Text))
            {
                MessageBox.Show(@"Please Select Present Address district", @"Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                validate = false;
            }
            else if (!unKnownRA.Checked && string.IsNullOrWhiteSpace(cmbPThana.Text))
            {
                MessageBox.Show(@"Please select Present Address Thana", @"Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                validate = false;
            }
            else if (!unKnownRA.Checked && string.IsNullOrWhiteSpace(cmbPPost.Text))
            {
                MessageBox.Show(@"Please Select Present Address Post Name", @"Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                validate = false;
            }
            else if (!unKnownRA.Checked && string.IsNullOrWhiteSpace(txtPPostCode.Text))
            {
                MessageBox.Show(@"Please select Present Address Post Code", @"Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                validate = false;
            }

            else if (!unKnownCheckBox.Checked && !sameAsRACheckBox.Checked && string.IsNullOrWhiteSpace(cmbDivision.Text))
            {
                MessageBox.Show(@"Please select Permanent Address division", @"Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                validate = false;
            }
            else if (!unKnownCheckBox.Checked && !sameAsRACheckBox.Checked && string.IsNullOrWhiteSpace(cmbDistrict.Text))
            {
                MessageBox.Show(@"Please Select Permanent Address district", @"Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                validate = false;
            }
            else if (!unKnownCheckBox.Checked && !sameAsRACheckBox.Checked && string.IsNullOrWhiteSpace(cmbThana.Text))
            {
                MessageBox.Show(@"Please select Permanent Address Thana", @"Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                validate = false;
            }
            else if (!unKnownCheckBox.Checked && !sameAsRACheckBox.Checked && string.IsNullOrWhiteSpace(cmbPost.Text))
            {
                MessageBox.Show(@"Please Select Permanent Address Post Name", @"Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                validate = false;
            }
            else if (!unKnownCheckBox.Checked && !sameAsRACheckBox.Checked && string.IsNullOrWhiteSpace(txtPostCode.Text))
            {
                MessageBox.Show(@"Please select Permanent Address Post Code", @"Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                validate = false;
            }
            else if (!Email())
            {
                validate = false;
            }
            else if (ValidateParticipant())
            {
                validate = false;
            }

            return validate;
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

        //private void cmbEmailAddress_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Email();
        //}

        private bool Email()
        {
            bool validate = true;
            if (string.IsNullOrWhiteSpace(cmbEmailAddress.Text))
            {
                MessageBox.Show(@"You Must Give the Email Address", @"Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
                validate = false;
            }
            else
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct2 = "select Email from EmailBank where Email='" + cmbEmailAddress.Text + "'";
                cmd = new SqlCommand(ct2, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read() && !rdr.IsDBNull(0))
                {
                    MessageBox.Show(@"This Email  Already Exists" + "\n" + @"You Can Not Use same email again", @"Sorry",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                    validate = false;
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
                        cmd.Parameters.AddWithValue("@d1", cmbEmailAddress.Text);
                        cmd.Parameters.AddWithValue("@d2", nUserId);
                        cmd.Parameters.AddWithValue("@d3", DateTime.UtcNow.ToLocalTime());
                        bankEmailId = (int)cmd.ExecuteScalar();
                        con.Close();

                        validate = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, @"error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        validate = false;
                    }
                }
            }

            return validate;
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
                MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }


        private void cmbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGender.SelectedIndex == -1)
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
                    MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void cmbNationality_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNationality.Text == "Not In The List")
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Please Input Nationality Here", "Input Here", "", -1, -1);
                if (string.IsNullOrWhiteSpace(input))
                {
                    cmbNationality.SelectedIndex = -1;
                }

                else
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 = "select Nationality from Nationalitys where Nationality='" + input + "'";
                    cmd = new SqlCommand(ct2, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() && !rdr.IsDBNull(0))
                    {
                        MessageBox.Show("This Nationality  Already Exists,Please Select From List", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                        cmbNationality.SelectedIndex = -1;
                    }
                    else
                    {
                        try
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string query1 = "insert into Nationalitys(Nationality) values (@d1)";
                            cmd = new SqlCommand(query1, con);
                            cmd.Parameters.AddWithValue("@d1", input);
                            cmd.ExecuteNonQuery();
                            con.Close();
                            cmbNationality.Items.Clear();
                            NationalityLoad();
                            cmbNationality.SelectedText = input;
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
                    cmd.CommandText = "SELECT NationalityId from Nationalitys WHERE Nationality= '" + cmbNationality.Text + "'";

                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        nationalityId = rdr.GetInt32(0);
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

        private void cmbEmailAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void SaveSecretary()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query1 = "INSERT INTO Secretary (ParticipantId, DateOfJoin) VALUES (@d1,@d2)";
                cmd = new SqlCommand(query1, con);
                cmd.Parameters.AddWithValue("@d1", currentPerticipantId);
                cmd.Parameters.AddWithValue("@d2", joinDateTimePicker.Value.ToUniversalTime().ToLocalTime());

                cmd.ExecuteScalar();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbEmailAddress_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cmbEmailAddress.Text))
            {


                string emailId = cmbEmailAddress.Text.Trim();
                Regex mRegxExpression;
                mRegxExpression =
                    new Regex(
                        @"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");
                if (!mRegxExpression.IsMatch(emailId))
                {

                    MessageBox.Show("Please type a valid email Address.", "MojoCRM", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    cmbEmailAddress.Clear();
                    cmbEmailAddress.Focus();

                }
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
