namespace Krypton.Toolkit.Suite.Extended.Outlook.Grid
{
    /// <summary>
    /// Class for TextAndImage object
    /// </summary>
    public class TextAndImage : IComparable<TextAndImage>
    {
        /// <summary>
        /// The text
        /// </summary>
        public string Text;
        /// <summary>
        /// The image
        /// </summary>
        public Image Image;

        /// <summary>
        /// Constructor
        /// </summary>
        public TextAndImage()
        { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="img">The image.</param>
        public TextAndImage(string text, Image img)
        {
            Text = text;
            Image = img;
        }

        /// <summary>
        /// Overrides ToString
        /// </summary>
        /// <returns>String that represents TextAndImage</returns>
        public override string ToString()
        {
            return Text;
        }

        /// <summary>
        /// Overrides Equals
        /// </summary>
        /// <param name="obj">The object to compare</param>
        /// <returns>true if equal, false otherwise.</returns>
        public override bool Equals(object obj)
        {
            return Text.Equals(obj.ToString());
        }

        /// <summary>
        /// Overrides GetHashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Compares to.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns></returns>
        public int CompareTo(TextAndImage other)
        {
            return Text.CompareTo(other.Text);
        }
    }
}