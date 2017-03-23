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
    public partial class DirectorCreation : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public string labelk;
        public int participantId,shareHolderId,directorId;
        public DirectorCreation()
        {
            InitializeComponent();
        }

        private void GetShareHolderId()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctq = "select ParticipantId from Participant where Participant.ParticipantName='" + txtDirectorName.Text + "'";
                cmd = new SqlCommand(ctq, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    participantId = (rdr.GetInt32(0));
                }
                con.Close();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string qry = "select ShareholderId from Shareholder where Shareholder.ParticipantId='" + participantId + "'";
                cmd = new SqlCommand(qry, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    shareHolderId = (rdr.GetInt32(0));
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtDirectorName.Text == "")
            {
                MessageBox.Show("Please Select director Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDirectorName.Focus();
                return;
            }
            try
            {
                GetShareHolderId();
                
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string qry1 = "select DerectorId from Derector where Derector.ShareholderId='" + shareHolderId + "'";
                cmd = new SqlCommand(qry1, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    directorId = (rdr.GetInt32(0));
                    MessageBox.Show("This Director Name  Already Exists,Please Select another one.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDirectorName.Text = "";
                    txtDirectorName.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into Derector(ShareholderId,JoiningDate) VALUES (@d1,@d2)";
                cmd = new SqlCommand(cb, con);
                cmd.Parameters.AddWithValue("@d1", shareHolderId);
                cmd.Parameters.AddWithValue("@d2", Convert.ToDateTime(txtJoiningDate.Value, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat));                  
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Successfully Created", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDirectorName.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbDirectorName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    con = new SqlConnection(cs.DBConn);
            //    con.Open();
            //    string ct = "select ShareholderId from Derector where ShareholderId='" + cmbDirectorName.Text + "'";
            //    cmd = new SqlCommand(ct);
            //    cmd.Connection = con;
            //    rdr = cmd.ExecuteReader();
            //    if (rdr.Read())
            //    {
            //        MessageBox.Show("This Director Name  Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        cmbDirectorName.Text = "";
            //        cmbDirectorName.Focus();


            //        if ((rdr != null))
            //        {
            //            rdr.Close();
            //        }
            //        return;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
        //public void DirectorLoad()
        //{
        //    try
        //    {
        //        con = new SqlConnection(cs.DBConn);
        //        con.Open();
        //        string query = "SELECT ParticipantName FROM Participant ";
        //        cmd = new SqlCommand(query, con);
        //        rdr = cmd.ExecuteReader();
        //        while (rdr.Read())
        //        {
        //            txtDirectorName.Items.Add(rdr[0]);
        //        }
        //        con.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        private void DirectorCreation_Load(object sender, EventArgs e)
        {
           // DirectorLoad();
        }

        private void DirectorCreation_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            BoardManagementUI frm = new BoardManagementUI();
             frm.Show();
        }
    }
}
