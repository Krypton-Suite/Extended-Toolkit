#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Krypton.Toolkit.Suite.Extended.Tool.Box
{
    [Serializable]
    public class ToolBoxTab : ToolBoxItem
    {
        #region Private Attributes

        private Rectangle _itemArea;                  // The rectangle where toolbox items are drawn
        private Delegate[] _delegates;                 // Event registration delegates
        private ToolBoxItemCollection _toolItems = null; // Array of toolbox items.

        private int _hotItemIndex = -1;   // The item under mouse, set in mouse move event.
        private int _selItemIndex = -1;   // Selected Item's index
        private int _oldSelItemIndex = -1;   // Old Selected item index.
        private int _itemSpacing = 0;    // This tab's item spacing.(if left zero, parent's item spacing will be used)

        private int _newItemIndex = 0;    // New item index which got added recently.
        private int _visibleTopIndex = -1;   // Loop bounds (see UpdateItemLoopIndexes)
        private int _visibleBottomIndex = -1;

        private Color _itemBgColour = Color.Empty;
        private Color _itemBorderColour = Color.Empty;
        private Color _itemNormColour = Color.Empty;
        private Color _itemSelColour = Color.Empty;
        private Color _itemHoverColour = Color.Empty;

        private ToolBoxViewMode _viewMode = ToolBoxViewMode.LIST;
        private bool _onlyOneItemPerRow = false;

        [NonSerialized]
        private Control _control = null;

        #endregion //Private Attributes

        #region Krypton Variables
        //Palette State
        private KryptonManager _manager = new KryptonManager();

        private PaletteBackInheritRedirect _paletteBack;

        private PaletteBorderInheritRedirect _paletteBorder;

        private PaletteContentInheritRedirect _paletteContent;

        private IPalette _palette;

        private PaletteRedirect _paletteRedirect;
        #endregion

        #region Properties

        [Category("ToolBoxTab")]
        public ToolBoxViewMode View
        {
            get { return _viewMode; }
            set
            {
                if (value != _viewMode)
                {
                    if (null != _parent && this == _parent.SelectedTab)
                    {
                        InvalidateEx(true);
                    }

                    _viewMode = value;

                    if (null != _parent)
                    {
                        UpdateItemRects(true, true, true, true);
                    }

                    if (null != _parent && this == _parent.SelectedTab)
                    {
                        if (-1 != _selItemIndex)
                        {
                            EnsureItemVisible(_selItemIndex);
                        }

                        UpdateScrollButtons();
                    }

                    if (null != _parent && this == _parent.SelectedTab)
                    {
                        _parent.Invalidate(_parent.UpScroll.Rectangle);
                        _parent.Invalidate(_parent.DownScroll.Rectangle);

                        InvalidateEx(true);
                    }
                }
            }
        }

        /*
        * UnComment this property if you are using XmlSerializer
        * [Category("ToolBoxTab"), Browsable(false)]
        * public ToolBoxItemCollection Items
        * {
        *     get{return _toolItems;}
        *     set
        *     {
        *         if(null != value && value != _toolItems)
        *         {
        *             _toolItems = value;
        *             UpdateItemRects(true);
        *         }
        *     }
        * }
        */

        [Category("ToolBoxTab")]
        public Color ItemBackgroundColour
        {
            get { return _itemBgColour; }
            set
            {
                if (value != _itemBgColour)
                {
                    _itemBgColour = value;

                    if (null != _parent)
                    {
                        _parent.Invalidate(_itemArea);
                    }
                }
            }
        }

        [Category("ToolBoxTab")]
        public Color ItemNormalColour
        {
            get { return _itemNormColour; }
            set
            {
                if (value != _itemNormColour)
                {
                    _itemNormColour = value;

                    if (null != _parent)
                    {
                        _parent.Invalidate(_itemArea);
                    }
                }
            }
        }

        [Category("ToolBoxTab")]
        public Color ItemBorderColour
        {
            get { return _itemBorderColour; }
            set
            {
                if (value != _itemBorderColour)
                {
                    _itemBorderColour = value;

                    if (null != _parent)
                    {
                        _parent.Invalidate(_itemArea);
                    }
                }
            }
        }

        [Category("ToolBoxTab")]
        public Color ItemSelectedColour
        {
            get { return _itemSelColour; }
            set
            {
                if (value != _itemSelColour)
                {
                    _itemSelColour = value;
                    if (null != _parent)
                    {
                        _parent.Invalidate(_itemArea);
                    }
                }
            }
        }

        [Category("ToolBoxTab")]
        public Color ItemHoverColour
        {
            get { return _itemHoverColour; }
            set
            {
                if (value != _itemHoverColour)
                {
                    _itemHoverColour = value;
                    if (null != _parent)
                    {
                        _parent.Invalidate(_itemArea);
                    }
                }
            }
        }

        [Category("ToolBoxTab"), Browsable(false), XmlIgnore]
        public ToolBoxItem this[int index]
        {
            get
            {
                ToolBoxItem item = null;

                try
                {
                    item = _toolItems[index];
                }
                catch
                {
                    item = null;
                }
                return item;
            }
        }

        [Category("ToolBoxTab"), Browsable(false), XmlIgnore]
        public ToolBoxItem this[string caption]
        {
            get
            {
                ToolBoxItem item = null;
                int iLoop = 0;

                try
                {
                    for (iLoop = 0; iLoop < _toolItems.Count; iLoop++)
                    {
                        if (_toolItems[iLoop].Caption.Equals(caption))
                        {
                            item = _toolItems[iLoop];
                            iLoop = _toolItems.Count + 1;
                        }
                    }
                }
                catch
                {
                }

                return item;
            }
        }

        [Category("ToolBoxTab"), Browsable(false), XmlIgnore]
        public int ItemCount
        {
            get
            {
                int count = 0;
                if (null != _toolItems)
                {
                    count = _toolItems.Count;
                }
                return count;
            }
        }

        [Category("ToolBoxTab"), Browsable(false), XmlIgnore]
        public Rectangle ItemArea
        {
            get { return _itemArea; }
            set
            {
                _itemArea = value;

                if (null != _control)
                {
                    UpdateControlRect(true);
                }
            }
        }

        [Category("ToolBoxTab")]
        public int ItemSpacing
        {
            get { return _itemSpacing; }
            set
            {
                if (value != _itemSpacing)
                {
                    _itemSpacing = value;

                    if (null != _parent && !_parent.IsLoading)
                    {
                        UpdateItemRects(true, true, true);
                    }
                }
            }
        }

        [Category("ToolBoxTab"), Browsable(false)]
        protected int ItemSpacingEx
        {
            get
            {
                int spacing = 0;

                spacing = _itemSpacing;

                if (0 >= _itemSpacing)
                {
                    spacing = _parent.ItemSpacing;
                }

                /*
                ** Large Icons needs atleast 3px spacing to look good.
                */
                if (_viewMode == ToolBoxViewMode.LARGEICONS)
                {
                    spacing = Math.Max(3, spacing);
                }

                return spacing;
            }
        }


        [Category("General")]
        public override bool Enabled
        {
            get { return _enabled; }
            set
            {
                if (value != _enabled)
                {
                    _enabled = value;
                    if (_enabled)
                    {
                        RegisterEvents(false);
                    }
                    else
                    {
                        UnRegisterEvents(false);
                    }
                    if (null != _parent)
                    {
                        _parent.Invalidate(_rectangle);
                        _parent.Invalidate(_itemArea);
                    }
                }
            }
        }

        [Category("General"), XmlIgnore]
        public override bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                if (value != _selected)
                {
                    _selected = value;

                    if (null != _parent && _parent.SelectedTab != this)
                    {
                        _parent.OnTabSelectionChanged(this, null);
                    }

                    Invalidate();

                }
            }
        }

        [Category("ToolBoxTab"), XmlIgnore]
        public ToolBoxItem SelectedItem
        {
            get { return this[_selItemIndex]; }
            set
            {
                if (null != _toolItems)
                {
                    SelectedItemIndex = _toolItems.IndexOf(value);
                }
            }
        }

        [Category("ToolBoxTab")]
        public int SelectedItemIndex
        {
            get { return _selItemIndex; }
            set
            {
                if (null != _toolItems && value != _selItemIndex && -1 != value && value < _toolItems.Count)
                {
                    _oldSelItemIndex = _selItemIndex;

                    if (-1 != _selItemIndex)
                    {
                        _toolItems[_selItemIndex].Selected = false;
                    }

                    _selItemIndex = value;

                    _toolItems[_selItemIndex].Selected = true;
                    _parent.Invalidate(_itemArea);
                }
            }
        }

        [Category("ToolBoxTab")]
        public bool ShowOnlyOneItemPerRow
        {
            get { return _onlyOneItemPerRow; }
            set
            {
                if (value != _onlyOneItemPerRow)
                {
                    _onlyOneItemPerRow = value;
                    if (null != _parent && !_parent.IsLoading)
                    {
                        UpdateItemRects(true, true, true);
                    }
                }
            }
        }

        [Category("ToolBoxTab")]
        public Control Control
        {
            get { return _control; }
            set
            {
                Control oldCtrl;

                if (value != _control)
                {
                    oldCtrl = _control;
                    _control = value;

                    if (null != _control)
                    {
                        if (DockStyle.None != _control.Dock)
                        {
                            _control.Dock = DockStyle.None;
                        }

                        _control.TabStop = true;
                    }

                    if (null != _parent && _selected)
                    {
                        if (null != _control)
                        {
                            _parent.Controls.Add(_control);
                        }
                        else
                        {
                            if (null != oldCtrl)
                            {
                                _parent.Controls.Remove(oldCtrl);
                            }
                        }
                    }

                    if (null != _control)
                    {
                        _toolItems = null;
                    }

                    if (null != _parent && !_parent.IsLoading)
                    {
                        UpdateItemRects(true, true, true);
                    }
                }
            }
        }

        public override bool CanMoveUp
        {
            get
            {
                return null != _parent ? _parent.CanMoveTabUp(this) : false;
            }
        }

        public override bool CanMoveDown
        {
            get
            {
                return null != _parent ? _parent.CanMoveTabDown(this) : false;
            }
        }



        #endregion //Properties

        #region Construction

        public ToolBoxTab()
        {
            Initialize();
        }

        public ToolBoxTab(string caption, int smallImageIndex) : base(caption, smallImageIndex)
        {
            Initialize();
        }

        #endregion //Construction

        #region Event Registration
        public bool RegisterEvents()
        {
            return RegisterEvents(true);
        }

        public bool UnRegisterEvents()
        {
            return UnRegisterEvents(true);
        }

        private bool RegisterEvents(bool registerPaint)
        {
            bool bOK = true;

            // Register the events with parent control.

            try
            {
                _parent.MouseDown += (MouseEventHandler)_delegates[0];
                _parent.MouseUp += (MouseEventHandler)_delegates[1];
                _parent.MouseMove += (MouseEventHandler)_delegates[2];
                _parent.MouseLeave += (EventHandler)_delegates[3];

                if (registerPaint)
                {
                    _parent.Paint += (PaintEventHandler)_delegates[4];
                }
            }
            catch
            {
                bOK = false;
            }
            return bOK;
        }

        private bool UnRegisterEvents(bool unRegisterPaint)
        {
            bool bOK = true;

            // Unregister the events from parent control.
            try
            {
                _parent.MouseDown -= (MouseEventHandler)_delegates[0];
                _parent.MouseUp -= (MouseEventHandler)_delegates[1];
                _parent.MouseMove -= (MouseEventHandler)_delegates[2];
                _parent.MouseLeave -= (EventHandler)_delegates[3];

                if (unRegisterPaint)
                {
                    _parent.Paint -= (PaintEventHandler)_delegates[4];
                }

            }
            catch
            {
                bOK = false;
            }
            return bOK;
        }

        #endregion //Event Registration

        #region Mouse Event Handlers

        private void On_MouseDown(object sender, MouseEventArgs e)
        {
            Point mousePt = Point.Empty;

            // Added by Neal Stublen
            mousePt.X = e.X;
            mousePt.Y = e.Y;

            if (HitTest(e.X, e.Y))
            {
                // Mouse down occured in the tab, if left button
                // was pressed lock the mouse move until mouse button
                // is released. Invalidate the rect to draw the tab
                // in depressed state.
                if (MouseButtons.Left == e.Button)
                {
                    _mouseDown = true;
                    this.MouseDownLocation = mousePt;
                    //_parent.LockMouseMove();
                    Invalidate();
                }

                // parent might have delegates registered for itemMousedown event.
                // this will make parent invoke them.
                _parent.OnTabMouseDown(this, e);

            }
            else if (!_mouseDown && null != _toolItems)
            {
                if (-1 == _hotItemIndex)
                {
                    _hotItemIndex = HitTestItem(e.X, e.Y);
                }

                if (-1 != _hotItemIndex)
                {
                    // There is a hotItem under mouse.

                    //if(MouseButtons.Left == e.Button) // Handling both buttons.
                    {
                        // If mouse button was pressed, the selected item is going
                        // to be changed. 
                        // SelectedItem goes as OldSelectedItem and the new Item will be
                        // the SelectedItem.
                        _oldSelItemIndex = _selItemIndex;

                        if (-1 != _oldSelItemIndex && _toolItems[_oldSelItemIndex].Selected)
                        {
                            // Update mouse flags for old selected item and
                            // mark it for redraw.
                            _toolItems[_oldSelItemIndex].MouseDown = false;
                            _toolItems[_oldSelItemIndex].Selected = false;
                            _toolItems[_oldSelItemIndex].Invalidate();
                        }

                        _selItemIndex = _hotItemIndex;
                        if (!_toolItems[_selItemIndex].MouseDown)
                        {
                            // Update flags for the new selected item
                            _toolItems[_selItemIndex].MouseDown = true;
                            _toolItems[_selItemIndex].Selected = true;

                            // Added by Neal Stublen
                            _toolItems[_selItemIndex].MouseDownLocation = mousePt;

                            //EnsureItemVisible(_selItemIndex);
                        }
                        // Mark the new selected item for redraw.
                        _toolItems[_selItemIndex].Invalidate();

                        //force the parent to redraw the invalidated rects.
                        _parent.Update();
                    }

                    // Allow parent to call its registered delegates for itemMouseDownEvent.
                    _parent.OnItemMouseDown(_toolItems[_selItemIndex], this, e);
                }
                else if (_itemArea.Contains(e.X, e.Y))
                {
                    _parent.OnTabMouseDown(this, e);
                }
            }
        }

        private void On_MouseUp(object sender, MouseEventArgs e)
        {
            bool bHit = HitTest(e.X, e.Y);

            if (_mouseDown || bHit)
            {
                // Mouse down occured inside the tab.
                if (_mouseDown)
                {
                    _mouseDown = false;

                    if (MouseButtons.Left == e.Button && bHit)
                    {
                        // Selection changed event.
                        _parent.OnTabSelectionChanged(this, null);
                    }
                    // Unlock the mousemove.
                    //_parent.UnLockMouseMove();

                    //Mark for redraw.
                    Invalidate();
                }

                if (bHit)
                {
                    // TabMouseUp event.
                    _parent.OnTabMouseUp(this, e);
                }
            }
            else if (Selected && -1 != _selItemIndex)
            {
                // Mouse up for item
                if (_toolItems[_selItemIndex].MouseDown)
                {
                    _toolItems[_selItemIndex].MouseDown = false;
                    // Make item visible in the itemArea
                    EnsureItemVisible(_selItemIndex);

                    if (_oldSelItemIndex != _selItemIndex)
                    {
                        // Item selection change
                        _parent.OnItemSelectionChanged(_toolItems[_selItemIndex], this);
                    }
                }
                _oldSelItemIndex = _selItemIndex;

                if (-1 != _hotItemIndex)
                {
                    // Item mouse up event
                    _parent.OnItemMouseUp(_toolItems[_hotItemIndex], this, e);
                }
                else if (_itemArea.Contains(e.X, e.Y))
                {
                    _parent.OnTabMouseUp(this, e);
                }
            }
        }

        public void CancelHotItemHover()
        {
            try
            {
                if (-1 != _hotItemIndex)
                {
                    _toolItems[_hotItemIndex].CancelHover();
                    _hotItemIndex = -1;
                }
            }
            catch
            {
                _hotItemIndex = -1;
            }
        }

        private void CheckMouseMoveForItems(MouseEventArgs e)
        {
            bool bFound = false;
            int index = -1;
            ToolBoxItem item = null;

            if (_itemArea.Contains(e.X, e.Y))
            {
                // Mouse coords inside the itemArea, check if
                // any item lies in the mouse coords.

                index = HitTestItem(e.X, e.Y);
                bFound = (-1 != index);

                if (bFound)
                {
                    // If an item was found, swap the hotitem
                    // with this new item.
                    if (_hotItemIndex != index)
                    {
                        CancelHotItemHover();
                        _hotItemIndex = index;
                        item = _toolItems[_hotItemIndex];
                        item.MouseHover = true;
                        item.Invalidate();
                        _parent.UpdateToolTip(item);
                    }
                }
                else
                {
                    CancelHotItemHover();
                    _parent.UpdateToolTip("");
                }

                //System.Diagnostics.Debug.WriteLine("ItemArea HitTest : Found " + index.ToString());
            }
            else
            {
                CancelHotItemHover();
                if (HitTest(e.X, e.Y))
                {
                    _parent.UpdateToolTip(this);
                }
            }

        }

        private bool DragSelectedItem(MouseEventArgs e)
        {
            bool bDragged = false;
            ToolBoxItem item = null;
            DragDropEffects effect = DragDropEffects.None;

            if (MouseButtons.Left == e.Button && _parent.Focused && -1 != _selItemIndex)
            {
                item = _toolItems[_selItemIndex];
            }

            // Now , it is not checked if object to drag drop is null or not...

            if (null != item && item.Enabled && item.MouseDown && item.CanStartDrag(e.X, e.Y) /*&& null != item.Object*/)
            {
                item.IsDragging = true;
                effect = _parent.DoDragDropItem(item, DragDropEffects.All);

                item.MouseDown = false;
                item.IsDragging = false;
                EnsureItemVisible(_selItemIndex);


                if (_oldSelItemIndex != _selItemIndex)
                {
                    // Item selection change
                    _parent.OnItemSelectionChanged(_toolItems[_selItemIndex], this);
                }

                bDragged = true;
            }

            return bDragged;
        }

        private void On_MouseMove(object sender, MouseEventArgs e)
        {
            bool oldMouseHover = false;

            oldMouseHover = _mouseHover;

            if (HitTest(e.X, e.Y))
            {
                _mouseHover = true;

                _parent.UpdateToolTip(this);
                CancelHotItemHover();

                if (_mouseDown)
                {
                    if (_movable && _enabled && CanStartDrag(e.X, e.Y))
                    {
                        _parent.DoDragDropItem(this, DragDropEffects.All);
                        _mouseDown = false;
                        Invalidate();
                    }
                }
                else if (SystemColors.ControlText != _parent.TabHoverTextColour)
                {
                    if (oldMouseHover != _mouseHover)
                    {
                        Invalidate();
                    }
                }
            }
            else
            {
                if (Selected)
                {
                    // Drag drop?
                    if (!DragSelectedItem(e))
                    {
                        CheckMouseMoveForItems(e);
                    }
                }

                if (_mouseHover)
                {
                    _mouseHover = false;

                    if (SystemColors.ControlText != _parent.TabHoverTextColour)
                    {
                        if (oldMouseHover != _mouseHover)
                        {
                            Invalidate();
                        }
                    }
                }
            }
        }

        private void On_MouseLeave(object sender, EventArgs e)
        {
            bool oldMouseHover = false;

            oldMouseHover = _mouseHover;
            _mouseHover = false;

            CancelHotItemHover();

            if (SystemColors.ControlText != _parent.TabHoverTextColour)
            {
                if (oldMouseHover != _mouseHover)
                {
                    Invalidate();
                }
            }
        }

        #endregion //Mouse Event Handlers

        #region Keyboard Handlers

        public bool HandleKeyDown(KeyEventArgs e)
        {
            bool handled = false;

            if (Keys.Enter == e.KeyCode || Keys.Space == e.KeyCode)
            {
                HandleAmbientKey(false);
                handled = true;
            }
            else
            {
                if (ToolBoxViewMode.LIST == _viewMode)
                {
                    handled = HandleListViewKeyDown(e);
                }
                else
                {
                    handled = HandleIconViewKeyDown(e);
                }
            }

            return handled;
        }

        public bool HandleKeyUp(KeyEventArgs e)
        {
            bool handled = false;

            if (Keys.Enter == e.KeyCode || Keys.Space == e.KeyCode)
            {
                HandleAmbientKey(true);
                handled = true;
            }

            return handled;
        }

        #endregion //Keyboard Handlers

        #region Paint Handlers

        private void DoPainting(PaintEventArgs e)
        {
            int offset = 0;
            Graphics g = e.Graphics;
            Rectangle r = e.ClipRectangle;
            Rectangle rImage = Rectangle.Empty;
            StringFormat strFormat = new StringFormat();
            ImageList imgList = null;
            Brush[] txBrushes = null;
            Brush txBrush = null;

            strFormat.LineAlignment = StringAlignment.Center;
            strFormat.Trimming = StringTrimming.EllipsisWord;
            strFormat.FormatFlags = StringFormatFlags.NoWrap;

            if (_rectangle.IntersectsWith(r))
            {
                r = _rectangle;

                // Draw border
                //ControlPaint.DrawBorder3D(g,r,_mouseDown?Border3DStyle.SunkenOuter:Border3DStyle.RaisedInner);

                KryptonToolBox.DrawBorders(g, r, _mouseDown);

                if (_mouseDown)
                {
                    r.Offset(1, 1);
                }


                txBrushes = new Brush[3];
                imgList = _parent.SmallImageList;

                // Draw image
                if (null != imgList && -1 != SmallImageIndex && SmallImageIndex < imgList.Images.Count)
                {

                    r.X += 2;
                    r.Width -= 2;
                    offset = (r.Height - imgList.ImageSize.Height) / 2;

                    rImage = r;
                    rImage.Y += offset;

                    rImage.Width = imgList.ImageSize.Width;
                    rImage.Height = imgList.ImageSize.Height;

                    if (_enabled && _parent.Enabled)
                    {
                        //g.DrawImage(img,rImage,0,0,img.Width,img.Height,GraphicsUnit.Pixel);
                        _parent.SmallImageList.Draw(g, r.X, r.Y + offset, SmallImageIndex);
                    }
                    else
                    {
                        g.DrawImage(imgList.Images[SmallImageIndex], rImage, 0, 0, rImage.Width, rImage.Height, GraphicsUnit.Pixel, _parent.DisabledImageAttribs);
                        //ControlPaint.DrawImageDisabled(g,_parent.ImageList.Images[ImageIndex],r.X+1,r.Y+1,_parent.BackColor);
                    }
                    r.X += _parent.SmallImageList.ImageSize.Width + 1;
                    r.Width -= _parent.SmallImageList.ImageSize.Width + 1;
                }

                // Prepare caption text color
                if (!_parent.Enabled || !_enabled)
                {
                    txBrush = SystemBrushes.InactiveCaption;
                }
                else
                {
                    txBrush = SystemBrushes.ControlText;

                    //System.Diagnostics.Debug.WriteLine(Environment.TickCount + " Drawing tab MouseHover " + _mouseHover + " Selected " + _selected);

                    if (_mouseHover)
                    {
                        if (SystemColors.ControlText != _parent.TabHoverTextColour && null == txBrushes[1])
                        {
                            txBrushes[1] = new SolidBrush(_parent.TabHoverTextColour);
                        }
                        txBrush = null != txBrushes[1] ? txBrushes[1] : txBrush;
                    }
                    else if (_selected)
                    {
                        if (SystemColors.ControlText != _parent.TabSelectedTextColour && null == txBrushes[0])
                        {
                            txBrushes[0] = new SolidBrush(_parent.TabSelectedTextColour);
                        }
                        txBrush = null != txBrushes[0] ? txBrushes[0] : txBrush;
                    }
                    else
                    {
                        if (SystemColors.ControlText != _parent.TabNormalTextColour && null == txBrushes[2])
                        {
                            txBrushes[2] = new SolidBrush(_parent.TabNormalTextColour);
                        }
                        txBrush = null != txBrushes[2] ? txBrushes[2] : txBrush;
                    }
                }


                r.X++; r.Width--;

                // Draw caption
                g.DrawString(_caption, _parent.Font, txBrush, r, strFormat);

                if (!_captionChecked)
                {
                    CheckCaption(g, _parent.Font, strFormat, r);
                }

                // Dispose brushes.
                if (null != txBrushes[0]) txBrushes[0].Dispose();
                if (null != txBrushes[1]) txBrushes[1].Dispose();
                if (null != txBrushes[2]) txBrushes[2].Dispose();

            }

            strFormat.FormatFlags = (StringFormatFlags)0;

            if (ToolBoxViewMode.LIST != this._viewMode)
            {
                strFormat.Alignment = StringAlignment.Center;
            }
            else
            {
                strFormat.FormatFlags = StringFormatFlags.NoWrap;
            }


            if (!_itemArea.IsEmpty)
            {
                /*
                ** Set Clipping region.
                */
                r = _itemArea;
                //r.Height -= 1;
                g.SetClip(r);

                try
                {
                    if (Color.Empty != _itemBgColour && _itemBgColour != _parent.BackColor)
                    {
                        txBrush = new SolidBrush(_itemBgColour);
                        g.FillRectangle(txBrush, _itemArea);

                        txBrush.Dispose();
                        txBrush = null;
                    }

                    if (0 <= _visibleTopIndex && 0 <= _visibleBottomIndex && _visibleBottomIndex < _toolItems.Count)
                    {
                        PaintItems(g, e.ClipRectangle, strFormat);
                    }
                }
                finally
                {
                    g.ResetClip();
                }
            }
        }

        private void DrawImage(Graphics g, ImageList imgList, int index, Rectangle rImage, bool bEnabled, bool bPartial)
        {
            if (0 < rImage.Height)
            {
                if (bPartial)
                {
                    if (bEnabled)
                    {
                        g.DrawImage(
                            imgList.Images[index],
                            rImage, 0, 0,
                            rImage.Width,
                            rImage.Height,
                            GraphicsUnit.Pixel);
                    }
                    else
                    {
                        g.DrawImage(
                            imgList.Images[index],
                            rImage, 0, 0,
                            rImage.Width,
                            rImage.Height,
                            GraphicsUnit.Pixel, _parent.DisabledImageAttribs);
                    }

                }
                else
                {
                    if (bEnabled)
                    {
                        imgList.Draw(g, rImage.X, rImage.Y, index);
                    }
                    else
                    {
                        g.DrawImage(imgList.Images[index],
                            rImage, 0, 0,
                            rImage.Width,
                            imgList.ImageSize.Height,
                            GraphicsUnit.Pixel,
                            _parent.DisabledImageAttribs);
                    }
                }
            }
        }

        private void PaintItems(Graphics g, Rectangle clipRect, StringFormat strFormat)
        {
            int iLoop = 0;
            int offset = 0;
            bool drawText = true;
            bool drewImage = false;
            ToolBoxItem item = null;
            Rectangle rect = Rectangle.Empty;
            Rectangle rImage = Rectangle.Empty;
            Rectangle rImageEx = Rectangle.Empty;
            Brush[] bgBrushes = null;
            Brush[] txBrushes = null;
            Brush txBrush = null;
            ImageList imgList = null;
            int imageIndex = -1;

            if (!(0 >= _itemArea.Height) && null != _toolItems)
            {
                bgBrushes = new Brush[3];
                txBrushes = new Brush[3];

                switch (_viewMode)
                {
                    case ToolBoxViewMode.LARGEICONS:
                        imgList = _parent.LargeImageList;
                        break;
                    case ToolBoxViewMode.SMALLICONS:
                    case ToolBoxViewMode.LIST:
                    default:
                        imgList = _parent.SmallImageList;
                        break;
                }

                if (null != imgList)
                {
                    rImage.Size = imgList.ImageSize;
                }

                for (iLoop = _visibleTopIndex; iLoop <= _visibleBottomIndex; iLoop++)
                {
                    item = _toolItems[iLoop];
                    rect = item.Rectangle;

                    if (ToolBoxViewMode.LIST == _viewMode)
                    {
                        rect.X += _itemArea.X;
                    }
                    else if (rect.X < _itemArea.X)
                    {
                        rect.X = _itemArea.X + 2;
                    }

                    rect.Y += _itemArea.Y;

                    //System.Diagnostics.Debug.WriteLine("Checking Painting item " + iLoop);

                    if (rect.Bottom <= _itemArea.Top)
                    {
                        // In this case, no need to call DrawPartialItem, cos
                        // no items will be partially visible at the top at any instance.
                        // Scrolling will place the items to the top by moving each item
                        // by itemHeight in one step.
                        continue;
                    }

                    if (!rect.IntersectsWith(clipRect))
                    {
                        //System.Diagnostics.Debug.WriteLine("ItemRect not in ClipRect " + iLoop + " @ " + System.Environment.TickCount );
                        continue;
                    }

                    //System.Diagnostics.Debug.WriteLine("Painting item " + iLoop);

                    // Draw background.
                    // Thanks to Neal Stublen for the suggestions to make the
                    // items paint "more" like the VS.NET ToolBox control.

                    if (item.MouseHover && !item.MouseDown)
                    {
                        if (null == bgBrushes[1])
                        {
                            bgBrushes[1] = new SolidBrush(_itemHoverColour.IsEmpty ? _parent.ItemHoverColour : _itemHoverColour);
                        }
                        g.FillRectangle(bgBrushes[1], rect);
                    }
                    else if (item.Selected)
                    {
                        if (null == bgBrushes[2])
                        {
                            bgBrushes[2] = new SolidBrush(_itemSelColour.IsEmpty ? _parent.ItemSelectedColour : _itemSelColour);
                        }
                        g.FillRectangle(bgBrushes[2], rect);
                    }
                    else
                    {
                        if (null == bgBrushes[0])
                        {
                            bgBrushes[0] = new SolidBrush(_itemNormColour.IsEmpty ? _parent.ItemNormalColour : _itemNormColour);
                        }
                        g.FillRectangle(bgBrushes[0], rect);
                    }

                    // Draw border
                    if ((item.MouseDown || item.Selected))
                    {
                        KryptonToolBox.DrawBorders(g, rect, true, _itemBorderColour.IsEmpty ? _parent.ItemBorderColour : _itemBorderColour);
                    }
                    else if (item.MouseHover)
                    {
                        KryptonToolBox.DrawBorders(g, rect, false, _itemBorderColour.IsEmpty ? _parent.ItemBorderColour : _itemBorderColour);
                    }

                    if (item.MouseDown)
                    {
                        rect.Offset(1, 1);
                    }

                    switch (_viewMode)
                    {
                        case ToolBoxViewMode.LARGEICONS:
                            imageIndex = item.LargeImageIndex;
                            break;
                        case ToolBoxViewMode.SMALLICONS:
                        case ToolBoxViewMode.LIST:
                        default:
                            imageIndex = item.SmallImageIndex;
                            break;
                    }

                    // Draw image
                    if (null != imgList && -1 != imageIndex && imageIndex < imgList.Images.Count)
                    {
                        rect.X += 2;
                        rect.Width -= 2;

                        if (_viewMode == ToolBoxViewMode.LARGEICONS)
                        {
                            offset = 2;
                        }
                        else
                        {
                            offset = (rect.Height - imgList.ImageSize.Height) / 2;
                        }

                        rImageEx.X = rect.X;
                        rImageEx.Y = rect.Y + offset;
                        rImageEx.Width = rImage.Width;
                        rImageEx.Height = rImage.Height;

                        if (_viewMode != ToolBoxViewMode.LIST)
                        {
                            offset = (rect.Width - imgList.ImageSize.Width) / 2;
                            rImageEx.X += offset;
                        }

                        if (rImageEx.Bottom > _itemArea.Bottom)
                        {
                            rImageEx.Height = (_itemArea.Bottom - rImageEx.Top);
                            DrawImage(g, imgList, imageIndex, rImageEx, Enabled && item.Enabled && _parent.Enabled, true);
                        }
                        else
                        {
                            DrawImage(g, imgList, imageIndex, rImageEx, Enabled && item.Enabled && _parent.Enabled, false);
                        }

                        rect.X += rImageEx.Width + 1;
                        rect.Width -= rImageEx.Width + 1;

                        drewImage = true;
                    }
                    else
                    {
                        drewImage = false;
                    }

                    rect.X++;
                    rect.Width--;

                    // Draw caption

                    drawText = true;

                    if (_viewMode != ToolBoxViewMode.LIST)
                    {
                        // rect.X = item.X;
                        rect = item.Rectangle;
                        rect.Y += _itemArea.Y;

                        if (ToolBoxViewMode.LARGEICONS == _viewMode)
                        {
                            if (drewImage)
                            {
                                rect.Y += (rImage.Height + 1);
                                rect.Height = (item.Height - rImage.Height) - 4;
                            }
                            else
                            {
                                rect.Inflate(-2, -2);
                            }
                        }
                        else if (ToolBoxViewMode.SMALLICONS == _viewMode)
                        {
                            if (drewImage)
                            {
                                drawText = false;
                            }
                            else
                            {
                                rect.Inflate(-2, -2);
                            }
                        }

                        rect.X++;
                        rect.Y++;

                        if (item.MouseDown)
                        {
                            rect.Offset(1, 1);
                        }

                    }

                    if (drawText)
                    {
                        drawText = !rect.IsEmpty;
                    }

                    if (drawText)
                    {
                        if (!Enabled || !item.Enabled || !item.Parent.Enabled)
                        {
                            txBrush = SystemBrushes.InactiveCaption;
                        }
                        else
                        {
                            txBrush = SystemBrushes.ControlText;

                            if (item.MouseHover)
                            {
                                if (SystemColors.ControlText != _parent.ItemHoverTextColour && null == txBrushes[1])
                                {
                                    txBrushes[1] = new SolidBrush(_parent.ItemHoverTextColour);
                                }
                                txBrush = null != txBrushes[1] ? txBrushes[1] : txBrush;
                            }
                            else if (item.Selected)
                            {
                                if (SystemColors.ControlText != _parent.ItemSelectedTextColour && null == txBrushes[0])
                                {
                                    txBrushes[0] = new SolidBrush(_parent.ItemSelectedTextColour);
                                }
                                txBrush = null != txBrushes[0] ? txBrushes[0] : txBrush;
                            }
                            else
                            {
                                if (SystemColors.ControlText != _parent.ItemNormalTextColour && null == txBrushes[2])
                                {
                                    txBrushes[2] = new SolidBrush(_parent.ItemNormalTextColour);
                                }
                                txBrush = null != txBrushes[2] ? txBrushes[2] : txBrush;
                            }
                        }

                        if (!item.CaptionChecked)
                        {
                            item.CheckCaption(g, _parent.Font, strFormat, rect);
                        }

                        g.DrawString(item.Caption, _parent.Font, txBrush, rect, strFormat);
                    }
                    else
                    {
                        if (ToolBoxViewMode.SMALLICONS == _viewMode && !item.CaptionChecked)
                        {
                            item.CheckCaption(g, _parent.Font, strFormat, Rectangle.Empty);
                        }
                    }

                    if (_viewMode == ToolBoxViewMode.LIST && rect.Bottom >= _itemArea.Bottom)
                    {
                        // Exit loop.
                        iLoop = _toolItems.Count + 1;
                    }
                }

                // Dispose brushes..
                if (null != bgBrushes[0]) bgBrushes[0].Dispose();
                if (null != bgBrushes[1]) bgBrushes[1].Dispose();
                if (null != bgBrushes[2]) bgBrushes[2].Dispose();

                if (null != txBrushes[0]) txBrushes[0].Dispose();
                if (null != txBrushes[1]) txBrushes[1].Dispose();
                if (null != txBrushes[2]) txBrushes[2].Dispose();

            }
        }

        private void On_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                DoPainting(e);
            }
            catch (Exception ex)
            {
                ex = ex;
            }
        }

        #endregion //Paint Handlers

        #region Public Methods

        public override string ToString()
        {
            return "(ToolBoxTab)";
        }

        public void InvalidateEx(bool invalidateItems)
        {
            InvalidateEx(true, invalidateItems);
        }

        public bool ItemVisible(int index)
        {
            bool bVisible = false;

            try
            {
                bVisible = ItemVisible(_toolItems[index]);
            }
            catch
            {
                bVisible = false;
            }

            return bVisible;
        }

        public bool ItemVisible(ToolBoxItem item)
        {
            bool bVisible = false;
            Rectangle rcTemp;

            try
            {
                rcTemp = item.Rectangle;
                rcTemp.X = _itemArea.X;
                rcTemp.Y += _itemArea.Y;
                bVisible = _itemArea.Contains(rcTemp) && rcTemp.Bottom < _itemArea.Bottom - 1 && rcTemp.Top > _itemArea.Top;
            }
            catch
            {
                bVisible = false;
            }

            return bVisible;
        }

        public bool Contains(ToolBoxItem item)
        {
            bool bContains = false;
            if (null != _toolItems)
            {
                bContains = _toolItems.Contains(item);
            }
            return bContains;
        }

        public int IndexOfItem(ToolBoxItem item)
        {
            int index = -1;

            if (null != _toolItems)
            {
                index = _toolItems.IndexOf(item);
            }
            return index;
        }

        public bool DeleteItem(ToolBoxItem item)
        {
            bool bDeleted = false;

            try
            {
                bDeleted = DeleteItem(_toolItems.IndexOf(item));
            }
            catch
            {
            }
            return bDeleted;
        }

        public bool DeleteItem(int index)
        {
            bool bDeleted = false;
            bool bOK = true;
            Rectangle rcItem = Rectangle.Empty;
            Rectangle rcTemp = Rectangle.Empty;

            try
            {
                // Is the item being edited?
                if (_parent.EditingItem != _toolItems[index])
                {
                    // End the editing before continuing
                    bOK = _parent.EndRenameItem();
                }
                if (bOK)
                {
                    // Delete only if deletable.
                    bOK = _toolItems[index].Deletable;
                }
                if (bOK)
                {
                    rcItem = _toolItems[index].Rectangle;

                    //Item was selected?
                    if (index == _selItemIndex)
                    {
                        // clear old-selected and selected item index
                        _selItemIndex = -1;
                        _oldSelItemIndex = -1;
                    }

                    _toolItems.RemoveAt(index);

                    UpdateItemRects(true, true, false);

                    if (0 >= _toolItems.Count)
                    {
                        _oldSelItemIndex = -1;
                        _selItemIndex = -1;
                        _visibleTopIndex = -1;
                        _visibleBottomIndex = -1;
                    }
                    else
                    {

                        index = (index >= _toolItems.Count) ? index - 1 : index;
                        index = (-1 > index) ? (index + 1) : index;

                        if (0 <= index && index < _toolItems.Count)
                        {
                            _oldSelItemIndex = -1;
                            _selItemIndex = index;
                            _toolItems[_selItemIndex].Selected = true;

                            _parent.OnItemSelectionChanged(_toolItems[_selItemIndex], this);
                        }

                        EnsureItemVisible(index);
                    }

                    _parent.Invalidate(_itemArea);

                    bDeleted = true;
                }
            }
            catch
            {
            }
            return bDeleted;
        }


        public void DeleteAllItems()
        {
            try
            {
                _toolItems.Clear();
                UpdateItemRects(true, true, false);
                _parent.Invalidate(_itemArea);
            }
            catch
            {
            }
        }

        public bool CanMoveItemUp(ToolBoxItem item)
        {
            bool bCanMoveUp = false;
            int index1 = -1;
            ToolBoxItem prev = null;

            try
            {
                index1 = _toolItems.IndexOf(item);
                prev = _toolItems[index1 - 1];
                bCanMoveUp = item.Movable && prev.Movable;
            }
            catch
            {
                bCanMoveUp = false;
            }

            return bCanMoveUp;
        }

        public bool CanMoveItemDown(ToolBoxItem item)
        {
            bool bCanMoveDn = false;
            int index1 = -1;
            ToolBoxItem next = null;

            try
            {
                index1 = _toolItems.IndexOf(item);
                next = _toolItems[index1 + 1];
                bCanMoveDn = item.Movable && next.Movable;
            }
            catch
            {
                bCanMoveDn = false;
            }

            return bCanMoveDn;
        }

        public bool MoveItemUp(ToolBoxItem item)
        {
            bool bMoved = false;
            int index1 = -1;

            try
            {
                index1 = _toolItems.IndexOf(item);
                bMoved = SwapItems(index1, index1 - 1);
            }
            catch
            {
                bMoved = false;
            }

            return bMoved;
        }

        public bool MoveItemDown(ToolBoxItem item)
        {
            bool bMoved = false;
            int index1 = -1;

            try
            {
                index1 = _toolItems.IndexOf(item);
                bMoved = SwapItems(index1, index1 + 1);
            }
            catch
            {
                bMoved = false;
            }

            return bMoved;
        }

        public bool SwapItems(ToolBoxItem item1, ToolBoxItem item2)
        {
            bool bSwaped = false;

            int index1 = -1;
            int index2 = -1;

            try
            {
                index1 = _toolItems.IndexOf(item1);
                index2 = _toolItems.IndexOf(item2);
                bSwaped = SwapItems(index1, index2);
            }
            catch
            {
                bSwaped = false;
            }

            return bSwaped;
        }

        public int HitTestItem(int x, int y)
        {
            int iLoop = 0;
            int index = -1;
            ToolBoxItem item = null;

            if (_itemArea.Contains(x, y) &&
                null != _toolItems &&
                0 < _toolItems.Count &&
                _visibleTopIndex <= _toolItems.Count &&
                _visibleBottomIndex <= _toolItems.Count)
            {
                for (iLoop = _visibleTopIndex; iLoop <= _visibleBottomIndex; iLoop++)
                {
                    item = _toolItems[iLoop];

                    if (item.HitTest(x, y))
                    {
                        index = iLoop;
                        iLoop = _visibleBottomIndex + 1;
                    }
                }
            }

            return index;
        }

        public int AddItemRaw(ToolBoxItem item)
        {
            int index = -1;

            if (null == _control)
            {
                if (null == _toolItems)
                {
                    _toolItems = new ToolBoxItemCollection();
                }

                index = _toolItems.Add(item);
            }

            return index;
        }

        public int AddItem(string caption)
        {
            return AddItem(caption, -1, true, null);
        }

        public int AddItem(string caption, int smallImageIndex)
        {
            return AddItem(caption, smallImageIndex, true, null);
        }

        public int AddItem(string caption, int smallImageIndex, int largeImageIndex)
        {
            return AddItem(caption, smallImageIndex, largeImageIndex, true, null);
        }

        public int AddItem(string caption, int smallImageIndex, bool allowDrag, object obj)
        {
            return AddItem(caption, smallImageIndex, -1, allowDrag, obj);
        }

        public int AddItem(string caption, int smallImageIndex, int largeImageIndex, bool allowDrag, object obj)
        {
            ToolBoxItem item = null;

            if (null == _control)
            {
                item = new ToolBoxItem(caption, smallImageIndex, allowDrag);
                item.Object = obj;
                item.LargeImageIndex = largeImageIndex;
            }

            return AddItem(item);
        }

        public int AddItem(ToolBoxItem item)
        {
            int index = -1;

            if (null == _control && _parent.EndRenameItem())
            {
                if (null == _toolItems)
                {
                    _toolItems = new ToolBoxItemCollection();
                }

                item.Parent = _parent;
                item.ParentItem = this;

                index = _toolItems.Add(item);

                if (_parent.Created)
                {
                    if (_parent.LayoutTimerActive && -1 != _newItemIndex)
                    {
                        _parent.EndTimedLayout();
                        OnLayoutFinished();
                    }
                    if (!_selected)
                    {
                        _selected = true;
                        _newItemIndex = index;
                        _parent.OnTabSelectionChanged(this, new LayoutFinished(OnLayoutFinished));
                    }
                    else
                    {
                        UpdateNewItem(index);
                    }
                }
                else
                {
                    _oldSelItemIndex = _selItemIndex;
                    if (-1 != _selItemIndex)
                    {
                        _toolItems[_selItemIndex].Selected = false;
                    }
                    _selItemIndex = index;
                    item.Selected = true;
                }
            }

            return index;
        }

        public void DoItemLayout()
        {
            UpdateItemLoopIndexes();
        }

        public bool CanScroll(ToolBoxScrollDirection scrollDir)
        {
            bool bCanScroll = true;


            if (null != _toolItems && 0 < _toolItems.Count)
            {
                if (_toolItems[0].Top - this.ItemSpacingEx >= _itemArea.Top &&
                    (_toolItems[_toolItems.Count - 1].Bottom + this.ItemSpacingEx) <= _itemArea.Bottom)
                {
                    bCanScroll = false;
                }
                else
                {
                    if (ToolBoxScrollDirection.UP == scrollDir)
                    {
                        bCanScroll = (_toolItems[0].Top + _itemArea.Top + this.ItemSpacingEx) < _itemArea.Top;
                    }
                    else if (ToolBoxScrollDirection.DOWN == scrollDir)
                    {
                        bCanScroll = (_toolItems[_toolItems.Count - 1].Bottom + _itemArea.Top + this.ItemSpacingEx) > _itemArea.Bottom;
                    }
                }
            }
            else
            {
                bCanScroll = false;
            }

            return bCanScroll;
        }

        public bool ScrollItems(ToolBoxScrollDirection scrollDir)
        {
            return ScrollItems(scrollDir, true);
        }

        public bool ScrollItems(ToolBoxScrollDirection scrollDir, bool bRedraw)
        {
            int scrollOffset = 0;
            bool bScrolled = false;
            try
            {
                if (null != _toolItems)
                {
                    scrollOffset = _toolItems[0].Height + this.ItemSpacingEx;
                }
                else
                {
                    scrollOffset = _parent.ItemHeight + this.ItemSpacingEx;
                }

                if (CanScroll(scrollDir))
                {
                    if (ToolBoxScrollDirection.UP == scrollDir)
                    {
                        ScrollItems(+scrollOffset, bRedraw);
                    }
                    else if (ToolBoxScrollDirection.DOWN == scrollDir)
                    {
                        ScrollItems(-scrollOffset, bRedraw);
                    }
                    bScrolled = true;
                }
            }
            catch
            {
                bScrolled = false;
            }

            return bScrolled;
        }

        public bool EnsureItemVisible(ToolBoxItem item)
        {
            bool bScrolled = false;
            int index = -1;

            if (null != _toolItems)
            {
                index = _toolItems.IndexOf(item);
            }

            if (-1 != index)
            {
                bScrolled = EnsureItemVisible(index);
            }
            return bScrolled;
        }

        public bool EnsureItemVisible(int index)
        {
            bool bScrolled = false;
            bool bLoop = true;
            bool bUpState = true;
            bool bDnState = true;

            ToolBoxScrollDirection dir = ToolBoxScrollDirection.UP;
            try
            {
                bUpState = _parent.UpScroll.Enabled;
                bDnState = _parent.DownScroll.Enabled;

                // Check if scrolling is needed or not.
                bLoop = !ItemVisible(index);

                if (bLoop)
                {
                    // Determine the scroll direction. This is
                    // to prevent from infinite swinging scrolling
                    // when the item area is too low.
                    if (_toolItems[index].Bottom + _itemArea.Top >= _itemArea.Bottom - 1)
                    {
                        dir = ToolBoxScrollDirection.DOWN;
                    }
                }
                while (bLoop)
                {
                    // Scroll in one direction only to prevent infinite
                    // looping. :)
                    if (ToolBoxScrollDirection.UP == dir)
                    {
                        if (_toolItems[index].Top + _itemArea.Top < _itemArea.Top + this.ItemSpacingEx)
                        {
                            bLoop = ScrollItems(dir);
                        }
                        else
                        {
                            bLoop = false;
                        }
                    }
                    else if (ToolBoxScrollDirection.DOWN == dir)
                    {
                        if (_toolItems[index].Bottom + _itemArea.Top >= _itemArea.Bottom - 1)
                        {
                            bLoop = ScrollItems(dir);
                        }
                        else
                        {
                            bLoop = false;
                        }
                    }
                    bScrolled |= bLoop;
                }

                if (!bScrolled)
                {
                    _toolItems[index].Invalidate();
                }

                UpdateScrollButtons();

                if (bUpState != _parent.UpScroll.Enabled)
                {
                    _parent.Invalidate(_parent.UpScroll.Rectangle);
                }
                if (bDnState != _parent.DownScroll.Enabled)
                {
                    _parent.Invalidate(_parent.DownScroll.Rectangle);
                }

            }
            catch
            {
                bScrolled = false;
            }

            return bScrolled;
        }

        public void UpdateItemRects(bool bRedraw)
        {
            UpdateItemRects(true, true, bRedraw);
        }

        public void UpdateItemRects(bool bUpdateXY, bool bUpdateSize, bool bRedraw)
        {
            UpdateItemRects(bUpdateXY, bUpdateSize, bRedraw, false);
        }

        #endregion //Public Methods

        #region Private Methods

        private void Initialize()
        {
            _delegates = new Delegate[5];

            _delegates[0] = new MouseEventHandler(On_MouseDown);
            _delegates[1] = new MouseEventHandler(On_MouseUp);
            _delegates[2] = new MouseEventHandler(On_MouseMove);
            _delegates[3] = new EventHandler(On_MouseLeave);
            _delegates[4] = new PaintEventHandler(On_Paint);

            //Create redirection object to the base palette
            if (((_palette != null)))
            {
                _palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);
            }
            KryptonManager.GlobalPaletteChanged += new EventHandler(OnGlobalPaletteChanged);
            _palette = KryptonManager.CurrentGlobalPalette;
            _paletteRedirect = new PaletteRedirect(_palette);

            //Create accessor objects for the back, border and content
            _paletteBack = new PaletteBackInheritRedirect(_paletteRedirect);

            _paletteBorder = new PaletteBorderInheritRedirect(_paletteRedirect);

            _paletteContent = new PaletteContentInheritRedirect(_paletteRedirect);

            InitColours();
        }

        private void InvalidateEx(bool invalidateSelf, bool invalidateItems)
        {
            if (invalidateSelf)
            {
                Invalidate();
            }

            if (invalidateItems)
            {
                _parent.Invalidate(_itemArea);
            }
        }

        private Size GetCurrentItemSize(ref int maxWidth)
        {
            Size itemSize = Size.Empty;

            maxWidth = _parent.DisplayRectangle.Width - (2);

            switch (this._viewMode)
            {
                case ToolBoxViewMode.LARGEICONS:
                    itemSize = _parent.LargeItemSize;
                    maxWidth -= 4;
                    break;
                case ToolBoxViewMode.SMALLICONS:
                    itemSize = _parent.SmallItemSize;
                    maxWidth -= 4;
                    break;
                case ToolBoxViewMode.LIST:
                default:
                    itemSize.Width = maxWidth - 0;
                    itemSize.Height = _parent.ItemHeight;
                    break;
            }

            return itemSize;
        }

        private Point GetItemLocation(int index, int itemWidth, int itemHeight, int maxWidth)
        {
            Point itemLoc = Point.Empty;
            bool bOk = true;

            if (null != _toolItems)
            {
                if (0 == index)
                {
                    itemLoc.X = ToolBoxViewMode.LIST == _viewMode ? 0 : 4;
                    itemLoc.Y = ToolBoxViewMode.LIST == _viewMode ? 1 : 2;
                }
                else if ((index - 1) < _toolItems.Count && 0 < index)
                {
                    itemLoc = _toolItems[index - 1].Location;

                    switch (this._viewMode)
                    {
                        case ToolBoxViewMode.LARGEICONS:
                        case ToolBoxViewMode.SMALLICONS:

                            itemLoc.X += itemWidth + this.ItemSpacingEx;

                            if (_onlyOneItemPerRow || _parent.ShowOnlyOneItemPerRow || (itemLoc.X + itemWidth) > maxWidth)
                            {
                                itemLoc.X = 4;
                                itemLoc.Y += itemHeight + this.ItemSpacingEx;
                            }
                            break;
                        case ToolBoxViewMode.LIST:
                        default:
                            itemLoc.X = 0;
                            itemLoc.Y += _parent.ItemHeight + this.ItemSpacingEx;
                            break;
                    }
                }
                else
                {
                    bOk = false;
                }

                if (bOk && ToolBoxViewMode.LIST != _viewMode && (_onlyOneItemPerRow || _parent.ShowOnlyOneItemPerRow))
                {
                    itemLoc.X += (maxWidth - itemWidth) / 2;
                }
            }

            return itemLoc;
        }

        private void UpdateItemRects(bool bUpdateXY, bool bUpdateSize, bool bRedraw, bool resetCaptionCheck)
        {
            bool[] bUpdates = null;
            Size itemSize = Size.Empty;
            int iLoop = 0;
            int maxWidth = 0;

            if (null != _toolItems && null == _control)
            {
                bUpdates = new bool[2];
                bUpdates[0] = false;
                bUpdates[1] = false;
                _visibleTopIndex = 0;
                _visibleBottomIndex = _toolItems.Count - 1;

                if (bUpdateSize)
                {
                    itemSize = GetCurrentItemSize(ref maxWidth);
                }

                for (iLoop = 0; iLoop < _toolItems.Count; iLoop++)
                {

                    /*if(resetCaptionCheck)
                    {
                        _toolItems[iLoop].UpdateViewChange();
                    }*/

                    if (bUpdateSize)
                    {
                        _toolItems[iLoop].Size = itemSize;
                    }

                    if (bUpdateXY)
                    {
                        _toolItems[iLoop].Location = GetItemLocation(iLoop, itemSize.Width, itemSize.Height, maxWidth);
                    }

                    UpdateItemLoopIndexes(iLoop, bUpdates);

                }

                PostUpdateItemLoopIndexes();

                if (bRedraw)
                {
                    _parent.Invalidate(_itemArea);
                }
            }

            if (null != _control)
            {
                UpdateControlRect(false);
            }

            UpdateScrollButtons();
        }

        private void UpdateControlRect(bool callLayout)
        {
            Rectangle ctrlRect;

            if (null != _control)
            {
                ctrlRect = _itemArea;
                ctrlRect.Y += this.ItemSpacingEx;
                ctrlRect.Height -= 2;

                if (callLayout)
                {
                    _control.SuspendLayout();
                }
                _control.Size = ctrlRect.Size;
                _control.Location = ctrlRect.Location;

                if (callLayout)
                {
                    _control.ResumeLayout(true);
                }
            }
        }

        private void HandleAmbientKey(bool up)
        {
            ToolBoxItem selItem = null;
            bool oldState = false;

            selItem = this[_selItemIndex];

            if (null != selItem)
            {
                oldState = selItem.MouseDown;

                if (up)
                {
                    selItem.MouseDown = false;
                }
                else
                {
                    selItem.MouseDown = true;
                }

                if (oldState != selItem.MouseDown)
                {
                    selItem.Invalidate();
                }
            }
        }

        private bool HandleListViewKeyDown(KeyEventArgs e)
        {
            int oldIndex = -1;
            int newIndex = -1;
            bool doHandle = true;

            oldIndex = _selItemIndex;
            newIndex = _selItemIndex;

            switch (e.KeyCode)
            {
                case Keys.Down:
                    if (newIndex + 1 < _toolItems.Count)
                    {
                        newIndex++;
                    }
                    break;
                case Keys.Up:
                    if (0 <= newIndex - 1)
                    {
                        newIndex--;
                    }
                    break;
                case Keys.PageUp:
                    newIndex = _visibleTopIndex - (_visibleBottomIndex - _visibleTopIndex) / 2;
                    newIndex = Math.Max(0, newIndex);
                    break;
                case Keys.PageDown:
                    newIndex = _visibleBottomIndex + (_visibleBottomIndex - _visibleTopIndex) / 2;
                    newIndex = Math.Min(newIndex, _toolItems.Count - 1);
                    break;
                case Keys.Home:
                    newIndex = 0;
                    break;
                case Keys.End:
                    newIndex = _toolItems.Count - 1;
                    break;
                case Keys.Tab:
                    if ((Keys.Shift == (e.Modifiers & Keys.Shift)))
                    {
                        newIndex--;
                    }
                    else
                    {
                        newIndex++;
                    }
                    doHandle = 0 <= newIndex && newIndex < _toolItems.Count;
                    break;
                default:
                    doHandle = false;
                    break;
            }

            if (doHandle && oldIndex != newIndex)
            {
                if (-1 != oldIndex)
                {
                    _toolItems[oldIndex].Selected = false;
                }

                if (-1 != newIndex)
                {
                    _selItemIndex = newIndex;
                    _toolItems[newIndex].Selected = true;

                    EnsureItemVisible(newIndex);
                }
            }

            return doHandle;
        }

        private bool HandleIconViewKeyDown(KeyEventArgs e)
        {
            int oldIndex = -1;
            int newIndex = -1;
            int tempIndex = -1;
            int iLoop = 0;
            int mulFactor = 1;
            bool doHandle = true;

            oldIndex = _selItemIndex;
            newIndex = _selItemIndex;

            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Left:

                        if (0 <= newIndex - 1)
                        {
                            newIndex--;
                        }

                        if (newIndex != oldIndex && _toolItems[oldIndex].Y != _toolItems[newIndex].Y)
                        {
                            newIndex = oldIndex;
                        }
                        break;
                    case Keys.Right:
                        if (newIndex + 1 < _toolItems.Count)
                        {
                            newIndex++;
                        }
                        if (newIndex != oldIndex && _toolItems[oldIndex].Y != _toolItems[newIndex].Y)
                        {
                            newIndex = oldIndex;
                        }
                        break;
                    case Keys.PageUp:
                        newIndex = _visibleTopIndex - (_visibleBottomIndex - _visibleTopIndex) / 2;
                        newIndex = Math.Max(0, newIndex);
                        break;
                    case Keys.PageDown:
                        newIndex = _visibleBottomIndex + (_visibleBottomIndex - _visibleTopIndex) / 2;
                        newIndex = Math.Min(newIndex, _toolItems.Count - 1);
                        break;
                    case Keys.Up:

                        tempIndex = oldIndex - mulFactor;
                        tempIndex = Math.Max(tempIndex, 0);

                        if (tempIndex != oldIndex)
                        {
                            for (iLoop = tempIndex; 0 <= iLoop; iLoop--)
                            {
                                if (_toolItems[iLoop].X == _toolItems[oldIndex].X)
                                {
                                    newIndex = iLoop;
                                    iLoop = -1;
                                }
                            }

                            if (newIndex == oldIndex && 1 != mulFactor)
                            {
                                newIndex = tempIndex;
                            }
                        }
                        break;
                    case Keys.Down:

                        tempIndex = oldIndex + mulFactor;
                        tempIndex = Math.Min(tempIndex, _toolItems.Count - 1);

                        if (tempIndex != oldIndex)
                        {
                            for (iLoop = tempIndex; iLoop < _toolItems.Count; iLoop++)
                            {
                                if (_toolItems[iLoop].X == _toolItems[oldIndex].X)
                                {
                                    newIndex = iLoop;
                                    iLoop = _toolItems.Count + 1;
                                }
                            }

                            if (newIndex == oldIndex && 1 != mulFactor)
                            {
                                newIndex = tempIndex;
                            }
                        }
                        break;
                    case Keys.Home:
                        newIndex = 0;
                        break;
                    case Keys.End:
                        newIndex = _toolItems.Count - 1;
                        break;

                    case Keys.Tab:
                        if ((Keys.Shift == (e.Modifiers & Keys.Shift)))
                        {
                            newIndex--;
                        }
                        else
                        {
                            newIndex++;
                        }
                        doHandle = 0 <= newIndex && newIndex < _toolItems.Count;
                        break;
                    default:
                        doHandle = false;
                        break;
                }
            }
            catch
            {
                doHandle = false;
            }

            if (doHandle && oldIndex != newIndex)
            {
                if (-1 != oldIndex)
                {
                    _toolItems[oldIndex].Selected = false;
                }

                if (-1 != newIndex)
                {
                    _selItemIndex = newIndex;
                    _toolItems[newIndex].Selected = true;

                    EnsureItemVisible(newIndex);
                }
            }

            return doHandle;
        }

        private void UpdateNewItem(int index)
        {
            int maxWidth = 0;

            if (index < _toolItems.Count && 0 <= index)
            {
                _toolItems[index].Size = GetCurrentItemSize(ref maxWidth);
                _toolItems[index].Location = GetItemLocation(index, _toolItems[index].Width, _toolItems[index].Height, maxWidth);

                if (null != this[_selItemIndex])
                {
                    _toolItems[_selItemIndex].Selected = false;
                }

                _toolItems[index].Selected = true;
                _parent.OnItemSelectionChanged(_toolItems[index], this);

                UpdateItemLoopIndexes();
                UpdateScrollButtons();

                if (!EnsureItemVisible(index))
                {
                    _toolItems[index].Invalidate();
                }

                if (!_itemBgColour.IsEmpty)
                {
                    InvalidateEx(false, true);
                }
            }
        }

        private void UpdateScrollButtons()
        {
            bool oldVal = false;

            oldVal = _parent.UpScroll.Enabled;
            _parent.UpScroll.Enabled = CanScroll(ToolBoxScrollDirection.UP);

            if (oldVal != _parent.UpScroll.Enabled)
            {
                _parent.Invalidate(_parent.UpScroll.Rectangle);
            }

            oldVal = _parent.DownScroll.Enabled;
            _parent.DownScroll.Enabled = CanScroll(ToolBoxScrollDirection.DOWN);

            if (oldVal != _parent.DownScroll.Enabled)
            {
                _parent.Invalidate(_parent.DownScroll.Rectangle);
            }

        }

        private void OnLayoutFinished()
        {
            if (-1 != _newItemIndex)
            {
                UpdateNewItem(_newItemIndex);
            }
            _newItemIndex = -1;
        }

        private bool SwapItems(int index1, int index2)
        {
            bool bSwaped = false;
            ToolBoxItem item1 = null;
            ToolBoxItem item2 = null;
            ToolBoxItem selItem = null;
            Rectangle rcTmp = Rectangle.Empty;

            try
            {
                if (index1 != index2)
                {
                    item1 = _toolItems[index1];
                    item2 = _toolItems[index2];

                    if (item1.Selected)
                    {
                        selItem = item1;
                    }

                    if (item2.Selected)
                    {
                        selItem = item2;
                    }

                    if (item1.Movable && item2.Movable)
                    {
                        rcTmp = item2.Rectangle;

                        item2.Rectangle = item1.Rectangle;
                        item1.Rectangle = rcTmp;

                        item1.MouseHover = false;
                        item2.MouseHover = false;

                        _toolItems[index2] = item1;
                        _toolItems[index1] = item2;

                        _parent.Invalidate(_itemArea);

                        if (null != selItem)
                        {
                            _selItemIndex = _toolItems.IndexOf(selItem);
                        }
                    }
                }
            }
            catch
            {
                bSwaped = false;
            }

            return bSwaped;
        }

        private void UpdateItemLoopIndexes(int index, bool[] bUpdates)
        {
            if (!bUpdates[0] && _toolItems[index].Top + _itemArea.Top >= _itemArea.Top)
            {
                _visibleTopIndex = index;
                bUpdates[0] = true;
            }
            if (!bUpdates[1] && _toolItems[index].Top + _itemArea.Top >= _itemArea.Bottom)
            {
                _visibleBottomIndex = index;
                bUpdates[1] = true;
            }
        }

        private void UpdateItemLoopIndexes()
        {
            int iItem = 0;
            bool[] bUpdates = new bool[2];

            bUpdates[0] = false;
            bUpdates[1] = false;

            if (null != _toolItems && null == _control)
            {
                _visibleTopIndex = 0;
                _visibleBottomIndex = _toolItems.Count - 1;

                for (iItem = 0; iItem < _toolItems.Count; iItem++)
                {
                    UpdateItemLoopIndexes(iItem, bUpdates);
                    if (true == bUpdates[0] && true == bUpdates[1])
                    {
                        iItem = _toolItems.Count + 1;
                    }
                }

                PostUpdateItemLoopIndexes();
            }

        }

        private void PostUpdateItemLoopIndexes()
        {
            int iLoop = 0;
            int lastY = 0;

            if (ToolBoxViewMode.LIST != this._viewMode)
            {
                lastY = _toolItems[_visibleBottomIndex].Y;

                for (iLoop = _visibleBottomIndex + 1; iLoop < _toolItems.Count; iLoop++)
                {
                    _visibleBottomIndex = iLoop;

                    if (_toolItems[iLoop].Y > lastY)
                    {
                        iLoop = _toolItems.Count + 1;
                    }
                }
            }
        }

        private void ScrollItems(int offset)
        {
            ScrollItems(offset, true);
        }

        private void ScrollItems(int offset, bool bRedraw)
        {
            int iItem = 0;
            bool[] bUpdates = new bool[2];

            bUpdates[0] = false;
            bUpdates[1] = false;

            if (null != _toolItems)
            {
                _visibleTopIndex = 0;
                _visibleBottomIndex = _toolItems.Count - 1;

                for (iItem = 0; iItem < _toolItems.Count; iItem++)
                {
                    _toolItems[iItem].Y += offset;

                    if (false == bUpdates[0] || false == bUpdates[1])
                    {
                        UpdateItemLoopIndexes(iItem, bUpdates);
                    }
                }

                //_visibleTopIndex    += (0 > offset) ? +1 : -1; 
                //_visibleBottomIndex += (0 > offset) ? +1 : -1; 


                if (bRedraw)
                {
                    Rectangle rInv = Rectangle.Empty;

                    rInv.X = _parent.Left;
                    rInv.Y = _itemArea.Y;
                    rInv.Width = _parent.Width;
                    rInv.Height = _itemArea.Height;

                    _parent.Invalidate(_itemArea);

                    //System.Diagnostics.Debug.WriteLine("ScrollItems : Invalidated " + rInv);

                }
            }
        }

        #endregion //Private Methods

        #region Krypton
        //Krypton Events
        private void OnPalettePaint(object sender, PaletteLayoutEventArgs e)
        {
            base.Invalidate();
        }

        private void OnGlobalPaletteChanged(object sender, EventArgs e)
        {
            if (((_palette != null)))
            {
                _palette.PalettePaint -= new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);
            }
            _palette = KryptonManager.CurrentGlobalPalette;
            _paletteRedirect.Target = _palette;
            if (((_palette != null)))
            {
                _palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);
                InitColours();
            }
            base.Invalidate();

        }


        private void InitColours()
        {
            ItemNormalColour = _palette.ColorTable.OverflowButtonGradientBegin;
            ItemBorderColour = _palette.ColorTable.ToolStripBorder;
            ItemBackgroundColour = _palette.ColorTable.MenuStripGradientBegin;
            ItemHoverColour = _palette.ColorTable.ButtonCheckedGradientBegin;
            ItemSelectedColour = _palette.ColorTable.ButtonPressedGradientBegin;
        }
        #endregion
    }
}