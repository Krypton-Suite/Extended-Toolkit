#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Navi.Suite
{
    [
    Designer("Krypton.Toolkit.Suite.Extended.Navi.Suite.NaviBarDesigner, Krypton.Toolkit.Suite.Extended.Navi.Suite, Version=2.0.0.0, Culture=neutral, PublicKeyToken=86dab5aa2dd98116"),
   DefaultEvent("activeBandChanged"),
   DefaultProperty("Bands"),
    //ToolboxItem("Krypton.Toolkit.Extended.Navi.Suite.NaviBarToolboxItem, Krypton.Toolkit.Extended.Navi.Suite, Version=2.0.0.0, Culture=neutral, PublicKeyToken=86dab5aa2dd98116"),	
    ToolboxItem(true),
   ToolboxBitmap(typeof(NaviBar))
   ]
    public class NaviBar : NaviControl, IObservable
    {
        // Fields
        private bool layoutEngineDirty = true;
        private bool bandInitRequired = true;
        private bool showMoreOptionsButton = true;
        private bool collapsed = false;
        private bool showCollapseButton = true;
        private int headerHeight = 27;
        private int minimizedButtonWidth = 25;
        private int minimizedPanelHeight = 32;
        private int buttonHeight = 32;
        private int popupHeight = 100;
        private int popupMinWidth = 50;
        private int visibleLargeButtons;
        private NaviBandCollection bands;
        private NaviBand activeBand;
        private NaviBarSettings settings;
        private NaviLayoutEngine naviLayoutEngine;
        private NaviLayoutStyle layoutStyle;
        private NaviLayoutFactory layoutFactory;
        private NaviBandEventHandler activeBandChanging;
        private EventHandler collapsedBandClick;
        private EventHandler collapsedChanged;
        private EventHandler activeBandChanged;
        private EventHandler layoutChanged;
        private ControlEventHandler bandAdded;
        private ImageList smallImages;
        private ImageList largeImages;

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the NaviBar class
        /// </summary>
        public NaviBar()
        {
            Initialize();
        }

        /// <summary>
        /// Iniializes a new instance of the NaviBar class
        /// </summary>
        /// <param name="container"></param>
        public NaviBar(IContainer container)
        {
            container.Add(this);
            Initialize();
        }

        #endregion

        #region Public Layout Properties

        /// <summary>
        /// Defines how the control is presented to the user
        /// </summary>
        [DefaultValue(NaviLayoutStyle.Office2007Blue)]
        public new NaviLayoutStyle LayoutStyle
        {
            get { return layoutStyle; }
            set
            {
                layoutStyle = value; layoutEngineDirty = true;
                PerformLayout();
                Invalidate();
            }
        }

        // Readonly

        /// <summary>
        /// Gets or sets the LayoutEngine 
        /// </summary>
        [
        Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        ]
        public NaviLayoutEngine NaviLayoutEngine
        {
            get { return naviLayoutEngine; }
            internal set
            {
                if (value == null)
                    layoutEngineDirty = true;
                if (naviLayoutEngine != null)
                    naviLayoutEngine.Cleanup();
                naviLayoutEngine = value;
                observers.Add(naviLayoutEngine);
            }
        }

        /// <summary>
        /// Infrastructure. Gets or sets a reference to internal collection of controls. 
        /// </summary>
        /// <remarks>
        /// This API supports the NaviSuite infrastructure and is not intended to be used directly from your 
        /// code.
        /// </remarks>
        [
        Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        ]
        public NaviControlCollection InternalControls
        {
            get { return Controls as NaviControlCollection; }
        }

        /// <summary>
        /// Infrastructure. Requests the LayoutEngine to reinitialize the bands. 
        /// </summary>
        /// <remarks>
        /// This API supports the NaviSuite infrastructure and is not intended to be used directly from your 
        /// code.
        /// </remarks>
        [
        Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        ]
        public bool BandInitRequired
        {
            get { return bandInitRequired; }
            set { bandInitRequired = value; }
        }

        #endregion

        #region Public View Style Properties

        /// <summary>
        /// Gets or sets the height of the header containing the title
        /// </summary>
        [
        Browsable(true),
        NotifyParentProperty(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DefaultValue(27),
        Category("View"),
        Description("Height of the header containing the title")
        ]
        public int HeaderHeight
        {
            get { return headerHeight; }
            set
            {
                headerHeight = value;
                PerformLayout();
            }
        }

        /// <summary>
        /// Gets or sets the height of the minimized buttons panel
        /// </summary>
        [
        Browsable(true),
        NotifyParentProperty(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DefaultValue(32),
        Category("View"),
        Description("The height of the minimized buttons panel")
        ]
        public int MinimizedPanelHeight
        {
            get { return minimizedPanelHeight; }
            set
            {
                minimizedPanelHeight = value;
                PerformLayout();
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the default height of the buttons
        /// </summary>
        [
        Browsable(true),
        NotifyParentProperty(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DefaultValue(32),
        Category("View"),
        Description("The default height of the buttons")
        ]
        public int ButtonHeight
        {
            get { return buttonHeight; }
            set
            {
                buttonHeight = value;
                PerformLayout();
            }
        }

        /// <summary>
        /// Gets or sets the height of the popup shown when clicking on collapsed bar
        /// </summary>
        [
        Browsable(true),
        NotifyParentProperty(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DefaultValue(100),
        Category("View"),
        Description("The height of the popup shown when the user clicks on the collapsed Navigation pane")
        ]
        public int PopupHeight
        {
            get { return popupHeight; }
            set
            {
                popupHeight = value;
                PerformLayout();
            }
        }

        /// <summary>
        /// Gets or sets the minimum width of the popup shown when clicking on collapsed bar
        /// </summary>
        [
        Browsable(true),
        NotifyParentProperty(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DefaultValue(50),
        Category("View"),
        Description("The minimum width of the popup shown when clicking on collapsed bar")
        ]
        public int PopupMinWidth
        {
            get { return popupMinWidth; }
            set
            {
                popupMinWidth = value;
                PerformLayout();
            }
        }
        //TODO
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual ImageList SmallImages
        {
            get { return smallImages; }
            set { smallImages = value; }
        }
        //TODO
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual ImageList LargeImages
        {
            get { return largeImages; }
            set { largeImages = value; }
        }

        // Read only

        /// <summary>
        /// Gets or sets the width of the minimized buttons
        /// </summary>
        [
        Browsable(false),
        NotifyParentProperty(true),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        DefaultValue(25),
        ]
        public int MinimizedButtonWidth
        {
            get { return minimizedButtonWidth; }
            set { minimizedButtonWidth = value; }
        }

        #endregion

        #region Public Behavior Properties

        /// <summary>
        /// Gets or sets whether to show the more options button or not
        /// </summary>
        [
        Browsable(true),
        NotifyParentProperty(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DefaultValue(true),
        Category("Navigation"),
        Description("Indicates whether the show more options button is visible or not")
        ]
        public bool ShowMoreOptionsButton
        {
            get { return showMoreOptionsButton; }
            set
            {
                showMoreOptionsButton = value;
                PerformLayout();
            }
        }

        /// <summary>
        /// Gets or sets whether the pane is minimized or not
        /// </summary>
        [
        Browsable(true),
        NotifyParentProperty(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DefaultValue(false),
        Category("Navigation"),
        Description("Indicates whether the Navigation Panel is minimized or not")
        ]
        public bool Collapsed
        {
            get { return collapsed; }
            set
            {
                bool raise = collapsed != value;
                collapsed = value;

                if (raise) OnCollapsedChanged(new EventArgs());

                PerformLayout();
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets whether to show the collapse button or not
        /// </summary>
        [
        Browsable(true),
        NotifyParentProperty(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DefaultValue(true),
        Category("Navigation"),
        Description("Indicates whether to show the collapse button or not")
        ]
        public bool ShowCollapseButton
        {
            get { return showCollapseButton; }
            set
            {
                showCollapseButton = value;
                PerformLayout();
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the amount of visible large buttons
        /// </summary>
        [
        Browsable(true),
        NotifyParentProperty(true),
        EditorBrowsable(EditorBrowsableState.Always),
        DefaultValue(0),
        Category("Navigation"),
        Description("The amount of large visible buttons")
        ]
        public int VisibleLargeButtons
        {
            get { return visibleLargeButtons; }
            set
            {
                visibleLargeButtons = value;
                PerformLayout();
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the settings file
        /// </summary>
        [
        Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
        ]
        public NaviBarSettings Settings
        {
            get
            {
                if (settings == null)
                    settings = new NaviBarSettings();
                settings.BandSettings.Clear();
                settings.VisibleButtons = visibleLargeButtons;
                settings.Collapsed = collapsed;

                // Make sure we have the correct ordering
                for (int i = 0; i < bands.Count; i++)
                    bands[i].Order = i;

                foreach (NaviBand band in bands)
                {
                    NaviBandSetting setting = new NaviBandSetting();

                    setting.Name = band.Text;
                    setting.Order = band.Order;
                    setting.Visible = band.Visible;

                    settings.BandSettings.Add(setting);
                }

                return settings;
            }
            set
            {
                settings = value;
            }
        }

        #endregion

        #region Public General Properties

        /// <summary>
        /// Gets or sets the collection of bands. 
        /// </summary>
        /// <remarks>
        /// Changes to the bands collection will be applied to the controls collection as well 
        /// and vice versa
        /// </remarks>
        [
        Browsable(true),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        Category("General"),
        Description("The bands of this Navigaion bar")
        ]
        public NaviBandCollection Bands
        {
            get { return bands; }
        }

        /// <summary>
        /// Gets or sets the active band
        /// </summary>
        [
        Browsable(true),
        Category("Navigation"),
        Description("The active band")
        ]
        public NaviBand ActiveBand
        {
            get { return activeBand; }
            set { SetActiveBand(value); }
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs before the active band is changed
        /// </summary>
        [
        Category("Navigation"),
        Description("Occurs before the active band is changed")
        ]
        public event NaviBandEventHandler ActiveBandChanging
        {
            add { lock (threadLock) { activeBandChanging += value; } }
            remove { lock (threadLock) { activeBandChanging -= value; } }
        }

        /// <summary>
        /// Occurs after the active band has been changed
        /// </summary>
        [
        Category("Navigation"),
        Description("Occurs after the active band has been changed")
        ]
        public event EventHandler ActiveBandChanged
        {
            add { lock (threadLock) { activeBandChanged += value; } }
            remove { lock (threadLock) { activeBandChanged -= value; } }
        }

        /// <summary>
        /// Occurs when the layout has been changed
        /// </summary>
        [
        Category("Navigation"),
        Description("Occurs when the layout has been changed")
        ]
        public event EventHandler LayoutChanged
        {
            add { lock (threadLock) { layoutChanged += value; } }
            remove { lock (threadLock) { layoutChanged -= value; } }
        }

        /// <summary>
        /// Occurs after a new band has been added to the collection of bands
        /// </summary>
        [
        Category("Navigation"),
        Description("Occurs after a new band has been added to the collection of bands")
        ]
        public event ControlEventHandler BandAdded
        {
            add { lock (threadLock) { bandAdded += value; } }
            remove { lock (threadLock) { bandAdded -= value; } }
        }

        /// <summary>
        /// Occurs when clicking on the band when the bar is collapsed
        /// </summary>
        [
        Category("Navigation"),
        Description("Occurs when clicking on the band when the bar is collapsed")
        ]
        public event EventHandler CollapsedBandClick
        {
            add { lock (threadLock) { collapsedBandClick += value; } }
            remove { lock (threadLock) { collapsedBandClick -= value; } }
        }

        /// <summary>
        /// Occurs when the value of collapsed has been changed
        /// </summary>
        [
        Category("Navigation"),
        Description("Occurs when the value of collapsed has been changed")
        ]
        public event EventHandler CollapsedChanged
        {
            add { lock (threadLock) { collapsedChanged += value; } }
            remove { lock (threadLock) { collapsedChanged -= value; } }
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Initializes the control for the first time
        /// </summary>
        private void Initialize()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);

            bands = new NaviBandCollection(this);
            layoutFactory = new NaviLayoutFactory(this);
            smallImages = new ImageList();
            largeImages = new ImageList();
        }

        #endregion

        #region Public General Methods

        /// <summary>
        /// Changes the currently active band to a given band
        /// </summary>
        /// <param name="band">The band to activate</param>
        public void SetActiveBand(NaviBand newBand)
        {
            NaviBandEventArgs e = new NaviBandEventArgs(newBand);
            OnActiveBandChanging(e);
            if (!e.Canceled)
            {
                if (activeBand != newBand)
                {
                    foreach (NaviBand band in bands)
                    {
                        if ((band != newBand) && (band.Button != null))
                        {
                            band.Button.Active = false;
                        }
                    }
                }
                if ((newBand != null) && (newBand.Button != null))
                {
                    newBand.Button.Active = true;
                }

                activeBand = newBand;
                OnActiveBandChanged(new EventArgs());
                PerformLayout();
                Invalidate();
            }
        }

        #endregion

        #region Public Settings Methods

        /// <summary>
        /// Applies the settings currently loaded in the Settings property
        /// </summary>
        /// <remarks>
        /// It's possible that no setting exist for this particular band. For example a new
        /// version has been released. Then this band is added at the end of the collection 
        /// and visible is set to true
        /// </remarks>
        public void ApplySettings()
        {
            SuspendLayout();

            if (settings == null)
                return;

            foreach (NaviBand band in bands)
            {
                // try to find the setting
                NaviBandSetting setting = null;
                foreach (NaviBandSetting tmpSetting in settings.BandSettings)
                {
                    if (tmpSetting.Name.ToLower() == band.Text.ToLower())
                        setting = tmpSetting;
                }

                // It's possible that no setting exist for this particular band. For example a new
                // version has been released. Then this band is added at the end of the collection 
                // and visible is set to true
                if (setting == null)
                {
                    band.Order = 999;
                    band.Visible = true;
                }
                else
                {
                    band.Visible = setting.Visible;
                    band.Order = setting.Order;
                }
            }

            VisibleLargeButtons = settings.VisibleButtons;
            if (settings.Collapsed != collapsed)
                Collapsed = settings.Collapsed;
            bands.Sort(new NaviBandOrderComparer());

            // Rebuild ordering values. This is to prevent 999 and duplicate values from showing 
            // up in the settings file
            for (int i = 0; i < bands.Count; i++)
                bands[i].Order = i;

            ResumeLayout();
        }

        #endregion

        #region Protected Event Methods

        /// <summary>
        /// Raises the ActiveBandChanging event
        /// </summary>
        /// <param name="e">Additional event info</param>
        internal void OnActiveBandChanging(NaviBandEventArgs e)
        {
            NaviBandEventHandler handler = activeBandChanging;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// Raises the ActiveBandChanged event
        /// </summary>
        /// <param name="e">Additional event info</param>
        internal void OnActiveBandChanged(EventArgs e)
        {
            EventHandler handler = activeBandChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// Raises the BandAdded event
        /// </summary>
        /// <param name="e">Additional event info</param>
        internal void OnBandAdded(ControlEventArgs e)
        {
            ControlEventHandler handler = bandAdded;
            if (handler != null)
            {
                handler(this, e);
            }
        }


        /// <summary>
        /// Raises the CSollapsedBandClick event
        /// </summary>
        /// <param name="e">Additional event info</param>
        internal void OnCollapsedBandClick(EventArgs e)
        {
            EventHandler handler = collapsedBandClick;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// Raises the CollapsedChanged event
        /// </summary>
        /// <param name="e">Additional event info</param>
        internal void OnCollapsedChanged(EventArgs e)
        {
            EventHandler handler = collapsedChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        #region Overloaded Methods

        /// <summary>
        /// Overloaded. Creates a new instance of the NaviControlCollection collection
        /// </summary>
        /// <returns>A new instance of the NaviControlCollection class</returns>
        protected override Control.ControlCollection CreateControlsInstance()
        {
            return new NaviControlCollection(this);
        }

        /// <summary>
        /// Overloaded. Raises the Layout event
        /// </summary>
        /// <param name="e">Additional event info</param>
        protected override void OnLayout(LayoutEventArgs e)
        {
            base.OnLayout(e);
            if ((layoutEngineDirty) && !(layoutFactory == null))
            {
                layoutFactory.ReinitializeLayout();
                layoutEngineDirty = false;
            }
            naviLayoutEngine.Layout(this, e);
        }

        #endregion

        #region Overloaded Mouse Methods

        /// <summary>
        /// Overloaded. Raises the MouseDown event
        /// </summary>
        /// <param name="e">Additional mouse info</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            NotifyObservers(this, "MouseDown", e);
        }

        /// <summary>
        /// Overloaded. Raises the MouseDown event.
        /// </summary>
        /// <param name="e">Additional mouse info</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            NotifyObservers(this, "MouseMove", e);
        }

        /// <summary>
        /// Overloaded. Raises the MouseLeave event and changes the cursor back to default
        /// </summary>
        /// <param name="e">Additional mouse info</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            NotifyObservers(this, "MouseLeave", e);
        }

        /// <summary>
        /// Overloaded. Raises the MouseUp event
        /// </summary>
        /// <param name="e">Additional mouse info</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            NotifyObservers(this, "MouseUp", e);
        }

        #endregion

        #region Overloaded Drawing Methods

        /// <summary>
        /// Overriden. Raises the Paint event
        /// </summary>
        /// <param name="e">Additional paint info</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (naviLayoutEngine != null)
            {
                naviLayoutEngine.Draw(e.Graphics);
            }
        }

        /// <summary>
        /// Overriden. Raises the PaintBackground
        /// </summary>
        /// <param name="pevent">Additional paint info</param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            if (naviLayoutEngine != null)
            {
                naviLayoutEngine.DrawBackground(e.Graphics);
            }
        }

        #endregion

        #region IObservable Members

        private List<IObserver> observers = new List<IObserver>();

        /// <summary>
        /// Gets the list of observers
        /// </summary>
        public List<IObserver> Observers
        {
            get { return observers; }
        }

        /// <summary>
        /// Notifies the Observers
        /// </summary>
        /// <param name="obj">The observable object</param>
        /// <param name="id">An identification which caused this notification</param>
        /// <param name="arguments">Additional arguments</param>
        public void NotifyObservers(IObservable obj, string id, object arguments)
        {
            foreach (IObserver observer in observers)
                observer.Notify(obj, id, arguments);
        }

        #endregion

        #region Class NaviBandControlCollection

        /// <summary>
        /// Infrastructure. Represents a collection of NaviBands. 
        /// </summary>
        /// <remarks>
        /// This API supports the NaviSuite infrastructure and is not intended to be used directly from your 
        /// code.
        /// </remarks>
        public class NaviControlCollection : Control.ControlCollection
        {
            private NaviBar ownerBar;

            /// <summary>
            /// Initializes a new instance of the NaviControlCollection class 
            /// </summary>
            /// <param name="owner">The parent control</param>
            public NaviControlCollection(Control owner)
               : base(owner)
            {
                if (owner is NaviBar)
                    ownerBar = (NaviBar)owner;
            }

            /// <summary>
            /// Overloaded. Adds a new control to the collection
            /// </summary>
            /// <param name="value">The control to add</param>
            public override void Add(System.Windows.Forms.Control value)
            {
                Owner.SuspendLayout();

                base.Add(value);

                if (value is NaviBand)
                {
                    NaviBand newBand = value as NaviBand;

                    if (!ownerBar.bands.Contains(newBand))
                        ownerBar.Bands.AddInternal(newBand);

                    newBand.OwnerBar = ownerBar;
                    ownerBar.BandInitRequired = true;
                }

                Owner.ResumeLayout();
            }

            /// <summary>
            /// Overloaded. Removes a control from the collection
            /// </summary>
            /// <param name="value">The control to remove</param>
            public override void Remove(Control value)
            {
                Owner.SuspendLayout();
                base.Remove(value);

                if (value is NaviBand)
                {
                    ownerBar.Bands.RemoveInternal(value as NaviBand);
                    ownerBar.BandInitRequired = true;
                }

                Owner.ResumeLayout();
            }
        }

        #endregion
    }
}