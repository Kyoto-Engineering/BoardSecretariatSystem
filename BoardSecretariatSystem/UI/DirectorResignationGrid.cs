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
    public partial class DirectorResignationGrid : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public DirectorResignationGrid()
        {
            InitializeComponent();
        }

        public string labelg;

        public void GetData()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT  Derector.DerectorId, Participant.ParticipantName, 'Director' as Title, EmailBank.Email, Participant.ContactNumber FROM  Participant LEFT JOIN Shareholder ON Participant.ParticipantId = Shareholder.ParticipantId  LEFT JOIN Derector ON Shareholder.ShareholderId = Derector.ShareholderId  LEFT JOIN EmailBank ON Participant.EmailBankId = EmailBank.EmailBankId where Derector.DateofRetirement is  null", con);

                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void GetAllDirector()
        {

            try
            {
                con = new SqlConnection(cs.DBConn);
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Derector.DerectorId, Participant.ParticipantName, Participant.FatherName, EmailBank.Email, Participant.ContactNumber FROM   Participant  LEFT JOIN EmailBank ON Participant.EmailBankId = EmailBank.EmailBankId  LEFT JOIN Shareholder ON Participant.ParticipantId = Shareholder.ParticipantId  LEFT JOIN Derector ON Shareholder.ShareholderId = Derector.ShareholderId", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.Rows.Clear();
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();
                    dataGridView1.Rows[n].Cells[4].Value = item[4].ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void DirectorResignationGrid_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void DirectorResignationGrid_FormClosed(object sender, FormClosedEventArgs e)
        {
                        this.Hide();
            BoardManagementUI frm=new BoardManagementUI();
                       frm.Show();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                DataGridViewRow dr = dataGridView1.CurrentRow;
                this.Hide();
                DirectorResignation frm = new DirectorResignation();
                frm.Show();
                frm.textDirectorId.Text = dr.Cells[0].Value.ToString();
                frm.textDirectorName.Text = dr.Cells[1].Value.ToString();                
                frm.labelk = labelg;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
