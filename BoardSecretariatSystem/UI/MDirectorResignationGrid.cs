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
    public partial class MDirectorResignationGrid : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        public string labelk;
        public MDirectorResignationGrid()
        {
            InitializeComponent();
        }

        public void GetData()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT  MDerector.MDerectorId, Participant.ParticipantName, 'Managing Director' as Title, EmailBank.Email FROM   Participant INNER JOIN Shareholder ON Participant.ParticipantId = Shareholder.ParticipantId INNER JOIN Derector ON Shareholder.ShareholderId = Derector.ShareholderId INNER JOIN  MDerector ON Derector.DerectorId = MDerector.DerectorId INNER JOIN  EmailBank ON Participant.EmailBankId = EmailBank.EmailBankId  where MDerector.DateofRetirement is null", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MDirectorResignationGrid_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                DataGridViewRow dr = dataGridView1.CurrentRow;
                this.Hide();
                MDirectorResignation frm = new MDirectorResignation();
                frm.Show();
                frm.txtManagingDirectorId.Text = dr.Cells[0].Value.ToString();
                frm.txtManagingDirectorName.Text = dr.Cells[1].Value.ToString();
                frm.labelg = labelk;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MDirectorResignationGrid_FormClosed(object sender, FormClosedEventArgs e)
        {
                       this.Hide();
            BoardManagementUI frm=new BoardManagementUI();
                       frm.Show();
        }
    }
}
