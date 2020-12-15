using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms.Design;
using System.Windows.Forms.Design.Behavior;

namespace System.ComponentModel.Design
{
    internal static class ComponentDesignerExtension
    {
        public const System.Reflection.BindingFlags AllInstBind = System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance;

        public static object EditValue(this ComponentDesigner designer, object objectToChange, string propName)
        {
            PropertyDescriptor prop = TypeDescriptor.GetProperties(objectToChange)[propName];
            EditorServiceContext context = new EditorServiceContext(designer, prop);
            var editor = prop.GetEditor(typeof(System.Drawing.Design.UITypeEditor)) as System.Drawing.Design.UITypeEditor;
            object curVal = prop.GetValue(objectToChange);
            object newVal = editor.EditValue(context, context, curVal);
            if (newVal != curVal)
                try { prop.SetValue(objectToChange, newVal); }
                catch (CheckoutException) { }
            return newVal;
        }

        public static List<DesignerActionItem> GetAllAttributedActionItems(this DesignerActionList actionList)
        {
            var fullAIList = new List<DesignerActionItem>();
            foreach (var mbr in actionList.GetType().GetMethods(AllInstBind))
            {
                foreach (IActionGetItem attr in mbr.GetCustomAttributes(typeof(DesignerActionMethodAttribute), false))
                {
                    if (mbr.ReturnType == typeof(void) && mbr.GetParameters().Length == 0)
                        fullAIList.Add(attr.GetItem(actionList, mbr));
                    else
                        throw new FormatException("DesignerActionMethodAttribute must be applied to a method returning void and having no parameters.");
                }
            }
            foreach (var mbr in actionList.GetType().GetProperties(AllInstBind))
            {
                foreach (IActionGetItem attr in mbr.GetCustomAttributes(typeof(DesignerActionPropertyAttribute), false))
                    fullAIList.Add(attr.GetItem(actionList, mbr));
            }
            fullAIList.Sort(CompareItems);
            return fullAIList;
        }

        public static DesignerVerbCollection GetAttributedVerbs(this ComponentDesigner designer)
        {
            var verbs = new DesignerVerbCollection();
            foreach (var m in designer.GetType().GetMethods(AllInstBind))
            {
                foreach (DesignerVerbAttribute attr in m.GetCustomAttributes(typeof(DesignerVerbAttribute), true))
                {
                    verbs.Add(attr.GetDesignerVerb(designer, m));
                }
            }
            return verbs;
        }

        public static DesignerActionItemCollection GetFilteredActionItems(this DesignerActionList actionList, List<DesignerActionItem> fullAIList)
        {
            DesignerActionItemCollection col = new DesignerActionItemCollection();
            fullAIList.ForEach(ai => { if (CheckCondition(actionList, ai)) { col.Add(ai); } });

            // Add header items for displayed items
            int i = 0; string cat = null;
            while (i < col.Count)
            {
                string curCat = col[i].Category;
                if (string.Compare(curCat, cat, true, Globalization.CultureInfo.CurrentCulture) != 0)
                {
                    col.Insert(i++, new DesignerActionHeaderItem(curCat));
                    cat = curCat;
                }
                i++;
            }

            return col;
        }

        public static IDictionary<string, List<Attribute>> GetRedirectedProperties(this ComponentDesigner d)
        {
            var ret = new Dictionary<string, List<Attribute>>();
            foreach (var prop in d.GetType().GetProperties(AllInstBind))
            {
                foreach (RedirectedDesignerPropertyAttribute attr in prop.GetCustomAttributes(typeof(RedirectedDesignerPropertyAttribute), false))
                {
                    List<Attribute> attributes;
                    if (attr.ApplyOtherAttributes)
                    {
                        attributes = new List<Attribute>(Array.ConvertAll<object, Attribute>(prop.GetCustomAttributes(false), o => o as System.Attribute));
                        attributes.RemoveAll(a => a is RedirectedDesignerPropertyAttribute);
                    }
                    else
                        attributes = new List<Attribute>();
                    ret.Add(prop.Name, attributes);
                }
            }
            return ret;
        }

