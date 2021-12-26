#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
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