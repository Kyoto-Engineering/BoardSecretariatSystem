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
    }
}
