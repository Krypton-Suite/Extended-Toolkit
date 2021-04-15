#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsParser;

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