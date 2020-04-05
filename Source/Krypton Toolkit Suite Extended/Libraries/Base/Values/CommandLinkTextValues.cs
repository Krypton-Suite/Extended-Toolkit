using System.ComponentModel;

namespace Krypton.Toolkit.Extended.Base
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