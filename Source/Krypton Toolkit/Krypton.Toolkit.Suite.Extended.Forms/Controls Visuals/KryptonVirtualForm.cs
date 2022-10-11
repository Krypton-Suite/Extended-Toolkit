using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.Forms
{
    public abstract class KryptonVirtualForm : Form, IKryptonDebug
    {
        public void KryptonResetCounters()
        {
            throw new NotImplementedException();
        }

        public int KryptonLayoutCounter { get; }
        public int KryptonPaintCounter { get; }
    }
}
