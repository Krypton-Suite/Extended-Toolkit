namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsCompiler
{
    internal abstract class ParseElement : IElement
    {
        internal int _confidence;

        internal Rule _rule;

        internal ParseElement(Rule rule)
        {
            _rule = rule;
        }

        void IElement.PostParse(IElement parent)
        {
        }
    }
}