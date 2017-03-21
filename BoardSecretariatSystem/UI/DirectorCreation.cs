﻿using System;
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
    public partial class DirectorCreation : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public DirectorCreation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbDirectorName.Text == "")
            {
                MessageBox.Show("Please Select director Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbDirectorName.Focus();
                return;
            }
            try
            {

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select ShareholderId from Derector where ShareholderId='" + cmbDirectorName.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("This Director Name  Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbDirectorName.Text = "";
                    cmbDirectorName.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string cb = "insert into ClientTypes(ClientType,CreatedByUId,CreatedDTime) VALUES (@d1)";
                cmd = new SqlCommand(cb, con);
                cmd.Parameters.AddWithValue("@d1", cmbDirectorName.Text);
                //cmd.Parameters.AddWithValue("@d1", userId);
                //cmd.Parameters.AddWithValue("@d1", DateTime.UtcNow.ToLocalTime());
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);                
                cmbDirectorName.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbDirectorName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select ShareholderId from Derector where ShareholderId='" + cmbDirectorName.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("This Director Name  Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbDirectorName.Text = "";
                    cmbDirectorName.Focus();


                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void DirectorLoad()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string query = "SELECT ParticipantName FROM Participant ";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbDirectorName.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DirectorCreation_Load(object sender, EventArgs e)
        {
            DirectorLoad();
        }

        private void DirectorCreation_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MainUI frm=new MainUI();
             frm.Show();
        }
    }
}
