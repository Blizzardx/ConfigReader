using Util;
using System.Collections.Generic;

public class test_xmlConfigParser
{
    private string m_strErrorMsg;

    public string GetErrorMsg()
    {
        return m_strErrorMsg;
    }
    public List<test_xmlConfig> ParserConfig(string[][] content)
    {
        List<test_xmlConfig> resultConfigTable = new List<test_xmlConfig>();
        for (int i = 0; i < content.Length; ++i)
        {
            resultConfigTable.Add(ParserLine(i, content[i]));

            if (string.IsNullOrEmpty(m_strErrorMsg))
            {
                return null;
            }
        }
        return resultConfigTable;
    }
    private test_xmlConfig ParserLine(int lineIndex, string[] values)
    {
		int tmpIndexOffset = 0;
		int skipCount = 0;

		test_xmlConfig configLineElement = new test_xmlConfig();

			if (!VaildUtil.TryConvert(values[0 + tmpIndexOffset], out configLineElement.id,0,50))
            {
                m_strErrorMsg = string.Format("{7} {0}.xlsx [{1},{2}]读取出现错误，{3}必须为{4} - {5} {6}型", "test_xmlConfig", lineIndex,0+1, configLineElement.id,0,50,"int","id");
	            return null;
            }

			if (!VaildUtil.TryConvert(values[1 + tmpIndexOffset], out configLineElement.nameMessageId,int.MinValue,int.MaxValue))
            {
                m_strErrorMsg = string.Format("{7} {0}.xlsx [{1},{2}]读取出现错误，{3}必须为{4} - {5} {6}型", "test_xmlConfig", lineIndex,1+1, configLineElement.nameMessageId,int.MinValue,int.MaxValue,"int","nameMessageId");
	            return null;
            }

			configLineElement.position = new test_xmlConfig.positionClass();
			if (!VaildUtil.TryConvert(values[2 + tmpIndexOffset], out configLineElement.position.x,double.MinValue,double.MaxValue))
            {
                m_strErrorMsg = string.Format("{7} {0}.xlsx [{1},{2}]读取出现错误，{3}必须为{4} - {5} {6}型", "test_xmlConfig", lineIndex,2+1, configLineElement.position.x,double.MinValue,double.MaxValue,"double","x");
	            return null;
            }
			if (!VaildUtil.TryConvert(values[3 + tmpIndexOffset], out configLineElement.position.y,double.MinValue,double.MaxValue))
            {
                m_strErrorMsg = string.Format("{7} {0}.xlsx [{1},{2}]读取出现错误，{3}必须为{4} - {5} {6}型", "test_xmlConfig", lineIndex,3+1, configLineElement.position.y,double.MinValue,double.MaxValue,"double","y");
	            return null;
            }
			if (!VaildUtil.TryConvert(values[4 + tmpIndexOffset], out configLineElement.position.z,double.MinValue,double.MaxValue))
            {
                m_strErrorMsg = string.Format("{7} {0}.xlsx [{1},{2}]读取出现错误，{3}必须为{4} - {5} {6}型", "test_xmlConfig", lineIndex,4+1, configLineElement.position.z,double.MinValue,double.MaxValue,"double","z");
	            return null;
            }

			configLineElement.resource = new test_xmlConfig.resourceClass();
			if (!VaildUtil.TryConvert(values[5 + tmpIndexOffset], out configLineElement.resource.textureName,null,null))
            {
                m_strErrorMsg = string.Format("{7} {0}.xlsx [{1},{2}]读取出现错误，{3}必须为{4} - {5} {6}型", "test_xmlConfig", lineIndex,5+1, configLineElement.resource.textureName,null,null,"string","textureName");
	            return null;
            }

			List<string> rotationSourceList = null;
			if (!VaildUtil.TryConvert(values[6 + tmpIndexOffset], 0,out rotationSourceList ,out skipCount))
            {
                m_strErrorMsg = string.Format("{3} {0}.xlsx [{1},{2}]数组解析读取出现错误", "test_xmlConfig", lineIndex,6+1,"{desc}");
	            return null;
            }

			var rotationList = new test_xmlConfig.rotationClass[rotationSourceList.Count];
			
			for(int i=0;i<3;++i)
			{
				int startIndex = i * 3;

				var rotationElement = new test_xmlConfig.rotationClass();	
				rotationList[i] = rotationElement;				

				if (!VaildUtil.TryConvert(values[0 + startIndex], out rotationElement.x,double.MinValue,double.MaxValue))
				{
					m_strErrorMsg = string.Format("{7} {0}.xlsx [{1},{2}]读取出现错误，{3}必须为{4} - {5} {6}型", "test_xmlConfig", lineIndex,0+1, rotationElement.x,double.MinValue,double.MaxValue,"double","x");
					return null;
				}
				if (!VaildUtil.TryConvert(values[1 + startIndex], out rotationElement.y,double.MinValue,double.MaxValue))
				{
					m_strErrorMsg = string.Format("{7} {0}.xlsx [{1},{2}]读取出现错误，{3}必须为{4} - {5} {6}型", "test_xmlConfig", lineIndex,1+1, rotationElement.y,double.MinValue,double.MaxValue,"double","y");
					return null;
				}
				if (!VaildUtil.TryConvert(values[2 + startIndex], out rotationElement.z,double.MinValue,double.MaxValue))
				{
					m_strErrorMsg = string.Format("{7} {0}.xlsx [{1},{2}]读取出现错误，{3}必须为{4} - {5} {6}型", "test_xmlConfig", lineIndex,2+1, rotationElement.z,double.MinValue,double.MaxValue,"double","z");
					return null;
				}

			}
			tmpIndexOffset += skipCount;

			List<string> attachNamePositionSourceList = null;
			if (!VaildUtil.TryConvert(values[7 + tmpIndexOffset], 0, out attachNamePositionSourceList , out skipCount))
            {
                m_strErrorMsg = string.Format("{3} {0}.xlsx [{1},{2}]数组解析读取出现错误", "test_xmlConfig", lineIndex,7+1,"{desc}");
	            return null;
            }

			var attachNamePositionList = new string[attachNamePositionSourceList.Count];

			for(int i=0;i<attachNamePositionSourceList.Count;++i)
			{		
				string subElement;	

				if (!VaildUtil.TryConvert(attachNamePositionSourceList[i], out subElement,null,null))
				{
					m_strErrorMsg = string.Format("{7} {0}.xlsx [{1},{2}]数组解析读取出现错误，{3}必须为{4} - {5} {6}型", "test_xmlConfig", lineIndex,i+1, subElement,null,null,"string","attachNamePosition");
					return null;
				}


				attachNamePositionList[i] = subElement;
			}

			tmpIndexOffset += skipCount;

			List<string> audioSourceSourceList = null;
			if (!VaildUtil.TryConvert(values[8 + tmpIndexOffset], 0,out audioSourceSourceList ,out skipCount))
            {
                m_strErrorMsg = string.Format("{3} {0}.xlsx [{1},{2}]数组解析读取出现错误", "test_xmlConfig", lineIndex,8+1,"{desc}");
	            return null;
            }

			var audioSourceList = new test_xmlConfig.audioSourceClass[audioSourceSourceList.Count];
			
			for(int i=0;i<1;++i)
			{
				int startIndex = i * 1;

				var audioSourceElement = new test_xmlConfig.audioSourceClass();	
				audioSourceList[i] = audioSourceElement;				

				if (!VaildUtil.TryConvert(values[0 + startIndex], out audioSourceElement.audioSourceName,null,null))
				{
					m_strErrorMsg = string.Format("{7} {0}.xlsx [{1},{2}]读取出现错误，{3}必须为{4} - {5} {6}型", "test_xmlConfig", lineIndex,0+1, audioSourceElement.audioSourceName,null,null,"string","auduioSourceName");
					return null;
				}

			}
			tmpIndexOffset += skipCount;



		return configLineElement;
    }
}