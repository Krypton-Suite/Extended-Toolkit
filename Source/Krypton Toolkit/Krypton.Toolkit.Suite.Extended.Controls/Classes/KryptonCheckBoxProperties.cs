#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2024 - 2024 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Controls
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class KryptonCheckBoxProperties
    {
        #region Identity

        public KryptonCheckBoxProperties()
        {
        }

        #endregion

        #region Instance Fields

        private Appearance _appearance = Appearance.Normal;
        private bool _autoSize = false;
        private bool _autoCheck = true;
        private bool _autoEllipsis = false;
        private ContentAlignment _checkAlign = ContentAlignment.MiddleLeft;
        private Color _flatAppearanceBorderColor = Color.Empty;
        private int _flatAppearanceBorderSize = 1;
        private Color _flatAppearanceCheckedBackColor = Color.Empty;
        private Color _flatAppearanceMouseDownBackColor = Color.Empty;
        private Color _flatAppearanceMouseOverBackColor = Color.Empty;
        private FlatStyle _flatStyle = FlatStyle.Standard;
        private Color _foreColor = SystemColors.ControlText;
        private RightToLeft _rightToLeft = RightToLeft.No;
        private ContentAlignment _textAlign = ContentAlignment.MiddleLeft;
        private bool _threeState = false;

        #endregion

        #region Public

        [DefaultValue(Appearance.Normal)]
        public Appearance Appearance
        {
            get { return _appearance; }
            set
            {
                _appearance = value;
                OnPropertyChanged();
            }
        }

        [DefaultValue(true)]
        public bool AutoCheck
        {
            get { return _autoCheck; }
            set
            {
                _autoCheck = value;
                OnPropertyChanged();
            }
        }

        [DefaultValue(false)]
        public bool AutoEllipsis
        {
            get { return _autoEllipsis; }
            set
            {
                _autoEllipsis = value;
                OnPropertyChanged();
            }
        }

        [DefaultValue(false)]
        public bool AutoSize
        {
            get { return _autoSize; }
            set
            {
                _autoSize = true;
                OnPropertyChanged();
            }
        }

        [DefaultValue(ContentAlignment.MiddleLeft)]
        public ContentAlignment CheckAlign
        {
            get { return _checkAlign; }
            set
            {
                _checkAlign = value;
                OnPropertyChanged();
            }
        }

        [DefaultValue(typeof(Color), "")]
        public Color FlatAppearanceBorderColor
        {
            get { return _flatAppearanceBorderColor; }
            set
            {
                _flatAppearanceBorderColor = value;
                OnPropertyChanged();
            }
        }

        [DefaultValue(1)]
        public int FlatAppearanceBorderSize
        {
            get { return _flatAppearanceBorderSize; }
            set
            {
                _flatAppearanceBorderSize = value;
                OnPropertyChanged();
            }
        }

        [DefaultValue(typeof(Color), "")]
        public Color FlatAppearanceCheckedBackColor
        {
            get { return _flatAppearanceCheckedBackColor; }
            set
            {
                _flatAppearanceCheckedBackColor = value;
                OnPropertyChanged();
            }
        }

        [DefaultValue(typeof(Color), "")]
        public Color FlatAppearanceMouseDownBackColor
        {
            get { return _flatAppearanceMouseDownBackColor; }
            set
            {
                _flatAppearanceMouseDownBackColor = value;
                OnPropertyChanged();
            }
        }

        [DefaultValue(typeof(Color), "")]
        public Color FlatAppearanceMouseOverBackColor
        {
            get { return _flatAppearanceMouseOverBackColor; }
            set
            {
                _flatAppearanceMouseOverBackColor = value;
                OnPropertyChanged();
            }
        }

        [DefaultValue(FlatStyle.Standard)]
        public FlatStyle FlatStyle
        {
            get { return _flatStyle; }
            set
            {
                _flatStyle = value;
                OnPropertyChanged();
            }
        }

        [DefaultValue(typeof(SystemColors), "ControlText")]
        public Color ForeColor
        {
            get { return _foreColor; }
            set
            {
                _foreColor = value;
                OnPropertyChanged();
            }
        }

        [DefaultValue(RightToLeft.No)]
        public RightToLeft RightToLeft
        {
            get { return _rightToLeft; }
            set
            {
                _rightToLeft = value;
                OnPropertyChanged();
            }
        }

        [DefaultValue(ContentAlignment.MiddleLeft)]
        public ContentAlignment TextAlign
        {
            get { return _textAlign; }
            set
            {
                _textAlign = value;
                OnPropertyChanged();
            }
        }

        [DefaultValue(false)]
        public bool ThreeState
        {
            get { return _threeState; }
            set
            {
                _threeState = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Implementation

        /// <summary>
        /// Called when any property changes.
        /// </summary>
        public event EventHandler PropertyChanged;

        protected void OnPropertyChanged()
        {
            EventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        #endregion
    }
}