#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Tool.Box
{
    [Serializable]
    public class ToolObject
    {
        #region Protected Attributes
        protected Rectangle _rectangle;
        protected string _toolTip = null;
        protected bool _forceCaptionToolTip = false;
        protected bool _captionChecked = false;

        #endregion //Protected Attributes

        #region Properties
        [ReadOnly(true), Browsable(false), XmlIgnore]
        public virtual Rectangle Rectangle
        {
            get => _rectangle;
            set
            {
                if (value != _rectangle)
                {
                    if (value.Size != _rectangle.Size)
                    {
                        _captionChecked = false;
                    }
                    _rectangle = value;
                }
            }
        }

        [Browsable(false), XmlIgnore]
        public virtual Point Location
        {
            get => _rectangle.Location;
            set => _rectangle.Location = value;
        }

        [Browsable(false), XmlIgnore]
        public virtual Size Size
        {
            get => _rectangle.Size;
            set
            {
                if (value != _rectangle.Size)
                {
                    _captionChecked = false;
                    _rectangle.Size = value;
                }
            }
        }

        [Browsable(false), XmlIgnore]
        public virtual int X
        {
            get => _rectangle.X;
            set => _rectangle.X = value;
        }

        [Browsable(false), XmlIgnore]
        public virtual int Y
        {
            get => _rectangle.Y;
            set => _rectangle.Y = value;
        }

        [Browsable(false), XmlIgnore]
        public virtual int Width
        {
            get => _rectangle.Width;
            set
            {
                if (value != _rectangle.Width)
                {
                    _captionChecked = false;
                    _rectangle.Width = value;
                }
            }
        }

        [Browsable(false), XmlIgnore]
        public virtual int Height
        {
            get => _rectangle.Height;
            set
            {
                if (value != _rectangle.Height)
                {
                    _captionChecked = false;
                    _rectangle.Height = value;
                }
            }
        }

        [Browsable(false), XmlIgnore]
        public virtual int Left => _rectangle.Left;

        [Browsable(false), XmlIgnore]
        public virtual int Right => _rectangle.Right;

        [Browsable(false), XmlIgnore]
        public virtual int Top => _rectangle.Top;

        [Browsable(false), XmlIgnore]
        public virtual int Bottom => _rectangle.Bottom;

        [Category("General")]
        public virtual string ToolTip
        {
            get => _toolTip;
            set => _toolTip = value;
        }

        [Category("General")]
        public virtual string Caption
        {
            get => null;
            set {; }
        }

        [Category("General"), Browsable(false), XmlIgnore]
        public virtual bool FullyVisible => true;

        [Category("General"), Browsable(false), XmlIgnore]
        public bool ForceCaptionToolTip => _forceCaptionToolTip;

        [Category("General"), Browsable(false), XmlIgnore]
        public bool CaptionChecked => _captionChecked;

        #endregion //Properties

        #region Construction
        public ToolObject()
        {
            _rectangle = new Rectangle(0, 0, 0, 0);
            _toolTip = "";
        }

        public ToolObject(Rectangle rectangle)
        {
            _rectangle = new Rectangle(rectangle.Location, rectangle.Size);
            _toolTip = "";
        }
        #endregion //Construction
    }
}