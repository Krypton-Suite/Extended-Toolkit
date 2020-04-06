using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Extended.Dialogs
{
    public class KryptonTypefaceDialog : KryptonForm
    {
        #region Drsign Code
        private Suite.Extended.Standard.Controls.KryptonPanelExtended kryptonPanelExtended1;
        private KryptonOKDialogButton kryptonOKDialogButton1;
        private System.Windows.Forms.Panel panel1;
        private Suite.Extended.Standard.Controls.KryptonPanelExtended kryptonPanelExtended2;
        private KryptonCancelDialogButton kryptonCancelDialogButton1;

        private void InitializeComponent()
        {
            this.kryptonPanelExtended1 = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonPanelExtended();
            this.kryptonOKDialogButton1 = new Krypton.Toolkit.Extended.Dialogs.KryptonOKDialogButton();
            this.kryptonCancelDialogButton1 = new Krypton.Toolkit.Extended.Dialogs.KryptonCancelDialogButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanelExtended2 = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonPanelExtended();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanelExtended1)).BeginInit();
            this.kryptonPanelExtended1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanelExtended2)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanelExtended1
            // 
            this.kryptonPanelExtended1.Controls.Add(this.kryptonOKDialogButton1);
            this.kryptonPanelExtended1.Controls.Add(this.kryptonCancelDialogButton1);
            this.kryptonPanelExtended1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanelExtended1.Image = null;
            this.kryptonPanelExtended1.Location = new System.Drawing.Point(0, 373);
            this.kryptonPanelExtended1.Name = "kryptonPanelExtended1";
            this.kryptonPanelExtended1.Size = new System.Drawing.Size(551, 46);
            this.kryptonPanelExtended1.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonPanelExtended1.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonPanelExtended1.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonPanelExtended1.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonPanelExtended1.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonPanelExtended1.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonPanelExtended1.TabIndex = 0;
            // 
            // kryptonOKDialogButton1
            // 
            this.kryptonOKDialogButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kryptonOKDialogButton1.Image = null;
            this.kryptonOKDialogButton1.Location = new System.Drawing.Point(353, 9);
            this.kryptonOKDialogButton1.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.Name = "kryptonOKDialogButton1";
            this.kryptonOKDialogButton1.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.Size = new System.Drawing.Size(90, 25);
            this.kryptonOKDialogButton1.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.TabIndex = 1;
            this.kryptonOKDialogButton1.Values.Text = "&OK";
            // 
            // kryptonCancelDialogButton1
            // 
            this.kryptonCancelDialogButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kryptonCancelDialogButton1.Image = null;
            this.kryptonCancelDialogButton1.Location = new System.Drawing.Point(449, 9);
            this.kryptonCancelDialogButton1.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.Name = "kryptonCancelDialogButton1";
            this.kryptonCancelDialogButton1.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.Size = new System.Drawing.Size(90, 25);
            this.kryptonCancelDialogButton1.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.TabIndex = 0;
            this.kryptonCancelDialogButton1.Values.Text = "C&ancel";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 370);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(551, 3);
            this.panel1.TabIndex = 1;
            // 
            // kryptonPanelExtended2
            // 
            this.kryptonPanelExtended2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanelExtended2.Image = null;
            this.kryptonPanelExtended2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanelExtended2.Name = "kryptonPanelExtended2";
            this.kryptonPanelExtended2.Size = new System.Drawing.Size(551, 370);
            this.kryptonPanelExtended2.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonPanelExtended2.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonPanelExtended2.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonPanelExtended2.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonPanelExtended2.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonPanelExtended2.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonPanelExtended2.TabIndex = 2;
            // 
            // KryptonTypefaceDialog
            // 
            this.ClientSize = new System.Drawing.Size(551, 419);
            this.Controls.Add(this.kryptonPanelExtended2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanelExtended1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonTypefaceDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanelExtended1)).EndInit();
            this.kryptonPanelExtended1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanelExtended2)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Events
        public delegate void TypefaceChangedEventHandler(object sender, TypefaceChangedEventArgs e);

        public event TypefaceChangedEventHandler TypefaceChanged;

        protected virtual void OnTypefaceChanged(object sender, TypefaceChangedEventArgs e) => TypefaceChanged?.Invoke(sender, e);
        #endregion

        #region Variable
        private Font _typeface;
        #endregion

        #region Property
        public Font Typeface
        {
            get => _typeface;

            set
            {
                _typeface = value;

                TypefaceChangedEventArgs e = new TypefaceChangedEventArgs(value);

                OnTypefaceChanged(this, e);
            }
        }
        #endregion

        #region Constructors
        public KryptonTypefaceDialog()
        {
            InitializeComponent();
        }
        #endregion
    }
}