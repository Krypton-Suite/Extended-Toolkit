namespace Krypton.Toolkit.Suite.Extended.Dock.Extender
{
    public partial class KryptonOverlayForm : KryptonForm
    {
        #region Public

        public new DockStyle Dock;

        public Control? DockHostControl;

        #endregion

        public KryptonOverlayForm()
        {
            InitializeComponent();
        }
    }
}
