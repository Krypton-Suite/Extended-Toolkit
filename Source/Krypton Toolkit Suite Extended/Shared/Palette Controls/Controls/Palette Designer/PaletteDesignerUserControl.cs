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
        private PictureBox pbxBorderColour;
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
        private ToolTip ttColourInformation;
        private IContainer components;
        private KryptonPalette internalPalette;
        private PictureBox pbxBaseColour;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbxBaseColour = new System.Windows.Forms.PictureBox();
            this.pbxDarkColour = new System.Windows.Forms.PictureBox();
            this.pbxMediumColour = new System.Windows.Forms.PictureBox();
            this.pbxLightColour = new System.Windows.Forms.PictureBox();
            this.pbxLightestColour = new System.Windows.Forms.PictureBox();
            this.pbxBorderColour = new System.Windows.Forms.PictureBox();
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
            this.internalPalette = new Krypton.Toolkit.KryptonPalette(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbxBaseColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDarkColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMediumColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLightColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLightestColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBorderColour)).BeginInit();
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
            // pbxBorderColour
            // 
            this.pbxBorderColour.BackColor = System.Drawing.Color.White;
            this.pbxBorderColour.Location = new System.Drawing.Point(418, 3);
            this.pbxBorderColour.Name = "pbxBorderColour";
            this.pbxBorderColour.Size = new System.Drawing.Size(64, 64);
            this.pbxBorderColour.TabIndex = 5;
            this.pbxBorderColour.TabStop = false;
            // 
            // pbxAlternativeNormalTextColour
            // 
            this.pbxAlternativeNormalTextColour.BackColor = System.Drawing.Color.White;
            this.pbxAlternativeNormalTextColour.Location = new System.Drawing.Point(501, 3);
            this.pbxAlternativeNormalTextColour.Name = "pbxAlternativeNormalTextColour";
            this.pbxAlternativeNormalTextColour.Size = new System.Drawing.Size(64, 64);
            this.pbxAlternativeNormalTextColour.TabIndex = 6;
            this.pbxAlternativeNormalTextColour.TabStop = false;
            // 
            // pbxNormalTextColour
            // 
            this.pbxNormalTextColour.BackColor = System.Drawing.Color.White;
            this.pbxNormalTextColour.Location = new System.Drawing.Point(584, 3);
            this.pbxNormalTextColour.Name = "pbxNormalTextColour";
            this.pbxNormalTextColour.Size = new System.Drawing.Size(64, 64);
            this.pbxNormalTextColour.TabIndex = 7;
            this.pbxNormalTextColour.TabStop = false;
            // 
            // pbxDisabledTextColour
            // 
            this.pbxDisabledTextColour.BackColor = System.Drawing.Color.White;
            this.pbxDisabledTextColour.Location = new System.Drawing.Point(667, 3);
            this.pbxDisabledTextColour.Name = "pbxDisabledTextColour";
            this.pbxDisabledTextColour.Size = new System.Drawing.Size(64, 64);
            this.pbxDisabledTextColour.TabIndex = 8;
            this.pbxDisabledTextColour.TabStop = false;
            // 
            // pbxFocusedTextColour
            // 
            this.pbxFocusedTextColour.BackColor = System.Drawing.Color.White;
            this.pbxFocusedTextColour.Location = new System.Drawing.Point(750, 3);
            this.pbxFocusedTextColour.Name = "pbxFocusedTextColour";
            this.pbxFocusedTextColour.Size = new System.Drawing.Size(64, 64);
            this.pbxFocusedTextColour.TabIndex = 9;
            this.pbxFocusedTextColour.TabStop = false;
            // 
            // pbxPressedTextColour
            // 
            this.pbxPressedTextColour.BackColor = System.Drawing.Color.White;
            this.pbxPressedTextColour.Location = new System.Drawing.Point(833, 3);
            this.pbxPressedTextColour.Name = "pbxPressedTextColour";
            this.pbxPressedTextColour.Size = new System.Drawing.Size(64, 64);
            this.pbxPressedTextColour.TabIndex = 10;
            this.pbxPressedTextColour.TabStop = false;
            // 
            // pbxDisabledControlColour
            // 
            this.pbxDisabledControlColour.BackColor = System.Drawing.Color.White;
            this.pbxDisabledControlColour.Location = new System.Drawing.Point(916, 3);
            this.pbxDisabledControlColour.Name = "pbxDisabledControlColour";
            this.pbxDisabledControlColour.Size = new System.Drawing.Size(64, 64);
            this.pbxDisabledControlColour.TabIndex = 11;
            this.pbxDisabledControlColour.TabStop = false;
            // 
            // pbxLinkNormalColour
            // 
            this.pbxLinkNormalColour.BackColor = System.Drawing.Color.White;
            this.pbxLinkNormalColour.Location = new System.Drawing.Point(1082, 3);
            this.pbxLinkNormalColour.Name = "pbxLinkNormalColour";
            this.pbxLinkNormalColour.Size = new System.Drawing.Size(64, 64);
            this.pbxLinkNormalColour.TabIndex = 12;
            this.pbxLinkNormalColour.TabStop = false;
            // 
            // pbxLinkFocusedColour
            // 
            this.pbxLinkFocusedColour.BackColor = System.Drawing.Color.White;
            this.pbxLinkFocusedColour.Location = new System.Drawing.Point(999, 3);
            this.pbxLinkFocusedColour.Name = "pbxLinkFocusedColour";
            this.pbxLinkFocusedColour.Size = new System.Drawing.Size(64, 64);
            this.pbxLinkFocusedColour.TabIndex = 13;
            this.pbxLinkFocusedColour.TabStop = false;
            // 
            // pbxLinkHoverColour
            // 
            this.pbxLinkHoverColour.BackColor = System.Drawing.Color.White;
            this.pbxLinkHoverColour.Location = new System.Drawing.Point(3, 179);
            this.pbxLinkHoverColour.Name = "pbxLinkHoverColour";
            this.pbxLinkHoverColour.Size = new System.Drawing.Size(64, 64);
            this.pbxLinkHoverColour.TabIndex = 14;
            this.pbxLinkHoverColour.TabStop = false;
            // 
            // pbxLinkVisitedColour
            // 
            this.pbxLinkVisitedColour.BackColor = System.Drawing.Color.White;
            this.pbxLinkVisitedColour.Location = new System.Drawing.Point(86, 179);
            this.pbxLinkVisitedColour.Name = "pbxLinkVisitedColour";
            this.pbxLinkVisitedColour.Size = new System.Drawing.Size(64, 64);
            this.pbxLinkVisitedColour.TabIndex = 15;
            this.pbxLinkVisitedColour.TabStop = false;
            // 
            // pbxCustomColourOne
            // 
            this.pbxCustomColourOne.BackColor = System.Drawing.Color.White;
            this.pbxCustomColourOne.Location = new System.Drawing.Point(169, 179);
            this.pbxCustomColourOne.Name = "pbxCustomColourOne";
            this.pbxCustomColourOne.Size = new System.Drawing.Size(64, 64);
            this.pbxCustomColourOne.TabIndex = 28;
            this.pbxCustomColourOne.TabStop = false;
            this.pbxCustomColourOne.Visible = false;
            // 
            // pbxCustomColourTwo
            // 
            this.pbxCustomColourTwo.BackColor = System.Drawing.Color.White;
            this.pbxCustomColourTwo.Location = new System.Drawing.Point(252, 179);
            this.pbxCustomColourTwo.Name = "pbxCustomColourTwo";
            this.pbxCustomColourTwo.Size = new System.Drawing.Size(64, 64);
            this.pbxCustomColourTwo.TabIndex = 27;
            this.pbxCustomColourTwo.TabStop = false;
            this.pbxCustomColourTwo.Visible = false;
            // 
            // pbxCustomColourThree
            // 
            this.pbxCustomColourThree.BackColor = System.Drawing.Color.White;
            this.pbxCustomColourThree.Location = new System.Drawing.Point(335, 179);
            this.pbxCustomColourThree.Name = "pbxCustomColourThree";
            this.pbxCustomColourThree.Size = new System.Drawing.Size(64, 64);
            this.pbxCustomColourThree.TabIndex = 26;
            this.pbxCustomColourThree.TabStop = false;
            this.pbxCustomColourThree.Visible = false;
            // 
            // pbxCustomColourFour
            // 
            this.pbxCustomColourFour.BackColor = System.Drawing.Color.White;
            this.pbxCustomColourFour.Location = new System.Drawing.Point(418, 179);
            this.pbxCustomColourFour.Name = "pbxCustomColourFour";
            this.pbxCustomColourFour.Size = new System.Drawing.Size(64, 64);
            this.pbxCustomColourFour.TabIndex = 25;
            this.pbxCustomColourFour.TabStop = false;
            this.pbxCustomColourFour.Visible = false;
            // 
            // pbxCustomColourFive
            // 
            this.pbxCustomColourFive.BackColor = System.Drawing.Color.White;
            this.pbxCustomColourFive.Location = new System.Drawing.Point(501, 179);
            this.pbxCustomColourFive.Name = "pbxCustomColourFive";
            this.pbxCustomColourFive.Size = new System.Drawing.Size(64, 64);
            this.pbxCustomColourFive.TabIndex = 24;
            this.pbxCustomColourFive.TabStop = false;
            this.pbxCustomColourFive.Visible = false;
            // 
            // pbxCustomTextColourOne
            // 
            this.pbxCustomTextColourOne.BackColor = System.Drawing.Color.White;
            this.pbxCustomTextColourOne.Location = new System.Drawing.Point(584, 179);
            this.pbxCustomTextColourOne.Name = "pbxCustomTextColourOne";
            this.pbxCustomTextColourOne.Size = new System.Drawing.Size(64, 64);
            this.pbxCustomTextColourOne.TabIndex = 23;
            this.pbxCustomTextColourOne.TabStop = false;
            this.pbxCustomTextColourOne.Visible = false;
            // 
            // pbxCustomTextColourTwo
            // 
            this.pbxCustomTextColourTwo.BackColor = System.Drawing.Color.White;
            this.pbxCustomTextColourTwo.Location = new System.Drawing.Point(667, 179);
            this.pbxCustomTextColourTwo.Name = "pbxCustomTextColourTwo";
            this.pbxCustomTextColourTwo.Size = new System.Drawing.Size(64, 64);
            this.pbxCustomTextColourTwo.TabIndex = 22;
            this.pbxCustomTextColourTwo.TabStop = false;
            this.pbxCustomTextColourTwo.Visible = false;
            // 
            // pbxCustomTextColourThree
            // 
            this.pbxCustomTextColourThree.BackColor = System.Drawing.Color.White;
            this.pbxCustomTextColourThree.Location = new System.Drawing.Point(750, 179);
            this.pbxCustomTextColourThree.Name = "pbxCustomTextColourThree";
            this.pbxCustomTextColourThree.Size = new System.Drawing.Size(64, 64);
            this.pbxCustomTextColourThree.TabIndex = 21;
            this.pbxCustomTextColourThree.TabStop = false;
            this.pbxCustomTextColourThree.Visible = false;
            // 
            // pbxCustomTextColourFour
            // 
            this.pbxCustomTextColourFour.BackColor = System.Drawing.Color.White;
            this.pbxCustomTextColourFour.Location = new System.Drawing.Point(833, 179);
            this.pbxCustomTextColourFour.Name = "pbxCustomTextColourFour";
            this.pbxCustomTextColourFour.Size = new System.Drawing.Size(64, 64);
            this.pbxCustomTextColourFour.TabIndex = 20;
            this.pbxCustomTextColourFour.TabStop = false;
            this.pbxCustomTextColourFour.Visible = false;
            // 
            // pbxCustomTextColourFive
            // 
            this.pbxCustomTextColourFive.BackColor = System.Drawing.Color.White;
            this.pbxCustomTextColourFive.Location = new System.Drawing.Point(916, 179);
            this.pbxCustomTextColourFive.Name = "pbxCustomTextColourFive";
            this.pbxCustomTextColourFive.Size = new System.Drawing.Size(64, 64);
            this.pbxCustomTextColourFive.TabIndex = 19;
            this.pbxCustomTextColourFive.TabStop = false;
            this.pbxCustomTextColourFive.Visible = false;
            // 
            // pbxMenuTextColour
            // 
            this.pbxMenuTextColour.BackColor = System.Drawing.Color.White;
            this.pbxMenuTextColour.Location = new System.Drawing.Point(999, 179);
            this.pbxMenuTextColour.Name = "pbxMenuTextColour";
            this.pbxMenuTextColour.Size = new System.Drawing.Size(64, 64);
            this.pbxMenuTextColour.TabIndex = 18;
            this.pbxMenuTextColour.TabStop = false;
            this.pbxMenuTextColour.Visible = false;
            // 
            // pbxStatusTextColour
            // 
            this.pbxStatusTextColour.BackColor = System.Drawing.Color.White;
            this.pbxStatusTextColour.Location = new System.Drawing.Point(1082, 179);
            this.pbxStatusTextColour.Name = "pbxStatusTextColour";
            this.pbxStatusTextColour.Size = new System.Drawing.Size(64, 64);
            this.pbxStatusTextColour.TabIndex = 17;
            this.pbxStatusTextColour.TabStop = false;
            this.pbxStatusTextColour.Visible = false;
            // 
            // pbxRibbonTabColour
            // 
            this.pbxRibbonTabColour.BackColor = System.Drawing.Color.White;
            this.pbxRibbonTabColour.Location = new System.Drawing.Point(3, 356);
            this.pbxRibbonTabColour.Name = "pbxRibbonTabColour";
            this.pbxRibbonTabColour.Size = new System.Drawing.Size(64, 64);
            this.pbxRibbonTabColour.TabIndex = 16;
            this.pbxRibbonTabColour.TabStop = false;
            this.pbxRibbonTabColour.Visible = false;
            // 
            // internalPalette
            // 
            this.internalPalette.CustomisedKryptonPaletteFilePath = null;
            // 
            // PaletteDesignerUserControl
            // 
            this.BackColor = System.Drawing.Color.Transparent;
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
            this.Controls.Add(this.pbxBorderColour);
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
            ((System.ComponentModel.ISupportInitialize)(this.pbxBorderColour)).EndInit();
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
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private bool _showColourInformation;

        private Color[] _paletteColours = new Color[29];

        private Color _defaultColour;

        private PictureBox[] _previews;

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

        public PictureBox[] ColourPreviews { get => _previews; private set => _previews = value; }
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

                ColourInformation.SetTooltip(pbxBorderColour, "Border");

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
            _previews = new PictureBox[29];

            ColourPreviews[0] = pbxBaseColour;

            ColourPreviews[1] = pbxDarkColour;

            ColourPreviews[2] = pbxMediumColour;

            ColourPreviews[3] = pbxLightColour;

            ColourPreviews[4] = pbxLightestColour;

            ColourPreviews[5] = pbxBorderColour;

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