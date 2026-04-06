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

using Timer = System.Windows.Forms.Timer;

namespace Krypton.Toolkit.Suite.Extended.Controls;

/// <summary>
/// A themed panel that accepts files (and optionally folders) dropped from Windows Explorer,
/// with optional click-to-browse using <see cref="OpenFileDialog"/>, and optional session quota with a progress bar.
/// </summary>
[ToolboxBitmap(typeof(KryptonPanel))]
[DefaultEvent(nameof(FilesDropped))]
[DefaultProperty(nameof(PromptText))]
[Description("Themed drop surface for files from Windows Explorer, optional open-file on click.")]
public class KryptonDropZone : KryptonPanel
{
    private string _promptText = "Drop files here";
    private string _allowedFileExtensions = string.Empty;
    private string _openFileDialogTitle = "Select files";
    private string _openFileDialogFilter = string.Empty;
    private List<string>? _allowedExtensionList;
    private bool _dragOver;
    private bool _showDragFeedback = true;
    private bool _acceptDirectories;
    private bool _openFileDialogOnClick = true;
    private int _maximumFileCount;
    private int _quotaMaximum;
    private int _acceptedPathCount;
    private bool _showQuotaProgress;
    private int _quotaProgressBarHeight = 14;
    private bool _showQuotaText = true;
    private bool _animateVisualFeedback = true;
    private Timer? _visualFeedbackTimer;
    private float _dragFeedbackPhase;
    private double _quotaFillDisplayed;

    /// <summary>Occurs when the user drops accepted files or completes a browse operation.</summary>
    public event EventHandler<DropZoneFilesDroppedEventArgs>? FilesDropped;

    /// <summary>Hint text drawn in the center of the control.</summary>
    [Category("Appearance")]
    [DefaultValue("Drop files here")]
    [Localizable(true)]
    public string PromptText
    {
        get => _promptText;
        set
        {
            _promptText = value ?? string.Empty;
            Invalidate();
        }
    }

    /// <summary>
    /// Optional extension filter for <b>files</b> only. Separate with semicolons, commas, or spaces (e.g. <c>.png;.jpg</c>).
    /// Folders ignore this filter when <see cref="AcceptDirectories"/> is true.
    /// </summary>
    [Category("Behavior")]
    [DefaultValue("")]
    public string AllowedFileExtensions
    {
        get => _allowedFileExtensions;
        set
        {
            _allowedFileExtensions = value ?? string.Empty;
            RebuildExtensionList();
        }
    }

    /// <summary>When true, directory paths from a drop are included in <see cref="DropZoneFilesDroppedEventArgs.FilePaths"/>.</summary>
    [Category("Behavior")]
    [DefaultValue(false)]
    public bool AcceptDirectories
    {
        get => _acceptDirectories;
        set => _acceptDirectories = value;
    }

    /// <summary>Maximum number of paths taken from each drop or browse operation; 0 means no per-operation limit. For a cap across multiple operations, use <see cref="QuotaMaximum"/>.</summary>
    [Category("Behavior")]
    [DefaultValue(0)]
    public int MaximumFileCount
    {
        get => _maximumFileCount;
        set => _maximumFileCount = value < 0 ? 0 : value;
    }

    /// <summary>
    /// When greater than zero, limits how many paths are accepted in total across all drops and browse operations until <see cref="ResetUploadQuota"/> is called.
    /// Works together with <see cref="MaximumFileCount"/> (per-operation cap is applied first, then the remaining session quota).
    /// </summary>
    [Category("Behavior")]
    [DefaultValue(0)]
    [Description("Session-wide cap on accepted paths; 0 disables quota. Use with ShowQuotaProgress to display usage.")]
    public int QuotaMaximum
    {
        get => _quotaMaximum;
        set
        {
            var v = value < 0 ? 0 : value;
            if (_quotaMaximum == v)
            {
                return;
            }

            _quotaMaximum = v;
            if (_acceptedPathCount > _quotaMaximum)
            {
                _acceptedPathCount = _quotaMaximum;
            }

            _quotaFillDisplayed = Math.Min(_quotaFillDisplayed, _acceptedPathCount);
            Invalidate();
            UpdateVisualFeedbackTimer();
        }
    }

    /// <summary>Number of paths accepted since the last <see cref="ResetUploadQuota"/> while <see cref="QuotaMaximum"/> is in use.</summary>
    [Category("Behavior")]
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int AcceptedPathCount => _acceptedPathCount;

