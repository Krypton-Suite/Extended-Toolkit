using Krypton.Toolkit.Suite.Extended.Toast;

namespace TestApp
{
    public partial class ToastExample : KryptonForm
    {
        #region Instance Fields

        private ActionType _actionType = ActionType.Default;

        private ActionButtonLocation _actionButtonLocation = ActionButtonLocation.Left;

        private DefaultNotificationButton _defaultNotificationButton = DefaultNotificationButton.None;

        private Krypton.Toolkit.Suite.Extended.Toast.IconType _iconType = Krypton.Toolkit.Suite.Extended.Toast.IconType.None;

        private RightToLeftSupport _rightToLeftSupport = RightToLeftSupport.LeftToRight;

        private ToastNotificationSystemSounds _systemSounds = ToastNotificationSystemSounds.None;

        private ToastNotificationContentAreaType _contentAreaType = ToastNotificationContentAreaType.Label;

        private PaletteRelativeAlign _userResponsePromptAlignHorizontal;

        private PaletteRelativeAlign _userResponsePromptAlignVertical;

        private KryptonCommand _actionButtonCommand = null;

        #endregion

        public ToastExample()
        {
            InitializeComponent();
        }

        #region Setters & Getters

        /// <summary>Sets the ActionType to value.</summary>
        /// <param name="value">The value of the ActionType.</param>
        public void SetActionType(ActionType value) => _actionType = value;

        /// <summary>Gets the ActionType value.</summary>
        /// <returns>The value of the ActionType.</returns>
        public ActionType GetActionType() => _actionType;

        /// <summary>Sets the ActionButtonLocation to value.</summary>
        /// <param name="value">The value of the ActionButtonLocation.</param>
        public void SetActionButtonLocation(ActionButtonLocation value) => _actionButtonLocation = value;

        /// <summary>Gets the ActionButtonLocation value.</summary>
        /// <returns>The value of the ActionButtonLocation.</returns>
        public ActionButtonLocation GetActionButtonLocation() => _actionButtonLocation;

        /// <summary>Sets the DefaultNotificationButton to value.</summary>
        /// <param name="value">The value of the DefaultNotificationButton.</param>
        public void SetDefaultNotificationButton(DefaultNotificationButton value) => _defaultNotificationButton = value;

        /// <summary>Gets the DefaultNotificationButton value.</summary>
        /// <returns>The value of the DefaultNotificationButton.</returns>
        public DefaultNotificationButton GetDefaultNotificationButton() => _defaultNotificationButton;

        /// <summary>Sets the IconType to value.</summary>
        /// <param name="value">The value of the IconType.</param>
        public void SetIconType(Krypton.Toolkit.Suite.Extended.Toast.IconType value) => _iconType = value;

        /// <summary>Gets the IconType value.</summary>
        /// <returns>The value of the IconType.</returns>
        public Krypton.Toolkit.Suite.Extended.Toast.IconType GetIconType() => _iconType;

        /// <summary>Sets the RightToLeftSupport to value.</summary>
        /// <param name="value">The value of the RightToLeftSupport.</param>
        public void SetRightToLeftSupport(RightToLeftSupport value) => _rightToLeftSupport = value;

        /// <summary>Gets the RightToLeftSupport value.</summary>
        /// <returns>The value of the RightToLeftSupport.</returns>
        public RightToLeftSupport GetRightToLeftSupport() => _rightToLeftSupport;

        /// <summary>Sets the ToastNotificationSystemSounds to value.</summary>
        /// <param name="value">The value of the ToastNotificationSystemSounds.</param>
        public void SetToastNotificationSystemSounds(ToastNotificationSystemSounds value) => _systemSounds = value;

        /// <summary>Gets the ToastNotificationSystemSounds value.</summary>
        /// <returns>The value of the ToastNotificationSystemSounds.</returns>
        public ToastNotificationSystemSounds GetToastNotificationSystemSounds() => _systemSounds;

        /// <summary>Sets the ToastNotificationContentAreaType to value.</summary>
        /// <param name="value">The value of the ToastNotificationContentAreaType.</param>
        public void SetToastNotificationContentAreaType(ToastNotificationContentAreaType value) => _contentAreaType = value;

        /// <summary>Gets the ToastNotificationContentAreaType value.</summary>
        /// <returns>The value of the ToastNotificationContentAreaType.</returns>
        public ToastNotificationContentAreaType GetToastNotificationContentAreaType() => _contentAreaType;

        /// <summary>Sets the UserResponsePromptAlignHorizontal to value.</summary>
        /// <param name="value">The value of the UserResponsePromptAlignHorizontal.</param>
        public void SetUserResponsePromptAlignHorizontal(PaletteRelativeAlign value) => _userResponsePromptAlignHorizontal = value;

        /// <summary>Gets the UserResponsePromptAlignHorizontal value.</summary>
        /// <returns>The value of the UserResponsePromptAlignHorizontal.</returns>
        public PaletteRelativeAlign GetUserResponsePromptAlignHorizontal() => _userResponsePromptAlignHorizontal;

