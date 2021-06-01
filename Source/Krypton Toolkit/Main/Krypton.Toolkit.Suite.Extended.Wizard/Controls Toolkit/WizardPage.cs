#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Wizard
{
    /// <summary>
    /// Represents a single page in a <see cref="WizardControl" />.
    /// </summary>
    [Designer(typeof(WizardPageDesigner)), DesignTimeVisible(true)]
    [DefaultProperty("Text"), DefaultEvent("Commit")]
    [ToolboxItem(false)]
    public partial class WizardPage : Control
    {
        #region Designer Code
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }

        #endregion
        #endregion

        private bool allowCancel = true, allowNext = true, allowBack = true;
        private bool showCancel = true, showNext = true, suppress;
        private bool isFinishPage;
        private string helpText;

        private LinkLabel helpLink;

        /// <summary>
        /// Initializes a new instance of the <see cref="WizardPage"/> class.
        /// </summary>
        public WizardPage()
        {
            InitializeComponent();
            Margin = Padding.Empty;
            base.Text = Properties.Resources.WizardHeader;
        }

        /// <summary>
        /// Occurs when the user has clicked the Next/Finish button but before the page is changed.
        /// </summary>
        [Category("Wizard"), Description("Occurs when the user has clicked the Next/Finish button but before the page is changed")]
        public event EventHandler<WizardPageConfirmEventArgs> Commit;

        /// <summary>
        /// Occurs when <see cref="HelpText"/> is set and the user has clicked the link at bottom of the content area.
        /// </summary>
        [Category("Wizard"), Description("Occurs when the user has clicked the help link")]
        public event EventHandler HelpClicked;

        /// <summary>
        /// Occurs when this page is entered.
        /// </summary>
        [Category("Wizard"), Description("Occurs when this page is entered")]
        public event EventHandler<WizardPageInitEventArgs> Initialize;

        /// <summary>
        /// Occurs when the user has clicked the Back button but before the page is changed.
        /// </summary>
        [Category("Wizard"), Description("Occurs when the user has clicked the Back button")]
        public event EventHandler<WizardPageConfirmEventArgs> Rollback;

        /// <summary>
        /// Gets or sets a value indicating whether to enable the Back button.
        /// </summary>
        /// <value><c>true</c> if Back button is enabled; otherwise, <c>false</c>.</value>
        [DefaultValue(true), Category("Behavior"), Description("Indicates whether to enable the Back button")]
        public virtual bool AllowBack
        {
            get { return allowBack; }
            set
            {
                if (allowBack == value) return;
                allowBack = value;
                UpdateOwner();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to enable the Cancel button.
        /// </summary>
        /// <value><c>true</c> if Cancel button is enabled; otherwise, <c>false</c>.</value>
        [DefaultValue(true), Category("Behavior"), Description("Indicates whether to enable the Cancel button")]
        public virtual bool AllowCancel
        {
            get { return allowCancel; }
            set
            {
                if (allowCancel == value) return;
                allowCancel = value;
                UpdateOwner();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to enable the Next/Finish button.
        /// </summary>
        /// <value><c>true</c> if Next/Finish button is enabled; otherwise, <c>false</c>.</value>
        [DefaultValue(true), Category("Behavior"), Description("Indicates whether to enable the Next/Finish button")]
        public virtual bool AllowNext
        {
            get { return allowNext; }
            set
            {
                if (allowNext == value) return;
                allowNext = value;
                UpdateOwner();
            }
        }

        /// <summary>
        /// Gets or sets the help text. When value is not <c>null</c>, a help link will be displayed at the bottom left of the content area. When clicked, the <see cref="OnHelpClicked"/> method will call the <see cref="HelpClicked"/> event.
        /// </summary>
        /// <value>
        /// The help text to display.
        /// </value>
        [DefaultValue(null), Category("Appearance"), Description("Help text to display on hyperlink at bottom left of content area.")]
        public string HelpText
        {
            get { return helpText; }
            set
            {
                if (helpLink == null)
                {
                    helpLink = new LinkLabel() { AutoSize = true, Dock = DockStyle.Bottom, Text = Resources.WizardPageDefaultHelpText, Visible = false };
                    helpLink.LinkClicked += helpLink_LinkClicked;
                    Controls.Add(helpLink);
                }
                helpText = value;
                if (helpText == null)
                {
                    helpLink.Visible = false;
                }
                else
                {
                    helpLink.Text = helpText;
                    helpLink.Visible = true;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this page is the last page in the sequence and should display the Finish text instead of the Next text on the Next/Finish button.
        /// </summary>
        /// <value><c>true</c> if this page is a finish page; otherwise, <c>false</c>.</value>
        [DefaultValue(false), Category("Behavior"), Description("Indicates whether this page is the last page")]
        public virtual bool IsFinishPage
        {
            get { return isFinishPage; }
            set
            {
                if (isFinishPage == value) return;
                isFinishPage = value;
                UpdateOwner();
            }
        }

        /// <summary>
        /// Gets or sets the next page that should be used when the user clicks the Next button or when the <see cref="WizardControl.NextPage"/> method is called. This is used to override the default behavior of going to the next page in the sequence defined within the <see cref="WizardControl.Pages"/> collection.
        /// </summary>
        /// <value>The wizard page to go to.</value>
        [DefaultValue(null), Category("Behavior"),
        Description("Specify a page other than the next page in the Pages collection as the next page.")]
        public virtual WizardPage NextPage { get; set; }

        /// <summary>
        /// Gets the <see cref="WizardControl"/> for this page.
        /// </summary>
        /// <value>The <see cref="WizardControl"/> for this page.</value>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual WizardPageContainer Owner { get; internal set; }

        /// <summary>
        /// Gets or sets a value indicating whether to show the Cancel button. If both <see cref="ShowCancel"/> and <see cref="ShowNext"/> are <c>false</c>, then the bottom command area will not be shown.
        /// </summary>
        /// <value><c>true</c> if Cancel button should be shown; otherwise, <c>false</c>.</value>
        [DefaultValue(true), Category("Behavior"), Description("Indicates whether to show the Cancel button")]
        public virtual bool ShowCancel
        {
            get { return showCancel; }
            set
            {
                if (showCancel == value) return;
                showCancel = value;
                UpdateOwner();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to show the Next/Finish button. If both <see cref="ShowCancel"/> and <see cref="ShowNext"/> are <c>false</c>, then the bottom command area will not be shown.
        /// </summary>
        /// <value><c>true</c> if Next/Finish button should be shown; otherwise, <c>false</c>.</value>
        [DefaultValue(true), Category("Behavior"), Description("Indicates whether to show the Next/Finish button")]
        public virtual bool ShowNext
        {
            get { return showNext; }
            set
            {
                if (showNext == value) return;
                showNext = value;
                UpdateOwner();
            }
        }

        /// <summary>
        /// Gets or sets the height and width of the control.
        /// </summary>
        /// <value></value>
        /// <returns>
        /// The <see cref="T:System.Drawing.Size"/> that represents the height and width of the control in pixels.
        /// </returns>
        [Browsable(false)]
        public new System.Drawing.Size Size { get { return base.Size; } set { base.Size = value; } }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="WizardPage"/> is suppressed and not shown in the normal flow.
        /// </summary>
        /// <value>
        ///   <c>true</c> if suppressed; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(false), Category("Behavior"), Description("Suppresses this page from viewing if selected as next.")]
        public virtual bool Suppress
        {
            get { return suppress; }
            set
            {
                if (suppress == value) return;
                suppress = value;
                UpdateOwner();
            }
        }

        /// <summary>
        /// Gets the required creation parameters when the control handle is created.
        /// </summary>
        /// <returns>A <see cref="T:System.Windows.Forms.CreateParams" /> that contains the required creation parameters when the handle to the control is created.</returns>
        protected override CreateParams CreateParams
        {
            get
            {
                var createParams = base.CreateParams;
                var parent = FindForm();
                var parentRightToLeftLayout = parent != null && parent.RightToLeftLayout;
                if ((RightToLeft == RightToLeft.Yes) && parentRightToLeftLayout)
                {
                    createParams.ExStyle |= 0x500000; // WS_EX_LAYOUTRTL | WS_EX_NOINHERITLAYOUT
                    createParams.ExStyle &= ~0x7000; // WS_EX_RIGHT | WS_EX_RTLREADING | WS_EX_LEFTSCROLLBAR
                }
                return createParams;
            }
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this wizard page.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this wizard page.
        /// </returns>
        public override string ToString() => $"{Name} (\"{Text}\")";

        internal bool CommitPage() => OnCommit();

        internal void InitializePage(WizardPage prevPage)
        {
            OnInitialize(prevPage);
        }

        internal bool RollbackPage() => OnRollback();

        /// <summary>
        /// Raises the <see cref="Commit" /> event.
        /// </summary>
        /// <returns><c>true</c> if handler does not set the <see cref="WizardPageConfirmEventArgs.Cancel"/> to <c>true</c>; otherwise, <c>false</c>.</returns>
        protected virtual bool OnCommit()
        {
            var e = new WizardPageConfirmEventArgs(this);
            Commit?.Invoke(this, e);
            return !e.Cancel;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.GotFocus"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            var firstChild = GetNextControl(this, true);
            firstChild?.Focus();
        }

        /// <summary>
        /// Raises the <see cref="HelpClicked"/> event.
        /// </summary>
        protected virtual void OnHelpClicked()
        {
            HelpClicked?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Raises the <see cref="Initialize"/> event.
        /// </summary>
        /// <param name="prevPage">The page that was previously selected.</param>
        protected virtual void OnInitialize(WizardPage prevPage)
        {
            Initialize?.Invoke(this, new WizardPageInitEventArgs(this, prevPage));
        }

        /// <summary>
        /// Raises the <see cref="Rollback"/> event.
        /// </summary>
        /// <returns><c>true</c> if handler does not set the <see cref="WizardPageConfirmEventArgs.Cancel"/> to <c>true</c>; otherwise, <c>false</c>.</returns>
        protected virtual bool OnRollback()
        {
            var e = new WizardPageConfirmEventArgs(this);
            Rollback?.Invoke(this, e);
            return !e.Cancel;
        }

        private void helpLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OnHelpClicked();
        }

        private void UpdateOwner()
        {
            if (Owner != null && this == Owner.SelectedPage)
                Owner.UpdateUIDependencies();
        }
    }
}