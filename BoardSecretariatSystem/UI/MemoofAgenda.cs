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
    public partial class MemoofAgenda : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        private ConnectionString cs = new ConnectionString();
        List<Tuple< string, int>> agendaloist=new List<Tuple< string, int>>();
        private Tuple<string, int> agendadetail;
        public int x, y;
        public int MeetingId { get; set; }

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
                string ct = "select MeetingId FROM Meeting  where Meeting.MeetingId='" + MeetingId + "'";
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

                
                comboBox2.Items.Clear();
                comboBox2.Text = "";

                con = new SqlConnection(cs.DBConn);
                con.Open();
                string ctt =
                    "SELECT 'Agenda '+Convert(varchar(12),row_number() OVER (ORDER BY MeetingAgendaId) )+' -'+Agenda.AgendaTitle, Agenda.AgendaId  FROM Meeting INNER JOIN SelectedAgenda ON Meeting.MeetingId = SelectedAgenda.MeetingId INNER JOIN Agenda ON SelectedAgenda.AgendaId = Agenda.AgendaId  where Meeting.MeetingId='" +
                    x + "' order by MeetingAgendaId asc";
                cmd = new SqlCommand(ctt);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                
                while (rdr.Read())
                {
                    
                    string b = rdr.GetString(0);
                    int c = rdr.GetInt32(1);
                    agendadetail=new Tuple<string, int>(b,c);
                    agendaloist.Add(agendadetail);
                }
                con.Close();
                foreach (Tuple< string, int> agendum in agendaloist)
                {
                    comboBox2.Items.Add(agendum.Item1);
                }
                 
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(comboBox2.Text))
            {
                try
            {
                //string output = new string(comboBox2.Text.ToCharArray().Where(c => char.IsDigit(c)).ToArray());
                var z = from entry in agendaloist
                        where entry.Item1 == comboBox2.Text
                    select entry.Item2;
                y = z.FirstOrDefault();
                
                //con = new SqlConnection(cs.DBConn);
                //con.Open();
                //string ct = "select Agenda.AgendaId FROM Agenda  where Agenda.AgendaId='" + comboBox2.Text + "'";
                //cmd = new SqlCommand(ct);
                //cmd.Connection = con;
                //rdr = cmd.ExecuteReader();

                //if (rdr.Read())
                //{

                //    y = (rdr.GetInt32(0));

                //}

                //con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            }
        }

        private void button1_Click(object sender, EventArgs e)
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
                    with1.DatabaseName = "BoardSecretariatDBKD_new1_CopyMain";
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
                    string output = new string(comboBox2.Text.ToCharArray().Where(c => char.IsDigit(c)).ToArray());
                    TextObject text1 = (TextObject)cr.ReportDefinition.Sections["PageHeaderSection3"].ReportObjects["Text1"];
                    text1.Text = "Agendum No. " +output + " Id. "+y;
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

        
    



