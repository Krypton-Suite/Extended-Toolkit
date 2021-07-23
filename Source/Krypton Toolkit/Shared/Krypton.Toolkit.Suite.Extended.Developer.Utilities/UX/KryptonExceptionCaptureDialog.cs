namespace Krypton.Toolkit.Suite.Extended.Developer.Utilities
{
    /// <summary>
    /// A window that allows the developer to capture an exception, and present it in a window.
    /// </summary>
    public class KryptonExceptionCaptureDialog : KryptonForm
    {
        #region Design Code
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonPanel kryptonPanel2;
        private KryptonRichTextBox krtbException;
        private KryptonButton kbtnCancel;
        private KryptonButton kbtnExportException;
        private KryptonPanel kryptonPanel1;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KryptonExceptionCaptureDialog));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.krtbException = new Krypton.Toolkit.KryptonRichTextBox();
            this.kbtnExportException = new Krypton.Toolkit.KryptonButton();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Controls.Add(this.kbtnExportException);
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 529);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(764, 50);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderSecondary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(764, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.krtbException);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(764, 529);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // krtbException
            // 
            this.krtbException.Location = new System.Drawing.Point(13, 13);
            this.krtbException.Name = "krtbException";
            this.krtbException.ReadOnly = true;
            this.krtbException.Size = new System.Drawing.Size(739, 501);
            this.krtbException.TabIndex = 0;
            this.krtbException.Text = "";
            // 
            // kbtnExportException
            // 
            this.kbtnExportException.Location = new System.Drawing.Point(13, 13);
            this.kbtnExportException.Name = "kbtnExportException";
            this.kbtnExportException.Size = new System.Drawing.Size(119, 25);
            this.kbtnExportException.TabIndex = 1;
            this.kbtnExportException.Values.Text = "Export &Exception";
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(662, 13);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.TabIndex = 2;
            this.kbtnCancel.Values.Text = "C&ancel";
            // 
            // KryptonExceptionCaptureDialog
            // 
            this.ClientSize = new System.Drawing.Size(764, 579);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonExceptionCaptureDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region Fields
        private Exception _exception;
        #endregion

        #region Properties
        public Exception Exception { get => _exception; set => _exception = value; }
        #endregion

        #region Constructors
        public KryptonExceptionCaptureDialog(Exception exception)
        {
            InitializeComponent();

            Exception = exception;

            CaptureException(Exception);
        }
        #endregion

        #region Methods
        private void CaptureException(Exception exception)
        {
            krtbException.Text = exception.Message;
        }
        #endregion
    }
}
