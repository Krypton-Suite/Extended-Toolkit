namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsParser
{
    internal interface ISemanticTag : IElement
    {
        void Content(IElement parent, string value, int line);
    }
}