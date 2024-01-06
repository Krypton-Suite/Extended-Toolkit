using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.Forms
{
    public class LinearEasing : Easing
    {
        #region Implementation

        /// <inheritdoc />
        public override double CalculateStep(int frame, int frames, double start, double end)
        => start + frame * (end - start) / frames;

        #endregion
    }
}