    /// <summary>When true and <see cref="QuotaMaximum"/> is greater than zero, draws a quota progress bar along the bottom edge.</summary>
    [Category("Appearance")]
    [DefaultValue(false)]
    public bool ShowQuotaProgress
    {
        get => _showQuotaProgress;
        set
        {
            if (_showQuotaProgress == value)
            {
                return;
            }

            _showQuotaProgress = value;
            Invalidate();
            UpdateVisualFeedbackTimer();
        }
    }

    /// <summary>Height in pixels of the quota bar when <see cref="ShowQuotaProgress"/> is on.</summary>
    [Category("Appearance")]
    [DefaultValue(14)]
    public int QuotaProgressBarHeight
    {
        get => _quotaProgressBarHeight;
        set
        {
            var h = value < 4 ? 4 : value;
            if (_quotaProgressBarHeight == h)
            {
                return;
            }

            _quotaProgressBarHeight = h;
            Invalidate();
        }
    }

    /// <summary>When true and the quota bar is tall enough, draws current and maximum counts on the bar.</summary>
    [Category("Appearance")]
    [DefaultValue(true)]
    public bool ShowQuotaText
    {
        get => _showQuotaText;
        set
        {
            if (_showQuotaText == value)
            {
                return;
            }

            _showQuotaText = value;
            Invalidate();
        }
    }

    /// <summary>When true, a dashed border is shown while the pointer is over the control with a valid drag.</summary>
    [Category("Appearance")]
    [DefaultValue(true)]
    public bool ShowDragFeedback
    {
        get => _showDragFeedback;
        set
        {
            if (_showDragFeedback == value)
            {
                return;
            }

            _showDragFeedback = value;
            UpdateVisualFeedbackTimer();
        }
    }

    /// <summary>
    /// When true, drag-over feedback uses a moving dash pattern and pulsing border; the quota bar eases toward the new value instead of jumping.
    /// </summary>
    [Category("Appearance")]
    [DefaultValue(true)]
    public bool AnimateVisualFeedback
    {
        get => _animateVisualFeedback;
        set
        {
            if (_animateVisualFeedback == value)
            {
                return;
            }

            _animateVisualFeedback = value;
            if (!value)
            {
                _quotaFillDisplayed = _acceptedPathCount;
            }

            Invalidate();
            UpdateVisualFeedbackTimer();
        }
    }

    /// <summary>When true, a click opens <see cref="OpenFileDialog"/> and raises <see cref="FilesDropped"/> for the selection.</summary>
    [Category("Behavior")]
    [DefaultValue(true)]
    public bool OpenFileDialogOnClick
    {
        get => _openFileDialogOnClick;
        set
        {
            if (_openFileDialogOnClick == value)
            {
                return;
            }

            _openFileDialogOnClick = value;
            Cursor = value ? Cursors.Hand : Cursors.Default;
        }
    }

    /// <summary>Title for the browse dialog when <see cref="OpenFileDialogOnClick"/> is true.</summary>
    [Category("Behavior")]
    [DefaultValue("Select files")]
    [Localizable(true)]
    public string OpenFileDialogTitle
    {
        get => _openFileDialogTitle;
        set => _openFileDialogTitle = value ?? string.Empty;
    }

    /// <summary>
    /// Filter for the browse dialog (same format as <see cref="OpenFileDialog.Filter"/>). Empty uses "All files|*.*".
    /// </summary>
    [Category("Behavior")]
    [DefaultValue("")]
    [Localizable(true)]
    public string OpenFileDialogFilter
    {
        get => _openFileDialogFilter;
        set => _openFileDialogFilter = value ?? string.Empty;
    }

    /// <summary>Initializes a new instance of the <see cref="KryptonDropZone"/> class.</summary>
    public KryptonDropZone()
    {
        AllowDrop = true;
        SetStyle(ControlStyles.ResizeRedraw, true);
        Cursor = Cursors.Hand;
        RebuildExtensionList();
    }

    /// <summary>Raises the <see cref="FilesDropped"/> event.</summary>
    /// <param name="e">The event data.</param>
    protected virtual void OnFilesDropped(DropZoneFilesDroppedEventArgs e) => FilesDropped?.Invoke(this, e);

    /// <summary>Clears the session quota counter so new paths can be accepted again.</summary>
    public void ResetUploadQuota()
    {
        if (_acceptedPathCount == 0)
        {
            return;
        }

        _acceptedPathCount = 0;
        _quotaFillDisplayed = 0;
        Invalidate();
        UpdateVisualFeedbackTimer();
    }

