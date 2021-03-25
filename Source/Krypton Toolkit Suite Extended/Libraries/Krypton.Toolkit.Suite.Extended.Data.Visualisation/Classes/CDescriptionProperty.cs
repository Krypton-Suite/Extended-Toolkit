#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    public class CDescriptionProperty
    {
        private string text;
        public string Text
        {
            get { return text; }
            set { text = value; }
        }

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

        public CDescriptionProperty()
        {

            Font = new Font("Tahoma", 14, FontStyle.Bold);
            Colour = Color.FromArgb(255, 255, 255, 255);
            Text = string.Empty;
            Visible = true;
        }

        private CDescriptionProperty m_clone = null;

        public void SaveObject()
        {
            m_clone = new CDescriptionProperty();
            m_clone.Text = this.Text;
            m_clone.Visible = this.Visible;
            m_clone.Font = this.Font;
            m_clone.Colour = this.Colour;
        }

        public void RestoreObject()
        {
            if (m_clone != null)
            {
                this.Text = m_clone.Text;
                this.Visible = m_clone.Visible;
                this.Font = m_clone.Font;
                this.Colour = m_clone.Colour;
            }
        }
    }
}
