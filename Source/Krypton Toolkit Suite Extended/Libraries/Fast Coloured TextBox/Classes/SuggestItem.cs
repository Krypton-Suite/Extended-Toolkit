namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    /// <summary>
    /// This Item does not check correspondence to current text fragment.
    /// SuggestItem is intended for dynamic menus.
    /// </summary>
    public class SuggestItem : AutoCompleteItem
    {
        public SuggestItem(string text, int imageIndex) : base(text, imageIndex)
        {
        }

        public override CompareResult Compare(string fragmentText)
        {
            return CompareResult.VISIBLE;
        }
    }
}