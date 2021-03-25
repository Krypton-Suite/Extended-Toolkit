﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */

// Original license

/**
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
* KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
* IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
* PURPOSE.
*
* License: GNU Lesser General Public License (LGPLv3)
*
* Email: pavel_torgashov@ukr.net.
*
* Copyright (C) Pavel Torgashov, 2011-2016.
*/
#endregion

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    public partial class Ruler : UserControl
    {
        #region Design Code
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }

        #endregion
        #endregion

        #region Variables
        private FastColouredTextBox target;

        //Palette State
        private KryptonManager _manager = new KryptonManager();
        private PaletteBackInheritRedirect _paletteBack;
        private PaletteBorderInheritRedirect _paletteBorder;
        private PaletteContentInheritRedirect _paletteContent;

        private IPalette _palette;
        private PaletteRedirect _paletteRedirect;
        #endregion

        public EventHandler TargetChanged;

        [DefaultValue(typeof(Color), "ControlLight")]
        public Color BackColour2 { get; set; }

        [DefaultValue(typeof(Color), "DarkGray")]
        public Color TickColour { get; set; }

        [DefaultValue(typeof(Color), "Black")]
        public Color CaretTickColour { get; set; }

        [Description("Target FastColouredTextBox")]
        public FastColouredTextBox Target
        {
            get { return target; }
            set
            {
                if (target != null)
                    UnSubscribe(target);
                target = value;
                Subscribe(target);
                OnTargetChanged();
            }
        }

        public Ruler()
        {
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            MinimumSize = new Size(0, 24);
            MaximumSize = new Size(int.MaxValue / 2, 24);

            //BackColour2 = SystemColors.ControlLight;
            //TickColour = Color.DarkGray;
            //CaretTickColour = Color.Black;

            //Create redirection object to the base palette
            if (((_palette != null)))
            {
                _palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);
            }
            KryptonManager.GlobalPaletteChanged += new EventHandler(OnGlobalPaletteChanged);
            _palette = KryptonManager.CurrentGlobalPalette;
            _paletteRedirect = new PaletteRedirect(_palette);

            //Create accessor objects for the back, border and content
            _paletteBack = new PaletteBackInheritRedirect(_paletteRedirect);
            _paletteBorder = new PaletteBorderInheritRedirect(_paletteRedirect);
            _paletteContent = new PaletteContentInheritRedirect(_paletteRedirect);

            InitColours();
        }



        protected virtual void OnTargetChanged()
        {
            if (TargetChanged != null)
                TargetChanged(this, EventArgs.Empty);
        }

        protected virtual void UnSubscribe(FastColouredTextBox target)
        {
            target.Scroll -= new ScrollEventHandler(target_Scroll);
            target.SelectionChanged -= new EventHandler(target_SelectionChanged);
            target.VisibleRangeChanged -= new EventHandler(target_VisibleRangeChanged);
        }

        protected virtual void Subscribe(FastColouredTextBox target)
        {
            target.Scroll += new ScrollEventHandler(target_Scroll);
            target.SelectionChanged += new EventHandler(target_SelectionChanged);
            target.VisibleRangeChanged += new EventHandler(target_VisibleRangeChanged);
        }

        void target_VisibleRangeChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        void target_SelectionChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        protected virtual void target_Scroll(object sender, ScrollEventArgs e)
        {
            Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (target == null)
                return;

            Point car = PointToClient(target.PointToScreen(target.PlaceToPoint(target.Selection.Start)));

            Size fontSize = TextRenderer.MeasureText("W", Font);

            int column = 0;
            e.Graphics.FillRectangle(new LinearGradientBrush(new Rectangle(0, 0, Width, Height), BackColor, BackColour2, 270), new Rectangle(0, 0, Width, Height));

            float columnWidth = target.CharWidth;
            var sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Near;

            var zeroPoint = target.PositionToPoint(0);
            zeroPoint = PointToClient(target.PointToScreen(zeroPoint));

            using (var pen = new Pen(TickColour))
            using (var textBrush = new SolidBrush(ForeColor))
                for (float x = zeroPoint.X; x < Right; x += columnWidth, ++column)
                {
                    if (column % 10 == 0)
                        e.Graphics.DrawString(column.ToString(), Font, textBrush, x, 0f, sf);

                    e.Graphics.DrawLine(pen, (int)x, fontSize.Height + (column % 5 == 0 ? 1 : 3), (int)x, Height - 4);
                }

            using (var pen = new Pen(TickColour))
                e.Graphics.DrawLine(pen, new Point(car.X - 3, Height - 3), new Point(car.X + 3, Height - 3));

            using (var pen = new Pen(CaretTickColour))
            {
                e.Graphics.DrawLine(pen, new Point(car.X - 2, fontSize.Height + 3), new Point(car.X - 2, Height - 4));
                e.Graphics.DrawLine(pen, new Point(car.X, fontSize.Height + 1), new Point(car.X, Height - 4));
                e.Graphics.DrawLine(pen, new Point(car.X + 2, fontSize.Height + 3), new Point(car.X + 2, Height - 4));
            }
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
            BackColour2 = _palette.ColorTable.OverflowButtonGradientBegin;
            ForeColor = _palette.ColorTable.MenuItemText;
            TickColour = _palette.ColorTable.MenuStripGradientEnd;
            CaretTickColour = _palette.ColorTable.MenuStripText;
        }
        #endregion
    }
}