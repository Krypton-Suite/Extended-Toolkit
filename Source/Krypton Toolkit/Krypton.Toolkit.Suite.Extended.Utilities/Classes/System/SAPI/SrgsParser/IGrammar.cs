#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;
using Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsGrammar;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsParser
{
    internal interface IGrammar : IElement
    {
        string Root
        {
            get;
            set;
        }

        SrgsTagFormat TagFormat
        {
            get;
            set;
        }

        Collection<string> GlobalTags
        {
            get;
            set;
        }

        GrammarType Mode
        {
            set;
        }

        CultureInfo Culture
        {
            set;
        }

        Uri XmlBase
        {
            set;
        }

        AlphabetType PhoneticAlphabet
        {
            set;
        }

        string Language
        {
            get;
            set;
        }

        string Namespace
        {
            get;
            set;
        }

        bool Debug
        {
            set;
        }

        Collection<string> CodeBehind
        {
            get;
            set;
        }

        Collection<string> ImportNamespaces
        {
            get;
            set;
        }

        Collection<string> AssemblyReferences
        {
            get;
            set;
        }

        IRule CreateRule(string id, RulePublic publicRule, RuleDynamic dynamic, bool hasSCript);
    }
}