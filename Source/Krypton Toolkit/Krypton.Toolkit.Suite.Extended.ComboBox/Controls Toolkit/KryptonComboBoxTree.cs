#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

#pragma warning disable CS8622
namespace Krypton.Toolkit.Suite.Extended.ComboBox
{
    public delegate void NodeSelectEventHandler();

    /// <summary>
    /// ComboBoxTree control is a treeview that drops down much like a combobox
    /// </summary>
    [ToolboxBitmap(typeof(System.Windows.Forms.ComboBox))]
    public sealed class KryptonComboBoxTree : Control
    {
        #region Private Fields
        private KryptonPanel _pnlBack;
        private Panel _pnlTree;
        private KryptonComboBox _combobox;
        private KryptonTreeView _tvTreeView;
        private LabelEx _lblSizingGrip;
        private Form _frmTreeView;

        private string _branchSeparator;
        private bool _absoluteChildrenSelectableOnly;
        private Point _dragOffset;
        #endregion

        #region Public Properties
        [Browsable(true), Description("Gets the TreeView Nodes collection"), Category("TreeView"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Editor(typeof(TreeNodeCollection), typeof(TreeNodeCollection))]
        public TreeNodeCollection Nodes => _tvTreeView.Nodes;

        [Browsable(true), Description("Gets or sets the TreeView's Selected Node"), Category("TreeView")]
        public TreeNode SelectedNode
        {
            set
            {
                _tvTreeView.SelectedNode = value;

                TreeViewNodeSelect(null, null);
            }

            get => _tvTreeView.SelectedNode;
        }

        [Browsable(false)]
        public KryptonComboBox ComboBox { get => _combobox; set => _combobox = value; }

        [Browsable(true), Description("Gets or sets the TreeView's Selected Node"), Category("TreeView")]
        public ImageList? Imagelist { get => _tvTreeView.ImageList; set => _tvTreeView.ImageList = value; }

        [Browsable(true), Description("Gets or sets the separator for the selected node's value"), Category("Appearance")]
        public string BranchSeparator
        {
            get => _branchSeparator;

            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.Length > 0)
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
            _pnlBack = new KryptonPanel();
            _pnlBack.BorderStyle = BorderStyle.None;
            _pnlBack.Dock = DockStyle.Fill;
            _pnlBack.AutoScroll = false;
            //pnlBack.BackColor = txtSelectedValue.BackColor;

            _lblSizingGrip = new LabelEx();
            _lblSizingGrip.Size = new Size(9, 9);
            _lblSizingGrip.Cursor = Cursors.SizeNWSE;
            _lblSizingGrip.Text = "";
            _lblSizingGrip.MouseMove += new MouseEventHandler(SizingGripMouseMove);
            _lblSizingGrip.MouseDown += new MouseEventHandler(SizingGripMouseDown);

            _tvTreeView = new KryptonTreeView();
            _tvTreeView.BorderStyle = PaletteBorderStyle.ControlClient;
            _tvTreeView.DoubleClick += new EventHandler(TreeViewNodeSelect);
            _tvTreeView.Location = new Point(0, 0);
            _tvTreeView.LostFocus += new EventHandler(TreeViewLostFocus);
            //tvTreeView.Scrollable = false;

            _frmTreeView = new Form();
            _frmTreeView.FormBorderStyle = FormBorderStyle.None;
            _frmTreeView.StartPosition = FormStartPosition.Manual;
            _frmTreeView.ShowInTaskbar = false;

            _pnlTree = new Panel();
            _pnlTree.Dock = DockStyle.Fill;
            _pnlTree.BorderStyle = BorderStyle.FixedSingle;
            _pnlTree.BackColor = Color.White;

            _combobox = new KryptonComboBox();
            _combobox.DropDownStyle = ComboBoxStyle.DropDownList;
            _combobox.Dock = DockStyle.Fill;
            _combobox.ComboBox!.Click += new EventHandler(ToggleTreeView);

            // Adding Controls to UserControl
            _pnlTree.Controls.Add(_lblSizingGrip);
            _pnlTree.Controls.Add(_tvTreeView);
            _frmTreeView.Controls.Add(_pnlTree);
            _pnlBack.Controls.Add(_combobox);
            Controls.Add(_pnlBack);
        }

        public KryptonTreeView TreeView => _tvTreeView;

        private void txtSelectedValue_Click(object sender, EventArgs e)
        {
            ToggleTreeView(this, new EventArgs());
        }

        private void RelocateGrip()
        {
            _lblSizingGrip.Top = _frmTreeView.Height - _lblSizingGrip.Height - 1;
            _lblSizingGrip.Left = _frmTreeView.Width - _lblSizingGrip.Width - 1;
        }

