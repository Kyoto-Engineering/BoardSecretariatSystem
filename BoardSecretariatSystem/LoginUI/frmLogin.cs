using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BoardSecretariatSystem.DBGateway;

namespace BoardSecretariatSystem
{
    public partial class frmLogin : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        public static int uId;
        public static string userType, userName, readyPassword, dbUserName, dbPassword;


        public frmLogin()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(userNameTextBox.Text))
            {
                MessageBox.Show("Please enter user name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                userNameTextBox.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(passwoardTextBox.Text))
            {
                MessageBox.Show("Please enter password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                passwoardTextBox.Focus();
                return;
            }
            
            try
            {

                string clearText = passwoardTextBox.Text.Trim();
                string password = clearText;
                byte[] bytes = Encoding.Unicode.GetBytes(password);
                byte[] inArray = HashAlgorithm.Create("SHA1").ComputeHash(bytes);
                string readyPassword1 = Convert.ToBase64String(inArray);
                readyPassword = readyPassword1;


                con = new SqlConnection(cs.DBConn);
                con.Open();
                string qry = "SELECT UserName,Password FROM Registration WHERE UserName = '" + userNameTextBox.Text + "' AND Password = '" + readyPassword + "'";
                cmd = new SqlCommand(qry, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read() == true)
                {
                    dbUserName = (rdr.GetString(0));
                    dbPassword = (rdr.GetString(1));


                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string ct = "select UserType,UserId from Registration where UserName='" + userNameTextBox.Text + "' and Password='" + readyPassword + "'";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        userType = (rdr.GetString(0));
                        uId = (rdr.GetInt32(1));
                    }
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }

                    if (dbUserName == userNameTextBox.Text && dbPassword == readyPassword && userType.Trim() == "Admin")
                    {
                        this.Hide();
                        MainUI frm = new MainUI();
                        frm.Show();

                    }
                    //if (dbUserName == userNameTextBox.Text && dbPassword == readyPassword && userType.Trim() == "User")
                    //{
                    //    this.Hide();
                    //    MainUI frm = new MainUI();
                    //    frm.Show();

                    //}

                }
                else
                {
                    MessageBox.Show("Login is Failed...Try again !", "Login Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    userNameTextBox.Clear();
                    passwoardTextBox.Clear();
                    userNameTextBox.Focus();
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //try
            //{
            //    SqlConnection myConnection = default(SqlConnection);
            //    myConnection = new SqlConnection(cs.DBConn);

            //    SqlCommand myCommand = default(SqlCommand);

            //    myCommand = new SqlCommand("SELECT UserName,Password FROM Registration WHERE UserName = @username AND Password = @UserPassword", myConnection);
            //    SqlParameter uName = new SqlParameter("@username", SqlDbType.VarChar);
            //    SqlParameter uPassword = new SqlParameter("@UserPassword", SqlDbType.VarChar);
            //    uName.Value = userNameTextBox.Text;
            //    uPassword.Value = passwoardTextBox.Text;
            //    myCommand.Parameters.Add(uName);
            //    myCommand.Parameters.Add(uPassword);

            //    myCommand.Connection.Open();
            //    rdr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

            //    if (rdr.Read() == true)
            //    {
            //        con = new SqlConnection(cs.DBConn);
            //        con.Open();
            //        string ct = "select UserType,UserId,Name from Registration where Username='" + userNameTextBox.Text + "'and Password='" + passwoardTextBox.Text + "'";
            //        cmd = new SqlCommand(ct);
            //        cmd.Connection = con;
            //        rdr = cmd.ExecuteReader();
            //        if (rdr.Read())
            //        {
            //            userType = (rdr.GetString(0));
            //            uId = (rdr.GetInt32(1));
            //            userName = (rdr.GetString(2));
            //        }
            //        if ((rdr != null))
            //        {
            //            rdr.Close();
            //        }

            //        if (userType.Trim() == "Admin")
            //        {
            //            this.Hide();
            //            MainUI frm = new MainUI();
            //            frm.Show();
            //            userNameTextBox.Clear();
            //            userNameTextBox.Clear();
            //        }
            //    }
              

            //    else
            //    {
            //        MessageBox.Show("Login is Failed...Try again !", "Login Denied", MessageBoxButtons.OK,
            //            MessageBoxIcon.Error);

            //        userNameTextBox.Clear();
            //        passwoardTextBox.Clear();
            //        userNameTextBox.Focus();
            //    }
            //    if (myConnection.State == ConnectionState.Open)
            //    {
            //        myConnection.Dispose();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
