using System;

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    /// <summary>
    /// This autocomplete item appears after dot
    /// </summary>
    public class MethodAutoCompleteItem : AutoCompleteItem
    {
        string firstPart;
        string lowercaseText;

        public MethodAutoCompleteItem(string text)
            : base(text)
        {
            lowercaseText = Text.ToLower();
        }

        public override CompareResult Compare(string fragmentText)
        {
            int i = fragmentText.LastIndexOf('.');
            if (i < 0)
                return CompareResult.HIDDEN;
            string lastPart = fragmentText.Substring(i + 1);
            firstPart = fragmentText.Substring(0, i);

            if (lastPart == "") return CompareResult.VISIBLE;
            if (Text.StartsWith(lastPart, StringComparison.InvariantCultureIgnoreCase))
                return CompareResult.VISIBLEANDSELECTED;
            if (lowercaseText.Contains(lastPart.ToLower()))
                return CompareResult.VISIBLE;

            return CompareResult.HIDDEN;
        }

        public override string GetTextForReplace()
        {
            return firstPart + "." + Text;
        }
    }
}