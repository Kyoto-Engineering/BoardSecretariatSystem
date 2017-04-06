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
using BoardSecretariatSystem.UI;

namespace BoardSecretariatSystem
{

    public partial class MeetingEntry : Form
    {

        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        private SqlDataAdapter ada;
        private ConnectionString cs = new ConnectionString();
        private DataTable dt;
        public string userId, agendaTypeId, labelk, labelg;
        public int companyId, addHId, metingTypeId;
        public int boardId,currentMeetingId,  tAgendaId;
        public string v,serialNo,agendaType;
       // public decimal aId,aId1;
        public int meetingNum, meetingNum1;

        public MeetingEntry()
        {
            
            InitializeComponent();
        }
               
        private void GetAgendaDetails()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT Agenda.AgendaId,Agenda.AgendaTopics, Agenda.AgendaTitle,AgendaTypes.AgendaType,AgendaTypes.AgendaTypeId FROM  Agenda INNER JOIN AgendaTypes ON Agenda.AgendaTypeId = AgendaTypes.AgendaTypeId", con);
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
        
        //private void GetMeetingTitle()
        //{
        //    try
        //    {
        //        con = new SqlConnection(cs.DBConn);
        //        con.Open();
        //        string ctt = "SELECT IDENT_CURRENT ('Meeting')";                
        //        cmd = new SqlCommand(ctt);
        //        cmd.Connection = con;
        //        rdr = cmd.ExecuteReader();
        //        if (rdr.Read())
        //        {
        //            aId = (rdr.GetDecimal(0));
        //            if(aId == 1)
        //            {
        //                txtMeetingNumber.Text = "1";
        //                txtMeetingTitle.Text ="1st Board Meeting";
        //            }
        //            else if (aId == 2)
        //            {
        //                txtMeetingNumber.Text = "2";
        //                txtMeetingTitle.Text = "2nd Board Meeting";
        //            }
        //            else if (aId == 3)
        //            {
        //                txtMeetingNumber.Text = "3";
        //                txtMeetingTitle.Text = "3rd Board Meeting";
        //            }
        //            else if (aId == 4)
        //            {
        //                txtMeetingNumber.Text = "4";
        //                txtMeetingTitle.Text = "4rth Board Meeting";
        //            }

        //            else if (aId >= 5)
        //            {
        //                txtMeetingNumber.Text = aId.ToString();
        //                txtMeetingTitle.Text = aId + "th Board Meeting";
        //            }
                                     
        //        }                
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        private void SaveCompanyAddress(int addHeaderId)
        {
            int aHeaderId = addHeaderId;

            if (aHeaderId == 1)
            {
                //con = new SqlConnection(cs.DBConn);
                //con.Open();
                //string insertQ = "insert into CompanyAddresses(AHeaderId,PostOfficeId,FlatNo,HouseNo,RoadNo,Block,Area,ContactNo,CompanyId) Values(@d1,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                //cmd = new SqlCommand(insertQ);
                //cmd.Connection = con;
                //cmd.Parameters.Add(new SqlParameter("@d1", string.IsNullOrEmpty(postofficeId) ? (object)DBNull.Value : postofficeId));
                //cmd.Parameters.Add(new SqlParameter("@d4", string.IsNullOrEmpty(postofficeId) ? (object)DBNull.Value : postofficeId));
                //cmd.Parameters.Add(new SqlParameter("@d5", string.IsNullOrEmpty(flatNoTextBox.Text) ? (object)DBNull.Value : flatNoTextBox.Text));
                //cmd.Parameters.Add(new SqlParameter("@d6", string.IsNullOrEmpty(houseNoTextBox.Text) ? (object)DBNull.Value : houseNoTextBox.Text));
                //cmd.Parameters.Add(new SqlParameter("@d7", string.IsNullOrEmpty(roadNoTextBox.Text) ? (object)DBNull.Value : roadNoTextBox.Text));
                //cmd.Parameters.Add(new SqlParameter("@d8", string.IsNullOrEmpty(blockTextBox.Text) ? (object)DBNull.Value : blockTextBox.Text));
                //cmd.Parameters.Add(new SqlParameter("@d9", string.IsNullOrEmpty(areaTextBox.Text) ? (object)DBNull.Value : areaTextBox.Text));
                //cmd.Parameters.Add(new SqlParameter("@d10", string.IsNullOrEmpty(contactNoTextBox.Text) ? (object)DBNull.Value : contactNoTextBox.Text));
                //cmd.Parameters.AddWithValue("@d11", currentCompanyId);
                //affectedRows1 = (int)cmd.ExecuteScalar();
                con.Close();
            }
 
        }
        private void LoadExistingAgenda()
        {
            //listView1.View = View.Details;
            //con = new SqlConnection(cs.DBConn);
            //string qry = "SELECT RTRIM(Ledger.LedgerName),RTRIM(Ledger.LedgerId),RTRIM(MPBYearOpening.CarriedBalance),RTRIM(BalanceFiscal.LId),RTRIM(Ledger.AGRelId)  FROM Ledger INNER JOIN  BalanceFiscal ON Ledger.LedgerId = BalanceFiscal.LedgerId INNER JOIN  MPBYearOpening ON BalanceFiscal.LId = MPBYearOpening.LId INNER JOIN  YearOpeningEvent ON MPBYearOpening.EventId = YearOpeningEvent.EventId where (Ledger.AGRelId=1 or Ledger.AGRelId=6) and YearOpeningEvent.FiscalId='" + fiscalLE3Year + "'";
            //ada = new SqlDataAdapter(qry, con);
            //dt = new DataTable();
            //ada.Fill(dt);

            //for (int b = 0; b < dt.Rows.Count; b++)
            //{
            //    DataRow dr = dt.Rows[b];
            //    ListViewItem listitem1 = new ListViewItem(dr[0].ToString());
            //    listitem1.SubItems.Add(dr[1].ToString());
            //    listitem1.SubItems.Add(dr[2].ToString());

            //    listitem1.SubItems.Add(dr[3].ToString());
            //    listitem1.SubItems.Add(dr[4].ToString());
            //    //listitem1.SubItems.Add(dr[5].ToString());
            //    listView1.Items.Add(listitem1);
            //}
        }

