#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public static class Style
    {
        public static IStyle Black => new Black();
        public static IStyle Blue1 => new Blue1();
        public static IStyle Blue2 => new Blue2();
        public static IStyle Blue3 => new Blue3();
        public static IStyle Burgundy => new Burgundy();
        public static IStyle Control => new ScottPlot.Control();
        public static IStyle Default => new Default();
        public static IStyle Gray1 => new Gray1();
        public static IStyle Gray2 => new Gray2();
        public static IStyle Hazel => new Hazel();
        public static IStyle Light1 => new Light1();
        public static IStyle Light2 => new Light2();
        public static IStyle Monospace => new Monospace();
        public static IStyle Pink => new Pink();
        public static IStyle Seaborn => new Seaborn();

        /// <summary>
        /// Return an array containing every available style
        /// </summary>
        public static IStyle[] GetStyles()
        {
            return Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => x.IsClass)
                .Where(x => !x.IsAbstract)
                .Where(x => x.GetInterfaces().Contains(typeof(IStyle)))
                .Select(x => (IStyle)FormatterServices.GetUninitializedObject(x))
                .ToArray();
        }
    }

}