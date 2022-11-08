#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
    /// <summary>
    /// An interface/contract to replace the default view (currently only applicable to WinForms)
    /// </summary>
    public interface IViewMaker
    {
        /// <summary>
        /// create the main view/dialog
        /// </summary>
        /// <returns><see cref="IExceptionReportView"/></returns>
        IExceptionReportView Create();

        /// <summary>
        /// show an error 
        /// </summary>
        /// <param name="message"></param>
        void ShowError(string message);
    }
}