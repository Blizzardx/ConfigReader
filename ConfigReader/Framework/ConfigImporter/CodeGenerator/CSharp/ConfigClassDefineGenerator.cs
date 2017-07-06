using ExcelImproter.Framework.ConfigImporter.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcelImproter.Framework.ConfigImporter.CodeGenerator
{
    class ConfigClassDefineGenerator
    {
        private string m_strClassDefineTempate;
        private string m_strClassMemberDefineTemplate;

        public string GenClassDefine(string configName,ExcelConfigInfo source)
        {
            InitTempate();

            if(null == source || source.nodeInfoList == null || source.nodeInfoList.Count==0)
            {
                return null;
            }

            StringBuilder content = new StringBuilder();

            for(int i=0;i<source.nodeInfoList.Count;++i)
            {
                content.Append(GenClassDefine(source.nodeInfoList[i]));
                content.Append('\n');
            }

            StringBuilder res = new StringBuilder(m_strClassDefineTempate);
            
            res = res.Replace("{0}", configName + "Config");
            res = res.Replace("{1}", content.ToString());
            return res.ToString();
            
        }        
        private string GenClassDefine(NodeBase nodeBase)
        {
            if(nodeBase is ConfigElementNodeInfo)
            {
                return GenClassDefine_Node(nodeBase as ConfigElementNodeInfo);
            }
            if (nodeBase is ConfigStructInfo)
            {
                return GenClassDefine_Struct(nodeBase as ConfigStructInfo);
            }
            if (nodeBase is ConfigStructListInfo)
            {
                return GenClassDefine_StructList(nodeBase as ConfigStructListInfo);
            }
            if (nodeBase is ConfigNodeListInfo)
            {
                return GenClassDefine_NodeLlist(nodeBase as ConfigNodeListInfo);
            }
            return string.Empty;
        }
        private string GenClassDefine_NodeLlist(ConfigNodeListInfo node)
        {
            StringBuilder res = new StringBuilder(m_strClassMemberDefineTemplate);

            res = res.Replace("{0}", GetType(node.nodeInfo.type) + "[]");
            res = res.Replace("{1}", node.nodeInfo.name);

            return res.ToString();
        }
        private string GenClassDefine_StructList(ConfigStructListInfo node)
        {
            StringBuilder res = new StringBuilder(m_strClassDefineTempate);

            StringBuilder tmpChildDefine = new StringBuilder();
            foreach (var elem in node.structInfo.nodeInfoList)
            {
                tmpChildDefine.Append(GenClassDefine_Node(elem));
            }

            res = res.Replace("{0}", node.structInfo.name + "Class");
            res = res.Replace("{1}", tmpChildDefine.ToString());
            res.Append('\n');

            StringBuilder memberDefine = new StringBuilder(m_strClassMemberDefineTemplate);

            memberDefine = memberDefine.Replace("{0}", node.structInfo.name + "Class[]");
            memberDefine = memberDefine.Replace("{1}", node.structInfo.name);
            res.Append(memberDefine);

            return res.ToString();
        }
        private string GenClassDefine_Struct(ConfigStructInfo node)
        {
            StringBuilder res = new StringBuilder(m_strClassDefineTempate);
            
            StringBuilder tmpChildDefine = new StringBuilder();
            foreach(var elem in node.nodeInfoList)
            {
                tmpChildDefine.Append(GenClassDefine_Node(elem));
            }

            res = res.Replace("{0}", node.name + "Class");
            res = res.Replace("{1}", tmpChildDefine.ToString());
            res.Append('\n');

            StringBuilder memberDefine = new StringBuilder(m_strClassMemberDefineTemplate);

            memberDefine = memberDefine.Replace("{0}", node.name + "Class");
            memberDefine = memberDefine.Replace("{1}", node.name);
            res.Append(memberDefine);

            return res.ToString();
        }
        private string GenClassDefine_Node(ConfigElementNodeInfo node)
        {
            StringBuilder res = new StringBuilder(m_strClassMemberDefineTemplate);

            res = res.Replace("{0}", GetType(node.type));
            res = res.Replace("{1}", node.name);

            return res.ToString();
        }
        private void InitTempate()
        {
            m_strClassDefineTempate = System.IO.File.ReadAllText("Config/CSharpClassDefineTemplate.txt");
            m_strClassMemberDefineTemplate = System.IO.File.ReadAllText("Config/CSharpClassMemberDefineTemplate.txt");
        }
        private string GetType(DataType type)
        {
            switch (type)
            {
                case DataType.Bool:
                    return "bool";
                case DataType.Byte:
                    return "sbyte";
                case DataType.Double:
                    return "double";
                case DataType.I16:
                    return "short";
                case DataType.I32:
                    return "int";
                case DataType.I64:
                    return "long";
                case DataType.String:
                    return "string";
            }
            return null;
        }
        List<Type> getAllTypes()
        {
            List<Type> typelist = new List<Type>() { typeof(ExcelConfigInfo) };
            var list = ReflectionManager.Instance.GetTypeByBase(typeof(NodeBase));
            if (null != list)
            {
                typelist.AddRange(list);
            }
            return typelist;
        }
    }
}
