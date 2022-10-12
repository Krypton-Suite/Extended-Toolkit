namespace Krypton.Toolkit.Suite.Extended.Forms
{
    [ToolboxItem(false), DesignerCategory(@"code")]
    public class FadeValues : Storage
    {
        #region Instance Variables

        private bool _useFade;

        private InternalFadeController _fadeController = new InternalFadeController();

        private int _fadeInterval;

        private VirtualForm _currentWindow;

        private VirtualForm _nextWindow;

        #endregion

        #region Public

        [DefaultValue(false)]
        public bool UseFade { get => _useFade; set => _useFade = value; }

        internal InternalFadeController FadeController => _fadeController;

        [DefaultValue(50)]
        public int FadeInterval { get => _fadeInterval; set => _fadeInterval = value; }

        [DefaultValue(null)]
        public VirtualForm CurrentWindow { get => _currentWindow; set => _currentWindow = value; }

        [DefaultValue(null)]
        public VirtualForm NextWindow { get => _nextWindow; set => _nextWindow = value; }

        #endregion

        #region Identity

        public FadeValues() => Reset();

        internal void Reset()
        {
            UseFade = false;

            FadeInterval = 50;

            CurrentWindow = null;

            NextWindow = null;
        }

        #endregion

        public override bool IsDefault => UseFade == false &&
                                          FadeInterval.Equals(50) && 
                                          CurrentWindow.Equals(null) && 
                                          NextWindow.Equals(null);
    }
}