    /// <inheritdoc />
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (_visualFeedbackTimer != null)
            {
                _visualFeedbackTimer.Tick -= OnVisualFeedbackTimerTick;
                _visualFeedbackTimer.Stop();
                _visualFeedbackTimer.Dispose();
                _visualFeedbackTimer = null;
            }
        }

        base.Dispose(disposing);
    }

    /// <inheritdoc />
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        var g = e.Graphics;
        var promptRect = GetPromptLayoutRectangle();

        if (!string.IsNullOrEmpty(_promptText))
        {
            TextRenderer.DrawText(
                g,
                _promptText,
                Font,
                promptRect,
                ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak |
                TextFormatFlags.EndEllipsis | TextFormatFlags.NoPadding);
        }

        if (_dragOver && _showDragFeedback)
        {
            var rect = new Rectangle(2, 2, promptRect.Width - 5, promptRect.Height - 5);
            var baseColor = GetFeedbackPenColor();
            var penColor = baseColor;
            if (_animateVisualFeedback)
            {
                var pulse = 0.45 + 0.55 * Math.Sin(_dragFeedbackPhase * 0.14);
                var alpha = (int)(100 + 155 * pulse);
                alpha = Math.Min(Math.Max(alpha, 60), 255);
                penColor = Color.FromArgb(alpha, baseColor.R, baseColor.G, baseColor.B);
            }

            using var pen = new Pen(penColor, 2) { DashStyle = DashStyle.Dash };
            if (_animateVisualFeedback)
            {
                pen.DashOffset = _dragFeedbackPhase * 1.8f % 24f;
            }

            g.DrawRectangle(pen, rect);
        }

        PaintQuotaProgressBar(g);
    }

    /// <inheritdoc />
    protected override void OnDragEnter(DragEventArgs drgevent)
    {
        if (!AllowDrop)
        {
            base.OnDragEnter(drgevent);
            return;
        }

        UpdateDragEffect(drgevent);
        base.OnDragEnter(drgevent);
    }

    /// <inheritdoc />
    protected override void OnDragOver(DragEventArgs drgevent)
    {
        if (!AllowDrop)
        {
            base.OnDragOver(drgevent);
            return;
        }

        UpdateDragEffect(drgevent);
        base.OnDragOver(drgevent);
    }

    /// <inheritdoc />
    protected override void OnDragLeave(EventArgs e)
    {
        if (_dragOver)
        {
            _dragOver = false;
            Invalidate();
            UpdateVisualFeedbackTimer();
        }

        base.OnDragLeave(e);
    }

    /// <inheritdoc />
    protected override void OnDragDrop(DragEventArgs drgevent)
    {
        _dragOver = false;
        Invalidate();
        UpdateVisualFeedbackTimer();

        if (!AllowDrop || !drgevent.Data.GetDataPresent(DataFormats.FileDrop))
        {
            base.OnDragDrop(drgevent);
            return;
        }

        if (drgevent.Data.GetData(DataFormats.FileDrop) is not string[] raw)
        {
            base.OnDragDrop(drgevent);
            return;
        }

        var accepted = ProcessIncomingPaths(raw);
        if (accepted.Count > 0)
        {
            CommitAcceptedPaths(accepted.Count);
            OnFilesDropped(new DropZoneFilesDroppedEventArgs(accepted));
        }

        base.OnDragDrop(drgevent);
    }

    /// <inheritdoc />
    protected override void OnClick(EventArgs e)
    {
        base.OnClick(e);

        if (!OpenFileDialogOnClick || !Enabled)
        {
            return;
        }

        using var ofd = new OpenFileDialog
        {
            Title = string.IsNullOrWhiteSpace(_openFileDialogTitle) ? "Select files" : _openFileDialogTitle,
            Filter = string.IsNullOrWhiteSpace(_openFileDialogFilter) ? @"All files|*.*" : _openFileDialogFilter,
            Multiselect = true,
        };

        var owner = FindForm();
        if (owner != null)
        {
            if (ofd.ShowDialog(owner) != DialogResult.OK)
            {
                return;
            }
        }
        else if (ofd.ShowDialog() != DialogResult.OK)
        {
            return;
        }

        var accepted = ProcessIncomingPaths(ofd.FileNames);
        if (accepted.Count > 0)
        {
            CommitAcceptedPaths(accepted.Count);
            OnFilesDropped(new DropZoneFilesDroppedEventArgs(accepted));
        }
    }

    private void UpdateDragEffect(DragEventArgs drgevent)
    {
        if (!drgevent.Data.GetDataPresent(DataFormats.FileDrop))
        {
            SetDragOver(false);
            drgevent.Effect = DragDropEffects.None;
            return;
        }

        if (drgevent.Data.GetData(DataFormats.FileDrop) is not string[] raw)
        {
            SetDragOver(false);
            drgevent.Effect = DragDropEffects.None;
            return;
        }

        var accepted = ProcessIncomingPaths(raw);
        if (accepted.Count == 0)
        {
            SetDragOver(false);
            drgevent.Effect = DragDropEffects.None;
        }
        else
        {
            SetDragOver(true);
            drgevent.Effect = DragDropEffects.Copy;
        }
    }

    private void SetDragOver(bool value)
    {
        if (_dragOver == value)
        {
            return;
        }

        _dragOver = value;
        Invalidate();
        UpdateVisualFeedbackTimer();
    }

    private Rectangle GetPromptLayoutRectangle()
    {
        var reserve = QuotaBarReservedHeight();
        if (reserve <= 0)
        {
            return ClientRectangle;
        }

        var h = ClientSize.Height - reserve;
        return h <= 0 ? ClientRectangle : new Rectangle(0, 0, ClientSize.Width, h);
    }

    private int QuotaBarReservedHeight()
    {
        if (!_showQuotaProgress || _quotaMaximum <= 0)
        {
            return 0;
        }

        return _quotaProgressBarHeight + 4;
    }

    private void PaintQuotaProgressBar(Graphics g)
    {
        if (!_showQuotaProgress || _quotaMaximum <= 0)
        {
            return;
        }

        var h = Math.Min(_quotaProgressBarHeight, Math.Max(4, Height - 8));
        var barRect = new Rectangle(2, Height - h - 2, Width - 4, h);
        if (barRect.Width <= 0 || barRect.Height <= 0)
        {
            return;
        }

        var palette = KryptonManager.CurrentGlobalPalette;
        var track = palette?.GetBackColor1(PaletteBackStyle.PanelClient, PaletteState.Normal)
                    ?? SystemColors.ControlLight;
        var fill = palette?.GetBackColor1(PaletteBackStyle.ButtonStandalone, PaletteState.Checked)
                   ?? SystemColors.Highlight;
        var border = palette?.GetBorderColor1(PaletteBorderStyle.ButtonStandalone, PaletteState.Normal)
                     ?? SystemColors.ControlDark;

        using (var b = new SolidBrush(track))
        {
            g.FillRectangle(b, barRect);
        }

        var fillNumerator = !_animateVisualFeedback || _quotaMaximum <= 0
            ? _acceptedPathCount
            : _quotaFillDisplayed;
        var fillW = _quotaMaximum <= 0
            ? 0
            : (int)Math.Round(fillNumerator / _quotaMaximum * barRect.Width);
        fillW = Math.Min(Math.Max(0, fillW), barRect.Width);
        if (fillW > 0)
        {
            var fillRect = new Rectangle(barRect.X, barRect.Y, fillW, barRect.Height);
            using var b = new SolidBrush(fill);
            g.FillRectangle(b, fillRect);
        }

        using (var pen = new Pen(border))
        {
            g.DrawRectangle(pen, new Rectangle(barRect.X, barRect.Y, barRect.Width - 1, barRect.Height - 1));
        }

        if (_showQuotaText && barRect.Height >= 12)
        {
            var label = $"{_acceptedPathCount} / {_quotaMaximum}";
            TextRenderer.DrawText(
                g,
                label,
                Font,
                barRect,
                ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine |
                TextFormatFlags.NoPadding);
        }
    }

    private List<string> ProcessIncomingPaths(IReadOnlyList<string> paths)
    {
        var list = CollectValidPaths(paths);
        return ApplySessionQuota(list);
    }

    private List<string> ApplySessionQuota(List<string> paths)
    {
        if (_quotaMaximum <= 0)
        {
            return paths;
        }

        var remaining = _quotaMaximum - _acceptedPathCount;
        if (remaining <= 0)
        {
            return [];
        }

        if (paths.Count <= remaining)
        {
            return paths;
        }

        return paths.GetRange(0, remaining);
    }

    private void CommitAcceptedPaths(int count)
    {
        if (_quotaMaximum <= 0 || count <= 0)
        {
            return;
        }

        _acceptedPathCount = Math.Min(_quotaMaximum, _acceptedPathCount + count);
        Invalidate();
        UpdateVisualFeedbackTimer();
    }

    private void EnsureVisualFeedbackTimer()
    {
        if (_visualFeedbackTimer != null)
        {
            return;
        }

        _visualFeedbackTimer = new Timer { Interval = 33 };
        _visualFeedbackTimer.Tick += OnVisualFeedbackTimerTick;
    }

    private void OnVisualFeedbackTimerTick(object? sender, EventArgs e)
    {
        var needAnotherFrame = false;

        if (_animateVisualFeedback && _dragOver && _showDragFeedback)
        {
            _dragFeedbackPhase += 0.35f;
            if (_dragFeedbackPhase > 6283f)
            {
                _dragFeedbackPhase = 0;
            }

            needAnotherFrame = true;
        }

        if (_animateVisualFeedback && _showQuotaProgress && _quotaMaximum > 0)
        {
            var target = _acceptedPathCount;
            var delta = target - _quotaFillDisplayed;
            if (delta > 0.001 || delta < -0.001)
            {
                _quotaFillDisplayed += delta * 0.28;
                if (Math.Abs(target - _quotaFillDisplayed) < 0.05)
                {
                    _quotaFillDisplayed = target;
                }

                needAnotherFrame = Math.Abs(target - _quotaFillDisplayed) > 0.001;
            }
            else
            {
                _quotaFillDisplayed = target;
            }
        }
        else if (_quotaMaximum > 0)
        {
            _quotaFillDisplayed = _acceptedPathCount;
        }

        Invalidate();

        if (!needAnotherFrame && !ShouldRunVisualFeedbackTimer())
        {
            _visualFeedbackTimer?.Stop();
        }
    }

    private bool ShouldRunVisualFeedbackTimer()
    {
        var drag = _animateVisualFeedback && _dragOver && _showDragFeedback;
        var quota = _animateVisualFeedback && _showQuotaProgress && _quotaMaximum > 0
                    && Math.Abs(_quotaFillDisplayed - _acceptedPathCount) > 0.001;
        return drag || quota;
    }

    private void UpdateVisualFeedbackTimer()
    {
        if (!IsHandleCreated || DesignMode)
        {
            return;
        }

        if (ShouldRunVisualFeedbackTimer())
        {
            EnsureVisualFeedbackTimer();
            _visualFeedbackTimer!.Start();
        }
        else
        {
            _visualFeedbackTimer?.Stop();
        }
    }

    private List<string> CollectValidPaths(IReadOnlyList<string> paths)
    {
        var result = new List<string>();
        foreach (var path in paths)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                continue;
            }

            string full;
            try
            {
                full = Path.GetFullPath(path);
            }
            catch
            {
                continue;
            }

            if (Directory.Exists(full))
            {
                if (_acceptDirectories)
                {
                    result.Add(full);
                }
            }
            else if (File.Exists(full) && MatchesExtension(full))
            {
                result.Add(full);
            }

            if (_maximumFileCount > 0 && result.Count >= _maximumFileCount)
            {
                break;
            }
        }

        return result;
    }

    private bool MatchesExtension(string filePath)
    {
        if (_allowedExtensionList is not { Count: > 0 })
        {
            return true;
        }

        var ext = Path.GetExtension(filePath);
        if (string.IsNullOrEmpty(ext))
        {
            return false;
        }

        ext = ext.ToLowerInvariant();
        foreach (var allowed in _allowedExtensionList)
        {
            if (ext == allowed)
            {
                return true;
            }
        }

        return false;
    }

    private void RebuildExtensionList()
    {
        if (string.IsNullOrWhiteSpace(_allowedFileExtensions))
        {
            _allowedExtensionList = null;
            return;
        }

        var parts = _allowedFileExtensions.Split([';', ',', ' '], StringSplitOptions.RemoveEmptyEntries);
        _allowedExtensionList = [];
        foreach (var p in parts)
        {
            var t = p.Trim();
            if (t.Length == 0)
            {
                continue;
            }

            if (!t.StartsWith(".", StringComparison.Ordinal))
            {
                t = "." + t;
            }

            _allowedExtensionList.Add(t.ToLowerInvariant());
        }

        if (_allowedExtensionList.Count == 0)
        {
            _allowedExtensionList = null;
        }
    }

    private Color GetFeedbackPenColor()
    {
        var palette = KryptonManager.CurrentGlobalPalette;
        return palette != null
            ? palette.GetBorderColor1(PaletteBorderStyle.ButtonStandalone, PaletteState.Tracking)
            : SystemColors.Highlight;
    }
}
