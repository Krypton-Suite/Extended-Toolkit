using System;
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
        private Suite.Extended.Base.CircularPictureBox circularPictureBox9;
        private Suite.Extended.Base.CircularPictureBox circularPictureBox10;
        private Suite.Extended.Base.CircularPictureBox circularPictureBox11;
        private Suite.Extended.Base.CircularPictureBox circularPictureBox12;
        private Suite.Extended.Base.CircularPictureBox circularPictureBox13;
        private Suite.Extended.Base.CircularPictureBox circularPictureBox14;
        private Suite.Extended.Base.CircularPictureBox circularPictureBox15;
        private Suite.Extended.Base.CircularPictureBox circularPictureBox16;
        private Suite.Extended.Base.CircularPictureBox circularPictureBox17;
        private Suite.Extended.Base.CircularPictureBox circularPictureBox18;
        private Suite.Extended.Base.CircularPictureBox circularPictureBox19;
        private Suite.Extended.Base.CircularPictureBox circularPictureBox20;
        private Suite.Extended.Base.CircularPictureBox circularPictureBox21;
        private Suite.Extended.Base.CircularPictureBox circularPictureBox22;
        private Suite.Extended.Base.CircularPictureBox circularPictureBox23;
        private Suite.Extended.Base.CircularPictureBox circularPictureBox24;
        private Suite.Extended.Base.CircularPictureBox circularPictureBox25;
        private Suite.Extended.Base.CircularPictureBox circularPictureBox26;
        private Suite.Extended.Base.CircularPictureBox circularPictureBox27;
        private Suite.Extended.Base.CircularPictureBox circularPictureBox28;
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
        private Suite.Extended.Base.CircularPictureBox circularPictureBox42;
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
            this.circularPictureBox9 = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.circularPictureBox10 = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.circularPictureBox11 = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.circularPictureBox12 = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.circularPictureBox13 = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.circularPictureBox14 = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.circularPictureBox15 = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.circularPictureBox16 = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.circularPictureBox17 = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.circularPictureBox18 = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.circularPictureBox19 = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.circularPictureBox20 = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.circularPictureBox21 = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.circularPictureBox22 = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.circularPictureBox23 = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.circularPictureBox24 = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.circularPictureBox25 = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.circularPictureBox26 = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.circularPictureBox27 = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.circularPictureBox28 = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
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
            this.circularPictureBox42 = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.ttColourInformation = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cpbxBaseColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxDarkColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxMediumColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxLightColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxLightestColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxBorderColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxAlternativeNormalTextColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxNormalTextColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox28)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox42)).BeginInit();
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
            // circularPictureBox9
            // 
            this.circularPictureBox9.BackColor = System.Drawing.Color.Black;
            this.circularPictureBox9.Location = new System.Drawing.Point(669, 13);
            this.circularPictureBox9.Name = "circularPictureBox9";
            this.circularPictureBox9.Size = new System.Drawing.Size(64, 64);
            this.circularPictureBox9.TabIndex = 8;
            this.circularPictureBox9.TabStop = false;
            this.circularPictureBox9.ToolTipValues = null;
            // 
            // circularPictureBox10
            // 
            this.circularPictureBox10.BackColor = System.Drawing.Color.Black;
            this.circularPictureBox10.Location = new System.Drawing.Point(751, 13);
            this.circularPictureBox10.Name = "circularPictureBox10";
            this.circularPictureBox10.Size = new System.Drawing.Size(64, 64);
            this.circularPictureBox10.TabIndex = 9;
            this.circularPictureBox10.TabStop = false;
            this.circularPictureBox10.ToolTipValues = null;
            // 
            // circularPictureBox11
            // 
            this.circularPictureBox11.BackColor = System.Drawing.Color.Black;
            this.circularPictureBox11.Location = new System.Drawing.Point(833, 13);
            this.circularPictureBox11.Name = "circularPictureBox11";
            this.circularPictureBox11.Size = new System.Drawing.Size(64, 64);
            this.circularPictureBox11.TabIndex = 10;
            this.circularPictureBox11.TabStop = false;
            this.circularPictureBox11.ToolTipValues = null;
            // 
            // circularPictureBox12
            // 
            this.circularPictureBox12.BackColor = System.Drawing.Color.Black;
            this.circularPictureBox12.Location = new System.Drawing.Point(915, 13);
            this.circularPictureBox12.Name = "circularPictureBox12";
            this.circularPictureBox12.Size = new System.Drawing.Size(64, 64);
            this.circularPictureBox12.TabIndex = 11;
            this.circularPictureBox12.TabStop = false;
            this.circularPictureBox12.ToolTipValues = null;
            // 
            // circularPictureBox13
            // 
            this.circularPictureBox13.BackColor = System.Drawing.Color.Black;
            this.circularPictureBox13.Location = new System.Drawing.Point(997, 13);
            this.circularPictureBox13.Name = "circularPictureBox13";
            this.circularPictureBox13.Size = new System.Drawing.Size(64, 64);
            this.circularPictureBox13.TabIndex = 12;
            this.circularPictureBox13.TabStop = false;
            this.circularPictureBox13.ToolTipValues = null;
            // 
            // circularPictureBox14
            // 
            this.circularPictureBox14.BackColor = System.Drawing.Color.Black;
            this.circularPictureBox14.Location = new System.Drawing.Point(1079, 13);
            this.circularPictureBox14.Name = "circularPictureBox14";
            this.circularPictureBox14.Size = new System.Drawing.Size(64, 64);
            this.circularPictureBox14.TabIndex = 13;
            this.circularPictureBox14.TabStop = false;
            this.circularPictureBox14.ToolTipValues = null;
            // 
            // circularPictureBox15
            // 
            this.circularPictureBox15.BackColor = System.Drawing.Color.Black;
            this.circularPictureBox15.Location = new System.Drawing.Point(1079, 165);
            this.circularPictureBox15.Name = "circularPictureBox15";
            this.circularPictureBox15.Size = new System.Drawing.Size(64, 64);
            this.circularPictureBox15.TabIndex = 27;
            this.circularPictureBox15.TabStop = false;
            this.circularPictureBox15.ToolTipValues = null;
            // 
            // circularPictureBox16
            // 
            this.circularPictureBox16.BackColor = System.Drawing.Color.Black;
            this.circularPictureBox16.Location = new System.Drawing.Point(997, 165);
            this.circularPictureBox16.Name = "circularPictureBox16";
            this.circularPictureBox16.Size = new System.Drawing.Size(64, 64);
            this.circularPictureBox16.TabIndex = 26;
            this.circularPictureBox16.TabStop = false;
            this.circularPictureBox16.ToolTipValues = null;
            // 
            // circularPictureBox17
            // 
            this.circularPictureBox17.BackColor = System.Drawing.Color.Black;
            this.circularPictureBox17.Location = new System.Drawing.Point(915, 165);
            this.circularPictureBox17.Name = "circularPictureBox17";
            this.circularPictureBox17.Size = new System.Drawing.Size(64, 64);
            this.circularPictureBox17.TabIndex = 25;
            this.circularPictureBox17.TabStop = false;
            this.circularPictureBox17.ToolTipValues = null;
            // 
            // circularPictureBox18
            // 
            this.circularPictureBox18.BackColor = System.Drawing.Color.Black;
            this.circularPictureBox18.Location = new System.Drawing.Point(833, 165);
            this.circularPictureBox18.Name = "circularPictureBox18";
            this.circularPictureBox18.Size = new System.Drawing.Size(64, 64);
            this.circularPictureBox18.TabIndex = 24;
            this.circularPictureBox18.TabStop = false;
            this.circularPictureBox18.ToolTipValues = null;
            // 
            // circularPictureBox19
            // 
            this.circularPictureBox19.BackColor = System.Drawing.Color.Black;
            this.circularPictureBox19.Location = new System.Drawing.Point(751, 165);
            this.circularPictureBox19.Name = "circularPictureBox19";
            this.circularPictureBox19.Size = new System.Drawing.Size(64, 64);
            this.circularPictureBox19.TabIndex = 23;
            this.circularPictureBox19.TabStop = false;
            this.circularPictureBox19.ToolTipValues = null;
            // 
            // circularPictureBox20
            // 
            this.circularPictureBox20.BackColor = System.Drawing.Color.Black;
            this.circularPictureBox20.Location = new System.Drawing.Point(669, 165);
            this.circularPictureBox20.Name = "circularPictureBox20";
            this.circularPictureBox20.Size = new System.Drawing.Size(64, 64);
            this.circularPictureBox20.TabIndex = 22;
            this.circularPictureBox20.TabStop = false;
            this.circularPictureBox20.ToolTipValues = null;
            // 
            // circularPictureBox21
            // 
            this.circularPictureBox21.BackColor = System.Drawing.Color.Black;
            this.circularPictureBox21.Location = new System.Drawing.Point(587, 165);
            this.circularPictureBox21.Name = "circularPictureBox21";
            this.circularPictureBox21.Size = new System.Drawing.Size(64, 64);
            this.circularPictureBox21.TabIndex = 21;
            this.circularPictureBox21.TabStop = false;
            this.circularPictureBox21.ToolTipValues = null;
            // 
            // circularPictureBox22
            // 
            this.circularPictureBox22.BackColor = System.Drawing.Color.Black;
            this.circularPictureBox22.Location = new System.Drawing.Point(505, 165);
            this.circularPictureBox22.Name = "circularPictureBox22";
            this.circularPictureBox22.Size = new System.Drawing.Size(64, 64);
            this.circularPictureBox22.TabIndex = 20;
            this.circularPictureBox22.TabStop = false;
            this.circularPictureBox22.ToolTipValues = null;
            // 
            // circularPictureBox23
            // 
            this.circularPictureBox23.BackColor = System.Drawing.Color.Black;
            this.circularPictureBox23.Location = new System.Drawing.Point(423, 165);
            this.circularPictureBox23.Name = "circularPictureBox23";
            this.circularPictureBox23.Size = new System.Drawing.Size(64, 64);
            this.circularPictureBox23.TabIndex = 19;
            this.circularPictureBox23.TabStop = false;
            this.circularPictureBox23.ToolTipValues = null;
            // 
            // circularPictureBox24
            // 
            this.circularPictureBox24.BackColor = System.Drawing.Color.Black;
            this.circularPictureBox24.Location = new System.Drawing.Point(341, 165);
            this.circularPictureBox24.Name = "circularPictureBox24";
            this.circularPictureBox24.Size = new System.Drawing.Size(64, 64);
            this.circularPictureBox24.TabIndex = 18;
            this.circularPictureBox24.TabStop = false;
            this.circularPictureBox24.ToolTipValues = null;
            // 
            // circularPictureBox25
            // 
            this.circularPictureBox25.BackColor = System.Drawing.Color.Black;
            this.circularPictureBox25.Location = new System.Drawing.Point(259, 165);
            this.circularPictureBox25.Name = "circularPictureBox25";
            this.circularPictureBox25.Size = new System.Drawing.Size(64, 64);
            this.circularPictureBox25.TabIndex = 17;
            this.circularPictureBox25.TabStop = false;
            this.circularPictureBox25.ToolTipValues = null;
            // 
            // circularPictureBox26
            // 
            this.circularPictureBox26.BackColor = System.Drawing.Color.Black;
            this.circularPictureBox26.Location = new System.Drawing.Point(177, 165);
            this.circularPictureBox26.Name = "circularPictureBox26";
            this.circularPictureBox26.Size = new System.Drawing.Size(64, 64);
            this.circularPictureBox26.TabIndex = 16;
            this.circularPictureBox26.TabStop = false;
            this.circularPictureBox26.ToolTipValues = null;
            // 
            // circularPictureBox27
            // 
            this.circularPictureBox27.BackColor = System.Drawing.Color.Black;
            this.circularPictureBox27.Location = new System.Drawing.Point(95, 165);
            this.circularPictureBox27.Name = "circularPictureBox27";
            this.circularPictureBox27.Size = new System.Drawing.Size(64, 64);
            this.circularPictureBox27.TabIndex = 15;
            this.circularPictureBox27.TabStop = false;
            this.circularPictureBox27.ToolTipValues = null;
            // 
            // circularPictureBox28
            // 
            this.circularPictureBox28.BackColor = System.Drawing.Color.Black;
            this.circularPictureBox28.Location = new System.Drawing.Point(13, 165);
            this.circularPictureBox28.Name = "circularPictureBox28";
            this.circularPictureBox28.Size = new System.Drawing.Size(64, 64);
            this.circularPictureBox28.TabIndex = 14;
            this.circularPictureBox28.TabStop = false;
            this.circularPictureBox28.ToolTipValues = null;
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
            // 
            // circularPictureBox42
            // 
            this.circularPictureBox42.BackColor = System.Drawing.Color.Black;
            this.circularPictureBox42.Location = new System.Drawing.Point(13, 317);
            this.circularPictureBox42.Name = "circularPictureBox42";
            this.circularPictureBox42.Size = new System.Drawing.Size(64, 64);
            this.circularPictureBox42.TabIndex = 28;
            this.circularPictureBox42.TabStop = false;
            this.circularPictureBox42.ToolTipValues = null;
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
            this.Controls.Add(this.circularPictureBox42);
            this.Controls.Add(this.circularPictureBox15);
            this.Controls.Add(this.circularPictureBox16);
            this.Controls.Add(this.circularPictureBox17);
            this.Controls.Add(this.circularPictureBox18);
            this.Controls.Add(this.circularPictureBox19);
            this.Controls.Add(this.circularPictureBox20);
            this.Controls.Add(this.circularPictureBox21);
            this.Controls.Add(this.circularPictureBox22);
            this.Controls.Add(this.circularPictureBox23);
            this.Controls.Add(this.circularPictureBox24);
            this.Controls.Add(this.circularPictureBox25);
            this.Controls.Add(this.circularPictureBox26);
            this.Controls.Add(this.circularPictureBox27);
            this.Controls.Add(this.circularPictureBox28);
            this.Controls.Add(this.circularPictureBox14);
            this.Controls.Add(this.circularPictureBox13);
            this.Controls.Add(this.circularPictureBox12);
            this.Controls.Add(this.circularPictureBox11);
            this.Controls.Add(this.circularPictureBox10);
            this.Controls.Add(this.circularPictureBox9);
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
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox28)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox42)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private bool _showColourInformation;

        //Palette State
        private KryptonManager k_manager = new KryptonManager();
        private PaletteBackInheritRedirect m_paletteBack;
        private PaletteBorderInheritRedirect m_paletteBorder;
        private PaletteContentInheritRedirect m_paletteContent;

        private IPalette _palette;
        private PaletteRedirect _paletteRedirect;
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
    }
}