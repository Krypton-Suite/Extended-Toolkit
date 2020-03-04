using Cyotek.Windows.Forms;
using Krypton.Toolkit.Extended.Base;
using Krypton.Toolkit.Extended.Colour.Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Dialogs
{
    [DefaultEvent("PreviewColorChanged"), DefaultProperty("Color")]
    public class ColourPickerDialog : KryptonForm
    {
        private Suite.Extended.Standard.Controls.KryptonButtonExtended kbeCancel;
        private Suite.Extended.Standard.Controls.KryptonButtonExtended kbeOk;
        private ColourEditorUserControl ceColour;
        private ColourWheelControl cwSelectedColour;
        private Suite.Extended.Standard.Controls.KryptonButtonExtended kbtneLoadColourPalette;
        private Suite.Extended.Standard.Controls.KryptonButtonExtended kryptonButtonExtended1;
        private CircularPictureBox cpbColourPreview;
        private ScreenColourPickerControl scpColours;
        private ColourEditorManager cem;
        private ColorGrid cgColourPalette;
        private KryptonPanel kpnlBack;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColourPickerDialog));
            this.kpnlBack = new Krypton.Toolkit.KryptonPanel();
            this.scpColours = new Krypton.Toolkit.Extended.Colour.Controls.ScreenColourPickerControl();
            this.ceColour = new Krypton.Toolkit.Extended.Colour.Controls.ColourEditorUserControl();
            this.cwSelectedColour = new Krypton.Toolkit.Extended.Colour.Controls.ColourWheelControl();
            this.cem = new Krypton.Toolkit.Extended.Colour.Controls.ColourEditorManager();
            this.kryptonButtonExtended1 = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonButtonExtended();
            this.kbeCancel = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonButtonExtended();
            this.kbeOk = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonButtonExtended();
            this.cgColourPalette = new Cyotek.Windows.Forms.ColorGrid();
            this.cpbColourPreview = new Krypton.Toolkit.Extended.Base.CircularPictureBox();
            this.kbtneLoadColourPalette = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonButtonExtended();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlBack)).BeginInit();
            this.kpnlBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbColourPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // kpnlBack
            // 
            this.kpnlBack.Controls.Add(this.cgColourPalette);
            this.kpnlBack.Controls.Add(this.cpbColourPreview);
            this.kpnlBack.Controls.Add(this.scpColours);
            this.kpnlBack.Controls.Add(this.kryptonButtonExtended1);
            this.kpnlBack.Controls.Add(this.kbtneLoadColourPalette);
            this.kpnlBack.Controls.Add(this.ceColour);
            this.kpnlBack.Controls.Add(this.cwSelectedColour);
            this.kpnlBack.Controls.Add(this.kbeCancel);
            this.kpnlBack.Controls.Add(this.kbeOk);
            this.kpnlBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpnlBack.Location = new System.Drawing.Point(0, 0);
            this.kpnlBack.Name = "kpnlBack";
            this.kpnlBack.Size = new System.Drawing.Size(647, 541);
            this.kpnlBack.TabIndex = 0;
            // 
            // scpColours
            // 
            this.scpColours.Colour = System.Drawing.Color.Empty;
            this.scpColours.Image = global::Krypton.Toolkit.Extended.Dialogs.Properties.Resources.eyedropper;
            this.scpColours.Location = new System.Drawing.Point(501, 144);
            this.scpColours.Name = "scpColours";
            this.scpColours.Size = new System.Drawing.Size(130, 131);
            // 
            // ceColour
            // 
            this.ceColour.BackColor = System.Drawing.Color.Transparent;
            this.ceColour.Location = new System.Drawing.Point(249, 12);
            this.ceColour.Name = "ceColour";
            this.ceColour.Size = new System.Drawing.Size(246, 321);
            this.ceColour.TabIndex = 1;
            // 
            // cwSelectedColour
            // 
            this.cwSelectedColour.BackColor = System.Drawing.Color.Transparent;
            this.cwSelectedColour.Location = new System.Drawing.Point(12, 12);
            this.cwSelectedColour.Name = "cwSelectedColour";
            this.cwSelectedColour.Size = new System.Drawing.Size(231, 212);
            this.cwSelectedColour.TabIndex = 1;
            // 
            // cem
            // 
            this.cem.Color = System.Drawing.Color.Empty;
            this.cem.ColourEditor = this.ceColour;
            this.cem.ColourWheel = this.cwSelectedColour;
            this.cem.ScreenColourPicker = this.scpColours;
            // 
            // kryptonButtonExtended1
            // 
            this.kryptonButtonExtended1.Image = null;
            this.kryptonButtonExtended1.Location = new System.Drawing.Point(42, 308);
            this.kryptonButtonExtended1.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended1.Name = "kryptonButtonExtended1";
            this.kryptonButtonExtended1.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended1.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended1.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended1.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended1.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended1.Size = new System.Drawing.Size(23, 23);
            this.kryptonButtonExtended1.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended1.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended1.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended1.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended1.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended1.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended1.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended1.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended1.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended1.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.TabIndex = 0;
            this.kryptonButtonExtended1.Values.Image = global::Krypton.Toolkit.Extended.Dialogs.Properties.Resources.palette_save;
            this.kryptonButtonExtended1.Values.Text = "";
            // 
            // kbeCancel
            // 
            this.kbeCancel.Image = null;
            this.kbeCancel.Location = new System.Drawing.Point(501, 64);
            this.kbeCancel.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbeCancel.Name = "kbeCancel";
            this.kbeCancel.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbeCancel.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbeCancel.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbeCancel.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbeCancel.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kbeCancel.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kbeCancel.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kbeCancel.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbeCancel.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kbeCancel.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbeCancel.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbeCancel.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbeCancel.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbeCancel.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbeCancel.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kbeCancel.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kbeCancel.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kbeCancel.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbeCancel.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kbeCancel.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbeCancel.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbeCancel.Size = new System.Drawing.Size(130, 38);
            this.kbeCancel.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbeCancel.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbeCancel.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbeCancel.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbeCancel.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kbeCancel.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kbeCancel.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kbeCancel.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbeCancel.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kbeCancel.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbeCancel.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbeCancel.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbeCancel.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbeCancel.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbeCancel.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kbeCancel.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kbeCancel.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kbeCancel.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbeCancel.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kbeCancel.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbeCancel.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbeCancel.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbeCancel.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbeCancel.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbeCancel.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kbeCancel.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kbeCancel.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kbeCancel.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbeCancel.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kbeCancel.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbeCancel.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbeCancel.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbeCancel.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbeCancel.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbeCancel.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kbeCancel.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kbeCancel.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kbeCancel.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbeCancel.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kbeCancel.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbeCancel.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbeCancel.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbeCancel.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbeCancel.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbeCancel.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kbeCancel.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kbeCancel.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kbeCancel.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbeCancel.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kbeCancel.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbeCancel.TabIndex = 2;
            this.kbeCancel.Values.Text = "Can&cel";
            // 
            // kbeOk
            // 
            this.kbeOk.Image = null;
            this.kbeOk.Location = new System.Drawing.Point(501, 20);
            this.kbeOk.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbeOk.Name = "kbeOk";
            this.kbeOk.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbeOk.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbeOk.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbeOk.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbeOk.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kbeOk.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kbeOk.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kbeOk.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbeOk.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kbeOk.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbeOk.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbeOk.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbeOk.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbeOk.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbeOk.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kbeOk.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kbeOk.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kbeOk.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbeOk.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kbeOk.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbeOk.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbeOk.Size = new System.Drawing.Size(130, 38);
            this.kbeOk.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbeOk.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbeOk.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbeOk.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbeOk.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kbeOk.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kbeOk.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kbeOk.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbeOk.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kbeOk.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbeOk.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbeOk.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbeOk.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbeOk.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbeOk.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kbeOk.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kbeOk.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kbeOk.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbeOk.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kbeOk.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbeOk.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbeOk.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbeOk.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbeOk.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbeOk.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kbeOk.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kbeOk.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kbeOk.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbeOk.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kbeOk.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbeOk.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbeOk.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbeOk.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbeOk.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbeOk.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kbeOk.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kbeOk.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kbeOk.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbeOk.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kbeOk.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbeOk.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbeOk.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbeOk.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbeOk.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbeOk.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kbeOk.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kbeOk.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kbeOk.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbeOk.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kbeOk.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbeOk.TabIndex = 1;
            this.kbeOk.Values.Text = "&Ok";
            // 
            // cgColourPalette
            // 
            this.cgColourPalette.BackColor = System.Drawing.Color.Transparent;
            this.cgColourPalette.Location = new System.Drawing.Point(12, 337);
            this.cgColourPalette.Name = "cgColourPalette";
            this.cgColourPalette.Size = new System.Drawing.Size(247, 180);
            this.cgColourPalette.TabIndex = 4;
            // 
            // cpbColourPreview
            // 
            this.cpbColourPreview.BackColor = System.Drawing.SystemColors.Control;
            this.cpbColourPreview.Location = new System.Drawing.Point(501, 397);
            this.cpbColourPreview.Name = "cpbColourPreview";
            this.cpbColourPreview.Size = new System.Drawing.Size(130, 120);
            this.cpbColourPreview.TabIndex = 3;
            this.cpbColourPreview.TabStop = false;
            this.cpbColourPreview.ToolTipValues = null;
            // 
            // kbtneLoadColourPalette
            // 
            this.kbtneLoadColourPalette.Image = global::Krypton.Toolkit.Extended.Dialogs.Properties.Resources.palette_load;
            this.kbtneLoadColourPalette.Location = new System.Drawing.Point(12, 308);
            this.kbtneLoadColourPalette.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneLoadColourPalette.Name = "kbtneLoadColourPalette";
            this.kbtneLoadColourPalette.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneLoadColourPalette.OverrideDefault.Content.LongText.Image = global::Krypton.Toolkit.Extended.Dialogs.Properties.Resources.palette_load;
            this.kbtneLoadColourPalette.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneLoadColourPalette.OverrideDefault.Content.ShortText.Image = global::Krypton.Toolkit.Extended.Dialogs.Properties.Resources.palette_load;
            this.kbtneLoadColourPalette.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneLoadColourPalette.OverrideFocus.Content.LongText.Image = global::Krypton.Toolkit.Extended.Dialogs.Properties.Resources.palette_load;
            this.kbtneLoadColourPalette.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneLoadColourPalette.OverrideFocus.Content.ShortText.Image = global::Krypton.Toolkit.Extended.Dialogs.Properties.Resources.palette_load;
            this.kbtneLoadColourPalette.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneLoadColourPalette.Size = new System.Drawing.Size(23, 23);
            this.kbtneLoadColourPalette.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneLoadColourPalette.StateCommon.Content.LongText.Image = global::Krypton.Toolkit.Extended.Dialogs.Properties.Resources.palette_load;
            this.kbtneLoadColourPalette.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneLoadColourPalette.StateCommon.Content.ShortText.Image = global::Krypton.Toolkit.Extended.Dialogs.Properties.Resources.palette_load;
            this.kbtneLoadColourPalette.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneLoadColourPalette.StateDisabled.Content.LongText.Image = global::Krypton.Toolkit.Extended.Dialogs.Properties.Resources.palette_load;
            this.kbtneLoadColourPalette.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneLoadColourPalette.StateDisabled.Content.ShortText.Image = global::Krypton.Toolkit.Extended.Dialogs.Properties.Resources.palette_load;
            this.kbtneLoadColourPalette.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneLoadColourPalette.StateNormal.Content.LongText.Image = global::Krypton.Toolkit.Extended.Dialogs.Properties.Resources.palette_load;
            this.kbtneLoadColourPalette.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneLoadColourPalette.StateNormal.Content.ShortText.Image = global::Krypton.Toolkit.Extended.Dialogs.Properties.Resources.palette_load;
            this.kbtneLoadColourPalette.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneLoadColourPalette.StatePressed.Content.LongText.Image = global::Krypton.Toolkit.Extended.Dialogs.Properties.Resources.palette_load;
            this.kbtneLoadColourPalette.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneLoadColourPalette.StatePressed.Content.ShortText.Image = global::Krypton.Toolkit.Extended.Dialogs.Properties.Resources.palette_load;
            this.kbtneLoadColourPalette.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneLoadColourPalette.StateTracking.Content.LongText.Image = global::Krypton.Toolkit.Extended.Dialogs.Properties.Resources.palette_load;
            this.kbtneLoadColourPalette.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneLoadColourPalette.StateTracking.Content.ShortText.Image = global::Krypton.Toolkit.Extended.Dialogs.Properties.Resources.palette_load;
            this.kbtneLoadColourPalette.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneLoadColourPalette.TabIndex = 1;
            this.kbtneLoadColourPalette.ToolTipValues.Description = "Load a custom palette.";
            this.kbtneLoadColourPalette.ToolTipValues.Heading = "Custom Palette";
            this.kbtneLoadColourPalette.ToolTipValues.Image = global::Krypton.Toolkit.Extended.Dialogs.Properties.Resources.palette_load;
            this.kbtneLoadColourPalette.Values.Image = global::Krypton.Toolkit.Extended.Dialogs.Properties.Resources.palette_load;
            this.kbtneLoadColourPalette.Values.Text = "";
            // 
            // ColourPickerDialog
            // 
            this.ClientSize = new System.Drawing.Size(647, 541);
            this.Controls.Add(this.kpnlBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColourPickerDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Colour Dialog";
            ((System.ComponentModel.ISupportInitialize)(this.kpnlBack)).EndInit();
            this.kpnlBack.ResumeLayout(false);
            this.kpnlBack.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbColourPreview)).EndInit();
            this.ResumeLayout(false);

        }
    }
}