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

    public partial class NodeInfoPanel : UserControl, INodeEditorView
    {
        public ConfigElementNodeInfo m_Data;

        public NodeInfoPanel(ConfigElementNodeInfo data = null)
        {
            InitializeComponent();

            comboBoxParamType.Items.Add(DataType.Bool);
            comboBoxParamType.Items.Add(DataType.Byte);
            comboBoxParamType.Items.Add(DataType.Double);
            comboBoxParamType.Items.Add(DataType.I16);
            comboBoxParamType.Items.Add(DataType.I32);
            comboBoxParamType.Items.Add(DataType.I64);
            comboBoxParamType.Items.Add(DataType.String);
            comboBoxParamType.SelectedIndex = 0;

            m_Data = data;
            if (null == m_Data)
            {
                m_Data = new ConfigElementNodeInfo();
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
            comboBoxParamType.SelectedItem = m_Data.type;
            textBoxMin.Text = m_Data.rangeMin;
            textBoxMax.Text = m_Data.rangeMax;
            textBoxRefConfigId.Text = m_Data.refrenceConfigId.ToString();
            textBoxRefConfigName.Text = m_Data.refrenceConfigName;
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
            m_Data.type=(DataType) comboBoxParamType.SelectedItem;
            m_Data.rangeMin = textBoxMin.Text;
            m_Data.rangeMax = textBoxMax.Text;

            if (!string.IsNullOrEmpty(textBoxRefConfigId.Text))
            {
                int refConfigId = 0;
                if (!int.TryParse(textBoxRefConfigId.Text, out refConfigId))
                {
                    return "refConfigId must be int";
                }
                m_Data.refrenceConfigId = refConfigId;
                m_Data.refrenceConfigName = textBoxRefConfigName.Text;
            }
            else
            {
                m_Data.refrenceConfigName = null;
                m_Data.refrenceConfigId = 0;
            }
            
            return null;
        }
        public NodeBase GetData()
        {
            return m_Data;
        }
        private void NodeInfoPanel_Load(object sender, EventArgs e)
        {

        }
    }
}
