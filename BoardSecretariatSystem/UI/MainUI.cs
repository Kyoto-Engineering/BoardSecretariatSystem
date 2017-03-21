using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BoardSecretariatSystem.LoginUI;
using BoardSecretariatSystem.UI;

namespace BoardSecretariatSystem
{
    public partial class MainUI : Form
    {
        public MainUI()
        {
            InitializeComponent();
        }

        private void companyCreateButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            CompanyEntryUI companyEntry=new CompanyEntryUI();

            companyEntry.Show();

           

        }

        private void boardCreateButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            BoardEntryUI boardEntry = new BoardEntryUI();

            boardEntry.Show();
        }

        private void meetingCreateButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            MeetingEntry meetingEntry = new MeetingEntry();

            meetingEntry.Show();
        }

        private void agendaCreateButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            AgendaEntryUI agendaEntry = new AgendaEntryUI();

            agendaEntry.Show();
        }

        private void participantCreateButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ParticipantCreation participantEntry = new ParticipantCreation();
            participantEntry.Show();
        }
        private void meetingExecutionButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            MeetingExecutionUI meetingExecution = new MeetingExecutionUI();

            meetingExecution.Show();
        }
        private void MainUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            frmLogin frmLogin=new frmLogin();
            frmLogin.Show();
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin frm =new frmLogin();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                       this.Hide();
            UserManagementUI frm=new UserManagementUI();
                        frm.Show();
        }

        private void buttonMultiCombo_Click(object sender, EventArgs e)
        {  
               this.Hide();
               GridForShareHolder frm = new GridForShareHolder();
               frm.Show();

        }

        

       
    }
}
