namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsParser
{
    internal interface IRule : IElement
    {
        string BaseClass
        {
            get;
            set;
        }

        void CreateScript(IGrammar grammar, string rule, string method, RuleMethodScript type);
    }
}