namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

public abstract class NamedColorsBase : INamedColors
{
    public Color[] GetAllColors() => GetType().GetMethods().Where(x => x.ReturnType == typeof(Color))
        .Select(x => x.Invoke(null, null)).Cast<Color>().ToArray();
}