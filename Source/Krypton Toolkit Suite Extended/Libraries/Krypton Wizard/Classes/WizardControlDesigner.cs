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
using System.Security.Permissions;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Krypton.Toolkit.Suite.Extended.Wizard
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust"), EditorBrowsable(EditorBrowsableState.Never)]
    internal class WizardControlDesigner : RichParentControlDesigner<WizardControl, WizardControlDesignerActionList>, IToolboxUser
    {
        private static string[] propsToRemove = new string[] { "Anchor", "AutoScrollOffset", "AutoSize", "BackColour",
            "BackgroundImage", "BackgroundImageLayout", "ContextMenuStrip", "Cursor", "Dock", "Enabled", "Font",
            "ForeColour", /*"Location",*/ "Margin", "MaximumSize", "MinimumSize", "Padding", /*"Size",*/ "TabStop",
            "Text", "UseWaitCursor" };

        private bool forwardOnDrag;

        public override System.Collections.ICollection AssociatedComponents => Control?.Pages ?? base.AssociatedComponents;

        public override SelectionRules SelectionRules => SelectionRules.Visible | SelectionRules.Locked;

        protected IDesignerHost DesignerHost => GetService<IDesignerHost>();

        protected override bool EnableDragRect => false;

        public override bool CanBeParentedTo(IDesigner parentDesigner) => parentDesigner?.Component is Form;

        public override bool CanParent(Control control) => control is WizardPage && !Control.Contains(control);

        public bool GetToolSupported(ToolboxItem tool) => tool.TypeName != typeof(WizardControl).FullName && Control?.SelectedPage != null;

        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            AutoResizeHandles = true;
            var wc = Control;
            if (wc == null) return;
            wc.SelectedPageChanged += WizardControl_SelectedPageChanged;
            //wc.GotFocus += WizardControl_OnGotFocus;
            wc.ControlAdded += WizardControl_OnControlAdded;
        }

        public override void InitializeNewComponent(System.Collections.IDictionary defaultValues)
        {
            base.InitializeNewComponent(defaultValues);
            Control.Text = Properties.Resources.WizardTitle;
        }

        public void ToolPicked(ToolboxItem tool)
        {
            if (tool.TypeName == "AeroWizard.WizardPage")
                InsertPageIntoWizard(true);
            if (Control?.SelectedPage != null)
                AddControlToActivePage(tool.TypeName);
        }

        internal void InsertPageIntoWizard(bool add)
        {
            var h = DesignerHost;
            var wiz = Control;
            DesignerTransaction dt = null;
            try
            {
                dt = h.CreateTransaction("Insert Wizard Page");
                var page = (WizardPage)h.CreateComponent(typeof(WizardPage));
                MemberDescriptor member = TypeDescriptor.GetProperties(wiz)["Pages"];
                RaiseComponentChanging(member);

                //Add a new page to the collection
                if (wiz.Pages.Count == 0 || add)
                    wiz.Pages.Add(page);
                else
                    wiz.Pages.Insert(wiz.SelectedPageIndex, page);

                RaiseComponentChanged(member, null, null);
            }
            finally
            {
                dt?.Commit();
            }
            RefreshDesigner();
        }

        internal void RefreshDesigner()
        {
            var das = GetService<DesignerActionUIService>();
            das?.Refresh(Control);
        }

        internal void RemovePageFromWizard(WizardPage page)
        {
            var h = DesignerHost;
            var c = ComponentChangeService;
            if (h == null || c == null)
                throw new ArgumentException("Both IDesignerHost and IComponentChangeService arguments cannot be null.");

            if (Control == null || !Control.Pages.Contains(page))
                return;

            DesignerTransaction dt = null;
            try
            {
                dt = h.CreateTransaction("Remove Wizard Page");

                MemberDescriptor member = TypeDescriptor.GetProperties(Control)["Pages"];
                RaiseComponentChanging(member);

                if (page.Owner != null)
                {
                    //c.OnComponentChanging(page.Owner, null);
                    page.Owner.Pages.Remove(page);
                    //c.OnComponentChanged(page.Owner, null, null, null);
                    h.DestroyComponent(page);
                }
                else
                {
                    //c.OnComponentChanging(page, null);
                    page.Dispose();
                    //c.OnComponentChanged(page, null, null, null);
                }
                RaiseComponentChanged(member, null, null);
            }
            finally
            {
                dt?.Commit();
            }
            RefreshDesigner();
        }

        protected override IComponent[] CreateToolCore(ToolboxItem tool, int x, int y, int width, int height, bool hasLocation, bool hasSize)
        {
            var pageDes = GetSelectedWizardPageDesigner();
            if (pageDes != null)
                InvokeCreateTool(pageDes, tool);
            return null;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Control.SelectedPageChanged -= WizardControl_SelectedPageChanged;
                var ss = SelectionService;
                if (ss != null)
                    ss.SelectionChanged -= OnSelectionChanged;
            }

            base.Dispose(disposing);
        }

        protected override bool GetHitTest(Point point)
        {
            if (Control.nextButton.ClientRectangle.Contains(Control.nextButton.PointToClient(point)))
                return true;
            return Control.backButton.ClientRectangle.Contains(Control.backButton.PointToClient(point));
        }

        protected override void OnDragDrop(DragEventArgs de)
        {
            if (forwardOnDrag)
            {
                var wizPageDesigner = GetSelectedWizardPageDesigner();
                wizPageDesigner?.OnDragDropInternal(de);
            }
            else
            {
                base.OnDragDrop(de);
            }
            forwardOnDrag = false;
        }

        protected override void OnDragEnter(DragEventArgs de)
        {
            forwardOnDrag = true;
            var wizPageDesigner = GetSelectedWizardPageDesigner();
            wizPageDesigner?.OnDragEnterInternal(de);
        }

        protected override void OnDragLeave(EventArgs e)
        {
            if (forwardOnDrag)
            {
                var wizPageDesigner = GetSelectedWizardPageDesigner();
                wizPageDesigner?.OnDragLeaveInternal(e);
            }
            else
            {
                base.OnDragLeave(e);
            }
            forwardOnDrag = false;
        }

        protected override void OnDragOver(DragEventArgs de)
        {
            if (forwardOnDrag)
            {
                var control = Control;
                var pt = control.PointToClient(new Point(de.X, de.Y));
                if (!control.DisplayRectangle.Contains(pt))
                {
                    de.Effect = DragDropEffects.None;
                }
                else
                {
                    var wizPageDesigner = GetSelectedWizardPageDesigner();
                    wizPageDesigner?.OnDragOverInternal(de);
                }
            }
            else
            {
                base.OnDragOver(de);
            }
        }

        protected override void OnGiveFeedback(GiveFeedbackEventArgs e)
        {
            if (forwardOnDrag)
            {
                var wizPageDesigner = GetSelectedWizardPageDesigner();
                wizPageDesigner?.OnGiveFeedbackInternal(e);
            }
            else
            {
                base.OnGiveFeedback(e);
            }
        }

        private void AddControlToActivePage(string typeName)
        {
            var dt = DesignerHost?.CreateTransaction("Add Control");
            var comp = DesignerHost?.CreateComponent(Type.GetType(typeName, false));
            if (comp != null)
            {
                var c = GetService<IComponentChangeService>();
                c.OnComponentChanging(Control.SelectedPage, null);
                Control.SelectedPage?.Container?.Add(comp);
                c.OnComponentChanged(Control.SelectedPage, null, null, null);
            }
            dt?.Commit();
        }

        private void CheckStatus()
        {
            Verbs[1].Enabled = Control != null && Control.Pages.Count > 0;
            Verbs[2].Enabled = Control?.SelectedPage != null;
        }

        private WizardPageDesigner GetSelectedWizardPageDesigner()
        {
            if (Control.SelectedPage == null) return null;
            return DesignerHost?.GetDesigner(Control.SelectedPage) as WizardPageDesigner;
        }

        [DesignerVerb("Add Page")]
        private void HandleAddPage(object sender, EventArgs e)
        {
            InsertPageIntoWizard(true);
            OnSelectionChanged(sender, e);
        }

        [DesignerVerb("Insert Page")]
        private void HandleInsertPage(object sender, EventArgs e)
        {
            InsertPageIntoWizard(false);
        }

        [DesignerVerb("Remove Page")]
        private void HandleRemovePage(object sender, EventArgs e)
        {
            if (Control?.SelectedPage == null) return;
            RemovePageFromWizard(Control.SelectedPage);
            OnSelectionChanged(sender, e);
        }

        protected override void OnComponentChanged(object sender, ComponentChangedEventArgs e)
        {
            CheckStatus();
        }

        protected override void OnSelectionChanged(object sender, EventArgs e)
        {
            if (!(SelectionService.PrimarySelection is WizardControl))
            {
                var p = SelectionService.PrimarySelection as WizardPage;
                if (p == null && SelectionService.PrimarySelection is Control)
                    p = ((Control)SelectionService.PrimarySelection).GetParent<WizardPage>();
                if (p != null && Control.SelectedPage != p)
                {
                    Control.SelectedPage = p;
                }
            }

            RefreshDesigner();
        }

        private void SelectComponent(Component p)
        {
            if (SelectionService == null) return;
            SelectionService.SetSelectedComponents(new object[] { Control }, SelectionTypes.Primary);
            if (p?.Site != null)
                SelectionService.SetSelectedComponents(new object[] { p });
            RefreshDesigner();
        }

        /*private void WizardControl_OnGotFocus(object sender, EventArgs e)
		{
			IEventHandlerService service = (IEventHandlerService)this.GetService(typeof(IEventHandlerService));
			if (service != null)
			{
				Control focusWindow = service.FocusWindow;
				if (focusWindow != null)
				{
					focusWindow.Focus();
				}
			}
		}*/

        private void WizardControl_OnControlAdded(object sender, ControlEventArgs e)
        {
            /*if ((e.Control != null) && !e.Control.IsHandleCreated)
			{
				var handle = e.Control.Handle;
			}*/
        }

        private void WizardControl_SelectedPageChanged(object sender, EventArgs e)
        {
            SelectComponent(Control.SelectedPage);
        }
    }

    internal class WizardControlDesignerActionList : RichDesignerActionList<WizardControlDesigner, WizardControl>
    {
        public WizardControlDesignerActionList(WizardControlDesigner wizDesigner, WizardControl control)
            : base(wizDesigner, control)
        {
        }

        [DesignerActionProperty("Go to page", 4, Condition = "HasPages")]
        public WizardPage GoToPage
        {
            get { return Component.SelectedPage; }
            set { if (value != null) Component.SelectedPage = value; }
        }

        [DesignerActionProperty("Edit pages...")]
        public WizardPageCollection Pages => Component?.Pages;

        private bool HasPages => Pages != null && Pages.Count > 0;

        [DesignerActionMethod("Add page", 1)]
        private void AddPage()
        {
            ParentDesigner.InsertPageIntoWizard(true);
        }

        [DesignerActionMethod("Insert page", 2, Condition = "HasPages")]
        private void InsertPage()
        {
            ParentDesigner.InsertPageIntoWizard(false);
        }
    }
}