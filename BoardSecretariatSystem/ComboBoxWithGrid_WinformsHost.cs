using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardSecretariatSystem
{
    [Designer("System.Windows.Forms.Design.ControlDesigner, System.Design")]
    [DesignerSerializer("System.ComponentModel.Design.Serialization.TypeCodeDomSerializer , System.Design", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design")]
    class ComboBoxWithGrid_WinformsHost : System.Windows.Forms.Integration.ElementHost
    {
        protected ComboBoxWithGrid m_WPFComboBoxWithGrid = new ComboBoxWithGrid();

        public ComboBoxWithGrid_WinformsHost()
        {
    base.Child = m_WPFComboBoxWithGrid;     
            
        }

        public int SelectedIndex
        {
            get
            {
                return m_WPFComboBoxWithGrid.SelectedIndex;
            }
            set
            {
                m_WPFComboBoxWithGrid.SelectedIndex = value;
            }
        }
        public Employee2 SelectedItem
        {
            get
            {
                return m_WPFComboBoxWithGrid.SelectedItem;
            }
            set
            {
                m_WPFComboBoxWithGrid.SelectedItem = value;
            }
        }

        public List<Employee2> Employee2s
        {
            get
            {
                return m_WPFComboBoxWithGrid.Employees;
            }
            set
            {
                m_WPFComboBoxWithGrid.Employees = value;
            }
        }
    }
}
