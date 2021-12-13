#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities
{
    public class KryptonColourContrastDialog : CommonExtendedKryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonPanel kryptonPanel2;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private KryptonWrapLabel kwlBaseColourHeader;
        private KryptonWrapLabel kwlContrastColourHeader;
        private CommonCircularPictureBox cbBaseColour;
        private CommonCircularPictureBox cbContrastColour;
        private KryptonAlphaValueLabel kavlblBase;
        private KryptonRedValueLabel krvlblBase;
        private KryptonGreenValueLabel kgvlblBase;
        private KryptonBlueValueLabel kbvlblBase;
        private KryptonAlphaValueNumericBox kavnumBase;
        private KryptonRedValueNumericBox krvnumBase;
        private KryptonGreenValueNumericBox kgvnumBase;
        private KryptonBlueValueNumericBox kbvnumBase;
        private KryptonAlphaValueLabel kavlblContrast;
        private KryptonRedValueLabel krvlblContrast;
        private KryptonGreenValueLabel kgvlblContrast;
        private KryptonBlueValueLabel kbvlblContrast;
        private KryptonAlphaValueNumericBox kavnumContrast;
        private KryptonRedValueNumericBox krvnumContrast;
        private KryptonGreenValueNumericBox kgvnumContrast;
        private KryptonBlueValueNumericBox kbvnumContrast;
        private ContextMenuStrip cmsContrast;
        private IContainer components;
        private ToolStripMenuItem makeThisTheBaseColourToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem4;
        private ToolStripMenuItem copyColourCodeAsToolStripMenuItem1;
        private ToolStripMenuItem aRGBToolStripMenuItem1;
        private ToolStripSeparator toolStripMenuItem5;
        private ToolStripMenuItem rGBToolStripMenuItem1;
        private ToolStripSeparator toolStripMenuItem6;
        private ToolStripMenuItem hexadecimalToolStripMenuItem1;
        private ContextMenuStrip cmsBase;
        private ToolStripMenuItem makeThisTheContrastColourToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem copyColourCodeAsToolStripMenuItem;
        private ToolStripMenuItem aRGBToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem rGBToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripMenuItem hexadecimalToolStripMenuItem;
        private KryptonButton kbtnOk;
        private KryptonButton kbtnCancel;
        private KryptonSplitButton ksbtnPalettes;
        private ContextMenuStrip cmsPaletteUtilities;
        private ToolStripMenuItem useBaseColourToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem7;
        private ToolStripMenuItem useContrastColourToolStripMenuItem;
        private KryptonLabel kryptonLabel1;
        private KryptonLabel kryptonLabel2;
        private ColourHexadecimalTextBox chtxtBase;
        private ColourHexadecimalTextBox chtxtContrast;
        private TableLayoutPanel tableLayoutPanel3;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.ksbtnPalettes = new Krypton.Toolkit.Suite.Extended.Buttons.KryptonSplitButton();
            this.cmsPaletteUtilities = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.useBaseColourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.useContrastColourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kbtnOk = new Krypton.Toolkit.KryptonButton();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbContrastColour = new Krypton.Toolkit.Suite.Extended.Common.CommonCircularPictureBox();
            this.cmsContrast = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.makeThisTheBaseColourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.copyColourCodeAsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aRGBToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.rGBToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.hexadecimalToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cbBaseColour = new Krypton.Toolkit.Suite.Extended.Common.CommonCircularPictureBox();
            this.cmsBase = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.makeThisTheContrastColourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.copyColourCodeAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aRGBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.rGBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.hexadecimalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kwlContrastColourHeader = new Krypton.Toolkit.KryptonWrapLabel();
            this.kwlBaseColourHeader = new Krypton.Toolkit.KryptonWrapLabel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kavlblBase = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.KryptonAlphaValueLabel();
            this.krvlblBase = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.KryptonRedValueLabel();
            this.kgvlblBase = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.KryptonGreenValueLabel();
            this.kbvlblBase = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.KryptonBlueValueLabel();
            this.kavnumBase = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.KryptonAlphaValueNumericBox();
            this.krvnumBase = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.KryptonRedValueNumericBox();
            this.kgvnumBase = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.KryptonGreenValueNumericBox();
            this.kbvnumBase = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.KryptonBlueValueNumericBox();
            this.chtxtBase = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.ColourHexadecimalTextBox();
            this.kavlblContrast = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.KryptonAlphaValueLabel();
            this.krvlblContrast = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.KryptonRedValueLabel();
            this.kgvlblContrast = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.KryptonGreenValueLabel();
            this.kbvlblContrast = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.KryptonBlueValueLabel();
            this.kavnumContrast = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.KryptonAlphaValueNumericBox();
            this.krvnumContrast = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.KryptonRedValueNumericBox();
            this.kgvnumContrast = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.KryptonGreenValueNumericBox();
            this.kbvnumContrast = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.KryptonBlueValueNumericBox();
            this.chtxtContrast = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.ColourHexadecimalTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.cmsPaletteUtilities.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbContrastColour)).BeginInit();
            this.cmsContrast.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbBaseColour)).BeginInit();
            this.cmsBase.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.ksbtnPalettes);
            this.kryptonPanel1.Controls.Add(this.kbtnOk);
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 644);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(876, 50);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // ksbtnPalettes
            // 
            this.ksbtnPalettes.AutoSize = true;
            this.ksbtnPalettes.ContextMenuStrip = this.cmsPaletteUtilities;
            this.ksbtnPalettes.Location = new System.Drawing.Point(12, 13);
            this.ksbtnPalettes.Name = "ksbtnPalettes";
            this.ksbtnPalettes.ProcessPath = null;
            this.ksbtnPalettes.ShowSplitOption = true;
            this.ksbtnPalettes.Size = new System.Drawing.Size(158, 25);
            this.ksbtnPalettes.TabIndex = 5;
            this.ksbtnPalettes.UseUACElevation = false;
            this.ksbtnPalettes.Values.Text = "&Use Colours for Palettes";
            // 
            // cmsPaletteUtilities
            // 
            this.cmsPaletteUtilities.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsPaletteUtilities.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.useBaseColourToolStripMenuItem,
            this.toolStripMenuItem7,
            this.useContrastColourToolStripMenuItem});
            this.cmsPaletteUtilities.Name = "contextMenuStrip1";
            this.cmsPaletteUtilities.Size = new System.Drawing.Size(181, 54);
            // 
            // useBaseColourToolStripMenuItem
            // 
            this.useBaseColourToolStripMenuItem.Name = "useBaseColourToolStripMenuItem";
            this.useBaseColourToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.useBaseColourToolStripMenuItem.Text = "Use &Base colour";
            this.useBaseColourToolStripMenuItem.Click += new System.EventHandler(this.useBaseColourToolStripMenuItem_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(177, 6);
            // 
            // useContrastColourToolStripMenuItem
            // 
            this.useContrastColourToolStripMenuItem.Name = "useContrastColourToolStripMenuItem";
            this.useContrastColourToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.useContrastColourToolStripMenuItem.Text = "Use C&ontrast Colour";
            this.useContrastColourToolStripMenuItem.Click += new System.EventHandler(this.useContrastColourToolStripMenuItem_Click);
            // 
            // kbtnOk
            // 
            this.kbtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnOk.Location = new System.Drawing.Point(678, 13);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.Size = new System.Drawing.Size(90, 25);
            this.kbtnOk.TabIndex = 2;
            this.kbtnOk.Values.Text = "&OK";
            this.kbtnOk.Click += new System.EventHandler(this.kbtnOk_Click);
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(774, 13);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.TabIndex = 1;
            this.kbtnCancel.Values.Text = "&Cancel";
            this.kbtnCancel.Click += new System.EventHandler(this.kbtnCancel_Click);
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderPrimary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(876, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.tableLayoutPanel1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(876, 644);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.cbContrastColour, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbBaseColour, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.kwlContrastColourHeader, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.kwlBaseColourHeader, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.24042F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.75958F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 199F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(876, 644);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cbContrastColour
            // 
            this.cbContrastColour.BackColor = System.Drawing.SystemColors.Control;
            this.cbContrastColour.ContextMenuStrip = this.cmsContrast;
            this.cbContrastColour.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbContrastColour.Location = new System.Drawing.Point(441, 61);
            this.cbContrastColour.Name = "cbContrastColour";
            this.cbContrastColour.Size = new System.Drawing.Size(432, 380);
            this.cbContrastColour.TabIndex = 7;
            this.cbContrastColour.TabStop = false;
            this.cbContrastColour.BackColorChanged += new System.EventHandler(this.cbContrastColour_BackColorChanged);
            // 
            // cmsContrast
            // 
            this.cmsContrast.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsContrast.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.makeThisTheBaseColourToolStripMenuItem,
            this.toolStripMenuItem4,
            this.copyColourCodeAsToolStripMenuItem1});
            this.cmsContrast.Name = "cmsContrast";
            this.cmsContrast.Size = new System.Drawing.Size(212, 54);
            // 
            // makeThisTheBaseColourToolStripMenuItem
            // 
            this.makeThisTheBaseColourToolStripMenuItem.Name = "makeThisTheBaseColourToolStripMenuItem";
            this.makeThisTheBaseColourToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.makeThisTheBaseColourToolStripMenuItem.Text = "Make this the &Base Colour";
            this.makeThisTheBaseColourToolStripMenuItem.Click += new System.EventHandler(this.makeThisTheBaseColourToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(208, 6);
            // 
            // copyColourCodeAsToolStripMenuItem1
            // 
            this.copyColourCodeAsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aRGBToolStripMenuItem1,
            this.toolStripMenuItem5,
            this.rGBToolStripMenuItem1,
            this.toolStripMenuItem6,
            this.hexadecimalToolStripMenuItem1});
            this.copyColourCodeAsToolStripMenuItem1.Name = "copyColourCodeAsToolStripMenuItem1";
            this.copyColourCodeAsToolStripMenuItem1.Size = new System.Drawing.Size(211, 22);
            this.copyColourCodeAsToolStripMenuItem1.Text = "Copy Colour C&ode As...";
            // 
            // aRGBToolStripMenuItem1
            // 
            this.aRGBToolStripMenuItem1.Name = "aRGBToolStripMenuItem1";
            this.aRGBToolStripMenuItem1.Size = new System.Drawing.Size(143, 22);
            this.aRGBToolStripMenuItem1.Text = "&ARGB";
            this.aRGBToolStripMenuItem1.Click += new System.EventHandler(this.aRGBToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(140, 6);
            // 
            // rGBToolStripMenuItem1
            // 
            this.rGBToolStripMenuItem1.Name = "rGBToolStripMenuItem1";
            this.rGBToolStripMenuItem1.Size = new System.Drawing.Size(143, 22);
            this.rGBToolStripMenuItem1.Text = "R&GB";
            this.rGBToolStripMenuItem1.Click += new System.EventHandler(this.rGBToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(140, 6);
            // 
            // hexadecimalToolStripMenuItem1
            // 
            this.hexadecimalToolStripMenuItem1.Name = "hexadecimalToolStripMenuItem1";
            this.hexadecimalToolStripMenuItem1.Size = new System.Drawing.Size(143, 22);
            this.hexadecimalToolStripMenuItem1.Text = "He&xadecimal";
            this.hexadecimalToolStripMenuItem1.Click += new System.EventHandler(this.hexadecimalToolStripMenuItem1_Click);
            // 
            // cbBaseColour
            // 
            this.cbBaseColour.BackColor = System.Drawing.SystemColors.Control;
            this.cbBaseColour.ContextMenuStrip = this.cmsBase;
            this.cbBaseColour.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbBaseColour.Location = new System.Drawing.Point(3, 61);
            this.cbBaseColour.Name = "cbBaseColour";
            this.cbBaseColour.Size = new System.Drawing.Size(432, 380);
            this.cbBaseColour.TabIndex = 6;
            this.cbBaseColour.TabStop = false;
            this.cbBaseColour.BackColorChanged += new System.EventHandler(this.cbBaseColour_BackColorChanged);
            // 
            // cmsBase
            // 
            this.cmsBase.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsBase.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.makeThisTheContrastColourToolStripMenuItem,
            this.toolStripMenuItem1,
            this.copyColourCodeAsToolStripMenuItem});
            this.cmsBase.Name = "cmsBase";
            this.cmsBase.Size = new System.Drawing.Size(233, 54);
            // 
            // makeThisTheContrastColourToolStripMenuItem
            // 
            this.makeThisTheContrastColourToolStripMenuItem.Name = "makeThisTheContrastColourToolStripMenuItem";
            this.makeThisTheContrastColourToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.makeThisTheContrastColourToolStripMenuItem.Text = "Make this the &Contrast Colour";
            this.makeThisTheContrastColourToolStripMenuItem.Click += new System.EventHandler(this.makeThisTheContrastColourToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(229, 6);
            // 
            // copyColourCodeAsToolStripMenuItem
            // 
            this.copyColourCodeAsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aRGBToolStripMenuItem,
            this.toolStripMenuItem2,
            this.rGBToolStripMenuItem,
            this.toolStripMenuItem3,
            this.hexadecimalToolStripMenuItem});
            this.copyColourCodeAsToolStripMenuItem.Name = "copyColourCodeAsToolStripMenuItem";
            this.copyColourCodeAsToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.copyColourCodeAsToolStripMenuItem.Text = "Copy Colour C&ode As...";
            // 
            // aRGBToolStripMenuItem
            // 
            this.aRGBToolStripMenuItem.Name = "aRGBToolStripMenuItem";
            this.aRGBToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.aRGBToolStripMenuItem.Text = "&ARGB";
            this.aRGBToolStripMenuItem.Click += new System.EventHandler(this.aRGBToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(140, 6);
            // 
            // rGBToolStripMenuItem
            // 
            this.rGBToolStripMenuItem.Name = "rGBToolStripMenuItem";
            this.rGBToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.rGBToolStripMenuItem.Text = "R&GB";
            this.rGBToolStripMenuItem.Click += new System.EventHandler(this.rGBToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(140, 6);
            // 
            // hexadecimalToolStripMenuItem
            // 
            this.hexadecimalToolStripMenuItem.Name = "hexadecimalToolStripMenuItem";
            this.hexadecimalToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.hexadecimalToolStripMenuItem.Text = "He&xadecimal";
            this.hexadecimalToolStripMenuItem.Click += new System.EventHandler(this.hexadecimalToolStripMenuItem_Click);
            // 
            // kwlContrastColourHeader
            // 
            this.kwlContrastColourHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kwlContrastColourHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlContrastColourHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlContrastColourHeader.Location = new System.Drawing.Point(441, 0);
            this.kwlContrastColourHeader.Name = "kwlContrastColourHeader";
            this.kwlContrastColourHeader.Size = new System.Drawing.Size(432, 58);
            this.kwlContrastColourHeader.StateCommon.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlContrastColourHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kwlBaseColourHeader
            // 
            this.kwlBaseColourHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kwlBaseColourHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlBaseColourHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlBaseColourHeader.Location = new System.Drawing.Point(3, 0);
            this.kwlBaseColourHeader.Name = "kwlBaseColourHeader";
            this.kwlBaseColourHeader.Size = new System.Drawing.Size(432, 58);
            this.kwlBaseColourHeader.StateCommon.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlBaseColourHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.kavlblBase, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.krvlblBase, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.kgvlblBase, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.kbvlblBase, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.kavnumBase, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.krvnumBase, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.kgvnumBase, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.kbvnumBase, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.kryptonLabel1, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.chtxtBase, 1, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 447);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(432, 194);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel1.Location = new System.Drawing.Point(3, 155);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(210, 36);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 9;
            this.kryptonLabel1.Values.Text = "Hex Value:";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.kavlblContrast, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.krvlblContrast, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.kgvlblContrast, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.kbvlblContrast, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.kavnumContrast, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.krvnumContrast, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.kgvnumContrast, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.kbvnumContrast, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.kryptonLabel2, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.chtxtContrast, 1, 4);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(441, 447);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(432, 194);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel2.Location = new System.Drawing.Point(3, 155);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(210, 36);
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.TabIndex = 8;
            this.kryptonLabel2.Values.Text = "Hex Value:";
            // 
            // kavlblBase
            // 
            this.kavlblBase.AlphaValue = 0;
            this.kavlblBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kavlblBase.ExtraText = "Alpha Value";
            this.kavlblBase.Location = new System.Drawing.Point(3, 3);
            this.kavlblBase.Name = "kavlblBase";
            this.kavlblBase.ShowColon = false;
            this.kavlblBase.ShowCurrentColourValue = false;
            this.kavlblBase.Size = new System.Drawing.Size(210, 32);
            this.kavlblBase.StateCommon.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kavlblBase.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kavlblBase.TabIndex = 1;
            this.kavlblBase.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kavlblBase.Values.Text = "Alpha Value:";
            // 
            // krvlblBase
            // 
            this.krvlblBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.krvlblBase.ExtraText = "Red Value";
            this.krvlblBase.Location = new System.Drawing.Point(3, 41);
            this.krvlblBase.Name = "krvlblBase";
            this.krvlblBase.RedValue = 0;
            this.krvlblBase.ShowColon = false;
            this.krvlblBase.ShowCurrentColourValue = false;
            this.krvlblBase.Size = new System.Drawing.Size(210, 32);
            this.krvlblBase.StateCommon.LongText.Color1 = System.Drawing.Color.Red;
            this.krvlblBase.StateCommon.LongText.Color2 = System.Drawing.Color.Red;
            this.krvlblBase.StateCommon.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.krvlblBase.StateCommon.ShortText.Color1 = System.Drawing.Color.Red;
            this.krvlblBase.StateCommon.ShortText.Color2 = System.Drawing.Color.Red;
            this.krvlblBase.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.krvlblBase.TabIndex = 2;
            this.krvlblBase.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.krvlblBase.UseAccessibleUI = false;
            this.krvlblBase.Values.Text = "Red Value:";
            // 
            // kgvlblBase
            // 
            this.kgvlblBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kgvlblBase.ExtraText = "Green Value";
            this.kgvlblBase.GreenValue = 0;
            this.kgvlblBase.Location = new System.Drawing.Point(3, 79);
            this.kgvlblBase.Name = "kgvlblBase";
            this.kgvlblBase.ShowColon = false;
            this.kgvlblBase.ShowCurrentColourValue = false;
            this.kgvlblBase.Size = new System.Drawing.Size(210, 32);
            this.kgvlblBase.StateCommon.LongText.Color1 = System.Drawing.Color.Green;
            this.kgvlblBase.StateCommon.LongText.Color2 = System.Drawing.Color.Green;
            this.kgvlblBase.StateCommon.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kgvlblBase.StateCommon.ShortText.Color1 = System.Drawing.Color.Green;
            this.kgvlblBase.StateCommon.ShortText.Color2 = System.Drawing.Color.Green;
            this.kgvlblBase.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kgvlblBase.TabIndex = 3;
            this.kgvlblBase.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kgvlblBase.UseAccessibleUI = false;
            this.kgvlblBase.Values.Text = "Green Value:";
            // 
            // kbvlblBase
            // 
            this.kbvlblBase.BlueValue = 0;
            this.kbvlblBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kbvlblBase.ExtraText = "Blue Value";
            this.kbvlblBase.Location = new System.Drawing.Point(3, 117);
            this.kbvlblBase.Name = "kbvlblBase";
            this.kbvlblBase.ShowColon = false;
            this.kbvlblBase.ShowCurrentColourValue = false;
            this.kbvlblBase.Size = new System.Drawing.Size(210, 32);
            this.kbvlblBase.StateCommon.LongText.Color1 = System.Drawing.Color.Blue;
            this.kbvlblBase.StateCommon.LongText.Color2 = System.Drawing.Color.Blue;
            this.kbvlblBase.StateCommon.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kbvlblBase.StateCommon.ShortText.Color1 = System.Drawing.Color.Blue;
            this.kbvlblBase.StateCommon.ShortText.Color2 = System.Drawing.Color.Blue;
            this.kbvlblBase.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kbvlblBase.TabIndex = 4;
            this.kbvlblBase.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kbvlblBase.UseAccessibleUI = false;
            this.kbvlblBase.Values.Text = "Blue Value:";
            // 
            // kavnumBase
            // 
            this.kavnumBase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kavnumBase.Location = new System.Drawing.Point(219, 3);
            this.kavnumBase.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.kavnumBase.Name = "kavnumBase";
            this.kavnumBase.Size = new System.Drawing.Size(210, 22);
            this.kavnumBase.TabIndex = 5;
            this.kavnumBase.Typeface = null;
            this.kavnumBase.ValueChanged += new System.EventHandler(this.kavnumBase_ValueChanged);
            // 
            // krvnumBase
            // 
            this.krvnumBase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.krvnumBase.Location = new System.Drawing.Point(219, 41);
            this.krvnumBase.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.krvnumBase.Name = "krvnumBase";
            this.krvnumBase.Size = new System.Drawing.Size(210, 22);
            this.krvnumBase.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.krvnumBase.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.krvnumBase.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.krvnumBase.TabIndex = 6;
            this.krvnumBase.ToolTipValues.Description = "The red value";
            this.krvnumBase.ToolTipValues.EnableToolTips = true;
            this.krvnumBase.ToolTipValues.Heading = "Red Value";
            this.krvnumBase.ToolTipValues.Image = null;
            this.krvnumBase.Typeface = null;
            this.krvnumBase.UseAccessibleUI = false;
            this.krvnumBase.ValueChanged += new System.EventHandler(this.krvnumBase_ValueChanged);
            // 
            // kgvnumBase
            // 
            this.kgvnumBase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kgvnumBase.Location = new System.Drawing.Point(219, 79);
            this.kgvnumBase.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.kgvnumBase.Name = "kgvnumBase";
            this.kgvnumBase.Size = new System.Drawing.Size(210, 22);
            this.kgvnumBase.StateCommon.Back.Color1 = System.Drawing.Color.Green;
            this.kgvnumBase.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.kgvnumBase.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kgvnumBase.TabIndex = 7;
            this.kgvnumBase.ToolTipValues.Description = "The green value";
            this.kgvnumBase.ToolTipValues.EnableToolTips = true;
            this.kgvnumBase.ToolTipValues.Heading = "Green Value";
            this.kgvnumBase.ToolTipValues.Image = null;
            this.kgvnumBase.Typeface = null;
            this.kgvnumBase.UseAccessibleUI = false;
            this.kgvnumBase.ValueChanged += new System.EventHandler(this.kgvnumBase_ValueChanged);
            // 
            // kbvnumBase
            // 
            this.kbvnumBase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kbvnumBase.Location = new System.Drawing.Point(219, 117);
            this.kbvnumBase.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.kbvnumBase.Name = "kbvnumBase";
            this.kbvnumBase.Size = new System.Drawing.Size(210, 22);
            this.kbvnumBase.StateCommon.Back.Color1 = System.Drawing.Color.Blue;
            this.kbvnumBase.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.kbvnumBase.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kbvnumBase.TabIndex = 8;
            this.kbvnumBase.ToolTipValues.Description = "The blue value";
            this.kbvnumBase.ToolTipValues.EnableToolTips = true;
            this.kbvnumBase.ToolTipValues.Heading = "Blue Value";
            this.kbvnumBase.ToolTipValues.Image = null;
            this.kbvnumBase.Typeface = null;
            this.kbvnumBase.UseAccessibleUI = false;
            this.kbvnumBase.ValueChanged += new System.EventHandler(this.kbvnumBase_ValueChanged);
            // 
            // chtxtBase
            // 
            this.chtxtBase.Colour = System.Drawing.Color.Empty;
            this.chtxtBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chtxtBase.CueHint.CueHintText = "000000";
            this.chtxtBase.Location = new System.Drawing.Point(219, 155);
            this.chtxtBase.MaxLength = 6;
            this.chtxtBase.Name = "chtxtBase";
            this.chtxtBase.Size = new System.Drawing.Size(210, 23);
            this.chtxtBase.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.chtxtBase.TabIndex = 10;
            this.chtxtBase.Text = "000000";
            this.chtxtBase.TextChanged += new System.EventHandler(this.chtxtBase_TextChanged);
            // 
            // kavlblContrast
            // 
            this.kavlblContrast.AlphaValue = 0;
            this.kavlblContrast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kavlblContrast.ExtraText = "Alpha Value";
            this.kavlblContrast.Location = new System.Drawing.Point(3, 3);
            this.kavlblContrast.Name = "kavlblContrast";
            this.kavlblContrast.ShowColon = false;
            this.kavlblContrast.ShowCurrentColourValue = false;
            this.kavlblContrast.Size = new System.Drawing.Size(210, 32);
            this.kavlblContrast.StateCommon.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kavlblContrast.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kavlblContrast.TabIndex = 0;
            this.kavlblContrast.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kavlblContrast.Values.Text = "Alpha Value:";
            // 
            // krvlblContrast
            // 
            this.krvlblContrast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.krvlblContrast.ExtraText = "Red Value";
            this.krvlblContrast.Location = new System.Drawing.Point(3, 41);
            this.krvlblContrast.Name = "krvlblContrast";
            this.krvlblContrast.RedValue = 0;
            this.krvlblContrast.ShowColon = false;
            this.krvlblContrast.ShowCurrentColourValue = false;
            this.krvlblContrast.Size = new System.Drawing.Size(210, 32);
            this.krvlblContrast.StateCommon.LongText.Color1 = System.Drawing.Color.Red;
            this.krvlblContrast.StateCommon.LongText.Color2 = System.Drawing.Color.Red;
            this.krvlblContrast.StateCommon.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.krvlblContrast.StateCommon.ShortText.Color1 = System.Drawing.Color.Red;
            this.krvlblContrast.StateCommon.ShortText.Color2 = System.Drawing.Color.Red;
            this.krvlblContrast.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.krvlblContrast.TabIndex = 1;
            this.krvlblContrast.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.krvlblContrast.UseAccessibleUI = false;
            this.krvlblContrast.Values.Text = "Red Value:";
            // 
            // kgvlblContrast
            // 
            this.kgvlblContrast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kgvlblContrast.ExtraText = "Green Value";
            this.kgvlblContrast.GreenValue = 0;
            this.kgvlblContrast.Location = new System.Drawing.Point(3, 79);
            this.kgvlblContrast.Name = "kgvlblContrast";
            this.kgvlblContrast.ShowColon = false;
            this.kgvlblContrast.ShowCurrentColourValue = false;
            this.kgvlblContrast.Size = new System.Drawing.Size(210, 32);
            this.kgvlblContrast.StateCommon.LongText.Color1 = System.Drawing.Color.Green;
            this.kgvlblContrast.StateCommon.LongText.Color2 = System.Drawing.Color.Green;
            this.kgvlblContrast.StateCommon.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kgvlblContrast.StateCommon.ShortText.Color1 = System.Drawing.Color.Green;
            this.kgvlblContrast.StateCommon.ShortText.Color2 = System.Drawing.Color.Green;
            this.kgvlblContrast.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kgvlblContrast.TabIndex = 2;
            this.kgvlblContrast.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kgvlblContrast.UseAccessibleUI = false;
            this.kgvlblContrast.Values.Text = "Green Value:";
            // 
            // kbvlblContrast
            // 
            this.kbvlblContrast.BlueValue = 0;
            this.kbvlblContrast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kbvlblContrast.ExtraText = "Blue Value";
            this.kbvlblContrast.Location = new System.Drawing.Point(3, 117);
            this.kbvlblContrast.Name = "kbvlblContrast";
            this.kbvlblContrast.ShowColon = false;
            this.kbvlblContrast.ShowCurrentColourValue = false;
            this.kbvlblContrast.Size = new System.Drawing.Size(210, 32);
            this.kbvlblContrast.StateCommon.LongText.Color1 = System.Drawing.Color.Blue;
            this.kbvlblContrast.StateCommon.LongText.Color2 = System.Drawing.Color.Blue;
            this.kbvlblContrast.StateCommon.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kbvlblContrast.StateCommon.ShortText.Color1 = System.Drawing.Color.Blue;
            this.kbvlblContrast.StateCommon.ShortText.Color2 = System.Drawing.Color.Blue;
            this.kbvlblContrast.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kbvlblContrast.TabIndex = 3;
            this.kbvlblContrast.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kbvlblContrast.UseAccessibleUI = false;
            this.kbvlblContrast.Values.Text = "Blue Value:";
            // 
            // kavnumContrast
            // 
            this.kavnumContrast.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kavnumContrast.Location = new System.Drawing.Point(219, 3);
            this.kavnumContrast.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.kavnumContrast.Name = "kavnumContrast";
            this.kavnumContrast.Size = new System.Drawing.Size(210, 22);
            this.kavnumContrast.TabIndex = 4;
            this.kavnumContrast.Typeface = null;
            this.kavnumContrast.ValueChanged += new System.EventHandler(this.kavnumContrast_ValueChanged);
            // 
            // krvnumContrast
            // 
            this.krvnumContrast.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.krvnumContrast.Location = new System.Drawing.Point(219, 41);
            this.krvnumContrast.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.krvnumContrast.Name = "krvnumContrast";
            this.krvnumContrast.Size = new System.Drawing.Size(210, 22);
            this.krvnumContrast.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.krvnumContrast.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.krvnumContrast.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.krvnumContrast.TabIndex = 5;
            this.krvnumContrast.ToolTipValues.Description = "The red value";
            this.krvnumContrast.ToolTipValues.EnableToolTips = true;
            this.krvnumContrast.ToolTipValues.Heading = "Red Value";
            this.krvnumContrast.ToolTipValues.Image = null;
            this.krvnumContrast.Typeface = null;
            this.krvnumContrast.UseAccessibleUI = false;
            this.krvnumContrast.ValueChanged += new System.EventHandler(this.krvnumContrast_ValueChanged);
            // 
            // kgvnumContrast
            // 
            this.kgvnumContrast.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kgvnumContrast.Location = new System.Drawing.Point(219, 79);
            this.kgvnumContrast.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.kgvnumContrast.Name = "kgvnumContrast";
            this.kgvnumContrast.Size = new System.Drawing.Size(210, 22);
            this.kgvnumContrast.StateCommon.Back.Color1 = System.Drawing.Color.Green;
            this.kgvnumContrast.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.kgvnumContrast.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kgvnumContrast.TabIndex = 6;
            this.kgvnumContrast.ToolTipValues.Description = "The green value";
            this.kgvnumContrast.ToolTipValues.EnableToolTips = true;
            this.kgvnumContrast.ToolTipValues.Heading = "Green Value";
            this.kgvnumContrast.ToolTipValues.Image = null;
            this.kgvnumContrast.Typeface = null;
            this.kgvnumContrast.UseAccessibleUI = false;
            this.kgvnumContrast.ValueChanged += new System.EventHandler(this.kgvnumContrast_ValueChanged);
            // 
            // kbvnumContrast
            // 
            this.kbvnumContrast.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kbvnumContrast.Location = new System.Drawing.Point(219, 117);
            this.kbvnumContrast.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.kbvnumContrast.Name = "kbvnumContrast";
            this.kbvnumContrast.Size = new System.Drawing.Size(210, 22);
            this.kbvnumContrast.StateCommon.Back.Color1 = System.Drawing.Color.Blue;
            this.kbvnumContrast.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.kbvnumContrast.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kbvnumContrast.TabIndex = 7;
            this.kbvnumContrast.ToolTipValues.Description = "The blue value";
            this.kbvnumContrast.ToolTipValues.EnableToolTips = true;
            this.kbvnumContrast.ToolTipValues.Heading = "Blue Value";
            this.kbvnumContrast.ToolTipValues.Image = null;
            this.kbvnumContrast.Typeface = null;
            this.kbvnumContrast.UseAccessibleUI = false;
            this.kbvnumContrast.ValueChanged += new System.EventHandler(this.kbvnumContrast_ValueChanged);
            // 
            // chtxtContrast
            // 
            this.chtxtContrast.Colour = System.Drawing.Color.Empty;
            this.chtxtContrast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chtxtContrast.CueHint.CueHintText = "000000";
            this.chtxtContrast.Location = new System.Drawing.Point(219, 155);
            this.chtxtContrast.MaxLength = 6;
            this.chtxtContrast.Name = "chtxtContrast";
            this.chtxtContrast.Size = new System.Drawing.Size(210, 23);
            this.chtxtContrast.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.chtxtContrast.TabIndex = 9;
            this.chtxtContrast.Text = "000000";
            // 
            // KryptonColourContrastDialog
            // 
            this.AcceptButton = this.kbtnOk;
            this.BlurValues.EnableBlur = true;
            this.CancelButton = this.kbtnCancel;
            this.ClientSize = new System.Drawing.Size(876, 694);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonColourContrastDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Contrast Colour Configurator";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.cmsPaletteUtilities.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbContrastColour)).EndInit();
            this.cmsContrast.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbBaseColour)).EndInit();
            this.cmsBase.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private bool _automateContrastColour, _useForPalettes, _keepOpacityValues;

        private Color _baseColour, _contrastColour;

        private System.Windows.Forms.Timer _updateUI;
        #endregion

        #region Properties
        public bool AutomateContrastColour { get => _automateContrastColour; set => _automateContrastColour = value; }

        public bool UseForPalettes { get => _useForPalettes; set => _useForPalettes = value; }

        public bool KeepOpacityValues { get => _keepOpacityValues; set => _keepOpacityValues = value; }

        public Color BaseColour { get => _baseColour; set => _baseColour = value; }

        public Color ContrastColour { get => _contrastColour; set => _contrastColour = value; }
        #endregion

        #region Constructor
        public KryptonColourContrastDialog(string baseColourHeader = "Base Colour", string contrastColourHeader = "Contrast Colour")
        {
            InitializeComponent();

            SetAutomateContrastColour(true);

            SetUseForPalettes(false);

            SetKeepOpacityValues(true);

            UpdateUI(Color.Empty, Color.Empty, baseColourHeader, contrastColourHeader, false);

            _updateUI = new System.Windows.Forms.Timer() { Enabled = true, Interval = 256 };

            _updateUI.Tick += UpdateUI_Tick;
        }

        public KryptonColourContrastDialog(Color baseColour, Color contrastColour, string baseColourHeader = "Base Colour", string contrastColourHeader = "Contrast Colour", bool showPaletteButton = false)
        {
            InitializeComponent();

            SetAutomateContrastColour(true);

            SetUseForPalettes(false);

            SetKeepOpacityValues(true);

            UpdateUI(baseColour, contrastColour, baseColourHeader, contrastColourHeader, showPaletteButton);

            _updateUI = new System.Windows.Forms.Timer() { Enabled = true, Interval = 256 };

            _updateUI.Tick += UpdateUI_Tick;
        }
        #endregion

        #region Event Handlers
        private void cbBaseColour_BackColorChanged(object sender, EventArgs e)
        {
            kavnumContrast.Value = cbContrastColour.BackColor.A;

            krvnumContrast.Value = cbContrastColour.BackColor.R;

            kgvnumContrast.Value = cbContrastColour.BackColor.G;

            kbvnumContrast.Value = cbContrastColour.BackColor.B;

            chtxtBase.Colour = cbBaseColour.BackColor;
        }

        private void cbContrastColour_BackColorChanged(object sender, EventArgs e)
        {
            kavnumBase.Value = cbBaseColour.BackColor.A;

            krvnumBase.Value = cbBaseColour.BackColor.R;

            kgvnumBase.Value = cbBaseColour.BackColor.G;

            kbvnumBase.Value = cbBaseColour.BackColor.B;

            chtxtContrast.Colour = cbContrastColour.BackColor;
        }

        private void useBaseColourToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void useContrastColourToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void kavnumBase_ValueChanged(object sender, EventArgs e)
        {
            byte alpha = (byte)kavnumBase.Value, red = (byte)krvnumBase.Value, green = (byte)kgvnumBase.Value, blue = (byte)kbvnumBase.Value;

            UpdateBaseColour(alpha, red, green, blue);
        }

        private void krvnumBase_ValueChanged(object sender, EventArgs e)
        {
            byte alpha = (byte)kavnumBase.Value, red = (byte)krvnumBase.Value, green = (byte)kgvnumBase.Value, blue = (byte)kbvnumBase.Value;

            UpdateBaseColour(alpha, red, green, blue);
        }

        private void kgvnumBase_ValueChanged(object sender, EventArgs e)
        {
            byte alpha = (byte)kavnumBase.Value, red = (byte)krvnumBase.Value, green = (byte)kgvnumBase.Value, blue = (byte)kbvnumBase.Value;

            UpdateBaseColour(alpha, red, green, blue);
        }

        private void kbvnumBase_ValueChanged(object sender, EventArgs e)
        {
            byte alpha = (byte)kavnumBase.Value, red = (byte)krvnumBase.Value, green = (byte)kgvnumBase.Value, blue = (byte)kbvnumBase.Value;

            UpdateBaseColour(alpha, red, green, blue);
        }

        private void kavnumContrast_ValueChanged(object sender, EventArgs e)
        {
            byte alpha = (byte)kavnumContrast.Value, red = (byte)krvnumContrast.Value, green = (byte)kgvnumContrast.Value, blue = (byte)kbvnumContrast.Value;

            UpdateContrastColour(alpha, red, green, blue);
        }

        private void krvnumContrast_ValueChanged(object sender, EventArgs e)
        {
            byte alpha = (byte)kavnumContrast.Value, red = (byte)krvnumContrast.Value, green = (byte)kgvnumContrast.Value, blue = (byte)kbvnumContrast.Value;

            UpdateContrastColour(alpha, red, green, blue);
        }

        private void kgvnumContrast_ValueChanged(object sender, EventArgs e)
        {
            byte alpha = (byte)kavnumContrast.Value, red = (byte)krvnumContrast.Value, green = (byte)kgvnumContrast.Value, blue = (byte)kbvnumContrast.Value;

            UpdateContrastColour(alpha, red, green, blue);
        }

        private void kbvnumContrast_ValueChanged(object sender, EventArgs e)
        {
            byte alpha = (byte)kavnumContrast.Value, red = (byte)krvnumContrast.Value, green = (byte)kgvnumContrast.Value, blue = (byte)kbvnumContrast.Value;

            UpdateContrastColour(alpha, red, green, blue);
        }

        private void makeThisTheContrastColourToolStripMenuItem_Click(object sender, EventArgs e) => cbContrastColour.BackColor = cbBaseColour.BackColor;

        private void aRGBToolStripMenuItem_Click(object sender, EventArgs e) => Clipboard.SetText(ColourExtensions.ColourToARGB(cbBaseColour.BackColor));

        private void rGBToolStripMenuItem_Click(object sender, EventArgs e) => Clipboard.SetText(ColourExtensions.ColourToRGB(cbBaseColour.BackColor));

        private void hexadecimalToolStripMenuItem_Click(object sender, EventArgs e) => Clipboard.SetText(ColourExtensions.ColourToHexadecimal(cbBaseColour.BackColor));

        private void makeThisTheBaseColourToolStripMenuItem_Click(object sender, EventArgs e) => cbBaseColour.BackColor = cbContrastColour.BackColor;

        private void aRGBToolStripMenuItem1_Click(object sender, EventArgs e) => Clipboard.SetText(ColourExtensions.ColourToARGB(cbContrastColour.BackColor));

        private void rGBToolStripMenuItem1_Click(object sender, EventArgs e) => Clipboard.SetText(ColourExtensions.ColourToRGB(cbContrastColour.BackColor));

        private void hexadecimalToolStripMenuItem1_Click(object sender, EventArgs e) => Clipboard.SetText(ColourExtensions.ColourToHexadecimal(cbContrastColour.BackColor));

        private void kbtnOk_Click(object sender, EventArgs e)
        {

        }

        private void kbtnCancel_Click(object sender, EventArgs e)
        {

        }

        private void UpdateUI_Tick(object sender, EventArgs e)
        {
            cbBaseColour.BackColor = Color.FromArgb(Convert.ToInt32(kavnumBase.Value), Convert.ToInt32(krvnumBase.Value), Convert.ToInt32(kgvnumBase.Value), Convert.ToInt32(kbvnumBase.Value));

            if (GetAutomateContrastColour())
            {
                cbContrastColour.BackColor = ColourExtensions.GetContrast(cbBaseColour.BackColor, GetKeepOpacityValues());
            }
        }

        private void chtxtBase_TextChanged(object sender, EventArgs e)
        {
            if (chtxtBase.Text.Length == 3 || chtxtBase.Text.Length == 6)
            {
                cbBaseColour.BackColor = ColorTranslator.FromHtml($"#{chtxtBase.Text}");
            }
        }
        #endregion

        #region Methods
        public void FireTimer(bool fire)
        {
            if (fire)
            {
                _updateUI.Start();
            }
            else
            {
                _updateUI.Stop();
            }
        }

        public void ShowPaletteButtons(bool visible) => ksbtnPalettes.Visible = visible;

        public void Refresh() => Invalidate();

        private void UpdateBaseColour(byte alpha, byte red, byte green, byte blue) => cbBaseColour.BackColor = Color.FromArgb(alpha, red, green, blue);

        private void UpdateContrastColour(byte alpha, byte red, byte green, byte blue) => cbContrastColour.BackColor = Color.FromArgb(alpha, red, green, blue);

        private void UpdateUI(Color baseColour, Color contrastColour, string baseColourHeader, string contrastColourHeader, bool showPaletteButton)
        {
            SetBaseColour(baseColour);

            SetContrastColour(contrastColour);

            kwlBaseColourHeader.Text = baseColourHeader;

            kwlContrastColourHeader.Text = contrastColourHeader;

            ShowPaletteButtons(showPaletteButton);
        }
        #endregion

        #region Setters and Getters
        /// <summary>
        /// Sets the AutomateContrastColour.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetAutomateContrastColour(bool value) => AutomateContrastColour = value;

        /// <summary>
        /// Gets the AutomateContrastColour.
        /// </summary>
        /// <returns>The value of AutomateContrastColour.</returns>
        public bool GetAutomateContrastColour() => AutomateContrastColour;

        /// <summary>
        /// Sets the UseForPalettes.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetUseForPalettes(bool value) => UseForPalettes = value;

        /// <summary>
        /// Gets the UseForPalettes.
        /// </summary>
        /// <returns>The value of UseForPalettes.</returns>
        public bool GetUseForPalettes() => UseForPalettes;

        /// <summary>
        /// Sets the KeepOpacityValues.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetKeepOpacityValues(bool value) => KeepOpacityValues = value;

        /// <summary>
        /// Gets the KeepOpacityValues.
        /// </summary>
        /// <returns>The value of KeepOpacityValues.</returns>
        public bool GetKeepOpacityValues() => KeepOpacityValues;

        /// <summary>
        /// Sets the BaseColour.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetBaseColour(Color value) => BaseColour = value;

        /// <summary>
        /// Gets the BaseColour.
        /// </summary>
        /// <returns>The value of BaseColour.</returns>
        public Color GetBaseColour() => BaseColour;

        /// <summary>
        /// Sets the ContrastColour.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetContrastColour(Color value) => ContrastColour = value;

        /// <summary>
        /// Gets the ContrastColour.
        /// </summary>
        /// <returns>The value of ContrastColour.</returns>
        public Color GetContrastColour() => ContrastColour;
        #endregion
    }
}