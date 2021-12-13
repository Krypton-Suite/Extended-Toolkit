﻿namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    /// <summary>
    /// This class defines the quality to use for renders after different interactive events occur.
    /// Programmatically-triggered events typically use high quality mode (anti-aliasing enabled).
    /// Real-time mouse-interactive events like zooming and panning typically use low quality mode.
    /// It is possible to automatically render using high quality after a period of inactivity.
    /// </summary>
    public class QualityConfiguration
    {
        public RenderType BenchmarkToggle = RenderType.HighQuality;
        public RenderType AutoAxis = RenderType.LowQualityThenHighQualityDelayed;
        public RenderType MouseInteractiveDragged = RenderType.LowQuality;
        public RenderType MouseInteractiveDropped = RenderType.HighQuality;
        public RenderType MouseWheelScrolled = RenderType.LowQualityThenHighQualityDelayed;
    }
}