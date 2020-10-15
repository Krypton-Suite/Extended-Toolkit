namespace Krypton.Toolkit.Suite.Extended.Base
{
    /// <summary>
    /// Contains information about a <see cref="CalendarTimeScaleUnit"/> that is about to be painted
    /// </summary>
    public class CalendarRendererTimeUnitEventArgs : CalendarRendererEventArgs
    {
        #region Events

        #endregion

        #region Fields
        private CalendarTimeScaleUnit _unit;
        #endregion

        #region Ctor

        public CalendarRendererTimeUnitEventArgs(CalendarRendererEventArgs original, CalendarTimeScaleUnit unit) : base(original)
        {
            _unit = unit;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the unit that is about to be painted
        /// </summary>
        public CalendarTimeScaleUnit Unit => _unit;


        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        #endregion
    }
}