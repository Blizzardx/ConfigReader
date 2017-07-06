using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExcelImproter.Framework.ConfigImporter.Excel.Editor
{
    public partial class ExcelConfigInfoEditor : Form
    {
        public enum PanelState
        {
            Idle,
            Edit,
            Add,
        }
        private INodeEditorView m_CurrentNodeEditor;
        private PanelState m_PanelState;
        private bool m_bIsAddingRoot;

        private ExcelConfigInfo m_Data;
        private string[] m_NodeTypeList = new string[]
        {
            "元素",
            "结构体",
            "数组-元素",
            "数组-结构体",
        };
        public ExcelConfigInfoEditor()
        {
            InitializeComponent();
            treeView.AfterSelect += OnClickTreeItem;
            for (int i = 0; i < m_NodeTypeList.Length; ++i)
            {
                comboBoxNodeTypeList.Items.Add(m_NodeTypeList[i]);
            }
            comboBoxNodeTypeList.SelectedIndexChanged += OnSelectNodeType;
            comboBoxNodeTypeList.SelectedIndex = 0;
            SetDetailPanelState(false);

        }
        private void SetDetailPanelState(bool status)
        {
            groupBoxNodeType.Enabled = status;
        }
        private void EditNode(TreeViewNodeInfo data)
        {
            buttonAdd.Enabled = false;
            buttonDone.Enabled = true;
            comboBoxNodeTypeList.SelectedItem = data.GetDisplayTypeName();
            comboBoxNodeTypeList.Enabled = false;

            RefreshDetailPanel();
        }
        #region event
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            m_PanelState = PanelState.Idle;
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {

        }
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            // hide menu
            foreach (ToolStripMenuItem elem in contextMenuStrip1.Items)
            {
                if (elem.Text == "删除节点")
                {
                    elem.Enabled = treeView.SelectedNode != null;
                }
                if (elem.Text == "展开全部子节点")
                {
                    elem.Enabled = treeView.Nodes.Count > 0;
                }
                if (elem.Text == "添加节点")
                {
                    if (treeView.SelectedNode != null)
                    {
                        TreeViewNodeInfo node = treeView.SelectedNode as TreeViewNodeInfo;
                        if (!node.CheckCanAddChildNode())
                        {
                            elem.Enabled = false;
                        }
                        else
                        {
                            elem.Enabled = true;
                        }
                    }
                    else
                    {
                        elem.Enabled = false;
                    }
                }
            }
        }
        private void AddNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(m_PanelState != PanelState.Idle)
            {
                MessageBox.Show(this, "控件正在编辑或者添加", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            buttonAdd.Enabled = true;
            buttonDone.Enabled = false;
            comboBoxNodeTypeList.Enabled = true;

            m_PanelState = PanelState.Add;
            m_bIsAddingRoot = false;

            treeView.Enabled = false;
            SetDetailPanelState(true);
        }
        private void 添加根节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_PanelState != PanelState.Idle)
            {
                MessageBox.Show(this, "控件正在编辑或者添加", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            comboBoxNodeTypeList.Enabled = true;
            buttonAdd.Enabled = true;
            buttonDone.Enabled = false;
            treeView.SelectedNode = null;
            m_bIsAddingRoot = true;
            m_PanelState = PanelState.Add;

            treeView.Enabled = false;
            SetDetailPanelState(true);
        }
        private void DeleteNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void 展开全部子节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void OnSelectNodeType(object sender, EventArgs e)
        {
            RefreshDetailPanel();
        }
        private void RefreshDetailPanel()
        {
            groupBoxNodeDetail.Controls.Clear();
            INode data = null;
            if (m_PanelState != PanelState.Add && null != treeView.SelectedNode)
            {
                data = (treeView.SelectedNode as TreeViewNodeInfo).GetData();
            }

            switch (comboBoxNodeTypeList.SelectedItem as string)
            {
                case "元素":
                    m_CurrentNodeEditor = new NodeInfoPanel(data as ConfigElementNodeInfo);
                    groupBoxNodeDetail.Controls.Add(m_CurrentNodeEditor as Control);
                    break;
                case "结构体":
                    m_CurrentNodeEditor = new StructInfoPanel(data as ConfigStructInfo);
                    groupBoxNodeDetail.Controls.Add(m_CurrentNodeEditor as Control);
                    break;
                case "数组-元素":
                    m_CurrentNodeEditor = new ListInfoPanel_Node(data as ConfigNodeListInfo);
                    groupBoxNodeDetail.Controls.Add(m_CurrentNodeEditor as Control);
                    break;
                case "数组-结构体":
                    m_CurrentNodeEditor = new ListInfoPanel_Struct(data as ConfigStructListInfo);
                    groupBoxNodeDetail.Controls.Add(m_CurrentNodeEditor as Control);
                    break;
            }
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var currentRoot = treeView.SelectedNode;
            string errorInfo = m_CurrentNodeEditor.CheckData();

            if (!string.IsNullOrEmpty(errorInfo))
            {
                var res = MessageBox.Show(this, errorInfo, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (null == currentRoot || m_bIsAddingRoot)
            {
                // add to root node
                treeView.Nodes.Add(new TreeViewNodeInfo(m_CurrentNodeEditor.GetData()));
            }
            else
            {
                currentRoot.Nodes.Add(new TreeViewNodeInfo(m_CurrentNodeEditor.GetData()));
            }
            m_PanelState = PanelState.Idle;
            treeView.Enabled = true;
            m_bIsAddingRoot = false;
            SetDetailPanelState(false);
        }
        private void buttonDone_Click(object sender, EventArgs e)
        {
            TreeViewNodeInfo currentRoot = treeView.SelectedNode as TreeViewNodeInfo;
            string errorInfo = m_CurrentNodeEditor.CheckData();

            if (!string.IsNullOrEmpty(errorInfo))
            {
                var res = MessageBox.Show(this, errorInfo, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (null != currentRoot)
            {
                // update node data
                currentRoot.SetData(m_CurrentNodeEditor.GetData());
            }
            m_PanelState = PanelState.Idle;
            treeView.Enabled = true;
            SetDetailPanelState(false);
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            treeView.Enabled = true;
            m_PanelState = PanelState.Idle;
            SetDetailPanelState(false);
        }
        private void OnClickTreeItem(object sender, TreeViewEventArgs e)
        {
            if (m_PanelState == PanelState.Add)
            {
                MessageBox.Show(this, "正在添加节点", "错误", MessageBoxButtons.OK);
                return;
            }
            TreeViewNodeInfo nodeInfo = treeView.SelectedNode as TreeViewNodeInfo;

            if (null == nodeInfo)
            {
                return;
            }
            
            SetDetailPanelState(true);
            EditNode(nodeInfo);
        }
        #endregion

    }
}
