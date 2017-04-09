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
    public partial class MeetingConsole7UI : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        private ConnectionString cs = new ConnectionString();
        private int meetingId, meetingNo, agendaId = 0;
        private int postponeid;
        private bool invitationSend, attendanceTaken, agendaSelected, attendancecompleted;
        public MeetingConsole7UI()
        {
            InitializeComponent();
        }

        private void MeetingConsole7UI_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MeetingManagementUI frm = new MeetingManagementUI();
            frm.Show();
        }


        private void MeetingInfo()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "SELECT MeetingId, MeetingNo, InvitationSend, AttendenceTaken,AttendanceCompleted FROM Meeting where Statuss='Open' and MeetingTypeId=1";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    meetingId = Convert.ToInt32(rdr["MeetingId"]);
                    meetingNo = Convert.ToInt32(rdr["MeetingNo"]);
                    invitationSend = rdr.GetBoolean(2);
                    attendanceTaken = rdr.GetBoolean(3);
                    attendancecompleted = rdr.GetBoolean(4);


                }
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
        private void LoadUI()
        {
            meetingNumOrIDTextBox.Text = Ordinal(meetingNo) + @" Board Meeting";
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT MeetingMinutes.AgendaSerialForMeeting, Agenda.AgendaTitle, MeetingMinutes.Resolution FROM Agenda INNER JOIN AgendaTypes ON Agenda.AgendaTypeId = AgendaTypes.AgendaTypeId INNER JOIN SelectedAgenda ON Agenda.AgendaId = SelectedAgenda.AgendaId INNER JOIN MeetingMinutes ON SelectedAgenda.MeetingAgendaId = MeetingMinutes.MeetingAgendaId where MeetingMinutes.MeetingId=" + meetingId + " ", con);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string x = Ordinal(int.Parse(rdr[0].ToString())) + @" Agenda";
                    minutedDataGridView.Rows.Add(x, rdr[1], rdr[2], rdr[3]);
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //try
            //{
            //    con = new SqlConnection(cs.DBConn);
            //    con.Open();
            //    cmd = new SqlCommand("SELECT row_number() OVER (ORDER BY MeetingParticipant.MPId) n,Participant.ParticipantName, AttendenceMeeting .Title,AttendenceMeeting.MPId FROM AttendenceMeeting join MeetingParticipant on AttendenceMeeting.MPId = MeetingParticipant.MPId  join Participant on MeetingParticipant.ParticipantId=Participant.ParticipantId where AttendenceMeeting.MeetingId=" + meetingId + "", con);
            //    rdr = cmd.ExecuteReader();
            //    while (rdr.Read())
            //    {
            //        attendedParticipantDataGridView.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3]);
            //    }
            //    if (con.State == ConnectionState.Open)
            //    {
            //        con.Close();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, @"error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }

        private void MeetingConsole7UI_Load(object sender, EventArgs e)
        {
            MeetingInfo();
            LoadUI();
        }
       
    }
}
