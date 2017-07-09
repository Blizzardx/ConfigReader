using Common.Config;
using ExcelImproter.Framework.ConfigImporter.CodeGenerator.CSharp;
using ExcelImproter.Framework.ConfigImporter.Excel;
using ExcelImproter.Framework.ConfigImporter.Excel.Editor;
using ExcelImproter.Framework.ConfigImporter.Excel.Editor.View;
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
            FormCollection coll = Application.OpenForms;
            foreach (Form form in coll)
            {
                if (form is GenCodeEditor)
                {
                    form.Focus();
                    return;
                }
            }
            GenCodeEditor aiForm = new GenCodeEditor();
            aiForm.Show();
        }
    }
}
