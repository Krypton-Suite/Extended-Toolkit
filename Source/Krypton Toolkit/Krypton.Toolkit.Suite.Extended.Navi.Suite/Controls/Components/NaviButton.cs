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

namespace Krypton.Toolkit.Suite.Extended.Navi.Suite
{
    [
    //Designer(typeof(Guifreaks.Navisuite.Design.NavigationBarButtonDesigner))
    DefaultEvent("Activated"),
    ]
    public partial class NaviButton : NaviControl
    {
        #region Fields

        private EventHandler activated;
        private Image largeImage;
        private Image smallImage;
        private bool small;
        private bool collapsed;
        private bool active;
        private bool showImage;

        protected ControlState state;
        protected InputState inputState;
        protected NaviBand band;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the NaviButton
        /// </summary>
        public NaviButton()
        {
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the NaviButton
        /// </summary>
        public NaviButton(IContainer container)
           : this()
        {
            container.Add(this);
        }

        #endregion

        #region Properties

        // Design time 

        /// <summary>
        /// Gets or sets the large image displayed when the button is not in minimized mode
        /// </summary>
        [
        DefaultValue(null),
        Localizable(true),
        Category("Appearance"),
        Description("The image displayed when the button is not displayed as a small button"),
        ]
        public Image LargeImage
        {
            get => largeImage;
            set
            {
                largeImage = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or set the image displayed when the button is in minimized mode
        /// </summary>
        [
        DefaultValue(null),
        Localizable(true),
        Category("The image displayed when the button is displayed as a small button"),
        ]
        public Image SmallImage
        {
            get => smallImage;
            set
            {
                smallImage = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets whether the image is visible or not
        /// </summary>
        [
        DefaultValue(true),
        Category("Indicates if the image is visible or not"),
        ]
        public bool ShowImage
        {
            get => showImage;
            set { showImage = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the band that is associated with this button
        /// </summary>
        [
        Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
        ]
        public NaviBand Band
        {
            get => band;
            internal set => band = value;
        }

        // Non design time

        /// <summary>
        /// Gets or sets whether the button is currently the active button
        /// </summary>
        [
        Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        ]
        public bool Active
        {
            get => active;
            set
            {
                active = value;
                if (active)
                {
                    state = ControlState.Active;
                    OnActivated(new EventArgs());
                }
                else
                {
                    state = ControlState.Normal;
                    inputState = InputState.Normal;
                }
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets whether the button should be drawn in the compact mode or the full mode
        /// </summary>
        [
        Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        ]
        public bool Small
        {
            get => small;
            set
            {
                small = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets whether the buttons should be drawn in minimized mode or not
        /// </summary>
        [
        Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        ]
        public virtual bool Collapsed
        {
            get => collapsed;
            set
            {
                collapsed = value;
                Invalidate();
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs the button is activated
        /// </summary>
        public event EventHandler Activated
        {
            add { lock (threadLock) { activated += value; } }
            remove { lock (threadLock) { activated -= value; } }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the button for the first time
        /// </summary>
        private void Initialize()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);

            Visible = true;
            small = false;
            collapsed = false;
            showImage = true;
        }

        /// <summary>
        /// Raises the Activated event
        /// </summary>
        /// <param name="e">Additional event info</param>
        protected virtual void OnActivated(EventArgs e)
        {
            EventHandler handler = activated;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Overriden. Raises the Paint event 
        /// </summary>
        /// <param name="e">Additional paint info</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Renderer.DrawButtonBg(e.Graphics, ClientRectangle, state, inputState);

            if (small)
            {
                Image imageSmall = null;
                if (smallImage != null)
                {
                    imageSmall = smallImage;
                }
                else if ((band != null) && (band.SmallImage != null))
                {
                    imageSmall = band.SmallImage;
                }
                else if ((band != null) && (band.SmallImageIndex >= 0) && (band.SmallImages != null)
                         && (band.SmallImageIndex < band.SmallImages.Images.Count))
                {
                    imageSmall = band.SmallImages.Images[band.SmallImageIndex];
                }

                if ((imageSmall != null) && (showImage))
                {
                    Point location = new Point((int)((Width / 2) - (imageSmall.Width / 2)),
                       (int)((Height / 2) - (imageSmall.Height / 2)));
                    Renderer.DrawImage(e.Graphics, location, imageSmall);
                }
            }
            else
            {
                Rectangle bounds = ClientRectangle;

                Image imageLarge = null;
                if (largeImage != null)
                {
                    imageLarge = largeImage;
                }
                else if ((band != null) && (band.LargeImage != null))
                {
                    imageLarge = band.LargeImage;
                }
                else if ((band != null) && (band.LargeImageIndex >= 0)
                                        && (band.LargeImageIndex < band.LargeImages.Images.Count))
                {
                    imageLarge = band.LargeImages.Images[band.LargeImageIndex];
                }

                if ((imageLarge != null) && showImage)
                {
                    Point location;

                    int margin = 10;
                    if (collapsed)
                    {
                        margin = 4;
                    }

                    if (RightToLeft == RightToLeft.Yes)
                    {
                        location = new Point(Width - margin - imageLarge.Width, (int)((Height / 2) - (imageLarge.Height / 2)));
                    }
                    else
                    {
                        location = new Point(margin, (int)((Height / 2) - (imageLarge.Height / 2)));
                    }

                    Renderer.DrawImage(e.Graphics, location, imageLarge);

                    // Calculate bounds for text
                    if (RightToLeft == RightToLeft.No)
                    {
                        bounds.X += 32;
                    }
                    bounds.Width -= 32;
                }
                bounds.X += 10;
                bounds.Width -= 10;
                if (!collapsed)
                {
                    Renderer.DrawText(e.Graphics, bounds, Font, Renderer.ColourTable.Text, Text,
                        RightToLeft == RightToLeft.Yes);
                }
            }
        }

        /// <summary>
        /// Overriden. Raises the MouseEnter event
        /// </summary>
        /// <param name="e">Additional mouse info</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            inputState = InputState.Hovered;
            Invalidate();
        }

        /// <summary>
        /// Overriden. Raises the MouseDown event
        /// </summary>
        /// <param name="e">Additional mouse info</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            inputState = InputState.Clicked;
            Invalidate();
        }

        /// <summary>
        /// Overriden. Raises the MouseUp event 
        /// </summary>
        /// <param name="e">Additional mouse info</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            inputState = InputState.Normal;
            Invalidate();
        }

        /// <summary>
        /// Overriden. Raises the MouseLeave event
        /// </summary>
        /// <param name="e">Additional mouse info</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            inputState = InputState.Normal;
            Invalidate();
        }

        /// <summary>
        /// Overriden. Raises the TextChanged event
        /// </summary>
        /// <param name="e">Additional event info</param>
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }

        #endregion
    }
}