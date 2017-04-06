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
    public partial class MeetingConsole5UI : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        private ConnectionString cs = new ConnectionString();
        private int meetingId, meetingNo, agendaId = 0;
        private int postponeid;
        private bool invitationSend, attendanceTaken, agendaSelected,attendancecompleted;
       
        public MeetingConsole5UI()
        {
            InitializeComponent();
            List<Employee2> employees = new List<Employee2>();
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand(" SELECT        Participant.ParticipantName, AttendenceMeeting.Title, AttendenceMeeting.AttendenceMeetingId FROM      AttendenceMeeting inner join      MeetingParticipant on AttendenceMeeting.MPId=MeetingParticipant.MPId INNER JOIN Participant ON MeetingParticipant.ParticipantId = Participant.ParticipantId INNER JOIN Meeting ON MeetingParticipant.MeetingId = Meeting.MeetingId where Meeting.Statuss='Open'" , con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (rdr.Read())
                {
                    employees.Add(new Employee2() { Name = rdr[0].ToString(), Title = rdr[1].ToString(), Id = rdr[2].ToString() });

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            this.comboBoxWithGrid_WinformsHost1.Employee2s = employees;
        }

        private void MeetingConsole5UI_FormClosed(object sender, FormClosedEventArgs e)
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
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            meetingNumOrIDTextBox.Text = Ordinal(meetingNo) + " Board Meeting";
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT row_number() OVER (ORDER BY MPId) n,Participant.ParticipantName, Title,MPId FROM MeetingParticipant join Participant on MeetingParticipant.ParticipantId=Participant.ParticipantId where MeetingId=" + meetingId + " and MPId not in (SELECT        MPId  FROM            AttendenceMeeting where MeetingId=" + meetingId + " )", con);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    invitedParticipantDataGridView.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3]);
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
             try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT row_number() OVER (ORDER BY MeetingParticipant.MPId) n,Participant.ParticipantName, AttendenceMeeting .Title,AttendenceMeeting.MPId FROM AttendenceMeeting join MeetingParticipant on AttendenceMeeting.MPId = MeetingParticipant.MPId  join Participant on MeetingParticipant.ParticipantId=Participant.ParticipantId where AttendenceMeeting.MeetingId="+meetingId+"", con);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    attendedParticipantDataGridView.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3]);
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

        private void MeetingConsole5UI_Load(object sender, EventArgs e)
        {
            MeetingInfo();
            LoadUI();
        }

        private void addToListButton_Click(object sender, EventArgs e)
        {
            if (ValidateAddtoButton())
            {
                UpdateAttendanceTaken();
                InsertToDatabase();

            }
            
        }

        private void InsertToDatabase()
        {
          
            try
            {
                   DataGridViewRow dr = new DataGridViewRow();
            dr = invitedParticipantDataGridView.SelectedRows[0];
                invitedParticipantDataGridView.Rows.Remove(dr);
                
            //string x=dr.Cells[3].ToString();
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "INSERT INTO AttendenceMeeting (MPId,MeetingId,Title) VALUES(@mid,@meid,@t)" +
                            "SELECT CONVERT(int, SCOPE_IDENTITY())"; 
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@mid", int.Parse(dr.Cells[3].Value.ToString()));
                cmd.Parameters.AddWithValue("@meid", meetingId);
                cmd.Parameters.AddWithValue("@t", dr.Cells[2].Value.ToString());
                int attendancMeetingId = (int)cmd.ExecuteScalar();
                cmd.ExecuteNonQuery();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                dr.Cells[3].Value = attendancMeetingId;
                attendedParticipantDataGridView.Rows.Add(dr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void invitedParticipantDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (invitedParticipantDataGridView.SelectedRows.Count > 1)
            {
                invitedParticipantDataGridView.SelectedRows[0].Selected = false;
            }
        }

        private void saveAllButton_Click(object sender, EventArgs e)
        {

            bool isChairmanExist = false;
            foreach (DataGridViewRow dr in attendedParticipantDataGridView.Rows)
            {
                if (dr.Cells[2].Value.ToString()=="Chairman")
                {
                    isChairmanExist = true;
                    break;
                }
            }
            if (!isChairmanExist)
            {
                LoadCombo();
                comboBoxWithGrid_WinformsHost1.Visible = true;
                label5.Visible = true;
                button1.Visible = true;
                MessageBox.Show("Select Who chaired The meeting");
            }
            else
            {
                UpdateAttendanceCopmpleted();
            }
        }

        private void LoadCombo()
        {
           
          
        }
        private void UpdateAttendanceCopmpleted()
        {
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string query = "Update Meeting set AttendanceCompleted=@at where  MeetingId=@id";
                    cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@at", true);
                    cmd.Parameters.AddWithValue("@id", meetingId);
                    cmd.ExecuteNonQuery();
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    MessageBox.Show("All Attendance Given Succesfully","Succes",MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        private void UpdateAttendanceTaken()
        {
            if (!attendanceTaken)
            {
                attendanceTaken = true;
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string query = "Update Meeting set AttendenceTaken=@at where  MeetingId=@id";
                    cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@at", attendanceTaken);
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxWithGrid_WinformsHost1.SelectedItem != null)
            {
                UpdateChairman();
                UpdateAttendanceCopmpleted();
                comboBoxWithGrid_WinformsHost1.Visible = false;
                label5.Visible = false;
                button1.Visible = false;
            }
            else
            {
                MessageBox.Show("Select Some One As Chairman");
            }
        }

        private void UpdateChairman()
        {  try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string query = "Update AttendenceMeeting set Title='Chairman' where  AttendenceMeetingId=@id";
                    cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@id", int.Parse(comboBoxWithGrid_WinformsHost1.SelectedItem.Id));
                    cmd.ExecuteNonQuery();
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    foreach (DataGridViewRow dr in attendedParticipantDataGridView.Rows)
                    {
                        if (dr.Cells[3].Value.ToString() == comboBoxWithGrid_WinformsHost1.SelectedItem.Id)
                        {
                            dr.Cells[2].Value = "Chairman";
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
        }

        private bool ValidateAddtoButton()
        {
            bool validate = true;
            if (!invitationSend)
            {
                MessageBox.Show(@"Invitation Not Send Yet."+"\n"+"Before Giving Attendance You Must Send Invitation ", "Sorry");
                validate = false;
            }
            else if (attendancecompleted)
            {
                MessageBox.Show(@"Already attendace giving is  completed."+"\n"+ "You Cannot give attendance now.","Sorry");
                validate = false;
            }
            return validate;
        }
    }
}
