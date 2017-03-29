using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
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
        public string userId, boardId, companyId, labelv, labelg, nParticipantId, nUserId;
        public int agendaId, agendaTypeId, meetingId, participantId, aId, agendaId1;
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
        private void GetAgendaDetails()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT Agenda.AgendaTopics,Agenda.AgendaTitle,AgendaTypes.AgendaType,AgendaTypes.AgendaTypeId  FROM  Agenda INNER JOIN AgendaTypes ON Agenda.AgendaTypeId = AgendaTypes.AgendaTypeId", con);
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
        private void GetAgendaId()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctt = "Select MAX(AgendaId) from Agenda ";
                cmd = new SqlCommand(ctt);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    aId = (rdr.GetInt32(0));
                    aId += 1;
                   // string[] tokens = agendaId1.Split('-');
                    //aId = Convert.ToInt32(tokens[1]);
                    txtAgendaHeader.Text = "Agenda-" +aId;
                }
                //if (!rdr.Read())
                //{
                   
                //    txtAgendaHeader.Text = "Agenda-1";
                //}
                

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
            GetAgendaId();
            CompanyNameLoad();
            GetAgendaDetails();
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
                    for (int i = 0; i < listView1.Items.Count - 1; i++)
                    {
                        con = new SqlConnection(cs.DBConn);
                        con.Open();
                        string query1 = "insert into Agenda(AgendaTopics,AgendaTitle,AgendaTypeId,UserId,DateTime) values (@d1,@d2,@d4,@d5,@d6)";
                        cmd = new SqlCommand(query1, con);
                        cmd.Parameters.AddWithValue("@d1", listView1.Items[i].SubItems[1].Text);
                        cmd.Parameters.AddWithValue("@d2", listView1.Items[i].SubItems[2].Text);                       
                        cmd.Parameters.AddWithValue("@d4", listView1.Items[i].SubItems[4].Text);
                        cmd.Parameters.AddWithValue("@d5", userId);
                        cmd.Parameters.AddWithValue("@d6", DateTime.UtcNow.ToLocalTime());
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }                  
                    MessageBox.Show("Saved Sucessfully", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  
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
               // list.SubItems.Add(txtMemoName.Text);
                list.SubItems.Add(cmbAgendaType.Text);
                list.SubItems.Add(agendaTypeId.ToString());

                listView1.Items.Add(list);            
                txtAgendaHeader.Text = "Agenda-" + aId;
                txtAgendaTitle.Clear();
                //txtMemoName.Clear();               
                return;
            }
            ListViewItem list1 = new ListViewItem();
            list1.SubItems.Add(txtAgendaHeader.Text);
            list1.SubItems.Add(txtAgendaTitle.Text);
          //  list1.SubItems.Add(txtMemoName.Text);
            list1.SubItems.Add(cmbAgendaType.Text);
            list1.SubItems.Add(agendaTypeId.ToString());

            listView1.Items.Add(list1);            
            txtAgendaHeader.Text = "Agenda-" + aId;
            txtAgendaTitle.Clear();
          //  txtMemoName.Clear();          
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

        }
    }





