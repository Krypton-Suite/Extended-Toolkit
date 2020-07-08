using System.Collections.Generic;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.GrammarBuilding
{
    internal class IdentifierCollection
    {
        protected List<string> _identifiers;

        internal IdentifierCollection()
        {
            _identifiers = new List<string>();
            CreateNewIdentifier("_");
        }

        internal string CreateNewIdentifier(string id)
        {
            if (!_identifiers.Contains(id))
            {
                _identifiers.Add(id);
                return id;
            }
            int num = 1;
            string text;
            do
            {
                text = id + num;
                num++;
            }
            while (_identifiers.Contains(text));
            _identifiers.Add(text);
            return text;
        }
    }
}