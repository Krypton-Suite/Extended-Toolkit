using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Dialogs
{
    public class TypefacePreviewControl : UserControl
    {
        #region Desin Code
        private Suite.Extended.Standard.Controls.KryptonGroupBoxExtended kgbTypefacePreview;
        private Suite.Extended.Standard.Controls.KryptonLabelExtended klblTypefacePreview;

        private void InitializeComponent()
        {
            this.kgbTypefacePreview = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonGroupBoxExtended();
            this.klblTypefacePreview = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonLabelExtended();
            ((System.ComponentModel.ISupportInitialize)(this.kgbTypefacePreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kgbTypefacePreview.Panel)).BeginInit();
            this.kgbTypefacePreview.Panel.SuspendLayout();
            this.kgbTypefacePreview.SuspendLayout();
            this.SuspendLayout();
            // 
            // kgbTypefacePreview
            // 
            this.kgbTypefacePreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kgbTypefacePreview.Image = null;
            this.kgbTypefacePreview.Location = new System.Drawing.Point(0, 0);
            this.kgbTypefacePreview.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kgbTypefacePreview.Name = "kgbTypefacePreview";
            // 
            // kgbTypefacePreview.Panel
            // 
            this.kgbTypefacePreview.Panel.Controls.Add(this.klblTypefacePreview);
            this.kgbTypefacePreview.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgbTypefacePreview.Size = new System.Drawing.Size(401, 242);
            this.kgbTypefacePreview.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kgbTypefacePreview.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgbTypefacePreview.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kgbTypefacePreview.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kgbTypefacePreview.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kgbTypefacePreview.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kgbTypefacePreview.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kgbTypefacePreview.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kgbTypefacePreview.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kgbTypefacePreview.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kgbTypefacePreview.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kgbTypefacePreview.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kgbTypefacePreview.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kgbTypefacePreview.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kgbTypefacePreview.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kgbTypefacePreview.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kgbTypefacePreview.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kgbTypefacePreview.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kgbTypefacePreview.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kgbTypefacePreview.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kgbTypefacePreview.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kgbTypefacePreview.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kgbTypefacePreview.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kgbTypefacePreview.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kgbTypefacePreview.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kgbTypefacePreview.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kgbTypefacePreview.TabIndex = 0;
            this.kgbTypefacePreview.Values.Heading = "Typeface Preview";
            // 
            // klblTypefacePreview
            // 
            this.klblTypefacePreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.klblTypefacePreview.Image = null;
            this.klblTypefacePreview.Location = new System.Drawing.Point(0, 0);
            this.klblTypefacePreview.LongTextTypeface = null;
            this.klblTypefacePreview.Name = "klblTypefacePreview";
            this.klblTypefacePreview.ShortTextTypeface = null;
            this.klblTypefacePreview.Size = new System.Drawing.Size(397, 222);
            this.klblTypefacePreview.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblTypefacePreview.StateCommon.ShortText.TextV = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblTypefacePreview.StateCommonTextColourOne = System.Drawing.Color.Empty;
            this.klblTypefacePreview.StateCommonTextColourTwo = System.Drawing.Color.Empty;
            this.klblTypefacePreview.StateDisabledTextColourOne = System.Drawing.Color.Empty;
            this.klblTypefacePreview.StateDisabledTextColourTwo = System.Drawing.Color.Empty;
            this.klblTypefacePreview.StateNormalTextColourOne = System.Drawing.Color.Empty;
            this.klblTypefacePreview.StateNormalTextColourTwo = System.Drawing.Color.Empty;
            this.klblTypefacePreview.TabIndex = 0;
            this.klblTypefacePreview.Values.Text = "Test Text 123 #+-*";
            // 
            // TypefacePreviewControl
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.kgbTypefacePreview);
            this.Name = "TypefacePreviewControl";
            this.Size = new System.Drawing.Size(401, 242);
            ((System.ComponentModel.ISupportInitialize)(this.kgbTypefacePreview.Panel)).EndInit();
            this.kgbTypefacePreview.Panel.ResumeLayout(false);
            this.kgbTypefacePreview.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kgbTypefacePreview)).EndInit();
            this.kgbTypefacePreview.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private Color _typefacePreviewColourOne, _typefacePreviewColourTwo;

        private Font _headerTypeface, _typefacePreview;

        private string _headerText, _typefacePreviewText;
        #endregion

        #region Properties
        public Color TypefacePreviewColourOne { get => _typefacePreviewColourOne; set { _typefacePreviewColourOne = value; Invalidate(); } }

        public Color TypefacePreviewColourTwo { get => _typefacePreviewColourTwo; set { _typefacePreviewColourTwo = value; Invalidate(); } }

        public Font HeaderTypeface { get => _headerTypeface; set { _headerTypeface = value; Invalidate(); } }

        public Font TypefacePreview { get => _typefacePreview; set { _typefacePreview = value; Invalidate(); } }

        [DefaultValue("Typeface Preview")]
        public string HeaderText { get => _headerText; set { _headerText = value; Invalidate(); } }

        [DefaultValue("Test Text 123 #+-*")]
        public string TypefacePreviewText { get => _typefacePreviewText; set { _typefacePreviewText = value; Invalidate(); } }
        #endregion

        #region Constructor
        public TypefacePreviewControl()
        {
            InitializeComponent();

            SetupControl();
        }
        #endregion

        #region Methods
        private void SetupControl()
        {
            TypefacePreviewColourOne = klblTypefacePreview.StateCommonTextColourOne;

            TypefacePreviewColourTwo = klblTypefacePreview.StateCommonTextColourTwo;

            HeaderTypeface = kgbTypefacePreview.ShortTextTypeface;

            TypefacePreview = klblTypefacePreview.ShortTextTypeface;

            HeaderText = kgbTypefacePreview.Values.Heading;

            TypefacePreviewText = klblTypefacePreview.Text;
        }

        private void UpdateTypefacePreviewColour(Color firstColour, Color secondColour)
        {
            klblTypefacePreview.StateCommonTextColourOne = firstColour;

            klblTypefacePreview.StateCommonTextColourTwo = secondColour;
        }
        #endregion

        #region Overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            UpdateTypefacePreviewColour(TypefacePreviewColourOne, TypefacePreviewColourTwo);

            kgbTypefacePreview.ShortTextTypeface = HeaderTypeface;

            klblTypefacePreview.ShortTextTypeface = TypefacePreview;

            kgbTypefacePreview.Values.Heading = HeaderText;

            klblTypefacePreview.Text = TypefacePreviewText;

            base.OnPaint(e);
        }
        #endregion
    }
}