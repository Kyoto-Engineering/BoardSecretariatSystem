using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BoardSecretariatSystem
{
    /// <summary>
    /// Interaction logic for TextWithSpellCheck.xaml
    /// </summary>
    public partial class TextWithSpellCheck : UserControl
    {
        public TextWithSpellCheck()
        {
            InitializeComponent();
        }
        public string Text
        {
            get
            {
                return textBox.Text;

            }
            set
            {
                textBox.Text = value;
            }
        }
    }
}
