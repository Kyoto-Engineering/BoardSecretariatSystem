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
using BoardSecretariatSystem.Reports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace BoardSecretariatSystem.UI
{
    public partial class Extract : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        private ConnectionString cs = new ConnectionString();
        public int x;
        public Extract()
        {
            InitializeComponent();
        }

        private void Extract_Load(object sender, EventArgs e)
        {
            extractidLoad();
        }

        private void extractidLoad()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "SELECT  ExtractId FROM ExtractBoardMeeting";
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
                string ct = "select ExtractId FROM ExtractBoardMeeting where ExtractBoardMeeting.ExtractId='" + comboBox1.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {

                    x = (rdr.GetInt32(0));

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
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Please Select Extract No");

            }

            else
            {
                //creating an object of ParameterField class
                ParameterField paramField = new ParameterField();

                //creating an object of ParameterFields class
                ParameterFields paramFields = new ParameterFields();

                //creating an object of ParameterDiscreteValue class
                ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();

                //set the parameter field name
                paramField.Name = "extractid";

                //set the parameter value
                paramDiscreteValue.Value = x;

                //add the parameter value in the ParameterField object
                paramField.CurrentValues.Add(paramDiscreteValue);

                //add the parameter in the ParameterFields object
                paramFields.Add(paramField);

                //set the parameterfield information in the crystal report



                ReportViewer f2 = new ReportViewer();
                TableLogOnInfos reportLogonInfos = new TableLogOnInfos();
                TableLogOnInfo reportLogonInfo = new TableLogOnInfo();
                ConnectionInfo reportConInfo = new ConnectionInfo();
                Tables tables = default(Tables);
                //	Table table = default(Table);
                var with1 = reportConInfo;
                with1.ServerName = "tcp:KyotoServer,49172";
                with1.DatabaseName = "BoardSecretariatDBKD_new1_CopyMain";
                with1.UserID = "sa";
                with1.Password = "SystemAdministrator";
                ResolutionExtractReportedit cr = new ResolutionExtractReportedit();
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

    }
}
