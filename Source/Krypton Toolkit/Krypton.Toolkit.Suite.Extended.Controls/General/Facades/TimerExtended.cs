namespace Krypton.Toolkit.Suite.Extended.Controls
{
    /// <summary>
    /// An abstraction of <see cref="System.Timers.Timer"/>.
    /// </summary>
    /// <remarks>Exists in order to make test assertions on usage of
    /// <see cref="System.Timers.Timer"/>.</remarks>
    public class TimerExtended : ITimer
    {
        /// <summary>
        /// Converts the specified <paramref name="timer"/> object to a
        /// <see cref="System.Timers.Timer"/>.
        /// </summary>
        /// <param name="timer">A <see cref="TimerExtended"/>.</param>
        /// <returns>The <see cref="System.Timers.Timer"/> of which
        /// <paramref name="timer"/> is an abstraction.</returns>
        public static explicit operator System.Timers.Timer(TimerExtended timer)
        {
            return timer.native;
        }

        private readonly System.Timers.Timer native;

        /// <summary>
        /// Instantiates a new <see cref="TimerExtended"/> with the specified
        /// properties.
        /// </summary>
        /// <param name="autoReset">The desired value of
        /// <see cref="AutoReset"/>.</param>
        /// <param name="interval">The desired value of
        /// <see cref="Interval"/>.</param>
        /// <param name="synchronizingObject">The desired value of
        /// <see cref="SynchronizingObject"/>; optional.</param>
        public TimerExtended(bool autoReset,
                     double interval,
                     ISynchronizeInvoke synchronizingObject)
        {
            native = new System.Timers.Timer
            {
                AutoReset = autoReset,
                Interval = interval,
                SynchronizingObject = synchronizingObject
            };
        }

        /// <summary>
        /// Finalizes a <see cref="TimerExtended"/>.
        /// </summary>
        ~TimerExtended()
        {
            Dispose(false);
            System.Diagnostics.Debug.Fail($"{GetType().FullName} was not disposed!");
        }

        /// <summary>
        /// Occurs when <see cref="Interval"/> elapses.
        /// </summary>
        public event ElapsedEventHandler Elapsed
        {
            add { native.Elapsed += value; }

            remove { native.Elapsed -= value; }
        }

        /// <summary>
        /// Indicates whether the <see cref="TimerExtended"/> should raise the
        /// <see cref="Elapsed"/> event each time <see cref="Interval"/> elapses
        /// or only after the first time it elapses.
        /// </summary>
        public bool AutoReset => native.AutoReset;

        /// <summary>
        /// Gets or sets the interval, in milliseconds, at which to raise the
        /// <see cref="Elapsed"/> event.
        /// </summary>
        public double Interval
        {
            get { return native.Interval; }

            set { native.Interval = value; }
        }

        /// <summary>
        /// Gets the object used to marshal events raised by the
        /// <see cref="TimerExtended"/>.
        /// </summary>
        public ISynchronizeInvoke SynchronizingObject => native.SynchronizingObject;

        /// <summary>
        /// Disposes resources acquired by the <see cref="TimerExtended"/>.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes unmanaged resources acquired by the <see cref="TimerExtended"/>,
        /// optionally disposing managed resources, as well.
        /// </summary>
        /// <param name="disposing">If <c>true</c>, managed resources are
        /// disposed along with unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                native.Dispose();
            }
        }

        /// <summary>
        /// Starts counting down <see cref="Interval"/> to raise
        /// <see cref="Elapsed"/>.
        /// </summary>
        public void Start()
        {
            native.Start();
        }

        /// <summary>
        /// Stops counting down <see cref="Interval"/> to raise
        /// <see cref="Elapsed"/>.
        /// </summary>
        public void Stop()
        {
            native.Stop();
        }
    }
}
