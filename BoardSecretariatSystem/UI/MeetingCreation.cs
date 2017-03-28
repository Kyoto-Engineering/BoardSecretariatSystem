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
        public decimal aId, aId1, addHId, userId;
        public int currentMeetingId, boardId,count;
        public string serialNo;


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
        private void GetMeetingTitle()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctt = "SELECT IDENT_CURRENT ('Meeting')";
                cmd = new SqlCommand(ctt);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    aId = (rdr.GetDecimal(0));
                    if (aId == 0)
                    {
                        txtMeetingName.Text = "1st Board Meeting";
                    }
                    else if (aId == 1)
                    {
                        txtMeetingName.Text = "2nd Board Meeting";
                    }
                    else if (aId == 2)
                    {
                        txtMeetingName.Text = "3rd Board Meeting";
                    }
                    else if (aId == 3)
                    {
                        txtMeetingName.Text = "4rth Board Meeting";
                    }

                    else if (aId >= 4)
                    {
                        aId1 = aId + 1;
                        txtMeetingName.Text = aId1 + "th Board Meeting";
                    }

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
                string query = "SELECT CompanyName FROM Company ";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtCompanyName.Text = (rdr.GetString(0));
                }
                con.Close();
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
        private void MeetingCreation_Load(object sender, EventArgs e)
        {
            GetMeetingTitle();
            BoardNameLoad();
            CompanyNameLoad();
            MeetingVanueLoad();
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
           string qry = "Select Count(MeetingId) from Meeting";
           cmd=new SqlCommand(qry,con);
           rdr=cmd.ExecuteReader();
            if (rdr.Read())
            {
                count = (rdr.GetInt32(0));
            }



            serialNo = yy + "-" + boardId + "-" + count + "-" + currentMeetingId;
        }
        private void buttonMeetingCreation_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query2 = "insert into Meeting(AHeaderId,MeetingName,MeetingDate,SerialNumber,UserId,DateTime) values (@d1,@d2,@d3,@d4,@d5,@d6)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                cmd = new SqlCommand(query2, con);
                cmd.Parameters.AddWithValue("@d1", addHId);
                cmd.Parameters.AddWithValue("@d2", txtMeetingName.Text);
                cmd.Parameters.AddWithValue("@d3", serialNo);
                cmd.Parameters.AddWithValue("@d4", txtMeetingDate.Value.Date);
                cmd.Parameters.AddWithValue("@d5", userId);
                cmd.Parameters.AddWithValue("@d6", DateTime.UtcNow.ToLocalTime());
                currentMeetingId = (int)cmd.ExecuteScalar();
                con.Close(); 

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MeetingCreation_FormClosed(object sender, FormClosedEventArgs e)
        {
                       this.Hide();
            MeetingManagementUI frm=new MeetingManagementUI();
                          frm.Show();

        }

        private void cmbVenue_SelectedIndexChanged(object sender, EventArgs e)
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
    }
}
