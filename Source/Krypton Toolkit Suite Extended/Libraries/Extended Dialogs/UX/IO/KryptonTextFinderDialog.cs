namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    /// <summary>Allows you to find &amp; highlight selected text within a specified <seealso cref="KryptonRichTextBox" />.</summary>
    public class KryptonTextFinderDialog : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private System.Windows.Forms.Panel panel1;
        private KryptonButton kryptonButton1;
        private KryptonPanel kryptonPanel2;
        private KryptonButton kryptonButton2;
        private KryptonColorButton kryptonColorButton1;
        private KryptonLabel kryptonLabel1;
        private KryptonTextBox kryptonTextBox1;
        private Base.KryptonSplitButton kryptonSplitButton1;
        private KryptonButton kbtnCancel;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonTextBox1 = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonColorButton1 = new Krypton.Toolkit.KryptonColorButton();
            this.kryptonButton2 = new Krypton.Toolkit.KryptonButton();
            this.kryptonSplitButton1 = new Krypton.Toolkit.Suite.Extended.Base.KryptonSplitButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonButton1);
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 146);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(504, 45);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(544, 8);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.TabIndex = 0;
            this.kbtnCancel.Values.Text = "C&ancel";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 143);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(504, 3);
            this.panel1.TabIndex = 2;
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kryptonButton1.Location = new System.Drawing.Point(207, 10);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(90, 25);
            this.kryptonButton1.TabIndex = 1;
            this.kryptonButton1.Values.Text = "C&ancel";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kryptonSplitButton1);
            this.kryptonPanel2.Controls.Add(this.kryptonButton2);
            this.kryptonPanel2.Controls.Add(this.kryptonColorButton1);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel2.Controls.Add(this.kryptonTextBox1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(504, 143);
            this.kryptonPanel2.TabIndex = 3;
            // 
            // kryptonTextBox1
            // 
            this.kryptonTextBox1.Location = new System.Drawing.Point(55, 24);
            this.kryptonTextBox1.Name = "kryptonTextBox1";
            this.kryptonTextBox1.Size = new System.Drawing.Size(437, 23);
            this.kryptonTextBox1.TabIndex = 0;
            this.kryptonTextBox1.Text = "kryptonTextBox1";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(13, 24);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(36, 20);
            this.kryptonLabel1.TabIndex = 1;
            this.kryptonLabel1.Values.Text = "Find:";
            // 
            // kryptonColorButton1
            // 
            this.kryptonColorButton1.Location = new System.Drawing.Point(13, 105);
            this.kryptonColorButton1.Name = "kryptonColorButton1";
            this.kryptonColorButton1.Size = new System.Drawing.Size(196, 25);
            this.kryptonColorButton1.TabIndex = 2;
            this.kryptonColorButton1.Values.Text = "Select a &Highlight Colour";
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.Location = new System.Drawing.Point(215, 105);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.Size = new System.Drawing.Size(138, 25);
            this.kryptonButton2.TabIndex = 3;
            this.kryptonButton2.Values.Text = "Count &Occurrences";
            // 
            // kryptonSplitButton1
            // 
            this.kryptonSplitButton1.AutoSize = true;
            this.kryptonSplitButton1.CornerRadius = -1;
            this.kryptonSplitButton1.Image = null;
            this.kryptonSplitButton1.Location = new System.Drawing.Point(360, 105);
            this.kryptonSplitButton1.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonSplitButton1.Name = "kryptonSplitButton1";
            this.kryptonSplitButton1.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonSplitButton1.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonSplitButton1.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonSplitButton1.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonSplitButton1.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonSplitButton1.ShowSplitOption = true;
            this.kryptonSplitButton1.Size = new System.Drawing.Size(131, 25);
            this.kryptonSplitButton1.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonSplitButton1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonSplitButton1.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonSplitButton1.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonSplitButton1.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonSplitButton1.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonSplitButton1.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonSplitButton1.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonSplitButton1.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonSplitButton1.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonSplitButton1.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonSplitButton1.TabIndex = 4;
            this.kryptonSplitButton1.Values.Text = "&Find....";
            // 
            // KryptonTextFinderDialog
            // 
            this.ClientSize = new System.Drawing.Size(504, 191);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "KryptonTextFinderDialog";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private KryptonRichTextBox _target;
        #endregion

        #region Properties
        public KryptonRichTextBox Target { get => _target; set => _target = value; }
        #endregion
    }
}