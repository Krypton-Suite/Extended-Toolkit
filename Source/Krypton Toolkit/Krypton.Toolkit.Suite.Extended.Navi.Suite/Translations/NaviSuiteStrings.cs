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
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class NaviSuiteStrings : GlobalId
    {
        #region Static Strings

        private const string DEFAULT_NAVI_SUITE_DESCRIPTION = @"Display buttons in this order";
        private const string DEFAULT_NAVI_SUITE_MOVE_UP = @"Move Up";
        private const string DEFAULT_NAVI_SUITE_MOVE_DOWN = @"Move Down";
        private const string DEFAULT_NAVI_SUITE_RESET = @"Reset";
        private const string DEFAULT_NAVI_SUITE_OPTIONS_TITLE = @"Options of the Navigation Pane";

        #endregion

        #region Identity

        public NaviSuiteStrings()
        {
            Reset();
        }

        public override string ToString() => !IsDefault ? "Modified" : string.Empty;

        #endregion

        #region Public

        [Browsable(false)]
        public bool IsDefault => Description.Equals(DEFAULT_NAVI_SUITE_DESCRIPTION) &&
                                 MoveUp.Equals(DEFAULT_NAVI_SUITE_MOVE_UP) &&
                                 MoveDown.Equals(DEFAULT_NAVI_SUITE_MOVE_DOWN) &&
                                 ResetText.Equals(DEFAULT_NAVI_SUITE_RESET) &&
                                 OptionsTitle.Equals(DEFAULT_NAVI_SUITE_OPTIONS_TITLE);

        public void Reset()
        {
            Description = DEFAULT_NAVI_SUITE_DESCRIPTION;

            MoveDown = DEFAULT_NAVI_SUITE_MOVE_DOWN;

            MoveUp = DEFAULT_NAVI_SUITE_MOVE_UP;

            OptionsTitle = DEFAULT_NAVI_SUITE_OPTIONS_TITLE;

            ResetText = DEFAULT_NAVI_SUITE_RESET;
        }

        /// <summary>Gets or sets the options dialog description text.</summary>
        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"The options dialog description text.")]
        [DefaultValue(DEFAULT_NAVI_SUITE_DESCRIPTION)]
        [RefreshProperties(RefreshProperties.All)]
        public string Description { get; set; }

        /// <summary>Gets or sets the options dialog move up button text.</summary>
        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"The options dialog move up button text.")]
        [DefaultValue(DEFAULT_NAVI_SUITE_MOVE_UP)]
        [RefreshProperties(RefreshProperties.All)]
        public string MoveUp { get; set; }

        /// <summary>Gets or sets the options dialog move down button text.</summary>
        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"The options dialog move down button text.")]
        [DefaultValue(DEFAULT_NAVI_SUITE_MOVE_DOWN)]
        [RefreshProperties(RefreshProperties.All)]
        public string MoveDown { get; set; }

        /// <summary>Gets or sets the options dialog reset button text.</summary>
        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"The options dialog reset button text.")]
        [DefaultValue(DEFAULT_NAVI_SUITE_RESET)]
        [RefreshProperties(RefreshProperties.All)]
        public string ResetText { get; set; }

        /// <summary>Gets or sets the options dialog title.</summary>
        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"The options dialog title.")]
        [DefaultValue(DEFAULT_NAVI_SUITE_OPTIONS_TITLE)]
        [RefreshProperties(RefreshProperties.All)]
        public string OptionsTitle { get; set; }

        #endregion
    }
}