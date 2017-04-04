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
    public partial class ListofDirector2 : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public string labelg;
        public ListofDirector2()
        {
            InitializeComponent();
        }

        public void GetAllDirector()
        {

            try
            {
                con = new SqlConnection(cs.DBConn);
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Participant.ParticipantName, Participant.FatherName, EmailBank.Email, Participant.ContactNumber FROM   Participant  INNER JOIN EmailBank ON Participant.EmailBankId = EmailBank.EmailBankId  INNER JOIN Shareholder ON Participant.ParticipantId = Shareholder.ParticipantId   INNER JOIN Derector ON Shareholder.ShareholderId = Derector.ShareholderId  where Derector.DerectorId not in (Select MDerector.DerectorId from MDerector) and Derector.DerectorId not in (Select Chairman.DerectorId from Chairman)", con);
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

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void ListofDirector2_Load(object sender, EventArgs e)
        {
            GetAllDirector();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                DataGridViewRow dr = dataGridView1.CurrentRow;
                this.Hide();
                Chairman frm = new Chairman();
                frm.Show();
                frm.txtChairmanName.Text = dr.Cells[0].Value.ToString();
                frm.labelk = labelg;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ListofDirector2_FormClosed(object sender, FormClosedEventArgs e)
        {
                    this.Hide();
            BoardManagementUI frm=new BoardManagementUI();
                    frm.Show();
        }
    }
}
