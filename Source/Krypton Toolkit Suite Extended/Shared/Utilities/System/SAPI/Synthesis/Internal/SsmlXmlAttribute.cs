namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis
{
    internal class SsmlXmlAttribute
    {
        internal string _prefix;

        internal string _name;

        internal string _value;

        internal string _ns;

        internal SsmlXmlAttribute(string prefix, string name, string value, string ns)
        {
            _prefix = prefix;
            _name = name;
            _value = value;
            _ns = ns;
        }
    }
}