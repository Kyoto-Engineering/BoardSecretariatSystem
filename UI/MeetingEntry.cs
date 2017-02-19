using System;
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
        

        public int memberId;
        public MeetingEntry()
        {
           
            InitializeComponent();
        }
        private void MeetingEntry_Load(object sender, EventArgs e)
        {

        }

        public 
        public void SelectMemberId()
        {
            if (!string.IsNullOrEmpty(memberNameTextBox.Text))
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();

                cmd.CommandText = "select MemberId from t_member WHERE MemberName= '" + memberNameTextBox.Text + "'";

                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    memberId = rdr.GetInt32(0);

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
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(memberNameTextBox.Text))
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct3 = "select MemberName from t_member where MemberName='" + memberNameTextBox.Text + "'";
                cmd = new SqlCommand(ct3, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read() && !rdr.IsDBNull(0))
                {
                    MessageBox.Show("This Member Name Already Exists,Please Input another one", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    memberNameTextBox.ResetText();
                    memberNameTextBox.Focus();
                    con.Close();

                }
            }

            else
            {
                try
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string query1 = "insert into t_member (MemberName) values (@memberName)" +
                                    "SELECT CONVERT(int, SCOPE_IDENTITY())";
                    cmd = new SqlCommand(query1, con);
                    cmd.Parameters.AddWithValue("@memberName", memberNameTextBox.Text);
                    //cmd.Parameters.AddWithValue("@d2", user_id);
                    //cmd.Parameters.AddWithValue("@d3", DateTime.UtcNow.ToLocalTime());
                    cmd.ExecuteNonQuery();
                    con.Close();


                    SelectMemberId();


                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string query2 = "insert into t_boradinfo (Topics,Discussion,Dicission,Date,Time,Place,ContactNo,MemberId) values (@topics,@discussion,@dicission,@date,@time,@place,@contactNo,@memberId)" +
                                    "SELECT CONVERT(int, SCOPE_IDENTITY())";
                    cmd = new SqlCommand(query2, con);
                    cmd.Parameters.AddWithValue("@topics", topicsTextBox.Text);
                    cmd.Parameters.AddWithValue("@discussion", discussionTextBox.Text);
                    cmd.Parameters.AddWithValue("@dicission", decissionTextBox.Text);
                    cmd.Parameters.AddWithValue("@date", datePicker.Value);
                    cmd.Parameters.AddWithValue("@time", timePicker.Value);
                    cmd.Parameters.AddWithValue("@place", placeTextBox.Text);
                    cmd.Parameters.AddWithValue("@contactNo", contactNoTextBox.Text);
                    cmd.Parameters.AddWithValue("@memberId", memberId);

                    //cmd.Parameters.AddWithValue("@d2", user_id);
                    //cmd.Parameters.AddWithValue("@d3", DateTime.UtcNow.ToLocalTime());
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Saved Sucessfully", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //var message = new MailMessage();
            //message.From = new MailAddress("sender@foo.bar.com");

            //message.To.Add(new MailAddress("01719363181@txt.att.net"));//See carrier destinations below
            ////message.To.Add(new MailAddress("5551234568@txt.att.net"));

            ////message.CC.Add(new MailAddress("carboncopy@foo.bar.com"));
            //message.Subject = "This is my subject";
            //message.Body = "This is the content";

            //var client = new SmtpClient();
            //client.Send(message);

            MailMessage mail = new MailMessage("engr.runju@gmail.com", "engr.runju@gmail.com");
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.google.com";
            mail.Subject = "this is a test email.";
            mail.Body = "this is my test email body";
            client.Send(mail);
        }

        
    }
}
