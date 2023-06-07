using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    /// <summary>Enum representing the effect of Mandatory flag.</summary>
    public enum UpdateMode
    {
        /// <summary>In this mode, it ignores Remind Later and Skip values set previously and hide both buttons.</summary>
        [XmlEnum("0")] Normal,

        /// <summary>In this mode, it won't show close button in addition to Normal mode behaviour.</summary>
        [XmlEnum("1")] Forced,

        /// <summary>In this mode, it will start downloading and applying update without showing standard update dialog in addition to Forced mode behaviour.</summary>
        [XmlEnum("2")] ForcedDownload
    }
}