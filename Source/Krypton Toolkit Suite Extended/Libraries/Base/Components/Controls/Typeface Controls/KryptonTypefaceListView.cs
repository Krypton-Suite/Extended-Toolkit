using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Base
{
    public class KryptonTypefaceListView : KryptonListView
    {
        #region Variables
        private int _maxFavourites;

        private ArrayList _favourites;

        private string[] _nonReadable;

        private Image _image;

        private Font _defaultTypeface;

        private StringFormat _nonReadableStringFormat, _standardStringFormat;
        #endregion

        #region Public Properties
        [DefaultValue(null)]
        public Image Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
                Invalidate();
            }
        }

        [Browsable(false)]
        public string[] NonReadableTypefaces
        {
            get => _nonReadable;

            set
            {
                _nonReadable = value;
                Invalidate();
            }
        }

        [DefaultValue(5)]
        public int MaximumFavourites
        {
            get => _maxFavourites;

            set
            {
                _maxFavourites = value;
                Invalidate();
            }
        }

        #endregion

        #region Private Functions
        private void GetTypefaces(Graphics g)
        {
            InstalledFontCollection installedTypefaces = new InstalledFontCollection();

            FontFamily[] fonts = installedTypefaces.Families;
            BeginUpdate();
            string name = "";
            foreach (FontFamily font in fonts)
            {
                name = font.Name.Trim();

                // TODO: Fix this
                //if (!Items.Contains(name))
                //{
                //    Items.Add(name);
                //}
            }
            EndUpdate();
        }

        private void DrawSeperator(Graphics g, Rectangle rect)
        {
            Pen pen = new Pen(ControlPaint.LightLight(ForeColor));
            g.DrawLine(pen, rect.X + 1, rect.Y + rect.Height - 3, rect.X + rect.Width - 2, rect.Y + rect.Height - 3);
            g.DrawLine(pen, rect.X + 1, rect.Y + rect.Height - 1, rect.X + rect.Width - 2, rect.Y + rect.Height - 1);
        }

        private bool IsNonReadableFont(string FontName)
        {
            foreach (string non in _nonReadable)
            {
                if (FontName == non)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion
    }
}