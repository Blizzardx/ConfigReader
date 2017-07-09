using Common.Config;

public class SystemConst
{
    public static PathConfig config;
}
public class PathConfig : XmlConfigBase
{
    public string ParserOutputPath;
    public string XmlRootPath;
}