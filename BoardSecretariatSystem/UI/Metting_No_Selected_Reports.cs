using BoardSecretariatSystem.DBGateway;
using BoardSecretariatSystem.Reports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
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

namespace BoardSecretariatSystem.UI
{
    public partial class Metting_No_Selected_Reports : Form
    {
         //ComboBox combobox1;
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        private ConnectionString cs = new ConnectionString();
        public int x;
        public string y;

        public Metting_No_Selected_Reports()
        {
            InitializeComponent();
        }

        private void Metting_No_Selected_Reports_Load(object sender, EventArgs e)
        {
            meetingidLoad();
            //CompanyNameLoad();
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
                    string mt = Ordinal(Convert.ToInt32(rdr[0]))+ " Board Meeting";
                    comboBox1.Items.Add(mt);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static string Ordinal(int number)
        {
            string suffix = String.Empty;
            if (number == 1 || number == 21 || number == 31 || number % 100 == 21 || number % 100 == 31)
            {
                suffix = "st";
            }
            else if (number == 2 || number == 22 || number % 100 == 22)
            {
                suffix = "nd";
            }
            else if (number == 3 || number == 23 || number % 100 == 23)
            {
                suffix = "rd";
            }
            else
            {
                suffix = "th";
            }
            return String.Format("{0}{1}", number, suffix);
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string output = new string(comboBox1.Text.ToCharArray().Where(c => char.IsDigit(c)).ToArray());
                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ct = "select MeetingId FROM Meeting  where Meeting.MeetingId='" + output+ "'";
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

    
        
        private void attendenceSlipButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Please Select Meeting No");

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
                paramField.Name = "meetingid";

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
                with1.DatabaseName = "BoardSecretariatDBKD_CopyMain";
                with1.UserID = "sa";
                with1.Password = "SystemAdministrator";
                AttendenceSlipReport cr = new AttendenceSlipReport();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Please Select Meeting No");

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
                paramField.Name = "meetingid";

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
                with1.DatabaseName = "BoardSecretariatDBKD_CopyMain";
                with1.UserID = "sa";
                with1.Password = "SystemAdministrator";
                BMFeeReport cr = new BMFeeReport();
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Please Select Meeting No");

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
                paramField.Name = "Meeting No";

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
                with1.DatabaseName = "BoardSecretariatDBKD_CopyMain";
                with1.UserID = "sa";
                with1.Password = "SystemAdministrator";
                ParticipantAttendenceReport cr = new ParticipantAttendenceReport();
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Please Select Meeting No");

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
                paramField.Name = "meetingid";

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
                with1.DatabaseName = "BoardSecretariatDBKD_CopyMain";
                with1.UserID = "sa";
                with1.Password = "SystemAdministrator";
                NoticeOfaMeetingReport cr = new NoticeOfaMeetingReport();
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

        private void button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Please Select Meeting No");

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
                paramField.Name = "meetingid";

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
                with1.DatabaseName = "BoardSecretariatDBKD_CopyMain";
                with1.UserID = "sa";
                with1.Password = "SystemAdministrator";
                MeetingMinutesReport cr = new MeetingMinutesReport();
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

        private void button6_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox1.Text))
            {
                MemoofAgenda f2 = new MemoofAgenda();
                f2.MeetingId = x;
                this.Visible = false;
                f2.ShowDialog();
                this.Visible = true;
            }

            else
            {
                MessageBox.Show("Select Meeting No");

            }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Extract f2 = new Extract();
            this.Visible = false;
            f2.ShowDialog();
            this.Visible = true;
        }
    }
}
