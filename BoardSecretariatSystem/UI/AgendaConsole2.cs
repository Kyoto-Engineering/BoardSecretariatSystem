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
    public partial class AgendaConsole2 : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public string h, k, userId;
        public int agendaTypeId,agendaId;
        public AgendaConsole2()
        {
            InitializeComponent();
        }

        private void AgendaConsole2_FormClosed(object sender, FormClosedEventArgs e)
        {
               this.Hide();
            MainUI frm=new MainUI();
               frm.Show();
        }
        private void GetAgendaDetails()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = new SqlCommand("SELECT Agenda.AgendaId,Agenda.AgendaTopics,Agenda.AgendaTitle,AgendaTypes.AgendaType,AgendaTypes.AgendaTypeId FROM  Agenda inner join AgendaTypes on Agenda.AgendaTypeId=AgendaTypes.AgendaTypeId Where AgendaTypes.AgendaTypeId= 1 Union  SELECT  Agenda.AgendaId,Agenda.AgendaTopics,Agenda.AgendaTitle,AgendaTypes.AgendaType,Agenda.AgendaTypeId FROM   Agenda inner  join AgendaTypes on Agenda.AgendaTypeId=AgendaTypes.AgendaTypeId Where Agenda.AgendaTypeId<> 1  and AgendaId not in(Select Agenda.AgendaId from SelectedAgenda inner join Agenda on Agenda.AgendaId=SelectedAgenda.AgendaId) order by Agenda.AgendaId", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3],rdr[4]);
                }
                con.Close();
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
        private void AgendaConsole2_Load(object sender, EventArgs e)
        {
            userId = frmLogin.uId.ToString();
            GetAgendaDetails();
            LoadAgendaType();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.CurrentRow;
                txtAgendaHeader.Text = dr.Cells[1].Value.ToString();
                txtAgendaTitle.Text = dr.Cells[2].Value.ToString();
                cmbAgendaType.Text = dr.Cells[3].Value.ToString();
                k = h;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonAdd_Click(object sender, EventArgs e)
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
            if (listView1.Items.Count == 0)
            {
                ListViewItem list = new ListViewItem();
                list.SubItems.Add(agendaId.ToString());               
                list.SubItems.Add(txtAgendaTitle.Text);               
                list.SubItems.Add(cmbAgendaType.Text);
                list.SubItems.Add(agendaTypeId.ToString());
               

                listView1.Items.Add(list);
                txtAgendaHeader.Clear();
                txtAgendaTitle.Clear();
                cmbAgendaType.SelectedIndex = -1;           
                return;
            }
            ListViewItem list1 = new ListViewItem();
            list1.SubItems.Add(agendaId.ToString());
            list1.SubItems.Add(txtAgendaTitle.Text);
            list1.SubItems.Add(cmbAgendaType.Text);
            list1.SubItems.Add(agendaTypeId.ToString());

            listView1.Items.Add(list1);
            txtAgendaHeader.Clear();
            txtAgendaTitle.Clear();
            cmbAgendaType.SelectedIndex = -1;          
            return;
        }

        private void cmbAgendaType_SelectedIndexChanged(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = listView1.Items.Count - 1; i >= 0; i--)
            {
                if (listView1.Items[i].Selected)
                {
                    listView1.Items[i].Remove();
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.Items.Count == 0)
                {
                    MessageBox.Show("Please add agenda in the list before submit", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                for (int i = 0; i < listView1.Items.Count - 1; i++)
                {
                    con = new SqlConnection(cs.DBConn);
                    con.Open();
                    string query1 = "Update Agenda  Set AgendaTitle=@d1,AgendaTypeId=@d2,UserId=@d3,DateTime=@d4 where Agenda.AgendaId='"+listView1.Items[i].SubItems[1].Text+"'";
                    cmd = new SqlCommand(query1, con);
                    cmd.Parameters.AddWithValue("@d1", listView1.Items[i].SubItems[2].Text);
                    cmd.Parameters.AddWithValue("@d2", listView1.Items[i].SubItems[4].Text);                   
                    cmd.Parameters.AddWithValue("@d3", userId);
                    cmd.Parameters.AddWithValue("@d4", DateTime.UtcNow.ToLocalTime());
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                MessageBox.Show("Sucessfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetAgendaDetails();
                listView1.Items.Clear();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtAgendaHeader_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT Agenda.AgendaId from Agenda WHERE Agenda.AgendaTopics= '" + txtAgendaHeader.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    agendaId = rdr.GetInt32(0);
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

        private void txtAgendaHeader_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAgendaTitle.Focus();
                e.Handled = true;
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
                buttonAdd.Focus();
                e.Handled = true;
            }
        }

        private void buttonAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonSave.Focus();
                e.Handled = true;
            }
        }
    }
}
