using Krypton.Toolkit.Extended.Dialogs.Resources;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Dialogs
{
    /// <summary>
    /// Adapted from: https://github.com/dotCoefficient/Notification/blob/master/Notification/Notification.cs
    /// </summary>
    /// <seealso cref="ComponentFactory.Krypton.Toolkit.KryptonForm" />
    public class KryptonToastNotificationWindow : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private Suite.Extended.Standard.Controls.KryptonButtonExtended kbtneLaunch;
        private Suite.Extended.Standard.Controls.KryptonButtonExtended kbtneDismiss;
        private System.Windows.Forms.Panel panel1;
        private KryptonPanel kryptonPanel2;
        private Suite.Extended.Standard.Controls.KryptonLabelExtended klblContent;
        private KryptonWrapLabel kwlTitle;
        private System.Windows.Forms.PictureBox pbxIcon;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtneDismiss = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonButtonExtended();
            this.kbtneLaunch = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonButtonExtended();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.pbxIcon = new System.Windows.Forms.PictureBox();
            this.kwlTitle = new Krypton.Toolkit.KryptonWrapLabel();
            this.klblContent = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonLabelExtended();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtneLaunch);
            this.kryptonPanel1.Controls.Add(this.kbtneDismiss);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 244);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(605, 45);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtneDismiss
            // 
            this.kbtneDismiss.Image = null;
            this.kbtneDismiss.Location = new System.Drawing.Point(449, 8);
            this.kbtneDismiss.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneDismiss.Name = "kbtneDismiss";
            this.kbtneDismiss.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneDismiss.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneDismiss.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtneDismiss.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtneDismiss.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kbtneDismiss.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtneDismiss.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtneDismiss.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneDismiss.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtneDismiss.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneDismiss.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneDismiss.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneDismiss.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtneDismiss.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtneDismiss.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kbtneDismiss.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtneDismiss.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtneDismiss.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneDismiss.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtneDismiss.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneDismiss.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneDismiss.Size = new System.Drawing.Size(144, 25);
            this.kbtneDismiss.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneDismiss.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneDismiss.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtneDismiss.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtneDismiss.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kbtneDismiss.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtneDismiss.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtneDismiss.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneDismiss.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtneDismiss.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneDismiss.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneDismiss.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneDismiss.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtneDismiss.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtneDismiss.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kbtneDismiss.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtneDismiss.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtneDismiss.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneDismiss.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtneDismiss.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneDismiss.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneDismiss.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneDismiss.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtneDismiss.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtneDismiss.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kbtneDismiss.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtneDismiss.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtneDismiss.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneDismiss.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtneDismiss.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneDismiss.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneDismiss.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneDismiss.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtneDismiss.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtneDismiss.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kbtneDismiss.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtneDismiss.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtneDismiss.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneDismiss.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtneDismiss.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneDismiss.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneDismiss.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneDismiss.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtneDismiss.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtneDismiss.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kbtneDismiss.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtneDismiss.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtneDismiss.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneDismiss.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtneDismiss.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneDismiss.TabIndex = 0;
            this.kbtneDismiss.Values.Text = "&Dismiss ({0})";
            this.kbtneDismiss.Click += new System.EventHandler(this.kbtneDismiss_Click);
            // 
            // kbtneLaunch
            // 
            this.kbtneLaunch.AutoSize = true;
            this.kbtneLaunch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtneLaunch.Image = null;
            this.kbtneLaunch.Location = new System.Drawing.Point(12, 8);
            this.kbtneLaunch.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneLaunch.Name = "kbtneLaunch";
            this.kbtneLaunch.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneLaunch.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneLaunch.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtneLaunch.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtneLaunch.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kbtneLaunch.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtneLaunch.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtneLaunch.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneLaunch.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtneLaunch.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneLaunch.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneLaunch.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneLaunch.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtneLaunch.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtneLaunch.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kbtneLaunch.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtneLaunch.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtneLaunch.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneLaunch.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtneLaunch.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneLaunch.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneLaunch.Size = new System.Drawing.Size(24, 20);
            this.kbtneLaunch.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneLaunch.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneLaunch.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtneLaunch.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtneLaunch.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kbtneLaunch.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtneLaunch.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtneLaunch.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneLaunch.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtneLaunch.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneLaunch.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneLaunch.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneLaunch.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtneLaunch.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtneLaunch.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kbtneLaunch.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtneLaunch.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtneLaunch.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneLaunch.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtneLaunch.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneLaunch.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneLaunch.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneLaunch.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtneLaunch.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtneLaunch.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kbtneLaunch.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtneLaunch.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtneLaunch.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneLaunch.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtneLaunch.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneLaunch.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneLaunch.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneLaunch.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtneLaunch.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtneLaunch.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kbtneLaunch.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtneLaunch.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtneLaunch.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneLaunch.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtneLaunch.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneLaunch.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneLaunch.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneLaunch.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtneLaunch.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtneLaunch.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kbtneLaunch.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtneLaunch.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtneLaunch.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneLaunch.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtneLaunch.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneLaunch.TabIndex = 1;
            this.kbtneLaunch.Values.Text = "{0}";
            this.kbtneLaunch.Click += new System.EventHandler(this.kbtneLaunch_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 241);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(605, 3);
            this.panel1.TabIndex = 1;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.klblContent);
            this.kryptonPanel2.Controls.Add(this.kwlTitle);
            this.kryptonPanel2.Controls.Add(this.pbxIcon);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(605, 241);
            this.kryptonPanel2.TabIndex = 2;
            // 
            // pbxIcon
            // 
            this.pbxIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbxIcon.Location = new System.Drawing.Point(12, 12);
            this.pbxIcon.Name = "pbxIcon";
            this.pbxIcon.Size = new System.Drawing.Size(64, 64);
            this.pbxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbxIcon.TabIndex = 3;
            this.pbxIcon.TabStop = false;
            // 
            // kwlTitle
            // 
            this.kwlTitle.AutoSize = false;
            this.kwlTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlTitle.Location = new System.Drawing.Point(82, 12);
            this.kwlTitle.Name = "kwlTitle";
            this.kwlTitle.Size = new System.Drawing.Size(511, 64);
            this.kwlTitle.StateCommon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlTitle.Text = "kryptonWrapLabel1";
            this.kwlTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // klblContent
            // 
            this.klblContent.AutoSize = false;
            this.klblContent.Image = null;
            this.klblContent.Location = new System.Drawing.Point(82, 79);
            this.klblContent.LongTextTypeface = null;
            this.klblContent.Name = "klblContent";
            this.klblContent.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblContent.Size = new System.Drawing.Size(511, 156);
            this.klblContent.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblContent.StateCommonTextColourOne = System.Drawing.Color.Empty;
            this.klblContent.StateCommonTextColourTwo = System.Drawing.Color.Empty;
            this.klblContent.StateDisabled.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblContent.StateDisabledTextColourOne = System.Drawing.Color.Empty;
            this.klblContent.StateDisabledTextColourTwo = System.Drawing.Color.Empty;
            this.klblContent.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblContent.StateNormalTextColourOne = System.Drawing.Color.Empty;
            this.klblContent.StateNormalTextColourTwo = System.Drawing.Color.Empty;
            this.klblContent.TabIndex = 4;
            this.klblContent.Values.Text = "kryptonLabelExtended1";
            // 
            // KryptonToastNotificationWindow
            // 
            this.ClientSize = new System.Drawing.Size(605, 289);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonToastNotificationWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.KryptonToastNotificationWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Enumerations
        public enum IconType
        {
            CUSTOM,
            OK,
            ERROR,
            EXCLAMATION,
            INFORMATION,
            QUESTION,
            NOTHING,
            NONE,
            STOP,
            HAND,
            WARNING
        }

        public enum ProgressBarOrientation
        {
            VERTICAL,
            HORIZONTAL
        }

        public enum RightToLeftSupport
        {
            LEFTTORIGHT,
            RIGHTTOLEFT
        }

        public enum ActionType
        {
            LAUCHPROCESS,
            OPEN
        }
        #endregion

        #region Variables
        private ActionType _actionType;
        private bool _fade, _showActionButton;
        private string _headerText, _contentText, _processName;
        private Image _image;
        private int _time, _cornerRadius;
        private Timer _timer;
        private SoundPlayer _player;
        private IconType _iconType;
        private RightToLeftSupport _rightToLeftSupport;
        private PaletteDrawBorders _drawBorders;
        #endregion

        #region Properties        
        /// <summary>
        /// Gets or sets the type of the action.
        /// </summary>
        /// <value>
        /// The type of the action.
        /// </value>
        public ActionType Action { get => _actionType; set => _actionType = value; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="KryptonToastNotificationWindow"/> is fade.
        /// </summary>
        /// <value>
        ///   <c>true</c> if fade; otherwise, <c>false</c>.
        /// </value>
        public bool Fade { get => _fade; set => _fade = value; }

        /// <summary>
        /// Gets or sets a value indicating whether [show action button].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show action button]; otherwise, <c>false</c>.
        /// </value>
        public bool ShowActionButton { get => _showActionButton; set => _showActionButton = value; }

        /// <summary>
        /// Gets or sets the sound path.
        /// </summary>
        /// <value>
        /// The sound path.
        /// </value>
        public string SoundPath { get; set; }

        /// <summary>
        /// Gets or sets the sound stream.
        /// </summary>
        /// <value>
        /// The sound stream.
        /// </value>
        public Stream SoundStream { get; set; }

        /// <summary>
        /// Gets or sets the header text.
        /// </summary>
        /// <value>
        /// The header text.
        /// </value>
        public string HeaderText { get => _headerText; set => _headerText = value; }

        /// <summary>
        /// Gets or sets the content text.
        /// </summary>
        /// <value>
        /// The content text.
        /// </value>
        public string ContentText { get => _contentText; set => _contentText = value; }

        /// <summary>
        /// Gets or sets the name of the process.
        /// </summary>
        /// <value>
        /// The name of the process.
        /// </value>
        public string ProcessName { get => _processName; set => _processName = value; }

        /// <summary>
        /// Gets or sets the icon image.
        /// </summary>
        /// <value>
        /// The icon image.
        /// </value>
        public Image IconImage
        {
            get => _image; set { _image = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the seconds.
        /// </summary>
        /// <value>
        /// The seconds.
        /// </value>
        public int Seconds { get; set; }

        public int CornerRadius { get => _cornerRadius; set { _cornerRadius = value; Invalidate(); } }

        public PaletteDrawBorders PaletteDrawBorders { get => _drawBorders; set { _drawBorders = value; Invalidate(); } }

        public IconType Type { get => _iconType; set => _iconType = value; }

        /// <summary>
        /// Gets or sets the right to left support.
        /// </summary>
        /// <value>
        /// The right to left support.
        /// </value>
        public RightToLeftSupport RightToLeft { get => _rightToLeftSupport; set { _rightToLeftSupport = value; Invalidate(); } }
        #endregion

        #region Constructors
        public KryptonToastNotificationWindow(bool fade, Image icon, string headerText, string contentText, bool showControlBox = true)
        {
            InitializeComponent();

            Fade = fade;

            pbxIcon.Image = icon;

            HeaderText = headerText;

            ContentText = contentText;

            TopMost = true;

            Resize += KryptonToastNotificationWindow_Resize;

            GotFocus += KryptonToastNotificationWindow_GotFocus;

            DoubleBuffered = true;

            ControlBox = showControlBox;
        }

        public KryptonToastNotificationWindow(bool fade, IconType iconType, string headerText, string contentText, bool showControlBox = true)
        {
            InitializeComponent();

            Fade = fade;

            Type = iconType;

            #region Update Icons
            if (iconType == IconType.NONE)
            {
                pbxIcon.Image = null;

                pbxIcon.Visible = false;
            }
            else if (iconType == IconType.QUESTION)
            {
                pbxIcon.Image = BitmapToImage(InputBoxResources.Input_Box_Question_64_x_64);
            }
            else if (iconType == IconType.INFORMATION)
            {
                pbxIcon.Image = BitmapToImage(InputBoxResources.Input_Box_Information_64_x_64);
            }
            else if (iconType == IconType.WARNING)
            {
                pbxIcon.Image = BitmapToImage(InputBoxResources.Input_Box_Warning_64_x_58);
            }
            else if (iconType == IconType.ERROR)
            {
                pbxIcon.Image = BitmapToImage(InputBoxResources.Input_Box_Critical_64_x_64);
            }
            else if (iconType == IconType.HAND)
            {
                pbxIcon.Image = BitmapToImage(InputBoxResources.Input_Box_Hand_64_x_64);
            }
            else if (iconType == IconType.STOP)
            {
                pbxIcon.Image = BitmapToImage(InputBoxResources.Input_Box_Stop_64_x_64);
            }
            else if (iconType == IconType.OK)
            {
                pbxIcon.Image = BitmapToImage(InputBoxResources.Input_Box_Ok_64_x_64);
            }
            #endregion

            HeaderText = headerText;

            ContentText = contentText;

            TopMost = true;

            Resize += KryptonToastNotificationWindow_Resize;

            GotFocus += KryptonToastNotificationWindow_GotFocus;

            DoubleBuffered = true;

            ControlBox = showControlBox;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KryptonToastNotificationWindow"/> class.
        /// </summary>
        /// <param name="fade">if set to <c>true</c> [fade].</param>
        /// <param name="image">The image.</param>
        /// <param name="headerText">The header text.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="seconds">The seconds.</param>
        public KryptonToastNotificationWindow(bool fade, Image image, string headerText, string contentText, int seconds, bool showControlBox = true) : this(fade, image, headerText, contentText, showControlBox)
        {
            Seconds = seconds;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KryptonToastNotificationWindow"/> class.
        /// </summary>
        /// <param name="fade">if set to <c>true</c> [fade].</param>
        /// <param name="image">The image.</param>
        /// <param name="headerText">The header text.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="seconds">The seconds.</param>
        /// <param name="soundPath">The sound path.</param>
        public KryptonToastNotificationWindow(bool fade, Image image, string headerText, string contentText, int seconds, string soundPath, bool showControlBox = true) : this(fade, image, headerText, contentText, seconds, showControlBox)
        {
            SoundPath = soundPath;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KryptonToastNotificationWindow"/> class.
        /// </summary>
        /// <param name="fade">if set to <c>true</c> [fade].</param>
        /// <param name="image">The image.</param>
        /// <param name="headerText">The header text.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="soundPath">The sound path.</param>
        public KryptonToastNotificationWindow(bool fade, Image image, string headerText, string contentText, string soundPath, bool showControlBox = true) : this(fade, image, headerText, contentText, showControlBox)
        {
            SoundPath = soundPath;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KryptonToastNotificationWindow"/> class.
        /// </summary>
        /// <param name="fade">if set to <c>true</c> [fade].</param>
        /// <param name="image">The image.</param>
        /// <param name="headerText">The header text.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="soundStream">The sound stream.</param>
        public KryptonToastNotificationWindow(bool fade, Image image, string headerText, string contentText, Stream soundStream, bool showControlBox = true) : this(fade, image, headerText, contentText, showControlBox)
        {
            SoundStream = soundStream;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KryptonToastNotificationWindow"/> class.
        /// </summary>
        /// <param name="fade">if set to <c>true</c> [fade].</param>
        /// <param name="image">The image.</param>
        /// <param name="headerText">The header text.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="seconds">The seconds.</param>
        /// <param name="soundStream">The sound stream.</param>
        public KryptonToastNotificationWindow(bool fade, Image image, string headerText, string contentText, int seconds, Stream soundStream, bool showControlBox = true) : this(fade, image, headerText, contentText, seconds, showControlBox)
        {
            SoundStream = soundStream;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KryptonToastNotificationWindow"/> class.
        /// </summary>
        /// <param name="fade">if set to <c>true</c> [fade].</param>
        /// <param name="image">The image.</param>
        /// <param name="headerText">The header text.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="showActionButton">if set to <c>true</c> [show action button].</param>
        /// <param name="actionType">Type of the action.</param>
        /// <param name="processName">Name of the process.</param>
        /// <param name="showControlBox">if set to <c>true</c> [show control box].</param>
        public KryptonToastNotificationWindow(bool fade, Image image, string headerText, string contentText, bool showActionButton, ActionType actionType, string processName, bool showControlBox = true) : this(fade, image, headerText, contentText, showControlBox)
        {
            ShowActionButton = showActionButton;

            Action = actionType;

            ProcessName = processName;

            SetActionText(actionType);
        }

        /// <summary>Initializes a new instance of the <see cref="KryptonToastNotificationWindow"/> class.</summary>
        /// <param name="fade">if set to <c>true</c> [fade].</param>
        /// <param name="image">The image.</param>
        /// <param name="headerText">The header text.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="showActionButton">if set to <c>true</c> [show action button].</param>
        /// <param name="actionType">Type of the action.</param>
        /// <param name="processName">Name of the process.</param>
        /// <param name="showControlBox">if set to <c>true</c> [show control box].</param>
        /// <param name="cornerRadius">The corner radius.</param>
        public KryptonToastNotificationWindow(bool fade, Image image, string headerText, string contentText, bool showActionButton, ActionType actionType, string processName, bool showControlBox = true, int cornerRadius = -1) : this(fade, image, headerText, contentText, showControlBox)
        {
            CornerRadius = cornerRadius;
        }

        /// <summary>Initializes a new instance of the <see cref="KryptonToastNotificationWindow"/> class.</summary>
        /// <param name="fade">if set to <c>true</c> [fade].</param>
        /// <param name="image">The image.</param>
        /// <param name="headerText">The header text.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="showActionButton">if set to <c>true</c> [show action button].</param>
        /// <param name="actionType">Type of the action.</param>
        /// <param name="processName">Name of the process.</param>
        /// <param name="showControlBox">if set to <c>true</c> [show control box].</param>
        /// <param name="cornerRadius">The corner radius.</param>
        /// <param name="borders">The borders.</param>
        public KryptonToastNotificationWindow(bool fade, Image image, string headerText, string contentText, bool showActionButton, ActionType actionType, string processName, bool showControlBox = true, int cornerRadius = -1, PaletteDrawBorders borders = PaletteDrawBorders.All) : this(fade, image, headerText, contentText, showControlBox)
        {
            PaletteDrawBorders = borders;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Fades the window in.
        /// </summary>
        private void FadeIn()
        {
            Timer fadeTimer = new Timer();

            fadeTimer.Interval = 10;

            fadeTimer.Tick += (sender, e) =>
            {
                if (Opacity == 1d)
                {
                    fadeTimer.Stop();
                }

                Opacity += 0.02d;
            };

            fadeTimer.Start();
        }

        /// <summary>
        /// Fades the window out and close.
        /// </summary>
        private void FadeOutAndClose()
        {
            Timer fadeTimer = new Timer();

            fadeTimer.Interval = 10;

            fadeTimer.Tick += (sender, e) =>
            {
                if (Opacity == 0d)
                {
                    fadeTimer.Stop();

                    Close();
                }

                Opacity -= 0.02d;
            };

            fadeTimer.Start();
        }

        /// <summary>
        /// Displays the control to the user.
        /// </summary>
        public new void Show()
        {
            Opacity = 0;

            ReconfigureUI(RightToLeft);

            if (Type != IconType.NONE)
            {
                UpdateIconType(Type);
            }
            else
            {
                pbxIcon.Image = IconImage;
            }

            kwlTitle.Text = HeaderText;

            klblContent.Text = ContentText;

            if (Seconds != 0)
            {
                kbtneDismiss.Text = $"Dismiss ({ Seconds - _time }s)";

                _timer = new Timer();

                _timer.Interval = 1000;

                _timer.Tick += (sender, e) =>
                {
                    _time++;

                    kbtneDismiss.Text = $"Dismiss ({ Seconds - _time }s)";

                    if (_time == Seconds)
                    {
                        _timer.Stop();

                        FadeOutAndClose();
                    }
                };
            }

            if (SoundPath != null)
            {
                _player = new SoundPlayer(SoundPath);
            }

            if (SoundStream != null)
            {
                _player = new SoundPlayer(SoundStream);
            }

            base.Show();
        }

        /// <summary>
        /// Gets a value indicating whether the window will be activated when it is shown.
        /// </summary>
        protected override bool ShowWithoutActivation { get => true; }

        /// <summary>
        /// Updates the type of the icon.
        /// </summary>
        /// <param name="iconType">Type of the icon.</param>
        public void UpdateIconType(IconType iconType)
        {
            switch (iconType)
            {
                case IconType.NONE:
                    AdjustLayout(new Size(622, 58), new Size(622, 153), new Point(12, 6), new Point(470, 6), false);
                    break;
                case IconType.QUESTION:
                    pbxIcon.Image = InputBoxResources.Input_Box_Question_64_x_64;

                    SystemSounds.Question.Play();
                    break;
                case IconType.INFORMATION:
                    pbxIcon.Image = InputBoxResources.Input_Box_Information_64_x_64;

                    SystemSounds.Exclamation.Play();
                    break;
                case IconType.WARNING:
                    pbxIcon.Image = InputBoxResources.Input_Box_Warning_64_x_58;

                    SystemSounds.Exclamation.Play();
                    break;
                case IconType.ERROR:
                    pbxIcon.Image = InputBoxResources.Input_Box_Critical_64_x_64;
                    break;
                case IconType.HAND:
                    pbxIcon.Image = InputBoxResources.Input_Box_Hand_64_x_64;
                    break;
                case IconType.STOP:
                    pbxIcon.Image = InputBoxResources.Input_Box_Stop_64_x_64;
                    break;
                case IconType.OK:
                    pbxIcon.Image = InputBoxResources.Input_Box_Ok_64_x_64;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            UpdateIconType(Type);

            ReconfigureUI(RightToLeft);

            StateCommon.Border.Rounding = CornerRadius;

            StateCommon.Border.DrawBorders = PaletteDrawBorders;

            base.OnPaint(e);
        }

        /// <summary>
        /// Bitmaps to image.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <returns></returns>
        private Image BitmapToImage(Bitmap bitmap)
        {
            Image tmp = new Bitmap(bitmap);

            return tmp;
        }

        /// <summary>
        /// Reconfigures the UI.
        /// </summary>
        /// <param name="rightToLeft">The right to left.</param>
        private void ReconfigureUI(RightToLeftSupport rightToLeft)
        {
            switch (rightToLeft)
            {
                case RightToLeftSupport.LEFTTORIGHT:
                    ConfigureLeftToRight();
                    break;
                case RightToLeftSupport.RIGHTTOLEFT:
                    ConfigureRightToLeft();
                    break;
                default:
                    ReconfigureUI(RightToLeftSupport.LEFTTORIGHT);
                    break;
            }
        }

        /// <summary>
        /// Configures the UI elements to left to right.
        /// </summary>
        private void ConfigureLeftToRight()
        {
            // TODO: Fix this
            //RightToLeft = RightToLeft.;

            pbxIcon.Location = new Point(12, 12);

            kwlTitle.Location = new Point(147, 12);

            klblContent.Location = new Point(147, 77);

            //klblContent.RightToLeft = RightToLeft.

            kbtneLaunch.Location = new Point(12, 6);

            //kbtneLaunch.RightToLeft = RightToLeft.

            kbtneDismiss.Location = new Point(470, 6);

            //kbtneDismiss.RightToLeft = RightToLeft.No;
        }

        /// <summary>
        /// Configures the UI to right to left.
        /// </summary>
        private void ConfigureRightToLeft()
        {

        }

        /// <summary>
        /// Launches the process.
        /// </summary>
        /// <param name="process">The process.</param>
        public void LaunchProcess(string process)
        {
            Process.Start(process);

            Debug.WriteLine($"[Launching process]: { Path.GetFullPath(process) } at { DateTime.Now.ToString() }");
        }

        /// <summary>
        /// Adjusts the layout.
        /// </summary>
        /// <param name="headerLabelSize">Size of the header label.</param>
        /// <param name="contentLabelSize">Size of the content label.</param>
        /// <param name="actionButtonLocation">The action button location.</param>
        /// <param name="dismissButtonLocation">The dismiss button location.</param>
        /// <param name="showIcon">if set to <c>true</c> [show icon].</param>
        private void AdjustLayout(Size headerLabelSize, Size contentLabelSize, Point actionButtonLocation, Point dismissButtonLocation, bool showIcon = true)
        {
            kwlTitle.Size = headerLabelSize;

            klblContent.Size = contentLabelSize;

            kbtneLaunch.Location = actionButtonLocation;

            kbtneDismiss.Location = dismissButtonLocation;

            pbxIcon.Visible = showIcon;
        }

        // TODO: Revisit
        private void ResetDefaultLayout()
        {
            AdjustLayout(new Size(487, 58), new Size(487, 153), new Point(12, 6), new Point(470, 6));
        }

        /// <summary>
        /// Sets the action text.
        /// </summary>
        /// <param name="type">The type.</param>
        private void SetActionText(ActionType type)
        {
            switch (type)
            {
                case ActionType.LAUCHPROCESS:
                    kbtneLaunch.Text = $"&Launch Process { Path.GetFileName(ProcessName) }";
                    break;
                case ActionType.OPEN:
                    kbtneLaunch.Text = "&Open";
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Gets the type of the action.
        /// </summary>
        /// <returns></returns>
        private ActionType GetAction() => Action;

        /// <summary>Opens the in explorer.</summary>
        /// <param name="process">The process.</param>
        private void OpenInExplorer(string process) => Process.Start("explorer.exe", process);
        #endregion

        #region Event Handlers
        private void KryptonToastNotificationWindow_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void KryptonToastNotificationWindow_GotFocus(object sender, EventArgs e) => kbtneDismiss.Focus();

        private void KryptonToastNotificationWindow_Load(object sender, EventArgs e)
        {
            // Bottom left
            Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - Width - 5, Screen.PrimaryScreen.WorkingArea.Height - Height - 5);

            if (Fade)
            {
                FadeIn();
            }

            if (_timer != null)
            {
                _timer.Start();
            }

            if (_player != null)
            {
                _player.Play();
            }
        }

        private void kbtneDismiss_Click(object sender, EventArgs e)
        {
            FadeOutAndClose();
        }

        private void kbtneLaunch_Click(object sender, EventArgs e)
        {
            if (GetAction() == ActionType.LAUCHPROCESS)
            {
                LaunchProcess(ProcessName);
            }
            else if (GetAction() == ActionType.OPEN)
            {
                OpenInExplorer(ProcessName);
            }
        }
        #endregion
    }
}