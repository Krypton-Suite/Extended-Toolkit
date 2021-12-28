#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Navi.Suite
{
    public class NaviLayoutEngineOffice : NaviLayoutEngine
    {
        // Fields
        private Rectangle splitterRectangle; // Defines the rectangle with the splitter
        private Rectangle smallButtonRectangle; // Defines the rectangle containing the compact buttons
        private Rectangle headerRectangle; // Defines the total header 
        private Rectangle headerTextRectangle; // Defines the header containing 
        private NaviButtonOptions optionsButton;
        private NaviButtonCollapse collapseButton;
        private NaviBandCollapsed collapsedBand;
        private NaviBandPopup popup;
        private NaviContextMenu optionsMenu;
        private ToolStripMenuItem miShowMoreButtons;
        private ToolStripMenuItem miShowLessButtons;
        private ToolStripMenuItem miShowMoreOptions;
        private ToolStripMenuItem miAddOrRemoveButtons;
        private ToolStripSeparator miSep;
        private PopupWindowHelper popupHelper = null;
        private readonly object threadLock = new object();
        private NaviBandEnumerator ienum;
        private Font headerFont = new Font("Arial", 11F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
        private NaviRenderer renderer;
        private int splitterHeight = 8;
        private int optionButtonWidth = 18;
        private int orgWidth;
        private int splitterPosition;
        private bool splitterDragging;
        private bool showNeverCollapse = false;
        private bool currentCollapseState = false;
        private int visibleButtonCount;
        private int largeButtonCount;
        private int overflowCount;
        private int menuCount;

        #region Constructor

        public NaviLayoutEngineOffice(NaviBar owner)
            : base(owner)
        {
        }

        #endregion

        #region Public Properties

        public NaviBar Bar
        {
            get { return OwnerBar; }
        }

        #endregion

        #region General Initialization Methods

        /// <summary>
        /// Initializes the LayoutEngine
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            renderer = new NaviOffice7Renderer();

            switch (OwnerBar.LayoutStyle)
            {
                // TODO Initialize renderer
                case NaviLayoutStyle.Office2003Blue:
                case NaviLayoutStyle.Office2003Green:
                case NaviLayoutStyle.Office2003Silver:
                    renderer = new NaviOffice3Renderer();
                    splitterHeight = 8;
                    renderer.Initialize(OwnerBar.LayoutStyle);
                    break;
                case NaviLayoutStyle.Office2007Blue:
                case NaviLayoutStyle.Office2007Silver:
                case NaviLayoutStyle.Office2007Black:
                    renderer = new NaviOffice7Renderer();
                    splitterHeight = 8;
                    renderer.Initialize(OwnerBar.LayoutStyle);
                    break;
                case NaviLayoutStyle.Office2010Blue:
                case NaviLayoutStyle.Office2010Silver:
                case NaviLayoutStyle.Office2010Black:
                    renderer = new NaviOffice10Renderer();
                    splitterHeight = 6;
                    renderer.Initialize(OwnerBar.LayoutStyle);
                    break;
                default:
                    break;
            }

            foreach (NaviBand band in Bar.Bands)
            {
                band.Renderer = renderer;
                if (band.Button != null)
                    band.Button.Renderer = renderer;
            }

            CreateAdditionalControls();
            InitializeAdditionalControls();
        }

        /// <summary>
        /// Initializes the Bands for the first time. 
        /// </summary>
        /// <remarks>
        /// Typically occurs when the collection of Bands has been changed
        /// </remarks>
        public override void InitializeBands()
        {
            foreach (NaviBand band in Bar.Bands)
            {
                if (band.Button == null)
                {
                    band.Button = new NaviButton();
                    band.Button.Click += new EventHandler(Button_Click);
                }

                band.OwnerBar = OwnerBar;
                band.Button.Renderer = renderer;
                band.Renderer = renderer;

                if (!Bar.InternalControls.Contains(band.Button))
                    Bar.Controls.Add(band.Button);

                Bar.BandInitRequired = false;
            }
        }

        /// <summary>
        /// Creates the additional controls, like the options button and the collapse button
        /// </summary>
        public void CreateAdditionalControls()
        {
            if (optionsButton == null)
            {
                optionsButton = new NaviButtonOptions();
                optionsButton.Small = true;
                optionsButton.Click += new EventHandler(optionsButton_Click);
            }

            if (collapseButton == null)
            {
                collapseButton = new NaviButtonCollapse();
                collapseButton.Size = new Size(18, 18);
                collapseButton.Name = "navigationBarCollapseButton1";
                collapseButton.Click += new EventHandler(collapseButton_Click);
            }

            if (collapsedBand == null)
            {
                collapsedBand = new NaviBandCollapsed();
                collapsedBand.Name = "navigationBarBar.CollapsedBand1";
                collapsedBand.Visible = false;
                collapsedBand.MouseUp += new MouseEventHandler(CollapsedBand_MouseUp);
            }

            InitializeMenu();

            if (!Bar.Controls.Contains(optionsButton))
                Bar.Controls.Add(optionsButton);

            if (!Bar.Controls.Contains(collapseButton))
                Bar.Controls.Add(collapseButton);

            if (!Bar.Controls.Contains(collapsedBand))
                Bar.Controls.Add(collapsedBand);
        }

        /// <summary>
        /// Initializes the additional controls, like the options button and the collapse button
        /// </summary>
        public void InitializeAdditionalControls()
        {
            if (collapseButton != null)
                collapseButton.Renderer = renderer;
            if (collapsedBand != null)
                collapsedBand.Renderer = renderer;
            if (optionsButton != null)
                optionsButton.Renderer = renderer;
        }

        /// <summary>
        /// Disposes the additional controls, like the options button and the collapse button
        /// </summary>
        public void DisposeAdditionalControls()
        {
            if (Bar.Controls.Contains(optionsButton))
                Bar.Controls.Remove(optionsButton);
            if (Bar.Controls.Contains(collapseButton))
                Bar.Controls.Remove(collapseButton);
            if (Bar.Controls.Contains(collapsedBand))
                Bar.Controls.Remove(collapsedBand);
        }

        public override void Cleanup()
        {
            base.Cleanup();
            DisposeAdditionalControls();
        }

        #endregion

        #region General Layout Methods

        /// <summary>
        /// Recalculates the size and positions of the small button rectangle
        /// </summary>
        private void CalculateRegions()
        {
            headerRectangle = new Rectangle(new Point(1, 1), new Size(Bar.Width - 2, Bar.HeaderHeight - 1));
            headerTextRectangle = new Rectangle(new Point(1, 1), new Size(Bar.Width - 2, Bar.HeaderHeight - 1));

            if (Bar.ShowMoreOptionsButton)
            {
                // The smallButtonRectangle is used to calculate the amount of overflow buttons
                if (Bar.RightToLeft == RightToLeft.Yes)
                    smallButtonRectangle = new Rectangle(1 + optionButtonWidth, Bar.Height - Bar.MinimizedPanelHeight, Bar.Width - 2 - optionButtonWidth, Bar.MinimizedPanelHeight - 1);
                else
                    smallButtonRectangle = new Rectangle(1, Bar.Height - Bar.MinimizedPanelHeight, Bar.Width - 2 - optionButtonWidth, Bar.MinimizedPanelHeight - 1);
            }
            else
                smallButtonRectangle = new Rectangle(1, Bar.Height - Bar.MinimizedPanelHeight, Bar.Width - 2, Bar.MinimizedPanelHeight - 1);
        }

        /// <summary>
        /// Performs the layout process
        /// </summary>
        public override bool Layout(object container, System.Windows.Forms.LayoutEventArgs layoutEventArgs)
        {
            if (Bar.BandInitRequired)
                InitializeBands();

            if (Bar.Collapsed != currentCollapseState)
            {
                SwitchCollapsion(Bar.Collapsed, currentCollapseState);
                currentCollapseState = Bar.Collapsed;
            }

            if (layoutEventArgs.AffectedProperty == "RightToLeft")
                LayoutMenu();

            CalculateRegions();
            CalculateButtonLayout();
            LayoutSplitter();
            LayoutBands(); // First, because of the options menu
            LayoutButtons((layoutEventArgs != null) && (layoutEventArgs.AffectedProperty == "OptionsMenu"));
            LayoutAdditionalControls();

            return true;
        }

        /// <summary>
        /// Lays out the additional controls being added from the layoutEngine 
        /// </summary>
        private void LayoutAdditionalControls()
        {
            if (Bar.ShowMoreOptionsButton)
            {
                // Initializes the options button
                optionsButton.Small = true;
                optionsButton.Height = smallButtonRectangle.Height;
                optionsButton.Width = optionButtonWidth;
                optionsButton.Visible = true;

                if (Bar.RightToLeft == RightToLeft.Yes)
                    optionsButton.Location = new Point(1, smallButtonRectangle.Top);
                else
                    optionsButton.Location = new Point(Bar.Width - (optionButtonWidth + 1), smallButtonRectangle.Top);
            }
            else
            {
                optionsButton.Visible = false;
            }

            // Initializes Collapse button                  
            collapseButton.Visible = Bar.ShowCollapseButton && (!showNeverCollapse);
            collapseButton.Size = new Size(Bar.HeaderHeight, Bar.HeaderHeight - 3);

            if (Bar.RightToLeft == RightToLeft.Yes)
                collapseButton.Location = new Point(4, 2); // (Bar.HeaderHeight / 2) + 3);
            else
                collapseButton.Location = new Point(Bar.Width - Bar.HeaderHeight - 3, 2); // (Bar.HeaderHeight / 2) + 3);        
        }

        /// <summary>
        /// Relayouts the options menu
        /// </summary>
        private void LayoutMenu()
        {
            optionsMenu.RightToLeft = Bar.RightToLeft;
        }


        #endregion

        #region Splitter Layout Methods

        /// <summary>
        /// Returns true if the given x and y coordinate are inside the bounds of the splitter 
        /// rectangle
        /// </summary>
        /// <param name="x">The x coordinate</param>
        /// <param name="y">The y coordinate</param>
        /// <returns>True when the x and y coordinate are inside the bounds; False otherwise</returns>
        private bool MouseInSplitter(int x, int y)
        {
            return ((x > splitterRectangle.X)
                && (x < splitterRectangle.Right)
                && (y > splitterRectangle.Y)
                && (y < splitterRectangle.Bottom));
        }

        /// <summary>
        /// Moves the splitter to a new location
        /// </summary>
        /// <param name="ylocation">The new y coordinate of the splitter</param>
        /// <remarks>
        /// The splitter can not be moved outside the bounds of the control. This method also moves the 
        /// splitter based on the current button height and the amount of visible buttons. 
        /// </remarks>
        private void DragSplitter(int ylocation)
        {
            // Position of the mouse calculated from the buttom of the control up to the top to 
            // make things easier. 
            int ylocinv = (Bar.Height - ylocation) - smallButtonRectangle.Height - splitterHeight;

            // Check whether splitter is inside bounds
            if (ylocinv > 0)
            {
                // Increment position using a step. 
                if (ylocinv > (Bar.ButtonHeight + (Bar.VisibleLargeButtons * Bar.ButtonHeight)))
                {
                    if (Bar.VisibleLargeButtons < visibleButtonCount)
                    {
                        Bar.VisibleLargeButtons++;
                    }
                }
                // Bar.ButtonHeight / 2 because it looks more smooth
                else if (ylocinv <= ((Bar.ButtonHeight * Bar.VisibleLargeButtons) - (Bar.ButtonHeight / 2)))
                {
                    if (Bar.VisibleLargeButtons > 0)
                    {
                        Bar.VisibleLargeButtons--;
                    }
                }
            }
            else
            {
                // Splitter is outside bounds (negative) 
                Bar.VisibleLargeButtons = 0;
            }

            Bar.PerformLayout();
            Bar.Invalidate();
        }

        /// <summary>
        /// Calculates the position of the splitter
        /// </summary>
        private void LayoutSplitter()
        {
            // splitterposition is calculated from the bottom of the control to the top. 
            // Thats not the same as the regular coordinate system. 
            splitterPosition = (Bar.ButtonHeight * largeButtonCount) + splitterHeight;

            // inverse calculation 
            // Width - 2 extra space reserved for the borders on both sides
            splitterRectangle = new Rectangle(1, Bar.Height - (splitterPosition + smallButtonRectangle.Height + 1),
                Bar.Width - 2, splitterHeight);
        }

        #endregion

        #region Button Layout Methods

        /// <summary>
        /// Defines how and where the buttons should be placed. 
        /// </summary>
        private void CalculateButtonLayout()
        {
            visibleButtonCount = 0;
            foreach (NaviBand band in Bar.Bands)
            {
                if (band.Visible)
                    visibleButtonCount++;
            }

            largeButtonCount = 0;
            overflowCount = 0;
            menuCount = 0;

            // Largebutton count can not be greater than the actual amount of visible buttons
            if (Bar.VisibleLargeButtons > visibleButtonCount)
                largeButtonCount = visibleButtonCount;
            else
            {
                if (Bar.VisibleLargeButtons < 0)
                    largeButtonCount = 0;
                else
                    largeButtonCount = Bar.VisibleLargeButtons;
            }

            // If buttons left
            if (largeButtonCount < visibleButtonCount)
            {
                // Calculate the max amount of buttons fitting in overflow panel
                int maxOverflow = smallButtonRectangle.Width / Bar.MinimizedButtonWidth;

                if (visibleButtonCount - largeButtonCount > maxOverflow)
                    overflowCount = maxOverflow;
                else
                    overflowCount = visibleButtonCount - largeButtonCount;

                // Put the rest of the button not fitting anywhere in a menu
                if (visibleButtonCount - largeButtonCount - overflowCount > 0)
                    menuCount = visibleButtonCount - largeButtonCount - overflowCount;
            }
        }

        /// <summary>
        /// Places the Large buttons in the correct positions
        /// </summary>
        private void LayoutLargeButtons()
        {
            // Gently lays out the position of the large buttons
            int flow = (splitterPosition + smallButtonRectangle.Height + 1) - splitterHeight;

            for (int i = 0; i < largeButtonCount; i++)
            {
                ienum.MoveNext();
                while (!ienum.Current.Visible)
                    ienum.MoveNext();

                ienum.Current.Button.Location = new Point(1, Bar.Height - flow);
                ienum.Current.Button.Height = Bar.ButtonHeight;
                ienum.Current.Button.Width = Bar.Width - 2; // extra space for border on both sides
                ienum.Current.Button.Small = false;

                flow -= Bar.ButtonHeight;
            }
        }

        /// <summary>
        /// Places the overflow buttons in the correct position
        /// </summary>
        private void LayoutOverflowButtons()
        {
            int compactFlow = (overflowCount * Bar.MinimizedButtonWidth) + 1;

            // This may seem odd but the buttons are positioned from the left to the right. 
            // The first overflow button will appear as the first left button. 
            if (Bar.ShowMoreOptionsButton)
                compactFlow += optionButtonWidth;

            for (int i = 0; i < overflowCount; i++)
            {
                ienum.MoveNext();
                while (!ienum.Current.Visible)
                    ienum.MoveNext();
                NaviBand band = ienum.Current;

                if (band.Visible)
                {
                    if (!Bar.Collapsed)
                    {
                        // TODO
                        band.Button.Small = true;
                        band.Button.Height = smallButtonRectangle.Height;
                        band.Button.Width = Bar.MinimizedButtonWidth;

                        if (Bar.RightToLeft == RightToLeft.Yes)
                            band.Button.Location = new Point(compactFlow - Bar.MinimizedButtonWidth, smallButtonRectangle.Top);
                        else
                            band.Button.Location = new Point(Bar.Width - compactFlow, smallButtonRectangle.Top);

                        compactFlow -= Bar.MinimizedButtonWidth;
                    }
                    else
                    {
                        // Collapsed, place buttons out of sight
                        band.Button.Location = new Point(0, 0);
                        band.Button.Size = new Size(0, 0);
                    }
                }
            }
        }

        private void LayoutMenuItems()
        {
            for (int i = 0; i < menuCount; i++)
            {
                ienum.MoveNext();
                while (!ienum.Current.Visible)
                    ienum.MoveNext();

                NaviBand band = (NaviBand)ienum.Current;

                // Collapsed, place buttons out of sight
                band.Button.Location = new Point(0, 0);
                band.Button.Size = new Size(0, 0);

                ToolStripMenuItem menuitem = new ToolStripMenuItem();

                menuitem.Name = "";
                menuitem.Size = new System.Drawing.Size(234, 22);
                menuitem.Text = band.Text;
                menuitem.Click += new EventHandler(menuitem_Click);

                if (band.SmallImage != null)
                    menuitem.Image = band.SmallImage;
                else if ((band != null) && (band.SmallImageIndex >= 0) && (band.SmallImages != null)
                    && (band.SmallImageIndex < band.SmallImages.Images.Count))
                {
                    menuitem.Image = band.SmallImages.Images[band.SmallImageIndex];
                }
                menuitem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;

                if (band == Bar.ActiveBand)
                {
                    menuitem.Checked = true;
                    menuitem.CheckState = System.Windows.Forms.CheckState.Checked;
                }
                else
                {
                    menuitem.Checked = false;
                    menuitem.CheckState = System.Windows.Forms.CheckState.Unchecked;
                }

                optionsMenu.Items.Add(menuitem);
            }
        }

        private void menuitem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
                if (menuItem != null)
                {
                    foreach (NaviBand band in Bar.Bands)
                    {
                        if (band.Text.Equals(menuItem.Text))
                        {
                            Bar.SetActiveBand(band);
                        }
                    }
                }
                Bar.PerformLayout();
                Bar.Invalidate();
            }
        }

        /// <summary>
        /// Defines the position of all buttons
        /// </summary>
        private void LayoutButtons(bool layoutMenuButtons)
        {
            ienum = Bar.Bands.GetNaviEnumerator();
            ienum.Reset();

            LayoutLargeButtons();
            LayoutOverflowButtons();
            if (layoutMenuButtons)
            {
                LayoutMenuItems();
                InitializeSubMenu();
            }
            else
                HideButtonRest();

        }

        /// <summary>
        /// When no menu items should be initialized the rest of the buttons should be hidden away
        /// </summary>
        private void HideButtonRest()
        {
            for (int i = 0; i < menuCount; i++)
            {
                ienum.MoveNext();
                while (!ienum.Current.Visible)
                    ienum.MoveNext();

                // Collapsed, place buttons out of sight
                ienum.Current.Button.Location = new Point(0, 0);
                ienum.Current.Button.Size = new Size(0, 0);

            }
        }

        #endregion

        #region Band Layout Methods

        /// <summary>
        /// Calculates the size and the position of the bands
        /// </summary>
        private void LayoutBands()
        {
            foreach (NaviBand band in Bar.Bands)
            {
                band.Location = new Point(1, Bar.HeaderHeight);

                if ((band == Bar.ActiveBand)
                && (!Bar.Collapsed))
                {
                    // Fake the change z-order to front 					
                    // BringToFront give design time issues in ordering of the bands
                    band.Size = new Size(Bar.Width - 2, splitterRectangle.Y - Bar.HeaderHeight);
                }
                else
                {
                    band.Size = new Size(0, 0);
                }
            }
            if ((Bar.Collapsed)
            && (collapsedBand != null))
            {
                collapsedBand.Visible = true;
                collapsedBand.BringToFront();
                if (Bar.ActiveBand != null)
                    collapsedBand.Text = Bar.ActiveBand.Text;
                else
                    collapsedBand.Text = "";
            }
            else
            {
                if ((collapsedBand != null) && (collapsedBand.Visible))
                    collapsedBand.Visible = false;
            }
            collapsedBand.Location = new Point(1, Bar.HeaderHeight);
            collapsedBand.Size = new Size(Bar.Width - 2, splitterRectangle.Y - 1 - Bar.HeaderHeight);
        }

        #endregion

        #region Mouse Handling Methods

        /// <summary>
        /// Handles the MouseDown event
        /// </summary>
        /// <param name="e">Additional event info</param>
        private void HandleMouseDown(MouseEventArgs e)
        {
            if (e != null)
            {
                if ((e.Button == MouseButtons.Left)
                && (e.Clicks == 1)
                && (MouseInSplitter(e.X, e.Y)))
                {
                    splitterDragging = true;
                }
                else
                {
                    splitterDragging = false;
                }
            }
        }

        /// <summary>
        /// Handles the MouseMove event
        /// </summary>
        /// <param name="e">Additional event info</param>
        private void HandleMouseMove(MouseEventArgs e)
        {
            if (e != null)
            {
                if (splitterDragging)
                    DragSplitter(e.Y);

                if ((MouseInSplitter(e.X, e.Y))
                || (splitterDragging))
                {
                    Bar.Cursor = Cursors.SizeNS;
                }
                else
                {
                    Bar.Cursor = Cursors.Default;
                }
            }
        }

        /// <summary>
        /// Overriden. Handles the Notification the observable object sent
        /// </summary>
        /// <param name="obj">The observable object</param>
        /// <param name="id">An identification which caused this notification</param>
        /// <param name="arguments">Additional info</param>
        public override void Notify(IObservable obj, string id, object arguments)
        {
            switch (id)
            {
                case "MouseDown":
                    HandleMouseDown(arguments as MouseEventArgs);
                    break;
                case "MouseMove":
                    HandleMouseMove(arguments as MouseEventArgs);
                    break;
                case "MouseLeave":
                    Bar.Cursor = Cursors.Default;
                    break;
                case "MouseUp":
                    splitterDragging = false;
                    break;
                default: break;
            }
        }

        #endregion

        #region Button Handling Methods

        /// <summary>
        /// Changes the activeband when the user clicks on a button
        /// </summary>
        private void Button_Click(object sender, EventArgs e)
        {
            NaviButton button = sender as NaviButton;
            if (button.Band != null)
                Bar.ActiveBand = button.Band;
        }

        #endregion

        #region Options Menu Methods

        /// <summary>
        /// Shows the options menu 
        /// </summary>
        /// <param name="sender">The button on which this event occured</param>
        /// <param name="e">Additional info</param>
        private void optionsButton_Click(object sender, EventArgs e)
        {
            ShowOptionsMenu();
        }

        /// <summary>
        /// Shows the options menu 
        /// </summary>
        public void ShowOptionsMenu()
        {
            InitializeMenu();
            Layout(Bar, new LayoutEventArgs(Bar, "OptionsMenu"));

            Point location = new Point(optionsButton.Right, optionsButton.Top + optionsButton.Height / 2);
            Point screenLocation = Bar.PointToScreen(location);
            optionsMenu.Show(screenLocation);
        }

        /// <summary>
        /// Initializes the menu for the first time
        /// </summary>
        private void InitializeMenu()
        {
            ResourceManager rm = new ResourceManager(
                "NaviSuite.Properties.Resources.Text", Assembly.GetExecutingAssembly());

            this.optionsMenu = new NaviContextMenu();
            this.miShowMoreButtons = new ToolStripMenuItem();
            this.miShowLessButtons = new ToolStripMenuItem();
            this.miShowMoreOptions = new ToolStripMenuItem();
            this.miAddOrRemoveButtons = new ToolStripMenuItem();
            this.miSep = new ToolStripSeparator();

            this.optionsMenu.Items.Clear();
            this.optionsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miShowMoreButtons,
            this.miShowLessButtons,
            this.miShowMoreOptions,
            this.miAddOrRemoveButtons,
            this.miSep});
            this.optionsMenu.Name = "optionsMenu";
            this.optionsMenu.Size = new System.Drawing.Size(235, 114);
            this.optionsMenu.RightToLeft = Bar.RightToLeft;

            // 
            // miShowMoreButtons
            // 
            this.miShowMoreButtons.Name = "showMoreButtonsToolStripMenuItem";
            this.miShowMoreButtons.Size = new System.Drawing.Size(234, 22);
            this.miShowMoreButtons.Text = rm.GetString("BarShowMore");
            this.miShowMoreButtons.Click += new EventHandler(miShowMoreButtons_Click);
            this.miShowMoreButtons.Image = ProjectResources.Up;
            this.miShowMoreButtons.Enabled = largeButtonCount < visibleButtonCount;
            this.miShowMoreButtons.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            // 
            // miShowLessButtons
            // 
            this.miShowLessButtons.Name = "showLessButtonsToolStripMenuItem";
            this.miShowLessButtons.Size = new System.Drawing.Size(234, 22);
            this.miShowLessButtons.Text = rm.GetString("BarShowLess");
            this.miShowLessButtons.Click += new EventHandler(miShowLessButtons_Click);
            this.miShowLessButtons.Image = ProjectResources.Down;
            this.miShowLessButtons.Enabled = largeButtonCount > 0;
            this.miShowLessButtons.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            // 
            // miShowMoreOptions
            // 
            this.miShowMoreOptions.Name = "optionsOfTheNavigationPaneToolStripMenuItem";
            this.miShowMoreOptions.Size = new System.Drawing.Size(234, 22);
            this.miShowMoreOptions.Text = rm.GetString("BarOptions");
            this.miShowMoreOptions.Click += new EventHandler(miShowMoreOptions_Click);
            // 
            // miAddOrRemoveButtons
            //          
            this.miAddOrRemoveButtons.Name = "addOrRemoveButtonsToolStripMenuItem";
            this.miAddOrRemoveButtons.Size = new System.Drawing.Size(234, 22);
            this.miAddOrRemoveButtons.Text = rm.GetString("BarAddOrRemove");

            // 
            // miSep
            //                   
        }

        /// <summary>
        /// Fills the submenu with the approperiate menuitems and initializes their checkstate
        /// </summary>
        private void InitializeSubMenu()
        {
            this.miAddOrRemoveButtons.DropDownItems.Clear();

            foreach (NaviBand band in Bar.Bands)
            {
                ToolStripMenuItem menuItem = new ToolStripMenuItem();

                menuItem.Text = band.Text;

                if (band.SmallImage != null)
                    menuItem.Image = band.SmallImage;
                else if ((band != null) && (band.SmallImageIndex >= 0) && (band.SmallImages != null)
                    && (band.SmallImageIndex < band.SmallImages.Images.Count))
                {
                    menuItem.Image = band.SmallImages.Images[band.SmallImageIndex];
                }

                if (band.Visible)
                {
                    menuItem.Checked = true;
                    menuItem.CheckState = System.Windows.Forms.CheckState.Checked;
                }
                else
                {
                    menuItem.Checked = false;
                    menuItem.CheckState = System.Windows.Forms.CheckState.Unchecked;
                }
                menuItem.CheckOnClick = true;
                menuItem.CheckedChanged += new EventHandler(menuItem_CheckedChanged);

                this.miAddOrRemoveButtons.DropDownItems.Add(menuItem);
            }
        }

        /// <summary>
        /// Shows or hide the button linked to the menu item
        /// </summary>
        /// <param name="sender">The control on which this event occured</param>
        /// <param name="e">Additional info</param>
        private void menuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
                if (menuItem != null)
                {
                    foreach (NaviBand band in Bar.Bands)
                    {
                        if (band.Text.Equals(menuItem.Text))
                        {
                            band.Visible = menuItem.Checked;
                        }
                    }
                }
                Bar.PerformLayout();
                Bar.Invalidate();
            }
        }

        /// <summary>
        /// Shows more buttons
        /// </summary>
        /// <param name="sender">The control on which this event occured</param>
        /// <param name="e">Additional info</param>
        private void miShowMoreButtons_Click(object sender, EventArgs e)
        {
            Bar.VisibleLargeButtons++;
            Bar.Invalidate();
        }

        /// <summary>
        /// Shows less buttons
        /// </summary>
        /// <param name="sender">The control on which this event occured</param>
        /// <param name="e">Additional info</param>
        private void miShowLessButtons_Click(object sender, EventArgs e)
        {
            Bar.VisibleLargeButtons--;
            Bar.Invalidate();
        }

        /// <summary>
        /// Shows more options regarding the navigation bar
        /// </summary>
        /// <param name="sender">The control on which this event occured</param>
        /// <param name="e">Additional info</param>
        private void miShowMoreOptions_Click(object sender, EventArgs e)
        {
            ShowMoreOptionsDialog();
        }

        /// <summary>
        /// Creates a new instance of the option dialog and shows it to the user.
        /// </summary>
        public void ShowMoreOptionsDialog()
        {
            NaviOptionsForm form = new NaviOptionsForm();
            form.Initialize(Bar);
            if (form.ShowDialog() == DialogResult.OK)
            {
                Bar.PerformLayout();
            }
        }

        #endregion

        #region Collapse Methods

        /// <summary>
        /// When the bar is collapsed this method closes the popup. 
        /// Call this before opening a new modal form. 
        /// </summary>
        public virtual void ClosePopup()
        {
            if ((Bar.Collapsed) && (popup.Visible))
            {
                popupHelper.ClosePopup();
            }
        }

        /// <summary>
        /// Changes the navigation bar to Bar.Collapsed view 
        /// </summary>
        public virtual void SwitchCollapsion(bool collapse, bool oldCollapsed)
        {
            if ((collapse)
            && (!oldCollapsed))
            {
                orgWidth = Bar.Width;
                Bar.Width = 33;
            }

            if (!collapse)
            {
                if (orgWidth < 100)
                    orgWidth = 100;
                Bar.Width = orgWidth;
            }

            foreach (NaviBand band in Bar.Bands)
            {
                band.Button.Collapsed = collapse;
            }
            collapseButton.Collapsed = collapse;
        }

        /// <summary>
        /// Shows the active band in a popup when the bar is collapsed
        /// </summary>
        public void ShowCollapsedBandPopup()
        {
            if (Bar.ActiveBand != null)
            {
                popup = new NaviBandPopup();
                popup.Content = Bar.ActiveBand.ClientArea;
                popup.Renderer = renderer;

                popupHelper = new PopupWindowHelper();
                KryptonForm parent = (KryptonForm)Bar.FindForm();
                popupHelper.PopupClosed += new PopupClosedEventHandler(popupHelper_PopupClosed);

                popupHelper.AssignHandle(parent.Handle);
                popup.Resizable = true;
                popup.ShowInTaskbar = false;
                popup.Height = Bar.PopupHeight;
                popup.Width = orgWidth;
                popup.RightToLeft = Bar.RightToLeft;
                popup.MinimumSize = new Size(Bar.PopupMinWidth, 30);

                if (Bar.RightToLeft == RightToLeft.Yes)
                {
                    popupHelper.ShowPopup(parent, popup, Bar.PointToScreen(new Point(0 - orgWidth, Bar.HeaderHeight)));
                }
                else
                {
                    popupHelper.ShowPopup(parent, popup, Bar.PointToScreen(new Point(Bar.Width, Bar.HeaderHeight)));
                }
            }
        }

        /// <summary>
        /// Hides the popup 
        /// </summary>
        private void HideCollapsedBandPopup()
        {
            Control clientArea = popup.Content;
            Bar.ActiveBand.Controls.Add(clientArea);
            clientArea.Invalidate();
            orgWidth = popup.Width;
            Bar.PerformLayout();
        }

        /// <summary>
        /// Switch the collapsion of the Navigation bar
        /// </summary>      
        private void collapseButton_Click(object sender, EventArgs e)
        {
            Bar.Collapsed = !Bar.Collapsed;
        }

        /// <summary>
        /// Shows the band in a popup
        /// </summary>
        private void CollapsedBand_MouseUp(object sender, MouseEventArgs e)
        {
            Bar.OnCollapsedBandClick(new EventArgs());
            ShowCollapsedBandPopup();
        }

        /// <summary>
        /// Hides the popup
        /// </summary>
        private void popupHelper_PopupClosed(object sender, PopupClosedEventArgs e)
        {
            HideCollapsedBandPopup();
        }

        #endregion

        #region Drawing Methods

        /// <summary>
        /// Requests the engine to start the drawing process for the navigation bar
        /// </summary>
        /// <param name="g">The graphics surface to draw on</param>
        public override void Draw(Graphics g)
        {
            base.Draw(g);
            if (Bar.ActiveBand != null)
            {
                renderer.DrawText(g, headerTextRectangle, headerFont, renderer.ColourTable.HeaderText, Bar.ActiveBand.Text,
                    Bar.RightToLeft == RightToLeft.Yes);
            }
            renderer.DrawSplitterBg(g, splitterRectangle);
        }

        public override void DrawBackground(Graphics g)
        {
            base.DrawBackground(g);

            renderer.DrawNaviBarBg(g, Bar.ClientRectangle);
            renderer.DrawNaviBarOverFlowPanelBg(g, smallButtonRectangle);
            renderer.DrawNaviBarHeaderBg(g, headerRectangle);
            renderer.DrawSplitterBg(g, splitterRectangle);
        }

        #endregion
    }
}