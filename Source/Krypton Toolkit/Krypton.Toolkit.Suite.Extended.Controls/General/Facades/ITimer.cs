using System.Timers;

namespace Krypton.Toolkit.Suite.Extended.Controls
{
    /// <summary>
    /// An abstraction of <see cref="System.Timers.Timer"/>.
    /// </summary>
    /// <remarks>Exists in order to make test assertions on usage of
    /// <see cref="System.Timers.Timer"/>.</remarks>
    public interface ITimer : IDisposable
    {
        /// <summary>
        /// Occurs when <see cref="Interval"/> elapses.
        /// </summary>
        event ElapsedEventHandler Elapsed;

        /// <summary>
        /// Gets or sets the interval, in milliseconds, at which to raise the
        /// <see cref="Elapsed"/> event.
        /// </summary>
        double Interval { get; set; }

        /// <summary>
        /// Starts counting down <see cref="Interval"/> to raise
        /// <see cref="Elapsed"/>.
        /// </summary>
        void Start();

        /// <summary>
        /// Stops counting down <see cref="Interval"/> to raise
        /// <see cref="Elapsed"/>.
        /// </summary>
        void Stop();
    }
}