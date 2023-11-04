#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Navigator
{
    [Designer(typeof(KryptonTabPageDesigner), typeof(IDesigner)), ToolboxBitmap(typeof(TabPage))]
    public class KryptonTabPage : TabPage
    {
        private PaletteBase m_Palette;
        private IRenderer m_Renderer;
        private PaletteMode m_PaletteMode;
        private PaletteRedirect m_PaletteRedirect;
        private PaletteBackInheritRedirect m_PaletteTabPageBackground;
        private IDisposable m_MementoTabPageBackground;

        public KryptonTabPage()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

            KryptonManager.GlobalPaletteChanged += KryptonManager_GlobalPaletteChanged;

            RefreshPalette();
        }

        ~KryptonTabPage()
        {
            KryptonManager.GlobalPaletteChanged -= KryptonManager_GlobalPaletteChanged;
        }

        private void KryptonManager_GlobalPaletteChanged(object sender, EventArgs e)
        {
            RefreshPalette();
        }

        private void RefreshPalette()
        {
            if (m_PaletteMode == PaletteMode.Global)
            {
                m_Palette = KryptonManager.CurrentGlobalPalette;
            }
            else
            {
                m_Palette = KryptonManager.GetPaletteForMode(m_PaletteMode);
            }

            m_Renderer = m_Palette.GetRenderer();
            m_PaletteRedirect = new PaletteRedirect(m_Palette);

            m_PaletteTabPageBackground = new PaletteBackInheritRedirect(m_PaletteRedirect);
            m_PaletteTabPageBackground.Style = PaletteBackStyle.PanelClient;

            Refresh();

        }

        [Category("Visuals"), DefaultValue(PaletteBackStyle.PanelClient)]
        public PaletteBackStyle PanelBackStyle
        {
            get => m_PaletteTabPageBackground.Style;
            set
            {
                m_PaletteTabPageBackground.Style = value;
                Refresh();
            }
        }

        [Category("Visuals"), DefaultValue(PaletteMode.Global)]
        public PaletteMode PaletteMode
        {
            get => m_PaletteMode;
            set
            {
                m_PaletteMode = value;
                RefreshPalette();
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (RenderContext renderContext = new RenderContext(this, e.Graphics, e.ClipRectangle, m_Renderer))
            {
                using (GraphicsPath path = new GraphicsPath())
                {
                    Rectangle rect = this.DisplayRectangle;
                    path.AddRectangle(rect);
                    m_MementoTabPageBackground = m_Renderer.RenderStandardBack.DrawBack(renderContext, rect, path, m_PaletteTabPageBackground, VisualOrientation.Top, PaletteState.Normal, m_MementoTabPageBackground);
                }
            }
        }

    }

    public class KryptonTabPageDesigner : ParentControlDesigner
    {
        private IDesignerHost m_DesignerHost;
        private ISelectionService m_SelectionService;

        public KryptonTabPageDesigner()
            : base()
        {
        }

        public override DesignerActionListCollection ActionLists
        {
            get
            {
                DesignerActionListCollection actionLists = new DesignerActionListCollection();
                actionLists.Add(new KryptonTabPageDesignList(this.Component));
                return actionLists;
            }
        }

        public override SelectionRules SelectionRules => SelectionRules.Visible;

        public override void InitializeNewComponent(System.Collections.IDictionary defaultValues)
        {
            base.InitializeNewComponent(defaultValues);
        }

        private IDesignerHost DesignerHost
        {
            get
            {
                if (m_DesignerHost == null)
                {
                    m_DesignerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
                }

                return m_DesignerHost;
            }
        }

        private ISelectionService SelectionService
        {
            get
            {
                if (m_SelectionService == null)
                {
                    m_SelectionService = (ISelectionService)(this.GetService(typeof(ISelectionService)));
                }

                return m_SelectionService;
            }
        }

        private KryptonTabPage KryptonTabPage => (KryptonTabPage)this.Component;
    }

    public class KryptonTabPageDesignList : DesignerActionList
    {
        private IDesignerHost m_DesignerHost;
        private ISelectionService m_SelectionService;

        public KryptonTabPageDesignList(IComponent component)
            : base(component)
        {
        }

        public PaletteBackStyle PanelBackStyle
        {
            get => this.KryptonTabPage.PanelBackStyle;
            set => SetProperty("PanelBackStyle", value);
        }

        public PaletteMode PaletteMode
        {
            get => this.KryptonTabPage.PaletteMode;
            set => SetProperty("PaletteMode", value);
        }

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection actionItems = new DesignerActionItemCollection();

            actionItems.Add(new DesignerActionHeaderItem("Appearance"));
            actionItems.Add(new DesignerActionPropertyItem("PanelBackStyle", "Back style", "Appearance"));

            actionItems.Add(new DesignerActionHeaderItem("Visuals"));
            actionItems.Add(new DesignerActionPropertyItem("PaletteMode", "Palette", "Visuals"));

            return actionItems;
        }

        private void SetProperty(string propertyName, object value)
        {
            PropertyDescriptor property = TypeDescriptor.GetProperties(this.KryptonTabPage)[propertyName];
            property.SetValue(this.KryptonTabPage, value);
        }

        private IDesignerHost DesignerHost
        {
            get
            {
                if (m_DesignerHost == null)
                {
                    m_DesignerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
                }

                return m_DesignerHost;
            }
        }

        private ISelectionService SelectionService
        {
            get
            {
                if (m_SelectionService == null)
                {
                    m_SelectionService = (ISelectionService)(this.GetService(typeof(ISelectionService)));
                }

                return m_SelectionService;
            }
        }

        private KryptonTabPage KryptonTabPage => (KryptonTabPage)this.Component;
    }

}