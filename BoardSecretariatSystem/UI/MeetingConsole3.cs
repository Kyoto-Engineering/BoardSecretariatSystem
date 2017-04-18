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
        public int participantId, metingTypeId,meetingId;
        public int meetingNum, meetingNum1;

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
            string qry = "SELECT Participant.ParticipantId As ParticipantId ,Participant.ParticipantName As ParticipantName, 'Chairman' As Title FROM  Chairman INNER JOIN Derector ON Chairman.DerectorId = Derector.DerectorId INNER JOIN Shareholder ON Derector.ShareholderId = Shareholder.ShareholderId INNER JOIN Participant ON Shareholder.ParticipantId = Participant.ParticipantId where Chairman.DateofRetirement is null Union SELECT  Participant.ParticipantId ,Participant.ParticipantName As ParticipantName, 'Managing Director' As Title FROM  MDerector INNER JOIN Derector ON MDerector.DerectorId = Derector.DerectorId INNER JOIN Shareholder ON Derector.ShareholderId = Shareholder.ShareholderId INNER JOIN Participant ON Shareholder.ParticipantId = Participant.ParticipantId where MDerector.DateofRetirement is null Union SELECT Participant.ParticipantId,Participant.ParticipantName As ParticipantName, 'Director' As Title FROM   Derector INNER JOIN Shareholder ON Derector.ShareholderId = Shareholder.ShareholderId INNER JOIN Participant ON Shareholder.ParticipantId = Participant.ParticipantId  where Participant.ParticipantId not in (SELECT Participant.ParticipantId FROM  Chairman INNER JOIN Derector ON Chairman.DerectorId = Derector.DerectorId INNER JOIN Shareholder ON Derector.ShareholderId = Shareholder.ShareholderId INNER JOIN Participant ON Shareholder.ParticipantId = Participant.ParticipantId where Chairman.DateofRetirement is null Union SELECT  Participant.ParticipantId  FROM   MDerector INNER JOIN Derector ON MDerector.DerectorId = Derector.DerectorId INNER JOIN Shareholder ON Derector.ShareholderId = Shareholder.ShareholderId INNER JOIN Participant ON Shareholder.ParticipantId = Participant.ParticipantId where MDerector.DateofRetirement is null) Union (SELECT  Participant.ParticipantId, Participant.ParticipantName, Participant.Designation  FROM   Meeting INNER JOIN  MeetingParticipant ON Meeting.MeetingId = MeetingParticipant.MeetingId INNER JOIN Participant ON MeetingParticipant.ParticipantId = Participant.ParticipantId  where Participant.ParticipantId not in (Select Shareholder.ParticipantId from Shareholder))";
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
                        txtMeetingTitle.Text = Ordinal(meetingNum) + " Board Meeting";
                    }
                    else
                    {
                        MessageBox.Show("Please Create  or Shedule a meeting First.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }
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
            GetMeetingTitle();
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
                                MessageBox.Show("You Can Not Add Same Item More than one times", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }


                        }
                        ListViewItem lst1 = new ListViewItem();
                        lst1.Text = dr.Cells[0].Value.ToString();
                        lst1.SubItems.Add(dr.Cells[1].Value.ToString());
                        lst1.SubItems.Add(dr.Cells[2].Value.ToString());                       
                        listView1.Items.Add(lst1);                       
                        ClearApprovedRequisition();
                    }

                    if (listView1.Items.Count == 0)
                    {
                        ListViewItem lst = new ListViewItem();
                        lst.Text = dr.Cells[0].Value.ToString();
                        lst.SubItems.Add(dr.Cells[1].Value.ToString());
                        lst.SubItems.Add(dr.Cells[2].Value.ToString());                       
                        listView1.Items.Add(lst);                      
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
        private void buttonInvitation_Click(object sender, EventArgs e)
        {
            this.Hide();
            MailSend frm=new MailSend();
            GetMeetingId();
            frm.meetingId22 = meetingId;
            frm.meetingNo22 = meetingNum;
            frm.Show();                     
        }
    }
}
