using Krypton.Toolkit.Extended.Palette.Controller;
using Krypton.Toolkit.Suite.Extended.Core;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Palette.Controls
{
    public class PaletteDesignerUserControl : UserControl
    {
        #region Designer Code
        private PictureBox pbxDarkColour;
        private PictureBox pbxMediumColour;
        private PictureBox pbxLightColour;
        private PictureBox pbxLightestColour;
        private PictureBox pbxBorderColourOne;
        private PictureBox pbxAlternativeNormalTextColour;
        private PictureBox pbxNormalTextColour;
        private PictureBox pbxDisabledTextColour;
        private PictureBox pbxFocusedTextColour;
        private PictureBox pbxPressedTextColour;
        private PictureBox pbxDisabledControlColour;
        private PictureBox pbxLinkNormalColour;
        private PictureBox pbxLinkFocusedColour;
        private PictureBox pbxLinkHoverColour;
        private PictureBox pbxLinkVisitedColour;
        private PictureBox pbxCustomColourOne;
        private PictureBox pbxCustomColourTwo;
        private PictureBox pbxCustomColourThree;
        private PictureBox pbxCustomColourFour;
        private PictureBox pbxCustomColourFive;
        private PictureBox pbxCustomTextColourOne;
        private PictureBox pbxCustomTextColourTwo;
        private PictureBox pbxCustomTextColourThree;
        private PictureBox pbxCustomTextColourFour;
        private PictureBox pbxCustomTextColourFive;
        private PictureBox pbxMenuTextColour;
        private PictureBox pbxStatusTextColour;
        private PictureBox pbxRibbonTabColour;
        private IContainer components;
        private ToolTip ttColourInformation;
        private ContextMenuStrip cmsBorderColourTwo;
        private ToolStripMenuItem toolStripMenuItem29;
        private ToolStripSeparator toolStripMenuItem58;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem29;
        private ContextMenuStrip cmsAlternativeNormalTextColour;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripSeparator toolStripMenuItem35;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem5;
        private ContextMenuStrip cmsMediumColour;
        private ToolStripMenuItem toolStripMenuItem28;
        private ToolStripSeparator toolStripMenuItem57;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem28;
        private ContextMenuStrip cmsDarkColour;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripSeparator toolStripMenuItem31;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem1;
        private ContextMenuStrip cmsRibbonTabTextColour;
        private ToolStripMenuItem toolStripMenuItem27;
        private ToolStripSeparator toolStripMenuItem56;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem27;
        private ContextMenuStrip cmsStatusTextColour;
        private ToolStripMenuItem toolStripMenuItem26;
        private ToolStripSeparator toolStripMenuItem55;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem26;
        private ContextMenuStrip cmsMenuTextColour;
        private ToolStripMenuItem toolStripMenuItem25;
        private ToolStripSeparator toolStripMenuItem54;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem25;
        private ContextMenuStrip cmsCustomTextColourFive;
        private ToolStripMenuItem toolStripMenuItem24;
        private ToolStripSeparator toolStripMenuItem53;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem24;
        private ContextMenuStrip cmsCustomTextColourFour;
        private ToolStripMenuItem toolStripMenuItem23;
        private ToolStripSeparator toolStripMenuItem52;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem23;
        private ContextMenuStrip cmsCustomTextColourThree;
        private ToolStripMenuItem toolStripMenuItem22;
        private ToolStripSeparator toolStripMenuItem51;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem22;
        private ContextMenuStrip cmsCustomTextColourTwo;
        private ToolStripMenuItem toolStripMenuItem21;
        private ToolStripSeparator toolStripMenuItem50;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem21;
        private ContextMenuStrip cmsCustomTextColourOne;
        private ToolStripMenuItem toolStripMenuItem20;
        private ToolStripSeparator toolStripMenuItem49;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem20;
        private ContextMenuStrip cmsCustomColourFive;
        private ToolStripMenuItem toolStripMenuItem19;
        private ToolStripSeparator toolStripMenuItem48;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem19;
        private ContextMenuStrip cmsCustomColourFour;
        private ToolStripMenuItem toolStripMenuItem18;
        private ToolStripSeparator toolStripMenuItem47;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem18;
        private ContextMenuStrip cmsCustomColourThree;
        private ToolStripMenuItem toolStripMenuItem17;
        private ToolStripSeparator toolStripMenuItem46;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem17;
        private ContextMenuStrip cmsCustomColourTwo;
        private ToolStripMenuItem toolStripMenuItem16;
        private ToolStripSeparator toolStripMenuItem45;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem16;
        private ContextMenuStrip cmsCustomColourOne;
        private ToolStripMenuItem toolStripMenuItem15;
        private ToolStripSeparator toolStripMenuItem44;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem15;
        private ContextMenuStrip cmsLinkVisitedColour;
        private ToolStripMenuItem toolStripMenuItem14;
        private ToolStripSeparator toolStripMenuItem43;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem14;
        private ContextMenuStrip cmsLinkHoverColour;
        private ToolStripMenuItem toolStripMenuItem13;
        private ToolStripSeparator toolStripMenuItem42;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem13;
        private ContextMenuStrip cmsLinkFocusedColour;
        private ToolStripMenuItem toolStripMenuItem12;
        private ToolStripSeparator toolStripMenuItem41;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem12;
        private ContextMenuStrip cmsDisabledControlColour;
        private ToolStripMenuItem toolStripMenuItem10;
        private ToolStripSeparator toolStripMenuItem39;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem10;
        private ContextMenuStrip cmsPressedTextColour;
        private ToolStripMenuItem toolStripMenuItem9;
        private ToolStripSeparator toolStripMenuItem38;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem9;
        private ContextMenuStrip cmsFocusedTextColour;
        private ToolStripMenuItem toolStripMenuItem8;
        private ToolStripSeparator toolStripMenuItem37;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem8;
        private ContextMenuStrip cmsDisabledTextColour;
        private ToolStripMenuItem toolStripMenuItem7;
        private ToolStripSeparator toolStripMenuItem36;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem7;
        private ContextMenuStrip cmsNormalTextColour;
        private ToolStripMenuItem toolStripMenuItem6;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem6;
        private ContextMenuStrip cmsBorderColourOne;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripSeparator toolStripMenuItem34;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem4;
        private ContextMenuStrip cmsLightestColour;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripSeparator toolStripMenuItem33;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem3;
        private ContextMenuStrip cmsLightColour;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripSeparator toolStripMenuItem32;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem2;
        private KryptonPalette internalPalette;
        private ContextMenuStrip cmsLinkNormalColour;
        private ToolStripMenuItem toolStripMenuItem11;
        private ToolStripSeparator toolStripMenuItem40;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem11;
        private ContextMenuStrip cmsBaseColour;
        private ToolStripMenuItem useAsBaseColourToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem30;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem;
        private PictureBox pbxBorderColourTwo;
        private PictureBox pbxBaseColour;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbxBaseColour = new System.Windows.Forms.PictureBox();
            this.pbxDarkColour = new System.Windows.Forms.PictureBox();
            this.pbxMediumColour = new System.Windows.Forms.PictureBox();
            this.pbxLightColour = new System.Windows.Forms.PictureBox();
            this.pbxLightestColour = new System.Windows.Forms.PictureBox();
            this.pbxBorderColourOne = new System.Windows.Forms.PictureBox();
            this.pbxAlternativeNormalTextColour = new System.Windows.Forms.PictureBox();
            this.pbxNormalTextColour = new System.Windows.Forms.PictureBox();
            this.pbxDisabledTextColour = new System.Windows.Forms.PictureBox();
            this.pbxFocusedTextColour = new System.Windows.Forms.PictureBox();
            this.pbxPressedTextColour = new System.Windows.Forms.PictureBox();
            this.pbxDisabledControlColour = new System.Windows.Forms.PictureBox();
            this.pbxLinkNormalColour = new System.Windows.Forms.PictureBox();
            this.pbxLinkFocusedColour = new System.Windows.Forms.PictureBox();
            this.pbxLinkHoverColour = new System.Windows.Forms.PictureBox();
            this.pbxLinkVisitedColour = new System.Windows.Forms.PictureBox();
            this.pbxCustomColourOne = new System.Windows.Forms.PictureBox();
            this.pbxCustomColourTwo = new System.Windows.Forms.PictureBox();
            this.pbxCustomColourThree = new System.Windows.Forms.PictureBox();
            this.pbxCustomColourFour = new System.Windows.Forms.PictureBox();
            this.pbxCustomColourFive = new System.Windows.Forms.PictureBox();
            this.pbxCustomTextColourOne = new System.Windows.Forms.PictureBox();
            this.pbxCustomTextColourTwo = new System.Windows.Forms.PictureBox();
            this.pbxCustomTextColourThree = new System.Windows.Forms.PictureBox();
            this.pbxCustomTextColourFour = new System.Windows.Forms.PictureBox();
            this.pbxCustomTextColourFive = new System.Windows.Forms.PictureBox();
            this.pbxMenuTextColour = new System.Windows.Forms.PictureBox();
            this.pbxStatusTextColour = new System.Windows.Forms.PictureBox();
            this.pbxRibbonTabColour = new System.Windows.Forms.PictureBox();
            this.ttColourInformation = new System.Windows.Forms.ToolTip(this.components);
            this.cmsBorderColourTwo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem29 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem58 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem29 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsAlternativeNormalTextColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem35 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsMediumColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem28 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem57 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem28 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDarkColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem31 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRibbonTabTextColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem27 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem56 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem27 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsStatusTextColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem26 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem55 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem26 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsMenuTextColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem25 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem54 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem25 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCustomTextColourFive = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem24 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem53 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem24 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCustomTextColourFour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem23 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem52 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem23 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCustomTextColourThree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem22 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem51 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem22 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCustomTextColourTwo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem21 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem50 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem21 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCustomTextColourOne = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem20 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem49 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem20 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCustomColourFive = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem19 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem48 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem19 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCustomColourFour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem18 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem47 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem18 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCustomColourThree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem17 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem46 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem17 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCustomColourTwo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem16 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem45 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem16 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCustomColourOne = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem15 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem44 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem15 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsLinkVisitedColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem43 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsLinkHoverColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem42 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsLinkFocusedColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem41 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDisabledControlColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem39 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsPressedTextColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem38 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsFocusedTextColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem37 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDisabledTextColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem36 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsNormalTextColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.generateARandomColourToolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsBorderColourOne = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem34 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsLightestColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem33 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsLightColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem32 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.internalPalette = new Krypton.Toolkit.KryptonPalette(this.components);
            this.cmsLinkNormalColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem40 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsBaseColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.useAsBaseColourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem30 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbxBorderColourTwo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBaseColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDarkColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMediumColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLightColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLightestColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBorderColourOne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAlternativeNormalTextColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxNormalTextColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDisabledTextColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFocusedTextColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPressedTextColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDisabledControlColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLinkNormalColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLinkFocusedColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLinkHoverColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLinkVisitedColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCustomColourOne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCustomColourTwo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCustomColourThree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCustomColourFour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCustomColourFive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCustomTextColourOne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCustomTextColourTwo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCustomTextColourThree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCustomTextColourFour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCustomTextColourFive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMenuTextColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxStatusTextColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRibbonTabColour)).BeginInit();
            this.cmsBorderColourTwo.SuspendLayout();
            this.cmsAlternativeNormalTextColour.SuspendLayout();
            this.cmsMediumColour.SuspendLayout();
            this.cmsDarkColour.SuspendLayout();
            this.cmsRibbonTabTextColour.SuspendLayout();
            this.cmsStatusTextColour.SuspendLayout();
            this.cmsMenuTextColour.SuspendLayout();
            this.cmsCustomTextColourFive.SuspendLayout();
            this.cmsCustomTextColourFour.SuspendLayout();
            this.cmsCustomTextColourThree.SuspendLayout();
            this.cmsCustomTextColourTwo.SuspendLayout();
            this.cmsCustomTextColourOne.SuspendLayout();
            this.cmsCustomColourFive.SuspendLayout();
            this.cmsCustomColourFour.SuspendLayout();
            this.cmsCustomColourThree.SuspendLayout();
            this.cmsCustomColourTwo.SuspendLayout();
            this.cmsCustomColourOne.SuspendLayout();
            this.cmsLinkVisitedColour.SuspendLayout();
            this.cmsLinkHoverColour.SuspendLayout();
            this.cmsLinkFocusedColour.SuspendLayout();
            this.cmsDisabledControlColour.SuspendLayout();
            this.cmsPressedTextColour.SuspendLayout();
            this.cmsFocusedTextColour.SuspendLayout();
            this.cmsDisabledTextColour.SuspendLayout();
            this.cmsNormalTextColour.SuspendLayout();
            this.cmsBorderColourOne.SuspendLayout();
            this.cmsLightestColour.SuspendLayout();
            this.cmsLightColour.SuspendLayout();
            this.cmsLinkNormalColour.SuspendLayout();
            this.cmsBaseColour.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBorderColourTwo)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxBaseColour
            // 
            this.pbxBaseColour.BackColor = System.Drawing.Color.White;
            this.pbxBaseColour.Location = new System.Drawing.Point(3, 3);
            this.pbxBaseColour.Name = "pbxBaseColour";
            this.pbxBaseColour.Size = new System.Drawing.Size(64, 64);
            this.pbxBaseColour.TabIndex = 0;
            this.pbxBaseColour.TabStop = false;
            // 
            // pbxDarkColour
            // 
            this.pbxDarkColour.BackColor = System.Drawing.Color.White;
            this.pbxDarkColour.Location = new System.Drawing.Point(86, 3);
            this.pbxDarkColour.Name = "pbxDarkColour";
            this.pbxDarkColour.Size = new System.Drawing.Size(64, 64);
            this.pbxDarkColour.TabIndex = 1;
            this.pbxDarkColour.TabStop = false;
            // 
            // pbxMediumColour
            // 
            this.pbxMediumColour.BackColor = System.Drawing.Color.White;
            this.pbxMediumColour.Location = new System.Drawing.Point(169, 3);
            this.pbxMediumColour.Name = "pbxMediumColour";
            this.pbxMediumColour.Size = new System.Drawing.Size(64, 64);
            this.pbxMediumColour.TabIndex = 2;
            this.pbxMediumColour.TabStop = false;
            // 
            // pbxLightColour
            // 
            this.pbxLightColour.BackColor = System.Drawing.Color.White;
            this.pbxLightColour.Location = new System.Drawing.Point(252, 3);
            this.pbxLightColour.Name = "pbxLightColour";
            this.pbxLightColour.Size = new System.Drawing.Size(64, 64);
            this.pbxLightColour.TabIndex = 3;
            this.pbxLightColour.TabStop = false;
            // 
            // pbxLightestColour
            // 
            this.pbxLightestColour.BackColor = System.Drawing.Color.White;
            this.pbxLightestColour.Location = new System.Drawing.Point(335, 3);
            this.pbxLightestColour.Name = "pbxLightestColour";
            this.pbxLightestColour.Size = new System.Drawing.Size(64, 64);
            this.pbxLightestColour.TabIndex = 4;
            this.pbxLightestColour.TabStop = false;
            // 
            // pbxBorderColourOne
            // 
            this.pbxBorderColourOne.BackColor = System.Drawing.Color.White;
            this.pbxBorderColourOne.Location = new System.Drawing.Point(418, 3);
            this.pbxBorderColourOne.Name = "pbxBorderColourOne";
            this.pbxBorderColourOne.Size = new System.Drawing.Size(64, 64);
            this.pbxBorderColourOne.TabIndex = 5;
            this.pbxBorderColourOne.TabStop = false;
            // 
            // pbxAlternativeNormalTextColour
            // 
            this.pbxAlternativeNormalTextColour.BackColor = System.Drawing.Color.White;
            this.pbxAlternativeNormalTextColour.Location = new System.Drawing.Point(584, 3);
            this.pbxAlternativeNormalTextColour.Name = "pbxAlternativeNormalTextColour";
            this.pbxAlternativeNormalTextColour.Size = new System.Drawing.Size(64, 64);
            this.pbxAlternativeNormalTextColour.TabIndex = 6;
            this.pbxAlternativeNormalTextColour.TabStop = false;
            // 
            // pbxNormalTextColour
            // 
            this.pbxNormalTextColour.BackColor = System.Drawing.Color.White;
            this.pbxNormalTextColour.Location = new System.Drawing.Point(667, 3);
            this.pbxNormalTextColour.Name = "pbxNormalTextColour";
            this.pbxNormalTextColour.Size = new System.Drawing.Size(64, 64);
            this.pbxNormalTextColour.TabIndex = 7;
            this.pbxNormalTextColour.TabStop = false;
            // 
            // pbxDisabledTextColour
            // 
            this.pbxDisabledTextColour.BackColor = System.Drawing.Color.White;
            this.pbxDisabledTextColour.Location = new System.Drawing.Point(750, 3);
            this.pbxDisabledTextColour.Name = "pbxDisabledTextColour";
            this.pbxDisabledTextColour.Size = new System.Drawing.Size(64, 64);
            this.pbxDisabledTextColour.TabIndex = 8;
            this.pbxDisabledTextColour.TabStop = false;
            // 
            // pbxFocusedTextColour
            // 
            this.pbxFocusedTextColour.BackColor = System.Drawing.Color.White;
            this.pbxFocusedTextColour.Location = new System.Drawing.Point(833, 3);
            this.pbxFocusedTextColour.Name = "pbxFocusedTextColour";
            this.pbxFocusedTextColour.Size = new System.Drawing.Size(64, 64);
            this.pbxFocusedTextColour.TabIndex = 9;
            this.pbxFocusedTextColour.TabStop = false;
            // 
            // pbxPressedTextColour
            // 
            this.pbxPressedTextColour.BackColor = System.Drawing.Color.White;
            this.pbxPressedTextColour.Location = new System.Drawing.Point(916, 3);
            this.pbxPressedTextColour.Name = "pbxPressedTextColour";
            this.pbxPressedTextColour.Size = new System.Drawing.Size(64, 64);
            this.pbxPressedTextColour.TabIndex = 10;
            this.pbxPressedTextColour.TabStop = false;
            // 
            // pbxDisabledControlColour
            // 
            this.pbxDisabledControlColour.BackColor = System.Drawing.Color.White;
            this.pbxDisabledControlColour.Location = new System.Drawing.Point(999, 3);
            this.pbxDisabledControlColour.Name = "pbxDisabledControlColour";
            this.pbxDisabledControlColour.Size = new System.Drawing.Size(64, 64);
            this.pbxDisabledControlColour.TabIndex = 11;
            this.pbxDisabledControlColour.TabStop = false;
            // 
            // pbxLinkNormalColour
            // 
            this.pbxLinkNormalColour.BackColor = System.Drawing.Color.White;
            this.pbxLinkNormalColour.Location = new System.Drawing.Point(3, 179);
            this.pbxLinkNormalColour.Name = "pbxLinkNormalColour";
            this.pbxLinkNormalColour.Size = new System.Drawing.Size(64, 64);
            this.pbxLinkNormalColour.TabIndex = 12;
            this.pbxLinkNormalColour.TabStop = false;
            // 
            // pbxLinkFocusedColour
            // 
            this.pbxLinkFocusedColour.BackColor = System.Drawing.Color.White;
            this.pbxLinkFocusedColour.Location = new System.Drawing.Point(1082, 3);
            this.pbxLinkFocusedColour.Name = "pbxLinkFocusedColour";
            this.pbxLinkFocusedColour.Size = new System.Drawing.Size(64, 64);
            this.pbxLinkFocusedColour.TabIndex = 13;
            this.pbxLinkFocusedColour.TabStop = false;
            // 
            // pbxLinkHoverColour
            // 
            this.pbxLinkHoverColour.BackColor = System.Drawing.Color.White;
            this.pbxLinkHoverColour.Location = new System.Drawing.Point(86, 179);
            this.pbxLinkHoverColour.Name = "pbxLinkHoverColour";
            this.pbxLinkHoverColour.Size = new System.Drawing.Size(64, 64);
            this.pbxLinkHoverColour.TabIndex = 14;
            this.pbxLinkHoverColour.TabStop = false;
            // 
            // pbxLinkVisitedColour
            // 
            this.pbxLinkVisitedColour.BackColor = System.Drawing.Color.White;
            this.pbxLinkVisitedColour.Location = new System.Drawing.Point(169, 179);
            this.pbxLinkVisitedColour.Name = "pbxLinkVisitedColour";
            this.pbxLinkVisitedColour.Size = new System.Drawing.Size(64, 64);
            this.pbxLinkVisitedColour.TabIndex = 15;
            this.pbxLinkVisitedColour.TabStop = false;
            // 
            // pbxCustomColourOne
            // 
            this.pbxCustomColourOne.BackColor = System.Drawing.Color.White;
            this.pbxCustomColourOne.Location = new System.Drawing.Point(252, 179);
            this.pbxCustomColourOne.Name = "pbxCustomColourOne";
            this.pbxCustomColourOne.Size = new System.Drawing.Size(64, 64);
            this.pbxCustomColourOne.TabIndex = 28;
            this.pbxCustomColourOne.TabStop = false;
            // 
            // pbxCustomColourTwo
            // 
            this.pbxCustomColourTwo.BackColor = System.Drawing.Color.White;
            this.pbxCustomColourTwo.Location = new System.Drawing.Point(335, 179);
            this.pbxCustomColourTwo.Name = "pbxCustomColourTwo";
            this.pbxCustomColourTwo.Size = new System.Drawing.Size(64, 64);
            this.pbxCustomColourTwo.TabIndex = 27;
            this.pbxCustomColourTwo.TabStop = false;
            // 
            // pbxCustomColourThree
            // 
            this.pbxCustomColourThree.BackColor = System.Drawing.Color.White;
            this.pbxCustomColourThree.Location = new System.Drawing.Point(418, 179);
            this.pbxCustomColourThree.Name = "pbxCustomColourThree";
            this.pbxCustomColourThree.Size = new System.Drawing.Size(64, 64);
            this.pbxCustomColourThree.TabIndex = 26;
            this.pbxCustomColourThree.TabStop = false;
            // 
            // pbxCustomColourFour
            // 
            this.pbxCustomColourFour.BackColor = System.Drawing.Color.White;
            this.pbxCustomColourFour.Location = new System.Drawing.Point(501, 179);
            this.pbxCustomColourFour.Name = "pbxCustomColourFour";
            this.pbxCustomColourFour.Size = new System.Drawing.Size(64, 64);
            this.pbxCustomColourFour.TabIndex = 25;
            this.pbxCustomColourFour.TabStop = false;
            // 
            // pbxCustomColourFive
            // 
            this.pbxCustomColourFive.BackColor = System.Drawing.Color.White;
            this.pbxCustomColourFive.Location = new System.Drawing.Point(584, 179);
            this.pbxCustomColourFive.Name = "pbxCustomColourFive";
            this.pbxCustomColourFive.Size = new System.Drawing.Size(64, 64);
            this.pbxCustomColourFive.TabIndex = 24;
            this.pbxCustomColourFive.TabStop = false;
            // 
            // pbxCustomTextColourOne
            // 
            this.pbxCustomTextColourOne.BackColor = System.Drawing.Color.White;
            this.pbxCustomTextColourOne.Location = new System.Drawing.Point(667, 179);
            this.pbxCustomTextColourOne.Name = "pbxCustomTextColourOne";
            this.pbxCustomTextColourOne.Size = new System.Drawing.Size(64, 64);
            this.pbxCustomTextColourOne.TabIndex = 23;
            this.pbxCustomTextColourOne.TabStop = false;
            // 
            // pbxCustomTextColourTwo
            // 
            this.pbxCustomTextColourTwo.BackColor = System.Drawing.Color.White;
            this.pbxCustomTextColourTwo.Location = new System.Drawing.Point(750, 179);
            this.pbxCustomTextColourTwo.Name = "pbxCustomTextColourTwo";
            this.pbxCustomTextColourTwo.Size = new System.Drawing.Size(64, 64);
            this.pbxCustomTextColourTwo.TabIndex = 22;
            this.pbxCustomTextColourTwo.TabStop = false;
            // 
            // pbxCustomTextColourThree
            // 
            this.pbxCustomTextColourThree.BackColor = System.Drawing.Color.White;
            this.pbxCustomTextColourThree.Location = new System.Drawing.Point(833, 179);
            this.pbxCustomTextColourThree.Name = "pbxCustomTextColourThree";
            this.pbxCustomTextColourThree.Size = new System.Drawing.Size(64, 64);
            this.pbxCustomTextColourThree.TabIndex = 21;
            this.pbxCustomTextColourThree.TabStop = false;
            // 
            // pbxCustomTextColourFour
            // 
            this.pbxCustomTextColourFour.BackColor = System.Drawing.Color.White;
            this.pbxCustomTextColourFour.Location = new System.Drawing.Point(916, 179);
            this.pbxCustomTextColourFour.Name = "pbxCustomTextColourFour";
            this.pbxCustomTextColourFour.Size = new System.Drawing.Size(64, 64);
            this.pbxCustomTextColourFour.TabIndex = 20;
            this.pbxCustomTextColourFour.TabStop = false;
            // 
            // pbxCustomTextColourFive
            // 
            this.pbxCustomTextColourFive.BackColor = System.Drawing.Color.White;
            this.pbxCustomTextColourFive.Location = new System.Drawing.Point(999, 179);
            this.pbxCustomTextColourFive.Name = "pbxCustomTextColourFive";
            this.pbxCustomTextColourFive.Size = new System.Drawing.Size(64, 64);
            this.pbxCustomTextColourFive.TabIndex = 19;
            this.pbxCustomTextColourFive.TabStop = false;
            // 
            // pbxMenuTextColour
            // 
            this.pbxMenuTextColour.BackColor = System.Drawing.Color.White;
            this.pbxMenuTextColour.Location = new System.Drawing.Point(1082, 179);
            this.pbxMenuTextColour.Name = "pbxMenuTextColour";
            this.pbxMenuTextColour.Size = new System.Drawing.Size(64, 64);
            this.pbxMenuTextColour.TabIndex = 18;
            this.pbxMenuTextColour.TabStop = false;
            // 
            // pbxStatusTextColour
            // 
            this.pbxStatusTextColour.BackColor = System.Drawing.Color.White;
            this.pbxStatusTextColour.Location = new System.Drawing.Point(3, 356);
            this.pbxStatusTextColour.Name = "pbxStatusTextColour";
            this.pbxStatusTextColour.Size = new System.Drawing.Size(64, 64);
            this.pbxStatusTextColour.TabIndex = 17;
            this.pbxStatusTextColour.TabStop = false;
            // 
            // pbxRibbonTabColour
            // 
            this.pbxRibbonTabColour.BackColor = System.Drawing.Color.White;
            this.pbxRibbonTabColour.Location = new System.Drawing.Point(86, 356);
            this.pbxRibbonTabColour.Name = "pbxRibbonTabColour";
            this.pbxRibbonTabColour.Size = new System.Drawing.Size(64, 64);
            this.pbxRibbonTabColour.TabIndex = 16;
            this.pbxRibbonTabColour.TabStop = false;
            // 
            // cmsBorderColourTwo
            // 
            this.cmsBorderColourTwo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsBorderColourTwo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem29,
            this.toolStripMenuItem58,
            this.generateARandomColourToolStripMenuItem29});
            this.cmsBorderColourTwo.Name = "contextMenuStrip1";
            this.cmsBorderColourTwo.Size = new System.Drawing.Size(218, 54);
            // 
            // toolStripMenuItem29
            // 
            this.toolStripMenuItem29.Name = "toolStripMenuItem29";
            this.toolStripMenuItem29.Size = new System.Drawing.Size(217, 22);
            this.toolStripMenuItem29.Text = "Use as &Base Colour";
            // 
            // toolStripMenuItem58
            // 
            this.toolStripMenuItem58.Name = "toolStripMenuItem58";
            this.toolStripMenuItem58.Size = new System.Drawing.Size(214, 6);
            // 
            // generateARandomColourToolStripMenuItem29
            // 
            this.generateARandomColourToolStripMenuItem29.Name = "generateARandomColourToolStripMenuItem29";
            this.generateARandomColourToolStripMenuItem29.Size = new System.Drawing.Size(217, 22);
            this.generateARandomColourToolStripMenuItem29.Text = "Generate a &Random Colour";
            // 
            // cmsAlternativeNormalTextColour
            // 
            this.cmsAlternativeNormalTextColour.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsAlternativeNormalTextColour.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem5,
            this.toolStripMenuItem35,
            this.generateARandomColourToolStripMenuItem5});
            this.cmsAlternativeNormalTextColour.Name = "contextMenuStrip1";
            this.cmsAlternativeNormalTextColour.Size = new System.Drawing.Size(218, 54);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(217, 22);
            this.toolStripMenuItem5.Text = "Use as &Base Colour";
            // 
            // toolStripMenuItem35
            // 
            this.toolStripMenuItem35.Name = "toolStripMenuItem35";
            this.toolStripMenuItem35.Size = new System.Drawing.Size(214, 6);
            // 
            // generateARandomColourToolStripMenuItem5
            // 
            this.generateARandomColourToolStripMenuItem5.Name = "generateARandomColourToolStripMenuItem5";
            this.generateARandomColourToolStripMenuItem5.Size = new System.Drawing.Size(217, 22);
            this.generateARandomColourToolStripMenuItem5.Text = "Generate a &Random Colour";
            // 
            // cmsMediumColour
            // 
            this.cmsMediumColour.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsMediumColour.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem28,
            this.toolStripMenuItem57,
            this.generateARandomColourToolStripMenuItem28});
            this.cmsMediumColour.Name = "contextMenuStrip1";
            this.cmsMediumColour.Size = new System.Drawing.Size(218, 54);
            // 
            // toolStripMenuItem28
            // 
            this.toolStripMenuItem28.Name = "toolStripMenuItem28";
            this.toolStripMenuItem28.Size = new System.Drawing.Size(217, 22);
            this.toolStripMenuItem28.Text = "Use as &Base Colour";
            // 
            // toolStripMenuItem57
            // 
            this.toolStripMenuItem57.Name = "toolStripMenuItem57";
            this.toolStripMenuItem57.Size = new System.Drawing.Size(214, 6);
            // 
            // generateARandomColourToolStripMenuItem28
            // 
            this.generateARandomColourToolStripMenuItem28.Name = "generateARandomColourToolStripMenuItem28";
            this.generateARandomColourToolStripMenuItem28.Size = new System.Drawing.Size(217, 22);
            this.generateARandomColourToolStripMenuItem28.Text = "Generate a &Random Colour";
            // 
            // cmsDarkColour
            // 
            this.cmsDarkColour.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsDarkColour.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem31,
            this.generateARandomColourToolStripMenuItem1});
            this.cmsDarkColour.Name = "contextMenuStrip1";
            this.cmsDarkColour.Size = new System.Drawing.Size(218, 54);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(217, 22);
            this.toolStripMenuItem1.Text = "Use as &Base Colour";
            // 
            // toolStripMenuItem31
            // 
            this.toolStripMenuItem31.Name = "toolStripMenuItem31";
            this.toolStripMenuItem31.Size = new System.Drawing.Size(214, 6);
            // 
            // generateARandomColourToolStripMenuItem1
            // 
            this.generateARandomColourToolStripMenuItem1.Name = "generateARandomColourToolStripMenuItem1";
            this.generateARandomColourToolStripMenuItem1.Size = new System.Drawing.Size(217, 22);
            this.generateARandomColourToolStripMenuItem1.Text = "Generate a &Random Colour";
            // 
            // cmsRibbonTabTextColour
            // 
            this.cmsRibbonTabTextColour.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsRibbonTabTextColour.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem27,
            this.toolStripMenuItem56,
            this.generateARandomColourToolStripMenuItem27});
            this.cmsRibbonTabTextColour.Name = "contextMenuStrip1";
            this.cmsRibbonTabTextColour.Size = new System.Drawing.Size(218, 54);
            // 
            // toolStripMenuItem27
            // 
            this.toolStripMenuItem27.Name = "toolStripMenuItem27";
            this.toolStripMenuItem27.Size = new System.Drawing.Size(217, 22);
            this.toolStripMenuItem27.Text = "Use as &Base Colour";
            // 
            // toolStripMenuItem56
            // 
            this.toolStripMenuItem56.Name = "toolStripMenuItem56";
            this.toolStripMenuItem56.Size = new System.Drawing.Size(214, 6);
            // 
            // generateARandomColourToolStripMenuItem27
            // 
            this.generateARandomColourToolStripMenuItem27.Name = "generateARandomColourToolStripMenuItem27";
            this.generateARandomColourToolStripMenuItem27.Size = new System.Drawing.Size(217, 22);
            this.generateARandomColourToolStripMenuItem27.Text = "Generate a &Random Colour";
            // 
            // cmsStatusTextColour
            // 
            this.cmsStatusTextColour.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsStatusTextColour.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem26,
            this.toolStripMenuItem55,
            this.generateARandomColourToolStripMenuItem26});
            this.cmsStatusTextColour.Name = "contextMenuStrip1";
            this.cmsStatusTextColour.Size = new System.Drawing.Size(218, 54);
            // 
            // toolStripMenuItem26
            // 
            this.toolStripMenuItem26.Name = "toolStripMenuItem26";
            this.toolStripMenuItem26.Size = new System.Drawing.Size(217, 22);
            this.toolStripMenuItem26.Text = "Use as &Base Colour";
            // 
            // toolStripMenuItem55
            // 
            this.toolStripMenuItem55.Name = "toolStripMenuItem55";
            this.toolStripMenuItem55.Size = new System.Drawing.Size(214, 6);
            // 
            // generateARandomColourToolStripMenuItem26
            // 
            this.generateARandomColourToolStripMenuItem26.Name = "generateARandomColourToolStripMenuItem26";
            this.generateARandomColourToolStripMenuItem26.Size = new System.Drawing.Size(217, 22);
            this.generateARandomColourToolStripMenuItem26.Text = "Generate a &Random Colour";
            // 
            // cmsMenuTextColour
            // 
            this.cmsMenuTextColour.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsMenuTextColour.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem25,
            this.toolStripMenuItem54,
            this.generateARandomColourToolStripMenuItem25});
            this.cmsMenuTextColour.Name = "contextMenuStrip1";
            this.cmsMenuTextColour.Size = new System.Drawing.Size(218, 54);
            // 
            // toolStripMenuItem25
            // 
            this.toolStripMenuItem25.Name = "toolStripMenuItem25";
            this.toolStripMenuItem25.Size = new System.Drawing.Size(217, 22);
            this.toolStripMenuItem25.Text = "Use as &Base Colour";
            // 
            // toolStripMenuItem54
            // 
            this.toolStripMenuItem54.Name = "toolStripMenuItem54";
            this.toolStripMenuItem54.Size = new System.Drawing.Size(214, 6);
            // 
            // generateARandomColourToolStripMenuItem25
            // 
            this.generateARandomColourToolStripMenuItem25.Name = "generateARandomColourToolStripMenuItem25";
            this.generateARandomColourToolStripMenuItem25.Size = new System.Drawing.Size(217, 22);
            this.generateARandomColourToolStripMenuItem25.Text = "Generate a &Random Colour";
            // 
            // cmsCustomTextColourFive
            // 
            this.cmsCustomTextColourFive.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsCustomTextColourFive.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem24,
            this.toolStripMenuItem53,
            this.generateARandomColourToolStripMenuItem24});
            this.cmsCustomTextColourFive.Name = "contextMenuStrip1";
            this.cmsCustomTextColourFive.Size = new System.Drawing.Size(218, 54);
            // 
            // toolStripMenuItem24
            // 
            this.toolStripMenuItem24.Name = "toolStripMenuItem24";
            this.toolStripMenuItem24.Size = new System.Drawing.Size(217, 22);
            this.toolStripMenuItem24.Text = "Use as &Base Colour";
            // 
            // toolStripMenuItem53
            // 
            this.toolStripMenuItem53.Name = "toolStripMenuItem53";
            this.toolStripMenuItem53.Size = new System.Drawing.Size(214, 6);
            // 
            // generateARandomColourToolStripMenuItem24
            // 
            this.generateARandomColourToolStripMenuItem24.Name = "generateARandomColourToolStripMenuItem24";
            this.generateARandomColourToolStripMenuItem24.Size = new System.Drawing.Size(217, 22);
            this.generateARandomColourToolStripMenuItem24.Text = "Generate a &Random Colour";
            // 
            // cmsCustomTextColourFour
            // 
            this.cmsCustomTextColourFour.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsCustomTextColourFour.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem23,
            this.toolStripMenuItem52,
            this.generateARandomColourToolStripMenuItem23});
            this.cmsCustomTextColourFour.Name = "contextMenuStrip1";
            this.cmsCustomTextColourFour.Size = new System.Drawing.Size(218, 54);
            // 
            // toolStripMenuItem23
            // 
            this.toolStripMenuItem23.Name = "toolStripMenuItem23";
            this.toolStripMenuItem23.Size = new System.Drawing.Size(217, 22);
            this.toolStripMenuItem23.Text = "Use as &Base Colour";
            // 
            // toolStripMenuItem52
            // 
            this.toolStripMenuItem52.Name = "toolStripMenuItem52";
            this.toolStripMenuItem52.Size = new System.Drawing.Size(214, 6);
            // 
            // generateARandomColourToolStripMenuItem23
            // 
            this.generateARandomColourToolStripMenuItem23.Name = "generateARandomColourToolStripMenuItem23";
            this.generateARandomColourToolStripMenuItem23.Size = new System.Drawing.Size(217, 22);
            this.generateARandomColourToolStripMenuItem23.Text = "Generate a &Random Colour";
            // 
            // cmsCustomTextColourThree
            // 
            this.cmsCustomTextColourThree.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsCustomTextColourThree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem22,
            this.toolStripMenuItem51,
            this.generateARandomColourToolStripMenuItem22});
            this.cmsCustomTextColourThree.Name = "contextMenuStrip1";
            this.cmsCustomTextColourThree.Size = new System.Drawing.Size(218, 54);
            // 
            // toolStripMenuItem22
            // 
            this.toolStripMenuItem22.Name = "toolStripMenuItem22";
            this.toolStripMenuItem22.Size = new System.Drawing.Size(217, 22);
            this.toolStripMenuItem22.Text = "Use as &Base Colour";
            // 
            // toolStripMenuItem51
            // 
            this.toolStripMenuItem51.Name = "toolStripMenuItem51";
            this.toolStripMenuItem51.Size = new System.Drawing.Size(214, 6);
            // 
            // generateARandomColourToolStripMenuItem22
            // 
            this.generateARandomColourToolStripMenuItem22.Name = "generateARandomColourToolStripMenuItem22";
            this.generateARandomColourToolStripMenuItem22.Size = new System.Drawing.Size(217, 22);
            this.generateARandomColourToolStripMenuItem22.Text = "Generate a &Random Colour";
            // 
            // cmsCustomTextColourTwo
            // 
            this.cmsCustomTextColourTwo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsCustomTextColourTwo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem21,
            this.toolStripMenuItem50,
            this.generateARandomColourToolStripMenuItem21});
            this.cmsCustomTextColourTwo.Name = "contextMenuStrip1";
            this.cmsCustomTextColourTwo.Size = new System.Drawing.Size(218, 54);
            // 
            // toolStripMenuItem21
            // 
            this.toolStripMenuItem21.Name = "toolStripMenuItem21";
            this.toolStripMenuItem21.Size = new System.Drawing.Size(217, 22);
            this.toolStripMenuItem21.Text = "Use as &Base Colour";
            // 
            // toolStripMenuItem50
            // 
            this.toolStripMenuItem50.Name = "toolStripMenuItem50";
            this.toolStripMenuItem50.Size = new System.Drawing.Size(214, 6);
            // 
            // generateARandomColourToolStripMenuItem21
            // 
            this.generateARandomColourToolStripMenuItem21.Name = "generateARandomColourToolStripMenuItem21";
            this.generateARandomColourToolStripMenuItem21.Size = new System.Drawing.Size(217, 22);
            this.generateARandomColourToolStripMenuItem21.Text = "Generate a &Random Colour";
            // 
            // cmsCustomTextColourOne
            // 
            this.cmsCustomTextColourOne.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsCustomTextColourOne.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem20,
            this.toolStripMenuItem49,
            this.generateARandomColourToolStripMenuItem20});
            this.cmsCustomTextColourOne.Name = "contextMenuStrip1";
            this.cmsCustomTextColourOne.Size = new System.Drawing.Size(218, 54);
            // 
            // toolStripMenuItem20
            // 
            this.toolStripMenuItem20.Name = "toolStripMenuItem20";
            this.toolStripMenuItem20.Size = new System.Drawing.Size(217, 22);
            this.toolStripMenuItem20.Text = "Use as &Base Colour";
            // 
            // toolStripMenuItem49
            // 
            this.toolStripMenuItem49.Name = "toolStripMenuItem49";
            this.toolStripMenuItem49.Size = new System.Drawing.Size(214, 6);
            // 
            // generateARandomColourToolStripMenuItem20
            // 
            this.generateARandomColourToolStripMenuItem20.Name = "generateARandomColourToolStripMenuItem20";
            this.generateARandomColourToolStripMenuItem20.Size = new System.Drawing.Size(217, 22);
            this.generateARandomColourToolStripMenuItem20.Text = "Generate a &Random Colour";
            // 
            // cmsCustomColourFive
            // 
            this.cmsCustomColourFive.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsCustomColourFive.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem19,
            this.toolStripMenuItem48,
            this.generateARandomColourToolStripMenuItem19});
            this.cmsCustomColourFive.Name = "contextMenuStrip1";
            this.cmsCustomColourFive.Size = new System.Drawing.Size(218, 54);
            // 
            // toolStripMenuItem19
            // 
            this.toolStripMenuItem19.Name = "toolStripMenuItem19";
            this.toolStripMenuItem19.Size = new System.Drawing.Size(217, 22);
            this.toolStripMenuItem19.Text = "Use as &Base Colour";
            // 
            // toolStripMenuItem48
            // 
            this.toolStripMenuItem48.Name = "toolStripMenuItem48";
            this.toolStripMenuItem48.Size = new System.Drawing.Size(214, 6);
            // 
            // generateARandomColourToolStripMenuItem19
            // 
            this.generateARandomColourToolStripMenuItem19.Name = "generateARandomColourToolStripMenuItem19";
            this.generateARandomColourToolStripMenuItem19.Size = new System.Drawing.Size(217, 22);
            this.generateARandomColourToolStripMenuItem19.Text = "Generate a &Random Colour";
            // 
            // cmsCustomColourFour
            // 
            this.cmsCustomColourFour.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsCustomColourFour.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem18,
            this.toolStripMenuItem47,
            this.generateARandomColourToolStripMenuItem18});
            this.cmsCustomColourFour.Name = "contextMenuStrip1";
            this.cmsCustomColourFour.Size = new System.Drawing.Size(218, 54);
            // 
            // toolStripMenuItem18
            // 
            this.toolStripMenuItem18.Name = "toolStripMenuItem18";
            this.toolStripMenuItem18.Size = new System.Drawing.Size(217, 22);
            this.toolStripMenuItem18.Text = "Use as &Base Colour";
            // 
            // toolStripMenuItem47
            // 
            this.toolStripMenuItem47.Name = "toolStripMenuItem47";
            this.toolStripMenuItem47.Size = new System.Drawing.Size(214, 6);
            // 
            // generateARandomColourToolStripMenuItem18
            // 
            this.generateARandomColourToolStripMenuItem18.Name = "generateARandomColourToolStripMenuItem18";
            this.generateARandomColourToolStripMenuItem18.Size = new System.Drawing.Size(217, 22);
            this.generateARandomColourToolStripMenuItem18.Text = "Generate a &Random Colour";
            // 
            // cmsCustomColourThree
            // 
            this.cmsCustomColourThree.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsCustomColourThree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem17,
            this.toolStripMenuItem46,
            this.generateARandomColourToolStripMenuItem17});
            this.cmsCustomColourThree.Name = "contextMenuStrip1";
            this.cmsCustomColourThree.Size = new System.Drawing.Size(218, 54);
            // 
            // toolStripMenuItem17
            // 
            this.toolStripMenuItem17.Name = "toolStripMenuItem17";
            this.toolStripMenuItem17.Size = new System.Drawing.Size(217, 22);
            this.toolStripMenuItem17.Text = "Use as &Base Colour";
            // 
            // toolStripMenuItem46
            // 
            this.toolStripMenuItem46.Name = "toolStripMenuItem46";
            this.toolStripMenuItem46.Size = new System.Drawing.Size(214, 6);
            // 
            // generateARandomColourToolStripMenuItem17
            // 
            this.generateARandomColourToolStripMenuItem17.Name = "generateARandomColourToolStripMenuItem17";
            this.generateARandomColourToolStripMenuItem17.Size = new System.Drawing.Size(217, 22);
            this.generateARandomColourToolStripMenuItem17.Text = "Generate a &Random Colour";
            // 
            // cmsCustomColourTwo
            // 
            this.cmsCustomColourTwo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsCustomColourTwo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem16,
            this.toolStripMenuItem45,
            this.generateARandomColourToolStripMenuItem16});
            this.cmsCustomColourTwo.Name = "contextMenuStrip1";
            this.cmsCustomColourTwo.Size = new System.Drawing.Size(218, 54);
            // 
            // toolStripMenuItem16
            // 
            this.toolStripMenuItem16.Name = "toolStripMenuItem16";
            this.toolStripMenuItem16.Size = new System.Drawing.Size(217, 22);
            this.toolStripMenuItem16.Text = "Use as &Base Colour";
            // 
            // toolStripMenuItem45
            // 
            this.toolStripMenuItem45.Name = "toolStripMenuItem45";
            this.toolStripMenuItem45.Size = new System.Drawing.Size(214, 6);
            // 
            // generateARandomColourToolStripMenuItem16
            // 
            this.generateARandomColourToolStripMenuItem16.Name = "generateARandomColourToolStripMenuItem16";
            this.generateARandomColourToolStripMenuItem16.Size = new System.Drawing.Size(217, 22);
            this.generateARandomColourToolStripMenuItem16.Text = "Generate a &Random Colour";
            // 
            // cmsCustomColourOne
            // 
            this.cmsCustomColourOne.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsCustomColourOne.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem15,
            this.toolStripMenuItem44,
            this.generateARandomColourToolStripMenuItem15});
            this.cmsCustomColourOne.Name = "contextMenuStrip1";
            this.cmsCustomColourOne.Size = new System.Drawing.Size(218, 54);
            // 
            // toolStripMenuItem15
            // 
            this.toolStripMenuItem15.Name = "toolStripMenuItem15";
            this.toolStripMenuItem15.Size = new System.Drawing.Size(217, 22);
            this.toolStripMenuItem15.Text = "Use as &Base Colour";
            // 
            // toolStripMenuItem44
            // 
            this.toolStripMenuItem44.Name = "toolStripMenuItem44";
            this.toolStripMenuItem44.Size = new System.Drawing.Size(214, 6);
            // 
            // generateARandomColourToolStripMenuItem15
            // 
            this.generateARandomColourToolStripMenuItem15.Name = "generateARandomColourToolStripMenuItem15";
            this.generateARandomColourToolStripMenuItem15.Size = new System.Drawing.Size(217, 22);
            this.generateARandomColourToolStripMenuItem15.Text = "Generate a &Random Colour";
            // 
            // cmsLinkVisitedColour
            // 
            this.cmsLinkVisitedColour.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsLinkVisitedColour.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem14,
            this.toolStripMenuItem43,
            this.generateARandomColourToolStripMenuItem14});
            this.cmsLinkVisitedColour.Name = "contextMenuStrip1";
            this.cmsLinkVisitedColour.Size = new System.Drawing.Size(218, 54);
            // 
            // toolStripMenuItem14
            // 
            this.toolStripMenuItem14.Name = "toolStripMenuItem14";
            this.toolStripMenuItem14.Size = new System.Drawing.Size(217, 22);
            this.toolStripMenuItem14.Text = "Use as &Base Colour";
            // 
            // toolStripMenuItem43
            // 
            this.toolStripMenuItem43.Name = "toolStripMenuItem43";
            this.toolStripMenuItem43.Size = new System.Drawing.Size(214, 6);
            // 
            // generateARandomColourToolStripMenuItem14
            // 
            this.generateARandomColourToolStripMenuItem14.Name = "generateARandomColourToolStripMenuItem14";
            this.generateARandomColourToolStripMenuItem14.Size = new System.Drawing.Size(217, 22);
            this.generateARandomColourToolStripMenuItem14.Text = "Generate a &Random Colour";
            // 
            // cmsLinkHoverColour
            // 
            this.cmsLinkHoverColour.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsLinkHoverColour.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem13,
            this.toolStripMenuItem42,
            this.generateARandomColourToolStripMenuItem13});
            this.cmsLinkHoverColour.Name = "contextMenuStrip1";
            this.cmsLinkHoverColour.Size = new System.Drawing.Size(218, 54);
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Size = new System.Drawing.Size(217, 22);
            this.toolStripMenuItem13.Text = "Use as &Base Colour";
            // 
            // toolStripMenuItem42
            // 
            this.toolStripMenuItem42.Name = "toolStripMenuItem42";
            this.toolStripMenuItem42.Size = new System.Drawing.Size(214, 6);
            // 
            // generateARandomColourToolStripMenuItem13
            // 
            this.generateARandomColourToolStripMenuItem13.Name = "generateARandomColourToolStripMenuItem13";
            this.generateARandomColourToolStripMenuItem13.Size = new System.Drawing.Size(217, 22);
            this.generateARandomColourToolStripMenuItem13.Text = "Generate a &Random Colour";
            // 
            // cmsLinkFocusedColour
            // 
            this.cmsLinkFocusedColour.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsLinkFocusedColour.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem12,
            this.toolStripMenuItem41,
            this.generateARandomColourToolStripMenuItem12});
            this.cmsLinkFocusedColour.Name = "contextMenuStrip1";
            this.cmsLinkFocusedColour.Size = new System.Drawing.Size(218, 54);
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(217, 22);
            this.toolStripMenuItem12.Text = "Use as &Base Colour";
            // 
            // toolStripMenuItem41
            // 
            this.toolStripMenuItem41.Name = "toolStripMenuItem41";
            this.toolStripMenuItem41.Size = new System.Drawing.Size(214, 6);
            // 
            // generateARandomColourToolStripMenuItem12
            // 
            this.generateARandomColourToolStripMenuItem12.Name = "generateARandomColourToolStripMenuItem12";
            this.generateARandomColourToolStripMenuItem12.Size = new System.Drawing.Size(217, 22);
            this.generateARandomColourToolStripMenuItem12.Text = "Generate a &Random Colour";
            // 
            // cmsDisabledControlColour
            // 
            this.cmsDisabledControlColour.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsDisabledControlColour.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem10,
            this.toolStripMenuItem39,
            this.generateARandomColourToolStripMenuItem10});
            this.cmsDisabledControlColour.Name = "contextMenuStrip1";
            this.cmsDisabledControlColour.Size = new System.Drawing.Size(218, 54);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(217, 22);
            this.toolStripMenuItem10.Text = "Use as &Base Colour";
            // 
            // toolStripMenuItem39
            // 
            this.toolStripMenuItem39.Name = "toolStripMenuItem39";
            this.toolStripMenuItem39.Size = new System.Drawing.Size(214, 6);
            // 
            // generateARandomColourToolStripMenuItem10
            // 
            this.generateARandomColourToolStripMenuItem10.Name = "generateARandomColourToolStripMenuItem10";
            this.generateARandomColourToolStripMenuItem10.Size = new System.Drawing.Size(217, 22);
            this.generateARandomColourToolStripMenuItem10.Text = "Generate a &Random Colour";
            // 
            // cmsPressedTextColour
            // 
            this.cmsPressedTextColour.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsPressedTextColour.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem9,
            this.toolStripMenuItem38,
            this.generateARandomColourToolStripMenuItem9});
            this.cmsPressedTextColour.Name = "contextMenuStrip1";
            this.cmsPressedTextColour.Size = new System.Drawing.Size(218, 54);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(217, 22);
            this.toolStripMenuItem9.Text = "Use as &Base Colour";
            // 
            // toolStripMenuItem38
            // 
            this.toolStripMenuItem38.Name = "toolStripMenuItem38";
            this.toolStripMenuItem38.Size = new System.Drawing.Size(214, 6);
            // 
            // generateARandomColourToolStripMenuItem9
            // 
            this.generateARandomColourToolStripMenuItem9.Name = "generateARandomColourToolStripMenuItem9";
            this.generateARandomColourToolStripMenuItem9.Size = new System.Drawing.Size(217, 22);
            this.generateARandomColourToolStripMenuItem9.Text = "Generate a &Random Colour";
            // 
            // cmsFocusedTextColour
            // 
            this.cmsFocusedTextColour.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsFocusedTextColour.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem8,
            this.toolStripMenuItem37,
            this.generateARandomColourToolStripMenuItem8});
            this.cmsFocusedTextColour.Name = "contextMenuStrip1";
            this.cmsFocusedTextColour.Size = new System.Drawing.Size(218, 54);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(217, 22);
            this.toolStripMenuItem8.Text = "Use as &Base Colour";
            // 
            // toolStripMenuItem37
            // 
            this.toolStripMenuItem37.Name = "toolStripMenuItem37";
            this.toolStripMenuItem37.Size = new System.Drawing.Size(214, 6);
            // 
            // generateARandomColourToolStripMenuItem8
            // 
            this.generateARandomColourToolStripMenuItem8.Name = "generateARandomColourToolStripMenuItem8";
            this.generateARandomColourToolStripMenuItem8.Size = new System.Drawing.Size(217, 22);
            this.generateARandomColourToolStripMenuItem8.Text = "Generate a &Random Colour";
            // 
            // cmsDisabledTextColour
            // 
            this.cmsDisabledTextColour.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsDisabledTextColour.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem7,
            this.toolStripMenuItem36,
            this.generateARandomColourToolStripMenuItem7});
            this.cmsDisabledTextColour.Name = "contextMenuStrip1";
            this.cmsDisabledTextColour.Size = new System.Drawing.Size(218, 54);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(217, 22);
            this.toolStripMenuItem7.Text = "Use as &Base Colour";
            // 
            // toolStripMenuItem36
            // 
            this.toolStripMenuItem36.Name = "toolStripMenuItem36";
            this.toolStripMenuItem36.Size = new System.Drawing.Size(214, 6);
            // 
            // generateARandomColourToolStripMenuItem7
            // 
            this.generateARandomColourToolStripMenuItem7.Name = "generateARandomColourToolStripMenuItem7";
            this.generateARandomColourToolStripMenuItem7.Size = new System.Drawing.Size(217, 22);
            this.generateARandomColourToolStripMenuItem7.Text = "Generate a &Random Colour";
            // 
            // cmsNormalTextColour
            // 
            this.cmsNormalTextColour.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsNormalTextColour.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem6,
            this.generateARandomColourToolStripMenuItem6});
            this.cmsNormalTextColour.Name = "contextMenuStrip1";
            this.cmsNormalTextColour.Size = new System.Drawing.Size(218, 48);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(217, 22);
            this.toolStripMenuItem6.Text = "Use as &Base Colour";
            // 
            // generateARandomColourToolStripMenuItem6
            // 
            this.generateARandomColourToolStripMenuItem6.Name = "generateARandomColourToolStripMenuItem6";
            this.generateARandomColourToolStripMenuItem6.Size = new System.Drawing.Size(217, 22);
            this.generateARandomColourToolStripMenuItem6.Text = "Generate a &Random Colour";
            // 
            // cmsBorderColourOne
            // 
            this.cmsBorderColourOne.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsBorderColourOne.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4,
            this.toolStripMenuItem34,
            this.generateARandomColourToolStripMenuItem4});
            this.cmsBorderColourOne.Name = "contextMenuStrip1";
            this.cmsBorderColourOne.Size = new System.Drawing.Size(218, 54);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(217, 22);
            this.toolStripMenuItem4.Text = "Use as &Base Colour";
            // 
            // toolStripMenuItem34
            // 
            this.toolStripMenuItem34.Name = "toolStripMenuItem34";
            this.toolStripMenuItem34.Size = new System.Drawing.Size(214, 6);
            // 
            // generateARandomColourToolStripMenuItem4
            // 
            this.generateARandomColourToolStripMenuItem4.Name = "generateARandomColourToolStripMenuItem4";
            this.generateARandomColourToolStripMenuItem4.Size = new System.Drawing.Size(217, 22);
            this.generateARandomColourToolStripMenuItem4.Text = "Generate a &Random Colour";
            // 
            // cmsLightestColour
            // 
            this.cmsLightestColour.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsLightestColour.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem33,
            this.generateARandomColourToolStripMenuItem3});
            this.cmsLightestColour.Name = "contextMenuStrip1";
            this.cmsLightestColour.Size = new System.Drawing.Size(218, 54);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(217, 22);
            this.toolStripMenuItem3.Text = "Use as &Base Colour";
            // 
            // toolStripMenuItem33
            // 
            this.toolStripMenuItem33.Name = "toolStripMenuItem33";
            this.toolStripMenuItem33.Size = new System.Drawing.Size(214, 6);
            // 
            // generateARandomColourToolStripMenuItem3
            // 
            this.generateARandomColourToolStripMenuItem3.Name = "generateARandomColourToolStripMenuItem3";
            this.generateARandomColourToolStripMenuItem3.Size = new System.Drawing.Size(217, 22);
            this.generateARandomColourToolStripMenuItem3.Text = "Generate a &Random Colour";
            // 
            // cmsLightColour
            // 
            this.cmsLightColour.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsLightColour.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem32,
            this.generateARandomColourToolStripMenuItem2});
            this.cmsLightColour.Name = "contextMenuStrip1";
            this.cmsLightColour.Size = new System.Drawing.Size(218, 54);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(217, 22);
            this.toolStripMenuItem2.Text = "Use as &Base Colour";
            // 
            // toolStripMenuItem32
            // 
            this.toolStripMenuItem32.Name = "toolStripMenuItem32";
            this.toolStripMenuItem32.Size = new System.Drawing.Size(214, 6);
            // 
            // generateARandomColourToolStripMenuItem2
            // 
            this.generateARandomColourToolStripMenuItem2.Name = "generateARandomColourToolStripMenuItem2";
            this.generateARandomColourToolStripMenuItem2.Size = new System.Drawing.Size(217, 22);
            this.generateARandomColourToolStripMenuItem2.Text = "Generate a &Random Colour";
            // 
            // internalPalette
            // 
            this.internalPalette.CustomisedKryptonPaletteFilePath = null;
            // 
            // cmsLinkNormalColour
            // 
            this.cmsLinkNormalColour.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsLinkNormalColour.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem11,
            this.toolStripMenuItem40,
            this.generateARandomColourToolStripMenuItem11});
            this.cmsLinkNormalColour.Name = "contextMenuStrip1";
            this.cmsLinkNormalColour.Size = new System.Drawing.Size(218, 54);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(217, 22);
            this.toolStripMenuItem11.Text = "Use as &Base Colour";
            // 
            // toolStripMenuItem40
            // 
            this.toolStripMenuItem40.Name = "toolStripMenuItem40";
            this.toolStripMenuItem40.Size = new System.Drawing.Size(214, 6);
            // 
            // generateARandomColourToolStripMenuItem11
            // 
            this.generateARandomColourToolStripMenuItem11.Name = "generateARandomColourToolStripMenuItem11";
            this.generateARandomColourToolStripMenuItem11.Size = new System.Drawing.Size(217, 22);
            this.generateARandomColourToolStripMenuItem11.Text = "Generate a &Random Colour";
            // 
            // cmsBaseColour
            // 
            this.cmsBaseColour.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsBaseColour.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.useAsBaseColourToolStripMenuItem,
            this.toolStripMenuItem30,
            this.generateARandomColourToolStripMenuItem});
            this.cmsBaseColour.Name = "cmsBaseColour";
            this.cmsBaseColour.Size = new System.Drawing.Size(218, 54);
            // 
            // useAsBaseColourToolStripMenuItem
            // 
            this.useAsBaseColourToolStripMenuItem.Name = "useAsBaseColourToolStripMenuItem";
            this.useAsBaseColourToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.useAsBaseColourToolStripMenuItem.Text = "Use as &Base Colour";
            // 
            // toolStripMenuItem30
            // 
            this.toolStripMenuItem30.Name = "toolStripMenuItem30";
            this.toolStripMenuItem30.Size = new System.Drawing.Size(214, 6);
            // 
            // generateARandomColourToolStripMenuItem
            // 
            this.generateARandomColourToolStripMenuItem.Name = "generateARandomColourToolStripMenuItem";
            this.generateARandomColourToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.generateARandomColourToolStripMenuItem.Text = "Generate a &Random Colour";
            // 
            // pbxBorderColourTwo
            // 
            this.pbxBorderColourTwo.BackColor = System.Drawing.Color.White;
            this.pbxBorderColourTwo.Location = new System.Drawing.Point(501, 3);
            this.pbxBorderColourTwo.Name = "pbxBorderColourTwo";
            this.pbxBorderColourTwo.Size = new System.Drawing.Size(64, 64);
            this.pbxBorderColourTwo.TabIndex = 59;
            this.pbxBorderColourTwo.TabStop = false;
            // 
            // PaletteDesignerUserControl
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pbxBorderColourTwo);
            this.Controls.Add(this.pbxCustomColourOne);
            this.Controls.Add(this.pbxCustomColourTwo);
            this.Controls.Add(this.pbxCustomColourThree);
            this.Controls.Add(this.pbxCustomColourFour);
            this.Controls.Add(this.pbxCustomColourFive);
            this.Controls.Add(this.pbxCustomTextColourOne);
            this.Controls.Add(this.pbxCustomTextColourTwo);
            this.Controls.Add(this.pbxCustomTextColourThree);
            this.Controls.Add(this.pbxCustomTextColourFour);
            this.Controls.Add(this.pbxCustomTextColourFive);
            this.Controls.Add(this.pbxMenuTextColour);
            this.Controls.Add(this.pbxStatusTextColour);
            this.Controls.Add(this.pbxRibbonTabColour);
            this.Controls.Add(this.pbxLinkVisitedColour);
            this.Controls.Add(this.pbxLinkHoverColour);
            this.Controls.Add(this.pbxLinkFocusedColour);
            this.Controls.Add(this.pbxLinkNormalColour);
            this.Controls.Add(this.pbxDisabledControlColour);
            this.Controls.Add(this.pbxPressedTextColour);
            this.Controls.Add(this.pbxFocusedTextColour);
            this.Controls.Add(this.pbxDisabledTextColour);
            this.Controls.Add(this.pbxNormalTextColour);
            this.Controls.Add(this.pbxAlternativeNormalTextColour);
            this.Controls.Add(this.pbxBorderColourOne);
            this.Controls.Add(this.pbxLightestColour);
            this.Controls.Add(this.pbxLightColour);
            this.Controls.Add(this.pbxMediumColour);
            this.Controls.Add(this.pbxDarkColour);
            this.Controls.Add(this.pbxBaseColour);
            this.Name = "PaletteDesignerUserControl";
            this.Size = new System.Drawing.Size(1161, 423);
            this.Load += new System.EventHandler(this.PaletteDesignerUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxBaseColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDarkColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMediumColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLightColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLightestColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBorderColourOne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAlternativeNormalTextColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxNormalTextColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDisabledTextColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFocusedTextColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPressedTextColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDisabledControlColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLinkNormalColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLinkFocusedColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLinkHoverColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLinkVisitedColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCustomColourOne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCustomColourTwo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCustomColourThree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCustomColourFour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCustomColourFive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCustomTextColourOne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCustomTextColourTwo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCustomTextColourThree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCustomTextColourFour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCustomTextColourFive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMenuTextColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxStatusTextColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRibbonTabColour)).EndInit();
            this.cmsBorderColourTwo.ResumeLayout(false);
            this.cmsAlternativeNormalTextColour.ResumeLayout(false);
            this.cmsMediumColour.ResumeLayout(false);
            this.cmsDarkColour.ResumeLayout(false);
            this.cmsRibbonTabTextColour.ResumeLayout(false);
            this.cmsStatusTextColour.ResumeLayout(false);
            this.cmsMenuTextColour.ResumeLayout(false);
            this.cmsCustomTextColourFive.ResumeLayout(false);
            this.cmsCustomTextColourFour.ResumeLayout(false);
            this.cmsCustomTextColourThree.ResumeLayout(false);
            this.cmsCustomTextColourTwo.ResumeLayout(false);
            this.cmsCustomTextColourOne.ResumeLayout(false);
            this.cmsCustomColourFive.ResumeLayout(false);
            this.cmsCustomColourFour.ResumeLayout(false);
            this.cmsCustomColourThree.ResumeLayout(false);
            this.cmsCustomColourTwo.ResumeLayout(false);
            this.cmsCustomColourOne.ResumeLayout(false);
            this.cmsLinkVisitedColour.ResumeLayout(false);
            this.cmsLinkHoverColour.ResumeLayout(false);
            this.cmsLinkFocusedColour.ResumeLayout(false);
            this.cmsDisabledControlColour.ResumeLayout(false);
            this.cmsPressedTextColour.ResumeLayout(false);
            this.cmsFocusedTextColour.ResumeLayout(false);
            this.cmsDisabledTextColour.ResumeLayout(false);
            this.cmsNormalTextColour.ResumeLayout(false);
            this.cmsBorderColourOne.ResumeLayout(false);
            this.cmsLightestColour.ResumeLayout(false);
            this.cmsLightColour.ResumeLayout(false);
            this.cmsLinkNormalColour.ResumeLayout(false);
            this.cmsBaseColour.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxBorderColourTwo)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private bool _showColourInformation, _invertColours;

        private Color[] _paletteColours = new Color[30];

        private Color _defaultColour;

        private PictureBox[] _previews;

        private PaletteMode _paletteMode;

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

        [DefaultValue(false)]
        public bool InvertColours { get => _invertColours; set => _invertColours = value; }

        public Color[] PaletteColours { get => _paletteColours; set { _paletteColours = value; Invalidate(); } }

        public Color DefaultColour { get => _defaultColour; set { _defaultColour = value; Invalidate(); } }

        public PictureBox[] ColourPreviews { get => _previews; private set => _previews = value; }

        public KryptonPalette Palette { get => internalPalette; set => internalPalette = value; }

        public PaletteMode PaletteMode { get => _paletteMode; set => _paletteMode = value; }
        #endregion

        #region Constructors
        public PaletteDesignerUserControl()
        {
            InitializeComponent();

            InitColours();

            PropagateColourPreviewArray();
        }
        #endregion

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
        /// <summary>Setup the colour tool tips.</summary>
        /// <param name="displayToolTips">if set to <c>true</c> [display tool tips].</param>
        public void SetupColourToolTips(bool displayToolTips)
        {
            if (displayToolTips)
            {
                ColourInformation.SetTooltip(pbxBaseColour, "Base");

                ColourInformation.SetTooltip(pbxDarkColour, "Dark");

                ColourInformation.SetTooltip(pbxMediumColour, "Medium");

                ColourInformation.SetTooltip(pbxLightColour, "Light");

                ColourInformation.SetTooltip(pbxLightestColour, "Lightest");

                ColourInformation.SetTooltip(pbxBorderColourOne, "Border");

                ColourInformation.SetTooltip(pbxAlternativeNormalTextColour, "Alternative Normal Text");

                ColourInformation.SetTooltip(pbxNormalTextColour, "Normal Text");

                ColourInformation.SetTooltip(pbxDisabledTextColour, "Disabled Text");

                ColourInformation.SetTooltip(pbxFocusedTextColour, "Focused Text");

                ColourInformation.SetTooltip(pbxPressedTextColour, "Pressed Text");

                ColourInformation.SetTooltip(pbxDisabledControlColour, "Disabled Control");

                ColourInformation.SetTooltip(pbxLinkNormalColour, "Link Normal Text");

                ColourInformation.SetTooltip(pbxLinkFocusedColour, "Link Focused Text");

                ColourInformation.SetTooltip(pbxLinkHoverColour, "Link Hover Text");

                ColourInformation.SetTooltip(pbxLinkVisitedColour, "Link Visited Text");

                ColourInformation.SetTooltip(pbxCustomColourOne, "Custom Colour One");

                ColourInformation.SetTooltip(pbxCustomColourTwo, "Custom Colour Two");

                ColourInformation.SetTooltip(pbxCustomColourThree, "Custom Colour Three");

                ColourInformation.SetTooltip(pbxCustomColourFour, "Custom Colour Four");

                ColourInformation.SetTooltip(pbxCustomColourFive, "Custom Colour Five");

                ColourInformation.SetTooltip(pbxCustomTextColourOne, "Custom Text Colour One");

                ColourInformation.SetTooltip(pbxCustomTextColourTwo, "Custom Text Colour Two");

                ColourInformation.SetTooltip(pbxCustomTextColourThree, "Custom Text Colour Three");

                ColourInformation.SetTooltip(pbxCustomTextColourFour, "Custom Text Colour Four");

                ColourInformation.SetTooltip(pbxCustomTextColourFive, "Custom Text Colour Five");

                ColourInformation.SetTooltip(pbxMenuTextColour, "Menu Text");

                ColourInformation.SetTooltip(pbxStatusTextColour, "Status Strip Text");

                ColourInformation.SetTooltip(pbxRibbonTabColour, "Ribbon Tab");
            }
        }

        /// <summary>Propagates the colour preview array.</summary>
        private void PropagateColourPreviewArray()
        {
            _previews = new PictureBox[30];

            ColourPreviews[0] = pbxBaseColour;

            ColourPreviews[1] = pbxDarkColour;

            ColourPreviews[2] = pbxMediumColour;

            ColourPreviews[3] = pbxLightColour;

            ColourPreviews[4] = pbxLightestColour;

            ColourPreviews[5] = pbxBorderColourOne;

            ColourPreviews[6] = pbxAlternativeNormalTextColour;

            ColourPreviews[7] = pbxNormalTextColour;

            ColourPreviews[8] = pbxDisabledTextColour;

            ColourPreviews[9] = pbxFocusedTextColour;

            ColourPreviews[10] = pbxPressedTextColour;

            ColourPreviews[11] = pbxDisabledControlColour;

            ColourPreviews[12] = pbxLinkNormalColour;

            ColourPreviews[13] = pbxLinkFocusedColour;

            ColourPreviews[14] = pbxLinkHoverColour;

            ColourPreviews[15] = pbxLinkVisitedColour;

            ColourPreviews[16] = pbxCustomColourOne;

            ColourPreviews[17] = pbxCustomColourTwo;

            ColourPreviews[18] = pbxCustomColourThree;

            ColourPreviews[19] = pbxCustomColourFour;

            ColourPreviews[20] = pbxCustomColourFive;

            ColourPreviews[21] = pbxCustomTextColourOne;

            ColourPreviews[22] = pbxCustomTextColourTwo;

            ColourPreviews[23] = pbxCustomTextColourThree;

            ColourPreviews[24] = pbxCustomTextColourFour;

            ColourPreviews[25] = pbxCustomTextColourFive;

            ColourPreviews[26] = pbxMenuTextColour;

            ColourPreviews[27] = pbxStatusTextColour;

            ColourPreviews[28] = pbxRibbonTabColour;
        }

        /// <summary>Resets the colours.</summary>
        /// <param name="defaultColour">The default colour.</param>
        public void ResetColours(Color defaultColour)
        {
            try
            {
                foreach (PictureBox box in ColourPreviews)
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

        public void ExportPaletteColours()
        {
            try
            {
                foreach (Color c in PaletteColours)
                {
                    if (c != Color.Transparent || c != Color.Empty)
                    {
                        //KryptonPaletteCreationEngine.ExportPaletteTheme(Palette, PaletteMode, GetPaletteColours()[0], GetPaletteColours()[1], GetPaletteColours()[2], GetPaletteColours()[3], GetPaletteColours()[4], GetPaletteColours()[5], GetPaletteColours()[6], GetPaletteColours()[7], GetPaletteColours()[8], GetPaletteColours()[9], GetPaletteColours()[10], GetPaletteColours()[11], GetPaletteColours()[12], GetPaletteColours()[13], GetPaletteColours()[14], GetPaletteColours()[15], GetPaletteColours()[16], GetPaletteColours()[17], GetPaletteColours()[18], GetPaletteColours()[19], GetPaletteColours()[20], GetPaletteColours()[21], GetPaletteColours()[22], GetPaletteColours()[23], GetPaletteColours()[24], GetPaletteColours()[25], GetPaletteColours()[26], GetPaletteColours()[27], GetPaletteColours()[28], InvertColours);

                        KryptonPaletteCreationEngine.ExportPaletteTheme(Palette, PaletteMode, GetPaletteColours(), InvertColours);
                    }
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

        private void PaletteDesignerUserControl_Load(object sender, EventArgs e)
        {

        }
    }
}