using Krypton.Toolkit.Extended.Base;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.IO
{
    public class FindWindow : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private Suite.Extended.Standard.Controls.KryptonButtonExtended kbtnFindNext;
        private Dialogs.KryptonCancelDialogButton kbtnCancel;
        private KryptonCheckBox kcbRegex;
        private KryptonCheckBox kcbMatchWholeWord;
        private KryptonCheckBox kcbMatchCase;
        private KryptonTextBox ktxtFind;
        private KryptonLabel kryptonLabel1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnFindNext = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonButtonExtended();
            this.kbtnCancel = new Krypton.Toolkit.Extended.Dialogs.KryptonCancelDialogButton();
            this.kcbRegex = new Krypton.Toolkit.KryptonCheckBox();
            this.kcbMatchWholeWord = new Krypton.Toolkit.KryptonCheckBox();
            this.kcbMatchCase = new Krypton.Toolkit.KryptonCheckBox();
            this.ktxtFind = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnFindNext);
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Controls.Add(this.kcbRegex);
            this.kryptonPanel1.Controls.Add(this.kcbMatchWholeWord);
            this.kryptonPanel1.Controls.Add(this.kcbMatchCase);
            this.kryptonPanel1.Controls.Add(this.ktxtFind);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(356, 98);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnFindNext
            // 
            this.kbtnFindNext.Image = null;
            this.kbtnFindNext.Location = new System.Drawing.Point(158, 64);
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
            this.kbtnFindNext.TabIndex = 1;
            this.kbtnFindNext.Values.Text = "&Find Next";
            this.kbtnFindNext.Click += new System.EventHandler(this.kbtnFindNext_Click);
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Image = null;
            this.kbtnCancel.Location = new System.Drawing.Point(254, 64);
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
            this.kbtnCancel.TabIndex = 1;
            this.kbtnCancel.Values.Text = "C&ancel";
            this.kbtnCancel.Click += new System.EventHandler(this.kbtnCancel_Click);
            // 
            // kcbRegex
            // 
            this.kcbRegex.Location = new System.Drawing.Point(283, 38);
            this.kcbRegex.Name = "kcbRegex";
            this.kcbRegex.Size = new System.Drawing.Size(57, 20);
            this.kcbRegex.TabIndex = 4;
            this.kcbRegex.Values.Text = "&Regex";
            // 
            // kcbMatchWholeWord
            // 
            this.kcbMatchWholeWord.Location = new System.Drawing.Point(147, 38);
            this.kcbMatchWholeWord.Name = "kcbMatchWholeWord";
            this.kcbMatchWholeWord.Size = new System.Drawing.Size(130, 20);
            this.kcbMatchWholeWord.TabIndex = 3;
            this.kcbMatchWholeWord.Values.Text = "Match &Whole Word";
            // 
            // kcbMatchCase
            // 
            this.kcbMatchCase.Location = new System.Drawing.Point(54, 38);
            this.kcbMatchCase.Name = "kcbMatchCase";
            this.kcbMatchCase.Size = new System.Drawing.Size(87, 20);
            this.kcbMatchCase.TabIndex = 2;
            this.kcbMatchCase.Values.Text = "Match &Case";
            this.kcbMatchCase.CheckedChanged += new System.EventHandler(this.kcbMatchCase_CheckedChanged);
            // 
            // ktxtFind
            // 
            this.ktxtFind.Hint = "Find...";
            this.ktxtFind.Location = new System.Drawing.Point(54, 9);
            this.ktxtFind.Name = "ktxtFind";
            this.ktxtFind.Size = new System.Drawing.Size(290, 23);
            this.ktxtFind.TabIndex = 1;
            this.ktxtFind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ktxtFind_KeyPress);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(36, 20);
            this.kryptonLabel1.TabIndex = 1;
            this.kryptonLabel1.Values.Text = "Find:";
            // 
            // FindWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 98);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FindWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Find";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FindWindow_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private bool _firstSearch = true;

        private Place _startPlace;

        private FastColouredTextBox _textBox;
        #endregion

        #region Constructor
        public FindWindow(FastColouredTextBox textBox)
        {
            InitializeComponent();

            _textBox = textBox;
        }
        #endregion

        #region Methods
        public virtual void FindNext(string pattern)
        {
            try
            {
                RegexOptions opt = kcbMatchCase.Checked ? RegexOptions.None : RegexOptions.IgnoreCase;
                if (!kcbRegex.Checked)
                    pattern = Regex.Escape(pattern);
                if (kcbMatchWholeWord.Checked)
                    pattern = "\\b" + pattern + "\\b";
                //
                Range range = tb.Selection.Clone();
                range.Normalize();
                //
                if (_firstSearch)
                {
                    _startPlace = range.Start;
                    _firstSearch = false;
                }
                //
                range.Start = range.End;
                if (range.Start >= startPlace)
                    range.End = new Place(tb.GetLineLength(tb.LinesCount - 1), tb.LinesCount - 1);
                else
                    range.End = startPlace;
                //
                foreach (var r in range.GetRangesByLines(pattern, opt))
                {
                    tb.Selection = r;
                    tb.DoSelectionVisible();
                    tb.Invalidate();
                    return;
                }
                //
                if (range.Start >= startPlace && startPlace > Place.Empty)
                {
                    tb.Selection.Start = new Place(0, 0);
                    FindNext(pattern);
                    return;
                }
                KryptonMessageBoxExtended.Show("Not found");
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        private void kbtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void kbtnFindNext_Click(object sender, EventArgs e)
        {
            FindNext(ktxtFind.Text);
        }

        private void ktxtFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                kbtnFindNext.PerformClick();
                e.Handled = true;
                return;
            }
            if (e.KeyChar == '\x1b')
            {
                Hide();
                e.Handled = true;
                return;
            }
        }

        private void FindWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
            _textBox.Focus();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override void OnActivated(EventArgs e)
        {
            ktxtFind.Focus();
            ResetSerach();
        }

        private void ResetSerach() => _firstSearch = true;

        private void kcbMatchCase_CheckedChanged(object sender, EventArgs e) => ResetSerach();
    }
}