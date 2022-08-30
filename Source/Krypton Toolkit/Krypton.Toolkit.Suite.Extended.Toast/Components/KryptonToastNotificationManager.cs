﻿#region BSD License
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

        private ActionType _actionType;

        private ActionButtonLocation _actionButtonLocation;

        private bool _useUserResponse, _useProgressBar, _usePanelColourInTextArea, _useNativeBackColourInUserResponseArea, _showCloseButton;

        private Color _userResponsePromptColour;

        private DefaultNotificationButton _defaultNotificationButton;

        private PaletteRelativeAlign _userResponsePromptAlignHorizontal, _userResponsePromptAlignVertical;

        private Font _contentTypeface, _headerTypeface, _userResponsePromptFont;

        private IconType _iconType;

        private int _time, _seconds;

        private Timer _timer;

        private SoundPlayer _soundPlayer;

        private string _actionButtonText, _title, _contentText, _soundPath, _dismissText, _userResponsePrompt;

        private Stream _soundStream;

        private Image _customImage;

        private RightToLeftSupport _rightToLeftSupport;

        private ToastNotificationContentAreaType _contentAreaType;

        private ToastNotificationSystemSounds _soundSystemSounds;

        private KryptonCommand _actionButtonCommand;
        #endregion

        #region Properties

        [DefaultValue(typeof(ActionType), "ActionType.Default")]
        public ActionType ActionType { get => _actionType; set => _actionType = value; }

        [DefaultValue(typeof(ActionButtonLocation), "ActionButtonLocation.Left")]
        public ActionButtonLocation ActionButtonLocation { get => _actionButtonLocation; set => _actionButtonLocation = value; }

        [DefaultValue(false), Description(@"Allows the user to type a response in a toast window.")]
        public bool UseUserResponsePrompt { get => _useUserResponse; set => _useUserResponse = value; }

        [DefaultValue(false), Description(@"Shows a progress bar in a toast window.")]
        public bool UseProgressBar { get => _useProgressBar; set => _useProgressBar = value; }

        [DefaultValue(false), Description(@"")]
        public bool UsePanelColourInTextArea { get => _usePanelColourInTextArea; set => _usePanelColourInTextArea = value; }

        [DefaultValue(false), Description(@"")]
        public bool UseNativeBackColourInUserResponseArea { get => _useNativeBackColourInUserResponseArea; set => _useNativeBackColourInUserResponseArea = value; }

        [DefaultValue(false), Description(@"")]
        public bool ShowCloseButton { get => _showCloseButton; set => _showCloseButton = value; }

        [DefaultValue(typeof(Color), "Color.Gray"), Description(@"")]
        public Color UserResponsePromptColour { get => _userResponsePromptColour; set => _userResponsePromptColour = value; }

        [DefaultValue(typeof(DefaultNotificationButton), "DefaultNotificationButton.DismissButton")]
        public DefaultNotificationButton DefaultNotificationButton { get => _defaultNotificationButton; set => _defaultNotificationButton = value; }

        [DefaultValue(typeof(PaletteRelativeAlign), "PaletteRelativeAlign.Center"), Description(@"")]
        public PaletteRelativeAlign UserResponsePromptAlignHorizontal { get => _userResponsePromptAlignHorizontal; set => _userResponsePromptAlignHorizontal = value; }

        [DefaultValue(typeof(PaletteRelativeAlign), "PaletteRelativeAlign.Center"), Description(@"")]
        public PaletteRelativeAlign UserResponsePromptAlignVertical { get => _userResponsePromptAlignVertical; set => _userResponsePromptAlignVertical = value; }

        [DefaultValue(typeof(Font), "Segoe UI, 8.25F"), Description(@"")]
        public Font ContentTypeface { get => _contentTypeface; set => _contentTypeface = value; }

        [DefaultValue(typeof(Font), "Segoe UI, 12F"), Description(@"")]
        public Font HeaderTypeface { get => _headerTypeface; set => _headerTypeface = value; }

        [DefaultValue(typeof(Font), "Segoe UI, 8.25F"), Description(@"")]
        public Font UserResponsePromptFont { get => _userResponsePromptFont; set => _userResponsePromptFont = value; }

        [DefaultValue(typeof(IconType), "IconType.None"), Description(@"")]
        public IconType IconType { get => _iconType; set => _iconType = value; }

        [DefaultValue(60), Description(@"")]
        public int Time { get => _time; set => _time = value; }

        [DefaultValue(60), Description(@"")]
        public int Seconds { get => _seconds; set => _seconds = value; }

        [DefaultValue(@"O&pen")]
        public string ActionButtonText { get => _actionButtonText; set => _actionButtonText = value; }

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

        [DefaultValue(typeof(RightToLeftSupport), "RightToLeftSupport.LeftToRight"), Description(@"")]
        public RightToLeftSupport RightToLeftSupport { get => _rightToLeftSupport; set => _rightToLeftSupport = value; }

        [DefaultValue(typeof(ToastNotificationContentAreaType), "ContentAreaType.WrappedLabel"), Description(@"")]
        public ToastNotificationContentAreaType ContentAreaType { get => _contentAreaType; set => _contentAreaType = value; }

        [DefaultValue(typeof(ToastNotificationSystemSounds), "ToastNotificationSystemSounds.None")]
        public ToastNotificationSystemSounds ToastNotificationSound { get => _soundSystemSounds; set => _soundSystemSounds = value; }

        [DefaultValue(null)]
        public KryptonCommand ActionButtonCommand { get => _actionButtonCommand; set => _actionButtonCommand = value; }

        #endregion

        #region Custom Events
        public event EventHandler DisplayNotification;
        #endregion

        #region Constructor

        /// <summary>Initializes a new instance of the <see cref="KryptonToastNotificationManager" /> class.</summary>
        public KryptonToastNotificationManager()
        {
            ActionButtonLocation = ActionButtonLocation.Left;

            ActionType = ActionType.Default;

            UseUserResponsePrompt = false;

            UseProgressBar = false;

            UsePanelColourInTextArea = false;

            UseNativeBackColourInUserResponseArea = false;

            ShowCloseButton = false;

            UserResponsePromptColour = Color.Gray;

            DefaultNotificationButton = DefaultNotificationButton.DismissButton;

            UserResponsePromptAlignHorizontal = PaletteRelativeAlign.Center;

            UserResponsePromptAlignVertical = PaletteRelativeAlign.Center;

            ContentTypeface = new Font("Segoe UI", 8.25F);

            HeaderTypeface = new Font("Segoe UI", 12F);

            UserResponsePromptFont = new Font("Segoe UI", 8.25F);

            IconType = IconType.None;

            Time = 60;

            Seconds = 60;

            ActionButtonText = @"O&pen";

            Title = @"";

            ContentText = @"";

            SoundPath = @"";

            DismissText = @"&Dismiss";

            UserResponsePromptText = @"Type response here...";

            SoundStream = null;

            CustomImage = null;

            RightToLeftSupport = RightToLeftSupport.LeftToRight;

            ContentAreaType = ToastNotificationContentAreaType.WrappedLabel;

            ToastNotificationSound = ToastNotificationSystemSounds.None;

            ActionButtonCommand = null;
        }

        /// <summary>Initializes a new instance of the <see cref="KryptonToastNotificationManager" /> class.</summary>
        /// <param name="actionType">Type of the action.</param>
        /// <param name="actionButtonLocation">The action button location.</param>
        /// <param name="useUserResponse">if set to <c>true</c> [use user response].</param>
        /// <param name="title">The title.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="usePanelColourInTextArea">The use panel colour in text area.</param>
        /// <param name="useNativeBackColourInUserResponseArea">The use native back colour in user response area.</param>
        /// <param name="showCloseButton">The show close button.</param>
        /// <param name="userResponsePromptColour">The user response prompt colour.</param>
        /// <param name="defaultNotificationButton">The default notification button.</param>
        /// <param name="userResponsePromptAlignHorizontal">The user response prompt align horizontal.</param>
        /// <param name="userResponsePromptAlignVertical">The user response prompt align vertical.</param>
        /// <param name="contentTypeface">The global typeface.</param>
        /// <param name="userResponsePromptFont">The user response prompt font.</param>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="time">The time.</param>
        /// <param name="seconds">The seconds.</param>
        /// <param name="soundPath">The sound path.</param>
        /// <param name="dismissText">The dismiss text.</param>
        /// <param name="userResponsePromptText">The user response prompt text.</param>
        /// <param name="soundStream">The sound stream.</param>
        /// <param name="customImage">The custom image.</param>
        /// <param name="rightToLeftSupport">The right to left support.</param>
        /// <param name="useProgressBar">if set to <c>true</c> [use progress bar].</param>
        /// <param name="contentAreaType">Type of the content area.</param>
        /// <param name="notificationSystemSound">The notification system sound.</param>
        public KryptonToastNotificationManager(ActionType? actionType, ActionButtonLocation? actionButtonLocation,
                                               bool useUserResponse, string title, string contentText,
                                               bool? usePanelColourInTextArea, bool? useNativeBackColourInUserResponseArea,
                                               bool? showCloseButton,
                                               Color? userResponsePromptColour = null,
                                               DefaultNotificationButton? defaultNotificationButton = null,
                                               PaletteRelativeAlign userResponsePromptAlignHorizontal = PaletteRelativeAlign.Near,
                                               PaletteRelativeAlign userResponsePromptAlignVertical = PaletteRelativeAlign.Near,
                                               Font contentTypeface = null, Font headerTypeface = null,
                                               Font userResponsePromptFont = null, 
                                               IconType iconType = IconType.None,
                                               int time = 0, int seconds = 0, string actionButtonText = @"O&pen",
                                               string soundPath = null, string dismissText = "Di&smiss",
                                               string userResponsePromptText = "Type response here...",
                                               Stream soundStream = null,
                                               Image customImage = null,
                                               RightToLeftSupport rightToLeftSupport = RightToLeftSupport.LeftToRight,
                                               bool useProgressBar = false, 
                                               ToastNotificationContentAreaType contentAreaType = ToastNotificationContentAreaType.WrappedLabel,
                                               ToastNotificationSystemSounds? notificationSystemSound = ToastNotificationSystemSounds.None,
                                               KryptonCommand? actionButtonCommand = null)
        {
            ActionButtonLocation = actionButtonLocation ?? ActionButtonLocation.Left;

            ActionType = actionType ?? ActionType.Default;

            UseProgressBar = useProgressBar;

            UseUserResponsePrompt = useUserResponse;

            ShowCloseButton = showCloseButton ?? false;

            Title = title;

            ContentText = contentText;

            UsePanelColourInTextArea = usePanelColourInTextArea ?? usePanelColourInTextArea.GetValueOrDefault();

            UseNativeBackColourInUserResponseArea = useNativeBackColourInUserResponseArea ?? useNativeBackColourInUserResponseArea.GetValueOrDefault();

            UserResponsePromptColour = userResponsePromptColour ?? Color.Gray;

            DefaultNotificationButton = defaultNotificationButton ?? DefaultNotificationButton.DismissButton;

            UserResponsePromptAlignHorizontal = userResponsePromptAlignHorizontal;

            UserResponsePromptAlignVertical = userResponsePromptAlignVertical;

            ContentTypeface = contentTypeface ?? new Font("Segoe UI", 8.25F);

            HeaderTypeface = headerTypeface ?? new Font("Segoe UI", 12F);

            UserResponsePromptFont = userResponsePromptFont ?? new Font("Segoe UI", 8.25F);

            IconType = iconType;

            Time = time;

            Seconds = seconds;

            ActionButtonText = actionButtonText;

            SoundPath = soundPath;

            DismissText = dismissText;

            UserResponsePromptText = userResponsePromptText;

            SoundStream = soundStream;

            CustomImage = customImage;

            RightToLeftSupport = rightToLeftSupport;

            ContentAreaType = contentAreaType;

            ToastNotificationSound = notificationSystemSound ?? ToastNotificationSystemSounds.None;

            ActionButtonCommand = actionButtonCommand ?? null;
        }
        #endregion

        #region Methods
        public void DisplayNotificationToast()
        {
            if (_rightToLeftSupport == RightToLeftSupport.LeftToRight)
            {
                if (!_useUserResponse)
                {
                    if (!_useProgressBar)
                    {
                        if (_contentAreaType == ToastNotificationContentAreaType.Label)
                        {
                            ApplicationUtilities.UnderConstruction();
                        }
                        else if (_contentAreaType == ToastNotificationContentAreaType.WrappedLabel)
                        {
                            BasicNotificationAlternativeUI notification = new BasicNotificationAlternativeUI(
                                IconType,
                                Title, ContentText, ShowCloseButton, Seconds, SoundPath,
                                CustomImage, DismissText,
                                RightToLeftSupport);

                            notification.Show();
                        }
                        else if (_contentAreaType == ToastNotificationContentAreaType.MultiLinedTextBox)
                        {
                            ApplicationUtilities.UnderConstruction();
                        }
                        else if (_contentAreaType == ToastNotificationContentAreaType.RichTextBox)
                        {
                            BasicNotification notification = new BasicNotification(IconType, Title, ContentText, 
                                                                                   UsePanelColourInTextArea,
                                                                                   ShowCloseButton,
                                                                                   Seconds, SoundPath,
                                                                                   CustomImage, DismissText, RightToLeftSupport);

                            notification.Show();
                        }
                    }
                    else
                    {
                        if (_contentAreaType == ToastNotificationContentAreaType.Label)
                        {
                            ApplicationUtilities.UnderConstruction();
                        }
                        else if (_contentAreaType == ToastNotificationContentAreaType.WrappedLabel)
                        {
                            BasicNotificationWithProgressBarAlternativeUI notification =
                                new BasicNotificationWithProgressBarAlternativeUI(IconType, Title, ContentText, 
                                                                                  ShowCloseButton,
                                                                                  Seconds, SoundStream,
                                                                                  CustomImage, DismissText, RightToLeftSupport);

                            notification.Show();
                        }
                        else if (_contentAreaType == ToastNotificationContentAreaType.MultiLinedTextBox)
                        {
                            ApplicationUtilities.UnderConstruction();
                        }
                        else if (_contentAreaType == ToastNotificationContentAreaType.RichTextBox)
                        {
                            BasicNotificationWithProgressBar notification = new BasicNotificationWithProgressBar(
                                                                                                                 IconType, Title, ContentText,
                                                                                                                 UsePanelColourInTextArea, 
                                                                                                                 ShowCloseButton,
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
                        if (_contentAreaType == ToastNotificationContentAreaType.Label)
                        {
                            ApplicationUtilities.UnderConstruction();
                        }
                        else if (_contentAreaType == ToastNotificationContentAreaType.WrappedLabel)
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
                        else if (_contentAreaType == ToastNotificationContentAreaType.MultiLinedTextBox)
                        {
                            ApplicationUtilities.UnderConstruction();
                        }
                        else if (_contentAreaType == ToastNotificationContentAreaType.RichTextBox)
                        {
                            BasicNotificationWithUserResponse notification = new BasicNotificationWithUserResponse(IconType, Title, ContentText,
                                                                                                                         UsePanelColourInTextArea, UseNativeBackColourInUserResponseArea, 
                                                                                                                         ShowCloseButton,
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