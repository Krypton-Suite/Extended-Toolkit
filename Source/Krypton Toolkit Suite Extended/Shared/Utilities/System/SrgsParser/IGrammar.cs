using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;
using System;
using System.Collections.ObjectModel;
using System.Globalization;

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