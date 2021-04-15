#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsParser;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.GrammarBuilding
{
    internal abstract class GrammarBuilderBase
    {
        private int _count = 1;

        private bool _marker;

        private BuilderElements _parent;

        internal virtual int Count
        {
            get
            {
                return _count;
            }
            set
            {
                _count = value;
            }
        }

        internal virtual bool Marked
        {
            get
            {
                return _marker;
            }
            set
            {
                _marker = value;
            }
        }

        internal virtual BuilderElements Parent
        {
            get
            {
                return _parent;
            }
            set
            {
                _parent = value;
            }
        }

        internal abstract string DebugSummary
        {
            get;
        }

        internal abstract GrammarBuilderBase Clone();

        internal abstract IElement CreateElement(IElementFactory elementFactory, IElement parent, IRule rule, IdentifierCollection ruleIds);

        internal virtual int CalcCount(BuilderElements parent)
        {
            Marked = false;
            Parent = parent;
            return Count;
        }
    }
}