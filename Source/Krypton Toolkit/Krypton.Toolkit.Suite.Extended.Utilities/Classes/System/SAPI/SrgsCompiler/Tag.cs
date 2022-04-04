#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsCompiler
{
    internal sealed class Tag : IComparable<Tag>
    {
        internal CfgSemanticTag _cfgTag;

        internal Backend _be;

        internal Tag(Tag tag)
        {
            _be = tag._be;
            _cfgTag = tag._cfgTag;
        }

        internal Tag(Backend be, CfgSemanticTag cfgTag)
        {
            _be = be;
            _cfgTag = cfgTag;
        }

        internal Tag(Backend be, CfgGrammar.CfgProperty property)
        {
            _be = be;
            _cfgTag = new CfgSemanticTag(be.Symbols, property);
        }

        int IComparable<Tag>.CompareTo(Tag tag)
        {
            return (int)(_cfgTag.ArcIndex - tag._cfgTag.ArcIndex);
        }

        internal void Serialize(StreamMarshaler streamBuffer)
        {
            streamBuffer.WriteStream(_cfgTag);
        }
    }
}