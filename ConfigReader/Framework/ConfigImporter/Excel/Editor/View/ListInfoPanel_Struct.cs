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
    public partial class ListInfoPanel_Struct : UserControl, INodeEditorView
    {
        private ConfigStructListInfo m_Data;

        private string[] m_ListType = new string[]
       {
            "|分割",
            "()分割",
       };
        public INode GetData()
        {
            return m_Data;
        }
        public string CheckData()
        {
            return null;
        }

        public ListInfoPanel_Struct(ConfigStructListInfo data = null)
        {
            InitializeComponent();
            for (int i = 0; i < m_ListType.Length; ++i)
            {
                comboBoxParamType.Items.Add(m_ListType[i]);
            }
            comboBoxParamType.SelectedValueChanged += OnSelectType;
            m_Data = data;
            if (null == m_Data)
            {
                m_Data = new ConfigStructListInfo();

                comboBoxParamType.SelectedIndex = 0;
            }
            else
            {
                comboBoxParamType.SelectedIndex = (int)m_Data.type;
            }
        }

        private void OnSelectType(object sender, EventArgs e)
        {
            m_Data.type = (ListSplitType)comboBoxParamType.SelectedIndex;
        }
    }
}