        /// <summary>Sets the UserResponsePromptAlignVertical to value.</summary>
        /// <param name="value">The value of the UserResponsePromptAlignVertical.</param>
        public void SetUserResponsePromptAlignVertical(PaletteRelativeAlign value) => _userResponsePromptAlignVertical = value;

        /// <summary>Gets the UserResponsePromptAlignVertical value.</summary>
        /// <returns>The value of the UserResponsePromptAlignVertical.</returns>
        public PaletteRelativeAlign GetUserResponsePromptAlignVertical() => _userResponsePromptAlignVertical;

        #endregion

        #region Methods

        private void EnableUserResponseUI(bool enabled)
        {
            ktxtPromptText.Enabled = enabled;

            kcolUserResponseColour.Enabled = enabled;

            kbtnUserResponseFont.Enabled = enabled;

            kryptonLabel3.Enabled = enabled;

            kcmbUserResponseTextAlignHorizontal.Enabled = enabled;

            kryptonLabel4.Enabled = enabled;

            kcmbUserResponseTextAlignVertical.Enabled = enabled;
        }

        #endregion

        private void ChangeIconType_CheckedChanged(object sender, EventArgs e)
        {
            kbbIconTypeCustomPath.Enabled = krbIconTypeCustom.Checked;

            if (krbIconTypeAsterisk.Checked)
            {
                SetIconType(Krypton.Toolkit.Suite.Extended.Toast.IconType.Asterisk);
            }
            else if (krbIconTypeCustom.Checked)
            {
                SetIconType(Krypton.Toolkit.Suite.Extended.Toast.IconType.Custom);
            }
            else if (krbIconTypeError.Checked)
            {
                SetIconType(Krypton.Toolkit.Suite.Extended.Toast.IconType.Error);
            }
            else if (krbIconTypeExclamation.Checked)
            {
                SetIconType(Krypton.Toolkit.Suite.Extended.Toast.IconType.Exclamation);
            }
            else if (krbIconTypeHand.Checked)
            {
                SetIconType(Krypton.Toolkit.Suite.Extended.Toast.IconType.Hand);
            }
            else if (krbIconTypeNone.Checked)
            {
                SetIconType(Krypton.Toolkit.Suite.Extended.Toast.IconType.None);
            }
            else if (krbIconTypeOk.Checked)
            {
                SetIconType(Krypton.Toolkit.Suite.Extended.Toast.IconType.Ok);
            }
            else if (krbIconTypeShield.Checked)
            {
                SetIconType(Krypton.Toolkit.Suite.Extended.Toast.IconType.Shield);
            }
            else if (krbIconTypeStop.Checked)
            {
                SetIconType(Krypton.Toolkit.Suite.Extended.Toast.IconType.Stop);
            }
            else if (krbIconTypeInformation.Checked)
            {
                SetIconType(Krypton.Toolkit.Suite.Extended.Toast.IconType.Information);
            }
            else if (krbIconTypeWarning.Checked)
            {
                SetIconType(Krypton.Toolkit.Suite.Extended.Toast.IconType.Warning);
            }
            else if (krbIconTypeWindowsLogo.Checked)
            {
                SetIconType(Krypton.Toolkit.Suite.Extended.Toast.IconType.WindowsLogo);
            }
        }

        private void ChangeContentAreaType_CheckedChanged(object sender, EventArgs e)
        {
            if (krbContentAreaTypeLabel.Checked)
            {
                SetToastNotificationContentAreaType(ToastNotificationContentAreaType.Label);
            }
            else if (krbContentAreaTypeMultilinedTextBox.Checked)
            {
                SetToastNotificationContentAreaType(ToastNotificationContentAreaType.MultiLinedTextBox);
            }
            else if (krbContentAreaTypeRichTextBox.Checked)
            {
                SetToastNotificationContentAreaType(ToastNotificationContentAreaType.RichTextBox);
            }
            else if (krbContentAreaTypeWrappedLabel.Checked)
            {
                SetToastNotificationContentAreaType(ToastNotificationContentAreaType.WrappedLabel);
            }
        }

        private void kcmbActionButtonLocation_TextChanged(object sender, EventArgs e) => SetActionButtonLocation((ActionButtonLocation)Enum.Parse(typeof(ActionButtonLocation), kcmbActionButtonLocation.Text));

        private void kcbActionType_TextChanged(object sender, EventArgs e) => SetActionType((ActionType)Enum.Parse(typeof(ActionType), kcbActionType.Text));

        private void kbtnShow_Click(object sender, EventArgs e)
        {
            KryptonToastNotificationManager manager = new()
            {

            };

            manager.DisplayNotificationToast();
        }

        private void kchkUseUserResponse_CheckedChanged(object sender, EventArgs e) => EnableUserResponseUI(kchkUseUserResponse.Checked);

        private void kbtnAttachCommand_Click(object sender, EventArgs e)
        {
            _actionButtonCommand = new();
        }
    }
}
