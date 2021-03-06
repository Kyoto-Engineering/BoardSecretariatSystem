﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BoardSecretariatSystem.DBGateway;
using BoardSecretariatSystem.Models;
using BoardSecretariatSystem.Reports;

namespace BoardSecretariatSystem.UI
{
    public partial class MeetingConsole4 : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        private ConnectionString cs = new ConnectionString();
        private int meetingId, meetingNo, agendaId = 0;
        private int postponeid,psid ;
        public DateTime dateTimeYears;
        public List<string> emails = new List<string>();
        private bool invitationSend, attendanceTaken,agendaSelected;
        public string MailSubject, addHeader, hNo, rNo, area, thana, dist, division, dateValue, timeValue, meetingTitle, EmailBody, status, _input=null;
        public MeetingConsole4()
        {
            InitializeComponent();
            List<Employee2> employees = new List<Employee2>();
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand(" SELECT        Participant.ParticipantName, MeetingParticipant.Title, Participant.ParticipantId FROM            MeetingParticipant INNER JOIN Participant ON MeetingParticipant.ParticipantId = Participant.ParticipantId INNER JOIN Meeting ON MeetingParticipant.MeetingId = Meeting.MeetingId where Meeting.Statuss='Open'", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (rdr.Read() == true)
                {
                    employees.Add(new Employee2() { Name = rdr[0].ToString(), Title = rdr[1].ToString(), Id = rdr[2].ToString()});
                   
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

      
            this.comboBoxWithGrid_WinformsHost1.Employee2s = employees;

        }

        private void MeetingConsole4_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();

            //MeetingManagementUI frm = new MeetingManagementUI();

            //frm.Show();
        }
        private void MeetingInfo()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "SELECT MeetingId, MeetingNo, InvitationSend, AttendenceTaken,AllAgendaSelected FROM Meeting where Statuss='Open' and MeetingTypeId=1";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    meetingId = Convert.ToInt32(rdr["MeetingId"]);
                    meetingNo = Convert.ToInt32(rdr["MeetingNo"]);
                    invitationSend = rdr.GetBoolean(2);
                    attendanceTaken = rdr.GetBoolean(3);
                    agendaSelected = rdr.GetBoolean(4);

                    con.Close();
                }

