#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

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