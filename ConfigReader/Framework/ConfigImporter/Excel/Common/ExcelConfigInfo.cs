using Common.Config;
using System.Collections.Generic;

namespace ExcelImproter.Framework.ConfigImporter.Excel
{
    public interface INode{}
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
    public class ConfigElementNodeInfo : INode
    {
        public int id;
        public string name;
        public string desc;
        public DataType type;
        public string rangeMin;
        public string rangeMax;
        public string refrenceConfigName;
        public int refrenceConfigId;            
    }
    #endregion

    #region struct
    public class ConfigStructInfo : INode
    {
        public int id;
        public string name;
        public string desc;
        public List<ConfigElementNodeInfo> nodeInfoList;
    }
    #endregion

    #region list
    public class ConfigNodeListInfo : INode
    {
        public ListSplitType type;
        public ConfigElementNodeInfo nodeInfo;
    }
    public class ConfigStructListInfo : INode
    {
        public ListSplitType type;
        public ConfigStructInfo structInfo;
    }
    #endregion

    #region config
    public class ExcelConfigInfo : XmlConfigBase
    {
        public List<INode> nodeInfoList;
    }
    #endregion
}
