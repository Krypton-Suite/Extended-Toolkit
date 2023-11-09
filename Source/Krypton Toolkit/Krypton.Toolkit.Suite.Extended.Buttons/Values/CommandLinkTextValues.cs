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


namespace Krypton.Toolkit.Suite.Extended.Buttons
{
    public class CommandLinkTextValues : CaptionValues
    {
        private const string DEFAULT_HEADING = @"Command Link V1";
        private const string DEFAULT_DESCRIPTION = @"Here be the ""Note Text""";

        public CommandLinkTextValues(NeedPaintHandler needPaint)
            : base(needPaint)
        {
        }

        protected override string GetHeadingDefault()
        {
            return DEFAULT_HEADING;
        }

        protected override string GetDescriptionDefault()
        {
            return DEFAULT_DESCRIPTION;
        }

        #region Description
        /// <summary>
        /// Gets and sets the header description text.
        /// </summary>
        [DefaultValue(DEFAULT_DESCRIPTION)]
        public override string Description
        {
            get => base.Description;
            set => base.Description = value;
        }
        #endregion

        public void ResetText()
        {
            Heading = DEFAULT_HEADING;
            Description = DEFAULT_DESCRIPTION;
        }
    }
}