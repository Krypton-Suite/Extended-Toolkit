using System.ComponentModel;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    public class FCTBTypeDescriptor : CustomTypeDescriptor
    {
        ICustomTypeDescriptor parent;
        object instance;

        public FCTBTypeDescriptor(ICustomTypeDescriptor parent, object instance)
            : base(parent)
        {
            this.parent = parent;
            this.instance = instance;
        }

        public override string GetComponentName()
        {
            var ctrl = (instance as Control);
            return ctrl == null ? null : ctrl.Name;
        }

        public override EventDescriptorCollection GetEvents()
        {
            var coll = base.GetEvents();
            var list = new EventDescriptor[coll.Count];

            for (int i = 0; i < coll.Count; i++)
                if (coll[i].Name == "TextChanged")//instead of TextChanged slip BindingTextChanged for binding
                    list[i] = new FooTextChangedDescriptor(coll[i]);
                else
                    list[i] = coll[i];

            return new EventDescriptorCollection(list);
        }
    }
}