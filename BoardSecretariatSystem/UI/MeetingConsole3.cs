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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using BoardSecretariatSystem.DBGateway;
using BoardSecretariatSystem.Models;
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
        public int participantId, metingTypeId,meetingId,psid;
        public int meetingNum, meetingNum1;
        public List<string> emails=new List<string>(); 
        //public string emails;
        public string MailSubject,addHeader, hNo, rNo, area, thana, dist, division, dateValue, timeValue, meetingTitle,EmailBody,status;
        public DateTime dateTimeYears;
        private bool attendanceTaken;
        private bool agendaSelected;
        private bool invitationSend;
        private string _input=null;
        private DataGridViewRow _dataGridViewRow;
        private string username, designation, contact;
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
            string qry = "SELECT        Participant.ParticipantId, Participant.ParticipantName, MeetingParticipant.Title FROM  MeetingParticipant INNER JOIN Participant ON MeetingParticipant.ParticipantId = Participant.ParticipantId where MeetingId="+meetingId;
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
                SqlDataAdapter sda = new SqlDataAdapter("SELECT  Participant.ParticipantId,Participant.ParticipantName, Participant.Designation FROM   Participant where  Participant.ParticipantId not in (SELECT       ParticipantId FROM MeetingParticipant where MeetingId="+meetingId+")" ,con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.Rows.Clear();
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                   dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
       
        private void GetMeetingId()
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string query = "Select Meeting.MeetingId From Meeting where Meeting.MeetingNo='"+meetingNum+"'";
            cmd = new SqlCommand(query, con);
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                meetingId = (rdr.GetInt32(0));
            }
        }
       
        public static string Ordinal(int number)
        {
            string suffix = String.Empty;
            if (number == 11 || number == 12 || number == 13 || number % 100 == 11 || number % 100 == 12 || number % 100 == 13)
            {
                suffix = "th";
            }
            else if (number == 1 || number % 10 == 1)
            {
                suffix = "st";
            }
            else if (number == 2 || number % 10 == 2)
            {
                suffix = "nd";
            }
            else if (number == 3 || number % 10 == 3)
            {
                suffix = "rd";
            }
            else
            {
                suffix = "th";
            }
            return String.Format("{0}{1}", number, suffix);
        }
        private void GetMeetingTitle()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string qr2 = "SELECT MAX(Meeting.MeetingId),MAX(Meeting.MeetingNo) FROM Meeting";
                cmd = new SqlCommand(qr2, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if (!(rdr.IsDBNull(0)))
                    {
                        meetingId = (rdr.GetInt32(0));
                        meetingNum = (rdr.GetInt32(1));
                        txtMeetingNumber.Text = meetingNum.ToString();
                       meetingTitle= txtMeetingTitle.Text = Ordinal(meetingNum) + " Board Meeting";
                        MailSubject = "Notice for " + meetingTitle;
                    }
                    else
                    {
                        MessageBox.Show("Please Create  or Shedule a meeting First.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MeetingInfo()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "Select InvitationSend,Statuss, AttendenceTaken,AllAgendaSelected FROM Meeting where MeetingId=@d1";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@d1", meetingId);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                   
                    invitationSend = rdr.GetBoolean(0);
                    status = rdr.GetString(1);
                    attendanceTaken = rdr.GetBoolean(2);
                    agendaSelected = rdr.GetBoolean(3);


                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
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
            GetMeetingTitle();
            MeetingInfo();
            SetExistingMeetingMemberInList();
            GetAdditionalParticipant();
            
        }

        private void buttonAdditionalParticipant_Click(object sender, EventArgs e)
        {
                           
            ParticipantCreation2 frm=new ParticipantCreation2();
            this.Visible = false;
            frm.ShowDialog();
            dataGridView1.Rows.Clear();
            GetAdditionalParticipant();
            this.Visible = true;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
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
        private void SaveMeetingParticipant()
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string qry = "insert into MeetingParticipant(MeetingId,ParticipantId,Title) values (@d1,@d2,@d3)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@d1",meetingId);
            cmd.Parameters.AddWithValue("@d2",participantId);
            cmd.Parameters.AddWithValue("@d3", string.IsNullOrWhiteSpace(_dataGridViewRow.Cells[2].Value.ToString()) ? (object)DBNull.Value : _dataGridViewRow.Cells[2].Value.ToString());
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (dataGridView1.SelectedRows.Count > 0)
                {
                    _dataGridViewRow = dataGridView1.SelectedRows[0];
                    participantId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());

                    if (listView1.Items.Count > 0)
                    {
                        int x = listView1.Items.Count - 1;
                        for (int i = 0; i <= x; i++)
                        {
                            if (participantId == Convert.ToInt32(listView1.Items[i].SubItems[0].Text))
                            {
                                MessageBox.Show("You Can Not Add Same Item More than one times", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }


                        }
                        ListViewItem lst2 = new ListViewItem();
                        lst2.Text = _dataGridViewRow.Cells[0].Value.ToString();
                        lst2.SubItems.Add(_dataGridViewRow.Cells[1].Value.ToString());
                        lst2.SubItems.Add(_dataGridViewRow.Cells[2].Value.ToString());                       
                        listView1.Items.Add(lst2);
                        SaveMeetingParticipant();
                        ClearApprovedRequisition();
                    }

                    if (listView1.Items.Count == 0)
                    {
                        ListViewItem lst = new ListViewItem();
                        lst.Text = _dataGridViewRow.Cells[0].Value.ToString();
                        lst.SubItems.Add(_dataGridViewRow.Cells[1].Value.ToString());
                        lst.SubItems.Add(_dataGridViewRow.Cells[2].Value.ToString());                       
                        listView1.Items.Add(lst);
                        SaveMeetingParticipant();
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
            if (status!="Open")
            {
                MessageBox.Show("MEETING IS COMPLETED SORRY");
            }
            else if(attendanceTaken)
            {
                MessageBox.Show("attendance is Taken already");
            }
            else if (invitationSend)
            {
                MessageBox.Show("invitation send already");
            }
            else if (!agendaSelected)
            {
                MessageBox.Show("All Agenda Not Selected wait");
            }
            else
            {


                InputBoxValidation validation = delegate(string val)
                {
                    if (val == "")
                        return "Password cannot be empty.";

                    return "";
                };
              
                if (InputBox.Show("Give Password of Secretary Email", "Give Password", ref _input, validation) == DialogResult.OK)
                {
                    if (CheckForInternetConnection())
                    {
                        NewMailMessage();
                    }
                }
            }
        }
        private void SetRecepientMailAddress()
        {
            con = new SqlConnection(cs.DBConn);
            //string qry =
            //    "SELECT Distinct EmailBank.Email FROM  Participant INNER JOIN EmailBank ON Participant.EmailBankId = EmailBank.EmailBankId  INNER JOIN MeetingParticipant ON Participant.ParticipantId = MeetingParticipant.ParticipantId where MeetingParticipant.MeetingId=" + meetingId;

            string qry = "SELECT email FROM testmail";

            //ada = new SqlDataAdapter(qry, con);
            //dt = new DataTable();
            //ada.Fill(dt);
            con.Open();
            SqlCommand sql = new SqlCommand(qry, con);
            rdr = sql.ExecuteReader();
            while (rdr.Read())
            {
                emails.Add(rdr.GetString(0));
            }

            //emails = "iqbalbdrocky@gmail.com";

        }
        private void GetBody()
        {
            
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string query = "Select MeetingDate From Meeting where Meeting.MeetingId=@d1";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@d1", meetingId);
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                dateTimeYears = (rdr.GetDateTime(0));
            }

            //dateValue = dateTimeYears.ToString("dddd, MMMMM, yyyy");
            dateValue = dateTimeYears.ToString("dddd, MMMM-dd, yyyy ");
            timeValue = dateTimeYears.ToString("hh:mm tt");
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string query2 =
                "SELECT  AddressHeader.AHeaderName, CompanyAddresses.Address  FROM   Meeting INNER JOIN AddressHeader ON Meeting.AHeaderId = AddressHeader.AHeaderId INNER JOIN CompanyAddresses ON AddressHeader.AHeaderId = CompanyAddresses.AHeaderId where Meeting.MeetingId='" +
                meetingId + "' ";
            cmd = new SqlCommand(query2, con);
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                addHeader = (rdr.GetString(0));
                hNo = (rdr.GetString(1));
            }

            con = new SqlConnection(cs.DBConn);
            con.Open();
            string Qqry = "SELECT Registration.Name, Registration.Designation, Registration.ContactNo FROM Registration INNER JOIN Meeting ON Meeting.UserId = Registration.UserId  where Meeting.MeetingId='" +
                meetingId + "' "; 
            cmd = new SqlCommand(Qqry, con);
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {

                username =(rdr.GetString(0));  
                designation = (rdr.GetString(1));
                contact = (rdr.GetString(2));
            }



            EmailBody = "Dear Patron,<br/><br/>Notice is hereby given to you that the " + meetingTitle + " of the Company will be held on " +
                           dateValue + " at " + timeValue + " in " + addHeader + ", " + hNo + ".<br/><br/>Best Regards<br/>" + username + "<br/>" + designation + "<br/>" + contact + " ";

        }
        private void NewMailMessage()
        {
           
            GetBody();
            SetRecepientMailAddress();
            if (MailSendAndValidate())
            {
                UpdateMeeting();
                MessageBox.Show("Participant Saving Complete");
            }

        }

        private bool MailSendAndValidate()
        {
            bool validate;
            try
            {
                for (int i = 0; i <= emails.Count - 1; i++)
                {
                    MailMessage msg = new MailMessage();
                    msg.From = new MailAddress("secretary@keal.com.bd", "Kyoto Engineering & Automation Ltd");
                    msg.To.Add(new MailAddress(emails[i]));
                    msg.Subject = MailSubject;
                    msg.Body = EmailBody;
                    msg.IsBodyHtml = true;
                    if ((EmailBody.Length) > 0)
                    {
                        if (System.IO.File.Exists(EmailBody))
                        {
                            msg.Attachments.Add(new Attachment(EmailBody));
                        }
                        SmtpClient smtp = new SmtpClient();

                        smtp.Host = "smtp.yandex.com";
                        smtp.Credentials = new NetworkCredential("secretary@keal.com.bd", _input);
                        smtp.EnableSsl = true;
                        smtp.Send(msg);
                    }
                }
                MessageBox.Show("Mail Sending Successfully");
                validate = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                validate = false;
            }
            return validate;
        }

        private void UpdateMeeting()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "UPDATE Meeting SET InvitationSend =1 where MeetingId=@mid";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@mid", meetingId);
                cmd.ExecuteNonQuery();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                MessageBox.Show(@"There Is  No Internet Connectivity Now." + "\n" + @"Please Try Later", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void sendButton_Click(object sender, EventArgs e)
        {
           


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
        private void buttonInvitation_Click(object sender, EventArgs e)
        {
            this.Hide();
            MailSend frm=new MailSend();
            GetMeetingId();
            frm.meetingId22 = meetingId;
            frm.meetingNo22 = meetingNum;
            frm.Show();                     
        }

        private void txtMeetingNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMeetingTitle.Focus();
                e.Handled = true;
            }
        }

        private void txtMeetingTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonAdditionalParticipant.Focus();
                e.Handled = true;
            }
        }

        private void buttonAdditionalParticipant_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addButton.Focus();
                e.Handled = true;
            }
        }

        private void addButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonComplete.Focus();
                e.Handled = true;
            }
        }

        private void buttonComplete_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonInvitation.Focus();
                e.Handled = true;
            }
        }
    }
}
