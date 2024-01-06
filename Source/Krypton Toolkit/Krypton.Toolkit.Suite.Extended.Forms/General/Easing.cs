using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.Forms
{
    public abstract class Easing
    {
        #region Static Fields

        private static Easing _linear;

        private static Easing _sinus;

        #endregion

        #region Public

        /// <summary>
        /// Gets an instance of the provided linear easing.
        /// </summary>
        public static Easing Linear
        {
            get
            {
                _linear ??= new LinearEasing();

                return _linear;
            }
        }

        /// <summary>
        /// Gets an instance of the provided sinus easing.
        /// </summary>
        public static Easing Sinus
        {
            get
            {
                _sinus ??= new SinusEasing();

                return _sinus;
            }
        }

        #endregion

        #region Implementation

        /// <summary>
        /// Calculate the current value for the given properties.
        /// </summary>
        /// <param name="frame">The current frame number.</param>
        /// <param name="frames">The total frame number.</param>
        /// <param name="start">The start value (at frame 0).</param>
        /// <param name="end">The final value (at frame total - 1).</param>
        /// <returns>The current value.</returns>
        public abstract double CalculateStep(int frame, int frames, double start, double end);

        #endregion
    }
}