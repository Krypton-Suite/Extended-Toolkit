using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Notifications
{
    /// <summary></summary>
    public interface IToastNotificationUIElements
    {
        /// <summary>Gets the base window.</summary>
        /// <value>The base window.</value>
        public KryptonForm BaseWindow { get; }

        /// <summary>Gets the content panel.</summary>
        /// <value>The content panel.</value>
        public KryptonPanel ContentPanel { get; }

        /// <summary>Gets the button panel.</summary>
        /// <value>The button panel.</value>
        public KryptonPanel ButtonPanel { get; }

        /// <summary>Gets the header label.</summary>
        /// <value>The header label.</value>
        public KryptonWrapLabel HeaderLabel { get; }

        /// <summary>Gets the content label.</summary>
        /// <value>The content label.</value>
        public KryptonWrapLabel ContentLabel { get; }

        /// <summary>Gets the action button.</summary>
        /// <value>The action button.</value>
        public KryptonButton ActionButton { get; }

        /// <summary>Gets the dismiss button.</summary>
        /// <value>The dismiss button.</value>
        public KryptonButton DismissButton { get; }

        /// <summary>Gets the splitter panel.</summary>
        /// <value>The splitter panel.</value>
        public Panel SplitterPanel { get; }

        /// <summary>Gets the icon box.</summary>
        /// <value>The icon box.</value>
        public PictureBox IconBox { get; }
    }
}