namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

public interface IHatch
{
    SKShader GetShader(Color backgroundColor, Color hatchColor);
}