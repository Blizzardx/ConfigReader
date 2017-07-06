namespace ExcelImproter.Framework.ConfigImporter.Excel.Editor
{
    partial class StructInfoPanel
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
            this.textBoxNodeDesc = new System.Windows.Forms.TextBox();
            this.textBoxNodeName = new System.Windows.Forms.TextBox();
            this.labelNodeId = new System.Windows.Forms.Label();
            this.labelNodeDesc = new System.Windows.Forms.Label();
            this.labelTypeName = new System.Windows.Forms.Label();
            this.textBoxNodeId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxNodeDesc
            // 
            this.textBoxNodeDesc.Location = new System.Drawing.Point(155, 153);
            this.textBoxNodeDesc.Name = "textBoxNodeDesc";
            this.textBoxNodeDesc.Size = new System.Drawing.Size(266, 21);
            this.textBoxNodeDesc.TabIndex = 70;
            // 
            // textBoxNodeName
            // 
            this.textBoxNodeName.Location = new System.Drawing.Point(155, 109);
            this.textBoxNodeName.Name = "textBoxNodeName";
            this.textBoxNodeName.Size = new System.Drawing.Size(266, 21);
            this.textBoxNodeName.TabIndex = 69;
            // 
            // labelNodeId
            // 
            this.labelNodeId.AutoSize = true;
            this.labelNodeId.Location = new System.Drawing.Point(67, 73);
            this.labelNodeId.Name = "labelNodeId";
            this.labelNodeId.Size = new System.Drawing.Size(41, 12);
            this.labelNodeId.TabIndex = 68;
            this.labelNodeId.Text = "节点ID";
            // 
            // labelNodeDesc
            // 
            this.labelNodeDesc.AutoSize = true;
            this.labelNodeDesc.Location = new System.Drawing.Point(67, 162);
            this.labelNodeDesc.Name = "labelNodeDesc";
            this.labelNodeDesc.Size = new System.Drawing.Size(53, 12);
            this.labelNodeDesc.TabIndex = 67;
            this.labelNodeDesc.Text = "节点描述";
            // 
            // labelTypeName
            // 
            this.labelTypeName.AutoSize = true;
            this.labelTypeName.Location = new System.Drawing.Point(67, 120);
            this.labelTypeName.Name = "labelTypeName";
            this.labelTypeName.Size = new System.Drawing.Size(53, 12);
            this.labelTypeName.TabIndex = 66;
            this.labelTypeName.Text = "节点名称";
            // 
            // textBoxNodeId
            // 
            this.textBoxNodeId.Location = new System.Drawing.Point(155, 64);
            this.textBoxNodeId.Name = "textBoxNodeId";
            this.textBoxNodeId.Size = new System.Drawing.Size(266, 21);
            this.textBoxNodeId.TabIndex = 65;
            // 
            // StructInfoPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxNodeDesc);
            this.Controls.Add(this.textBoxNodeName);
            this.Controls.Add(this.labelNodeId);
            this.Controls.Add(this.labelNodeDesc);
            this.Controls.Add(this.labelTypeName);
            this.Controls.Add(this.textBoxNodeId);
            this.Name = "StructInfoPanel";
            this.Size = new System.Drawing.Size(503, 336);
            this.Load += new System.EventHandler(this.StructInfoPanel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNodeDesc;
        private System.Windows.Forms.TextBox textBoxNodeName;
        private System.Windows.Forms.Label labelNodeId;
        private System.Windows.Forms.Label labelNodeDesc;
        private System.Windows.Forms.Label labelTypeName;
        private System.Windows.Forms.TextBox textBoxNodeId;
    }
}
