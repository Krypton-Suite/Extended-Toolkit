using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Base
{
    public class KryptonTypefaceExample : UserControl
    {
        #region Designer Code
        private Krypton.Toolkit.KryptonLabel klblPreview;
        private Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;

        private void InitializeComponent()
        {
            this.kryptonGroupBox1 = new Krypton.Toolkit.KryptonGroupBox();
            this.klblPreview = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.klblPreview);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(530, 281);
            this.kryptonGroupBox1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonGroupBox1.TabIndex = 0;
            this.kryptonGroupBox1.Values.Heading = "Current Preview";
            // 
            // klblPreview
            // 
            this.klblPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.klblPreview.Location = new System.Drawing.Point(0, 0);
            this.klblPreview.Name = "klblPreview";
            this.klblPreview.Size = new System.Drawing.Size(526, 251);
            this.klblPreview.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblPreview.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblPreview.StateCommon.ShortText.TextV = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblPreview.TabIndex = 0;
            this.klblPreview.Values.Text = "AaBbCc123#+*-";
            // 
            // KryptonTypefaceExample
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.kryptonGroupBox1);
            this.Name = "KryptonTypefaceExample";
            this.Size = new System.Drawing.Size(530, 281);
            this.Load += new System.EventHandler(this.KryptonTypefaceExample_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            this.kryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private Font _typeface;

        private string _headerText, _sampleText;
        #endregion

        #region Properties
        public Font Typeface { get => _typeface; set { _typeface = value; Invalidate(); } }

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
            Typeface = new Font("Segoe UI", 12f, FontStyle.Regular);

            HeaderText = "Sample Typeface";

            SampleText = "AaBbCc123#+*-";
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            SetTypeface(Typeface);

            SetHeaderText(HeaderText);

            SetSampleText(SampleText);

            base.OnPaint(e);
        }

        #region Methods
        private void SetTypeface(Font typeface) => klblPreview.StateCommon.ShortText.Font = typeface;

        private void SetHeaderText(string headerText) => kryptonGroupBox1.Values.Heading = headerText;

        private void SetSampleText(string sampleText) => klblPreview.Text = sampleText;
        #endregion
    }
}