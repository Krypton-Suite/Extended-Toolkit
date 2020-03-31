namespace Krypton.Toolkit.Extended.IO
{
    public class ReplaceWindow : KryptonForm
    {
        private KryptonTextBox kryptonTextBox1;
        private KryptonLabel kryptonLabel2;
        private KryptonCheckBox kcbRegex;
        private KryptonCheckBox kcbMatchWholeWord;
        private KryptonCheckBox kcbMatchCase;
        private KryptonTextBox ktxtFind;
        private KryptonLabel kryptonLabel1;
        private Suite.Extended.Standard.Controls.KryptonButtonExtended kryptonButtonExtended2;
        private Suite.Extended.Standard.Controls.KryptonButtonExtended kryptonButtonExtended1;
        private Suite.Extended.Standard.Controls.KryptonButtonExtended kbtnFindNext;
        private Dialogs.KryptonCancelDialogButton kbtnCancel;
        private KryptonPanel kryptonPanel1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kcbRegex = new Krypton.Toolkit.KryptonCheckBox();
            this.kcbMatchWholeWord = new Krypton.Toolkit.KryptonCheckBox();
            this.kcbMatchCase = new Krypton.Toolkit.KryptonCheckBox();
            this.ktxtFind = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonTextBox1 = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kbtnFindNext = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonButtonExtended();
            this.kbtnCancel = new Krypton.Toolkit.Extended.Dialogs.KryptonCancelDialogButton();
            this.kryptonButtonExtended1 = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonButtonExtended();
            this.kryptonButtonExtended2 = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonButtonExtended();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonButtonExtended2);
            this.kryptonPanel1.Controls.Add(this.kryptonButtonExtended1);
            this.kryptonPanel1.Controls.Add(this.kbtnFindNext);
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Controls.Add(this.kryptonTextBox1);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel1.Controls.Add(this.kcbRegex);
            this.kryptonPanel1.Controls.Add(this.kcbMatchWholeWord);
            this.kryptonPanel1.Controls.Add(this.kcbMatchCase);
            this.kryptonPanel1.Controls.Add(this.ktxtFind);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(390, 191);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kcbRegex
            // 
            this.kcbRegex.Location = new System.Drawing.Point(303, 38);
            this.kcbRegex.Name = "kcbRegex";
            this.kcbRegex.Size = new System.Drawing.Size(57, 20);
            this.kcbRegex.TabIndex = 9;
            this.kcbRegex.Values.Text = "&Regex";
            // 
            // kcbMatchWholeWord
            // 
            this.kcbMatchWholeWord.Location = new System.Drawing.Point(167, 38);
            this.kcbMatchWholeWord.Name = "kcbMatchWholeWord";
            this.kcbMatchWholeWord.Size = new System.Drawing.Size(130, 20);
            this.kcbMatchWholeWord.TabIndex = 8;
            this.kcbMatchWholeWord.Values.Text = "Match &Whole Word";
            // 
            // kcbMatchCase
            // 
            this.kcbMatchCase.Location = new System.Drawing.Point(74, 38);
            this.kcbMatchCase.Name = "kcbMatchCase";
            this.kcbMatchCase.Size = new System.Drawing.Size(87, 20);
            this.kcbMatchCase.TabIndex = 7;
            this.kcbMatchCase.Values.Text = "Match &Case";
            // 
            // ktxtFind
            // 
            this.ktxtFind.Hint = "Find...";
            this.ktxtFind.Location = new System.Drawing.Point(74, 9);
            this.ktxtFind.Name = "ktxtFind";
            this.ktxtFind.Size = new System.Drawing.Size(304, 23);
            this.ktxtFind.TabIndex = 5;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(32, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(36, 20);
            this.kryptonLabel1.TabIndex = 6;
            this.kryptonLabel1.Values.Text = "Find:";
            // 
            // kryptonTextBox1
            // 
            this.kryptonTextBox1.Hint = "Find...";
            this.kryptonTextBox1.Location = new System.Drawing.Point(74, 82);
            this.kryptonTextBox1.Name = "kryptonTextBox1";
            this.kryptonTextBox1.Size = new System.Drawing.Size(304, 23);
            this.kryptonTextBox1.TabIndex = 10;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(12, 85);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(56, 20);
            this.kryptonLabel2.TabIndex = 11;
            this.kryptonLabel2.Values.Text = "Replace:";
            // 
            // kbtnFindNext
            // 
            this.kbtnFindNext.Image = null;
            this.kbtnFindNext.Location = new System.Drawing.Point(96, 124);
            this.kbtnFindNext.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnFindNext.Name = "kbtnFindNext";
            this.kbtnFindNext.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnFindNext.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnFindNext.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnFindNext.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnFindNext.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnFindNext.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnFindNext.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnFindNext.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnFindNext.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnFindNext.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnFindNext.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnFindNext.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnFindNext.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnFindNext.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnFindNext.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnFindNext.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnFindNext.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnFindNext.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnFindNext.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnFindNext.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnFindNext.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnFindNext.Size = new System.Drawing.Size(90, 25);
            this.kbtnFindNext.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnFindNext.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnFindNext.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnFindNext.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnFindNext.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnFindNext.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnFindNext.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnFindNext.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnFindNext.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnFindNext.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnFindNext.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnFindNext.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnFindNext.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnFindNext.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnFindNext.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnFindNext.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnFindNext.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnFindNext.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnFindNext.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnFindNext.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnFindNext.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnFindNext.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnFindNext.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnFindNext.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnFindNext.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnFindNext.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnFindNext.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnFindNext.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnFindNext.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnFindNext.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnFindNext.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnFindNext.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnFindNext.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnFindNext.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnFindNext.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnFindNext.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnFindNext.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnFindNext.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnFindNext.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnFindNext.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnFindNext.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnFindNext.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnFindNext.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnFindNext.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnFindNext.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnFindNext.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnFindNext.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnFindNext.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnFindNext.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnFindNext.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnFindNext.TabIndex = 12;
            this.kbtnFindNext.Values.Text = "&Find Next";
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Image = null;
            this.kbtnCancel.Location = new System.Drawing.Point(288, 155);
            this.kbtnCancel.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.TabIndex = 13;
            this.kbtnCancel.Values.Text = "C&ancel";
            // 
            // kryptonButtonExtended1
            // 
            this.kryptonButtonExtended1.Image = null;
            this.kryptonButtonExtended1.Location = new System.Drawing.Point(192, 124);
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
            this.kryptonButtonExtended1.Size = new System.Drawing.Size(90, 25);
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
            this.kryptonButtonExtended1.TabIndex = 14;
            this.kryptonButtonExtended1.Values.Text = "&Find Next";
            // 
            // kryptonButtonExtended2
            // 
            this.kryptonButtonExtended2.Image = null;
            this.kryptonButtonExtended2.Location = new System.Drawing.Point(288, 124);
            this.kryptonButtonExtended2.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended2.Name = "kryptonButtonExtended2";
            this.kryptonButtonExtended2.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended2.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended2.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended2.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended2.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended2.Size = new System.Drawing.Size(90, 25);
            this.kryptonButtonExtended2.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended2.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended2.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended2.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended2.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended2.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended2.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended2.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended2.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended2.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended2.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.TabIndex = 15;
            this.kryptonButtonExtended2.Values.Text = "&Find Next";
            // 
            // ReplaceWindow
            // 
            this.ClientSize = new System.Drawing.Size(390, 191);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "ReplaceWindow";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}