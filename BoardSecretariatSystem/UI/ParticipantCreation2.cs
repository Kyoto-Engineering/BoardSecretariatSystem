﻿using System;
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
    public partial class ParticipantCreation2 : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        public int nationalityId;
        public int affectedRows1,
            affectedRows2,
            affectedRows3,
            currentPerticipantId,
            currentShareHolderId,
            bankEmailId,
            boardMemberId,
            companyId = 1,
            genderId;

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



        public ParticipantCreation2()
        {
            InitializeComponent();
        }

        private void Reset()
        {
            CountryNamecomboBox.SelectedIndex = -1;
            CountryCodetextBox.Clear();
            txtParticipantName.Clear();
            txtFatherName.Clear();
            txtMotherName.Clear();
            txtDesignation.Clear();
            txtCellNumber.Clear();
            cmbGender.SelectedIndex = -1;
            txtBirthCertificateNo.Clear();
            txtDateOfBirth.Value = DateTime.Today;
            txtPassportNo.Clear();
            txtTINNumber.Clear();
            txtNationalId.Clear();
            cmbEmailAddress.SelectedIndex = -1;
            cmbParticipantType.SelectedIndex = -1;

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
            txtParticipantName.Clear();
            txtFatherName.Clear();
            txtMotherName.Clear();
            txtDesignation.Clear();
            txtCellNumber.Clear();
            cmbGender.SelectedIndex = -1;
            txtBirthCertificateNo.Clear();
            txtDateOfBirth.Value = DateTime.Today;
            txtPassportNo.Clear();
            txtTINNumber.Clear();
            txtNationalId.Clear();
            cmbEmailAddress.SelectedIndex = -1;
            cmbParticipantType.SelectedIndex = -1;
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
                string query1 = "insert into Participant(ParticipantName,MotherName,FatherName,DateOfBirth,Designation,ContactNumber,NationalId,BirthCertificateNumber,PassportNumber,TIN,EmailBankId,CompanyId,GenderId,CountryId,UserId,DateTime) values (@d1,@d2,@d3,@d4,@d5,@d7,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                cmd = new SqlCommand(query1, con);
                cmd.Parameters.AddWithValue("@d1", txtParticipantName.Text);
                cmd.Parameters.Add(new SqlParameter("@d2",string.IsNullOrEmpty(txtMotherName.Text) ? (object) DBNull.Value : txtMotherName.Text));
                cmd.Parameters.Add(new SqlParameter("@d3",string.IsNullOrEmpty(txtFatherName.Text) ? (object) DBNull.Value : txtFatherName.Text));
                cmd.Parameters.AddWithValue("@d4", Convert.ToDateTime(txtDateOfBirth.Value, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat));
                cmd.Parameters.Add(new SqlParameter("@d5",string.IsNullOrEmpty(txtDesignation.Text) ? (object) DBNull.Value : txtDesignation.Text));
                cmd.Parameters.Add(new SqlParameter("@d6",string.IsNullOrEmpty(boardMemberId.ToString()) ? (object) DBNull.Value : boardMemberId.ToString()));
                cmd.Parameters.Add(new SqlParameter("@d7",string.IsNullOrEmpty(txtCellNumber.Text) ? (object) DBNull.Value : txtCellNumber.Text));
                cmd.Parameters.Add(new SqlParameter("@d9",string.IsNullOrEmpty(txtNationalId.Text) ? (object) DBNull.Value : txtNationalId.Text));
                cmd.Parameters.Add(new SqlParameter("@d10",string.IsNullOrEmpty(txtBirthCertificateNo.Text)?(object) DBNull.Value : txtBirthCertificateNo.Text));
                cmd.Parameters.Add(new SqlParameter("@d11",string.IsNullOrEmpty(txtPassportNo.Text) ? (object) DBNull.Value : txtPassportNo.Text));
                cmd.Parameters.Add(new SqlParameter("@d12",string.IsNullOrEmpty(txtTINNumber.Text) ? (object) DBNull.Value : txtTINNumber.Text));
                cmd.Parameters.AddWithValue("@d13", bankEmailId);
                cmd.Parameters.AddWithValue("@d14", companyId);
                cmd.Parameters.AddWithValue("@d15", genderId);
                cmd.Parameters.AddWithValue("@d16", countryid);
                cmd.Parameters.AddWithValue("@d17", nUserId);
                cmd.Parameters.AddWithValue("@d18", DateTime.UtcNow.ToLocalTime());
                currentPerticipantId = (int) cmd.ExecuteScalar();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveParticipantAddress(string tblName1)
        {
            string tableName = tblName1;

            if (tableName == "PPresentAddresses")
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string insertQ = "insert into " + tableName + "(PostOfficeId,PFlatNo,PHouseNo,PRoadNo,PBlock,PArea,PContactNo,ParticipantId) Values(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                cmd = new SqlCommand(insertQ, con);
                cmd.Parameters.Add(new SqlParameter("@d1",string.IsNullOrEmpty(postofficeIdP) ? (object) DBNull.Value : postofficeIdP));
                cmd.Parameters.Add(new SqlParameter("@d2", string.IsNullOrEmpty(txtPFlatName.Text) ? (object) DBNull.Value : txtPFlatName.Text));
                cmd.Parameters.Add(new SqlParameter("@d3", string.IsNullOrEmpty(txtPHouseName.Text) ? (object) DBNull.Value : txtPHouseName.Text));
                cmd.Parameters.Add(new SqlParameter("@d4", string.IsNullOrEmpty(txtPRoadNo.Text) ? (object) DBNull.Value : txtPRoadNo.Text));
                cmd.Parameters.Add(new SqlParameter("@d5", string.IsNullOrEmpty(txtPBlock.Text) ? (object) DBNull.Value : txtPBlock.Text));
                cmd.Parameters.Add(new SqlParameter("@d6", string.IsNullOrEmpty(txtPArea.Text) ? (object) DBNull.Value : txtPArea.Text));
                cmd.Parameters.Add(new SqlParameter("@d7",string.IsNullOrEmpty(txtPContactNo.Text) ? (object) DBNull.Value : txtPContactNo.Text));
                cmd.Parameters.AddWithValue("@d8", currentPerticipantId);
                affectedRows1 = (int) cmd.ExecuteScalar();
                con.Close();
            }
            else if (tableName == "PPermanantAddresses")
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string insertQ = "insert into " + tableName + "(PostOfficeId,FlatNo,HouseNo,RoadNo,Block,Area,ContactNo,ParticipantId) Values(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)" +"SELECT CONVERT(int, SCOPE_IDENTITY())";
                cmd = new SqlCommand(insertQ, con);
                cmd.Parameters.Add(new SqlParameter("@d1", string.IsNullOrEmpty(postofficeId) ? (object) DBNull.Value : postofficeId));
                cmd.Parameters.Add(new SqlParameter("@d2",string.IsNullOrEmpty(txtFlatNo.Text) ? (object) DBNull.Value : txtFlatNo.Text));
                cmd.Parameters.Add(new SqlParameter("@d3", string.IsNullOrEmpty(txtHouseNo.Text) ? (object) DBNull.Value : txtHouseNo.Text));
                cmd.Parameters.Add(new SqlParameter("@d4", string.IsNullOrEmpty(txtRoadNo.Text) ? (object) DBNull.Value : txtRoadNo.Text));
                cmd.Parameters.Add(new SqlParameter("@d5", string.IsNullOrEmpty(txtBlock.Text) ? (object) DBNull.Value : txtBlock.Text));
                cmd.Parameters.Add(new SqlParameter("@d6", string.IsNullOrEmpty(txtArea.Text) ? (object) DBNull.Value : txtArea.Text));
                cmd.Parameters.Add(new SqlParameter("@d7",string.IsNullOrEmpty(txtContactNo.Text) ? (object) DBNull.Value : txtContactNo.Text));
                cmd.Parameters.AddWithValue("@d8", currentPerticipantId);
                affectedRows1 = (int) cmd.ExecuteScalar();
                con.Close();
            }
        }

        private void PermanantSameAsPresent(string tblName1)
        {
            string tableName = tblName1;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string Qry = "insert into " + tableName + "(PostOfficeId,PFlatNo,PHouseNo,PRoadNo,PBlock,PArea,PContactNo,ParticipantId) Values(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
            cmd = new SqlCommand(Qry, con);
            cmd.Parameters.Add(new SqlParameter("@d1",string.IsNullOrEmpty(postofficeIdP) ? (object) DBNull.Value : postofficeIdP));
            cmd.Parameters.Add(new SqlParameter("@d2", string.IsNullOrEmpty(txtPFlatName.Text) ? (object) DBNull.Value : txtPFlatName.Text));
            cmd.Parameters.Add(new SqlParameter("@d3",string.IsNullOrEmpty(txtPHouseName.Text) ? (object) DBNull.Value : txtPHouseName.Text));
            cmd.Parameters.Add(new SqlParameter("@d4",string.IsNullOrEmpty(txtPRoadNo.Text) ? (object) DBNull.Value : txtPRoadNo.Text));
            cmd.Parameters.Add(new SqlParameter("@d5", string.IsNullOrEmpty(txtPBlock.Text) ? (object) DBNull.Value : txtPBlock.Text));
            cmd.Parameters.Add(new SqlParameter("@d6", string.IsNullOrEmpty(txtPArea.Text) ? (object) DBNull.Value : txtPArea.Text));
            cmd.Parameters.Add(new SqlParameter("@d7", string.IsNullOrEmpty(txtPContactNo.Text) ? (object) DBNull.Value : txtPContactNo.Text));
            cmd.Parameters.AddWithValue("@d8", currentPerticipantId);
            affectedRows2 = (int) cmd.ExecuteScalar();
            con.Close();
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


        private void button1_Click(object sender, EventArgs e)
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

        

        private void EmailAddress()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctt = "select Email from EmailBank";
                cmd = new SqlCommand(ctt);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbEmailAddress.Items.Add(rdr.GetValue(0).ToString());
                }
                cmbEmailAddress.Items.Add("Not In The List");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetParticipantType()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                //string ctt = "select BoardMemberType from BoardMemberTypes";
                string ctt = "SELECT BoardMemberType FROM BoardMemberTypes where BoardMemberTypeId<>1 and BoardMemberTypeId<>4";
                cmd = new SqlCommand(ctt);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbParticipantType.Items.Add(rdr.GetValue(0).ToString());
                }
                cmbParticipantType.Items.Add("Not In The List");
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
                cmbGender.Items.Add("Not In The List");
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

        private void ParticipantCreation2_Load(object sender, EventArgs e)
        {
            FillCountry();
            CountryNamecomboBox.SelectedItem = "Bangladesh";
            nUserId = frmLogin.uId.ToString();
            GetParticipantType();
            FillPermanantDivisionCombo();
            FillPresentDivisionCombo();
            GetGender();
            EmailAddress();
            groupBox6.Hide();
            addButton.Location = new Point(871, 570);
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
                string ct = "select RTRIM(Districts.District) from Districts  Where Districts.Division_ID = '" +divisionIdP + "' order by Districts.Division_ID desc";
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
                string ct = "select RTRIM(Thanas.Thana) from Thanas  Where Thanas.D_ID = '" + districtIdP +"' order by Thanas.D_ID desc";
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
                string ct = "select RTRIM(PostOffice.PostOfficeName) from PostOffice  Where PostOffice.T_ID = '" + thanaIdP + "' order by PostOffice.T_ID desc";
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
                string ctk = "SELECT  RTRIM(PostOffice.PostOfficeId),RTRIM(PostOffice.PostCode) from PostOffice WHERE PostOffice.PostOfficeName=@find";
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
                cmbThana.Items.Clear();
                cmbThana.Text = "";
                cmbPost.SelectedIndex = -1;
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
                string ct = "select RTRIM(PostOffice.PostOfficeName) from PostOffice  Where PostOffice.T_ID = '" +thanaId + "' order by PostOffice.T_ID desc";
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

        private void cmbEmailAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEmailAddress.Text == "Not In The List")
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Please Input Email Id Here", "Input Here", "",
                    -1, -1);
                if (string.IsNullOrWhiteSpace(input))
                {
                    cmbEmailAddress.SelectedIndex = -1;
                }

                else
                {
                    if (!string.IsNullOrWhiteSpace(input))
                    {
                        string emailId = input.Trim();
                        Regex mRegxExpression;
                        mRegxExpression =
                            new Regex(
                                @"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");
                        if (!mRegxExpression.IsMatch(emailId))
                        {
                            MessageBox.Show("Please type a valid email Address.", "MojoCRM", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }
                    }
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 = "select Email from EmailBank where Email='" + input + "'";
                    cmd = new SqlCommand(ct2, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() && !rdr.IsDBNull(0))
                    {
                        MessageBox.Show("This Email  Already Exists,Please Select From List", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                        cmbEmailAddress.SelectedIndex = -1;
                    }
                    else
                    {
                        try
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string query1 = "insert into  EmailBank(Email, UserId,DateAndTime) values (@d1,@d2,@d3)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            cmd = new SqlCommand(query1, con);
                            cmd.Parameters.AddWithValue("@d1", input);
                            cmd.Parameters.AddWithValue("@d2", nUserId);
                            cmd.Parameters.AddWithValue("@d3", DateTime.UtcNow.ToLocalTime());
                            cmd.ExecuteNonQuery();
                            con.Close();
                            cmbEmailAddress.Items.Clear();
                            EmailAddress();
                            cmbEmailAddress.SelectedText = input;
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
                    cmd.CommandText = "SELECT EmailBankId from EmailBank WHERE Email= '" + cmbEmailAddress.Text + "'";

                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        bankEmailId = rdr.GetInt32(0);
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

        private void cmbParticipantType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT BoardMemberTypeId from BoardMemberTypes WHERE BoardMemberTypes.BoardMemberType= '" + cmbParticipantType.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    boardMemberId = rdr.GetInt32(0);
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

        private void ParticipantCreation2_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void txtPContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char) Keys.Back)))
                e.Handled = true;
        }

        private void txtContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char) Keys.Back)))
                e.Handled = true;
        }

        private void addButton_Click(object sender, EventArgs e)
        { 
            if (string.IsNullOrEmpty(txtParticipantName.Text))
            {
                MessageBox.Show("Please enter Participant  name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (unKnownRA.Checked == false)
            {
                if (string.IsNullOrWhiteSpace(cmbPDivision.Text))
                {
                    MessageBox.Show("Please select Present Address division", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(cmbPDistrict.Text))
                {
                    MessageBox.Show("Please Select Present Address district", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(cmbPThana.Text))
                {
                    MessageBox.Show("Please select Present Address Thana", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(cmbPPost.Text))
                {
                    MessageBox.Show("Please Select Present Address Post Name", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtPPostCode.Text))
                {
                    MessageBox.Show("Please select Present Address Post Code", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }
            if (unKnownCheckBox.Checked == false && sameAsRACheckBox.Checked == false)
            {
                if (string.IsNullOrWhiteSpace(cmbDivision.Text))
                {
                    MessageBox.Show("Please select Permanant Address division", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(cmbDistrict.Text))
                {
                    MessageBox.Show("Please Select Permanant Address district", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(cmbThana.Text))
                {
                    MessageBox.Show("Please select Permanant Address Thana", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(cmbPost.Text))
                {
                    MessageBox.Show("Please Select Permanant Address Post Name", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtPostCode.Text))
                {
                    MessageBox.Show("Please select Permanant Address Post Code", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct3 =
                    "select Participant.ParticipantName from Participant where  Participant.ParticipantName='" +
                    txtParticipantName.Text + "'";
                cmd = new SqlCommand(ct3, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read() && !rdr.IsDBNull(0))
                {
                    MessageBox.Show("This Share Holder Already Exists,Please Input another one", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                con.Close();
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

                MessageBox.Show("Successfully Created", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
                CountryNamecomboBox.SelectedItem = "Bangladesh";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtCellNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char) Keys.Back)))
                e.Handled = true;
        }

        private void txtPContactNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGender.Text == "Not In The List")
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Please Input Gender Here", "Input Here", "", -1, -1);
                if (string.IsNullOrWhiteSpace(input))
                {
                    cmbGender.SelectedIndex = -1;
                }

                else
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 = "select GenderName from Gender where GenderName='" + input + "'";
                    cmd = new SqlCommand(ct2, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() && !rdr.IsDBNull(0))
                    {
                        MessageBox.Show("This Gender  Already Exists,Please Select From List", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                        cmbGender.SelectedIndex = -1;
                    }
                    else
                    {
                        try
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string query1 = "insert into  Gender(GenderName) values (@d1)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            cmd = new SqlCommand(query1, con);
                            cmd.Parameters.AddWithValue("@d1", input);
                            cmd.ExecuteNonQuery();
                            con.Close();
                            cmbGender.Items.Clear();
                            GetGender();
                            cmbGender.SelectedText = input;
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
        }


        private void CountryNamecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CountryNamecomboBox.Text == "Bangladesh")
            {

                groupBox6.Hide();
                groupBox2.Show();
                groupBox3.Show();
                addButton.Location = new Point(871, 570);
            }
            else
            {

                groupBox2.Hide();
                groupBox3.Hide();
                groupBox6.Show();
                groupBox6.Location = new Point(566, 18);
                addButton.Location = new Point(780, 157);
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

        private void addButton_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtParticipantName.Text))
            {
                MessageBox.Show("Please enter Participant  name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(cmbParticipantType.Text))
            {
                MessageBox.Show("Please enter Participant  Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CountryNamecomboBox.Text == "Bangladesh")
            {
                if (unKnownRA.Checked == false)
                {
                    if (string.IsNullOrWhiteSpace(cmbPDivision.Text))
                    {
                        MessageBox.Show("Please select Present Address division", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(cmbPDistrict.Text))
                    {
                        MessageBox.Show("Please Select Present Address district", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(cmbPThana.Text))
                    {
                        MessageBox.Show("Please select Present Address Thana", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(cmbPPost.Text))
                    {
                        MessageBox.Show("Please Select Present Address Post Name", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(txtPPostCode.Text))
                    {
                        MessageBox.Show("Please select Present Address Post Code", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                }
                if (unKnownCheckBox.Checked == false && sameAsRACheckBox.Checked == false)
                {
                    if (string.IsNullOrWhiteSpace(cmbDivision.Text))
                    {
                        MessageBox.Show("Please select Permanant Address division", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(cmbDistrict.Text))
                    {
                        MessageBox.Show("Please Select Permanant Address district", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(cmbThana.Text))
                    {
                        MessageBox.Show("Please select Permanant Address Thana", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(cmbPost.Text))
                    {
                        MessageBox.Show("Please Select Permanant Address Post Name", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(txtPostCode.Text))
                    {
                        MessageBox.Show("Please select Permanant Address Post Code", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                }

                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct3 =
                        "select Participant.ParticipantName from Participant where  Participant.ParticipantName='" +
                        txtParticipantName.Text + "'";
                    cmd = new SqlCommand(ct3, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() && !rdr.IsDBNull(0))
                    {
                        MessageBox.Show("This Share Holder Already Exists,Please Input another one", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }
                    con.Close();
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

                    MessageBox.Show("Successfully Created", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    if (CountryNamecomboBox.Text != "Bangladesh")
                    {
                        if (string.IsNullOrWhiteSpace(StreettextBox.Text) &&
                            string.IsNullOrWhiteSpace(StatetextBox.Text) &&
                            string.IsNullOrWhiteSpace(PostalCodetextBox.Text))
                        {
                            MessageBox.Show("Please enter Addresses!", "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;

                        }
                    }

                    SaveParticipant();
                    ForeignAddresses("ForeignAddress");
                    MessageBox.Show("Successfully Created", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset2();
                    CountryNamecomboBox.SelectedItem = "Bangladesh";

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                txtParticipantName.Focus();
                e.Handled = true;
            }
        }

        private void txtParticipantName_KeyDown(object sender, KeyEventArgs e)
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
                txtDesignation.Focus();
                e.Handled = true;
            }
        }

        private void txtDesignation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbParticipantType.Focus();
                e.Handled = true;
            }
        }

        private void cmbParticipantType_KeyDown(object sender, KeyEventArgs e)
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

        private void cmbNationality_KeyDown(object sender, KeyEventArgs e)
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
                cmbEmailAddress.Focus();
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
                cmbPThana.Focus();
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
                addButton.Focus();
                e.Handled = true;
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
                    cmbEmailAddress.SelectedIndex = -1;
                    cmbEmailAddress.ResetText();
                    cmbEmailAddress.Focus();

                }
            }
        }
    }
}
