using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.ComboBox
{
    public delegate void NodeSelectEventHandler();

    /// <summary>
    /// ComboBoxTree control is a treeview that drops down much like a combobox
    /// </summary>
    [System.Drawing.ToolboxBitmapAttribute(typeof(System.Windows.Forms.ComboBox))]
    public sealed class KryptonComboBoxTree : Control
    {
        #region Private Fields
        private KryptonPanel pnlBack;
        private Panel pnlTree;
        private Krypton.Toolkit.KryptonComboBox combobox;
        private KryptonTreeView tvTreeView;
        private LabelEx lblSizingGrip;
        private Form frmTreeView;

        private string _branchSeparator;
        private bool _absoluteChildrenSelectableOnly;
        private System.Drawing.Point DragOffset;
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
        public Toolkit.KryptonComboBox ComboBox { get => combobox; set => combobox = value; }

        [Browsable(true), Description("Gets or sets the TreeView's Selected Node"), Category("TreeView")]
        public ImageList Imagelist { get => tvTreeView.ImageList; set => tvTreeView.ImageList = value; }

        [Browsable(true), Description("Gets or sets the separator for the selected node's value"), Category("Appearance")]
        public string BranchSeparator
        {
            get => _branchSeparator;

            set
            {
                if (!MissingFrameWorkAPIs.IsNullOrWhiteSpace(value) && value.Length > 0)
                {
                    _branchSeparator = value.Substring(0, 1);
                }
            }
        }
        [Browsable(true), Description("Gets or sets the separator for the selected node's value"), Category("Behavior")]
        public bool AbsoluteChildrenSelectableOnly { get => _absoluteChildrenSelectableOnly; set => _absoluteChildrenSelectableOnly = value; }
        #endregion

        public KryptonComboBoxTree()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw, true);

            InitializeComponent();

            // Initializing Controls
            pnlBack = new Krypton.Toolkit.KryptonPanel();
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
            tvTreeView.BorderStyle = PaletteBorderStyle.ControlClient;
            tvTreeView.DoubleClick += new EventHandler(TreeViewNodeSelect);
            tvTreeView.Location = new Point(0, 0);
            tvTreeView.LostFocus += new EventHandler(TreeViewLostFocus);
            //tvTreeView.Scrollable = false;

            frmTreeView = new Form();
            frmTreeView.FormBorderStyle = FormBorderStyle.None;
            frmTreeView.StartPosition = FormStartPosition.Manual;
            frmTreeView.ShowInTaskbar = false;

            pnlTree = new Panel();
            pnlTree.Dock = DockStyle.Fill;
            pnlTree.BorderStyle = BorderStyle.FixedSingle;
            pnlTree.BackColor = Color.White;

            combobox = new Krypton.Toolkit.KryptonComboBox();
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

        public KryptonTreeView TreeView => tvTreeView;

        private void txtSelectedValue_Click(object sender, EventArgs e)
        {
            ToggleTreeView(this, new EventArgs());
        }

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
                frmTreeView.Location = new Point(CBRect.X, CBRect.Y + pnlBack.Height);

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

        #region Events
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

                frmTreeView.Size = new Size(TvWidth, TvHeight);
                pnlTree.Size = frmTreeView.Size;
                tvTreeView.Size = new Size(frmTreeView.Size.Width - lblSizingGrip.Width, frmTreeView.Size.Height - lblSizingGrip.Width); ;
                RelocateGrip();
            }
        }

        private void SizingGripMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int OffsetX = Math.Abs(Cursor.Position.X - frmTreeView.RectangleToScreen(frmTreeView.ClientRectangle).Right);
                int OffsetY = Math.Abs(Cursor.Position.Y - frmTreeView.RectangleToScreen(frmTreeView.ClientRectangle).Bottom);

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

                combobox.Text = tvTreeView.SelectedNode.Text;
            }
        }

        private void InitializeComponent()
        {
            //
            // ComboBoxTree
            //
            Name = "ComboBoxTree";
            _absoluteChildrenSelectableOnly = true;
            Layout += new System.Windows.Forms.LayoutEventHandler(ComboBoxTree_Layout);

        }

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

        #endregion

        #region LabelEx
        private class LabelEx : Label
        {
            /// <summary>
            ///
            /// </summary>
            public LabelEx()
            {
                SetStyle(ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="e"></param>
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                ControlPaint.DrawSizeGrip(e.Graphics, Color.White, 0, 0, Size.Width, Size.Height);
            }
        }
        #endregion

        #region ButtonEx
        private class ButtonEx : KryptonButton
        {
            private ButtonState state;

            /// <summary>
            ///
            /// </summary>
            public ButtonEx()
            {
                SetStyle(ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            }
            /// <summary>
            ///
            /// </summary>
            /// <param name="e"></param>
            protected override void OnMouseDown(MouseEventArgs e)
            {
                state = ButtonState.Flat;
                base.OnMouseDown(e);
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="e"></param>
            protected override void OnMouseUp(MouseEventArgs e)
            {
                state = ButtonState.Normal;
                base.OnMouseUp(e);
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="e"></param>
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);

                System.Windows.Forms.ControlPaint.DrawComboButton(e.Graphics, e.ClipRectangle, state);
            }
        }
        #endregion
    }
}