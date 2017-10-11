using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Security.RightsManagement;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BoardSecretariatSystem.DBGateway;

namespace BoardSecretariatSystem
{

    public partial class AgendaEntryUI : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        private ConnectionString cs = new ConnectionString();
        private delegate void ChangeFocusDelegate(Control ctl);
        public string userId, boardId, companyId, labelv, labelg, nParticipantId, nUserId,dragtid;
        public int agendaId,  meetingId, participantId, agendaId1;
        public Nullable<decimal> aId, aId1,agendaTypeId1,agendaTypeId,aIdK;
        public AgendaEntryUI()
        {            
            InitializeComponent();
        }
        private void changeFocus(Control ctl)
        {
            ctl.Focus();
        }
        private void AgendaEntryUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            MainUI mainUI = new MainUI();
            mainUI.Show();
        }
        public void CompanyNameLoad()
        {         
        }
        private void SaveMeetingAgenda()
        {
            try
            {
                for (int i = 0; i <= listView1.Items.Count - 1; i++)
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "insert into MeetingParticipant(MeetingId,AgendaId) VALUES(@d1,@d2)";
                    cmd = new SqlCommand(cb, con);
                    cmd.Parameters.AddWithValue("d1", meetingId);
                    cmd.Parameters.AddWithValue("d2", listView1.Items[i].SubItems[1].Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void SaveMeetingParticipant()
        {
            try
            {
                for (int i = 0; i <= listView1.Items.Count - 1; i++)
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string cb = "insert into MeetingParticipant(MeetingId,ParticipantId) VALUES(@d1,@d2)";
                    cmd = new SqlCommand(cb,con);                    
                    cmd.Parameters.AddWithValue("d1", meetingId);
                    cmd.Parameters.AddWithValue("d2", listView1.Items[i].SubItems[4].Text);
                    cmd.ExecuteNonQuery();                    
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void GetAgendaDetails2()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT Agenda.AgendaId,Agenda.AgendaTitle,AgendaTypes.AgendaType,AgendaTypes.AgendaTypeId FROM  Agenda inner join AgendaTypes on Agenda.AgendaTypeId=AgendaTypes.AgendaTypeId Where AgendaTypes.AgendaTypeId= 1 Union SELECT  Agenda.AgendaId, Agenda.AgendaTitle,AgendaTypes.AgendaType,Agenda.AgendaTypeId FROM   Agenda inner  join AgendaTypes on Agenda.AgendaTypeId=AgendaTypes.AgendaTypeId Where Agenda.AgendaTypeId<> 1 and AgendaId not in( Select Agenda.AgendaId from SelectedAgenda inner join Agenda on Agenda.AgendaId=SelectedAgenda.AgendaId) order by Agenda.AgendaId", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2],rdr[3]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetAgendaDetails()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT  Agenda.AgendaId, Agenda.AgendaTitle,AgendaTypes.AgendaType,Agenda.AgendaTypeId FROM   Agenda inner  join AgendaTypes on Agenda.AgendaTypeId=AgendaTypes.AgendaTypeId Where Agenda.AgendaTypeId<> 1 and AgendaId not in( Select Agenda.AgendaId from SelectedAgenda inner join Agenda on Agenda.AgendaId=SelectedAgenda.AgendaId) order by Agenda.AgendaId", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetAgendaDetails3()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT Agenda.AgendaId,Agenda.AgendaTitle,AgendaTypes.AgendaType,AgendaTypes.AgendaTypeId FROM  Agenda inner join AgendaTypes on Agenda.AgendaTypeId=AgendaTypes.AgendaTypeId Where AgendaTypes.AgendaTypeId= 1 order by Agenda.AgendaId", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView2.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView2.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetAgendaHeader()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "Select Agenda.AgendaTypeId From  Agenda  where Agenda.AgendaTypeId=1 OR Agenda.AgendaTypeId=2 OR Agenda.AgendaTypeId=3";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                   agendaTypeId = (rdr.GetInt32(0));
                }
                con.Close();

                if (agendaTypeId ==1 || agendaTypeId==2 || agendaTypeId== 3)
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();                    
                    string qr2 = "SELECT MAX(Agenda.AgendaNo) FROM Agenda";
                    cmd = new SqlCommand(qr2, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        aId = (rdr.GetInt32(0));
                        if (aId >= 1)
                        {
                            aId = aId+1;
                            txtAgendaHeader.Text = "Agenda-"+aId;
                        }                        
                    }
                }
                else
                {
                    aId = 1;
                    txtAgendaHeader.Text = "Agenda-1";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GetAgendaId()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctt = "SELECT IDENT_CURRENT ('Agenda')";
                cmd = new SqlCommand(ctt);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    aId = (rdr.GetDecimal(0));
                    aId = 1;
                   
                    txtAgendaHeader.Text = "Agenda-" +aId;
                }                              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadAgendaType()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctt = "select AgendaType from AgendaTypes order by AgendaTypes.AgendaTypeId desc";
                cmd = new SqlCommand(ctt);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbAgendaType.Items.Add(rdr.GetValue(0).ToString());
                }
                cmbAgendaType.Items.Add("Not In The List");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AgendaEntryUI_Load(object sender, EventArgs e)
        {
            userId = frmLogin.uId.ToString();          
            GetAgendaHeader();
            CompanyNameLoad();
            GetAgendaDetails();
            GetAgendaDetails3();
            LoadAgendaType();
        }      
       
       
        private void agendaSaveButton_Click(object sender, EventArgs e)
        {                                
               try
                {
                    if (listView1.Items.Count == 0)
                    {
                        MessageBox.Show("Please add agenda in the list before submit", "error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return;

                    }
                    for (int i = 0; i <= listView1.Items.Count - 1; i++)
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string query1 = "insert into Agenda(AgendaTopics,AgendaTitle,AgendaTypeId,AgendaNo,UserId,DateTime) values(@d1,@d2,@d3,@d4,@d5,@d6)";
                        cmd = new SqlCommand(query1, con);
                        cmd.Parameters.AddWithValue("@d1", listView1.Items[i].SubItems[1].Text);
                        cmd.Parameters.AddWithValue("@d2", listView1.Items[i].SubItems[2].Text);                       
                        cmd.Parameters.AddWithValue("@d3", listView1.Items[i].SubItems[4].Text);
                        cmd.Parameters.AddWithValue("@d4", listView1.Items[i].SubItems[5].Text);
                        cmd.Parameters.AddWithValue("@d5", userId);
                        cmd.Parameters.AddWithValue("@d6", DateTime.UtcNow.ToLocalTime());
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }                  
                    MessageBox.Show("Saved Sucessfully", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   dataGridView1.Rows.Clear();
                    GetAgendaDetails();
                    GetAgendaDetails3();
                   listView1.Items.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
           
        }                    
      
        private void button1_Click_2(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAgendaTitle.Text))
            {
                MessageBox.Show("Please enter agenda title", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(cmbAgendaType.Text))
            {
                MessageBox.Show("Please select agenda type", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ++aId;
            if (listView1.Items.Count == 0)
            {
                ListViewItem list = new ListViewItem();
                list.SubItems.Add(txtAgendaHeader.Text);
                list.SubItems.Add(txtAgendaTitle.Text);               
                list.SubItems.Add(cmbAgendaType.Text);
                list.SubItems.Add(agendaTypeId.ToString());
                aIdK = aId - 1;
                list.SubItems.Add(aIdK.ToString());
                listView1.Items.Add(list);            
                txtAgendaHeader.Text = "Agenda-" + aId;
                txtAgendaTitle.Clear();
                cmbAgendaType.SelectedIndex = -1;               
                return;
            }
            ListViewItem list1 = new ListViewItem();
            list1.SubItems.Add(txtAgendaHeader.Text);
            list1.SubItems.Add(txtAgendaTitle.Text);          
            list1.SubItems.Add(cmbAgendaType.Text);
            list1.SubItems.Add(agendaTypeId.ToString());
            aIdK = aId - 1;
            list1.SubItems.Add(aIdK.ToString());
            listView1.Items.Add(list1);            
            txtAgendaHeader.Text = "Agenda-" + aId;
            txtAgendaTitle.Clear();
            cmbAgendaType.SelectedIndex = -1;       
            return;
        }

        private void cmbAgendaType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAgendaType.Text == "Not In The List")
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Please Input New Agenda Type  Here", "Input Here", "", -1, -1);
                if (string.IsNullOrWhiteSpace(input))
                {
                    cmbAgendaType.SelectedIndex = -1;
                }

                else
                {                    
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 = "select AgendaType from AgendaTypes where AgendaType='" + input + "'";
                    cmd = new SqlCommand(ct2, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() && !rdr.IsDBNull(0))
                    {
                        MessageBox.Show("This  Agenda Types  Already Exists,Please Select From List", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                        cmbAgendaType.SelectedIndex = -1;
                    }
                    else
                    {
                        try
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string query1 = "insert into AgendaTypes(AgendaType) values (@d1)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            cmd = new SqlCommand(query1, con);
                            cmd.Parameters.AddWithValue("@d1", input);                            
                            cmd.ExecuteNonQuery();
                            con.Close();
                            cmbAgendaType.Items.Clear();
                            LoadAgendaType();
                            cmbAgendaType.SelectedText = input;
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
                    cmd.CommandText = "SELECT AgendaTypeId from AgendaTypes WHERE AgendaType= '" + cmbAgendaType.Text + "'";
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        agendaTypeId = rdr.GetInt32(0);
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

        private void txtAgendaTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbAgendaType.Focus();
                e.Handled = true;
            }
        }

        private void cmbAgendaType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Focus();
                e.Handled = true;
            }
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                agendaSaveButton.Focus();
                e.Handled = true;
            }
        }

        
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            DataGridViewRow drs = dataGridView2.CurrentRow;
            dragtid = drs.Cells[3].Value.ToString();

            if (dragtid == "1")
            {
                txtAgendaTitle.Text = drs.Cells[1].Value.ToString();

            }

        }

        }
    }





