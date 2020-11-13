using System;
using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    [Serializable]
    public class ServiceColours
    {
        public Color CollapseMarkerForeColour { get; set; }
        public Color CollapseMarkerBackColour { get; set; }
        public Color CollapseMarkerBorderColour { get; set; }
        public Color ExpandMarkerForeColour { get; set; }
        public Color ExpandMarkerBackColour { get; set; }
        public Color ExpandMarkerBorderColour { get; set; }

        public ServiceColours()
        {
            CollapseMarkerForeColour = Color.Silver;
            CollapseMarkerBackColour = Color.White;
            CollapseMarkerBorderColour = Color.Silver;
            ExpandMarkerForeColour = Color.Red;
            ExpandMarkerBackColour = Color.White;
            ExpandMarkerBorderColour = Color.Silver;
        }
    }
}