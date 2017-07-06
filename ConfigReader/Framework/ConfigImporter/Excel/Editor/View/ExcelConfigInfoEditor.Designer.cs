namespace ExcelImproter.Framework.ConfigImporter.Excel.Editor
{
    partial class ExcelConfigInfoEditor
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
            this.components = new System.ComponentModel.Container();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.treeView = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加根节点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.展开全部子节点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxNodeType = new System.Windows.Forms.GroupBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDone = new System.Windows.Forms.Button();
            this.groupBoxNodeDetail = new System.Windows.Forms.GroupBox();
            this.comboBoxNodeTypeList = new System.Windows.Forms.ComboBox();
            this.labelParamType = new System.Windows.Forms.Label();
            this.上移ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.下移ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBoxNodeType.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(13, 9);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(102, 36);
            this.buttonLoad.TabIndex = 6;
            this.buttonLoad.Text = "载入";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(198, 9);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(102, 36);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "保存";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // treeView
            // 
            this.treeView.ContextMenuStrip = this.contextMenuStrip1;
            this.treeView.Location = new System.Drawing.Point(7, 67);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(965, 608);
            this.treeView.TabIndex = 4;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddNodeToolStripMenuItem,
            this.添加根节点ToolStripMenuItem,
            this.展开全部子节点ToolStripMenuItem,
            this.DeleteNodeToolStripMenuItem,
            this.上移ToolStripMenuItem,
            this.下移ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 136);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // AddNodeToolStripMenuItem
            // 
            this.AddNodeToolStripMenuItem.Name = "AddNodeToolStripMenuItem";
            this.AddNodeToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.AddNodeToolStripMenuItem.Text = "添加节点";
            this.AddNodeToolStripMenuItem.Click += new System.EventHandler(this.AddNodeToolStripMenuItem_Click);
            // 
            // 添加根节点ToolStripMenuItem
            // 
            this.添加根节点ToolStripMenuItem.Name = "添加根节点ToolStripMenuItem";
            this.添加根节点ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.添加根节点ToolStripMenuItem.Text = "添加根节点";
            this.添加根节点ToolStripMenuItem.Click += new System.EventHandler(this.添加根节点ToolStripMenuItem_Click);
            // 
            // 展开全部子节点ToolStripMenuItem
            // 
            this.展开全部子节点ToolStripMenuItem.Name = "展开全部子节点ToolStripMenuItem";
            this.展开全部子节点ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.展开全部子节点ToolStripMenuItem.Text = "展开全部子节点";
            this.展开全部子节点ToolStripMenuItem.Click += new System.EventHandler(this.展开全部子节点ToolStripMenuItem_Click);
            // 
            // DeleteNodeToolStripMenuItem
            // 
            this.DeleteNodeToolStripMenuItem.Name = "DeleteNodeToolStripMenuItem";
            this.DeleteNodeToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.DeleteNodeToolStripMenuItem.Text = "删除节点";
            this.DeleteNodeToolStripMenuItem.Click += new System.EventHandler(this.DeleteNodeToolStripMenuItem_Click);
            // 
            // groupBoxNodeType
            // 
            this.groupBoxNodeType.Controls.Add(this.buttonCancel);
            this.groupBoxNodeType.Controls.Add(this.buttonAdd);
            this.groupBoxNodeType.Controls.Add(this.buttonDone);
            this.groupBoxNodeType.Controls.Add(this.groupBoxNodeDetail);
            this.groupBoxNodeType.Controls.Add(this.comboBoxNodeTypeList);
            this.groupBoxNodeType.Controls.Add(this.labelParamType);
            this.groupBoxNodeType.Location = new System.Drawing.Point(992, 67);
            this.groupBoxNodeType.Name = "groupBoxNodeType";
            this.groupBoxNodeType.Size = new System.Drawing.Size(579, 606);
            this.groupBoxNodeType.TabIndex = 8;
            this.groupBoxNodeType.TabStop = false;
            this.groupBoxNodeType.Text = "节点类型";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(395, 508);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(107, 36);
            this.buttonCancel.TabIndex = 77;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(106, 507);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(107, 36);
            this.buttonAdd.TabIndex = 76;
            this.buttonAdd.Text = "添加";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDone
            // 
            this.buttonDone.Location = new System.Drawing.Point(248, 508);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(107, 36);
            this.buttonDone.TabIndex = 75;
            this.buttonDone.Text = "完成";
            this.buttonDone.UseVisualStyleBackColor = true;
            this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
            // 
            // groupBoxNodeDetail
            // 
            this.groupBoxNodeDetail.Location = new System.Drawing.Point(13, 62);
            this.groupBoxNodeDetail.Name = "groupBoxNodeDetail";
            this.groupBoxNodeDetail.Size = new System.Drawing.Size(553, 407);
            this.groupBoxNodeDetail.TabIndex = 74;
            this.groupBoxNodeDetail.TabStop = false;
            this.groupBoxNodeDetail.Text = "节点详情";
            // 
            // comboBoxNodeTypeList
            // 
            this.comboBoxNodeTypeList.FormattingEnabled = true;
            this.comboBoxNodeTypeList.Location = new System.Drawing.Point(189, 32);
            this.comboBoxNodeTypeList.Name = "comboBoxNodeTypeList";
            this.comboBoxNodeTypeList.Size = new System.Drawing.Size(266, 20);
            this.comboBoxNodeTypeList.TabIndex = 73;
            // 
            // labelParamType
            // 
            this.labelParamType.AutoSize = true;
            this.labelParamType.Location = new System.Drawing.Point(101, 40);
            this.labelParamType.Name = "labelParamType";
            this.labelParamType.Size = new System.Drawing.Size(53, 12);
            this.labelParamType.TabIndex = 72;
            this.labelParamType.Text = "元素类型";
            // 
            // 上移ToolStripMenuItem
            // 
            this.上移ToolStripMenuItem.Name = "上移ToolStripMenuItem";
            this.上移ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.上移ToolStripMenuItem.Text = "上移";
            this.上移ToolStripMenuItem.Click += new System.EventHandler(this.上移ToolStripMenuItem_Click);
            // 
            // 下移ToolStripMenuItem
            // 
            this.下移ToolStripMenuItem.Name = "下移ToolStripMenuItem";
            this.下移ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.下移ToolStripMenuItem.Text = "下移";
            this.下移ToolStripMenuItem.Click += new System.EventHandler(this.下移ToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(406, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 36);
            this.button1.TabIndex = 9;
            this.button1.Text = "刷新id";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ExcelConfigInfoEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1573, 685);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBoxNodeType);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.treeView);
            this.Name = "ExcelConfigInfoEditor";
            this.Text = "ExcelConfigInfoEditor";
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBoxNodeType.ResumeLayout(false);
            this.groupBoxNodeType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 展开全部子节点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddNodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteNodeToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBoxNodeType;
        private System.Windows.Forms.ComboBox comboBoxNodeTypeList;
        private System.Windows.Forms.Label labelParamType;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDone;
        private System.Windows.Forms.GroupBox groupBoxNodeDetail;
        private System.Windows.Forms.ToolStripMenuItem 添加根节点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 上移ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 下移ToolStripMenuItem;
        private System.Windows.Forms.Button button1;
    }
}