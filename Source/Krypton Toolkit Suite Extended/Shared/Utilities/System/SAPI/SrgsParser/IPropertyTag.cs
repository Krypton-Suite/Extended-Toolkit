namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsParser
{
    internal interface IPropertyTag : IElement
    {
        void NameValue(IElement parent, string name, object value);
    }
}