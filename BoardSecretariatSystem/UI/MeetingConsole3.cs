using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BoardSecretariatSystem.DBGateway;

namespace BoardSecretariatSystem.UI
{
    public partial class MeetingConsole3 : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        private SqlDataAdapter ada;
        private DataTable dt;
        public int participantId;

        public MeetingConsole3()
        {
            InitializeComponent();
        }

        private void MeetingConsole3_FormClosed(object sender, FormClosedEventArgs e)
        {
                           this.Hide();
            MeetingManagementUI frm =new MeetingManagementUI();
                            frm.Show();
        }

       
        private void SetExistingMeetingMemberInList()
        {
            listView1.View = View.Details;
            con = new SqlConnection(cs.DBConn);
            string qry = "SELECT Participant.ParticipantId As ParticipantId ,Participant.ParticipantName As ParticipantName, 'Chairman' As Title FROM  Chairman INNER JOIN Derector ON Chairman.DerectorId = Derector.DerectorId INNER JOIN Shareholder ON Derector.ShareholderId = Shareholder.ShareholderId INNER JOIN Participant ON Shareholder.ParticipantId = Participant.ParticipantId where Chairman.DateofRetirement is null Union SELECT  Participant.ParticipantId ,Participant.ParticipantName As ParticipantName, 'Managing Director' As Title FROM   MDerector INNER JOIN Derector ON MDerector.DerectorId = Derector.DerectorId INNER JOIN Shareholder ON Derector.ShareholderId = Shareholder.ShareholderId INNER JOIN Participant ON Shareholder.ParticipantId = Participant.ParticipantId where MDerector.DateofRetirement is null Union SELECT Participant.ParticipantId,Participant.ParticipantName As ParticipantName, 'Director' As Title FROM   Derector INNER JOIN Shareholder ON Derector.ShareholderId = Shareholder.ShareholderId INNER JOIN Participant ON Shareholder.ParticipantId = Participant.ParticipantId  where Participant.ParticipantId not in (SELECT Participant.ParticipantId FROM  Chairman INNER JOIN Derector ON Chairman.DerectorId = Derector.DerectorId INNER JOIN Shareholder ON Derector.ShareholderId = Shareholder.ShareholderId INNER JOIN Participant ON Shareholder.ParticipantId = Participant.ParticipantId where Chairman.DateofRetirement is null Union SELECT  Participant.ParticipantId  FROM   MDerector INNER JOIN Derector ON MDerector.DerectorId = Derector.DerectorId INNER JOIN Shareholder ON Derector.ShareholderId = Shareholder.ShareholderId INNER JOIN Participant ON Shareholder.ParticipantId = Participant.ParticipantId where MDerector.DateofRetirement is null)";
            ada = new SqlDataAdapter(qry, con);
            dt = new DataTable();
            ada.Fill(dt);

            for (int b = 0; b < dt.Rows.Count; b++)
            {
                DataRow dr = dt.Rows[b];
                ListViewItem listitem1 = new ListViewItem(dr[0].ToString());
                listitem1.SubItems.Add(dr[1].ToString());
                listitem1.SubItems.Add(dr[2].ToString());                           
                listView1.Items.Add(listitem1);
            }
        }
        public void GetAdditionalParticipant()
        {

            try
            {
                con = new SqlConnection(cs.DBConn);
                SqlDataAdapter sda = new SqlDataAdapter("SELECT  Participant.ParticipantId,Participant.ParticipantName, Participant.Designation FROM   Participant where  Participant.ParticipantId not in (Select Shareholder.ParticipantId from Shareholder)", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.Rows.Clear();
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                   dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                   // dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void MeetingConsole3_Load(object sender, EventArgs e)
        {
            buttonInvitation.Visible = false;
            SetExistingMeetingMemberInList();
            GetAdditionalParticipant();
        }

        private void buttonAdditionalParticipant_Click(object sender, EventArgs e)
        {
                           this.Hide();
            ParticipantCreation2 frm=new ParticipantCreation2();
                            frm.Show();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow dr = dataGridView1.SelectedRows[0];
                    participantId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    if (listView1.Items.Count == 0)
                    {
                        ListViewItem lst = new ListViewItem();
                        lst.Text = dr.Cells[0].Value.ToString();
                        lst.SubItems.Add(dr.Cells[1].Value.ToString());
                        lst.SubItems.Add(dr.Cells[2].Value.ToString());
                        lst.SubItems.Add(dr.Cells[3].Value.ToString());
                        lst.SubItems.Add(dr.Cells[4].Value.ToString());
                        listView1.Items.Add(lst);
                       // SaveSelectedAgenda();
                    }
                    else if (listView1.FindItemWithText(participantId.ToString()) == null)
                    {
                        ListViewItem lst1 = new ListViewItem();
                        lst1.Text = dr.Cells[0].Value.ToString();
                        lst1.SubItems.Add(dr.Cells[1].Value.ToString());
                        lst1.SubItems.Add(dr.Cells[2].Value.ToString());
                        lst1.SubItems.Add(dr.Cells[3].Value.ToString());
                        lst1.SubItems.Add(dr.Cells[4].Value.ToString());
                        listView1.Items.Add(lst1);
                      //  SaveSelectedAgenda();
                    }
                    else
                    {
                        MessageBox.Show("You Can Not Add Same Item More than one times", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("There is not any row selected, please select row and Click Add Button!");

            }              
        }

        private void buttonComplete_Click(object sender, EventArgs e)
        {
            buttonInvitation.Visible = true;
        }

        private void buttonInvitation_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("siddique_iceiu@yahoo.com");

                mail.From = new MailAddress("siddiqueiceiu@gmail.com");
                mail.To.Add("siddique_iceiu@yahoo.com");
                mail.Subject = "Test Mail";
                mail.Body = "This is for testing SMTP mail from GMAIL";

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("siddique_iceiu@yahoo.com", "a123456789a");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("mail Send");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
