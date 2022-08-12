#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Toast
{
    public class KryptonToastNotificationManager : Component
    {
        #region Variables
        private bool _useUserResponse, _useProgressBar, _usePanelColourInTextArea, _useNativeBackColourInUserResponseArea;

        private Color _userResponsePromptColour;

        private PaletteRelativeAlign _userResponsePromptAlignHorizontal, _userResponsePromptAlignVertical;

        private Font _userResponsePromptFont;

        private KryptonToastNotificationIconType _iconType;

        private int _time, _seconds;

        private Timer _timer;

        private SoundPlayer _soundPlayer;

        private string _title, _contentText, _soundPath, _dismissText, _userResponsePrompt;

        private Stream _soundStream;

        private Image _customImage;

        private KryptonToastNotificationRightToLeftSupport _rightToLeftSupport;

        private KryptonToastNotificationContentAreaType _contentAreaType;
        #endregion

        #region Properties
        [DefaultValue(false), Description(@"Allows the user to type a response in a toast window.")]
        public bool UseUserResponsePrompt { get => _useUserResponse; set => _useUserResponse = value; }

        [DefaultValue(false), Description(@"Shows a progress bar in a toast window.")]
        public bool UseProgressBar { get => _useProgressBar; set => _useProgressBar = value; }

        [DefaultValue(false), Description(@"")]
        public bool UsePanelColourInTextArea { get => _usePanelColourInTextArea; set => _usePanelColourInTextArea = value; }

        [DefaultValue(false), Description(@"")]
        public bool UseNativeBackColourInUserResponseArea { get => _useNativeBackColourInUserResponseArea; set => _useNativeBackColourInUserResponseArea = value; }

        [DefaultValue(typeof(Color), "Color.Gray"), Description(@"")]
        public Color UserResponsePromptColour { get => _userResponsePromptColour; set => _userResponsePromptColour = value; }

        [DefaultValue(typeof(PaletteRelativeAlign), "PaletteRelativeAlign.Center"), Description(@"")]
        public PaletteRelativeAlign UserResponsePromptAlignHorizontal { get => _userResponsePromptAlignHorizontal; set => _userResponsePromptAlignHorizontal = value; }

        [DefaultValue(typeof(PaletteRelativeAlign), "PaletteRelativeAlign.Center"), Description(@"")]
        public PaletteRelativeAlign UserResponsePromptAlignVertical { get => _userResponsePromptAlignVertical; set => _userResponsePromptAlignVertical = value; }

        [DefaultValue(typeof(Font), "Segoe UI, 8.25F"), Description(@"")]
        public Font UserResponsePromptFont { get => _userResponsePromptFont; set => _userResponsePromptFont = value; }

        [DefaultValue(typeof(KryptonToastNotificationIconType), "IconType.NONE"), Description(@"")]
        public KryptonToastNotificationIconType IconType { get => _iconType; set => _iconType = value; }

        [DefaultValue(60), Description(@"")]
        public int Time { get => _time; set => _time = value; }

        [DefaultValue(60), Description(@"")]
        public int Seconds { get => _seconds; set => _seconds = value; }

        [DefaultValue(@""), Description(@"")]
        public string Title { get => _title; set => _title = value; }

        [DefaultValue(@""), Description(@"")]
        public string ContentText { get => _contentText; set => _contentText = value; }

        [DefaultValue(@""), Description(@"")]
        public string SoundPath { get => _soundPath; set => _soundPath = value; }

        [DefaultValue(@""), Description(@"")]
        public string DismissText { get => _dismissText; set => _dismissText = value; }

        [DefaultValue(@"Type response here..."), Description(@"")]
        public string UserResponsePromptText { get => _userResponsePrompt; set => _userResponsePrompt = value; }

        [DefaultValue(null), Description(@"")]
        public Stream SoundStream { get => _soundStream; set => _soundStream = value; }

        [DefaultValue(null), Description(@"")]
        public Image CustomImage { get => _customImage; set => _customImage = value; }

        [DefaultValue(typeof(KryptonToastNotificationRightToLeftSupport), "RightToLeftSupport.LEFTTORIGHT"), Description(@"")]
        public KryptonToastNotificationRightToLeftSupport RightToLeftSupport { get => _rightToLeftSupport; set => _rightToLeftSupport = value; }

        [DefaultValue(typeof(KryptonToastNotificationContentAreaType), "ContentAreaType.WRAPPEDLABEL"), Description(@"")]
        public KryptonToastNotificationContentAreaType ContentAreaType { get => _contentAreaType; set => _contentAreaType = value; }
        #endregion

        #region Custom Events
        public event EventHandler DisplayNotification;
        #endregion

        #region Constructor

        public KryptonToastNotificationManager()
        {
            UseUserResponsePrompt = false;

            UseProgressBar = false;

            UsePanelColourInTextArea = false;

            UseNativeBackColourInUserResponseArea = false;

            UserResponsePromptColour = Color.Gray;

            UserResponsePromptAlignHorizontal = PaletteRelativeAlign.Center;

            UserResponsePromptAlignVertical = PaletteRelativeAlign.Center;

            UserResponsePromptFont = new Font("Segoe UI", 8.25F);

            IconType = KryptonToastNotificationIconType.None;

            Time = 60;

            Seconds = 60;

            Title = @"";

            ContentText = @"";

            SoundPath = @"";

            DismissText = @"&Dismiss";

            UserResponsePromptText = @"Type response here...";

            SoundStream = null;

            CustomImage = null;

            RightToLeftSupport = KryptonToastNotificationRightToLeftSupport.LEFTTORIGHT;

            ContentAreaType = KryptonToastNotificationContentAreaType.WRAPPEDLABEL;
        }

        public KryptonToastNotificationManager(bool useUserResponse, string title, string contentText,
                                               bool? usePanelColourInTextArea, bool? useNativeBackColourInUserResponseArea,
                                               Color? userResponsePromptColour = null,
                                               PaletteRelativeAlign userResponsePromptAlignHorizontal = PaletteRelativeAlign.Near,
                                               PaletteRelativeAlign userResponsePromptAlignVertical = PaletteRelativeAlign.Near,
                                               Font userResponsePromptFont = null, KryptonToastNotificationIconType iconType = KryptonToastNotificationIconType.None,
                                               int time = 0, int seconds = 0, string soundPath = null, string dismissText = "Di&smiss",
                                               string userResponsePromptText = "Type response here...", Stream soundStream = null,
                                               Image customImage = null, KryptonToastNotificationRightToLeftSupport rightToLeftSupport = KryptonToastNotificationRightToLeftSupport.LEFTTORIGHT,
                                               bool useProgressBar = false, KryptonToastNotificationContentAreaType contentAreaType = KryptonToastNotificationContentAreaType.WRAPPEDLABEL)
        {
            UseProgressBar = useProgressBar;

            UseUserResponsePrompt = useUserResponse;

            Title = title;

            ContentText = contentText;

            UsePanelColourInTextArea = usePanelColourInTextArea ?? usePanelColourInTextArea.GetValueOrDefault();

            UseNativeBackColourInUserResponseArea = useNativeBackColourInUserResponseArea ?? useNativeBackColourInUserResponseArea.GetValueOrDefault();

            UserResponsePromptColour = userResponsePromptColour ?? Color.Gray;

            UserResponsePromptAlignHorizontal = userResponsePromptAlignHorizontal;

            UserResponsePromptAlignVertical = userResponsePromptAlignVertical;

            UserResponsePromptFont = userResponsePromptFont ?? new Font("Segoe UI", 8.25F);

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
            if (_rightToLeftSupport == KryptonToastNotificationRightToLeftSupport.LEFTTORIGHT)
            {
                if (!_useUserResponse)
                {
                    if (!_useProgressBar)
                    {
                        if (_contentAreaType == KryptonToastNotificationContentAreaType.LABEL)
                        {
                            ApplicationUtilities.UnderConstruction();
                        }
                        else if (_contentAreaType == KryptonToastNotificationContentAreaType.WRAPPEDLABEL)
                        {
                            BasicNotificationAlternativeUI notification = new BasicNotificationAlternativeUI(
                                IconType,
                                Title, ContentText, Seconds, SoundPath,
                                CustomImage, DismissText,
                                RightToLeftSupport);

                            notification.Show();
                        }
                        else if (_contentAreaType == KryptonToastNotificationContentAreaType.MULTILINEDTEXTBOX)
                        {
                            ApplicationUtilities.UnderConstruction();
                        }
                        else if (_contentAreaType == KryptonToastNotificationContentAreaType.RICHTEXTBOX)
                        {
                            BasicNotification notification = new BasicNotification(IconType, Title, ContentText, 
                                                                                   UsePanelColourInTextArea,
                                                                                   Seconds, SoundPath,
                                                                                   CustomImage, DismissText, RightToLeftSupport);

                            notification.Show();
                        }
                    }
                    else
                    {
                        if (_contentAreaType == KryptonToastNotificationContentAreaType.LABEL)
                        {
                            ApplicationUtilities.UnderConstruction();
                        }
                        else if (_contentAreaType == KryptonToastNotificationContentAreaType.WRAPPEDLABEL)
                        {
                            BasicNotificationWithProgressBarAlternativeUI notification =
                                new BasicNotificationWithProgressBarAlternativeUI(IconType, Title, ContentText,
                                    Seconds,
                                    SoundStream, CustomImage, DismissText, RightToLeftSupport);

                            notification.Show();
                        }
                        else if (_contentAreaType == KryptonToastNotificationContentAreaType.MULTILINEDTEXTBOX)
                        {
                            ApplicationUtilities.UnderConstruction();
                        }
                        else if (_contentAreaType == KryptonToastNotificationContentAreaType.RICHTEXTBOX)
                        {
                            BasicNotificationWithProgressBar notification = new BasicNotificationWithProgressBar(
                                                                                                                 IconType, Title, ContentText,
                                                                                                                 UsePanelColourInTextArea,
                                                                                                                 Seconds, SoundStream,
                                                                                                                 CustomImage, DismissText, RightToLeftSupport);

                            notification.Show();
                        }
                    }
                }
                else
                {
                    if (!_useProgressBar)
                    {
                        if (_contentAreaType == KryptonToastNotificationContentAreaType.LABEL)
                        {
                            ApplicationUtilities.UnderConstruction();
                        }
                        else if (_contentAreaType == KryptonToastNotificationContentAreaType.WRAPPEDLABEL)
                        {
                            BasicNotificationWithUserResponseWrappedLabel notification = new BasicNotificationWithUserResponseWrappedLabel(IconType, Title, ContentText, Seconds,
                                                                                                                                                 SoundPath, CustomImage,
                                                                                                                                                 DismissText, UserResponsePromptText,
                                                                                                                                                 UserResponsePromptColour,
                                                                                                                                                 UserResponsePromptAlignHorizontal, 
                                                                                                                                                 UserResponsePromptAlignVertical,
                                                                                                                                                 UserResponsePromptFont, RightToLeftSupport);

                            notification.Show();
                        }
                        else if (_contentAreaType == KryptonToastNotificationContentAreaType.MULTILINEDTEXTBOX)
                        {
                            ApplicationUtilities.UnderConstruction();
                        }
                        else if (_contentAreaType == KryptonToastNotificationContentAreaType.RICHTEXTBOX)
                        {
                            BasicNotificationWithUserResponse notification = new BasicNotificationWithUserResponse(IconType, Title, ContentText,
                                                                                                                         UsePanelColourInTextArea, UseNativeBackColourInUserResponseArea,
                                                                                                                         Seconds,
                                                                                                                         SoundPath, CustomImage,
                                                                                                                         DismissText, UserResponsePromptText, 
                                                                                                                         UserResponsePromptColour,
                                                                                                                         UserResponsePromptAlignHorizontal, UserResponsePromptAlignVertical,
                                                                                                                         UserResponsePromptFont, RightToLeftSupport);

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