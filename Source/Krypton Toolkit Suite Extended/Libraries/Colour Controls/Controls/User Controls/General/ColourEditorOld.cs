using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Drawing.Suite
{
    [DefaultEvent("ColourChanged"), DefaultProperty("Colour")]
    public class ColourEditorOld : UserControl, IColourEditor
    {
        #region Design Code
        private Panel pnlAlpha;
        private Panel pnlHSLUI;
        private Panel panel8;
        private Panel panel7;
        private Panel panel6;
        private Panel panel5;
        private Panel pnlRGB;
        private Panel panel12;
        private Panel panel11;
        private Panel panel10;
        private Panel panel9;
        private Panel panel35;
        private Panel panel27;
        private Panel panel13;
        private Panel panel32;
        private Panel panel24;
        private Panel panel16;
        private Panel panel33;
        private Panel panel25;
        private Panel panel15;
        private Panel panel34;
        private Panel panel26;
        private Panel panel14;
        private KryptonLabel kryptonLabel1;
        private Panel panel29;
        private Panel panel21;
        private Panel pnlRed;
        private Panel panel30;
        private Panel panel22;
        private Panel pnlGreen;
        private Panel panel31;
        private Panel panel23;
        private Panel pnlBlue;
        private Panel panel28;
        private Panel panel17;
        private KryptonLabel klblAlpha;
        private KryptonLabel klblHSL;
        private KryptonLabel klblHue;
        private KryptonLabel kryptonLabel8;
        private KryptonLabel kryptonLabel9;
        private KryptonLabel klblRed;
        private KryptonLabel klblGreen;
        private KryptonLabel klblBlue;
        private KryptonLabel klblHex;
        private RGBAColourSliderControl rColourBar;
        private RGBAColourSliderControl gColourBar;
        private RGBAColourSliderControl bColourBar;
        private KryptonComboBox kcmbHexadecimalValue;
        private KryptonRedValueNumericBox knudRed;
        private KryptonGreenValueNumericBox knudGreen;
        private KryptonBlueValueNumericBox knudBlue;
        private HueColourSliderControl hColourBar;
        private SaturationColourSliderControl sColourBar;
        private LightnessColourSliderControl lColourBar;
        private RGBAColourSliderControl aColourBar;
        private KryptonNumericUpDown knudHue;
        private KryptonNumericUpDown knudSaturation;
        private KryptonNumericUpDown knudLuminosity;
        private KryptonNumericUpDown knudAlpha;
        private Panel pnlHexadecimal;

        private void InitializeComponent()
        {
            this.pnlAlpha = new System.Windows.Forms.Panel();
            this.panel35 = new System.Windows.Forms.Panel();
            this.aColourBar = new Krypton.Toolkit.Suite.Extended.Drawing.Suite.RGBAColourSliderControl();
            this.panel27 = new System.Windows.Forms.Panel();
            this.knudAlpha = new Krypton.Toolkit.KryptonNumericUpDown();
            this.panel13 = new System.Windows.Forms.Panel();
            this.klblAlpha = new Krypton.Toolkit.KryptonLabel();
            this.pnlHSLUI = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.klblHSL = new Krypton.Toolkit.KryptonLabel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel32 = new System.Windows.Forms.Panel();
            this.hColourBar = new Krypton.Toolkit.Suite.Extended.Drawing.Suite.HueColourSliderControl();
            this.panel24 = new System.Windows.Forms.Panel();
            this.knudHue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.panel16 = new System.Windows.Forms.Panel();
            this.klblHue = new Krypton.Toolkit.KryptonLabel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel33 = new System.Windows.Forms.Panel();
            this.sColourBar = new Krypton.Toolkit.Suite.Extended.Drawing.Suite.SaturationColourSliderControl();
            this.panel25 = new System.Windows.Forms.Panel();
            this.knudSaturation = new Krypton.Toolkit.KryptonNumericUpDown();
            this.panel15 = new System.Windows.Forms.Panel();
            this.kryptonLabel8 = new Krypton.Toolkit.KryptonLabel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel34 = new System.Windows.Forms.Panel();
            this.lColourBar = new Krypton.Toolkit.Suite.Extended.Drawing.Suite.LightnessColourSliderControl();
            this.panel26 = new System.Windows.Forms.Panel();
            this.knudLuminosity = new Krypton.Toolkit.KryptonNumericUpDown();
            this.panel14 = new System.Windows.Forms.Panel();
            this.kryptonLabel9 = new Krypton.Toolkit.KryptonLabel();
            this.pnlRGB = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel29 = new System.Windows.Forms.Panel();
            this.rColourBar = new Krypton.Toolkit.Suite.Extended.Drawing.Suite.RGBAColourSliderControl();
            this.panel21 = new System.Windows.Forms.Panel();
            this.knudRed = new Krypton.Toolkit.Suite.Extended.Drawing.Suite.KryptonRedValueNumericBox();
            this.pnlRed = new System.Windows.Forms.Panel();
            this.klblRed = new Krypton.Toolkit.KryptonLabel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel30 = new System.Windows.Forms.Panel();
            this.gColourBar = new Krypton.Toolkit.Suite.Extended.Drawing.Suite.RGBAColourSliderControl();
            this.panel22 = new System.Windows.Forms.Panel();
            this.knudGreen = new Krypton.Toolkit.Suite.Extended.Drawing.Suite.KryptonGreenValueNumericBox();
            this.pnlGreen = new System.Windows.Forms.Panel();
            this.klblGreen = new Krypton.Toolkit.KryptonLabel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel31 = new System.Windows.Forms.Panel();
            this.bColourBar = new Krypton.Toolkit.Suite.Extended.Drawing.Suite.RGBAColourSliderControl();
            this.panel23 = new System.Windows.Forms.Panel();
            this.knudBlue = new Krypton.Toolkit.Suite.Extended.Drawing.Suite.KryptonBlueValueNumericBox();
            this.pnlBlue = new System.Windows.Forms.Panel();
            this.klblBlue = new Krypton.Toolkit.KryptonLabel();
            this.pnlHexadecimal = new System.Windows.Forms.Panel();
            this.panel28 = new System.Windows.Forms.Panel();
            this.kcmbHexadecimalValue = new Krypton.Toolkit.KryptonComboBox();
            this.panel17 = new System.Windows.Forms.Panel();
            this.klblHex = new Krypton.Toolkit.KryptonLabel();
            this.pnlAlpha.SuspendLayout();
            this.panel35.SuspendLayout();
            this.panel27.SuspendLayout();
            this.panel13.SuspendLayout();
            this.pnlHSLUI.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel32.SuspendLayout();
            this.panel24.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel33.SuspendLayout();
            this.panel25.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel34.SuspendLayout();
            this.panel26.SuspendLayout();
            this.panel14.SuspendLayout();
            this.pnlRGB.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel29.SuspendLayout();
            this.panel21.SuspendLayout();
            this.pnlRed.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel30.SuspendLayout();
            this.panel22.SuspendLayout();
            this.pnlGreen.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel31.SuspendLayout();
            this.panel23.SuspendLayout();
            this.pnlBlue.SuspendLayout();
            this.pnlHexadecimal.SuspendLayout();
            this.panel28.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbHexadecimalValue)).BeginInit();
            this.panel17.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlAlpha
            // 
            this.pnlAlpha.BackColor = System.Drawing.Color.Transparent;
            this.pnlAlpha.Controls.Add(this.panel35);
            this.pnlAlpha.Controls.Add(this.panel27);
            this.pnlAlpha.Controls.Add(this.panel13);
            this.pnlAlpha.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAlpha.Location = new System.Drawing.Point(0, 338);
            this.pnlAlpha.Name = "pnlAlpha";
            this.pnlAlpha.Size = new System.Drawing.Size(337, 37);
            this.pnlAlpha.TabIndex = 0;
            // 
            // panel35
            // 
            this.panel35.BackColor = System.Drawing.Color.Transparent;
            this.panel35.Controls.Add(this.aColourBar);
            this.panel35.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel35.Location = new System.Drawing.Point(83, 0);
            this.panel35.Name = "panel35";
            this.panel35.Size = new System.Drawing.Size(171, 37);
            this.panel35.TabIndex = 5;
            // 
            // aColourBar
            // 
            this.aColourBar.BackColor = System.Drawing.Color.Transparent;
            this.aColourBar.Channel = Krypton.Toolkit.Suite.Extended.Drawing.Suite.RGBAChannel.Alpha;
            this.aColourBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aColourBar.Location = new System.Drawing.Point(0, 0);
            this.aColourBar.Name = "aColourBar";
            this.aColourBar.Size = new System.Drawing.Size(171, 37);
            this.aColourBar.TabIndex = 26;
            // 
            // panel27
            // 
            this.panel27.BackColor = System.Drawing.Color.Transparent;
            this.panel27.Controls.Add(this.knudAlpha);
            this.panel27.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel27.Location = new System.Drawing.Point(254, 0);
            this.panel27.Name = "panel27";
            this.panel27.Size = new System.Drawing.Size(83, 37);
            this.panel27.TabIndex = 4;
            // 
            // knudAlpha
            // 
            this.knudAlpha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.knudAlpha.Location = new System.Drawing.Point(12, 7);
            this.knudAlpha.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudAlpha.Name = "knudAlpha";
            this.knudAlpha.Size = new System.Drawing.Size(58, 23);
            this.knudAlpha.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knudAlpha.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudAlpha.TabIndex = 34;
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.Transparent;
            this.panel13.Controls.Add(this.klblAlpha);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel13.Location = new System.Drawing.Point(0, 0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(83, 37);
            this.panel13.TabIndex = 1;
            // 
            // klblAlpha
            // 
            this.klblAlpha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.klblAlpha.Location = new System.Drawing.Point(0, 0);
            this.klblAlpha.Name = "klblAlpha";
            this.klblAlpha.Size = new System.Drawing.Size(83, 37);
            this.klblAlpha.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblAlpha.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblAlpha.TabIndex = 1;
            this.klblAlpha.Values.Text = "Alpha:";
            // 
            // pnlHSLUI
            // 
            this.pnlHSLUI.BackColor = System.Drawing.Color.Transparent;
            this.pnlHSLUI.Controls.Add(this.panel8);
            this.pnlHSLUI.Controls.Add(this.panel7);
            this.pnlHSLUI.Controls.Add(this.panel6);
            this.pnlHSLUI.Controls.Add(this.panel5);
            this.pnlHSLUI.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlHSLUI.Location = new System.Drawing.Point(0, 187);
            this.pnlHSLUI.Name = "pnlHSLUI";
            this.pnlHSLUI.Size = new System.Drawing.Size(337, 151);
            this.pnlHSLUI.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Transparent;
            this.panel8.Controls.Add(this.klblHSL);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(337, 40);
            this.panel8.TabIndex = 4;
            // 
            // klblHSL
            // 
            this.klblHSL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.klblHSL.Location = new System.Drawing.Point(0, 0);
            this.klblHSL.Name = "klblHSL";
            this.klblHSL.Size = new System.Drawing.Size(337, 40);
            this.klblHSL.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblHSL.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblHSL.TabIndex = 1;
            this.klblHSL.Values.Text = "HSL";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Transparent;
            this.panel7.Controls.Add(this.panel32);
            this.panel7.Controls.Add(this.panel24);
            this.panel7.Controls.Add(this.panel16);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 40);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(337, 37);
            this.panel7.TabIndex = 3;
            // 
            // panel32
            // 
            this.panel32.BackColor = System.Drawing.Color.Transparent;
            this.panel32.Controls.Add(this.hColourBar);
            this.panel32.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel32.Location = new System.Drawing.Point(83, 0);
            this.panel32.Name = "panel32";
            this.panel32.Size = new System.Drawing.Size(171, 37);
            this.panel32.TabIndex = 5;
            // 
            // hColourBar
            // 
            this.hColourBar.BackColor = System.Drawing.Color.Transparent;
            this.hColourBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hColourBar.Location = new System.Drawing.Point(0, 0);
            this.hColourBar.Name = "hColourBar";
            this.hColourBar.Size = new System.Drawing.Size(171, 37);
            this.hColourBar.TabIndex = 23;
            // 
            // panel24
            // 
            this.panel24.BackColor = System.Drawing.Color.Transparent;
            this.panel24.Controls.Add(this.knudHue);
            this.panel24.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel24.Location = new System.Drawing.Point(254, 0);
            this.panel24.Name = "panel24";
            this.panel24.Size = new System.Drawing.Size(83, 37);
            this.panel24.TabIndex = 4;
            // 
            // knudHue
            // 
            this.knudHue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.knudHue.Location = new System.Drawing.Point(12, 7);
            this.knudHue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudHue.Name = "knudHue";
            this.knudHue.Size = new System.Drawing.Size(58, 23);
            this.knudHue.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knudHue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudHue.TabIndex = 31;
            // 
            // panel16
            // 
            this.panel16.BackColor = System.Drawing.Color.Transparent;
            this.panel16.Controls.Add(this.klblHue);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel16.Location = new System.Drawing.Point(0, 0);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(83, 37);
            this.panel16.TabIndex = 2;
            // 
            // klblHue
            // 
            this.klblHue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.klblHue.Location = new System.Drawing.Point(0, 0);
            this.klblHue.Name = "klblHue";
            this.klblHue.Size = new System.Drawing.Size(83, 37);
            this.klblHue.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblHue.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblHue.TabIndex = 1;
            this.klblHue.Values.Text = "H:";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.Controls.Add(this.panel33);
            this.panel6.Controls.Add(this.panel25);
            this.panel6.Controls.Add(this.panel15);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 77);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(337, 37);
            this.panel6.TabIndex = 2;
            // 
            // panel33
            // 
            this.panel33.BackColor = System.Drawing.Color.Transparent;
            this.panel33.Controls.Add(this.sColourBar);
            this.panel33.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel33.Location = new System.Drawing.Point(83, 0);
            this.panel33.Name = "panel33";
            this.panel33.Size = new System.Drawing.Size(171, 37);
            this.panel33.TabIndex = 5;
            // 
            // sColourBar
            // 
            this.sColourBar.BackColor = System.Drawing.Color.Transparent;
            this.sColourBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sColourBar.Location = new System.Drawing.Point(0, 0);
            this.sColourBar.Name = "sColourBar";
            this.sColourBar.Size = new System.Drawing.Size(171, 37);
            this.sColourBar.TabIndex = 24;
            // 
            // panel25
            // 
            this.panel25.BackColor = System.Drawing.Color.Transparent;
            this.panel25.Controls.Add(this.knudSaturation);
            this.panel25.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel25.Location = new System.Drawing.Point(254, 0);
            this.panel25.Name = "panel25";
            this.panel25.Size = new System.Drawing.Size(83, 37);
            this.panel25.TabIndex = 4;
            // 
            // knudSaturation
            // 
            this.knudSaturation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.knudSaturation.Location = new System.Drawing.Point(12, 7);
            this.knudSaturation.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudSaturation.Name = "knudSaturation";
            this.knudSaturation.Size = new System.Drawing.Size(58, 23);
            this.knudSaturation.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knudSaturation.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudSaturation.TabIndex = 32;
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.Transparent;
            this.panel15.Controls.Add(this.kryptonLabel8);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel15.Location = new System.Drawing.Point(0, 0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(83, 37);
            this.panel15.TabIndex = 2;
            // 
            // kryptonLabel8
            // 
            this.kryptonLabel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel8.Location = new System.Drawing.Point(0, 0);
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.Size = new System.Drawing.Size(83, 37);
            this.kryptonLabel8.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel8.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.kryptonLabel8.TabIndex = 1;
            this.kryptonLabel8.Values.Text = "S:";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.Controls.Add(this.panel34);
            this.panel5.Controls.Add(this.panel26);
            this.panel5.Controls.Add(this.panel14);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 114);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(337, 37);
            this.panel5.TabIndex = 1;
            // 
            // panel34
            // 
            this.panel34.BackColor = System.Drawing.Color.Transparent;
            this.panel34.Controls.Add(this.lColourBar);
            this.panel34.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel34.Location = new System.Drawing.Point(83, 0);
            this.panel34.Name = "panel34";
            this.panel34.Size = new System.Drawing.Size(171, 37);
            this.panel34.TabIndex = 5;
            // 
            // lColourBar
            // 
            this.lColourBar.BackColor = System.Drawing.Color.Transparent;
            this.lColourBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lColourBar.Location = new System.Drawing.Point(0, 0);
            this.lColourBar.Name = "lColourBar";
            this.lColourBar.Size = new System.Drawing.Size(171, 37);
            this.lColourBar.TabIndex = 25;
            // 
            // panel26
            // 
            this.panel26.BackColor = System.Drawing.Color.Transparent;
            this.panel26.Controls.Add(this.knudLuminosity);
            this.panel26.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel26.Location = new System.Drawing.Point(254, 0);
            this.panel26.Name = "panel26";
            this.panel26.Size = new System.Drawing.Size(83, 37);
            this.panel26.TabIndex = 4;
            // 
            // knudLuminosity
            // 
            this.knudLuminosity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.knudLuminosity.Location = new System.Drawing.Point(12, 7);
            this.knudLuminosity.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudLuminosity.Name = "knudLuminosity";
            this.knudLuminosity.Size = new System.Drawing.Size(58, 23);
            this.knudLuminosity.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knudLuminosity.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudLuminosity.TabIndex = 33;
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.Transparent;
            this.panel14.Controls.Add(this.kryptonLabel9);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel14.Location = new System.Drawing.Point(0, 0);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(83, 37);
            this.panel14.TabIndex = 2;
            // 
            // kryptonLabel9
            // 
            this.kryptonLabel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel9.Location = new System.Drawing.Point(0, 0);
            this.kryptonLabel9.Name = "kryptonLabel9";
            this.kryptonLabel9.Size = new System.Drawing.Size(83, 37);
            this.kryptonLabel9.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel9.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.kryptonLabel9.TabIndex = 1;
            this.kryptonLabel9.Values.Text = "L:";
            // 
            // pnlRGB
            // 
            this.pnlRGB.BackColor = System.Drawing.Color.Transparent;
            this.pnlRGB.Controls.Add(this.panel12);
            this.pnlRGB.Controls.Add(this.panel11);
            this.pnlRGB.Controls.Add(this.panel10);
            this.pnlRGB.Controls.Add(this.panel9);
            this.pnlRGB.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRGB.Location = new System.Drawing.Point(0, 0);
            this.pnlRGB.Name = "pnlRGB";
            this.pnlRGB.Size = new System.Drawing.Size(337, 150);
            this.pnlRGB.TabIndex = 2;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.Transparent;
            this.panel12.Controls.Add(this.kryptonLabel1);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(337, 39);
            this.panel12.TabIndex = 4;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(337, 39);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "RGB";
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.Transparent;
            this.panel11.Controls.Add(this.panel29);
            this.panel11.Controls.Add(this.panel21);
            this.panel11.Controls.Add(this.pnlRed);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel11.Location = new System.Drawing.Point(0, 39);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(337, 37);
            this.panel11.TabIndex = 3;
            // 
            // panel29
            // 
            this.panel29.BackColor = System.Drawing.Color.Transparent;
            this.panel29.Controls.Add(this.rColourBar);
            this.panel29.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel29.Location = new System.Drawing.Point(83, 0);
            this.panel29.Name = "panel29";
            this.panel29.Size = new System.Drawing.Size(171, 37);
            this.panel29.TabIndex = 4;
            // 
            // rColourBar
            // 
            this.rColourBar.BackColor = System.Drawing.Color.Transparent;
            this.rColourBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rColourBar.Location = new System.Drawing.Point(0, 0);
            this.rColourBar.Name = "rColourBar";
            this.rColourBar.Size = new System.Drawing.Size(171, 37);
            this.rColourBar.TabIndex = 18;
            // 
            // panel21
            // 
            this.panel21.BackColor = System.Drawing.Color.Transparent;
            this.panel21.Controls.Add(this.knudRed);
            this.panel21.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel21.Location = new System.Drawing.Point(254, 0);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(83, 37);
            this.panel21.TabIndex = 3;
            // 
            // knudRed
            // 
            this.knudRed.Location = new System.Drawing.Point(12, 7);
            this.knudRed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudRed.Name = "knudRed";
            this.knudRed.Size = new System.Drawing.Size(58, 22);
            this.knudRed.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.knudRed.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knudRed.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudRed.TabIndex = 27;
            this.knudRed.Typeface = null;
            this.knudRed.UseAccessibleUI = false;
            // 
            // pnlRed
            // 
            this.pnlRed.BackColor = System.Drawing.Color.Transparent;
            this.pnlRed.Controls.Add(this.klblRed);
            this.pnlRed.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlRed.Location = new System.Drawing.Point(0, 0);
            this.pnlRed.Name = "pnlRed";
            this.pnlRed.Size = new System.Drawing.Size(83, 37);
            this.pnlRed.TabIndex = 2;
            // 
            // klblRed
            // 
            this.klblRed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.klblRed.Location = new System.Drawing.Point(0, 0);
            this.klblRed.Name = "klblRed";
            this.klblRed.Size = new System.Drawing.Size(83, 37);
            this.klblRed.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblRed.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblRed.TabIndex = 1;
            this.klblRed.Values.Text = "R:";
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Transparent;
            this.panel10.Controls.Add(this.panel30);
            this.panel10.Controls.Add(this.panel22);
            this.panel10.Controls.Add(this.pnlGreen);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel10.Location = new System.Drawing.Point(0, 76);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(337, 37);
            this.panel10.TabIndex = 2;
            // 
            // panel30
            // 
            this.panel30.BackColor = System.Drawing.Color.Transparent;
            this.panel30.Controls.Add(this.gColourBar);
            this.panel30.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel30.Location = new System.Drawing.Point(83, 0);
            this.panel30.Name = "panel30";
            this.panel30.Size = new System.Drawing.Size(171, 37);
            this.panel30.TabIndex = 5;
            // 
            // gColourBar
            // 
            this.gColourBar.BackColor = System.Drawing.Color.Transparent;
            this.gColourBar.Channel = Krypton.Toolkit.Suite.Extended.Drawing.Suite.RGBAChannel.Green;
            this.gColourBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gColourBar.Location = new System.Drawing.Point(0, 0);
            this.gColourBar.Name = "gColourBar";
            this.gColourBar.Size = new System.Drawing.Size(171, 37);
            this.gColourBar.TabIndex = 19;
            // 
            // panel22
            // 
            this.panel22.BackColor = System.Drawing.Color.Transparent;
            this.panel22.Controls.Add(this.knudGreen);
            this.panel22.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel22.Location = new System.Drawing.Point(254, 0);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(83, 37);
            this.panel22.TabIndex = 4;
            // 
            // knudGreen
            // 
            this.knudGreen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.knudGreen.Location = new System.Drawing.Point(12, 7);
            this.knudGreen.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudGreen.Name = "knudGreen";
            this.knudGreen.Size = new System.Drawing.Size(58, 22);
            this.knudGreen.StateCommon.Back.Color1 = System.Drawing.Color.Green;
            this.knudGreen.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knudGreen.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudGreen.TabIndex = 28;
            this.knudGreen.Typeface = null;
            this.knudGreen.UseAccessibleUI = false;
            // 
            // pnlGreen
            // 
            this.pnlGreen.BackColor = System.Drawing.Color.Transparent;
            this.pnlGreen.Controls.Add(this.klblGreen);
            this.pnlGreen.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlGreen.Location = new System.Drawing.Point(0, 0);
            this.pnlGreen.Name = "pnlGreen";
            this.pnlGreen.Size = new System.Drawing.Size(83, 37);
            this.pnlGreen.TabIndex = 2;
            // 
            // klblGreen
            // 
            this.klblGreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.klblGreen.Location = new System.Drawing.Point(0, 0);
            this.klblGreen.Name = "klblGreen";
            this.klblGreen.Size = new System.Drawing.Size(83, 37);
            this.klblGreen.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblGreen.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblGreen.TabIndex = 1;
            this.klblGreen.Values.Text = "G:";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Transparent;
            this.panel9.Controls.Add(this.panel31);
            this.panel9.Controls.Add(this.panel23);
            this.panel9.Controls.Add(this.pnlBlue);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel9.Location = new System.Drawing.Point(0, 113);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(337, 37);
            this.panel9.TabIndex = 1;
            // 
            // panel31
            // 
            this.panel31.BackColor = System.Drawing.Color.Transparent;
            this.panel31.Controls.Add(this.bColourBar);
            this.panel31.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel31.Location = new System.Drawing.Point(83, 0);
            this.panel31.Name = "panel31";
            this.panel31.Size = new System.Drawing.Size(171, 37);
            this.panel31.TabIndex = 5;
            // 
            // bColourBar
            // 
            this.bColourBar.BackColor = System.Drawing.Color.Transparent;
            this.bColourBar.Channel = Krypton.Toolkit.Suite.Extended.Drawing.Suite.RGBAChannel.Blue;
            this.bColourBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bColourBar.Location = new System.Drawing.Point(0, 0);
            this.bColourBar.Name = "bColourBar";
            this.bColourBar.Size = new System.Drawing.Size(171, 37);
            this.bColourBar.TabIndex = 20;
            // 
            // panel23
            // 
            this.panel23.BackColor = System.Drawing.Color.Transparent;
            this.panel23.Controls.Add(this.knudBlue);
            this.panel23.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel23.Location = new System.Drawing.Point(254, 0);
            this.panel23.Name = "panel23";
            this.panel23.Size = new System.Drawing.Size(83, 37);
            this.panel23.TabIndex = 4;
            // 
            // knudBlue
            // 
            this.knudBlue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.knudBlue.Location = new System.Drawing.Point(12, 7);
            this.knudBlue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudBlue.Name = "knudBlue";
            this.knudBlue.Size = new System.Drawing.Size(58, 22);
            this.knudBlue.StateCommon.Back.Color1 = System.Drawing.Color.Blue;
            this.knudBlue.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knudBlue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudBlue.TabIndex = 29;
            this.knudBlue.Typeface = null;
            this.knudBlue.UseAccessibleUI = false;
            // 
            // pnlBlue
            // 
            this.pnlBlue.BackColor = System.Drawing.Color.Transparent;
            this.pnlBlue.Controls.Add(this.klblBlue);
            this.pnlBlue.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBlue.Location = new System.Drawing.Point(0, 0);
            this.pnlBlue.Name = "pnlBlue";
            this.pnlBlue.Size = new System.Drawing.Size(83, 37);
            this.pnlBlue.TabIndex = 2;
            // 
            // klblBlue
            // 
            this.klblBlue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.klblBlue.Location = new System.Drawing.Point(0, 0);
            this.klblBlue.Name = "klblBlue";
            this.klblBlue.Size = new System.Drawing.Size(83, 37);
            this.klblBlue.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblBlue.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblBlue.TabIndex = 1;
            this.klblBlue.Values.Text = "B:";
            // 
            // pnlHexadecimal
            // 
            this.pnlHexadecimal.BackColor = System.Drawing.Color.Transparent;
            this.pnlHexadecimal.Controls.Add(this.panel28);
            this.pnlHexadecimal.Controls.Add(this.panel17);
            this.pnlHexadecimal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHexadecimal.Location = new System.Drawing.Point(0, 150);
            this.pnlHexadecimal.Name = "pnlHexadecimal";
            this.pnlHexadecimal.Size = new System.Drawing.Size(337, 37);
            this.pnlHexadecimal.TabIndex = 3;
            // 
            // panel28
            // 
            this.panel28.BackColor = System.Drawing.Color.Transparent;
            this.panel28.Controls.Add(this.kcmbHexadecimalValue);
            this.panel28.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel28.Location = new System.Drawing.Point(83, 0);
            this.panel28.Name = "panel28";
            this.panel28.Size = new System.Drawing.Size(254, 37);
            this.panel28.TabIndex = 4;
            // 
            // kcmbHexadecimalValue
            // 
            this.kcmbHexadecimalValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kcmbHexadecimalValue.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.kcmbHexadecimalValue.DropDownWidth = 254;
            this.kcmbHexadecimalValue.IntegralHeight = false;
            this.kcmbHexadecimalValue.Location = new System.Drawing.Point(0, 0);
            this.kcmbHexadecimalValue.Name = "kcmbHexadecimalValue";
            this.kcmbHexadecimalValue.Size = new System.Drawing.Size(254, 22);
            this.kcmbHexadecimalValue.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbHexadecimalValue.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbHexadecimalValue.TabIndex = 0;
            // 
            // panel17
            // 
            this.panel17.BackColor = System.Drawing.Color.Transparent;
            this.panel17.Controls.Add(this.klblHex);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel17.Location = new System.Drawing.Point(0, 0);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(83, 37);
            this.panel17.TabIndex = 2;
            // 
            // klblHex
            // 
            this.klblHex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.klblHex.Location = new System.Drawing.Point(0, 0);
            this.klblHex.Name = "klblHex";
            this.klblHex.Size = new System.Drawing.Size(83, 37);
            this.klblHex.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblHex.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblHex.TabIndex = 1;
            this.klblHex.Values.Text = "Hex:";
            // 
            // ColourEditorOld
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlHexadecimal);
            this.Controls.Add(this.pnlRGB);
            this.Controls.Add(this.pnlHSLUI);
            this.Controls.Add(this.pnlAlpha);
            this.Name = "ColourEditorOld";
            this.Size = new System.Drawing.Size(337, 375);
            this.pnlAlpha.ResumeLayout(false);
            this.panel35.ResumeLayout(false);
            this.panel27.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.pnlHSLUI.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel32.ResumeLayout(false);
            this.panel24.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel33.ResumeLayout(false);
            this.panel25.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel34.ResumeLayout(false);
            this.panel26.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.pnlRGB.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel29.ResumeLayout(false);
            this.panel21.ResumeLayout(false);
            this.pnlRed.ResumeLayout(false);
            this.pnlRed.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel30.ResumeLayout(false);
            this.panel22.ResumeLayout(false);
            this.pnlGreen.ResumeLayout(false);
            this.pnlGreen.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel31.ResumeLayout(false);
            this.panel23.ResumeLayout(false);
            this.pnlBlue.ResumeLayout(false);
            this.pnlBlue.PerformLayout();
            this.pnlHexadecimal.ResumeLayout(false);
            this.panel28.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kcmbHexadecimalValue)).EndInit();
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region Constants
        //private const int DEFAULT_SIZE_HEIGHT = Height;

        private static readonly object _eventColourChanged = new object();

        private static readonly object _eventOrientationChanged = new object();

        private static readonly object _eventShowAlphaChannelChanged = new object();

        private static readonly object _eventShowColourSpaceLabelsChanged = new object();

        private const int _minimumBarWidth = 30;

        #endregion

        #region Fields

        private Color _colour;

        private HSLColour _hslColour;

        private Orientation _orientation;

        private bool _showAlphaChannel, _showColourSpaceLabels, _showLabelsInColour, _showHSLUI, _showHexadecimalUI;

        #endregion

        #region Events

        [Category("Property Changed")]
        public event EventHandler OrientationChanged
        {
            add { this.Events.AddHandler(_eventOrientationChanged, value); }
            remove { this.Events.RemoveHandler(_eventOrientationChanged, value); }
        }

        [Category("Property Changed")]
        public event EventHandler ShowAlphaChannelChanged
        {
            add { this.Events.AddHandler(_eventShowAlphaChannelChanged, value); }
            remove { this.Events.RemoveHandler(_eventShowAlphaChannelChanged, value); }
        }

        /// <summary>
        /// Occurs when the ShowColourSpaceLabels property value changes
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler ShowColourSpaceLabelsChanged
        {
            add { this.Events.AddHandler(_eventShowColourSpaceLabelsChanged, value); }
            remove { this.Events.RemoveHandler(_eventShowColourSpaceLabelsChanged, value); }
        }

        [Category("Property Changed")]
        public event EventHandler ColourChanged
        {
            add => this.Events.AddHandler(_eventColourChanged, value);

            remove => Events.RemoveHandler(_eventColourChanged, value);
        }

        public delegate void ColourChangedEventHandler(object sender, ColourChangedEventArgs e);

        //public event ColourChangedEventHandler ColourChanged;

        //protected virtual void OnColourChanged(object sender, ColourChangedEventArgs e) => ColourChanged?.Invoke(sender, e);
        #endregion

        #region Properties
        [Category("Appearance"), DefaultValue(typeof(Color), "0, 0, 0")]
        public Color Colour
        {
            get => _colour;

            set
            {
                if (value.A != 255 && !_showAlphaChannel)
                {
                    value = Color.FromArgb(255, value);
                }

                if (_colour != value)
                {
                    _colour = value;

                    if (!LockUpdates)
                    {
                        LockUpdates = true;

                        HslColour = new HSLColour(value);

                        LockUpdates = false;

                        UpdateFields(false);
                    }
                    else
                    {
                        OnColourChanged(EventArgs.Empty);
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the component colour as a HSL structure.
        /// </summary>
        /// <value>The component colour.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual HSLColour HslColour
        {
            get => _hslColour;
            set
            {
                if (HslColour != value)
                {
                    _hslColour = value;

                    if (!LockUpdates)
                    {
                        LockUpdates = true;

                        Colour = value.ToRgbColour();

                        LockUpdates = false;

                        UpdateFields(false);
                    }
                    else
                    {
                        this.OnColourChanged(EventArgs.Empty);
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the orientation of the editor.
        /// </summary>
        /// <value>The orientation.</value>
        [Category("Appearance")]
        [DefaultValue(typeof(Orientation), "Vertical")]
        public virtual Orientation Orientation
        {
            get { return _orientation; }
            set
            {
                if (this.Orientation != value)
                {
                    _orientation = value;

                    this.OnOrientationChanged(EventArgs.Empty);
                }
            }
        }

        [Category("Behavior")]
        [DefaultValue(true)]
        public virtual bool ShowAlphaChannel
        {
            get { return _showAlphaChannel; }
            set
            {
                if (_showAlphaChannel != value)
                {
                    _showAlphaChannel = value;

                    //this.OnShowAlphaChannelChanged(EventArgs.Empty);

                    Invalidate();
                }
            }
        }

        [Category("Appearance"), DefaultValue(true)]
        public bool ShowColourSpaceLabels
        {
            get => _showColourSpaceLabels;

            set
            {
                if (_showColourSpaceLabels != value)
                {
                    _showColourSpaceLabels = value;

                    //this.OnShowColourSpaceLabelsChanged(EventArgs.Empty);

                    Invalidate();
                }
            }
        }

        [Category("Appearence"), DefaultValue(false)]
        public bool ShowLabelsInColour { get => _showLabelsInColour; set { _showLabelsInColour = value; Invalidate(); } }

        [Category("Appearence"), DefaultValue(true)]
        public bool ShowHSL { get => _showHSLUI; set { _showHSLUI = value; Invalidate(); } }

        [Category("Appearence"), DefaultValue(true)]
        public bool ShowHexadecimal { get => _showHexadecimalUI; set { _showHexadecimalUI = value; Invalidate(); } }

        /// <summary>
        /// Gets or sets a value indicating whether input changes should be processed.
        /// </summary>
        /// <value><c>true</c> if input changes should be processed; otherwise, <c>false</c>.</value>
        protected bool LockUpdates { get; set; }
        #endregion

        #region Constructor
        public ColourEditorOld()
        {
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);

            _colour = Color.Black;

            _orientation = Orientation.Vertical;

            Size = new Size(261, 359);

            _showAlphaChannel = true;

            _showColourSpaceLabels = true;
        }
        #endregion

        #region Methods
        private void SetBarStates(bool visible)
        {
            rColourBar.Visible = visible;
            gColourBar.Visible = visible;
            bColourBar.Visible = visible;
            hColourBar.Visible = visible;
            sColourBar.Visible = visible;
            lColourBar.Visible = visible;
            aColourBar.Visible = _showAlphaChannel && visible;
        }

        private void SetControlStates()
        {
            pnlAlpha.Visible = _showAlphaChannel;

            pnlRGB.Visible = _showColourSpaceLabels;

            pnlHexadecimal.Visible = _showHexadecimalUI;

            pnlHSLUI.Visible = _showHSLUI;
        }

        private void SetDropDownWidth()
        {
            if (kcmbHexadecimalValue.Items.Count != 0)
            {
                kcmbHexadecimalValue.DropDownWidth = kcmbHexadecimalValue.ItemHeight * 2 + kcmbHexadecimalValue.Items.Cast<string>().Max(s => TextRenderer.MeasureText(s, this.Font).Width);
            }
        }

        /// <summary>
        /// Change handler for editing components.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ValueChangedHandler(object sender, EventArgs e)
        {
            if (!this.LockUpdates)
            {
                bool useHsl;
                bool useRgb;
                bool useNamed;

                useHsl = false;
                useRgb = false;
                useNamed = false;

                this.LockUpdates = true;

                if (sender == kcmbHexadecimalValue)
                {
                    string text;
                    int namedIndex;

                    text = kcmbHexadecimalValue.Text;
                    if (text.StartsWith("#"))
                    {
                        text = text.Substring(1);
                    }

#if !NETCOREAPP
                    if (kcmbHexadecimalValue.Items.Count == 0)
                    {
                        this.FillNamedColours();
                    }
#endif

                    namedIndex = kcmbHexadecimalValue.FindStringExact(text);

                    if (namedIndex != -1 || text.Length == 6 || text.Length == 8)
                    {
                        try
                        {
                            Color colour;

                            colour = namedIndex != -1 ? Color.FromName(text) : ColorTranslator.FromHtml("#" + text);
                            knudAlpha.Value = colour.A;
                            knudRed.Value = colour.R;
                            knudBlue.Value = colour.B;
                            knudGreen.Value = colour.G;

                            useRgb = true;
                        }
                        // ReSharper disable EmptyGeneralCatchClause
                        catch
                        { }
                        // ReSharper restore EmptyGeneralCatchClause
                    }
                    else
                    {
                        useNamed = true;
                    }
                }
                else if (sender == aColourBar || sender == rColourBar || sender == gColourBar || sender == bColourBar)
                {
                    knudAlpha.Value = (int)aColourBar.Value;
                    knudRed.Value = (int)rColourBar.Value;
                    knudGreen.Value = (int)gColourBar.Value;
                    knudBlue.Value = (int)bColourBar.Value;

                    useRgb = true;
                }
                else if (sender == knudAlpha || sender == knudRed || sender == knudGreen || sender == knudBlue)
                {
                    useRgb = true;
                }
                else if (sender == hColourBar || sender == lColourBar || sender == sColourBar)
                {
                    knudHue.Value = (int)hColourBar.Value;
                    knudSaturation.Value = (int)sColourBar.Value;
                    knudLuminosity.Value = (int)lColourBar.Value;

                    useHsl = true;
                }
                else if (sender == knudHue || sender == knudSaturation || sender == knudLuminosity)
                {
                    useHsl = true;
                }

                if (useRgb || useNamed)
                {
                    Color colour;

                    colour = useNamed ? Color.FromName(kcmbHexadecimalValue.Text) : Color.FromArgb((int)knudAlpha.Value, (int)knudRed.Value, (int)knudGreen.Value, (int)knudBlue.Value);

                    this.Colour = colour;
                    this.HslColour = new HSLColour(colour);
                }
                else if (useHsl)
                {
                    HSLColour colour;

                    colour = new HSLColour((int)knudAlpha.Value, (double)knudHue.Value, (double)knudSaturation.Value / 100, (double)knudLuminosity.Value / 100);
                    this.HslColour = colour;
                    this.Colour = colour.ToRgbColour();
                }

                this.LockUpdates = false;
                this.UpdateFields(true);
            }
        }

        private void SetColouredLabels(bool value)
        {
            if (value)
            {
                klblRed.StateCommon.ShortText.Color1 = Color.Red;

                klblRed.StateCommon.ShortText.Color2 = Color.Red;

                klblGreen.StateCommon.ShortText.Color1 = Color.Green;

                klblGreen.StateCommon.ShortText.Color2 = Color.Green;

                klblBlue.StateCommon.ShortText.Color1 = Color.Blue;

                klblBlue.StateCommon.ShortText.Color2 = Color.Blue;
            }
            else
            {
                klblRed.StateCommon.ShortText.Color1 = Color.Empty;

                klblRed.StateCommon.ShortText.Color2 = Color.Empty;

                klblGreen.StateCommon.ShortText.Color1 = Color.Empty;

                klblGreen.StateCommon.ShortText.Color2 = Color.Empty;

                klblBlue.StateCommon.ShortText.Color1 = Color.Empty;

                klblBlue.StateCommon.ShortText.Color2 = Color.Empty;
            }
        }

        private void ShowHSLUI(bool value)
        {
            pnlHSLUI.Visible = value;

            AdjustUI();
        }

        private void ShowAlphaUI(bool value) { pnlAlpha.Visible = value; AdjustUI(); }

        private void ShowHexadecimalUI(bool value) { pnlHexadecimal.Visible = value; AdjustUI(); }

        private void AdjustUI()
        {
            int height;

            if (ShowAlphaChannel && ShowHexadecimal && ShowHSL)
            {
                height = pnlRGB.Height + pnlRed.Height + pnlBlue.Height + pnlHexadecimal.Height + pnlHSLUI.Height + pnlAlpha.Height;

                Height = height;
            }
            else if (ShowAlphaChannel && ShowHexadecimal)
            {
                height = pnlRGB.Height + pnlRed.Height + pnlBlue.Height + pnlHexadecimal.Height + pnlAlpha.Height;

                Height = height;
            }
            else if (ShowAlphaChannel && ShowHSL)
            {
                height = pnlRGB.Height + pnlRed.Height + pnlBlue.Height + pnlHSLUI.Height +  pnlAlpha.Height;

                Height = height;
            }
        }

#if !NETCOREAPP
        private void AddColourProperties<T>()
        {
            Type type;
            Type colourType;

            type = typeof(T);
            colourType = typeof(Color);

            // ReSharper disable once LoopCanBePartlyConvertedToQuery
            foreach (PropertyInfo property in type.GetProperties(BindingFlags.Public | BindingFlags.Static))
            {
                if (property.PropertyType == colourType)
                {
                    Color colour;

                    colour = (Color)property.GetValue(type, null);
                    if (!colour.IsEmpty)
                    {
                        kcmbHexadecimalValue.Items.Add(colour.Name);
                    }
                }
            }
        }
#endif

        private string AddSpaces(string text)
        {
            string result;

            //http://stackoverflow.com/a/272929/148962

            if (!string.IsNullOrEmpty(text))
            {
                StringBuilder newText;

                newText = new StringBuilder(text.Length * 2);
                newText.Append(text[0]);
                for (int i = 1; i < text.Length; i++)
                {
                    if (char.IsUpper(text[i]) && text[i - 1] != ' ')
                    {
                        newText.Append(' ');
                    }
                    newText.Append(text[i]);
                }

                result = newText.ToString();
            }
            else
            {
                result = null;
            }

            return result;
        }

#if !NETCOREAPP
        private void FillNamedColours()
        {
            AddColourProperties<SystemColors>();
            
            AddColourProperties<Color>();
            
            SetDropDownWidth();
        }
#endif
        #endregion

        #region Override Voids
        /// <summary>
        /// Raises the <see cref="ColourChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnColourChanged(EventArgs e)
        {
            EventHandler handler;

            this.UpdateFields(false);

            handler = (EventHandler)this.Events[_eventColourChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="OrientationChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnOrientationChanged(EventArgs e)
        {
            EventHandler handler;

            //ResizeComponents();

            handler = (EventHandler)this.Events[_eventOrientationChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="ShowAlphaChannelChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnShowAlphaChannelChanged(EventArgs e)
        {
            EventHandler handler;

            this.SetControlStates();

            //ResizeComponents();

            handler = (EventHandler)this.Events[_eventShowAlphaChannelChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="ShowColourSpaceLabelsChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnShowColourSpaceLabelsChanged(EventArgs e)
        {
            EventHandler handler;

            this.SetControlStates();

            //ResizeComponents();

            handler = (EventHandler)this.Events[_eventShowColourSpaceLabelsChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Resizes the editing components.
        /// </summary>
        protected virtual void ResizeComponents()
        {
            try
            {
                int group1HeaderLeft;
                int group1BarLeft;
                int group1EditLeft;
                int group2HeaderLeft;
                int group2BarLeft;
                int group2EditLeft;
                int barWidth;
                int editWidth;
                int top;
                int innerMargin;
                int columnWidth;
                int rowHeight;
                int labelOffset;
                int colourBarOffset;
                int editOffset;
                int barHorizontalOffset;

                top = this.Padding.Top;
                innerMargin = 3;
                editWidth = TextRenderer.MeasureText("0000W", this.Font).Width + 6; // magic 6 for interior spacing+borders
                rowHeight = Math.Max(Math.Max(klblRed.Height, rColourBar.Height), knudRed.Height);
                labelOffset = (rowHeight - klblRed.Height) >> 1;
                colourBarOffset = (rowHeight - rColourBar.Height) >> 1;
                editOffset = (rowHeight - knudRed.Height) >> 1;
                barHorizontalOffset = _showAlphaChannel ? klblAlpha.Width : klblHue.Width;

                switch (this.Orientation)
                {
                    case Orientation.Horizontal:
                        columnWidth = (this.ClientSize.Width - (this.Padding.Horizontal + innerMargin)) >> 1;
                        break;
                    default:
                        columnWidth = this.ClientSize.Width - this.Padding.Horizontal;
                        break;
                }

                group1HeaderLeft = this.Padding.Left;
                group1EditLeft = columnWidth - editWidth;
                group1BarLeft = group1HeaderLeft + barHorizontalOffset + innerMargin;

                if (this.Orientation == Orientation.Horizontal)
                {
                    group2HeaderLeft = this.Padding.Left + columnWidth + innerMargin;
                    group2EditLeft = this.ClientSize.Width - (this.Padding.Right + editWidth);
                    group2BarLeft = group2HeaderLeft + barHorizontalOffset + innerMargin;
                }
                else
                {
                    group2HeaderLeft = group1HeaderLeft;
                    group2EditLeft = group1EditLeft;
                    group2BarLeft = group1BarLeft;
                }

                barWidth = group1EditLeft - (group1BarLeft + innerMargin);

                this.SetBarStates(barWidth >= _minimumBarWidth);

                /*
                   // RGB header
                   if (_showColourSpaceLabels)
                   {
                       klblRGB.SetBounds(group1HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                       top += rowHeight + innerMargin;
                   }

                   // R row
                   klblRed.SetBounds(group1HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                   rColourBar.SetBounds(group1BarLeft, top + colourBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                   knudRed.SetBounds(group1EditLeft + editOffset, top, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                   top += rowHeight + innerMargin;

                   // G row
                   klblGreen.SetBounds(group1HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                   gColourBar.SetBounds(group1BarLeft, top + colourBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                   knudGreen.SetBounds(group1EditLeft + editOffset, top, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                   top += rowHeight + innerMargin;

                   // B row
                   klblBlue.SetBounds(group1HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                   bColourBar.SetBounds(group1BarLeft, top + colourBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                   knudBlue.SetBounds(group1EditLeft + editOffset, top, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                   top += rowHeight + innerMargin;
                   */

                // Hex row
                klblHex.SetBounds(group1HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                kcmbHexadecimalValue.SetBounds(klblHex.Right + innerMargin, top + colourBarOffset, barWidth + editOffset + editWidth - (klblHex.Right - group1BarLeft), 0, BoundsSpecified.Location | BoundsSpecified.Width);
                top += rowHeight + innerMargin;

                // reset top
                if (this.Orientation == Orientation.Horizontal)
                {
                    top = this.Padding.Top;
                }

                /*
                // HSL header
                if (_showColourSpaceLabels)
                {
                    klblHSL.SetBounds(group2HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                    top += rowHeight + innerMargin;
                }

                // H row
                klblHue.SetBounds(group2HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                hColourBar.SetBounds(group2BarLeft, top + colourBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                knudHue.SetBounds(group2EditLeft, top + editOffset, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                top += rowHeight + innerMargin;

                // S row
                klblSaturation.SetBounds(group2HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                sColourBar.SetBounds(group2BarLeft, top + colourBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                knudSaturation.SetBounds(group2EditLeft, top + editOffset, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                top += rowHeight + innerMargin;

                // L row
                klblLuminosity.SetBounds(group2HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                lColourBar.SetBounds(group2BarLeft, top + colourBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                knudLuminosity.SetBounds(group2EditLeft, top + editOffset, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                top += rowHeight + innerMargin;

                // A row
                klblAlpha.SetBounds(group2HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                aColourBar.SetBounds(group2BarLeft, top + colourBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                knudAlpha.SetBounds(group2EditLeft, top + editOffset, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                */
            }
            // ReSharper disable EmptyGeneralCatchClause
            catch
            // ReSharper restore EmptyGeneralCatchClause
            {
                // ignore errors
            }
        }

        /// <summary>
        /// Updates the editing field values.
        /// </summary>
        /// <param name="userAction">if set to <c>true</c> the update is due to user interaction.</param>
        protected virtual void UpdateFields(bool userAction)
        {
            if (!this.LockUpdates)
            {
                try
                {
                    this.LockUpdates = true;

                    // RGB
                    if (!(userAction && knudRed.Focused))
                    {
                        knudRed.Value = this.Colour.R;
                    }
                    if (!(userAction && knudGreen.Focused))
                    {
                        knudGreen.Value = this.Colour.G;
                    }
                    if (!(userAction && knudBlue.Focused))
                    {
                        knudBlue.Value = this.Colour.B;
                    }
                    rColourBar.Value = this.Colour.R;
                    rColourBar.Colour = this.Colour;
                    gColourBar.Value = this.Colour.G;
                    gColourBar.Colour = this.Colour;
                    bColourBar.Value = this.Colour.B;
                    bColourBar.Colour = this.Colour;

                    // HTML
                    if (!(userAction && kcmbHexadecimalValue.Focused))
                    {
                        kcmbHexadecimalValue.Text = this.Colour.IsNamedColor ? this.Colour.Name : string.Format("{0:X2}{1:X2}{2:X2}", this.Colour.R, this.Colour.G, this.Colour.B);
                    }

                    // HSL
                    if (!(userAction && knudHue.Focused))
                    {
                        knudHue.Value = (int)this.HslColour.H;
                    }
                    if (!(userAction && knudSaturation.Focused))
                    {
                        knudSaturation.Value = (int)(this.HslColour.S * 100);
                    }
                    if (!(userAction && knudLuminosity.Focused))
                    {
                        knudLuminosity.Value = (int)(this.HslColour.L * 100);
                    }
                    hColourBar.Value = (int)this.HslColour.H;
                    sColourBar.Colour = this.Colour;
                    sColourBar.Value = (int)(this.HslColour.S * 100);
                    lColourBar.Colour = this.Colour;
                    lColourBar.Value = (int)(this.HslColour.L * 100);

                    // Alpha
                    if (!(userAction && knudAlpha.Focused))
                    {
                        knudAlpha.Value = this.Colour.A;
                    }
                    aColourBar.Colour = this.Colour;
                    aColourBar.Value = this.Colour.A;
                }
                finally
                {
                    this.LockUpdates = false;
                }
            }
        }
        #endregion

        #region Overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
        #endregion
    }
}