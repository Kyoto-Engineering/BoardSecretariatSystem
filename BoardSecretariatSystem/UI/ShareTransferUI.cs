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
    }
}

