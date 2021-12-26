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
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Krypton.Toolkit.Suite.Extended.Navigator
{
    [Designer(typeof(KryptonTabControlDesigner), typeof(IDesigner)), ToolboxBitmap(typeof(TabControl))]
    public class KryptonTabControlAlternative : TabControl
    {

        #region "Static properties"
        private static Control g_ViewLayoutContextControl;
        private static StringFormat g_StringFormat;
        private static Font g_TabFontBold;
        private static Font g_TabFontRegular;
        #endregion

        private IPalette m_Palette;
        private IRenderer m_Renderer;
        private ViewLayoutContext m_ViewLayoutContext;
        private PaletteMode m_PaletteMode;
        private PaletteRedirect m_PaletteRedirect;
        private PaletteBackInheritRedirect m_PaletteTabControlBackground;
        private PaletteBorderInheritRedirect m_PaletteTabPageBorder;
        private PaletteBackInheritRedirect m_PaletteTabButtonBackground;
        private PaletteBorderInheritRedirect m_PaletteTabButtonBorder;
        private IDisposable m_MementoTabButtonBackground;
        private Boolean m_TransparentBackground = true;
        private SolidBrush m_TabBrush;
        private Font m_TabFont;

        static KryptonTabControlAlternative()
        {
            g_ViewLayoutContextControl = new Control();
            g_StringFormat = new StringFormat(StringFormatFlags.NoWrap);
            g_StringFormat.Alignment = StringAlignment.Center;
            g_StringFormat.LineAlignment = StringAlignment.Center;
        }

        public KryptonTabControlAlternative()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

            KryptonManager.GlobalPaletteChanged += KryptonManager_GlobalPaletteChanged;

            RefreshPalette();
        }

        ~KryptonTabControlAlternative()
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

            m_ViewLayoutContext = new ViewLayoutContext(g_ViewLayoutContextControl, m_Renderer);
            g_TabFontBold = new Font(m_Palette.GetContentShortTextFont(PaletteContentStyle.ButtonNavigatorStack, PaletteState.Normal), FontStyle.Bold);
            g_TabFontRegular = new Font(g_TabFontBold, FontStyle.Regular);

            m_PaletteRedirect = new PaletteRedirect(m_Palette);
            m_PaletteTabControlBackground = new PaletteBackInheritRedirect(m_PaletteRedirect);
            m_PaletteTabPageBorder = new PaletteBorderInheritRedirect(m_PaletteRedirect);
            m_PaletteTabButtonBackground = new PaletteBackInheritRedirect(m_PaletteRedirect);
            m_PaletteTabButtonBorder = new PaletteBorderInheritRedirect(m_PaletteRedirect);

            m_PaletteTabControlBackground.Style = PaletteBackStyle.PanelClient;
            m_PaletteTabPageBorder.Style = PaletteBorderStyle.ButtonNavigatorStack;
            m_PaletteTabButtonBackground.Style = PaletteBackStyle.ButtonNavigatorStack;
            m_PaletteTabButtonBorder.Style = PaletteBorderStyle.ButtonNavigatorMini;

            m_TabBrush = new SolidBrush(m_Palette.GetContentShortTextColor1(PaletteContentStyle.ButtonNavigatorStack, PaletteState.Normal));

            Refresh();
        }

        [Editor(typeof(KryptonTabPageCollectionEditor), typeof(UITypeEditor))]
        public new TabPageCollection TabPages
        {
            get
            {
                return base.TabPages;
            }
        }

        internal class KryptonTabPageCollectionEditor : CollectionEditor
        {
            public KryptonTabPageCollectionEditor(System.Type type)
                : base(type)
            {
            }

            protected override Type CreateCollectionItemType()
            {
                return typeof(KryptonTabPage);
            }
        }

        [Category("Visuals"), DefaultValue(PaletteBackStyle.PanelClient)]
        public PaletteBackStyle PanelBackStyle
        {
            get
            {
                return m_PaletteTabControlBackground.Style;
            }
            set
            {
                m_PaletteTabControlBackground.Style = value;
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

        [Category("Visuals"), DefaultValue(true)]
        public bool TransparentBackground
        {
            get
            {
                return m_TransparentBackground;
            }
            set
            {
                m_TransparentBackground = value;
                RefreshPalette();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle RBorder = DisplayRectangle;
            RBorder.Inflate(1, 1);

            using (Pen PBorder = new Pen(m_PaletteTabPageBorder.GetBorderColor1(PaletteState.Normal)))
            {
                e.Graphics.DrawRectangle(PBorder, RBorder);
            }

            if (this.TabCount > 0)
            {
                using (RenderContext renderContext = new RenderContext(this, e.Graphics, e.ClipRectangle, m_Renderer))
                {
                    renderContext.Graphics.CompositingQuality = CompositingQuality.HighQuality;
                    renderContext.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                    int selectedIndex = this.SelectedIndex;
                    for (int index = 0; index <= this.TabCount - 1; index++)
                    {
                        if (index != selectedIndex)
                            this.PaintTab(index, renderContext);
                    }
                    if (selectedIndex >= 0)
                        this.PaintTab(selectedIndex, renderContext);
                }
            }

        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            if (Application.RenderWithVisualStyles && m_TransparentBackground)
            {
                System.Windows.Forms.GroupBoxRenderer.DrawParentBackground(pevent.Graphics, pevent.ClipRectangle, this);
            }
            else
            {
                Color backColour = m_Palette.GetBackColor1(PanelBackStyle, PaletteState.Normal);
                using (SolidBrush backBrush = new SolidBrush(backColour))
                {
                    pevent.Graphics.FillRectangle(backBrush, pevent.ClipRectangle);
                }
            }
        }

        private void PaintTab(int index, RenderContext renderContext)
        {
            bool Selected = (SelectedIndex == index);

            Rectangle tabRect = GetTabRect(index);

            if ((Appearance & TabAppearance.Normal) == TabAppearance.Normal)
            {
                tabRect.Inflate(0, Selected ? 2 : 1);
                tabRect.X += 1;
            }

            PaletteState State = default(PaletteState);
            if (Selected)
            {
                State = PaletteState.Pressed;
            }
            else
            {
                State = tabRect.Contains(PointToClient(MousePosition)) ? PaletteState.Tracking : PaletteState.Normal;
            }

            VisualOrientation visualOrientation = (VisualOrientation)Alignment;

            if (m_PaletteTabButtonBackground.GetBackDraw(State) == InheritBool.True)
            {
                using (GraphicsPath BackPath = m_Renderer.RenderStandardBorder.GetBackPath(renderContext, tabRect, m_PaletteTabButtonBorder, visualOrientation, State))
                {
                    m_MementoTabButtonBackground = m_Renderer.RenderStandardBack.DrawBack(renderContext, tabRect, BackPath, m_PaletteTabButtonBackground, visualOrientation, State, m_MementoTabButtonBackground);
                }
            }

            if (m_PaletteTabButtonBorder.GetBorderDraw(State) == InheritBool.True)
            {
                m_Renderer.RenderStandardBorder.DrawBorder(renderContext, tabRect, m_PaletteTabButtonBorder, visualOrientation, State);
            }
            else if (Selected)
            {
                using (Pen PBorder = new Pen(m_PaletteTabPageBorder.GetBorderColor1(PaletteState.Normal)))
                {
                    Rectangle RBorder = tabRect;
                    RBorder.Width -= 1;

                    renderContext.Graphics.DrawRectangle(PBorder, RBorder);
                }
            }

            // (TODO: adjust rendering for other Appearance settings)

            if (ImageList != null)
            {
                Image tabImage = null;

                if (TabPages[index].ImageIndex != -1)
                {
                    int imageIndex = TabPages[index].ImageIndex;
                    tabImage = ImageList.Images[imageIndex];
                }
                else if (TabPages[index].ImageKey != null)
                {
                    string imageKey = TabPages[index].ImageKey;
                    tabImage = ImageList.Images[imageKey];
                }

                if (tabImage != null)
                {
                    int x = tabRect.X + (tabImage.Width / 2);
                    int y = tabRect.Y + (tabRect.Height - tabImage.Height) / 2;

                    renderContext.Graphics.DrawImage(tabImage, x, y);

                    tabRect.X += tabImage.Width;
                    tabRect.Width -= tabImage.Width;

                }

            }

            if (m_TabFont == null || (!object.ReferenceEquals(m_TabFont, g_TabFontBold) & !object.ReferenceEquals(m_TabFont, g_TabFontRegular)))
            {
                if (renderContext.Graphics.MeasureString(TabPages[index].Text, g_TabFontBold, tabRect.X, g_StringFormat).Width <= tabRect.Width)
                    m_TabFont = g_TabFontBold;
                else
                    m_TabFont = g_TabFontRegular;
            }

            renderContext.Graphics.DrawString(TabPages[index].Text, m_TabFont, m_TabBrush, tabRect, g_StringFormat);

        }

    }

    public class KryptonTabControlDesigner : ParentControlDesigner
    {
        private IDesignerHost m_DesignerHost;
        private ISelectionService m_SelectionService;

        public KryptonTabControlDesigner()
            : base()
        {
        }

        public override DesignerActionListCollection ActionLists
        {
            get
            {
                DesignerActionListCollection actionLists = new DesignerActionListCollection();
                actionLists.Add(new KryptonTabControlDesignList(this.Component));
                return actionLists;
            }
        }

        public override SelectionRules SelectionRules
        {
            get
            {
                if (this.Control.Dock == DockStyle.Fill)
                    return SelectionRules.Visible;
                return base.SelectionRules;
            }
        }

        public override void InitializeNewComponent(System.Collections.IDictionary defaultValues)
        {
            /* Creating my own TabPage class
             * http://social.msdn.microsoft.com/Forums/en/winformsdesigner/thread/2d9ea42c-f29b-49b2-ba2b-0964975fad17 
             */

            base.InitializeNewComponent(defaultValues);

            KryptonTabPage page1 = (KryptonTabPage)DesignerHost.CreateComponent(typeof(KryptonTabPage));
            page1.Text = page1.Name;

            KryptonTabPage page2 = (KryptonTabPage)DesignerHost.CreateComponent(typeof(KryptonTabPage));
            page2.Text = page2.Name;

            this.KryptonTabControl.Size = new Size(300, 200);
            this.KryptonTabControl.TabPages.AddRange(new KryptonTabPage[] { page1, page2 });

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

        private KryptonTabControl KryptonTabControl
        {
            get { return (KryptonTabControl)this.Component; }
        }

        #region TabControl designer fix

        /* Tabcontrol using custom Tabpages
     * http://dotnetrix.co.uk/tabcontrol.htm#tip10
     */

        private const int WM_NCHITTEST = 0x84;
        private const int HTTRANSPARENT = -1;
        private const int HTCLIENT = 1;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
            {
                // Select tabcontrol when TabControl clicked outside of TabItem.
                if (m.Result.ToInt32() == HTTRANSPARENT)
                    m.Result = (IntPtr)HTCLIENT;
            }

        }

        private enum TabControlHitTest
        {
            TCHT_NOWHERE = 1,
            TCHT_ONITEMICON = 2,
            TCHT_ONITEMLABEL = 4,
            TCHT_ONITEM = TCHT_ONITEMICON | TCHT_ONITEMLABEL
        }

        private const int TCM_HITTEST = 0x130D;

        private struct TCHITTESTINFO
        {
            public Point pt;
            public TabControlHitTest flags;
        }

        protected override bool GetHitTest(Point point)
        {
            if (this.SelectionService.PrimarySelection == this.Control)
            {
                TCHITTESTINFO hti = new TCHITTESTINFO();

                hti.pt = this.Control.PointToClient(point);
                hti.flags = 0;

                Message m = new Message();
                m.HWnd = this.Control.Handle;
                m.Msg = TCM_HITTEST;

                IntPtr lparam = Marshal.AllocHGlobal(Marshal.SizeOf(hti));
                Marshal.StructureToPtr(hti, lparam, false);
                m.LParam = lparam;

                base.WndProc(ref m);
                Marshal.FreeHGlobal(lparam);

                if (m.Result.ToInt32() != -1)
                    return hti.flags != TabControlHitTest.TCHT_NOWHERE;

            }

            return false;
        }

        #endregion

    }

    public class KryptonTabControlDesignList : DesignerActionList
    {
        /* Simplify UI Development with Custom Designer Actions in Visual Studio
         * http://msdn.microsoft.com/en-us/magazine/cc163758.aspx
         */

        private IDesignerHost m_DesignerHost;
        private ISelectionService m_SelectionService;

        public KryptonTabControlDesignList(IComponent component)
            : base(component)
        {
        }

        public PaletteBackStyle PanelBackStyle
        {
            get { return this.KryptonTabControl.PanelBackStyle; }
            set { SetProperty("PanelBackStyle", value); }
        }

        public PaletteMode PaletteMode
        {
            get { return this.KryptonTabControl.PaletteMode; }
            set { SetProperty("PaletteMode", value); }
        }

        public bool TransparentBackground
        {
            get { return this.KryptonTabControl.TransparentBackground; }
            set { SetProperty("TransparentBackground", value); }
        }

        public void AddTab()
        {
            TabPage page = (TabPage)DesignerHost.CreateComponent(typeof(TabPage));
            page.Text = page.Name;

            this.KryptonTabControl.TabPages.Add(page);
            this.KryptonTabControl.SelectedTab = page;
        }

        public void RemoveTab()
        {
            if (this.KryptonTabControl.SelectedTab == null) return;

            TabPage page = this.KryptonTabControl.SelectedTab;
            DesignerHost.DestroyComponent(page);

            SelectionService.SetSelectedComponents(new IComponent[] { this.KryptonTabControl }, SelectionTypes.Auto);
        }

        public void ToggleDockStyle()
        {
            Boolean docked = (this.KryptonTabControl.Dock == DockStyle.Fill);
            SetProperty("Dock", docked ? DockStyle.None : DockStyle.Fill);
        }

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection actionItems = new DesignerActionItemCollection();

            actionItems.Add(new DesignerActionHeaderItem("Appearance"));
            actionItems.Add(new DesignerActionPropertyItem("PanelBackStyle", "Back style", "Appearance"));
            actionItems.Add(new DesignerActionPropertyItem("TransparentBackground", "Transparent background", "Appearance"));

            actionItems.Add(new DesignerActionHeaderItem("Visuals"));
            actionItems.Add(new DesignerActionPropertyItem("PaletteMode", "Palette", "Visuals"));

            actionItems.Add(new DesignerActionMethodItem(this, "AddTab", "Add tab", "Actions", true));
            actionItems.Add(new DesignerActionMethodItem(this, "RemoveTab", "Remove tab", "Actions", true));

            actionItems.Add(new DesignerActionMethodItem(this, "ToggleDockStyle", GetDockStyleText()));

            return actionItems;
        }

        private string GetDockStyleText()
        {
            if (this.KryptonTabControl.Dock == DockStyle.Fill)
                return "Undock in parent container";
            else
                return "Dock in parent container";
        }

        private void SetProperty(string propertyName, object value)
        {
            PropertyDescriptor property = TypeDescriptor.GetProperties(this.KryptonTabControl)[propertyName];
            property.SetValue(this.KryptonTabControl, value);
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

        private KryptonTabControlAlternative KryptonTabControl
        {
            get { return (KryptonTabControlAlternative)this.Component; }
        }

    }

}