using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Base
{
    public class KryptonTypefaceStyle : UserControl
    {
        #region Designer Code
        private Krypton.Toolkit.KryptonCheckBox kchkUnderline;
        private Krypton.Toolkit.KryptonCheckBox kchkStrikeout;
        private Krypton.Toolkit.KryptonCheckBox kchkItalic;
        private Krypton.Toolkit.KryptonCheckBox kchkBold;
        private Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;

        private void InitializeComponent()
        {
            this.kryptonGroupBox1 = new Krypton.Toolkit.KryptonGroupBox();
            this.kchkBold = new Krypton.Toolkit.KryptonCheckBox();
            this.kchkItalic = new Krypton.Toolkit.KryptonCheckBox();
            this.kchkStrikeout = new Krypton.Toolkit.KryptonCheckBox();
            this.kchkUnderline = new Krypton.Toolkit.KryptonCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.CaptionStyle = Krypton.Toolkit.LabelStyle.GroupBoxCaption;
            this.kryptonGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonGroupBox1.GroupBackStyle = Krypton.Toolkit.PaletteBackStyle.ControlGroupBox;
            this.kryptonGroupBox1.GroupBorderStyle = Krypton.Toolkit.PaletteBorderStyle.ControlGroupBox;
            this.kryptonGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.kchkUnderline);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kchkStrikeout);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kchkItalic);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kchkBold);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(242, 193);
            this.kryptonGroupBox1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonGroupBox1.StateCommon.Content.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kryptonGroupBox1.StateCommon.Content.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kryptonGroupBox1.TabIndex = 1;
            this.kryptonGroupBox1.Values.Heading = "Typeface Style";
            // 
            // kchkBold
            // 
            this.kchkBold.Location = new System.Drawing.Point(14, 13);
            this.kchkBold.Name = "kchkBold";
            this.kchkBold.Size = new System.Drawing.Size(60, 26);
            this.kchkBold.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kchkBold.StateCommon.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kchkBold.StateCommon.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kchkBold.TabIndex = 2;
            this.kchkBold.Values.Text = "&Bold";
            // 
            // kchkItalic
            // 
            this.kchkItalic.Location = new System.Drawing.Point(14, 48);
            this.kchkItalic.Name = "kchkItalic";
            this.kchkItalic.Size = new System.Drawing.Size(59, 26);
            this.kchkItalic.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kchkItalic.StateCommon.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kchkItalic.StateCommon.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kchkItalic.TabIndex = 3;
            this.kchkItalic.Values.Text = "I&talic";
            // 
            // kchkStrikeout
            // 
            this.kchkStrikeout.Location = new System.Drawing.Point(14, 83);
            this.kchkStrikeout.Name = "kchkStrikeout";
            this.kchkStrikeout.Size = new System.Drawing.Size(90, 26);
            this.kchkStrikeout.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kchkStrikeout.StateCommon.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kchkStrikeout.StateCommon.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kchkStrikeout.TabIndex = 4;
            this.kchkStrikeout.Values.Text = "Str&ikeout";
            // 
            // kchkUnderline
            // 
            this.kchkUnderline.Location = new System.Drawing.Point(14, 118);
            this.kchkUnderline.Name = "kchkUnderline";
            this.kchkUnderline.Size = new System.Drawing.Size(95, 26);
            this.kchkUnderline.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kchkUnderline.StateCommon.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kchkUnderline.StateCommon.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kchkUnderline.TabIndex = 5;
            this.kchkUnderline.Values.Text = "&Underline";
            // 
            // KryptonTypefaceStyle
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.kryptonGroupBox1);
            this.Name = "KryptonTypefaceStyle";
            this.Size = new System.Drawing.Size(242, 193);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            this.kryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private bool _bold, _italic, _strikeout, _underline;

        private string _boldString, _italicString, _strikeoutString, _underlineString;
        #endregion

        #region Properties

        #endregion

        #region Constructors
        public KryptonTypefaceStyle()
        {
            InitializeComponent();
        }
        #endregion
    }
}