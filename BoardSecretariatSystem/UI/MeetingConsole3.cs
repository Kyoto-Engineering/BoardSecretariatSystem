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

namespace BoardSecretariatSystem.UI
{
    public partial class MeetingConsole3 : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();

        public MeetingConsole3()
        {
            InitializeComponent();
        }

        private void MeetingConsole3_FormClosed(object sender, FormClosedEventArgs e)
        {
                           this.Hide();
            MeetingManagementUI frm =new MeetingManagementUI();
                            frm.Show();
        }

        //private void ShowLabel()
        //{
        //    label5.Visible = true;
        //    label6.Visible = true;
        //    label7.Visible = true;
        //    txtParticipantName.Visible = true;
        //    txtDesignation.Visible = true;
        //    txtParticipantType.Visible = true; 
        //}
        //private void HideLevel()
        //{
        //    label5.Visible = false;
        //    label6.Visible = false;
        //    label7.Visible = false;
        //    txtParticipantName.Visible = false;
        //    txtDesignation.Visible = false;
        //    txtParticipantType.Visible = false;

        //}
        private void MeetingConsole3_Load(object sender, EventArgs e)
        {
            //HideLevel();
        }

        private void buttonAdditionalParticipant_Click(object sender, EventArgs e)
        {
                           this.Hide();
            ParticipantCreation2 frm=new ParticipantCreation2();
                            frm.Show();

        }
    }
}
