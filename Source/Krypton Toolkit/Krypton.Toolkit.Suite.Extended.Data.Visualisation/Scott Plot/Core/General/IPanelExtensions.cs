namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public static class PanelExtensions
    {
        /// <summary>
        /// Returns true for X axes (bottom and top)
        /// </summary>
        public static bool IsHorizontal(this IPanel panel) => panel.Edge is Edge.Bottom or Edge.Top;

        /// <summary>
        /// Returns true for Y axes (left and right)
        /// </summary>
        public static bool IsVertical(this IPanel panel) => !panel.IsHorizontal();
    }
}