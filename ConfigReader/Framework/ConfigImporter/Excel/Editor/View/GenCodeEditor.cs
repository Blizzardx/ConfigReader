using Common.Config;
using ExcelImproter.Framework.ConfigImporter.CodeGenerator.CSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExcelImproter.Framework.ConfigImporter.Excel.Editor.View
{
    public partial class GenCodeEditor : Form
    {
        private const string m_strConfigPath = "Config/SystemConfig.xml";

        public GenCodeEditor()
        {
            InitializeComponent();
            LoadSystemConfig();

            XmlPathTextBox.Text = SystemConst.config.XmlRootPath;
            OutputPathTextBox.Text = SystemConst.config.ParserOutputPath;
        }

        private void selectExcelPathButton_Click(object sender, EventArgs e)
        {
            configPathFolderBrowserDialog.SelectedPath = Environment.CurrentDirectory;
            configPathFolderBrowserDialog.Description = "选择Xml所存在的路径";
            DialogResult result = configPathFolderBrowserDialog.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                XmlPathTextBox.Text = configPathFolderBrowserDialog.SelectedPath;
                SystemConst.config.XmlRootPath = configPathFolderBrowserDialog.SelectedPath;
                SaveSystemConfig();
            }
        }
        private void selectXmlOutputPathButton_Click(object sender, EventArgs e)
        {
            configPathFolderBrowserDialog.SelectedPath = Environment.CurrentDirectory;
            configPathFolderBrowserDialog.Description = "选择Xml所存在的路径";
            DialogResult result = configPathFolderBrowserDialog.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                OutputPathTextBox.Text = configPathFolderBrowserDialog.SelectedPath;
                SystemConst.config.ParserOutputPath = configPathFolderBrowserDialog.SelectedPath;
                SaveSystemConfig();
            }
        }
        private void buttonGen_Click(object sender, EventArgs e)
        {
            var path = OpenFile();
            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            GenElement(path);
        }
        private void buttonGenAll_Click(object sender, EventArgs e)
        {
            DirectoryInfo info = new DirectoryInfo(SystemConst.config.XmlRootPath);
            var allFile = info.GetFiles("*.xml");

            for(int i=0;i<allFile.Length;++i)
            {
                GenElement(allFile[i].FullName);
            }
        }
        private void genCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        private void GenElement(string xmlFullPath)
        {
            var content = System.IO.File.ReadAllText(xmlFullPath);
            var config = XmlConfigBase.DeSerialize<ExcelConfigInfo>(content, getAllTypes().ToArray());

            System.IO.FileInfo tmpInfo = new System.IO.FileInfo(xmlFullPath);

            string configName = configName = tmpInfo.Name.Substring(0, tmpInfo.Name.Length - tmpInfo.Extension.Length);
            string outputDirectory = string.Empty;
            if (string.IsNullOrEmpty(SystemConst.config.ParserOutputPath))
            {
                outputDirectory = tmpInfo.Directory.ToString();
            }
            else
            {
                outputDirectory = SystemConst.config.ParserOutputPath ;
            }

            ConfigClassDefineGenerator tool = new ConfigClassDefineGenerator();
            tool.GenClassDefine(configName, config, outputDirectory + "/");

            ConfigParserGenerator parserTool = new ConfigParserGenerator();
            parserTool.GenParserClass(configName, config, outputDirectory + "/");

            LogQueue.Instance.Enqueue("Generate Done " + configName);  
        }
        private string OpenFile()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "所有文件(*.xml)|*.xml";
            fileDialog.InitialDirectory = SystemConst.config.XmlRootPath;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                return fileDialog.FileName;
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
        private void LoadSystemConfig()
        {
            try
            {
                var content = File.ReadAllText(m_strConfigPath);
                SystemConst.config = XmlConfigBase.DeSerialize< PathConfig>(content);
            }
            catch (Exception e)
            {
                SystemConst.config = new PathConfig();
            }
        }
        private void SaveSystemConfig()
        {
           var content = XmlConfigBase.Serialize(SystemConst.config);
           File.WriteAllText(m_strConfigPath,content);
        }
    }
}
