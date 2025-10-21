namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

public abstract class FormsPlotBase : UserControl, IPlotControl
{
    #region Public

    public Plot Plot { get; internal set; }
        
    public IPlotInteraction Interaction { get; set; }

    public IPlotMenu Menu { get; set; }

    public abstract GRContext? GrContext { get; }

    public float DisplayScale { get; set; }

    #endregion

    #region Identity

    public FormsPlotBase()
    {
        DisplayScale = DetectDisplayScale();
        Interaction = new Interaction(this);
        Menu = new FormsPlotMenu(this);
        Plot = Reset();

        // TODO: replace this with an annotation instead of title
        bool isDesignMode = Process.GetCurrentProcess().ProcessName == "devenv";
        Plot.Title(isDesignMode ? $"ScottPlot {Version.VersionString}" : string.Empty);
    }

    #endregion

    #region Implementation

    public Plot Reset()
    {
        Plot newPlot = new()
        {
            FigureBackground = this.BackColor.ToColor(),
        };

        return Reset(newPlot);
    }

    public Plot Reset(Plot newPlot)
    {
        Plot oldPlot = Plot;
        Plot = newPlot;
        oldPlot?.Dispose();
        return newPlot;
    }

    public void ShowContextMenu(Pixel position) => Menu.ShowContextMenu(position);

    public float DetectDisplayScale()
    {
        using var g = CreateGraphics();
        const int DEFAULT_DPI = 96;
        var ratio = g.DpiX / DEFAULT_DPI;
        return ratio;
    }

    internal void SKElement_MouseDown(object? sender, MouseEventArgs e)
    {
        Interaction.MouseDown(e.Pixel(), e.Button());
        base.OnMouseDown(e);
    }

    internal void SKElement_MouseUp(object? sender, MouseEventArgs e)
    {
        Interaction.MouseUp(e.Pixel(), e.Button());
        base.OnMouseUp(e);
    }

    internal void SKElement_MouseMove(object? sender, MouseEventArgs e)
    {
        Interaction.OnMouseMove(e.Pixel());
        base.OnMouseMove(e);
    }

    internal void SKElement_DoubleClick(object? sender, EventArgs e)
    {
        Interaction.DoubleClick();
        base.OnDoubleClick(e);
    }

    internal void SKElement_MouseWheel(object? sender, MouseEventArgs e)
    {
        Interaction.MouseWheelVertical(e.Pixel(), e.Delta);
        base.OnMouseWheel(e);
    }

    internal void SKElement_KeyDown(object? sender, KeyEventArgs e)
    {
        Interaction.KeyDown(e.Key());
        base.OnKeyDown(e);
    }

    internal void SKElement_KeyUp(object? sender, KeyEventArgs e)
    {
        Interaction.KeyUp(e.Key());
        base.OnKeyUp(e);
    }

    #endregion

    #region Public Overrides

    public override System.Drawing.Color BackColor
    {
        get => base.BackColor;

        set
        {
            base.BackColor = value;

            if (Plot != null)
            {
                Plot.FigureBackground = value.ToColor();
            }
        }
    }

    #endregion
}