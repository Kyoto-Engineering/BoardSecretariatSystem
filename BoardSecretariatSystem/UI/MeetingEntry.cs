using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BoardSecretariatSystem.DBGateway;

namespace BoardSecretariatSystem
{

    public partial class MeetingEntry : Form
    {

        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        private ConnectionString cs = new ConnectionString();

        public string userId;
        public int companyId, addId;
        public int board_id,currentMeetingId;
        public string v,serialNo;

        public MeetingEntry()
        {
            userId = frmLogin.uId.ToString();
            InitializeComponent();
        }
        public void MeetingVanueLoad()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "SELECT CompanyAddresses.AddressHeader FROM CompanyAddresses order by  CompanyAddresses.ADId desc";
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
        private void MeetingEntry_Load(object sender, EventArgs e)
        {
            CompanyNameLoad();
            GetAllMeetingList();
            LoadCombo();
            GetAllParticipant();

            MeetingVanueLoad();
        }
        public void CompanyNameLoad()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "SELECT CompanyName FROM Company ";

                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    companyNameComboBox.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCombo()
        {
            // DataTable dt = new DataTable(); 
            //con = new SqlConnection(cs.DBConn);
            //SqlDataAdapter sda = new SqlDataAdapter("Select ParticipantName from t_participant ", con);
            //DataTable dt = new DataTable();
            //sda.Fill(dt);
            //DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            //combo.HeaderText = "Participants";
            //combo.Name = "Combo";
            //ArrayList row = new ArrayList();
            //foreach (DataRow items in dt.Rows)
            //{
            //    row.Add(items["Name"]).ToString();
            //}

            //combo.Items.AddRange(row.ToArray());
            //meetingListdataGridView.Columns.Add(combo);

            //con = new SqlConnection(cs.DBConn);
            //ArrayList row1 = new ArrayList();
            //const string query = "Select ParticipantName from t_participant";           
            //using (SqlConnection cn = new SqlConnection(cs.DBConn))
            //{
            //    using (SqlCommand cm = new SqlCommand(query, cn))
            //    {
            //        cn.Open();
            //        SqlDataReader reader = cm.ExecuteReader();
            //        while (reader.Read())
            //        {
            //            row1.Add(reader.GetString(0));
            //        }
            //    }
            //}


            //SqlDataAdapter sda = new SqlDataAdapter("Select ParticipantName from t_participant ", con);           
            //DataTable dt = new DataTable();
            //sda.Fill(dt);
            //DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            //combo.HeaderText = "Participants";
            //combo.Name = "Combo";
            //ArrayList row = new ArrayList();
            //foreach (DataRow items in dt.Rows)
            //{
            //    row.Add(items["ParticipantName"].ToString());
            //}
            //combo.Items.AddRange(row.ToArray());
            //meetingListdataGridView.Columns.Add(combo);          
        }

        private void GetAllParticipant()
        {
            //con = new SqlConnection(cs.DBConn);
            //ArrayList row = new ArrayList();
            //const string query = "Select ParticipantName from t_participant";
           
            //using (SqlConnection cn = new SqlConnection(cs.DBConn))
            //{
            //    using (SqlCommand cm = new SqlCommand(query, cn))
            //    {
            //        cn.Open();
            //        SqlDataReader reader = cm.ExecuteReader();
            //        while (reader.Read())
            //        {
            //           row.Add(reader.GetString(0));
            //        }
            //    }
            //}
        }

        public void GetAllMeetingList()
        {

            //try
            //{
            //    con = new SqlConnection(cs.DBConn);
            //    SqlDataAdapter sda = new SqlDataAdapter("SELECT t_company.CompanyName, t_board.BoardName, t_meeting.MeetingName, t_meeting.MeetingLocation, t_meeting.MeetingDate FROM t_company INNER JOIN t_board ON t_company.CompanyId = t_board.CompanyId INNER JOIN t_meeting ON t_board.BoardId = t_meeting.BoardId", con);
            //    DataTable dt = new DataTable();
            //    sda.Fill(dt);
            //    meetingListdataGridView.Rows.Clear();
            //    foreach (DataRow item in dt.Rows)
            //    {
            //        int n = meetingListdataGridView.Rows.Add();
            //        meetingListdataGridView.Rows[n].Cells[0].Value = item[0].ToString();
            //        meetingListdataGridView.Rows[n].Cells[1].Value = item[1].ToString();
            //        meetingListdataGridView.Rows[n].Cells[2].Value = item[2].ToString();
            //        meetingListdataGridView.Rows[n].Cells[3].Value = item[3].ToString();
            //        meetingListdataGridView.Rows[n].Cells[4].Value = item[4].ToString();                 
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }
        
        private void Reset()
        {
            companyNameComboBox.SelectedIndex = -1;
            boardNameComboBox.SelectedIndex = -1;
            meetingNameTextBox.Clear();
            cmbVenue.SelectedIndex = -1;
            meetingDatePicker.Value=DateTime.Today;
        }

