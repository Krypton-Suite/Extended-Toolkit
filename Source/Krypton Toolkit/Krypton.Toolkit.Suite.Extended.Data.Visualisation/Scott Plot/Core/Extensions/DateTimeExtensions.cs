#pragma warning disable CS1570 // XML comment has badly formed XML
namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

/// <summary>
/// These methods hold conversion logic between DateTime (used for representing dates)
/// and double (used for defining positions on a Cartesian coordinate plane).
/// 
/// Converting double <-> OADate has issues (e.g., OADates have a limited range), so by
/// isolating the conversion here we can ensure we can change the logic later without
/// hunting around the code base finding all the OADate conversion calls.
/// </summary>
public static class DateTimeExtensions
{
    /// <summary>
    /// Convert a number that can be plotted on a numeric axis into a DateTime
    /// </summary>
    public static DateTime ToDateTime(this double value)
    {
        return value switch
        {
            <= -657435 => new DateTime(100, 1, 1),
            >= 2958466 => new DateTime(9_999, 1, 1),
            _ => DateTime.FromOADate(value)
        };
    }

    /// <summary>
    /// Convert a DateTime into a number that can be plotted on a numeric axis
    /// </summary>
    public static double ToNumber(this DateTime value)
    {
        return value.Year switch
        {
            < 100 => new DateTime(100, 1, 1).ToOADate(),
            >= 10_000 => new DateTime(10_000, 1, 1).ToOADate(),
            _ => value.ToOADate()
        };
    }
}