using System;
using System.Windows.Forms;

namespace ExcelImproter.Framework.ConfigImporter.Excel.Editor
{
    public partial class StructInfoPanel : UserControl, INodeEditorView
    {
        public ConfigStructInfo m_Data;

        public StructInfoPanel(ConfigStructInfo data = null)
        {
            InitializeComponent();
            m_Data = data;
            if (null == m_Data)
            {
                m_Data = new ConfigStructInfo();
            }
            else
            {
                RefreshData();
            }
        }
        private void RefreshData()
        {
            textBoxNodeId.Text = m_Data.id.ToString();
            textBoxNodeDesc.Text = m_Data.desc;
            textBoxNodeName.Text = m_Data.name;
        }
        public string CheckData()
        {           
            if (string.IsNullOrEmpty(textBoxNodeDesc.Text))
            {
                return "desc can't be null";
            }
            if (string.IsNullOrEmpty(textBoxNodeName.Text))
            {
                return "name can't be null";
            }
            m_Data.desc = textBoxNodeDesc.Text;
            m_Data.name = textBoxNodeName.Text;
            return null;
        }

        public NodeBase GetData()
        {
            return m_Data;
        }
        private void StructInfoPanel_Load(object sender, EventArgs e)
        {

        }
    }
}
