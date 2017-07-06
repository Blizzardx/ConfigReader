using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
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
            if (string.IsNullOrEmpty(textBoxNodeId.Text))
            {
                return "id can't be null";
            }
            int id = 0;
            if (!int.TryParse(textBoxNodeId.Text, out id))
            {
                return "id must be int";
            }
            if (string.IsNullOrEmpty(textBoxNodeDesc.Text))
            {
                return "desc can't be null";
            }
            if (string.IsNullOrEmpty(textBoxNodeName.Text))
            {
                return "name can't be null";
            }
            m_Data.id = id;
            m_Data.desc = textBoxNodeDesc.Text;
            m_Data.name = textBoxNodeName.Text;
            return null;
        }

        public INode GetData()
        {
            return m_Data;
        }
        private void StructInfoPanel_Load(object sender, EventArgs e)
        {

        }
    }
}
