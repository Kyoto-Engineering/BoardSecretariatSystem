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
    public partial class BoardEntryUI : Form 
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        private ConnectionString cs = new ConnectionString();
        private delegate void ChangeFocusDelegate(Control ctl);
        public int companyId, currentBoardId, bankEmailId, boardId,currentBoardMemberId;
        public string userId, divisionId, divisionIdP, districtId, districtIdP, thanaId, thanaIdP, postofficeId, postofficeIdP, memberTypeId;

        public BoardEntryUI()
        {
            InitializeComponent();
            CompanyNameLoad();
            
        }

        private void changeFocus(Control ctl)
        {
            ctl.Focus();
        }
        private void BoardEntryUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            MainUI mainUI = new MainUI();
            mainUI.Show();
        }

        public void CompanyNameLoad()
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();


            string query = "SELECT CompanyName FROM Company ";

            cmd = new SqlCommand(query, con);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                cmbCompanyName.Items.Add(rdr[0]);
            }
            con.Close();

        }

        private void saveButton_Click(object sender, EventArgs e)
        {           
        }

        private void companyNameComboBox_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cmbCompanyName.Text) && !cmbCompanyName.Items.Contains(cmbCompanyName.Text))
            {
                MessageBox.Show("Please Select A Valid Company Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCompanyName.ResetText();
                this.BeginInvoke(new ChangeFocusDelegate(changeFocus), cmbCompanyName);
            }
        }

        private void Reset()
        {
            cmbCompanyName.ResetText();
            cmbCompanyName.SelectedIndex = -1;
            txtBoardName.Clear();
        }
        private void SaveMemberAddress()
        {
            try
            {
                for (int i = 0; i <= listView1.Items.Count - 1; i++)
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string query1 = "insert into Participant(ParticipantName,BoardMemberTypeId,Designation,EmailBankId,ContactNumber,CompanyId,BoardId,UserId,DateTime) values (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                    cmd = new SqlCommand(query1, con);
                    cmd.Parameters.AddWithValue("@d1", listView1.Items[i].SubItems[0].Text);
                    cmd.Parameters.AddWithValue("@d2", "1");
                    cmd.Parameters.AddWithValue("@d3", listView1.Items[i].SubItems[1].Text);
                    cmd.Parameters.AddWithValue("@d4", listView1.Items[i].SubItems[3].Text);
                    cmd.Parameters.AddWithValue("@d5", listView1.Items[i].SubItems[4].Text);
                    cmd.Parameters.AddWithValue("@d6", companyId);
                    cmd.Parameters.AddWithValue("@d7", boardId);
                    cmd.Parameters.AddWithValue("@d8", userId);
                    cmd.Parameters.AddWithValue("@d9", DateTime.UtcNow.ToLocalTime());
                    currentBoardMemberId = (int)cmd.ExecuteScalar();
                    con.Close();        


                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string qry = "insert into PPresentAddresses(PostOfficeId,PFlatNo,PHouseNo,PRoadNo,PBlock,PArea,PContactNo,ParticipantId) VALUES(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)";
                    cmd = new SqlCommand(qry, con);
                    cmd.Parameters.AddWithValue("d1", listView1.Items[i].SubItems[11].Text);
                    cmd.Parameters.AddWithValue("d2", listView1.Items[i].SubItems[5].Text);
                    cmd.Parameters.AddWithValue("d3", listView1.Items[i].SubItems[6].Text);
                    cmd.Parameters.AddWithValue("d4", listView1.Items[i].SubItems[7].Text);
                    cmd.Parameters.AddWithValue("d5", listView1.Items[i].SubItems[8].Text);
                    cmd.Parameters.AddWithValue("d6", listView1.Items[i].SubItems[9].Text);
                    cmd.Parameters.AddWithValue("d7", listView1.Items[i].SubItems[10].Text);
                    cmd.Parameters.Add(new SqlParameter("@d1", string.IsNullOrEmpty(postofficeIdP) ? (object)DBNull.Value : postofficeIdP));
                    cmd.Parameters.Add(new SqlParameter("@d2", string.IsNullOrEmpty(txtPFlatName.Text) ? (object)DBNull.Value : txtPFlatName.Text));
                    cmd.Parameters.Add(new SqlParameter("@d3", string.IsNullOrEmpty(txtPHouseName.Text) ? (object)DBNull.Value : txtPHouseName.Text));
                    cmd.Parameters.Add(new SqlParameter("@d4", string.IsNullOrEmpty(txtPRoadNo.Text) ? (object)DBNull.Value : txtPRoadNo.Text));
                    cmd.Parameters.Add(new SqlParameter("@d5", string.IsNullOrEmpty(txtPBlock.Text) ? (object)DBNull.Value : txtPBlock.Text));
                    cmd.Parameters.Add(new SqlParameter("@d6", string.IsNullOrEmpty(txtPArea.Text) ? (object)DBNull.Value : txtPArea.Text));
                    cmd.Parameters.Add(new SqlParameter("@d7", string.IsNullOrEmpty(txtPContactNo.Text) ? (object)DBNull.Value : txtPContactNo.Text));
                    cmd.Parameters.AddWithValue("d8", currentBoardMemberId);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "insert into PPermanantAddresses(PostOfficeId,FlatNo,HouseNo,RoadNo,Block,Area,ContactNo,ParticipantId) VALUES(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)";
                    cmd = new SqlCommand(cb, con);
                    cmd.Parameters.AddWithValue("d1", listView1.Items[i].SubItems[18].Text);
                    cmd.Parameters.AddWithValue("d2", listView1.Items[i].SubItems[12].Text);
                    cmd.Parameters.AddWithValue("d3", listView1.Items[i].SubItems[13].Text);
                    cmd.Parameters.AddWithValue("d4", listView1.Items[i].SubItems[14].Text);
                    cmd.Parameters.AddWithValue("d5", listView1.Items[i].SubItems[15].Text);
                    cmd.Parameters.AddWithValue("d6", listView1.Items[i].SubItems[16].Text);
                    cmd.Parameters.AddWithValue("d7", listView1.Items[i].SubItems[17].Text);
                    cmd.Parameters.AddWithValue("d8", currentBoardMemberId);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void SaveMemberPermanantAddress()
        {
            try
            {
                for (int i = 0; i <= listView1.Items.Count - 1; i++)
                {
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void SavePerticipant()
        {
            try
            {
                for (int i = 0; i < listView1.Items.Count-1; i++)
                {
                       
                }   
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                        
        }
        private void saveButton_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbCompanyName.Text))
            {
                MessageBox.Show("Please Select company name", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
             if (string.IsNullOrEmpty(txtBoardName.Text))
            {
                MessageBox.Show("Please enter board name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 return;
            }

             if (!string.IsNullOrEmpty(txtBoardName.Text))
             {
                 con = new SqlConnection(cs.DBConn);
                 con.Open();
                 string ct1 = "select BoardName from Board where BoardName='" + txtBoardName.Text + "' ";
                 cmd = new SqlCommand(ct1, con);
                 rdr = cmd.ExecuteReader();
                 if (rdr.Read() && !rdr.IsDBNull(0))
                 {
                     MessageBox.Show("This Board Name Already Exists,Please Input another one", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     txtBoardName.ResetText();
                     txtBoardName.Focus();
                     con.Close();

                 }                
                        try
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string query1 ="insert into Board (BoardName,CompanyId,UserId,DateTime) values (@d1,@d2,@d3,@d4)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            cmd = new SqlCommand(query1, con);
                            cmd.Parameters.AddWithValue("@d1", txtBoardName.Text);
                            cmd.Parameters.AddWithValue("@d2", companyId);
                            cmd.Parameters.AddWithValue("@d3", userId);
                            cmd.Parameters.AddWithValue("@d4", DateTime.UtcNow.ToLocalTime());
                            currentBoardId = (int) cmd.ExecuteScalar();
                            con.Close();                           
                            SaveMemberAddress();
                            MessageBox.Show("Saved Sucessfully", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Reset();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        //private void GetBoardName()
        //{
        //    try
        //    {
        //        con = new SqlConnection(cs.DBConn);
        //        con.Open();
        //        string ctt = "select BoardName from Board";
        //        cmd = new SqlCommand(ctt);
        //        cmd.Connection = con;
        //        rdr = cmd.ExecuteReader();
        //        while (rdr.Read())
        //        {
        //            cmbBoardName.Items.Add(rdr.GetValue(0).ToString());
        //        }
        //        cmbBoardName.Items.Add("Not In The List");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
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
        private void Reset2()
        {
            cmbCompanyName.SelectedIndex = -1;
            //cmbMemberType.SelectedIndex = -1;
            txtMemberName.Clear();
            txtBoardName.Clear();
            txtMDesignation.Clear();
            cmbEmailAddress.SelectedIndex = -1;
            txtCellNumber.Clear();
            unKnownRA.CheckedChanged -= unKnownRA_CheckedChanged;
            unKnownRA.Checked = false;
            unKnownRA.CheckedChanged += unKnownRA_CheckedChanged;
            unKnownCheckBox.CheckedChanged -= unKnownCheckBox_CheckedChanged;
            unKnownCheckBox.Checked = false;
            unKnownCheckBox.CheckedChanged += unKnownCheckBox_CheckedChanged;

            sameAsRACheckBox.CheckedChanged -= sameAsRACheckBox_CheckedChanged;
            sameAsRACheckBox.Checked = false;
            sameAsRACheckBox.CheckedChanged += sameAsRACheckBox_CheckedChanged;

            ResetPermanantAddress();
            ResetPresentAddress();
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

        private void BoardEntryUI_Load(object sender, EventArgs e)
        {
            FillPermanantDivisionCombo();
            FillPresentDivisionCombo();
            EmailAddress();
                
            userId = frmLogin.uId.ToString();
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
        private void addButton_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)
            {
                ListViewItem list = new ListViewItem();
                //1. Both Not Applicable
                if (unKnownRA.Checked && unKnownCheckBox.Checked)
                {
                    list.SubItems.Add(txtMemberName.Text);
                    list.SubItems.Add(txtMDesignation.Text);
                    list.SubItems.Add(cmbEmailAddress.Text);
                    list.SubItems.Add(txtCellNumber.Text);
                }
                //2.Present Address Applicable  & Permanant Address not Applicable
                if (unKnownRA.Checked && unKnownCheckBox.Checked == false)
                {
                    list.SubItems.Add(txtMemberName.Text);
                    list.SubItems.Add(txtMDesignation.Text);
                    list.SubItems.Add(cmbEmailAddress.Text);
                    list.SubItems.Add(txtCellNumber.Text);


                    list.SubItems.Add(txtPFlatName.Text);
                    list.SubItems.Add(txtPHouseName.Text);
                    list.SubItems.Add(txtPRoadNo.Text);
                    list.SubItems.Add(txtPBlock.Text);
                    list.SubItems.Add(txtPArea.Text);
                    list.SubItems.Add(txtPContactNo.Text);
                    list.SubItems.Add(txtPPostCode.Text);


                    list.SubItems.Add(txtFlatNo.Text);
                    list.SubItems.Add(txtHouseNo.Text);
                    list.SubItems.Add(txtRoadNo.Text);
                    list.SubItems.Add(txtBlock.Text);
                    list.SubItems.Add(txtArea.Text);
                    list.SubItems.Add(txtContactNo.Text);
                    list.SubItems.Add(txtPostCode.Text);
                }
                //3.Present Address Applicable  & Permanant Address Same as  Corporate Address                                        
                if (sameAsRACheckBox.Checked)
                {
                    list.SubItems.Add(txtMemberName.Text);
                    list.SubItems.Add(txtMDesignation.Text);
                    list.SubItems.Add(cmbEmailAddress.Text);
                    list.SubItems.Add(txtCellNumber.Text);

                    list.SubItems.Add(txtPFlatName.Text);
                    list.SubItems.Add(txtPHouseName.Text);
                    list.SubItems.Add(txtPRoadNo.Text);
                    list.SubItems.Add(txtPBlock.Text);
                    list.SubItems.Add(txtPArea.Text);
                    list.SubItems.Add(txtPContactNo.Text);
                    list.SubItems.Add(txtPPostCode.Text);

                    list.SubItems.Add(txtPFlatName.Text);
                    list.SubItems.Add(txtPHouseName.Text);
                    list.SubItems.Add(txtPRoadNo.Text);
                    list.SubItems.Add(txtPBlock.Text);
                    list.SubItems.Add(txtPArea.Text);
                    list.SubItems.Add(txtPContactNo.Text);
                    list.SubItems.Add(txtPPostCode.Text);

                   

                }
                //4.Present Address Applicable  & Permanant  Address  Applicable
                if (sameAsRACheckBox.Checked == false && unKnownCheckBox.Checked == false)
                {
                    list.SubItems.Add(txtMemberName.Text);
                    list.SubItems.Add(txtMDesignation.Text);
                    list.SubItems.Add(cmbEmailAddress.Text);
                    list.SubItems.Add(txtCellNumber.Text);

                    list.SubItems.Add(txtPFlatName.Text);
                    list.SubItems.Add(txtPHouseName.Text);
                    list.SubItems.Add(txtPRoadNo.Text);
                    list.SubItems.Add(txtPBlock.Text);
                    list.SubItems.Add(txtPArea.Text);
                    list.SubItems.Add(txtPContactNo.Text);
                    list.SubItems.Add(txtPPostCode.Text);

                    list.SubItems.Add(txtFlatNo.Text);
                    list.SubItems.Add(txtHouseNo.Text);
                    list.SubItems.Add(txtRoadNo.Text);
                    list.SubItems.Add(txtBlock.Text);
                    list.SubItems.Add(txtArea.Text);
                    list.SubItems.Add(txtContactNo.Text);
                    list.SubItems.Add(txtPostCode.Text);
                    
                }                                                   
                listView1.Items.Add(list);

                txtMemberName.Clear();
                txtMDesignation.Clear();
                cmbEmailAddress.SelectedIndex = -1;
                txtCellNumber.Clear();

                txtPFlatName.Clear();
                txtPHouseName.Clear();
                txtPRoadNo.Clear();
                txtPBlock.Clear();
                txtPArea.Clear();
                txtPContactNo.Clear();
                txtPPostCode.Clear();

                txtFlatNo.Clear();
                txtHouseNo.Clear();
                txtRoadNo.Clear();
                txtBlock.Clear();
                txtArea.Clear();
                txtContactNo.Clear();
                txtPostCode.Clear();                
                return;
            }


            ListViewItem list1 = new ListViewItem();
            //1. Both Not Applicable
            if (unKnownRA.Checked && unKnownCheckBox.Checked)
            {
                list1.SubItems.Add(txtMemberName.Text);
                list1.SubItems.Add(txtMDesignation.Text);
                list1.SubItems.Add(cmbEmailAddress.Text);
                list1.SubItems.Add(txtCellNumber.Text);
            }
            //2.Present Address Applicable  & Permanant Address not Applicable
            if (unKnownRA.Checked && unKnownCheckBox.Checked == false)
            {
                list1.SubItems.Add(txtMemberName.Text);
                list1.SubItems.Add(txtMDesignation.Text);
                list1.SubItems.Add(cmbEmailAddress.Text);
                list1.SubItems.Add(txtCellNumber.Text);

                //SaveParticipantAddress("PPermanantAddresses");
                list1.SubItems.Add(txtFlatNo.Text);
                list1.SubItems.Add(txtHouseNo.Text);
                list1.SubItems.Add(txtRoadNo.Text);
                list1.SubItems.Add(txtBlock.Text);
                list1.SubItems.Add(txtArea.Text);
                list1.SubItems.Add(txtContactNo.Text);
                list1.SubItems.Add(txtPostCode.Text);
            }
            //3.Present Address Applicable  & Permanant Address Same as  Corporate Address                                        
            if (sameAsRACheckBox.Checked)
            {
                list1.SubItems.Add(txtMemberName.Text);
                list1.SubItems.Add(txtMDesignation.Text);
                list1.SubItems.Add(cmbEmailAddress.Text);
                list1.SubItems.Add(txtCellNumber.Text);

                list1.SubItems.Add(txtPFlatName.Text);
                list1.SubItems.Add(txtPHouseName.Text);
                list1.SubItems.Add(txtPRoadNo.Text);
                list1.SubItems.Add(txtPBlock.Text);
                list1.SubItems.Add(txtPArea.Text);
                list1.SubItems.Add(txtPContactNo.Text);
                list1.SubItems.Add(txtPPostCode.Text);
               // SaveParticipantAddress("PPermanantAddresses");

                list1.SubItems.Add(txtPFlatName.Text);
                list1.SubItems.Add(txtPHouseName.Text);
                list1.SubItems.Add(txtPRoadNo.Text);
                list1.SubItems.Add(txtPBlock.Text);
                list1.SubItems.Add(txtPArea.Text);
                list1.SubItems.Add(txtPContactNo.Text);
                list1.SubItems.Add(txtPPostCode.Text);
                

            }
            //4.Present Address Applicable  & Permanant  Address  Applicable
            if (sameAsRACheckBox.Checked == false && unKnownCheckBox.Checked == false)
            {
                list1.SubItems.Add(txtMemberName.Text);
                list1.SubItems.Add(txtMDesignation.Text);
                list1.SubItems.Add(cmbEmailAddress.Text);
                list1.SubItems.Add(txtCellNumber.Text);

                list1.SubItems.Add(txtPFlatName.Text);
                list1.SubItems.Add(txtPHouseName.Text);
                list1.SubItems.Add(txtPRoadNo.Text);
                list1.SubItems.Add(txtPBlock.Text);
                list1.SubItems.Add(txtPArea.Text);
                list1.SubItems.Add(txtPContactNo.Text);
                list1.SubItems.Add(txtPPostCode.Text);

                list1.SubItems.Add(txtFlatNo.Text);
                list1.SubItems.Add(txtHouseNo.Text);
                list1.SubItems.Add(txtRoadNo.Text);
                list1.SubItems.Add(txtBlock.Text);
                list1.SubItems.Add(txtArea.Text);
                list1.SubItems.Add(txtContactNo.Text);
                list1.SubItems.Add(txtPostCode.Text);
               
            }                               

            listView1.Items.Add(list1);

            txtMemberName.Clear();
            txtMDesignation.Clear();
            cmbEmailAddress.SelectedIndex = -1;
            txtCellNumber.Clear();

            txtPFlatName.Clear();
            txtPHouseName.Clear();
            txtPRoadNo.Clear();
            txtPBlock.Clear();
            txtPArea.Clear();
            txtPContactNo.Clear();
            txtPPostCode.Clear();

            txtFlatNo.Clear();
            txtHouseNo.Clear();
            txtRoadNo.Clear();
            txtBlock.Clear();
            txtArea.Clear();
            txtContactNo.Clear();
            txtPostCode.Clear();
            return;
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

        private void cmbPThana_SelectedIndexChanged(object sender, EventArgs e)
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

        private void unKnownCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (unKnownCheckBox.Checked)
            {

                if (sameAsRACheckBox.Checked)
                {
                    sameAsRACheckBox.CheckedChanged -= sameAsRACheckBox_CheckedChanged;
                    sameAsRACheckBox.Checked = false;
                    sameAsRACheckBox.CheckedChanged += sameAsRACheckBox_CheckedChanged;
                    groupBox7.Enabled = false;
                    ResetPermanantAddress();
                    ResetPStar();
                }
                else
                {

                    groupBox7.Enabled = false;
                    ResetPermanantAddress();
                    ResetPStar();
                }

            }
            else
            {
                if (sameAsRACheckBox.Checked)
                {
                    groupBox7.Enabled = false;
                    ResetPermanantAddress();
                    ResetPStar();
                }
                else
                {

                    groupBox7.Enabled = true;
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
                    groupBox7.Enabled = false;
                    ResetPermanantAddress();
                    ResetPStar();
                }
                else
                {

                    groupBox7.Enabled = false;
                    ResetPermanantAddress();
                    ResetPStar();
                }

            }
            else
            {
                if (unKnownCheckBox.Checked)
                {
                    groupBox7.Enabled = false;
                    ResetPresentAddress();
                    ResetPStar();
                }
                else
                {

                    groupBox7.Enabled = true;
                    ResetPresentAddress();
                    FillPStar();
                }
            }
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
                            cmd.Parameters.AddWithValue("@d2", userId);
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

        private void cmbBoardName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbBoardName.Text == "Not In The List")
            //{
            //    string input = Microsoft.VisualBasic.Interaction.InputBox("Please Input Board Name  Here", "Input Here", "", -1, -1);
            //    if (string.IsNullOrWhiteSpace(input))
            //    {
            //        cmbBoardName.SelectedIndex = -1;
            //    }

            //    else
            //    {                   
            //        con = new SqlConnection(cs.DBConn);
            //        con.Open();
            //        string ct2 = "select BoardName from Board where BoardName='" + input + "'";
            //        cmd = new SqlCommand(ct2, con);
            //        rdr = cmd.ExecuteReader();
            //        if (rdr.Read() && !rdr.IsDBNull(0))
            //        {
            //            MessageBox.Show("This Board  Already Exists,Please Select From List", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            con.Close();
            //            cmbBoardName.SelectedIndex = -1;
            //        }
            //        else
            //        {
            //            try
            //            {
            //                con = new SqlConnection(cs.DBConn);
            //                con.Open();
            //                string query1 = "insert into Board (BoardName,CompanyId,UserId,DateTime) values (@d1,@d2,@d3,@d4)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
            //                cmd = new SqlCommand(query1, con);
            //                cmd.Parameters.AddWithValue("@d1", input);
            //                cmd.Parameters.AddWithValue("@d2", companyId);
            //                cmd.Parameters.AddWithValue("@d3", userId);
            //                cmd.Parameters.AddWithValue("@d4", DateTime.UtcNow.ToLocalTime());
            //                cmd.ExecuteNonQuery();
            //                con.Close();
            //                cmbBoardName.Items.Clear();
            //                GetBoardName();
            //                cmbBoardName.SelectedText = input;
            //            }
            //            catch (Exception ex)
            //            {
            //                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    try
            //    {
            //        con = new SqlConnection(cs.DBConn);
            //        con.Open();
            //        cmd = con.CreateCommand();
            //        cmd.CommandText = "SELECT BoardId from Board WHERE BoardName= '" + cmbBoardName.Text + "'";

            //        rdr = cmd.ExecuteReader();
            //        if (rdr.Read())
            //        {
            //            boardId = rdr.GetInt32(0);
            //        }
            //        if ((rdr != null))
            //        {
            //            rdr.Close();
            //        }
            //        if (con.State == ConnectionState.Open)
            //        {
            //            con.Close();
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
        }

        private void cmbCompanyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT CompanyId from Company WHERE CompanyName= '" + cmbCompanyName.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    companyId = rdr.GetInt32(0);
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










