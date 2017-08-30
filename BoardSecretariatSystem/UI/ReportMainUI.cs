using BoardSecretariatSystem.Reports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoardSecretariatSystem.UI
{
    public partial class ReportMainUI : Form
    {
        public ReportMainUI()
        {
            InitializeComponent();
        }

        private void attendenceSlipButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Metting_No_Selected_Reports mm = new Metting_No_Selected_Reports();
            mm.ShowDialog();
            this.Visible = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            ReportUI ri = new ReportUI();
            ri.ShowDialog();
            this.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            ScheduleX ri = new ScheduleX();
            ri.ShowDialog();
            this.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            postpondReportUI ri = new postpondReportUI();
            ri.ShowDialog();
            this.Visible = true;
        }

        private void CompanyProfileButton_Click(object sender, EventArgs e)
        {
            ReportViewer f2 = new ReportViewer();
            TableLogOnInfos reportLogonInfos = new TableLogOnInfos();
            TableLogOnInfo reportLogonInfo = new TableLogOnInfo();
            ConnectionInfo reportConInfo = new ConnectionInfo();
            Tables tables = default(Tables);
            var with1 = reportConInfo;
            with1.ServerName = "tcp:KyotoServer,49172";
            with1.DatabaseName = "BoardSecretariatDBKD";
            with1.UserID = "sa";
            with1.Password = "SystemAdministrator";
            DetailsOfCompany cr = new DetailsOfCompany();

            tables = cr.Database.Tables;
            foreach (Table table in tables)
            {
                reportLogonInfo = table.LogOnInfo;
                reportLogonInfo.ConnectionInfo = reportConInfo;
                table.ApplyLogOnInfo(reportLogonInfo);
            }

            f2.crystalReportViewer1.ReportSource = cr;

            this.Visible = false;
            f2.ShowDialog();
            this.Visible = true;
        }
    }
}
