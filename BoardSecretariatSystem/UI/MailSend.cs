using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BoardSecretariatSystem.DBGateway;

namespace BoardSecretariatSystem.UI
{
    public partial class MailSend : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        private ConnectionString cs = new ConnectionString();
        public string userId, hostName;
        public int metingTypeId;
        public Nullable<int> meetingNum, meetingNum1;
        public SqlDataAdapter ada;
        private DataTable dt;

        public MailSend()
        {
            InitializeComponent();
        }

        private void NewMailMessage()
        {
            try
            {
                for (int i = 0; i <= listView1.Items.Count - 1; i++)
                {
                    MailMessage msg = new MailMessage();
                    msg.From = new MailAddress(txtFrom.Text, "Kyoto Engineering & Automation Ltd");
                    msg.To.Add(new MailAddress(listView1.Items[i].SubItems[2].Text));
                    msg.Subject = txtSubject.Text;
                    msg.Body = txtBody.Text;
                    msg.IsBodyHtml = true;
                    if ((txtBody.Text.Length) > 0)
                    {
                        if (System.IO.File.Exists(txtBody.Text))
                        {
                            msg.Attachments.Add(new Attachment(txtBody.Text));
                        }
                        SmtpClient smtp = new SmtpClient();

                        smtp.Host = hostName;
                        smtp.Credentials = new NetworkCredential(txtFrom.Text, txtPassword.Text);
                        smtp.EnableSsl = true;
                        smtp.Send(msg);
                        MessageBox.Show("Mail Sending Successfully");
                    }
                }
            }

            catch
            {
                MessageBox.Show("Please check your UserName & Password");
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            NewMailMessage();
        }

        private void MailSend_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MeetingConsole3 frm = new MeetingConsole3();
            frm.Show();
        }

        private void LoadSenderEmailAddress()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctt =
                    "SELECT  EmailBank.Email FROM  Registration INNER JOIN EmailBank ON Registration.EmailBankId = EmailBank.EmailBankId where Registration.UserId='" +
                    userId + "'";
                cmd = new SqlCommand(ctt);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtFrom.Text = (rdr.GetString(0));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetMailHost()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "SELECT HostName FROM  MailHost order by MailHost.MailHostId desc";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbDomainHostName.Items.Add(rdr[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void GetMeetingNumber()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "Select MeetingTypeId From Meeting where MeetingTypeId=1";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    metingTypeId = (rdr.GetInt32(0));
                }

                if (metingTypeId == 1)
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string qr2 = "SELECT MAX(Meeting.MeetingNo) FROM Meeting where Meeting.MeetingTypeId='" +
                                 metingTypeId + "'";
                    cmd = new SqlCommand(qr2, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        meetingNum = (rdr.GetInt32(0));
                        if (meetingNum == 1)
                        {
                            meetingNum1 = meetingNum;
                            //txtMeetingNumber.Text = meetingNum1.ToString();
                            txtSubject.Text = "Notice for 1st Board Meeting";
                        }
                        else if (meetingNum == 2)
                        {
                            meetingNum1 = meetingNum;
                            //txtMeetingNumber.Text = meetingNum1.ToString();
                            txtSubject.Text = "Notice for 2nd Board Meeting";
                        }

                        else if (meetingNum == 3)
                        {
                            meetingNum1 = meetingNum;
                            // txtMeetingNumber.Text = meetingNum1.ToString();
                            txtSubject.Text = "Notice for 3rd Board Meeting";
                        }

                        else if (meetingNum >= 4)
                        {
                            meetingNum1 = meetingNum;
                            //  txtMeetingNumber.Text = meetingNum1.ToString();
                            txtSubject.Text = "Notice for" + meetingNum + "th Board Meeting";
                        }

                    }
                }
                else
                {
                    MessageBox.Show("You need to Create or Schedule a new Meeting", "error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    //meetingNum1 = meetingNum;
                    //txtMeetingNumber.Text = meetingNum1.ToString();
                    //txtMeetingTitle.Text = "1st Board Meeting";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetRecepientMailAddress()
        {
            listView1.View = View.Details;
            con = new SqlConnection(cs.DBConn);
            string qry ="SELECT  Participant.EmailBankId,EmailBank.Email FROM  Participant INNER JOIN EmailBank ON Participant.EmailBankId = EmailBank.EmailBankId  INNER JOIN MeetingParticipant ON Participant.ParticipantId = MeetingParticipant.ParticipantId";
            ada = new SqlDataAdapter(qry, con);
            dt = new DataTable();
            ada.Fill(dt);

            for (int b = 0; b < dt.Rows.Count; b++)
            {
                DataRow dr = dt.Rows[b];
                ListViewItem listitem1 = new ListViewItem(dr[0].ToString());
                listitem1.SubItems.Add(dr[1].ToString());
                //listitem1.SubItems.Add(dr[2].ToString());               
                listView1.Items.Add(listitem1);
            }
        }

        private void MailSend_Load(object sender, EventArgs e)
        {
            GetMailHost();
            GetMeetingNumber();
            userId = frmLogin.uId.ToString();
            LoadSenderEmailAddress();
            SetRecepientMailAddress();
        }

        private void txtFrom_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbDomainHostName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDomainHostName.Text == "Yandex")
            {
                hostName = "smtp.yandex.com";
            }
            if (cmbDomainHostName.Text == "Gmail")
            {
                hostName = "smtp.gmail.com";
            }
            if (cmbDomainHostName.Text == "Yahoo")

                hostName = "smtp.yahoo.com";
        }
    }
}


