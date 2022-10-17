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

namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities
{
    [ToolboxBitmap(typeof(KryptonTrackBar))]
    public class KryptonBlueTrackBar : KryptonTrackBar
    {
        #region Variables
        private bool _useAccessibleUI;
        #endregion

        #region Properties
        public bool UseAccessibleUI { get => _useAccessibleUI; set { _useAccessibleUI = value; Invalidate(); } }
        #endregion

        #region Constructor
        public KryptonBlueTrackBar()
        {
            Maximum = 255;

            TickStyle = TickStyle.None;

            Size = new Size(182, 27);
        }
        #endregion

        #region Methods
        private void AlterTrackbarUI(bool useAccessibleUI)
        {
            if (useAccessibleUI)
            {
                StateCommon.Tick.Color1 = Color.Empty;

                StateCommon.Track.Color1 = Color.Empty;

                StateCommon.Track.Color2 = Color.Empty;

                StateCommon.Track.Color3 = Color.Empty;

                StateCommon.Track.Color4 = Color.Empty;

                StateCommon.Track.Color5 = Color.Empty;
            }
            else
            {
                StateCommon.Tick.Color1 = Color.Blue;

                StateCommon.Track.Color1 = Color.Blue;

                StateCommon.Track.Color2 = Color.Blue;

                StateCommon.Track.Color3 = Color.Blue;

                StateCommon.Track.Color4 = Color.Blue;

                StateCommon.Track.Color5 = Color.Blue;
            }
        }
        #endregion

        #region Overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            AlterTrackbarUI(_useAccessibleUI);

            base.OnPaint(e);
        }
        #endregion
    }
}