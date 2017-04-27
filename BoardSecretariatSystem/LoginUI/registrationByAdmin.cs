using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BoardSecretariatSystem.DAO;
using BoardSecretariatSystem.DBGateway;
using BoardSecretariatSystem.Manager;

namespace BoardSecretariatSystem.LoginUI
{
    public partial class registrationByAdmin : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public string readyPassword;
        public int emailId,emailTypeId;
        public string userId;
        public registrationByAdmin()
        {
            InitializeComponent();
        }
        private void Reset()
        {
            userNameTextBox.Clear();
            passwordTextBox.Clear();
            txtUserComboBox.SelectedIndex = -1;
            nameTextBox.Clear();
            cmbEmailAddress.SelectedIndex = -1;
            //emailTextBox.Clear();
            designationTextBox.Clear();
            departmentTextBox.Clear();
            contactNoTextBox.Clear();
            userButton.Enabled = true;
        }

        public string EncodePasswordToBase64(string password)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] inArray = HashAlgorithm.Create("SHA1").ComputeHash(bytes);
            string readyPassword1 = Convert.ToBase64String(inArray);
            readyPassword = readyPassword1;
            return readyPassword;
        }

        private void userButton_Click(object sender, EventArgs e)
        {

            if (userNameTextBox.Text == "")
            {
                MessageBox.Show("Please enter user name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                userNameTextBox.Focus();
                return;
            }
            if (passwordTextBox.Text == "")
            {
                MessageBox.Show("Please Type Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                passwordTextBox.Focus();
                return;
            }
            if (nameTextBox.Text == "")
            {
                MessageBox.Show("Please Type your Full Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nameTextBox.Focus();
                return;
            }
            if (designationTextBox.Text == "")
            {
                MessageBox.Show("Please Type your designation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                designationTextBox.Focus();
                return;
            }
            if (departmentTextBox.Text == "")
            {
                MessageBox.Show("Please Type your Department", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                departmentTextBox.Focus();
                return;
            }
            string password = passwordTextBox.Text.Trim();
            EncodePasswordToBase64(password);
            int us = 0;
            UserManager aManager = new UserManager();
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "Select Username from Registration where Username='" + userNameTextBox.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("This User Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Reset();
                    userNameTextBox.Focus();

                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }

                User nUser = new User
                {
                    UserName = userNameTextBox.Text,
                    Password = readyPassword,
                    UserType = txtUserComboBox.Text,
                    Name = nameTextBox.Text,
                    EmailId = emailId,
                    Designation = designationTextBox.Text,
                    Department = departmentTextBox.Text,
                    ContactNo = contactNoTextBox.Text

                };
                us = aManager.SaveUser(nUser);
                MessageBox.Show("Successfully  User Created.", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);

                userButton.Enabled = false;
                Reset();

                frmLogin lg = new frmLogin();
                this.Visible = false;
                lg.ShowDialog();
                this.Visible = true;
            }
            catch (FormatException formatException)
            {
                MessageBox.Show("Please Enter Input in Correct Format", formatException.Message);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void registrationByAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            UserManagementUI frm=new UserManagementUI();
            frm.Show();
        }
        private void EmailAddress()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctt = "select Email from EmailBank";
                cmd = new SqlCommand(ctt);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbEmailAddress.Items.Add(rdr.GetValue(0).ToString());
                }
                cmbEmailAddress.Items.Add("Not In The List");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GetEmailHostType()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctt = "select HostName from MailHost";
                cmd = new SqlCommand(ctt);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbEmailType.Items.Add(rdr.GetValue(0).ToString());
                }
                cmbEmailType.Items.Add("Not In The List");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void registrationByAdmin_Load(object sender, EventArgs e)
        {
            userId = frmLogin.uId.ToString();
            EmailAddress();
            GetEmailHostType();
        }

        private void cmbEmailAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEmailAddress.Text == "Not In The List")
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Please Input Email Address  Here","Input Here", "", -1, -1);
                if (string.IsNullOrWhiteSpace(input))
                {
                    cmbEmailAddress.SelectedIndex = -1;
                }

                else
                {
                    if (!string.IsNullOrWhiteSpace(input))
                    {
                        string emailId = input.Trim();
                        Regex mRegxExpression;
                        mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");
                        if (!mRegxExpression.IsMatch(emailId))
                        {
                            MessageBox.Show("Please type a valid email Address.", "MojoCRM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;

                        }
                    }
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 = "select Email from EmailBank where Email='" + input + "'";
                    cmd = new SqlCommand(ct2, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() && !rdr.IsDBNull(0))
                    {
                        MessageBox.Show("This Email  Already Exists,Please Select From List", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                        cmbEmailAddress.SelectedIndex = -1;
                    }
                    else
                    {
                        try
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string query1 = "insert into EmailBank (Email, UserId,DateAndTime) values (@d1,@d2,@d3)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            cmd = new SqlCommand(query1, con);
                            cmd.Parameters.AddWithValue("@d1", input);
                            cmd.Parameters.AddWithValue("@d2", userId);
                            cmd.Parameters.AddWithValue("@d3", DateTime.UtcNow.ToLocalTime());
                            cmd.ExecuteNonQuery();
                            con.Close();
                            cmbEmailAddress.Items.Clear();
                            EmailAddress();
                            cmbEmailAddress.SelectedText = input;
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
                    cmd.CommandText = "SELECT EmailBankId from EmailBank WHERE Email= '" + cmbEmailAddress.Text + "'";

                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        emailId = rdr.GetInt32(0);
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

        private void cmbEmailType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEmailType.Text == "Not In The List")
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Please Input Host Mail Here", "Input Here", "",
                    -1, -1);
                if (string.IsNullOrWhiteSpace(input))
                {
                    cmbEmailType.SelectedIndex = -1;
                }

                else
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct2 = "select HostName from MailHost where HostName='" + input + "'";
                    cmd = new SqlCommand(ct2, con);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read() && !rdr.IsDBNull(0))
                    {
                        MessageBox.Show("This Mail Host  Already Exists,Please Select From List", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                        cmbEmailType.SelectedIndex = -1;
                    }
                    else
                    {
                        try
                        {
                            con = new SqlConnection(cs.DBConn);
                            con.Open();
                            string query1 = "insert into  MailHost(HostName) values (@d1)" + "SELECT CONVERT(int, SCOPE_IDENTITY())";
                            cmd = new SqlCommand(query1, con);
                            cmd.Parameters.AddWithValue("@d1", input);
                            cmd.ExecuteNonQuery();
                            con.Close();
                            cmbEmailType.Items.Clear();
                            GetEmailHostType();
                            cmbEmailType.SelectedText = input;
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
                    cmd.CommandText = "SELECT MailHostId from MailHost WHERE HostName= '" + cmbEmailType.Text + "'";
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        emailTypeId = rdr.GetInt32(0);
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

        private void contactNoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char) Keys.Back)))
                e.Handled = true;
        }

        private void userNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                passwordTextBox.Focus();
                e.Handled = true;
            }
        }

        private void passwordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtUserComboBox.Focus();
                e.Handled = true;
            }
        }

        private void txtUserComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                nameTextBox.Focus();
                e.Handled = true;
            }
        }

        private void nameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                designationTextBox.Focus();
                e.Handled = true;
            }
        }

        private void designationTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                departmentTextBox.Focus();
                e.Handled = true;
            }
        }

        private void departmentTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                contactNoTextBox.Focus();
                e.Handled = true;
            }
        }

        private void contactNoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbEmailType.Focus();
                e.Handled = true;
            }
        }

        private void cmbEmailType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbEmailAddress.Focus();
                e.Handled = true;
            }
        }

        private void cmbEmailAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                userButton_Click(this, new EventArgs());
                
            }
        }

        private void cmbEmailAddress_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cmbEmailAddress.Text))
            {


                string emailId = cmbEmailAddress.Text.Trim();
                Regex mRegxExpression;
                mRegxExpression =
                    new Regex(
                        @"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");
                if (!mRegxExpression.IsMatch(emailId))
                {

                    MessageBox.Show("Please type a valid email Address.", "MojoCRM", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    cmbEmailAddress.SelectedIndex = -1;
                    cmbEmailAddress.ResetText();
                    cmbEmailAddress.Focus();

                }
            }
        }
    }
}
