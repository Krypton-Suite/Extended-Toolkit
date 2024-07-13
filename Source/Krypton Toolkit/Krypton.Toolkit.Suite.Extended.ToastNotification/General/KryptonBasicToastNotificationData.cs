﻿namespace Krypton.Toolkit.Suite.Extended.ToastNotification
{
    /// <summary>Contains the data and information required, to create a basic toast notification.</summary>
    public struct KryptonBasicToastNotificationData
    {
        #region Public

        /// <summary>Gets or sets the enable hyper links.</summary>
        /// <value>The enable hyper links.</value>
        public bool? EnableHyperLinks { get; set; }

        /// <summary>Gets or sets the use fade.</summary>
        /// <value>The use fade.</value>
        public bool UseFade { get; set; }

        /// <summary>Gets or sets the top most.</summary>
        /// <value>The top most.</value>
        public bool? TopMost { get; set; }

        /// <summary>Gets or sets the show close button.</summary>
        /// <value>The show close button.</value>
        public bool? ShowCloseButton { get; set; }

        /// <summary>Gets or sets the show do not show again option.</summary>
        /// <value>The show do not show again option.</value>
        public bool? ShowDoNotShowAgainOption { get; set; }

        /// <summary>Gets or sets a value indicating whether [show count down seconds on progress bar].</summary>
        /// <value><c>true</c> if [show count down seconds on progress bar]; otherwise, <c>false</c>.</value>
        public bool ShowCountDownSecondsOnProgressBar { get; set; }

        /// <summary>Gets or sets the state of the use do not show again option three.</summary>
        /// <value>The state of the use do not show again option three.</value>
        public bool? UseDoNotShowAgainOptionThreeState { get; set; }

        /// <summary>Gets or sets the do not show again option checked value.</summary>
        /// <value>The do not show again option checked value.</value>
        public bool IsDoNotShowAgainOptionChecked { get; set; }

        /// <summary>Gets or sets the report toast location. Use this for development purposes only.</summary>
        /// <value>Reports the toast location.</value>
        public bool ReportToastLocation { get; set; }

        /// <summary>Gets or sets a value indicating whether [use RTL reading].</summary>
        /// <value><c>true</c> if [use RTL reading]; otherwise, <c>false</c>.</value>
        public KryptonUseRTLLayout UseRtlReading { get; set; }

        /// <summary>Gets or sets the state of the do not show again option check.</summary>
        /// <value>The state of the do not show again option check.</value>
        public CheckState? DoNotShowAgainOptionCheckState { get; set; }

        /// <summary>Gets or sets the first border color.</summary>
        /// <value>The first border color.</value>
        public Color? BorderColor1 { get; set; }

        /// <summary>Gets or sets the second border color.</summary>
        /// <value>The second border color.</value>
        public Color? BorderColor2 { get; set; }

        /// <summary>Gets or sets the notification content font.</summary>
        /// <value>The notification content font.</value>
        public Font? NotificationContentFont { get; set; }

        /// <summary>Gets or sets the notification title font.</summary>
        /// <value>The notification title font.</value>
        public Font? NotificationTitleFont { get; set; }

        /// <summary>Gets or sets the count-down seconds.</summary>
        /// <value>The count-down seconds.</value>
        public int? CountDownSeconds { get; set; }

        /// <summary>Gets or sets the count-down timer interval.</summary>
        /// <value>The count-down timer interval.</value>
        public int? CountDownTimerInterval { get; set; }

        /// <summary>Gets or sets the content of the notification.</summary>
        /// <value>The content of the notification.</value>
        public string? NotificationContent { get; set; }

        /// <summary>Gets or sets the notification title.</summary>
        /// <value>The notification title.</value>
        public string? NotificationTitle { get; set; }

        /// <summary>Gets or sets the optional CheckBox text.</summary>
        /// <value>The optional CheckBox text.</value>
        public string? OptionalCheckBoxText { get; set; }

        /// <summary>Gets or sets the custom image.</summary>
        /// <value>The custom image.</value>
        public Bitmap? CustomImage { get; set; }

        /// <summary>Gets or sets the notification location.</summary>
        /// <value>The notification location.</value>
        public Point? NotificationLocation { get; set; }

        /// <summary>Gets or sets the toast host.</summary>
        /// <value>The toast host.</value>
        public IWin32Window? ToastHost { get; set; }

        /// <summary>Gets or sets the right to left layout.</summary>
        /// <value>The right to left layout.</value>
        public RightToLeftLayout? RightToLeftLayout { get; set; }

        /// <summary>Gets or sets the notification icon.</summary>
        /// <value>The notification icon.</value>
        public KryptonToastNotificationIcon? NotificationIcon { get; set; }

        public PaletteRelativeAlign? TitleAlignment { get; set; }

        #endregion

        #region Identity

        /// <summary>Initializes a new instance of the <see cref="KryptonBasicToastNotificationData" /> struct.</summary>
        public KryptonBasicToastNotificationData()
        {
            // Defaults, when needed
            UseFade = false;

            ReportToastLocation = false;

            UseRtlReading = KryptonUseRTLLayout.No;

            ShowCountDownSecondsOnProgressBar = true;

            #region Do Not Show Again Values

            ShowDoNotShowAgainOption = false;

            UseDoNotShowAgainOptionThreeState = false;

            DoNotShowAgainOptionCheckState = CheckState.Unchecked;

            #endregion

            CountDownTimerInterval = 1000;

            BorderColor1 = GlobalStaticValues.EMPTY_COLOR;

            BorderColor2 = GlobalStaticValues.EMPTY_COLOR;

            OptionalCheckBoxText = KryptonManager.Strings.CustomStrings.DoNotShowAgain;

            ToastHost = null;

            RightToLeftLayout = Toolkit.RightToLeftLayout.LeftToRight;
        }

        #endregion
    }
}