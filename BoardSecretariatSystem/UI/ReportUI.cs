using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BoardSecretariatSystem.Reports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace BoardSecretariatSystem.UI
{

    public partial class ReportUI : Form
    {
        public int x;
        public ReportUI()
        {
            InitializeComponent();
        }

        private void bmFeeButton_Click(object sender, EventArgs e)
        {
            //creating an object of ParameterField class
            ParameterField paramField = new ParameterField();

            //creating an object of ParameterFields class
           //ParameterFields paramFields = new ParameterFields();

            //creating an object of ParameterDiscreteValue class
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();

            //set the parameter field name
            paramField.Name = "ParticipantName";

            //set the parameter value
            paramDiscreteValue.Value = x;

            //add the parameter value in the ParameterField object
            paramField.CurrentValues.Add(paramDiscreteValue);

            //add the parameter in the ParameterFields object
            //paramFields.Add(paramField);

            //set the parameterfield information in the crystal report



            ReportViewer f2 = new ReportViewer();
            TableLogOnInfos reportLogonInfos = new TableLogOnInfos();
            TableLogOnInfo reportLogonInfo = new TableLogOnInfo();
            ConnectionInfo reportConInfo = new ConnectionInfo();
            Tables tables = default(Tables);
            //	Table table = default(Table);
            var with1 = reportConInfo;
            with1.ServerName = "tcp:KyotoServer,49172";
            with1.DatabaseName = "BoardSecretariatDBDemo";
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
            //f2.crystalReportViewer1.ParameterFieldInfo = paramFields;
            //set the parameterfield information in the crystal report
            f2.crystalReportViewer1.ReportSource = cr;
           
            this.Visible = false;

            f2.ShowDialog();
            this.Visible = true;
        }

        private void noticeButton_Click(object sender, EventArgs e)
        {
            //creating an object of ParameterField class
            ParameterField paramField = new ParameterField();

            //creating an object of ParameterFields class
            //ParameterFields paramFields = new ParameterFields();

            //creating an object of ParameterDiscreteValue class
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();

            //set the parameter field name
            paramField.Name = "ParticipantName";

            //set the parameter value
            paramDiscreteValue.Value = x;

            //add the parameter value in the ParameterField object
            paramField.CurrentValues.Add(paramDiscreteValue);

            //add the parameter in the ParameterFields object
            //paramFields.Add(paramField);

            //set the parameterfield information in the crystal report



            ReportViewer f2 = new ReportViewer();
            TableLogOnInfos reportLogonInfos = new TableLogOnInfos();
            TableLogOnInfo reportLogonInfo = new TableLogOnInfo();
            ConnectionInfo reportConInfo = new ConnectionInfo();
            Tables tables = default(Tables);
            //	Table table = default(Table);
            var with1 = reportConInfo;
            with1.ServerName = "tcp:KyotoServer,49172";
            with1.DatabaseName = "BoardSecretariatDBDemo";
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
            //f2.crystalReportViewer1.ParameterFieldInfo = paramFields;
            //set the parameterfield information in the crystal report
            f2.crystalReportViewer1.ReportSource = cr;

            this.Visible = false;

            f2.ShowDialog();
            this.Visible = true;
        }

        private void participantAttenButton_Click(object sender, EventArgs e)
        {
            //creating an object of ParameterField class
            ParameterField paramField = new ParameterField();

            //creating an object of ParameterFields class
            //ParameterFields paramFields = new ParameterFields();

            //creating an object of ParameterDiscreteValue class
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();

            //set the parameter field name
            paramField.Name = "ParticipantName";

            //set the parameter value
            paramDiscreteValue.Value = x;

            //add the parameter value in the ParameterField object
            paramField.CurrentValues.Add(paramDiscreteValue);

            //add the parameter in the ParameterFields object
            //paramFields.Add(paramField);

            //set the parameterfield information in the crystal report



            ReportViewer f2 = new ReportViewer();
            TableLogOnInfos reportLogonInfos = new TableLogOnInfos();
            TableLogOnInfo reportLogonInfo = new TableLogOnInfo();
            ConnectionInfo reportConInfo = new ConnectionInfo();
            Tables tables = default(Tables);
            //	Table table = default(Table);
            var with1 = reportConInfo;
            with1.ServerName = "tcp:KyotoServer,49172";
            with1.DatabaseName = "BoardSecretariatDBDemo";
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
            //f2.crystalReportViewer1.ParameterFieldInfo = paramFields;
            //set the parameterfield information in the crystal report
            f2.crystalReportViewer1.ReportSource = cr;

            this.Visible = false;

            f2.ShowDialog();
            this.Visible = true;
        }

        private void meetingMinutesButton_Click(object sender, EventArgs e)
        {
            //creating an object of ParameterField class
            ParameterField paramField = new ParameterField();

            //creating an object of ParameterFields class
            //ParameterFields paramFields = new ParameterFields();

            //creating an object of ParameterDiscreteValue class
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();

            //set the parameter field name
            paramField.Name = "ParticipantName";

            //set the parameter value
            paramDiscreteValue.Value = x;

            //add the parameter value in the ParameterField object
            paramField.CurrentValues.Add(paramDiscreteValue);

            //add the parameter in the ParameterFields object
            //paramFields.Add(paramField);

            //set the parameterfield information in the crystal report



            ReportViewer f2 = new ReportViewer();
            TableLogOnInfos reportLogonInfos = new TableLogOnInfos();
            TableLogOnInfo reportLogonInfo = new TableLogOnInfo();
            ConnectionInfo reportConInfo = new ConnectionInfo();
            Tables tables = default(Tables);
            //	Table table = default(Table);
            var with1 = reportConInfo;
            with1.ServerName = "tcp:KyotoServer,49172";
            with1.DatabaseName = "BoardSecretariatDBDemo";
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
            //f2.crystalReportViewer1.ParameterFieldInfo = paramFields;
            //set the parameterfield information in the crystal report
            f2.crystalReportViewer1.ReportSource = cr;

            this.Visible = false;

            f2.ShowDialog();
            this.Visible = true;
        }
    }
}
