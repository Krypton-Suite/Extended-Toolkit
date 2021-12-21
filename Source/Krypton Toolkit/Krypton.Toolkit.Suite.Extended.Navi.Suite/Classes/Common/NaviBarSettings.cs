#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Navi.Suite
{
    [XmlRoot("settings")]
    public class NaviBarSettings
    {
        [XmlElement("band")]
        public List<NaviBandSetting> BandSettings { get; set; }

        [XmlElement("visibleButtons")]
        public int VisibleButtons { get; set; }

        [XmlElement("collapsed")]
        public bool Collapsed { get; set; }

        public NaviBarSettings()
        {
            BandSettings = new List<NaviBandSetting>();
        }
    }
}