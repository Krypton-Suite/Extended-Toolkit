using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Colour.Controls
{
    public class ColourEditor : UserControl, IColourEditor
    {
        private Panel pnlRGB;
        private Panel panel7;
        private Panel panel19;
        private Panel panel18;
        private Panel panel17;
        private Panel panel6;
        private Panel panel32;
        private KryptonNumericUpDown kryptonNumericUpDown2;
        private Panel panel28;
        private KryptonNumericUpDown kryptonNumericUpDown3;
        private Panel panel24;
        private KryptonNumericUpDown kryptonNumericUpDown1;
        private Panel panel5;
        private Panel panel31;
        private KryptonLabel kryptonLabel4;
        private Panel panel27;
        private KryptonLabel kryptonLabel5;
        private Panel panel23;
        private KryptonLabel kryptonLabel3;
        private Panel panel4;
        private KryptonLabel kryptonLabel1;
        private Panel pnlHSL;
        private Panel panel12;
        private Panel panel22;
        private Panel panel21;
        private Panel panel20;
        private Panel panel11;
        private Panel panel34;
        private KryptonNumericUpDown kryptonNumericUpDown5;
        private Panel panel30;
        private KryptonNumericUpDown kryptonNumericUpDown6;
        private Panel panel25;
        private KryptonNumericUpDown kryptonNumericUpDown4;
        private Panel panel10;
        private Panel panel33;
        private KryptonLabel kryptonLabel8;
        private Panel panel29;
        private KryptonLabel kryptonLabel9;
        private Panel panel26;
        private KryptonLabel kryptonLabel7;
        private Panel panel9;
        private Panel panel1;
        private Panel panel14;
        private KryptonNumericUpDown kryptonNumericUpDown7;
        private Panel panel13;
        private KryptonLabel kryptonLabel10;
        private Panel panel8;
        private KryptonLabel kryptonLabel2;
        private Panel panel3;
        private Panel panel16;
        private KryptonComboBox kryptonComboBox1;
        private Panel panel15;
        private KryptonLabel kryptonLabel6;

        public Color Colour { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event EventHandler ColourChanged;

        private void InitializeComponent()
        {
            this.pnlRGB = new System.Windows.Forms.Panel();
            this.pnlHSL = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.panel17 = new System.Windows.Forms.Panel();
            this.panel18 = new System.Windows.Forms.Panel();
            this.panel19 = new System.Windows.Forms.Panel();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.panel20 = new System.Windows.Forms.Panel();
            this.panel21 = new System.Windows.Forms.Panel();
            this.panel22 = new System.Windows.Forms.Panel();
            this.panel23 = new System.Windows.Forms.Panel();
            this.panel24 = new System.Windows.Forms.Panel();
            this.panel25 = new System.Windows.Forms.Panel();
            this.panel26 = new System.Windows.Forms.Panel();
            this.panel27 = new System.Windows.Forms.Panel();
            this.panel28 = new System.Windows.Forms.Panel();
            this.panel29 = new System.Windows.Forms.Panel();
            this.panel30 = new System.Windows.Forms.Panel();
            this.panel31 = new System.Windows.Forms.Panel();
            this.panel32 = new System.Windows.Forms.Panel();
            this.panel33 = new System.Windows.Forms.Panel();
            this.panel34 = new System.Windows.Forms.Panel();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel6 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel7 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel8 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel9 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel10 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonComboBox1 = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonNumericUpDown1 = new Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonNumericUpDown2 = new Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonNumericUpDown3 = new Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonNumericUpDown4 = new Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonNumericUpDown5 = new Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonNumericUpDown6 = new Krypton.Toolkit.KryptonNumericUpDown();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonNumericUpDown7 = new Krypton.Toolkit.KryptonNumericUpDown();
            this.pnlRGB.SuspendLayout();
            this.pnlHSL.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel23.SuspendLayout();
            this.panel24.SuspendLayout();
            this.panel25.SuspendLayout();
            this.panel26.SuspendLayout();
            this.panel27.SuspendLayout();
            this.panel28.SuspendLayout();
            this.panel29.SuspendLayout();
            this.panel30.SuspendLayout();
            this.panel31.SuspendLayout();
            this.panel32.SuspendLayout();
            this.panel33.SuspendLayout();
            this.panel34.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonComboBox1)).BeginInit();
            this.panel14.SuspendLayout();
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
            // pnlHSL
            // 
            this.pnlHSL.BackColor = System.Drawing.Color.Transparent;
            this.pnlHSL.Controls.Add(this.panel12);
            this.pnlHSL.Controls.Add(this.panel11);
            this.pnlHSL.Controls.Add(this.panel10);
            this.pnlHSL.Controls.Add(this.panel9);
            this.pnlHSL.Controls.Add(this.panel8);
            this.pnlHSL.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlHSL.Location = new System.Drawing.Point(0, 117);
            this.pnlHSL.Name = "pnlHSL";
            this.pnlHSL.Size = new System.Drawing.Size(246, 126);
            this.pnlHSL.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.panel16);
            this.panel3.Controls.Add(this.panel15);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 93);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(246, 24);
            this.panel3.TabIndex = 2;
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
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Transparent;
            this.panel9.Controls.Add(this.panel1);
            this.panel9.Controls.Add(this.panel14);
            this.panel9.Controls.Add(this.panel13);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel9.Location = new System.Drawing.Point(0, 100);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(246, 26);
            this.panel9.TabIndex = 3;
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
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.Transparent;
            this.panel13.Controls.Add(this.kryptonLabel10);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel13.Location = new System.Drawing.Point(0, 0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(51, 26);
            this.panel13.TabIndex = 3;
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.Transparent;
            this.panel15.Controls.Add(this.kryptonLabel6);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel15.Location = new System.Drawing.Point(0, 0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(35, 24);
            this.panel15.TabIndex = 4;
            // 
            // panel16
            // 
            this.panel16.BackColor = System.Drawing.Color.Transparent;
            this.panel16.Controls.Add(this.kryptonComboBox1);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel16.Location = new System.Drawing.Point(35, 0);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(211, 24);
            this.panel16.TabIndex = 8;
            // 
            // panel17
            // 
            this.panel17.BackColor = System.Drawing.Color.Transparent;
            this.panel17.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel17.Location = new System.Drawing.Point(0, 0);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(159, 22);
            this.panel17.TabIndex = 3;
            // 
            // panel18
            // 
            this.panel18.BackColor = System.Drawing.Color.Transparent;
            this.panel18.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel18.Location = new System.Drawing.Point(0, 45);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(159, 22);
            this.panel18.TabIndex = 4;
            // 
            // panel19
            // 
            this.panel19.BackColor = System.Drawing.Color.Transparent;
            this.panel19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel19.Location = new System.Drawing.Point(0, 22);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(159, 23);
            this.panel19.TabIndex = 5;
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
            // panel20
            // 
            this.panel20.BackColor = System.Drawing.Color.Transparent;
            this.panel20.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel20.Location = new System.Drawing.Point(0, 0);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(159, 22);
            this.panel20.TabIndex = 4;
            // 
            // panel21
            // 
            this.panel21.BackColor = System.Drawing.Color.Transparent;
            this.panel21.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel21.Location = new System.Drawing.Point(0, 52);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(159, 22);
            this.panel21.TabIndex = 5;
            // 
            // panel22
            // 
            this.panel22.BackColor = System.Drawing.Color.Transparent;
            this.panel22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel22.Location = new System.Drawing.Point(0, 22);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(159, 30);
            this.panel22.TabIndex = 6;
            // 
            // panel23
            // 
            this.panel23.BackColor = System.Drawing.Color.Transparent;
            this.panel23.Controls.Add(this.kryptonLabel3);
            this.panel23.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel23.Location = new System.Drawing.Point(0, 0);
            this.panel23.Name = "panel23";
            this.panel23.Size = new System.Drawing.Size(35, 22);
            this.panel23.TabIndex = 4;
            // 
            // panel24
            // 
            this.panel24.BackColor = System.Drawing.Color.Transparent;
            this.panel24.Controls.Add(this.kryptonNumericUpDown1);
            this.panel24.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel24.Location = new System.Drawing.Point(0, 0);
            this.panel24.Name = "panel24";
            this.panel24.Size = new System.Drawing.Size(52, 22);
            this.panel24.TabIndex = 4;
            // 
            // panel25
            // 
            this.panel25.BackColor = System.Drawing.Color.Transparent;
            this.panel25.Controls.Add(this.kryptonNumericUpDown4);
            this.panel25.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel25.Location = new System.Drawing.Point(0, 0);
            this.panel25.Name = "panel25";
            this.panel25.Size = new System.Drawing.Size(52, 22);
            this.panel25.TabIndex = 4;
            // 
            // panel26
            // 
            this.panel26.BackColor = System.Drawing.Color.Transparent;
            this.panel26.Controls.Add(this.kryptonLabel7);
            this.panel26.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel26.Location = new System.Drawing.Point(0, 0);
            this.panel26.Name = "panel26";
            this.panel26.Size = new System.Drawing.Size(35, 26);
            this.panel26.TabIndex = 4;
            // 
            // panel27
            // 
            this.panel27.BackColor = System.Drawing.Color.Transparent;
            this.panel27.Controls.Add(this.kryptonLabel5);
            this.panel27.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel27.Location = new System.Drawing.Point(0, 45);
            this.panel27.Name = "panel27";
            this.panel27.Size = new System.Drawing.Size(35, 22);
            this.panel27.TabIndex = 5;
            // 
            // panel28
            // 
            this.panel28.BackColor = System.Drawing.Color.Transparent;
            this.panel28.Controls.Add(this.kryptonNumericUpDown3);
            this.panel28.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel28.Location = new System.Drawing.Point(0, 45);
            this.panel28.Name = "panel28";
            this.panel28.Size = new System.Drawing.Size(52, 22);
            this.panel28.TabIndex = 5;
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
            // panel30
            // 
            this.panel30.BackColor = System.Drawing.Color.Transparent;
            this.panel30.Controls.Add(this.kryptonNumericUpDown6);
            this.panel30.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel30.Location = new System.Drawing.Point(0, 52);
            this.panel30.Name = "panel30";
            this.panel30.Size = new System.Drawing.Size(52, 22);
            this.panel30.TabIndex = 5;
            // 
            // panel31
            // 
            this.panel31.BackColor = System.Drawing.Color.Transparent;
            this.panel31.Controls.Add(this.kryptonLabel4);
            this.panel31.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel31.Location = new System.Drawing.Point(0, 22);
            this.panel31.Name = "panel31";
            this.panel31.Size = new System.Drawing.Size(35, 23);
            this.panel31.TabIndex = 6;
            // 
            // panel32
            // 
            this.panel32.BackColor = System.Drawing.Color.Transparent;
            this.panel32.Controls.Add(this.kryptonNumericUpDown2);
            this.panel32.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel32.Location = new System.Drawing.Point(0, 22);
            this.panel32.Name = "panel32";
            this.panel32.Size = new System.Drawing.Size(52, 23);
            this.panel32.TabIndex = 6;
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
            // panel34
            // 
            this.panel34.BackColor = System.Drawing.Color.Transparent;
            this.panel34.Controls.Add(this.kryptonNumericUpDown5);
            this.panel34.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel34.Location = new System.Drawing.Point(0, 22);
            this.panel34.Name = "panel34";
            this.panel34.Size = new System.Drawing.Size(52, 30);
            this.panel34.TabIndex = 6;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel3.Location = new System.Drawing.Point(0, 0);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(35, 22);
            this.kryptonLabel3.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.kryptonLabel3.StateCommon.ShortText.TextV = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.kryptonLabel3.TabIndex = 1;
            this.kryptonLabel3.Values.Text = "R:";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel4.Location = new System.Drawing.Point(0, 0);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(35, 23);
            this.kryptonLabel4.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel4.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.kryptonLabel4.StateCommon.ShortText.TextV = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.kryptonLabel4.TabIndex = 1;
            this.kryptonLabel4.Values.Text = "G:";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel5.Location = new System.Drawing.Point(0, 0);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(35, 22);
            this.kryptonLabel5.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel5.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.kryptonLabel5.StateCommon.ShortText.TextV = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.kryptonLabel5.TabIndex = 1;
            this.kryptonLabel5.Values.Text = "B:";
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel6.Location = new System.Drawing.Point(0, 0);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(35, 24);
            this.kryptonLabel6.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel6.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.kryptonLabel6.StateCommon.ShortText.TextV = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.kryptonLabel6.TabIndex = 1;
            this.kryptonLabel6.Values.Text = "Hex:";
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel7.Location = new System.Drawing.Point(0, 0);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(35, 26);
            this.kryptonLabel7.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel7.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.kryptonLabel7.StateCommon.ShortText.TextV = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.kryptonLabel7.TabIndex = 1;
            this.kryptonLabel7.Values.Text = "H:";
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
            // kryptonLabel10
            // 
            this.kryptonLabel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel10.Location = new System.Drawing.Point(0, 0);
            this.kryptonLabel10.Name = "kryptonLabel10";
            this.kryptonLabel10.Size = new System.Drawing.Size(51, 26);
            this.kryptonLabel10.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel10.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.kryptonLabel10.StateCommon.ShortText.TextV = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.kryptonLabel10.TabIndex = 2;
            this.kryptonLabel10.Values.Text = "Alpha:";
            // 
            // kryptonComboBox1
            // 
            this.kryptonComboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.kryptonComboBox1.DropDownWidth = 211;
            this.kryptonComboBox1.IntegralHeight = false;
            this.kryptonComboBox1.Location = new System.Drawing.Point(0, 0);
            this.kryptonComboBox1.Name = "kryptonComboBox1";
            this.kryptonComboBox1.Size = new System.Drawing.Size(211, 21);
            this.kryptonComboBox1.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kryptonComboBox1.TabIndex = 0;
            this.kryptonComboBox1.Text = "kryptonComboBox1";
            // 
            // kryptonNumericUpDown1
            // 
            this.kryptonNumericUpDown1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonNumericUpDown1.Location = new System.Drawing.Point(0, 0);
            this.kryptonNumericUpDown1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.kryptonNumericUpDown1.Name = "kryptonNumericUpDown1";
            this.kryptonNumericUpDown1.Size = new System.Drawing.Size(52, 22);
            this.kryptonNumericUpDown1.TabIndex = 0;
            // 
            // kryptonNumericUpDown2
            // 
            this.kryptonNumericUpDown2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonNumericUpDown2.Location = new System.Drawing.Point(0, 0);
            this.kryptonNumericUpDown2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.kryptonNumericUpDown2.Name = "kryptonNumericUpDown2";
            this.kryptonNumericUpDown2.Size = new System.Drawing.Size(52, 22);
            this.kryptonNumericUpDown2.TabIndex = 1;
            // 
            // kryptonNumericUpDown3
            // 
            this.kryptonNumericUpDown3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonNumericUpDown3.Location = new System.Drawing.Point(0, 0);
            this.kryptonNumericUpDown3.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.kryptonNumericUpDown3.Name = "kryptonNumericUpDown3";
            this.kryptonNumericUpDown3.Size = new System.Drawing.Size(52, 22);
            this.kryptonNumericUpDown3.TabIndex = 1;
            // 
            // kryptonNumericUpDown4
            // 
            this.kryptonNumericUpDown4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonNumericUpDown4.Location = new System.Drawing.Point(0, 0);
            this.kryptonNumericUpDown4.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.kryptonNumericUpDown4.Name = "kryptonNumericUpDown4";
            this.kryptonNumericUpDown4.Size = new System.Drawing.Size(52, 22);
            this.kryptonNumericUpDown4.TabIndex = 1;
            // 
            // kryptonNumericUpDown5
            // 
            this.kryptonNumericUpDown5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonNumericUpDown5.Location = new System.Drawing.Point(0, 0);
            this.kryptonNumericUpDown5.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.kryptonNumericUpDown5.Name = "kryptonNumericUpDown5";
            this.kryptonNumericUpDown5.Size = new System.Drawing.Size(52, 22);
            this.kryptonNumericUpDown5.TabIndex = 1;
            // 
            // kryptonNumericUpDown6
            // 
            this.kryptonNumericUpDown6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonNumericUpDown6.Location = new System.Drawing.Point(0, 0);
            this.kryptonNumericUpDown6.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.kryptonNumericUpDown6.Name = "kryptonNumericUpDown6";
            this.kryptonNumericUpDown6.Size = new System.Drawing.Size(52, 22);
            this.kryptonNumericUpDown6.TabIndex = 1;
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.Transparent;
            this.panel14.Controls.Add(this.kryptonNumericUpDown7);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel14.Location = new System.Drawing.Point(194, 0);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(52, 26);
            this.panel14.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(51, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(143, 26);
            this.panel1.TabIndex = 9;
            // 
            // kryptonNumericUpDown7
            // 
            this.kryptonNumericUpDown7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonNumericUpDown7.Location = new System.Drawing.Point(0, 0);
            this.kryptonNumericUpDown7.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.kryptonNumericUpDown7.Name = "kryptonNumericUpDown7";
            this.kryptonNumericUpDown7.Size = new System.Drawing.Size(52, 22);
            this.kryptonNumericUpDown7.TabIndex = 2;
            // 
            // ColourEditor
            // 
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pnlHSL);
            this.Controls.Add(this.pnlRGB);
            this.Name = "ColourEditor";
            this.Size = new System.Drawing.Size(246, 243);
            this.pnlRGB.ResumeLayout(false);
            this.pnlHSL.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.panel16.ResumeLayout(false);
            this.panel23.ResumeLayout(false);
            this.panel23.PerformLayout();
            this.panel24.ResumeLayout(false);
            this.panel25.ResumeLayout(false);
            this.panel26.ResumeLayout(false);
            this.panel26.PerformLayout();
            this.panel27.ResumeLayout(false);
            this.panel27.PerformLayout();
            this.panel28.ResumeLayout(false);
            this.panel29.ResumeLayout(false);
            this.panel29.PerformLayout();
            this.panel30.ResumeLayout(false);
            this.panel31.ResumeLayout(false);
            this.panel31.PerformLayout();
            this.panel32.ResumeLayout(false);
            this.panel33.ResumeLayout(false);
            this.panel33.PerformLayout();
            this.panel34.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonComboBox1)).EndInit();
            this.panel14.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}