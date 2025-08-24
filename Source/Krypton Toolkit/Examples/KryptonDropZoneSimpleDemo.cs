using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Krypton.Toolkit.Suite.Extended.Controls;

namespace Krypton.Toolkit.Suite.Extended.Controls.Demo
{
    public partial class KryptonDropZoneSimpleDemo : Form
    {
        private KryptonDropZone _dropZone;
        private KryptonLabel _infoLabel;

        public KryptonDropZoneSimpleDemo()
        {
            InitializeComponent();
            SetupDropZone();
        }

        private void InitializeComponent()
        {
            this.Text = "KryptonDropZone - Simple Demo";
            this.Size = new Size(600, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;
        }

        private void SetupDropZone()
        {
            // Create the drop zone with custom styling
            _dropZone = new KryptonDropZone
            {
                Dock = DockStyle.Top,
                Height = 250,
                DropZoneText = "Drag and drop files here or click to browse",
                BorderColor = Color.LightGray,
                HoverBorderColor = Color.DodgerBlue,
                ShowHoverShadow = true,
                ShowFileListView = true,      // Show file list by default
                ShowSizeProgressBar = true,   // Show progress bar
                ShowClearButton = true        // Show clear button
            };

            // Set allowed file extensions
            _dropZone.AllowedExtensions = new List<string> { ".txt", ".pdf", ".doc", ".docx", ".jpg", ".png" };

            // Subscribe to file drop events
            _dropZone.ValidFilesDropped += OnFilesDropped;

            // Create info label
            _infoLabel = new KryptonLabel
            {
                Text = "Drop files in the zone above or click to browse. The control will show file sizes and allow you to manage the file list.",
                Dock = DockStyle.Fill,
                //TextAlign = ContentAlignment.TopLeft,
                Font = new Font("Segoe UI", 9),
                Padding = new Padding(20),
                BackColor = Color.White
            };

            // Add controls to form
            this.Controls.Add(_dropZone);
            this.Controls.Add(_infoLabel);
        }

        private void OnFilesDropped(object sender, List<string> files)
        {
            // Update info label with file information
            _infoLabel.Text = $"✅ Files dropped successfully!\n\n" +
                             $"📁 Number of files: {files.Count}\n" +
                             $"💾 Total size: {_dropZone.TotalFileSizeFormatted}\n" +
                             $"📋 Allowed extensions: {string.Join(", ", _dropZone.AllowedExtensions)}\n\n" +
                             $"💡 Features available:\n" +
                             $"   • File list with icons and tooltips\n" +
                             $"   • Progress bar showing file processing\n" +
                             $"   • Clear button to remove all files\n" +
                             $"   • Drag & drop reordering within the list\n" +
                             $"   • File extension filtering\n" +
                             $"   • Click anywhere in drop zone to browse files";
        }
    }
}
