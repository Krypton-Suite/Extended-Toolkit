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
        public TreeNodeCollection Nodes
        {
            get
            {
                return this.tvTreeView.Nodes;
            }
        }

        [Browsable(true), Description("Gets or sets the TreeView's Selected Node"), Category("TreeView")]
        public TreeNode SelectedNode
        {
            set
            {
                this.tvTreeView.SelectedNode = value;
                TreeViewNodeSelect(null, null);
            }
            get
            {
                return this.tvTreeView.SelectedNode;
            }
        }

        [Browsable(false)]
        public Toolkit.KryptonComboBox ComboBox
        {
            get { return combobox; }
            set { combobox = value; }
        }

        [Browsable(true), Description("Gets or sets the TreeView's Selected Node"), Category("TreeView")]
        public ImageList Imagelist
        {
            get { return this.tvTreeView.ImageList; }
            set { this.tvTreeView.ImageList = value; }
        }

        [Browsable(true), Description("Gets or sets the separator for the selected node's value"), Category("Appearance")]
        public string BranchSeparator
        {
            get { return this._branchSeparator; }
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Length > 0)
                    this._branchSeparator = value.Substring(0, 1);
            }
        }
        [Browsable(true), Description("Gets or sets the separator for the selected node's value"), Category("Behavior")]
        public bool AbsoluteChildrenSelectableOnly
        {
            get { return this._absoluteChildrenSelectableOnly; }
            set { this._absoluteChildrenSelectableOnly = value; }
        }
        #endregion

        public KryptonComboBoxTree()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw, true);

            this.InitializeComponent();

            // Initializing Controls
            this.pnlBack = new Krypton.Toolkit.KryptonPanel();
            this.pnlBack.BorderStyle = BorderStyle.None;
            this.pnlBack.Dock = DockStyle.Fill;
            this.pnlBack.AutoScroll = false;
            //this.pnlBack.BackColor = txtSelectedValue.BackColor;

            this.lblSizingGrip = new LabelEx();
            this.lblSizingGrip.Size = new Size(9, 9);
            this.lblSizingGrip.Cursor = Cursors.SizeNWSE;
            this.lblSizingGrip.Text = "";
            this.lblSizingGrip.MouseMove += new MouseEventHandler(SizingGripMouseMove);
            this.lblSizingGrip.MouseDown += new MouseEventHandler(SizingGripMouseDown);

            this.tvTreeView = new KryptonTreeView();
            this.tvTreeView.BorderStyle = PaletteBorderStyle.ControlClient;
            this.tvTreeView.DoubleClick += new EventHandler(TreeViewNodeSelect);
            this.tvTreeView.Location = new Point(0, 0);
            this.tvTreeView.LostFocus += new EventHandler(TreeViewLostFocus);
            //this.tvTreeView.Scrollable = false;

            this.frmTreeView = new Form();
            this.frmTreeView.FormBorderStyle = FormBorderStyle.None;
            this.frmTreeView.StartPosition = FormStartPosition.Manual;
            this.frmTreeView.ShowInTaskbar = false;

            this.pnlTree = new Panel();
            this.pnlTree.Dock = DockStyle.Fill;
            this.pnlTree.BorderStyle = BorderStyle.FixedSingle;
            this.pnlTree.BackColor = Color.White;

            combobox = new Krypton.Toolkit.KryptonComboBox();
            combobox.DropDownStyle = ComboBoxStyle.DropDownList;
            combobox.Dock = DockStyle.Fill;
            combobox.ComboBox.Click += new EventHandler(ToggleTreeView);

            // Adding Controls to UserControl
            this.pnlTree.Controls.Add(this.lblSizingGrip);
            this.pnlTree.Controls.Add(this.tvTreeView);
            this.frmTreeView.Controls.Add(this.pnlTree);
            this.pnlBack.Controls.Add(combobox);
            this.Controls.Add(this.pnlBack);
        }

        public KryptonTreeView TreeView => tvTreeView;

        private void txtSelectedValue_Click(object sender, EventArgs e)
        {
            ToggleTreeView(this, new EventArgs());
        }

        private void RelocateGrip()
        {
            this.lblSizingGrip.Top = this.frmTreeView.Height - lblSizingGrip.Height - 1;
            this.lblSizingGrip.Left = this.frmTreeView.Width - lblSizingGrip.Width - 1;
        }

        private void ToggleTreeView(object sender, EventArgs e)
        {
            if (!this.frmTreeView.Visible)
            {
                Rectangle CBRect = this.RectangleToScreen(this.ClientRectangle);
                this.frmTreeView.Location = new System.Drawing.Point(CBRect.X, CBRect.Y + this.pnlBack.Height);

                this.frmTreeView.Show();
                this.frmTreeView.BringToFront();

                this.RelocateGrip();
                //this.tbSelectedValue.Text = "";
            }
            else
            {
                this.frmTreeView.Hide();
            }
        }

        public bool ValidateText()
        {
            string validatorText = this.Text;
            TreeNodeCollection nodes = this.tvTreeView.Nodes;

            for (int i = 0; i < validatorText.Split(this._branchSeparator.ToCharArray()[0]).Length; i++)
            {
                bool nodeFound = false;
                string NodeToFind = validatorText.Split(this._branchSeparator.ToCharArray()[0])[i];
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
                TvWidth = Cursor.Position.X - this.frmTreeView.Location.X;
                TvWidth = TvWidth + this.DragOffset.X;
                TvHeight = Cursor.Position.Y - this.frmTreeView.Location.Y;
                TvHeight = TvHeight + this.DragOffset.Y;

                if (TvWidth < 50)
                    TvWidth = 50;
                if (TvHeight < 50)
                    TvHeight = 50;

                this.frmTreeView.Size = new System.Drawing.Size(TvWidth, TvHeight);
                this.pnlTree.Size = this.frmTreeView.Size;
                this.tvTreeView.Size = new System.Drawing.Size(this.frmTreeView.Size.Width - this.lblSizingGrip.Width, this.frmTreeView.Size.Height - this.lblSizingGrip.Width); ;
                RelocateGrip();
            }
        }

        private void SizingGripMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int OffsetX = System.Math.Abs(Cursor.Position.X - this.frmTreeView.RectangleToScreen(this.frmTreeView.ClientRectangle).Right);
                int OffsetY = System.Math.Abs(Cursor.Position.Y - this.frmTreeView.RectangleToScreen(this.frmTreeView.ClientRectangle).Bottom);

                this.DragOffset = new Point(OffsetX, OffsetY);
            }
        }

        private void TreeViewLostFocus(object sender, EventArgs e)
        {
            if (!IsDisposed && Created)
            {
                if (!this.combobox.RectangleToScreen(this.combobox.ClientRectangle).Contains(Cursor.Position))
                {
                    this.frmTreeView.Hide();
                }
            }
        }

        private void TreeViewNodeSelect(object sender, EventArgs e)
        {
            if (tvTreeView.SelectedNode != null)
            {
                if (this._absoluteChildrenSelectableOnly)
                {
                    if (this.tvTreeView.SelectedNode.Nodes.Count == 0)
                    {
                        combobox.Items.Clear();
                        combobox.Items.Add(tvTreeView.SelectedNode.FullPath.Replace(@"\", this._branchSeparator));
                        combobox.SelectedIndex = 0;
                        this.ToggleTreeView(sender, null);
                    }
                }
                else
                {
                    combobox.Items.Clear();
                    combobox.Items.Add(tvTreeView.SelectedNode.FullPath.Replace(@"\", this._branchSeparator));
                    combobox.SelectedIndex = 0;
                    this.ToggleTreeView(sender, null);
                }
            }
        }

        private void InitializeComponent()
        {
            //
            // ComboBoxTree
            //
            this.Name = "ComboBoxTree";
            this._absoluteChildrenSelectableOnly = true;
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.ComboBoxTree_Layout);

        }

        private void ComboBoxTree_Layout(object sender, LayoutEventArgs e)
        {
            //this.Height = this.combobox.Height + 10;
            this.pnlBack.Size = new Size(this.Width, this.Height - 2);

            this.frmTreeView.Size = new Size(this.Width, this.tvTreeView.Height + 30);
            this.pnlTree.Size = this.frmTreeView.Size;
            this.tvTreeView.Width = this.frmTreeView.Width - this.lblSizingGrip.Width;
            this.tvTreeView.Height = this.frmTreeView.Height - this.lblSizingGrip.Width;
            this.RelocateGrip();
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
                this.SetStyle(ControlStyles.UserPaint, true);
                this.SetStyle(ControlStyles.DoubleBuffer, true);
                this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="e"></param>
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                ControlPaint.DrawSizeGrip(e.Graphics, Color.White, 0, 0, this.Size.Width, this.Size.Height);
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