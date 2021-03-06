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
using BoardSecretariatSystem.LoginUI;
using BoardSecretariatSystem.UI;

namespace BoardSecretariatSystem
{
    public partial class MainUI : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        ConnectionString cs=new ConnectionString();
        public int availableIssuedShare;

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
            BoardCreation boardEntry = new BoardCreation();
            boardEntry.Show();
        }

        private void meetingCreateButton_Click(object sender, EventArgs e)
        {
                               this.Hide();
            MeetingManagementUI meetingEntry = new MeetingManagementUI();
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
            //this.Hide();

            //MeetingExecutionUI meetingExecution = new MeetingExecutionUI();

            //meetingExecution.Show();
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
            BoardManagementUI frm=new BoardManagementUI();
                frm.Show();

        }

        private void reportButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;            
            ReportMainUI frm = new ReportMainUI();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void agendaAmendmentButton_Click(object sender, EventArgs e)
        {
                      this.Hide();
            AgendaConsole2 frm=new AgendaConsole2();
                      frm.Show();
        }

        private void sendMail_Click(object sender, EventArgs e)
        {
            this.Hide();
            MailSend frm=new MailSend();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SecretaryCreation frm = new SecretaryCreation();
            this.Visible = false;
            frm.ShowDialog();
            this.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ExtractBoardMeeting frm = new ExtractBoardMeeting();
            this.Visible = false;
            frm.ShowDialog();
            this.Visible = true;
        }

     

    }
}
