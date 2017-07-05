namespace ExcelImproter.Framework.ConfigImporter.Excel.Editor
{
    partial class ListInfoPanel
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxParamType = new System.Windows.Forms.ComboBox();
            this.labelParamType = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxParamType
            // 
            this.comboBoxParamType.FormattingEnabled = true;
            this.comboBoxParamType.Location = new System.Drawing.Point(156, 62);
            this.comboBoxParamType.Name = "comboBoxParamType";
            this.comboBoxParamType.Size = new System.Drawing.Size(266, 20);
            this.comboBoxParamType.TabIndex = 67;
            // 
            // labelParamType
            // 
            this.labelParamType.AutoSize = true;
            this.labelParamType.Location = new System.Drawing.Point(68, 70);
            this.labelParamType.Name = "labelParamType";
            this.labelParamType.Size = new System.Drawing.Size(53, 12);
            this.labelParamType.TabIndex = 66;
            this.labelParamType.Text = "数组类型";
            // 
            // ListInfoPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBoxParamType);
            this.Controls.Add(this.labelParamType);
            this.Name = "ListInfoPanel";
            this.Size = new System.Drawing.Size(503, 539);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxParamType;
        private System.Windows.Forms.Label labelParamType;
    }
}
