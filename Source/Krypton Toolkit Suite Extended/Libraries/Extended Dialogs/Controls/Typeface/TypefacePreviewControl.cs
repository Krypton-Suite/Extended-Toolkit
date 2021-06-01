#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    public class TypefacePreviewControl : UserControl
    {
        #region Design Code
        private KryptonGroupBox kgbTypefacePreview;
        private KryptonLabel klblTypefacePreview;

        private void InitializeComponent()
        {
            this.kgbTypefacePreview = new KryptonGroupBox();
            this.klblTypefacePreview = new KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kgbTypefacePreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kgbTypefacePreview.Panel)).BeginInit();
            this.kgbTypefacePreview.Panel.SuspendLayout();
            this.kgbTypefacePreview.SuspendLayout();
            this.SuspendLayout();
            // 
            // kgbTypefacePreview
            // 
            this.kgbTypefacePreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kgbTypefacePreview.Location = new System.Drawing.Point(0, 0);
            this.kgbTypefacePreview.Name = "kgbTypefacePreview";
            // 
            // kgbTypefacePreview.Panel
            // 
            this.kgbTypefacePreview.Panel.Controls.Add(this.klblTypefacePreview);
            this.kgbTypefacePreview.Size = new System.Drawing.Size(240, 140);
            this.kgbTypefacePreview.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kgbTypefacePreview.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgbTypefacePreview.TabIndex = 0;
            this.kgbTypefacePreview.Values.Heading = "Typeface Preview";
            // 
            // klblTypefacePreview
            // 
            this.klblTypefacePreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.klblTypefacePreview.Location = new System.Drawing.Point(0, 0);
            this.klblTypefacePreview.Name = "klblTypefacePreview";
            this.klblTypefacePreview.Size = new System.Drawing.Size(236, 120);
            this.klblTypefacePreview.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblTypefacePreview.StateCommon.ShortText.TextV = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblTypefacePreview.TabIndex = 0;
            this.klblTypefacePreview.Values.Text = "Test Text 123 #+-*";
            // 
            // TypefacePreviewControl
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.kgbTypefacePreview);
            this.Name = "TypefacePreviewControl";
            this.Size = new System.Drawing.Size(240, 140);
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
        public Color TypefacePreviewColourOne { get => klblTypefacePreview.StateCommon.ShortText.Color1; set => klblTypefacePreview.StateCommon.ShortText.Color1 = value; }

        public Color TypefacePreviewColourTwo { get => klblTypefacePreview.StateCommon.ShortText.Color2; set => klblTypefacePreview.StateCommon.ShortText.Color2 = value; }

        public Font HeaderTypeface { get => kgbTypefacePreview.StateCommon.Content.ShortText.Font; set => kgbTypefacePreview.StateCommon.Content.ShortText.Font = value; }

        public Font TypefacePreview { get => klblTypefacePreview.StateCommon.ShortText.Font; set => klblTypefacePreview.StateCommon.ShortText.Font = value; }

        [DefaultValue("Typeface Preview")]
        public string HeaderText { get => kgbTypefacePreview.Values.Heading; set => kgbTypefacePreview.Values.Heading = value; }

        [DefaultValue("Test Text 123 #+-*")]
        public string TypefacePreviewText { get => klblTypefacePreview.Text; set => klblTypefacePreview.Text = value; }
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
            TypefacePreviewColourOne = klblTypefacePreview.StateCommon.ShortText.Color1;

            TypefacePreviewColourTwo = klblTypefacePreview.StateCommon.ShortText.Color2;

            HeaderTypeface = kgbTypefacePreview.StateCommon.Content.ShortText.Font;

            TypefacePreview = klblTypefacePreview.StateCommon.ShortText.Font;

            HeaderText = kgbTypefacePreview.Values.Heading;

            TypefacePreviewText = klblTypefacePreview.Text;
        }

        private void UpdateTypefacePreviewColour(Color firstColour, Color secondColour)
        {
            klblTypefacePreview.StateCommon.ShortText.Color1 = firstColour;

            klblTypefacePreview.StateCommon.ShortText.Color2 = secondColour;
        }
        #endregion

        #region Overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            //UpdateTypefacePreviewColour(TypefacePreviewColourOne, TypefacePreviewColourTwo);

            //kgbTypefacePreview.ShortTextTypeface = HeaderTypeface;

            //klblTypefacePreview.ShortTextTypeface = TypefacePreview;

            //kgbTypefacePreview.Values.Heading = HeaderText;

            //klblTypefacePreview.Text = TypefacePreviewText;

            base.OnPaint(e);
        }
        #endregion
    }
}