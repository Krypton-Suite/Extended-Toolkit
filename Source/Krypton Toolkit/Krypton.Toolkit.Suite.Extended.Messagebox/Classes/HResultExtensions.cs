namespace Krypton.Toolkit.Suite.Extended.Messagebox;

internal static class HResultExtensions
{
    public static bool Succeeded(this PI.HRESULT hr) => hr >= 0;

    public static bool Failed(this PI.HRESULT hr) => hr < 0;

    public static string AsString(this PI.HRESULT hr)
        => Enum.IsDefined(typeof(PI.HRESULT), hr)
            ? $"HRESULT {hr} [0x{(int)hr:X} ({(int)hr:D})]"
            : $"HRESULT [0x{(int)hr:X} ({(int)hr:D})]";
}