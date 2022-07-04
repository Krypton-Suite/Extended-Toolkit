#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

#pragma warning disable 1591
namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
	/// <summary>
    /// The top-level model/object passed to report templates
    /// </summary>
    public class ReportModel
    {
        public App App { get; set; }
        public Error Error { get; set; }
        public string SystemInfo { get; set; }
    }
}