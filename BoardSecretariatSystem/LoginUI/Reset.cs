﻿using System;
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

namespace BoardSecretariatSystem.LoginUI
{
    public partial class Reset : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public string readyPassword;
        public Reset()
        {
            InitializeComponent();
        }


        private void UpdateUserPassword()
        {
            try
            {
                string clearText = txtPassword.Text.Trim();
                string password = clearText;
                byte[] bytes = Encoding.Unicode.GetBytes(password);
                byte[] inArray = HashAlgorithm.Create("SHA1").ComputeHash(bytes);
                string readyPassword1 = Convert.ToBase64String(inArray);
                readyPassword = readyPassword1;

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "Update Registration set Password=@d1 where UserName='" + cmbUserName.Text + "'";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", readyPassword);
                rdr = cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Successfully Reset Password", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbUserName.SelectedIndex = -1;
                txtPassword.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (cmbUserName.Text == "")
            {
                MessageBox.Show("Please enter username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbUserName.Focus();
                return;
            }

            if (txtPassword.Text == "")
            {
                MessageBox.Show("Please enter password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return;
            }

         //   GetUserType();


            try
            {


                //if (testUserType == "SuperAdmin" && usertType1 == "SuperAdmin")
                //{
                UpdateUserPassword();
                //}
                //if (testUserType == "SuperAdmin" && usertType1 == "Admin")
                //{
                //    UpdateUserPassword();
                //}
                //if (testUserType == "SuperAdmin" && usertType1 == "User")
                //{
                //    UpdateUserPassword();
                //}
                //if (testUserType == "Admin" && usertType1 == "User")
                //{
                //    UpdateUserPassword();
                //}
                //if (testUserType == "Admin" && usertType1 == "SuperAdmin")
                //{

                //    MessageBox.Show("You  can not   Reset this Password", "eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    cmbUserName.SelectedIndex = -1;
                //    txtPassword.Clear();
                //}
                //if (testUserType == "Admin" && usertType1 == "Admin")
                //{

                //    MessageBox.Show("You  can not   Reset this Password", "eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    cmbUserName.SelectedIndex = -1;
                //    txtPassword.Clear();
                //}


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}