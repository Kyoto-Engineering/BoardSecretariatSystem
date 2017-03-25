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
        public string userId, agendaTypeId, labelk, labelg;
        public int companyId, addHId, aId;
        public int boardId,currentMeetingId,  agendaId;
        public string v,serialNo,agendaType;

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
        private void GetAgendaDetails()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT Agenda.AgendaTopics, Agenda.AgendaTitle, Agenda.Memo, AgendaTypes.AgendaType,AgendaTypes.AgendaTypeId FROM  Agenda INNER JOIN AgendaTypes ON Agenda.AgendaTypeId = AgendaTypes.AgendaTypeId", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2],rdr[3],rdr[4]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string ctt = "Select MAX(MeetingId) from Meeting ";
                cmd = new SqlCommand(ctt);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read()==false)
                {
                    aId = (rdr.GetInt32(0));
                    if(aId == null)
                    {
                        txtMeetingName.Text ="1st Board Meeting";
                    }
                    if (aId == 1)
                    {
                        txtMeetingName.Text = "2nd Board Meeting";
                    }
                    if (aId == 2)
                    {
                        txtMeetingName.Text = "3rd Board Meeting";
                    }
                    if (aId == 3)
                    {
                        txtMeetingName.Text = "4rth Board Meeting";
                    }

                    if (aId == 4)
                    {
                        txtMeetingName.Text = "5th Board Meeting";
                    }
                    if (aId == 5)
                    {
                        txtMeetingName.Text = "6th Board Meeting";
                    }
                    if (aId == 6)
                    {
                        txtMeetingName.Text = "7th Board Meeting";
                    }
                    if (aId == 7)
                    {
                        txtMeetingName.Text = "8th Board Meeting";
                    }
                    if (aId == 8)
                    {
                        txtMeetingName.Text = "9th Board Meeting";
                    }
                    if (aId == 9)
                    {
                        txtMeetingName.Text = "10th Board Meeting";
                    }
                    if (aId == 10)
                    {
                        txtMeetingName.Text = "11th Board Meeting";
                    }
                    if (aId == 11)
                    {
                        txtMeetingName.Text = "12th Board Meeting";
                    }

                    if (aId == 12)
                    {
                        txtMeetingName.Text = "13th Board Meeting";
                    }
                    if (aId == 13)
                    {
                        txtMeetingName.Text = "14th Board Meeting";
                    }
                    if (aId == 14)
                    {
                        txtMeetingName.Text = "15th Board Meeting";
                    }
                    if (aId == 15)
                    {
                        txtMeetingName.Text = "16th Board Meeting";
                    }
                    if (aId == 16)
                    {
                        txtMeetingName.Text = "17th Board Meeting";
                    }
                    if (aId == 17)
                    {
                        txtMeetingName.Text = "18th Board Meeting";
                    }
                    if (aId == 18)
                    {
                        txtMeetingName.Text = "19th Board Meeting";
                    }
                    if (aId == 19)
                    {
                        txtMeetingName.Text = "20th Board Meeting";
                    }

                    if (aId == 20)
                    {
                        txtMeetingName.Text = "21th Board Meeting";
                    }
                    if (aId == 21)
                    {
                        txtMeetingName.Text = "22th Board Meeting";
                    }
                    if (aId == 22)
                    {
                        txtMeetingName.Text = "23th Board Meeting";
                    }
                    if (aId == 23)
                    {
                        txtMeetingName.Text = "24th Board Meeting";
                    }
                    if (aId == 24)
                    {
                        txtMeetingName.Text = "25th Board Meeting";
                    }
                    if (aId == 25)
                    {
                        txtMeetingName.Text = "26th Board Meeting";
                    }
                    if (aId == 26)
                    {
                        txtMeetingName.Text = "27th Board Meeting";
                    }
                    if (aId == 27)
                    {
                        txtMeetingName.Text = "28th Board Meeting";
                    }

                    if (aId == 28)
                    {
                        txtMeetingName.Text = "29th Board Meeting";
                    }
                    if (aId == 29)
                    {
                        txtMeetingName.Text = "30th Board Meeting";
                    }
                    if (aId == 30)
                    {
                        txtMeetingName.Text = "31th Board Meeting";
                    }
                    if (aId == 31)
                    {
                        txtMeetingName.Text = "32th Board Meeting";
                    }
                    if (aId == 32)
                    {
                        txtMeetingName.Text = "33th Board Meeting";
                    }
                    if (aId == 33)
                    {
                        txtMeetingName.Text = "34th Board Meeting";
                    }
                    if (aId == 34)
                    {
                        txtMeetingName.Text = "35th Board Meeting";
                    }
                    if (aId == 35)
                    {
                        txtMeetingName.Text = "36th Board Meeting";
                    }

                    if (aId == 36)
                    {
                        txtMeetingName.Text = "37th Board Meeting";
                    }
                    if (aId == 37)
                    {
                        txtMeetingName.Text = "38th Board Meeting";
                    }
                    if (aId == 38)
                    {
                        txtMeetingName.Text = "39th Board Meeting";
                    }
                    if (aId == 39)
                    {
                        txtMeetingName.Text = "40th Board Meeting";
                    }
                    if (aId == 40)
                    {
                        txtMeetingName.Text = "41th Board Meeting";
                    }
                    if (aId == 41)
                    {
                        txtMeetingName.Text = "42th Board Meeting";
                    }
                    if (aId == 42)
                    {
                        txtMeetingName.Text = "43th Board Meeting";
                    }
                    if (aId == 43)
                    {
                        txtMeetingName.Text = "44th Board Meeting";
                    }

                    if (aId == 44)
                    {
                        txtMeetingName.Text = "45th Board Meeting";
                    }
                    if (aId == 45)
                    {
                        txtMeetingName.Text = "46th Board Meeting";
                    }
                    if (aId == 46)
                    {
                        txtMeetingName.Text = "47th Board Meeting";
                    }
                    if (aId == 47)
                    {
                        txtMeetingName.Text = "48th Board Meeting";
                    }
                    if (aId == 48)
                    {
                        txtMeetingName.Text = "49th Board Meeting";
                    }
                    if (aId == 49)
                    {
                        txtMeetingName.Text = "50th Board Meeting";
                    }
                    if (aId == 50)
                    {
                        txtMeetingName.Text = "51th Board Meeting";
                    }
                    if (aId == 51)
                    {
                        txtMeetingName.Text = "52th Board Meeting";
                    }

                    if (aId == 52)
                    {
                        txtMeetingName.Text = "53th Board Meeting";
                    }
                    if (aId == 53)
                    {
                        txtMeetingName.Text = "54th Board Meeting";
                    }
                    if (aId == 54)
                    {
                        txtMeetingName.Text = "55th Board Meeting";
                    }
                    if (aId == 55)
                    {
                        txtMeetingName.Text = "56th Board Meeting";
                    }
                    if (aId == 56)
                    {
                        txtMeetingName.Text = "57th Board Meeting";
                    }
                    if (aId == 57)
                    {
                        txtMeetingName.Text = "58th Board Meeting";
                    }
                    if (aId == 58)
                    {
                        txtMeetingName.Text = "59th Board Meeting";
                    }
                    if (aId == 59)
                    {
                        txtMeetingName.Text = "60th Board Meeting";
                    }

                    if (aId == 60)
                    {
                        txtMeetingName.Text = "61th Board Meeting";
                    }
                    if (aId == 61)
                    {
                        txtMeetingName.Text = "62th Board Meeting";
                    }
                    if (aId == 62)
                    {
                        txtMeetingName.Text = "63th Board Meeting";
                    }
                    if (aId == 63)
                    {
                        txtMeetingName.Text = "64th Board Meeting";
                    }
                    if (aId == 64)
                    {
                        txtMeetingName.Text = "65th Board Meeting";
                    }
                    if (aId == 65)
                    {
                        txtMeetingName.Text = "66th Board Meeting";
                    }
                    if (aId == 66)
                    {
                        txtMeetingName.Text = "67th Board Meeting";
                    }
                    if (aId == 67)
                    {
                        txtMeetingName.Text = "68th Board Meeting";
                    }
                    if (aId == 68)
                    {
                        txtMeetingName.Text = "69th Board Meeting";
                    }
                    if (aId == 69)
                    {
                        txtMeetingName.Text = "70th Board Meeting";
                    }
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MeetingEntry_Load(object sender, EventArgs e)
        {
            GetAgendaDetails();
            CompanyNameLoad();
            BoardNameLoad();
            AgendaHeaderLoad();
            GetMeetingTitle();

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
        private void Reset()
        {
            //companyNameComboBox.SelectedIndex = -1;
            //boardNameComboBox.SelectedIndex = -1;
            //meetingNameTextBox.Clear();
            cmbVenue.SelectedIndex = -1;
            txtMeetingDate.Value=DateTime.Today;
        }

        private void GenerateSerialNumberForMeeting()
        {
           String sDate = DateTime.Now.ToString();
           DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));
           String dy = datevalue.Day.ToString();
           String mn = datevalue.Month.ToString();
           String yy = datevalue.Year.ToString();
             //referenceNo = "OIA-" + sClientIdForRefNum + "-" + sQN + "-" + quotationId +"";
            serialNo = yy + boardId + "" + currentMeetingId; 
        }
        private void saveButton_Click(object sender, EventArgs e)
        {                      
                try
                {                    
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string query2 = "insert into Meeting(AHeaderId,MeetingName,MeetingLocation,MeetingDate,BoardId,UserId,DateTime) values (@d1,@d2,@d3,@d4,@d5,@d6)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                    cmd = new SqlCommand(query2, con);
                    cmd.Parameters.AddWithValue("@d1", addHId);
                    cmd.Parameters.AddWithValue("@d2", txtMeetingName.Text);
                    cmd.Parameters.AddWithValue("@d3", cmbVenue.Text);
                    cmd.Parameters.AddWithValue("@d4", txtMeetingDate.Value.Date);                                  
                    cmd.Parameters.AddWithValue("@d5", boardId);
                    cmd.Parameters.AddWithValue("@d6", userId);
                    cmd.Parameters.AddWithValue("@d7", DateTime.UtcNow.ToLocalTime());
                    currentMeetingId = (int)cmd.ExecuteScalar();
                    con.Close();
                    Reset();
                    MessageBox.Show("Saved Sucessfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
           
        }
        

        private void MeetingEntry_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            MainUI mainUI = new MainUI();
            mainUI.Show();
        }                
        private void cmbVenue_SelectedIndexChanged(object sender, EventArgs e)
        {            
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT AHeaderId from AddressHeader WHERE AHeaderName= '" + cmbVenue.Text + "'";
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
        private void addButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow dr = dataGridView1.SelectedRows[0];
                    agendaId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    if (listView1.Items.Count == 0)
                    {
                        ListViewItem lst = new ListViewItem();
                        lst.Text = dr.Cells[0].Value.ToString();
                        lst.SubItems.Add(dr.Cells[1].Value.ToString());
                        lst.SubItems.Add(dr.Cells[2].Value.ToString());
                        lst.SubItems.Add(dr.Cells[3].Value.ToString());
                        lst.SubItems.Add(dr.Cells[4].Value.ToString());
                        lst.SubItems.Add(dr.Cells[5].Value.ToString());
                        lst.SubItems.Add(dr.Cells[6].Value.ToString());
                        lst.SubItems.Add(dr.Cells[7].Value.ToString());
                        lst.SubItems.Add(dr.Cells[8].Value.ToString());
                        lst.SubItems.Add(dr.Cells[9].Value.ToString());
                        listView1.Items.Add(lst);
                    }
                    else if (listView1.FindItemWithText(agendaId.ToString()) == null)
                    {
                        ListViewItem lst1 = new ListViewItem();
                        lst1.Text = dr.Cells[0].Value.ToString();
                        lst1.SubItems.Add(dr.Cells[1].Value.ToString());
                        lst1.SubItems.Add(dr.Cells[2].Value.ToString());
                        lst1.SubItems.Add(dr.Cells[3].Value.ToString());
                        lst1.SubItems.Add(dr.Cells[4].Value.ToString());
                        lst1.SubItems.Add(dr.Cells[5].Value.ToString());
                        lst1.SubItems.Add(dr.Cells[6].Value.ToString());
                        lst1.SubItems.Add(dr.Cells[7].Value.ToString());
                        lst1.SubItems.Add(dr.Cells[8].Value.ToString());
                        lst1.SubItems.Add(dr.Cells[9].Value.ToString());
                        listView1.Items.Add(lst1);
                    }
                    else
                    {
                        MessageBox.Show("You Can Not Add Same Item More than one times", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }                     

        //    if (listView1.Items.Count == 0)
        //    {
        //        ListViewItem list = new ListViewItem();
        //        list.SubItems.Add(txtAgendaHeader.Text);
        //        list.SubItems.Add(txtAgendaTitle.Text);
        //        list.SubItems.Add(txtMemoName.Text);
        //        list.SubItems.Add(agendaType);
        //        list.SubItems.Add(agendaTypeId.ToString());

        //        listView1.Items.Add(list);
        //        txtAgendaHeader.Clear();
        //        txtAgendaTitle.Clear();
        //        txtMemoName.Clear();               
        //        return;
        //    }
        //    ListViewItem list1 = new ListViewItem();
        //    list1.SubItems.Add(txtAgendaHeader.Text);
        //    list1.SubItems.Add(txtAgendaTitle.Text);
        //    list1.SubItems.Add(txtMemoName.Text);
        //    list1.SubItems.Add(agendaType);
        //    list1.SubItems.Add(agendaTypeId.ToString());

        //    listView1.Items.Add(list1);
        //    txtAgendaHeader.Clear();
        //    txtAgendaTitle.Clear();
        //    txtMemoName.Clear();       
        //    return;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
          


                // DataGridViewRow dr = dataGridView1.CurrentRow;                                          
                //txtAgendaHeader.Text = dr.Cells[0].Value.ToString();
                //txtAgendaTitle.Text = dr.Cells[1].Value.ToString();
                //txtMemoName.Text = dr.Cells[2].Value.ToString();
                // agendaType = dr.Cells[3].Value.ToString();
                // agendaTypeId = dr.Cells[4].Value.ToString();
                labelk = labelg;
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    try
                    {
                        DataGridViewRow dr = dataGridView1.SelectedRows[0];
                        agendaId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                        if (listView1.Items.Count == 0)
                        {
                            ListViewItem lst = new ListViewItem();
                            lst.Text = dr.Cells[0].Value.ToString();
                            lst.SubItems.Add(dr.Cells[1].Value.ToString());
                            lst.SubItems.Add(dr.Cells[2].Value.ToString());
                            lst.SubItems.Add(dr.Cells[3].Value.ToString());
                            lst.SubItems.Add(dr.Cells[4].Value.ToString());
                            lst.SubItems.Add(dr.Cells[5].Value.ToString());
                            lst.SubItems.Add(dr.Cells[6].Value.ToString());
                            lst.SubItems.Add(dr.Cells[7].Value.ToString());
                            lst.SubItems.Add(dr.Cells[8].Value.ToString());
                            lst.SubItems.Add(dr.Cells[9].Value.ToString());
                            listView1.Items.Add(lst);
                        }
                        else if (listView1.FindItemWithText(agendaId.ToString()) == null)
                        {
                            ListViewItem lst1 = new ListViewItem();
                            lst1.Text = dr.Cells[0].Value.ToString();
                            lst1.SubItems.Add(dr.Cells[1].Value.ToString());
                            lst1.SubItems.Add(dr.Cells[2].Value.ToString());
                            lst1.SubItems.Add(dr.Cells[3].Value.ToString());
                            lst1.SubItems.Add(dr.Cells[4].Value.ToString());
                            lst1.SubItems.Add(dr.Cells[5].Value.ToString());
                            lst1.SubItems.Add(dr.Cells[6].Value.ToString());
                            lst1.SubItems.Add(dr.Cells[7].Value.ToString());
                            lst1.SubItems.Add(dr.Cells[8].Value.ToString());
                            lst1.SubItems.Add(dr.Cells[9].Value.ToString());
                            listView1.Items.Add(lst1);
                        }
                        else
                        {
                            MessageBox.Show("You Can Not Add Same Item More than one times", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }                     
           }

        private void meetingListGroupBox_Enter(object sender, EventArgs e)
        {

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
