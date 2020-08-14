using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    public class KryptonTypefaceExample : UserControl
    {
        #region Designer Code
        private Krypton.Toolkit.KryptonLabel klblPreview;
        private Krypton.Toolkit.KryptonGroupBox kgbContent;

        private void InitializeComponent()
        {
            this.kgbContent = new Krypton.Toolkit.KryptonGroupBox();
            this.klblPreview = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kgbContent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kgbContent.Panel)).BeginInit();
            this.kgbContent.Panel.SuspendLayout();
            this.kgbContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // kgbContent
            // 
            this.kgbContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kgbContent.Location = new System.Drawing.Point(0, 0);
            this.kgbContent.Name = "kgbContent";
            // 
            // kgbContent.Panel
            // 
            this.kgbContent.Panel.Controls.Add(this.klblPreview);
            this.kgbContent.Size = new System.Drawing.Size(259, 168);
            this.kgbContent.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kgbContent.TabIndex = 0;
            this.kgbContent.Values.Heading = "Current Preview";
            // 
            // klblPreview
            // 
            this.klblPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.klblPreview.Location = new System.Drawing.Point(0, 0);
            this.klblPreview.Name = "klblPreview";
            this.klblPreview.Size = new System.Drawing.Size(255, 138);
            this.klblPreview.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblPreview.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblPreview.StateCommon.ShortText.TextV = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblPreview.TabIndex = 0;
            this.klblPreview.Values.Text = "AaBbCc123#+*-";
            // 
            // KryptonTypefaceExample
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.kgbContent);
            this.Name = "KryptonTypefaceExample";
            this.Size = new System.Drawing.Size(259, 168);
            this.Load += new System.EventHandler(this.KryptonTypefaceExample_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kgbContent.Panel)).EndInit();
            this.kgbContent.Panel.ResumeLayout(false);
            this.kgbContent.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kgbContent)).EndInit();
            this.kgbContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private Font _typeface, _headerTypeface;

        private string _headerText, _sampleText;
        #endregion

        #region Properties
        [DefaultValue(typeof(Font), "Microsoft Sans Serif, 8.25f")]
        public Font Typeface { get => _typeface; set { _typeface = value; Invalidate(); } }

        [DefaultValue(typeof(Font), "Microsoft Sans Serif, 8.25f, FontStyle.Bold")]
        public Font HheaderTypeface { get => _headerTypeface; set { _headerTypeface = value; Invalidate(); } }

        public string HeaderText { get => _headerText; set { _headerText = value; Invalidate(); } }

        public string SampleText { get => _sampleText; set { _sampleText = value; Invalidate(); } }
        #endregion

        #region Constructor
        public KryptonTypefaceExample()
        {
            InitializeComponent();
        }
        #endregion

        private void KryptonTypefaceExample_Load(object sender, EventArgs e)
        {
            Typeface = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);

            HheaderTypeface = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);

            HeaderText = "Sample Typeface";

            SampleText = "AaBbCc123#+*-";
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            SetTypeface(Typeface);

            SetHeaderText(HeaderText);

            SetHheaderTypeface(HheaderTypeface);

            SetSampleText(SampleText);

            base.OnPaint(e);
        }

        #region Methods
        private void SetTypeface(Font typeface) => klblPreview.StateCommon.ShortText.Font = typeface;

        private void SetHheaderTypeface(Font typeface) => kgbContent.StateCommon.Content.ShortText.Font = typeface;

        private void SetHeaderText(string headerText) => kgbContent.Values.Heading = headerText;

        private void SetSampleText(string sampleText) => klblPreview.Text = sampleText;
        #endregion
    }
}