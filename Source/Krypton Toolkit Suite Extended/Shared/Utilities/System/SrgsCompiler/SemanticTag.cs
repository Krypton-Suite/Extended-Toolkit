using System;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsCompiler
{
    internal sealed class SemanticTag : ParseElement, ISemanticTag, IElement
    {
        private CfgGrammar.CfgProperty _propInfo = new CfgGrammar.CfgProperty();

        internal SemanticTag(ParseElement parent, Backend backend)
            : base(parent._rule)
        {
        }

        void ISemanticTag.Content(IElement parentElement, string sTag, int iLine)
        {
            sTag = sTag.Trim(Helpers._achTrimChars);
            if (!string.IsNullOrEmpty(sTag))
            {
                _propInfo._ulId = (uint)iLine;
                _propInfo._comValue = sTag;
                ParseElementCollection parseElementCollection = (ParseElementCollection)parentElement;
                parseElementCollection.AddSemanticInterpretationTag(_propInfo);
            }
        }
    }
}