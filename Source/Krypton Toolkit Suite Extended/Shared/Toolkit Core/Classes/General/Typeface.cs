using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public class Typeface
    {
        public Typeface()
        {

        }


        /// <summary>Gets the default typeface.</summary>
        /// <returns>Microsoft Sans Serif, 8.25</returns>
        public static Font GetDefaultTypeface() => new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
    }
}