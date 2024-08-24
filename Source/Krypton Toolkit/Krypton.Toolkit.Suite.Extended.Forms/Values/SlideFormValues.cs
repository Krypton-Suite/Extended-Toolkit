using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.Forms
{
    public class SlideFormValues : Storage
    {
        #region Static Fields

        private const float DEFAULT_SLIDE_STEP = 1.0f;

        private const SlideDirection DEFAULT_SLIDE_DIRECTION = SlideDirection.Right;

        #endregion

        #region Public

        public float SlideStep { internal get; set; }

        public SlideDirection SlideDirection { internal get; set; }

        #endregion

        #region Identity

        public SlideFormValues()
        {
            Reset();
        }

        #endregion

        public override bool IsDefault => SlideStep.Equals(DEFAULT_SLIDE_STEP) && 
                                          SlideDirection.Equals(DEFAULT_SLIDE_DIRECTION);

        #region Implementation

        public void Reset()
        {
            SlideStep = DEFAULT_SLIDE_STEP;

            SlideDirection = DEFAULT_SLIDE_DIRECTION;
        }

        #endregion
    }
}
