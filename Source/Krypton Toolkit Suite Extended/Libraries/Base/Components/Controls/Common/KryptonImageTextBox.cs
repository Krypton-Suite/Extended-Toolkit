using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    public class KryptonImageTextBox : UserControl
    {
        #region Design Code
        private KryptonTextBox ktxtInternalTextBox;
        private PictureBox pbxImageLeft;
        private PictureBox pbxImageRight;
        private Panel pnlLeft;
        private Panel pnlRight;
        private Panel pnlContent;

        private void InitializeComponent()
        {
            this.ktxtInternalTextBox = new Krypton.Toolkit.KryptonTextBox();
            this.pbxImageLeft = new System.Windows.Forms.PictureBox();
            this.pbxImageRight = new System.Windows.Forms.PictureBox();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImageLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImageRight)).BeginInit();
            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // ktxtInternalTextBox
            // 
            this.ktxtInternalTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ktxtInternalTextBox.Location = new System.Drawing.Point(0, 0);
            this.ktxtInternalTextBox.Name = "ktxtInternalTextBox";
            this.ktxtInternalTextBox.Size = new System.Drawing.Size(226, 23);
            this.ktxtInternalTextBox.TabIndex = 0;
            // 
            // pbxImageLeft
            // 
            this.pbxImageLeft.BackColor = System.Drawing.Color.Transparent;
            this.pbxImageLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxImageLeft.Location = new System.Drawing.Point(0, 0);
            this.pbxImageLeft.Name = "pbxImageLeft";
            this.pbxImageLeft.Size = new System.Drawing.Size(23, 23);
            this.pbxImageLeft.TabIndex = 1;
            this.pbxImageLeft.TabStop = false;
            // 
            // pbxImageRight
            // 
            this.pbxImageRight.BackColor = System.Drawing.Color.Transparent;
            this.pbxImageRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxImageRight.Location = new System.Drawing.Point(0, 0);
            this.pbxImageRight.Name = "pbxImageRight";
            this.pbxImageRight.Size = new System.Drawing.Size(23, 23);
            this.pbxImageRight.TabIndex = 2;
            this.pbxImageRight.TabStop = false;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.pbxImageLeft);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(23, 23);
            this.pnlLeft.TabIndex = 3;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pbxImageRight);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(249, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(23, 23);
            this.pnlRight.TabIndex = 4;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.ktxtInternalTextBox);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(23, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(226, 23);
            this.pnlContent.TabIndex = 3;
            // 
            // KryptonImageTextBox
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Name = "KryptonImageTextBox";
            this.Size = new System.Drawing.Size(272, 23);
            ((System.ComponentModel.ISupportInitialize)(this.pbxImageLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImageRight)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region Properties
        private Image _image;

        private KryptonTextBoxImageAlignment _imageAlignment;
        #endregion

        #region Properties
        public KryptonTextBox InternalTextBox { get => ktxtInternalTextBox; }

        public Image Image { get => _image; set { _image = value; Invalidate(); } }

        public KryptonTextBoxImageAlignment ImageAlignment { get => _imageAlignment; set { _imageAlignment = value; Invalidate(); } }
        #endregion

        #region Constructor
        public KryptonImageTextBox()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods
        private void SetImage(Image image)
        {
            if (ImageAlignment == KryptonTextBoxImageAlignment.LEFT)
            {
                pbxImageLeft.Image = image;
            }
            else if (ImageAlignment == KryptonTextBoxImageAlignment.RIGHT)
            {
                pbxImageRight.Image = image;
            }
        }
        #endregion

        #region Overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            if (ImageAlignment == KryptonTextBoxImageAlignment.LEFT)
            {
                pnlLeft.Visible = true;

                pnlRight.Visible = false;
            }
            else if (ImageAlignment == KryptonTextBoxImageAlignment.RIGHT)
            {
                pnlLeft.Visible = false;

                pnlRight.Visible = true;
            }

            SetImage(Image);

            base.OnPaint(e);
        }
        #endregion
    }
}