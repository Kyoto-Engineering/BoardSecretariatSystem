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

namespace BoardSecretariatSystem.UI
{
    
    public partial class ParticipantCreation : Form
    {
        SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public string companyId , nUserId, divisionId, divisionIdP, districtId, districtIdP, thanaId, thanaIdP, postofficeId, postofficeIdP;
        public int affectedRows1, affectedRows2, affectedRows3, currentPerticipantId, boardId, bankEmailId;
        public ParticipantCreation()
        {
            InitializeComponent();
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
                while (rdr.Read())
                {
                    companyNameComboBox.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void ParticipantCreation_Load(object sender, EventArgs e)
        {
            nUserId = frmLogin.uId.ToString();
            CompanyNameLoad();
            EmailAddress();
            FillPresentDivisionCombo();
            FillPermanantDivisionCombo();
        }

        private void companyNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Company.CompanyId)  from  Company  WHERE Company.CompanyName=@find";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "Company"));
                cmd.Parameters["@find"].Value = companyNameComboBox.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    companyId = (rdr.GetString(0));

                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                companyNameComboBox.Text = companyNameComboBox.Text.Trim();
                boardNameComboBox.Items.Clear();
                boardNameComboBox.SelectedIndex = -1;
                boardNameComboBox.Enabled = true;
                boardNameComboBox.Focus();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select RTRIM(Board.BoardName) from Board  Where Board.CompanyId = '" + companyId + "' order by Board.BoardId desc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    boardNameComboBox.Items.Add(rdr[0]);
                }
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ParticipantCreation_FormClosed(object sender, FormClosedEventArgs e)
        {
               this.Hide();
           MainUI frm=new MainUI();
                frm.Show();
        }
        private void PermanantSameAsPresent(string tblName1)
        {
            string tableName = tblName1;
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string Qry = "insert into " + tableName + "(PostOfficeId,FlatNo,HouseNo,RoadNo,Block,Area,ContactNo,ParticipantId) Values(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)" + "SELECT CONVERT(int, SCOPE_IDENTITY())"; 
            cmd = new SqlCommand(Qry,con);            
            cmd.Parameters.Add(new SqlParameter("@d1", string.IsNullOrEmpty(postofficeIdP) ? (object)DBNull.Value : postofficeIdP));
            cmd.Parameters.Add(new SqlParameter("@d2", string.IsNullOrEmpty(txtPFlatName.Text) ? (object)DBNull.Value : txtPFlatName.Text));
            cmd.Parameters.Add(new SqlParameter("@d3", string.IsNullOrEmpty(txtPHouseName.Text) ? (object)DBNull.Value : txtPHouseName.Text));
            cmd.Parameters.Add(new SqlParameter("@d4", string.IsNullOrEmpty(txtPRoadNo.Text) ? (object)DBNull.Value : txtPRoadNo.Text));
            cmd.Parameters.Add(new SqlParameter("@d5", string.IsNullOrEmpty(txtPBlock.Text) ? (object)DBNull.Value : txtPBlock.Text));
            cmd.Parameters.Add(new SqlParameter("@d6", string.IsNullOrEmpty(txtPArea.Text) ? (object)DBNull.Value : txtPArea.Text));
            cmd.Parameters.Add(new SqlParameter("@d7", string.IsNullOrEmpty(txtPContactNo.Text) ? (object)DBNull.Value : txtPContactNo.Text));
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
                string insertQ = "insert into " + tableName + "(PostOfficeId,PFlatNo,PHouseNo,PRoadNo,PBlock,PArea,PContactNo,ParticipantId) Values(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                cmd = new SqlCommand(insertQ,con);             
                cmd.Parameters.Add(new SqlParameter("@d1", string.IsNullOrEmpty(postofficeIdP) ? (object)DBNull.Value : postofficeIdP));
                cmd.Parameters.Add(new SqlParameter("@d2", string.IsNullOrEmpty(txtPFlatName.Text) ? (object)DBNull.Value : txtPFlatName.Text));
                cmd.Parameters.Add(new SqlParameter("@d3", string.IsNullOrEmpty(txtPHouseName.Text) ? (object)DBNull.Value : txtPHouseName.Text));
                cmd.Parameters.Add(new SqlParameter("@d4", string.IsNullOrEmpty(txtPRoadNo.Text) ? (object)DBNull.Value : txtPRoadNo.Text));
                cmd.Parameters.Add(new SqlParameter("@d5", string.IsNullOrEmpty(txtPBlock.Text) ? (object)DBNull.Value : txtPBlock.Text));
                cmd.Parameters.Add(new SqlParameter("@d6", string.IsNullOrEmpty(txtPArea.Text) ? (object)DBNull.Value : txtPArea.Text));
                cmd.Parameters.Add(new SqlParameter("@d7", string.IsNullOrEmpty(txtPContactNo.Text) ? (object)DBNull.Value : txtPContactNo.Text));
                cmd.Parameters.AddWithValue("@d8", currentPerticipantId);               
                affectedRows1 = (int)cmd.ExecuteScalar();
                con.Close();
            }
            else if (tableName == "PPermanantAddresses")
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string insertQ = "insert into " + tableName + "(PostOfficeId,FlatNo,HouseNo,RoadNo,Block,Area,ContactNo,ParticipantId) Values(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";                
                cmd = new SqlCommand(insertQ,con);               
                cmd.Parameters.Add(new SqlParameter("@d1", string.IsNullOrEmpty(postofficeId) ? (object)DBNull.Value : postofficeId));
                cmd.Parameters.Add(new SqlParameter("@d2", string.IsNullOrEmpty(txtFlatNo.Text) ? (object)DBNull.Value : txtFlatNo.Text));
                cmd.Parameters.Add(new SqlParameter("@d3", string.IsNullOrEmpty(txtHouseNo.Text) ? (object)DBNull.Value : txtHouseNo.Text));
                cmd.Parameters.Add(new SqlParameter("@d4", string.IsNullOrEmpty(txtRoadNo.Text) ? (object)DBNull.Value : txtRoadNo.Text));
                cmd.Parameters.Add(new SqlParameter("@d5", string.IsNullOrEmpty(txtBlock.Text) ? (object)DBNull.Value : txtBlock.Text));
                cmd.Parameters.Add(new SqlParameter("@d6", string.IsNullOrEmpty(txtArea.Text) ? (object)DBNull.Value : txtArea.Text));
                cmd.Parameters.Add(new SqlParameter("@d7", string.IsNullOrEmpty(txtContactNo.Text) ? (object)DBNull.Value : txtContactNo.Text));
                cmd.Parameters.AddWithValue("@d8", currentPerticipantId);               
                affectedRows1 = (int)cmd.ExecuteScalar();
                con.Close();
            }
        }

        private void Reset()
        {
            companyNameComboBox.SelectedIndex = -1;
            boardNameComboBox.SelectedIndex = -1;
            participantNameTextBox.Clear();
            participantDesignationTextBox.Clear();
            cmbEmailAddress.SelectedIndex = -1;
            participantContactNoTextBox.Clear();
           

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
                string query1 = "insert into Participant (ParticipantName,ContactNumber,Designation,EmailBankId,CompanyId,BoardId,UserId,DateTime) values (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                cmd = new SqlCommand(query1, con);
                cmd.Parameters.AddWithValue("@d1", participantNameTextBox.Text);
                cmd.Parameters.AddWithValue("@d2", participantContactNoTextBox.Text);
                cmd.Parameters.AddWithValue("@d3", participantDesignationTextBox.Text);
                cmd.Parameters.AddWithValue("@d4", bankEmailId);
                cmd.Parameters.AddWithValue("@d5", companyId);
                cmd.Parameters.AddWithValue("@d6", boardId);
                cmd.Parameters.AddWithValue("@d7", nUserId);
                cmd.Parameters.AddWithValue("@d8", DateTime.UtcNow.ToLocalTime());
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(companyNameComboBox.Text))
            {
                MessageBox.Show("Please select company name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           if (string.IsNullOrEmpty(boardNameComboBox.Text))
            {
                MessageBox.Show("Please select board name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return;
            }
          if (string.IsNullOrEmpty(participantNameTextBox.Text))
            {
                MessageBox.Show("Please input participant name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
              return;
            }

            if (unKnownRA.Checked == false)
            {
                if (string.IsNullOrWhiteSpace(cmbPDivision.Text))
                {
                    MessageBox.Show("Please select Present Address division", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(cmbPDistrict.Text))
                {
                    MessageBox.Show("Please Select Present Address district", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(cmbPThana.Text))
                {
                    MessageBox.Show("Please select Present Address Thana", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(cmbPPost.Text))
                {
                    MessageBox.Show("Please Select Present Address Post Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtPPostCode.Text))
                {
                    MessageBox.Show("Please select Present Address Post Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (unKnownCheckBox.Checked == false && sameAsRACheckBox.Checked == false)
            {
                if (string.IsNullOrWhiteSpace(cmbDivision.Text))
                {
                    MessageBox.Show("Please select Permanant Address division", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(cmbDistrict.Text))
                {
                    MessageBox.Show("Please Select Permanant Address district", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(cmbThana.Text))
                {
                    MessageBox.Show("Please select Permanant Address Thana", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(cmbPost.Text))
                {
                    MessageBox.Show("Please Select Permanant Address Post Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtPostCode.Text))
                {
                    MessageBox.Show("Please select Permanant Address Post Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }               
            }

            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct3 = "select Participant.ParticipantName from Participant where  Participant.ParticipantName='" + participantNameTextBox.Text + "'";
                cmd = new SqlCommand(ct3, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read() && !rdr.IsDBNull(0))
                {
                    MessageBox.Show("This Participant Already Exists,Please Input another one", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
                //1.Permanant Address Applicable  & Present Address not Applicable
                if (unKnownRA.Checked)
                {
                    SaveParticipant();
                    SaveParticipantAddress("PPermanantAddresses");
                }
                //2.Permanant Address Applicable  & Present Address Same as  Corporate Address                                        
                if (sameAsRACheckBox.Checked)
                {
                    SaveParticipant();
                    SaveParticipantAddress("PPermanantAddresses");
                    PermanantSameAsPresent("PPresentAddresses");

                }
                //3.Permanant Address Applicable  & Present Address  Applicable
                if (sameAsRACheckBox.Checked == false && unKnownCheckBox.Checked == false)
                {
                    SaveParticipant();
                    SaveParticipantAddress("PPermanantAddresses");
                    SaveParticipantAddress("PPresentAddresses");
                }
                MessageBox.Show("Saved Sucessfully", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                    




        }
        private void boardNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "select BoardId from Board WHERE Board.BoardName= '" + boardNameComboBox.Text+ "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                   boardId = (rdr.GetInt32(0));
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
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbRADivision_SelectedIndexChanged(object sender, EventArgs e)
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

        private void cmbRADistrict_SelectedIndexChanged(object sender, EventArgs e)
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

        private void cmbRAThana_SelectedIndexChanged(object sender, EventArgs e)
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
                cmbPost.Items.Clear();
                cmbPost.Text = "";
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

        private void cmbRAPost_SelectedIndexChanged(object sender, EventArgs e)
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

        private void cmbWAPost_SelectedIndexChanged(object sender, EventArgs e)
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

        private void cmbWAThana_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctk = "SELECT  RTRIM(Thanas.T_ID)  from Thanas WHERE Thanas.Thana=@find";
                cmd = new SqlCommand(ctk);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NVarChar, 50, "Thana"));
                cmd.Parameters["@find"].Value = cmbPThana.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    thanaIdP= (rdr.GetString(0));

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

        private void cmbWADistrict_SelectedIndexChanged(object sender, EventArgs e)
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
                string ct = "select RTRIM(Thanas.Thana) from Thanas  Where Thanas.D_ID = '" + districtIdP + "' order by Thanas.D_ID desc";
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

        private void cmbWADivision_SelectedIndexChanged(object sender, EventArgs e)
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
                string ct = "select RTRIM(Districts.District) from Districts  Where Districts.Division_ID = '" + divisionIdP + "' order by Districts.Division_ID desc";
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
                    ResetPresentAddress();
                    ResetPStar();
                }
                else
                {

                    groupBox4.Enabled = false;
                    ResetPresentAddress();
                    ResetPStar();
                }

            }
            else
            {
                if (sameAsRACheckBox.Checked)
                {
                    groupBox4.Enabled = false;
                    ResetPresentAddress();
                    ResetPStar();
                }
                else
                {

                    groupBox4.Enabled = true;
                    ResetPresentAddress();
                    FillPStar();
                }
            }
        }

        private void txtPContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char) Keys.Back)))
                e.Handled = true;
        }

        private void txtContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
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
                    ResetPresentAddress();
                    ResetPStar();
                }
                else
                {

                    groupBox4.Enabled = false;
                    ResetPresentAddress();
                    ResetPStar();
                }

            }
            else
            {
                if (unKnownCheckBox.Checked)
                {
                    groupBox4.Enabled = false;
                    ResetPresentAddress();
                    ResetPStar();
                }
                else
                {

                    groupBox4.Enabled = true;
                    ResetPresentAddress();
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
            }
            else
            {
                FillStar();
                groupBox5.Enabled = true;
            }
        }
        private void unKnownRA_TextChanged(object sender, EventArgs e)
        {

        }
        private void cmbEmailAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEmailAddress.Text == "Not In The List")
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Please Input Mode Of Conduct  Here", "Input Here", "", -1, -1);
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
                        mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");
                        if (!mRegxExpression.IsMatch(emailId))
                        {

                            MessageBox.Show("Please type a valid email Address.", "MojoCRM", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("This Email  Already Exists,Please Select From List", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                        cmbEmailAddress.SelectedIndex = -1;
                    }
                    else
                    {
                        try
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string query1 = "insert into EmailBank (Email, UserId,DateAndTime) values (@d1,@d2,@d3)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
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

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }
    }
}
