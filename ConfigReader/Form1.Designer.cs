﻿namespace ExcelImproter
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.editorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excelEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.codeGeneratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.genCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox1.Location = new System.Drawing.Point(3, 83);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(963, 514);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editorToolStripMenuItem,
            this.codeGeneratorToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(968, 25);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // editorToolStripMenuItem
            // 
            this.editorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.excelEditorToolStripMenuItem});
            this.editorToolStripMenuItem.Name = "editorToolStripMenuItem";
            this.editorToolStripMenuItem.Size = new System.Drawing.Size(55, 21);
            this.editorToolStripMenuItem.Text = "Editor";
            // 
            // excelEditorToolStripMenuItem
            // 
            this.excelEditorToolStripMenuItem.Name = "excelEditorToolStripMenuItem";
            this.excelEditorToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.excelEditorToolStripMenuItem.Text = "ExcelEditor";
            this.excelEditorToolStripMenuItem.Click += new System.EventHandler(this.excelEditorToolStripMenuItem_Click);
            // 
            // codeGeneratorToolStripMenuItem
            // 
            this.codeGeneratorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.genCodeToolStripMenuItem});
            this.codeGeneratorToolStripMenuItem.Name = "codeGeneratorToolStripMenuItem";
            this.codeGeneratorToolStripMenuItem.Size = new System.Drawing.Size(110, 21);
            this.codeGeneratorToolStripMenuItem.Text = "CodeGenerator";
            this.codeGeneratorToolStripMenuItem.Click += new System.EventHandler(this.codeGeneratorToolStripMenuItem_Click);
            // 
            // genCodeToolStripMenuItem
            // 
            this.genCodeToolStripMenuItem.Name = "genCodeToolStripMenuItem";
            this.genCodeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.genCodeToolStripMenuItem.Text = "GenCode";
            this.genCodeToolStripMenuItem.Click += new System.EventHandler(this.genCodeToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 596);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excelEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem codeGeneratorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem genCodeToolStripMenuItem;
    }
}

