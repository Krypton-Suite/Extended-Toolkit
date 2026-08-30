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

using System.Reflection;

using Krypton.Toolkit.Utilities;

namespace TestForm;

public partial class StartScreen : KryptonForm
{
    private readonly List<KryptonCommandLinkButton> _buttons;
    private readonly IComparer<KryptonCommandLinkButton> _headingComparer;
    private readonly System.Windows.Forms.Timer _filterTimer;
    private readonly int _panelWidth;
    private readonly Size _sizeAtStartup;
    private readonly RegistryAccess _registryAccess;
    private bool _dockTopRight;

    public StartScreen()
    {
        InitializeComponent();

        _registryAccess = new RegistryAccess();
        _dockTopRight = false;
        _buttons = [];
        _headingComparer = new ButtonHeadingComparer();
        _panelWidth = tlpMain.Width;
        _filterTimer = new System.Windows.Forms.Timer();
        _sizeAtStartup = new Size(902, 633);

        Size = _sizeAtStartup;
        FormClosing += OnFormClosing;

        btnDockTopRight.Click += OnBtnDockTopRightClick;
        btnRestoreSize.Click += OnBtnRestoreSizeClick;

        SetupFilterBox();
        SetupExitButton();
        SetupTableLayoutPanel();
        AddButtons();
        SortButtons();
        AddButtonsToTlpMain();
        RestoreSettings();
    }

    /// <summary>
    /// Buttons to be displayed in the list can be added, removed, or altered here.
    /// </summary>
    private void AddButtons()
    {
        CreateButton<AdvancedDataGridView>("Advanced Data Grid", "Original Gironi-style lab with memory tests and saved filters.");
        CreateButton<AdvancedDataGridViewFilterSortExample>("Advanced Data Grid (Filter & Sort)", "Excel-style header dropdowns: checklist, custom filter, sort glyphs, saved views, search, RTL, and per-column options.");
        CreateButton<BasicToastNotificationTest>("Basic Toast Notification", "Exercise the basic toast notification API.");
        CreateButton<BottomSheetExample>("Bottom Sheet", "Modal and non-modal KryptonBottomSheet demos.");
        CreateButton<ButtonItems>("Button Items", "Extended button controls.");
        CreateButton<CalendarItems>("Calendar Items", "Extended calendar controls.");
        CreateButton<CardExample>("Card", "KryptonCard appearances, sections, and interaction.");
        CreateButton<CheckBoxComboBoxTest>("CheckBox ComboBox", "Checked combo box item selection.");
        CreateButton<CheckSumExample>("CheckSum Tools", "File checksum generation and verification.");
        CreateButton<CircularProgressBarExample>("Circular ProgressBar", "Extended circular progress bar.");
        CreateButton<CoreColourDialogExamples>("Core Colour Dialogs", "Core colour dialog examples.");
        CreateButton<CoreDialogExamples>("Core Dialogs", "Core specialised dialog examples.");
        CreateButton<DialogExamples>("Dialog Examples", "Extended dialog suite.");
        CreateButton<DockExtenderExample>("Dock Extender", "Dock extender host and float windows.");
        CreateButton<ExtendedControlExamples>("Extended Controls", "General extended control catalogue.");
        CreateButton<ExternalThemeSelectorChooser>("External Theme Selector", "Load and apply external palettes.");
        CreateButton<FloatingMenuToolbarExampleMain>("Floating Toolbars", "Floatable menu and tool strips.");
        CreateButton<FloatingMenuToolbarAdvancedExample>("Floating Toolbars (Advanced)", "Advanced floatable toolbar scenarios.");
        CreateButton<GanttChartExample>("Gantt Chart", "KryptonGanttChart scheduling demo.");
        CreateButton<KryptonFormExtended1>("Krypton Form Extended", "KryptonFormExtended chrome and behaviour.");
        CreateButton<MainWindow>("Examples Landing (legacy)", "Original button-grid launcher from the Examples project.");
        CreateButton<KryptonFormExtended2>("Krypton Form Extended 2", "Additional KryptonFormExtended scenarios.");
        CreateButton<KryptonInputBoxExtendedExample>("InputBox Extended", "KryptonInputBoxExtended prompts.");
        CreateButton<KryptonProgressBarExtendedExamples>("ProgressBar Extended", "Extended progress bar styles.");
        CreateButton<KryptonRibbonExtendedExample>("Ribbon Extended", "Extended ribbon features.");
        CreateButton<MemoryBoxExample>("Memory Box", "KryptonMemoryBox remember-choice dialog.");
        CreateButton<MessageBoxExample>("MessageBox Extended", "KryptonMessageBoxExtended options.");
        CreateButton<MessageBoxFooterExample>("MessageBox Footer", "Extended message box footer content.");
        CreateButton<NaviBarExample>("Navi Bar", "Outlook-style navigation bar.");
        CreateButton<RadialMenuExample>("Radial Menu", "Extended radial menu.");
        CreateButton<ThemeTools>("Theme Tools", "Theme switching and palette tools.");
        CreateButton<ToastNotificationMenu>("Toast Notifications", "Extended toast notification menu.");
        CreateButton<ToolBoxExample>("Tool Box", "Extended tool box control.");
        CreateButton<ToolStripItems>("Tool Strip Items", "Extended tool strip items.");
        CreateButton<TreeGridViewAdvancedExample>("TreeGridView Advanced", "Advanced tree grid features.");
        CreateButton<TreeGridViewDataSourceExample>("TreeGridView Data Source", "Data-bound tree grid.");
        CreateButton<TreeGridViewExample>("TreeGridView", "Hierarchical tree grid.");
        CreateButton<WizardExample>("Wizard", "Extended wizard control.");
    }

