namespace Krypton.Toolkit.Suite.Extended.Forms
{
    [ToolboxItem(false), DesignerCategory(@"code")]
    public class FadeValues : Storage
    {
        #region Instance Variables

        private bool _useFade;

        private FadeController _fadeController = new();

        private int _fadeInterval;

        private KryptonFormExtended _currentWindow;

        private KryptonFormExtended _nextWindow;

        private VirtualForm _currentVirtualWindow;

        private VirtualForm _nextVirtualWindow;

        #endregion

        #region Public

        [DefaultValue(false)]
        public bool UseFade { get => _useFade; set => _useFade = value; }

        internal FadeController FadeController => _fadeController;

        [DefaultValue(50)]
        public int FadeInterval { get => _fadeInterval; set => _fadeInterval = value; }

        [DefaultValue(null)]
        public KryptonFormExtended CurrentWindow { get => _currentWindow; set => _currentWindow = value; }

        [DefaultValue(null)]
        public KryptonFormExtended NextWindow { get => _nextWindow; set => _nextWindow = value; }

        [DefaultValue(null)]
        public VirtualForm CurrentVirtualWindow { get => _currentVirtualWindow; set => _currentVirtualWindow = value; }

        [DefaultValue(null)]
        public VirtualForm NextVirtualWindow { get => _nextVirtualWindow; set => _nextVirtualWindow = value; }

        #endregion

        #region Identity

        public FadeValues() => Reset();

        internal void Reset()
        {
            UseFade = false;

            FadeInterval = 50;

            CurrentWindow = null;

            NextWindow = null;

            CurrentVirtualWindow = null;

            NextVirtualWindow = null;
        }

        #endregion

        #region Default Instance

        public override bool IsDefault => UseFade == false &&
                                          FadeInterval.Equals(50) &&
                                          CurrentWindow.Equals(null) &&
                                          NextWindow.Equals(null) &&
                                          CurrentVirtualWindow.Equals(null) &&
                                          NextVirtualWindow.Equals(null);

        #endregion
    }
}