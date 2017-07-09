using Common.Config;
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
        private string m_strCurrentEditFilePath;

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
        private void Save()
        {
            ExcelConfigInfo configInfo = new ExcelConfigInfo();
            configInfo.nodeInfoList = new List<NodeBase>();

            RefreshId();

            var nodes = treeView.Nodes;
            if(nodes == null || nodes.Count == 0)
            {
                return;
            }

            foreach(var node in nodes)
            {
                var nodeInfo = node as TreeViewNodeInfo;
                if(!CheckNodeCorrect(nodeInfo.GetData()))
                {
                    return;
                }
                configInfo.nodeInfoList.Add(nodeInfo.GetData());
            }

            string configContent = null;
            try
            {
                configContent = XmlConfigBase.Serialize(configInfo, getAllTypes().ToArray());
            }
            catch(Exception e)
            {
                LogQueue.Instance.Enqueue(e.Message);
            }
            if(string.IsNullOrEmpty(configContent))
            {
                return;
            }
            var savePath = string.IsNullOrEmpty(m_strCurrentEditFilePath) ? SaveFile() : m_strCurrentEditFilePath;
            if(string.IsNullOrEmpty(savePath))
            {
                return;
            }
            System.IO.File.WriteAllText(savePath, configContent);
            LogQueue.Instance.Enqueue("saved!");
        }
        private string SaveFile()
        {
            SaveFileDialog fileDialog = new SaveFileDialog();

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                return fileDialog.FileName;
            }
            return null;
        }
        private string OpenFile()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "xml文件(*.xml)|*.xml";
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
        private void Load()
        {
            var path = OpenFile();
            if (string.IsNullOrEmpty(path))
            {
                return;
            }
            var content = System.IO.File.ReadAllText(path);
            var config = XmlConfigBase.DeSerialize<ExcelConfigInfo>(content,getAllTypes().ToArray());
            treeView.Nodes.Clear();

            for (int i=0;i< config.nodeInfoList.Count;++i)
            {
                GetNodeViewByNodeInfo(treeView.Nodes, config.nodeInfoList[i]);
            }

            treeView.ExpandAll();

            m_strCurrentEditFilePath = path;

            LogQueue.Instance.Enqueue("loaded!");
        }
        private void GetNodeViewByNodeInfo(TreeNodeCollection rootView, NodeBase nodeBase)
        {
            TreeViewNodeInfo childView = new TreeViewNodeInfo(nodeBase);
            
            if (nodeBase is ConfigStructInfo)
            {
                foreach(var elem in (nodeBase as ConfigStructInfo).nodeInfoList)
                {
                    GetNodeViewByNodeInfo(childView.Nodes, elem);
                }
            }
            if(nodeBase is ConfigNodeListInfo)
            {
                var elem = (nodeBase as ConfigNodeListInfo).nodeInfo;
                GetNodeViewByNodeInfo(childView.Nodes, elem);
            }
            if(nodeBase is ConfigStructListInfo)
            {
                var elem = (nodeBase as ConfigStructListInfo).structInfo;
                GetNodeViewByNodeInfo(childView.Nodes, elem);
            }
            rootView.Add(childView);
        }
        private bool CheckNodeCorrect(NodeBase node)
        {
            if (node is ConfigElementNodeInfo)
            {
                return true;
            }
            if (node is ConfigStructInfo)
            {
                var realNode = node as ConfigStructInfo;
                if(realNode.nodeInfoList == null || realNode.nodeInfoList.Count == 0)
                {
                    MessageBox.Show(this, realNode.name + " 结构体下必须存在子节点", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                return true;
            }
            if (node is ConfigStructListInfo)
            {
                var realNode = node as ConfigStructListInfo;
                if(realNode.structInfo == null)
                {
                    MessageBox.Show(this, "数组-结构体下必须有子节点", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                return CheckNodeCorrect(realNode.structInfo);
            }
            if (node is ConfigNodeListInfo)
            {
                var realNode = node as ConfigNodeListInfo;
                if (realNode.nodeInfo == null)
                {
                    MessageBox.Show(this, "数组-元素下必须有子节点", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                return true;
            }
            return false;
        }
        private bool TryAddNodeToRootNode(NodeBase root, NodeBase child)
        {
            if (root is ConfigElementNodeInfo)
            {
                var res = MessageBox.Show(this, "元素下不能添加子节点", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (root is ConfigStructInfo)
            {
                if (!(child is ConfigElementNodeInfo))
                {
                    var res = MessageBox.Show(this, "结构体下只能添加元素", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                var realRoot = (root as ConfigStructInfo);
                if (realRoot.nodeInfoList == null)
                {
                    realRoot.nodeInfoList = new List<ConfigElementNodeInfo>();
                }
                realRoot.nodeInfoList.Add(child as ConfigElementNodeInfo);
                return true;
            }
            if (root is ConfigStructListInfo)
            {
                if (!(child is ConfigStructInfo))
                {
                    var res = MessageBox.Show(this, "数组-结构体 下只能添加结构体", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                var realRoot = (root as ConfigStructListInfo);
                if(realRoot.structInfo != null)
                {
                    MessageBox.Show(this, "数组-结构体 下已经存在结构体", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                realRoot.structInfo = child as ConfigStructInfo;
                return true;
            }
            if (root is ConfigNodeListInfo)
            {
                if (!(child is ConfigElementNodeInfo))
                {
                    var res = MessageBox.Show(this, "数组-元素 下只能添加元素", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                var realRoot = (root as ConfigNodeListInfo);
                if (realRoot.nodeInfo != null)
                {
                    MessageBox.Show(this, "数组-元素 下已经存在元素", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                realRoot.nodeInfo = child as ConfigElementNodeInfo;
                return true;
            }
            return false;
        }
        private int m_iTmpIndex;
        private void RefreshId()
        {
            m_iTmpIndex = 0;
            var nodes = treeView.Nodes;
            for(int i=0;i<nodes.Count;++i)
            {
                var nodeInf = (nodes[i] as TreeViewNodeInfo).GetData();
                UpdateNodeId(nodeInf);
            }
        }
        private void UpdateNodeId(NodeBase nodeInfo)
        {
            if (nodeInfo is ConfigElementNodeInfo)
            {
                var realInfo = nodeInfo as ConfigElementNodeInfo;
                realInfo.id = m_iTmpIndex++;
            }
            if(nodeInfo is ConfigStructInfo)
            {
                var realInfo = nodeInfo as ConfigStructInfo;
                realInfo.id = m_iTmpIndex;
                for (int i=0;null != realInfo.nodeInfoList && i<realInfo.nodeInfoList.Count;++i)
                {
                    UpdateNodeId(realInfo.nodeInfoList[i]);
                }
            }
            if (nodeInfo is ConfigNodeListInfo)
            {
                var realInfo = nodeInfo as ConfigNodeListInfo;                
                if (null != realInfo.nodeInfo)
                {
                    UpdateNodeId(realInfo.nodeInfo);
                }
            }
            if (nodeInfo is ConfigStructListInfo)
            {
                var realInfo = nodeInfo as ConfigStructListInfo;
                if (null != realInfo.structInfo)
                {
                    UpdateNodeId(realInfo.structInfo);
                }
            }
        }
        #region event
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            try
            {
                Load();
            }
            catch (Exception exception)
            {
                LogQueue.Instance.Enqueue(exception.Message);
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            Save();
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
                if(elem.Text == "上移" || elem.Text == "下移")
                {
                    TreeViewNodeInfo node = treeView.SelectedNode as TreeViewNodeInfo;
                    elem.Enabled = node != null;
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

            RefreshDetailPanel();
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
            RefreshDetailPanel();
            treeView.Enabled = false;
            SetDetailPanelState(true);
        }
        private void DeleteNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode == null)
            {
                return;
            }
            var res = MessageBox.Show(this, "确定要执行操作吗？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (res != DialogResult.OK)
            {
                return;
            }
            TreeViewNodeInfo node = treeView.SelectedNode as TreeViewNodeInfo;
            if (null == node.Parent)
            {
                treeView.Nodes.Remove(node);
                return;
            }
            TreeViewNodeInfo parent = node.Parent as TreeViewNodeInfo;
            parent.Nodes.Remove(node);
            if (parent.GetData() is ConfigStructInfo)
            {
                var data = parent.GetData() as ConfigStructInfo;
                if(!data.nodeInfoList.Remove(node.GetData() as ConfigElementNodeInfo))
                {
                    MessageBox.Show(this, "删除失败，没找到对应节点", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
            }
            if (parent.GetData() is ConfigNodeListInfo)
            {
                var data = parent.GetData() as ConfigNodeListInfo;
                data.nodeInfo = null;
            }
            if (parent.GetData() is ConfigStructListInfo)
            {
                var data = parent.GetData() as ConfigStructListInfo;
                data.structInfo = null;
            }
        }
        private void 展开全部子节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView.ExpandAll();
        }
        private void 上移ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeViewNodeInfo node = treeView.SelectedNode as TreeViewNodeInfo;
            TreeNodeCollection nodes = null;
            NodeBase parentNodeInfo = null;

            if(null == node.Parent)
            {
                nodes = treeView.Nodes;
            }
            else
            {
                nodes = node.Parent.Nodes;
                parentNodeInfo = (node.Parent as TreeViewNodeInfo).GetData();
            }
            for (int i = 1; i < nodes.Count; ++i)
            {
                if (nodes[i] == node)
                {
                    nodes.RemoveAt(i);
                    nodes.Insert(i - 1, node);
                    break;
                }
            }
            if(null != parentNodeInfo)
            {
                if(!(parentNodeInfo is ConfigStructInfo))
                {
                    LogQueue.Instance.Enqueue("parentNodeInfo is not ConfigStructInfo");
                    return;
                }
                var realInfo = parentNodeInfo as ConfigStructInfo;
                for (int i = 1; i < realInfo.nodeInfoList.Count; ++i)
                {
                    if (realInfo.nodeInfoList[i] == node.GetData())
                    {
                        realInfo.nodeInfoList.RemoveAt(i);
                        realInfo.nodeInfoList.Insert(i - 1, node.GetData() as ConfigElementNodeInfo);
                        break;
                    }
                }
            }
        }
        private void 下移ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeViewNodeInfo node = treeView.SelectedNode as TreeViewNodeInfo;
            TreeNodeCollection nodes = null;
            NodeBase parentNodeInfo = null;
            if (null == node.Parent)
            {
                nodes = treeView.Nodes;
            }
            else
            {
                nodes = node.Parent.Nodes;
                parentNodeInfo = (node.Parent as TreeViewNodeInfo).GetData();
            }
            for (int i = 0; i < nodes.Count-1; ++i)
            {
                if (nodes[i] == node)
                {
                    nodes.RemoveAt(i);
                    nodes.Insert(i + 1, node);
                    break;
                }
            }
            if (null != parentNodeInfo)
            {
                if (!(parentNodeInfo is ConfigStructInfo))
                {
                    LogQueue.Instance.Enqueue("parentNodeInfo is not ConfigStructInfo");
                    return;
                }
                var realInfo = parentNodeInfo as ConfigStructInfo;
                for (int i = 0; i < realInfo.nodeInfoList.Count-1; ++i)
                {
                    if (realInfo.nodeInfoList[i] == node.GetData())
                    {
                        realInfo.nodeInfoList.RemoveAt(i);
                        realInfo.nodeInfoList.Insert(i + 1, node.GetData() as ConfigElementNodeInfo);
                        break;
                    }
                }
            }
        }
        private void OnSelectNodeType(object sender, EventArgs e)
        {
            RefreshDetailPanel();
        }
        private void RefreshDetailPanel()
        {
            groupBoxNodeDetail.Controls.Clear();
            NodeBase data = null;
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
                if (!TryAddNodeToRootNode((currentRoot as TreeViewNodeInfo).GetData(), m_CurrentNodeEditor.GetData()))
                {
                    return;
                }
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
        private void button1_Click(object sender, EventArgs e)
        {
            RefreshId();
        }
        #endregion

    }
}