    private void OnFormClosing(object? sender, FormClosingEventArgs e)
    {
        SaveSettings();
    }

    private bool IsFormDockedTopRight()
    {
        return Top == 0
            && Left == Screen.FromControl(this).Bounds.Width - Size.Width;
    }

    private void SaveSettings()
    {
        _registryAccess.LastFilterString = tbFilter.Text;
        _registryAccess.DockTopRight = IsFormDockedTopRight();
        _registryAccess.FormSize = Size;
    }

    private void RestoreSettings()
    {
        RestoreFormSize();
        RestoreLastFilter();
        RestoreFormLocation();
    }

    private void RestoreFormLocation()
    {
        _dockTopRight = _registryAccess.DockTopRight;
        if (_dockTopRight)
        {
            OnBtnDockTopRightClick(null, EventArgs.Empty);
        }
    }

    private void RestoreLastFilter()
    {
        string lastFilter = _registryAccess.LastFilterString;
        if (lastFilter.Length > 0)
        {
            tbFilter.Text = lastFilter;
        }
    }

    private void RestoreFormSize()
    {
        Size size = _registryAccess.FormSize;
        if (size.Width > 0 && size.Height > 0)
        {
            Size = _registryAccess.FormSize;
        }
    }

    private void CreateButton<TForm>(string heading, string description, Image? image = null)
        where TForm : Form
    {
        KryptonCommandLinkButton button = new();
        Type formType = typeof(TForm);

        button.CommandLinkTextValues.Heading = heading;
        button.CommandLinkTextValues.Description = description;
        button.AccessibleName = heading;
        button.AccessibleDescription = description;
        button.AccessibleRole = AccessibleRole.PushButton;
        button.AutoSize = false;
        button.Dock = DockStyle.Fill;
        button.MinimumSize = new Size(0, 60);
        button.Size = new Size(_panelWidth - 10, 60);
        button.Click += (_, _) => OnCommandLinkTestButtonClick(formType);

        if (image is not null)
        {
            button.CommandLinkTextValues.UseDefaultImage = false;
            button.CommandLinkTextValues.Image = new Bitmap(image, 48, 48);
        }

        _buttons.Add(button);
    }

    private void SetupExitButton()
    {
        FontFamily family = KryptonManager.CurrentGlobalPalette.GetContentShortTextFont(PaletteContentStyle.InputControlStandalone, PaletteState.Normal)!.FontFamily;
        kbtnExit.StateCommon.Content.ShortText.Font = new Font(family, 14F, FontStyle.Regular);
    }

