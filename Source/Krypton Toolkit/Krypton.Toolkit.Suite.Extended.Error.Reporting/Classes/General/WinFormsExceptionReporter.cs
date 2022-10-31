﻿#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
	/// <summary>
	/// The entry-point (class) to invoking a (WinForms) ExceptionReporter dialog
	/// eg new ExceptionReporter().Show(exceptions)
	/// </summary>
	public class ExceptionReporter : ExceptionReporterBase
	{
		/// <summary>
		/// Initialise the ExceptionReporter
		/// </summary>
		public ExceptionReporter()
		{
			ViewMaker = new DefaultWinFormsViewmaker(_info);
		}

		/// <summary>
		/// Contract by which to show any dialogs/view
		/// </summary>
		// ReSharper disable once UnusedAutoPropertyAccessor.Global
		public IViewMaker ViewMaker { get; set; }

		/// <summary>
		/// Show the ExceptionReport dialog
		/// </summary>
		/// <remarks>The <see cref="ExceptionReporter"/> will analyze the <see cref="Exception"/>s and 
		/// create and show the report dialog.</remarks>
		/// <param name="exceptions">The <see cref="Exception"/>s to show.</param>
		public bool Show(params Exception[] exceptions)
		{
			// silently ignore the mistake of passing null
			if (exceptions == null || exceptions.Length == 0 || exceptions.Length >= 1 && exceptions[0] == null) return false;
			if (ViewMaker == null)
			{
				Debug.WriteLine("DefaultWinFormsViewmaker must be initialized (not null). Add `er.DefaultWinFormsViewmaker = new DefaultWinFormsViewmaker(er.Config);` where 'er' is the ExceptionReporter object");
				return false;
			}

			try
			{
				_info.SetExceptions(exceptions);

				var view = ViewMaker.Create();
				view.ShowWindow();
				return true;
			}
			catch (Exception ex)
			{
				ViewMaker.ShowError(ex.Message);
				return false;
			}
		}

		/// <summary>
		/// Show the ExceptionReport dialog with a custom message instead of the Exception's Message property
		/// </summary>
		/// <param name="customMessage">custom (exception) message</param>
		/// <param name="exceptions">The exception/s to display in the exception report</param>
		public void Show(string customMessage, params Exception[] exceptions)
		{
			_info.CustomMessage = customMessage;
			Show(exceptions);
		}

		/// <summary>
		/// Send the report, asynchronously, without showing a dialog (silent send)
		/// <see cref="ExceptionReportInfo.SendMethod"/>must be SMTP or WebService, else this is ignored (silently)
		/// </summary>
		/// <param name="exceptions">The exception/s to include in the report</param>
		public void Send(params Exception[] exceptions)
		{
			base.Send(new WinFormsScreenShooter(), new SilentSendEvent(), exceptions);
		}
	}
}