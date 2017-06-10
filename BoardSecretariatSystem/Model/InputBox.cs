using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoardSecretariatSystem.Models
{
    public class InputBox
    {
        public static DialogResult Show(string title, string promptText, ref string value)
        {
            return Show(title, promptText, ref value, null);
        }

        //Fuction

        public static DialogResult Show(string title, string promptText, ref string value,
            InputBoxValidation validation)
        {
            Form form = new Form();
            Label label = new Label();
            Label label2 = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();
            TextBox textBox1 = new TextBox();
            CheckBox ch1 =new CheckBox();
            CheckBox ch2 = new CheckBox();
            form.Text = title;
            label.Text = promptText;
            label2.Text = "Confirm Password";
            textBox.Text = value;
            //textBox.PasswordChar = '*';
            textBox.UseSystemPasswordChar = true;
            textBox1.UseSystemPasswordChar = true;
            //textBox1.Enter += new System.EventHandler(textBox1_Enter); ;
            ch1.Text = "Show";
            ch2.Text = "Show";
            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            ch1.SetBounds(394,36,75,20);
            label2.SetBounds(9, 56, 372, 13);
            textBox1.SetBounds(12, 72, 372, 20);
            ch2.SetBounds(394, 72, 75, 20);
            buttonOk.SetBounds(228, 108, 75, 23);
            buttonCancel.SetBounds(309, 108, 75, 23);

            label.AutoSize = true;
            //textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            //textBox1.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 145);
            form.Controls.AddRange(new Control[] { label, textBox,ch1,label2,textBox1, buttonOk,ch2, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, ch1.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;
            if (validation != null)
            {
                textBox1.Enter += delegate(object sender, EventArgs e)
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        MessageBox.Show(@"Enter Password Before Confirm");
                        textBox.Focus();
                    }
                };
                ch1.CheckedChanged += delegate(object sender, EventArgs e)
                {
                   
                    if (ch1.Checked)
                    {
                        textBox.UseSystemPasswordChar = false;
                        //textBox.Refresh();
                    }
                    else
                    {
                        textBox.UseSystemPasswordChar = true;
                        
                    }
                };
                ch1.Leave += delegate(object sender, EventArgs e)
                {

                    ch1.Checked = false;
                };
                ch2.CheckedChanged += delegate(object sender, EventArgs e)
                {

                    if (ch2.Checked)
                    {
                        textBox1.UseSystemPasswordChar = false;
                        //textBox.Refresh();
                    }
                    else
                    {
                        textBox1.UseSystemPasswordChar = true;

                    }
                };
                ch2.Leave += delegate(object sender, EventArgs e)
                {

                    ch2.Checked = false;
                };
                textBox1.Leave += delegate(object sender, EventArgs e)
                {
                    if (!string.IsNullOrWhiteSpace(textBox.Text)&&!string.IsNullOrWhiteSpace(textBox1.Text))
                    {
                        if (textBox1.Text!=textBox.Text)
                        {
                            MessageBox.Show(@"Password Not Matched Please check");
                            textBox1.Clear();
                            textBox.Focus();
                        }
                        
                    }
                };
                form.FormClosing += delegate(object sender, FormClosingEventArgs e)
                {
                    if (form.DialogResult == DialogResult.OK)
                    {
                        string errorText = validation(textBox1.Text);
                        if (e.Cancel = (errorText != ""))
                        {
                            MessageBox.Show(form, errorText, "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox.Focus();
                        }
                    }
                };
            }
            DialogResult dialogResult = form.ShowDialog();
            value = textBox1.Text;
            return dialogResult;
        }
        //private static void textBox1_Enter(object sender, EventArgs e)
        //{
        //    if(string.IsNullOrWhiteSpace(textBox.Text))
        //}
    }

    public delegate string textValidation(string errorMessage);
    public delegate string InputBoxValidation(string errorMessage);
}
