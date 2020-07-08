namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsParser
{
    internal interface IScript : IElement
    {
        IScript Create(string rule, RuleMethodScript onInit);
    }
}