                else
                {
                    MessageBox.Show("No Meeting Is Available For This Perpose");
                    con.Close();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public static string Ordinal(int number)
        {
            string suffix = String.Empty;
            if (number == 11 || number == 12 || number == 13 || number%100 == 11 || number%100 == 12 || number%100 == 13)
            {
                suffix = "th";
            }
            else if (number == 1 || number % 10 == 1 )
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
        private void LoadUI()
        {
            meetingNumIDTextBox.Text = Ordinal(meetingNo) + " Board Meeting";
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT  Participant.ParticipantName, MeetingParticipant.Title   FROM            MeetingParticipant INNER JOIN Participant ON MeetingParticipant.ParticipantId = Participant.ParticipantId INNER JOIN Meeting on  MeetingParticipant.MeetingId = Meeting.MeetingId where Meeting.Statuss ='Open'", con);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cancelationNoticeDataGridView.Rows.Add(rdr[0], rdr[1]);
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

        private void MeetingConsole4_Load(object sender, EventArgs e)
        {
            MeetingInfo();
            LoadUI();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (ValidationChecking())
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
                    else
                    {
                        _input = null;
                    }
                }
               
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
        private void SetRecepientMailAddress()
        {
           
            con = new SqlConnection(cs.DBConn);
            string qry =
                "SELECT distinct EmailBank.Email, MeetingParticipant.MeetingId FROM MeetingParticipant INNER JOIN Participant ON MeetingParticipant.ParticipantId = Participant.ParticipantId INNER JOIN EmailBank ON Participant.EmailBankId = EmailBank.EmailBankId WHERE MeetingParticipant.MeetingId =" + meetingId;
            con.Open();
            SqlCommand sql = new SqlCommand(qry, con);
            rdr = sql.ExecuteReader();
            while (rdr.Read())
            {
                emails.Add(rdr.GetString(0));
            }

        }
        private void NewMailMessage()
        {
            
            GetBody();
            SetRecepientMailAddress();
            if (MailSendAndValidate())
            {
                SavePostPone();
                Notice();
                DeleteXtraParticipants();
                UpdateMeeting();
                MessageBox.Show("Posteponed Succesfully");
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
                _input = null;
            }
            return validate;
        }
        private void GetBody()
        {
            EmailBody = "Dear<br>Notice is hereby given to you that the " + meetingNumIDTextBox.Text +
                        " of the Company is Postponed for \"" + reasonForCancelRichTextBox.Text +
                        "\". <br> Probable Meeting Time is is " + probableNextMeetingDateTimePicker.Text+"<br>Ordered By<br>"+comboBoxWithGrid_WinformsHost1.SelectedItem.Name+"<br>"+comboBoxWithGrid_WinformsHost1.SelectedItem.Title;
            MailSubject = "Postpone Notice for" + meetingNumIDTextBox.Text;
        }

        private void SavePostPone()
        {
            try
            {

                int orderbyid = int.Parse(comboBoxWithGrid_WinformsHost1.SelectedItem.Id);
            con = new SqlConnection(cs.DBConn); 
            con.Open();
            string query2 = "INSERT INTO PostPoned(MeetingId,Cause,Dates,OrderById) values(@MID,@Cause,@d,@Oid)" +
                            "SELECT CONVERT(int, SCOPE_IDENTITY())";
            cmd = new SqlCommand(query2, con);
            cmd.Parameters.AddWithValue("@MID", meetingId);
            cmd.Parameters.AddWithValue("@Cause",reasonForCancelRichTextBox.Text);
            cmd.Parameters.AddWithValue("@d",DateTime.UtcNow.ToLocalTime() );
            cmd.Parameters.AddWithValue("@Oid", orderbyid);
            postponeid= (int)cmd.ExecuteScalar();
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

        private void Notice()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "INSERT INTO PostPonedReceiver            (PostPonedId           ,ParticipantId)       SELECT "+postponeid+" ,    MeetingParticipant.ParticipantId FROM            MeetingParticipant INNER JOIN Meeting ON MeetingParticipant.MeetingId = Meeting.MeetingId where Meeting.Statuss='Open'";
                cmd =new SqlCommand(query,con);
                cmd.ExecuteNonQuery();
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

        private void UpdateMeeting(){
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "Update            Meeting set MeetingDate=@d ,InvitationSend=@inv,AllAgendaSelected=@all where  MeetingId=@id";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@d",
                    Convert.ToDateTime(probableNextMeetingDateTimePicker.Value,
                        System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat));
                cmd.Parameters.AddWithValue("@inv",0);
                cmd.Parameters.AddWithValue("@all", 0);
                cmd.Parameters.AddWithValue("@id", meetingId);
                cmd.ExecuteNonQuery();
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
        private void DeleteXtraParticipants()
        
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query =
                    "Delete MeetingParticipant from MeetingParticipant inner join Meeting on MeetingParticipant.MeetingId=Meeting.MeetingId where  ParticipantId in( SELECT        Participant.ParticipantId FROM            MeetingParticipant INNER JOIN                         Participant ON MeetingParticipant.ParticipantId = Participant.ParticipantId INNER JOIN                         Meeting ON MeetingParticipant.MeetingId = Meeting.MeetingId where Meeting.Statuss='Open' and Participant.ParticipantId not in (SELECT        Participant.ParticipantId FROM            Participant INNER JOIN                         Shareholder ON Participant.ParticipantId = Shareholder.ParticipantId INNER JOIN                         Derector ON Shareholder.ShareholderId = Derector.ShareholderId where Derector.DateofRetirement is  null)) and Meeting.Statuss='Open'";
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
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

        private bool ValidationChecking()
        {
            bool validity=true;
            if (string.IsNullOrWhiteSpace(reasonForCancelRichTextBox.Text))
            {
                MessageBox.Show("Give A cause to postpone");
                validity = false;
            }
            else if (comboBoxWithGrid_WinformsHost1.SelectedItem == null)
            {
                MessageBox.Show("Select Order by first");
                validity = false;
            }
            else if (!invitationSend)
            {
                MessageBox.Show("You Can not Postpone this meeting . Invitation not send yet");
                validity= false;
            }
            else if (attendanceTaken)
            {
                MessageBox.Show("You Can not Postpone this meeting. Atendance already taken ");
                validity = false;
            }
            return validity;
        }

        private void meetingNumIDTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                reasonForCancelRichTextBox.Focus();
                e.Handled = true;
            }
        }

        private void reasonForCancelRichTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                probableNextMeetingDateTimePicker.Focus();
                e.Handled = true;
            }
        }

        private void probableNextMeetingDateTimePicker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cancelButton.Focus();
                e.Handled = true;
            }
        }

        private void cancelButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sendNoticeButton.Focus();
                e.Handled = true;
            }
        }

        private void sendNoticeButton_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
