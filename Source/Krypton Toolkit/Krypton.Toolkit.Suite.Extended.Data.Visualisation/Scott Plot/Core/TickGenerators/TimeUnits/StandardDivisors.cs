namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    internal static class StandardDivisors
    {
        public static readonly IReadOnlyList<int> Decimal = [1, 5, 10];
        public static readonly IReadOnlyList<int> Sexagesimal = [1, 5, 10, 15, 20, 30, 60];
        public static readonly IReadOnlyList<int> Dozenal = [1, 2, 3, 4, 6, 12];
        public static readonly IReadOnlyList<int> Hexadecimal = [1, 2, 3, 4, 6, 8, 16];
        public static readonly IReadOnlyList<int> Days = [1, 3, 7, 14, 28];
        public static readonly IReadOnlyList<int> Months = [1, 3, 6];
        public static readonly IReadOnlyList<int> Years = [1, 2, 3, 4, 5, 10];
    }
}