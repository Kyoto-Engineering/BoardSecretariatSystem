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

        public string user_id;
        public int company_id;
        public int board_id;
        public string v;

        public MeetingEntry()
        {
            user_id = frmLogin.uId.ToString();
            InitializeComponent();
        }
        private void MeetingEntry_Load(object sender, EventArgs e)
        {
            CompanyNameLoad();
            GetAllMeetingList();
            LoadCombo();
            GetAllParticipant();

           
        }
        public void CompanyNameLoad()
        {
            con = new SqlConnection(cs.DBConn);
            con.Open();
            string query = "SELECT CompanyName FROM t_company ";

            cmd = new SqlCommand(query, con);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                companyNameComboBox.Items.Add(rdr[0]);
            }
            con.Close();
        }

        private void LoadCombo()
        {
            // DataTable dt = new DataTable(); // I use DataTable here because I only want to grab data in ONE Table.. If using mutilple tables then use DataSet instead
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

            con = new SqlConnection(cs.DBConn);
            ArrayList row1 = new ArrayList();
            const string query = "Select ParticipantName from t_participant";
            //const string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=PSeminar;Integrated Security=true;Trusted_Connection=Yes;MultipleActiveResultSets=true";
            using (SqlConnection cn = new SqlConnection(cs.DBConn))
            {
                using (SqlCommand cm = new SqlCommand(query, cn))
                {
                    cn.Open();
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {
                        row1.Add(reader.GetString(0));
                    }
                }
            }

            DataTable dt = new DataTable();
            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            combo.HeaderText = "Participants";
            combo.Name = "Combo";
            ArrayList row = new ArrayList();
            foreach (DataRow items in dt.Rows)
            {
                row.Add(items["Name"]).ToString();
            }

            combo.Items.AddRange(row.ToArray());
            meetingListdataGridView.Columns.Add(combo);


            
        }

        private void GetAllParticipant()
        {
            //con = new SqlConnection(cs.DBConn);
            //ArrayList row = new ArrayList();
            //const string query = "Select ParticipantName from t_participant";
            ////const string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=PSeminar;Integrated Security=true;Trusted_Connection=Yes;MultipleActiveResultSets=true";
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

            try
            {
                con = new SqlConnection(cs.DBConn);
                SqlDataAdapter sda = new SqlDataAdapter("SELECT t_company.CompanyName, t_board.BoardName, t_meeting.MeetingName, t_meeting.MeetingLocation, t_meeting.MeetingDate FROM t_company INNER JOIN t_board ON t_company.CompanyId = t_board.CompanyId INNER JOIN t_meeting ON t_board.BoardId = t_meeting.BoardId", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                meetingListdataGridView.Rows.Clear();
                foreach (DataRow item in dt.Rows)
                {
                    int n = meetingListdataGridView.Rows.Add();
                    meetingListdataGridView.Rows[n].Cells[0].Value = item[0].ToString();
                    meetingListdataGridView.Rows[n].Cells[1].Value = item[1].ToString();
                    meetingListdataGridView.Rows[n].Cells[2].Value = item[2].ToString();
                    meetingListdataGridView.Rows[n].Cells[3].Value = item[3].ToString();
                    meetingListdataGridView.Rows[n].Cells[4].Value = item[4].ToString();
                    

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void SelectBoardId()
        {
           
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();

                cmd.CommandText = "select BoardId from t_board WHERE CompanyId= '" + company_id + "'";

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
        
        private void saveButton_Click(object sender, EventArgs e)
        {           
                try
                {
                    SelectBoardId();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string query2 = "insert into t_meeting (MeetingName,MeetingLocation,MeetingDate,BoardId,UserId,DateTime) values (@d1,@d2,@d3,@d4,@d5,@d6)" +
                                    "SELECT CONVERT(int, SCOPE_IDENTITY())";
                    cmd = new SqlCommand(query2, con);
                    cmd.Parameters.AddWithValue("@d1", meetingNameTextBox.Text);
                    cmd.Parameters.AddWithValue("@d2", locationTextBox.Text);
                    cmd.Parameters.AddWithValue("@d3", meetingDatePicker.Value.Date);                                  
                    cmd.Parameters.AddWithValue("@d4", board_id);
                    cmd.Parameters.AddWithValue("@d5", user_id);
                    cmd.Parameters.AddWithValue("@d6", DateTime.UtcNow.ToLocalTime());
                    cmd.ExecuteNonQuery();
                    con.Close();

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

                cmd.CommandText = "select CompanyId from t_company WHERE CompanyName= '" + companyNameComboBox.Text + "'";

                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    company_id = rdr.GetInt32(0);
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
                    string query = "SELECT BoardName from t_board where CompanyId= '" + company_id + "'";

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
            SqlDataAdapter sda = new SqlDataAdapter("SELECT t_company.CompanyName, t_board.BoardName, t_meeting.MeetingName, t_meeting.MeetingLocation, t_meeting.MeetingDate FROM t_company INNER JOIN t_board ON t_company.CompanyId = t_board.CompanyId INNER JOIN t_meeting ON t_board.BoardId = t_meeting.BoardId WHERE (t_company.CompanyName LIKE '" + searchTextBox.Text + "%') or(t_board.BoardName LIKE '" + searchTextBox.Text + "%') or (t_meeting.MeetingName LIKE '" + searchTextBox.Text + "%')", con);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            meetingListdataGridView.Rows.Clear();
            foreach (DataRow item in dataTable.Rows)
            {
                int n = meetingListdataGridView.Rows.Add();
                meetingListdataGridView.Rows[n].Cells[0].Value = item[0].ToString();
                meetingListdataGridView.Rows[n].Cells[1].Value = item[1].ToString();
                meetingListdataGridView.Rows[n].Cells[2].Value = item[2].ToString();
                meetingListdataGridView.Rows[n].Cells[3].Value = item[3].ToString();
                meetingListdataGridView.Rows[n].Cells[4].Value = item[4].ToString();
            }
        }

       
        




    }
}
