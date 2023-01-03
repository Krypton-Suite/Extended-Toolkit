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

using Timer = System.Windows.Forms.Timer;

namespace Krypton.Toolkit.Suite.Extended.Forms
{
    /// <summary>
    /// Manages the drawing of Shadows
    /// </summary>
    internal class BlurManager
    {
        #region Instance Fields
        private readonly VirtualForm _parentForm;
        private readonly BlurValues _blurValues;
        private VisualBlur _visualBlur;
        private readonly Timer _detectIsActiveTimer;
        private Bitmap _currentFormDisplay;
        private double? _parentBeforeOpacity;
        #endregion

        #region Identity

        public BlurManager(VirtualForm kryptonForm, BlurValues blurValues)
        {
            _parentForm = kryptonForm;
            _blurValues = blurValues;

            _parentForm.Closing += KryptonFormOnClosing;
            _detectIsActiveTimer = new Timer { Enabled = false, Interval = 200 };
            _detectIsActiveTimer.Tick += DetectIsTopMost;

            _blurValues.BlurWhenFocusLostChanged += BlurValues_EnableBlurChanged;
            _blurValues.OpacityChanged += BlurValuesOnOpacityChanged;
        }

        internal void SetBlurState(bool parentIsActive)
        {
            if (_parentForm.IsDisposed
                || _parentForm.Disposing)
            {
                return;
            }

            if (_blurValues.BlurWhenFocusLost
                && !parentIsActive
               )
            {
                DoTheBlur();
            }
            else
            {
                RemoveBlur();
            }
        }

        #endregion Identity

        private void KryptonFormOnClosing(object sender, /*Cancel*/EventArgs e) => RemoveBlur();

        private void RemoveBlur()
        {
            if (!_parentForm.IsDisposed
                && !_parentForm.Disposing
                && _parentBeforeOpacity.HasValue
               )
            {
                _parentForm.Opacity = _parentBeforeOpacity.Value;
                _parentBeforeOpacity = null;
            }

            _detectIsActiveTimer.Enabled = false;
            if (_visualBlur != null)
            {
                _visualBlur.Visible = false;
                _visualBlur.Dispose();
                _visualBlur = null;
            }
        }

        public bool IsOverlapped()
        {
            if (_blurValues.BlurWhenFocusLost
                || !PlatformInvoke.IsWindowVisible(_parentForm.Handle)
                )
            {
                return false;
            }

            IntPtr hWnd = _parentForm.Handle;
            // The set is used to make calling GetWindow in a loop stable by checking if we have already
            //  visited the window returned by GetWindow. This avoids the possibility of an infinite loop.
            var visited = new HashSet<IntPtr> { hWnd };
            try
            {
                Form activeForm = Form.ActiveForm;
                if (activeForm != null)
                {
                    visited.Add(activeForm.Handle);
                }

                visited.Add(_visualBlur.Handle);


                PlatformInvoke.RECT thisRect = new();
                PlatformInvoke.GetWindowRect(hWnd, ref thisRect);

                while ((hWnd = PlatformInvoke.GetWindow(hWnd, PlatformInvoke.GetWindowType.GW_HWNDPREV)) != IntPtr.Zero
                       && !visited.Contains(hWnd))
                {
                    visited.Add(hWnd);
                    PlatformInvoke.RECT testRect = new();
                    if (PlatformInvoke.IsWindowVisible(hWnd)
                        && PlatformInvoke.GetWindowRect(hWnd, ref testRect)
                        && PlatformInvoke.IntersectRect(out _, ref thisRect, ref testRect)
                       )
                    {
                        return true;
                    }
                }

                return false;
            }
            finally
            {
                // Attempt to clear sooner to allow handles to be released.
                visited.Clear();
                visited = null;
            }
        }

        private void BlurValuesOnOpacityChanged(object sender, EventArgs e)
        {
            if (_visualBlur != null)
            {
                _visualBlur.Visible = false;
                DoTheBlur();
            }
        }

        private void BlurValues_EnableBlurChanged(object sender, EventArgs e)
        {
            if (!_blurValues.BlurWhenFocusLost)
            {
                RemoveBlur();
            }
        }

        private void DetectIsTopMost(object sender, EventArgs e)
        {
            if ((_visualBlur != null)
                && IsOverlapped()
                    )
            {
                RemoveBlur();
            }
        }

        private void DoTheBlur()
        {
            if (!_blurValues.BlurWhenFocusLost
                || _parentForm.IsDisposed
                || _parentForm.Disposing
                )
            {
                // Has blur been turned off ?
                return;
            }
            _visualBlur = new VisualBlur(_blurValues);
            Rectangle clientRectangle = CommonHelper.RealClientRectangle(_parentForm.Handle);
            _visualBlur.SetTargetRect(_parentForm.DesktopLocation, clientRectangle);

            Rectangle targetRect = _visualBlur.TargetRect;
            _visualBlur.UpdateBlur(_currentFormDisplay);
            // As UpdateBlur can take a few moments, then it is possible for the app to be closed before getting to the next line
            if ((_visualBlur == null)
                || _parentForm.IsDisposed
                || _parentForm.Disposing
               )
            {
                return;
            }

            PlatformInvoke.SetWindowPos(_visualBlur.Handle, PlatformInvoke.HWND_TOP,//.HWND_TOPMOST,
            //PlatformInvoke.SetWindowPos(_visualBlur.Handle, _parentForm.Handle,
                targetRect.X, targetRect.Y, targetRect.Width, targetRect.Height,
                PlatformInvoke.SWP_.NOACTIVATE
                | PlatformInvoke.SWP_.NOREDRAW
                | PlatformInvoke.SWP_.SHOWWINDOW
                | PlatformInvoke.SWP_.NOCOPYBITS
            //| PlatformInvoke.SWP_.NOOWNERZORDER
            );
            // Set parent form opacity afterwards to prevent flicker
            _parentBeforeOpacity ??= _parentForm.Opacity;

            _parentForm.Opacity = _blurValues.Opacity / 100.0;
            _detectIsActiveTimer.Enabled = true;

        }

        internal void TakeSnapshot()
        {
            _currentFormDisplay?.Dispose();
            if (!_blurValues.BlurWhenFocusLost
                || _parentForm.IsDisposed
                || _parentForm.Disposing
                )
            {
                // Has blur been turned off ?
                _currentFormDisplay = null;
                return;
            }
            Rectangle clientRectangle = CommonHelper.RealClientRectangle(_parentForm.Handle);
            _currentFormDisplay = TakeSnapshot(VisualBlur.GetTargetRectangle(_parentForm.DesktopLocation, clientRectangle));
        }

        private static Bitmap TakeSnapshot(Rectangle targetRectangle)
        {
            Bitmap bmp = new(targetRectangle.Width, targetRectangle.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(targetRectangle.Left, targetRectangle.Top, 0, 0, bmp.Size);
            return bmp;
        }

    }
}