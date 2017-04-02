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
using BoardSecretariatSystem;

namespace BoardSecretariatSystem
{
    /// <summary>
    /// Interaction logic for ComboBoxWithGrid.xaml
    /// </summary>
    public partial class ComboBoxWithGrid : UserControl
    {
        public ComboBoxWithGrid()
        {
             InitializeComponent();
            SelectedIndex = 0;
            SelectedItem = null;

            this.DataContext = this;
        }

        public int SelectedIndex 
        {
            get
            {
               return comboBox.SelectedIndex;
            }
            set
            {
                comboBox.SelectedIndex = value;
            }
        }
        public Employee2  SelectedItem
        {
            get { return (Employee2)comboBox.SelectedItem; }
            set
            {
                comboBox.SelectedItem = value;
            }
        } 
        public List<Employee2> Employees { get; set; }
    }
        }
    

