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
using BoardSecretariatSystem.Reports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace BoardSecretariatSystem.UI
{
    public partial class MemoofAgenda : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        private ConnectionString cs = new ConnectionString();
        public int x, y;

        public MemoofAgenda()
        {
            InitializeComponent();
        }

        private void MemoofAgenda_Load(object sender, EventArgs e)
        {
            meetingidLoad();
           // comboBox2.Enabled = false;
           // button1.Enabled = false;

        }

        private void meetingidLoad()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "SELECT  MeetingId FROM Meeting";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    comboBox1.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select MeetingId FROM Meeting  where Meeting.MeetingId='" + comboBox1.Text +"'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {

                    x = (rdr.GetInt32(0));

                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                comboBox1.Text = comboBox1.Text.Trim();
                comboBox2.Items.Clear();
                comboBox2.Text = "";

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctt =
                    "SELECT Agenda.AgendaId FROM Meeting INNER JOIN SelectedAgenda ON Meeting.MeetingId = SelectedAgenda.MeetingId INNER JOIN Agenda ON SelectedAgenda.AgendaId = Agenda.AgendaId where Meeting.MeetingId= '" +
                    x + "' order by Agenda.AgendaId asc";
                cmd = new SqlCommand(ctt);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    comboBox2.Items.Add(rdr[0]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select Agenda.AgendaId FROM Agenda  where Agenda.AgendaId='" + comboBox2.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {

                    y = (rdr.GetInt32(0));

                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox1.Text))
            {



                if (string.IsNullOrEmpty(comboBox2.Text))
                {
                    MessageBox.Show("Select Agenda No");

                }

                else
                {
                    //button1.Enabled = true;
                    //creating an object of ParameterField class
                    ParameterField paramField = new ParameterField();
                    ParameterField paramField1 = new ParameterField();
                    //creating an object of ParameterFields class
                    ParameterFields paramFields = new ParameterFields();
                    //ParameterFields paramFields1 = new ParameterFields();
                    //creating an object of ParameterDiscreteValue class
                    ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();
                    ParameterDiscreteValue paramDiscreteValue1 = new ParameterDiscreteValue();

                    //set the parameter field name
                    paramField.Name = "meetingid";

                    //set the parameter value
                    paramDiscreteValue.Value = x;
                    //paramDiscreteValue1.Value = y;
                    //add the parameter value in the ParameterField object
                    paramField.CurrentValues.Add(paramDiscreteValue);
                    //paramField1.CurrentValues.Add(paramDiscreteValue1);
                    //add the parameter in the ParameterFields object
                    paramFields.Add(paramField);
                    paramField1.Name = "Agendaid";
                    paramDiscreteValue1.Value = y;
                    ////paramDiscreteValue1.Value = y;
                    ////add the parameter value in the ParameterField object
                    paramField1.CurrentValues.Add(paramDiscreteValue1);
                    ////paramFields1.Add(paramField1);
                    ////set the parameterfield information in the crystal report
                    paramFields.Add(paramField1);


                    ReportViewer f2 = new ReportViewer();
                    TableLogOnInfos reportLogonInfos = new TableLogOnInfos();
                    TableLogOnInfo reportLogonInfo = new TableLogOnInfo();
                    ConnectionInfo reportConInfo = new ConnectionInfo();
                    Tables tables = default(Tables);
                    //	Table table = default(Table);
                    var with1 = reportConInfo;
                    with1.ServerName = "tcp:KyotoServer,49172";
                    with1.DatabaseName = "BoardSecretariatDBKD";
                    with1.UserID = "sa";
                    with1.Password = "SystemAdministrator";
                    MemoOfAgendaReport cr = new MemoOfAgendaReport();
                    tables = cr.Database.Tables;
                    foreach (Table table in tables)
                    {
                        reportLogonInfo = table.LogOnInfo;
                        reportLogonInfo.ConnectionInfo = reportConInfo;
                        table.ApplyLogOnInfo(reportLogonInfo);
                    }
                    f2.crystalReportViewer1.ParameterFieldInfo = paramFields;
                    //set the parameterfield information in the crystal report
                    f2.crystalReportViewer1.ReportSource = cr;
                    this.Visible = false;

                    f2.ShowDialog();
                    this.Visible = true;

                }


            }

            else
            {
                MessageBox.Show("Select Meeting No");
            
            }
           
        }
    }
}

        
    


