using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Krypton.Toolkit.Suite.Extended.Controls;

namespace Krypton.Toolkit.Suite.Extended.Controls.Demo
{
    public partial class KryptonDropZoneDemo : Form
    {
        private KryptonDropZone _dropZone;
        private KryptonCheckBox _showFileListCheckBox;
        private KryptonCheckBox _showProgressBarCheckBox;
        private KryptonCheckBox _showClearButtonCheckBox;
        private KryptonTextBox _allowedExtensionsTextBox;
        private KryptonLabel _statusLabel;
        private KryptonButton _saveListButton;
        private KryptonButton _loadListButton;
        private KryptonButton _clearAllButton;

        public KryptonDropZoneDemo()
        {
            InitializeComponent();
            InitializeDemo();
        }

        private void InitializeComponent()
        {
            this.Text = "KryptonDropZone Demo";
            this.Size = new Size(800, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;
        }

        private void InitializeDemo()
        {
            // Create main drop zone
            _dropZone = new KryptonDropZone
            {
                Dock = DockStyle.Top,
                Height = 300,
                DropZoneText = "Drag and drop files here or click to browse",
                BorderColor = Color.LightGray,
                HoverBorderColor = Color.DodgerBlue,
                ShowHoverShadow = true
            };

            // Subscribe to file drop events
            _dropZone.ValidFilesDropped += OnFilesDropped;

            // Create control panel
            var controlPanel = CreateControlPanel();

            // Create status panel
            var statusPanel = CreateStatusPanel();

            // Layout controls
            this.Controls.Add(_dropZone);
            this.Controls.Add(controlPanel);
            this.Controls.Add(statusPanel);

            // Set up layout
            controlPanel.Dock = DockStyle.Top;
            statusPanel.Dock = DockStyle.Fill;
        }

        private Panel CreateControlPanel()
        {
            var panel = new Panel
            {
                Height = 200,
                BackColor = Color.White,
                Padding = new Padding(10)
            };

            // Checkboxes for controlling visibility
            _showFileListCheckBox = new KryptonCheckBox
            {
                Text = "Show File List",
                Location = new Point(10, 10),
                Checked = false
            };
            _showFileListCheckBox.CheckedChanged += (s, e) => _dropZone.ShowFileListView = _showFileListCheckBox.Checked;

            _showProgressBarCheckBox = new KryptonCheckBox
            {
                Text = "Show Progress Bar",
                Location = new Point(10, 40),
                Checked = true
            };
            _showProgressBarCheckBox.CheckedChanged += (s, e) => _dropZone.ShowSizeProgressBar = _showProgressBarCheckBox.Checked;

            _showClearButtonCheckBox = new KryptonCheckBox
            {
                Text = "Show Clear Button",
                Location = new Point(10, 70),
                Checked = true
            };
            _showClearButtonCheckBox.CheckedChanged += (s, e) => _dropZone.ShowClearButton = _showClearButtonCheckBox.Checked;

            // Allowed extensions input
            var extensionsLabel = new KryptonLabel
            {
                Text = "Allowed Extensions (comma-separated, leave empty for all):",
                Location = new Point(10, 100),
                Width = 300
            };

            _allowedExtensionsTextBox = new KryptonTextBox
            {
                Location = new Point(10, 125),
                Width = 300,
                Text = ".txt,.pdf,.doc,.docx,.jpg,.png"
            };
            _allowedExtensionsTextBox.TextChanged += OnExtensionsChanged;

            // Action buttons
            _saveListButton = new KryptonButton
            {
                Text = "Save File List",
                Location = new Point(350, 10),
                Width = 120
            };
            _saveListButton.Click += OnSaveList;

            _loadListButton = new KryptonButton
            {
                Text = "Load File List",
                Location = new Point(350, 40),
                Width = 120
            };
            _loadListButton.Click += OnLoadList;

            _clearAllButton = new KryptonButton
            {
                Text = "Clear All Files",
                Location = new Point(350, 70),
                Width = 120
            };
            _clearAllButton.Click += OnClearAll;

            // Add controls to panel
            panel.Controls.AddRange(new Control[]
            {
                _showFileListCheckBox,
                _showProgressBarCheckBox,
                _showClearButtonCheckBox,
                extensionsLabel,
                _allowedExtensionsTextBox,
                _saveListButton,
                _loadListButton,
                _clearAllButton
            });

            return panel;
        }

        private Panel CreateStatusPanel()
        {
            var panel = new Panel
            {
                BackColor = Color.White,
                Padding = new Padding(10)
            };

            _statusLabel = new KryptonLabel
            {
                Text = "Ready to accept files. Drag and drop files or click in the drop zone to browse.",
                Dock = DockStyle.Fill,
                //StateCommon. = ContentAlignment.TopLeft,
                Font = new Font("Segoe UI", 9)
            };

            _statusLabel.StateCommon.ShortText.TextH = PaletteRelativeAlign.Near;
            _statusLabel.StateCommon.ShortText.TextV = PaletteRelativeAlign.Near;

            panel.Controls.Add(_statusLabel);
            return panel;
        }

        private void OnFilesDropped(object sender, List<string> files)
        {
            UpdateStatus($"Files dropped: {files.Count} files, Total size: {_dropZone.TotalFileSizeFormatted}");
            
            // Show file list if not already visible
            if (!_dropZone.ShowFileListView)
            {
                _showFileListCheckBox.Checked = true;
            }
        }

        private void OnExtensionsChanged(object sender, EventArgs e)
        {
            var extensions = _allowedExtensionsTextBox.Text.Split(',');
            var extensionList = new List<string>();
            
            foreach (var ext in extensions)
            {
                var trimmed = ext.Trim();
                if (!string.IsNullOrEmpty(trimmed))
                {
                    if (!trimmed.StartsWith("."))
                        trimmed = "." + trimmed;
                    extensionList.Add(trimmed.ToLower());
                }
            }
            
            _dropZone.AllowedExtensions = extensionList;
            UpdateStatus($"File extensions updated: {string.Join(", ", extensionList)}");
        }

        private void OnSaveList(object sender, EventArgs e)
        {
            using var saveDialog = new SaveFileDialog
            {
                Title = "Save File List",
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                DefaultExt = "txt"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _dropZone.SaveToFile(saveDialog.FileName);
                    UpdateStatus($"File list saved to: {saveDialog.FileName}");
                }
                catch (Exception ex)
                {
                    UpdateStatus($"Error saving file list: {ex.Message}");
                }
            }
        }

        private void OnLoadList(object sender, EventArgs e)
        {
            using var openDialog = new OpenFileDialog
            {
                Title = "Load File List",
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                DefaultExt = "txt"
            };

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _dropZone.LoadFromFile(openDialog.FileName);
                    UpdateStatus($"File list loaded from: {openDialog.FileName}");
                    
                    // Show file list if files were loaded
                    if (!_dropZone.ShowFileListView)
                    {
                        _showFileListCheckBox.Checked = true;
                    }
                }
                catch (Exception ex)
                {
                    UpdateStatus($"Error loading file list: {ex.Message}");
                }
            }
        }

        private void OnClearAll(object sender, EventArgs e)
        {
            //_dropZone.ClearFiles();
            UpdateStatus("All files cleared from the drop zone.");
        }

        private void UpdateStatus(string message)
        {
            if (_statusLabel.InvokeRequired)
            {
                _statusLabel.Invoke(new Action(() => UpdateStatus(message)));
            }
            else
            {
                _statusLabel.Text = $"[{DateTime.Now:HH:mm:ss}] {message}";
            }
        }
    }
}
