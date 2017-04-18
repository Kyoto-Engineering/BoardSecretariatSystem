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
    public partial class DirectorResignation : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public int vacantPostOfDirector, vacantPostOfDirector1, participantId, shareHolderId, directorId, mDirectorId, companyId=1;
        public string labelk;
        public int numberOfDirector=0, numberOfDirector1;
        public DirectorResignation()
        {
            InitializeComponent();
        }
        private void GetDirectorId()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctq = "select ParticipantId from Participant where Participant.ParticipantName='" + textDirectorName.Text + "'";
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

        public void Reset()
        {
            txtResignationDate.Value=DateTime.Today;
            txtCauseOfResignation.Clear();
            textDirectorId.Clear();
            textDirectorName.Clear();
        }
        private void buttonDone_Click(object sender, EventArgs e)
        {
            if (textDirectorName.Text == "")
            {
                MessageBox.Show("Please Select Director Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textDirectorName.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string qry2 = "SELECT Company.VacantPostofDirector from  Company";
                cmd = new SqlCommand(qry2, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                   // numberOfDirector = (rdr.GetInt32(0));
                    vacantPostOfDirector = (rdr.GetInt32(0));

                }
                con.Close();

                numberOfDirector1 = numberOfDirector + 1;
                vacantPostOfDirector1 = vacantPostOfDirector + 1;

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string qry1 = "Update Company Set VacantPostofDirector=@d1  where Company.CompanyId='" + companyId + "'";
                cmd = new SqlCommand(qry1, con);                
                cmd.Parameters.AddWithValue("@d1", vacantPostOfDirector1);
                cmd.ExecuteReader();
                con.Close();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string qrk = "Update Derector Set CouseOfRetirement=@d2,DateofRetirement=@d3  where Derector.DerectorId='" + textDirectorId.Text + "'";
                cmd = new SqlCommand(qrk, con);
                cmd.Parameters.AddWithValue("@d2", txtCauseOfResignation.Text);
                cmd.Parameters.AddWithValue("@d3", Convert.ToDateTime(txtResignationDate.Value, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat));                
                cmd.ExecuteReader();
                con.Close();                                                                     
               MessageBox.Show("Successfully Resigned", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DirectorResignation_Load(object sender, EventArgs e)
        {

        }

        private void DirectorResignation_FormClosed(object sender, FormClosedEventArgs e)
        {
                         this.Hide();
            BoardManagementUI frm=new BoardManagementUI();
                         frm.Show();
        }
    }
}
