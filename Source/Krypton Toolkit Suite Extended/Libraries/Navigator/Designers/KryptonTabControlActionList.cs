using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Navigator
{
    public class KryptonTabControlActionList : DesignerActionList
    {
        /* Simplify UI Development with Custom Designer Actions in Visual Studio
         * http://msdn.microsoft.com/en-us/magazine/cc163758.aspx
         */

        private IDesignerHost m_DesignerHost;
        private ISelectionService m_SelectionService;

        public KryptonTabControlActionList(IComponent component)
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

        private KryptonTabControlVersion2 KryptonTabControl
        {
            get { return (KryptonTabControlVersion2)this.Component; }
        }

    }
}