        private void GenerateSerialNumberForMeeting()
        {
           String sDate = DateTime.Now.ToString();
           DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));
           String dy = datevalue.Day.ToString();
           String mn = datevalue.Month.ToString();
           String yy = datevalue.Year.ToString();
             //referenceNo = "OIA-" + sClientIdForRefNum + "-" + sQN + "-" + quotationId +"";
            serialNo = yy + board_id + "" + currentMeetingId; 
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(companyNameComboBox.Text))
            {
                MessageBox.Show("Please enter company Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (string.IsNullOrWhiteSpace(boardNameComboBox.Text))
            {
                MessageBox.Show("Please select board Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(meetingNameTextBox.Text))
            {
                MessageBox.Show("Please Select meeting Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                try
                {
                    
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string query2 = "insert into Meeting (MeetingName,MeetingLocation,MeetingDate,BoardId,UserId,DateTime) values (@d1,@d2,@d3,@d4,@d5,@d6)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                    cmd = new SqlCommand(query2, con);
                    cmd.Parameters.AddWithValue("@d1", meetingNameTextBox.Text);
                    //cmd.Parameters.AddWithValue("@d2", locationTextBox.Text);
                    cmd.Parameters.AddWithValue("@d3", meetingDatePicker.Value.Date);                                  
                    cmd.Parameters.AddWithValue("@d4", board_id);
                    cmd.Parameters.AddWithValue("@d5", userId);
                    cmd.Parameters.AddWithValue("@d6", DateTime.UtcNow.ToLocalTime());
                    currentMeetingId = (int)cmd.ExecuteScalar();
                    con.Close();
                    Reset();
                    MessageBox.Show("Saved Sucessfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            GetAllMeetingList();
        }
        

        private void MeetingEntry_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            MainUI mainUI = new MainUI();
            mainUI.Show();
        }

        private void companyNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetAllBoardByCompanyId();
        }

        public void GetAllBoardByCompanyId()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();

                cmd.CommandText = "select CompanyId from Company WHERE CompanyName= '" + companyNameComboBox.Text + "'";

                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    companyId = rdr.GetInt32(0);
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


            if (!string.IsNullOrWhiteSpace(companyNameComboBox.Text))
            {

                boardNameComboBox.Items.Clear();
                boardNameComboBox.ResetText();
                boardNameComboBox.SelectedIndex = -1;
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = con.CreateCommand();
                    string query = "SELECT BoardName from Board where CompanyId= '" + companyId + "'";

                    cmd = new SqlCommand(query, con);
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        boardNameComboBox.Items.Add(rdr.GetValue(0).ToString());
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
                    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            //SqlDataAdapter sda = new SqlDataAdapter("SELECT t_company.CompanyName, t_board.BoardName, t_meeting.MeetingName, t_meeting.MeetingLocation, t_meeting.MeetingDate FROM t_company INNER JOIN t_board ON t_company.CompanyId = t_board.CompanyId INNER JOIN t_meeting ON t_board.BoardId = t_meeting.BoardId WHERE (t_company.CompanyName LIKE '" + searchTextBox.Text + "%') or(t_board.BoardName LIKE '" + searchTextBox.Text + "%') or (t_meeting.MeetingName LIKE '" + searchTextBox.Text + "%')", con);
            //DataTable dataTable = new DataTable();
            //sda.Fill(dataTable);
            //meetingListdataGridView.Rows.Clear();
            //foreach (DataRow item in dataTable.Rows)
            //{
            //    int n = meetingListdataGridView.Rows.Add();
            //    meetingListdataGridView.Rows[n].Cells[0].Value = item[0].ToString();
            //    meetingListdataGridView.Rows[n].Cells[1].Value = item[1].ToString();
            //    meetingListdataGridView.Rows[n].Cells[2].Value = item[2].ToString();
            //    meetingListdataGridView.Rows[n].Cells[3].Value = item[3].ToString();
            //    meetingListdataGridView.Rows[n].Cells[4].Value = item[4].ToString();
            //}
        }

        private void cmbVenue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVenue.Text == "Not In The List")
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Please Input Mode Of Conduct  Here", "Input Here", "", -1, -1);
                if (string.IsNullOrWhiteSpace(input))
                {
                    cmbVenue.SelectedIndex = -1;
                }

                else
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 = "select AddressHeader from EmailBank where Email='" + input + "'";
                    cmd = new SqlCommand(ct2, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() && !rdr.IsDBNull(0))
                    {
                        MessageBox.Show("This AddressHeader  Already Exists,Please Select From List", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                        cmbVenue.SelectedIndex = -1;
                    }
                    else
                    {
                        try
                        {

                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string query1 = "insert into EmailBank (AddressHeader, UserId,DateAndTime) values (@d1,@d2,@d3)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            cmd = new SqlCommand(query1, con);
                            cmd.Parameters.AddWithValue("@d1", input);
                            cmd.Parameters.AddWithValue("@d2", userId);
                            cmd.Parameters.AddWithValue("@d3", DateTime.UtcNow.ToLocalTime());
                            cmd.ExecuteNonQuery();

                            con.Close();
                            cmbVenue.Items.Clear();
                            MeetingVanueLoad();
                            cmbVenue.SelectedText = input;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT ADId from CompanyAddresses WHERE AddressHeader= '" + cmbVenue.Text + "'";

                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        addId = rdr.GetInt32(0);
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

        private void boardNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();

                cmd.CommandText = "select BoardId from t_board WHERE CompanyId= '" + companyId + "' And BoardName='" + boardNameComboBox.Text + "'";

                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    board_id = rdr.GetInt32(0);

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
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
