namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

/// <summary>
/// Represents a single item in a right-click pop-up menu
/// </summary>
public struct ContextMenuItem
{
    public string Label { get; set; }

    public Action<IPlotControl> OnInvoke { get; set; }
}