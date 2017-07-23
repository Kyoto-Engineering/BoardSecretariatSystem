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
    public partial class ReportUI : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        private ConnectionString cs = new ConnectionString();
        public int x;
        public string y;
        public ReportUI()
        {
            InitializeComponent();
        }

        private void ReportUI_Load(object sender, EventArgs e)
        {
          
            CompanyNameLoad();
        }

       
        private void CompanyNameLoad()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "SELECT  CompanyName FROM Company order by CompanyName asc";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    comboBox2.Items.Add(rdr[0]);  //comboBox2.Items.Add(rdr.GetValue(0).ToString());
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
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //creating an object of ParameterField class
           // ParameterField paramField = new ParameterField();

            //creating an object of ParameterFields class
           // ParameterFields paramFields = new ParameterFields();

            //creating an object of ParameterDiscreteValue class
            //ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();

            //set the parameter field name
            //paramField.Name = "meetingid";

            //set the parameter value
            //paramDiscreteValue.Value = x;

            //add the parameter value in the ParameterField object
            //paramField.CurrentValues.Add(paramDiscreteValue);

            //add the parameter in the ParameterFields object
           // paramFields.Add(paramField);

            //set the parameterfield information in the crystal report



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

            Form_IX cr = new Form_IX();
            
            tables = cr.Database.Tables;
            foreach (Table table in tables)
            {
                reportLogonInfo = table.LogOnInfo;
                reportLogonInfo.ConnectionInfo = reportConInfo;
                table.ApplyLogOnInfo(reportLogonInfo);
            }

            //f2.crystalReportViewer1.ParameterFieldInfo = paramFields;
            //set the parameterfield information in the crystal report
            f2.crystalReportViewer1.ReportSource = cr;
            
            this.Visible = false;
            f2.ShowDialog();
            this.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
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

            Form_X cr = new Form_X();

            tables = cr.Database.Tables;
            foreach (Table table in tables)
            {
                reportLogonInfo = table.LogOnInfo;
                reportLogonInfo.ConnectionInfo = reportConInfo;
                table.ApplyLogOnInfo(reportLogonInfo);
            }

            //f2.crystalReportViewer1.ParameterFieldInfo = paramFields;
            //set the parameterfield information in the crystal report
            f2.crystalReportViewer1.ReportSource = cr;

            this.Visible = false;
            f2.ShowDialog();
            this.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
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

            Form_VI cr = new Form_VI();

            tables = cr.Database.Tables;
            foreach (Table table in tables)
            {
                reportLogonInfo = table.LogOnInfo;
                reportLogonInfo.ConnectionInfo = reportConInfo;
                table.ApplyLogOnInfo(reportLogonInfo);
            }

            //f2.crystalReportViewer1.ParameterFieldInfo = paramFields;
            //set the parameterfield information in the crystal report
            f2.crystalReportViewer1.ReportSource = cr;

            this.Visible = false;
            f2.ShowDialog();
            this.Visible = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select CompanyName FROM Company where CompanyName='" + comboBox2.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {

                    y = (rdr.GetString(0));

                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox2.Text))
            {
                MessageBox.Show("Please Select Company Name");

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
                paramField.Name = "Company_Name";

                //set the parameter value
                paramDiscreteValue.Value = y;

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
                with1.DatabaseName = "BoardSecretariatDBKD";
                with1.UserID = "sa";
                with1.Password = "SystemAdministrator";

                Form_XII cr = new Form_XII();

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
