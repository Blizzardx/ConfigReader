namespace ExcelImproter.Framework.ConfigImporter.Excel.Editor.View
{
    partial class GenCodeEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonGen = new System.Windows.Forms.Button();
            this.buttonGenAll = new System.Windows.Forms.Button();
            this.comboBoxCodeTypeList = new System.Windows.Forms.ComboBox();
            this.labelParamType = new System.Windows.Forms.Label();
            this.selectXmlPathButton = new System.Windows.Forms.Button();
            this.XmlPathTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.configPathFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.selectXmlOutputPathButton = new System.Windows.Forms.Button();
            this.OutputPathTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonGen
            // 
            this.buttonGen.Location = new System.Drawing.Point(131, 280);
            this.buttonGen.Name = "buttonGen";
            this.buttonGen.Size = new System.Drawing.Size(102, 36);
            this.buttonGen.TabIndex = 8;
            this.buttonGen.Text = "生成单文件";
            this.buttonGen.UseVisualStyleBackColor = true;
            this.buttonGen.Click += new System.EventHandler(this.buttonGen_Click);
            // 
            // buttonGenAll
            // 
            this.buttonGenAll.Location = new System.Drawing.Point(295, 280);
            this.buttonGenAll.Name = "buttonGenAll";
            this.buttonGenAll.Size = new System.Drawing.Size(102, 36);
            this.buttonGenAll.TabIndex = 7;
            this.buttonGenAll.Text = "全部生成";
            this.buttonGenAll.UseVisualStyleBackColor = true;
            this.buttonGenAll.Click += new System.EventHandler(this.buttonGenAll_Click);
            // 
            // comboBoxCodeTypeList
            // 
            this.comboBoxCodeTypeList.FormattingEnabled = true;
            this.comboBoxCodeTypeList.Location = new System.Drawing.Point(193, 169);
            this.comboBoxCodeTypeList.Name = "comboBoxCodeTypeList";
            this.comboBoxCodeTypeList.Size = new System.Drawing.Size(266, 20);
            this.comboBoxCodeTypeList.TabIndex = 75;
            // 
            // labelParamType
            // 
            this.labelParamType.AutoSize = true;
            this.labelParamType.Location = new System.Drawing.Point(105, 177);
            this.labelParamType.Name = "labelParamType";
            this.labelParamType.Size = new System.Drawing.Size(29, 12);
            this.labelParamType.TabIndex = 74;
            this.labelParamType.Text = "类型";
            // 
            // selectXmlPathButton
            // 
            this.selectXmlPathButton.Location = new System.Drawing.Point(490, 51);
            this.selectXmlPathButton.Name = "selectXmlPathButton";
            this.selectXmlPathButton.Size = new System.Drawing.Size(70, 23);
            this.selectXmlPathButton.TabIndex = 78;
            this.selectXmlPathButton.Text = "选择目录";
            this.selectXmlPathButton.UseVisualStyleBackColor = true;
            this.selectXmlPathButton.Click += new System.EventHandler(this.selectExcelPathButton_Click);
            // 
            // XmlPathTextBox
            // 
            this.XmlPathTextBox.Location = new System.Drawing.Point(131, 55);
            this.XmlPathTextBox.Name = "XmlPathTextBox";
            this.XmlPathTextBox.ReadOnly = true;
            this.XmlPathTextBox.Size = new System.Drawing.Size(353, 21);
            this.XmlPathTextBox.TabIndex = 77;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(9, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 23);
            this.label3.TabIndex = 76;
            this.label3.Text = "Xml文件路径:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // selectXmlOutputPathButton
            // 
            this.selectXmlOutputPathButton.Location = new System.Drawing.Point(490, 99);
            this.selectXmlOutputPathButton.Name = "selectXmlOutputPathButton";
            this.selectXmlOutputPathButton.Size = new System.Drawing.Size(70, 23);
            this.selectXmlOutputPathButton.TabIndex = 81;
            this.selectXmlOutputPathButton.Text = "选择目录";
            this.selectXmlOutputPathButton.UseVisualStyleBackColor = true;
            this.selectXmlOutputPathButton.Click += new System.EventHandler(this.selectXmlOutputPathButton_Click);
            // 
            // OutputPathTextBox
            // 
            this.OutputPathTextBox.Location = new System.Drawing.Point(131, 103);
            this.OutputPathTextBox.Name = "OutputPathTextBox";
            this.OutputPathTextBox.ReadOnly = true;
            this.OutputPathTextBox.Size = new System.Drawing.Size(353, 21);
            this.OutputPathTextBox.TabIndex = 80;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 23);
            this.label1.TabIndex = 79;
            this.label1.Text = "生成文件导出路径:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // GenCodeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 458);
            this.Controls.Add(this.selectXmlOutputPathButton);
            this.Controls.Add(this.OutputPathTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectXmlPathButton);
            this.Controls.Add(this.XmlPathTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxCodeTypeList);
            this.Controls.Add(this.labelParamType);
            this.Controls.Add(this.buttonGen);
            this.Controls.Add(this.buttonGenAll);
            this.Name = "GenCodeEditor";
            this.Text = "GenCodeEditor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGen;
        private System.Windows.Forms.Button buttonGenAll;
        private System.Windows.Forms.ComboBox comboBoxCodeTypeList;
        private System.Windows.Forms.Label labelParamType;
        private System.Windows.Forms.Button selectXmlPathButton;
        private System.Windows.Forms.TextBox XmlPathTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FolderBrowserDialog configPathFolderBrowserDialog;
        private System.Windows.Forms.Button selectXmlOutputPathButton;
        private System.Windows.Forms.TextBox OutputPathTextBox;
        private System.Windows.Forms.Label label1;
    }
}