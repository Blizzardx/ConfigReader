using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ExcelImproter.Framework.ConfigImporter.Excel;

namespace ExcelImproter.Framework.ConfigImporter.CodeGenerator.CSharp
{
    internal class ConfigClassDefineGenerator
    {
        private string m_strClassDefineTempate;
        private string m_strClassMemberDefineTemplate;

        public void GenClassDefine(string configName, ExcelConfigInfo source,string outputPath)
        {
            InitTempate();

            if (null == source || source.nodeInfoList == null || source.nodeInfoList.Count == 0)
            {
                return;
            }

            var content = new StringBuilder();

            for (var i = 0; i < source.nodeInfoList.Count; ++i)
            {
                content.Append(GenClassDefine(source.nodeInfoList[i]));
                content.Append('\n');
            }

            var res = new StringBuilder(m_strClassDefineTempate);

            res = res.Replace("{0}", configName + "Config");
            res = res.Replace("{1}", content.ToString());

            File.WriteAllText(outputPath + configName + "Config" + ".cs",res.ToString());
        }

        private string GenClassDefine(NodeBase nodeBase)
        {
            if (nodeBase is ConfigElementNodeInfo)
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
            var res = new StringBuilder(m_strClassMemberDefineTemplate);

            res = res.Replace("{0}", CommonTool.GetType(node.nodeInfo.type) + "[]");
            res = res.Replace("{1}", node.nodeInfo.name);

            return res.ToString();
        }

        private string GenClassDefine_StructList(ConfigStructListInfo node)
        {
            var res = new StringBuilder(m_strClassDefineTempate);

            var tmpChildDefine = new StringBuilder();
            foreach (var elem in node.structInfo.nodeInfoList)
            {
                tmpChildDefine.Append(GenClassDefine_Node(elem));
            }

            res = res.Replace("{0}", node.structInfo.name + "Class");
            res = res.Replace("{1}", tmpChildDefine.ToString());
            res.Append('\n');

            var memberDefine = new StringBuilder(m_strClassMemberDefineTemplate);

            memberDefine = memberDefine.Replace("{0}", node.structInfo.name + "Class[]");
            memberDefine = memberDefine.Replace("{1}", node.structInfo.name);
            res.Append(memberDefine);

            return res.ToString();
        }

        private string GenClassDefine_Struct(ConfigStructInfo node)
        {
            var res = new StringBuilder(m_strClassDefineTempate);

            var tmpChildDefine = new StringBuilder();
            foreach (var elem in node.nodeInfoList)
            {
                tmpChildDefine.Append(GenClassDefine_Node(elem));
            }

            res = res.Replace("{0}", node.name + "Class");
            res = res.Replace("{1}", tmpChildDefine.ToString());
            res.Append('\n');

            var memberDefine = new StringBuilder(m_strClassMemberDefineTemplate);

            memberDefine = memberDefine.Replace("{0}", node.name + "Class");
            memberDefine = memberDefine.Replace("{1}", node.name);
            res.Append(memberDefine);

            return res.ToString();
        }

        private string GenClassDefine_Node(ConfigElementNodeInfo node)
        {
            var res = new StringBuilder(m_strClassMemberDefineTemplate);

            res = res.Replace("{0}", CommonTool.GetType(node.type));
            res = res.Replace("{1}", node.name);

            return res.ToString();
        }

        private void InitTempate()
        {
            m_strClassDefineTempate = File.ReadAllText("Config/CSharpClassDefineTemplate.txt");
            m_strClassMemberDefineTemplate = File.ReadAllText("Config/CSharpClassMemberDefineTemplate.txt");
        }

       

        private List<Type> getAllTypes()
        {
            var typelist = new List<Type> {typeof (ExcelConfigInfo)};
            var list = ReflectionManager.Instance.GetTypeByBase(typeof (NodeBase));
            if (null != list)
            {
                typelist.AddRange(list);
            }
            return typelist;
        }
    }
}