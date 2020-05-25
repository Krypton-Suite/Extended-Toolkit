using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.IO
{
    public class KryptonFileExplorer : UserControl
    {
        private Panel panel1;
        private Panel panel5;
        private Panel panel4;
        private Panel panel2;
        private Panel panel3;
        private KryptonBreadCrumb kryptonBreadCrumb1;
        private Panel panel7;
        private Panel panel6;
        private Panel panel12;
        private Panel panel11;
        private Panel panel8;
        private Panel panel9;
        private Panel panel10;
        private KryptonTreeView kryptonTreeView1;
        private ListView listView1;
        private KryptonButton kryptonButton1;
        private KryptonButton kryptonButton2;
        private KryptonComboBox kryptonComboBox1;
        private KryptonLabel kryptonLabel1;
        private KryptonButton kbtnAction;
        private Base.KryptonSplitButton kryptonSplitButton1;
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
            this.kryptonTreeView1 = new Krypton.Toolkit.KryptonTreeView();
            this.kryptonBreadCrumb1 = new Krypton.Toolkit.KryptonBreadCrumb();
            this.listView1 = new System.Windows.Forms.ListView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton2 = new Krypton.Toolkit.KryptonButton();
            this.kryptonComboBox1 = new Krypton.Toolkit.KryptonComboBox();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.kryptonSplitButton1 = new Krypton.Toolkit.Extended.Base.KryptonSplitButton();
            this.kbtnAction = new Krypton.Toolkit.KryptonButton();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
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
            ((System.ComponentModel.ISupportInitialize)(this.kryptonBreadCrumb1)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonComboBox1)).BeginInit();
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
            this.panel5.Controls.Add(this.kryptonBreadCrumb1);
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
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.kryptonTreeView1);
            // 
            // kryptonSplitContainer1.Panel2
            // 
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.listView1);
            this.kryptonSplitContainer1.Size = new System.Drawing.Size(670, 344);
            this.kryptonSplitContainer1.SplitterDistance = 223;
            this.kryptonSplitContainer1.TabIndex = 0;
            // 
            // kryptonTreeView1
            // 
            this.kryptonTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonTreeView1.Location = new System.Drawing.Point(0, 0);
            this.kryptonTreeView1.Name = "kryptonTreeView1";
            this.kryptonTreeView1.Size = new System.Drawing.Size(223, 344);
            this.kryptonTreeView1.TabIndex = 0;
            // 
            // kryptonBreadCrumb1
            // 
            this.kryptonBreadCrumb1.AutoSize = false;
            this.kryptonBreadCrumb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonBreadCrumb1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBreadCrumb1.Name = "kryptonBreadCrumb1";
            // 
            // 
            // 
            this.kryptonBreadCrumb1.RootItem.ShortText = "Root";
            this.kryptonBreadCrumb1.Size = new System.Drawing.Size(550, 23);
            this.kryptonBreadCrumb1.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(442, 344);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
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
            this.panel9.Controls.Add(this.kryptonSplitButton1);
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
            this.panel11.Controls.Add(this.kryptonLabel1);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(60, 23);
            this.panel11.TabIndex = 2;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.kryptonComboBox1);
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
            // kryptonComboBox1
            // 
            this.kryptonComboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.kryptonComboBox1.DropDownWidth = 490;
            this.kryptonComboBox1.IntegralHeight = false;
            this.kryptonComboBox1.Location = new System.Drawing.Point(0, 0);
            this.kryptonComboBox1.Name = "kryptonComboBox1";
            this.kryptonComboBox1.Size = new System.Drawing.Size(490, 21);
            this.kryptonComboBox1.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kryptonComboBox1.TabIndex = 0;
            this.kryptonComboBox1.Text = "kryptonComboBox1";
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
            // kryptonSplitButton1
            // 
            this.kryptonSplitButton1.AutoSize = true;
            this.kryptonSplitButton1.CornerRadius = -1;
            this.kryptonSplitButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonSplitButton1.Image = null;
            this.kryptonSplitButton1.Location = new System.Drawing.Point(0, 0);
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
            this.kryptonSplitButton1.Size = new System.Drawing.Size(60, 23);
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
            this.kryptonSplitButton1.TabIndex = 0;
            this.kryptonSplitButton1.Values.Text = "kryptonSplitButton1";
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
            // kryptonLabel1
            // 
            this.kryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(60, 23);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "kryptonLabel1";
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
            ((System.ComponentModel.ISupportInitialize)(this.kryptonBreadCrumb1)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonComboBox1)).EndInit();
            this.ResumeLayout(false);

        }
    }
}