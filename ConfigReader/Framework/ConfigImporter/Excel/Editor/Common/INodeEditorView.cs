using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcelImproter.Framework.ConfigImporter.Excel.Editor
{
    interface INodeEditorView
    {
        INode GetData();
        string CheckData();

    }
}