        public static void RedirectRegisteredProperties(this ComponentDesigner d, System.Collections.IDictionary properties, IDictionary<string, List<Attribute>> redirectedProps)
        {
            foreach (var propName in redirectedProps.Keys)
            {
                PropertyDescriptor oldPropertyDescriptor = (PropertyDescriptor)properties[propName];
                if (oldPropertyDescriptor != null)
                {
                    List<Attribute> attributes = redirectedProps[propName];
                    properties[propName] = TypeDescriptor.CreateProperty(d.GetType(), oldPropertyDescriptor, attributes.ToArray());
                }
            }
        }

        [Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "d")]
        public static void RemoveProperties(this ComponentDesigner d, System.Collections.IDictionary properties, IEnumerable<string> propertiesToRemove)
        {
            foreach (string p in propertiesToRemove)
                if (properties.Contains(p))
                    properties.Remove(p);
        }

        public static void SetComponentProperty<T>(this ComponentDesigner d, string propName, T value)
        {
            PropertyDescriptor propDesc = TypeDescriptor.GetProperties(d.Component)[propName];
            if (propDesc != null && propDesc.PropertyType == typeof(T) && !propDesc.IsReadOnly && propDesc.IsBrowsable)
                propDesc.SetValue(d.Component, value);
        }

        public static System.Windows.Forms.DialogResult ShowDialog(this ComponentDesigner designer, System.Windows.Forms.Form dialog)
        {
            EditorServiceContext context = new EditorServiceContext(designer);
            return context.ShowDialog(dialog);
        }

        private static bool CheckCondition(DesignerActionList actionList, DesignerActionItem ai)
        {
            if (ai.Properties["Condition"] != null)
            {
                var p = actionList.GetType().GetProperty((string)ai.Properties["Condition"], AllInstBind, null, typeof(bool), Type.EmptyTypes, null);
                if (p != null)
                    return (bool)p.GetValue(actionList, null);
            }
            return true;
        }

        private static int CompareItems(DesignerActionItem a, DesignerActionItem b)
        {
            int c = string.Compare(a.Category ?? string.Empty, b.Category ?? string.Empty, true, Globalization.CultureInfo.CurrentCulture);
            if (c != 0)
                return c;
            c = (int)a.Properties["Order"] - (int)b.Properties["Order"];
            if (c != 0)
                return c;
            return string.Compare(a.DisplayName, b.DisplayName, true, Globalization.CultureInfo.CurrentCulture);
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    internal sealed class RedirectedDesignerPropertyAttribute : System.Attribute
    {
        public RedirectedDesignerPropertyAttribute() { ApplyOtherAttributes = true; }

        public bool ApplyOtherAttributes { get; set; }
    }
}

namespace System.Windows.Forms.Design
{
    internal interface IActionGetItem
    {
        string Category { get; }

        DesignerActionItem GetItem(DesignerActionList actions, Reflection.MemberInfo mbr);
    }

