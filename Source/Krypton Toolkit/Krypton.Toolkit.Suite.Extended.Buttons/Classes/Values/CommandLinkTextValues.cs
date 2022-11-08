#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Buttons
{
    public class CommandLinkTextValues : CaptionValues
    {
        private const string _defaultHeading = @"Command Link V1";
        private const string _defaultDescription = @"Here be the ""Note Text""";

        public CommandLinkTextValues(NeedPaintHandler needPaint)
            : base(needPaint)
        {
        }

        protected override string GetHeadingDefault()
        {
            return _defaultHeading;
        }

        protected override string GetDescriptionDefault()
        {
            return _defaultDescription;
        }

        #region Description
        /// <summary>
        /// Gets and sets the header description text.
        /// </summary>
        [DefaultValue(_defaultDescription)]
        public override string Description
        {
            get => base.Description;
            set => base.Description = value;
        }
        #endregion

        public void ResetText()
        {
            Heading = _defaultHeading;
            Description = _defaultDescription;
        }
    }
}