using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcelImproter.Framework.ConfigImporter.Excel;

namespace ExcelImproter.Framework.ConfigImporter.CodeGenerator.CSharp
{
    class CommonTool
    {
        public static string GetType(DataType type)
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
        public static string GetMinRangeByDataType(DataType type)
        {
            switch (type)
            {
                case DataType.Bool:
                    return "";
                case DataType.Byte:
                    return "sbyte.MinValue";
                case DataType.Double:
                    return "double.MinValue";
                case DataType.I16:
                    return "short.MinValue";
                case DataType.I32:
                    return "int.MinValue";
                case DataType.I64:
                    return "long.MinValue";
                case DataType.String:
                    return "null";
            }
            return null;
        }
        public static string GetMaxRangeByDataType(DataType type)
        {
            switch (type)
            {
                case DataType.Bool:
                    return "";
                case DataType.Byte:
                    return "sbyte.MaxValue";
                case DataType.Double:
                    return "double.MaxValue";
                case DataType.I16:
                    return "short.MaxValue";
                case DataType.I32:
                    return "int.MaxValue";
                case DataType.I64:
                    return "long.MaxValue";
                case DataType.String:
                    return "null";
            }
            return null;
        }
    }
}
