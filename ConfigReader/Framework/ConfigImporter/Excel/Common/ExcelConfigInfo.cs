using Common.Config;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ExcelImproter.Framework.ConfigImporter.Excel
{
    public class NodeBase{}

    public enum DataType
    {
        Bool,
        Byte,
        Double,
        I16,
        I32,
        I64,
        String,
    }

    public enum ListSplitType
    {
        Letter,
        Brackets,
    }

    #region element
    public class ConfigElementNodeInfo : NodeBase
    {
        [XmlAttribute("id")]
        public int id;
        [XmlAttribute("name")]
        public string name;
        [XmlAttribute("desc")]
        public string desc;
        [XmlAttribute("type")]
        public DataType type;
        [XmlAttribute("rangeMin")]
        public string rangeMin;
        [XmlAttribute("rangeMax")]
        public string rangeMax;
        [XmlAttribute("refrenceConfigName")]
        public string refrenceConfigName;
        [XmlAttribute("refrenceConfigId")]
        public int refrenceConfigId;
        [XmlAttribute("defaultValue")]
        public string defaultValue;
        [XmlAttribute("isAllowDefaultValue")]
        public bool isAllowDefaultValue;
    }
    #endregion

    #region struct
    public class ConfigStructInfo : NodeBase
    {
        [XmlAttribute("id")]
        public int id;
        [XmlAttribute("name")]
        public string name;
        [XmlAttribute("desc")]
        public string desc;
        [XmlElement("nodeInfoList")]
        public List<ConfigElementNodeInfo> nodeInfoList;
    }
    #endregion

    #region list
    public class ConfigNodeListInfo : NodeBase
    {
        [XmlAttribute("types")]
        public ListSplitType type;
        [XmlElement("nodeInfo")]
        public ConfigElementNodeInfo nodeInfo;
    }
    public class ConfigStructListInfo : NodeBase
    {
        [XmlAttribute("types")]
        public ListSplitType type;
        [XmlElement("structInfo")]
        public ConfigStructInfo structInfo;
    }
    #endregion

    #region config
    [XmlRoot("root")]
    public class ExcelConfigInfo : XmlConfigBase
    {
        [XmlElement("nodeInfoList")]
        public List<NodeBase> nodeInfoList;
    }
    #endregion
}
