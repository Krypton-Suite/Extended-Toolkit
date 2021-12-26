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
    [TypeConverter(typeof(ExpandableObjectConverter)), Serializable]
    public class ToolBoxItem : ToolObject
    {
        #region Protected Attributes

        protected int _smallImageIndex;
        protected int _largeImageIndex;
        protected bool _selected;
        protected bool _enabled;
        protected bool _mouseDown;
        protected bool _mouseHover;
        protected bool _allowDrag;
        protected bool _isDragging;
        protected bool _renamable;
        protected bool _movable;
        protected bool _deletable;
        protected string _caption;
        protected object _object;

        [NonSerialized]
        protected ToolBoxItem _parentItem;

        [NonSerialized]
        protected KryptonToolBox _parent;

        // Added by Neal Stublen
        [NonSerialized]
        protected Rectangle _dragSafeRect = Rectangle.Empty;

        #endregion //Protected Attributes

        #region Properties

        [Category("ToolBoxItem"), Browsable(false), XmlIgnore]
        public virtual KryptonToolBox Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        [Category("General"), Browsable(false), XmlIgnore]
        public virtual ToolBoxItem ParentItem
        {
            get { return _parentItem; }
            set { _parentItem = value; }
        }

        [Category("General")]
        public override string Caption
        {
            get { return _caption; }
            set
            {
                if (!value.Equals(_caption))
                {
                    _caption = value;
                    _captionChecked = false;

                    Invalidate();
                }
            }
        }

        [Category("General")]
        public virtual int SmallImageIndex
        {
            get { return _smallImageIndex; }
            set
            {
                if (value != _smallImageIndex)
                {
                    _smallImageIndex = value;
                    Invalidate();
                }
            }
        }

        [Category("General")]
        public virtual int LargeImageIndex
        {
            get { return _largeImageIndex; }
            set
            {
                if (value != _largeImageIndex)
                {
                    _largeImageIndex = value;
                    Invalidate();
                }
            }
        }

        [Category("General"), Browsable(false)]
        public virtual bool Selected
        {
            get { return _selected; }
            set
            {
                if (value != _selected)
                {
                    _selected = value;
                    Invalidate();
                }
            }
        }

        [Category("General"), Browsable(false), XmlIgnore]
        public virtual bool MouseDown
        {
            get { return _mouseDown; }
            set { _mouseDown = value; }
        }

        [Category("General"), Browsable(false), XmlIgnore]
        public virtual bool MouseHover
        {
            get { return _mouseHover; }
            set { _mouseHover = value; }
        }

        [Category("General")]
        public virtual bool Enabled
        {
            get { return _enabled; }
            set
            {
                if (value != _enabled)
                {
                    _enabled = value;
                    Invalidate();
                }
            }
        }

        [Category("General")]
        public virtual bool AllowDrag
        {
            get { return _allowDrag; }
            set { _allowDrag = value; }
        }

        [Category("General"), Browsable(false), XmlIgnore]
        public virtual bool IsDragging
        {
            get { return _isDragging; }
            set { _isDragging = value; }
        }

        [Category("General")]
        public virtual bool Renamable
        {
            get { return _renamable; }
            set { _renamable = value; }
        }

        [Category("General")]
        public virtual bool Movable
        {
            get { return _movable; }
            set { _movable = value; }
        }

        [Category("General")]
        public virtual bool CanMoveUp
        {
            get { return null != _parentItem ? ((ToolBoxTab)_parentItem).CanMoveItemUp(this) : false; }
        }

        [Category("General")]
        public virtual bool CanMoveDown
        {
            get { return null != _parentItem ? ((ToolBoxTab)_parentItem).CanMoveItemDown(this) : false; }
        }

        [Category("General")]
        public virtual bool Deletable
        {
            get { return _deletable; }
            set { _deletable = value; }
        }

        [Category("General")]
        public virtual object Object
        {
            get { return _object; }
            set { _object = value; }
        }

        [Category("General")]
        public override bool FullyVisible
        {
            get
            {
                if (null != this._parentItem)
                {
                    return ((ToolBoxTab)this._parentItem).ItemVisible(this);
                }
                else
                {
                    return base.FullyVisible;
                }
            }
        }


        // Added by Neal Stublen
        [Category("ToolBoxItem"), Browsable(false), XmlIgnore]
        internal virtual Point MouseDownLocation
        {
            set
            {
                _dragSafeRect.Location = value;
                _dragSafeRect.Size = SystemInformation.DragSize;
                _dragSafeRect.Offset(-SystemInformation.DragSize.Width / 2, -SystemInformation.DragSize.Height / 2);
            }
        }

        #endregion //Properties

        #region Construction

        public ToolBoxItem()
        {
            _parent = null;
            _smallImageIndex = -1;
            _largeImageIndex = -1;
            _caption = "";
            _enabled = true;
            _allowDrag = true;
            _renamable = true;
            _movable = true;
            _deletable = true;
        }

        public ToolBoxItem(string caption, int smallImageIndex) : this()
        {
            _caption = caption;
            _smallImageIndex = smallImageIndex;
        }

        public ToolBoxItem(string caption, int smallImageIndex, bool allowDrag)
            : this(caption, smallImageIndex)
        {
            _allowDrag = allowDrag;
        }
        #endregion //Construction

        #region Public Methods

        public override string ToString()
        {
            return "(ToolBoxItem)";
        }

        public virtual bool HitTest(int x, int y)
        {
            bool bHit = false;
            ToolBoxTab parentTab = _parentItem as ToolBoxTab;
            Rectangle rcTemp = Rectangle.Empty;

            bHit = false;

            if (null != parentTab)
            {
                rcTemp = _rectangle;

                rcTemp.X += parentTab.ItemArea.X;
                rcTemp.Y += parentTab.ItemArea.Y;

                if (rcTemp.Bottom >= parentTab.ItemArea.Bottom - 0)
                {
                    rcTemp.Height = (parentTab.ItemArea.Bottom - 0) - rcTemp.Top;
                }
                bHit = rcTemp.Contains(x, y);
            }
            else
            {
                bHit = _rectangle.Contains(x, y);
            }

            return bHit;
        }

        public virtual void CancelHover()
        {
            if (_mouseHover)
            {
                _mouseHover = false;
                Invalidate();
            }
        }

        public virtual void Rename()
        {
            _parent.RenameItem(this);
        }

        // Added by Neal Stublen
        public virtual bool CanStartDrag(int x, int y)
        {
            return AllowDrag && !_dragSafeRect.Contains(x, y);
        }

        public virtual void Invalidate()
        {

            ToolBoxTab parentTab = _parentItem as ToolBoxTab;
            Rectangle rcTemp = Rectangle.Empty;

            if (null != _parent && !_rectangle.IsEmpty)
            {
                if (null != parentTab)
                {
                    rcTemp = _rectangle;
                    rcTemp.Y += parentTab.ItemArea.Y;
                    rcTemp.Inflate(+1, +1);

                    if (rcTemp.Bottom > parentTab.ItemArea.Bottom)
                    {
                        rcTemp.Height = parentTab.ItemArea.Bottom - rcTemp.Top;
                    }
                    _parent.Invalidate(rcTemp);
                }
                else
                {
                    _parent.Invalidate(_rectangle);
                }
            }
        }
        #endregion //Public Methods

        #region Internal Methods

        public void CheckCaption(Graphics g, Font f, StringFormat s, Rectangle rect)
        {
            StringFormat newS = null;
            SizeF area = SizeF.Empty; ;
            Size size;

            if (!_captionChecked)
            {
                try
                {
                    newS = (StringFormat)s.Clone();
                    area.Width = StringFormatFlags.NoWrap == (StringFormatFlags.NoWrap & s.FormatFlags) ? Int32.MaxValue : rect.Width;
                    area.Height = Int32.MaxValue;

                    newS.Trimming = StringTrimming.None;

                    size = g.MeasureString(_caption, f, area, newS).ToSize();

                    _captionChecked = true;

                    if (size.Width > rect.Width || size.Height > rect.Height)
                    {
                        _forceCaptionToolTip = true;
                    }
                    else
                    {
                        _forceCaptionToolTip = false;
                    }
                }
                catch
                {
                }
            }
        }

        internal void UpdateViewChange()
        {
            _captionChecked = false;
        }

        #endregion //Internal Methods

    }
}