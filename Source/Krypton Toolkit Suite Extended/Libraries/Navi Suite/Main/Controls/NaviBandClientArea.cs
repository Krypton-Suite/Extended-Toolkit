#region License and Copyright
/*
 
Copyright (c) Guifreaks - Jacob Mesu
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:
    * Redistributions of source code must retain the above copyright
      notice, this list of conditions and the following disclaimer.
    * Redistributions in binary form must reproduce the above copyright
      notice, this list of conditions and the following disclaimer in the
      documentation and/or other materials provided with the distribution.
    * Neither the name of the Guifreaks nor the
      names of its contributors may be used to endorse or promote products
      derived from this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL <COPYRIGHT HOLDER> BE LIABLE FOR ANY
DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

*/
#endregion

using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Navi.Suite
{
    [ToolboxItem(false)]
    public partial class NaviBandClientArea : NaviControl
    {
        // Fields
        private Bitmap backgroundCanvas;

        /// <summary>
        /// Initializes a new instance of the NaviBandClientArea
        /// </summary>
        public NaviBandClientArea()
        {
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the NaviBandClientArea
        /// </summary>
        public NaviBandClientArea(IContainer container)
        {
            container.Add(this);
            Initialize();
        }

        #region Properties

        /// <summary>
        /// Gets a bitmap containing the background of the ClientArea, 
        /// </summary>
        /// <remarks>This bitmap is used for faking opacity of the NaviGroup</remarks>
        public Bitmap BackgroundCanvas
        {
            get { return backgroundCanvas; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the 7control for the first time. 
        /// </summary>
        private void Initialize()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        private void InitializeCanvas()
        {
            if (backgroundCanvas != null)
                backgroundCanvas.Dispose();

            if (Size.Width == 0)
                Size = new System.Drawing.Size(1, Size.Height);
            if (Size.Height == 0)
                Size = new System.Drawing.Size(Size.Width, 1);

            backgroundCanvas = new Bitmap(Size.Width, Size.Height, PixelFormat.Format32bppPArgb);
        }

        /// <summary>
        /// Paints the background on a temporary cache
        /// </summary>
        public void PaintCanvas()
        {
            using (Graphics bitGraphics = Graphics.FromImage(backgroundCanvas))
            {
                if (Renderer != null)
                    Renderer.DrawNaviBandClientAreaBg(bitGraphics, ClientRectangle);
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
        }

        /// <summary>
        /// Overriden. Raises the PaintBackground event
        /// </summary>
        /// <param name="e">Additional paint info</param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            PaintCanvas();
            if (backgroundCanvas == null)
                InitializeCanvas();
            e.Graphics.DrawImageUnscaled(backgroundCanvas, new Point(0, 0));
        }

        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            InitializeCanvas();
            PaintCanvas();
            Invalidate();

            foreach (Control control in Controls)
                control.Invalidate();
        }

        #endregion
    }
}