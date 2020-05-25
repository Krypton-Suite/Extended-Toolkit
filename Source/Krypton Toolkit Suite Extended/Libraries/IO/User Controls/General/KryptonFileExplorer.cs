using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.IO
{
    public class KryptonFileExplorer : UserControl
    {
        #region Designer Code
        private Panel panel1;
        private Panel panel5;
        private Panel panel4;
        private Panel panel2;
        private Panel panel3;
        private KryptonBreadCrumb kbcPath;
        private Panel panel7;
        private Panel panel6;
        private Panel panel12;
        private Panel panel11;
        private Panel panel8;
        private Panel panel9;
        private Panel panel10;
        private KryptonTreeView ktvFileSystem;
        private ListView lvContents;
        private KryptonButton kryptonButton1;
        private KryptonButton kryptonButton2;
        private KryptonComboBox kcmbChosenItem;
        private KryptonLabel klblAction;
        private KryptonButton kbtnAction;
        private Base.KryptonSplitButton ksbtnAction;
        private KryptonButton kbtnCancel;
        private KryptonSplitContainer kryptonSplitContainer1;

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.kryptonSplitContainer1 = new Krypton.Toolkit.KryptonSplitContainer();
            this.ktvFileSystem = new Krypton.Toolkit.KryptonTreeView();
            this.kbcPath = new Krypton.Toolkit.KryptonBreadCrumb();
            this.lvContents = new System.Windows.Forms.ListView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton2 = new Krypton.Toolkit.KryptonButton();
            this.kcmbChosenItem = new Krypton.Toolkit.KryptonComboBox();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.ksbtnAction = new Krypton.Toolkit.Extended.Base.KryptonSplitButton();
            this.kbtnAction = new Krypton.Toolkit.KryptonButton();
            this.klblAction = new Krypton.Toolkit.KryptonLabel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
            this.kryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
            this.kryptonSplitContainer1.Panel2.SuspendLayout();
            this.kryptonSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kbcPath)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbChosenItem)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(670, 23);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel12);
            this.panel2.Controls.Add(this.panel11);
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 367);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(670, 23);
            this.panel2.TabIndex = 1;
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
            // panel4
            // 
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(120, 23);
            this.panel4.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.kbcPath);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(120, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(550, 23);
            this.panel5.TabIndex = 1;
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
            this.kbcPath.Size = new System.Drawing.Size(550, 23);
            this.kbcPath.TabIndex = 0;
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
            // panel6
            // 
            this.panel6.Controls.Add(this.kryptonButton2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(60, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(60, 23);
            this.panel6.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.kryptonButton1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(60, 23);
            this.panel7.TabIndex = 1;
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
            this.panel9.Controls.Add(this.kbtnAction);
            this.panel9.Controls.Add(this.ksbtnAction);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(60, 23);
            this.panel9.TabIndex = 1;
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
            // panel11
            // 
            this.panel11.Controls.Add(this.klblAction);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(60, 23);
            this.panel11.TabIndex = 2;
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
            // kryptonButton1
            // 
            this.kryptonButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonButton1.Location = new System.Drawing.Point(0, 0);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(60, 23);
            this.kryptonButton1.TabIndex = 0;
            this.kryptonButton1.Values.Text = "kryptonButton1";
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonButton2.Location = new System.Drawing.Point(0, 0);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.Size = new System.Drawing.Size(60, 23);
            this.kryptonButton2.TabIndex = 0;
            this.kryptonButton2.Values.Text = "kryptonButton2";
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
            this.ksbtnAction.TabIndex = 0;
            this.ksbtnAction.Values.Text = "ACTION";
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
            // klblAction
            // 
            this.klblAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.klblAction.Location = new System.Drawing.Point(0, 0);
            this.klblAction.Name = "klblAction";
            this.klblAction.Size = new System.Drawing.Size(60, 23);
            this.klblAction.TabIndex = 0;
            this.klblAction.Values.Text = "kryptonLabel1";
            // 
            // KryptonFileExplorer
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "KryptonFileExplorer";
            this.Size = new System.Drawing.Size(670, 390);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
            this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
            this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
            this.kryptonSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kbcPath)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kcmbChosenItem)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private bool _showBackButton, _showForwardButton, _showBreadcrumbBar, _showSingularActionButton, _showSplitActionButton;
        #endregion

        #region Properties

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
        #endregion

        #region Overrides
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
        #endregion
    }
}