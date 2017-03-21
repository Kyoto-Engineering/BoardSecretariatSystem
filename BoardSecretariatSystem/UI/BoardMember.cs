using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardSecretariatSystem.UI
{
   public  class BoardMember
    {
        public string Name { get; set; }

        public string Designation { get; set; }

        public string Email { get; set; }
    }

   /// <summary>
   /// Interaction logic for UserControl1.xaml
   /// </summary>
   public partial class ComboBoxWithGrid : UserControl
   {
       public ComboBoxWithGrid()
       {
           InitializeComponent();
           SelectedIndex = 0;

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
       public List<BoardMember> BoardMembers { get; set; }
   }
}
