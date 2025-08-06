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
    private List<string> _droppedFiles = new();

    private bool _isHovering = false; // ADDED: Hover state for transitions

    [Category("Behavior")]
    [Description("Whether to display the list of dropped files.")]
    [DefaultValue(true)]
    public bool ShowFileListView
    {
        get => _fileListView.Visible;
        set
        {
            if (_fileListView.Visible != value)
            {
                _fileListView.Visible = value;
                _fileListView.Height = value ? 150 : 0; // ADDED: Collapse/expand logic
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
    [Description("A list of allowed file extensions.")]
    public List<string> AllowedExtensions { get; set; } = new(); // CHANGED: No default list, user-defined

    public event EventHandler<List<string>> ValidFilesDropped;

    public KryptonDropZone()
    {
        AllowDrop = true;
        InitializeControls();
        RegisterEvents();
        ApplyThemeStyling();
    }

    private void InitializeControls()
    {
        _fileListView = new ListView
        {
            Dock = DockStyle.Fill,
            View = View.Details,
            HeaderStyle = ColumnHeaderStyle.None,
            FullRowSelect = true,
            SmallImageList = new ImageList { ImageSize = new Size(32, 32), ColorDepth = ColorDepth.Depth32Bit }, // CHANGED: Thumbnail size
            AllowDrop = false
        };
        _fileListView.Columns.Add("Files", -2);
        _fileListView.ItemDrag += (s, e) => _fileListView.DoDragDrop(e.Item, DragDropEffects.Move);
        _fileListView.DragEnter += (s, e) => e.Effect = DragDropEffects.Move;
        _fileListView.DragDrop += (s, e) => HandleListReorder(e);

        _clearButton = new Button
        {
            Text = "Clear All",
            Dock = DockStyle.Bottom,
            Height = 30,
            BackColor = Color.Transparent,
            FlatStyle = FlatStyle.Flat
        };
        _clearButton.FlatAppearance.BorderSize = 0;
        _clearButton.ForeColor = KryptonManager.CurrentGlobalPalette?.GetRibbonTextColor(PaletteRibbonTextStyle.RibbonTab, PaletteState.Normal) ?? SystemColors.ControlText; // ADDED: Theme-aware text color
        _clearButton.Click += (s, e) => ClearFiles();

        _instructionLabel = new KryptonWrapLabel
        {
            Text = "Drag files or folders here...",
            TextAlign = ContentAlignment.MiddleCenter,
            Dock = DockStyle.Fill
        };

        Controls.Add(_instructionLabel);
        Controls.Add(_fileListView);
        Controls.Add(_clearButton);
    }

    private void RegisterEvents()
    {
        DragEnter += (s, e) => { e.Effect = DragDropEffects.Copy; _isHovering = true; Invalidate(); }; // ADDED
        DragLeave += (s, e) => { _isHovering = false; Invalidate(); }; // ADDED
        DragDrop += (s, e) => { HandleDrop(e); _isHovering = false; Invalidate(); }; // CHANGED
    }

    private void ApplyThemeStyling()
    {
        StateCommon.Color1 = Color.WhiteSmoke;
        StateCommon.Color2 = Color.WhiteSmoke;
        Paint += (s, e) => DrawDottedBorder(e.Graphics);
    }

    private void DrawDottedBorder(Graphics g)
    {
        using Pen pen = new(_isHovering ? Color.DodgerBlue : Color.Gray) // CHANGED: Hover feedback
        {
            DashStyle = DashStyle.Dot,
            Width = 2 // ADDED: Thicker border for visibility
        };
        Rectangle rect = ClientRectangle;
        rect.Inflate(-2, -2);
        g.DrawRectangle(pen, rect);
    }

    private void HandleDrop(DragEventArgs e)
    {
        if (e.Data.GetData(DataFormats.FileDrop) is not string[] files) return;

        var validFiles = new List<string>();
        foreach (string path in files)
        {
            if (Directory.Exists(path))
                validFiles.AddRange(Directory.GetFiles(path, "*.*", SearchOption.AllDirectories));
            else if (File.Exists(path))
                validFiles.Add(path);
        }

        _droppedFiles = validFiles.Distinct().ToList();
        UpdateListView();
        ValidFilesDropped?.Invoke(this, _droppedFiles.Where(IsValidExtension).ToList());
    }

    private void UpdateListView()
    {
        _fileListView.BeginUpdate();
        _fileListView.Items.Clear();
        foreach (string file in _droppedFiles)
        {
            var ext = Path.GetExtension(file).ToLowerInvariant();
            Icon icon = Icon.ExtractAssociatedIcon(file);
            if (icon != null && !_fileListView.SmallImageList.Images.ContainsKey(file)) // CHANGED
            {
                _fileListView.SmallImageList.Images.Add(file, icon); // Use full file path key for uniqueness
            }

            var item = new ListViewItem(Path.GetFileName(file), file); // CHANGED
            item.ToolTipText = file;
            if (!IsValidExtension(file))
                item.ForeColor = Color.Gray;

            _fileListView.Items.Add(item);
        }
        _fileListView.EndUpdate();
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
        _fileListView.Items.Clear();
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
        UpdateListView();
    }
}
