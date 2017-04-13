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
        private int meetingId, meetingNo, agendaId = 0,gridno=0;
        private int postponeid,mmid=0;
        DataGridViewRow dr = new DataGridViewRow();
        private bool invitationSend, attendanceTaken, agendaSelected, attendancecompleted,meetingStarted,allDiscussionCompleted;
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
                string query = "SELECT MeetingId, MeetingNo, InvitationSend, AttendenceTaken,AttendanceCompleted,MeetingStarted,AllDiscussionCompleted FROM Meeting where Statuss='Open' and MeetingTypeId=1";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    meetingId = Convert.ToInt32(rdr["MeetingId"]);
                    meetingNo = Convert.ToInt32(rdr["MeetingNo"]);
                    invitationSend = rdr.GetBoolean(2);
                    attendanceTaken = rdr.GetBoolean(3);
                    attendancecompleted = rdr.GetBoolean(4);
                    meetingStarted = rdr.GetBoolean(5);
                    allDiscussionCompleted = rdr.GetBoolean(6);
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
                cmd = new SqlCommand("SELECT MeetingMinutes.AgendaSerialForMeeting, Agenda.AgendaTitle, MeetingMinutes.Resolution, MeetingMinutes.Discussion, MeetingMinutes.MeetingMinuteId FROM Agenda INNER JOIN AgendaTypes ON Agenda.AgendaTypeId = AgendaTypes.AgendaTypeId INNER JOIN SelectedAgenda ON Agenda.AgendaId = SelectedAgenda.AgendaId INNER JOIN MeetingMinutes ON SelectedAgenda.MeetingAgendaId = MeetingMinutes.MeetingAgendaId where MeetingMinutes.MeetingId=" + meetingId + " ", con);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string x = Ordinal(int.Parse(rdr[0].ToString())) + @" Agenda";
                    minutedDataGridView.Rows.Add(x, rdr[1], rdr[2],rdr[3],rdr[4]);
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

        private void MeetingConsole7UI_Load(object sender, EventArgs e)
        {
            MeetingInfo();
            LoadUI();
        }

        private void minutedDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            gridno = 1;
            dr = minutedDataGridView.SelectedRows[0];
            mmid = int.Parse(dr.Cells[4].Value.ToString());
            agendumTextBox.Text = dr.Cells[0].Value.ToString() + @". " + dr.Cells[1].Value.ToString();
            textWithSpellCheck1.Text = dr.Cells[2].Value.ToString();
        }

        private void addToListButton_Click(object sender, EventArgs e)
        {
            if (ValidateAddtoListButton())
            {
                SaveToDatabase();

                
                if (gridno==1)
                {
                    InsertToGrid();
                }
                else if(gridno==2)
                {
                    InsertToGrid2();
                }

                Clear();
            }
           
        }

        private void SaveToDatabase()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "UPDATE MeetingMinutes SET Resolution = @res WHERE  MeetingMinuteId= @mmid";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@res", textWithSpellCheck1.Text);
                cmd.Parameters.AddWithValue("@mmid", mmid);
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

        private void InsertToGrid()
        {
            minutedDataGridView.Rows.Remove(dr);
            int x = resolvedDataGridView.Rows.Count;
            dr.Cells[0].Value = (x + 1).ToString();
            dr.Cells[3].Value = textWithSpellCheck1.Text;
            resolvedDataGridView.Rows.Add(dr);
        }

        private bool ValidateAddtoListButton()
        {
            bool validate = true;
            if (!invitationSend)
            {
                MessageBox.Show(@"Invitation Not Send Yet." + "\n" + @"Before Completing You Must Send Invitation ", @"Sorry");
                validate = false;
            }
            else if (!attendancecompleted)
            {
                MessageBox.Show(@"Attendace giving is not  completed." + "\n" + @"You Must Complete Attendece.", @"Sorry");
                validate = false;
            }
            else if (!meetingStarted)
            {
                MessageBox.Show(@"Meeting Not Started Yet"+"\n"+@"You Cannot Save now",@"Sorry",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                validate = false;
            }
            else if(!allDiscussionCompleted)
            {
                MessageBox.Show(@"All Discussion Not Completed Yet"+"\n"+@"Press Save All Button on Console 6 if Your Discussion Is Finished",@"Error",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                validate = false;
            }
            else if (mmid == 0)
            {
                MessageBox.Show(@"Nothing Is Selected .Select First" , @"Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                validate = false;
            }
            return validate;
        }
        private void Clear()
        {
            textWithSpellCheck1.Text=String.Empty;
            mmid = 0;
            agendumTextBox.Clear();
        }

        private void resolvedDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void InsertToGrid2()
        {
            foreach (DataGridViewRow x in resolvedDataGridView.Rows)
            {
                if (dr==x)
                {
                    x.Cells[3].Value = textWithSpellCheck1.Text;
                }
            }
          
        }

        private void saveAllButton_Click(object sender, EventArgs e)
        {
            if (ValidateSaveAllButton())
            {
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string query = "Update Meeting set Statuss=@at where  MeetingId=@id";
                    cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@at", "Close");
                    cmd.Parameters.AddWithValue("@id", meetingId);
                    cmd.ExecuteNonQuery();
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    MessageBox.Show(@"All Attendance Given Successfully",@"Success",MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, @"error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private bool ValidateSaveAllButton()
        {
            bool validate = true;

              if (!invitationSend)
            {
                MessageBox.Show(@"Invitation Not Send Yet." + "\n" + @"Before Completing You Must Send Invitation ", @"Sorry");
                validate = false;
            }
            else if (!attendancecompleted)
            {
                MessageBox.Show(@"Attendace giving is not  completed." + "\n" + @"You Must Complete Attendece.", @"Sorry");
                validate = false;
            }
            else if (!meetingStarted)
            {
                MessageBox.Show(@"Meeting Not Started Yet" + "\n" + @"You Cannot Save now", @"Sorry", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                validate = false;
            }
            else if (!allDiscussionCompleted)
            {
                MessageBox.Show(@"All Discussion Not Completed Yet" + "\n" + @"Press Save All Button on Console 6 if Your Discussion Is Finished", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                validate = false;
            }
         
            return validate;
        }

        private void resolvedDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            gridno = 2;
            dr = resolvedDataGridView.SelectedRows[0];
            mmid = int.Parse(dr.Cells[4].Value.ToString());
            agendumTextBox.Text = dr.Cells[0].Value.ToString() + @". " + dr.Cells[1].Value.ToString();
            textWithSpellCheck1.Text = dr.Cells[2].Value.ToString();
        }
    }

}
