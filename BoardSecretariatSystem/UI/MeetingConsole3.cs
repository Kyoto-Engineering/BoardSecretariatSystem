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
using System.Windows;
using System.Windows.Forms;
using BoardSecretariatSystem.DBGateway;
using MessageBox = System.Windows.Forms.MessageBox;

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
        public int participantId, metingTypeId;
        public Nullable<int> meetingNum, meetingNum1;

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
        //private void GetMeetingTitle()
        //{
        //    try
        //    {
        //        con = new SqlConnection(cs.DBConn);
        //        con.Open();
        //        string ctt = "SELECT IDENT_CURRENT ('Meeting')";
        //        cmd = new SqlCommand(ctt);
        //        cmd.Connection = con;
        //        rdr = cmd.ExecuteReader();
        //        if (rdr.Read())
        //        {
        //            aId = (rdr.GetDecimal(0));
        //            if (aId == 1)
        //            {
        //                txtMeetingNumber.Text = "1";
        //                txtMeetingTitle.Text = "1st Board Meeting";
        //            }
        //            else if (aId == 2)
        //            {
        //                txtMeetingNumber.Text = "2";
        //                txtMeetingTitle.Text = "2nd Board Meeting";
        //            }
        //            else if (aId == 3)
        //            {
        //                txtMeetingNumber.Text = "3";
        //                txtMeetingTitle.Text = "3rd Board Meeting";
        //            }
        //            else if (aId == 4)
        //            {
        //                txtMeetingNumber.Text = "4";
        //                txtMeetingTitle.Text = "4rth Board Meeting";
        //            }

        //            else if (aId >= 5)
        //            {
        //                txtMeetingNumber.Text = aId.ToString();
        //                txtMeetingTitle.Text = aId + "th Board Meeting";
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

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
                        if (meetingNum == 1)
                        {
                            meetingNum1 = meetingNum;
                            txtMeetingNumber.Text = meetingNum1.ToString();
                            txtMeetingTitle.Text = "1st Board Meeting";
                        }
                        else if (meetingNum == 2)
                        {
                            meetingNum1 = meetingNum;
                            txtMeetingNumber.Text = meetingNum1.ToString();
                            txtMeetingTitle.Text = "2nd Board Meeting";
                        }

                        else if (meetingNum == 3)
                        {
                            meetingNum1 = meetingNum;
                            txtMeetingNumber.Text = meetingNum1.ToString();
                           txtMeetingTitle.Text = "3rd Board Meeting";
                        }

                        else if (meetingNum >= 4)
                        {
                            meetingNum1 = meetingNum;
                            txtMeetingNumber.Text = meetingNum1.ToString();
                            txtMeetingTitle.Text = meetingNum + "th Board Meeting";
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
        private void MeetingConsole3_Load(object sender, EventArgs e)
        {
            buttonInvitation.Visible = false;
            SetExistingMeetingMemberInList();
            GetAdditionalParticipant();
            GetMeetingNumber();
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
        //private void SaveSelectedParticipant()
        //{
        //    try
        //    {
        //        for (int i=0; i <= listView1.Items.Count-1; i++)
        //        {
        //            con = new SqlConnection(cs.DBConn);
        //            con.Open();
        //            string query2 = "insert into MeetingParticipant(MeetingId,ParticipantId,Title) values (@d1,@d2,@d3)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
        //            cmd = new SqlCommand(query2, con);
        //            cmd.Parameters.AddWithValue("@d1", txtMeetingNumber.Text);
        //            cmd.Parameters.AddWithValue("@d2", dr.Cells[1].Value.ToString());
        //            cmd.Parameters.AddWithValue("@d3", listView1.Items[i].SubItems[2].Text);
        //            cmd.ExecuteNonQuery();                    
        //            con.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        public void ClearApprovedRequisition()
        {

            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {


                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                }

            }
            dataGridView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow dr = dataGridView1.SelectedRows[0];
                    participantId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());

                    if (listView1.Items.Count > 0)
                    {
                        int x = listView1.Items.Count - 1;
                        for (int i = 0; i <= x; i++)
                        {
                            if (participantId == Convert.ToInt32(listView1.Items[i].SubItems[0].Text))
                            {
                                MessageBox.Show("This Participant already exist in the list.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }


                        }
                        ListViewItem lst1 = new ListViewItem();
                        lst1.Text = dr.Cells[0].Value.ToString();
                        lst1.SubItems.Add(dr.Cells[1].Value.ToString());
                        lst1.SubItems.Add(dr.Cells[2].Value.ToString());
                        lst1.SubItems.Add(dr.Cells[3].Value.ToString());
                        //lst1.SubItems.Add(dr.Cells[4].Value.ToString());
                        listView1.Items.Add(lst1);

                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string query2 = "insert into MeetingParticipant(MeetingId,ParticipantId,Title) values (@d1,@d2,@d3)";
                        cmd = new SqlCommand(query2, con);
                        cmd.Parameters.AddWithValue("@d1", txtMeetingNumber.Text);
                        cmd.Parameters.AddWithValue("@d2", dr.Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("@d3", dr.Cells[3].Value.ToString());
                        cmd.ExecuteNonQuery();
                        con.Close();

                        ClearApprovedRequisition();

                    }

                    if (listView1.Items.Count == 0)
                    {
                        ListViewItem lst = new ListViewItem();
                        lst.Text = dr.Cells[0].Value.ToString();
                        lst.SubItems.Add(dr.Cells[1].Value.ToString());
                        lst.SubItems.Add(dr.Cells[2].Value.ToString());
                        lst.SubItems.Add(dr.Cells[3].Value.ToString());
                        //lst.SubItems.Add(dr.Cells[4].Value.ToString());
                        listView1.Items.Add(lst);

                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string query2 = "insert into MeetingParticipant(MeetingId,ParticipantId,Title) values (@d1,@d2,@d3)";
                        cmd = new SqlCommand(query2, con);
                        cmd.Parameters.AddWithValue("@d1", txtMeetingNumber.Text);
                        cmd.Parameters.AddWithValue("@d2", dr.Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("@d3", dr.Cells[3].Value.ToString());
                        cmd.ExecuteNonQuery();
                        con.Close();
                        ClearApprovedRequisition();
                    }
                }
                else
                {
                    MessageBox.Show("There is not any row selected, please select row and Click Add Button!");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonComplete_Click(object sender, EventArgs e)
        {
            buttonInvitation.Visible = true;
        }



        protected void SendEmail(string _subject, MailAddress _from, MailAddress _to, List<MailAddress> _cc, List<MailAddress> _bcc = null)
             {
        string Text = "";
        SmtpClient mailClient = new SmtpClient("Mailhost");
        MailMessage msgMail;
                 Text = "Stuff";
        msgMail = new MailMessage();
        msgMail.From = _from;
        msgMail.To.Add(_to);
        foreach (MailAddress addr in _cc)
        {
            msgMail.CC.Add(addr);
        }
        if (_bcc != null)
        {
            foreach (MailAddress addr in _bcc)
            {
                msgMail.Bcc.Add(addr);
            }
        }
        msgMail.Subject = _subject;
        msgMail.Body = Text;
        msgMail.IsBodyHtml = true;
        mailClient.Send(msgMail);
        msgMail.Dispose();
    }


        private void buttonInvitation_Click(object sender, RoutedEventArgs e)
        {
            MailAddress from = new MailAddress("it@keal.com.bd", "Kyoto");
            MailAddress to = new MailAddress("siddiqueiceiu@gmail.com", "AshrafSiddik");
            List<MailAddress> cc = new List<MailAddress>();
            cc.Add(new MailAddress("siddiqueiciu@gmail.com", "Siddik"));
            SendEmail("Want to test this damn thing", from, to, cc);



            //try
            //{
            //    MailMessage mail = new MailMessage();
            //    SmtpClient SmtpServer = new SmtpClient("siddique_iceiu@yahoo.com");

            //    mail.From = new MailAddress("siddiqueiceiu@gmail.com");
            //    mail.To.Add("siddique_iceiu@yahoo.com");
            //    mail.Subject = "Test Mail";
            //    mail.Body = "This is for testing SMTP mail from GMAIL";

            //    SmtpServer.Port = 587;
            //    SmtpServer.Credentials = new System.Net.NetworkCredential("siddique_iceiu@yahoo.com", "a123456789a");
            //    SmtpServer.EnableSsl = true;

            //    SmtpServer.Send(mail);
            //    MessageBox.Show("mail Send");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
        }

        private void NewMailMessage()
        {
            //try
            //{
            //    MailMessage msg = new MailMessage();
            //    msg.From = new MailAddress(fromMailTextBox.Text, "gethealthTips");
            //    msg.To.Add(new MailAddress(toTextBox.Text));
            //    msg.Subject = subjectTextBox.Text;
            //    msg.Body = listBox1.Text;
            //    msg.IsBodyHtml = true;
            //    if ((labelpath.Text.Length) > 0)
            //    {
            //        if (System.IO.File.Exists(labelpath.Text))
            //        {
            //            msg.Attachments.Add(new Attachment(labelpath.Text));
            //        }
            //        SmtpClient smtp = new SmtpClient();
            //        smtp.Host = "smtp.gmail.com";
            //        smtp.Credentials = new NetworkCredential(fromMailTextBox.Text, passwordTextBox.Text);
            //        smtp.EnableSsl = true;
            //        smtp.Send(msg);
            //        MessageBox.Show("Mail Sending Successfully");
            //    }
            //}

            //catch
            //{
            //    MessageBox.Show("Please check your UserName & Password");
            //}
        }
        private void buttonInvitation_Click(object sender, EventArgs e)
        {
            this.Hide();
            MailSend frm=new MailSend();
            frm.Show();
            //MailAddress from = new MailAddress("it@keal.com.bd", "Kyoto");
            //MailAddress to = new MailAddress("siddiqueiceiu@gmail.com", "AshrafSiddik");
            //List<MailAddress> cc = new List<MailAddress>();
            //cc.Add(new MailAddress("siddiqueiciu@gmail.com", "Siddik"));
            //SendEmail("Want to test this damn thing", from, to, cc);
        }

        private void saveAllButton_Click(object sender, EventArgs e)
        {

        }
    }
}
