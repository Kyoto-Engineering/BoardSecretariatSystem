using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardSecretariatSystem.UI
{
    [Designer("System.Windows.Forms.Design.ControlDesigner, System.Design")]
    [DesignerSerializer("System.ComponentModel.Design.Serialization.TypeCodeDomSerializer , System.Design", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design")]
    public class ComboBoxWithGrid_WinformsHost : System.Windows.Forms.Integration.ElementHost
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

        public List<BoardMember> Customers
        {
            get
            {
                return m_WPFComboBoxWithGrid.BoardMembers;
            }
            set
            {
                m_WPFComboBoxWithGrid.BoardMembers = value;
            }
        }
    }
}
