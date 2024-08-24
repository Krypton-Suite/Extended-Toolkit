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

namespace Krypton.Toolkit.Suite.Extended.Navigator
{
    [DesignTimeVisible(false), DefaultProperty("Text")]
    public class OutlookBarButton : IDisposable
    {

        #region " Constructors "

        //Includes a constructor without parameters so the control can be configured during design-time.

        public OutlookBarButton()
        {
            Owner = new OutlookBar();
        }

        public OutlookBarButton(string text, Icon image)
        {
            Owner = new OutlookBar();
            Text = text;
            Image = image;
        }

        internal OutlookBarButton(OutlookBar owner)
        {
            Owner = owner;
        }

        #endregion

        #region " Destructor "

        //The ButtonClass is not inheriting from Control, so I need this destructor...

        // To detect redundant calls
        private bool _disposedValue = false;
        // IDisposable
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // TODO: free unmanaged resources when explicitly called
                }
                //string EmptyLineVar = null;
                // TODO: free shared unmanaged resources
            }
            _disposedValue = true;
        }

        #region " IDisposable Support "
        // This code added by Visual Basic to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #endregion


        //This field lets us react with the parent control.
        internal OutlookBar Owner;

        internal ButtonState State = ButtonState.Passive;

        private string _text;
        private bool _visible = true;
        private bool _allowed = true;
        private Icon? _image = Properties.Resources.DefaultIcon;
        internal Rectangle Rectangle;
        internal bool IsLarge;
        private bool _selected;
        private string _tag1;
        private string _tag2;
        private string? _buddyPage1;
        private string? _buddyPage2;

        [DefaultValue(typeof(string), ""), Browsable(true)]
        public string Tag1
        {
            get => _tag1;
            set => _tag1 = value;
        }

        [DefaultValue(typeof(string), ""), Browsable(true)]
        public string Tag2
        {
            get => _tag2;
            set => _tag2 = value;
        }

        [DefaultValue(typeof(string), ""), Browsable(true)]
        public string BuddyPage1
        {
            get => _buddyPage1 ?? string.Empty;
            set => _buddyPage1 = value;
        }

        [DefaultValue(typeof(string), ""), Browsable(true)]
        public string BuddyPage2
        {
            get => _buddyPage2 ?? string.Empty;
            set => _buddyPage2 = value;
        }

        public string Text
        {
            get => _text;
            set => _text = value;
        }

        [DefaultValue(typeof(bool), "True")]
        public bool Visible
        {
            get => _visible;
            set
            {
                _visible = value;
                if (!value)
                {
                    Rectangle = new Rectangle();
                }
            }

        }

        [DefaultValue(typeof(bool), "False"), Browsable(true)]
        public bool Selected
        {
            get => _selected;
            set
            {
                _selected = value;
                switch (value)
                {
                    case true:
                        Owner._SelectedButton = this;
                        break;
                    case false:
                        Owner._SelectedButton = null;
                        break;
                }
                Owner.SetSelectionChanged(this);
            }
        }

        [DefaultValue(typeof(bool), "True")]
        public bool Allowed
        {
            get => _allowed;
            set
            {
                _allowed = value;
                if (value == false)
                {
                    Visible = false;
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Icon Image
        {
            get
            {
                if (_image == null)
                {
                    return Properties.Resources.DefaultIcon;
                }
                else
                {
                    return _image;
                }
            }
            set => _image = value;
        }

        public override string ToString()
        {
            return Text;
        }

    }


}