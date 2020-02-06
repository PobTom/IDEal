using FastColoredTextBoxNS;

namespace Ideal
{
    //internal class PrjMethodAutocompleteItem : AutocompleteItem
    internal class PrjMethodAutocompleteItem : MethodAutocompleteItem
    {
        public PrjMethodAutocompleteItem(string text) : base(text)
        {
        }

        //public int ImageIndex { get; set; }

        public override CompareResult Compare(string fragmentText)
        {
            if (Text.StartsWith(fragmentText))
            {
                return CompareResult.Visible;
            }
            return CompareResult.Hidden;
        }
        public override string GetTextForReplace()
        {
            // don't change anything just return full line
            return Text;
        }
        //get
    }
}