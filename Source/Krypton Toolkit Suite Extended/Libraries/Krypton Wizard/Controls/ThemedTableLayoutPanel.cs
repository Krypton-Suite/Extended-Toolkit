using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Krypton.Toolkit.Suite.Extended.Wizard
{
    /// <summary>
    /// A table layout panel that supports a glass overlay.
    /// </summary>
    [ToolboxItem(true), ToolboxBitmap(typeof(ThemedTableLayoutPanel), "Resources\\ThemedTableLayoutPanel.bmp")]
    public class ThemedTableLayoutPanel : TableLayoutPanel
    {
        private VisualStyleRenderer rnd;

        /// <summary>
        /// Initializes a new instance of the <see cref="ThemedTableLayoutPanel"/> class.
        /// </summary>
        public ThemedTableLayoutPanel()
        {
            SetTheme(VisualStyleElement.Window.Dialog.Normal);
        }

        /// <summary>
        /// Clears the theme and defaults to TableLayoutPanel painting.
        /// </summary>
        public void ClearTheme()
        {
            rnd = null;
        }

        /// <summary>
        /// Sets the theme using a defined <see cref="VisualStyleElement"/>.
        /// </summary>
        /// <param name="element">The visual element.</param>
        public void SetTheme(VisualStyleElement element)
        {
            if (VisualStyleRenderer.IsSupported && VisualStyleRenderer.IsElementDefined(element))
                rnd = new VisualStyleRenderer(element);
            else
                rnd = null;
        }

        /// <summary>
        /// Sets the theme using theme class information.
        /// </summary>
        /// <param name="className">Name of the theme class.</param>
        /// <param name="part">The theme part.</param>
        /// <param name="state">The theme state.</param>
        public void SetTheme(string className, int part, int state)
        {
            if (VisualStyleRenderer.IsSupported)
            {
                try
                {
                    rnd = new VisualStyleRenderer(className, part, state);
                    return;
                }
                catch { }
            }
            rnd = null;
        }

        /// <summary>
        /// Gets or sets a value indicating whether to watch getting and losing focus.
        /// </summary>
        /// <value>
        ///   <c>true</c> if watching focus events; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(false), Category("Behavior")]
        public bool WatchFocus { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this table supports glass (can be enclosed in the glass margin).
        /// </summary>
        /// <value>
        ///   <c>true</c> if supports glass; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(false), Category("Appearance")]
        public bool SupportGlass { get; set; }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.HandleCreated" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnHandleCreated(System.EventArgs e)
        {
            base.OnHandleCreated(e);
            AttachToFormEvents();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (!this.IsDesignMode() && SupportGlass && DesktopWindowManager.IsCompositionEnabled())
                try { e.Graphics.Clear(System.Drawing.Color.Black); } catch { }
            else
            {
                if (this.IsDesignMode() || rnd == null || !Application.RenderWithVisualStyles)
                    try { e.Graphics.Clear(BackColor); } catch { }
                else
                    rnd.DrawBackground(e.Graphics, ClientRectangle, e.ClipRectangle);
            }
            base.OnPaint(e);
        }

        private void AttachToFormEvents()
        {
            Form pForm = FindForm();
            if (pForm != null && WatchFocus)
            {
                pForm.Activated += new System.EventHandler(Form_GotFocus);
                pForm.Deactivate += new System.EventHandler(Form_LostFocus);
            }
        }

        private void Form_GotFocus(object sender, System.EventArgs e)
        {
            OnGotFocus(e);
            if (rnd != null && Application.RenderWithVisualStyles)
                rnd.SetParameters(rnd.Class, rnd.Part, 1);
            Refresh();
        }

        private void Form_LostFocus(object sender, System.EventArgs e)
        {
            OnLostFocus(e);
            if (rnd != null && Application.RenderWithVisualStyles)
                rnd.SetParameters(rnd.Class, rnd.Part, 2);
            Refresh();
        }
    }
}