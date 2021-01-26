using Krypton.Toolkit.Suite.Extended.Core;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Palette.Controls
{
    public class PaletteDesignerCircularUserControl : UserControl
    {
        #region Design Code
        private Suite.Extended.Base.CircularPictureBox cpbxBaseColour;
        private Suite.Extended.Base.CircularPictureBox cpbxMediumColour;
        private Suite.Extended.Base.CircularPictureBox cpbxLightColour;
        private Suite.Extended.Base.CircularPictureBox cpbxLightestColour;
        private Suite.Extended.Base.CircularPictureBox cpbxBorderColour;
        private Suite.Extended.Base.CircularPictureBox cpbxAlternativeNormalTextColour;
        private Suite.Extended.Base.CircularPictureBox cpbxNormalTextColour;
        private Suite.Extended.Base.CircularPictureBox cpbxDisabledTextColour;
        private Suite.Extended.Base.CircularPictureBox cpbxFocusedTextColour;
        private Suite.Extended.Base.CircularPictureBox cpbxPressedTextColour;
        private Suite.Extended.Base.CircularPictureBox cpbxDisabledControlColour;
        private Suite.Extended.Base.CircularPictureBox cpbxLinkNormalColour;
        private Suite.Extended.Base.CircularPictureBox cpbxLinkFocusedColour;
        private Suite.Extended.Base.CircularPictureBox cpbxStatusTextColour;
        private Suite.Extended.Base.CircularPictureBox cpbxMenuTextColour;
        private Suite.Extended.Base.CircularPictureBox cpbxCustomTextColourFive;
        private Suite.Extended.Base.CircularPictureBox cpbxCustomTextColourFour;
        private Suite.Extended.Base.CircularPictureBox cpbxCustomTextColourThree;
        private Suite.Extended.Base.CircularPictureBox cpbxCustomTextColourTwo;
        private Suite.Extended.Base.CircularPictureBox cpbxCustomTextColourOne;
        private Suite.Extended.Base.CircularPictureBox cpbxCustomColourFive;
        private Suite.Extended.Base.CircularPictureBox cpbxCustomColourFour;
        private Suite.Extended.Base.CircularPictureBox cpbxCustomColourThree;
        private Suite.Extended.Base.CircularPictureBox cpbxCustomColourTwo;
        private Suite.Extended.Base.CircularPictureBox cpbxCustomColourOne;
        private Suite.Extended.Base.CircularPictureBox cpbxLinkVisitedColour;
        private Suite.Extended.Base.CircularPictureBox cpbxLinkHoverColour;
        private Suite.Extended.Base.CircularPictureBox cbpxDisabledTextColour;
        private Suite.Extended.Base.CircularPictureBox circularPictureBox30;
        private Suite.Extended.Base.CircularPictureBox circularPictureBox31;
        private Suite.Extended.Base.CircularPictureBox circularPictureBox32;
        private Suite.Extended.Base.CircularPictureBox circularPictureBox33;
        private Suite.Extended.Base.CircularPictureBox circularPictureBox34;
        private Suite.Extended.Base.CircularPictureBox circularPictureBox35;
        private Suite.Extended.Base.CircularPictureBox circularPictureBox36;
        private Suite.Extended.Base.CircularPictureBox circularPictureBox37;
        private Suite.Extended.Base.CircularPictureBox circularPictureBox38;
        private Suite.Extended.Base.CircularPictureBox circularPictureBox39;
        private Suite.Extended.Base.CircularPictureBox circularPictureBox40;
        private Suite.Extended.Base.CircularPictureBox circularPictureBox41;
        private Suite.Extended.Base.CircularPictureBox cpbxRibbonTabTextColour;
        private ToolTip ttColourInformation;
        private System.ComponentModel.IContainer components;
        private KryptonPalette internalPalette;
        private ContextMenuStrip cmsBaseColour;
        private ToolStripMenuItem useAsBaseColourToolStripMenuItem;
        private ContextMenuStrip cmsDarkColour;
        private ToolStripMenuItem toolStripMenuItem1;
        private ContextMenuStrip cmsLightColour;
        private ToolStripMenuItem toolStripMenuItem2;
        private ContextMenuStrip cmsLightestColour;
        private ToolStripMenuItem toolStripMenuItem3;
        private ContextMenuStrip cmsBorderColour;
        private ToolStripMenuItem toolStripMenuItem4;
        private ContextMenuStrip cmsAlternativeNormalTextColour;
        private ToolStripMenuItem toolStripMenuItem5;
        private ContextMenuStrip cmsNormalTextColour;
        private ToolStripMenuItem toolStripMenuItem6;
        private ContextMenuStrip cmsDisabledTextColour;
        private ToolStripMenuItem toolStripMenuItem7;
        private ContextMenuStrip cmsFocusedTextColour;
        private ToolStripMenuItem toolStripMenuItem8;
        private ContextMenuStrip cmsPressedTextColour;
        private ToolStripMenuItem toolStripMenuItem9;
        private ContextMenuStrip cmsDisabledControlColour;
        private ToolStripMenuItem toolStripMenuItem10;
        private ContextMenuStrip cmsLinkNormalColour;
        private ToolStripMenuItem toolStripMenuItem11;
        private ContextMenuStrip cmsLinkFocusedColour;
        private ToolStripMenuItem toolStripMenuItem12;
        private ContextMenuStrip cmsLinkHoverColour;
        private ToolStripMenuItem toolStripMenuItem13;
        private ContextMenuStrip cmsLinkVisitedColour;
        private ToolStripMenuItem toolStripMenuItem14;
        private ContextMenuStrip cmsCustomColourOne;
        private ToolStripMenuItem toolStripMenuItem15;
        private ContextMenuStrip cmsCustomColourTwo;
        private ToolStripMenuItem toolStripMenuItem16;
        private ContextMenuStrip cmsCustomColourThree;
        private ToolStripMenuItem toolStripMenuItem17;
        private ContextMenuStrip cmscmsCustomColourFour;
        private ToolStripMenuItem toolStripMenuItem18;
        private ContextMenuStrip cmscmsCustomColourFive;
        private ToolStripMenuItem toolStripMenuItem19;
        private ContextMenuStrip cmsCustomTextColourOne;
        private ToolStripMenuItem toolStripMenuItem20;
        private ContextMenuStrip cmsCustomTextColourTwo;
        private ToolStripMenuItem toolStripMenuItem21;
        private ContextMenuStrip cmsCustomTextColourThree;
        private ToolStripMenuItem toolStripMenuItem22;
        private ContextMenuStrip cmsCustomTextColourFour;
        private ToolStripMenuItem toolStripMenuItem23;
        private ContextMenuStrip cmsCustomTextColourFive;
        private ToolStripMenuItem toolStripMenuItem24;
        private ContextMenuStrip cmsMenuTextColour;
        private ToolStripMenuItem toolStripMenuItem25;
        private ContextMenuStrip cmsStatusTextColour;
        private ToolStripMenuItem toolStripMenuItem26;
        private ContextMenuStrip cmsRibbonTabTextColour;
        private ToolStripMenuItem toolStripMenuItem27;
        private ContextMenuStrip contextMenuStrip29;
        private ToolStripMenuItem toolStripMenuItem28;
        private Suite.Extended.Base.CircularPictureBox cpbxDarkColour;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cpbxBaseColour = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cpbxDarkColour = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cpbxMediumColour = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cpbxLightColour = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cpbxLightestColour = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cpbxBorderColour = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cpbxAlternativeNormalTextColour = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cpbxNormalTextColour = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cpbxDisabledTextColour = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cpbxFocusedTextColour = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cpbxPressedTextColour = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cpbxDisabledControlColour = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cpbxLinkNormalColour = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cpbxLinkFocusedColour = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cpbxStatusTextColour = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cpbxMenuTextColour = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cpbxCustomTextColourFive = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cpbxCustomTextColourFour = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cpbxCustomTextColourThree = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cpbxCustomTextColourTwo = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cpbxCustomTextColourOne = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cpbxCustomColourFive = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cpbxCustomColourFour = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cpbxCustomColourThree = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cpbxCustomColourTwo = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cpbxCustomColourOne = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cpbxLinkVisitedColour = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cpbxLinkHoverColour = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cbpxDisabledTextColour = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.circularPictureBox30 = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.circularPictureBox31 = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.circularPictureBox32 = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.circularPictureBox33 = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.circularPictureBox34 = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.circularPictureBox35 = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.circularPictureBox36 = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.circularPictureBox37 = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.circularPictureBox38 = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.circularPictureBox39 = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.circularPictureBox40 = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.circularPictureBox41 = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cpbxRibbonTabTextColour = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.ttColourInformation = new System.Windows.Forms.ToolTip(this.components);
            this.internalPalette = new Krypton.Toolkit.KryptonPalette(this.components);
            this.cmsBaseColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.useAsBaseColourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDarkColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsLightColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsLightestColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsBorderColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsAlternativeNormalTextColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsNormalTextColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDisabledTextColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsFocusedTextColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsPressedTextColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDisabledControlColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsLinkNormalColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsLinkFocusedColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsLinkHoverColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsLinkVisitedColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCustomColourOne = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem15 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCustomColourTwo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem16 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCustomColourThree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem17 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmscmsCustomColourFour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem18 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmscmsCustomColourFive = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem19 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCustomTextColourOne = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem20 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCustomTextColourTwo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem21 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCustomTextColourThree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem22 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCustomTextColourFour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem23 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCustomTextColourFive = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem24 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsMenuTextColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem25 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsStatusTextColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem26 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRibbonTabTextColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem27 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip29 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem28 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxBaseColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxDarkColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxMediumColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxLightColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxLightestColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxBorderColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxAlternativeNormalTextColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxNormalTextColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxDisabledTextColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxFocusedTextColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxPressedTextColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxDisabledControlColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxLinkNormalColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxLinkFocusedColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxStatusTextColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxMenuTextColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxCustomTextColourFive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxCustomTextColourFour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxCustomTextColourThree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxCustomTextColourTwo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxCustomTextColourOne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxCustomColourFive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxCustomColourFour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxCustomColourThree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxCustomColourTwo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxCustomColourOne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxLinkVisitedColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxLinkHoverColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbpxDisabledTextColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxRibbonTabTextColour)).BeginInit();
            this.cmsBaseColour.SuspendLayout();
            this.cmsDarkColour.SuspendLayout();
            this.cmsLightColour.SuspendLayout();
            this.cmsLightestColour.SuspendLayout();
            this.cmsBorderColour.SuspendLayout();
            this.cmsAlternativeNormalTextColour.SuspendLayout();
            this.cmsNormalTextColour.SuspendLayout();
            this.cmsDisabledTextColour.SuspendLayout();
            this.cmsFocusedTextColour.SuspendLayout();
            this.cmsPressedTextColour.SuspendLayout();
            this.cmsDisabledControlColour.SuspendLayout();
            this.cmsLinkNormalColour.SuspendLayout();
            this.cmsLinkFocusedColour.SuspendLayout();
            this.cmsLinkHoverColour.SuspendLayout();
            this.cmsLinkVisitedColour.SuspendLayout();
            this.cmsCustomColourOne.SuspendLayout();
            this.cmsCustomColourTwo.SuspendLayout();
            this.cmsCustomColourThree.SuspendLayout();
            this.cmscmsCustomColourFour.SuspendLayout();
            this.cmscmsCustomColourFive.SuspendLayout();
            this.cmsCustomTextColourOne.SuspendLayout();
            this.cmsCustomTextColourTwo.SuspendLayout();
            this.cmsCustomTextColourThree.SuspendLayout();
            this.cmsCustomTextColourFour.SuspendLayout();
            this.cmsCustomTextColourFive.SuspendLayout();
            this.cmsMenuTextColour.SuspendLayout();
            this.cmsStatusTextColour.SuspendLayout();
            this.cmsRibbonTabTextColour.SuspendLayout();
            this.contextMenuStrip29.SuspendLayout();
            this.SuspendLayout();
            // 
            // cpbxBaseColour
            // 
            this.cpbxBaseColour.BackColor = System.Drawing.Color.White;
            this.cpbxBaseColour.Location = new System.Drawing.Point(13, 13);
            this.cpbxBaseColour.Name = "cpbxBaseColour";
            this.cpbxBaseColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxBaseColour.TabIndex = 0;
            this.cpbxBaseColour.TabStop = false;
            this.cpbxBaseColour.ToolTipValues = null;
            // 
            // cpbxDarkColour
            // 
            this.cpbxDarkColour.BackColor = System.Drawing.Color.White;
            this.cpbxDarkColour.Location = new System.Drawing.Point(95, 13);
            this.cpbxDarkColour.Name = "cpbxDarkColour";
            this.cpbxDarkColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxDarkColour.TabIndex = 1;
            this.cpbxDarkColour.TabStop = false;
            this.cpbxDarkColour.ToolTipValues = null;
            // 
            // cpbxMediumColour
            // 
            this.cpbxMediumColour.BackColor = System.Drawing.Color.White;
            this.cpbxMediumColour.Location = new System.Drawing.Point(177, 13);
            this.cpbxMediumColour.Name = "cpbxMediumColour";
            this.cpbxMediumColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxMediumColour.TabIndex = 2;
            this.cpbxMediumColour.TabStop = false;
            this.cpbxMediumColour.ToolTipValues = null;
            // 
            // cpbxLightColour
            // 
            this.cpbxLightColour.BackColor = System.Drawing.Color.White;
            this.cpbxLightColour.Location = new System.Drawing.Point(259, 13);
            this.cpbxLightColour.Name = "cpbxLightColour";
            this.cpbxLightColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxLightColour.TabIndex = 3;
            this.cpbxLightColour.TabStop = false;
            this.cpbxLightColour.ToolTipValues = null;
            // 
            // cpbxLightestColour
            // 
            this.cpbxLightestColour.BackColor = System.Drawing.Color.White;
            this.cpbxLightestColour.Location = new System.Drawing.Point(341, 13);
            this.cpbxLightestColour.Name = "cpbxLightestColour";
            this.cpbxLightestColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxLightestColour.TabIndex = 4;
            this.cpbxLightestColour.TabStop = false;
            this.cpbxLightestColour.ToolTipValues = null;
            // 
            // cpbxBorderColour
            // 
            this.cpbxBorderColour.BackColor = System.Drawing.Color.White;
            this.cpbxBorderColour.Location = new System.Drawing.Point(423, 13);
            this.cpbxBorderColour.Name = "cpbxBorderColour";
            this.cpbxBorderColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxBorderColour.TabIndex = 5;
            this.cpbxBorderColour.TabStop = false;
            this.cpbxBorderColour.ToolTipValues = null;
            // 
            // cpbxAlternativeNormalTextColour
            // 
            this.cpbxAlternativeNormalTextColour.BackColor = System.Drawing.Color.White;
            this.cpbxAlternativeNormalTextColour.Location = new System.Drawing.Point(505, 13);
            this.cpbxAlternativeNormalTextColour.Name = "cpbxAlternativeNormalTextColour";
            this.cpbxAlternativeNormalTextColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxAlternativeNormalTextColour.TabIndex = 6;
            this.cpbxAlternativeNormalTextColour.TabStop = false;
            this.cpbxAlternativeNormalTextColour.ToolTipValues = null;
            // 
            // cpbxNormalTextColour
            // 
            this.cpbxNormalTextColour.BackColor = System.Drawing.Color.White;
            this.cpbxNormalTextColour.Location = new System.Drawing.Point(587, 13);
            this.cpbxNormalTextColour.Name = "cpbxNormalTextColour";
            this.cpbxNormalTextColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxNormalTextColour.TabIndex = 7;
            this.cpbxNormalTextColour.TabStop = false;
            this.cpbxNormalTextColour.ToolTipValues = null;
            // 
            // cpbxDisabledTextColour
            // 
            this.cpbxDisabledTextColour.BackColor = System.Drawing.Color.White;
            this.cpbxDisabledTextColour.Location = new System.Drawing.Point(669, 13);
            this.cpbxDisabledTextColour.Name = "cpbxDisabledTextColour";
            this.cpbxDisabledTextColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxDisabledTextColour.TabIndex = 8;
            this.cpbxDisabledTextColour.TabStop = false;
            this.cpbxDisabledTextColour.ToolTipValues = null;
            // 
            // cpbxFocusedTextColour
            // 
            this.cpbxFocusedTextColour.BackColor = System.Drawing.Color.White;
            this.cpbxFocusedTextColour.Location = new System.Drawing.Point(751, 13);
            this.cpbxFocusedTextColour.Name = "cpbxFocusedTextColour";
            this.cpbxFocusedTextColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxFocusedTextColour.TabIndex = 9;
            this.cpbxFocusedTextColour.TabStop = false;
            this.cpbxFocusedTextColour.ToolTipValues = null;
            // 
            // cpbxPressedTextColour
            // 
            this.cpbxPressedTextColour.BackColor = System.Drawing.Color.White;
            this.cpbxPressedTextColour.Location = new System.Drawing.Point(833, 13);
            this.cpbxPressedTextColour.Name = "cpbxPressedTextColour";
            this.cpbxPressedTextColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxPressedTextColour.TabIndex = 10;
            this.cpbxPressedTextColour.TabStop = false;
            this.cpbxPressedTextColour.ToolTipValues = null;
            // 
            // cpbxDisabledControlColour
            // 
            this.cpbxDisabledControlColour.BackColor = System.Drawing.Color.White;
            this.cpbxDisabledControlColour.Location = new System.Drawing.Point(915, 13);
            this.cpbxDisabledControlColour.Name = "cpbxDisabledControlColour";
            this.cpbxDisabledControlColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxDisabledControlColour.TabIndex = 11;
            this.cpbxDisabledControlColour.TabStop = false;
            this.cpbxDisabledControlColour.ToolTipValues = null;
            // 
            // cpbxLinkNormalColour
            // 
            this.cpbxLinkNormalColour.BackColor = System.Drawing.Color.White;
            this.cpbxLinkNormalColour.Location = new System.Drawing.Point(997, 13);
            this.cpbxLinkNormalColour.Name = "cpbxLinkNormalColour";
            this.cpbxLinkNormalColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxLinkNormalColour.TabIndex = 12;
            this.cpbxLinkNormalColour.TabStop = false;
            this.cpbxLinkNormalColour.ToolTipValues = null;
            // 
            // cpbxLinkFocusedColour
            // 
            this.cpbxLinkFocusedColour.BackColor = System.Drawing.Color.White;
            this.cpbxLinkFocusedColour.Location = new System.Drawing.Point(1079, 13);
            this.cpbxLinkFocusedColour.Name = "cpbxLinkFocusedColour";
            this.cpbxLinkFocusedColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxLinkFocusedColour.TabIndex = 13;
            this.cpbxLinkFocusedColour.TabStop = false;
            this.cpbxLinkFocusedColour.ToolTipValues = null;
            // 
            // cpbxStatusTextColour
            // 
            this.cpbxStatusTextColour.BackColor = System.Drawing.Color.White;
            this.cpbxStatusTextColour.Location = new System.Drawing.Point(1079, 165);
            this.cpbxStatusTextColour.Name = "cpbxStatusTextColour";
            this.cpbxStatusTextColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxStatusTextColour.TabIndex = 27;
            this.cpbxStatusTextColour.TabStop = false;
            this.cpbxStatusTextColour.ToolTipValues = null;
            // 
            // cpbxMenuTextColour
            // 
            this.cpbxMenuTextColour.BackColor = System.Drawing.Color.White;
            this.cpbxMenuTextColour.Location = new System.Drawing.Point(997, 165);
            this.cpbxMenuTextColour.Name = "cpbxMenuTextColour";
            this.cpbxMenuTextColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxMenuTextColour.TabIndex = 26;
            this.cpbxMenuTextColour.TabStop = false;
            this.cpbxMenuTextColour.ToolTipValues = null;
            // 
            // cpbxCustomTextColourFive
            // 
            this.cpbxCustomTextColourFive.BackColor = System.Drawing.Color.White;
            this.cpbxCustomTextColourFive.Location = new System.Drawing.Point(915, 165);
            this.cpbxCustomTextColourFive.Name = "cpbxCustomTextColourFive";
            this.cpbxCustomTextColourFive.Size = new System.Drawing.Size(64, 64);
            this.cpbxCustomTextColourFive.TabIndex = 25;
            this.cpbxCustomTextColourFive.TabStop = false;
            this.cpbxCustomTextColourFive.ToolTipValues = null;
            // 
            // cpbxCustomTextColourFour
            // 
            this.cpbxCustomTextColourFour.BackColor = System.Drawing.Color.White;
            this.cpbxCustomTextColourFour.Location = new System.Drawing.Point(833, 165);
            this.cpbxCustomTextColourFour.Name = "cpbxCustomTextColourFour";
            this.cpbxCustomTextColourFour.Size = new System.Drawing.Size(64, 64);
            this.cpbxCustomTextColourFour.TabIndex = 24;
            this.cpbxCustomTextColourFour.TabStop = false;
            this.cpbxCustomTextColourFour.ToolTipValues = null;
            // 
            // cpbxCustomTextColourThree
            // 
            this.cpbxCustomTextColourThree.BackColor = System.Drawing.Color.White;
            this.cpbxCustomTextColourThree.Location = new System.Drawing.Point(751, 165);
            this.cpbxCustomTextColourThree.Name = "cpbxCustomTextColourThree";
            this.cpbxCustomTextColourThree.Size = new System.Drawing.Size(64, 64);
            this.cpbxCustomTextColourThree.TabIndex = 23;
            this.cpbxCustomTextColourThree.TabStop = false;
            this.cpbxCustomTextColourThree.ToolTipValues = null;
            // 
            // cpbxCustomTextColourTwo
            // 
            this.cpbxCustomTextColourTwo.BackColor = System.Drawing.Color.White;
            this.cpbxCustomTextColourTwo.Location = new System.Drawing.Point(669, 165);
            this.cpbxCustomTextColourTwo.Name = "cpbxCustomTextColourTwo";
            this.cpbxCustomTextColourTwo.Size = new System.Drawing.Size(64, 64);
            this.cpbxCustomTextColourTwo.TabIndex = 22;
            this.cpbxCustomTextColourTwo.TabStop = false;
            this.cpbxCustomTextColourTwo.ToolTipValues = null;
            // 
            // cpbxCustomTextColourOne
            // 
            this.cpbxCustomTextColourOne.BackColor = System.Drawing.Color.White;
            this.cpbxCustomTextColourOne.Location = new System.Drawing.Point(587, 165);
            this.cpbxCustomTextColourOne.Name = "cpbxCustomTextColourOne";
            this.cpbxCustomTextColourOne.Size = new System.Drawing.Size(64, 64);
            this.cpbxCustomTextColourOne.TabIndex = 21;
            this.cpbxCustomTextColourOne.TabStop = false;
            this.cpbxCustomTextColourOne.ToolTipValues = null;
            // 
            // cpbxCustomColourFive
            // 
            this.cpbxCustomColourFive.BackColor = System.Drawing.Color.White;
            this.cpbxCustomColourFive.Location = new System.Drawing.Point(505, 165);
            this.cpbxCustomColourFive.Name = "cpbxCustomColourFive";
            this.cpbxCustomColourFive.Size = new System.Drawing.Size(64, 64);
            this.cpbxCustomColourFive.TabIndex = 20;
            this.cpbxCustomColourFive.TabStop = false;
            this.cpbxCustomColourFive.ToolTipValues = null;
            // 
            // cpbxCustomColourFour
            // 
            this.cpbxCustomColourFour.BackColor = System.Drawing.Color.White;
            this.cpbxCustomColourFour.Location = new System.Drawing.Point(423, 165);
            this.cpbxCustomColourFour.Name = "cpbxCustomColourFour";
            this.cpbxCustomColourFour.Size = new System.Drawing.Size(64, 64);
            this.cpbxCustomColourFour.TabIndex = 19;
            this.cpbxCustomColourFour.TabStop = false;
            this.cpbxCustomColourFour.ToolTipValues = null;
            // 
            // cpbxCustomColourThree
            // 
            this.cpbxCustomColourThree.BackColor = System.Drawing.Color.White;
            this.cpbxCustomColourThree.Location = new System.Drawing.Point(341, 165);
            this.cpbxCustomColourThree.Name = "cpbxCustomColourThree";
            this.cpbxCustomColourThree.Size = new System.Drawing.Size(64, 64);
            this.cpbxCustomColourThree.TabIndex = 18;
            this.cpbxCustomColourThree.TabStop = false;
            this.cpbxCustomColourThree.ToolTipValues = null;
            // 
            // cpbxCustomColourTwo
            // 
            this.cpbxCustomColourTwo.BackColor = System.Drawing.Color.White;
            this.cpbxCustomColourTwo.Location = new System.Drawing.Point(259, 165);
            this.cpbxCustomColourTwo.Name = "cpbxCustomColourTwo";
            this.cpbxCustomColourTwo.Size = new System.Drawing.Size(64, 64);
            this.cpbxCustomColourTwo.TabIndex = 17;
            this.cpbxCustomColourTwo.TabStop = false;
            this.cpbxCustomColourTwo.ToolTipValues = null;
            // 
            // cpbxCustomColourOne
            // 
            this.cpbxCustomColourOne.BackColor = System.Drawing.Color.White;
            this.cpbxCustomColourOne.Location = new System.Drawing.Point(177, 165);
            this.cpbxCustomColourOne.Name = "cpbxCustomColourOne";
            this.cpbxCustomColourOne.Size = new System.Drawing.Size(64, 64);
            this.cpbxCustomColourOne.TabIndex = 16;
            this.cpbxCustomColourOne.TabStop = false;
            this.cpbxCustomColourOne.ToolTipValues = null;
            // 
            // cpbxLinkVisitedColour
            // 
            this.cpbxLinkVisitedColour.BackColor = System.Drawing.Color.White;
            this.cpbxLinkVisitedColour.Location = new System.Drawing.Point(95, 165);
            this.cpbxLinkVisitedColour.Name = "cpbxLinkVisitedColour";
            this.cpbxLinkVisitedColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxLinkVisitedColour.TabIndex = 15;
            this.cpbxLinkVisitedColour.TabStop = false;
            this.cpbxLinkVisitedColour.ToolTipValues = null;
            // 
            // cpbxLinkHoverColour
            // 
            this.cpbxLinkHoverColour.BackColor = System.Drawing.Color.White;
            this.cpbxLinkHoverColour.Location = new System.Drawing.Point(13, 165);
            this.cpbxLinkHoverColour.Name = "cpbxLinkHoverColour";
            this.cpbxLinkHoverColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxLinkHoverColour.TabIndex = 14;
            this.cpbxLinkHoverColour.TabStop = false;
            this.cpbxLinkHoverColour.ToolTipValues = null;
            // 
            // cbpxDisabledTextColour
            // 
            this.cbpxDisabledTextColour.BackColor = System.Drawing.Color.White;
            this.cbpxDisabledTextColour.Location = new System.Drawing.Point(1079, 318);
            this.cbpxDisabledTextColour.Name = "cbpxDisabledTextColour";
            this.cbpxDisabledTextColour.Size = new System.Drawing.Size(64, 64);
            this.cbpxDisabledTextColour.TabIndex = 41;
            this.cbpxDisabledTextColour.TabStop = false;
            this.cbpxDisabledTextColour.ToolTipValues = null;
            this.cbpxDisabledTextColour.Visible = false;
            // 
            // circularPictureBox30
            // 
            this.circularPictureBox30.BackColor = System.Drawing.Color.White;
            this.circularPictureBox30.Location = new System.Drawing.Point(997, 318);
            this.circularPictureBox30.Name = "circularPictureBox30";
            this.circularPictureBox30.Size = new System.Drawing.Size(64, 64);
            this.circularPictureBox30.TabIndex = 40;
            this.circularPictureBox30.TabStop = false;
            this.circularPictureBox30.ToolTipValues = null;
            this.circularPictureBox30.Visible = false;
            // 
            // circularPictureBox31
            // 
            this.circularPictureBox31.BackColor = System.Drawing.Color.White;
            this.circularPictureBox31.Location = new System.Drawing.Point(915, 318);
            this.circularPictureBox31.Name = "circularPictureBox31";
            this.circularPictureBox31.Size = new System.Drawing.Size(64, 64);
            this.circularPictureBox31.TabIndex = 39;
            this.circularPictureBox31.TabStop = false;
            this.circularPictureBox31.ToolTipValues = null;
            this.circularPictureBox31.Visible = false;
            // 
            // circularPictureBox32
            // 
            this.circularPictureBox32.BackColor = System.Drawing.Color.White;
            this.circularPictureBox32.Location = new System.Drawing.Point(833, 318);
            this.circularPictureBox32.Name = "circularPictureBox32";
            this.circularPictureBox32.Size = new System.Drawing.Size(64, 64);
            this.circularPictureBox32.TabIndex = 38;
            this.circularPictureBox32.TabStop = false;
            this.circularPictureBox32.ToolTipValues = null;
            this.circularPictureBox32.Visible = false;
            // 
            // circularPictureBox33
            // 
            this.circularPictureBox33.BackColor = System.Drawing.Color.White;
            this.circularPictureBox33.Location = new System.Drawing.Point(751, 318);
            this.circularPictureBox33.Name = "circularPictureBox33";
            this.circularPictureBox33.Size = new System.Drawing.Size(64, 64);
            this.circularPictureBox33.TabIndex = 37;
            this.circularPictureBox33.TabStop = false;
            this.circularPictureBox33.ToolTipValues = null;
            this.circularPictureBox33.Visible = false;
            // 
            // circularPictureBox34
            // 
            this.circularPictureBox34.BackColor = System.Drawing.Color.White;
            this.circularPictureBox34.Location = new System.Drawing.Point(669, 318);
            this.circularPictureBox34.Name = "circularPictureBox34";
            this.circularPictureBox34.Size = new System.Drawing.Size(64, 64);
            this.circularPictureBox34.TabIndex = 36;
            this.circularPictureBox34.TabStop = false;
            this.circularPictureBox34.ToolTipValues = null;
            this.circularPictureBox34.Visible = false;
            // 
            // circularPictureBox35
            // 
            this.circularPictureBox35.BackColor = System.Drawing.Color.White;
            this.circularPictureBox35.Location = new System.Drawing.Point(587, 318);
            this.circularPictureBox35.Name = "circularPictureBox35";
            this.circularPictureBox35.Size = new System.Drawing.Size(64, 64);
            this.circularPictureBox35.TabIndex = 35;
            this.circularPictureBox35.TabStop = false;
            this.circularPictureBox35.ToolTipValues = null;
            this.circularPictureBox35.Visible = false;
            // 
            // circularPictureBox36
            // 
            this.circularPictureBox36.BackColor = System.Drawing.Color.White;
            this.circularPictureBox36.Location = new System.Drawing.Point(505, 318);
            this.circularPictureBox36.Name = "circularPictureBox36";
            this.circularPictureBox36.Size = new System.Drawing.Size(64, 64);
            this.circularPictureBox36.TabIndex = 34;
            this.circularPictureBox36.TabStop = false;
            this.circularPictureBox36.ToolTipValues = null;
            this.circularPictureBox36.Visible = false;
            // 
            // circularPictureBox37
            // 
            this.circularPictureBox37.BackColor = System.Drawing.Color.White;
            this.circularPictureBox37.Location = new System.Drawing.Point(423, 318);
            this.circularPictureBox37.Name = "circularPictureBox37";
            this.circularPictureBox37.Size = new System.Drawing.Size(64, 64);
            this.circularPictureBox37.TabIndex = 33;
            this.circularPictureBox37.TabStop = false;
            this.circularPictureBox37.ToolTipValues = null;
            this.circularPictureBox37.Visible = false;
            // 
            // circularPictureBox38
            // 
            this.circularPictureBox38.BackColor = System.Drawing.Color.White;
            this.circularPictureBox38.Location = new System.Drawing.Point(341, 318);
            this.circularPictureBox38.Name = "circularPictureBox38";
            this.circularPictureBox38.Size = new System.Drawing.Size(64, 64);
            this.circularPictureBox38.TabIndex = 32;
            this.circularPictureBox38.TabStop = false;
            this.circularPictureBox38.ToolTipValues = null;
            this.circularPictureBox38.Visible = false;
            // 
            // circularPictureBox39
            // 
            this.circularPictureBox39.BackColor = System.Drawing.Color.White;
            this.circularPictureBox39.Location = new System.Drawing.Point(259, 318);
            this.circularPictureBox39.Name = "circularPictureBox39";
            this.circularPictureBox39.Size = new System.Drawing.Size(64, 64);
            this.circularPictureBox39.TabIndex = 31;
            this.circularPictureBox39.TabStop = false;
            this.circularPictureBox39.ToolTipValues = null;
            this.circularPictureBox39.Visible = false;
            // 
            // circularPictureBox40
            // 
            this.circularPictureBox40.BackColor = System.Drawing.Color.White;
            this.circularPictureBox40.Location = new System.Drawing.Point(177, 318);
            this.circularPictureBox40.Name = "circularPictureBox40";
            this.circularPictureBox40.Size = new System.Drawing.Size(64, 64);
            this.circularPictureBox40.TabIndex = 30;
            this.circularPictureBox40.TabStop = false;
            this.circularPictureBox40.ToolTipValues = null;
            this.circularPictureBox40.Visible = false;
            // 
            // circularPictureBox41
            // 
            this.circularPictureBox41.BackColor = System.Drawing.Color.White;
            this.circularPictureBox41.Location = new System.Drawing.Point(95, 318);
            this.circularPictureBox41.Name = "circularPictureBox41";
            this.circularPictureBox41.Size = new System.Drawing.Size(64, 64);
            this.circularPictureBox41.TabIndex = 29;
            this.circularPictureBox41.TabStop = false;
            this.circularPictureBox41.ToolTipValues = null;
            this.circularPictureBox41.Visible = false;
            // 
            // cpbxRibbonTabTextColour
            // 
            this.cpbxRibbonTabTextColour.BackColor = System.Drawing.Color.White;
            this.cpbxRibbonTabTextColour.Location = new System.Drawing.Point(13, 317);
            this.cpbxRibbonTabTextColour.Name = "cpbxRibbonTabTextColour";
            this.cpbxRibbonTabTextColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxRibbonTabTextColour.TabIndex = 28;
            this.cpbxRibbonTabTextColour.TabStop = false;
            this.cpbxRibbonTabTextColour.ToolTipValues = null;
            // 
            // internalPalette
            // 
            this.internalPalette.CustomisedKryptonPaletteFilePath = null;
            // 
            // cmsBaseColour
            // 
            this.cmsBaseColour.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsBaseColour.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.useAsBaseColourToolStripMenuItem});
            this.cmsBaseColour.Name = "cmsBaseColour";
            this.cmsBaseColour.Size = new System.Drawing.Size(174, 26);
            // 
            // useAsBaseColourToolStripMenuItem
            // 
            this.useAsBaseColourToolStripMenuItem.Name = "useAsBaseColourToolStripMenuItem";
            this.useAsBaseColourToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.useAsBaseColourToolStripMenuItem.Text = "Use as &Base Colour";
            // 
            // cmsDarkColour
            // 
            this.cmsDarkColour.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsDarkColour.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.cmsDarkColour.Name = "contextMenuStrip1";
            this.cmsDarkColour.Size = new System.Drawing.Size(174, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItem1.Text = "Use as &Base Colour";
            // 
            // cmsLightColour
            // 
            this.cmsLightColour.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsLightColour.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.cmsLightColour.Name = "contextMenuStrip1";
            this.cmsLightColour.Size = new System.Drawing.Size(174, 26);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItem2.Text = "Use as &Base Colour";
            // 
            // cmsLightestColour
            // 
            this.cmsLightestColour.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsLightestColour.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3});
            this.cmsLightestColour.Name = "contextMenuStrip1";
            this.cmsLightestColour.Size = new System.Drawing.Size(174, 26);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItem3.Text = "Use as &Base Colour";
            // 
            // cmsBorderColour
            // 
            this.cmsBorderColour.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsBorderColour.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4});
            this.cmsBorderColour.Name = "contextMenuStrip1";
            this.cmsBorderColour.Size = new System.Drawing.Size(174, 26);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItem4.Text = "Use as &Base Colour";
            // 
            // cmsAlternativeNormalTextColour
            // 
            this.cmsAlternativeNormalTextColour.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsAlternativeNormalTextColour.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem5});
            this.cmsAlternativeNormalTextColour.Name = "contextMenuStrip1";
            this.cmsAlternativeNormalTextColour.Size = new System.Drawing.Size(174, 26);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItem5.Text = "Use as &Base Colour";
            // 
            // cmsNormalTextColour
            // 
            this.cmsNormalTextColour.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsNormalTextColour.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem6});
            this.cmsNormalTextColour.Name = "contextMenuStrip1";
            this.cmsNormalTextColour.Size = new System.Drawing.Size(174, 26);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItem6.Text = "Use as &Base Colour";
            // 
            // cmsDisabledTextColour
            // 
            this.cmsDisabledTextColour.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsDisabledTextColour.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem7});
            this.cmsDisabledTextColour.Name = "contextMenuStrip1";
            this.cmsDisabledTextColour.Size = new System.Drawing.Size(174, 26);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItem7.Text = "Use as &Base Colour";
            // 
            // cmsFocusedTextColour
            // 
            this.cmsFocusedTextColour.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsFocusedTextColour.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem8});
            this.cmsFocusedTextColour.Name = "contextMenuStrip1";
            this.cmsFocusedTextColour.Size = new System.Drawing.Size(174, 26);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItem8.Text = "Use as &Base Colour";
            // 
            // cmsPressedTextColour
            // 
            this.cmsPressedTextColour.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsPressedTextColour.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem9});
            this.cmsPressedTextColour.Name = "contextMenuStrip1";
            this.cmsPressedTextColour.Size = new System.Drawing.Size(174, 26);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItem9.Text = "Use as &Base Colour";
            // 
            // cmsDisabledControlColour
            // 
            this.cmsDisabledControlColour.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsDisabledControlColour.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem10});
            this.cmsDisabledControlColour.Name = "contextMenuStrip1";
            this.cmsDisabledControlColour.Size = new System.Drawing.Size(174, 26);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItem10.Text = "Use as &Base Colour";
            // 
            // cmsLinkNormalColour
            // 
            this.cmsLinkNormalColour.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsLinkNormalColour.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem11});
            this.cmsLinkNormalColour.Name = "contextMenuStrip1";
            this.cmsLinkNormalColour.Size = new System.Drawing.Size(174, 26);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItem11.Text = "Use as &Base Colour";
            // 
            // cmsLinkFocusedColour
            // 
            this.cmsLinkFocusedColour.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsLinkFocusedColour.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem12});
            this.cmsLinkFocusedColour.Name = "contextMenuStrip1";
            this.cmsLinkFocusedColour.Size = new System.Drawing.Size(174, 26);
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItem12.Text = "Use as &Base Colour";
            // 
            // cmsLinkHoverColour
            // 
            this.cmsLinkHoverColour.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsLinkHoverColour.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem13});
            this.cmsLinkHoverColour.Name = "contextMenuStrip1";
            this.cmsLinkHoverColour.Size = new System.Drawing.Size(174, 26);
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItem13.Text = "Use as &Base Colour";
            // 
            // cmsLinkVisitedColour
            // 
            this.cmsLinkVisitedColour.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsLinkVisitedColour.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem14});
            this.cmsLinkVisitedColour.Name = "contextMenuStrip1";
            this.cmsLinkVisitedColour.Size = new System.Drawing.Size(174, 26);
            // 
            // toolStripMenuItem14
            // 
            this.toolStripMenuItem14.Name = "toolStripMenuItem14";
            this.toolStripMenuItem14.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItem14.Text = "Use as &Base Colour";
            // 
            // cmsCustomColourOne
            // 
            this.cmsCustomColourOne.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsCustomColourOne.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem15});
            this.cmsCustomColourOne.Name = "contextMenuStrip1";
            this.cmsCustomColourOne.Size = new System.Drawing.Size(174, 26);
            // 
            // toolStripMenuItem15
            // 
            this.toolStripMenuItem15.Name = "toolStripMenuItem15";
            this.toolStripMenuItem15.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItem15.Text = "Use as &Base Colour";
            // 
            // cmsCustomColourTwo
            // 
            this.cmsCustomColourTwo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsCustomColourTwo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem16});
            this.cmsCustomColourTwo.Name = "contextMenuStrip1";
            this.cmsCustomColourTwo.Size = new System.Drawing.Size(174, 26);
            // 
            // toolStripMenuItem16
            // 
            this.toolStripMenuItem16.Name = "toolStripMenuItem16";
            this.toolStripMenuItem16.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItem16.Text = "Use as &Base Colour";
            // 
            // cmsCustomColourThree
            // 
            this.cmsCustomColourThree.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsCustomColourThree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem17});
            this.cmsCustomColourThree.Name = "contextMenuStrip1";
            this.cmsCustomColourThree.Size = new System.Drawing.Size(174, 26);
            // 
            // toolStripMenuItem17
            // 
            this.toolStripMenuItem17.Name = "toolStripMenuItem17";
            this.toolStripMenuItem17.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItem17.Text = "Use as &Base Colour";
            // 
            // cmscmsCustomColourFour
            // 
            this.cmscmsCustomColourFour.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmscmsCustomColourFour.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem18});
            this.cmscmsCustomColourFour.Name = "contextMenuStrip1";
            this.cmscmsCustomColourFour.Size = new System.Drawing.Size(174, 26);
            // 
            // toolStripMenuItem18
            // 
            this.toolStripMenuItem18.Name = "toolStripMenuItem18";
            this.toolStripMenuItem18.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItem18.Text = "Use as &Base Colour";
            // 
            // cmscmsCustomColourFive
            // 
            this.cmscmsCustomColourFive.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmscmsCustomColourFive.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem19});
            this.cmscmsCustomColourFive.Name = "contextMenuStrip1";
            this.cmscmsCustomColourFive.Size = new System.Drawing.Size(174, 26);
            // 
            // toolStripMenuItem19
            // 
            this.toolStripMenuItem19.Name = "toolStripMenuItem19";
            this.toolStripMenuItem19.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItem19.Text = "Use as &Base Colour";
            // 
            // cmsCustomTextColourOne
            // 
            this.cmsCustomTextColourOne.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsCustomTextColourOne.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem20});
            this.cmsCustomTextColourOne.Name = "contextMenuStrip1";
            this.cmsCustomTextColourOne.Size = new System.Drawing.Size(174, 26);
            // 
            // toolStripMenuItem20
            // 
            this.toolStripMenuItem20.Name = "toolStripMenuItem20";
            this.toolStripMenuItem20.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItem20.Text = "Use as &Base Colour";
            // 
            // cmsCustomTextColourTwo
            // 
            this.cmsCustomTextColourTwo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsCustomTextColourTwo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem21});
            this.cmsCustomTextColourTwo.Name = "contextMenuStrip1";
            this.cmsCustomTextColourTwo.Size = new System.Drawing.Size(174, 26);
            // 
            // toolStripMenuItem21
            // 
            this.toolStripMenuItem21.Name = "toolStripMenuItem21";
            this.toolStripMenuItem21.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItem21.Text = "Use as &Base Colour";
            // 
            // cmsCustomTextColourThree
            // 
            this.cmsCustomTextColourThree.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsCustomTextColourThree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem22});
            this.cmsCustomTextColourThree.Name = "contextMenuStrip1";
            this.cmsCustomTextColourThree.Size = new System.Drawing.Size(174, 26);
            // 
            // toolStripMenuItem22
            // 
            this.toolStripMenuItem22.Name = "toolStripMenuItem22";
            this.toolStripMenuItem22.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItem22.Text = "Use as &Base Colour";
            // 
            // cmsCustomTextColourFour
            // 
            this.cmsCustomTextColourFour.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsCustomTextColourFour.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem23});
            this.cmsCustomTextColourFour.Name = "contextMenuStrip1";
            this.cmsCustomTextColourFour.Size = new System.Drawing.Size(174, 26);
            // 
            // toolStripMenuItem23
            // 
            this.toolStripMenuItem23.Name = "toolStripMenuItem23";
            this.toolStripMenuItem23.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItem23.Text = "Use as &Base Colour";
            // 
            // cmsCustomTextColourFive
            // 
            this.cmsCustomTextColourFive.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsCustomTextColourFive.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem24});
            this.cmsCustomTextColourFive.Name = "contextMenuStrip1";
            this.cmsCustomTextColourFive.Size = new System.Drawing.Size(174, 26);
            // 
            // toolStripMenuItem24
            // 
            this.toolStripMenuItem24.Name = "toolStripMenuItem24";
            this.toolStripMenuItem24.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItem24.Text = "Use as &Base Colour";
            // 
            // cmsMenuTextColour
            // 
            this.cmsMenuTextColour.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsMenuTextColour.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem25});
            this.cmsMenuTextColour.Name = "contextMenuStrip1";
            this.cmsMenuTextColour.Size = new System.Drawing.Size(174, 26);
            // 
            // toolStripMenuItem25
            // 
            this.toolStripMenuItem25.Name = "toolStripMenuItem25";
            this.toolStripMenuItem25.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItem25.Text = "Use as &Base Colour";
            // 
            // cmsStatusTextColour
            // 
            this.cmsStatusTextColour.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsStatusTextColour.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem26});
            this.cmsStatusTextColour.Name = "contextMenuStrip1";
            this.cmsStatusTextColour.Size = new System.Drawing.Size(174, 26);
            // 
            // toolStripMenuItem26
            // 
            this.toolStripMenuItem26.Name = "toolStripMenuItem26";
            this.toolStripMenuItem26.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItem26.Text = "Use as &Base Colour";
            // 
            // cmsRibbonTabTextColour
            // 
            this.cmsRibbonTabTextColour.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsRibbonTabTextColour.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem27});
            this.cmsRibbonTabTextColour.Name = "contextMenuStrip1";
            this.cmsRibbonTabTextColour.Size = new System.Drawing.Size(174, 26);
            // 
            // toolStripMenuItem27
            // 
            this.toolStripMenuItem27.Name = "toolStripMenuItem27";
            this.toolStripMenuItem27.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItem27.Text = "Use as &Base Colour";
            // 
            // contextMenuStrip29
            // 
            this.contextMenuStrip29.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuStrip29.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem28});
            this.contextMenuStrip29.Name = "contextMenuStrip1";
            this.contextMenuStrip29.Size = new System.Drawing.Size(174, 26);
            // 
            // toolStripMenuItem28
            // 
            this.toolStripMenuItem28.Name = "toolStripMenuItem28";
            this.toolStripMenuItem28.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItem28.Text = "Use as &Base Colour";
            // 
            // PaletteDesignerCircularUserControl
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.cbpxDisabledTextColour);
            this.Controls.Add(this.circularPictureBox30);
            this.Controls.Add(this.circularPictureBox31);
            this.Controls.Add(this.circularPictureBox32);
            this.Controls.Add(this.circularPictureBox33);
            this.Controls.Add(this.circularPictureBox34);
            this.Controls.Add(this.circularPictureBox35);
            this.Controls.Add(this.circularPictureBox36);
            this.Controls.Add(this.circularPictureBox37);
            this.Controls.Add(this.circularPictureBox38);
            this.Controls.Add(this.circularPictureBox39);
            this.Controls.Add(this.circularPictureBox40);
            this.Controls.Add(this.circularPictureBox41);
            this.Controls.Add(this.cpbxRibbonTabTextColour);
            this.Controls.Add(this.cpbxStatusTextColour);
            this.Controls.Add(this.cpbxMenuTextColour);
            this.Controls.Add(this.cpbxCustomTextColourFive);
            this.Controls.Add(this.cpbxCustomTextColourFour);
            this.Controls.Add(this.cpbxCustomTextColourThree);
            this.Controls.Add(this.cpbxCustomTextColourTwo);
            this.Controls.Add(this.cpbxCustomTextColourOne);
            this.Controls.Add(this.cpbxCustomColourFive);
            this.Controls.Add(this.cpbxCustomColourFour);
            this.Controls.Add(this.cpbxCustomColourThree);
            this.Controls.Add(this.cpbxCustomColourTwo);
            this.Controls.Add(this.cpbxCustomColourOne);
            this.Controls.Add(this.cpbxLinkVisitedColour);
            this.Controls.Add(this.cpbxLinkHoverColour);
            this.Controls.Add(this.cpbxLinkFocusedColour);
            this.Controls.Add(this.cpbxLinkNormalColour);
            this.Controls.Add(this.cpbxDisabledControlColour);
            this.Controls.Add(this.cpbxPressedTextColour);
            this.Controls.Add(this.cpbxFocusedTextColour);
            this.Controls.Add(this.cpbxDisabledTextColour);
            this.Controls.Add(this.cpbxNormalTextColour);
            this.Controls.Add(this.cpbxAlternativeNormalTextColour);
            this.Controls.Add(this.cpbxBorderColour);
            this.Controls.Add(this.cpbxLightestColour);
            this.Controls.Add(this.cpbxLightColour);
            this.Controls.Add(this.cpbxMediumColour);
            this.Controls.Add(this.cpbxDarkColour);
            this.Controls.Add(this.cpbxBaseColour);
            this.Name = "PaletteDesignerCircularUserControl";
            this.Size = new System.Drawing.Size(1161, 423);
            this.Load += new System.EventHandler(this.PaletteDesignerCircularUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cpbxBaseColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxDarkColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxMediumColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxLightColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxLightestColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxBorderColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxAlternativeNormalTextColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxNormalTextColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxDisabledTextColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxFocusedTextColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxPressedTextColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxDisabledControlColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxLinkNormalColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxLinkFocusedColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxStatusTextColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxMenuTextColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxCustomTextColourFive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxCustomTextColourFour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxCustomTextColourThree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxCustomTextColourTwo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxCustomTextColourOne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxCustomColourFive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxCustomColourFour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxCustomColourThree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxCustomColourTwo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxCustomColourOne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxLinkVisitedColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxLinkHoverColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbpxDisabledTextColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxRibbonTabTextColour)).EndInit();
            this.cmsBaseColour.ResumeLayout(false);
            this.cmsDarkColour.ResumeLayout(false);
            this.cmsLightColour.ResumeLayout(false);
            this.cmsLightestColour.ResumeLayout(false);
            this.cmsBorderColour.ResumeLayout(false);
            this.cmsAlternativeNormalTextColour.ResumeLayout(false);
            this.cmsNormalTextColour.ResumeLayout(false);
            this.cmsDisabledTextColour.ResumeLayout(false);
            this.cmsFocusedTextColour.ResumeLayout(false);
            this.cmsPressedTextColour.ResumeLayout(false);
            this.cmsDisabledControlColour.ResumeLayout(false);
            this.cmsLinkNormalColour.ResumeLayout(false);
            this.cmsLinkFocusedColour.ResumeLayout(false);
            this.cmsLinkHoverColour.ResumeLayout(false);
            this.cmsLinkVisitedColour.ResumeLayout(false);
            this.cmsCustomColourOne.ResumeLayout(false);
            this.cmsCustomColourTwo.ResumeLayout(false);
            this.cmsCustomColourThree.ResumeLayout(false);
            this.cmscmsCustomColourFour.ResumeLayout(false);
            this.cmscmsCustomColourFive.ResumeLayout(false);
            this.cmsCustomTextColourOne.ResumeLayout(false);
            this.cmsCustomTextColourTwo.ResumeLayout(false);
            this.cmsCustomTextColourThree.ResumeLayout(false);
            this.cmsCustomTextColourFour.ResumeLayout(false);
            this.cmsCustomTextColourFive.ResumeLayout(false);
            this.cmsMenuTextColour.ResumeLayout(false);
            this.cmsStatusTextColour.ResumeLayout(false);
            this.cmsRibbonTabTextColour.ResumeLayout(false);
            this.contextMenuStrip29.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private bool _showColourInformation;

        private Color[] _paletteColours = new Color[29];

        private Color _defaultColour;

        private Suite.Extended.Base.CircularPictureBox[] _previews;

        //Palette State
        private KryptonManager k_manager = new KryptonManager();
        private PaletteBackInheritRedirect m_paletteBack;
        private PaletteBorderInheritRedirect m_paletteBorder;
        private PaletteContentInheritRedirect m_paletteContent;

        private IPalette _palette;
        private PaletteRedirect _paletteRedirect;
        #endregion

        #region Properties
        [DefaultValue(true)]
        public bool ShowColourInformation { get => _showColourInformation; set => _showColourInformation = value; }

        public Color[] PaletteColours { get => _paletteColours; set { _paletteColours = value; Invalidate(); } }

        public Color DefaultColour { get => _defaultColour; set { _defaultColour = value; Invalidate(); } }

        public Suite.Extended.Base.CircularPictureBox[] ColourPreviews { get => _previews; private set => _previews = value; }

        public KryptonPalette Palette { get => internalPalette; set => internalPalette = value; }
        #endregion

        #region Constructors
        public PaletteDesignerCircularUserControl()
        {
            InitializeComponent();

            InitColours();

            PropagateColourPreviewArray();
        }
        #endregion

        private void PaletteDesignerCircularUserControl_Load(object sender, EventArgs e)
        {

        }

        #region " Krypton "
        //Krypton Events
        private void OnPalettePaint(object sender, PaletteLayoutEventArgs e)
        {
            base.Invalidate();
        }

        private void OnGlobalPaletteChanged(object sender, EventArgs e)
        {
            if (((_palette != null)))
            {
                _palette.PalettePaint -= new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);
            }
            _palette = KryptonManager.CurrentGlobalPalette;
            _paletteRedirect.Target = _palette;
            if (((_palette != null)))
            {
                _palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);
                InitColours();
            }
            base.Invalidate();

        }


        private void InitColours()
        {
            BorderStyle = BorderStyle.None;
            ttColourInformation.ForeColor = _palette.ColorTable.MenuItemText;
            ttColourInformation.BackColor = _palette.ColorTable.MenuStripGradientBegin;
        }
        #endregion

        #region Methods
        public void SetupColourToolTips(bool displayToolTips)
        {
            if (displayToolTips)
            {
                ColourInformation.SetTooltip(cpbxBaseColour, "Base");

                ColourInformation.SetTooltip(cpbxDarkColour, "Dark");

                ColourInformation.SetTooltip(cpbxMediumColour, "Medium");

                ColourInformation.SetTooltip(cpbxLightColour, "Light");

                ColourInformation.SetTooltip(cpbxLightestColour, "Lightest");

                ColourInformation.SetTooltip(cpbxBorderColour, "Border");

                ColourInformation.SetTooltip(cpbxAlternativeNormalTextColour, "Alternative Normal Text");

                ColourInformation.SetTooltip(cpbxNormalTextColour, "Normal Text");

                ColourInformation.SetTooltip(cpbxDisabledTextColour, "Disabled Text");

                ColourInformation.SetTooltip(cpbxFocusedTextColour, "Focused Text");

                ColourInformation.SetTooltip(cpbxPressedTextColour, "Pressed Text");

                ColourInformation.SetTooltip(cpbxDisabledControlColour, "Disabled Control");

                ColourInformation.SetTooltip(cpbxLinkNormalColour, "Link Normal Text");

                ColourInformation.SetTooltip(cpbxLinkFocusedColour, "Link Focused Text");

                ColourInformation.SetTooltip(cpbxLinkHoverColour, "Link Hover Text");

                ColourInformation.SetTooltip(cpbxLinkVisitedColour, "Link Visited Text");

                ColourInformation.SetTooltip(cpbxCustomColourOne, "Custom Colour One");

                ColourInformation.SetTooltip(cpbxCustomColourTwo, "Custom Colour Two");

                ColourInformation.SetTooltip(cpbxCustomColourThree, "Custom Colour Three");

                ColourInformation.SetTooltip(cpbxCustomColourFour, "Custom Colour Four");

                ColourInformation.SetTooltip(cpbxCustomColourFive, "Custom Colour Five");

                ColourInformation.SetTooltip(cpbxCustomTextColourOne, "Custom Text Colour One");

                ColourInformation.SetTooltip(cpbxCustomTextColourTwo, "Custom Text Colour Two");

                ColourInformation.SetTooltip(cpbxCustomTextColourThree, "Custom Text Colour Three");

                ColourInformation.SetTooltip(cpbxCustomTextColourFour, "Custom Text Colour Four");

                ColourInformation.SetTooltip(cpbxCustomTextColourFive, "Custom Text Colour Five");

                ColourInformation.SetTooltip(cpbxMenuTextColour, "Menu Text");

                ColourInformation.SetTooltip(cpbxStatusTextColour, "Status Strip Text");

                ColourInformation.SetTooltip(cpbxRibbonTabTextColour, "Ribbon Tab");
            }
            else
            {
                if (_previews.Length > 0)
                {
                    try
                    {
                        foreach (Suite.Extended.Base.CircularPictureBox box in _previews)
                        {
                            box.ToolTipValues.Description = string.Empty;
                        }
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }
                }
            }
        }

        /// <summary>Propagates the colour preview array.</summary>
        private void PropagateColourPreviewArray()
        {
            _previews = new Suite.Extended.Base.CircularPictureBox[30];

            ColourPreviews[0] = cpbxBaseColour;

            ColourPreviews[1] = cpbxDarkColour;

            ColourPreviews[2] = cpbxMediumColour;

            ColourPreviews[3] = cpbxLightColour;

            ColourPreviews[4] = cpbxLightestColour;

            ColourPreviews[5] = cpbxBorderColour;

            ColourPreviews[6] = cpbxAlternativeNormalTextColour;

            ColourPreviews[7] = cpbxNormalTextColour;

            ColourPreviews[8] = cpbxDisabledTextColour;

            ColourPreviews[9] = cpbxFocusedTextColour;

            ColourPreviews[10] = cpbxPressedTextColour;

            ColourPreviews[11] = cpbxDisabledControlColour;

            ColourPreviews[12] = cpbxLinkNormalColour;

            ColourPreviews[13] = cpbxLinkFocusedColour;

            ColourPreviews[14] = cpbxLinkHoverColour;

            ColourPreviews[15] = cpbxLinkVisitedColour;

            ColourPreviews[16] = cpbxCustomColourOne;

            ColourPreviews[17] = cpbxCustomColourTwo;

            ColourPreviews[18] = cpbxCustomColourThree;

            ColourPreviews[19] = cpbxCustomColourFour;

            ColourPreviews[20] = cpbxCustomColourFive;

            ColourPreviews[21] = cpbxCustomTextColourOne;

            ColourPreviews[22] = cpbxCustomTextColourTwo;

            ColourPreviews[23] = cpbxCustomTextColourThree;

            ColourPreviews[24] = cpbxCustomTextColourFour;

            ColourPreviews[25] = cpbxCustomTextColourFive;

            ColourPreviews[26] = cpbxMenuTextColour;

            ColourPreviews[27] = cpbxStatusTextColour;

            ColourPreviews[28] = cpbxRibbonTabTextColour;
        }

        /// <summary>Resets the colours.</summary>
        /// <param name="defaultColour">The default colour.</param>
        public void ResetColours(Color defaultColour)
        {
            try
            {
                foreach (Suite.Extended.Base.CircularPictureBox box in ColourPreviews)
                {
                    box.BackColor = defaultColour;
                }
            }
            catch (Exception e)
            {
                Suite.Extended.Common.ExceptionHandler.CaptureException(e);
            }
        }

        /// <summary>Sets the colour previews.</summary>
        /// <param name="paletteColours">The palette colours.</param>
        private void SetColourPreviews(Color[] paletteColours)
        {
            try
            {
                if (ColourPreviews.Length > 0)
                {
                    ColourPreviews[0].BackColor = paletteColours[0];

                    ColourPreviews[1].BackColor = paletteColours[1];

                    ColourPreviews[2].BackColor = paletteColours[2];

                    ColourPreviews[3].BackColor = paletteColours[3];

                    ColourPreviews[4].BackColor = paletteColours[4];

                    ColourPreviews[5].BackColor = paletteColours[5];

                    ColourPreviews[6].BackColor = paletteColours[6];

                    ColourPreviews[7].BackColor = paletteColours[7];

                    ColourPreviews[8].BackColor = paletteColours[8];

                    ColourPreviews[9].BackColor = paletteColours[9];

                    ColourPreviews[10].BackColor = paletteColours[10];

                    ColourPreviews[11].BackColor = paletteColours[11];

                    ColourPreviews[12].BackColor = paletteColours[12];

                    ColourPreviews[13].BackColor = paletteColours[13];

                    ColourPreviews[14].BackColor = paletteColours[14];

                    ColourPreviews[15].BackColor = paletteColours[15];

                    ColourPreviews[16].BackColor = paletteColours[16];

                    ColourPreviews[17].BackColor = paletteColours[17];

                    ColourPreviews[18].BackColor = paletteColours[18];

                    ColourPreviews[19].BackColor = paletteColours[19];

                    ColourPreviews[20].BackColor = paletteColours[20];

                    ColourPreviews[21].BackColor = paletteColours[21];

                    ColourPreviews[22].BackColor = paletteColours[22];

                    ColourPreviews[23].BackColor = paletteColours[23];

                    ColourPreviews[24].BackColor = paletteColours[24];

                    ColourPreviews[25].BackColor = paletteColours[25];

                    ColourPreviews[26].BackColor = paletteColours[26];

                    ColourPreviews[27].BackColor = paletteColours[27];

                    ColourPreviews[28].BackColor = paletteColours[28];
                }
            }
            catch (Exception e)
            {
                Suite.Extended.Common.ExceptionHandler.CaptureException(e);
            }
        }
        #endregion

        #region Setters and Getters
        /// <summary>
        /// Sets the PaletteColours.
        /// </summary>
        /// <param name="values">The value.</param>
        public void SetPaletteColours(Color[] values) => _paletteColours = values;

        /// <summary>
        /// Gets the PaletteColours.
        /// </summary>
        /// <returns>The value of _paletteColours.</returns>
        public Color[] GetPaletteColours() => _paletteColours;
        #endregion
    }
}