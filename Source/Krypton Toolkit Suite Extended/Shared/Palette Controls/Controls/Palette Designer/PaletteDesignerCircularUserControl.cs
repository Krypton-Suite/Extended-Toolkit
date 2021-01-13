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
        private Suite.Extended.Base.CircularPictureBox cpbxDisabledColour;
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
        private Suite.Extended.Base.CircularPictureBox circularPictureBox29;
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
        private Suite.Extended.Base.CircularPictureBox cpbxRibbonTabColour;
        private ToolTip ttColourInformation;
        private System.ComponentModel.IContainer components;
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
            this.cpbxDisabledColour = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
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
            this.circularPictureBox29 = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
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
            this.cpbxRibbonTabColour = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.ttColourInformation = new System.Windows.Forms.ToolTip(this.components);
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
            ((System.ComponentModel.ISupportInitialize)(this.cpbxDisabledColour)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox29)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.cpbxRibbonTabColour)).BeginInit();
            this.SuspendLayout();
            // 
            // cpbxBaseColour
            // 
            this.cpbxBaseColour.BackColor = System.Drawing.Color.Black;
            this.cpbxBaseColour.Location = new System.Drawing.Point(13, 13);
            this.cpbxBaseColour.Name = "cpbxBaseColour";
            this.cpbxBaseColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxBaseColour.TabIndex = 0;
            this.cpbxBaseColour.TabStop = false;
            this.cpbxBaseColour.ToolTipValues = null;
            // 
            // cpbxDarkColour
            // 
            this.cpbxDarkColour.BackColor = System.Drawing.Color.Black;
            this.cpbxDarkColour.Location = new System.Drawing.Point(95, 13);
            this.cpbxDarkColour.Name = "cpbxDarkColour";
            this.cpbxDarkColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxDarkColour.TabIndex = 1;
            this.cpbxDarkColour.TabStop = false;
            this.cpbxDarkColour.ToolTipValues = null;
            // 
            // cpbxMediumColour
            // 
            this.cpbxMediumColour.BackColor = System.Drawing.Color.Black;
            this.cpbxMediumColour.Location = new System.Drawing.Point(177, 13);
            this.cpbxMediumColour.Name = "cpbxMediumColour";
            this.cpbxMediumColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxMediumColour.TabIndex = 2;
            this.cpbxMediumColour.TabStop = false;
            this.cpbxMediumColour.ToolTipValues = null;
            // 
            // cpbxLightColour
            // 
            this.cpbxLightColour.BackColor = System.Drawing.Color.Black;
            this.cpbxLightColour.Location = new System.Drawing.Point(259, 13);
            this.cpbxLightColour.Name = "cpbxLightColour";
            this.cpbxLightColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxLightColour.TabIndex = 3;
            this.cpbxLightColour.TabStop = false;
            this.cpbxLightColour.ToolTipValues = null;
            // 
            // cpbxLightestColour
            // 
            this.cpbxLightestColour.BackColor = System.Drawing.Color.Black;
            this.cpbxLightestColour.Location = new System.Drawing.Point(341, 13);
            this.cpbxLightestColour.Name = "cpbxLightestColour";
            this.cpbxLightestColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxLightestColour.TabIndex = 4;
            this.cpbxLightestColour.TabStop = false;
            this.cpbxLightestColour.ToolTipValues = null;
            // 
            // cpbxBorderColour
            // 
            this.cpbxBorderColour.BackColor = System.Drawing.Color.Black;
            this.cpbxBorderColour.Location = new System.Drawing.Point(423, 13);
            this.cpbxBorderColour.Name = "cpbxBorderColour";
            this.cpbxBorderColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxBorderColour.TabIndex = 5;
            this.cpbxBorderColour.TabStop = false;
            this.cpbxBorderColour.ToolTipValues = null;
            // 
            // cpbxAlternativeNormalTextColour
            // 
            this.cpbxAlternativeNormalTextColour.BackColor = System.Drawing.Color.Black;
            this.cpbxAlternativeNormalTextColour.Location = new System.Drawing.Point(505, 13);
            this.cpbxAlternativeNormalTextColour.Name = "cpbxAlternativeNormalTextColour";
            this.cpbxAlternativeNormalTextColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxAlternativeNormalTextColour.TabIndex = 6;
            this.cpbxAlternativeNormalTextColour.TabStop = false;
            this.cpbxAlternativeNormalTextColour.ToolTipValues = null;
            // 
            // cpbxNormalTextColour
            // 
            this.cpbxNormalTextColour.BackColor = System.Drawing.Color.Black;
            this.cpbxNormalTextColour.Location = new System.Drawing.Point(587, 13);
            this.cpbxNormalTextColour.Name = "cpbxNormalTextColour";
            this.cpbxNormalTextColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxNormalTextColour.TabIndex = 7;
            this.cpbxNormalTextColour.TabStop = false;
            this.cpbxNormalTextColour.ToolTipValues = null;
            // 
            // cpbxDisabledTextColour
            // 
            this.cpbxDisabledTextColour.BackColor = System.Drawing.Color.Black;
            this.cpbxDisabledTextColour.Location = new System.Drawing.Point(669, 13);
            this.cpbxDisabledTextColour.Name = "cpbxDisabledTextColour";
            this.cpbxDisabledTextColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxDisabledTextColour.TabIndex = 8;
            this.cpbxDisabledTextColour.TabStop = false;
            this.cpbxDisabledTextColour.ToolTipValues = null;
            // 
            // cpbxFocusedTextColour
            // 
            this.cpbxFocusedTextColour.BackColor = System.Drawing.Color.Black;
            this.cpbxFocusedTextColour.Location = new System.Drawing.Point(751, 13);
            this.cpbxFocusedTextColour.Name = "cpbxFocusedTextColour";
            this.cpbxFocusedTextColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxFocusedTextColour.TabIndex = 9;
            this.cpbxFocusedTextColour.TabStop = false;
            this.cpbxFocusedTextColour.ToolTipValues = null;
            // 
            // cpbxPressedTextColour
            // 
            this.cpbxPressedTextColour.BackColor = System.Drawing.Color.Black;
            this.cpbxPressedTextColour.Location = new System.Drawing.Point(833, 13);
            this.cpbxPressedTextColour.Name = "cpbxPressedTextColour";
            this.cpbxPressedTextColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxPressedTextColour.TabIndex = 10;
            this.cpbxPressedTextColour.TabStop = false;
            this.cpbxPressedTextColour.ToolTipValues = null;
            // 
            // cpbxDisabledColour
            // 
            this.cpbxDisabledColour.BackColor = System.Drawing.Color.Black;
            this.cpbxDisabledColour.Location = new System.Drawing.Point(915, 13);
            this.cpbxDisabledColour.Name = "cpbxDisabledColour";
            this.cpbxDisabledColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxDisabledColour.TabIndex = 11;
            this.cpbxDisabledColour.TabStop = false;
            this.cpbxDisabledColour.ToolTipValues = null;
            // 
            // cpbxLinkNormalColour
            // 
            this.cpbxLinkNormalColour.BackColor = System.Drawing.Color.Black;
            this.cpbxLinkNormalColour.Location = new System.Drawing.Point(997, 13);
            this.cpbxLinkNormalColour.Name = "cpbxLinkNormalColour";
            this.cpbxLinkNormalColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxLinkNormalColour.TabIndex = 12;
            this.cpbxLinkNormalColour.TabStop = false;
            this.cpbxLinkNormalColour.ToolTipValues = null;
            // 
            // cpbxLinkFocusedColour
            // 
            this.cpbxLinkFocusedColour.BackColor = System.Drawing.Color.Black;
            this.cpbxLinkFocusedColour.Location = new System.Drawing.Point(1079, 13);
            this.cpbxLinkFocusedColour.Name = "cpbxLinkFocusedColour";
            this.cpbxLinkFocusedColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxLinkFocusedColour.TabIndex = 13;
            this.cpbxLinkFocusedColour.TabStop = false;
            this.cpbxLinkFocusedColour.ToolTipValues = null;
            // 
            // cpbxStatusTextColour
            // 
            this.cpbxStatusTextColour.BackColor = System.Drawing.Color.Black;
            this.cpbxStatusTextColour.Location = new System.Drawing.Point(1079, 165);
            this.cpbxStatusTextColour.Name = "cpbxStatusTextColour";
            this.cpbxStatusTextColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxStatusTextColour.TabIndex = 27;
            this.cpbxStatusTextColour.TabStop = false;
            this.cpbxStatusTextColour.ToolTipValues = null;
            // 
            // cpbxMenuTextColour
            // 
            this.cpbxMenuTextColour.BackColor = System.Drawing.Color.Black;
            this.cpbxMenuTextColour.Location = new System.Drawing.Point(997, 165);
            this.cpbxMenuTextColour.Name = "cpbxMenuTextColour";
            this.cpbxMenuTextColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxMenuTextColour.TabIndex = 26;
            this.cpbxMenuTextColour.TabStop = false;
            this.cpbxMenuTextColour.ToolTipValues = null;
            // 
            // cpbxCustomTextColourFive
            // 
            this.cpbxCustomTextColourFive.BackColor = System.Drawing.Color.Black;
            this.cpbxCustomTextColourFive.Location = new System.Drawing.Point(915, 165);
            this.cpbxCustomTextColourFive.Name = "cpbxCustomTextColourFive";
            this.cpbxCustomTextColourFive.Size = new System.Drawing.Size(64, 64);
            this.cpbxCustomTextColourFive.TabIndex = 25;
            this.cpbxCustomTextColourFive.TabStop = false;
            this.cpbxCustomTextColourFive.ToolTipValues = null;
            // 
            // cpbxCustomTextColourFour
            // 
            this.cpbxCustomTextColourFour.BackColor = System.Drawing.Color.Black;
            this.cpbxCustomTextColourFour.Location = new System.Drawing.Point(833, 165);
            this.cpbxCustomTextColourFour.Name = "cpbxCustomTextColourFour";
            this.cpbxCustomTextColourFour.Size = new System.Drawing.Size(64, 64);
            this.cpbxCustomTextColourFour.TabIndex = 24;
            this.cpbxCustomTextColourFour.TabStop = false;
            this.cpbxCustomTextColourFour.ToolTipValues = null;
            // 
            // cpbxCustomTextColourThree
            // 
            this.cpbxCustomTextColourThree.BackColor = System.Drawing.Color.Black;
            this.cpbxCustomTextColourThree.Location = new System.Drawing.Point(751, 165);
            this.cpbxCustomTextColourThree.Name = "cpbxCustomTextColourThree";
            this.cpbxCustomTextColourThree.Size = new System.Drawing.Size(64, 64);
            this.cpbxCustomTextColourThree.TabIndex = 23;
            this.cpbxCustomTextColourThree.TabStop = false;
            this.cpbxCustomTextColourThree.ToolTipValues = null;
            // 
            // cpbxCustomTextColourTwo
            // 
            this.cpbxCustomTextColourTwo.BackColor = System.Drawing.Color.Black;
            this.cpbxCustomTextColourTwo.Location = new System.Drawing.Point(669, 165);
            this.cpbxCustomTextColourTwo.Name = "cpbxCustomTextColourTwo";
            this.cpbxCustomTextColourTwo.Size = new System.Drawing.Size(64, 64);
            this.cpbxCustomTextColourTwo.TabIndex = 22;
            this.cpbxCustomTextColourTwo.TabStop = false;
            this.cpbxCustomTextColourTwo.ToolTipValues = null;
            // 
            // cpbxCustomTextColourOne
            // 
            this.cpbxCustomTextColourOne.BackColor = System.Drawing.Color.Black;
            this.cpbxCustomTextColourOne.Location = new System.Drawing.Point(587, 165);
            this.cpbxCustomTextColourOne.Name = "cpbxCustomTextColourOne";
            this.cpbxCustomTextColourOne.Size = new System.Drawing.Size(64, 64);
            this.cpbxCustomTextColourOne.TabIndex = 21;
            this.cpbxCustomTextColourOne.TabStop = false;
            this.cpbxCustomTextColourOne.ToolTipValues = null;
            // 
            // cpbxCustomColourFive
            // 
            this.cpbxCustomColourFive.BackColor = System.Drawing.Color.Black;
            this.cpbxCustomColourFive.Location = new System.Drawing.Point(505, 165);
            this.cpbxCustomColourFive.Name = "cpbxCustomColourFive";
            this.cpbxCustomColourFive.Size = new System.Drawing.Size(64, 64);
            this.cpbxCustomColourFive.TabIndex = 20;
            this.cpbxCustomColourFive.TabStop = false;
            this.cpbxCustomColourFive.ToolTipValues = null;
            // 
            // cpbxCustomColourFour
            // 
            this.cpbxCustomColourFour.BackColor = System.Drawing.Color.Black;
            this.cpbxCustomColourFour.Location = new System.Drawing.Point(423, 165);
            this.cpbxCustomColourFour.Name = "cpbxCustomColourFour";
            this.cpbxCustomColourFour.Size = new System.Drawing.Size(64, 64);
            this.cpbxCustomColourFour.TabIndex = 19;
            this.cpbxCustomColourFour.TabStop = false;
            this.cpbxCustomColourFour.ToolTipValues = null;
            // 
            // cpbxCustomColourThree
            // 
            this.cpbxCustomColourThree.BackColor = System.Drawing.Color.Black;
            this.cpbxCustomColourThree.Location = new System.Drawing.Point(341, 165);
            this.cpbxCustomColourThree.Name = "cpbxCustomColourThree";
            this.cpbxCustomColourThree.Size = new System.Drawing.Size(64, 64);
            this.cpbxCustomColourThree.TabIndex = 18;
            this.cpbxCustomColourThree.TabStop = false;
            this.cpbxCustomColourThree.ToolTipValues = null;
            // 
            // cpbxCustomColourTwo
            // 
            this.cpbxCustomColourTwo.BackColor = System.Drawing.Color.Black;
            this.cpbxCustomColourTwo.Location = new System.Drawing.Point(259, 165);
            this.cpbxCustomColourTwo.Name = "cpbxCustomColourTwo";
            this.cpbxCustomColourTwo.Size = new System.Drawing.Size(64, 64);
            this.cpbxCustomColourTwo.TabIndex = 17;
            this.cpbxCustomColourTwo.TabStop = false;
            this.cpbxCustomColourTwo.ToolTipValues = null;
            // 
            // cpbxCustomColourOne
            // 
            this.cpbxCustomColourOne.BackColor = System.Drawing.Color.Black;
            this.cpbxCustomColourOne.Location = new System.Drawing.Point(177, 165);
            this.cpbxCustomColourOne.Name = "cpbxCustomColourOne";
            this.cpbxCustomColourOne.Size = new System.Drawing.Size(64, 64);
            this.cpbxCustomColourOne.TabIndex = 16;
            this.cpbxCustomColourOne.TabStop = false;
            this.cpbxCustomColourOne.ToolTipValues = null;
            // 
            // cpbxLinkVisitedColour
            // 
            this.cpbxLinkVisitedColour.BackColor = System.Drawing.Color.Black;
            this.cpbxLinkVisitedColour.Location = new System.Drawing.Point(95, 165);
            this.cpbxLinkVisitedColour.Name = "cpbxLinkVisitedColour";
            this.cpbxLinkVisitedColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxLinkVisitedColour.TabIndex = 15;
            this.cpbxLinkVisitedColour.TabStop = false;
            this.cpbxLinkVisitedColour.ToolTipValues = null;
            // 
            // cpbxLinkHoverColour
            // 
            this.cpbxLinkHoverColour.BackColor = System.Drawing.Color.Black;
            this.cpbxLinkHoverColour.Location = new System.Drawing.Point(13, 165);
            this.cpbxLinkHoverColour.Name = "cpbxLinkHoverColour";
            this.cpbxLinkHoverColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxLinkHoverColour.TabIndex = 14;
            this.cpbxLinkHoverColour.TabStop = false;
            this.cpbxLinkHoverColour.ToolTipValues = null;
            // 
            // circularPictureBox29
            // 
            this.circularPictureBox29.BackColor = System.Drawing.Color.Black;
            this.circularPictureBox29.Location = new System.Drawing.Point(1079, 318);
            this.circularPictureBox29.Name = "circularPictureBox29";
            this.circularPictureBox29.Size = new System.Drawing.Size(64, 64);
            this.circularPictureBox29.TabIndex = 41;
            this.circularPictureBox29.TabStop = false;
            this.circularPictureBox29.ToolTipValues = null;
            this.circularPictureBox29.Visible = false;
            // 
            // circularPictureBox30
            // 
            this.circularPictureBox30.BackColor = System.Drawing.Color.Black;
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
            this.circularPictureBox31.BackColor = System.Drawing.Color.Black;
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
            this.circularPictureBox32.BackColor = System.Drawing.Color.Black;
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
            this.circularPictureBox33.BackColor = System.Drawing.Color.Black;
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
            this.circularPictureBox34.BackColor = System.Drawing.Color.Black;
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
            this.circularPictureBox35.BackColor = System.Drawing.Color.Black;
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
            this.circularPictureBox36.BackColor = System.Drawing.Color.Black;
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
            this.circularPictureBox37.BackColor = System.Drawing.Color.Black;
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
            this.circularPictureBox38.BackColor = System.Drawing.Color.Black;
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
            this.circularPictureBox39.BackColor = System.Drawing.Color.Black;
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
            this.circularPictureBox40.BackColor = System.Drawing.Color.Black;
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
            this.circularPictureBox41.BackColor = System.Drawing.Color.Black;
            this.circularPictureBox41.Location = new System.Drawing.Point(95, 318);
            this.circularPictureBox41.Name = "circularPictureBox41";
            this.circularPictureBox41.Size = new System.Drawing.Size(64, 64);
            this.circularPictureBox41.TabIndex = 29;
            this.circularPictureBox41.TabStop = false;
            this.circularPictureBox41.ToolTipValues = null;
            this.circularPictureBox41.Visible = false;
            // 
            // cpbxRibbonTabColour
            // 
            this.cpbxRibbonTabColour.BackColor = System.Drawing.Color.Black;
            this.cpbxRibbonTabColour.Location = new System.Drawing.Point(13, 317);
            this.cpbxRibbonTabColour.Name = "cpbxRibbonTabColour";
            this.cpbxRibbonTabColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxRibbonTabColour.TabIndex = 28;
            this.cpbxRibbonTabColour.TabStop = false;
            this.cpbxRibbonTabColour.ToolTipValues = null;
            // 
            // PaletteDesignerCircularUserControl
            // 
            this.Controls.Add(this.circularPictureBox29);
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
            this.Controls.Add(this.cpbxRibbonTabColour);
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
            this.Controls.Add(this.cpbxDisabledColour);
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
            ((System.ComponentModel.ISupportInitialize)(this.cpbxDisabledColour)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox29)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.cpbxRibbonTabColour)).EndInit();
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

                ColourInformation.SetTooltip(cpbxDisabledColour, "Disabled Control");

                ColourInformation.SetTooltip(cpbxLinkNormalColour, "Link Normal Text");

                ColourInformation.SetTooltip(cpbxLinkFocusedColour, "Link Focused Text");

                ColourInformation.SetTooltip(cpbxLinkHoverColour, "Link Hover Text");

                ColourInformation.SetTooltip(cpbxLinkVisitedColour, "Link Visited Text");
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
            _previews = new Suite.Extended.Base.CircularPictureBox[29];

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

            ColourPreviews[11] = cpbxDisabledColour;

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

            ColourPreviews[28] = cpbxRibbonTabColour;
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