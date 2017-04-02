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
    public partial class BoardMemoManagement : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        private ConnectionString cs = new ConnectionString();
        private int meetingId, meetingNo,agendaId=0;
        public BoardMemoManagement()
        {
            InitializeComponent();
        }


        private void BoardMemoManagement_FormClosed(object sender, FormClosedEventArgs e)
        {
                            this.Hide();
            MeetingManagementUI frm=new MeetingManagementUI();
                             frm.Show();
        }

        private void MeetingInfo()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "SELECT MeetingId, MeetingNo FROM Meeting where Statuss='Open' and MeetingTypeId=1";
                cmd = new SqlCommand(query, con);
               rdr= cmd.ExecuteReader();
                if (rdr.Read())
                {
                    meetingId = Convert.ToInt32(rdr["MeetingId"]);
                    meetingNo = Convert.ToInt32(rdr["MeetingNo"]);
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

        private void BoardMemoManagement_Load(object sender, EventArgs e)
        {
           // Ordinal();
            MeetingInfo();
            LoadUI();
            LoadGrid();
        }

        private void LoadUI()
        {
            txtMeetingName.Text = Ordinal(meetingNo) + " Board Meeting";
        }

        private void LoadGrid()
        { con = new SqlConnection(cs.DBConn);
                con.Open();
               cmd = new SqlCommand("SELECT Agenda.AgendaId, Agenda.AgendaTitle, Agenda.Memo FROM SelectedAgenda INNER JOIN Agenda ON SelectedAgenda.AgendaId = Agenda.AgendaId where SelectedAgenda.MeetingId = "+meetingId+"",con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2]);
            }
            if (con.State==ConnectionState.Open)
            {
                con.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dataGridView1.CurrentRow;
            agendaId = int.Parse(dr.Cells[0].Value.ToString());
            txtAgendaTitle.Text = dr.Cells[1].Value.ToString();
            textWithSpellCheck1.Text = dr.Cells[2].Value.ToString();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

            if (agendaId==0)
            {
                MessageBox.Show("Please Select Agenda First", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (string.IsNullOrWhiteSpace(textWithSpellCheck1.Text))
            {
                MessageBox.Show("Please Write Something As Memo", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string query = "Update Agenda Set Memo=@memo  where AgendaId=@agid";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@memo", textWithSpellCheck1.Text);
                    cmd.Parameters.AddWithValue("@agid", agendaId);
                    cmd.ExecuteNonQuery();
                    foreach (DataGridViewRow dr in dataGridView1.Rows)
                    {
                        if (dr.Cells[0].Value.ToString() == agendaId.ToString())
                        {
                            dataGridView1.Rows.Remove(dr);
                        }
                    }
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    MessageBox.Show("Memo Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void Clear()
        {
            agendaId = 0;
            txtAgendaTitle.Clear();
            textWithSpellCheck1.Text=String.Empty;
        }
        
    }
}
