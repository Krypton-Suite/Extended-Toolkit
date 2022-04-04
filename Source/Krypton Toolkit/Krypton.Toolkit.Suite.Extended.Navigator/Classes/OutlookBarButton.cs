#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
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
            this.Owner = new OutlookBar();
        }

        public OutlookBarButton(string text, Icon image)
        {
            this.Owner = new OutlookBar();
            this.Text = text;
            this.Image = image;
        }

        internal OutlookBarButton(OutlookBar owner)
        {
            this.Owner = owner;
        }

        #endregion

        #region " Destructor "

        //The ButtonClass is not inheriting from Control, so I need this destructor...

        // To detect redundant calls
        private bool disposedValue = false;
        // IDisposable
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    // TODO: free unmanaged resources when explicitly called
                }
                //string EmptyLineVar = null;
                // TODO: free shared unmanaged resources
            }
            this.disposedValue = true;
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

        private string _Text;
        private bool _Visible = true;
        private bool _Allowed = true;
        private Icon _Image = Properties.Resources.DefaultIcon;
        internal Rectangle Rectangle;
        internal bool isLarge;
        private bool _Selected;
        private string _Tag1;
        private string _Tag2;
        private string _BuddyPage1;
        private string _BuddyPage2;

        [DefaultValue(typeof(string), ""), Browsable(true)]
        public string Tag1
        {
            get { return this._Tag1; }
            set { this._Tag1 = value; }
        }

        [DefaultValue(typeof(string), ""), Browsable(true)]
        public string Tag2
        {
            get { return this._Tag2; }
            set { this._Tag2 = value; }
        }

        [DefaultValue(typeof(string), ""), Browsable(true)]
        public string BuddyPage1
        {
            get { return this._BuddyPage1; }
            set { this._BuddyPage1 = value; }
        }

        [DefaultValue(typeof(string), ""), Browsable(true)]
        public string BuddyPage2
        {
            get { return this._BuddyPage2; }
            set { this._BuddyPage2 = value; }
        }

        public string Text
        {
            get { return this._Text; }
            set { this._Text = value; }
        }

        [DefaultValue(typeof(bool), "True")]
        public bool Visible
        {
            get
            {
                return this._Visible;
            }
            set
            {
                this._Visible = value;
                if (!value)
                {
                    this.Rectangle = new Rectangle();
                }
            }

        }

        [DefaultValue(typeof(bool), "False"), Browsable(true)]
        public bool Selected
        {
            get { return this._Selected; }
            set
            {
                this._Selected = value;
                switch (value)
                {
                    case true:
                        this.Owner._SelectedButton = this;
                        break;
                    case false:
                        this.Owner._SelectedButton = null;
                        break;
                }
                Owner.SetSelectionChanged(this);
            }
        }

        [DefaultValue(typeof(bool), "True")]
        public bool Allowed
        {
            get { return this._Allowed; }
            set
            {
                this._Allowed = value;
                if (value == false)
                {
                    this.Visible = false;
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Icon Image
        {
            get
            {
                if (this._Image == null)
                {
                    return Properties.Resources.DefaultIcon;
                }
                else
                {
                    return this._Image;
                }
            }
            set { this._Image = value; }
        }

        public override string ToString()
        {
            return this.Text;
        }

    }


}