#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    public class SettingsWindow : KryptonForm
    {
        #region Design Mode
        private KryptonPanel kryptonPanel1;
        private KryptonPanel kryptonPanel2;
        private KryptonButton kbtnApply;
        private KryptonButton kbtnCancel;
        private KryptonGroupBox kryptonGroupBox1;
        private KryptonCheckBox kchkVerticalAxisDateAndTimeFormat;
        private KryptonCheckBox kchkVerticalAxisShowMinorTicks;
        private KryptonButton kbtnVerticalAxisFitData;
        private KryptonTextBox ktxtVerticalAxisLowerLimit;
        private KryptonLabel kryptonLabel3;
        private KryptonTextBox ktxtVerticalAxisUpperLimit;
        private KryptonLabel kryptonLabel2;
        private KryptonTextBox ktxtVerticalAxisLabelText;
        private KryptonLabel kryptonLabel1;
        private KryptonGroupBox kryptonGroupBox2;
        private KryptonCheckBox kchkHorizontalAxisDateAndTimeFormat;
        private KryptonCheckBox kchkHorizontalAxisShowMinorTicks;
        private KryptonButton kbtnHorizontalAxisFitData;
        private KryptonTextBox ktxtHorizontalAxisLowerLimit;
        private KryptonLabel kryptonLabel4;
        private KryptonTextBox ktxtHorizontalAxisUpperLimit;
        private KryptonLabel kryptonLabel5;
        private KryptonTextBox ktxtHorizontalAxisLabelText;
        private KryptonLabel kryptonLabel6;
        private KryptonGroupBox kryptonGroupBox7;
        private KryptonGroupBox kryptonGroupBox9;
        private KryptonGroupBox kryptonGroupBox8;
        private KryptonGroupBox kryptonGroupBox6;
        private KryptonGroupBox kryptonGroupBox5;
        private KryptonGroupBox kryptonGroupBox4;
        private KryptonGroupBox kryptonGroupBox3;
        private KryptonCheckBox kchkImageQualityLowWhileDragging;
        private KryptonRadioButton krbImageQualityHigh;
        private KryptonRadioButton krbImageQualityLow;
        private KryptonCheckBox kchkDisplayOnGraph;
        private KryptonComboBox kcmbColourStyle;
        private KryptonButton kbtnTightenLayout;
        private KryptonCheckBox kchkGrid;
        private KryptonCheckBox kchkMultiplier;
        private KryptonCheckBox kchkOffset;
        private KryptonListBox klbPlotObjects;
        private KryptonTextBox ktxtLabelText;
        private KryptonButton kbtnSaveCSV;
        private KryptonButton kbtnCopyCSV;
        private System.Windows.Forms.Panel panel1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.kbtnApply = new Krypton.Toolkit.KryptonButton();
            this.kryptonGroupBox1 = new Krypton.Toolkit.KryptonGroupBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.ktxtVerticalAxisLabelText = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.ktxtVerticalAxisUpperLimit = new Krypton.Toolkit.KryptonTextBox();
            this.ktxtVerticalAxisLowerLimit = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.kbtnVerticalAxisFitData = new Krypton.Toolkit.KryptonButton();
            this.kchkVerticalAxisShowMinorTicks = new Krypton.Toolkit.KryptonCheckBox();
            this.kchkVerticalAxisDateAndTimeFormat = new Krypton.Toolkit.KryptonCheckBox();
            this.kryptonGroupBox2 = new Krypton.Toolkit.KryptonGroupBox();
            this.kchkHorizontalAxisDateAndTimeFormat = new Krypton.Toolkit.KryptonCheckBox();
            this.kchkHorizontalAxisShowMinorTicks = new Krypton.Toolkit.KryptonCheckBox();
            this.kbtnHorizontalAxisFitData = new Krypton.Toolkit.KryptonButton();
            this.ktxtHorizontalAxisLowerLimit = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.ktxtHorizontalAxisUpperLimit = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            this.ktxtHorizontalAxisLabelText = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel6 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonGroupBox3 = new Krypton.Toolkit.KryptonGroupBox();
            this.kryptonGroupBox4 = new Krypton.Toolkit.KryptonGroupBox();
            this.kryptonGroupBox5 = new Krypton.Toolkit.KryptonGroupBox();
            this.kryptonGroupBox6 = new Krypton.Toolkit.KryptonGroupBox();
            this.kryptonGroupBox7 = new Krypton.Toolkit.KryptonGroupBox();
            this.kryptonGroupBox8 = new Krypton.Toolkit.KryptonGroupBox();
            this.kryptonGroupBox9 = new Krypton.Toolkit.KryptonGroupBox();
            this.krbImageQualityLow = new Krypton.Toolkit.KryptonRadioButton();
            this.krbImageQualityHigh = new Krypton.Toolkit.KryptonRadioButton();
            this.kchkImageQualityLowWhileDragging = new Krypton.Toolkit.KryptonCheckBox();
            this.kcmbColourStyle = new Krypton.Toolkit.KryptonComboBox();
            this.kchkDisplayOnGraph = new Krypton.Toolkit.KryptonCheckBox();
            this.kchkOffset = new Krypton.Toolkit.KryptonCheckBox();
            this.kchkMultiplier = new Krypton.Toolkit.KryptonCheckBox();
            this.kchkGrid = new Krypton.Toolkit.KryptonCheckBox();
            this.kbtnTightenLayout = new Krypton.Toolkit.KryptonButton();
            this.klbPlotObjects = new Krypton.Toolkit.KryptonListBox();
            this.ktxtLabelText = new Krypton.Toolkit.KryptonTextBox();
            this.kbtnCopyCSV = new Krypton.Toolkit.KryptonButton();
            this.kbtnSaveCSV = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).BeginInit();
            this.kryptonGroupBox2.Panel.SuspendLayout();
            this.kryptonGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox3.Panel)).BeginInit();
            this.kryptonGroupBox3.Panel.SuspendLayout();
            this.kryptonGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox4.Panel)).BeginInit();
            this.kryptonGroupBox4.Panel.SuspendLayout();
            this.kryptonGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox5.Panel)).BeginInit();
            this.kryptonGroupBox5.Panel.SuspendLayout();
            this.kryptonGroupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox6.Panel)).BeginInit();
            this.kryptonGroupBox6.Panel.SuspendLayout();
            this.kryptonGroupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox7.Panel)).BeginInit();
            this.kryptonGroupBox7.Panel.SuspendLayout();
            this.kryptonGroupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox8.Panel)).BeginInit();
            this.kryptonGroupBox8.Panel.SuspendLayout();
            this.kryptonGroupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox9.Panel)).BeginInit();
            this.kryptonGroupBox9.Panel.SuspendLayout();
            this.kryptonGroupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbColourStyle)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnApply);
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 466);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1000, 43);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kbtnTightenLayout);
            this.kryptonPanel2.Controls.Add(this.kryptonGroupBox7);
            this.kryptonPanel2.Controls.Add(this.kryptonGroupBox6);
            this.kryptonPanel2.Controls.Add(this.kryptonGroupBox5);
            this.kryptonPanel2.Controls.Add(this.kryptonGroupBox4);
            this.kryptonPanel2.Controls.Add(this.kryptonGroupBox3);
            this.kryptonPanel2.Controls.Add(this.kryptonGroupBox2);
            this.kryptonPanel2.Controls.Add(this.kryptonGroupBox1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(1000, 466);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 463);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 3);
            this.panel1.TabIndex = 2;
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(898, 6);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.TabIndex = 0;
            this.kbtnCancel.Values.Text = "C&ancel";
            this.kbtnCancel.Click += new System.EventHandler(this.kbtnCancel_Click);
            // 
            // kbtnApply
            // 
            this.kbtnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnApply.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnApply.Enabled = false;
            this.kbtnApply.Location = new System.Drawing.Point(802, 6);
            this.kbtnApply.Name = "kbtnApply";
            this.kbtnApply.Size = new System.Drawing.Size(90, 25);
            this.kbtnApply.TabIndex = 1;
            this.kbtnApply.Values.Text = "App&ly";
            this.kbtnApply.Click += new System.EventHandler(this.kbtnApply_Click);
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.kchkVerticalAxisDateAndTimeFormat);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kchkVerticalAxisShowMinorTicks);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kbtnVerticalAxisFitData);
            this.kryptonGroupBox1.Panel.Controls.Add(this.ktxtVerticalAxisLowerLimit);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel3);
            this.kryptonGroupBox1.Panel.Controls.Add(this.ktxtVerticalAxisUpperLimit);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel2);
            this.kryptonGroupBox1.Panel.Controls.Add(this.ktxtVerticalAxisLabelText);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel1);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(301, 218);
            this.kryptonGroupBox1.TabIndex = 0;
            this.kryptonGroupBox1.Values.Heading = "Vertical Axis";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(13, 15);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(42, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Label:";
            // 
            // ktxtVerticalAxisLabelText
            // 
            this.ktxtVerticalAxisLabelText.Hint = "Label text...";
            this.ktxtVerticalAxisLabelText.Location = new System.Drawing.Point(96, 15);
            this.ktxtVerticalAxisLabelText.Name = "ktxtVerticalAxisLabelText";
            this.ktxtVerticalAxisLabelText.Size = new System.Drawing.Size(190, 23);
            this.ktxtVerticalAxisLabelText.TabIndex = 1;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(13, 44);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(77, 20);
            this.kryptonLabel2.TabIndex = 2;
            this.kryptonLabel2.Values.Text = "Upper Limit:";
            // 
            // ktxtVerticalAxisUpperLimit
            // 
            this.ktxtVerticalAxisUpperLimit.Hint = "Upper limit...";
            this.ktxtVerticalAxisUpperLimit.Location = new System.Drawing.Point(96, 44);
            this.ktxtVerticalAxisUpperLimit.Name = "ktxtVerticalAxisUpperLimit";
            this.ktxtVerticalAxisUpperLimit.Size = new System.Drawing.Size(100, 23);
            this.ktxtVerticalAxisUpperLimit.TabIndex = 3;
            // 
            // ktxtVerticalAxisLowerLimit
            // 
            this.ktxtVerticalAxisLowerLimit.Hint = "Lower limit...";
            this.ktxtVerticalAxisLowerLimit.Location = new System.Drawing.Point(96, 73);
            this.ktxtVerticalAxisLowerLimit.Name = "ktxtVerticalAxisLowerLimit";
            this.ktxtVerticalAxisLowerLimit.Size = new System.Drawing.Size(100, 23);
            this.ktxtVerticalAxisLowerLimit.TabIndex = 5;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(13, 73);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(76, 20);
            this.kryptonLabel3.TabIndex = 4;
            this.kryptonLabel3.Values.Text = "Lower Limit:";
            // 
            // kbtnVerticalAxisFitData
            // 
            this.kbtnVerticalAxisFitData.Location = new System.Drawing.Point(96, 102);
            this.kbtnVerticalAxisFitData.Name = "kbtnVerticalAxisFitData";
            this.kbtnVerticalAxisFitData.Size = new System.Drawing.Size(100, 25);
            this.kbtnVerticalAxisFitData.TabIndex = 6;
            this.kbtnVerticalAxisFitData.Values.Text = "Fit &Data";
            this.kbtnVerticalAxisFitData.Click += new System.EventHandler(this.kbtnVerticalAxisFitData_Click);
            // 
            // kchkVerticalAxisShowMinorTicks
            // 
            this.kchkVerticalAxisShowMinorTicks.Location = new System.Drawing.Point(96, 134);
            this.kchkVerticalAxisShowMinorTicks.Name = "kchkVerticalAxisShowMinorTicks";
            this.kchkVerticalAxisShowMinorTicks.Size = new System.Drawing.Size(119, 20);
            this.kchkVerticalAxisShowMinorTicks.TabIndex = 7;
            this.kchkVerticalAxisShowMinorTicks.Values.Text = "&Show Minor Ticks";
            // 
            // kchkVerticalAxisDateAndTimeFormat
            // 
            this.kchkVerticalAxisDateAndTimeFormat.Location = new System.Drawing.Point(96, 160);
            this.kchkVerticalAxisDateAndTimeFormat.Name = "kchkVerticalAxisDateAndTimeFormat";
            this.kchkVerticalAxisDateAndTimeFormat.Size = new System.Drawing.Size(134, 20);
            this.kchkVerticalAxisDateAndTimeFormat.TabIndex = 8;
            this.kchkVerticalAxisDateAndTimeFormat.Values.Text = "Date && &Time Format";
            // 
            // kryptonGroupBox2
            // 
            this.kryptonGroupBox2.Location = new System.Drawing.Point(12, 236);
            this.kryptonGroupBox2.Name = "kryptonGroupBox2";
            // 
            // kryptonGroupBox2.Panel
            // 
            this.kryptonGroupBox2.Panel.Controls.Add(this.kchkHorizontalAxisDateAndTimeFormat);
            this.kryptonGroupBox2.Panel.Controls.Add(this.kchkHorizontalAxisShowMinorTicks);
            this.kryptonGroupBox2.Panel.Controls.Add(this.kbtnHorizontalAxisFitData);
            this.kryptonGroupBox2.Panel.Controls.Add(this.ktxtHorizontalAxisLowerLimit);
            this.kryptonGroupBox2.Panel.Controls.Add(this.kryptonLabel4);
            this.kryptonGroupBox2.Panel.Controls.Add(this.ktxtHorizontalAxisUpperLimit);
            this.kryptonGroupBox2.Panel.Controls.Add(this.kryptonLabel5);
            this.kryptonGroupBox2.Panel.Controls.Add(this.ktxtHorizontalAxisLabelText);
            this.kryptonGroupBox2.Panel.Controls.Add(this.kryptonLabel6);
            this.kryptonGroupBox2.Size = new System.Drawing.Size(301, 218);
            this.kryptonGroupBox2.TabIndex = 3;
            this.kryptonGroupBox2.Values.Heading = "Horizontal Axis";
            // 
            // kchkHorizontalAxisDateAndTimeFormat
            // 
            this.kchkHorizontalAxisDateAndTimeFormat.Location = new System.Drawing.Point(96, 160);
            this.kchkHorizontalAxisDateAndTimeFormat.Name = "kchkHorizontalAxisDateAndTimeFormat";
            this.kchkHorizontalAxisDateAndTimeFormat.Size = new System.Drawing.Size(134, 20);
            this.kchkHorizontalAxisDateAndTimeFormat.TabIndex = 8;
            this.kchkHorizontalAxisDateAndTimeFormat.Values.Text = "Date && &Time Format";
            // 
            // kchkHorizontalAxisShowMinorTicks
            // 
            this.kchkHorizontalAxisShowMinorTicks.Location = new System.Drawing.Point(96, 134);
            this.kchkHorizontalAxisShowMinorTicks.Name = "kchkHorizontalAxisShowMinorTicks";
            this.kchkHorizontalAxisShowMinorTicks.Size = new System.Drawing.Size(119, 20);
            this.kchkHorizontalAxisShowMinorTicks.TabIndex = 7;
            this.kchkHorizontalAxisShowMinorTicks.Values.Text = "&Show Minor Ticks";
            // 
            // kbtnHorizontalAxisFitData
            // 
            this.kbtnHorizontalAxisFitData.Location = new System.Drawing.Point(96, 102);
            this.kbtnHorizontalAxisFitData.Name = "kbtnHorizontalAxisFitData";
            this.kbtnHorizontalAxisFitData.Size = new System.Drawing.Size(100, 25);
            this.kbtnHorizontalAxisFitData.TabIndex = 6;
            this.kbtnHorizontalAxisFitData.Values.Text = "Fit &Data";
            this.kbtnHorizontalAxisFitData.Click += new System.EventHandler(this.kbtnHorizontalAxisFitData_Click);
            // 
            // ktxtHorizontalAxisLowerLimit
            // 
            this.ktxtHorizontalAxisLowerLimit.Hint = "Lower limit...";
            this.ktxtHorizontalAxisLowerLimit.Location = new System.Drawing.Point(96, 73);
            this.ktxtHorizontalAxisLowerLimit.Name = "ktxtHorizontalAxisLowerLimit";
            this.ktxtHorizontalAxisLowerLimit.Size = new System.Drawing.Size(100, 23);
            this.ktxtHorizontalAxisLowerLimit.TabIndex = 5;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(13, 73);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(76, 20);
            this.kryptonLabel4.TabIndex = 4;
            this.kryptonLabel4.Values.Text = "Lower Limit:";
            // 
            // ktxtHorizontalAxisUpperLimit
            // 
            this.ktxtHorizontalAxisUpperLimit.Hint = "Upper limit...";
            this.ktxtHorizontalAxisUpperLimit.Location = new System.Drawing.Point(96, 44);
            this.ktxtHorizontalAxisUpperLimit.Name = "ktxtHorizontalAxisUpperLimit";
            this.ktxtHorizontalAxisUpperLimit.Size = new System.Drawing.Size(100, 23);
            this.ktxtHorizontalAxisUpperLimit.TabIndex = 3;
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(13, 44);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(77, 20);
            this.kryptonLabel5.TabIndex = 2;
            this.kryptonLabel5.Values.Text = "Upper Limit:";
            // 
            // ktxtHorizontalAxisLabelText
            // 
            this.ktxtHorizontalAxisLabelText.Hint = "Label text...";
            this.ktxtHorizontalAxisLabelText.Location = new System.Drawing.Point(96, 15);
            this.ktxtHorizontalAxisLabelText.Name = "ktxtHorizontalAxisLabelText";
            this.ktxtHorizontalAxisLabelText.Size = new System.Drawing.Size(190, 23);
            this.ktxtHorizontalAxisLabelText.TabIndex = 1;
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(13, 15);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(42, 20);
            this.kryptonLabel6.TabIndex = 0;
            this.kryptonLabel6.Values.Text = "Label:";
            // 
            // kryptonGroupBox3
            // 
            this.kryptonGroupBox3.Location = new System.Drawing.Point(319, 12);
            this.kryptonGroupBox3.Name = "kryptonGroupBox3";
            // 
            // kryptonGroupBox3.Panel
            // 
            this.kryptonGroupBox3.Panel.Controls.Add(this.kchkImageQualityLowWhileDragging);
            this.kryptonGroupBox3.Panel.Controls.Add(this.krbImageQualityHigh);
            this.kryptonGroupBox3.Panel.Controls.Add(this.krbImageQualityLow);
            this.kryptonGroupBox3.Size = new System.Drawing.Size(355, 75);
            this.kryptonGroupBox3.TabIndex = 4;
            this.kryptonGroupBox3.Values.Heading = "Image Quality";
            // 
            // kryptonGroupBox4
            // 
            this.kryptonGroupBox4.Location = new System.Drawing.Point(319, 93);
            this.kryptonGroupBox4.Name = "kryptonGroupBox4";
            // 
            // kryptonGroupBox4.Panel
            // 
            this.kryptonGroupBox4.Panel.Controls.Add(this.kcmbColourStyle);
            this.kryptonGroupBox4.Size = new System.Drawing.Size(355, 75);
            this.kryptonGroupBox4.TabIndex = 5;
            this.kryptonGroupBox4.Values.Heading = "Colour Style";
            // 
            // kryptonGroupBox5
            // 
            this.kryptonGroupBox5.Location = new System.Drawing.Point(319, 174);
            this.kryptonGroupBox5.Name = "kryptonGroupBox5";
            // 
            // kryptonGroupBox5.Panel
            // 
            this.kryptonGroupBox5.Panel.Controls.Add(this.kchkDisplayOnGraph);
            this.kryptonGroupBox5.Size = new System.Drawing.Size(355, 75);
            this.kryptonGroupBox5.TabIndex = 6;
            this.kryptonGroupBox5.Values.Heading = "Legend";
            // 
            // kryptonGroupBox6
            // 
            this.kryptonGroupBox6.Location = new System.Drawing.Point(319, 255);
            this.kryptonGroupBox6.Name = "kryptonGroupBox6";
            // 
            // kryptonGroupBox6.Panel
            // 
            this.kryptonGroupBox6.Panel.Controls.Add(this.kchkGrid);
            this.kryptonGroupBox6.Panel.Controls.Add(this.kchkMultiplier);
            this.kryptonGroupBox6.Panel.Controls.Add(this.kchkOffset);
            this.kryptonGroupBox6.Size = new System.Drawing.Size(355, 75);
            this.kryptonGroupBox6.TabIndex = 7;
            this.kryptonGroupBox6.Values.Heading = "Tick Display";
            // 
            // kryptonGroupBox7
            // 
            this.kryptonGroupBox7.Location = new System.Drawing.Point(680, 12);
            this.kryptonGroupBox7.Name = "kryptonGroupBox7";
            // 
            // kryptonGroupBox7.Panel
            // 
            this.kryptonGroupBox7.Panel.Controls.Add(this.klbPlotObjects);
            this.kryptonGroupBox7.Panel.Controls.Add(this.kryptonGroupBox9);
            this.kryptonGroupBox7.Panel.Controls.Add(this.kryptonGroupBox8);
            this.kryptonGroupBox7.Size = new System.Drawing.Size(308, 442);
            this.kryptonGroupBox7.TabIndex = 8;
            this.kryptonGroupBox7.Values.Heading = "Plottable Objects";
            // 
            // kryptonGroupBox8
            // 
            this.kryptonGroupBox8.Location = new System.Drawing.Point(12, 329);
            this.kryptonGroupBox8.Name = "kryptonGroupBox8";
            // 
            // kryptonGroupBox8.Panel
            // 
            this.kryptonGroupBox8.Panel.Controls.Add(this.kbtnSaveCSV);
            this.kryptonGroupBox8.Panel.Controls.Add(this.kbtnCopyCSV);
            this.kryptonGroupBox8.Size = new System.Drawing.Size(279, 75);
            this.kryptonGroupBox8.TabIndex = 9;
            this.kryptonGroupBox8.Values.Heading = "Data Export";
            // 
            // kryptonGroupBox9
            // 
            this.kryptonGroupBox9.Location = new System.Drawing.Point(12, 248);
            this.kryptonGroupBox9.Name = "kryptonGroupBox9";
            // 
            // kryptonGroupBox9.Panel
            // 
            this.kryptonGroupBox9.Panel.Controls.Add(this.ktxtLabelText);
            this.kryptonGroupBox9.Size = new System.Drawing.Size(279, 75);
            this.kryptonGroupBox9.TabIndex = 10;
            this.kryptonGroupBox9.Values.Heading = "Label";
            // 
            // krbImageQualityLow
            // 
            this.krbImageQualityLow.Location = new System.Drawing.Point(14, 15);
            this.krbImageQualityLow.Name = "krbImageQualityLow";
            this.krbImageQualityLow.Size = new System.Drawing.Size(44, 20);
            this.krbImageQualityLow.TabIndex = 0;
            this.krbImageQualityLow.Values.Text = "&Low";
            // 
            // krbImageQualityHigh
            // 
            this.krbImageQualityHigh.Location = new System.Drawing.Point(64, 15);
            this.krbImageQualityHigh.Name = "krbImageQualityHigh";
            this.krbImageQualityHigh.Size = new System.Drawing.Size(49, 20);
            this.krbImageQualityHigh.TabIndex = 1;
            this.krbImageQualityHigh.Values.Text = "Hi&gh";
            // 
            // kchkImageQualityLowWhileDragging
            // 
            this.kchkImageQualityLowWhileDragging.Location = new System.Drawing.Point(119, 15);
            this.kchkImageQualityLowWhileDragging.Name = "kchkImageQualityLowWhileDragging";
            this.kchkImageQualityLowWhileDragging.Size = new System.Drawing.Size(130, 20);
            this.kchkImageQualityLowWhileDragging.TabIndex = 2;
            this.kchkImageQualityLowWhileDragging.Values.Text = "&Low while dragging";
            // 
            // kcmbColourStyle
            // 
            this.kcmbColourStyle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.kcmbColourStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kcmbColourStyle.DropDownWidth = 325;
            this.kcmbColourStyle.IntegralHeight = false;
            this.kcmbColourStyle.Location = new System.Drawing.Point(14, 12);
            this.kcmbColourStyle.Name = "kcmbColourStyle";
            this.kcmbColourStyle.Size = new System.Drawing.Size(325, 21);
            this.kcmbColourStyle.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbColourStyle.TabIndex = 0;
            // 
            // kchkDisplayOnGraph
            // 
            this.kchkDisplayOnGraph.Location = new System.Drawing.Point(14, 14);
            this.kchkDisplayOnGraph.Name = "kchkDisplayOnGraph";
            this.kchkDisplayOnGraph.Size = new System.Drawing.Size(117, 20);
            this.kchkDisplayOnGraph.TabIndex = 3;
            this.kchkDisplayOnGraph.Values.Text = "Di&splay on Graph";
            // 
            // kchkOffset
            // 
            this.kchkOffset.Location = new System.Drawing.Point(14, 15);
            this.kchkOffset.Name = "kchkOffset";
            this.kchkOffset.Size = new System.Drawing.Size(56, 20);
            this.kchkOffset.TabIndex = 3;
            this.kchkOffset.Values.Text = "Offs&et";
            // 
            // kchkMultiplier
            // 
            this.kchkMultiplier.Location = new System.Drawing.Point(76, 15);
            this.kchkMultiplier.Name = "kchkMultiplier";
            this.kchkMultiplier.Size = new System.Drawing.Size(76, 20);
            this.kchkMultiplier.TabIndex = 4;
            this.kchkMultiplier.Values.Text = "&Multiplier";
            // 
            // kchkGrid
            // 
            this.kchkGrid.Location = new System.Drawing.Point(158, 15);
            this.kchkGrid.Name = "kchkGrid";
            this.kchkGrid.Size = new System.Drawing.Size(47, 20);
            this.kchkGrid.TabIndex = 5;
            this.kchkGrid.Values.Text = "G&rid";
            // 
            // kbtnTightenLayout
            // 
            this.kbtnTightenLayout.Location = new System.Drawing.Point(319, 336);
            this.kbtnTightenLayout.Name = "kbtnTightenLayout";
            this.kbtnTightenLayout.Size = new System.Drawing.Size(154, 25);
            this.kbtnTightenLayout.TabIndex = 9;
            this.kbtnTightenLayout.Values.Text = "Ti&ghten Layout";
            this.kbtnTightenLayout.Click += new System.EventHandler(this.kbtnTightenLayout_Click);
            // 
            // klbPlotObjects
            // 
            this.klbPlotObjects.Location = new System.Drawing.Point(12, 15);
            this.klbPlotObjects.Name = "klbPlotObjects";
            this.klbPlotObjects.Size = new System.Drawing.Size(279, 227);
            this.klbPlotObjects.TabIndex = 11;
            this.klbPlotObjects.SelectedIndexChanged += new System.EventHandler(this.klbPlotObjects_SelectedIndexChanged);
            // 
            // ktxtLabelText
            // 
            this.ktxtLabelText.Hint = "Label text...";
            this.ktxtLabelText.Location = new System.Drawing.Point(12, 12);
            this.ktxtLabelText.Name = "ktxtLabelText";
            this.ktxtLabelText.Size = new System.Drawing.Size(249, 23);
            this.ktxtLabelText.TabIndex = 0;
            // 
            // kbtnCopyCSV
            // 
            this.kbtnCopyCSV.Location = new System.Drawing.Point(12, 13);
            this.kbtnCopyCSV.Name = "kbtnCopyCSV";
            this.kbtnCopyCSV.Size = new System.Drawing.Size(90, 25);
            this.kbtnCopyCSV.TabIndex = 0;
            this.kbtnCopyCSV.Values.Text = "C&opy CSV";
            this.kbtnCopyCSV.Click += new System.EventHandler(this.kbtnCopyCSV_Click);
            // 
            // kbtnSaveCSV
            // 
            this.kbtnSaveCSV.Location = new System.Drawing.Point(108, 13);
            this.kbtnSaveCSV.Name = "kbtnSaveCSV";
            this.kbtnSaveCSV.Size = new System.Drawing.Size(90, 25);
            this.kbtnSaveCSV.TabIndex = 1;
            this.kbtnSaveCSV.Values.Text = "&Save CSV";
            this.kbtnSaveCSV.Click += new System.EventHandler(this.kbtnSaveCSV_Click);
            // 
            // SettingsWindow
            // 
            this.ClientSize = new System.Drawing.Size(1000, 509);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            this.kryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).EndInit();
            this.kryptonGroupBox2.Panel.ResumeLayout(false);
            this.kryptonGroupBox2.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).EndInit();
            this.kryptonGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox3.Panel)).EndInit();
            this.kryptonGroupBox3.Panel.ResumeLayout(false);
            this.kryptonGroupBox3.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox3)).EndInit();
            this.kryptonGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox4.Panel)).EndInit();
            this.kryptonGroupBox4.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox4)).EndInit();
            this.kryptonGroupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox5.Panel)).EndInit();
            this.kryptonGroupBox5.Panel.ResumeLayout(false);
            this.kryptonGroupBox5.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox5)).EndInit();
            this.kryptonGroupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox6.Panel)).EndInit();
            this.kryptonGroupBox6.Panel.ResumeLayout(false);
            this.kryptonGroupBox6.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox6)).EndInit();
            this.kryptonGroupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox7.Panel)).EndInit();
            this.kryptonGroupBox7.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox7)).EndInit();
            this.kryptonGroupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox8.Panel)).EndInit();
            this.kryptonGroupBox8.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox8)).EndInit();
            this.kryptonGroupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox9.Panel)).EndInit();
            this.kryptonGroupBox9.Panel.ResumeLayout(false);
            this.kryptonGroupBox9.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox9)).EndInit();
            this.kryptonGroupBox9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kcmbColourStyle)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private Plot _plot;
        #endregion

        #region Properties
        public Plot Plot { get => _plot; set => _plot = value; }
        #endregion

        #region Constructor
        public SettingsWindow(Plot plot)
        {
            InitializeComponent();

            Plot = plot;

            PopualteGuiFromPlot();
        }
        #endregion

        private void kbtnVerticalAxisFitData_Click(object sender, EventArgs e)
        {
            Plot.AxisAutoY();

            PopualteGuiFromPlot();
        }

        private void kbtnHorizontalAxisFitData_Click(object sender, EventArgs e)
        {
            Plot.AxisAutoX();

            PopualteGuiFromPlot();
        }

        private void kbtnTightenLayout_Click(object sender, EventArgs e)
        {
            Plot.TightenLayout();
        }

        private void kbtnCopyCSV_Click(object sender, EventArgs e)
        {
            int plotObjectIndex = klbPlotObjects.SelectedIndex;

            IExportable plottable = (IExportable)Plot.GetPlottables()[plotObjectIndex];

            Clipboard.SetText(plottable.GetCSV());
        }

        private void kbtnSaveCSV_Click(object sender, EventArgs e)
        {
            int plotObjectIndex = klbPlotObjects.SelectedIndex;

            IExportable plottable = (IExportable)Plot.GetPlottables()[plotObjectIndex];

            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Title = $"Export CSV data for {plottable}";
            savefile.FileName = "data.csv";
            savefile.Filter = "CSV Files (*.csv)|*.csv|All files (*.*)|*.*";
            if (savefile.ShowDialog() == DialogResult.OK)
                plottable.SaveCSV(savefile.FileName);
        }

        private void kbtnApply_Click(object sender, EventArgs e)
        {
            var settings = Plot.GetSettings();

            // vertical axis
            Plot.YLabel(ktxtVerticalAxisLabelText.Text);
            Plot.Ticks(displayTicksYminor: kchkVerticalAxisShowMinorTicks.Checked, dateTimeY: kchkVerticalAxisDateAndTimeFormat.Checked);
            double y1, y2;
            double.TryParse(ktxtVerticalAxisLowerLimit.Text, out y1);
            double.TryParse(ktxtVerticalAxisUpperLimit.Text, out y2);
            Plot.Axis(y1: y1, y2: y2);

            // horizontal axis
            Plot.XLabel(ktxtHorizontalAxisLabelText.Text);
            Plot.Ticks(displayTicksXminor: kchkHorizontalAxisShowMinorTicks.Checked, dateTimeX: kchkHorizontalAxisDateAndTimeFormat.Checked);
            double x1, x2;
            double.TryParse(ktxtHorizontalAxisLowerLimit.Text, out x1);
            double.TryParse(ktxtHorizontalAxisUpperLimit.Text, out x2);
            Plot.Axis(x1: x1, x2: x2);

            // tick display options
            Plot.Ticks(useOffsetNotation: kchkOffset.Checked, useMultiplierNotation: kchkMultiplier.Checked);

            // image quality
            Plot.AntiAlias(figure: krbImageQualityHigh.Checked, data: krbImageQualityHigh.Checked);
            //Plot.mouseTracker.lowQualityWhileInteracting = cbQualityLowWhileDragging.Checked;

            // misc
            Plot.Grid(enable: kchkGrid.Checked);
            Plot.Legend(enableLegend: kchkDisplayOnGraph.Checked);
            if (kcmbColourStyle.Text != "")
            {
                Style newStyle = (Style)Enum.Parse(typeof(Style), kcmbColourStyle.Text);
                Plot.Style(newStyle);
            }

            Close();
        }

        private void kbtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region Methods
        private void PopualteGuiFromPlot()
        {
            // vertical axis
            ktxtVerticalAxisLabelText.Text = Plot.GetSettings().yLabel.text;
            ktxtVerticalAxisUpperLimit.Text = Math.Round(Plot.Axis()[3], 4).ToString();
            ktxtVerticalAxisLowerLimit.Text = Math.Round(Plot.Axis()[2], 4).ToString();
            kchkVerticalAxisShowMinorTicks.Checked = Plot.GetSettings().ticks.displayYminor;
            kchkVerticalAxisDateAndTimeFormat.Checked = Plot.GetSettings().ticks.y.dateFormat;

            // horizontal axis
            ktxtHorizontalAxisLabelText.Text = Plot.GetSettings().xLabel.text;
            ktxtHorizontalAxisUpperLimit.Text = Math.Round(Plot.Axis()[1], 4).ToString();
            ktxtHorizontalAxisLowerLimit.Text = Math.Round(Plot.Axis()[0], 4).ToString();
            kchkHorizontalAxisShowMinorTicks.Checked = Plot.GetSettings().ticks.displayXminor;
            kchkHorizontalAxisDateAndTimeFormat.Checked = Plot.GetSettings().ticks.x.dateFormat;

            // tick display options
            kchkOffset.Checked = Plot.GetSettings().ticks.useOffsetNotation;
            kchkMultiplier.Checked = Plot.GetSettings().ticks.useMultiplierNotation;
            kchkGrid.Checked = Plot.GetSettings().HorizontalGridLines.Visible;

            // legend
            kchkDisplayOnGraph.Checked = Plot.GetSettings().Legend.Visible;

            // image quality
            krbImageQualityLow.Checked = !Plot.GetSettings().misc.antiAliasData;
            krbImageQualityHigh.Checked = Plot.GetSettings().misc.antiAliasData;
            //cbQualityLowWhileDragging.Checked = Plot.mouseTracker.lowQualityWhileInteracting;

            // list of plottables
            klbPlotObjects.Items.Clear();

            foreach (var plotObject in Plot.GetPlottables())
            {
                klbPlotObjects.Items.Add(plotObject);
            }

            // list of color styles
            kcmbColourStyle.Items.AddRange(Enum.GetNames(typeof(Style)));
        }
        #endregion

        private void klbPlotObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (klbPlotObjects.Items.Count > 0 && klbPlotObjects.SelectedItem != null)
            {
                int plotObjectIndex = klbPlotObjects.SelectedIndex;

                var plottable = Plot.GetPlottables()[plotObjectIndex];

                kbtnSaveCSV.Enabled = plottable is IExportable;

                kbtnCopyCSV.Enabled = plottable is IExportable;

                // don't allow labels to be changed (after new legend system)
                //tbLabel.Enabled = true;
                //tbLabel.Text = plottable.ToString();
                ktxtLabelText.Text = "editing disabled";
            }
            else
            {
                kbtnSaveCSV.Enabled = false;

                kbtnCopyCSV.Enabled = false;

                ktxtLabelText.Enabled = false;
            }
        }
    }
}