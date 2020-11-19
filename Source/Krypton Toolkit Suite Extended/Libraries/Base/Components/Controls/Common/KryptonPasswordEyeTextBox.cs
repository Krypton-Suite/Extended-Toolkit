using System;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    public class KryptonPasswordEyeTextBox : UserControl
    {
        #region Design Code
        private Panel pnlButton;
        private Panel pnlTextField;
        private KryptonTextBox ktxtPasswordField;
        private KryptonButton kbtnRevealPassword;
        private KryptonCheckButton kchkbtnRevealPassword;

        private void InitializeComponent()
        {
            this.pnlButton = new System.Windows.Forms.Panel();
            this.kchkbtnRevealPassword = new Krypton.Toolkit.KryptonCheckButton();
            this.pnlTextField = new System.Windows.Forms.Panel();
            this.ktxtPasswordField = new Krypton.Toolkit.KryptonTextBox();
            this.kbtnRevealPassword = new Krypton.Toolkit.KryptonButton();
            this.pnlButton.SuspendLayout();
            this.pnlTextField.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButton
            // 
            this.pnlButton.BackColor = System.Drawing.Color.Transparent;
            this.pnlButton.Controls.Add(this.kbtnRevealPassword);
            this.pnlButton.Controls.Add(this.kchkbtnRevealPassword);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlButton.Location = new System.Drawing.Point(223, 0);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(27, 27);
            this.pnlButton.TabIndex = 0;
            // 
            // kchkbtnRevealPassword
            // 
            this.kchkbtnRevealPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kchkbtnRevealPassword.Location = new System.Drawing.Point(0, 0);
            this.kchkbtnRevealPassword.Name = "kchkbtnRevealPassword";
            this.kchkbtnRevealPassword.Size = new System.Drawing.Size(27, 27);
            this.kchkbtnRevealPassword.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.kchkbtnRevealPassword.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.kchkbtnRevealPassword.StateCommon.Back.Image = global::Krypton.Toolkit.Suite.Extended.Base.Properties.Resources.PasswordEyeImage;
            this.kchkbtnRevealPassword.TabIndex = 0;
            this.kchkbtnRevealPassword.Values.Image = global::Krypton.Toolkit.Suite.Extended.Base.Properties.Resources.PasswordEyeImage;
            this.kchkbtnRevealPassword.Values.Text = "";
            // 
            // pnlTextField
            // 
            this.pnlTextField.Controls.Add(this.ktxtPasswordField);
            this.pnlTextField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTextField.Location = new System.Drawing.Point(0, 0);
            this.pnlTextField.Name = "pnlTextField";
            this.pnlTextField.Size = new System.Drawing.Size(223, 27);
            this.pnlTextField.TabIndex = 1;
            // 
            // ktxtPasswordField
            // 
            this.ktxtPasswordField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ktxtPasswordField.Location = new System.Drawing.Point(0, 0);
            this.ktxtPasswordField.Name = "ktxtPasswordField";
            this.ktxtPasswordField.PasswordChar = '●';
            this.ktxtPasswordField.Size = new System.Drawing.Size(223, 23);
            this.ktxtPasswordField.TabIndex = 0;
            this.ktxtPasswordField.UseSystemPasswordChar = true;
            // 
            // kbtnRevealPassword
            // 
            this.kbtnRevealPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kbtnRevealPassword.Location = new System.Drawing.Point(0, 0);
            this.kbtnRevealPassword.Name = "kbtnRevealPassword";
            this.kbtnRevealPassword.Size = new System.Drawing.Size(27, 27);
            this.kbtnRevealPassword.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.kbtnRevealPassword.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.kbtnRevealPassword.StateCommon.Back.Image = global::Krypton.Toolkit.Suite.Extended.Base.Properties.Resources.PasswordEyeImage;
            this.kbtnRevealPassword.TabIndex = 1;
            this.kbtnRevealPassword.Values.Text = "";
            // 
            // KryptonPasswordEyeTextBox
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlTextField);
            this.Controls.Add(this.pnlButton);
            this.Name = "KryptonPasswordEyeTextBox";
            this.Size = new System.Drawing.Size(250, 27);
            this.pnlButton.ResumeLayout(false);
            this.pnlTextField.ResumeLayout(false);
            this.pnlTextField.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region Delegates
        public delegate void PasswordEyePropertiesChangedHandler(object sender, PasswordEyePropertiesChangedEventArgs e);
        #endregion

        #region Event
        public event PasswordEyePropertiesChangedHandler PasswordEyePropertiesChanged;
        #endregion

        #region Constants
        private static Color BACK_COLOUR = Color.White;

        private static Color FORE_COLOUR = SystemColors.MenuText;

        // used to specify whether or 
        // not TextBox Text is masked
        private const char PASSWORD_HIDDEN = '●';
        private const char PASSWORD_VISIBLE = '\0';
        // initial TextBox properties
        private const int TEXTBOX_HEIGHT = 23;
        private const int TEXTBOX_LOCATION_X = 1;
        private const int TEXTBOX_LOCATION_Y = 1;
        static int TEXTBOX_MAXIMUM_WIDTH = 20;
        private const int TEXTBOX_MAXLENGTH = 50;
        // initial Button properties
        private const int BUTTON_HEIGHT = TEXTBOX_HEIGHT;
        private const int BUTTON_WIDTH = BUTTON_HEIGHT;
        // initial panel properties
        private const int PANEL_LOCATION_X = 1;
        private const int PANEL_LOCATION_Y = 1;
        private const string WIDEST_CHARACTER = "W";
        #endregion

        #region Krypton Variables
        //Palette State
        private KryptonManager _manager = new KryptonManager();
        private PaletteBackInheritRedirect _paletteBack;
        private PaletteBorderInheritRedirect _paletteBorder;
        private PaletteContentInheritRedirect _paletteContent;

        private IPalette _palette;
        private PaletteRedirect _paletteRedirect;
        #endregion

        #region Variables
        private bool _useCheckButton;

        private Color _backColour = BACK_COLOUR, _foreColour = FORE_COLOUR;

        private int _textboxMaximumWidth = TEXTBOX_MAXIMUM_WIDTH;
        #endregion

        #region Properties
        public bool UseCheckButton { get => _useCheckButton; set { _useCheckButton = value; Invalidate(); } }
        #endregion

        #region Event Triggers
        public virtual void TriggerPasswordEyePoropertiesChangedEvent()
        {
            if (PasswordEyePropertiesChanged != null)
            {
                PasswordEyePropertiesChanged(this, new PasswordEyePropertiesChangedEventArgs(_backColour, kchkbtnRevealPassword, this, _foreColour, _textboxMaximumWidth, pnlTextField, ktxtPasswordField));
            }
        }
        #endregion

        #region Constructors
        public KryptonPasswordEyeTextBox()
        {
            InitializeComponent();

            kchkbtnRevealPassword.MouseDown += KchkbtnRevealPassword_MouseDown;

            kchkbtnRevealPassword.MouseUp += KchkbtnRevealPassword_MouseUp;

            kbtnRevealPassword.MouseDown += KbtnRevealPassword_MouseDown;

            kbtnRevealPassword.MouseUp += KbtnRevealPassword_MouseUp;

            ktxtPasswordField.FontChanged += KtxtPasswordField_FontChanged;

            ktxtPasswordField.TextChanged += KtxtPasswordField_TextChanged;
        }
        #endregion

        #region Methods
        private int TextboxTextWidth()
        {
            string textboxText = string.Empty;
            int width = 0;
            // build a test string so we 
            // can find the width needed 
            // for the textbox
            while (textboxText.Length < _textboxMaximumWidth)
            {
                textboxText += WIDEST_CHARACTER;
            }

            using (Graphics graphics = ktxtPasswordField.CreateGraphics())
            {
                Size size = TextRenderer.MeasureText(graphics, textboxText, ktxtPasswordField.StateCommon.Content.Font, new Size(1, 1), TextFormatFlags.NoPadding);
                // MeasureText does not appear 
                // to return a correct length; 
                // 2/3 seems to help
                width = Round((2.0 * (double)size.Width) / 3.0);
            }

            return (width);
        }

        private int Round(double value) => ((int)(value + 0.5));

        private void SetControlProperties()
        {
            int button_location_y = 0;
            // remove all components from 
            // the control
            this.Controls.Clear();
            // remove all components from 
            // the panel
            pnlButton.Controls.Clear();
            pnlTextField.Controls.Clear();
            // process textbox first; the 
            // textbox width is dependent 
            // on the Font and the 
            // Max_Display properties; in
            // turn the textbox properties 
            // drive most of the control's 
            // other properties
            ktxtPasswordField.BackColor = _backColour;
            ktxtPasswordField.ForeColor = _foreColour;
            // textbox location within 
            // panel is fixed 
            ktxtPasswordField.Location = new Point(TEXTBOX_LOCATION_X, TEXTBOX_LOCATION_Y);
            ktxtPasswordField.Size = new Size(TextboxTextWidth(), ktxtPasswordField.Height);
            // process button next; the 
            // panel width depends upon 
            // both the textbox and button 
            // properties
            kbtnRevealPassword.BackColor = _backColour;
            kbtnRevealPassword.BackgroundImage = Properties.Resources.PasswordEyeImage;
            kbtnRevealPassword.BackgroundImageLayout = ImageLayout.Zoom;

            kchkbtnRevealPassword.BackColor = _backColour;

            kchkbtnRevealPassword.BackgroundImage = Properties.Resources.PasswordEyeImage;

            kchkbtnRevealPassword.BackgroundImageLayout = ImageLayout.Zoom;
            // when the textbox.Height is 
            // greater than TEXTBOX_HEIGHT 
            // the button.Size takes on 
            // the value 
            //      ( BUTTON_HEIGHT, 
            //        BUTTON_WIDTH ) 
            // and the button is centered 
            // vertically with respect to 
            // the textbox
            if (ktxtPasswordField.Height > TEXTBOX_HEIGHT)
            {
                button.Size = new Size(BUTTON_HEIGHT, BUTTON_WIDTH);
                button_location_y =
                    round((double)(textbox.Height -
                                         button.Height) / 2.0);
            }
            else
            {
                button.Size = new Size(textbox.Height,
                                         textbox.Height);
                button_location_y = textbox.Location.Y;
            }
            button.Location = new Point(textbox.Location.X +
                                              textbox.Width + 1,
                                          button_location_y);
            // process panel
            panel.BackColor = backcolor;
            // panel location within 
            // control is fixed
            panel.Location = new Point(PANEL_LOCATION_X,
                                         PANEL_LOCATION_Y);
            panel.Size = new Size(
                                    // space preceeds textbox
                                    (textbox.Location.X + 1) +
                                        // space follows textbox
                                        (textbox.Width + 1) +
                                        // space follows button
                                        (button.Width + 1),
                                    // space at top and bottom
                                    (textbox.Height + 2));
            // add back the TextBox and 
            // the Button to the Panel's 
            // control collection
            panel.Controls.Add(textbox);
            panel.Controls.Add(button);
            // add back the Panel to the 
            // control's control 
            // collection
            this.Controls.Add(panel);
            // adjust the width and height 
            // of the control by adding a 
            // pixel at the right, left,
            // top, and bottom
            this.Width = panel.Width + 2;
            this.Height = panel.Height + 2;
            // advise any subscriber that 
            // the control properties have 
            // changed
            TriggerPasswordEyePoropertiesChangedEvent();
        }
        #endregion

        #region Overrides
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            SetControlProperties();
        }
        #endregion

        #region Event Handlers
        private void KtxtPasswordField_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void KtxtPasswordField_FontChanged(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void KchkbtnRevealPassword_MouseUp(object sender, MouseEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void KchkbtnRevealPassword_MouseDown(object sender, MouseEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void KbtnRevealPassword_MouseUp(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void KbtnRevealPassword_MouseDown(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}