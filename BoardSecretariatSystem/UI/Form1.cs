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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var boardMembers = new List<BoardMember>();

            for (int i = 0; i < 10; i++)
            {
                boardMembers.Add(new BoardMember()
                {
                    Name = "Name" + i,
                    Designation = "Designation" + i,
                    Email = "Email" + i
                });
            }

            //this.ComboBoxWithGrid_WinformsHost.BoardMembers = BoardMembers;

            //this.elementHost1.SelectedIndex = 6;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MainUI frm=new MainUI();
            frm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void elementHost1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }
    }
}
