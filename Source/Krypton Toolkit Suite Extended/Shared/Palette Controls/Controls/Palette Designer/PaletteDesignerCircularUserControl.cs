using Krypton.Toolkit.Extended.Palette.Controller;
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
        private Suite.Extended.Base.CircularPictureBox cpbxBorderColourOne;
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
        private Suite.Extended.Base.CircularPictureBox cpbxBorderColourTwo;
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
        private ContextMenuStrip cmsBorderColourOne;
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
        private ContextMenuStrip cmsCustomColourFour;
        private ToolStripMenuItem toolStripMenuItem18;
        private ContextMenuStrip cmsCustomColourFive;
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
        private ContextMenuStrip cmsMediumColour;
        private ToolStripMenuItem toolStripMenuItem28;
        private ContextMenuStrip cmsBorderColourTwo;
        private ToolStripMenuItem toolStripMenuItem29;
        private ToolStripSeparator toolStripMenuItem30;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem31;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem1;
        private ToolStripSeparator toolStripMenuItem57;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem28;
        private ToolStripSeparator toolStripMenuItem32;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem2;
        private ToolStripSeparator toolStripMenuItem33;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem3;
        private ToolStripSeparator toolStripMenuItem34;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem4;
        private ToolStripSeparator toolStripMenuItem35;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem5;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem6;
        private ToolStripSeparator toolStripMenuItem36;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem7;
        private ToolStripSeparator toolStripMenuItem37;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem8;
        private ToolStripSeparator toolStripMenuItem38;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem9;
        private ToolStripSeparator toolStripMenuItem39;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem10;
        private ToolStripSeparator toolStripMenuItem40;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem11;
        private ToolStripSeparator toolStripMenuItem41;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem12;
        private ToolStripSeparator toolStripMenuItem55;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem26;
        private ToolStripSeparator toolStripMenuItem54;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem25;
        private ToolStripSeparator toolStripMenuItem53;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem24;
        private ToolStripSeparator toolStripMenuItem52;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem23;
        private ToolStripSeparator toolStripMenuItem51;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem22;
        private ToolStripSeparator toolStripMenuItem50;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem21;
        private ToolStripSeparator toolStripMenuItem49;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem20;
        private ToolStripSeparator toolStripMenuItem48;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem19;
        private ToolStripSeparator toolStripMenuItem47;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem18;
        private ToolStripSeparator toolStripMenuItem46;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem17;
        private ToolStripSeparator toolStripMenuItem45;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem16;
        private ToolStripSeparator toolStripMenuItem44;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem15;
        private ToolStripSeparator toolStripMenuItem43;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem14;
        private ToolStripSeparator toolStripMenuItem42;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem13;
        private ToolStripSeparator toolStripMenuItem56;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem27;
        private ToolStripSeparator toolStripMenuItem58;
        private ToolStripMenuItem generateARandomColourToolStripMenuItem29;
        private Suite.Extended.Base.CircularPictureBox cpbxDarkColour;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cpbxBaseColour = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cmsBaseColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.useAsBaseColourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem30 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cpbxDarkColour = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cmsDarkColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem31 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cpbxMediumColour = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cmsMediumColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem28 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem57 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem28 = new System.Windows.Forms.ToolStripMenuItem();
            this.cpbxLightColour = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cmsLightColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem32 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.cpbxLightestColour = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cmsLightestColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem33 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.cpbxBorderColourOne = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cmsBorderColourOne = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem34 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.cpbxAlternativeNormalTextColour = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cmsAlternativeNormalTextColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem35 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.cpbxNormalTextColour = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cmsNormalTextColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.generateARandomColourToolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.cpbxDisabledTextColour = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cmsDisabledTextColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem36 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.cpbxFocusedTextColour = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cmsFocusedTextColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem37 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.cpbxPressedTextColour = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cmsPressedTextColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem38 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.cpbxDisabledControlColour = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cmsDisabledControlColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem39 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.cpbxLinkNormalColour = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cmsLinkNormalColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem40 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.cpbxLinkFocusedColour = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cmsLinkFocusedColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem41 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.cpbxStatusTextColour = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cmsStatusTextColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem26 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem55 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem26 = new System.Windows.Forms.ToolStripMenuItem();
            this.cpbxMenuTextColour = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cmsMenuTextColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem25 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem54 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem25 = new System.Windows.Forms.ToolStripMenuItem();
            this.cpbxCustomTextColourFive = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cmsCustomTextColourFive = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem24 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem53 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem24 = new System.Windows.Forms.ToolStripMenuItem();
            this.cpbxCustomTextColourFour = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cmsCustomTextColourFour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem23 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem52 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem23 = new System.Windows.Forms.ToolStripMenuItem();
            this.cpbxCustomTextColourThree = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cmsCustomTextColourThree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem22 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem51 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem22 = new System.Windows.Forms.ToolStripMenuItem();
            this.cpbxCustomTextColourTwo = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cmsCustomTextColourTwo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem21 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem50 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem21 = new System.Windows.Forms.ToolStripMenuItem();
            this.cpbxCustomTextColourOne = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cmsCustomTextColourOne = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem20 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem49 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem20 = new System.Windows.Forms.ToolStripMenuItem();
            this.cpbxCustomColourFive = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cmsCustomColourFive = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem19 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem48 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem19 = new System.Windows.Forms.ToolStripMenuItem();
            this.cpbxCustomColourFour = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cmsCustomColourFour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem18 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem47 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem18 = new System.Windows.Forms.ToolStripMenuItem();
            this.cpbxCustomColourThree = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cmsCustomColourThree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem17 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem46 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem17 = new System.Windows.Forms.ToolStripMenuItem();
            this.cpbxCustomColourTwo = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cmsCustomColourTwo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem16 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem45 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem16 = new System.Windows.Forms.ToolStripMenuItem();
            this.cpbxCustomColourOne = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cmsCustomColourOne = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem15 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem44 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem15 = new System.Windows.Forms.ToolStripMenuItem();
            this.cpbxLinkVisitedColour = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cmsLinkVisitedColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem43 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
            this.cpbxLinkHoverColour = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cmsLinkHoverColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem42 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
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
            this.cpbxBorderColourTwo = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cmsBorderColourTwo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem29 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem58 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem29 = new System.Windows.Forms.ToolStripMenuItem();
            this.cpbxRibbonTabTextColour = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.cmsRibbonTabTextColour = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem27 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem56 = new System.Windows.Forms.ToolStripSeparator();
            this.generateARandomColourToolStripMenuItem27 = new System.Windows.Forms.ToolStripMenuItem();
            this.ttColourInformation = new System.Windows.Forms.ToolTip(this.components);
            this.internalPalette = new Krypton.Toolkit.KryptonPalette(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cpbxBaseColour)).BeginInit();
            this.cmsBaseColour.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxDarkColour)).BeginInit();
            this.cmsDarkColour.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxMediumColour)).BeginInit();
            this.cmsMediumColour.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxLightColour)).BeginInit();
            this.cmsLightColour.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxLightestColour)).BeginInit();
            this.cmsLightestColour.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxBorderColourOne)).BeginInit();
            this.cmsBorderColourOne.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxAlternativeNormalTextColour)).BeginInit();
            this.cmsAlternativeNormalTextColour.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxNormalTextColour)).BeginInit();
            this.cmsNormalTextColour.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxDisabledTextColour)).BeginInit();
            this.cmsDisabledTextColour.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxFocusedTextColour)).BeginInit();
            this.cmsFocusedTextColour.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxPressedTextColour)).BeginInit();
            this.cmsPressedTextColour.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxDisabledControlColour)).BeginInit();
            this.cmsDisabledControlColour.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxLinkNormalColour)).BeginInit();
            this.cmsLinkNormalColour.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxLinkFocusedColour)).BeginInit();
            this.cmsLinkFocusedColour.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxStatusTextColour)).BeginInit();
            this.cmsStatusTextColour.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxMenuTextColour)).BeginInit();
            this.cmsMenuTextColour.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxCustomTextColourFive)).BeginInit();
            this.cmsCustomTextColourFive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxCustomTextColourFour)).BeginInit();
            this.cmsCustomTextColourFour.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxCustomTextColourThree)).BeginInit();
            this.cmsCustomTextColourThree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxCustomTextColourTwo)).BeginInit();
            this.cmsCustomTextColourTwo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxCustomTextColourOne)).BeginInit();
            this.cmsCustomTextColourOne.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxCustomColourFive)).BeginInit();
            this.cmsCustomColourFive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxCustomColourFour)).BeginInit();
            this.cmsCustomColourFour.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxCustomColourThree)).BeginInit();
            this.cmsCustomColourThree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxCustomColourTwo)).BeginInit();
            this.cmsCustomColourTwo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxCustomColourOne)).BeginInit();
            this.cmsCustomColourOne.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxLinkVisitedColour)).BeginInit();
            this.cmsLinkVisitedColour.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxLinkHoverColour)).BeginInit();
            this.cmsLinkHoverColour.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.cpbxBorderColourTwo)).BeginInit();
            this.cmsBorderColourTwo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxRibbonTabTextColour)).BeginInit();
            this.cmsRibbonTabTextColour.SuspendLayout();
            this.SuspendLayout();
            // 
            // cpbxBaseColour
            // 
            this.cpbxBaseColour.BackColor = System.Drawing.Color.White;
            this.cpbxBaseColour.ContextMenuStrip = this.cmsBaseColour;
            this.cpbxBaseColour.Location = new System.Drawing.Point(13, 13);
            this.cpbxBaseColour.Name = "cpbxBaseColour";
            this.cpbxBaseColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxBaseColour.TabIndex = 0;
            this.cpbxBaseColour.TabStop = false;
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
            this.useAsBaseColourToolStripMenuItem.Click += new System.EventHandler(this.useAsBaseColourToolStripMenuItem_Click);
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
            this.generateARandomColourToolStripMenuItem.Click += new System.EventHandler(this.generateARandomColourToolStripMenuItem_Click);
            // 
            // cpbxDarkColour
            // 
            this.cpbxDarkColour.BackColor = System.Drawing.Color.White;
            this.cpbxDarkColour.ContextMenuStrip = this.cmsDarkColour;
            this.cpbxDarkColour.Location = new System.Drawing.Point(95, 13);
            this.cpbxDarkColour.Name = "cpbxDarkColour";
            this.cpbxDarkColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxDarkColour.TabIndex = 1;
            this.cpbxDarkColour.TabStop = false;
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
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
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
            this.generateARandomColourToolStripMenuItem1.Click += new System.EventHandler(this.generateARandomColourToolStripMenuItem1_Click);
            // 
            // cpbxMediumColour
            // 
            this.cpbxMediumColour.BackColor = System.Drawing.Color.White;
            this.cpbxMediumColour.ContextMenuStrip = this.cmsMediumColour;
            this.cpbxMediumColour.Location = new System.Drawing.Point(177, 13);
            this.cpbxMediumColour.Name = "cpbxMediumColour";
            this.cpbxMediumColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxMediumColour.TabIndex = 2;
            this.cpbxMediumColour.TabStop = false;
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
            this.toolStripMenuItem28.Click += new System.EventHandler(this.toolStripMenuItem28_Click);
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
            this.generateARandomColourToolStripMenuItem28.Click += new System.EventHandler(this.generateARandomColourToolStripMenuItem28_Click);
            // 
            // cpbxLightColour
            // 
            this.cpbxLightColour.BackColor = System.Drawing.Color.White;
            this.cpbxLightColour.ContextMenuStrip = this.cmsLightColour;
            this.cpbxLightColour.Location = new System.Drawing.Point(259, 13);
            this.cpbxLightColour.Name = "cpbxLightColour";
            this.cpbxLightColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxLightColour.TabIndex = 3;
            this.cpbxLightColour.TabStop = false;
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
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
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
            this.generateARandomColourToolStripMenuItem2.Click += new System.EventHandler(this.generateARandomColourToolStripMenuItem2_Click);
            // 
            // cpbxLightestColour
            // 
            this.cpbxLightestColour.BackColor = System.Drawing.Color.White;
            this.cpbxLightestColour.ContextMenuStrip = this.cmsLightestColour;
            this.cpbxLightestColour.Location = new System.Drawing.Point(341, 13);
            this.cpbxLightestColour.Name = "cpbxLightestColour";
            this.cpbxLightestColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxLightestColour.TabIndex = 4;
            this.cpbxLightestColour.TabStop = false;
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
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
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
            this.generateARandomColourToolStripMenuItem3.Click += new System.EventHandler(this.generateARandomColourToolStripMenuItem3_Click);
            // 
            // cpbxBorderColourOne
            // 
            this.cpbxBorderColourOne.BackColor = System.Drawing.Color.White;
            this.cpbxBorderColourOne.ContextMenuStrip = this.cmsBorderColourOne;
            this.cpbxBorderColourOne.Location = new System.Drawing.Point(423, 13);
            this.cpbxBorderColourOne.Name = "cpbxBorderColourOne";
            this.cpbxBorderColourOne.Size = new System.Drawing.Size(64, 64);
            this.cpbxBorderColourOne.TabIndex = 5;
            this.cpbxBorderColourOne.TabStop = false;
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
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
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
            this.generateARandomColourToolStripMenuItem4.Click += new System.EventHandler(this.generateARandomColourToolStripMenuItem4_Click);
            // 
            // cpbxAlternativeNormalTextColour
            // 
            this.cpbxAlternativeNormalTextColour.BackColor = System.Drawing.Color.White;
            this.cpbxAlternativeNormalTextColour.ContextMenuStrip = this.cmsAlternativeNormalTextColour;
            this.cpbxAlternativeNormalTextColour.Location = new System.Drawing.Point(587, 13);
            this.cpbxAlternativeNormalTextColour.Name = "cpbxAlternativeNormalTextColour";
            this.cpbxAlternativeNormalTextColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxAlternativeNormalTextColour.TabIndex = 6;
            this.cpbxAlternativeNormalTextColour.TabStop = false;
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
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
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
            this.generateARandomColourToolStripMenuItem5.Click += new System.EventHandler(this.generateARandomColourToolStripMenuItem5_Click);
            // 
            // cpbxNormalTextColour
            // 
            this.cpbxNormalTextColour.BackColor = System.Drawing.Color.White;
            this.cpbxNormalTextColour.ContextMenuStrip = this.cmsNormalTextColour;
            this.cpbxNormalTextColour.Location = new System.Drawing.Point(669, 13);
            this.cpbxNormalTextColour.Name = "cpbxNormalTextColour";
            this.cpbxNormalTextColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxNormalTextColour.TabIndex = 7;
            this.cpbxNormalTextColour.TabStop = false;
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
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // generateARandomColourToolStripMenuItem6
            // 
            this.generateARandomColourToolStripMenuItem6.Name = "generateARandomColourToolStripMenuItem6";
            this.generateARandomColourToolStripMenuItem6.Size = new System.Drawing.Size(217, 22);
            this.generateARandomColourToolStripMenuItem6.Text = "Generate a &Random Colour";
            this.generateARandomColourToolStripMenuItem6.Click += new System.EventHandler(this.generateARandomColourToolStripMenuItem6_Click);
            // 
            // cpbxDisabledTextColour
            // 
            this.cpbxDisabledTextColour.BackColor = System.Drawing.Color.White;
            this.cpbxDisabledTextColour.ContextMenuStrip = this.cmsDisabledTextColour;
            this.cpbxDisabledTextColour.Location = new System.Drawing.Point(751, 13);
            this.cpbxDisabledTextColour.Name = "cpbxDisabledTextColour";
            this.cpbxDisabledTextColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxDisabledTextColour.TabIndex = 8;
            this.cpbxDisabledTextColour.TabStop = false;
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
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
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
            this.generateARandomColourToolStripMenuItem7.Click += new System.EventHandler(this.generateARandomColourToolStripMenuItem7_Click);
            // 
            // cpbxFocusedTextColour
            // 
            this.cpbxFocusedTextColour.BackColor = System.Drawing.Color.White;
            this.cpbxFocusedTextColour.ContextMenuStrip = this.cmsFocusedTextColour;
            this.cpbxFocusedTextColour.Location = new System.Drawing.Point(833, 13);
            this.cpbxFocusedTextColour.Name = "cpbxFocusedTextColour";
            this.cpbxFocusedTextColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxFocusedTextColour.TabIndex = 9;
            this.cpbxFocusedTextColour.TabStop = false;
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
            this.toolStripMenuItem8.Click += new System.EventHandler(this.toolStripMenuItem8_Click);
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
            this.generateARandomColourToolStripMenuItem8.Click += new System.EventHandler(this.generateARandomColourToolStripMenuItem8_Click);
            // 
            // cpbxPressedTextColour
            // 
            this.cpbxPressedTextColour.BackColor = System.Drawing.Color.White;
            this.cpbxPressedTextColour.ContextMenuStrip = this.cmsPressedTextColour;
            this.cpbxPressedTextColour.Location = new System.Drawing.Point(915, 13);
            this.cpbxPressedTextColour.Name = "cpbxPressedTextColour";
            this.cpbxPressedTextColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxPressedTextColour.TabIndex = 10;
            this.cpbxPressedTextColour.TabStop = false;
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
            this.toolStripMenuItem9.Click += new System.EventHandler(this.toolStripMenuItem9_Click);
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
            this.generateARandomColourToolStripMenuItem9.Click += new System.EventHandler(this.generateARandomColourToolStripMenuItem9_Click);
            // 
            // cpbxDisabledControlColour
            // 
            this.cpbxDisabledControlColour.BackColor = System.Drawing.Color.White;
            this.cpbxDisabledControlColour.ContextMenuStrip = this.cmsDisabledControlColour;
            this.cpbxDisabledControlColour.Location = new System.Drawing.Point(997, 13);
            this.cpbxDisabledControlColour.Name = "cpbxDisabledControlColour";
            this.cpbxDisabledControlColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxDisabledControlColour.TabIndex = 11;
            this.cpbxDisabledControlColour.TabStop = false;
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
            this.toolStripMenuItem10.Click += new System.EventHandler(this.toolStripMenuItem10_Click);
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
            this.generateARandomColourToolStripMenuItem10.Click += new System.EventHandler(this.generateARandomColourToolStripMenuItem10_Click);
            // 
            // cpbxLinkNormalColour
            // 
            this.cpbxLinkNormalColour.BackColor = System.Drawing.Color.White;
            this.cpbxLinkNormalColour.ContextMenuStrip = this.cmsLinkNormalColour;
            this.cpbxLinkNormalColour.Location = new System.Drawing.Point(95, 165);
            this.cpbxLinkNormalColour.Name = "cpbxLinkNormalColour";
            this.cpbxLinkNormalColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxLinkNormalColour.TabIndex = 12;
            this.cpbxLinkNormalColour.TabStop = false;
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
            this.toolStripMenuItem11.Click += new System.EventHandler(this.toolStripMenuItem11_Click);
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
            this.generateARandomColourToolStripMenuItem11.Click += new System.EventHandler(this.generateARandomColourToolStripMenuItem11_Click);
            // 
            // cpbxLinkFocusedColour
            // 
            this.cpbxLinkFocusedColour.BackColor = System.Drawing.Color.White;
            this.cpbxLinkFocusedColour.ContextMenuStrip = this.cmsLinkFocusedColour;
            this.cpbxLinkFocusedColour.Location = new System.Drawing.Point(1079, 13);
            this.cpbxLinkFocusedColour.Name = "cpbxLinkFocusedColour";
            this.cpbxLinkFocusedColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxLinkFocusedColour.TabIndex = 13;
            this.cpbxLinkFocusedColour.TabStop = false;
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
            this.toolStripMenuItem12.Click += new System.EventHandler(this.toolStripMenuItem12_Click);
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
            this.generateARandomColourToolStripMenuItem12.Click += new System.EventHandler(this.generateARandomColourToolStripMenuItem12_Click);
            // 
            // cpbxStatusTextColour
            // 
            this.cpbxStatusTextColour.BackColor = System.Drawing.Color.White;
            this.cpbxStatusTextColour.ContextMenuStrip = this.cmsStatusTextColour;
            this.cpbxStatusTextColour.Location = new System.Drawing.Point(13, 318);
            this.cpbxStatusTextColour.Name = "cpbxStatusTextColour";
            this.cpbxStatusTextColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxStatusTextColour.TabIndex = 27;
            this.cpbxStatusTextColour.TabStop = false;
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
            this.toolStripMenuItem26.Click += new System.EventHandler(this.toolStripMenuItem26_Click);
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
            this.generateARandomColourToolStripMenuItem26.Click += new System.EventHandler(this.generateARandomColourToolStripMenuItem26_Click);
            // 
            // cpbxMenuTextColour
            // 
            this.cpbxMenuTextColour.BackColor = System.Drawing.Color.White;
            this.cpbxMenuTextColour.ContextMenuStrip = this.cmsMenuTextColour;
            this.cpbxMenuTextColour.Location = new System.Drawing.Point(1079, 165);
            this.cpbxMenuTextColour.Name = "cpbxMenuTextColour";
            this.cpbxMenuTextColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxMenuTextColour.TabIndex = 26;
            this.cpbxMenuTextColour.TabStop = false;
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
            this.toolStripMenuItem25.Click += new System.EventHandler(this.toolStripMenuItem25_Click);
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
            this.generateARandomColourToolStripMenuItem25.Click += new System.EventHandler(this.generateARandomColourToolStripMenuItem25_Click);
            // 
            // cpbxCustomTextColourFive
            // 
            this.cpbxCustomTextColourFive.BackColor = System.Drawing.Color.White;
            this.cpbxCustomTextColourFive.ContextMenuStrip = this.cmsCustomTextColourFive;
            this.cpbxCustomTextColourFive.Location = new System.Drawing.Point(997, 165);
            this.cpbxCustomTextColourFive.Name = "cpbxCustomTextColourFive";
            this.cpbxCustomTextColourFive.Size = new System.Drawing.Size(64, 64);
            this.cpbxCustomTextColourFive.TabIndex = 25;
            this.cpbxCustomTextColourFive.TabStop = false;
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
            this.toolStripMenuItem24.Click += new System.EventHandler(this.toolStripMenuItem24_Click);
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
            this.generateARandomColourToolStripMenuItem24.Click += new System.EventHandler(this.generateARandomColourToolStripMenuItem24_Click);
            // 
            // cpbxCustomTextColourFour
            // 
            this.cpbxCustomTextColourFour.BackColor = System.Drawing.Color.White;
            this.cpbxCustomTextColourFour.ContextMenuStrip = this.cmsCustomTextColourFour;
            this.cpbxCustomTextColourFour.Location = new System.Drawing.Point(915, 165);
            this.cpbxCustomTextColourFour.Name = "cpbxCustomTextColourFour";
            this.cpbxCustomTextColourFour.Size = new System.Drawing.Size(64, 64);
            this.cpbxCustomTextColourFour.TabIndex = 24;
            this.cpbxCustomTextColourFour.TabStop = false;
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
            this.toolStripMenuItem23.Click += new System.EventHandler(this.toolStripMenuItem23_Click);
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
            this.generateARandomColourToolStripMenuItem23.Click += new System.EventHandler(this.generateARandomColourToolStripMenuItem23_Click);
            // 
            // cpbxCustomTextColourThree
            // 
            this.cpbxCustomTextColourThree.BackColor = System.Drawing.Color.White;
            this.cpbxCustomTextColourThree.ContextMenuStrip = this.cmsCustomTextColourThree;
            this.cpbxCustomTextColourThree.Location = new System.Drawing.Point(833, 165);
            this.cpbxCustomTextColourThree.Name = "cpbxCustomTextColourThree";
            this.cpbxCustomTextColourThree.Size = new System.Drawing.Size(64, 64);
            this.cpbxCustomTextColourThree.TabIndex = 23;
            this.cpbxCustomTextColourThree.TabStop = false;
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
            this.toolStripMenuItem22.Click += new System.EventHandler(this.toolStripMenuItem22_Click);
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
            this.generateARandomColourToolStripMenuItem22.Click += new System.EventHandler(this.generateARandomColourToolStripMenuItem22_Click);
            // 
            // cpbxCustomTextColourTwo
            // 
            this.cpbxCustomTextColourTwo.BackColor = System.Drawing.Color.White;
            this.cpbxCustomTextColourTwo.ContextMenuStrip = this.cmsCustomTextColourTwo;
            this.cpbxCustomTextColourTwo.Location = new System.Drawing.Point(751, 165);
            this.cpbxCustomTextColourTwo.Name = "cpbxCustomTextColourTwo";
            this.cpbxCustomTextColourTwo.Size = new System.Drawing.Size(64, 64);
            this.cpbxCustomTextColourTwo.TabIndex = 22;
            this.cpbxCustomTextColourTwo.TabStop = false;
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
            this.toolStripMenuItem21.Click += new System.EventHandler(this.toolStripMenuItem21_Click);
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
            this.generateARandomColourToolStripMenuItem21.Click += new System.EventHandler(this.generateARandomColourToolStripMenuItem21_Click);
            // 
            // cpbxCustomTextColourOne
            // 
            this.cpbxCustomTextColourOne.BackColor = System.Drawing.Color.White;
            this.cpbxCustomTextColourOne.ContextMenuStrip = this.cmsCustomTextColourOne;
            this.cpbxCustomTextColourOne.Location = new System.Drawing.Point(669, 165);
            this.cpbxCustomTextColourOne.Name = "cpbxCustomTextColourOne";
            this.cpbxCustomTextColourOne.Size = new System.Drawing.Size(64, 64);
            this.cpbxCustomTextColourOne.TabIndex = 21;
            this.cpbxCustomTextColourOne.TabStop = false;
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
            this.toolStripMenuItem20.Click += new System.EventHandler(this.toolStripMenuItem20_Click);
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
            this.generateARandomColourToolStripMenuItem20.Click += new System.EventHandler(this.generateARandomColourToolStripMenuItem20_Click);
            // 
            // cpbxCustomColourFive
            // 
            this.cpbxCustomColourFive.BackColor = System.Drawing.Color.White;
            this.cpbxCustomColourFive.ContextMenuStrip = this.cmsCustomColourFive;
            this.cpbxCustomColourFive.Location = new System.Drawing.Point(587, 165);
            this.cpbxCustomColourFive.Name = "cpbxCustomColourFive";
            this.cpbxCustomColourFive.Size = new System.Drawing.Size(64, 64);
            this.cpbxCustomColourFive.TabIndex = 20;
            this.cpbxCustomColourFive.TabStop = false;
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
            this.toolStripMenuItem19.Click += new System.EventHandler(this.toolStripMenuItem19_Click);
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
            this.generateARandomColourToolStripMenuItem19.Click += new System.EventHandler(this.generateARandomColourToolStripMenuItem19_Click);
            // 
            // cpbxCustomColourFour
            // 
            this.cpbxCustomColourFour.BackColor = System.Drawing.Color.White;
            this.cpbxCustomColourFour.ContextMenuStrip = this.cmsCustomColourFour;
            this.cpbxCustomColourFour.Location = new System.Drawing.Point(505, 165);
            this.cpbxCustomColourFour.Name = "cpbxCustomColourFour";
            this.cpbxCustomColourFour.Size = new System.Drawing.Size(64, 64);
            this.cpbxCustomColourFour.TabIndex = 19;
            this.cpbxCustomColourFour.TabStop = false;
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
            this.toolStripMenuItem18.Click += new System.EventHandler(this.toolStripMenuItem18_Click);
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
            this.generateARandomColourToolStripMenuItem18.Click += new System.EventHandler(this.generateARandomColourToolStripMenuItem18_Click);
            // 
            // cpbxCustomColourThree
            // 
            this.cpbxCustomColourThree.BackColor = System.Drawing.Color.White;
            this.cpbxCustomColourThree.ContextMenuStrip = this.cmsCustomColourThree;
            this.cpbxCustomColourThree.Location = new System.Drawing.Point(423, 165);
            this.cpbxCustomColourThree.Name = "cpbxCustomColourThree";
            this.cpbxCustomColourThree.Size = new System.Drawing.Size(64, 64);
            this.cpbxCustomColourThree.TabIndex = 18;
            this.cpbxCustomColourThree.TabStop = false;
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
            this.toolStripMenuItem17.Click += new System.EventHandler(this.toolStripMenuItem17_Click);
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
            this.generateARandomColourToolStripMenuItem17.Click += new System.EventHandler(this.generateARandomColourToolStripMenuItem17_Click);
            // 
            // cpbxCustomColourTwo
            // 
            this.cpbxCustomColourTwo.BackColor = System.Drawing.Color.White;
            this.cpbxCustomColourTwo.ContextMenuStrip = this.cmsCustomColourTwo;
            this.cpbxCustomColourTwo.Location = new System.Drawing.Point(341, 165);
            this.cpbxCustomColourTwo.Name = "cpbxCustomColourTwo";
            this.cpbxCustomColourTwo.Size = new System.Drawing.Size(64, 64);
            this.cpbxCustomColourTwo.TabIndex = 17;
            this.cpbxCustomColourTwo.TabStop = false;
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
            this.toolStripMenuItem16.Click += new System.EventHandler(this.toolStripMenuItem16_Click);
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
            this.generateARandomColourToolStripMenuItem16.Click += new System.EventHandler(this.generateARandomColourToolStripMenuItem16_Click);
            // 
            // cpbxCustomColourOne
            // 
            this.cpbxCustomColourOne.BackColor = System.Drawing.Color.White;
            this.cpbxCustomColourOne.ContextMenuStrip = this.cmsCustomColourOne;
            this.cpbxCustomColourOne.Location = new System.Drawing.Point(259, 165);
            this.cpbxCustomColourOne.Name = "cpbxCustomColourOne";
            this.cpbxCustomColourOne.Size = new System.Drawing.Size(64, 64);
            this.cpbxCustomColourOne.TabIndex = 16;
            this.cpbxCustomColourOne.TabStop = false;
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
            this.toolStripMenuItem15.Click += new System.EventHandler(this.toolStripMenuItem15_Click);
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
            this.generateARandomColourToolStripMenuItem15.Click += new System.EventHandler(this.generateARandomColourToolStripMenuItem15_Click);
            // 
            // cpbxLinkVisitedColour
            // 
            this.cpbxLinkVisitedColour.BackColor = System.Drawing.Color.White;
            this.cpbxLinkVisitedColour.ContextMenuStrip = this.cmsLinkVisitedColour;
            this.cpbxLinkVisitedColour.Location = new System.Drawing.Point(177, 165);
            this.cpbxLinkVisitedColour.Name = "cpbxLinkVisitedColour";
            this.cpbxLinkVisitedColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxLinkVisitedColour.TabIndex = 15;
            this.cpbxLinkVisitedColour.TabStop = false;
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
            this.toolStripMenuItem14.Click += new System.EventHandler(this.toolStripMenuItem14_Click);
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
            this.generateARandomColourToolStripMenuItem14.Click += new System.EventHandler(this.generateARandomColourToolStripMenuItem14_Click);
            // 
            // cpbxLinkHoverColour
            // 
            this.cpbxLinkHoverColour.BackColor = System.Drawing.Color.White;
            this.cpbxLinkHoverColour.ContextMenuStrip = this.cmsLinkHoverColour;
            this.cpbxLinkHoverColour.Location = new System.Drawing.Point(13, 165);
            this.cpbxLinkHoverColour.Name = "cpbxLinkHoverColour";
            this.cpbxLinkHoverColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxLinkHoverColour.TabIndex = 14;
            this.cpbxLinkHoverColour.TabStop = false;
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
            this.toolStripMenuItem13.Click += new System.EventHandler(this.toolStripMenuItem13_Click);
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
            this.generateARandomColourToolStripMenuItem13.Click += new System.EventHandler(this.generateARandomColourToolStripMenuItem13_Click);
            // 
            // cbpxDisabledTextColour
            // 
            this.cbpxDisabledTextColour.BackColor = System.Drawing.Color.White;
            this.cbpxDisabledTextColour.Location = new System.Drawing.Point(1079, 318);
            this.cbpxDisabledTextColour.Name = "cbpxDisabledTextColour";
            this.cbpxDisabledTextColour.Size = new System.Drawing.Size(64, 64);
            this.cbpxDisabledTextColour.TabIndex = 41;
            this.cbpxDisabledTextColour.TabStop = false;
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
            this.circularPictureBox40.Visible = false;
            // 
            // cpbxBorderColourTwo
            // 
            this.cpbxBorderColourTwo.BackColor = System.Drawing.Color.White;
            this.cpbxBorderColourTwo.ContextMenuStrip = this.cmsBorderColourTwo;
            this.cpbxBorderColourTwo.Location = new System.Drawing.Point(505, 13);
            this.cpbxBorderColourTwo.Name = "cpbxBorderColourTwo";
            this.cpbxBorderColourTwo.Size = new System.Drawing.Size(64, 64);
            this.cpbxBorderColourTwo.TabIndex = 29;
            this.cpbxBorderColourTwo.TabStop = false;
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
            this.toolStripMenuItem29.Click += new System.EventHandler(this.toolStripMenuItem29_Click);
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
            this.generateARandomColourToolStripMenuItem29.Click += new System.EventHandler(this.generateARandomColourToolStripMenuItem29_Click);
            // 
            // cpbxRibbonTabTextColour
            // 
            this.cpbxRibbonTabTextColour.BackColor = System.Drawing.Color.White;
            this.cpbxRibbonTabTextColour.ContextMenuStrip = this.cmsRibbonTabTextColour;
            this.cpbxRibbonTabTextColour.Location = new System.Drawing.Point(95, 318);
            this.cpbxRibbonTabTextColour.Name = "cpbxRibbonTabTextColour";
            this.cpbxRibbonTabTextColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxRibbonTabTextColour.TabIndex = 28;
            this.cpbxRibbonTabTextColour.TabStop = false;
            // 
            // cmsRibbonTabTextColour
            // 
            this.cmsRibbonTabTextColour.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsRibbonTabTextColour.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem27,
            this.toolStripMenuItem56,
            this.generateARandomColourToolStripMenuItem27});
            this.cmsRibbonTabTextColour.Name = "contextMenuStrip1";
            this.cmsRibbonTabTextColour.Size = new System.Drawing.Size(218, 76);
            // 
            // toolStripMenuItem27
            // 
            this.toolStripMenuItem27.Name = "toolStripMenuItem27";
            this.toolStripMenuItem27.Size = new System.Drawing.Size(217, 22);
            this.toolStripMenuItem27.Text = "Use as &Base Colour";
            this.toolStripMenuItem27.Click += new System.EventHandler(this.toolStripMenuItem27_Click);
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
            this.generateARandomColourToolStripMenuItem27.Click += new System.EventHandler(this.generateARandomColourToolStripMenuItem27_Click);
            // 
            // internalPalette
            // 
            this.internalPalette.CustomisedKryptonPaletteFilePath = null;
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
            this.Controls.Add(this.cpbxBorderColourTwo);
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
            this.Controls.Add(this.cpbxBorderColourOne);
            this.Controls.Add(this.cpbxLightestColour);
            this.Controls.Add(this.cpbxLightColour);
            this.Controls.Add(this.cpbxMediumColour);
            this.Controls.Add(this.cpbxDarkColour);
            this.Controls.Add(this.cpbxBaseColour);
            this.Name = "PaletteDesignerCircularUserControl";
            this.Size = new System.Drawing.Size(1161, 423);
            this.Load += new System.EventHandler(this.PaletteDesignerCircularUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cpbxBaseColour)).EndInit();
            this.cmsBaseColour.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cpbxDarkColour)).EndInit();
            this.cmsDarkColour.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cpbxMediumColour)).EndInit();
            this.cmsMediumColour.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cpbxLightColour)).EndInit();
            this.cmsLightColour.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cpbxLightestColour)).EndInit();
            this.cmsLightestColour.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cpbxBorderColourOne)).EndInit();
            this.cmsBorderColourOne.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cpbxAlternativeNormalTextColour)).EndInit();
            this.cmsAlternativeNormalTextColour.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cpbxNormalTextColour)).EndInit();
            this.cmsNormalTextColour.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cpbxDisabledTextColour)).EndInit();
            this.cmsDisabledTextColour.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cpbxFocusedTextColour)).EndInit();
            this.cmsFocusedTextColour.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cpbxPressedTextColour)).EndInit();
            this.cmsPressedTextColour.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cpbxDisabledControlColour)).EndInit();
            this.cmsDisabledControlColour.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cpbxLinkNormalColour)).EndInit();
            this.cmsLinkNormalColour.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cpbxLinkFocusedColour)).EndInit();
            this.cmsLinkFocusedColour.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cpbxStatusTextColour)).EndInit();
            this.cmsStatusTextColour.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cpbxMenuTextColour)).EndInit();
            this.cmsMenuTextColour.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cpbxCustomTextColourFive)).EndInit();
            this.cmsCustomTextColourFive.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cpbxCustomTextColourFour)).EndInit();
            this.cmsCustomTextColourFour.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cpbxCustomTextColourThree)).EndInit();
            this.cmsCustomTextColourThree.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cpbxCustomTextColourTwo)).EndInit();
            this.cmsCustomTextColourTwo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cpbxCustomTextColourOne)).EndInit();
            this.cmsCustomTextColourOne.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cpbxCustomColourFive)).EndInit();
            this.cmsCustomColourFive.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cpbxCustomColourFour)).EndInit();
            this.cmsCustomColourFour.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cpbxCustomColourThree)).EndInit();
            this.cmsCustomColourThree.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cpbxCustomColourTwo)).EndInit();
            this.cmsCustomColourTwo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cpbxCustomColourOne)).EndInit();
            this.cmsCustomColourOne.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cpbxLinkVisitedColour)).EndInit();
            this.cmsLinkVisitedColour.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cpbxLinkHoverColour)).EndInit();
            this.cmsLinkHoverColour.ResumeLayout(false);
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
            ((System.ComponentModel.ISupportInitialize)(this.cpbxBorderColourTwo)).EndInit();
            this.cmsBorderColourTwo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cpbxRibbonTabTextColour)).EndInit();
            this.cmsRibbonTabTextColour.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private bool _showColourInformation, _invertColours;

        private Color[] _paletteColours = new Color[30];

        private Color _defaultColour;

        private Suite.Extended.Base.CircularPictureBox[] _previews;

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
        public bool ShowColourInformation { get => _showColourInformation; set { _showColourInformation = value; Invalidate(); } }

        [DefaultValue(false)]
        public bool InvertColours { get => _invertColours; set => _invertColours = value; }

        public Color[] PaletteColours { get => _paletteColours; set { _paletteColours = value; Invalidate(); } }

        public Color DefaultColour { get => _defaultColour; set { _defaultColour = value; Invalidate(); } }

        public Suite.Extended.Base.CircularPictureBox[] ColourPreviews { get => _previews; private set => _previews = value; }

        public KryptonPalette Palette { get => internalPalette; set => internalPalette = value; }

        public PaletteMode PaletteMode { get => _paletteMode; set => _paletteMode = value; }
        #endregion

        #region Constructors
        public PaletteDesignerCircularUserControl()
        {
            InitializeComponent();

            PropagateColourPreviewArray();
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

                ColourInformation.SetTooltip(cpbxBorderColourOne, "Border One");

                ColourInformation.SetTooltip(cpbxBorderColourTwo, "Border Two");

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
                            //box.tt.Description = string.Empty;
                        }
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }
                }
            }
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

        public void GenerateRandomColours()
        {
            try
            {
                if (_previews.Length! < 0)
                {
                    generateARandomColourToolStripMenuItem.PerformClick();

                    generateARandomColourToolStripMenuItem1.PerformClick();

                    generateARandomColourToolStripMenuItem2.PerformClick();

                    generateARandomColourToolStripMenuItem3.PerformClick();

                    generateARandomColourToolStripMenuItem4.PerformClick();

                    generateARandomColourToolStripMenuItem5.PerformClick();

                    generateARandomColourToolStripMenuItem6.PerformClick();

                    generateARandomColourToolStripMenuItem7.PerformClick();

                    generateARandomColourToolStripMenuItem8.PerformClick();

                    generateARandomColourToolStripMenuItem9.PerformClick();

                    generateARandomColourToolStripMenuItem10.PerformClick();

                    generateARandomColourToolStripMenuItem11.PerformClick();

                    generateARandomColourToolStripMenuItem12.PerformClick();

                    generateARandomColourToolStripMenuItem13.PerformClick();

                    generateARandomColourToolStripMenuItem14.PerformClick();

                    generateARandomColourToolStripMenuItem15.PerformClick();

                    generateARandomColourToolStripMenuItem16.PerformClick();

                    generateARandomColourToolStripMenuItem17.PerformClick();

                    generateARandomColourToolStripMenuItem18.PerformClick();

                    generateARandomColourToolStripMenuItem19.PerformClick();

                    generateARandomColourToolStripMenuItem20.PerformClick();

                    generateARandomColourToolStripMenuItem21.PerformClick();

                    generateARandomColourToolStripMenuItem22.PerformClick();

                    generateARandomColourToolStripMenuItem23.PerformClick();

                    generateARandomColourToolStripMenuItem24.PerformClick();

                    generateARandomColourToolStripMenuItem25.PerformClick();

                    generateARandomColourToolStripMenuItem26.PerformClick();

                    generateARandomColourToolStripMenuItem27.PerformClick();

                    generateARandomColourToolStripMenuItem28.PerformClick();

                    generateARandomColourToolStripMenuItem29.PerformClick();

                    SetColourPreviews(PaletteColours);
                }
            }
            catch (Exception e)
            {

                throw;
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

        #region Event Handlers
        private void PaletteDesignerCircularUserControl_Load(object sender, EventArgs e)
        {

        }

        #region Generate Random Colours
        private void generateARandomColourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color randomColour = ColourExtensions.GenerateRandomColour();

            cpbxBaseColour.BackColor = randomColour;
        }

        private void generateARandomColourToolStripMenuItem28_Click(object sender, EventArgs e)
        {
            Color randomColour = ColourExtensions.GenerateRandomColour();

            cpbxMediumColour.BackColor = randomColour;
        }

        private void generateARandomColourToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Color randomColour = ColourExtensions.GenerateRandomColour();

            cpbxDarkColour.BackColor = randomColour;
        }

        private void generateARandomColourToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Color randomColour = ColourExtensions.GenerateRandomColour();

            cpbxLightColour.BackColor = randomColour;
        }

        private void generateARandomColourToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Color randomColour = ColourExtensions.GenerateRandomColour();

            cpbxLightestColour.BackColor = randomColour;
        }

        private void generateARandomColourToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Color randomColour = ColourExtensions.GenerateRandomColour();

            cpbxBorderColourOne.BackColor = randomColour;
        }

        private void generateARandomColourToolStripMenuItem29_Click(object sender, EventArgs e)
        {
            Color randomColour = ColourExtensions.GenerateRandomColour();

            cpbxBorderColourTwo.BackColor = randomColour;
        }

        private void generateARandomColourToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Color randomColour = ColourExtensions.GenerateRandomColour();

            cpbxAlternativeNormalTextColour.BackColor = randomColour;
        }

        private void generateARandomColourToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Color randomColour = ColourExtensions.GenerateRandomColour();

            cpbxNormalTextColour.BackColor = randomColour;
        }

        private void generateARandomColourToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Color randomColour = ColourExtensions.GenerateRandomColour();

            cpbxDisabledTextColour.BackColor = randomColour;
        }

        private void generateARandomColourToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Color randomColour = ColourExtensions.GenerateRandomColour();

            cpbxFocusedTextColour.BackColor = randomColour;
        }

        private void generateARandomColourToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            Color randomColour = ColourExtensions.GenerateRandomColour();

            cpbxPressedTextColour.BackColor = randomColour;
        }

        private void generateARandomColourToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            Color randomColour = ColourExtensions.GenerateRandomColour();

            cpbxDisabledControlColour.BackColor = randomColour;
        }

        private void generateARandomColourToolStripMenuItem11_Click(object sender, EventArgs e)
        {
            Color randomColour = ColourExtensions.GenerateRandomColour();

            cpbxLinkNormalColour.BackColor = randomColour;
        }

        private void generateARandomColourToolStripMenuItem12_Click(object sender, EventArgs e)
        {
            Color randomColour = ColourExtensions.GenerateRandomColour();

            cpbxLinkFocusedColour.BackColor = randomColour;
        }

        private void generateARandomColourToolStripMenuItem13_Click(object sender, EventArgs e)
        {
            Color randomColour = ColourExtensions.GenerateRandomColour();

            cpbxLinkHoverColour.BackColor = randomColour;
        }

        private void generateARandomColourToolStripMenuItem14_Click(object sender, EventArgs e)
        {
            Color randomColour = ColourExtensions.GenerateRandomColour();

            cpbxLinkVisitedColour.BackColor = randomColour;
        }

        private void generateARandomColourToolStripMenuItem15_Click(object sender, EventArgs e)
        {
            Color randomColour = ColourExtensions.GenerateRandomColour();

            cpbxCustomColourOne.BackColor = randomColour;
        }

        private void generateARandomColourToolStripMenuItem16_Click(object sender, EventArgs e)
        {
            Color randomColour = ColourExtensions.GenerateRandomColour();

            cpbxCustomColourTwo.BackColor = randomColour;
        }

        private void generateARandomColourToolStripMenuItem17_Click(object sender, EventArgs e)
        {
            Color randomColour = ColourExtensions.GenerateRandomColour();

            cpbxCustomColourThree.BackColor = randomColour;
        }

        private void generateARandomColourToolStripMenuItem18_Click(object sender, EventArgs e)
        {
            Color randomColour = ColourExtensions.GenerateRandomColour();

            cpbxCustomColourFour.BackColor = randomColour;
        }

        private void generateARandomColourToolStripMenuItem19_Click(object sender, EventArgs e)
        {
            Color randomColour = ColourExtensions.GenerateRandomColour();

            cpbxCustomColourFive.BackColor = randomColour;
        }

        private void generateARandomColourToolStripMenuItem20_Click(object sender, EventArgs e)
        {
            Color randomColour = ColourExtensions.GenerateRandomColour();

            cpbxCustomTextColourOne.BackColor = randomColour;
        }

        private void generateARandomColourToolStripMenuItem21_Click(object sender, EventArgs e)
        {
            Color randomColour = ColourExtensions.GenerateRandomColour();

            cpbxCustomTextColourTwo.BackColor = randomColour;
        }

        private void generateARandomColourToolStripMenuItem22_Click(object sender, EventArgs e)
        {
            Color randomColour = ColourExtensions.GenerateRandomColour();

            cpbxCustomTextColourThree.BackColor = randomColour;
        }

        private void generateARandomColourToolStripMenuItem23_Click(object sender, EventArgs e)
        {
            Color randomColour = ColourExtensions.GenerateRandomColour();

            cpbxCustomTextColourFour.BackColor = randomColour;
        }

        private void generateARandomColourToolStripMenuItem24_Click(object sender, EventArgs e)
        {
            Color randomColour = ColourExtensions.GenerateRandomColour();

            cpbxCustomTextColourFive.BackColor = randomColour;
        }

        private void generateARandomColourToolStripMenuItem25_Click(object sender, EventArgs e)
        {
            Color randomColour = ColourExtensions.GenerateRandomColour();

            cpbxMenuTextColour.BackColor = randomColour;
        }

        private void generateARandomColourToolStripMenuItem26_Click(object sender, EventArgs e)
        {
            Color randomColour = ColourExtensions.GenerateRandomColour();

            cpbxStatusTextColour.BackColor = randomColour;
        }

        private void generateARandomColourToolStripMenuItem27_Click(object sender, EventArgs e)
        {
            Color randomColour = ColourExtensions.GenerateRandomColour();

            cpbxRibbonTabTextColour.BackColor = randomColour;
        }
        #endregion

        #region Use as Base Colour
        private void useAsBaseColourToolStripMenuItem_Click(object sender, EventArgs e) => ColourExtensions.UseAsBaseColour(cpbxBaseColour);

        private void toolStripMenuItem28_Click(object sender, EventArgs e) => ColourExtensions.UseAsBaseColour(cpbxMediumColour);

        private void toolStripMenuItem1_Click(object sender, EventArgs e) => ColourExtensions.UseAsBaseColour(cpbxDarkColour);

        private void toolStripMenuItem2_Click(object sender, EventArgs e) => ColourExtensions.UseAsBaseColour(cpbxLightColour);

        private void toolStripMenuItem3_Click(object sender, EventArgs e) => ColourExtensions.UseAsBaseColour(cpbxLightestColour);

        private void toolStripMenuItem4_Click(object sender, EventArgs e) => ColourExtensions.UseAsBaseColour(cpbxBorderColourOne);

        private void toolStripMenuItem29_Click(object sender, EventArgs e) => ColourExtensions.UseAsBaseColour(cpbxBorderColourTwo);

        private void toolStripMenuItem5_Click(object sender, EventArgs e) => ColourExtensions.UseAsBaseColour(cpbxAlternativeNormalTextColour);

        private void toolStripMenuItem6_Click(object sender, EventArgs e) => ColourExtensions.UseAsBaseColour(cpbxNormalTextColour);

        private void toolStripMenuItem7_Click(object sender, EventArgs e) => ColourExtensions.UseAsBaseColour(cpbxDisabledTextColour);

        private void toolStripMenuItem8_Click(object sender, EventArgs e) => ColourExtensions.UseAsBaseColour(cpbxFocusedTextColour);

        private void toolStripMenuItem9_Click(object sender, EventArgs e) => ColourExtensions.UseAsBaseColour(cpbxPressedTextColour);

        private void toolStripMenuItem10_Click(object sender, EventArgs e) => ColourExtensions.UseAsBaseColour(cpbxDisabledControlColour);

        private void toolStripMenuItem11_Click(object sender, EventArgs e) => ColourExtensions.UseAsBaseColour(cpbxLinkNormalColour);

        private void toolStripMenuItem12_Click(object sender, EventArgs e) => ColourExtensions.UseAsBaseColour(cpbxLinkFocusedColour);

        private void toolStripMenuItem13_Click(object sender, EventArgs e) => ColourExtensions.UseAsBaseColour(cpbxLinkHoverColour);

        private void toolStripMenuItem14_Click(object sender, EventArgs e) => ColourExtensions.UseAsBaseColour(cpbxLinkVisitedColour);

        private void toolStripMenuItem15_Click(object sender, EventArgs e) => ColourExtensions.UseAsBaseColour(cpbxCustomColourOne);

        private void toolStripMenuItem16_Click(object sender, EventArgs e) => ColourExtensions.UseAsBaseColour(cpbxCustomColourTwo);

        private void toolStripMenuItem17_Click(object sender, EventArgs e) => ColourExtensions.UseAsBaseColour(cpbxCustomColourThree);

        private void toolStripMenuItem18_Click(object sender, EventArgs e) => ColourExtensions.UseAsBaseColour(cpbxCustomColourFour);

        private void toolStripMenuItem19_Click(object sender, EventArgs e) => ColourExtensions.UseAsBaseColour(cpbxCustomColourFive);

        private void toolStripMenuItem20_Click(object sender, EventArgs e) => ColourExtensions.UseAsBaseColour(cpbxCustomTextColourOne);

        private void toolStripMenuItem21_Click(object sender, EventArgs e) => ColourExtensions.UseAsBaseColour(cpbxCustomTextColourTwo);

        private void toolStripMenuItem22_Click(object sender, EventArgs e) => ColourExtensions.UseAsBaseColour(cpbxCustomTextColourThree);

        private void toolStripMenuItem23_Click(object sender, EventArgs e) => ColourExtensions.UseAsBaseColour(cpbxCustomTextColourFour);

        private void toolStripMenuItem24_Click(object sender, EventArgs e) => ColourExtensions.UseAsBaseColour(cpbxCustomTextColourFive);

        private void toolStripMenuItem25_Click(object sender, EventArgs e) => ColourExtensions.UseAsBaseColour(cpbxMenuTextColour);

        private void toolStripMenuItem26_Click(object sender, EventArgs e) => ColourExtensions.UseAsBaseColour(cpbxStatusTextColour);

        private void toolStripMenuItem27_Click(object sender, EventArgs e) => ColourExtensions.UseAsBaseColour(cpbxRibbonTabTextColour);
        #endregion

        #endregion

        #region Overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            SetupColourToolTips(ShowColourInformation);

            base.OnPaint(e);
        }
        #endregion

        #region Array Management
        /// <summary>Propagates the colour preview array.</summary>
        private void PropagateColourPreviewArray()
        {
            _previews = new Suite.Extended.Base.CircularPictureBox[30];

            ColourPreviews[0] = cpbxBaseColour;

            ColourPreviews[1] = cpbxDarkColour;

            ColourPreviews[2] = cpbxMediumColour;

            ColourPreviews[3] = cpbxLightColour;

            ColourPreviews[4] = cpbxLightestColour;

            ColourPreviews[5] = cpbxBorderColourOne;

            ColourPreviews[6] = cpbxBorderColourTwo;

            ColourPreviews[7] = cpbxAlternativeNormalTextColour;

            ColourPreviews[8] = cpbxNormalTextColour;

            ColourPreviews[9] = cpbxDisabledTextColour;

            ColourPreviews[10] = cpbxFocusedTextColour;

            ColourPreviews[11] = cpbxPressedTextColour;

            ColourPreviews[12] = cpbxDisabledControlColour;

            ColourPreviews[13] = cpbxLinkNormalColour;

            ColourPreviews[14] = cpbxLinkFocusedColour;

            ColourPreviews[15] = cpbxLinkHoverColour;

            ColourPreviews[16] = cpbxLinkVisitedColour;

            ColourPreviews[17] = cpbxCustomColourOne;

            ColourPreviews[18] = cpbxCustomColourTwo;

            ColourPreviews[19] = cpbxCustomColourThree;

            ColourPreviews[20] = cpbxCustomColourFour;

            ColourPreviews[21] = cpbxCustomColourFive;

            ColourPreviews[22] = cpbxCustomTextColourOne;

            ColourPreviews[23] = cpbxCustomTextColourTwo;

            ColourPreviews[24] = cpbxCustomTextColourThree;

            ColourPreviews[25] = cpbxCustomTextColourFour;

            ColourPreviews[26] = cpbxCustomTextColourFive;

            ColourPreviews[27] = cpbxMenuTextColour;

            ColourPreviews[28] = cpbxStatusTextColour;

            ColourPreviews[29] = cpbxRibbonTabTextColour;
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

                    ColourPreviews[29].BackColor = paletteColours[29];
                }
            }
            catch (Exception e)
            {
                Suite.Extended.Common.ExceptionHandler.CaptureException(e);
            }
        }
        #endregion
    }
}