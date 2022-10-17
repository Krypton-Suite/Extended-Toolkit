#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Error.Reporting;

public class App
{
    public string Name { get; set; }
    public string Version { get; set; }
    public string Region { get; set; } = CultureInfo.CurrentCulture.DisplayName;

    /// <summary> eg used in HTML lang attribute </summary>
    public string Language { get; set; } = "en";

    /// <summary> Title of the report </summary>
    public string Title { get; set; } = "Exception Report";

    /// <summary> optional - will not show field at all if empty </summary>
    public string User { get; set; }

    public IEnumerable<AssemblyRef> AssemblyRefs { get; set; }
}