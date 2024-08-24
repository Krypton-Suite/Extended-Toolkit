using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Forms
{
    public partial class KryptonSlideForm : VisualSlideForm
    {
        public KryptonSlideForm(KryptonFormExtended owner, float step) : base(owner, step)
        {
            InitializeComponent();
        }
    }
}
