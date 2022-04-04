#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Navi.Suite
{
    [ToolboxItemFilter("System.Windows.Forms", ToolboxItemFilterType.Custom)]
    public class NaviBarDesigner : ParentControlDesigner
    {
        #region Fields

        private NaviBar designingControl;
        private ISelectionService selectionService;
        private IComponentChangeService componentChangeService;
        private IDesignerHost host;

        #endregion

        #region Constructor
        #endregion

        #region Properties
        #endregion

        #region Methods

        /// <summary>
        /// Sets the value for a given property
        /// </summary>
        /// <param name="propName">The name of the property</param>
        /// <param name="value">The new value of the property</param>
        private void SetValue(string propName, object value)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(designingControl);
            PropertyDescriptor property = properties.Find(propName, true);
            if (property != null)
            {
                property.SetValue(designingControl, value);
            }
        }

        /// <summary>
        /// Gets the value of a given property
        /// </summary>
        /// <param name="propName">The name of the property</param>
        private object GetValue(string propName)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(designingControl);
            PropertyDescriptor property = properties.Find(propName, true);
            if (property != null)
            {
                return property.GetValue(designingControl);
            }
            else
            {
                return null;
            }
        }

        private void InitializeServices()
        {
            selectionService = GetService(typeof(ISelectionService)) as ISelectionService;
            if (selectionService != null)
            {
                selectionService.SelectionChanged += new System.EventHandler(selectionService_SelectionChanged);
            }

            componentChangeService = GetService(typeof(IComponentChangeService))
               as IComponentChangeService;
            if (componentChangeService != null)
            {
                //componentChangeService.ComponentChanged += new ComponentChangedEventHandler(componentChangeService_ComponentChanged);
            }

            host = (IDesignerHost)GetService(typeof(IDesignerHost));
        }

        private bool HandleClickEvent(int x, int y)
        {
            if (designingControl != null)
            {
                foreach (NaviBand band in designingControl.Bands)
                {
                    if ((band.Button != null)
                    && (band.Button.Bounds.Contains(x, y)))
                    {
                        ArrayList list = new ArrayList();
                        list.Add(band);
                        if (selectionService != null)
                        {
                            designingControl.SetActiveBand(
                                selectionService.PrimarySelection as NaviBand);
                            selectionService.SetSelectedComponents(list);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        #endregion

        #region Overrides

        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            designingControl = component as NaviBar;
            InitializeServices();
        }

        public override void InitializeNewComponent(System.Collections.IDictionary defaultValues)
        {
            base.InitializeNewComponent(defaultValues);
        }

        public override DesignerVerbCollection Verbs
        {
            get
            {
                DesignerVerb[] verbs = new DesignerVerb[] {
               new DesignerVerb("Add band..",
                  new EventHandler(AddBandVerbClicked)) };
                return new DesignerVerbCollection(verbs);
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (selectionService != null)
            {
                selectionService.SelectionChanged -= new System.EventHandler(selectionService_SelectionChanged);
            }
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case NativeMethods.WM_LBUTTONUP:
                    if (!HandleClickEvent(NativeMethods.LoWord(m.LParam),
                       NativeMethods.HiWord(m.LParam)))
                    {
                        base.WndProc(ref m);
                    }
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        #endregion

        #region Event Handling

        private void selectionService_SelectionChanged(object sender, EventArgs e)
        {
            if (selectionService.PrimarySelection is NaviBand)
            {
                designingControl.SetActiveBand(
                   selectionService.PrimarySelection as NaviBand);
                designingControl.PerformLayout();
            }
        }

        private void AddBandVerbClicked(object sender, EventArgs e)
        {
            NaviBand band = host.CreateComponent(typeof(NaviBand)) as NaviBand;
            if (band != null)
            {
                designingControl.Controls.Add(band);
            }
        }

        #endregion
    }
}