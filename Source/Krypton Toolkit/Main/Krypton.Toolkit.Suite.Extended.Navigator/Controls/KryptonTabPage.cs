#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Krypton.Toolkit.Suite.Extended.Navigator
{
    [Designer(typeof(KryptonTabPageDesigner), typeof(IDesigner)), ToolboxBitmap(typeof(TabPage))]
    public class KryptonTabPage : TabPage
    {
        private IPalette m_Palette;
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
                m_Palette = KryptonManager.CurrentGlobalPalette;
            else
                m_Palette = KryptonManager.GetPaletteForMode(m_PaletteMode);

            m_Renderer = m_Palette.GetRenderer();
            m_PaletteRedirect = new PaletteRedirect(m_Palette);

            m_PaletteTabPageBackground = new PaletteBackInheritRedirect(m_PaletteRedirect);
            m_PaletteTabPageBackground.Style = PaletteBackStyle.PanelClient;

            Refresh();

        }

        [Category("Visuals"), DefaultValue(PaletteBackStyle.PanelClient)]
        public PaletteBackStyle PanelBackStyle
        {
            get
            {
                return m_PaletteTabPageBackground.Style;
            }
            set
            {
                m_PaletteTabPageBackground.Style = value;
                Refresh();
            }
        }

        [Category("Visuals"), DefaultValue(PaletteMode.Global)]
        public PaletteMode PaletteMode
        {
            get
            {
                return m_PaletteMode;
            }
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

        public override SelectionRules SelectionRules
        {
            get
            {
                return SelectionRules.Visible;
            }
        }

        public override void InitializeNewComponent(System.Collections.IDictionary defaultValues)
        {
            base.InitializeNewComponent(defaultValues);
        }

        private IDesignerHost DesignerHost
        {
            get
            {
                if (m_DesignerHost == null)
                    m_DesignerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
                return m_DesignerHost;
            }
        }

        private ISelectionService SelectionService
        {
            get
            {
                if (m_SelectionService == null)
                    m_SelectionService = (ISelectionService)(this.GetService(typeof(ISelectionService)));
                return m_SelectionService;
            }
        }

        private KryptonTabPage KryptonTabPage
        {
            get { return (KryptonTabPage)this.Component; }
        }

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
            get { return this.KryptonTabPage.PanelBackStyle; }
            set { SetProperty("PanelBackStyle", value); }
        }

        public PaletteMode PaletteMode
        {
            get { return this.KryptonTabPage.PaletteMode; }
            set { SetProperty("PaletteMode", value); }
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
                    m_DesignerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
                return m_DesignerHost;
            }
        }

        private ISelectionService SelectionService
        {
            get
            {
                if (m_SelectionService == null)
                    m_SelectionService = (ISelectionService)(this.GetService(typeof(ISelectionService)));
                return m_SelectionService;
            }
        }

        private KryptonTabPage KryptonTabPage
        {
            get { return (KryptonTabPage)this.Component; }
        }

    }

}