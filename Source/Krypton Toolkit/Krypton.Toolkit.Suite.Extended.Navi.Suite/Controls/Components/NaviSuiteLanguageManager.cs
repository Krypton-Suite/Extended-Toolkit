#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Navi.Suite
{
    public class NaviSuiteLanguageManager : Component
    {
        #region Public

        /// <summary>Gets the navi suite strings.</summary>
        /// <value>The navi suite strings.</value>
        [Category(@"Visuals")]
        [Description(@"Collection of navi suite strings.")]
        [MergableProperty(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Localizable(true)]
        public NaviSuiteStrings NaviSuiteStrings => SuiteStrings;

        private bool ShouldSerializeNaviSuiteStrings() => !SuiteStrings.IsDefault;

        public void ResetNaviSuiteStrings() => SuiteStrings.Reset();

        #endregion

        #region Static Strings

        public static NaviSuiteStrings SuiteStrings
        { get; } = new();

        #endregion

        #region Identity

        public NaviSuiteLanguageManager()
        {

        }

        #endregion

        #region Implementation

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsDefault => !(ShouldSerializeNaviSuiteStrings());

        public void Reset()
        {
            ResetNaviSuiteStrings();
        }

        #endregion
    }
}