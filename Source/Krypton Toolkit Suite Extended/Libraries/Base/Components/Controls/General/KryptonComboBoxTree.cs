using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    [ToolboxBitmap(typeof(KryptonComboBox))]
    public sealed class KryptonComboBoxTree : Control
    {
        #region Delegates
        public delegate void NodeSelectedEventHandler();
        #endregion

        #region Designer Code
        private void InitializeComponent()
        {
            //
            // ComboBoxTree
            //
            Name = "ComboBoxTree";
            _absoluteChildrenSelectableOnly = true;
            Layout += new System.Windows.Forms.LayoutEventHandler(ComboBoxTree_Layout);

        }
        #endregion

        #region Private Fields
        private KryptonPanel pnlBack;
        private KryptonPanel pnlTree;
        private KryptonComboBox combobox;
        private KryptonTreeView tvTreeView;
        private LabelEx lblSizingGrip;
        private KryptonForm frmTreeView;

        private string _branchSeparator;
        private bool _absoluteChildrenSelectableOnly;
        private Point DragOffset;
        #endregion

        #region Public Properties
        [Browsable(true), Description("Gets the TreeView Nodes collection"), Category("TreeView"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Editor(typeof(TreeNodeCollection), typeof(TreeNodeCollection))]
        public TreeNodeCollection Nodes => tvTreeView.Nodes;

        [Browsable(true), Description("Gets or sets the TreeView's Selected Node"), Category("TreeView")]
        public TreeNode SelectedNode
        {
            set
            {
                tvTreeView.SelectedNode = value;

                TreeViewNodeSelect(null, null);
            }

            get => tvTreeView.SelectedNode;
        }

        [Browsable(false)]
        public KryptonComboBox ComboBox
        {
            get => combobox;

            set => combobox = value;
        }

        [Browsable(true), Description("Gets or sets the TreeView's Selected Node"), Category("TreeView")]
        public ImageList Imagelist
        {
            get => tvTreeView.ImageList;

            set => tvTreeView.ImageList = value;
        }

        [Browsable(true), Description("Gets or sets the separator for the selected node's value"), Category("Appearance")]
        public string BranchSeparator
        {
            get => _branchSeparator;

            set
            {
                if (!string.IsNullOrEmpty(value) && value.Length > 0)
                {
                    _branchSeparator = value.Substring(0, 1);
                }
            }
        }
        [Browsable(true), Description("Gets or sets the separator for the selected node's value"), Category("Behavior")]
        public bool AbsoluteChildrenSelectableOnly
        {
            get => _absoluteChildrenSelectableOnly;

            set => _absoluteChildrenSelectableOnly = value;
        }

        public TreeView TreeView { get => tvTreeView; }
        #endregion

        #region Constructor
        public KryptonComboBoxTree()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw, true);

            InitializeComponent();

            // Initializing Controls
            pnlBack = new KryptonPanel();
            pnlBack.BorderStyle = BorderStyle.None;
            pnlBack.Dock = DockStyle.Fill;
            pnlBack.AutoScroll = false;
            //pnlBack.BackColor = txtSelectedValue.BackColor;

            lblSizingGrip = new LabelEx();
            lblSizingGrip.Size = new Size(9, 9);
            lblSizingGrip.Cursor = Cursors.SizeNWSE;
            lblSizingGrip.Text = "";
            lblSizingGrip.MouseMove += new MouseEventHandler(SizingGripMouseMove);
            lblSizingGrip.MouseDown += new MouseEventHandler(SizingGripMouseDown);

            tvTreeView = new KryptonTreeView();
            tvTreeView.BorderStyle = BorderStyle.None;
            tvTreeView.DoubleClick += new EventHandler(TreeViewNodeSelect);
            tvTreeView.Location = new Point(0, 0);
            tvTreeView.LostFocus += new EventHandler(TreeViewLostFocus);
            //tvTreeView.Scrollable = false;

            frmTreeView = new KryptonForm();
            frmTreeView.FormBorderStyle = FormBorderStyle.None;
            frmTreeView.StartPosition = FormStartPosition.Manual;
            frmTreeView.ShowInTaskbar = false;

            pnlTree = new KryptonPanel();
            pnlTree.Dock = DockStyle.Fill;
            pnlTree.BorderStyle = BorderStyle.FixedSingle;
            pnlTree.BackColor = Color.White;

            combobox = new KryptonComboBox();
            combobox.DropDownStyle = ComboBoxStyle.DropDownList;
            combobox.Dock = DockStyle.Fill;
            combobox.ComboBox.Click += new EventHandler(ToggleTreeView);

            // Adding Controls to UserControl
            pnlTree.Controls.Add(lblSizingGrip);
            pnlTree.Controls.Add(tvTreeView);
            frmTreeView.Controls.Add(pnlTree);
            pnlBack.Controls.Add(combobox);
            Controls.Add(pnlBack);
        }
        #endregion

        #region Events
        private void ComboBoxTree_Layout(object sender, LayoutEventArgs e)
        {
            //Height = combobox.Height + 10;
            pnlBack.Size = new Size(Width, Height - 2);

            frmTreeView.Size = new Size(Width, tvTreeView.Height + 30);
            pnlTree.Size = frmTreeView.Size;
            tvTreeView.Width = frmTreeView.Width - lblSizingGrip.Width;
            tvTreeView.Height = frmTreeView.Height - lblSizingGrip.Width;
            RelocateGrip();
        }

        private void txtSelectedValue_Click(object sender, EventArgs e)
        {
            ToggleTreeView(this, new EventArgs());
        }

        private void SizingGripMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int TvWidth, TvHeight;
                TvWidth = Cursor.Position.X - frmTreeView.Location.X;
                TvWidth = TvWidth + DragOffset.X;
                TvHeight = Cursor.Position.Y - frmTreeView.Location.Y;
                TvHeight = TvHeight + DragOffset.Y;

                if (TvWidth < 50)
                    TvWidth = 50;
                if (TvHeight < 50)
                    TvHeight = 50;

                frmTreeView.Size = new System.Drawing.Size(TvWidth, TvHeight);
                pnlTree.Size = frmTreeView.Size;
                tvTreeView.Size = new System.Drawing.Size(frmTreeView.Size.Width - lblSizingGrip.Width, frmTreeView.Size.Height - lblSizingGrip.Width); ;
                RelocateGrip();
            }
        }

        private void SizingGripMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int OffsetX = System.Math.Abs(Cursor.Position.X - frmTreeView.RectangleToScreen(frmTreeView.ClientRectangle).Right);
                int OffsetY = System.Math.Abs(Cursor.Position.Y - frmTreeView.RectangleToScreen(frmTreeView.ClientRectangle).Bottom);

                DragOffset = new Point(OffsetX, OffsetY);
            }
        }

        private void TreeViewLostFocus(object sender, EventArgs e)
        {
            if (!IsDisposed && Created)
            {
                if (!combobox.RectangleToScreen(combobox.ClientRectangle).Contains(Cursor.Position))
                {
                    frmTreeView.Hide();
                }
            }
        }

        private void TreeViewNodeSelect(object sender, EventArgs e)
        {
            if (tvTreeView.SelectedNode != null)
            {
                if (_absoluteChildrenSelectableOnly)
                {
                    if (tvTreeView.SelectedNode.Nodes.Count == 0)
                    {
                        combobox.Items.Clear();
                        combobox.Items.Add(tvTreeView.SelectedNode.FullPath.Replace(@"\", _branchSeparator));
                        combobox.SelectedIndex = 0;
                        ToggleTreeView(sender, null);
                    }
                }
                else
                {
                    combobox.Items.Clear();
                    combobox.Items.Add(tvTreeView.SelectedNode.FullPath.Replace(@"\", _branchSeparator));
                    combobox.SelectedIndex = 0;
                    ToggleTreeView(sender, null);
                }
            }
        }
        #endregion

        #region Methods
        private void RelocateGrip()
        {
            lblSizingGrip.Top = frmTreeView.Height - lblSizingGrip.Height - 1;
            lblSizingGrip.Left = frmTreeView.Width - lblSizingGrip.Width - 1;
        }

        private void ToggleTreeView(object sender, EventArgs e)
        {
            if (!frmTreeView.Visible)
            {
                Rectangle CBRect = RectangleToScreen(ClientRectangle);
                frmTreeView.Location = new System.Drawing.Point(CBRect.X, CBRect.Y + pnlBack.Height);

                frmTreeView.Show();
                frmTreeView.BringToFront();

                RelocateGrip();
                //tbSelectedValue.Text = "";
            }
            else
            {
                frmTreeView.Hide();
            }
        }

        public bool ValidateText()
        {
            string validatorText = Text;
            TreeNodeCollection nodes = tvTreeView.Nodes;

            for (int i = 0; i < validatorText.Split(_branchSeparator.ToCharArray()[0]).Length; i++)
            {
                bool nodeFound = false;
                string NodeToFind = validatorText.Split(_branchSeparator.ToCharArray()[0])[i];
                for (int j = 0; j < nodes.Count; j++)
                {
                    if (nodes[j].Text == NodeToFind)
                    {
                        nodeFound = true;
                        nodes = nodes[j].Nodes;
                        break;
                    }
                }

                if (!nodeFound)
                    return false;
            }

            return true;
        }
        #endregion
    }
}