using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    public class CValueProperty
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

        public enum ValueMode
        {
            Digit,      // Display the value of each bar at the top of it
            Percent     // Display a percentage depending on the other values
        }
        private ValueMode mode;
        public ValueMode Mode
        {
            get { return mode; }
            set { mode = value; }
        }

        public CValueProperty()
        {
            Mode = ValueMode.Digit;
            Font = new Font("Tahoma", 7);
            Colour = Color.FromArgb(255, 255, 255, 255);
            Visible = true;
        }

        private CValueProperty m_clone = null;

        public void SaveObject()
        {
            m_clone = new CValueProperty();
            m_clone.Visible = this.Visible;
            m_clone.Font = this.Font;
            m_clone.Colour = this.Colour;
            m_clone.Mode = this.Mode;
        }

        public void RestoreObject()
        {
            if (m_clone != null)
            {
                this.Visible = m_clone.Visible;
                this.Font = m_clone.Font;
                this.Colour = m_clone.Colour;
                this.Mode = m_clone.Mode;
            }
        }
    }
}