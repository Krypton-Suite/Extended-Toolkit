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
    /// The interface (contract) for an ExceptionReport dialog/View
    /// </summary>
    public interface IExceptionReportView : IReportSendEvent
    {
        string ProgressMessage { set; }
        bool EnableEmailButton { set; }
        bool ShowProgressBar { set; }
        bool ShowFullDetail { get; set; }
        string UserExplanation { get; }

        void MapiSendCompleted();
        void SetInProgressState();
        void PopulateExceptionTab(IEnumerable<Exception> exceptions);
        void PopulateAssembliesTab();
        void PopulateSysInfoTab();
        void SetProgressCompleteState();
        void ToggleShowFullDetail();
        void ShowWindow();
    }
}

#pragma warning restore 1591