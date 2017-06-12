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
    public partial class MeetingCreation : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        ConnectionString cs=new ConnectionString();
        private SqlDataReader rdr;
        public int meetingNum, meetingId;
        public decimal addHId;
        public int affectedRows1, currentMeetingId, boardId, count, companyId,metingTypeId;
        public string serialNo, divisionId, districtId, thanaId, postofficeId, userId,addressHeader,meetingStatus;


        public MeetingCreation()
        {
            InitializeComponent();
        }


        public void BoardNameLoad()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "SELECT BoardName FROM Board ";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtBoardName.Text = (rdr.GetString(0));
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void AgendaHeaderLoad()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "SELECT  AHeaderName  FROM  AddressHeader";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbVenue.Items.Add(rdr.GetValue(0).ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveMeetingParticipant()
        {      
           con = new SqlConnection(cs.DBConn);
           con.Open();
           string qry = "insert into MeetingParticipant(MeetingId,ParticipantId,Title) SELECT  @d1,Participant.ParticipantId As ParticipantId , 'Chairman' As Title FROM   Chairman INNER JOIN Derector ON Chairman.DerectorId = Derector.DerectorId INNER JOIN Shareholder ON Derector.ShareholderId = Shareholder.ShareholderId INNER JOIN Participant ON Shareholder.ParticipantId = Participant.ParticipantId where Chairman.DateofRetirement is null Union SELECT @d1, Participant.ParticipantId , 'Managing Director' As Title FROM  MDerector INNER JOIN  Derector ON MDerector.DerectorId = Derector.DerectorId INNER JOIN  Shareholder ON Derector.ShareholderId = Shareholder.ShareholderId INNER JOIN Participant ON Shareholder.ParticipantId = Participant.ParticipantId where MDerector.DateofRetirement is null Union SELECT @d1, Participant.ParticipantId , 'Director' As Title FROM  Derector INNER JOIN Shareholder ON Derector.ShareholderId = Shareholder.ShareholderId INNER JOIN Participant ON Shareholder.ParticipantId = Participant.ParticipantId  where Participant.ParticipantId not in (SELECT Participant.ParticipantId FROM  Chairman INNER JOIN Derector ON Chairman.DerectorId = Derector.DerectorId INNER JOIN Shareholder ON Derector.ShareholderId = Shareholder.ShareholderId INNER JOIN  Participant ON Shareholder.ParticipantId = Participant.ParticipantId where Chairman.DateofRetirement is null Union SELECT  Participant.ParticipantId FROM  MDerector INNER JOIN Derector ON MDerector.DerectorId = Derector.DerectorId INNER JOIN Shareholder ON Derector.ShareholderId = Shareholder.ShareholderId INNER JOIN Participant ON Shareholder.ParticipantId = Participant.ParticipantId where MDerector.DateofRetirement is null)";
           cmd = new SqlCommand(qry, con);
           cmd.Parameters.AddWithValue("@d1", currentMeetingId);
           cmd.ExecuteNonQuery();
           con.Close();
        }
        private void GetMeetingTitle()
        {
            try
            {               
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string qr2 = "SELECT      MeetingId, MeetingNo, Statuss FROM   Meeting WHERE MeetingId=(SELECT      Max(MeetingId)  FROM   Meeting WHERE MeetingTypeId=1)";                  
                    cmd = new SqlCommand(qr2, con);
                    rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if (rdr.HasRows)
                    {
                        meetingId = (rdr.GetInt32(0));
                        meetingNum = (rdr.GetInt32(1));
                        meetingStatus = rdr.GetString(2);
                        meetingNum = meetingNum + 1;
                        txtMeetingName.Text = Ordinal(meetingNum) + " Board Meeting";
                    }
                }
                else
                {
                    meetingId = 1;
                    meetingNum = 1;
                    txtMeetingName.Text = Ordinal(meetingNum) + " Board Meeting";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void CompanyNameLoad()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "SELECT CompanyName,CompanyId FROM Company ";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtCompanyName.Text = (rdr.GetString(0));
                    companyId = (rdr.GetInt32(1));
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Create A comany First");
                    con.Close();
                    this.Close();
                }
               
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }       
        public void MeetingVanueLoad()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "SELECT AddressHeader.AHeaderName FROM AddressHeader order by  AddressHeader.AHeaderId desc";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbVenue.Items.Add(rdr[0]);
                }
                con.Close();
                cmbVenue.Items.Add("Not In The List");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static string Ordinal(int number)
        {
            string suffix = String.Empty;
            if (number == 1 || number == 21 || number == 31 || number % 100 == 21 || number % 100 == 31)
            {
                suffix = "st";
            }
            else if (number == 2 || number == 22 || number % 100 == 22)
            {
                suffix = "nd";
            }
            else if (number == 3 || number == 23 || number % 100 == 23)
            {
                suffix = "rd";
            }
            else
            {
                suffix = "th";
            }
            return String.Format("{0}{1}", number, suffix);
        }

        private void MeetingCreation_Load(object sender, EventArgs e)
        {
            userId = frmLogin.uId.ToString();
            groupBox2.Visible = false;
            label4.Visible = false;
            label9.Visible = false;
            this.Size= new Size(700, 550);            
            BoardNameLoad();
            CompanyNameLoad();
            MeetingVanueLoad();
            GetMeetingTitle();
           
            GenerateSerialNumberForMeeting();
        }
        private void GenerateSerialNumberForMeeting()
        {
            String sDate = DateTime.Now.ToString();
            DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));
            String dy = datevalue.Day.ToString();
            String mn = datevalue.Month.ToString();
            String yy = datevalue.Year.ToString();
           con=new SqlConnection(cs.DBConn);
           con.Open();
           string qry = "Select Count(MeetingId) from Meeting where MeetingTypeId=1";
           cmd=new SqlCommand(qry,con);
           rdr=cmd.ExecuteReader();
            if (rdr.Read())
            {
                count = (rdr.GetInt32(0));
            }
            con.Close();
            con.Open();
            string qry2 = "Select Max(MeetingId) from Meeting";
            cmd = new SqlCommand(qry, con);
            rdr = cmd.ExecuteReader();
            if (rdr.Read()&&!rdr.IsDBNull(0))
            {
                currentMeetingId = (rdr.GetInt32(0));
            }
            else
            {
                currentMeetingId = 1;
            }
            if (count == 0)
            {
                
                count = 1;
                serialNo = yy + "-" + boardId + "-" + count + "-" + currentMeetingId;
            }
            else
            {
                count++;
                serialNo = yy + "-" + boardId + "-" + count + "-" + currentMeetingId;
            }  
            con.Close();
        }

        private void SaveAddressHeader()
        {
            try
            {                
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query2 = "insert into AddressHeader(AHeaderName) values (@d1)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                cmd = new SqlCommand(query2, con);
                cmd.Parameters.AddWithValue("@d1", txtNAddressHeader.Text);               
                addHId = (int)cmd.ExecuteScalar();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SaveMeetingAddress()
        {
               
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string insertQ = "insert into CompanyAddresses(AHeaderId,Address,CompanyId) Values(@d1,@d4,@d11)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                cmd = new SqlCommand(insertQ);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@d1", string.IsNullOrEmpty(addHId.ToString()) ? (object)DBNull.Value : addHId.ToString()));
                cmd.Parameters.Add(new SqlParameter("@d4", string.IsNullOrEmpty(corporateRichTextBox.Text) ? (object)DBNull.Value : corporateRichTextBox.Text));
                cmd.Parameters.AddWithValue("@d11", companyId);
                affectedRows1 = (int)cmd.ExecuteScalar();
                con.Close();
        }

        private void ResetAddress()
        {
          corporateRichTextBox.Clear();
        }
        private void Reset()
        {
            txtCompanyName.Clear();
            txtBoardName.Clear();
            txtMeetingName.Clear();
            cmbVenue.SelectedIndex = -1;
            txtMeetingDate.Value=DateTime.Today;

            if (!string.IsNullOrEmpty(txtNAddressHeader.Text))
            {
                ResetAddress();
            }
           
        }
        
        private void buttonMeetingCreation_Click(object sender, EventArgs e)
        {
            if (ValidateCreateMeeting())
            {
                if (string.IsNullOrEmpty(cmbVenue.Text))
                {
                    MessageBox.Show("Please Select Vanue for the Meeting", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cmbVenue.Text == "Not In The List")
                {
                    if (string.IsNullOrEmpty(txtNAddressHeader.Text))
                    {
                        MessageBox.Show("Please enter Address Header for the Meeting", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string ct = "select AHeaderName from AddressHeader where AHeaderName='" + txtNAddressHeader.Text + "'";

                        cmd = new SqlCommand(ct);
                        cmd.Connection = con;
                        rdr = cmd.ExecuteReader();

                        if (rdr.Read())
                        {
                            MessageBox.Show("This Address Header name Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            if ((rdr != null))
                            {
                                rdr.Close();
                            }
                            return;
                        }

                    }

                    if (string.IsNullOrEmpty(corporateRichTextBox.Text))
                    {
                        MessageBox.Show("Please insert Address", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }

                try
                {
                    if (!string.IsNullOrEmpty(txtNAddressHeader.Text))
                    {
                        SaveAddressHeader();
                        SaveMeetingAddress();
                    }
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string query2 = "insert into Meeting(AHeaderId,MeetingNo,MeetingDate,SerialNumber,UserId,DateTime,MeetingTypeId,Statuss,AllAgendaSelected,InvitationSend,AttendenceTaken,AttendanceCompleted,MeetingStarted,AllDiscussionCompleted) values (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d9,@d9,@d9,@d9,@d9)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                    cmd = new SqlCommand(query2, con);
                    cmd.Parameters.AddWithValue("@d1", addHId);
                    cmd.Parameters.AddWithValue("@d2", meetingNum);
                    cmd.Parameters.AddWithValue("@d3", Convert.ToDateTime(txtMeetingDate.Value, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat));
                    cmd.Parameters.AddWithValue("@d4", serialNo);
                    cmd.Parameters.AddWithValue("@d5", userId);
                    cmd.Parameters.AddWithValue("@d6", DateTime.UtcNow.ToLocalTime());
                    cmd.Parameters.AddWithValue("@d7", 1);
                    cmd.Parameters.AddWithValue("@d8", "Open");
                    cmd.Parameters.AddWithValue("@d9", 0);
                    currentMeetingId = (int)cmd.ExecuteScalar();
                    con.Close();
                    SaveMeetingParticipant();
                    MessageBox.Show("Meeting Created Successfully", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    this.Close();

                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                this.Close();
            }
            
            
        }

        private void MeetingCreation_FormClosed(object sender, FormClosedEventArgs e)
        {
                       this.Hide();
            MeetingManagementUI frm=new MeetingManagementUI();
                          frm.Show();

        }

        private bool VisibleAddressHeader()
        {
            bool validate = true;
            if (cmbVenue.Text == "Not In The List")
            {
                MeetingCreation.ActiveForm.Width += 627;
                groupBox2.Visible = true;
                label4.Visible = true;
                label9.Visible = true;
                validate = false;
            }
            else if (MeetingCreation.ActiveForm!=null && MeetingCreation.ActiveForm.Width == 1327)
            {
                MeetingCreation.ActiveForm.Width -= 627;
                groupBox2.Visible = false;
                label9.Visible = false;
                label4.Visible = false;
                validate = true;
            }
            return validate;
        }
       
        private void cmbVenue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VisibleAddressHeader())
            {
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT AddressHeader.AHeaderId from AddressHeader where  AddressHeader.AHeaderName= '" + cmbVenue.Text + "'";
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        addHId = rdr.GetInt32(0);
                    }
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } 
            }
           
        }

        private void txtBoardName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT BoardId from Board WHERE BoardName= '" + txtBoardName.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    boardId = rdr.GetInt32(0);
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

        private bool ValidateCreateMeeting()
        {
            bool validate = true;
            if (meetingStatus== "Open")
            {
                MessageBox.Show(@"There is already another meeting opened." + "\n" + @"You cannot create another meeting Now");
                validate = false;
            }
            return validate;
        }

        private void txtCompanyName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBoardName.Focus();
                e.Handled = true;
            }
        }

        private void txtBoardName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMeetingName.Focus();
                e.Handled = true;
            }
        }

        private void txtMeetingName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbVenue.Focus();
                e.Handled = true;
            }
        }

        private void cmbVenue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMeetingDate.Focus();
                e.Handled = true;
            }
        }

        private void txtMeetingDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNAddressHeader.Focus();
                e.Handled = true;
            }
        }

        private void txtNAddressHeader_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                corporateRichTextBox.Focus();
                e.Handled = true;
            }
        }
    }
}
