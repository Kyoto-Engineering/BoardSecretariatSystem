﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BoardSecretariatSystem.UI;

namespace BoardSecretariatSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmLogin());
           // Application.Run(new MemberList());
            //Application.Run(new MeetingEntry());
            //Application.Run(new SecretaryCreation());
            //Application.Run(new ParticipantCreation2());

            //Application.Run(new MailSend());
            Application.Run(new ShareTransferUI());


        }
    }
}
