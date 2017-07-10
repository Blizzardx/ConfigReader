using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Text;
using ExcelImproter.Framework.ConfigImporter.Excel;


namespace ExcelImproter.Framework.ConfigImporter.CodeGenerator.CSharp
{
    internal class ConfigParserGenerator
    {
        private string m_strParserClassTempate;
        private string m_strParserMemberTemplate;
        private string m_strParserListNodeTemplate;
        private string m_strParserListNodeMemberTemplate;
        private string m_strParserListStructTemplate;
        private string m_strParserListStructMemberTemplate;

        private string m_strConfigName;
        private string m_strLineElementMemberName;
        private int m_iIndex;

        private ConfigCheckGenerator m_ConfigCheckGen;

        public void GenParserClass(string configName, ExcelConfigInfo source,string outputPath)
        {
            if (null == source || source.nodeInfoList == null || source.nodeInfoList.Count == 0)
            {
                return;
            }

            InitTempate();
            m_strConfigName = configName ;
            m_strLineElementMemberName = "configLineElement";
            m_iIndex = 0;

            var content = new StringBuilder();

            for (int i = 0; i < source.nodeInfoList.Count; ++i)
            {
                var node = source.nodeInfoList[i];
                content.Append(GenParserClass(node));
                content.Append('\n');
            }

            StringBuilder res = new StringBuilder(m_strParserClassTempate);
            res = res.Replace("{ParserMember}", content.ToString());
            res = res.Replace("{ConfigName}", m_strConfigName );
            res = res.Replace("{result}", "resultConfigTable" );
            res = res.Replace("{className}", m_strConfigName);
            res = res.Replace("{lineElement}", m_strLineElementMemberName);

            m_ConfigCheckGen = new ConfigCheckGenerator();
            var checkContent = m_ConfigCheckGen.GenCheckerConfig(source);
            res = res.Replace("{ConfigChecker}", checkContent);

            File.WriteAllText(outputPath + m_strConfigName + "Parser.cs", res.ToString());
        }
        private void InitTempate()
        {
            m_strParserClassTempate = File.ReadAllText("Config/CSharpParserClassTemplate.txt");
            m_strParserMemberTemplate = File.ReadAllText("Config/CSharpParserNodeMemberTemplate.txt");
            m_strParserListNodeTemplate = File.ReadAllText("Config/CSharpParserListNodeTemplate.txt");
            m_strParserListNodeMemberTemplate = File.ReadAllText("Config/CSharpParserListNodeMemberTemplate.txt");
            m_strParserListStructTemplate = File.ReadAllText("Config/CSharpParserListStructTemplate.txt");
            m_strParserListStructMemberTemplate = File.ReadAllText("Config/CSharpParserListStructMemberTemplate.txt");
        }
        private string GenParserClass(NodeBase nodeBase)
        {
            if (nodeBase is ConfigElementNodeInfo)
            {
                return GenParserClass_Node(m_strLineElementMemberName,nodeBase as ConfigElementNodeInfo);
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
        private string GenParserClass_Node(string rootMemberName,ConfigElementNodeInfo node)
        {
            string rangeMin = node.rangeMin;
            string rangeMax = node.rangeMax;

            if (string.IsNullOrEmpty(rangeMin))
            {
                rangeMin = CommonTool.GetMinRangeByDataType(node.type);
            }
            if (string.IsNullOrEmpty(rangeMax))
            {
                rangeMax = CommonTool.GetMaxRangeByDataType(node.type);
            }
            StringBuilder res = new StringBuilder(m_strParserMemberTemplate);

            res = res.Replace("{refrenceConfigName}", node.refrenceConfigName);
            res = res.Replace("{refrenceConfigId}", node.refrenceConfigId.ToString());
            res = res.Replace("{membername}", rootMemberName + "." + node.name);
            res = res.Replace("{index}", m_iIndex.ToString());
            res = res.Replace("{min}", rangeMin);
            res = res.Replace("{max}", rangeMax);
            res = res.Replace("{configName}", m_strConfigName);
            res = res.Replace("{classname}", CommonTool.GetType(node.type));
            res = res.Replace("{desc}", node.desc);
            res.Append('\n');

            ++m_iIndex;
            return res.ToString();
        }
        private string GenParserClass_Struct(ConfigStructInfo node)
        {
            string structType = m_strConfigName + "." + node.name + "Class";
            string structMemberName = m_strLineElementMemberName + "." + node.name;

            StringBuilder res = new StringBuilder();
            res.Append('\t');
            res.Append('\t');
            res.Append('\t');
            res.Append(structMemberName + " = new " + structType + "();");
            res.Append('\n');

            for (int i = 0; i < node.nodeInfoList.Count; ++i)
            {
                res.Append(GenParserClass_Node(structMemberName, node.nodeInfoList[i]));
            }
            return res.ToString();
        }
        private string GenParserClass_NodeLlist(ConfigNodeListInfo node)
        {
            string sourceListName = node.nodeInfo.name + "SourceList";
            string listName = m_strLineElementMemberName + "." + node.nodeInfo.name;
            string tmpListElement = node.nodeInfo.name + "TmpList";

            StringBuilder memberParser = new StringBuilder(m_strParserListNodeMemberTemplate);
            string rangeMin = node.nodeInfo.rangeMin;
            string rangeMax = node.nodeInfo.rangeMax;

            if (string.IsNullOrEmpty(rangeMin))
            {
                rangeMin = CommonTool.GetMinRangeByDataType(node.nodeInfo.type);
            }
            if (string.IsNullOrEmpty(rangeMax))
            {
                rangeMax = CommonTool.GetMaxRangeByDataType(node.nodeInfo.type);
            }
            memberParser = memberParser.Replace("{refrenceConfigName}", node.nodeInfo.refrenceConfigName);
            memberParser = memberParser.Replace("{refrenceConfigId}", node.nodeInfo.refrenceConfigId.ToString());
            memberParser = memberParser.Replace("{sourceList}", sourceListName);
            memberParser = memberParser.Replace("{min}", rangeMin);
            memberParser = memberParser.Replace("{max}", rangeMax);
            memberParser = memberParser.Replace("{configName}", m_strConfigName);
            memberParser = memberParser.Replace("{classname}", CommonTool.GetType(node.nodeInfo.type));
            memberParser = memberParser.Replace("{desc}", node.nodeInfo.desc);

            memberParser.Append('\n');


            StringBuilder res = new StringBuilder(m_strParserListNodeTemplate);

            
            res = res.Replace("{sourceList}", sourceListName);
            res = res.Replace("{listMembername}", listName);
            res = res.Replace("{index}", m_iIndex.ToString());
            res = res.Replace("{configName}", m_strConfigName);
            res = res.Replace("{listStructName}", CommonTool.GetType(node.nodeInfo.type));
            res = res.Replace("{splitType}", ((int)node.type).ToString()); 
            res = res.Replace("{tmplistMembername}", tmpListElement); 

             res = res.Replace("{ParserListMember}", memberParser.ToString());
            res.Append('\n');

            ++m_iIndex;

            return res.ToString();
        }
        private string GenParserClass_StructList(ConfigStructListInfo node)
        {
            string sourceListName = node.structInfo.name + "SourceList";
            string listName = m_strLineElementMemberName + "." + node.structInfo.name;
            string structLineElement = node.structInfo.name + "Element";
            string tmpListElement = node.structInfo.name + "TmpList";

            StringBuilder memberParser = new StringBuilder();
            for (int i = 0; i < node.structInfo.nodeInfoList.Count; ++i)
            {
                var tmpNode = node.structInfo.nodeInfoList[i];

                string rangeMin = tmpNode.rangeMin;
                string rangeMax = tmpNode.rangeMax;

                if (string.IsNullOrEmpty(rangeMin))
                {
                    rangeMin = CommonTool.GetMinRangeByDataType(tmpNode.type);
                }
                if (string.IsNullOrEmpty(rangeMax))
                {
                    rangeMax = CommonTool.GetMaxRangeByDataType(tmpNode.type);
                }

                StringBuilder lineElement = new StringBuilder(m_strParserListStructMemberTemplate);
                lineElement = lineElement.Replace("{refrenceConfigName}", tmpNode.refrenceConfigName);
                lineElement = lineElement.Replace("{refrenceConfigId}", tmpNode.refrenceConfigId.ToString());
                lineElement = lineElement.Replace("{index}", i.ToString());
                lineElement = lineElement.Replace("{min}", rangeMin);
                lineElement = lineElement.Replace("{max}", rangeMax);
                lineElement = lineElement.Replace("{configName}", m_strConfigName);
                lineElement = lineElement.Replace("{classname}", CommonTool.GetType(tmpNode.type));
                lineElement = lineElement.Replace("{desc}", tmpNode.desc);
                lineElement = lineElement.Replace("{sourceList}", sourceListName);

                lineElement = lineElement.Replace("{membername}", structLineElement + "." + tmpNode.name);
                lineElement.Append('\n');

                memberParser.Append(lineElement);
            }

            StringBuilder res = new StringBuilder(m_strParserListStructTemplate);

            res = res.Replace("{structMemberCount}", node.structInfo.nodeInfoList.Count.ToString());
            res = res.Replace("{subElement}", structLineElement);
            res = res.Replace("{sourceList}", sourceListName);
            res = res.Replace("{listMembername}", listName);
            res = res.Replace("{index}", m_iIndex.ToString());
            res = res.Replace("{configName}", m_strConfigName);
            res = res.Replace("{splitType}", ((int)node.type).ToString());
            res = res.Replace("{listStructName}", m_strConfigName + "." + node.structInfo.name+"Class");
            res = res.Replace("{tmplistMembername}", tmpListElement);

            res = res.Replace("{ParserListMember}", memberParser.ToString());

            res.Append('\n');
            
            ++m_iIndex;

            return res.ToString();
        }
    }
}

