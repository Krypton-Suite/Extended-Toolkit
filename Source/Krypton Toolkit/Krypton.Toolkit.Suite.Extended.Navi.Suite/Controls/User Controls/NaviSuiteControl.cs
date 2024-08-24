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
    /// <summary>
    /// Represents a control with customizable drawing and layout styles
    /// </summary>
    [ToolboxItem(false)]
    public partial class NaviSuiteControl : ContainerControl
    {
        #region Designer Code
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }

        #endregion
        #endregion

        private NaviLayoutStyle layoutStyle = NaviLayoutStyle.Office2007Blue;
        private EventHandler layoutStyleChanged;
        private NaviRenderer renderer;

        protected readonly object threadLock = new object();

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the NaviControl
        /// </summary>
        public NaviSuiteControl()
        {
        }

        /// <summary>
        /// Initializes a new instance of the NaviControl
        /// </summary>
        /// <param name="container">The parent container</param>
        public NaviSuiteControl(IContainer container)
        {
            container.Add(this);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Indicates how the control is presented to the user
        /// </summary>
        [DefaultValue(NaviLayoutStyle.Office2007Blue)]
        public NaviLayoutStyle LayoutStyle
        {
            get => layoutStyle;
            set
            {
                layoutStyle = value;
                if (layoutStyle != NaviLayoutStyle.StyleFromOwner)
                {
                    renderer = null;
                }

                OnLayoutStyleChanged(new EventArgs());
            }
        }

        /// <summary>
        /// Gets or sets the renderer responsible for drawing the control
        /// </summary>
        [
        Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
        ]
        public virtual NaviRenderer Renderer
        {
            get => renderer;
            set
            {
                renderer = value;
                layoutStyle = NaviLayoutStyle.StyleFromOwner;
                Invalidate();
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs after the layout style has been changed
        /// </summary>
        public event EventHandler LayoutStyleChanged
        {
            add { lock (threadLock) { layoutStyleChanged += value; } }
            remove { lock (threadLock) { layoutStyleChanged -= value; } }
        }

        #endregion

        #region Methods

        private void InitializeRenderer()
        {
            renderer = new NaviOffice7Renderer();

            switch (layoutStyle)
            {
                case NaviLayoutStyle.Office2003Blue:
                case NaviLayoutStyle.Office2003Green:
                case NaviLayoutStyle.Office2003Silver:
                    renderer = new NaviOffice3Renderer();
                    renderer.Initialize(layoutStyle);
                    break;
                case NaviLayoutStyle.Office2007Blue:
                case NaviLayoutStyle.Office2007Silver:
                case NaviLayoutStyle.Office2007Black:
                    renderer = new NaviOffice7Renderer();
                    renderer.Initialize(layoutStyle);
                    break;
                case NaviLayoutStyle.Office2010Blue:
                case NaviLayoutStyle.Office2010Silver:
                case NaviLayoutStyle.Office2010Black:
                    renderer = new NaviOffice10Renderer();
                    renderer.Initialize(layoutStyle);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Raises the LayoutStyleChanged event
        /// </summary>
        /// <param name="e">Additional event info</param>
        protected virtual void OnLayoutStyleChanged(EventArgs e)
        {
            EventHandler handler = layoutStyleChanged;
            if (handler != null)
            {
                handler(this, e);
            }

            Invalidate();
        }

        /// <summary>
        /// Overriden. Raises the Paint event
        /// </summary>
        /// <param name="e">Additional paint info</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (renderer == null)
            {
                InitializeRenderer();
            }
        }

        /// <summary>
        /// Overriden. Raises the PaintBackground
        /// </summary>
        /// <param name="e">Additional paint info</param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            if (renderer == null)
            {
                InitializeRenderer();
            }
        }

        #endregion
    }
}