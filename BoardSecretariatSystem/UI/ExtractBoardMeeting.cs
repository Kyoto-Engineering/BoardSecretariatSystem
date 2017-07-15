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
    public partial class ExtractBoardMeeting : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        public Nullable<Int64> meetingid;
        public string user_id;
        public int extractid;

        public ExtractBoardMeeting()
        {
            InitializeComponent();
        }

        private void ExtractBoardMeeting_Load(object sender, EventArgs e)
        {
            user_id = frmLogin.uId.ToString();
            GetMeetingNo();
        }

        private void GetMeetingNo()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctt = "select MeetingNo from Meeting";
                cmd = new SqlCommand(ctt);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbMeetingNo.Items.Add(rdr.GetValue(0).ToString());
                }
                //cmbGender.Items.Add("Not In The List");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbMeetingNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select MeetingId from Meeting  where  Meeting.MeetingNo='" + cmbMeetingNo.Text + "' ";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {

                    meetingid = Convert.ToInt64(rdr["MeetingId"]);
                }
                con.Close();

                con = new SqlConnection(cs.DBConn);
                con.Open();
                //cmd = new SqlCommand("SELECT RTRIM(ProductListSummary.Sl),RTRIM(ProductListSummary.ProductGenericDescription),RTRIM(ProductListSummary.ItemDescription),RTRIM(ProductListSummary.ItemCode),RTRIM(MasterStocks.MQuantity),RTRIM(MasterStocks.UnitPrice) from ProductListSummary,MasterStocks where MasterStocks.Sl=ProductListSummary.Sl order by MasterStocks.Sl desc", con);
                cmd = new SqlCommand("SELECT MeetingMinutes.MeetingMinuteId, MeetingMinutes.Resolution FROM Meeting INNER JOIN MeetingMinutes ON Meeting.MeetingId = MeetingMinutes.MeetingId where  Meeting.MeetingNo='" + cmbMeetingNo.Text + "' order by Meeting.MeetingNo asc", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1]);
                }
                con.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addbutton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show(@"Please Select Row!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                try
                {
                    DataGridViewRow dr = dataGridView1.SelectedRows[0];
                    if (listView1.Items.Count == 0)
                    {
                        ListViewItem lst = new ListViewItem();
                        lst.Text = dr.Cells[0].Value.ToString();
                        lst.SubItems.Add(dr.Cells[1].Value.ToString());
                        listView1.Items.Add(lst);
                        cmbMeetingNo.Enabled = false;
                    }
                    else
                    {
                        String Val = dr.Cells[0].Value.ToString();
                        if (listView1.FindItemWithText(Val) == null)
                        {
                            ListViewItem lst1 = new ListViewItem();
                            lst1.Text = dr.Cells[0].Value.ToString();
                            lst1.SubItems.Add(dr.Cells[1].Value.ToString());
                            listView1.Items.Add(lst1);
                        }
                        else
                        {
                            MessageBox.Show("You Can Not Add Same item More than one times", "error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }            
        }

        private void Extractbutton_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)
            {
                MessageBox.Show("Please add to Chart first", "Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            con = new SqlConnection(cs.DBConn);
            string cd1 = "INSERT INTO ExtractBoardMeeting (MeetingId,Purpose,UserId,EntryDate) VALUES (@d1,@d2,@d3,@d4)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
            cmd = new SqlCommand(cd1, con);
            cmd.Parameters.AddWithValue("@d1", meetingid);
            cmd.Parameters.AddWithValue("@d2", PurposerichTextBox.Text);
            cmd.Parameters.AddWithValue("@d3", user_id);
            cmd.Parameters.AddWithValue("@d4", DateTime.UtcNow.ToLocalTime());
            con.Open();
            extractid = (int)cmd.ExecuteScalar();
            con.Close();
            try
            {
                for (int i = 0; i <= listView1.Items.Count - 1; i++)
                {
                    con = new SqlConnection(cs.DBConn);
                    string cd = "INSERT INTO DetailsOfExtract (MeetingMinuteId,ExtractId) VALUES (@d1,@d2)";
                    cmd = new SqlCommand(cd, con);
                    cmd.Parameters.AddWithValue("@d1", listView1.Items[i].SubItems[0].Text);
                    cmd.Parameters.AddWithValue("@d2", extractid);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
                MessageBox.Show("Successfully Extracted.", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listView1.Items.Clear();
                cmbMeetingNo.Enabled = true;
                cmbMeetingNo.SelectedIndex = -1;
                PurposerichTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