    private void SetupFilterBox()
    {
        tbFilter.Clear();

        FontFamily family = KryptonManager.CurrentGlobalPalette.GetContentShortTextFont(PaletteContentStyle.InputControlStandalone, PaletteState.Normal)!.FontFamily;
        tbFilter.StateCommon.Content.Font = new Font(family, 14F, FontStyle.Regular);
        tbFilter.TextChanged += OnFilterChanged;
        btnClearFilter.Click += (_, _) => tbFilter.Clear();

        _filterTimer.Interval = 200;
        _filterTimer.Tick += OnFilterChangedPerformFilter;
    }

    private void OnBtnRestoreSizeClick(object? sender, EventArgs e)
    {
        Size = _sizeAtStartup;
    }

    private void OnBtnDockTopRightClick(object? sender, EventArgs e)
    {
        _dockTopRight = true;
        Location = new Point(Screen.FromControl(this).Bounds.Width - Width, 0);
    }

    private void OnCommandLinkTestButtonClick(Type formType)
    {
        if (Activator.CreateInstance(formType) is Form form)
        {
            form.Show();
        }
    }

    private void SortButtons()
    {
        _buttons.Sort(_headingComparer);
    }

    private void SetupTableLayoutPanel()
    {
        SetTableLayoutPanelDoubleBuffered(true);
        tlpMain.RowCount = 0;
        tlpMain.ColumnCount = 1;

        tlpMain.AutoSize = false;
        tlpMain.BackColor = Color.Transparent;
        tlpMain.Padding = new Padding(0);
        tlpMain.Margin = new Padding(0);
        tlpMain.AutoScroll = true;

        tlpMain.RowStyles.Clear();
        tlpMain.ColumnStyles.Clear();
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
    }

    private void SetTableLayoutPanelDoubleBuffered(bool enableDoubleBuffering)
    {
        PropertyInfo? propertyInfo = typeof(TableLayoutPanel).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
        if (propertyInfo is not null)
        {
            propertyInfo.SetValue(tlpMain, enableDoubleBuffering);
        }
        else
        {
            throw new NullReferenceException(nameof(propertyInfo));
        }
    }

    private void AddButtonsToTlpMain()
    {
        _buttons.ForEach(button =>
        {
            tlpMain.RowCount += 1;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlpMain.Controls.Add(button, 0, tlpMain.RowCount - 1);
        });
    }

    private void OnFilterChanged(object? sender, EventArgs e)
    {
        _filterTimer.Stop();
        _filterTimer.Start();
    }

    private void OnFilterChangedPerformFilter(object? sender, EventArgs e)
    {
        _filterTimer.Stop();

        if (tbFilter.Text.Length > 0)
        {
            _buttons.ForEach(button => button.Visible = button.CommandLinkTextValues.Heading.IndexOf(tbFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        else
        {
            _buttons.ForEach(button => button.Visible = true);
        }

        if (tlpMain.Controls.Count > 0)
        {
            tlpMain.ScrollControlIntoView(tlpMain.Controls[0]);
        }
    }

    private void kbtnExit_Click(object? sender, EventArgs e)
    {
        Close();
    }

    private class ButtonHeadingComparer : IComparer<KryptonCommandLinkButton>
    {
        /// <summary>
        /// Compares the command link buttons case insensitive by their Heading string.
        /// </summary>
        public int Compare(KryptonCommandLinkButton? x, KryptonCommandLinkButton? y)
        {
            if (x is not null && y is not null)
            {
                string headingX = x.CommandLinkTextValues.Heading.ToLower(CultureInfo.InvariantCulture);
                string headingY = y.CommandLinkTextValues.Heading.ToLower(CultureInfo.InvariantCulture);

                return string.Compare(headingX, headingY, StringComparison.Ordinal);
            }

            throw new NullReferenceException("ButtonHeadingComparer: make sure that parameter x and y both are valid references to a KryptonCommandLinkButton instance.");
        }
    }
}
