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
    public partial class BoardCreation : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public string userId;
        public int currentBoardId, companyId;
        public BoardCreation()
        {
            InitializeComponent();
        }

        private void Reset()
        {
            txtBoardName.Clear();
            cmbCompanyName.SelectedIndex = -1;
        }
        private void saveButton_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(cmbCompanyName.Text))
            {
                MessageBox.Show("Please Select company name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    con.Close();
                    return;
                   

                }
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string query1 = "insert into Board(BoardName,CompanyId,UserId,DateTime) values (@d1,@d2,@d3,@d4)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                    cmd = new SqlCommand(query1, con);
                    cmd.Parameters.AddWithValue("@d1", txtBoardName.Text);
                    cmd.Parameters.AddWithValue("@d2", companyId);
                    cmd.Parameters.AddWithValue("@d3", userId);
                    cmd.Parameters.AddWithValue("@d4", DateTime.UtcNow.ToLocalTime());
                    currentBoardId = (int)cmd.ExecuteScalar();
                    con.Close();                   
                    MessageBox.Show("Sucessfully Created.", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void CompanyNameLoad()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "SELECT CompanyName FROM Company  ";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                   
                     cmbCompanyName.Items.Add(rdr.GetValue(0).ToString());
                }              
                con.Close();                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BoardCreation_Load(object sender, EventArgs e)
        {
            CompanyNameLoad();
        }

        private void BoardCreation_FormClosed(object sender, FormClosedEventArgs e)
        {
                this.Hide();
            MainUI frm=new MainUI();
                frm.Show();
        }

        private void cmbCompanyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query2 = "SELECT CompanyId FROM Company where  Company.CompanyName='" + cmbCompanyName.Text + "' ";
                cmd = new SqlCommand(query2, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    companyId = (rdr.GetInt32(0));
                }

                con.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
