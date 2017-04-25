using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoardSecretariatSystem.UI
{
    public partial class ShareTransferUI : Form
    {
        public ShareTransferUI()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

        }

        private void cellNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

      

        private void cellNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void ShareTransferUI_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void w1ContactNoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void w2ContactNoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void emailComboBox_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(emailComboBox.Text))
            {


                string emailId = emailComboBox.Text.Trim();
                Regex mRegxExpression;
                mRegxExpression =
                    new Regex(
                        @"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");
                if (!mRegxExpression.IsMatch(emailId))
                {

                    MessageBox.Show("Please type a valid email Address.", "MojoCRM", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    emailComboBox.SelectedIndex = -1;
                    emailComboBox.ResetText();
                    emailComboBox.Focus();

                }
            }
        }

        private void cellNumberTextBox_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void nameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                fatherNameTextBox.Focus();
                e.Handled = true;
            }
        }

        private void fatherNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                motherNameTextBox.Focus();
                e.Handled = true;
            }
        }

        private void motherNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateOfBirthTextBox.Focus();
                e.Handled = true;
            }
        }

        private void dateOfBirthTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cellNumberTextBox.Focus();
                e.Handled = true;
            }
        }

        private void cellNumberTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                nationalIdTextBox.Focus();
                e.Handled = true;
            }
        }

        private void nationalIdTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                birthCertificateNoTextBox.Focus();
                e.Handled = true;
            }
        }

        private void birthCertificateNoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                passportNoTextBox.Focus();
                e.Handled = true;
            }
        }

        private void passportNoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tinTextBox.Focus();
                e.Handled = true;
            }
        }

        private void tinTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                emailComboBox.Focus();
                e.Handled = true;
            }
        }

        private void emailComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               genderComboBox.Focus();
                e.Handled = true;
            }
        }

        private void genderComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                personDivisionComboBox.Focus();
                e.Handled = true;
            }
        }

        private void personDivisionComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                personDistrictComboBox.Focus();
                e.Handled = true;
            }
        }

        private void personDistrictComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                personThanaComboBox.Focus();
                e.Handled = true;
            }
        }

        private void personThanaComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                personPostComboBox.Focus();
                e.Handled = true;
            }
        }

        private void personPostComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                personPostCodeTextBox.Focus();
                e.Handled = true;
            }
        }

        private void personPostCodeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                totalAmountTextBox.Focus();
                e.Handled = true;
            }
        }

        private void totalAmountTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                startFolioNoComboBox.Focus();
                e.Handled = true;
            }
        }

        private void startFolioNoComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                endFolioNoComboBox.Focus();
                e.Handled = true;
            }
        }

        private void endFolioNoComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                witness1NameTextBox.Focus();
                e.Handled = true;
            }
        }

        private void witness1NameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                w1occupationTextBox.Focus();
                e.Handled = true;
            }
        }

        private void w1occupationTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                w1flatNoTextBox.Focus();
                e.Handled = true;
            }
        }

        private void w1flatNoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                w1houseNoTextBox.Focus();
                e.Handled = true;
            }
        }

        private void w1houseNoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                w1roadNoTextBox.Focus();
                e.Handled = true;
            }
        }

        private void w1roadNoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                w1blockTextBox.Focus();
                e.Handled = true;
            }
        }

        private void w1blockTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                w1AreaTextBox.Focus();
                e.Handled = true;
            }
        }

        private void w1AreaTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                w1ContactNoTextBox.Focus();
                e.Handled = true;
            }
        }

        private void w1ContactNoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                w1DivisionComboBox.Focus();
                e.Handled = true;
            }
        }

        private void w1DivisionComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                w1DistrictComboBox.Focus();
                e.Handled = true;
            }
        }

        private void w1DistrictComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                w1ThanaComboBox.Focus();
                e.Handled = true;
            }
        }

        private void w1ThanaComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                w1PostComboBox.Focus();
                e.Handled = true;
            }
        }

        private void w1PostComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                w1PostCodeTextBox.Focus();
                e.Handled = true;
            }
        }

        private void w1PostCodeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                witness2NameTextBox.Focus();
                e.Handled = true;
            }
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void witness2NameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                w2OccupationTextBox.Focus();
                e.Handled = true;
            }
        }

        private void w2OccupationTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                w2FlatNoTextBox.Focus();
                e.Handled = true;
            }
        }

        private void w2FlatNoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                w2HouseNoTextBox.Focus();
                e.Handled = true;
            }
        }

        private void w2HouseNoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                w2RoadNoTextBox.Focus();
                e.Handled = true;
            }
        }

        private void w2RoadNoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                w2BlockTextBox.Focus();
                e.Handled = true;
            }
        }

        private void w2BlockTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                w2AreaTextBox.Focus();
                e.Handled = true;
            }
        }

        private void w2AreaTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                w2ContactNoTextBox.Focus();
                e.Handled = true;
            }
        }

        private void w2ContactNoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                w2DivisionComboBox.Focus();
                e.Handled = true;
            }
        }

        private void w2DivisionComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                w2DistrictComboBox.Focus();
                e.Handled = true;
            }
        }

        private void w2DistrictComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                w2ThanaComboBox.Focus();
                e.Handled = true;
            }
        }

        private void w2ThanaComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                w2PostOfficeComboBox.Focus();
                e.Handled = true;
            }
        }

        private void w2PostOfficeComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                w2PostCodeTextBox.Focus();
                e.Handled = true;
            }
        }

        private void w2PostCodeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                saveButton.Focus();
                e.Handled = true;
            }
        }

        private void saveButton_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
