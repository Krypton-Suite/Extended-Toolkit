using Krypton.Toolkit.Suite.Extended.Base;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.IO
{
    public class KryptonFileExplorer : UserControl
    {
        #region Designer Code
        private Panel pnlTop;
        private Panel pnlPath;
        private Panel pnlNavigationButtons;
        private Panel panel2;
        private Panel panel3;
        private KryptonBreadCrumb kbcPath;
        private Panel pnlBackButton;
        private Panel pnlForwardButton;
        private Panel panel12;
        private Panel pnlAction;
        private Panel panel8;
        private Panel panel9;
        private Panel panel10;
        private KryptonTreeView ktvFileSystem;
        private ListView lvContents;
        private KryptonButton kbtnBack;
        private KryptonButton kbtnForward;
        private KryptonComboBox kcmbChosenItem;
        private KryptonLabel klblAction;
        private KryptonButton kbtnAction;
        private KryptonButton kbtnCancel;
        private Panel pnlUp;
        private KryptonButton kbtnUp;
        private KryptonSplitButton ksbtnAction;
        private KryptonSplitContainer kryptonSplitContainer1;

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlPath = new System.Windows.Forms.Panel();
            this.kbcPath = new Krypton.Toolkit.KryptonBreadCrumb();
            this.pnlNavigationButtons = new System.Windows.Forms.Panel();
            this.pnlBackButton = new System.Windows.Forms.Panel();
            this.kbtnBack = new Krypton.Toolkit.KryptonButton();
            this.pnlForwardButton = new System.Windows.Forms.Panel();
            this.kbtnForward = new Krypton.Toolkit.KryptonButton();
            this.pnlUp = new System.Windows.Forms.Panel();
            this.kbtnUp = new Krypton.Toolkit.KryptonButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.kcmbChosenItem = new Krypton.Toolkit.KryptonComboBox();
            this.pnlAction = new System.Windows.Forms.Panel();
            this.klblAction = new Krypton.Toolkit.KryptonLabel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.kbtnAction = new Krypton.Toolkit.KryptonButton();
            this.panel10 = new System.Windows.Forms.Panel();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.kryptonSplitContainer1 = new Krypton.Toolkit.KryptonSplitContainer();
            this.ktvFileSystem = new Krypton.Toolkit.KryptonTreeView();
            this.lvContents = new System.Windows.Forms.ListView();
            this.ksbtnAction = new Krypton.Toolkit.Suite.Extended.Base.KryptonSplitButton();
            this.pnlTop.SuspendLayout();
            this.pnlPath.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kbcPath)).BeginInit();
            this.pnlNavigationButtons.SuspendLayout();
            this.pnlBackButton.SuspendLayout();
            this.pnlForwardButton.SuspendLayout();
            this.pnlUp.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbChosenItem)).BeginInit();
            this.pnlAction.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
            this.kryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
            this.kryptonSplitContainer1.Panel2.SuspendLayout();
            this.kryptonSplitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.pnlPath);
            this.pnlTop.Controls.Add(this.pnlNavigationButtons);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(670, 23);
            this.pnlTop.TabIndex = 0;
            // 
            // pnlPath
            // 
            this.pnlPath.Controls.Add(this.kbcPath);
            this.pnlPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPath.Location = new System.Drawing.Point(220, 0);
            this.pnlPath.Name = "pnlPath";
            this.pnlPath.Size = new System.Drawing.Size(450, 23);
            this.pnlPath.TabIndex = 1;
            // 
            // kbcPath
            // 
            this.kbcPath.AutoSize = false;
            this.kbcPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kbcPath.Location = new System.Drawing.Point(0, 0);
            this.kbcPath.Name = "kbcPath";
            // 
            // 
            // 
            this.kbcPath.RootItem.ShortText = "Root";
            this.kbcPath.SelectedItem = this.kbcPath.RootItem;
            this.kbcPath.Size = new System.Drawing.Size(450, 23);
            this.kbcPath.TabIndex = 0;
            // 
            // pnlNavigationButtons
            // 
            this.pnlNavigationButtons.Controls.Add(this.pnlBackButton);
            this.pnlNavigationButtons.Controls.Add(this.pnlForwardButton);
            this.pnlNavigationButtons.Controls.Add(this.pnlUp);
            this.pnlNavigationButtons.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlNavigationButtons.Location = new System.Drawing.Point(0, 0);
            this.pnlNavigationButtons.Name = "pnlNavigationButtons";
            this.pnlNavigationButtons.Size = new System.Drawing.Size(220, 23);
            this.pnlNavigationButtons.TabIndex = 0;
            // 
            // pnlBackButton
            // 
            this.pnlBackButton.Controls.Add(this.kbtnBack);
            this.pnlBackButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBackButton.Location = new System.Drawing.Point(0, 0);
            this.pnlBackButton.Name = "pnlBackButton";
            this.pnlBackButton.Size = new System.Drawing.Size(74, 23);
            this.pnlBackButton.TabIndex = 1;
            // 
            // kbtnBack
            // 
            this.kbtnBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kbtnBack.Location = new System.Drawing.Point(0, 0);
            this.kbtnBack.Name = "kbtnBack";
            this.kbtnBack.Size = new System.Drawing.Size(74, 23);
            this.kbtnBack.TabIndex = 0;
            this.kbtnBack.Values.Text = "<<";
            // 
            // pnlForwardButton
            // 
            this.pnlForwardButton.Controls.Add(this.kbtnForward);
            this.pnlForwardButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlForwardButton.Location = new System.Drawing.Point(74, 0);
            this.pnlForwardButton.Name = "pnlForwardButton";
            this.pnlForwardButton.Size = new System.Drawing.Size(73, 23);
            this.pnlForwardButton.TabIndex = 0;
            // 
            // kbtnForward
            // 
            this.kbtnForward.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kbtnForward.Location = new System.Drawing.Point(0, 0);
            this.kbtnForward.Name = "kbtnForward";
            this.kbtnForward.Size = new System.Drawing.Size(73, 23);
            this.kbtnForward.TabIndex = 0;
            this.kbtnForward.Values.Text = ">>";
            // 
            // pnlUp
            // 
            this.pnlUp.Controls.Add(this.kbtnUp);
            this.pnlUp.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlUp.Location = new System.Drawing.Point(147, 0);
            this.pnlUp.Name = "pnlUp";
            this.pnlUp.Size = new System.Drawing.Size(73, 23);
            this.pnlUp.TabIndex = 2;
            // 
            // kbtnUp
            // 
            this.kbtnUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kbtnUp.Location = new System.Drawing.Point(0, 0);
            this.kbtnUp.Name = "kbtnUp";
            this.kbtnUp.Size = new System.Drawing.Size(73, 23);
            this.kbtnUp.TabIndex = 0;
            this.kbtnUp.Values.Text = "^";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel12);
            this.panel2.Controls.Add(this.pnlAction);
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 367);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(670, 23);
            this.panel2.TabIndex = 1;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.kcmbChosenItem);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(60, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(490, 23);
            this.panel12.TabIndex = 3;
            // 
            // kcmbChosenItem
            // 
            this.kcmbChosenItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kcmbChosenItem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.kcmbChosenItem.DropDownWidth = 490;
            this.kcmbChosenItem.IntegralHeight = false;
            this.kcmbChosenItem.Location = new System.Drawing.Point(0, 0);
            this.kcmbChosenItem.Name = "kcmbChosenItem";
            this.kcmbChosenItem.Size = new System.Drawing.Size(490, 21);
            this.kcmbChosenItem.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbChosenItem.TabIndex = 0;
            this.kcmbChosenItem.Text = "kryptonComboBox1";
            // 
            // pnlAction
            // 
            this.pnlAction.Controls.Add(this.klblAction);
            this.pnlAction.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlAction.Location = new System.Drawing.Point(0, 0);
            this.pnlAction.Name = "pnlAction";
            this.pnlAction.Size = new System.Drawing.Size(60, 23);
            this.pnlAction.TabIndex = 2;
            // 
            // klblAction
            // 
            this.klblAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.klblAction.Location = new System.Drawing.Point(0, 0);
            this.klblAction.Name = "klblAction";
            this.klblAction.Size = new System.Drawing.Size(60, 23);
            this.klblAction.TabIndex = 0;
            this.klblAction.Values.Text = "kryptonLabel1";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.panel9);
            this.panel8.Controls.Add(this.panel10);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(550, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(120, 23);
            this.panel8.TabIndex = 1;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.ksbtnAction);
            this.panel9.Controls.Add(this.kbtnAction);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(60, 23);
            this.panel9.TabIndex = 1;
            // 
            // kbtnAction
            // 
            this.kbtnAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kbtnAction.Location = new System.Drawing.Point(0, 0);
            this.kbtnAction.Name = "kbtnAction";
            this.kbtnAction.Size = new System.Drawing.Size(60, 23);
            this.kbtnAction.TabIndex = 1;
            this.kbtnAction.Values.Text = "ACTION";
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.kbtnCancel);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel10.Location = new System.Drawing.Point(60, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(60, 23);
            this.panel10.TabIndex = 0;
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kbtnCancel.Location = new System.Drawing.Point(0, 0);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(60, 23);
            this.kbtnCancel.TabIndex = 0;
            this.kbtnCancel.Values.Text = "&Cancel";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.kryptonSplitContainer1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 23);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(670, 344);
            this.panel3.TabIndex = 2;
            // 
            // kryptonSplitContainer1
            // 
            this.kryptonSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.kryptonSplitContainer1.Name = "kryptonSplitContainer1";
            // 
            // kryptonSplitContainer1.Panel1
            // 
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.ktvFileSystem);
            // 
            // kryptonSplitContainer1.Panel2
            // 
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.lvContents);
            this.kryptonSplitContainer1.Size = new System.Drawing.Size(670, 344);
            this.kryptonSplitContainer1.SplitterDistance = 223;
            this.kryptonSplitContainer1.TabIndex = 0;
            // 
            // ktvFileSystem
            // 
            this.ktvFileSystem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ktvFileSystem.Location = new System.Drawing.Point(0, 0);
            this.ktvFileSystem.Name = "ktvFileSystem";
            this.ktvFileSystem.Size = new System.Drawing.Size(223, 344);
            this.ktvFileSystem.TabIndex = 0;
            // 
            // lvContents
            // 
            this.lvContents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvContents.HideSelection = false;
            this.lvContents.Location = new System.Drawing.Point(0, 0);
            this.lvContents.Name = "lvContents";
            this.lvContents.Size = new System.Drawing.Size(442, 344);
            this.lvContents.TabIndex = 0;
            this.lvContents.UseCompatibleStateImageBehavior = false;
            // 
            // ksbtnAction
            // 
            this.ksbtnAction.AutoSize = true;
            this.ksbtnAction.CornerRadius = -1;
            this.ksbtnAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ksbtnAction.Image = null;
            this.ksbtnAction.Location = new System.Drawing.Point(0, 0);
            this.ksbtnAction.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ksbtnAction.Name = "ksbtnAction";
            this.ksbtnAction.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ksbtnAction.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ksbtnAction.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.ksbtnAction.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.ksbtnAction.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.ksbtnAction.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.ksbtnAction.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.ksbtnAction.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.ksbtnAction.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.ksbtnAction.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.ksbtnAction.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ksbtnAction.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ksbtnAction.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.ksbtnAction.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.ksbtnAction.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.ksbtnAction.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.ksbtnAction.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.ksbtnAction.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.ksbtnAction.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.ksbtnAction.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.ksbtnAction.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ksbtnAction.ShowSplitOption = true;
            this.ksbtnAction.Size = new System.Drawing.Size(60, 23);
            this.ksbtnAction.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ksbtnAction.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ksbtnAction.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.ksbtnAction.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.ksbtnAction.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.ksbtnAction.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.ksbtnAction.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.ksbtnAction.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.ksbtnAction.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.ksbtnAction.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.ksbtnAction.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ksbtnAction.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ksbtnAction.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.ksbtnAction.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.ksbtnAction.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.ksbtnAction.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.ksbtnAction.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.ksbtnAction.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.ksbtnAction.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.ksbtnAction.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.ksbtnAction.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ksbtnAction.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ksbtnAction.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.ksbtnAction.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.ksbtnAction.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.ksbtnAction.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.ksbtnAction.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.ksbtnAction.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.ksbtnAction.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.ksbtnAction.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.ksbtnAction.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ksbtnAction.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ksbtnAction.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.ksbtnAction.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.ksbtnAction.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.ksbtnAction.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.ksbtnAction.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.ksbtnAction.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.ksbtnAction.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.ksbtnAction.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.ksbtnAction.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ksbtnAction.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ksbtnAction.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.ksbtnAction.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.ksbtnAction.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.ksbtnAction.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.ksbtnAction.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.ksbtnAction.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.ksbtnAction.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.ksbtnAction.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.ksbtnAction.TabIndex = 2;
            this.ksbtnAction.Values.Text = "ACTION";
            // 
            // KryptonFileExplorer
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlTop);
            this.Name = "KryptonFileExplorer";
            this.Size = new System.Drawing.Size(670, 390);
            this.pnlTop.ResumeLayout(false);
            this.pnlPath.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kbcPath)).EndInit();
            this.pnlNavigationButtons.ResumeLayout(false);
            this.pnlBackButton.ResumeLayout(false);
            this.pnlForwardButton.ResumeLayout(false);
            this.pnlUp.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kcmbChosenItem)).EndInit();
            this.pnlAction.ResumeLayout(false);
            this.pnlAction.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
            this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
            this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
            this.kryptonSplitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private bool _showBackButton, _showForwardButton, _showUpButton, _showBreadcrumbBar, _showSingularActionButton, _showSplitActionButton, _showTopControls;
        #endregion

        #region Properties
        [DefaultValue(true)]
        public bool ShowBackButton { get => _showBackButton; set { _showBackButton = value; Invalidate(); } }

        [DefaultValue(true)]
        public bool ShowForwardButton { get => _showForwardButton; set { _showForwardButton = value; Invalidate(); } }

        [DefaultValue(true)]
        public bool ShowUpButton { get => _showUpButton; set { _showUpButton = value; Invalidate(); } }

        [DefaultValue(true)]
        public bool ShowBreadcrumbBar { get => _showBreadcrumbBar; set { _showBreadcrumbBar = value; Invalidate(); } }

        [DefaultValue(true)]
        public bool ShowTopControls { get => _showBreadcrumbBar; set { _showBreadcrumbBar = value; Invalidate(); } }

        [DefaultValue(true)]
        public bool ShowSingularActionButton { get => _showSingularActionButton; set { _showSingularActionButton = value; Invalidate(); } }

        [DefaultValue(true)]
        public bool ShowSplitActionButton { get => _showSplitActionButton; set { _showSplitActionButton = value; Invalidate(); } }

        [DefaultValue(true)]
        public bool ShowTopControlsUI { get => _showTopControls; set { _showTopControls = value; Invalidate(); } }
        #endregion

        #region Constructor
        public KryptonFileExplorer()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods
        private string TranslateListViewItemIntoPath(ListViewItem item) => Path.GetFullPath(item.Text);

        //private string TranslateListViewItemIntoPath(KryptonListViewItem item) => Path.GetFullPath(item.Text);

        public void UpdateSizing()
        {

        }

        private void UpdateButtonContainerWidth(Panel buttonContainer, Panel container)
        {
            if (_showUpButton)
            {
                buttonContainer.Width = container.Width / 3;
            }
            else if (_showBackButton && _showForwardButton)
            {
                buttonContainer.Width = container.Width / 2;
            }
        }
        #endregion

        #region Overrides
        protected override void OnResize(EventArgs e)
        {
            UpdateSizing();

            base.OnResize(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
        #endregion
    }
}