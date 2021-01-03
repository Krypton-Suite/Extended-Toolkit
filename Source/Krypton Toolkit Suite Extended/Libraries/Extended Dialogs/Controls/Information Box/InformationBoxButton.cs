using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    /// <summary>
    /// Glass button
    /// </summary>
    [Category("Glass Components")]
    [DefaultEvent("Click")]
    [DefaultProperty("Text")]
    [Description("Button with glass look and feel")]
    [ToolboxBitmap(typeof(Button))]
    public partial class InformationBoxButton : Control
    {
        #region Design Code
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
                this.components.Dispose();
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
            this.components = new System.ComponentModel.Container();
            this.buttonText = new System.Windows.Forms.Label();
            this.timerFade = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // buttonText
            // 
            this.buttonText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonText.BackColor = System.Drawing.Color.Transparent;
            this.buttonText.ForeColor = System.Drawing.Color.White;
            this.buttonText.Location = new System.Drawing.Point(5, 6);
            this.buttonText.Margin = new System.Windows.Forms.Padding(0);
            this.buttonText.Name = "buttonText";
            this.buttonText.Size = new System.Drawing.Size(199, 26);
            this.buttonText.TabIndex = 0;
            this.buttonText.Text = "Label de test";
            this.buttonText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonText.MouseLeave += new System.EventHandler(this.OnTextLeave);
            this.buttonText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnTextDown);
            this.buttonText.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnTextUp);
            this.buttonText.MouseEnter += new System.EventHandler(this.OnTextEnter);
            // 
            // timerFade
            // 
            this.timerFade.Interval = 2000;
            this.timerFade.Tick += new System.EventHandler(this.OnFadeTick);
            // 
            // Button
            // 
            this.Controls.Add(this.buttonText);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(16, 16);
            this.Size = new System.Drawing.Size(209, 41);
            this.ForeColorChanged += new System.EventHandler(this.OnNewForeColor);
            this.EnabledChanged += new System.EventHandler(this.OnEnabledChanged);
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// Inner label for the button
        /// </summary>
        private System.Windows.Forms.Label buttonText;

        /// <summary>
        /// Inner timer for effects
        /// </summary>
        private System.Windows.Forms.Timer timerFade;
        #endregion

        #region Attributes

        /// <summary>
        /// Contains the side borders
        /// </summary>
        private SideBorder sideBorder;

        /// <summary>
        /// Contains the side border bottom column
        /// </summary>
        private Color sideBorderBottomColor = Color.Transparent;

        /// <summary>
        /// Contains the side border top column
        /// </summary>
        private Color sideBorderTopColor = Color.White;

        /// <summary>
        /// Contains the side border width
        /// </summary>
        private int sideBorderWidth = 1;

        #region Button state

        /// <summary>
        /// Flag for the pushed state
        /// </summary>
        private bool pushed;

        /// <summary>
        /// Flag for the hover state
        /// </summary>
        private bool hover;

        /// <summary>
        /// Flag for the pushed persistant mode
        /// </summary>
        private bool persistantMode;

        #endregion Button state

        /// <summary>
        /// Value of the alpha channel
        /// </summary>
        private int alphaChannelCoeff;

        /// <summary>
        /// Text alignment
        /// </summary>
        private ContentAlignment textAlign = ContentAlignment.MiddleCenter;

        /// <summary>
        /// Fore color used for the disabled state
        /// </summary>
        private Color disabledForeColor = Color.Gray;

        #endregion Attributes

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="InformationBoxButton"/> class.
        /// </summary>
        public InformationBoxButton()
        {
            this.InitializeComponent();
            this.DoubleBuffered = true;
            this.timerFade.Interval = 20;

            this.BackColor = Color.Black;
            this.ForeColor = Color.White;

            this.GotFocus += Control_GotFocus;
            this.LostFocus += Control_LostFocus;
            this.KeyDown += Control_KeyDown;
            this.KeyUp += Control_KeyUp;
        }

        #endregion Constructor

        #region Focus

        /// <summary>
        /// Handles the GotFocus event of the Control control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Control_GotFocus(object sender, System.EventArgs e)
        {
            Refresh();
        }

        /// <summary>
        /// Handles the LostFocus event of the Control control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Control_LostFocus(object sender, System.EventArgs e)
        {
            Refresh();
        }

        /// <summary>
        /// Processes a mnemonic character.
        /// </summary>
        /// <param name="charCode">The character to process.</param>
        /// <returns>
        /// true if the character was processed as a mnemonic by the control; otherwise, false.
        /// </returns>
        protected override bool ProcessMnemonic(char charCode)
        {
            if (Enabled && Visible && IsMnemonic(charCode, this.Text))
            {
                // Perform action associated with mnemonic
                // Moves focus to our control
                Focus();
                Refresh();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Handles the ChangeUICues event of the FocusableControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.UICuesEventArgs"/> instance containing the event data.</param>
        private void FocusableControl_ChangeUICues(object sender, UICuesEventArgs e)
        {
            if (e.ChangeFocus || e.ChangeKeyboard)
            {
                Refresh();
            }
        }

        #endregion Focus

        #region Events

        /// <summary>
        /// Event raised when button is clicked
        /// </summary>
        public new event EventHandler<EventArgs> Click;

        #endregion Events

        #region Properties

        /// <summary>
        /// Gets or sets if a custom border is shown on the sides of the control
        /// </summary>
        /// <value>The side border.</value>
        [Category("Side Border"), Description("Defines if a special side border should be displayed"),
         DefaultValue("None")]
        public SideBorder SideBorder
        {
            get
            {
                return this.sideBorder;
            }

            set
            {
                this.sideBorder = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the border width
        /// </summary>
        /// <value>The width of the side border.</value>
        [Category("Side Border"), Description("Defines the width of the side border")]
        public int SideBorderWidth
        {
            get
            {
                return this.sideBorderWidth;
            }

            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("The border width must be positive");
                }

                this.sideBorderWidth = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the top border color
        /// </summary>
        /// <value>The top color of the side border.</value>
        [Category("Side Border"), Description("Defines the top color of the side border")]
        public Color SideBorderTopColor
        {
            get
            {
                return this.sideBorderTopColor;
            }

            set
            {
                this.sideBorderTopColor = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the bottom border color
        /// </summary>
        /// <value>The bottom color of the side border.</value>
        [Category("Side Border"), Description("Defines the bottom color of the side border")]
        public Color SideBorderBottomColor
        {
            get
            {
                return this.sideBorderBottomColor;
            }

            set
            {
                this.sideBorderBottomColor = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the text color when the button is disabled
        /// </summary>
        [Category("Appearance"), Description("Defines the text color when the button is disabled")]
        public Color DisabledForeColor
        {
            get
            {
                return this.disabledForeColor;
            }

            set
            {
                this.disabledForeColor = value;
                this.RefreshLabelColor();
            }
        }

        /// <summary>
        /// Gets or sets the alignment of the text
        /// </summary>
        [Category("Appearance"), Description("Defines the alignment of the text")]
        public ContentAlignment TextAlign
        {
            get
            {
                return this.textAlign;
            }

            set
            {
                this.textAlign = value;
                this.buttonText.TextAlign = this.textAlign;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the button text
        /// </summary>
        [Category("Appearance"), Description("Defines the text of the button"), Browsable(true)]
        public override string Text
        {
            get
            {
                return this.buttonText.Text;
            }

            set
            {
                this.buttonText.Text = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the button remains clicked after mouse button is released.
        /// </summary>
        /// <value><c>true</c> if the button remains clicked after mouse button is released; otherwise, <c>false</c>.</value>
        [Category("Behavior"), Description("Defines if the button remains clicked after mouse button is released"), DefaultValue("false")]
        public bool PersistantMode
        {
            get
            {
                return this.persistantMode;
            }

            set
            {
                this.persistantMode = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Button"/> is pushed.
        /// </summary>
        /// <value><c>true</c> if pushed; otherwise, <c>false</c>.</value>
        [Category("Behavior"), Description("Defines if button appears as pushed"), Browsable(true)]
        public bool Pushed
        {
            get
            {
                return this.pushed;
            }

            set
            {
                // Do nothing if not in persistant mode
                if (!this.persistantMode)
                {
                    return;
                }

                this.pushed = value;
                this.Invalidate();
            }
        }

        #endregion Properties

        #region Event handlers

        /// <summary>
        /// When button is clicked
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnClick(EventArgs e)
        {
            if (this.Click != null)
            {
                this.Click(this, e);
            }
        }

        #region Background

        /// <summary>
        /// Paints the background
        /// </summary>
        /// <param name="pevent">A <see cref="T:System.Windows.Forms.PaintEventArgs"></see> that contains information about the control to paint.</param>
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);

            PaintingEngine.PaintGlassEffect(pevent.Graphics, BackColor, Width, Height);
            PaintingEngine.PaintGradientBorders(pevent.Graphics, this.sideBorderTopColor, this.sideBorderBottomColor, Width, Height, this.sideBorderWidth, this.sideBorder);

            if (this.pushed)
            {
                PaintingEngine.PaintPushedEffect(pevent.Graphics, Width, Height);
            }
            else if (Enabled && (this.hover || this.timerFade.Enabled))
            {
                PaintingEngine.PaintHoverEffect(
                    pevent.Graphics,
                    Color.FromArgb(12 * this.alphaChannelCoeff, Color.Gainsboro),
                    Color.FromArgb(12 * this.alphaChannelCoeff, Color.Black),
                    Color.FromArgb(10 * this.alphaChannelCoeff, Color.White),
                    Color.FromArgb(5 * this.alphaChannelCoeff, Color.Beige),
                    this.Width,
                    this.Height);
            }

            // Draw a dotted line inside the client rectangle
            if (ShowFocusCues && ContainsFocus)
            {
                Rectangle r = ClientRectangle;
                r.Inflate(-7, -7);
                r.Width--;
                r.Height--;
                Pen p = new Pen(Color.White, 1);
                p.DashStyle = DashStyle.Dot;
                pevent.Graphics.DrawRectangle(p, r);
            }
        }

        #endregion Background

        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt == false &&
                e.Control == false &&
                e.Shift == false &&
                (e.KeyCode == Keys.Space ||
                 e.KeyCode == Keys.Enter))
            {
                ClickPressed();
                e.Handled = true;
                return;
            }
        }

        private void Control_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Alt == false &&
                e.Control == false &&
                e.Shift == false &&
                (e.KeyCode == Keys.Space ||
                 e.KeyCode == Keys.Enter))
            {
                ClickReleased();
                e.Handled = true;
                return;
            }
        }

        /// <summary>
        /// When forecolor is changed
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnNewForeColor(object sender, EventArgs e)
        {
            this.RefreshLabelColor();
        }

        /// <summary>
        /// When the 'Enabled' property is changed
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnEnabledChanged(object sender, EventArgs e)
        {
            this.RefreshLabelColor();
            this.Invalidate();
        }

        /// <summary>
        /// When mouse enters the button
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnTextEnter(object sender, EventArgs e)
        {
            if (!Enabled)
            {
                return;
            }

            if (this.pushed && this.persistantMode)
            {
                return;
            }

            this.hover = true;
            this.timerFade.Start();
            this.Invalidate();

            this.OnEnter(e);
        }

        /// <summary>
        /// When mouse leaves the button
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnTextLeave(object sender, EventArgs e)
        {
            if (!Enabled)
            {
                return;
            }

            if (this.pushed && this.persistantMode)
            {
                return;
            }

            this.hover = false;
            this.timerFade.Start();
            this.Invalidate();

            this.OnLeave(e);
        }

        /// <summary>
        /// When user clicks on the button
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void OnTextDown(object sender, MouseEventArgs e)
        {
            ClickPressed();
        }

        /// <summary>
        /// When user release the mouse button
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void OnTextUp(object sender, MouseEventArgs e)
        {
            ClickReleased();
        }

        #region Timer Tick (for fading effect)

        /// <summary>
        /// Called when [fade tick].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnFadeTick(object sender, EventArgs e)
        {
            if (this.hover)
            {
                this.alphaChannelCoeff += 2;

                if (this.alphaChannelCoeff >= 10)
                {
                    this.alphaChannelCoeff = 10;
                    this.timerFade.Stop();
                }
            }
            else if (!this.pushed)
            {
                this.alphaChannelCoeff -= 2;

                if (this.alphaChannelCoeff <= 0)
                {
                    this.alphaChannelCoeff = 0;
                    this.timerFade.Stop();
                }
            }

            this.Invalidate();
        }

        #endregion Timer Tick (for fading effect)

        #endregion Event handlers

        #region Methods

        /// <summary>
        /// Click pressed.
        /// </summary>
        private void ClickPressed()
        {
            this.timerFade.Stop();

            if (!Enabled)
            {
                return;
            }

            if (this.pushed && this.persistantMode)
            {
                this.pushed = false;
            }
            else
            {
                this.pushed = true;
            }

            this.Invalidate();
        }

        /// <summary>
        /// Click released.
        /// </summary>
        private void ClickReleased()
        {
            if (!Enabled)
            {
                return;
            }

            if (this.persistantMode)
            {
                return;
            }

            this.pushed = false;
            this.hover = true;
            this.Invalidate();

            // Raises event
            this.OnClick(new EventArgs());
        }

        /// <summary>
        /// Sets the text forecolor
        /// </summary>
        private void RefreshLabelColor()
        {
            this.buttonText.ForeColor = Enabled ? ForeColor : this.disabledForeColor;
            Invalidate();
        }

        #endregion Methods
    }
}