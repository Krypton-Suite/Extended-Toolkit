#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Wizard
{
    /// <summary>
    /// Shows a list of all the pages in the WizardControl
    /// </summary>
    [ProvideProperty("StepText", typeof(WizardPage))]
    [ProvideProperty("StepTextIndentLevel", typeof(WizardPage))]
    internal class StepList : ScrollableControl, IExtenderProvider
    {
        private const TextFormatFlags defBulletTextFormat = TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding;
        private const TextFormatFlags defStringTextFormat = TextFormatFlags.EndEllipsis | TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter;

        private Font boldFont;
        private int bulletWidth;
        private int defItemHeight;
        private readonly Dictionary<WizardPage, int> indentLevels = new Dictionary<WizardPage, int>();
        private WizardControl myParent;
        private Font ptrFont;
        private readonly Dictionary<WizardPage, string> stepTexts = new Dictionary<WizardPage, string>();

        /// <summary>
        /// Occurs when a visual aspect of an owner-drawn StepList changes.
        /// </summary>
        [Category("Appearance")]
        public event EventHandler<DrawStepListItemEventArgs> DrawItem;

        /// <summary>
        /// Occurs when an owner-drawn StepList is created and the sizes of the list items are determined.
        /// </summary>
        [Category("Appearance")]
        public event EventHandler<MeasureStepListItemEventArgs> MeasureItem;

        /// <summary>
        /// Gets or sets a value indicating whether the StepList is drawn by the operating system or by code that you provide.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the StepList is drawn by code that you provide; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(false), Category("Appearance"), Description("Indicates if controls is drawn by owner.")]
        public bool OwnerDraw { get; set; }

        /// <summary>
        /// Gets the default size of the control.
        /// </summary>
        /// <returns>The default <see cref="T:System.Drawing.Size" /> of the control.</returns>
        protected override Size DefaultSize => new Size(150, 200);

        /// <summary>
        /// Gets the step text.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns>Step text for the specified wizard page.</returns>
        [DefaultValue(null), Category("Appearance"), Description("Alternate text to provide to the StepList. Default value comes the Text property of the WizardPage.")]
        public string GetStepText(WizardPage page)
        {
            string value;
            if (stepTexts.TryGetValue(page, out value))
                return value;
            return page.Text;
        }

        /// <summary>
        /// Gets the step text indent level.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns>Step text indent level for the specified wizard page.</returns>
        [DefaultValue(0), Category("Appearance"), Description("Indentation level for text provided to the StepList.")]
        public int GetStepTextIndentLevel(WizardPage page)
        {
            int value;
            if (indentLevels.TryGetValue(page, out value))
                return value;
            return 0;
        }

        bool IExtenderProvider.CanExtend(object extendee) => (extendee is WizardPage);

        /// <summary>
        /// Sets the step text.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="value">The value.</param>
        public void SetStepText(WizardPage page, string value)
        {
            if (string.IsNullOrEmpty(value) || value == page.Text)
                stepTexts.Remove(page);
            else
                stepTexts[page] = value;
            Refresh();
        }

        /// <summary>
        /// Sets the step text indent level.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="value">The indent level.</param>
        public void SetStepTextIndentLevel(WizardPage page, int value)
        {
            if (value < 0) value = 0;
            if (value == 0)
                indentLevels.Remove(page);
            else
                indentLevels[page] = value;
            Refresh();
        }

        /// <summary>
        /// Raises the <see cref="E:DrawItem"/> event.
        /// </summary>
        /// <param name="e">The <see cref="DrawStepListItemEventArgs"/> instance containing the event data.</param>
        protected virtual void OnDrawItem(DrawStepListItemEventArgs e)
        {
            DrawItem?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:FontChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            using (var g = CreateGraphics())
            {
                defItemHeight = (int)Math.Ceiling(TextRenderer.MeasureText(g, "Wg", Font).Height * 1.2);
                ptrFont = new Font("Marlett", Font.Size);
                boldFont = new Font(Font, FontStyle.Bold);
                bulletWidth = TextRenderer.MeasureText(g, "4", ptrFont, new Size(0, defItemHeight), defBulletTextFormat).Width;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:MeasureItem"/> event.
        /// </summary>
        /// <param name="e">The <see cref="MeasureStepListItemEventArgs"/> instance containing the event data.</param>
        protected virtual void OnMeasureItem(MeasureStepListItemEventArgs e)
        {
            MeasureItem?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (myParent == null) return;
            var y = Padding.Top;
            var pages = myParent.Pages;
            var hit = false;
            for (var i = 0; i < pages.Count; i++)
            {
                var curPage = pages[i];
                if (!curPage.Suppress)
                {
                    var itemSize = new Size(Width - Padding.Horizontal, defItemHeight);
                    if (OwnerDraw)
                    {
                        var meArg = new MeasureStepListItemEventArgs(e.Graphics, Font, curPage, new Size(Width, defItemHeight));
                        OnMeasureItem(meArg);
                        itemSize = meArg.ItemSize;
                    }
                    if (y + itemSize.Height > (Height - Padding.Bottom))
                        break;
                    var isSelected = myParent.SelectedPage == curPage;
                    if (isSelected) hit = true;
                    var eArg = new DrawStepListItemEventArgs(e.Graphics, Font, new Rectangle(new Point(Padding.Left, y), itemSize), curPage, isSelected, hit);
                    if (OwnerDraw)
                        OnDrawItem(eArg);
                    else
                        DefaultDrawItem(eArg);
                    y += itemSize.Height;
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.ParentChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            SetupControl(this.GetParent<WizardControl>());
        }

        private static void Split(Rectangle rect, int xPos, out Rectangle r1, out Rectangle r2)
        {
            r1 = r2 = rect;
            r1.Width = r2.X = xPos;
            r2.Width = r2.Width - xPos;
        }

        private void DefaultDrawItem(DrawStepListItemEventArgs e)
        {
            Color fc = ForeColor, bc = BackColor;
            var level = GetStepTextIndentLevel(e.Item);
            var isRTL = RightToLeft == RightToLeft.Yes;
            var tffrtl = isRTL ? TextFormatFlags.Right : 0;
            Rectangle rect, prect;
            if (isRTL)
            {
                Split(e.Bounds, Width - bulletWidth, out rect, out prect);
                prect.X = e.Bounds.Width - (bulletWidth * (level + 1));
                rect.Width = Width - (bulletWidth * (level + 1));
            }
            else
            {
                Split(e.Bounds, bulletWidth, out prect, out rect);
                prect.X = bulletWidth * level;
                rect.X = bulletWidth * (level + 1);
            }
            if (!e.Completed)
                fc = SystemColors.GrayText;
            using (Brush br = new SolidBrush(bc))
                e.Graphics.FillRectangle(br, Rectangle.Union(rect, prect));
            TextRenderer.DrawText(e.Graphics, e.Completed ? (isRTL ? "3" : "4") : "a", ptrFont, prect, fc, defBulletTextFormat | tffrtl);
            TextRenderer.DrawText(e.Graphics, GetStepText(e.Item), e.Selected ? boldFont : Font, rect, fc, defStringTextFormat | tffrtl);
        }

        private void pages_Changed(object sender, EventedList<WizardPage>.ListChangedEventArgs<WizardPage> e)
        {
            Refresh();
        }

        private void ResetStepText(WizardPage page)
        {
            SetStepText(page, null);
        }

        private void SetupControl(WizardControl p)
        {
            if (myParent != null)
            {
                var pages = myParent.Pages;
                pages.ItemAdded -= pages_Changed;
                pages.ItemChanged -= pages_Changed;
                pages.ItemDeleted -= pages_Changed;
            }
            myParent = p;
            if (myParent != null)
            {
                var pages = myParent.Pages;
                pages.ItemAdded += pages_Changed;
                pages.ItemChanged += pages_Changed;
                pages.ItemDeleted += pages_Changed;
            }
            Refresh();
        }

        private bool ShouldSerializeStepText(WizardPage page) => GetStepText(page) != page.Text;
    }
}