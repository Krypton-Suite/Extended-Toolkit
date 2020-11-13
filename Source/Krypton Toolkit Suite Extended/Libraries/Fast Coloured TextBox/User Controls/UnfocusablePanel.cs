﻿using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    [ToolboxItem(false)]
    public class UnfocusablePanel : UserControl
    {
        public Color BackColour2 { get; set; }
        public Color BorderColour { get; set; }
        public new string Text { get; set; }
        public StringAlignment TextAlignment { get; set; }

        public UnfocusablePanel()
        {
            SetStyle(ControlStyles.Selectable, false);
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (var brush = new LinearGradientBrush(ClientRectangle, BackColour2, BackColor, 90))
                e.Graphics.FillRectangle(brush, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
            using (var pen = new Pen(BorderColour))
                e.Graphics.DrawRectangle(pen, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);

            if (!string.IsNullOrEmpty(Text))
            {
                StringFormat sf = new StringFormat();
                sf.Alignment = TextAlignment;
                sf.LineAlignment = StringAlignment.Center;
                using (var brush = new SolidBrush(ForeColor))
                    e.Graphics.DrawString(Text, Font, brush, new RectangleF(1, 1, ClientSize.Width - 2, ClientSize.Height - 2), sf);
            }
        }
    }
}