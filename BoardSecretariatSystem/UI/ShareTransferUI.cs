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
    public partial class ShareTransferUI : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        public string startCertificateid, endCertificateid;
        public int shid;

        public ShareTransferUI()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

        }


        private void ShareTransferUI_Load(object sender, EventArgs e)
        {
            startCertificateNoComboBox.Enabled = false;
            endCertificateNoComboBox.Enabled = false;
        }

        public void FillstartCertificateNo()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "SELECT CertificateNumber FROM Certificate where ShareholderId='"+shid+"'";
                
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    startCertificateNoComboBox.Items.Add(rdr[0]);
                }
                //    con = new SqlConnection(cs.DBConn);
                //    con.Open();
                //    string ctt = "select RTRIM(CountryId) from Countries  where  Countries.CountryName='" +
                //                 CountrycomboBox.Text + "' ";
                //    cmd = new SqlCommand(ctt);
                //    cmd.Connection = con;
                //    rdr = cmd.ExecuteReader();

                //    if (rdr.Read())
                //    {
                //        countryid = (rdr.GetString(0));
                //        //countryid = rdr.GetInt32(0);

                //    }

                //    //CountrycomboBox.Items.Add("Not In The List");
                //    con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void FillendCertificateNo()
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "SELECT CertificateNumber FROM Certificate where ShareholderId='" + shid + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    endCertificateNoComboBox.Items.Add(rdr[0]);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cellNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

      

        private void cellNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        

        private void w1ContactNoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void w2ContactNoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void btnShareHolderGrid_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShareHolderGrid frmk = new ShareHolderGrid();
            frmk.Show();
        }

        private void startCertificateNoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            endCertificateNoComboBox.Enabled = true;
            //int x = startCertificateNoComboBox.SelectedIndex;
            //int y = endCertificateNoComboBox.SelectedIndex;
            //if (x > y)
            //{
            //    startCertificateNoComboBox.SelectedIndex = -1;
             
            //}
            //else
            //{


                try
                {

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "select RTRIM(CertificateId) from Certificate  where  Certificate.CertificateNumber='" +
                                startCertificateNoComboBox.Text + "' ";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        startCertificateid = (rdr.GetString(0));

                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            //}
        }

        private void endCertificateNoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int a = startCertificateNoComboBox.SelectedIndex;
            int b = endCertificateNoComboBox.SelectedIndex;
            if (a > b)
            {              
                //MessageBox.Show("Please select greater than or equal", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                endCertificateNoComboBox.SelectedIndex = -1;
                //endCertificateNoComboBox.Focus();
                
            }  
            
            else
            {
                try
                {

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "select RTRIM(CertificateId) from Certificate  where  Certificate.CertificateNumber='" +
                                endCertificateNoComboBox.Text + "' ";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        endCertificateid = (rdr.GetString(0));

                    }
                    con.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void emailComboBox_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(emailComboBox.Text))
            {


                string emailId = emailComboBox.Text.Trim();
                Regex mRegxExpression;
                mRegxExpression =
                    new Regex(
                        @"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");
                if (!mRegxExpression.IsMatch(emailId))
                {

                    MessageBox.Show("Please type a valid email Address.", "MojoCRM", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    emailComboBox.SelectedIndex = -1;
                    emailComboBox.ResetText();
                    emailComboBox.Focus();

                }
            }
        }

       
        private void nameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                fatherNameTextBox.Focus();
                e.Handled = true;
            }
        }

        private void fatherNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                motherNameTextBox.Focus();
                e.Handled = true;
            }
        }

        private void motherNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateOfBirthTextBox.Focus();
                e.Handled = true;
            }
        }

        private void dateOfBirthTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cellNumberTextBox.Focus();
                e.Handled = true;
            }
        }

        private void cellNumberTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                nationalIdTextBox.Focus();
                e.Handled = true;
            }
        }

        private void nationalIdTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                birthCertificateNoTextBox.Focus();
                e.Handled = true;
            }
        }

        private void birthCertificateNoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                passportNoTextBox.Focus();
                e.Handled = true;
            }
        }

        private void passportNoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tinTextBox.Focus();
                e.Handled = true;
            }
        }

        private void tinTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                emailComboBox.Focus();
                e.Handled = true;
            }
        }

        private void emailComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               genderComboBox.Focus();
                e.Handled = true;
            }
        }

        private void genderComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                personDivisionComboBox.Focus();
                e.Handled = true;
            }
        }

        private void personDivisionComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                personDistrictComboBox.Focus();
                e.Handled = true;
            }
        }

        private void personDistrictComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                personThanaComboBox.Focus();
                e.Handled = true;
            }
        }

        private void personThanaComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                personPostComboBox.Focus();
                e.Handled = true;
            }
        }

        private void personPostComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                personPostCodeTextBox.Focus();
                e.Handled = true;
            }
        }

        private void personPostCodeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                totalAmountTextBox.Focus();
                e.Handled = true;
            }
        }

        private void totalAmountTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                startFolioNoComboBox.Focus();
                e.Handled = true;
            }
        }

        private void startFolioNoComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                endFolioNoComboBox.Focus();
                e.Handled = true;
            }
        }

        private void endFolioNoComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                witness1NameTextBox.Focus();
                e.Handled = true;
            }
        }

        private void witness1NameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                w1occupationTextBox.Focus();
                e.Handled = true;
            }
        }

        private void w1occupationTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                w1flatNoTextBox.Focus();
                e.Handled = true;
            }
        }

        private void w1flatNoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                w1houseNoTextBox.Focus();
                e.Handled = true;
            }
        }

        private void w1houseNoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                w1roadNoTextBox.Focus();
                e.Handled = true;
            }
        }

        private void w1roadNoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                w1blockTextBox.Focus();
                e.Handled = true;
            }
        }

        private void w1blockTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                w1AreaTextBox.Focus();
                e.Handled = true;
            }
        }

        private void w1AreaTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                w1ContactNoTextBox.Focus();
                e.Handled = true;
            }
        }

        private void w1ContactNoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                w1DivisionComboBox.Focus();
                e.Handled = true;
            }
        }

        private void w1DivisionComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                w1DistrictComboBox.Focus();
                e.Handled = true;
            }
        }

        private void w1DistrictComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                w1ThanaComboBox.Focus();
                e.Handled = true;
            }
        }

        private void w1ThanaComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                w1PostComboBox.Focus();
                e.Handled = true;
            }
        }

        private void w1PostComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                w1PostCodeTextBox.Focus();
                e.Handled = true;
            }
        }

        private void w1PostCodeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                witness2NameTextBox.Focus();
                e.Handled = true;
            }
        }

      
        private void witness2NameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                w2OccupationTextBox.Focus();
                e.Handled = true;
            }
        }

        private void w2OccupationTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                w2FlatNoTextBox.Focus();
                e.Handled = true;
            }
        }

        private void w2FlatNoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                w2HouseNoTextBox.Focus();
                e.Handled = true;
            }
        }

        private void w2HouseNoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                w2RoadNoTextBox.Focus();
                e.Handled = true;
            }
        }

        private void w2RoadNoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                w2BlockTextBox.Focus();
                e.Handled = true;
            }
        }

        private void w2BlockTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                w2AreaTextBox.Focus();
                e.Handled = true;
            }
        }

        private void w2AreaTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                w2ContactNoTextBox.Focus();
                e.Handled = true;
            }
        }

        private void w2ContactNoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                w2DivisionComboBox.Focus();
                e.Handled = true;
            }
        }

        private void w2DivisionComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                w2DistrictComboBox.Focus();
                e.Handled = true;
            }
        }

        private void w2DistrictComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                w2ThanaComboBox.Focus();
                e.Handled = true;
            }
        }

        private void w2ThanaComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                w2PostOfficeComboBox.Focus();
                e.Handled = true;
            }
        }

        private void w2PostOfficeComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                w2PostCodeTextBox.Focus();
                e.Handled = true;
            }
        }

        private void w2PostCodeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                saveButton.Focus();
                e.Handled = true;
            }
        }

       

    }
}

