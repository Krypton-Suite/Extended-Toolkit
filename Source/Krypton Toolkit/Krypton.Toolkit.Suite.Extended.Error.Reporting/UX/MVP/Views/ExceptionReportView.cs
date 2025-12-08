#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Error.Reporting;

public partial class ExceptionReportView : KryptonForm, IExceptionReportView
{
    #region Fields
    private bool _isDataRefreshRequired;
    private readonly ExceptionReportPresenter _presenter;
    #endregion

    #region Property

    #endregion

    #region IExceptionReportView Implementation

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string ProgressMessage
    {
        set
        {
            tslblProgressMessage.Visible = true;
            tslblProgressMessage.Text = value;
        }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool EnableEmailButton
    {
        set => kbtnElectronicMail.Enabled = value;
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool ShowProgressBar
    {
        set => toolStripProgressBar1.Visible = value;
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    private bool ShowProgressLabel
    {
        set => tslblProgressMessage.Visible = value;
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool ShowFullDetail { get; set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string UserExplanation => ktxtUserExplanation.Text;

    public void MapiSendCompleted()
    {
        Completed(true);
        ProgressMessage = string.Empty;
    }

    public void SetInProgressState()
    {
        Cursor = Cursors.WaitCursor;
        ShowProgressLabel = true;
        ShowProgressBar = true;
        Application.DoEvents();
    }

    public void PopulateExceptionTab(IEnumerable<Exception> exceptions)
    {
        var exs = exceptions as Exception[] ?? exceptions.ToArray();
        if (exs.Length == 1)
        {
            var exception = exs.FirstOrDefault();
            AddExceptionControl(kpExceptions, exception);
        }
        else
        {
            var innerTabControl = new TabControl { Dock = DockStyle.Fill };
            kpExceptions.Controls.Add(innerTabControl);
            for (var index = 0; index < exs.Length; index++)
            {
                var exception = exs[index];
                var tabPage = new TabPage { Text = $@"Exception {index + 1}" };
                innerTabControl.TabPages.Add(tabPage);
                AddExceptionControl(tabPage, exception);
            }
        }
    }

    public void PopulateAssembliesTab()
    {
        klvAssemblies.Clear();
        klvAssemblies.Columns.Add("Name", 320, HorizontalAlignment.Left);
        klvAssemblies.Columns.Add("Version", 150, HorizontalAlignment.Left);

        _presenter.GetReferencedAssemblies().ForEach(AddAssembly);
    }

    public void PopulateSysInfoTab()
    {
        var rootNode = CreateSysInfoTree();
        ktvEnvironment.Nodes.Add(rootNode);
        rootNode.Expand();
    }

    public void SetProgressCompleteState()
    {
        Cursor = Cursors.Default;
        ShowProgressLabel = ShowProgressBar = false;
    }

    public void ToggleShowFullDetail()
    {
        if (ShowFullDetail)
        {
            kpnlLessDetails.Hide();
            kbtnLessDetail.Text = Properties.Resources.ExceptionReportView_ToggleShowFullDetail_Less_Detail;
            kpnlMain.Show();
            kpnlButtons.Show();
            Size = new Size(613, 537);
        }
        else
        {
            kpnlLessDetails.Show();
            kbtnSimpleDetailToggle.Text = Properties.Resources.ExceptionReportView_ToggleShowFullDetail_More_Detail;
            kpnlMain.Hide();
            kpnlButtons.Hide();
            Size = new Size(415, 235);
        }
    }

    public void ShowWindow()
    {
        _isDataRefreshRequired = true;
        ShowDialog();
    }

    public void Completed(bool success)
    {
        ProgressMessage = success ? Properties.Resources.Report_sent : Properties.Resources.Failed_to_send_report;
        ShowProgressBar = false;
        kbtnElectronicMail.Enabled = true;
    }

    public void ShowError(string message, Exception exception)
    {
        KryptonMessageBox.Show(message, Properties.Resources.ExceptionReportView_ShowError_Error_sending_report, KryptonMessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
    }
    #endregion

    #region Constructor
    public ExceptionReportView(ExceptionReportInfo reportInfo)
    {
        ShowFullDetail = true;

        InitializeComponent();

        TopMost = reportInfo.TopMost;

        _presenter = new ExceptionReportPresenter(this, reportInfo);

        WireUpEvents();
        PopulateTabs();
        PopulateReportInfo(reportInfo);
    }
    #endregion

    #region Methods
    private void PopulateReportInfo(ExceptionReportInfo reportInfo)
    {
        klblExplanation.Text = reportInfo.UserExplanationLabel ?? Properties.Resources.Please_enter_a_brief_explanation_of_events_leading_up_to_this_exception;
        ShowFullDetail = reportInfo.ShowFullDetail;
        ToggleShowFullDetail();
        kbtnLessDetail.Visible = reportInfo.ShowLessDetailButton;

        //TODO: show all exception messages
        ktxtExceptionMessageLarge.Text =
            ktxtExceptionMessage.Text =
                !string.IsNullOrEmpty(reportInfo.CustomMessage) ? reportInfo.CustomMessage : reportInfo.Exceptions.First().Message;

        ktxtExceptionMessageLarge2.Text = ktxtExceptionMessageLarge.Text;

        ktxtDate.Text = reportInfo.ExceptionDate.ToShortDateString();
        ktxtTime.Text = reportInfo.ExceptionDate.ToShortTimeString();
        ktxtApplicationName.Text = reportInfo.AppName;
        ktxtVersion.Text = reportInfo.AppVersion;

        if (!reportInfo.ShowButtonIcons)
        {
            RemoveButtonIcons();
        }

        if (!reportInfo.ShowEmailButton)
        {
            RemoveEmailButton();
        }

        Text = reportInfo.TitleText ?? Properties.Resources.ErrorReport;
        ktxtUserExplanation.StateCommon.Content.Font = new Font(ktxtUserExplanation.StateCommon.Content.Font?.FontFamily!, reportInfo.UserExplanationFontSize);
        klblContactCompany.Text =
            string.Format(
                Properties.Resources.ExceptionReportView_PopulateReportInfo_If_this_problem_persists__please_contact__0__support_ +
                Environment.NewLine, reportInfo.CompanyName);
        kbtnSimpleEmail.Text =
            $@"{(reportInfo.SendMethod == ReportSendMethod.WebService ? Properties.Resources.Send : "Email")} {(reportInfo.SendMethod == ReportSendMethod.WebService && !reportInfo.CompanyName.IsEmpty() ? string.Format(Properties.Resources.to__0_, reportInfo.CompanyName) : reportInfo.CompanyName)}";
        kbtnElectronicMail.Text = reportInfo.SendMethod == ReportSendMethod.WebService ? Properties.Resources.Send : "Email";
    }

    private void RemoveEmailButton()
    {
        this.kbtnSimpleEmail.Hide();
        this.kbtnElectronicMail.Hide();
        this.kbtnCopy.Location = kbtnElectronicMail.Location;
        this.kbtnSimpleCopy.Location = kbtnSimpleEmail.Location;
    }

    private void RemoveButtonIcons()
    {
        // removing the icons, requires a bit of reshuffling of positions
        kbtnCopy.Values.Image = kbtnElectronicMail.Values.Image = kbtnSave.Values.Image = null;
        kbtnClose.Height = kbtnLessDetail.Height = kbtnCopy.Height = kbtnElectronicMail.Height = kbtnSave.Height = 27;
        //kbtnClose.TextAlign = btnDetailToggle.TextAlign = btnCopy.TextAlign = btnEmail.TextAlign = btnSave.TextAlign = ContentAlignment.MiddleCenter;
        kbtnClose.Font = kbtnLessDetail.Font = kbtnSave.Font = kbtnElectronicMail.Font = kbtnCopy.Font = new Font(kbtnCopy.Font.FontFamily, 8.25f);
        ShiftDown3Pixels([kbtnClose, kbtnLessDetail, kbtnCopy, kbtnElectronicMail, kbtnSave]);
    }

    private static void ShiftDown3Pixels(IEnumerable<Control> buttons)
    {
        foreach (var button in buttons)
        {
            button.Location = Point.Add(button.Location, new Size(new Point(0, 3)));
        }
    }

    private void WireUpEvents()
    {
        kbtnElectronicMail.Click += Email_Click;
        kbtnSimpleEmail.Click += Email_Click;
        kbtnCopy.Click += Copy_Click;
        kbtnSimpleCopy.Click += Copy_Click;
        kbtnClose.Click += Close_Click;
        kbtnLessDetail.Click += Detail_Click;
        kbtnSimpleDetailToggle.Click += Detail_Click;
        kbtnSave.Click += Save_Click;
        KeyPreview = true;
        KeyDown += ExceptionReportView_KeyDown;
    }

    /// <summary>
    /// starts with all tabs visible, and removes ones that aren't configured to show
    /// </summary>
    private void PopulateTabs()
    {
        if (!_presenter.ReportInfo.ShowGeneralTab)
        {
            kryptonNavigator1.Pages.Remove(kpGeneral);
        }
        if (!_presenter.ReportInfo.ShowExceptionsTab)
        {
            kryptonNavigator1.Pages.Remove(kpExceptions);
        }
        if (!_presenter.ReportInfo.ShowAssembliesTab)
        {
            kryptonNavigator1.Pages.Remove(kpAssemblies);
        }
        if (!_presenter.ReportInfo.ShowSysInfoTab)
        {
            kryptonNavigator1.Pages.Remove(kpSystemInformation);
        }
    }

    private void AddExceptionControl(Control control, Exception? exception)
    {
        var exceptionDetail = new ExceptionDetailControl();
        exceptionDetail.SetControlBackgrounds(_presenter.ReportInfo.BackgroundColor);
        exceptionDetail.PopulateExceptionTab(exception!);
        exceptionDetail.Dock = DockStyle.Fill;
        control.Controls.Add(exceptionDetail);
    }

    private void AddAssembly(AssemblyRef assembly)
    {
        var listViewItem = new ListViewItem
        {
            Text = assembly.Name
        };
        listViewItem.SubItems.Add(assembly.Version);
        klvAssemblies.Items.Add(listViewItem);
    }

    private TreeNode CreateSysInfoTree()
    {
        var rootNode = new TreeNode("System");

        foreach (var sysInfoResult in _presenter.GetSysInfoResults())
        {
            SysInfoResultMapperWinForm.AddTreeViewNode(rootNode, sysInfoResult);
        }

        return rootNode;
    }
    #endregion

    #region Event Handlers

    private void ExceptionReportView_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Escape)
        {
            Close();
        }
    }

    private void Copy_Click(object? sender, EventArgs e)
    {
        _presenter.CopyReportToClipboard();
    }

    private void Close_Click(object? sender, EventArgs e)
    {
        Close();
    }

    private void Detail_Click(object? sender, EventArgs e)
    {
        _presenter.ToggleDetail();
    }

    private void Email_Click(object? sender, EventArgs e)
    {
        _presenter.SendReport();
    }

    private void Save_Click(object? sender, EventArgs e)
    {
        var saveDialog = new SaveFileDialog
        {
            Filter = @"Archive (*.zip)|*.zip|All files (*.*)|*.*",
            FilterIndex = 1,
            RestoreDirectory = true
        };
        if (saveDialog.ShowDialog() == DialogResult.OK)
        {
            _presenter.SaveZipReportToFile(saveDialog.FileName);
        }
    }

    #endregion

    #region Protected

    protected override void OnActivated(EventArgs e)
    {
        base.OnActivated(e);

        if (_isDataRefreshRequired)
        {
            _isDataRefreshRequired = false;

            _presenter.PopulateReport();
        }
    }

    protected override void OnSizeChanged(EventArgs e)
    {
        base.OnSizeChanged(e);

        FormBorderStyle = ShowFullDetail ? FormBorderStyle.Sizable : FormBorderStyle.FixedDialog;
    }

    #endregion
}