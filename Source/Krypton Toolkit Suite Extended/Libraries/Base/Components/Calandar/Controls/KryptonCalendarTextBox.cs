namespace Krypton.Toolkit.Suite.Extended.Base
{
    public class KryptonCalendarTextBox : KryptonTextBox //TextBox
    {
        #region Fields
        private KryptonCalendar _calendar;
        #endregion

        #region Ctor

        /// <summary>
        /// Creates a new <see cref="KryptonCalendarTextBox"/> for the specified <see cref="KryptonCalendar"/>
        /// </summary>
        /// <param name="calendar">Calendar where this control lives</param>
        public KryptonCalendarTextBox(KryptonCalendar calendar)
        {
            _calendar = calendar;
        }

        #endregion

        #region Props

        /// <summary>
        /// Gets the calendar where this control lives
        /// </summary>
        public KryptonCalendar Calendar
        {
            get { return _calendar; }
        }


        #endregion

        #region Methods



        #endregion
    }
}