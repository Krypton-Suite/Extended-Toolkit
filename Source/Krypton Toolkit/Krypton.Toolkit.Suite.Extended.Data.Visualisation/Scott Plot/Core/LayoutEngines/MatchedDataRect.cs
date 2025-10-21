namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

/// <summary>
/// Generate layouts that match layouts of another control
/// </summary>
public class MatchedDataRect : LayoutEngineBase, ILayoutEngine
{
    private Plot ReferencePlot { get; }

    public MatchedDataRect(Plot referencePlot)
    {
        ReferencePlot = referencePlot;
    }

    public Layout GetLayout(PixelRect figureRect, IEnumerable<IPanel> panels)
    {
        Dictionary<IPanel, float> panelSizes = MeasurePanels(panels);
        Dictionary<IPanel, float> panelOffsets = GetPanelOffsets(panels, panelSizes);

        PixelRect dataRect = ReferencePlot.RenderManager.LastRender.DataRect;
        return new Layout(figureRect, dataRect, panelSizes, panelOffsets);
    }
}