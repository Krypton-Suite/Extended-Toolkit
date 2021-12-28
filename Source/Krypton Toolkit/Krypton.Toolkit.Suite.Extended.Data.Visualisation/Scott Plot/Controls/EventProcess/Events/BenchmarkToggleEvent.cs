#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    /// <summary>
    /// This event toggles visibility of the benchmark.
    /// This event is typically called after double-clicking the plot.
    /// </summary>
    public class BenchmarkToggleEvent : IUIEvent
    {
        private readonly Plot Plot;
        private readonly Configuration Configuration;
        public RenderType RenderType => Configuration.QualityConfiguration.BenchmarkToggle;

        public BenchmarkToggleEvent(Plot plt, Configuration config)
        {
            Plot = plt;
            Configuration = config;
        }

        public void ProcessEvent()
        {
            Plot.Benchmark(!Plot.Benchmark(null));
        }
    }
}