    [System.AttributeUsage(System.AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    internal sealed class DesignerActionMethodAttribute : System.Attribute, IActionGetItem
    {
        public DesignerActionMethodAttribute(string displayName, int displayOrder = 0)
        {
            DisplayName = displayName;
            DisplayOrder = displayOrder;
        }

        public bool AllowAssociate { get; set; }

        public string Category { get; set; }

        public string Condition { get; set; }

        public string Description { get; set; }

        public string DisplayName { get; }

        public int DisplayOrder { get; }

        public bool IncludeAsDesignerVerb { get; set; }

        DesignerActionItem IActionGetItem.GetItem(DesignerActionList actions, Reflection.MemberInfo mbr)
        {
            var ret = new DesignerActionMethodItem(actions, mbr.Name, DisplayName, Category, Description, IncludeAsDesignerVerb)
            { AllowAssociate = AllowAssociate };
            if (!string.IsNullOrEmpty(Condition))
                ret.Properties.Add("Condition", Condition);
            ret.Properties.Add("Order", DisplayOrder);
            return ret;
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    internal sealed class DesignerActionPropertyAttribute : System.Attribute, IActionGetItem
    {
        public DesignerActionPropertyAttribute(string displayName, int displayOrder = 0)
        {
            DisplayName = displayName;
            DisplayOrder = displayOrder;
        }

        public bool AllowAssociate { get; set; }

        public string Category { get; set; }

        public string Condition { get; set; }

        public string Description { get; set; }

        public string DisplayName { get; }

        public int DisplayOrder { get; }

        DesignerActionItem IActionGetItem.GetItem(DesignerActionList actions, Reflection.MemberInfo mbr)
        {
            var ret = new DesignerActionPropertyItem(mbr.Name, DisplayName, Category, Description)
            { AllowAssociate = AllowAssociate };
            if (!string.IsNullOrEmpty(Condition))
                ret.Properties.Add("Condition", Condition);
            ret.Properties.Add("Order", DisplayOrder);
            return ret;
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    internal sealed class DesignerVerbAttribute : System.Attribute
    {
        private CommandID cmdId;
        private string menuText;

        public DesignerVerbAttribute(string menuText)
        {
            this.menuText = menuText;
        }

        public DesignerVerbAttribute(string menuText, Guid commandMenuGroup, int commandId)
        {
            this.menuText = menuText;
            cmdId = new CommandID(commandMenuGroup, commandId);
        }

        internal DesignerVerb GetDesignerVerb(object obj, Reflection.MethodInfo mi)
        {
            EventHandler handler = (EventHandler)Delegate.CreateDelegate(typeof(EventHandler), obj, mi);
            if (cmdId != null)
                return new DesignerVerb(menuText, handler, cmdId);
            return new DesignerVerb(menuText, handler);
        }
    }

    internal class EditorServiceContext : IWindowsFormsEditorService, ITypeDescriptorContext, IServiceProvider
    {
        private IComponentChangeService _componentChangeSvc;
        private ComponentDesigner _designer;
        private PropertyDescriptor _targetProperty;

        internal EditorServiceContext(ComponentDesigner designer)
        {
            _designer = designer;
        }

        internal EditorServiceContext(ComponentDesigner designer, PropertyDescriptor prop)
        {
            _designer = designer;
            _targetProperty = prop;
            if (prop == null)
            {
                prop = TypeDescriptor.GetDefaultProperty(designer.Component);
                if ((prop != null) && typeof(System.Collections.ICollection).IsAssignableFrom(prop.PropertyType))
                    _targetProperty = prop;
            }
        }

        internal EditorServiceContext(ComponentDesigner designer, PropertyDescriptor prop, string newVerbText)
            : this(designer, prop)
        {
            _designer.Verbs.Add(new DesignerVerb(newVerbText, new EventHandler(OnEditItems)));
        }

        private T GetService<T>() => (T)((IServiceProvider)this).GetService(typeof(T));

        private void OnEditItems(object sender, EventArgs e)
        {
            object component = _targetProperty.GetValue(_designer.Component);
            if (component != null)
            {
                CollectionEditor editor = TypeDescriptor.GetEditor(component, typeof(System.Drawing.Design.UITypeEditor)) as CollectionEditor;
                if (editor != null)
                    editor.EditValue(this, this, component);
            }
        }

        void ITypeDescriptorContext.OnComponentChanged()
        {
            ChangeService.OnComponentChanged(_designer.Component, _targetProperty, null, null);
        }

        bool ITypeDescriptorContext.OnComponentChanging()
        {
            try
            {
                ChangeService.OnComponentChanging(_designer.Component, _targetProperty);
            }
            catch (CheckoutException exception)
            {
                if (exception != CheckoutException.Canceled)
                    throw;
                return false;
            }
            return true;
        }

        object IServiceProvider.GetService(Type serviceType)
        {
            if ((serviceType == typeof(ITypeDescriptorContext)) || (serviceType == typeof(IWindowsFormsEditorService)))
                return this;
            if ((_designer.Component != null) && (_designer.Component.Site != null))
                return _designer.Component.Site.GetService(serviceType);
            return null;
        }

        void IWindowsFormsEditorService.CloseDropDown()
        {
        }

        void IWindowsFormsEditorService.DropDownControl(Control control)
        {
        }

        public DialogResult ShowDialog(Form dialog)
        {
            if (dialog == null)
                throw new ArgumentNullException(nameof(dialog));
            IUIService service = GetService<IUIService>();
            if (service != null)
                return service.ShowDialog(dialog);
            return dialog.ShowDialog(_designer.Component as IWin32Window);
        }

        private IComponentChangeService ChangeService
        {
            get
            {
                if (_componentChangeSvc == null)
                    _componentChangeSvc = GetService<IComponentChangeService>();
                return _componentChangeSvc;
            }
        }

        IContainer ITypeDescriptorContext.Container
        {
            get
            {
                if (_designer.Component.Site != null)
                    return _designer.Component.Site.Container;
                return null;
            }
        }

        object ITypeDescriptorContext.Instance => _designer.Component;

        PropertyDescriptor ITypeDescriptorContext.PropertyDescriptor => _targetProperty;
    }

    internal abstract class RichBehavior<D> : Behavior.Behavior where D : ControlDesigner
    {
        public RichBehavior(D designer)
        {
            Designer = designer;
        }

        public D Designer { get; }
    }

    internal class RichComponentDesigner<C, A> : ComponentDesigner
        where C : Component
        where A : _BaseDesignerActionList
    {
        private A actions;
        private Adorner adorner;
        private IDictionary<string, List<Attribute>> redirectedProps;
        private DesignerVerbCollection verbs;

        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (actions == null)
                    actions = Activator.CreateInstance(typeof(A), this, Component) as A;
                return new DesignerActionListCollection(new DesignerActionList[] { actions });
            }
        }

        public BehaviorService BehaviorService { get; private set; }

        public IComponentChangeService ComponentChangeService { get; private set; }

        public new C Component => (C)base.Component;

        public virtual GlyphCollection Glyphs => Adorner.Glyphs;

        public ISelectionService SelectionService { get; private set; }

        public override DesignerVerbCollection Verbs
        {
            get
            {
                if (verbs == null)
                    verbs = this.GetAttributedVerbs();
                return verbs;
            }
        }

        internal Adorner Adorner
        {
            get
            {
                if (adorner == null)
                {
                    adorner = new Adorner();
                    BehaviorService.Adorners.Add(adorner);
                }
                return adorner;
            }
        }

        protected virtual IEnumerable<string> PropertiesToRemove => new string[0];

        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            BehaviorService = GetService<BehaviorService>();
            SelectionService = GetService<ISelectionService>();
            if (SelectionService != null)
                SelectionService.SelectionChanged += OnSelectionChanged;
            ComponentChangeService = GetService<IComponentChangeService>();
            if (ComponentChangeService != null)
                ComponentChangeService.ComponentChanged += OnComponentChanged;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (BehaviorService != null & adorner != null)
                    BehaviorService.Adorners.Remove(adorner);
                ISelectionService ss = SelectionService;
                if (ss != null)
                    ss.SelectionChanged -= OnSelectionChanged;
                IComponentChangeService cs = ComponentChangeService;
                if (cs != null)
                    cs.ComponentChanged -= OnComponentChanged;
            }
            base.Dispose(disposing);
        }

        protected virtual S GetService<S>() where S : class => (S)GetService(typeof(S));

        protected virtual void OnComponentChanged(object sender, ComponentChangedEventArgs e)
        {
        }

        protected virtual void OnSelectionChanged(object sender, EventArgs e)
        {
        }

        protected override void PreFilterProperties(System.Collections.IDictionary properties)
        {
            base.PreFilterProperties(properties);

            // RedirectRegisteredProperties
            if (redirectedProps == null)
                redirectedProps = this.GetRedirectedProperties();
            this.RedirectRegisteredProperties(properties, redirectedProps);

            // Remove properties
            this.RemoveProperties(properties, PropertiesToRemove);
        }
    }

    internal class RichControlDesigner<C, A> : ControlDesigner
        where C : Control
        where A : _BaseDesignerActionList
    {
        private A actions;
        private Adorner adorner;
        private IDictionary<string, List<Attribute>> redirectedProps;
        private DesignerVerbCollection verbs;

        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (actions == null)
                    actions = Activator.CreateInstance(typeof(A), this, Component) as A;
                return new DesignerActionListCollection(new DesignerActionList[] { actions });
            }
        }

        public new BehaviorService BehaviorService => base.BehaviorService;

        public IComponentChangeService ComponentChangeService { get; private set; }

        public new C Control => (C)base.Control;

        public virtual GlyphCollection Glyphs => Adorner.Glyphs;

        public ISelectionService SelectionService { get; private set; }

        public override DesignerVerbCollection Verbs
        {
            get
            {
                if (verbs == null)
                    verbs = this.GetAttributedVerbs();
                return verbs;
            }
        }

        internal Adorner Adorner
        {
            get
            {
                if (adorner == null)
                {
                    adorner = new Adorner();
                    BehaviorService.Adorners.Add(adorner);
                }
                return adorner;
            }
        }

        protected virtual IEnumerable<string> PropertiesToRemove => new string[0];

        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            SelectionService = GetService<ISelectionService>();
            if (SelectionService != null)
                SelectionService.SelectionChanged += OnSelectionChanged;
            ComponentChangeService = GetService<IComponentChangeService>();
            if (ComponentChangeService != null)
                ComponentChangeService.ComponentChanged += OnComponentChanged;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (BehaviorService != null)
                    BehaviorService.Adorners.Remove(adorner);
                ISelectionService ss = SelectionService;
                if (ss != null)
                    ss.SelectionChanged -= OnSelectionChanged;
                IComponentChangeService cs = ComponentChangeService;
                if (cs != null)
                    cs.ComponentChanged -= OnComponentChanged;
            }
            base.Dispose(disposing);
        }

