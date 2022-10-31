#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
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