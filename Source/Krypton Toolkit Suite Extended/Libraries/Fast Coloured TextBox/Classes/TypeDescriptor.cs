using System;
using System.ComponentModel;

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    ///
    /// These classes are required for correct data binding to Text property of FastColoredTextbox
    /// 
    public class FCTBDescriptionProvider : TypeDescriptionProvider
    {
        public FCTBDescriptionProvider(Type type)
            : base(GetDefaultTypeProvider(type))
        {
        }

        private static TypeDescriptionProvider GetDefaultTypeProvider(Type type)
        {
            return TypeDescriptor.GetProvider(type);
        }



        public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance)
        {
            ICustomTypeDescriptor defaultDescriptor = base.GetTypeDescriptor(objectType, instance);
            return new FCTBTypeDescriptor(defaultDescriptor, instance);
        }
    }
}