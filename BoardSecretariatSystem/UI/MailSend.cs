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
        private SqlDataAdapter ada;
        private DataTable dt;
        public string userId, meetingName, meetingDate, meetingTime;
        public int metingTypeId;
        public Nullable<int> meetingNum, meetingNum1;
        public MailSend()
        {
            InitializeComponent();
        }
        private void NewMailMessage()
        {
            try
            {

                for (int i = 0; i <= listView1.Items.Count-1; i++)
                {
                    MailMessage msg = new MailMessage();
                    msg.From = new MailAddress(txtFrom.Text, "Kyoto Engineering & Automation Ltd");
                    msg.To.Add(new MailAddress(listView1.Items[i].SubItems[1].Text));
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

                        smtp.Host = "smtp.yandex.com";
                        smtp.Credentials = new NetworkCredential(txtFrom.Text, txtPassword.Text);
                        smtp.EnableSsl = true;
                        smtp.Send(msg);

                    }
                }
                MessageBox.Show("Mail Sending Successfully");
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
                string ctt = "SELECT  EmailBank.Email FROM  Registration INNER JOIN EmailBank ON Registration.EmailBankId = EmailBank.EmailBankId where Registration.UserId='"+userId+"'";
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

        private void GetBody()
        {
            //txtBody.Text = "Notice is hereby given to you that the '" + meetingName +
            //               "' of the Company will be held on '" + meetingDate + "' at '" + meetingTime +
            //               "' am in Register office, House-64, Road-03, Niketon, Gulshan, Gulshan, Dhaka: 1212";
            txtBody.Text = "Notice is hereby given to you that the 2nd Board Meeting of the Company will be held on 1st February, 2016 at 10:30 am in Register office, House-64, Road-03, Niketon, Gulshan, Gulshan, Dhaka: 1212";
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
                    string qr2 = "SELECT MAX(Meeting.MeetingNo) FROM Meeting where Meeting.MeetingTypeId='" + metingTypeId + "'";
                    cmd = new SqlCommand(qr2, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        meetingNum = (rdr.GetInt32(0));
                        meetingDate = (rdr.GetString(1));
                        if (meetingNum == 1)
                        {
                            meetingNum1 = meetingNum;
                            //txtMeetingNumber.Text = meetingNum1.ToString();
                            txtSubject.Text = "NOTICE FOR THE 1ST BOARD  MEETING";
                        }
                        else if (meetingNum == 2)
                        {
                            meetingNum1 = meetingNum;
                            //txtMeetingNumber.Text = meetingNum1.ToString();
                            txtSubject.Text = "NOTICE FOR THE 2ND BOARD  MEETING";
                        }

                        else if (meetingNum == 3)
                        {
                            meetingNum1 = meetingNum;
                           // txtMeetingNumber.Text = meetingNum1.ToString();
                            txtSubject.Text = "NOTICE FOR THE 3RD BOARD  MEETING";
                        }

                        else if (meetingNum >= 4)
                        {
                            meetingNum1 = meetingNum;
                          //  txtMeetingNumber.Text = meetingNum1.ToString();
                            txtSubject.Text = "NOTICE FOR THE" + meetingNum + "th BOARD  MEETING";
                        }

                    }
                }
                else
                {
                    MessageBox.Show("You need to Create or Schedule a new Meeting", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void ListOfRecepientEmailAddress()
        {
            listView1.View = View.Details;
            con = new SqlConnection(cs.DBConn);
            string qry = "SELECT Participant.ParticipantId,EmailBank.Email FROM  Participant INNER JOIN MeetingParticipant ON Participant.ParticipantId = MeetingParticipant.ParticipantId INNER JOIN EmailBank ON Participant.EmailBankId = EmailBank.EmailBankId";
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

        private int  GetForeach()
        {
            int[] intArray = {1,2,3,4,5,6,7,8,9};
            int[] k = { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            int[] sum = new int[10];
            int i = 0;
          foreach (int num in intArray)
          {
              sum[i] = num + k[i];
              i++;
          }
            return sum[i];
        }

        private void MailSend_Load(object sender, EventArgs e)
        {
           // GetForeach();
            GetBody();
            GetMeetingNumber();
            userId = frmLogin.uId.ToString();
            LoadSenderEmailAddress();
            ListOfRecepientEmailAddress();
        }

        private void txtFrom_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
