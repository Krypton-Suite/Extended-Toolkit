using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    public class KryptonPasswordEyeTextBox : UserControl
    {
        #region Design Code
        private Panel panel1;
        private Panel panel2;
        private KryptonTextBox ktxtPasswordField;
        private KryptonCheckButton kchkbtnRevealPassword;

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.kchkbtnRevealPassword = new Krypton.Toolkit.KryptonCheckButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ktxtPasswordField = new Krypton.Toolkit.KryptonTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.kchkbtnRevealPassword);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(223, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(27, 27);
            this.panel1.TabIndex = 0;
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
            // panel2
            // 
            this.panel2.Controls.Add(this.ktxtPasswordField);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(223, 27);
            this.panel2.TabIndex = 1;
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
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "KryptonPasswordEyeTextBox";
            this.Size = new System.Drawing.Size(250, 27);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
    }
}