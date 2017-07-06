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
        private INode m_Data;

        public TreeViewNodeInfo(INode data)
        {
            m_TypeToNameMap=new Dictionary<Type, string>();
            m_TypeToNameMap.Add(typeof(ConfigElementNodeInfo), "元素");
            m_TypeToNameMap.Add(typeof(ConfigStructInfo), "结构体");
            m_TypeToNameMap.Add(typeof(ConfigNodeListInfo), "数组-元素");
            m_TypeToNameMap.Add(typeof(ConfigStructListInfo), "数组-结构体");

            SetData(data);
        }

        public void SetData(INode data)
        {
            m_Data = data;
            Text = GetDisplayName();
        }
        public INode GetData()
        {
            return m_Data;
        }

        public string GetDisplayName()
        {
            return m_TypeToNameMap[m_Data.GetType()];
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
