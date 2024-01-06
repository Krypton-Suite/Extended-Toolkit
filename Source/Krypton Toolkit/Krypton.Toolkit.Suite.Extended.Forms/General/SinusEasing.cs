using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.Forms
{
    public class SinusEasing : Easing
    {
        #region Public

        /// <summary>
        /// Gets or sets the amplitude of the sinus wave.
        /// </summary>
        public double Amplitude { get; set; }

        /// <summary>
        /// Gets or sets the frequency of the sinus wave.
        /// </summary>
        public double Frequency { get; set; }

        #endregion

        #region Identity

        /// <summary>
        /// Creates an object of the sinus easing.
        /// </summary>
        /// <param name="amplitude">The amplitude of the sinus wave.</param>
        /// <param name="frequency">The frequency of the sinus wave.</param>
        public SinusEasing(double amplitude = 0.2, double frequency = 2.0)
        {
            Amplitude = amplitude;
            Frequency = frequency;
        }

        #endregion

        #region Implementation

        /// <inheritdoc />
        public override double CalculateStep(int frame, int frames, double start, double end)
            => start + frame * (end - start) / frames +
               Math.Sin(frame * Frequency * 2 * Math.PI / frames) * (end - start) * Amplitude;

        #endregion
    }
}