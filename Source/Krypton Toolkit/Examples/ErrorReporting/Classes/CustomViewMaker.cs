using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.Error.Reporting;

namespace ErrorReporting
{
    /// <summary>
    /// A sample implementation of IViewMaker used to switch the view used by ExceptionReporter
    /// </summary>
    public class CustomViewMaker : IViewMaker
    {
        public IExceptionReportView Create()
        {
            return new CustomReporterView();
        }

        public void ShowError(string message)
        {
            KryptonMessageBox.Show(message);
        }
    }
}