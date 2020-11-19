using System;
using System.ComponentModel;
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
            this.kbtnRevealPassword = new Krypton.Toolkit.KryptonButton();
            this.kchkbtnRevealPassword = new Krypton.Toolkit.KryptonCheckButton();
            this.pnlTextField = new System.Windows.Forms.Panel();
            this.ktxtPasswordField = new Krypton.Toolkit.KryptonTextBox();
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
            // kbtnRevealPassword
            // 
            this.kbtnRevealPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kbtnRevealPassword.Location = new System.Drawing.Point(0, 0);
            this.kbtnRevealPassword.Name = "kbtnRevealPassword";
            this.kbtnRevealPassword.Size = new System.Drawing.Size(27, 27);
            this.kbtnRevealPassword.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.kbtnRevealPassword.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.kbtnRevealPassword.StateCommon.Back.Image = global::Krypton.Toolkit.Suite.Extended.Base.Properties.Resources.Eye_Icon;
            this.kbtnRevealPassword.TabIndex = 1;
            this.kbtnRevealPassword.ToolTipValues.Description = "Reveals the password in the textbox.";
            this.kbtnRevealPassword.ToolTipValues.EnableToolTips = true;
            this.kbtnRevealPassword.ToolTipValues.Heading = "Reveal Password";
            this.kbtnRevealPassword.ToolTipValues.Image = global::Krypton.Toolkit.Suite.Extended.Base.Properties.Resources.PasswordEyeImage;
            this.kbtnRevealPassword.Values.Text = "";
            // 
            // kchkbtnRevealPassword
            // 
            this.kchkbtnRevealPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kchkbtnRevealPassword.Location = new System.Drawing.Point(0, 0);
            this.kchkbtnRevealPassword.Name = "kchkbtnRevealPassword";
            this.kchkbtnRevealPassword.Size = new System.Drawing.Size(27, 27);
            this.kchkbtnRevealPassword.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.kchkbtnRevealPassword.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.kchkbtnRevealPassword.StateCommon.Back.Image = global::Krypton.Toolkit.Suite.Extended.Base.Properties.Resources.Eye_Icon;
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

        private string _password;
        #endregion

        #region Properties
        /// <summary>Use a KryptonCheckButton instead of a KryptonButton.</summary>
        /// <value><c>true</c> if [use check button]; otherwise, <c>false</c>.</value>
        [DefaultValue(false), Description("Use a KryptonCheckButton instead of a KryptonButton.")]
        public bool UseCheckButton { get => _useCheckButton; set { _useCheckButton = value; Invalidate(); } }

        /// <summary>Gets the stored password.</summary>
        /// <value>The password.</value>
        [DefaultValue(""), Description("Gets the stored password.")]
        public string Password { get => _password; private set => _password = value; }
        #endregion

        #region Constructors
        public KryptonPasswordEyeTextBox()
        {
            InitializeComponent();

            kchkbtnRevealPassword.CheckedChanged += KchkbtnRevealPassword_CheckedChanged;

            kbtnRevealPassword.MouseDown += KbtnRevealPassword_MouseDown;

            kbtnRevealPassword.MouseUp += KbtnRevealPassword_MouseUp;

            ktxtPasswordField.FontChanged += KtxtPasswordField_FontChanged;

            ktxtPasswordField.TextChanged += KtxtPasswordField_TextChanged;
        }
        #endregion

        #region Overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            kbtnRevealPassword.Visible = UseCheckButton;
        }
        #endregion

        #region Event Handlers
        private void KtxtPasswordField_TextChanged(object sender, EventArgs e) => Password = ktxtPasswordField.Text;

        private void KtxtPasswordField_FontChanged(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void KchkbtnRevealPassword_CheckedChanged(object sender, EventArgs e) => ktxtPasswordField.UseSystemPasswordChar = kchkbtnRevealPassword.Checked;

        private void KbtnRevealPassword_MouseUp(object sender, MouseEventArgs e) => ktxtPasswordField.UseSystemPasswordChar = false;

        private void KbtnRevealPassword_MouseDown(object sender, MouseEventArgs e) => ktxtPasswordField.UseSystemPasswordChar = true;
        #endregion
    }
}