        protected virtual S GetService<S>() where S : class => (S)GetService(typeof(S));

        protected virtual void OnComponentChanged(object sender, ComponentChangedEventArgs e)
        {
        }

        protected virtual void OnSelectionChanged(object sender, EventArgs e)
        {
        }

        protected override void PreFilterProperties(System.Collections.IDictionary properties)
        {
            base.PreFilterProperties(properties);

            // RedirectRegisteredProperties
            if (redirectedProps == null)
                redirectedProps = this.GetRedirectedProperties();
            this.RedirectRegisteredProperties(properties, redirectedProps);

            // Remove properties
            this.RemoveProperties(properties, PropertiesToRemove);
        }
    }

    internal abstract class _BaseDesignerActionList : DesignerActionList
    {
        private List<DesignerActionItem> fullAIList;

        public _BaseDesignerActionList(ComponentDesigner designer, IComponent component)
            : base(component)
        {
            base.AutoShow = true;
            ParentDesigner = designer;
        }

        public ComponentDesigner ParentDesigner { get; }

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            // Retrieve all attributed methods and properties
            if (fullAIList == null)
                fullAIList = this.GetAllAttributedActionItems();

            // Filter for conditions and load
            return this.GetFilteredActionItems(fullAIList);
        }

        protected T GetComponentProperty<T>(string propName)
        {
            var p = ComponentProp(propName, typeof(T));
            if (p != null)
                return (T)p.GetValue(Component, null);
            return default(T);
        }

        protected void SetComponentProperty<T>(string propName, T value)
        {
            var p = ComponentProp(propName, typeof(T));
            if (p != null)
                p.SetValue(Component, value, null);
        }

        private Reflection.PropertyInfo ComponentProp(string propName, Type retType) => Component.GetType().GetProperty(propName, ComponentDesignerExtension.AllInstBind, null, retType, Type.EmptyTypes, null);
    }

    internal abstract class RichDesignerActionList<D, C> : _BaseDesignerActionList where D : ComponentDesigner where C : Component
    {
        public RichDesignerActionList(D designer, C component) : base(designer, component)
        {
            ParentDesigner = designer;
        }

        public new C Component => (C)base.Component;

        public new D ParentDesigner { get; }
    }

    internal abstract class RichGlyph<D> : Glyph, IDisposable where D : ControlDesigner
    {
        public RichGlyph(D designer, Behavior.Behavior behavior)
            : base(behavior)
        {
            Designer = designer;
        }

        public D Designer { get; }

        public virtual void Dispose()
        {
        }

        public void SetBehavior(RichBehavior<D> b) { base.SetBehavior(b); }
    }

    internal class RichParentControlDesigner<C, A> : ParentControlDesigner
        where C : Control
        where A : _BaseDesignerActionList
    {
        private A actions;
        private Adorner adorner;
        private IDictionary<string, List<Attribute>> redirectedProps;
        private DesignerVerbCollection verbs;

        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (actions == null)
                    actions = Activator.CreateInstance(typeof(A), this, Component) as A;
                return new DesignerActionListCollection(new DesignerActionList[] { actions });
            }
        }

        public new BehaviorService BehaviorService => base.BehaviorService;

        public IComponentChangeService ComponentChangeService { get; private set; }

        public new C Control => (C)base.Control;

        public virtual GlyphCollection Glyphs => Adorner.Glyphs;

        public ISelectionService SelectionService { get; private set; }

        public override DesignerVerbCollection Verbs
        {
            get
            {
                if (verbs == null)
                    verbs = this.GetAttributedVerbs();
                return verbs;
            }
        }

        internal Adorner Adorner
        {
            get
            {
                if (adorner == null)
                {
                    adorner = new Adorner();
                    BehaviorService.Adorners.Add(adorner);
                }
                return adorner;
            }
        }

        protected virtual IEnumerable<string> PropertiesToRemove => new string[0];

        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            SelectionService = GetService<ISelectionService>();
            if (SelectionService != null)
                SelectionService.SelectionChanged += OnSelectionChanged;
            ComponentChangeService = GetService<IComponentChangeService>();
            if (ComponentChangeService != null)
                ComponentChangeService.ComponentChanged += OnComponentChanged;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (BehaviorService != null & adorner != null)
                    BehaviorService.Adorners.Remove(adorner);
                ISelectionService ss = SelectionService;
                if (ss != null)
                    ss.SelectionChanged -= OnSelectionChanged;
                IComponentChangeService cs = ComponentChangeService;
                if (cs != null)
                    cs.ComponentChanged -= OnComponentChanged;
            }
            base.Dispose(disposing);
        }

        protected virtual S GetService<S>() where S : class => (S)GetService(typeof(S));

        protected virtual void OnComponentChanged(object sender, ComponentChangedEventArgs e)
        {
        }

        protected virtual void OnSelectionChanged(object sender, EventArgs e)
        {
        }

        protected override void PreFilterProperties(System.Collections.IDictionary properties)
        {
            base.PreFilterProperties(properties);

            // RedirectRegisteredProperties
            if (redirectedProps == null)
                redirectedProps = this.GetRedirectedProperties();
            this.RedirectRegisteredProperties(properties, redirectedProps);

            // Remove properties
            this.RemoveProperties(properties, PropertiesToRemove);
        }
    }
}