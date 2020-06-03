using Krypton.Toolkit.Extended.Dialogs.Resources;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Dialogs
{
    public class KryptonInputBoxExtended : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private Suite.Extended.Standard.Controls.KryptonButtonExtended kbtnButtonThree;
        private Suite.Extended.Standard.Controls.KryptonButtonExtended kbtnButtonTwo;
        private Suite.Extended.Standard.Controls.KryptonButtonExtended kbtnButtonOne;
        private System.Windows.Forms.Panel panel1;
        private KryptonPanel kryptonPanel2;
        private Suite.Extended.Standard.Controls.KryptonTextBoxExtended ktxtUserInput;
        private Suite.Extended.Standard.Controls.KryptonButtonExtended kbtnButtonFour;
        private KryptonWrapLabel kwlMessage;
        private Suite.Extended.Standard.Controls.KryptonComboBoxExtended kcmbUserSelection;
        private Suite.Extended.Standard.Controls.KryptonMaskedTextBoxExtended kmtxtUserInput;
        private System.Windows.Forms.PictureBox pbxImage;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnButtonOne = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonButtonExtended();
            this.kbtnButtonTwo = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonButtonExtended();
            this.kbtnButtonThree = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonButtonExtended();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.pbxImage = new System.Windows.Forms.PictureBox();
            this.ktxtUserInput = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonTextBoxExtended();
            this.kbtnButtonFour = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonButtonExtended();
            this.kwlMessage = new Krypton.Toolkit.KryptonWrapLabel();
            this.kcmbUserSelection = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonComboBoxExtended();
            this.kmtxtUserInput = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonMaskedTextBoxExtended();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbUserSelection)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnButtonThree);
            this.kryptonPanel1.Controls.Add(this.kbtnButtonFour);
            this.kryptonPanel1.Controls.Add(this.kbtnButtonTwo);
            this.kryptonPanel1.Controls.Add(this.kbtnButtonOne);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 213);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(580, 48);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnButtonOne
            // 
            this.kbtnButtonOne.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnButtonOne.Image = null;
            this.kbtnButtonOne.Location = new System.Drawing.Point(238, 12);
            this.kbtnButtonOne.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnButtonOne.Name = "kbtnButtonOne";
            this.kbtnButtonOne.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnButtonOne.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnButtonOne.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonOne.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonOne.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonOne.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonOne.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonOne.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonOne.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonOne.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonOne.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnButtonOne.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnButtonOne.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonOne.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonOne.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonOne.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonOne.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonOne.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonOne.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonOne.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonOne.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnButtonOne.Size = new System.Drawing.Size(106, 25);
            this.kbtnButtonOne.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnButtonOne.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnButtonOne.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonOne.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonOne.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonOne.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonOne.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonOne.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonOne.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonOne.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonOne.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnButtonOne.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnButtonOne.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonOne.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonOne.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonOne.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonOne.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonOne.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonOne.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonOne.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonOne.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnButtonOne.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnButtonOne.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonOne.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonOne.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonOne.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonOne.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonOne.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonOne.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonOne.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonOne.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnButtonOne.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnButtonOne.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonOne.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonOne.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonOne.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonOne.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonOne.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonOne.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonOne.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonOne.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnButtonOne.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnButtonOne.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonOne.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonOne.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonOne.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonOne.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonOne.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonOne.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonOne.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonOne.TabIndex = 0;
            this.kbtnButtonOne.Values.Text = "Button 1";
            this.kbtnButtonOne.Click += new System.EventHandler(this.kbtnButtonOne_Click);
            // 
            // kbtnButtonTwo
            // 
            this.kbtnButtonTwo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnButtonTwo.Image = null;
            this.kbtnButtonTwo.Location = new System.Drawing.Point(350, 12);
            this.kbtnButtonTwo.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnButtonTwo.Name = "kbtnButtonTwo";
            this.kbtnButtonTwo.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnButtonTwo.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnButtonTwo.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnButtonTwo.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnButtonTwo.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnButtonTwo.Size = new System.Drawing.Size(106, 25);
            this.kbtnButtonTwo.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnButtonTwo.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnButtonTwo.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnButtonTwo.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnButtonTwo.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnButtonTwo.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnButtonTwo.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnButtonTwo.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnButtonTwo.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnButtonTwo.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnButtonTwo.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonTwo.TabIndex = 1;
            this.kbtnButtonTwo.Values.Text = "Button 2";
            this.kbtnButtonTwo.Click += new System.EventHandler(this.kbtnButtonTwo_Click);
            // 
            // kbtnButtonThree
            // 
            this.kbtnButtonThree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnButtonThree.Image = null;
            this.kbtnButtonThree.Location = new System.Drawing.Point(462, 12);
            this.kbtnButtonThree.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnButtonThree.Name = "kbtnButtonThree";
            this.kbtnButtonThree.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnButtonThree.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnButtonThree.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonThree.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonThree.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonThree.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonThree.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonThree.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonThree.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonThree.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonThree.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnButtonThree.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnButtonThree.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonThree.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonThree.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonThree.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonThree.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonThree.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonThree.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonThree.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonThree.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnButtonThree.Size = new System.Drawing.Size(106, 25);
            this.kbtnButtonThree.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnButtonThree.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnButtonThree.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonThree.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonThree.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonThree.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonThree.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonThree.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonThree.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonThree.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonThree.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnButtonThree.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnButtonThree.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonThree.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonThree.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonThree.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonThree.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonThree.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonThree.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonThree.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonThree.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnButtonThree.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnButtonThree.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonThree.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonThree.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonThree.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonThree.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonThree.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonThree.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonThree.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonThree.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnButtonThree.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnButtonThree.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonThree.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonThree.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonThree.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonThree.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonThree.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonThree.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonThree.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonThree.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnButtonThree.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnButtonThree.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonThree.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonThree.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonThree.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonThree.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonThree.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonThree.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonThree.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonThree.TabIndex = 2;
            this.kbtnButtonThree.Values.Text = "Button 3";
            this.kbtnButtonThree.Click += new System.EventHandler(this.kbtnButtonThree_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 210);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(580, 3);
            this.panel1.TabIndex = 1;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.ktxtUserInput);
            this.kryptonPanel2.Controls.Add(this.kmtxtUserInput);
            this.kryptonPanel2.Controls.Add(this.kcmbUserSelection);
            this.kryptonPanel2.Controls.Add(this.kwlMessage);
            this.kryptonPanel2.Controls.Add(this.pbxImage);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(580, 210);
            this.kryptonPanel2.TabIndex = 2;
            // 
            // pbxImage
            // 
            this.pbxImage.BackColor = System.Drawing.Color.Transparent;
            this.pbxImage.Location = new System.Drawing.Point(12, 29);
            this.pbxImage.Name = "pbxImage";
            this.pbxImage.Size = new System.Drawing.Size(128, 128);
            this.pbxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbxImage.TabIndex = 0;
            this.pbxImage.TabStop = false;
            // 
            // ktxtUserInput
            // 
            this.ktxtUserInput.Location = new System.Drawing.Point(147, 160);
            this.ktxtUserInput.Name = "ktxtUserInput";
            this.ktxtUserInput.Size = new System.Drawing.Size(309, 24);
            this.ktxtUserInput.StateActive.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ktxtUserInput.StateActive.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.ktxtUserInput.StateActiveBackGroundColour = System.Drawing.Color.Empty;
            this.ktxtUserInput.StateActiveBorderColourOne = System.Drawing.Color.Empty;
            this.ktxtUserInput.StateActiveBorderColourTwo = System.Drawing.Color.Empty;
            this.ktxtUserInput.StateActiveTextColour = System.Drawing.Color.Empty;
            this.ktxtUserInput.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ktxtUserInput.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.ktxtUserInput.StateCommonBackGroundColour = System.Drawing.Color.Empty;
            this.ktxtUserInput.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.ktxtUserInput.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.ktxtUserInput.StateCommonTextColour = System.Drawing.Color.Empty;
            this.ktxtUserInput.StateDisabled.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ktxtUserInput.StateDisabled.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.ktxtUserInput.StateDisabledBackGroundColour = System.Drawing.Color.Empty;
            this.ktxtUserInput.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.ktxtUserInput.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.ktxtUserInput.StateDisabledTextColour = System.Drawing.Color.Empty;
            this.ktxtUserInput.StateNormal.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ktxtUserInput.StateNormal.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.ktxtUserInput.StateNormalBackgroundColour = System.Drawing.Color.Empty;
            this.ktxtUserInput.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.ktxtUserInput.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.ktxtUserInput.StateNormalTextColour = System.Drawing.Color.Empty;
            this.ktxtUserInput.TabIndex = 3;
            this.ktxtUserInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ktxtUserInput.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ktxtUserInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ktxtUserInput_KeyDown);
            // 
            // kbtnButtonFour
            // 
            this.kbtnButtonFour.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnButtonFour.Image = null;
            this.kbtnButtonFour.Location = new System.Drawing.Point(462, 12);
            this.kbtnButtonFour.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnButtonFour.Name = "kbtnButtonFour";
            this.kbtnButtonFour.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnButtonFour.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnButtonFour.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonFour.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonFour.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonFour.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonFour.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonFour.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonFour.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonFour.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonFour.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnButtonFour.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnButtonFour.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonFour.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonFour.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonFour.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonFour.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonFour.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonFour.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonFour.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonFour.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnButtonFour.Size = new System.Drawing.Size(106, 25);
            this.kbtnButtonFour.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnButtonFour.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnButtonFour.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonFour.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonFour.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonFour.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonFour.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonFour.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonFour.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonFour.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonFour.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnButtonFour.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnButtonFour.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonFour.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonFour.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonFour.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonFour.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonFour.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonFour.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonFour.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonFour.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnButtonFour.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnButtonFour.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonFour.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonFour.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonFour.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonFour.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonFour.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonFour.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonFour.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonFour.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnButtonFour.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnButtonFour.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonFour.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonFour.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonFour.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonFour.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonFour.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonFour.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonFour.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonFour.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnButtonFour.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnButtonFour.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonFour.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonFour.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonFour.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonFour.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonFour.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonFour.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnButtonFour.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnButtonFour.TabIndex = 3;
            this.kbtnButtonFour.Values.Text = "Button 4";
            this.kbtnButtonFour.Click += new System.EventHandler(this.kbtnButtonFour_Click);
            // 
            // kwlMessage
            // 
            this.kwlMessage.AutoSize = false;
            this.kwlMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlMessage.Location = new System.Drawing.Point(147, 9);
            this.kwlMessage.Name = "kwlMessage";
            this.kwlMessage.Size = new System.Drawing.Size(421, 145);
            this.kwlMessage.StateCommon.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlMessage.Text = "kryptonWrapLabel1";
            this.kwlMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // kcmbUserSelection
            // 
            this.kcmbUserSelection.ComboBoxContentTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbUserSelection.ComboBoxItemContentLongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbUserSelection.ComboBoxItemContentShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbUserSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kcmbUserSelection.DropDownWidth = 309;
            this.kcmbUserSelection.Image = null;
            this.kcmbUserSelection.IntegralHeight = false;
            this.kcmbUserSelection.Location = new System.Drawing.Point(147, 162);
            this.kcmbUserSelection.Name = "kcmbUserSelection";
            this.kcmbUserSelection.Size = new System.Drawing.Size(309, 22);
            this.kcmbUserSelection.StateActive.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbUserSelection.StateActive.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kcmbUserSelection.StateActiveComboBoxBackColour = System.Drawing.Color.Empty;
            this.kcmbUserSelection.StateActiveComboBoxBorderColourOne = System.Drawing.Color.Empty;
            this.kcmbUserSelection.StateActiveComboBoxBorderColourTwo = System.Drawing.Color.Empty;
            this.kcmbUserSelection.StateActiveComboBoxContentColour = System.Drawing.Color.Empty;
            this.kcmbUserSelection.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbUserSelection.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbUserSelection.StateCommon.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbUserSelection.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbUserSelection.StateCommonComboBoxBackColour = System.Drawing.Color.Empty;
            this.kcmbUserSelection.StateCommonComboBoxBorderColourOne = System.Drawing.Color.Empty;
            this.kcmbUserSelection.StateCommonComboBoxBorderColourTwo = System.Drawing.Color.Empty;
            this.kcmbUserSelection.StateCommonComboBoxContentColour = System.Drawing.Color.Empty;
            this.kcmbUserSelection.StateCommonComboBoxDropBackColourOne = System.Drawing.Color.Empty;
            this.kcmbUserSelection.StateCommonComboBoxDropBackColourTwo = System.Drawing.Color.Empty;
            this.kcmbUserSelection.StateCommonComboBoxItemBackColourOne = System.Drawing.Color.Empty;
            this.kcmbUserSelection.StateCommonComboBoxItemBackColourTwo = System.Drawing.Color.Empty;
            this.kcmbUserSelection.StateCommonComboBoxItemContentLongTextColourOne = System.Drawing.Color.Empty;
            this.kcmbUserSelection.StateCommonComboBoxItemContentLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcmbUserSelection.StateCommonComboBoxItemContentShortTextColourOne = System.Drawing.Color.Empty;
            this.kcmbUserSelection.StateCommonComboBoxItemContentShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcmbUserSelection.StateDisabled.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbUserSelection.StateDisabled.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kcmbUserSelection.StateDisabled.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbUserSelection.StateDisabled.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbUserSelection.StateDisabledComboBoxBackColour = System.Drawing.Color.Empty;
            this.kcmbUserSelection.StateDisabledComboBoxBorderColourOne = System.Drawing.Color.Empty;
            this.kcmbUserSelection.StateDisabledComboBoxBorderColourTwo = System.Drawing.Color.Empty;
            this.kcmbUserSelection.StateDisabledComboBoxContentColour = System.Drawing.Color.Empty;
            this.kcmbUserSelection.StateDisabledComboBoxItemBackColourOne = System.Drawing.Color.Empty;
            this.kcmbUserSelection.StateDisabledComboBoxItemBackColourTwo = System.Drawing.Color.Empty;
            this.kcmbUserSelection.StateDisabledComboBoxItemContentLongTextColourOne = System.Drawing.Color.Empty;
            this.kcmbUserSelection.StateDisabledComboBoxItemContentLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcmbUserSelection.StateDisabledComboBoxItemContentShortTextColourOne = System.Drawing.Color.Empty;
            this.kcmbUserSelection.StateDisabledComboBoxItemContentShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcmbUserSelection.StateNormal.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbUserSelection.StateNormal.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kcmbUserSelection.StateNormal.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbUserSelection.StateNormal.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbUserSelection.StateNormalComboBoxBackColour = System.Drawing.Color.Empty;
            this.kcmbUserSelection.StateNormalComboBoxBorderColourOne = System.Drawing.Color.Empty;
            this.kcmbUserSelection.StateNormalComboBoxBorderColourTwo = System.Drawing.Color.Empty;
            this.kcmbUserSelection.StateNormalComboBoxContentColour = System.Drawing.Color.Empty;
            this.kcmbUserSelection.StateNormalComboBoxItemBackColourOne = System.Drawing.Color.Empty;
            this.kcmbUserSelection.StateNormalComboBoxItemBackColourTwo = System.Drawing.Color.Empty;
            this.kcmbUserSelection.StateNormalComboBoxItemContentLongTextColourOne = System.Drawing.Color.Empty;
            this.kcmbUserSelection.StateNormalComboBoxItemContentLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcmbUserSelection.StateNormalComboBoxItemContentShortTextColourOne = System.Drawing.Color.Empty;
            this.kcmbUserSelection.StateNormalComboBoxItemContentShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcmbUserSelection.StateTracking.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbUserSelection.StateTracking.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbUserSelection.StateTrackingComboBoxItemBackColourOne = System.Drawing.Color.Empty;
            this.kcmbUserSelection.StateTrackingComboBoxItemBackColourTwo = System.Drawing.Color.Empty;
            this.kcmbUserSelection.StateTrackingComboBoxItemContentLongTextColourOne = System.Drawing.Color.Empty;
            this.kcmbUserSelection.StateTrackingComboBoxItemContentLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcmbUserSelection.StateTrackingComboBoxItemContentShortTextColourOne = System.Drawing.Color.Empty;
            this.kcmbUserSelection.StateTrackingComboBoxItemContentShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcmbUserSelection.TabIndex = 3;
            this.kcmbUserSelection.KeyDown += new System.Windows.Forms.KeyEventHandler(this.kcmbUserSelection_KeyDown);
            // 
            // kmtxtUserInput
            // 
            this.kmtxtUserInput.Location = new System.Drawing.Point(147, 160);
            this.kmtxtUserInput.Name = "kmtxtUserInput";
            this.kmtxtUserInput.Size = new System.Drawing.Size(309, 24);
            this.kmtxtUserInput.StateActive.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kmtxtUserInput.StateActive.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kmtxtUserInput.StateActiveBackGroundColour = System.Drawing.Color.Empty;
            this.kmtxtUserInput.StateActiveBorderColourOne = System.Drawing.Color.Empty;
            this.kmtxtUserInput.StateActiveBorderColourTwo = System.Drawing.Color.Empty;
            this.kmtxtUserInput.StateActiveTextColour = System.Drawing.Color.Empty;
            this.kmtxtUserInput.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kmtxtUserInput.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kmtxtUserInput.StateCommonBackGroundColour = System.Drawing.Color.Empty;
            this.kmtxtUserInput.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kmtxtUserInput.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kmtxtUserInput.StateCommonTextColour = System.Drawing.Color.Empty;
            this.kmtxtUserInput.StateDisabled.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kmtxtUserInput.StateDisabled.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kmtxtUserInput.StateDisabledBackGroundColour = System.Drawing.Color.Empty;
            this.kmtxtUserInput.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kmtxtUserInput.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kmtxtUserInput.StateDisabledTextColour = System.Drawing.Color.Empty;
            this.kmtxtUserInput.StateNormal.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kmtxtUserInput.StateNormal.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kmtxtUserInput.StateNormalBackgroundColour = System.Drawing.Color.Empty;
            this.kmtxtUserInput.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kmtxtUserInput.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kmtxtUserInput.StateNormalTextColour = System.Drawing.Color.Empty;
            this.kmtxtUserInput.TabIndex = 4;
            this.kmtxtUserInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kmtxtUserInput.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kmtxtUserInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.kmtxtUserInput_KeyDown);
            // 
            // KryptonInputBoxExtended
            // 
            this.ClientSize = new System.Drawing.Size(580, 261);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonInputBoxExtended";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KryptonInputBoxExtended_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbUserSelection)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private static DialogResult _userResponse;

        private static string[] _buttonTextArray = new string[4];

        private Image[] _iconImageArray = new Image[7];

        private Image _customImage;
        #endregion

        #region Enumerations
        public enum Icon
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
            HAND
        }

        public enum IconImageSize
        {
            CUSTOM,
            THIRTYTWO,
            FOURTYEIGHT,
            SIXTYFOUR,
            ONEHUNDREDANDTWENTYEIGHT
        }

        public enum Type
        {
            COMBOBOX,
            TEXTBOX,
            MASKEDTEXTBOX,
            NOTHING
        }

        public enum Buttons
        {
            OK,
            OKCANCEL,
            YESNO,
            YESNOCANCEL
        }

        public enum Language
        {
            CZECH,
            ENGLISH,
            FRENCH,
            GERMAN,
            SLOVAKIAN,
            SPANISH,
            CUSTOM
        }

        public enum TextAlignment
        {
            LEFT,
            CENTRE,
            RIGHT
        }

        public enum NormalMessageTextAlignment
        {
            INHERIT,
            NEARNEAR,
            NEARCENTRE,
            NEARFAR,
            CENTRENEAR,
            CENTRECENTRE,
            CENTREFAR,
            FARNEAR,
            FARCENTRE,
            FARFAR,
            INHERITNEAR,
            INHERITCENTRE,
            INHERITFAR,
            NEARINHERIT,
            CENTREINHERIT,
            FARINHERIT
        }

        public enum WrappedMessageTextAlignment
        {
            TOPLEFT,
            TOPCENTRE,
            TOPRIGHT,
            MIDDLELEFT,
            MIDDLECENTRE,
            MIDDLERIGHT,
            BOTTOMLEFT,
            BOTTOMCENTRE,
            BOTTOMRIGHT
        }

        public enum MessageDisplayType
        {
            LABEL,
            WRAPPEDLABEL
        }
        #endregion

        #region Properties
        public static DialogResult UserResponse { get => _userResponse; set => _userResponse = value; }

        public Image[] IconImages { get => _iconImageArray; private set => _iconImageArray = value; }

        public Image CustomImage { get => _customImage; set => _customImage = value; }
        #endregion

        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="KryptonInputBoxExtended"/> class.</summary>
        /// <param name="message">The message.</param>
        /// <param name="title">The title.</param>
        /// <param name="language">The language.</param>
        /// <param name="type">The type.</param>
        /// <param name="listItems">The list items.</param>
        /// <param name="showInTaskBar">if set to <c>true</c> [show in task bar].</param>
        /// <param name="controlTypeface">The control typeface.</param>
        /// <param name="messageTypeface">The message typeface.</param>
        /// <param name="okText">The ok text.</param>
        /// <param name="yesText">The yes text.</param>
        /// <param name="noText">The no text.</param>
        /// <param name="cancelText">The cancel text.</param>
        /// <param name="hintText">The hint text.</param>
        public KryptonInputBoxExtended(string message, string title = "", Language language = Language.ENGLISH, Type type = Type.NOTHING, string[] listItems = null, bool showInTaskBar = false, Font controlTypeface = null, Font messageTypeface = null, string okText = "&Ok", string yesText = "&Yes", string noText = "N&o", string cancelText = "&Cancel", string hintText = "")
        {
            InitializeComponent();

            PropagateIconImageArray(IconImages);

            SetMessage(message);

            SetTitle(title);

            SetIconType(Icon.NOTHING);

            SetLanguage(language, okText, yesText, noText, cancelText);

            AdaptButtons(Buttons.OK, language);

            ChangeButtonVisibility(Buttons.OK);

            AdaptUI(type, listItems);

            SetShowInTaskbar(showInTaskBar);

            SetControlTypeface(controlTypeface);

            SetMessageTypeface(messageTypeface);

            SetHint(hintText);
        }

        /// <summary>Initializes a new instance of the <see cref="KryptonInputBoxExtended"/> class.</summary>
        /// <param name="message">The message.</param>
        /// <param name="title">The title.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="image">The image.</param>
        /// <param name="language">The language.</param>
        /// <param name="type">The type.</param>
        /// <param name="listItems">The list items.</param>
        /// <param name="showInTaskBar">if set to <c>true</c> [show in task bar].</param>
        /// <param name="controlTypeface">The control typeface.</param>
        /// <param name="messageTypeface">The message typeface.</param>
        /// <param name="okText">The ok text.</param>
        /// <param name="yesText">The yes text.</param>
        /// <param name="noText">The no text.</param>
        /// <param name="cancelText">The cancel text.</param>
        /// <param name="hintText">The hint text.</param>
        public KryptonInputBoxExtended(string message, string title = "", Icon icon = Icon.NONE, Image image = null, Language language = Language.ENGLISH, Type type = Type.NOTHING, string[] listItems = null, bool showInTaskBar = false, Font controlTypeface = null, Font messageTypeface = null, string okText = "&Ok", string yesText = "&Yes", string noText = "N&o", string cancelText = "&Cancel", string hintText = "")
        {
            InitializeComponent();

            PropagateIconImageArray(IconImages);

            SetMessage(message);

            SetTitle(title);

            SetIconType(icon, image);

            SetLanguage(language, okText, yesText, noText, cancelText);

            AdaptButtons(Buttons.OK, language);

            ChangeButtonVisibility(Buttons.OK);

            AdaptUI(type, listItems);

            SetShowInTaskbar(showInTaskBar);

            SetControlTypeface(controlTypeface);

            SetMessageTypeface(messageTypeface);

            SetHint(hintText);
        }

        /// <summary>Initializes a new instance of the <see cref="KryptonInputBoxExtended"/> class.</summary>
        /// <param name="message">The message.</param>
        /// <param name="title">The title.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="image">The image.</param>
        /// <param name="language">The language.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="type">The type.</param>
        /// <param name="listItems">The list items.</param>
        /// <param name="showInTaskBar">if set to <c>true</c> [show in task bar].</param>
        /// <param name="controlTypeface">The control typeface.</param>
        /// <param name="messageTypeface">The message typeface.</param>
        /// <param name="okText">The ok text.</param>
        /// <param name="yesText">The yes text.</param>
        /// <param name="noText">The no text.</param>
        /// <param name="cancelText">The cancel text.</param>
        /// <param name="hintText">The hint text.</param>
        public KryptonInputBoxExtended(string message, string title = "", Icon icon = Icon.INFORMATION, Image image = null, Language language = Language.ENGLISH, Buttons buttons = Buttons.OK, Type type = Type.NOTHING, string[] listItems = null, bool showInTaskBar = false, Font controlTypeface = null, Font messageTypeface = null, string okText = "&Ok", string yesText = "&Yes", string noText = "N&o", string cancelText = "&Cancel", string hintText = "")
        {
            InitializeComponent();

            PropagateIconImageArray(IconImages);

            SetMessage(message);

            SetTitle(title);

            SetIconType(icon, image);

            SetLanguage(language, okText, yesText, noText, cancelText);

            AdaptButtons(buttons, language);

            ChangeButtonVisibility(buttons);

            AdaptUI(type, listItems);

            SetShowInTaskbar(showInTaskBar);

            SetControlTypeface(controlTypeface);

            SetMessageTypeface(messageTypeface);

            SetHint(hintText);
        }

        /// <summary>Initializes a new instance of the <see cref="KryptonInputBoxExtended"/> class.</summary>
        /// <param name="message">The message.</param>
        /// <param name="title">The title.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="image">The image.</param>
        /// <param name="language">The language.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="type">The type.</param>
        /// <param name="listItems">The list items.</param>
        /// <param name="showInTaskBar">if set to <c>true</c> [show in task bar].</param>
        /// <param name="controlTypeface">The control typeface.</param>
        /// <param name="messageTypeface">The message typeface.</param>
        /// <param name="okText">The ok text.</param>
        /// <param name="yesText">The yes text.</param>
        /// <param name="noText">The no text.</param>
        /// <param name="cancelText">The cancel text.</param>
        /// <param name="hintText">The hint text.</param>
        /// <param name="startPosition">The start position.</param>
        public KryptonInputBoxExtended(string message, string title = "", Icon icon = Icon.INFORMATION, Image image = null, Language language = Language.ENGLISH, Buttons buttons = Buttons.OK, Type type = Type.NOTHING, string[] listItems = null, bool showInTaskBar = false, Font controlTypeface = null, Font messageTypeface = null, string okText = "&Ok", string yesText = "&Yes", string noText = "N&o", string cancelText = "&Cancel", string hintText = "", FormStartPosition startPosition = FormStartPosition.WindowsDefaultLocation)
        {
            InitializeComponent();

            PropagateIconImageArray(IconImages);

            SetMessage(message);

            SetTitle(title);

            SetIconType(icon, image);

            SetLanguage(language, okText, yesText, noText, cancelText);

            AdaptButtons(buttons, language);

            ChangeButtonVisibility(buttons);

            AdaptUI(type, listItems);

            SetShowInTaskbar(showInTaskBar);

            SetControlTypeface(controlTypeface);

            SetMessageTypeface(messageTypeface);

            SetHint(hintText);

            SetStartPosition(startPosition);
        }

        /// <summary>Initializes a new instance of the <see cref="KryptonInputBoxExtended"/> class.</summary>
        /// <param name="message">The message.</param>
        /// <param name="title">The title.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="image">The image.</param>
        /// <param name="language">The language.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="type">The type.</param>
        /// <param name="listItems">The list items.</param>
        /// <param name="showInTaskBar">if set to <c>true</c> [show in task bar].</param>
        /// <param name="controlTypeface">The control typeface.</param>
        /// <param name="messageTypeface">The message typeface.</param>
        /// <param name="okText">The ok text.</param>
        /// <param name="yesText">The yes text.</param>
        /// <param name="noText">The no text.</param>
        /// <param name="cancelText">The cancel text.</param>
        /// <param name="hintText">The hint text.</param>
        /// <param name="textAlignment">The text alignment.</param>
        public KryptonInputBoxExtended(string message, string title = "", Icon icon = Icon.INFORMATION, Image image = null, Language language = Language.ENGLISH, Buttons buttons = Buttons.OK, Type type = Type.NOTHING, string[] listItems = null, bool showInTaskBar = false, Font controlTypeface = null, Font messageTypeface = null, string okText = "&Ok", string yesText = "&Yes", string noText = "N&o", string cancelText = "&Cancel", string hintText = "", WrappedMessageTextAlignment textAlignment = WrappedMessageTextAlignment.MIDDLELEFT)
        {
            InitializeComponent();

            PropagateIconImageArray(IconImages);

            SetMessage(message);

            SetTitle(title);

            SetIconType(icon, image);

            SetLanguage(language, okText, yesText, noText, cancelText);

            AdaptButtons(buttons, language);

            ChangeButtonVisibility(buttons);

            AdaptUI(type, listItems);

            SetShowInTaskbar(showInTaskBar);

            SetControlTypeface(controlTypeface);

            SetMessageTypeface(messageTypeface);

            SetHint(hintText);

            SetMessageTextAlignment(textAlignment);
        }

        /// <summary>Initializes a new instance of the <see cref="KryptonInputBoxExtended"/> class.</summary>
        /// <param name="iconLocation">The icon location.</param>
        /// <param name="message">The message.</param>
        /// <param name="title">The title.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="image">The image.</param>
        /// <param name="language">The language.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="type">The type.</param>
        /// <param name="listItems">The list items.</param>
        /// <param name="showInTaskBar">if set to <c>true</c> [show in task bar].</param>
        /// <param name="controlTypeface">The control typeface.</param>
        /// <param name="messageTypeface">The message typeface.</param>
        /// <param name="okText">The ok text.</param>
        /// <param name="yesText">The yes text.</param>
        /// <param name="noText">The no text.</param>
        /// <param name="cancelText">The cancel text.</param>
        /// <param name="hintText">The hint text.</param>
        /// <param name="startPosition">The start position.</param>
        /// <param name="textAlignment">The text alignment.</param>
        public KryptonInputBoxExtended(Point iconLocation, string message, string title = "", Icon icon = Icon.INFORMATION, Image image = null, Language language = Language.ENGLISH, Buttons buttons = Buttons.OK, Type type = Type.NOTHING, string[] listItems = null, bool showInTaskBar = false, Font controlTypeface = null, Font messageTypeface = null, string okText = "&Ok", string yesText = "&Yes", string noText = "N&o", string cancelText = "&Cancel", string hintText = "", FormStartPosition startPosition = FormStartPosition.WindowsDefaultLocation, TextAlignment textAlignment = TextAlignment.LEFT)
        {
            InitializeComponent();

            PropagateIconImageArray(IconImages);

            SetMessage(message);

            SetTitle(title);

            SetIconType(icon, image);

            SetLanguage(language, okText, yesText, noText, cancelText);

            AdaptButtons(buttons, language);

            ChangeButtonVisibility(buttons);

            AdaptUI(type, listItems);

            SetShowInTaskbar(showInTaskBar);

            SetControlTypeface(controlTypeface);

            SetMessageTypeface(messageTypeface);

            SetHint(hintText);

            RelocateIcon(iconLocation);

            SetTextAlignment(textAlignment);

            SetStartPosition(startPosition);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Sets the message.
        /// </summary>
        /// <param name="message">The message.</param>
        private void SetMessage(string message) => kwlMessage.Text = message;

        /// <summary>Sets the title.</summary>
        /// <param name="title">The title.</param>
        private void SetTitle(string title) => Text = title;

        /// <summary>Sets the message typeface.</summary>
        /// <param name="typeface">The typeface.</param>
        private void SetMessageTypeface(Font typeface) => kwlMessage.StateCommon.Font = typeface;

        /// <summary>Sets the show in taskbar.</summary>
        /// <param name="showInTaskbar">if set to <c>true</c> [show in taskbar].</param>
        private void SetShowInTaskbar(bool showInTaskbar) => ShowInTaskbar = showInTaskbar;

        /// <summary>
        /// Sets the hint.
        /// </summary>
        /// <param name="hintText">The hint text.</param>
        private void SetHint(string hintText) => ktxtUserInput.Hint = hintText;

        /// <summary>Sets the control typeface.</summary>
        /// <param name="typeface">The typeface.</param>
        private void SetControlTypeface(Font typeface)
        {
            kbtnButtonThree.StateCommon.Content.ShortText.Font = typeface;

            kbtnButtonFour.StateCommon.Content.ShortText.Font = typeface;

            kbtnButtonOne.StateCommon.Content.ShortText.Font = typeface;

            kbtnButtonTwo.StateCommon.Content.ShortText.Font = typeface;
        }

        /// <summary>
        /// Sets the language.
        /// </summary>
        /// <param name="language">The language.</param>
        /// <param name="okText">The ok text.</param>
        /// <param name="yesText">The yes text.</param>
        /// <param name="noText">The no text.</param>
        /// <param name="cancelText">The cancel text.</param>
        private void SetLanguage(Language language, string okText = "", string yesText = "", string noText = "", string cancelText = "")
        {
            switch (language)
            {
                case Language.CZECH:
                    _buttonTextArray = "OK,Ano,Ne,Storno".Split(',');
                    break;
                case Language.FRENCH:
                    _buttonTextArray = "OK,Oui,Non,Annuler".Split(',');
                    break;
                case Language.GERMAN:
                    _buttonTextArray = "OK,Ja,Nein,Stornieren".Split(',');
                    break;
                case Language.SLOVAKIAN:
                    _buttonTextArray = "OK,Áno,Nie,Zrušiť".Split(',');
                    break;
                case Language.SPANISH:
                    _buttonTextArray = "OK,Sí,No,Cancelar".Split(',');
                    break;
                case Language.CUSTOM:
                    _buttonTextArray = SetCustomText(okText, yesText, noText, cancelText);
                    break;
                default:
                    _buttonTextArray = "OK,Yes,No,Cancel".Split(',');
                    break;
            }
        }

        /// <summary>
        /// Sets the custom text.
        /// </summary>
        /// <param name="okText">The ok text.</param>
        /// <param name="yesText">The yes text.</param>
        /// <param name="noText">The no text.</param>
        /// <param name="cancelText">The cancel text.</param>
        /// <returns></returns>
        private static string[] SetCustomText(string okText, string yesText, string noText, string cancelText)
        {
            string[] tempArray = new string[4];

            tempArray = $"{ okText },{ yesText },{ noText },{ cancelText }".Split(',');

            return tempArray;
        }

        /// <summary>
        /// Handles the Click event of the Button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Button_Click(object sender, EventArgs e)
        {
            KryptonButton button = (KryptonButton)sender;

            switch (button.Name)
            {
                case "kbtnChoiceOne":
                    UserResponse = DialogResult.Yes;
                    break;
                case "kbtnChoiceTwo":
                    UserResponse = DialogResult.No;
                    break;
                case "kbtnChoiceThree":
                    UserResponse = DialogResult.Cancel;
                    break;
                default:
                    UserResponse = DialogResult.OK;
                    break;
            }
        }

        /// <summary>Sets the type of the icon.</summary>
        /// <param name="icon">The icon.</param>
        /// <param name="image">The image.</param>
        /// <exception cref="ArgumentNullException"></exception>
        private void SetIconType(Icon icon, Image image = null)
        {
            switch (icon)
            {
                case Icon.CUSTOM:
                    if (image != null)
                    {
                        AdaptUI(true);

                        SetIconImage(image);
                    }
                    else
                    {
                        throw new ArgumentNullException();
                    }
                    break;
                case Icon.OK:
                    AdaptUI(true);

                    SetIconImage(InputBoxResources.Input_Box_Ok_64_x_64);
                    break;
                case Icon.ERROR:
                    AdaptUI(true);

                    SetIconImage(InputBoxResources.Input_Box_Critical_64_x_64);
                    break;
                case Icon.EXCLAMATION:
                    AdaptUI(true);

                    SetIconImage(InputBoxResources.Input_Box_Warning_64_x_58);
                    break;
                case Icon.INFORMATION:
                    AdaptUI(true);

                    SetIconImage(InputBoxResources.Input_Box_Information_64_x_64);
                    break;
                case Icon.QUESTION:
                    AdaptUI(true);

                    SetIconImage(InputBoxResources.Input_Box_Question_64_x_64);
                    break;
                case Icon.NOTHING:
                    AdaptUI(false);
                    break;
                case Icon.NONE:
                    AdaptUI(false);
                    break;
                case Icon.STOP:
                    AdaptUI(true);

                    SetIconImage(InputBoxResources.Input_Box_Stop_64_x_64);
                    break;
                case Icon.HAND:
                    AdaptUI(true);

                    SetIconImage(InputBoxResources.Input_Box_Hand_64_x_64);
                    break;
            }
        }

        /// <summary>Sets the icon image.</summary>
        /// <param name="image">The image.</param>
        private void SetIconImage(Image image) => pbxImage.Image = image;

        /// <summary>Adapts the buttons.</summary>
        /// <param name="buttons">The buttons.</param>
        /// <param name="language">The language.</param>
        /// <returns></returns>
        private KryptonButton[] AdaptButtons(Buttons buttons, Language language)
        {
            KryptonButton[] buttonArray = new KryptonButton[3];

            #region Set Button Text
            kbtnButtonOne.Text = _buttonTextArray[0];

            kbtnButtonTwo.Text = _buttonTextArray[1];

            kbtnButtonFour.Text = _buttonTextArray[2];

            kbtnButtonThree.Text = _buttonTextArray[3];
            #endregion

            switch (buttons)
            {
                case Buttons.OK:
                    kbtnButtonOne.Location = new Point(483, 9);

                    buttonArray[0] = kbtnButtonOne;
                    break;
                case Buttons.OKCANCEL:
                    kbtnButtonOne.Location = new Point(388, 9);

                    buttonArray[0] = kbtnButtonOne;

                    kbtnButtonThree.Location = new Point(483, 9);

                    buttonArray[1] = kbtnButtonThree;
                    break;
                case Buttons.YESNO:
                    kbtnButtonTwo.Location = new Point(388, 9);

                    buttonArray[0] = kbtnButtonTwo;

                    kbtnButtonFour.Location = new Point(483, 9);

                    buttonArray[1] = kbtnButtonFour;
                    break;
                case Buttons.YESNOCANCEL:
                    kbtnButtonTwo.Location = new Point(293, 9);

                    buttonArray[0] = kbtnButtonTwo;

                    kbtnButtonFour.Location = new Point(388, 9);

                    buttonArray[1] = kbtnButtonFour;

                    kbtnButtonThree.Location = new Point(483, 9);

                    buttonArray[2] = kbtnButtonThree;
                    break;
                default:
                    break;
            }

            foreach (KryptonButton button in buttonArray)
            {
                if (button != null)
                {
                    button.Size = new Size(89, 28);

                    button.Click += Button_Click;
                }
            }

            return buttonArray;
        }

        /// <summary>Adapts the UI.</summary>
        /// <param name="showIconBox">if set to <c>true</c> [show icon box].</param>
        private void AdaptUI(bool showIconBox)
        {
            if (showIconBox)
            {
                pbxImage.Visible = true;

                ResizeControls(new Size(489, 175), new Point(213, 192), new Point(213, 192));
            }
            else
            {
                pbxImage.Visible = false;

                ResizeControls(new Size(560, 175), new Point(180, 192), new Point(180, 192));
            }
        }

        /// <summary>Adapts the UI.</summary>
        /// <param name="type">The type.</param>
        /// <param name="itemList">The item list.</param>
        private void AdaptUI(Type type, string[] itemList)
        {
            if (itemList != null)
            {
                foreach (string item in itemList)
                {
                    kcmbUserSelection.Items.Add(item);
                }

                kcmbUserSelection.SelectedIndex = 0;
            }

            switch (type)
            {
                case Type.COMBOBOX:
                    ktxtUserInput.Visible = false;

                    kmtxtUserInput.Visible = false;

                    kcmbUserSelection.Visible = true;
                    break;
                case Type.TEXTBOX:
                    ktxtUserInput.Visible = true;

                    kmtxtUserInput.Visible = false;

                    kcmbUserSelection.Visible = false;
                    break;
                case Type.MASKEDTEXTBOX:
                    ktxtUserInput.Visible = false;

                    kmtxtUserInput.Visible = true;

                    kcmbUserSelection.Visible = false;
                    break;
            }
        }

        /// <summary>Adapts the display type of the message.</summary>
        /// <param name="displayType">The display type.</param>
        private void AdaptMessageDisplayType(MessageDisplayType displayType)
        {
            switch (displayType)
            {
                case MessageDisplayType.LABEL:
                    kwlMessage.Visible = true;

                    kwlMessage.Visible = false;
                    break;
                case MessageDisplayType.WRAPPEDLABEL:
                    kwlMessage.Visible = false;

                    kwlMessage.Visible = true;
                    break;
            }
        }

        /// <summary>Resizes the controls.</summary>
        /// <param name="messageLabelSize">Size of the message label.</param>
        /// <param name="userSelectionLocation">The user selection location.</param>
        /// <param name="userInputLocation">The user input location.</param>
        private void ResizeControls(Size messageLabelSize, Point userSelectionLocation, Point userInputLocation)
        {
            kwlMessage.Size = messageLabelSize;

            kcmbUserSelection.Location = userSelectionLocation;

            ktxtUserInput.Location = userInputLocation;
        }

        /// <summary>
        /// Sets the text alignment.
        /// </summary>
        /// <param name="textAlignment">The text alignment.</param>
        private void SetTextAlignment(TextAlignment textAlignment)
        {
            switch (textAlignment)
            {
                case TextAlignment.LEFT:
                    ktxtUserInput.TextAlign = HorizontalAlignment.Left;
                    break;
                case TextAlignment.CENTRE:
                    ktxtUserInput.TextAlign = HorizontalAlignment.Center;
                    break;
                case TextAlignment.RIGHT:
                    ktxtUserInput.TextAlign = HorizontalAlignment.Right;
                    break;
            }
        }

        /// <summary>
        /// Gets the user response.
        /// </summary>
        /// <returns></returns>
        public string GetUserResponse() => ktxtUserInput.Text;

        /// <summary>
        /// Gets the user choice.
        /// </summary>
        /// <returns></returns>
        public string GetUserChoice() => kcmbUserSelection.Text;

        /// <summary>Relocates the icon.</summary>
        /// <param name="newPoint">The new point.</param>
        private void RelocateIcon(Point newPoint) => pbxImage.Location = newPoint;

        private void SetStartPosition(FormStartPosition startPosition) => StartPosition = startPosition;

        /// <summary>
        /// Changes the button visibility.
        /// </summary>
        /// <param name="buttons">The buttons.</param>
        private void ChangeButtonVisibility(Buttons buttons)
        {
            switch (buttons)
            {
                case Buttons.OK:
                    kbtnButtonOne.Visible = true;

                    kbtnButtonThree.Visible = false;

                    kbtnButtonFour.Visible = false;

                    kbtnButtonTwo.Visible = false;
                    break;
                case Buttons.OKCANCEL:
                    kbtnButtonOne.Visible = true;

                    kbtnButtonThree.Visible = true;

                    kbtnButtonFour.Visible = false;

                    kbtnButtonTwo.Visible = false;
                    break;
                case Buttons.YESNO:
                    kbtnButtonOne.Visible = false;

                    kbtnButtonThree.Visible = false;

                    kbtnButtonFour.Visible = true;

                    kbtnButtonTwo.Visible = true;
                    break;
                case Buttons.YESNOCANCEL:
                    kbtnButtonOne.Visible = false;

                    kbtnButtonThree.Visible = true;

                    kbtnButtonFour.Visible = true;

                    kbtnButtonTwo.Visible = true;
                    break;
            }
        }

        /// <summary>Sets the mask.</summary>
        /// <param name="maskText">The mask text.</param>
        private void SetMask(string maskText) => kmtxtUserInput.Mask = maskText;

        /// <summary>Sets the masked textbox text alignment.</summary>
        /// <param name="alignment">The alignment.</param>
        private void SetMaskedTextboxTextAlignment(TextAlignment alignment)
        {
            switch (alignment)
            {
                case TextAlignment.LEFT:
                    kmtxtUserInput.TextAlign = HorizontalAlignment.Left;
                    break;
                case TextAlignment.CENTRE:
                    kmtxtUserInput.TextAlign = HorizontalAlignment.Center;
                    break;
                case TextAlignment.RIGHT:
                    kmtxtUserInput.TextAlign = HorizontalAlignment.Right;
                    break;
            }
        }

        /*
        /// <summary>Sets the message text alignment.</summary>
        /// <param name="alignment">The alignment.</param>
        private void SetMessageTextAlignment(MessageTextAlignment alignment)
        {
            switch (alignment)
            {
                case MessageTextAlignment.INHERIT:
                    kwlMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Inherit;

                    kwlMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Inherit;
                    break;
                case MessageTextAlignment.NEARNEAR:
                    kwlMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Near;

                    kwlMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Near;
                    break;
                case MessageTextAlignment.NEARCENTRE:
                    kwlMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Near;

                    kwlMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Center;
                    break;
                case MessageTextAlignment.NEARFAR:
                    kwlMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Near;

                    kwlMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Far;
                    break;
                case MessageTextAlignment.CENTRENEAR:
                    kwlMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Center;

                    kwlMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Near;
                    break;
                case MessageTextAlignment.CENTRECENTRE:
                    kwlMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Center;

                    kwlMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Center;
                    break;
                case MessageTextAlignment.CENTREFAR:
                    kwlMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Center;

                    kwlMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Far;
                    break;
                case MessageTextAlignment.FARNEAR:
                    kwlMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Far;

                    kwlMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Near;
                    break;
                case MessageTextAlignment.FARCENTRE:
                    kwlMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Far;

                    kwlMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Center;
                    break;
                case MessageTextAlignment.FARFAR:
                    kwlMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Far;

                    kwlMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Far;
                    break;
                case MessageTextAlignment.INHERITNEAR:
                    kwlMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Inherit;

                    kwlMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Near;
                    break;
                case MessageTextAlignment.INHERITCENTRE:
                    kwlMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Inherit;

                    kwlMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Center;
                    break;
                case MessageTextAlignment.INHERITFAR:
                    kwlMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Inherit;

                    kwlMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Far;
                    break;
                case MessageTextAlignment.NEARINHERIT:
                    kwlMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Near;

                    kwlMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Inherit;
                    break;
                case MessageTextAlignment.CENTREINHERIT:
                    kwlMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Center;

                    kwlMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Inherit;
                    break;
                case MessageTextAlignment.FARINHERIT:
                    kwlMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Far;

                    kwlMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Inherit;
                    break;
            }
        }
        */

        /// <summary>Sets the message text alignment.</summary>
        /// <param name="alignment">The alignment.</param>
        private void SetMessageTextAlignment(WrappedMessageTextAlignment alignment)
        {
            switch (alignment)
            {
                case WrappedMessageTextAlignment.TOPLEFT:
                    kwlMessage.TextAlign = ContentAlignment.TopLeft;
                    break;
                case WrappedMessageTextAlignment.TOPCENTRE:
                    kwlMessage.TextAlign = ContentAlignment.TopCenter;
                    break;
                case WrappedMessageTextAlignment.TOPRIGHT:
                    kwlMessage.TextAlign = ContentAlignment.TopRight;
                    break;
                case WrappedMessageTextAlignment.MIDDLELEFT:
                    kwlMessage.TextAlign = ContentAlignment.MiddleLeft;
                    break;
                case WrappedMessageTextAlignment.MIDDLECENTRE:
                    kwlMessage.TextAlign = ContentAlignment.MiddleCenter;
                    break;
                case WrappedMessageTextAlignment.MIDDLERIGHT:
                    kwlMessage.TextAlign = ContentAlignment.MiddleRight;
                    break;
                case WrappedMessageTextAlignment.BOTTOMLEFT:
                    kwlMessage.TextAlign = ContentAlignment.BottomLeft;
                    break;
                case WrappedMessageTextAlignment.BOTTOMCENTRE:
                    kwlMessage.TextAlign = ContentAlignment.BottomCenter;
                    break;
                case WrappedMessageTextAlignment.BOTTOMRIGHT:
                    kwlMessage.TextAlign = ContentAlignment.BottomRight;
                    break;
                default:
                    kwlMessage.TextAlign = ContentAlignment.MiddleLeft;
                    break;
            }
        }

        private void PropagateIconImageArray(Image[] imageArray)
        {
            imageArray[0] = InputBoxResources.Input_Box_Critical_128_x_128;

            imageArray[1] = InputBoxResources.Input_Box_Hand_128_x_128;

            imageArray[2] = InputBoxResources.Input_Box_Information_128_x_128;

            imageArray[3] = InputBoxResources.Input_Box_Ok_128_x_128;

            imageArray[4] = InputBoxResources.Input_Box_Question_128_x_128;

            imageArray[5] = InputBoxResources.Input_Box_Stop_128_x_128;

            imageArray[6] = InputBoxResources.Input_Box_Warning_128_x_115;
        }

        private Image[] ReturnIconImageArray() => IconImages;
        #endregion

        private void KryptonInputBoxExtended_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != null)
            {
                UserResponse = DialogResult;
            }
            else
            {
                DialogResult = DialogResult.None;
            }
        }

        private void ktxtUserInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult = DialogResult.OK;

                Close();
            }
        }

        private void kmtxtUserInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult = DialogResult.OK;

                Close();
            }
        }

        private void kcmbUserSelection_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult = DialogResult.OK;

                Close();
            }
        }

        private void kbtnButtonThree_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void kbtnButtonFour_Click(object sender, EventArgs e) => DialogResult = DialogResult.No;

        private void kbtnButtonTwo_Click(object sender, EventArgs e) => DialogResult = DialogResult.Yes;

        private void kbtnButtonOne_Click(object sender, EventArgs e) => DialogResult = DialogResult.OK;

        #region Show

        #region Internal Show
        private static string InternalShow(string message, string title = "", Language language = Language.ENGLISH, Type type = Type.NOTHING, string[] listItems = null, bool showInTaskBar = false, Font controlTypeface = null, Font messageTypeface = null, string okText = "&Ok", string yesText = "&Yes", string noText = "N&o", string cancelText = "&Cancel", string hintText = "")
        {
            using (KryptonInputBoxExtended ib = new KryptonInputBoxExtended(message, title, language, type, listItems, showInTaskBar, controlTypeface, messageTypeface, okText, yesText, noText, cancelText, hintText))
            {
                return ib.ShowDialog() == DialogResult.OK ? ib.GetUserResponse() : string.Empty;
            }
        }

        private static string InternalShow(string message, string title = "", Icon icon = Icon.INFORMATION, Image image = null, Language language = Language.ENGLISH, Buttons buttons = Buttons.OK, Type type = Type.NOTHING, string[] listItems = null, bool showInTaskBar = false, Font controlTypeface = null, Font messageTypeface = null, string okText = "&Ok", string yesText = "&Yes", string noText = "N&o", string cancelText = "&Cancel", string hintText = "", FormStartPosition startPosition = FormStartPosition.WindowsDefaultLocation, TextAlignment textAlignment = TextAlignment.LEFT, Point iconLocation = new Point())
        {
            using (KryptonInputBoxExtended inputBoxExtended = new KryptonInputBoxExtended(iconLocation, message, title, icon, image, language, buttons, type, listItems, showInTaskBar, controlTypeface, messageTypeface, okText, yesText, noText, cancelText, hintText, startPosition, textAlignment))
            {
                inputBoxExtended.StartPosition = startPosition;

                return inputBoxExtended.ShowDialog() == DialogResult.OK ? inputBoxExtended.GetUserResponse() : string.Empty;
            }
        }

        private static string InternalShow(IWin32Window owner, string message, string title = "", Icon icon = Icon.INFORMATION, Image image = null, Language language = Language.ENGLISH, Buttons buttons = Buttons.OK, Type type = Type.NOTHING, string[] listItems = null, bool showInTaskBar = false, Font controlTypeface = null, Font messageTypeface = null, string okText = "&Ok", string yesText = "&Yes", string noText = "N&o", string cancelText = "&Cancel", string hintText = "", FormStartPosition startPosition = FormStartPosition.WindowsDefaultLocation, TextAlignment textAlignment = TextAlignment.LEFT, Point iconLocation = new Point())
        {
            IWin32Window showOwner = owner ?? FromHandle(PI.GetActiveWindow());

            string result;

            using (KryptonInputBoxExtended inputBoxExtended = new KryptonInputBoxExtended(iconLocation, message, title, icon, image, language, buttons, type, listItems, showInTaskBar, controlTypeface, messageTypeface, okText, yesText, noText, cancelText, hintText, startPosition, textAlignment))
            {
                inputBoxExtended.StartPosition = startPosition;

                switch (type)
                {
                    case Type.COMBOBOX:
                        break;
                    case Type.TEXTBOX:
                        break;
                    case Type.MASKEDTEXTBOX:
                        break;
                    case Type.NOTHING:
                        break;
                    default:
                        result = inputBoxExtended.ShowDialog(showOwner) == DialogResult.OK ? inputBoxExtended.GetUserResponse() : string.Empty;
                        break;
                }

                return inputBoxExtended.ShowDialog(showOwner) == DialogResult.OK ? inputBoxExtended.GetUserResponse() : string.Empty;
            }
        }
        #endregion

        public static string Show(string message, string title = "", Language language = Language.ENGLISH, Type type = Type.NOTHING, string[] listItems = null, bool showInTaskBar = false, Font controlTypeface = null, Font messageTypeface = null, string okText = "&Ok", string yesText = "&Yes", string noText = "N&o", string cancelText = "&Cancel", string hintText = "") => InternalShow(message, title, language, type, listItems, showInTaskBar, controlTypeface, messageTypeface, okText, yesText, noText, cancelText, hintText);

        public static string Show(string message, string title = "", Icon icon = Icon.INFORMATION, Image image = null, Language language = Language.ENGLISH, Buttons buttons = Buttons.OK, Type type = Type.NOTHING, string[] listItems = null, bool showInTaskBar = false, Font controlTypeface = null, Font messageTypeface = null, string okText = "&Ok", string yesText = "&Yes", string noText = "N&o", string cancelText = "&Cancel", string hintText = "", FormStartPosition startPosition = FormStartPosition.WindowsDefaultLocation, TextAlignment textAlignment = TextAlignment.LEFT, Point iconLocation = new Point()) => InternalShow(message, title, icon, image, language, buttons, type, listItems, showInTaskBar, controlTypeface, messageTypeface, okText, yesText, noText, cancelText, hintText, startPosition, textAlignment, iconLocation);
        #endregion
    }
}