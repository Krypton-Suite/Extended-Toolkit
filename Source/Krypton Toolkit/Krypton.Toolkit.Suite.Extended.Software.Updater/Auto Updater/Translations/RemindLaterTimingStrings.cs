using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class RemindLaterTimingStrings : GlobalId
    {
        #region Static Fields

        private const string DEFAULT_AFTER_THIRTY_MINUTES = @"After 30 minutes";

        private const string DEFAULT_AFTER_TWELVE_HOURS = @"After 12 hours";

        private const string DEFAULT_AFTER_ONE_DAY = @"After 1 day";

        private const string DEFAULT_AFTER_TWO_DAYS = @"After 2 days";

        private const string DEFAULT_AFTER_FOUR_DAYS = @"After 4 days";

        private const string DEFAULT_AFTER_EIGHT_DAYS = @"After 8 days";

        private const string DEFAULT_AFTER_TEN_DAYS = @"After 10 days";

        #endregion

        #region Identity

        public RemindLaterTimingStrings()
        {
            Reset();
        }

        public override string ToString() => !IsDefault ? "Modified" : string.Empty;

        #endregion

        #region Public

        [Browsable(false)]
        public bool IsDefault => ThirtyMinutes.Equals(DEFAULT_AFTER_THIRTY_MINUTES) &&
                                 TwelveHours.Equals(DEFAULT_AFTER_TWELVE_HOURS) &&
                                 OneDay.Equals(DEFAULT_AFTER_ONE_DAY) &&
                                 TwoDays.Equals(DEFAULT_AFTER_TWO_DAYS) &&
                                 FourDays.Equals(DEFAULT_AFTER_FOUR_DAYS) &&
                                 EightDays.Equals(DEFAULT_AFTER_EIGHT_DAYS) &&
                                 TenDays.Equals(DEFAULT_AFTER_TEN_DAYS);

        public void Reset()
        {
            ThirtyMinutes = DEFAULT_AFTER_THIRTY_MINUTES;

            TwelveHours = DEFAULT_AFTER_TWELVE_HOURS;

            OneDay = DEFAULT_AFTER_ONE_DAY;

            TwoDays = DEFAULT_AFTER_TWO_DAYS;

            FourDays = DEFAULT_AFTER_FOUR_DAYS;

            EightDays = DEFAULT_AFTER_EIGHT_DAYS;

            TenDays = DEFAULT_AFTER_TEN_DAYS;
        }

        // <summary>Gets or sets the thirty minutes string.</summary>
        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"Localised thirty minutes string.")]
        [DefaultValue(DEFAULT_AFTER_THIRTY_MINUTES)]
        [RefreshProperties(RefreshProperties.All)]
        public string ThirtyMinutes { get; set; }

        // <summary>Gets or sets the twelve hours string.</summary>
        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"Localised twelve hours string.")]
        [DefaultValue(DEFAULT_AFTER_TWELVE_HOURS)]
        [RefreshProperties(RefreshProperties.All)]
        public string TwelveHours { get; set; }

        // <summary>Gets or sets the one day string.</summary>
        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"Localised one day string.")]
        [DefaultValue(DEFAULT_AFTER_ONE_DAY)]
        [RefreshProperties(RefreshProperties.All)]
        public string OneDay { get; set; }

        // <summary>Gets or sets the two days string.</summary>
        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"Localised two days string.")]
        [DefaultValue(DEFAULT_AFTER_TWO_DAYS)]
        [RefreshProperties(RefreshProperties.All)]
        public string TwoDays { get; set; }

        // <summary>Gets or sets the four days string.</summary>
        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"Localised four days string.")]
        [DefaultValue(DEFAULT_AFTER_FOUR_DAYS)]
        [RefreshProperties(RefreshProperties.All)]
        public string FourDays { get; set; }

        // <summary>Gets or sets the eight days string.</summary>
        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"Localised eight days string.")]
        [DefaultValue(DEFAULT_AFTER_EIGHT_DAYS)]
        [RefreshProperties(RefreshProperties.All)]
        public string EightDays { get; set; }

        // <summary>Gets or sets the ten days string.</summary>
        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"Localised ten days string.")]
        [DefaultValue(DEFAULT_AFTER_TEN_DAYS)]
        [RefreshProperties(RefreshProperties.All)]
        public string TenDays { get; set; }

        #endregion
    }
}