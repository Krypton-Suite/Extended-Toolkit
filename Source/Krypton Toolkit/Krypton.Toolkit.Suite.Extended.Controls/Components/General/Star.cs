#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Collections.Generic;

namespace Krypton.Toolkit.Suite.Extended.Controls
{
    internal class Star : PictureBox
    {
        private Container _components;
        public int StarNumber { get; private set; }

        private enum States { Off, On }

        private readonly Dictionary<States, Image> _stars;

        private readonly Action<int> _clicked;
        private readonly Action<int> _mouseEnter;
        private readonly Action<int> _mouseLeave;

        internal Star(int starNumber, Image offImage, Image onImage, Action<int> clicked, Action<int> mouseEnter, Action<int> mouseLeave)
        {
            Size = new Size(offImage.Width, offImage.Height);
            Left = (Width * (starNumber - 1));

            _stars = new Dictionary<States, Image>
                        {
                            {States.On, onImage},
                            {States.Off, offImage}
                        };
            StarNumber = starNumber;
            Image = _stars[States.Off];

            _clicked = clicked;
            _mouseEnter = mouseEnter;
            _mouseLeave = mouseLeave;


            InitializeComponent();
        }

        public void ToggleStar(int starNumber)
        {
            Image = StarNumber > starNumber ? _stars[States.Off] : _stars[States.On];
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            _mouseEnter(StarNumber);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            _mouseLeave(StarNumber);
        }

        protected override void OnClick(EventArgs e)
        {
            _clicked(StarNumber);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            _components = new Container();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_components != null)
                {
                    _components.Dispose();
                }
            }

            base.Dispose(disposing);
        }
        #endregion
    }
}