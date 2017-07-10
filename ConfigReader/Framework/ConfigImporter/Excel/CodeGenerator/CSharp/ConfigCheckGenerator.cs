using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ExcelImproter.Framework.ConfigImporter.Excel;

namespace ExcelImproter.Framework.ConfigImporter.CodeGenerator.CSharp
{
    class ConfigCheckGenerator
    {
        private string m_strCheckerClassTempate;
        private string m_strCheckerListNodeTemplate;
        private string m_strCheckerListStructMemberTemplate;
        private string m_strCheckerListStructTemplate;
        private string m_strCheckerMemberTemplate;
        private int m_iIndex;

        internal string GenCheckerConfig(ExcelConfigInfo source)
        {
            if (null == source || source.nodeInfoList == null || source.nodeInfoList.Count == 0)
            {
                return null;
            }
            InitTempate();
            m_iIndex = 0;
            var content = new StringBuilder();

            for (int i = 0; i < source.nodeInfoList.Count; ++i)
            {
                var node = source.nodeInfoList[i];
                content.Append(GenParserClass(node));
                content.Append('\n');
            }

            StringBuilder res = new StringBuilder(m_strCheckerClassTempate);
            res = res.Replace("{CheckMember}", content.ToString());

            return res.ToString();
        }
        private void InitTempate()
        {
            m_strCheckerClassTempate = File.ReadAllText("Config/CSharpCheckConfigTemplate.txt");
            m_strCheckerMemberTemplate = File.ReadAllText("Config/CSharpCheckConfigNodeMemberTemplate.txt");
            m_strCheckerListNodeTemplate = File.ReadAllText("Config/CSharpCheckConfigListNodeTemplate.txt");
            m_strCheckerListStructTemplate = File.ReadAllText("Config/CSharpCheckConfigListStructTemplate.txt");
            m_strCheckerListStructMemberTemplate = File.ReadAllText("Config/CSharpCheckConfigListStructMemberTemplate.txt");
        }
        private string GenParserClass(NodeBase nodeBase)
        {
            if (nodeBase is ConfigElementNodeInfo)
            {
                return GenParserClass_Node(nodeBase as ConfigElementNodeInfo);
            }
            if (nodeBase is ConfigStructInfo)
            {
                return GenParserClass_Struct(nodeBase as ConfigStructInfo);
            }
            if (nodeBase is ConfigStructListInfo)
            {
                return GenParserClass_StructList(nodeBase as ConfigStructListInfo);
            }
            if (nodeBase is ConfigNodeListInfo)
            {
                return GenParserClass_NodeLlist(nodeBase as ConfigNodeListInfo);
            }
            return string.Empty;
        }
        private string GenParserClass_Node(ConfigElementNodeInfo node)
        {
            StringBuilder res = new StringBuilder(m_strCheckerMemberTemplate);

            res = res.Replace("{id}", node.id.ToString());
            res = res.Replace("{realIndex}", m_iIndex.ToString());
            res.Append('\n');

            ++m_iIndex;
            return res.ToString();
        }
        private string GenParserClass_Struct(ConfigStructInfo node)
        {
            StringBuilder res = new StringBuilder();

            for (int i = 0; i < node.nodeInfoList.Count; ++i)
            {
                res.Append(GenParserClass_Node( node.nodeInfoList[i]));
            }
            return res.ToString();
        }
        private string GenParserClass_NodeLlist(ConfigNodeListInfo node)
        {
            string sourceListName = node.nodeInfo.name + "SourceList";

            StringBuilder res = new StringBuilder(m_strCheckerListNodeTemplate);

            res = res.Replace("{id}", node.nodeInfo.id.ToString());
            res = res.Replace("{sourceList}", sourceListName);
            res = res.Replace("{realIndex}", m_iIndex.ToString());
            res = res.Replace("{splitType}", ((int)node.type).ToString());

            res.Append('\n');

            ++m_iIndex;

            return res.ToString();
        }
        private string GenParserClass_StructList(ConfigStructListInfo node)
        {
            string sourceListName = node.structInfo.name + "SourceList";

            StringBuilder memberParser = new StringBuilder();
            for (int i = 0; i < node.structInfo.nodeInfoList.Count; ++i)
            {
                var tmpNode = node.structInfo.nodeInfoList[i];

                StringBuilder lineElement = new StringBuilder(m_strCheckerListStructMemberTemplate);
                lineElement = lineElement.Replace("{tmpIndex}", i.ToString());
                lineElement = lineElement.Replace("{id}", tmpNode.id.ToString());
                lineElement = lineElement.Replace("{sourceList}", sourceListName);
                lineElement.Append('\n');

                memberParser.Append(lineElement);
            }

            StringBuilder res = new StringBuilder(m_strCheckerListStructTemplate);

            res = res.Replace("{structMemberCount}", node.structInfo.nodeInfoList.Count.ToString());
            res = res.Replace("{sourceList}", sourceListName);
            res = res.Replace("{realIndex}", m_iIndex.ToString());
            res = res.Replace("{splitType}", ((int)node.type).ToString());

            res = res.Replace("{ParserListMember}", memberParser.ToString());

            res.Append('\n');

            ++m_iIndex;

            return res.ToString();
        }
    }
}
