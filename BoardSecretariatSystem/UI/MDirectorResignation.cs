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
    public partial class MDirectorResignation : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs = new ConnectionString();
        public int vacantPostOfMDirector, vacantPostOfMDirector1, companyId=1;
       
        public MDirectorResignation()
        {
            InitializeComponent();
        }

        public string labelg;
        public void Reset()
        {
            txtDateOfRetirement.Value = DateTime.Today;
            txtResignationCause.Clear();
            txtManagingDirectorId.Clear();
            txtManagingDirectorName.Clear();
        }
        private void buttonDone_Click(object sender, EventArgs e)
        {
            if (txtManagingDirectorName.Text == "")
            {
                MessageBox.Show("Please Select Managing director Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtManagingDirectorName.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string qry2 = "SELECT Company.VacantPostofMDirector from  Company";
                cmd = new SqlCommand(qry2, con);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    vacantPostOfMDirector = (rdr.GetInt32(0));

                }
                con.Close();
                if (vacantPostOfMDirector == 1)
                {
                    MessageBox.Show("please Appoint first Some one as Managing Director", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    vacantPostOfMDirector1 = vacantPostOfMDirector + 1;
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string qry = "Update Company Set VacantPostofMDirector=@d1 where Company.CompanyId='" + companyId + "'";
                    cmd = new SqlCommand(qry, con);
                    cmd.Parameters.AddWithValue("@d1", vacantPostOfMDirector1);
                    cmd.ExecuteReader();
                    con.Close();
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string qrk = "Update MDerector  Set DateofRetirement=@d1,CouseOfRetirement=@d2 where MDerector.MDerectorId='" + txtManagingDirectorId.Text + "'";
                    cmd = new SqlCommand(qrk, con);
                    cmd.Parameters.AddWithValue("@d1", Convert.ToDateTime(txtDateOfRetirement.Value, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat));
                    cmd.Parameters.AddWithValue("@d2", txtResignationCause.Text);
                    cmd.ExecuteReader();
                    con.Close();
                    MessageBox.Show("Successfully Resigned", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MDirectorResignation_Load(object sender, EventArgs e)
        {

        }

        private void MDirectorResignation_FormClosed(object sender, FormClosedEventArgs e)
        {
                         this.Hide();
            BoardManagementUI frm=new BoardManagementUI();
                        frm.Show();
        }

        private void txtDateOfRetirement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtManagingDirectorId.Focus();
                e.Handled = true;
            }
        }

        private void txtManagingDirectorId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtManagingDirectorName.Focus();
                e.Handled = true;
            }
        }

        private void txtManagingDirectorName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtResignationCause.Focus();
                e.Handled = true;
            }
        }

        private void txtResignationCause_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonDone.Focus();
                e.Handled = true;
            }
        }
    }
}
