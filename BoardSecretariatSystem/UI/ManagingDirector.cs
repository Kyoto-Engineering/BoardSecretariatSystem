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
    public partial class ManagingDirector : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public string labelk;
        public int directorId, participantId, shareHolderId, mDirectorId, vacantPostOfMDirector, vacantPostOfMDirector1, companyId=1;
        public ManagingDirector()
        {
            InitializeComponent();
        }

        private void ManagingDirector_Load(object sender, EventArgs e)
        {

        }

        private void ManagingDirector_FormClosed(object sender, FormClosedEventArgs e)
        {
                    this.Hide();
            BoardManagementUI frm=new BoardManagementUI();
                     frm.Show();
        }
        private void GetDirectorId()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctq = "select ParticipantId from Participant where Participant.ParticipantName='" + txtMDirectorName.Text + "'";
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

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string qry3 = "select DerectorId from Derector where Derector.ShareholderId='" + shareHolderId + "'";
                cmd = new SqlCommand(qry3, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    directorId = (rdr.GetInt32(0));
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (txtMDirectorName.Text == "")
            {
                MessageBox.Show("Please Select Managing director Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMDirectorName.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string qry2 = "SELECT Company.VacantPostofMDirector from  Company";
                cmd = new SqlCommand(qry2, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    vacantPostOfMDirector = (rdr.GetInt32(0));

                }
                con.Close();
                
                if (vacantPostOfMDirector == 0)
                {
                    MessageBox.Show("There is not  available any  vacant Post of Managing Director", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    vacantPostOfMDirector1 = vacantPostOfMDirector - 1;
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string qry = "Update Company Set VacantPostofMDirector=@d1 where Company.CompanyId='" + companyId + "'";
                    cmd = new SqlCommand(qry, con);
                    cmd.Parameters.AddWithValue("@d1", vacantPostOfMDirector1);
                    cmd.ExecuteReader();
                    con.Close();

                    GetDirectorId();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string qry1 = "select MDerectorId from MDerector where MDerector.DerectorId='" + directorId + "'";
                    cmd = new SqlCommand(qry1, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        mDirectorId = (rdr.GetInt32(0));
                        MessageBox.Show("This Managing Director Already Exists,Please Select another one.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtMDirectorName.Text = "";
                        txtMDirectorName.Focus();
                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                        return;
                    }
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "insert into MDerector(DerectorId,JoiningDate) VALUES (@d1,@d2)";
                    cmd = new SqlCommand(cb, con);
                    cmd.Parameters.AddWithValue("@d1", directorId);
                    cmd.Parameters.AddWithValue("@d2", Convert.ToDateTime(txtMDJoiningDate.Value, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat));
                    cmd.ExecuteReader();
                    con.Close();
                    MessageBox.Show("Successfully Created", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMDirectorName.Clear();
                }                               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
