using System;
using System.ComponentModel;

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    public class FooTextChangedDescriptor : EventDescriptor
    {
        public FooTextChangedDescriptor(MemberDescriptor desc)
           : base(desc)
        {
        }

        public override void AddEventHandler(object component, Delegate value)
        {
            (component as FastColouredTextBox).BindingTextChanged += value as EventHandler;
        }

        public override Type ComponentType
        {
            get { return typeof(FastColouredTextBox); }
        }

        public override Type EventType
        {
            get { return typeof(EventHandler); }
        }

        public override bool IsMulticast
        {
            get { return true; }
        }

        public override void RemoveEventHandler(object component, Delegate value)
        {
            (component as FastColouredTextBox).BindingTextChanged -= value as EventHandler;
        }
    }
}