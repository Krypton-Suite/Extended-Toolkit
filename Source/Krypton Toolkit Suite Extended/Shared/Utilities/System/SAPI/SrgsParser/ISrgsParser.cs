namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsParser
{
    internal interface ISrgsParser
    {
        IElementFactory ElementFactory
        {
            set;
        }

        void Parse();
    }
}