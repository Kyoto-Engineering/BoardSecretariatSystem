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
    public partial class Chairman : Form
    {
        SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public string labelk;
        public int directorId, participantId, shareHolderId, mDirectorId, vacantPostOfChairman, vacantPostOfChairman1, companyId=1;
        public Chairman()
        {
            InitializeComponent();
        }

        private void Chairman_Load(object sender, EventArgs e)
        {

        }

        private void Chairman_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            BoardManagementUI frm = new BoardManagementUI();
             frm.Show();
        }
        private void GetDirectorId()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctq = "select ParticipantId from Participant where Participant.ParticipantName='" + txtChairmanName.Text + "'";
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
            if (txtChairmanName.Text == "")
            {
                MessageBox.Show("Please Select Chairman Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtChairmanName.Focus();
                return;
            }
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string qry2 = "SELECT Company.VacantPostofChairman from  Company";
                cmd = new SqlCommand(qry2, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    vacantPostOfChairman = (rdr.GetInt32(0));

                }
                con.Close();
                if (vacantPostOfChairman == 0)
                {
                    MessageBox.Show("There is not  available any  vacant Post of Chairman", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    vacantPostOfChairman1 = vacantPostOfChairman - 1;
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string qry = "Update Company Set VacantPostofChairman=@d1 where Company.CompanyId='" + companyId + "'";
                    cmd = new SqlCommand(qry, con);
                    cmd.Parameters.AddWithValue("@d1", vacantPostOfChairman1);
                    cmd.ExecuteReader();
                    con.Close();

                    GetDirectorId();

                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string qry1 = "select ChairmanId from Chairman where Chairman.DerectorId='" + directorId + "'";
                    cmd = new SqlCommand(qry1, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        mDirectorId = (rdr.GetInt32(0));
                        MessageBox.Show("This Chairman  Already Exists,Please Select another one.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtChairmanName.Text = "";
                        txtChairmanName.Focus();
                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                        return;
                    }
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "insert into Chairman(DerectorId,JoiningDate) VALUES (@d1,@d2)";
                    cmd = new SqlCommand(cb, con);
                    cmd.Parameters.AddWithValue("@d1", directorId);
                    cmd.Parameters.AddWithValue("@d2", Convert.ToDateTime(txtChairmanJoiningDate.Value, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat));
                    cmd.ExecuteReader();
                    con.Close();
                    MessageBox.Show("Successfully Created", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtChairmanName.Clear();                                                               
                }               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtChairmanName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtChairmanJoiningDate.Focus();
                e.Handled = true;
            }
        }

        private void txtChairmanJoiningDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonCreate.Focus();
                e.Handled = true;
            }
        }
    }
}
