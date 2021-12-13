#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities
{
    public class ColourEditor : UserControl, IColourEditor
    {
        #region Designer Code
        private Panel pnlRGB;
        private Panel panel7;
        private Panel panel19;
        private Panel panel18;
        private Panel panel17;
        private Panel panel6;
        private Panel panel32;
        private KryptonNumericUpDown knudGreen;
        private Panel panel28;
        private KryptonNumericUpDown knudBlue;
        private Panel panel24;
        private KryptonNumericUpDown knudRed;
        private Panel panel5;
        private Panel panel31;
        private KryptonLabel klblGreen;
        private Panel panel27;
        private KryptonLabel klblBlue;
        private Panel panel23;
        private KryptonLabel klblRed;
        private Panel panel4;
        private KryptonLabel kryptonLabel1;
        private Panel pnlHSLUI;
        private Panel panel12;
        private Panel panel22;
        private Panel panel21;
        private Panel panel20;
        private Panel panel11;
        private Panel panel34;
        private KryptonNumericUpDown knudSaturation;
        private Panel panel30;
        private KryptonNumericUpDown knudLuminosity;
        private Panel panel25;
        private KryptonNumericUpDown knudHue;
        private Panel panel10;
        private Panel panel33;
        private KryptonLabel kryptonLabel8;
        private Panel panel29;
        private KryptonLabel kryptonLabel9;
        private Panel panel26;
        private KryptonLabel klblHue;
        private Panel pnlAlpha;
        private Panel panel1;
        private Panel panel14;
        private KryptonNumericUpDown knudAlpha;
        private Panel panel13;
        private KryptonLabel klblAlpha;
        private Panel panel8;
        private KryptonLabel kryptonLabel2;
        private Panel pnlHexadecimal;
        private Panel panel16;
        private KryptonComboBox kcmbHexadecimalValue;
        private Panel panel15;
        private RGBAColourSliderControl rColourBar;
        private RGBAColourSliderControl gColourBar;
        private RGBAColourSliderControl bColourBar;
        private HueColourSliderControl hColourBar;
        private SaturationColourSliderControl sColourBar;
        private LightnessColourSliderControl lColourBar;
        private RGBAColourSliderControl aColourBar;
        private KryptonLabel klblHex;

        private void InitializeComponent()
        {
            this.pnlRGB = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel19 = new System.Windows.Forms.Panel();
            this.gColourBar = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.RGBAColourSliderControl();
            this.panel18 = new System.Windows.Forms.Panel();
            this.bColourBar = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.RGBAColourSliderControl();
            this.panel17 = new System.Windows.Forms.Panel();
            this.rColourBar = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.RGBAColourSliderControl();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel32 = new System.Windows.Forms.Panel();
            this.knudGreen = new Krypton.Toolkit.KryptonNumericUpDown();
            this.panel28 = new System.Windows.Forms.Panel();
            this.knudBlue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.panel24 = new System.Windows.Forms.Panel();
            this.knudRed = new Krypton.Toolkit.KryptonNumericUpDown();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel31 = new System.Windows.Forms.Panel();
            this.klblGreen = new Krypton.Toolkit.KryptonLabel();
            this.panel27 = new System.Windows.Forms.Panel();
            this.klblBlue = new Krypton.Toolkit.KryptonLabel();
            this.panel23 = new System.Windows.Forms.Panel();
            this.klblRed = new Krypton.Toolkit.KryptonLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.pnlHSLUI = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel22 = new System.Windows.Forms.Panel();
            this.sColourBar = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.SaturationColourSliderControl();
            this.panel21 = new System.Windows.Forms.Panel();
            this.lColourBar = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.LightnessColourSliderControl();
            this.panel20 = new System.Windows.Forms.Panel();
            this.hColourBar = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.HueColourSliderControl();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel34 = new System.Windows.Forms.Panel();
            this.knudSaturation = new Krypton.Toolkit.KryptonNumericUpDown();
            this.panel30 = new System.Windows.Forms.Panel();
            this.knudLuminosity = new Krypton.Toolkit.KryptonNumericUpDown();
            this.panel25 = new System.Windows.Forms.Panel();
            this.knudHue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel33 = new System.Windows.Forms.Panel();
            this.kryptonLabel8 = new Krypton.Toolkit.KryptonLabel();
            this.panel29 = new System.Windows.Forms.Panel();
            this.kryptonLabel9 = new Krypton.Toolkit.KryptonLabel();
            this.panel26 = new System.Windows.Forms.Panel();
            this.klblHue = new Krypton.Toolkit.KryptonLabel();
            this.pnlAlpha = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.aColourBar = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.RGBAColourSliderControl();
            this.panel14 = new System.Windows.Forms.Panel();
            this.knudAlpha = new Krypton.Toolkit.KryptonNumericUpDown();
            this.panel13 = new System.Windows.Forms.Panel();
            this.klblAlpha = new Krypton.Toolkit.KryptonLabel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.pnlHexadecimal = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.kcmbHexadecimalValue = new Krypton.Toolkit.KryptonComboBox();
            this.panel15 = new System.Windows.Forms.Panel();
            this.klblHex = new Krypton.Toolkit.KryptonLabel();
            this.pnlRGB.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel19.SuspendLayout();
            this.panel18.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel32.SuspendLayout();
            this.panel28.SuspendLayout();
            this.panel24.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel31.SuspendLayout();
            this.panel27.SuspendLayout();
            this.panel23.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlHSLUI.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel22.SuspendLayout();
            this.panel21.SuspendLayout();
            this.panel20.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel34.SuspendLayout();
            this.panel30.SuspendLayout();
            this.panel25.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel33.SuspendLayout();
            this.panel29.SuspendLayout();
            this.panel26.SuspendLayout();
            this.pnlAlpha.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel8.SuspendLayout();
            this.pnlHexadecimal.SuspendLayout();
            this.panel16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbHexadecimalValue)).BeginInit();
            this.panel15.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRGB
            // 
            this.pnlRGB.BackColor = System.Drawing.Color.Transparent;
            this.pnlRGB.Controls.Add(this.panel7);
            this.pnlRGB.Controls.Add(this.panel6);
            this.pnlRGB.Controls.Add(this.panel5);
            this.pnlRGB.Controls.Add(this.panel4);
            this.pnlRGB.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRGB.Location = new System.Drawing.Point(0, 0);
            this.pnlRGB.Name = "pnlRGB";
            this.pnlRGB.Size = new System.Drawing.Size(246, 93);
            this.pnlRGB.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Transparent;
            this.panel7.Controls.Add(this.panel19);
            this.panel7.Controls.Add(this.panel18);
            this.panel7.Controls.Add(this.panel17);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(35, 26);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(159, 67);
            this.panel7.TabIndex = 4;
            // 
            // panel19
            // 
            this.panel19.BackColor = System.Drawing.Color.Transparent;
            this.panel19.Controls.Add(this.gColourBar);
            this.panel19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel19.Location = new System.Drawing.Point(0, 22);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(159, 23);
            this.panel19.TabIndex = 5;
            // 
            // gColourBar
            // 
            this.gColourBar.BackColor = System.Drawing.Color.Transparent;
            this.gColourBar.Channel = Krypton.Toolkit.Suite.Extended.Drawing.Utilities.RGBAChannel.Green;
            this.gColourBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gColourBar.Location = new System.Drawing.Point(0, 0);
            this.gColourBar.Name = "gColourBar";
            this.gColourBar.Size = new System.Drawing.Size(159, 23);
            this.gColourBar.TabIndex = 1;
            // 
            // panel18
            // 
            this.panel18.BackColor = System.Drawing.Color.Transparent;
            this.panel18.Controls.Add(this.bColourBar);
            this.panel18.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel18.Location = new System.Drawing.Point(0, 45);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(159, 22);
            this.panel18.TabIndex = 4;
            // 
            // bColourBar
            // 
            this.bColourBar.BackColor = System.Drawing.Color.Transparent;
            this.bColourBar.Channel = Krypton.Toolkit.Suite.Extended.Drawing.Utilities.RGBAChannel.Blue;
            this.bColourBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bColourBar.Location = new System.Drawing.Point(0, 0);
            this.bColourBar.Name = "bColourBar";
            this.bColourBar.Size = new System.Drawing.Size(159, 22);
            this.bColourBar.TabIndex = 1;
            // 
            // panel17
            // 
            this.panel17.BackColor = System.Drawing.Color.Transparent;
            this.panel17.Controls.Add(this.rColourBar);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel17.Location = new System.Drawing.Point(0, 0);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(159, 22);
            this.panel17.TabIndex = 3;
            // 
            // rColourBar
            // 
            this.rColourBar.BackColor = System.Drawing.Color.Transparent;
            this.rColourBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rColourBar.Location = new System.Drawing.Point(0, 0);
            this.rColourBar.Name = "rColourBar";
            this.rColourBar.Size = new System.Drawing.Size(159, 22);
            this.rColourBar.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.Controls.Add(this.panel32);
            this.panel6.Controls.Add(this.panel28);
            this.panel6.Controls.Add(this.panel24);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(194, 26);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(52, 67);
            this.panel6.TabIndex = 3;
            // 
            // panel32
            // 
            this.panel32.BackColor = System.Drawing.Color.Transparent;
            this.panel32.Controls.Add(this.knudGreen);
            this.panel32.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel32.Location = new System.Drawing.Point(0, 22);
            this.panel32.Name = "panel32";
            this.panel32.Size = new System.Drawing.Size(52, 23);
            this.panel32.TabIndex = 6;
            // 
            // knudGreen
            // 
            this.knudGreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.knudGreen.Location = new System.Drawing.Point(0, 0);
            this.knudGreen.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudGreen.Name = "knudGreen";
            this.knudGreen.Size = new System.Drawing.Size(52, 23);
            this.knudGreen.TabIndex = 1;
            // 
            // panel28
            // 
            this.panel28.BackColor = System.Drawing.Color.Transparent;
            this.panel28.Controls.Add(this.knudBlue);
            this.panel28.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel28.Location = new System.Drawing.Point(0, 45);
            this.panel28.Name = "panel28";
            this.panel28.Size = new System.Drawing.Size(52, 22);
            this.panel28.TabIndex = 5;
            // 
            // knudBlue
            // 
            this.knudBlue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.knudBlue.Location = new System.Drawing.Point(0, 0);
            this.knudBlue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudBlue.Name = "knudBlue";
            this.knudBlue.Size = new System.Drawing.Size(52, 22);
            this.knudBlue.TabIndex = 1;
            // 
            // panel24
            // 
            this.panel24.BackColor = System.Drawing.Color.Transparent;
            this.panel24.Controls.Add(this.knudRed);
            this.panel24.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel24.Location = new System.Drawing.Point(0, 0);
            this.panel24.Name = "panel24";
            this.panel24.Size = new System.Drawing.Size(52, 22);
            this.panel24.TabIndex = 4;
            // 
            // knudRed
            // 
            this.knudRed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.knudRed.Location = new System.Drawing.Point(0, 0);
            this.knudRed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudRed.Name = "knudRed";
            this.knudRed.Size = new System.Drawing.Size(52, 22);
            this.knudRed.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.Controls.Add(this.panel31);
            this.panel5.Controls.Add(this.panel27);
            this.panel5.Controls.Add(this.panel23);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 26);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(35, 67);
            this.panel5.TabIndex = 2;
            // 
            // panel31
            // 
            this.panel31.BackColor = System.Drawing.Color.Transparent;
            this.panel31.Controls.Add(this.klblGreen);
            this.panel31.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel31.Location = new System.Drawing.Point(0, 22);
            this.panel31.Name = "panel31";
            this.panel31.Size = new System.Drawing.Size(35, 23);
            this.panel31.TabIndex = 6;
            // 
            // klblGreen
            // 
            this.klblGreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.klblGreen.Location = new System.Drawing.Point(0, 0);
            this.klblGreen.Name = "klblGreen";
            this.klblGreen.Size = new System.Drawing.Size(35, 23);
            this.klblGreen.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblGreen.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblGreen.StateCommon.ShortText.TextV = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblGreen.TabIndex = 1;
            this.klblGreen.Values.Text = "G:";
            // 
            // panel27
            // 
            this.panel27.BackColor = System.Drawing.Color.Transparent;
            this.panel27.Controls.Add(this.klblBlue);
            this.panel27.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel27.Location = new System.Drawing.Point(0, 45);
            this.panel27.Name = "panel27";
            this.panel27.Size = new System.Drawing.Size(35, 22);
            this.panel27.TabIndex = 5;
            // 
            // klblBlue
            // 
            this.klblBlue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.klblBlue.Location = new System.Drawing.Point(0, 0);
            this.klblBlue.Name = "klblBlue";
            this.klblBlue.Size = new System.Drawing.Size(35, 22);
            this.klblBlue.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblBlue.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblBlue.StateCommon.ShortText.TextV = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblBlue.TabIndex = 1;
            this.klblBlue.Values.Text = "B:";
            // 
            // panel23
            // 
            this.panel23.BackColor = System.Drawing.Color.Transparent;
            this.panel23.Controls.Add(this.klblRed);
            this.panel23.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel23.Location = new System.Drawing.Point(0, 0);
            this.panel23.Name = "panel23";
            this.panel23.Size = new System.Drawing.Size(35, 22);
            this.panel23.TabIndex = 4;
            // 
            // klblRed
            // 
            this.klblRed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.klblRed.Location = new System.Drawing.Point(0, 0);
            this.klblRed.Name = "klblRed";
            this.klblRed.Size = new System.Drawing.Size(35, 22);
            this.klblRed.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblRed.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblRed.StateCommon.ShortText.TextV = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblRed.TabIndex = 1;
            this.klblRed.Values.Text = "R:";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.kryptonLabel1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(246, 26);
            this.panel4.TabIndex = 1;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(246, 26);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.kryptonLabel1.StateCommon.ShortText.TextV = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "RGB";
            // 
            // pnlHSLUI
            // 
            this.pnlHSLUI.BackColor = System.Drawing.Color.Transparent;
            this.pnlHSLUI.Controls.Add(this.panel12);
            this.pnlHSLUI.Controls.Add(this.panel11);
            this.pnlHSLUI.Controls.Add(this.panel10);
            this.pnlHSLUI.Controls.Add(this.pnlAlpha);
            this.pnlHSLUI.Controls.Add(this.panel8);
            this.pnlHSLUI.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlHSLUI.Location = new System.Drawing.Point(0, 117);
            this.pnlHSLUI.Name = "pnlHSLUI";
            this.pnlHSLUI.Size = new System.Drawing.Size(246, 126);
            this.pnlHSLUI.TabIndex = 1;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.Transparent;
            this.panel12.Controls.Add(this.panel22);
            this.panel12.Controls.Add(this.panel21);
            this.panel12.Controls.Add(this.panel20);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(35, 26);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(159, 74);
            this.panel12.TabIndex = 6;
            // 
            // panel22
            // 
            this.panel22.BackColor = System.Drawing.Color.Transparent;
            this.panel22.Controls.Add(this.sColourBar);
            this.panel22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel22.Location = new System.Drawing.Point(0, 22);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(159, 30);
            this.panel22.TabIndex = 6;
            // 
            // sColourBar
            // 
            this.sColourBar.BackColor = System.Drawing.Color.Transparent;
            this.sColourBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sColourBar.Location = new System.Drawing.Point(0, 0);
            this.sColourBar.Name = "sColourBar";
            this.sColourBar.Size = new System.Drawing.Size(159, 30);
            this.sColourBar.TabIndex = 0;
            // 
            // panel21
            // 
            this.panel21.BackColor = System.Drawing.Color.Transparent;
            this.panel21.Controls.Add(this.lColourBar);
            this.panel21.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel21.Location = new System.Drawing.Point(0, 52);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(159, 22);
            this.panel21.TabIndex = 5;
            // 
            // lColourBar
            // 
            this.lColourBar.BackColor = System.Drawing.Color.Transparent;
            this.lColourBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lColourBar.Location = new System.Drawing.Point(0, 0);
            this.lColourBar.Name = "lColourBar";
            this.lColourBar.Size = new System.Drawing.Size(159, 22);
            this.lColourBar.TabIndex = 0;
            // 
            // panel20
            // 
            this.panel20.BackColor = System.Drawing.Color.Transparent;
            this.panel20.Controls.Add(this.hColourBar);
            this.panel20.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel20.Location = new System.Drawing.Point(0, 0);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(159, 22);
            this.panel20.TabIndex = 4;
            // 
            // hColourBar
            // 
            this.hColourBar.BackColor = System.Drawing.Color.Transparent;
            this.hColourBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hColourBar.Location = new System.Drawing.Point(0, 0);
            this.hColourBar.Name = "hColourBar";
            this.hColourBar.Size = new System.Drawing.Size(159, 22);
            this.hColourBar.TabIndex = 0;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.Transparent;
            this.panel11.Controls.Add(this.panel34);
            this.panel11.Controls.Add(this.panel30);
            this.panel11.Controls.Add(this.panel25);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel11.Location = new System.Drawing.Point(194, 26);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(52, 74);
            this.panel11.TabIndex = 5;
            // 
            // panel34
            // 
            this.panel34.BackColor = System.Drawing.Color.Transparent;
            this.panel34.Controls.Add(this.knudSaturation);
            this.panel34.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel34.Location = new System.Drawing.Point(0, 22);
            this.panel34.Name = "panel34";
            this.panel34.Size = new System.Drawing.Size(52, 30);
            this.panel34.TabIndex = 6;
            // 
            // knudSaturation
            // 
            this.knudSaturation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.knudSaturation.Location = new System.Drawing.Point(0, 0);
            this.knudSaturation.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudSaturation.Name = "knudSaturation";
            this.knudSaturation.Size = new System.Drawing.Size(52, 30);
            this.knudSaturation.TabIndex = 1;
            // 
            // panel30
            // 
            this.panel30.BackColor = System.Drawing.Color.Transparent;
            this.panel30.Controls.Add(this.knudLuminosity);
            this.panel30.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel30.Location = new System.Drawing.Point(0, 52);
            this.panel30.Name = "panel30";
            this.panel30.Size = new System.Drawing.Size(52, 22);
            this.panel30.TabIndex = 5;
            // 
            // knudLuminosity
            // 
            this.knudLuminosity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.knudLuminosity.Location = new System.Drawing.Point(0, 0);
            this.knudLuminosity.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudLuminosity.Name = "knudLuminosity";
            this.knudLuminosity.Size = new System.Drawing.Size(52, 22);
            this.knudLuminosity.TabIndex = 1;
            // 
            // panel25
            // 
            this.panel25.BackColor = System.Drawing.Color.Transparent;
            this.panel25.Controls.Add(this.knudHue);
            this.panel25.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel25.Location = new System.Drawing.Point(0, 0);
            this.panel25.Name = "panel25";
            this.panel25.Size = new System.Drawing.Size(52, 22);
            this.panel25.TabIndex = 4;
            // 
            // knudHue
            // 
            this.knudHue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.knudHue.Location = new System.Drawing.Point(0, 0);
            this.knudHue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudHue.Name = "knudHue";
            this.knudHue.Size = new System.Drawing.Size(52, 22);
            this.knudHue.TabIndex = 1;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Transparent;
            this.panel10.Controls.Add(this.panel33);
            this.panel10.Controls.Add(this.panel29);
            this.panel10.Controls.Add(this.panel26);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel10.Location = new System.Drawing.Point(0, 26);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(35, 74);
            this.panel10.TabIndex = 4;
            // 
            // panel33
            // 
            this.panel33.BackColor = System.Drawing.Color.Transparent;
            this.panel33.Controls.Add(this.kryptonLabel8);
            this.panel33.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel33.Location = new System.Drawing.Point(0, 26);
            this.panel33.Name = "panel33";
            this.panel33.Size = new System.Drawing.Size(35, 22);
            this.panel33.TabIndex = 6;
            // 
            // kryptonLabel8
            // 
            this.kryptonLabel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel8.Location = new System.Drawing.Point(0, 0);
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.Size = new System.Drawing.Size(35, 22);
            this.kryptonLabel8.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel8.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.kryptonLabel8.StateCommon.ShortText.TextV = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.kryptonLabel8.TabIndex = 1;
            this.kryptonLabel8.Values.Text = "S:";
            // 
            // panel29
            // 
            this.panel29.BackColor = System.Drawing.Color.Transparent;
            this.panel29.Controls.Add(this.kryptonLabel9);
            this.panel29.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel29.Location = new System.Drawing.Point(0, 48);
            this.panel29.Name = "panel29";
            this.panel29.Size = new System.Drawing.Size(35, 26);
            this.panel29.TabIndex = 5;
            // 
            // kryptonLabel9
            // 
            this.kryptonLabel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel9.Location = new System.Drawing.Point(0, 0);
            this.kryptonLabel9.Name = "kryptonLabel9";
            this.kryptonLabel9.Size = new System.Drawing.Size(35, 26);
            this.kryptonLabel9.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel9.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.kryptonLabel9.StateCommon.ShortText.TextV = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.kryptonLabel9.TabIndex = 1;
            this.kryptonLabel9.Values.Text = "L:";
            // 
            // panel26
            // 
            this.panel26.BackColor = System.Drawing.Color.Transparent;
            this.panel26.Controls.Add(this.klblHue);
            this.panel26.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel26.Location = new System.Drawing.Point(0, 0);
            this.panel26.Name = "panel26";
            this.panel26.Size = new System.Drawing.Size(35, 26);
            this.panel26.TabIndex = 4;
            // 
            // klblHue
            // 
            this.klblHue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.klblHue.Location = new System.Drawing.Point(0, 0);
            this.klblHue.Name = "klblHue";
            this.klblHue.Size = new System.Drawing.Size(35, 26);
            this.klblHue.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblHue.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblHue.StateCommon.ShortText.TextV = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblHue.TabIndex = 1;
            this.klblHue.Values.Text = "H:";
            // 
            // pnlAlpha
            // 
            this.pnlAlpha.BackColor = System.Drawing.Color.Transparent;
            this.pnlAlpha.Controls.Add(this.panel1);
            this.pnlAlpha.Controls.Add(this.panel14);
            this.pnlAlpha.Controls.Add(this.panel13);
            this.pnlAlpha.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAlpha.Location = new System.Drawing.Point(0, 100);
            this.pnlAlpha.Name = "pnlAlpha";
            this.pnlAlpha.Size = new System.Drawing.Size(246, 26);
            this.pnlAlpha.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.aColourBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(51, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(143, 26);
            this.panel1.TabIndex = 9;
            // 
            // aColourBar
            // 
            this.aColourBar.BackColor = System.Drawing.Color.Transparent;
            this.aColourBar.Channel = Krypton.Toolkit.Suite.Extended.Drawing.Utilities.RGBAChannel.Alpha;
            this.aColourBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aColourBar.Location = new System.Drawing.Point(0, 0);
            this.aColourBar.Name = "aColourBar";
            this.aColourBar.Size = new System.Drawing.Size(143, 26);
            this.aColourBar.TabIndex = 0;
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.Transparent;
            this.panel14.Controls.Add(this.knudAlpha);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel14.Location = new System.Drawing.Point(194, 0);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(52, 26);
            this.panel14.TabIndex = 8;
            // 
            // knudAlpha
            // 
            this.knudAlpha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.knudAlpha.Location = new System.Drawing.Point(0, 0);
            this.knudAlpha.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudAlpha.Name = "knudAlpha";
            this.knudAlpha.Size = new System.Drawing.Size(52, 26);
            this.knudAlpha.TabIndex = 2;
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.Transparent;
            this.panel13.Controls.Add(this.klblAlpha);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel13.Location = new System.Drawing.Point(0, 0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(51, 26);
            this.panel13.TabIndex = 3;
            // 
            // klblAlpha
            // 
            this.klblAlpha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.klblAlpha.Location = new System.Drawing.Point(0, 0);
            this.klblAlpha.Name = "klblAlpha";
            this.klblAlpha.Size = new System.Drawing.Size(51, 26);
            this.klblAlpha.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblAlpha.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblAlpha.StateCommon.ShortText.TextV = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblAlpha.TabIndex = 2;
            this.klblAlpha.Values.Text = "Alpha:";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Transparent;
            this.panel8.Controls.Add(this.kryptonLabel2);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(246, 26);
            this.panel8.TabIndex = 2;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(246, 26);
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.kryptonLabel2.StateCommon.ShortText.TextV = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.kryptonLabel2.TabIndex = 1;
            this.kryptonLabel2.Values.Text = "HSL";
            // 
            // pnlHexadecimal
            // 
            this.pnlHexadecimal.BackColor = System.Drawing.Color.Transparent;
            this.pnlHexadecimal.Controls.Add(this.panel16);
            this.pnlHexadecimal.Controls.Add(this.panel15);
            this.pnlHexadecimal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHexadecimal.Location = new System.Drawing.Point(0, 93);
            this.pnlHexadecimal.Name = "pnlHexadecimal";
            this.pnlHexadecimal.Size = new System.Drawing.Size(246, 24);
            this.pnlHexadecimal.TabIndex = 2;
            // 
            // panel16
            // 
            this.panel16.BackColor = System.Drawing.Color.Transparent;
            this.panel16.Controls.Add(this.kcmbHexadecimalValue);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel16.Location = new System.Drawing.Point(35, 0);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(211, 24);
            this.panel16.TabIndex = 8;
            // 
            // kcmbHexadecimalValue
            // 
            this.kcmbHexadecimalValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kcmbHexadecimalValue.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.kcmbHexadecimalValue.DropDownWidth = 211;
            this.kcmbHexadecimalValue.IntegralHeight = false;
            this.kcmbHexadecimalValue.Location = new System.Drawing.Point(0, 0);
            this.kcmbHexadecimalValue.Name = "kcmbHexadecimalValue";
            this.kcmbHexadecimalValue.Size = new System.Drawing.Size(211, 21);
            this.kcmbHexadecimalValue.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbHexadecimalValue.TabIndex = 0;
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.Transparent;
            this.panel15.Controls.Add(this.klblHex);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel15.Location = new System.Drawing.Point(0, 0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(35, 24);
            this.panel15.TabIndex = 4;
            // 
            // klblHex
            // 
            this.klblHex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.klblHex.Location = new System.Drawing.Point(0, 0);
            this.klblHex.Name = "klblHex";
            this.klblHex.Size = new System.Drawing.Size(35, 24);
            this.klblHex.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblHex.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblHex.StateCommon.ShortText.TextV = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblHex.TabIndex = 1;
            this.klblHex.Values.Text = "Hex:";
            // 
            // ColourEditor
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlHexadecimal);
            this.Controls.Add(this.pnlHSLUI);
            this.Controls.Add(this.pnlRGB);
            this.Name = "ColourEditor";
            this.Size = new System.Drawing.Size(246, 243);
            this.pnlRGB.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel19.ResumeLayout(false);
            this.panel18.ResumeLayout(false);
            this.panel17.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel32.ResumeLayout(false);
            this.panel28.ResumeLayout(false);
            this.panel24.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel31.ResumeLayout(false);
            this.panel31.PerformLayout();
            this.panel27.ResumeLayout(false);
            this.panel27.PerformLayout();
            this.panel23.ResumeLayout(false);
            this.panel23.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.pnlHSLUI.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel22.ResumeLayout(false);
            this.panel21.ResumeLayout(false);
            this.panel20.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel34.ResumeLayout(false);
            this.panel30.ResumeLayout(false);
            this.panel25.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel33.ResumeLayout(false);
            this.panel33.PerformLayout();
            this.panel29.ResumeLayout(false);
            this.panel29.PerformLayout();
            this.panel26.ResumeLayout(false);
            this.panel26.PerformLayout();
            this.pnlAlpha.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.pnlHexadecimal.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kcmbHexadecimalValue)).EndInit();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
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

        //[Category("Appearence"), DefaultValue(true)]
        //public bool ShowHSL { get => _showHSLUI; set { _showHSLUI = value; Invalidate(); } }

        //[Category("Appearence"), DefaultValue(true)]
        //public bool ShowHexadecimal { get => _showHexadecimalUI; set { _showHexadecimalUI = value; Invalidate(); } }

        /// <summary>
        /// Gets or sets a value indicating whether input changes should be processed.
        /// </summary>
        /// <value><c>true</c> if input changes should be processed; otherwise, <c>false</c>.</value>
        protected bool LockUpdates { get; set; }
        #endregion

        #region Constructor
        public ColourEditor()
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

            //if (ShowAlphaChannel && ShowHexadecimal && ShowHSL)
            //{
            //    height = pnlRGB.Height + pnlRed.Height + pnlBlue.Height + pnlHexadecimal.Height + pnlHSLUI.Height + pnlAlpha.Height;

            //    Height = height;
            //}
            //else if (ShowAlphaChannel && ShowHexadecimal)
            //{
            //    height = pnlRGB.Height + pnlRed.Height + pnlBlue.Height + pnlHexadecimal.Height + pnlAlpha.Height;

            //    Height = height;
            //}
            //else if (ShowAlphaChannel && ShowHSL)
            //{
            //    height = pnlRGB.Height + pnlRed.Height + pnlBlue.Height + pnlHSLUI.Height + pnlAlpha.Height;

            //    Height = height;
            //}
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

        /// <summary>Uses the RGB numeric boxes.</summary>
        /// <param name="useRGB">if set to <c>true</c> [use RGB].</param>
        private void UseRGBNumericBoxes(bool useRGB)
        {
            if (useRGB)
            {
                knudRed.StateCommon.Back.Color1 = Color.Red;

                knudRed.StateCommon.Content.Color1 = Color.White;

                knudGreen.StateCommon.Back.Color1 = Color.Green;

                knudGreen.StateCommon.Content.Color1 = Color.White;

                knudBlue.StateCommon.Back.Color1 = Color.Blue;

                knudBlue.StateCommon.Content.Color1 = Color.White;
            }
            else
            {
                knudRed.StateCommon.Back.Color1 = Color.Empty;

                knudRed.StateCommon.Content.Color1 = Color.Empty;

                knudGreen.StateCommon.Back.Color1 = Color.Empty;

                knudGreen.StateCommon.Content.Color1 = Color.Empty;

                knudBlue.StateCommon.Back.Color1 = Color.Empty;

                knudBlue.StateCommon.Content.Color1 = Color.Empty;
            }
        }
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
    }
}