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
    public partial class ShareHolderGrid : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        public ShareHolderGrid()
        {
            InitializeComponent();
        }

        public void GetData()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd =
                    new SqlCommand(
                        "SELECT Shareholder.ShareHolderName, EmailBank.Email, Participant.ContactNumber FROM Shareholder INNER JOIN Participant ON Shareholder.ParticipantId = Participant.ParticipantId INNER JOIN EmailBank ON Participant.EmailBankId = EmailBank.EmailBankId",
                        con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                shareHolderDataGridView.Rows.Clear();
                while (rdr.Read() == true)
                {
                    shareHolderDataGridView.Rows.Add(rdr[0], rdr[1], rdr[2]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void shareHolderDataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = shareHolderDataGridView.SelectedRows[0];

                this.Dispose();
                ShareTransferUI frm = new ShareTransferUI();
                frm.Show();
                frm.fromNametextBox.Text = dr.Cells[0].Value.ToString();
                frm.fromEmailtextBox.Text = dr.Cells[1].Value.ToString();
                frm.fromContacttextBox.Text = dr.Cells[2].Value.ToString();
                //frm.BrandcomboBox.Enabled = true;
                //frm.txtOProductId.Enabled = false;
                //frm.txtOSProductName.Enabled = false;
                //frm.groupBox3.Enabled = false;
                //frm.groupBox2.Enabled = false;
                //frm.groupBox7.Enabled = false;
                //frm.dateTimePicker1.Focus();
                //frm.txtAttention.Focus();
                // this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShareHolderGrid_Load(object sender, EventArgs e)
        {
            GetData();
        }


    }
}
