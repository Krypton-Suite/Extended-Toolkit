#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2025 - 2025 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

using Task = System.Threading.Tasks.Task;

namespace Krypton.Toolkit.Suite.Extended.Controls
{
    [DesignerCategory(@"code")]
    [ToolboxItem(true)]
    public class KryptonRadialMenu : UserControl
    {
        #region Instance Fields

        private Dictionary<Rectangle, string> _arrowZones = new Dictionary<Rectangle, string>();
        private Dictionary<string, List<string>> _subMenus = new Dictionary<string, List<string>>();
        private Dictionary<string, List<Image>> _subMenuIcons = new Dictionary<string, List<Image>>();
        private Dictionary<string, List<Color>> _subMenuColors = new Dictionary<string, List<Color>>();
        private string? _activeMenu = null;
        private bool _menuOpen = false;
        private int _hoveredSegment = -1;
        private float _animationProgress = 0;
        private ToolTip _tooltip = new ToolTip();
        private bool _isDragging = false;
        private Point _dragStart;

        #endregion

        #region Events

        public event EventHandler<string> MenuItemClicked;
        public event EventHandler<string> SubMenuItemClicked;
        public event EventHandler CentralButtonClicked;

        #endregion

        #region Public

        [Category("Custom Properties")]
        [Description("The items to display in the menu.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<string> MenuItems { get; set; } = new List<string> { "File", "Edit", "View", "Tools", "Help" };

        [Category("Custom Properties")]
        [Description("The icons to display next to the menu items.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Image> MenuIcons { get; set; } = new List<Image>();

        [Category("Custom Properties")]
        [Description("The colors to use for the menu segments.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Color> SegmentColors { get; set; } = new List<Color>();

        #endregion

        #region Identity

        public KryptonRadialMenu()
        {
            Size = new Size(200, 200);
            DoubleBuffered = true;
            MouseMove += KryptonRadialMenu_MouseMove;
            MouseLeave += (s, e) => { _hoveredSegment = -1; Invalidate(); };
            MouseClick += KryptonRadialMenu_MouseClick;
            MouseDown += KryptonRadialMenu_MouseDown;
            MouseUp += KryptonRadialMenu_MouseUp;
        }

        #endregion

        #region Overrides

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            List<string> currentItems = _activeMenu == null ? MenuItems : _subMenus[_activeMenu];
            List<Image> currentIcons = _activeMenu == null ? MenuIcons : _subMenuIcons[_activeMenu];
            List<Color> currentColors = _activeMenu == null ? SegmentColors : _subMenuColors[_activeMenu];

            int centerX = Width / 2;
            int centerY = Height / 2;
            int maxRadius = Math.Min(Width, Height) / 2 - 10;
            int radius = (int)(maxRadius * _animationProgress);
            int numSegments = currentItems.Count;

            if (_menuOpen && numSegments > 0 && radius > 10)
            {
                float angleStep = 360f / numSegments;

                for (int i = 0; i < numSegments; i++)
                {
                    float startAngle = i * angleStep;
                    using (GraphicsPath path = new GraphicsPath())
                    {
                        path.AddPie(centerX - radius, centerY - radius, radius * 2, radius * 2, startAngle, angleStep);
                        using (SolidBrush brush = new SolidBrush(i == _hoveredSegment
                                   ? Color.LightBlue
                                   : (i < currentColors.Count ? currentColors[i] : Color.Gray)))
                        {
                            g.FillPath(brush, path);
                        }

                        g.DrawPath(Pens.Black, path);
                    }

                    float segmentCenterAngle = startAngle + angleStep / 2;
                    float segmentTextX =
                        centerX + (float)(Math.Cos(segmentCenterAngle * Math.PI / 180) * radius * 0.75);
                    float segmentTextY =
                        centerY + (float)(Math.Sin(segmentCenterAngle * Math.PI / 180) * radius * 0.75);

                    if (i < currentIcons.Count && currentIcons[i] != null)
                    {
                        float iconX = segmentTextX - 10;
                        float iconY = segmentTextY - 20;
                        g.DrawImage(currentIcons[i], iconX, iconY, 20, 20);
                    }

                    if (i < currentItems.Count)
                    {
                        Font itemFont = new Font("Arial", 10, FontStyle.Bold);
                        SizeF textSize = g.MeasureString(currentItems[i], itemFont);
                        PointF textPosition = new PointF(segmentTextX - textSize.Width / 2, segmentTextY + 5);
                        g.DrawString(currentItems[i], itemFont, Brushes.Black, textPosition);
                    }
                }
            }

            // Draw central button (always visible)
            int buttonSize = 40;
            Rectangle centerButtonRect =
                new Rectangle(centerX - buttonSize / 2, centerY - buttonSize / 2, buttonSize, buttonSize);
            g.FillEllipse(Brushes.White, centerButtonRect);
            g.DrawEllipse(Pens.Black, centerButtonRect);

            // Define text or image for the button
            string buttonText = _activeMenu == null ? "☰" : "←"; // Hamburger menu or back arrow
            Font buttonFont = new Font("Arial", 12, FontStyle.Bold);
            SizeF textSizeBtn = g.MeasureString(buttonText, buttonFont);
            PointF textPositionBtn = new PointF(
                centerX - textSizeBtn.Width / 2,
                centerY - textSizeBtn.Height / 2
            );

            // Draw text in the center
            g.DrawString(buttonText, buttonFont, Brushes.Black, textPositionBtn);
        }

        #endregion

        #region Implementation

        public void AddSubMenu(string mainItem, List<string> subItems, List<Image>? subIcons = null, List<Color>? subColors = null)
        {
            _subMenus[mainItem] = subItems;
            _subMenuIcons[mainItem] = subIcons ?? new List<Image>();
            _subMenuColors[mainItem] = subColors ?? new List<Color>();
        }

        private async void ToggleMenu()
        {
            if (!_menuOpen)
            {
                _menuOpen = true;
                for (int i = 0; i <= 10; i++)
                {
                    _animationProgress = i / 10f;
                    Invalidate();
                    await Task.Delay(20);
                }
            }
            else
            {
                for (int i = 10; i >= 0; i--)
                {
                    _animationProgress = i / 10f;
                    Invalidate();
                    await Task.Delay(20);
                }
                _menuOpen = false;
            }
        }

        private void KryptonRadialMenu_MouseDown(object? sender, MouseEventArgs e)
        {
            int centerX = Width / 2;
            int centerY = Height / 2;
            int distance = (int)Math.Sqrt(Math.Pow(e.X - centerX, 2) + Math.Pow(e.Y - centerY, 2));

            if (distance < 20) // Central button clicked
            {
                _isDragging = true;
                _dragStart = e.Location;
            }
        }

        private void KryptonRadialMenu_MouseUp(object? sender, MouseEventArgs e)
        {
            _isDragging = false;
        }

        private void KryptonRadialMenu_MouseMove(object? sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                this.Location = new Point(this.Left + e.X - _dragStart.X, this.Top + e.Y - _dragStart.Y);
                return;
            }

            if (!_menuOpen) return;

            int centerX = Width / 2;
            int centerY = Height / 2;
            float angleStep = 360f / (_activeMenu == null ? MenuItems.Count : _subMenus[_activeMenu].Count);

            double angle = Math.Atan2(e.Y - centerY, e.X - centerX) * (180 / Math.PI);
            if (angle < 0) angle += 360;

            int newHoveredSegment = (int)(angle / angleStep);
            if (_hoveredSegment != newHoveredSegment)
            {
                _hoveredSegment = newHoveredSegment;
                Invalidate();

                List<string> currentItems = _activeMenu == null ? MenuItems : _subMenus[_activeMenu];
                if (_hoveredSegment < currentItems.Count)
                {
                    _tooltip.SetToolTip(this, currentItems[_hoveredSegment]);
                }
            }
        }

        private void KryptonRadialMenu_MouseClick(object? sender, MouseEventArgs e)
        {
            int centerX = Width / 2;
            int centerY = Height / 2;
            int distance = (int)Math.Sqrt(Math.Pow(e.X - centerX, 2) + Math.Pow(e.Y - centerY, 2));

            // Check if clicked on central button
            if (distance < 20)
            {
                CentralButtonClicked?.Invoke(this, EventArgs.Empty);

                if (_activeMenu != null)
                {
                    _activeMenu = null;
                }
                else
                {
                    ToggleMenu();
                }
                Invalidate();
                return;
            }

            // Check if clicked on an arrow (for submenu navigation)
            foreach (var arrow in _arrowZones)
            {
                if (arrow.Key.Contains(e.Location))
                {
                    _activeMenu = arrow.Value;
                    Invalidate();
                    return;
                }
            }

            // Check if clicked on a segment
            if (_menuOpen && _hoveredSegment >= 0)
            {
                List<string> currentItems = _activeMenu == null ? MenuItems : _subMenus[_activeMenu];

                if (_hoveredSegment < currentItems.Count)
                {
                    string clickedItem = currentItems[_hoveredSegment];

                    if (_subMenus.ContainsKey(clickedItem))
                    {
                        _activeMenu = clickedItem;
                    }
                    else
                    {
                        if (_activeMenu == null)
                            MenuItemClicked?.Invoke(this, clickedItem);
                        else
                            SubMenuItemClicked?.Invoke(this, clickedItem);
                    }
                }
            }
        }
    }

    #endregion
}