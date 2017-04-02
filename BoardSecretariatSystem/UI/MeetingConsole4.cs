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
    public partial class MeetingConsole4 : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        private ConnectionString cs = new ConnectionString();
        private int meetingId, meetingNo, agendaId = 0;
        public MeetingConsole4()
        {
            InitializeComponent();
            List<Employee2> employees = new List<Employee2>();
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand(" SELECT        Participant.ParticipantName, MeetingParticipant.Title FROM            MeetingParticipant INNER JOIN Participant ON MeetingParticipant.ParticipantId = Participant.ParticipantId INNER JOIN Meeting ON MeetingParticipant.MeetingId = Meeting.MeetingId where Meeting.Statuss='Open'", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (rdr.Read() == true)
                {
                    employees.Add(new Employee2() { Name = rdr[0].ToString(), Title = rdr[1].ToString()});
                    //dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //for (int i = 0; i < 10; i++)
            //{
            //    employees.Add(new Employee2() { Name = "Name" + i, Designation = "Address" + i, Department = "TelephoneNumber" + i });

            //}

            this.comboBoxWithGrid_WinformsHost1.Employee2s = employees;

            //this.comboBoxWithGrid_WinformsHost1.SelectedIndex = 6;
        }

        private void MeetingConsole4_FormClosed(object sender, FormClosedEventArgs e)
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
                string query = "SELECT MeetingId, MeetingNo FROM Meeting where Statuss='Open' and MeetingTypeId=1";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    meetingId = Convert.ToInt32(rdr["MeetingId"]);
                    meetingNo = Convert.ToInt32(rdr["MeetingNo"]);
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
            if (number % 100 == 23)
            {
                suffix = "rd";
            }
            else if (number == 1 || number == 21 || number == 31)
            {
                suffix = "st";
            }
            else if (number == 2 || number == 22)
            {
                suffix = "nd";
            }
            else if (number == 3 || number == 23)
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
                cmd = new SqlCommand("SELECT       Participant.ParticipantName, MeetingParticipant.Title  FROM            MeetingParticipant INNER JOIN Participant ON MeetingParticipant.ParticipantId = Participant.ParticipantId INNER JOIN Meeting on  MeetingParticipant.MeetingId = Meeting.MeetingId where Meeting.Statuss ='Open'",con);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cancelationNoticeDataGridView.Rows.Add(rdr[0], rdr[1]);
                }
                //if (con.State == ConnectionState.Open)
                //{
                //    con.Close();
                //}
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
        

    }
}
