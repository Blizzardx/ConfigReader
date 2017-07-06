using Common.Config;
using ExcelImproter.Framework.ConfigImporter.CodeGenerator;
using ExcelImproter.Framework.ConfigImporter.Excel;
using ExcelImproter.Framework.ConfigImporter.Excel.Editor;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExcelImproter
{
    public partial class Form1 : Form
    {
        public Form1(string[] args)
        {           
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            string log = LogQueue.Instance.Dequeue();
            if (log == null)
            {
                return;
            }
            this.richTextBox1.AppendText(log);
            this.richTextBox1.Focus();
            this.richTextBox1.Select(this.richTextBox1.Text.Length, 0);
            this.richTextBox1.ScrollToCaret();
        }

        private void excelEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCollection coll = Application.OpenForms;
            foreach (Form form in coll)
            {
                if (form is ExcelConfigInfoEditor)
                {
                    form.Focus();
                    return;
                }
            }
            ExcelConfigInfoEditor aiForm = new ExcelConfigInfoEditor();
            aiForm.Show();
        }

        private void codeGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void genCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var path = OpenFile();
            if (string.IsNullOrEmpty(path))
            {
                return;
            }
            var content = System.IO.File.ReadAllText(path);
            var config = XmlConfigBase.DeSerialize<ExcelConfigInfo>(content, getAllTypes().ToArray());

            System.IO.FileInfo tmpInfo = new System.IO.FileInfo(path);
            ConfigClassDefineGenerator tool = new ConfigClassDefineGenerator();
            var classFile = tool.GenClassDefine(tmpInfo.Name.Replace('.','_'), config);
            System.IO.File.WriteAllText(path.Replace(".xml", ".cs"), classFile);
        }
        private string OpenFile()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "所有文件(*.*)|*.*";
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
    }
}
