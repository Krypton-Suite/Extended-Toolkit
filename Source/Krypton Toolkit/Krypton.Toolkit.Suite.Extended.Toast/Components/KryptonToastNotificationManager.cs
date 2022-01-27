namespace Krypton.Toolkit.Suite.Extended.Toast
{
    public class KryptonToastNotificationManager : Component
    {
        #region Variables
        private bool _useUserResponse, _useProgressBar;

        private Color _userResponsePromptColour;

        private PaletteRelativeAlign _userResponsePromptAlignHorizontal, _userResponsePromptAlignVertical;

        private Font _userResponsePromptFont;

        private IconType _iconType;

        private int _time, _seconds;

        private Timer _timer;

        private SoundPlayer _soundPlayer;

        private string _title, _contentText, _soundPath, _dismissText, _userResponsePrompt;

        private Stream _soundStream;

        private Image _customImage;

        private RightToLeftSupport _rightToLeftSupport;

        private ContentAreaType _contentAreaType;
        #endregion

        #region Properties
        public bool UseUserResponsePrompt { get => _useUserResponse; set => _useUserResponse = value; }

        public bool UseProgressBar { get => _useProgressBar; set => _useProgressBar = value; }

        public Color UserResponsePromptColour { get => _userResponsePromptColour; set => _userResponsePromptColour = value; }

        public PaletteRelativeAlign UserResponsePromptAlignHorizontal { get => _userResponsePromptAlignHorizontal; set => _userResponsePromptAlignHorizontal = value; }

        public PaletteRelativeAlign UserResponsePromptAlignVertical { get => _userResponsePromptAlignVertical; set => _userResponsePromptAlignVertical = value; }

        public Font UserResponsePromptFont { get => _userResponsePromptFont; set => _userResponsePromptFont = value; }

        public IconType IconType { get => _iconType; set => _iconType = value; }

        public int Time { get => _time; set => _time = value; }

        public int Seconds { get => _seconds; set => _seconds = value; }

        public string Title { get => _title; set => _title = value; }

        public string ContentText { get => _contentText; set => _contentText = value; }

        public string SoundPath { get => _soundPath; set => _soundPath = value; }

        public string DismissText { get => _dismissText; set => _dismissText = value; }

        public string UserResponsePromptText { get => _userResponsePrompt; set => _userResponsePrompt = value; }

        public Stream SoundStream { get => _soundStream; set => _soundStream = value; }

        public Image CustomImage { get => _customImage; set => _customImage = value; }

        public RightToLeftSupport RightToLeftSupport { get => _rightToLeftSupport; set => _rightToLeftSupport = value; }

        public ContentAreaType ContentAreaType { get => _contentAreaType; set => _contentAreaType = value; }
        #endregion

        #region Custom Events
        public event EventHandler DisplayNotification;
        #endregion

        #region Constructor
        public KryptonToastNotificationManager(bool useUserResponse, string title, string contentText, Color? userResponsePromptColour = null,
                                               PaletteRelativeAlign userResponsePromptAlignHorizontal = PaletteRelativeAlign.Near,
                                               PaletteRelativeAlign userResponsePromptAlignVertical = PaletteRelativeAlign.Near,
                                               Font userResponsePromptFont = null, IconType iconType = IconType.NONE,
                                               int time = 0, int seconds = 0, string soundPath = null, string dismissText = "Di&smiss",
                                               string userResponsePromptText = "Type response here...", Stream soundStream = null,
                                               Image customImage = null, RightToLeftSupport rightToLeftSupport = RightToLeftSupport.LEFTTORIGHT,
                                               bool useProgressBar = false, ContentAreaType contentAreaType = ContentAreaType.WRAPPEDLABEL)
        {
            UseProgressBar = useProgressBar;

            UseUserResponsePrompt = useUserResponse;

            Title = title;

            ContentText = contentText;

            UserResponsePromptColour = userResponsePromptColour ?? Color.Gray;

            UserResponsePromptAlignHorizontal = userResponsePromptAlignHorizontal;

            UserResponsePromptAlignVertical = userResponsePromptAlignVertical;

            UserResponsePromptFont = userResponsePromptFont ?? new Font("Segoe UI", 8F);

            IconType = iconType;

            Time = time;

            Seconds = seconds;

            SoundPath = soundPath;

            DismissText = dismissText;

            UserResponsePromptText = userResponsePromptText;

            SoundStream = soundStream;

            CustomImage = customImage;

            RightToLeftSupport = rightToLeftSupport;

            ContentAreaType = contentAreaType;
        }
        #endregion

        #region Methods
        public void DisplayNotificationToast()
        {
            if (_rightToLeftSupport == RightToLeftSupport.LEFTTORIGHT)
            {
                if (!_useUserResponse)
                {
                    if (!_useProgressBar)
                    {
                        if (_contentAreaType == ContentAreaType.LABEL)
                        {
                            ApplicationUtilities.UnderConstruction();
                        }
                        else if (_contentAreaType == ContentAreaType.WRAPPEDLABEL)
                        {
                            BasicNotificationAlternativeUILTR notification = new BasicNotificationAlternativeUILTR(
                                IconType,
                                Title, ContentText, Seconds, SoundPath,
                                CustomImage, DismissText);

                            notification.Show();
                        }
                        else if (_contentAreaType == ContentAreaType.MULTILINEDTEXTBOX)
                        {
                            ApplicationUtilities.UnderConstruction();
                        }
                        else if (_contentAreaType == ContentAreaType.RICHTEXTBOX)
                        {
                            BasicNotificationLTR notification = new BasicNotificationLTR(IconType, Title, ContentText,
                                Seconds, SoundPath,
                                CustomImage, DismissText);

                            notification.Show();
                        }
                    }
                    else
                    {
                        if (_contentAreaType == ContentAreaType.LABEL)
                        {
                            ApplicationUtilities.UnderConstruction();
                        }
                        else if (_contentAreaType == ContentAreaType.WRAPPEDLABEL)
                        {
                            BasicNotificationWithProgressBarAlternativeUILTR notification =
                                new BasicNotificationWithProgressBarAlternativeUILTR(IconType, Title, ContentText,
                                    Seconds,
                                    SoundStream, CustomImage, DismissText);

                            notification.Show();
                        }
                        else if (_contentAreaType == ContentAreaType.MULTILINEDTEXTBOX)
                        {
                            ApplicationUtilities.UnderConstruction();
                        }
                        else if (_contentAreaType == ContentAreaType.RICHTEXTBOX)
                        {
                            BasicNotificationWithProgressBarLTR notification = new BasicNotificationWithProgressBarLTR(
                                IconType, Title, ContentText, Seconds, SoundStream,
                                CustomImage, DismissText);

                            notification.Show();
                        }
                    }
                }
                else
                {
                    if (!_useProgressBar)
                    {
                        if (_contentAreaType == ContentAreaType.LABEL)
                        {
                            ApplicationUtilities.UnderConstruction();
                        }
                        else if (_contentAreaType == ContentAreaType.WRAPPEDLABEL)
                        {
                            BasicNotificationWithUserResponseWrappedLabelLTR notification = new BasicNotificationWithUserResponseWrappedLabelLTR(IconType, Title, ContentText, Seconds,
                                                                                                                                                 SoundPath, CustomImage,
                                                                                                                                                 DismissText, UserResponsePromptText,
                                                                                                                                                 UserResponsePromptColour,
                                                                                                                                                 UserResponsePromptAlignHorizontal, 
                                                                                                                                                 UserResponsePromptAlignVertical,
                                                                                                                                                 UserResponsePromptFont);

                            notification.Show();
                        }
                        else if (_contentAreaType == ContentAreaType.MULTILINEDTEXTBOX)
                        {
                            ApplicationUtilities.UnderConstruction();
                        }
                        else if (_contentAreaType == ContentAreaType.RICHTEXTBOX)
                        {
                            BasicNotificationWithUserResponseLTR notification = new BasicNotificationWithUserResponseLTR(IconType, Title, ContentText, Seconds,
                                                                                                                         SoundPath, CustomImage,
                                                                                                                         DismissText, UserResponsePromptText, 
                                                                                                                         UserResponsePromptColour,
                                                                                                                         UserResponsePromptAlignHorizontal, UserResponsePromptAlignVertical,
                                                                                                                         UserResponsePromptFont);

                            notification.Show();
                        }
                    }
                }
            }
            else
            {
                if (!_useUserResponse)
                {
                    
                }
                else
                {
                    
                }
            }
        }

        public DialogResult DisplayNotificationToastResult()
        {
            DialogResult result = DialogResult.None;


            return result;
        }
        #endregion
    }
}