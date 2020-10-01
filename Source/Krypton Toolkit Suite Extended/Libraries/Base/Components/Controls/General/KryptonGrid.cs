using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    [ToolboxBitmap(typeof(DataGridView))]
    public class KryptonGrid : DataGridView
    {

        private IPalette _palette;
        private PaletteRedirect _paletteRedirect;
        private PaletteBackInheritRedirect _paletteBack;
        private PaletteBorderInheritRedirect _paletteBorder;
        private PaletteContentInheritRedirect _paletteContent;
        private IDisposable _mementoBack;
        public KryptonGrid()
        {
            SetStyle(
      ControlStyles.AllPaintingInWmPaint |
      ControlStyles.OptimizedDoubleBuffer |
      ControlStyles.ResizeRedraw, true);

            _palette = KryptonManager.CurrentGlobalPalette;

            if (_palette != null)
                _palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);


            KryptonManager.GlobalPaletteChanged += new EventHandler(OnGlobalPaletteChanged);

            _paletteRedirect = new PaletteRedirect(_palette);
            _paletteBack = new PaletteBackInheritRedirect(_paletteRedirect);
            _paletteBorder = new PaletteBorderInheritRedirect(_paletteRedirect);
            _paletteContent = new PaletteContentInheritRedirect(_paletteRedirect);

            this.RowTemplate.DefaultCellStyle.SelectionBackColor =
            Color.Transparent;
            this.DefaultCellStyle.SelectionBackColor = Color.Transparent;
            this.DefaultCellStyle.SelectionForeColor = Color.Navy;
            this.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Navy;
            this.AlternatingRowsDefaultCellStyle.BackColor = _palette.ColorTable.ToolStripGradientBegin;
            BackgroundColor = Color.FromArgb(179, 196, 216);
        }

        private void OnGlobalPaletteChanged(object sender, EventArgs e)
        {

            if (_palette != null)
                _palette.PalettePaint -= new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);


            _palette = KryptonManager.CurrentGlobalPalette;
            _paletteRedirect.Target = _palette;


            if (_palette != null)
            {
                _palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);
                this.AlternatingRowsDefaultCellStyle.BackColor = _palette.ColorTable.ToolStripGradientBegin;
            }

            Invalidate();
        }

        private void OnPalettePaint(object sender, PaletteLayoutEventArgs e)
        {

            Invalidate();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {


                if (_mementoBack != null)
                {
                    _mementoBack.Dispose();
                    _mementoBack = null;
                }


                if (_palette != null)
                {
                    _palette.PalettePaint -= new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);
                    _palette = null;
                }


                KryptonManager.GlobalPaletteChanged -= new EventHandler(OnGlobalPaletteChanged);
            }

            base.Dispose(disposing);
        }


        protected override void OnRowPrePaint(DataGridViewRowPrePaintEventArgs e)
        {
            e.PaintParts &= ~DataGridViewPaintParts.Focus;
            Rectangle rowBounds = new Rectangle(
               this.RowHeadersWidth, e.RowBounds.Top,
               this.Columns.GetColumnsWidth(
                   DataGridViewElementStates.Visible) -
               this.HorizontalScrollingOffset + 1,
               e.RowBounds.Height);

            if ((e.State & DataGridViewElementStates.Selected) == DataGridViewElementStates.Selected)
            {

                using (GraphicsPath path = new GraphicsPath())
                {
                    IRenderer renderer = _palette.GetRenderer();
                    path.AddRectangle(rowBounds);

                    using (RenderContext context = new RenderContext(this, e.Graphics, rowBounds, renderer))
                    {


                        _paletteBack.Style = PaletteBackStyle.ButtonNavigatorStack;
                        _paletteBorder.Style = PaletteBorderStyle.ButtonNavigatorStack;

                        _mementoBack = renderer.RenderStandardBack.DrawBack(context, rowBounds, path, _paletteBack, VisualOrientation.Top, PaletteState.Tracking, _mementoBack);
                        renderer.RenderStandardBorder.DrawBorder(context,
                                                       rowBounds,
                                                       _paletteBorder,
                                                       VisualOrientation.Top,
                                                       PaletteState.Normal);
                    }


                }
            }

        }
        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex != -1)
            {

                using (GraphicsPath path = new GraphicsPath())
                {
                    IRenderer renderer = _palette.GetRenderer();
                    Rectangle rect = new Rectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height);
                    Rectangle rect2 = new Rectangle(e.CellBounds.X - 1, e.CellBounds.Y - 1, e.CellBounds.Width + 2, e.CellBounds.Height + 1);
                    path.AddRectangle(rect);
                    Color gradStartColour = _palette.ColorTable.ToolStripGradientBegin;
                    Color gradMiddleColour = _palette.ColorTable.MenuStripGradientEnd;

                    using (RenderContext context = new RenderContext(this, e.Graphics, rect, renderer))
                    {
                        if (e.State == DataGridViewElementStates.Selected)
                        {
                            _paletteBack.Style = PaletteBackStyle.HeaderPrimary;
                            _paletteBorder.Style = PaletteBorderStyle.HeaderPrimary;
                            _paletteContent.Style = PaletteContentStyle.HeaderPrimary;
                        }
                        else
                        {
                            _paletteBack.Style = PaletteBackStyle.HeaderPrimary;
                            _paletteBorder.Style = PaletteBorderStyle.HeaderPrimary;
                            _paletteContent.Style = PaletteContentStyle.HeaderPrimary;
                        }
                        //_mementoBack = renderer.RenderStandardBack.DrawBack(context, e.CellBounds, path, _paletteBack, VisualOrientation.Top, PaletteState.Normal, _mementoBack);

                        //Empty Area
                        e.Graphics.FillRectangle(new SolidBrush(Color.White), rect);

                        //Fill Gradient
                        using (LinearGradientBrush brush = new LinearGradientBrush(rect2, gradStartColour, gradMiddleColour, LinearGradientMode.Vertical))
                        {
                            e.Graphics.FillRectangle(brush, rect);
                        }

                        renderer.RenderStandardBorder.DrawBorder(context,
                                                       new Rectangle(e.CellBounds.X - 1, e.CellBounds.Y - 1, e.CellBounds.Width + 2, e.CellBounds.Height + 1),
                                                       _paletteBorder,
                                                       VisualOrientation.Top,
                                                       PaletteState.Normal);


                    }
                }

                e.Paint(e.CellBounds, (DataGridViewPaintParts.ContentForeground | DataGridViewPaintParts.ContentBackground | DataGridViewPaintParts.Border));
                e.Handled = true;
            }
            else if (e.RowIndex >= 0 && e.ColumnIndex > -1 && ((e.State & DataGridViewElementStates.Selected) == DataGridViewElementStates.Selected))
            {

                using (GraphicsPath path = new GraphicsPath())
                {
                    IRenderer renderer = _palette.GetRenderer();
                    path.AddRectangle(new Rectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height));

                    using (RenderContext context = new RenderContext(this, e.Graphics, e.ClipBounds, renderer))
                    {
                        _paletteBack.Style = PaletteBackStyle.ButtonListItem;
                        _paletteBorder.Style = PaletteBorderStyle.ButtonNavigatorStack;

                        _mementoBack = renderer.RenderStandardBack.DrawBack(context,
                            new Rectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height),
                            path, _paletteBack, VisualOrientation.Top, PaletteState.Tracking, _mementoBack);
                        renderer.RenderStandardBorder.DrawBorder(context,
                                                       new Rectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height),
                                                       _paletteBorder,
                                                       VisualOrientation.Top,
                                                       PaletteState.Normal);
                    }
                }

                e.Paint(e.CellBounds, (DataGridViewPaintParts.ContentForeground | DataGridViewPaintParts.ContentBackground | DataGridViewPaintParts.Border));
                e.Handled = true;
            }
            else if (e.ColumnIndex == -1)
            {
                using (GraphicsPath path = new GraphicsPath())
                {
                    IRenderer renderer = _palette.GetRenderer();
                    path.AddRectangle(new Rectangle(e.CellBounds.X + 1, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height));

                    Color gradStartColour = _palette.ColorTable.ToolStripGradientBegin;
                    Color gradMiddleColour = _palette.ColorTable.MenuStripGradientEnd;

                    using (RenderContext context = new RenderContext(this, e.Graphics, e.ClipBounds, renderer))
                    {
                        if (e.State == DataGridViewElementStates.Selected)
                        {
                            _paletteBack.Style = PaletteBackStyle.HeaderPrimary;
                            _paletteBorder.Style = PaletteBorderStyle.HeaderPrimary;
                        }
                        else
                        {
                            _paletteBack.Style = PaletteBackStyle.HeaderPrimary;
                            _paletteBorder.Style = PaletteBorderStyle.HeaderPrimary;
                        }

                        //_mementoBack = renderer.RenderStandardBack.DrawBack(context, e.CellBounds, path, _paletteBack, VisualOrientation.Top, PaletteState.Normal, _mementoBack);
                        renderer.RenderStandardBorder.DrawBorder(context,
                               new Rectangle(e.CellBounds.X, e.CellBounds.Y - 1, e.CellBounds.Width, e.CellBounds.Height + 1),
                               _paletteBorder,
                               VisualOrientation.Top,
                               PaletteState.Normal);

                        //Empty Area
                        e.Graphics.FillRectangle(new SolidBrush(Color.White), e.CellBounds);

                        //Fill Gradient
                        using (LinearGradientBrush brush = new LinearGradientBrush(e.CellBounds, gradStartColour, gradMiddleColour, LinearGradientMode.Vertical))
                        {
                            e.Graphics.FillRectangle(brush, e.CellBounds);
                        }
                    }
                }
                e.Paint(new Rectangle(e.CellBounds.X + 1, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height - 1),
                    (DataGridViewPaintParts.ContentForeground | DataGridViewPaintParts.ContentBackground | DataGridViewPaintParts.Border));

                e.Handled = true;
            }
            else
                base.OnCellPainting(e);
        }

    }
}