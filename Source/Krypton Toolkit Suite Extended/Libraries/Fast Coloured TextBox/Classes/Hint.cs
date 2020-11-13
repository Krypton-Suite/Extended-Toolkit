using System;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    /// <summary>
    /// Hint of FastColoredTextbox
    /// </summary>
    public class Hint
    {
        /// <summary>
        /// Text of simple hint
        /// </summary>
        public string Text { get { return HostPanel.Text; } set { HostPanel.Text = value; } }
        /// <summary>
        /// Linked range
        /// </summary>
        public Range Range { get; set; }
        /// <summary>
        /// Backcolor
        /// </summary>
        public Color BackColour { get { return HostPanel.BackColor; } set { HostPanel.BackColor = value; } }
        /// <summary>
        /// Second backcolor
        /// </summary>
        public Color BackColour2 { get { return HostPanel.BackColour2; } set { HostPanel.BackColour2 = value; } }
        /// <summary>
        /// Border color
        /// </summary>
        public Color BorderColour { get { return HostPanel.BorderColour; } set { HostPanel.BorderColour = value; } }
        /// <summary>
        /// Fore color
        /// </summary>
        public Color ForeColour { get { return HostPanel.ForeColor; } set { HostPanel.ForeColor = value; } }
        /// <summary>
        /// Text alignment
        /// </summary>
        public StringAlignment TextAlignment { get { return HostPanel.TextAlignment; } set { HostPanel.TextAlignment = value; } }
        /// <summary>
        /// Font
        /// </summary>
        public Font Font { get { return HostPanel.Font; } set { HostPanel.Font = value; } }
        /// <summary>
        /// Occurs when user click on simple hint
        /// </summary>
        public event EventHandler Click
        {
            add { HostPanel.Click += value; }
            remove { HostPanel.Click -= value; }
        }
        /// <summary>
        /// Inner control
        /// </summary>
        public Control InnerControl { get; set; }
        /// <summary>
        /// Docking (allows None and Fill only)
        /// </summary>
        public DockStyle Dock { get; set; }
        /// <summary>
        /// Width of hint (if Dock is None)
        /// </summary>
        public int Width { get { return HostPanel.Width; } set { HostPanel.Width = value; } }
        /// <summary>
        /// Height of hint
        /// </summary>
        public int Height { get { return HostPanel.Height; } set { HostPanel.Height = value; } }
        /// <summary>
        /// Host panel
        /// </summary>
        public UnfocusablePanel HostPanel { get; private set; }

        internal int TopPadding { get; set; }
        /// <summary>
        /// Tag
        /// </summary>
        public object Tag { get; set; }
        /// <summary>
        /// Cursor
        /// </summary>
        public Cursor Cursor { get { return HostPanel.Cursor; } set { HostPanel.Cursor = value; } }
        /// <summary>
        /// Inlining. If True then hint will moves apart text.
        /// </summary>
        public bool Inline { get; set; }

        /// <summary>
        /// Scroll textbox to the hint
        /// </summary>
        public virtual void DoVisible()
        {
            Range.tb.DoRangeVisible(Range, true);
            Range.tb.DoVisibleRectangle(HostPanel.Bounds);

            Range.tb.Invalidate();
        }

        private Hint(Range range, Control innerControl, string text, bool inline, bool dock)
        {
            this.Range = range;
            this.Inline = inline;
            this.InnerControl = innerControl;

            Init();

            Dock = dock ? DockStyle.Fill : DockStyle.None;
            Text = text;
        }

        /// <summary>
        /// Creates Hint
        /// </summary>
        /// <param name="range">Linked range</param>
        /// <param name="text">Text for simple hint</param>
        /// <param name="inline">Inlining. If True then hint will moves apart text</param>
        /// <param name="dock">Docking. If True then hint will fill whole line</param>
        public Hint(Range range, string text, bool inline, bool dock)
            : this(range, null, text, inline, dock)
        {
        }

        /// <summary>
        /// Creates Hint
        /// </summary>
        /// <param name="range">Linked range</param>
        /// <param name="text">Text for simple hint</param>
        public Hint(Range range, string text)
            : this(range, null, text, true, true)
        {
        }

        /// <summary>
        /// Creates Hint
        /// </summary>
        /// <param name="range">Linked range</param>
        /// <param name="innerControl">Inner control</param>
        /// <param name="inline">Inlining. If True then hint will moves apart text</param>
        /// <param name="dock">Docking. If True then hint will fill whole line</param>
        public Hint(Range range, Control innerControl, bool inline, bool dock)
            : this(range, innerControl, null, inline, dock)
        {
        }

        /// <summary>
        /// Creates Hint
        /// </summary>
        /// <param name="range">Linked range</param>
        /// <param name="innerControl">Inner control</param>
        public Hint(Range range, Control innerControl)
            : this(range, innerControl, null, true, true)
        {
        }

        protected virtual void Init()
        {
            HostPanel = new UnfocusablePanel();
            HostPanel.Click += OnClick;

            Cursor = Cursors.Default;
            BorderColour = Color.Silver;
            BackColour2 = Color.White;
            BackColour = InnerControl == null ? Color.Silver : SystemColors.Control;
            ForeColour = Color.Black;
            TextAlignment = StringAlignment.Near;
            Font = Range.tb.Parent == null ? Range.tb.Font : Range.tb.Parent.Font;

            if (InnerControl != null)
            {
                HostPanel.Controls.Add(InnerControl);
                var size = InnerControl.GetPreferredSize(InnerControl.Size);
                HostPanel.Width = size.Width + 2;
                HostPanel.Height = size.Height + 2;
                InnerControl.Dock = DockStyle.Fill;
                InnerControl.Visible = true;
                BackColour = SystemColors.Control;
            }
            else
            {
                HostPanel.Height = Range.tb.CharHeight + 5;
            }
        }

        protected virtual void OnClick(object sender, EventArgs e)
        {
            Range.tb.OnHintClick(this);
        }
    }
}