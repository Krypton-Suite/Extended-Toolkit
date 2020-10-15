namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsParser
{
    internal interface IToken : IElement
    {
        string Text
        {
            set;
        }

        string Display
        {
            set;
        }

        string Pronunciation
        {
            set;
        }
    }
}