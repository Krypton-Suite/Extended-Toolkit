#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    public class CLabelProperty
    {
        private bool bVisible;
        public bool Visible
        {
            get { return bVisible; }
            set { bVisible = value; }
        }

        private Font font;
        public Font Font
        {
            get { return font; }
            set { font = value; }
        }

        private Color colour;
        public Color Colour
        {
            get { return colour; }
            set { colour = value; }
        }

        public CLabelProperty()
        {

            Font = new Font("Tahoma", 8, FontStyle.Bold);
            Colour = Color.FromArgb(255, 255, 255, 255);
            Visible = true;
        }

        private CLabelProperty m_clone = null;

        public void SaveObject()
        {
            m_clone = new CLabelProperty();
            m_clone.Visible = this.Visible;
            m_clone.Font = this.Font;
            m_clone.Colour = this.Colour;
        }

        public void RestoreObject()
        {
            if (m_clone != null)
            {
                this.Visible = m_clone.Visible;
                this.Font = m_clone.Font;
                this.Colour = m_clone.Colour;
            }
        }
    }
}