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

using MethodInvoker = System.Windows.Forms.MethodInvoker;

namespace Krypton.Toolkit.Suite.Extended.Forms
{
    /// <summary>
    /// Manages the drawing of Shadows
    /// </summary>
    internal class ShadowManager
    {
        #region Instance Fields
        private readonly VisualForm _parentForm;
        private readonly ShadowValues _shadowValues;
        private bool _allowDrawing;
        private VisualShadowBase?[] _shadowForms;
        #endregion

        #region Identity
        public ShadowManager(VisualForm kryptonForm, ShadowValues shadowValues)
        {
            _parentForm = kryptonForm;
            _shadowValues = shadowValues;

            _parentForm.Closing += KryptonFormOnClosing;
            _parentForm.Load += FormLoaded;

            shadowValues.EnableShadowsChanged += ShadowValues_EnableShadowsChanged;
            shadowValues.MarginsChanged += ShadowValues_MarginsChanged;
            shadowValues.BlurDistanceChanged += ShadowValues_BlurDistanceChanged;
            shadowValues.ColourChanged += ShadowValues_ColourChanged;
            shadowValues.OpacityChanged += ShadowValues_OpacityChanged;

        }

        internal void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case PlatformInvoke.WM_.WINDOWPOSCHANGED:
                    {
                        PlatformInvoke.WINDOWPOS structure = (PlatformInvoke.WINDOWPOS)Marshal.PtrToStructure(m.LParam, typeof(PlatformInvoke.WINDOWPOS));
                        var move = !structure.flags.HasFlag(PlatformInvoke.SWP_.NOSIZE | PlatformInvoke.SWP_.NOMOVE);
                        PositionShadowForms(move);
                        if (!move)
                        {
                            ReCalcBrushes();
                        }
                    }
                    break;
            }
        }

        #endregion

        private void InitialiseShadowForms()
        {
            if (_shadowForms != null)
            {
                foreach (var shadowForm in _shadowForms)
                {
                    shadowForm!.Visible = false;
                    shadowForm.Dispose();
                }
            }
            _shadowForms = new VisualShadowBase[4];

            for (var i = 0; i < 4; i++)
            {
                _shadowForms[i] = new VisualShadowBase(_shadowValues, (VisualOrientation)i);
            }
        }

        private bool AllowDrawing =>
            _allowDrawing
            && _shadowValues.EnableShadows
            && _parentForm.Visible;

        private void KryptonFormOnClosing(object sender, /*Cancel*/EventArgs e)
        {
            _allowDrawing = false;
            FlashWindowExListener.FlashEvent -= OnFlashWindowExListenerOnFlashEvent;

            if (_shadowForms != null)
            {
                foreach (var shadowForm in _shadowForms)
                {
                    shadowForm!.Visible = false;
                    shadowForm.Dispose();
                }
            }
        }

        private void FormLoaded(object sender, EventArgs e)
        {
            _allowDrawing = (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
                            && (Process.GetCurrentProcess().ProcessName != @"devenv");
            if (_shadowForms == null)
            {
                InitialiseShadowForms();
                SetShadowFormsSizes();
                FlashWindowExListener.Register(_parentForm as Form);
                FlashWindowExListener.FlashEvent += OnFlashWindowExListenerOnFlashEvent;
            }
            else
            {
                PositionShadowForms(false);
            }
        }

        // Try and keep the shadows where  they are supposed to be when the form is flashing.
        private void OnFlashWindowExListenerOnFlashEvent(Form form, bool flashing)
        {
            if (!flashing)
            {
                _parentForm.BeginInvoke((MethodInvoker)(() => PositionShadowForms(false)));
            }
        }

        private void ShadowValues_ColourChanged(object sender, ColorEventArgs e) => ReCalcBrushes();

        private void ShadowValues_BlurDistanceChanged(object sender, EventArgs e) => ReCalcBrushes();

        private void ShadowValues_OpacityChanged(object sender, EventArgs e) => ReCalcBrushes();

        private void ShadowValues_MarginsChanged(object sender, EventArgs e) => SetShadowFormsSizes();

        private void ShadowValues_EnableShadowsChanged(object sender, EventArgs e)
        {
            if (!_allowDrawing)
            {
                // Call before shown is complete
                return;
            }

            foreach (var shadowForm in _shadowForms)
            {
                shadowForm!.Visible = AllowDrawing;
            }
        }


        private void SetShadowFormsSizes()
        {
            PositionShadowForms(false);
            ReCalcBrushes();
        }

        private void ReCalcBrushes()
        {
            if (!AllowDrawing)
            {
                return;
            }

            // calculate the "whole" shadow
            Rectangle clientRectangle = CommonHelper.RealClientRectangle(_parentForm.Handle);
            using Bitmap allShadow = DrawShadowBitmap(clientRectangle);
            foreach (var shadowForm in _shadowForms)
            {
                shadowForm?.ReCalcShadow(allShadow, clientRectangle);
            }
        }

        /// <summary>
        /// Probably a more efficient way, but this gives the easiest testable visible results
        /// </summary>
        /// <param name="clientRectangle"></param>
        /// <returns></returns>
        private Bitmap DrawShadowBitmap(Rectangle clientRectangle)
        {
            int extraWidth = _shadowValues.ExtraWidth;
            var w = clientRectangle.Width + extraWidth * 2;
            var h = clientRectangle.Height + extraWidth * 2;

            var blur = (float)(_shadowValues.BlurDistance / 100.0 * extraWidth);
            var solidW = clientRectangle.Width + blur * 2;
            var solidH = clientRectangle.Height + blur * 2;
            var blurOffset = _shadowValues.ExtraWidth - blur;
            Bitmap bitmap = new(w, h);
            bitmap.MakeTransparent();
            using Graphics g = Graphics.FromImage(bitmap);
            // fill background
            //g.FillRectangle(Brushes.Magenta, 0,0,w,h);
            // +1 to fill the gap
            g.FillRectangle(new SolidBrush(_shadowValues.Colour),
                blurOffset, blurOffset, solidW + 1, solidH + 1);

            // four dir gradient
            if (blurOffset > 0)
            {
                using (LinearGradientBrush brush = new(new PointF(0, 0), new PointF(blurOffset, 0),
                    Color.Transparent, _shadowValues.Colour))
                {
                    // Left
                    g.FillRectangle(brush, 0, blurOffset, blurOffset, solidH);

                    // Top
                    brush.RotateTransform(90);
                    g.FillRectangle(brush, blurOffset, 0, solidW, blurOffset);

                    // Right
                    // make sure pattern is correct
                    brush.ResetTransform();
                    brush.TranslateTransform(w % blurOffset, h % blurOffset);

                    brush.RotateTransform(180);
                    g.FillRectangle(brush, w - blurOffset, blurOffset, blurOffset, solidH);
                    // Bottom
                    brush.RotateTransform(90);
                    g.FillRectangle(brush, blurOffset, h - blurOffset, solidW, blurOffset);
                }


                // four corner
                using (GraphicsPath gp = new())
                using (Matrix matrix = new())
                {
                    gp.AddEllipse(0, 0, blurOffset * 2, blurOffset * 2);
                    using (PathGradientBrush pgb = new PathGradientBrush(gp)
                    {
                        CenterColor = _shadowValues.Colour,
                        SurroundColors = new[] { Color.Transparent },
                        CenterPoint = new PointF(blurOffset, blurOffset)
                    })
                    {
                        // left-Top
                        g.FillPie(pgb, 0, 0, blurOffset * 2, blurOffset * 2, 180, 90);

                        // right-Top
                        matrix.Translate(w - blurOffset * 2, 0);

                        pgb.Transform = matrix;
                        //pgb.Transform.Translate(w-blur*2, 0);
                        g.FillPie(pgb, w - blurOffset * 2, 0, blurOffset * 2, blurOffset * 2, 270, 90);

                        // right-Bottom
                        matrix.Translate(0, h - blurOffset * 2);
                        pgb.Transform = matrix;
                        g.FillPie(pgb, w - blurOffset * 2, h - blurOffset * 2, blurOffset * 2, blurOffset * 2, 0, 90);

                        // left-Bottom
                        matrix.Reset();
                        matrix.Translate(0, h - blurOffset * 2);
                        pgb.Transform = matrix;
                        g.FillPie(pgb, 0, h - blurOffset * 2, blurOffset * 2, blurOffset * 2, 90, 90);
                    }
                }
            }

            //
            return bitmap;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Move operations have to be done as a single operation to reduce flickering
        /// </remarks>
        private void PositionShadowForms(bool move)
        {
            if (!_allowDrawing)
            {
                // Probably called before shown is complete
                return;
            }

            void Mi()
            {
                var shadowFormVisible = AllowDrawing;
                foreach (var shadowForm in _shadowForms)
                {
                    shadowForm!.Visible = shadowFormVisible;
                }
                if (!shadowFormVisible)
                {
                    return;
                }

                Point desktopLocation = _parentForm.DesktopLocation;

                IntPtr hWinPosInfo = PlatformInvoke.BeginDeferWindowPos(_shadowForms.Length);

                foreach (var shadowForm in _shadowForms)
                {
                    shadowForm?.CalcPositionShadowForm(desktopLocation,
                        CommonHelper.RealClientRectangle(_parentForm.Handle));
                    Rectangle targetRect = shadowForm!.TargetRect;
                    hWinPosInfo = PlatformInvoke.DeferWindowPos(hWinPosInfo, shadowForm.Handle, /*PlatformInvoke.HWND_TOPMOST, //*/_parentForm.Handle,
                        targetRect.X, targetRect.Y, targetRect.Width, targetRect.Height,
                        (move ? PlatformInvoke.SWP_.NOSIZE : 0) |
                        PlatformInvoke.SWP_.NOACTIVATE
                        | PlatformInvoke.SWP_.NOREDRAW
                        | PlatformInvoke.SWP_.SHOWWINDOW
                        | PlatformInvoke.SWP_.NOCOPYBITS
                        | PlatformInvoke.SWP_.NOOWNERZORDER
                    );
                }

                PlatformInvoke.EndDeferWindowPos(hWinPosInfo);
            }

            if (_parentForm.InvokeRequired)
            {
                _parentForm.Invoke((MethodInvoker)Mi);
            }
            else
            {
                Mi();
            }

        }
    }
}