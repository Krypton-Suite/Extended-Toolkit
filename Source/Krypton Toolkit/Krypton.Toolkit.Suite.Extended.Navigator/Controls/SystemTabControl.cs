#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Navigator
{
    [ToolboxBitmap(typeof(TabControl)), ToolboxItem(false)]
    public class SystemTabControl : TabControl
    {
        private IPalette _palette;
        private PaletteRedirect _paletteRedirect;
        private bool FlagControl = false;

        #region   ... properties ...

        public new TabAppearance Appearance
        {
            get { return base.Appearance; }
            set
            {
                TabAppearance ta = value;
                if (ta != TabAppearance.Normal)
                    ta = TabAppearance.Normal;

                base.Appearance = ta;
            }
        }

        private Color _hotForeColour;
        [Browsable(true), Category("Appearance-Extended")]
        public Color HotForeColour
        {
            get { return _hotForeColour; }
            set { _hotForeColour = value; }
        }

        private Color _globalBackColour;
        [Browsable(true), Category("Appearance-Extended")]
        public Color GlobalBackColour
        {
            get { return _globalBackColour; }
            set { _globalBackColour = value; }
        }

        private Color _backColor;
        [Browsable(true), Category("Appearance-Extended")]
        public override Color BackColor
        {
            get { return _backColor; }
            set { _backColor = value; Invalidate(); }
        }

        private Boolean _useKrypton = true;
        [Browsable(true), Category("Appearance-Extended")]
        public Boolean UseKrypton
        {
            get { return _useKrypton; }
            set { _useKrypton = value; }
        }

        private Boolean _useExtendedLayout = false;
        [Browsable(true), Category("Appearance-Extended")]
        public Boolean UseExtendedLayout
        {
            get { return _useExtendedLayout; }
            set
            {
                Boolean result = value;
                if (result == true)
                {
                    this.SizeMode = TabSizeMode.Fixed;
                    this.Alignment = TabAlignment.Right;
                    this.DrawMode = TabDrawMode.OwnerDrawFixed;
                    this.ItemSize = new Size(25, 150);
                }
                else
                {
                    this.SizeMode = TabSizeMode.Normal;
                    this.Alignment = TabAlignment.Top;
                    this.DrawMode = TabDrawMode.OwnerDrawFixed;
                    this.ItemSize = new Size(108, 21);
                }

                _useExtendedLayout = value;
            }
        }

        #endregion

        #region ... Constructor ...

        public SystemTabControl()
        {

            //Add any initialization after the InitializeComponent() call 
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            // add Palette Handler
            if (_palette != null)
                _palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);

            KryptonManager.GlobalPaletteChanged += new EventHandler(OnGlobalPaletteChanged);

            _palette = KryptonManager.CurrentGlobalPalette;
            _paletteRedirect = new PaletteRedirect(_palette);

            //Kryptonized
            if (_useKrypton)
            {
                _globalBackColour = _palette.ColorTable.ToolStripContentPanelGradientEnd;
                _backColor = _palette.ColorTable.ToolStripGradientMiddle;
                _hotForeColour = _palette.ColorTable.MenuStripText;
                if (_hotForeColour == Color.White) _hotForeColour = Color.DarkGray;
            }

            //Visual styles enabled? 
            try
            {
                VisualStyleRenderer render = new VisualStyleRenderer(VisualStyleElement.Tab.Pane.Normal);
                this.DrawMode = TabDrawMode.OwnerDrawFixed;
                this.SetStyle(ControlStyles.UserPaint, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.DrawMode = TabDrawMode.Normal;
                this.SetStyle(ControlStyles.UserPaint, false);
            }

            //Which Appearance Style 
            if (this.Appearance != TabAppearance.Normal)
            {
                this.DrawMode = TabDrawMode.Normal;
                this.SetStyle(ControlStyles.UserPaint, false);
            }

            // if ExtendedLayout


        }
        #endregion

        #region ... Krypton ...
        //Kripton Palette Events
        private void OnGlobalPaletteChanged(object sender, EventArgs e)
        {
            if (_palette != null)
                _palette.PalettePaint -= new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);

            _palette = KryptonManager.CurrentGlobalPalette;
            _paletteRedirect.Target = _palette;

            if (_palette != null)
            {
                _palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);
                //repaint with new values
                if (_useKrypton)
                {
                    _globalBackColour = _palette.ColorTable.ToolStripContentPanelGradientEnd;
                    _backColor = _palette.ColorTable.ToolStripGradientBegin;
                    _hotForeColour = _palette.ColorTable.MenuStripText;
                    if (_hotForeColour == Color.White) _hotForeColour = Color.DarkGray;
                }
            }

            Invalidate();
        }

        //Kripton Palette Events
        private void OnPalettePaint(object sender, PaletteLayoutEventArgs e)
        {
            Invalidate();
        }
        #endregion

        #region ... Overriden Methods ...
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            //Which Appearance Style 
            //Buttons or Flat Buttons --> NormalDraw
            if (this.Appearance != TabAppearance.Normal)
            {
                this.DrawMode = TabDrawMode.Normal;
                this.SetStyle(ControlStyles.UserPaint, false);
                Invalidate();
            }

            base.OnPaint(e);
            DrawControl(e.Graphics);
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Graphics g = this.CreateGraphics();
            for (int i = 0; i < this.TabCount; i++)
            {
                if (this.GetTabRect(i).Contains(e.X, e.Y))
                {
                    if (this.HotTrack)
                    {
                        //DrawTab(g, this.TabPages[i], i, true);
                        this.TabPages[i].Tag = true;
                    }
                }
                else
                {
                    //DrawTab(g, this.TabPages[i], i, false);
                    this.TabPages[i].Tag = false;
                }
            }
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            for (int i = 0; i < this.TabCount; i++)
            {
                this.TabPages[i].Tag = false;
            }
            Invalidate();
        }

        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);
        }
        protected override bool ProcessMnemonic(char charCode)
        {

            foreach (TabPage p in this.TabPages)
            {
                if (Control.IsMnemonic(charCode, p.Text))
                {
                    this.SelectedTab = p;
                    this.Focus();
                    return true;
                }
            }
            return base.ProcessMnemonic(charCode);

        }

        #endregion

        #region ... Draw Methods ...
        internal void DrawControl(Graphics g)
        {
            if (!Visible)
            {
                return;
            }
            VisualStyleRenderer render = new VisualStyleRenderer(VisualStyleElement.Tab.Pane.Normal);
            Rectangle TabControlArea = this.ClientRectangle;
            Rectangle TabArea = this.DisplayRectangle;


            if (!Utility.IsVista())
            {
                TabArea.Y = TabArea.Y;
                TabArea.Width = TabArea.Width + 2;
                TabArea.Height = TabArea.Height + 2;
                int nDelta = SystemInformation.Border3DSize.Width;
                TabArea.Inflate(nDelta - 1, nDelta - 1);
            }
            else
            {
                TabArea.Y = TabArea.Y;
                TabArea.Width = TabArea.Width + 2;
                TabArea.Height = TabArea.Height + 1;
                int nDelta = SystemInformation.BorderSize.Width;
                TabArea.Inflate(nDelta, nDelta);
            }

            //Align? Increase Height
            if (Alignment != TabAlignment.Top && Alignment != TabAlignment.Bottom)
            {
                TabArea.Height = TabArea.Height + 1;
            }

            //render.DrawBackground
            if (_useKrypton)
            {
                g.FillRectangle(new SolidBrush(_globalBackColour), ClientRectangle);
            }

            //Draw BackGround
            render.DrawBackground(g, TabArea);

            int i = 0;
            while (i < this.TabCount)
            {
                if (_useKrypton)
                {
                    this.TabPages[i].BackColor = _backColor;
                }
                DrawTab(g, this.TabPages[i], i);
                i += 1;
            }

        }
        internal void DrawTab(Graphics g, TabPage tabPage, int nIndex)
        {
            Rectangle recBounds = this.GetTabRect(nIndex);
            RectangleF tabTextArea = (RectangleF)this.GetTabRect(nIndex);
            bool bSelected = (this.SelectedIndex == nIndex);
            bool bHot = false;

            VisualStyleRenderer render = new VisualStyleRenderer(VisualStyleElement.Tab.Pane.Normal);


            if (tabPage.Tag != null)
            {
                bHot = (bool)tabPage.Tag;
            }

            //Align?
            if (Alignment == TabAlignment.Top || Alignment == TabAlignment.Bottom)
            {
                recBounds.Offset(2, 0);
                recBounds.Width = recBounds.Width + 1;
            }
            else
            {
                //right or left
                recBounds.Offset(0, 1);
                recBounds.Height = recBounds.Height + 0;
                tabTextArea.Height = tabTextArea.Height - 2;
                tabTextArea.Offset(-2, 0);
                //and selected
                if (bSelected)
                {
                    if (Alignment == TabAlignment.Left)
                    {
                        recBounds.Width = recBounds.Width + 3;
                        tabTextArea.Width = tabTextArea.Width + 3;
                    }
                    else
                    {
                        recBounds.X = recBounds.X - 3;
                        recBounds.Width = recBounds.Width + 3;
                        tabTextArea.X = tabTextArea.X - 3;
                        tabTextArea.Width = tabTextArea.Width + 3;
                    }
                }

            }


            //Tab Selected
            if (bSelected)
            {
                //highter if selected and no multiline
                if (this.Multiline != true)
                {
                    if (Alignment == TabAlignment.Top || Alignment == TabAlignment.Bottom)
                    {
                        recBounds.Height = recBounds.Height + 2;
                        recBounds.Width = recBounds.Width - 1;
                    }
                }
                else //lower profile
                {
                    if (Alignment == TabAlignment.Top || Alignment == TabAlignment.Bottom)
                    {
                        recBounds.Y = recBounds.Y + 1;
                        recBounds.Height = recBounds.Height + 1;
                        recBounds.Width = recBounds.Width - 1;
                        tabTextArea.Offset(0, 1);
                    }
                }
                render = new VisualStyleRenderer(VisualStyleElement.Tab.TabItem.Pressed);
                render.DrawBackground(g, recBounds);
                render.DrawEdge(g, recBounds, Edges.Diagonal, EdgeStyle.Sunken, EdgeEffects.Flat);
            }
            //Tab HotTrack
            else if (bHot)
            {
                if (bSelected) //hot and selected Multiline
                {
                    //highter if selected and no multiline
                    if (this.Multiline != true)
                    {
                        if (Alignment == TabAlignment.Top || Alignment == TabAlignment.Bottom)
                        {
                            recBounds.Height = recBounds.Height + 2;
                            recBounds.Width = recBounds.Width - 1;
                        }
                    }
                    else//lower if selected and multiline
                    {
                        if (Alignment == TabAlignment.Top || Alignment == TabAlignment.Bottom)
                        {
                            recBounds.Y = recBounds.Y + 1;
                            recBounds.Height = recBounds.Height + 1;
                            recBounds.Width = recBounds.Width - 1;
                            tabTextArea.Offset(0, 1);
                        }
                    }
                }
                //tab Hot and not selected
                else
                {
                    if (Alignment == TabAlignment.Top || Alignment == TabAlignment.Bottom)
                    {
                        //smaller if not selected, text lower
                        recBounds.Y = recBounds.Y + 3;
                        recBounds.Height = recBounds.Height - 2;
                        tabTextArea.Offset(0, 2);
                    }
                }

                render = new VisualStyleRenderer(VisualStyleElement.Tab.TabItem.Hot);
                render.DrawBackground(g, recBounds);
                render.DrawEdge(g, recBounds, Edges.Diagonal, EdgeStyle.Sunken, EdgeEffects.Flat);
            }

            //Tab Normal
            else
            {
                //smaller if not selected, text lower
                if (Alignment == TabAlignment.Top || Alignment == TabAlignment.Bottom)
                {
                    recBounds.Y = recBounds.Y + 3;
                    recBounds.Height = recBounds.Height - 2;
                    tabTextArea.Offset(0, 2);
                }
                render = new VisualStyleRenderer(VisualStyleElement.Tab.TabItem.Normal);
                render.DrawBackground(g, recBounds);
                render.DrawEdge(g, recBounds, Edges.Diagonal, EdgeStyle.Sunken, EdgeEffects.Flat);
            }

            //DrawBottomLine 
            if (Alignment != TabAlignment.Top)
            {
                render.DrawEdge(g, recBounds, Edges.Bottom, EdgeStyle.Sunken, EdgeEffects.Flat);
            }


            //image management
            if ((tabPage.ImageIndex >= 0) && ((ImageList != null)) && ((ImageList.Images[tabPage.ImageIndex] != null)))
            {
                int nLeftMargin = 8;
                int nRightMargin = 1;
                Image img = ImageList.Images[tabPage.ImageIndex];
                Rectangle rimage = new Rectangle(recBounds.X + nLeftMargin, recBounds.Y + 1, img.Width, img.Height);
                float nAdj = (float)(nLeftMargin + img.Width + nRightMargin);
                // adjust rectangles for top, bottom and ExtendedLayout
                if (Alignment == TabAlignment.Top || Alignment == TabAlignment.Bottom || _useExtendedLayout == true)
                {
                    nAdj = (float)(nLeftMargin + img.Width + nRightMargin);

                    rimage.Y += (recBounds.Height - img.Height) / 2;
                    tabTextArea.X += nAdj;
                    tabTextArea.Width -= nAdj;

                    //selected
                    if (bSelected)
                    {
                        //normal
                        if (!_useExtendedLayout)
                        {
                            rimage.Offset(0, -1);
                        }
                        //exted Layout
                        else
                        {
                            rimage.Offset(2, 0);
                        }
                    }
                }
                else
                {
                    //not ExtendedLayout, not rotate if left tab page
                    if (_useExtendedLayout == false)
                    {
                        img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        //rimage.X += (recBounds.Width - img.Width) / 2;
                        rimage.X -= 4;
                        rimage.Y += 3;

                        nAdj = (float)(10 + img.Height);
                        tabTextArea.Y += img.Height;
                        tabTextArea.Height -= img.Height;
                    }

                }

                g.DrawImage(img, rimage);
            }

            //string management
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            if (FlagControl)
            {
                stringFormat.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show;
            }
            else
            {
                stringFormat.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Hide;
            }
            Brush br;
            if (!bHot)
            {
                br = new SolidBrush(tabPage.ForeColor);
            }
            else
            {
                if (_useKrypton)
                {
                    br = new SolidBrush(_hotForeColour);
                }
                else
                {
                    br = new SolidBrush(tabPage.ForeColor);
                }
            }

            //use AntiAlias
            if (Utility.IsVista())
            {
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            }
            else
            {
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            }


            //Vertical Orientation
            if ((this.Alignment == TabAlignment.Left) || (this.Alignment == TabAlignment.Right))
            {
                //not ExtendedLayout
                if (_useExtendedLayout == false)
                {
                    stringFormat.FormatFlags = StringFormatFlags.DirectionVertical;
                }
                else
                //Extended Layout
                {
                    tabTextArea.Offset(1, 2);
                    tabTextArea.Width = tabTextArea.Width - 2;
                    stringFormat.FormatFlags = StringFormatFlags.NoWrap;
                    stringFormat.Trimming = StringTrimming.EllipsisCharacter;
                }
            }
            g.DrawString(tabPage.Text, Font, br, tabTextArea, stringFormat);
            bHot = false;

        }
        #endregion

        #region ... Key Events ...
        private void KryptonTabControl_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Menu)
            {
                FlagControl = true;
            }
            else
            {
                FlagControl = false;
            }
            this.UpdateStyles();
        }
        #endregion
    }
}