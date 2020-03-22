namespace Krypton.Toolkit.Extended.Base
{
    internal class CalendarTimeScaleUnit
    {
        private CalendarDay calendarDay;
        private int i;
        private int hourSum;
        private int minSum;

        public CalendarTimeScaleUnit(CalendarDay calendarDay, int i, int hourSum, int minSum)
        {
            this.calendarDay = calendarDay;
            this.i = i;
            this.hourSum = hourSum;
            this.minSum = minSum;
        }
    }
}