using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.Controls;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class KryptonDropZone : KryptonPanel
{
    private ListView _fileListView;
    private Button _clearButton;
    private KryptonWrapLabel _instructionLabel;
    private KryptonProgressBarExtended _sizeProgressBar;
    private KryptonWrapLabel _sizeLabel;
    private List<string> _droppedFiles = new();

    private bool _isHovering = false; // ADDED: Hover state for transitions

    [Category("Behavior")]
    [Description("Whether to display the list of dropped files.")]
    [DefaultValue(false)]
    public bool ShowFileListView
    {
        get => _fileListView.Visible;
        set
        {
            if (_fileListView.Visible != value)
            {
                _fileListView.Visible = value;
                _fileListView.Height = value ? 150 : 0;
                
                // Also show/hide related controls
                _sizeProgressBar.Visible = value && ShowSizeProgressBar;
                _sizeLabel.Visible = value && ShowSizeProgressBar;
                _clearButton.Visible = value && ShowClearButton;
            }
        }
    }

    [Category("Behavior")]
    [Description("Whether to display the Clear All button.")]
    [DefaultValue(true)]
    public bool ShowClearButton
    {
        get => _clearButton.Visible;
        set => _clearButton.Visible = value;
    }

    [Category("Behavior")]
    [Description("Whether to display the file size progress bar.")]
    [DefaultValue(true)]
    public bool ShowSizeProgressBar
    {
        get => _sizeProgressBar.Visible;
        set
        {
            _sizeProgressBar.Visible = value;
            _sizeLabel.Visible = value;
        }
    }

    [Category("Behavior")]
    [Description("A list of allowed file extensions.")]
    public List<string> AllowedExtensions { get; set; } = new(); // CHANGED: No default list, user-defined

    [Category("Appearance")]
    [Description("The text displayed in the drop zone.")]
    [DefaultValue("Drag and drop files here or click to browse")]
    public string DropZoneText
    {
        get => _instructionLabel.Text;
        set => _instructionLabel.Text = value;
    }

    [Category("Appearance")]
    [Description("The color of the drop zone border.")]
    [DefaultValue(typeof(Color), "LightGray")]
    public Color BorderColor { get; set; } = Color.LightGray;

    [Category("Appearance")]
    [Description("The color of the drop zone border when hovering.")]
    [DefaultValue(typeof(Color), "DodgerBlue")]
    public Color HoverBorderColor { get; set; } = Color.DodgerBlue;

    [Category("Appearance")]
    [Description("Whether to show a subtle shadow effect on hover.")]
    [DefaultValue(true)]
    public bool ShowHoverShadow { get; set; } = true;

    [Category("Appearance")]
    [Description("Whether to use Krypton theme colors automatically.")]
    [DefaultValue(true)]
    public bool UseKryptonTheme { get; set; } = true;

    [Category("Appearance")]
    [Description("The opacity of the background pattern (0-255).")]
    [DefaultValue(3)]
    public int BackgroundPatternOpacity { get; set; } = 3;

    [Category("Data")]
    [Description("Total size of all dropped files in bytes.")]
    [Browsable(false)]
    public long TotalFileSize { get; private set; }

    [Category("Data")]
    [Description("Formatted string representation of total file size.")]
    [Browsable(false)]
    public string TotalFileSizeFormatted => FormatFileSize(TotalFileSize);

    public event EventHandler<List<string>> ValidFilesDropped;

    public KryptonDropZone()
    {
        AllowDrop = true;
        InitializeControls();
        RegisterEvents();
        ApplyThemeStyling();
        
        // Make the control clickable for file browsing
        Click += (s, e) => BrowseForFiles();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            // Unsubscribe from theme changes to prevent memory leaks
            KryptonManager.GlobalPaletteChanged -= OnGlobalPaletteChanged;
        }
        base.Dispose(disposing);
    }

    private void BrowseForFiles()
    {
        using var openFileDialog = new OpenFileDialog
        {
            Multiselect = true,
            Title = "Select Files",
            Filter = "All Files (*.*)|*.*"
        };

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            // Simulate a drop event with the selected files
            var data = new DataObject(DataFormats.FileDrop, openFileDialog.FileNames);
            var args = new DragEventArgs(data, 0, 0, 0, DragDropEffects.Copy, DragDropEffects.Copy);
            HandleDrop(args);
        }
    }

    private void InitializeControls()
    {
        // Create a more centered, minimalist layout
        _instructionLabel = new KryptonWrapLabel
        {
            Text = "Drag and drop files here or click to browse",
            TextAlign = ContentAlignment.MiddleCenter,
            Dock = DockStyle.Fill,
            Font = new Font("Segoe UI", 10, FontStyle.Regular),
            ForeColor = Color.DimGray
        };

        _fileListView = new ListView
        {
            Dock = DockStyle.Bottom,
            View = View.Details,
            HeaderStyle = ColumnHeaderStyle.None,
            FullRowSelect = true,
            SmallImageList = new ImageList { ImageSize = new Size(32, 32), ColorDepth = ColorDepth.Depth32Bit },
            AllowDrop = false,
            Height = 0, // Start collapsed
            Visible = false
        };
        _fileListView.Columns.Add("Files", -2);
        _fileListView.ItemDrag += (s, e) => _fileListView.DoDragDrop(e.Item, DragDropEffects.Move);
        _fileListView.DragEnter += (s, e) => e.Effect = DragDropEffects.Move;
        _fileListView.DragDrop += (s, e) => HandleListReorder(e);

        _sizeProgressBar = new KryptonProgressBarExtended
        {
            Dock = DockStyle.Bottom,
            Height = 20,
            Visible = false,
            Minimum = 0,
            Maximum = 100,
            Value = 0
        };
        
        _sizeLabel = new KryptonWrapLabel
        {
            Text = "0 bytes",
            TextAlign = ContentAlignment.MiddleCenter,
            Dock = DockStyle.Bottom,
            Visible = false,
            Height = 20
        };

        _clearButton = new Button
        {
            Text = "Clear All",
            Dock = DockStyle.Bottom,
            Height = 30,
            BackColor = Color.Transparent,
            FlatStyle = FlatStyle.Flat,
            Visible = false
        };
        _clearButton.FlatAppearance.BorderSize = 0;
        _clearButton.ForeColor = KryptonManager.CurrentGlobalPalette?.GetRibbonTextColor(PaletteRibbonTextStyle.RibbonTab, PaletteState.Normal) ?? SystemColors.ControlText;
        _clearButton.Click += (s, e) => ClearFiles();

        // Add controls in order (bottom to top for proper layering)
        Controls.Add(_clearButton);
        Controls.Add(_sizeLabel);
        Controls.Add(_sizeProgressBar);
        Controls.Add(_fileListView);
        Controls.Add(_instructionLabel);
    }

    private void RegisterEvents()
    {
        DragEnter += (s, e) => { e.Effect = DragDropEffects.Copy; _isHovering = true; Invalidate(); }; // ADDED
        DragLeave += (s, e) => { _isHovering = false; Invalidate(); }; // ADDED
        DragDrop += (s, e) => { HandleDrop(e); _isHovering = false; Invalidate(); }; // CHANGED
    }

    private void ApplyThemeStyling()
    {
        if (UseKryptonTheme)
        {
            // Use Krypton theming system for colors and styling
            StateCommon.Color1 = KryptonManager.CurrentGlobalPalette?.GetBackColor1(PaletteBackStyle.PanelClient, PaletteState.Normal) ?? Color.WhiteSmoke;
            StateCommon.Color2 = KryptonManager.CurrentGlobalPalette?.GetBackColor2(PaletteBackStyle.PanelClient, PaletteState.Normal) ?? Color.WhiteSmoke;
            
            // Set border colors based on Krypton theme
            //StateCommon.Border.Color1 = KryptonManager.CurrentGlobalPalette?.GetBorderColor1(PaletteBorderStyle.ButtonStandalone, PaletteState.Normal) ?? Color.LightGray;
            //StateCommon.Border.Color2 = KryptonManager.CurrentGlobalPalette?.GetBorderColor2(PaletteBorderStyle.ButtonStandalone, PaletteState.Normal) ?? Color.LightGray;
        }
        else
        {
            // Use custom colors when theming is disabled
            StateCommon.Color1 = Color.WhiteSmoke;
            StateCommon.Color2 = Color.WhiteSmoke;
            //StateCommon.Border.Color1 = BorderColor;
            //StateCommon.Border.Color2 = BorderColor;
        }
        
        // Add padding around the control for better spacing
        Padding = new Padding(20);
        
        // Subscribe to theme changes only when theming is enabled
        if (UseKryptonTheme)
        {
            KryptonManager.GlobalPaletteChanged -= OnGlobalPaletteChanged; // Remove existing subscription
            KryptonManager.GlobalPaletteChanged += OnGlobalPaletteChanged;
        }
        
        // Add custom painting for drop zone
        Paint += (s, e) => DrawBackground(e.Graphics);
        Paint += (s, e) => DrawDottedBorder(e.Graphics);
        
        // Apply theme to child controls
        ApplyThemeToChildControls();
    }

    private void ApplyThemeToChildControls()
    {
        if (!UseKryptonTheme)
        {
            // Use custom colors when theming is disabled
            if (_instructionLabel != null)
            {
                _instructionLabel.StateCommon.TextColor = Color.DimGray;
                _instructionLabel.StateCommon.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            }
            
            if (_sizeLabel != null)
            {
                _sizeLabel.StateCommon.TextColor = Color.DimGray;
            }
            
            if (_clearButton != null)
            {
                _clearButton.ForeColor = SystemColors.ControlText;
                _clearButton.BackColor = Color.Transparent;
            }
            return;
        }

        // Apply Krypton theme to instruction label
        if (_instructionLabel != null)
        {
            _instructionLabel.StateCommon.TextColor = KryptonManager.CurrentGlobalPalette?.GetContentShortTextColor1(PaletteContentStyle.LabelNormalControl, PaletteState.Normal) ?? Color.DimGray;
            _instructionLabel.StateCommon.Font = KryptonManager.CurrentGlobalPalette?.GetContentShortTextFont(PaletteContentStyle.LabelNormalControl, PaletteState.Normal) ?? new Font("Segoe UI", 10, FontStyle.Regular);
        }

        // Apply Krypton theme to size label
        if (_sizeLabel != null)
        {
            _sizeLabel.StateCommon.TextColor = KryptonManager.CurrentGlobalPalette?.GetContentShortTextColor1(PaletteContentStyle.LabelNormalControl, PaletteState.Normal) ?? Color.DimGray;
        }

        // Apply Krypton theme to clear button
        if (_clearButton != null)
        {
            _clearButton.ForeColor = KryptonManager.CurrentGlobalPalette?.GetContentShortTextColor1(PaletteContentStyle.ButtonStandalone, PaletteState.Normal) ?? SystemColors.ControlText;
            _clearButton.BackColor = KryptonManager.CurrentGlobalPalette?.GetBackColor1(PaletteBackStyle.ButtonStandalone, PaletteState.Normal) ?? Color.Transparent;
        }

        // Apply Krypton theme to progress bar (already a Krypton control)
        if (_sizeProgressBar != null)
        {
            // Progress bar automatically uses Krypton theming
        }
    }

    private void OnGlobalPaletteChanged(object sender, EventArgs e)
    {
        // Reapply theming when global palette changes
        ApplyThemeStyling();
        Invalidate();
    }

    private void DrawBackground(Graphics g)
    {
        // Get subtle background color from Krypton theme
        Color subtleColor = KryptonManager.CurrentGlobalPalette?.GetBackColor1(PaletteBackStyle.PanelAlternate, PaletteState.Normal) ?? Color.Gray;
        
        // Create a very subtle background pattern
        using var brush = new SolidBrush(Color.FromArgb(BackgroundPatternOpacity, subtleColor));
        Rectangle rect = ClientRectangle;
        
        // Draw subtle diagonal lines
        for (int i = 0; i < rect.Width + rect.Height; i += 20)
        {
            g.DrawLine(new Pen(brush, 1), 
                new Point(i, 0), 
                new Point(i - rect.Height, rect.Height));
        }
    }

    private void DrawDottedBorder(Graphics g)
    {
        // Create a centered drop zone area like in the image
        Rectangle rect = ClientRectangle;
        rect.Inflate(-40, -40); // Create margin around the drop zone
        
        Color normalBorderColor, hoverBorderColor;
        
        if (UseKryptonTheme)
        {
            // Get colors from Krypton theme
            normalBorderColor = KryptonManager.CurrentGlobalPalette?.GetBorderColor1(PaletteBorderStyle.ButtonStandalone, PaletteState.Normal) ?? BorderColor;
            hoverBorderColor = KryptonManager.CurrentGlobalPalette?.GetBorderColor1(PaletteBorderStyle.ButtonStandalone, PaletteState.Tracking) ?? HoverBorderColor;
        }
        else
        {
            // Use custom colors when theming is disabled
            normalBorderColor = BorderColor;
            hoverBorderColor = HoverBorderColor;
        }
        
        // Draw the main drop zone border
        using Pen pen = new(_isHovering ? hoverBorderColor : normalBorderColor)
        {
            DashStyle = DashStyle.Dash,
            Width = 2
        };
        
        // Draw rounded rectangle effect (simulated with multiple lines)
        g.DrawRectangle(pen, rect);
        
        // Add subtle inner shadow effect
        if (_isHovering && ShowHoverShadow)
        {
            using Pen shadowPen = new(Color.FromArgb(30, hoverBorderColor))
            {
                Width = 1
            };
            Rectangle shadowRect = rect;
            shadowRect.Inflate(2, 2);
            g.DrawRectangle(shadowPen, shadowRect);
        }
    }

    private void HandleDrop(DragEventArgs e)
    {
        if (e.Data.GetData(DataFormats.FileDrop) is not string[] files) return;

        var validFiles = new List<string>();
        long totalSize = 0;
        foreach (string path in files)
        {
            if (Directory.Exists(path))
            {
                var filesInDir = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
                validFiles.AddRange(filesInDir);
                foreach (var file in filesInDir)
                {
                    try
                    {
                        var fileInfo = new FileInfo(file);
                        if (fileInfo.Exists)
                        {
                            totalSize += fileInfo.Length;
                        }
                    }
                    catch (UnauthorizedAccessException)
                    {
                        // Skip files we can't access
                    }
                }
            }
            else if (File.Exists(path))
            {
                try
                {
                    var fileInfo = new FileInfo(path);
                    if (fileInfo.Exists)
                    {
                        validFiles.Add(path);
                        totalSize += fileInfo.Length;
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    // Skip files we can't access
                }
            }
        }

        _droppedFiles = validFiles.Distinct().ToList();
        TotalFileSize = totalSize;
        
        // Update progress bar and size label
        if (ShowSizeProgressBar)
        {
            _sizeProgressBar.Maximum = 100;
            _sizeProgressBar.Value = 0;
            _sizeLabel.Text = $"Total: {FormatFileSize(totalSize)}";
        }
        
        UpdateListView();
        ValidFilesDropped?.Invoke(this, _droppedFiles.Where(IsValidExtension).ToList());
    }

    private void UpdateListView()
    {
        _fileListView.BeginUpdate();
        _fileListView.Items.Clear();
        long currentSize = 0;
        int processedFiles = 0;
        
        foreach (string file in _droppedFiles)
        {
            try
            {
                var ext = Path.GetExtension(file).ToLowerInvariant();
                Icon icon = Icon.ExtractAssociatedIcon(file);
                if (icon != null && !_fileListView.SmallImageList.Images.ContainsKey(file))
                {
                    _fileListView.SmallImageList.Images.Add(file, icon);
                }

                var item = new ListViewItem(Path.GetFileName(file), file);
                item.ToolTipText = file;
                if (!IsValidExtension(file))
                    item.ForeColor = Color.Gray;

                _fileListView.Items.Add(item);
                
                var fileInfo = new FileInfo(file);
                if (fileInfo.Exists)
                {
                    currentSize += fileInfo.Length;
                }
                processedFiles++;
                
                // Update progress bar for each file processed
                if (ShowSizeProgressBar && TotalFileSize > 0)
                {
                    int progress = (int)((processedFiles * 100.0) / _droppedFiles.Count);
                    _sizeProgressBar.Value = Math.Min(progress, 100);
                    _sizeLabel.Text = $"Processed: {processedFiles}/{_droppedFiles.Count} files ({FormatFileSize(currentSize)} / {FormatFileSize(TotalFileSize)})";
                }
            }
            catch (Exception)
            {
                // Skip files that can't be processed
                processedFiles++;
            }
        }
        
        _fileListView.EndUpdate();
        
        // Final update of progress bar and label
        if (ShowSizeProgressBar)
        {
            _sizeProgressBar.Value = 100;
            _sizeLabel.Text = $"Total: {FormatFileSize(TotalFileSize)} ({_droppedFiles.Count} files)";
        }
    }

    private void HandleListReorder(DragEventArgs e)
    {
        if (e.Data.GetData(typeof(ListViewItem)) is not ListViewItem draggedItem) return;

        Point cp = _fileListView.PointToClient(new Point(e.X, e.Y));
        ListViewItem targetItem = _fileListView.GetItemAt(cp.X, cp.Y);
        if (targetItem == null || draggedItem == targetItem) return;

        int draggedIndex = draggedItem.Index;
        int targetIndex = targetItem.Index;

        string temp = _droppedFiles[draggedIndex];
        _droppedFiles.RemoveAt(draggedIndex);
        _droppedFiles.Insert(targetIndex, temp);
        UpdateListView();
    }

    private void ClearFiles()
    {
        _droppedFiles.Clear();
        TotalFileSize = 0;
        _fileListView.Items.Clear();
        
        if (ShowSizeProgressBar)
        {
            _sizeProgressBar.Value = 0;
            _sizeLabel.Text = "0 bytes";
        }
    }

    private bool IsValidExtension(string file)
    {
        string ext = Path.GetExtension(file).ToLowerInvariant();
        return AllowedExtensions.Count == 0 || AllowedExtensions.Contains(ext); // CHANGED: empty list = allow all
    }

    public void SaveToFile(string path)
    {
        File.WriteAllLines(path, _droppedFiles);
    }

    public void LoadFromFile(string path)
    {
        if (!File.Exists(path)) return;
        _droppedFiles = File.ReadAllLines(path).ToList();
        
        // Calculate total file size for loaded files
        long totalSize = 0;
        foreach (string file in _droppedFiles)
        {
            try
            {
                if (File.Exists(file))
                {
                    var fileInfo = new FileInfo(file);
                    totalSize += fileInfo.Length;
                }
            }
            catch (Exception)
            {
                // Skip files that can't be accessed
            }
        }
        TotalFileSize = totalSize;
        
        UpdateListView();
    }

    private string FormatFileSize(long bytes)
    {
        if (bytes == 0) return "0 bytes";
        string[] sizes = { "B", "KB", "MB", "GB", "TB" };
        int order = 0;
        while (bytes >= 1024 && order < sizes.Length - 1)
        {
            order++;
            bytes = bytes / 1024;
        }
        return $"{bytes:0.##} {sizes[order]}";
    }

    /// <summary>
    /// Gets the size of a specific file in bytes.
    /// </summary>
    /// <param name="filePath">Path to the file</param>
    /// <returns>File size in bytes, or -1 if file doesn't exist or can't be accessed</returns>
    public long GetFileSize(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                var fileInfo = new FileInfo(filePath);
                return fileInfo.Length;
            }
        }
        catch (Exception)
        {
            // Return -1 for inaccessible files
        }
        return -1;
    }

    /// <summary>
    /// Gets a dictionary of file paths and their sizes for all dropped files.
    /// </summary>
    /// <returns>Dictionary with file paths as keys and file sizes as values</returns>
    public Dictionary<string, long> GetFileSizes()
    {
        var fileSizes = new Dictionary<string, long>();
        foreach (string file in _droppedFiles)
        {
            fileSizes[file] = GetFileSize(file);
        }
        return fileSizes;
    }
}