        private void GetMeetingTitle()
        {
            try
            {                              
                    con = new SqlConnection(cs.DBConn);
                    con.Open();                   
                    string qr2 = "SELECT MAX(Meeting.MeetingNo) FROM Meeting";
                    cmd = new SqlCommand(qr2, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        meetingNum = (rdr.GetInt32(0));
                        if (meetingNum == 1)
                        {
                            txtMeetingNumber.Text = meetingNum.ToString();
                            txtMeetingTitle.Text = "1st Board Meeting";
                        }
                        else if (meetingNum == 2)
                        {
                            txtMeetingNumber.Text = meetingNum.ToString();
                            txtMeetingTitle.Text = "2nd Board Meeting";
                        }

                        else if (meetingNum == 3)
                        {
                            txtMeetingNumber.Text = meetingNum.ToString();
                            txtMeetingTitle.Text = "3rd Board Meeting";
                        }

                        else if (meetingNum >= 4)
                        {
                            txtMeetingNumber.Text = meetingNum.ToString();
                            txtMeetingTitle.Text = meetingNum + "th Board Meeting";
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
            userId = frmLogin.uId.ToString();
            GetAgendaDetails();
           
            GetMeetingTitle();

        }
        //public void CompanyNameLoad()
        //{
        //    try
        //    {
        //        con = new SqlConnection(cs.DBConn);
        //        con.Open();
        //        string query = "SELECT CompanyName FROM Company ";
        //        cmd = new SqlCommand(query, con);
        //        rdr = cmd.ExecuteReader();
        //        if (rdr.Read())
        //        {
        //            txtCompanyName.Text = (rdr.GetString(0));
        //        }
        //        con.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}                     
              
        private void SaveSelectedAgenda()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query2 = "insert into SelectedAgenda(MeetingId,AgendaId) values (@d1,@d2)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                cmd = new SqlCommand(query2, con);
                cmd.Parameters.AddWithValue("@d1", txtMeetingNumber.Text);
                cmd.Parameters.AddWithValue("@d2", tAgendaId);
                currentMeetingId = (int)cmd.ExecuteScalar();
                con.Close();  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            //if (listView1.Items.Count == 0)
            //{
            //    MessageBox.Show("Please Select the item from the grid and into the list", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //else
            //{
            //    try
            //    {
            //        SaveSelectedAgenda();               
                    
            //        MessageBox.Show(" All Saved Sucessfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}

        }
        

        private void MeetingEntry_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
    MeetingManagementUI mainUI = new MeetingManagementUI();
            mainUI.Show();
        }                
        private void cmbVenue_SelectedIndexChanged(object sender, EventArgs e)
        {            
                //try
                //{
                //    con = new SqlConnection(cs.DBConn);
                //    con.Open();
                //    cmd = con.CreateCommand();
                //    cmd.CommandText = "SELECT AHeaderId from AddressHeader WHERE AHeaderName= '" + cmbVenue.Text + "'";
                //    rdr = cmd.ExecuteReader();
                //    if (rdr.Read())
                //    {
                //        addHId = rdr.GetInt32(0);
                //    }
                //    if ((rdr != null))
                //    {
                //        rdr.Close();
                //    }
                //    if (con.State == ConnectionState.Open)
                //    {
                //        con.Close();
                //    }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}           
        }      
        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                   
              if (dataGridView1.SelectedRows.Count > 0)
                 {                                                  
                    DataGridViewRow dr = dataGridView1.SelectedRows[0];
                    tAgendaId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                   
                    if (listView1.Items.Count>0)
                    {
                       int x = listView1.Items.Count - 1;
                       for (int i = 0; i <= x; i++)
                        {                          
                               if (tAgendaId == Convert.ToInt32(listView1.Items[i].SubItems[0].Text))
                               {
                                   MessageBox.Show("You Can Not Add Same Item More than one times", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                   return;                                                                
                               }
                              
                          
                        }
                       ListViewItem lst1 = new ListViewItem();
                       lst1.Text = dr.Cells[0].Value.ToString();
                       lst1.SubItems.Add(dr.Cells[1].Value.ToString());
                       lst1.SubItems.Add(dr.Cells[2].Value.ToString());
                       lst1.SubItems.Add(dr.Cells[3].Value.ToString());
                       lst1.SubItems.Add(dr.Cells[4].Value.ToString());
                       listView1.Items.Add(lst1);
                       SaveSelectedAgenda();
                     }

                    if (listView1.Items.Count == 0)
                    {
                        ListViewItem lst = new ListViewItem();
                        lst.Text = dr.Cells[0].Value.ToString();
                        lst.SubItems.Add(dr.Cells[1].Value.ToString());
                        lst.SubItems.Add(dr.Cells[2].Value.ToString());
                        lst.SubItems.Add(dr.Cells[3].Value.ToString());
                        lst.SubItems.Add(dr.Cells[4].Value.ToString());
                        listView1.Items.Add(lst);
                        SaveSelectedAgenda();
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

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
          


                // DataGridViewRow dr = dataGridView1.CurrentRow;                                          
                //txtAgendaHeader.Text = dr.Cells[0].Value.ToString();
                //txtAgendaTitle.Text = dr.Cells[1].Value.ToString();
                //txtMemoName.Text = dr.Cells[2].Value.ToString();
                // agendaType = dr.Cells[3].Value.ToString();
                // agendaTypeId = dr.Cells[4].Value.ToString();
              //  labelk = labelg;
                //if (dataGridView1.SelectedRows.Count > 0)
                //{
                //    try
                //    {
                //        DataGridViewRow dr = dataGridView1.SelectedRows[0];
                //        agendaId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                //        if (listView1.Items.Count == 0)
                //        {
                //            ListViewItem lst = new ListViewItem();
                //            lst.Text = dr.Cells[0].Value.ToString();
                //            lst.SubItems.Add(dr.Cells[1].Value.ToString());
                //            lst.SubItems.Add(dr.Cells[2].Value.ToString());
                //            lst.SubItems.Add(dr.Cells[3].Value.ToString());
                //            lst.SubItems.Add(dr.Cells[4].Value.ToString());
                //            lst.SubItems.Add(dr.Cells[5].Value.ToString());
                //            lst.SubItems.Add(dr.Cells[6].Value.ToString());
                //            lst.SubItems.Add(dr.Cells[7].Value.ToString());
                //            lst.SubItems.Add(dr.Cells[8].Value.ToString());
                //            lst.SubItems.Add(dr.Cells[9].Value.ToString());
                //            listView1.Items.Add(lst);
                //        }
                //        else if (listView1.FindItemWithText(agendaId.ToString()) == null)
                //        {
                //            ListViewItem lst1 = new ListViewItem();
                //            lst1.Text = dr.Cells[0].Value.ToString();
                //            lst1.SubItems.Add(dr.Cells[1].Value.ToString());
                //            lst1.SubItems.Add(dr.Cells[2].Value.ToString());
                //            lst1.SubItems.Add(dr.Cells[3].Value.ToString());
                //            lst1.SubItems.Add(dr.Cells[4].Value.ToString());
                //            lst1.SubItems.Add(dr.Cells[5].Value.ToString());
                //            lst1.SubItems.Add(dr.Cells[6].Value.ToString());
                //            lst1.SubItems.Add(dr.Cells[7].Value.ToString());
                //            lst1.SubItems.Add(dr.Cells[8].Value.ToString());
                //            lst1.SubItems.Add(dr.Cells[9].Value.ToString());
                //            listView1.Items.Add(lst1);
                //        }
                //        else
                //        {
                //            MessageBox.Show("You Can Not Add Same Item More than one times", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //            return;
                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //}                     
           }

        private void meetingListGroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void txtBoardName_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    con = new SqlConnection(cs.DBConn);
            //    con.Open();
            //    cmd = con.CreateCommand();
            //    cmd.CommandText = "SELECT BoardId from Board WHERE BoardName= '" + txtBoardName.Text + "'";
            //    rdr = cmd.ExecuteReader();
            //    if (rdr.Read())
            //    {
            //        boardId = rdr.GetInt32(0);
            //    }
            //    if ((rdr != null))
            //    {
            //        rdr.Close();
            //    }
            //    if (con.State == ConnectionState.Open)
            //    {
            //        con.Close();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}           
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
           
           
            for (int i = listView1.Items.Count - 1; i >= 0; i--)
            {
                if (listView1.Items[i].Selected)
                {
                    listView1.Items[i].Remove();
                }
            }
        }

        private void txtMeetingName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
