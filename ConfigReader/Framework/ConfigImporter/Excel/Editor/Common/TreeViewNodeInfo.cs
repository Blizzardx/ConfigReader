using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExcelImproter.Framework.ConfigImporter.Excel.Editor
{
    class TreeViewNodeInfo : TreeNode
    {
        private Dictionary<Type, string> m_TypeToNameMap;
        private NodeBase m_Data;

        public TreeViewNodeInfo(NodeBase data)
        {
            m_TypeToNameMap=new Dictionary<Type, string>();
            m_TypeToNameMap.Add(typeof(ConfigElementNodeInfo), "元素");
            m_TypeToNameMap.Add(typeof(ConfigStructInfo), "结构体");
            m_TypeToNameMap.Add(typeof(ConfigNodeListInfo), "数组-元素");
            m_TypeToNameMap.Add(typeof(ConfigStructListInfo), "数组-结构体");

            SetData(data);
        }

        public void SetData(NodeBase data)
        {
            m_Data = data;
            Text = GetDisplayName();
        }
        public NodeBase GetData()
        {
            return m_Data;
        }

        public string GetDisplayName()
        {
            string suffix = string.Empty;

            if (m_Data is ConfigElementNodeInfo)
            {
                var data = m_Data as ConfigElementNodeInfo;
                suffix = ":" + data.name;
            }
            if (m_Data is ConfigStructInfo)
            {
                var data = m_Data as ConfigStructInfo;
                suffix = ":" + data.name;
            }
            if (m_Data is ConfigNodeListInfo)
            {
            }
            if (m_Data is ConfigStructListInfo)
            {
            }
            return m_TypeToNameMap[m_Data.GetType()] + suffix;
        }
        public string GetDisplayTypeName()
        {
            return m_TypeToNameMap[m_Data.GetType()];
        }
        public bool CheckCanAddChildNode()
        {
            if (m_Data is ConfigElementNodeInfo)
            {
                return false;
            }
            return true;
        }
    }
}
