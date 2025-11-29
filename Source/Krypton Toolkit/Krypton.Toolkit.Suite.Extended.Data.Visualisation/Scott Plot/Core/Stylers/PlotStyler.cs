namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

/// <summary>
/// A collection of high-level methods that make it easy to style many components of a plot at once
/// </summary>
public class PlotStyler
{
    private readonly Plot _plot;

    public PlotStyler(Plot plot)
    {
        _plot = plot;
    }

    /// <summary>
    /// Apply background colors to the figure and data areas
    /// </summary>
    public void Background(Color figure, Color data)
    {
        _plot.FigureBackground = figure;
        _plot.DataBackground = data;
    }

    /// <summary>
    /// Apply a single color to all components of each axis (label, tick labels, tick marks, and frame)
    /// </summary>
    public void ColorAxes(Color color)
    {
        foreach (AxisBase axis in _plot.Axes.GetAxes().OfType<AxisBase>())
        {
            axis.Color(color);
        }

        _plot.Axes.Title.Label.ForeColor = color;
    }

    /// <summary>
    /// Apply a color to all currently visible grids
    /// </summary>
    public void ColorGrids(Color majorColor)
    {
        foreach (DefaultGrid grid in _plot.Axes.Grids.OfType<DefaultGrid>())
        {
            grid.MajorLineStyle.Color = majorColor;
        }
    }

    /// <summary>
    /// Apply a color to all currently visible grids
    /// </summary>
    public void ColorGrids(Color majorColor, Color minorColor)
    {
        foreach (DefaultGrid grid in _plot.Axes.Grids.OfType<DefaultGrid>())
        {
            grid.MajorLineStyle.Color = majorColor;
            grid.MinorLineStyle.Color = minorColor;
        }
    }

    public void ColorLegend(Color background, Color foreground, Color border)
    {
        _plot.Legend.BackgroundFill.Color = background;
        _plot.Legend.Font.Color = foreground;
        _plot.Legend.OutlineStyle.Color = border;
    }

    /// <summary>
    /// Set frame thickness for each side of the plot
    /// </summary>
    public void AxisFrame(float left, float right, float bottom, float top)
    {
        _plot.Axes.Left.FrameLineStyle.Width = left;
        _plot.Axes.Right.FrameLineStyle.Width = right;
        _plot.Axes.Bottom.FrameLineStyle.Width = bottom;
        _plot.Axes.Top.FrameLineStyle.Width = top;
    }

    /// <summary>
    /// Apply the given font name to all existing plot objects.
    /// Also sets the default font name so this font will be used for plot objects added in the future.
    /// </summary>
    public void SetFont(string fontName)
    {
        fontName = Fonts.Exists(fontName) ? fontName : Fonts.Default;

        // set default font so future added objects will use it
        Fonts.Default = fontName;

        // title
        _plot.Axes.Title.Label.FontName = fontName;

        // axis labels and ticks
        foreach (IAxis axis in _plot.Axes.GetAxes())
        {
            axis.Label.FontName = fontName;
            axis.TickLabelStyle.FontName = fontName;
        }

        // TODO: also modify tick labels
        // TODO: also modify plotted text
    }

    [Obsolete("use SetBestFonts()", true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool SetFontFromText(string text)
    {
        throw new InvalidOperationException();
    }

    /// <summary>
    /// Detects the best font to apply to every label in the plot based on the characters that they contain.
    /// If the best font for a label cannot be detected, the font last defined by <see cref="SetFont(string)"/> will be used.
    /// </summary>
    public void SetBestFonts()
    {
        // title
        _plot.Axes.Title.Label.SetBestFont();

        // axis labels and ticks
        foreach (IAxis axis in _plot.Axes.GetAxes())
        {
            axis.Label.SetBestFont();
        }

        // TODO: also modify tick labels
        // TODO: also modify plotted text
    }

    /// <summary>
    /// Reset colors and palette do a dark mode style
    /// </summary>
    public void DarkMode()
    {
        _plot.Add.Palette = new Penumbra();

        ColorAxes(Color.FromHex("#d7d7d7"));
        ColorGrids(Color.FromHex("#404040"));
        Background(
            figure: Color.FromHex("#181818"),
            data: Color.FromHex("#1f1f1f"));
        ColorLegend(
            background: Color.FromHex("#404040"),
            foreground: Color.FromHex("#d7d7d7"),
            border: Color.FromHex("#d7d7d7"));
    }
}