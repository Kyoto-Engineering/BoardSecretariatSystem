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
        public int meetingNum, meetingNum1, meetingId;
        private bool invitationSend, attendanceTaken, agendaSelected;

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
                cmd = new SqlCommand("(SELECT Agenda.AgendaId, Agenda.AgendaTopics, Agenda.AgendaTitle, AgendaTypes.AgendaType, AgendaTypes.AgendaTypeId FROM Agenda INNER JOIN AgendaTypes ON Agenda.AgendaTypeId = AgendaTypes.AgendaTypeId WHERE        (AgendaTypes.AgendaTypeId = 1) union SELECT        Agenda.AgendaId, Agenda.AgendaTopics, Agenda.AgendaTitle, AgendaTypes.AgendaType, AgendaTypes.AgendaTypeId FROM Agenda INNER JOIN  AgendaTypes ON Agenda.AgendaTypeId = AgendaTypes.AgendaTypeId where AgendaTypes.AgendaTypeId<>1 and Agenda.AgendaId not in  (select AgendaId from SelectedAgenda )) except SELECT        Agenda.AgendaId, Agenda.AgendaTopics, Agenda.AgendaTitle, AgendaTypes.AgendaType, AgendaTypes.AgendaTypeId FROM   Agenda INNER JOIN AgendaTypes ON Agenda.AgendaTypeId = AgendaTypes.AgendaTypeId INNER JOIN  SelectedAgenda ON Agenda.AgendaId = SelectedAgenda.AgendaId WHERE  (SelectedAgenda.MeetingId =@d1)", con);
                cmd.Parameters.AddWithValue("d1", meetingId);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add( rdr[0], rdr[1], rdr[2], rdr[3],rdr[4]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void GetMeetingTitle()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string qr2 = "SELECT MAX(Meeting.MeetingId),MAX(Meeting.MeetingNo) FROM Meeting";
                cmd = new SqlCommand(qr2, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if (!(rdr.IsDBNull(0)))
                    {
                        meetingId = (rdr.GetInt32(0));
                        meetingNum = (rdr.GetInt32(1));
                        txtMeetingNumber.Text = meetingNum.ToString();
                        txtMeetingTitle.Text = Ordinal(meetingNum) + " Board Meeting";
                    }
                    else
                    {
                        MessageBox.Show("Please Create  or Shedule a meeting First.", "error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return;
                        
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
            
            GetMeetingTitle();
            GetAgendaDetails();
            SetExistingMeetingMemberInList();
            MeetingInfo();


        }
        private void MeetingInfo()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "SELECT MeetingId, MeetingNo, InvitationSend, AttendenceTaken,AllAgendaSelected FROM Meeting where Statuss='Open' and MeetingTypeId=1";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    invitationSend = rdr.GetBoolean(2);
                    attendanceTaken = rdr.GetBoolean(3);
                    agendaSelected = rdr.GetBoolean(4);
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
        private void SetExistingMeetingMemberInList()
        {
            
            con = new SqlConnection(cs.DBConn);
            string qry = "SELECT        Agenda.AgendaId, Agenda.AgendaTopics, Agenda.AgendaTitle, AgendaTypes.AgendaType, AgendaTypes.AgendaTypeId FROM   Agenda INNER JOIN AgendaTypes ON Agenda.AgendaTypeId = AgendaTypes.AgendaTypeId INNER JOIN  SelectedAgenda ON Agenda.AgendaId = SelectedAgenda.AgendaId WHERE  (SelectedAgenda.MeetingId ="+meetingId+")";
            ada = new SqlDataAdapter(qry, con);
            dt = new DataTable();
            ada.Fill(dt);

            for (int b = 0; b < dt.Rows.Count; b++)
            {
                DataRow dr = dt.Rows[b];
                ListViewItem listitem1 = new ListViewItem(dr[0].ToString());
                listitem1.SubItems.Add(dr[1].ToString());
                listitem1.SubItems.Add(dr[2].ToString());
                listitem1.SubItems.Add(dr[3].ToString());
                listitem1.SubItems.Add(dr[4].ToString());
                listView1.Items.Add(listitem1);
            }
        }
        
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
        private void UpdateMeetingStarted()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query2 = "Update  Meeting Set AllAgendaSelected=@d1 where  Meeting.MeetingId='" + meetingId + "' ";
                cmd = new SqlCommand(query2, con);
                cmd.Parameters.AddWithValue("@d1", 1);
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show(@"All Agenda Succesfully Saved");
                agendaSelected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            UpdateMeetingStarted();
        }       
        private void MeetingEntry_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
    MeetingManagementUI mainUI = new MeetingManagementUI();
            mainUI.Show();
        }
        public void ClearApprovedRequisition()
        {

            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {


                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                }

            }
            dataGridView1.Refresh();
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            if (invitationSend)
            {
                MessageBox.Show(
                    " INVITATION SEND  ALREADY. YOU CAN NOT ADD NEW AGENDA NOW    \r\n Postpone this meeteing to add again");
            }
            else
            {

                if (agendaSelected)
                {
                   DialogResult dialog= MessageBox.Show("All Agenda was selected \r\n Are you sure to add new agenda?","Confirm",
                        MessageBoxButtons.YesNo);
                    if (dialog==DialogResult.No)
                    {
                        return;
                    }
                }
                try
                {

                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        DataGridViewRow dr = dataGridView1.SelectedRows[0];
                        tAgendaId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());

                        if (listView1.Items.Count > 0)
                        {
                            int x = listView1.Items.Count - 1;
                            for (int i = 0; i <= x; i++)
                            {
                                if (tAgendaId == Convert.ToInt32(listView1.Items[i].SubItems[0].Text))
                                {
                                    MessageBox.Show("You Can Not Add Same Item More than one times", "error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            ClearApprovedRequisition();
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
                            ClearApprovedRequisition();
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

        }       
        private void meetingListGroupBox_Enter(object sender, EventArgs e)
        {

        }       
        private void removeButton_Click(object sender, EventArgs e)
        {
            if (invitationSend)
            {
                MessageBox.Show(
                    " INVITATION SEND  ALREADY. YOU CAN NOT Remove Agenda NOW    \r\n Postpone this meeteing to add again");
            }
            else
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Are You Sure?", "Confirm", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)

                    {
                        if (agendaSelected)
                        {
                            DialogResult dialog = MessageBox.Show("All Agenda was selected \r\n Are you sure to remove agenda?", "Confirm",
                                MessageBoxButtons.YesNo);
                            if (dialog == DialogResult.No)
                            {
                                return;
                            }
                        } 
                        try
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string query2 = "DELETE FROM SelectedAgenda WHERE MeetingId = @d1 AND AgendaId =@d2";
                            cmd = new SqlCommand(query2, con);
                            cmd.Parameters.AddWithValue("@d1", txtMeetingNumber.Text);
                            cmd.Parameters.AddWithValue("@d2", listView1.SelectedItems[0].Text);
                            cmd.ExecuteNonQuery();
                            con.Close();
                            dataGridView1.Rows.Clear();
                            GetAgendaDetails();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        for (int i = listView1.Items.Count - 1; i >= 0; i--)
                        {
                            if (listView1.Items[i].Selected)
                            {
                                listView1.Items[i].Remove();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Select Something First");
                }

            }
        }

        private void txtMeetingNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMeetingTitle.Focus();
                e.Handled = true;
            }
        }

        private void txtMeetingTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addButton.Focus();
                e.Handled = true;
            }
        }

        private void addButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                saveButton.Focus();
                e.Handled = true;
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells[5].Value = (e.RowIndex + 1).ToString();
        }

      
    }
}