        private void ToggleTreeView(object? sender, EventArgs? e)
        {
            if (!_frmTreeView.Visible)
            {
                Rectangle cbRect = RectangleToScreen(ClientRectangle);
                _frmTreeView.Location = new Point(cbRect.X, cbRect.Y + _pnlBack.Height);

                _frmTreeView.Show();
                _frmTreeView.BringToFront();

                RelocateGrip();
                //tbSelectedValue.Text = "";
            }
            else
            {
                _frmTreeView.Hide();
            }
        }

        public bool ValidateText()
        {
            string validatorText = Text;
            TreeNodeCollection nodes = _tvTreeView.Nodes;

            for (int i = 0; i < validatorText.Split(_branchSeparator.ToCharArray()[0]).Length; i++)
            {
                bool nodeFound = false;
                string nodeToFind = validatorText.Split(_branchSeparator.ToCharArray()[0])[i];
                for (int j = 0; j < nodes.Count; j++)
                {
                    if (nodes[j].Text == nodeToFind)
                    {
                        nodeFound = true;
                        nodes = nodes[j].Nodes;
                        break;
                    }
                }

                if (!nodeFound)
                {
                    return false;
                }
            }

            return true;
        }

        #region Events
        private void SizingGripMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int tvWidth, tvHeight;
                tvWidth = Cursor.Position.X - _frmTreeView.Location.X;
                tvWidth = tvWidth + _dragOffset.X;
                tvHeight = Cursor.Position.Y - _frmTreeView.Location.Y;
                tvHeight = tvHeight + _dragOffset.Y;

                if (tvWidth < 50)
                {
                    tvWidth = 50;
                }

                if (tvHeight < 50)
                {
                    tvHeight = 50;
                }

                _frmTreeView.Size = new Size(tvWidth, tvHeight);
                _pnlTree.Size = _frmTreeView.Size;
                _tvTreeView.Size = new Size(_frmTreeView.Size.Width - _lblSizingGrip.Width, _frmTreeView.Size.Height - _lblSizingGrip.Width); ;
                RelocateGrip();
            }
        }

        private void SizingGripMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int offsetX = Math.Abs(Cursor.Position.X - _frmTreeView.RectangleToScreen(_frmTreeView.ClientRectangle).Right);
                int offsetY = Math.Abs(Cursor.Position.Y - _frmTreeView.RectangleToScreen(_frmTreeView.ClientRectangle).Bottom);

                _dragOffset = new Point(offsetX, offsetY);
            }
        }

        private void TreeViewLostFocus(object sender, EventArgs e)
        {
            if (!IsDisposed && Created)
            {
                if (!_combobox.RectangleToScreen(_combobox.ClientRectangle).Contains(Cursor.Position))
                {
                    _frmTreeView.Hide();
                }
            }
        }

        private void TreeViewNodeSelect(object? sender, EventArgs? e)
        {
            if (_tvTreeView.SelectedNode != null)
            {
                if (_absoluteChildrenSelectableOnly)
                {
                    if (_tvTreeView.SelectedNode.Nodes.Count == 0)
                    {
                        _combobox.Items.Clear();
                        _combobox.Items.Add(_tvTreeView.SelectedNode.FullPath.Replace(@"\", _branchSeparator));
                        _combobox.SelectedIndex = 0;
                        ToggleTreeView(sender, null);
                    }
                }
                else
                {
                    _combobox.Items.Clear();
                    _combobox.Items.Add(_tvTreeView.SelectedNode.FullPath.Replace(@"\", _branchSeparator));
                    _combobox.SelectedIndex = 0;
                    ToggleTreeView(sender, null);
                }

                _combobox.Text = _tvTreeView.SelectedNode.Text;
            }
        }

        private void InitializeComponent()
        {
            //
            // ComboBoxTree
            //
            Name = "ComboBoxTree";
            _absoluteChildrenSelectableOnly = true;
            Layout += new LayoutEventHandler(ComboBoxTree_Layout);

        }

        private void ComboBoxTree_Layout(object sender, LayoutEventArgs e)
        {
            //Height = combobox.Height + 10;
            _pnlBack.Size = new Size(Width, Height - 2);

            _frmTreeView.Size = new Size(Width, _tvTreeView.Height + 30);
            _pnlTree.Size = _frmTreeView.Size;
            _tvTreeView.Width = _frmTreeView.Width - _lblSizingGrip.Width;
            _tvTreeView.Height = _frmTreeView.Height - _lblSizingGrip.Width;
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
            private ButtonState _state;

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
                _state = ButtonState.Flat;
                base.OnMouseDown(e);
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="e"></param>
            protected override void OnMouseUp(MouseEventArgs e)
            {
                _state = ButtonState.Normal;
                base.OnMouseUp(e);
            }

            /// <summary>
            ///
            /// </summary>
            /// <param name="e"></param>
            protected override void OnPaint(PaintEventArgs? e)
            {
                base.OnPaint(e);

                ControlPaint.DrawComboButton(e?.Graphics!, e!.ClipRectangle, _state);
            }
        }
        #endregion
    }
}