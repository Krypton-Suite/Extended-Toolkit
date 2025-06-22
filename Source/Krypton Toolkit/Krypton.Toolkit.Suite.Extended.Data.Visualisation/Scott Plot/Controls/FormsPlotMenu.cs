namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

public class FormsPlotMenu : IPlotMenu
{
    public string DefaultSaveImageFilename { get; set; } = "Plot.png";
    public List<ContextMenuItem> ContextMenuItems { get; set; } = [];
    private readonly FormsPlotBase _thisControl;

    public FormsPlotMenu(FormsPlotBase control)
    {
        _thisControl = control;
        Reset();
    }

    public List<ContextMenuItem> StandardContextMenuItems()
    {
        ContextMenuItem saveImage = new()
        {
            Label = "Save Image",
            OnInvoke = OpenSaveImageDialog,
        };

        ContextMenuItem copyImage = new()
        {
            Label = "Copy to Clipboard",
            OnInvoke = CopyImageToClipboard
        };

        return
        [
            saveImage,
            copyImage
        ];
    }

    public void CopyImageToClipboard(IPlotControl plotControl)
    {
        PixelSize lastRenderSize = plotControl.Plot.RenderManager.LastRender.FigureRect.Size;
        Bitmap bmp = plotControl.Plot.GetBitmap((int)lastRenderSize.Width, (int)lastRenderSize.Height);
        Clipboard.SetImage(bmp);
    }

    public ContextMenuStrip GetContextMenu()
    {
        ContextMenuStrip menu = new();

        foreach (ContextMenuItem item in ContextMenuItems)
        {
            ToolStripMenuItem menuItem = new(item.Label);
            menuItem.Click += (s, e) => item.OnInvoke(_thisControl);

            menu.Items.Add(menuItem);
        }

        return menu;
    }

    public void OpenSaveImageDialog(IPlotControl plotControl)
    {
        SaveFileDialog dialog = new()
        {
            FileName = DefaultSaveImageFilename,
            Filter = "PNG Files (*.png)|*.png" +
                     "|JPEG Files (*.jpg, *.jpeg)|*.jpg;*.jpeg" +
                     "|BMP Files (*.bmp)|*.bmp" +
                     "|WebP Files (*.webp)|*.webp" +
                     "|SVG Files (*.svg)|*.svg" +
                     "|All files (*.*)|*.*"
        };

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            if (string.IsNullOrEmpty(dialog.FileName))
                return;

            ImageFormat format;

            try
            {
                format = ImageFormatLookup.FromFilePath(dialog.FileName);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Unsupported image file format", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                PixelSize lastRenderSize = plotControl.Plot.RenderManager.LastRender.FigureRect.Size;
                plotControl.Plot.Save(dialog.FileName, (int)lastRenderSize.Width, (int)lastRenderSize.Height, format);
            }
            catch (Exception)
            {
                MessageBox.Show("Image save failed", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }

    public void ShowContextMenu(Pixel pixel)
    {
        DebugUtilities.WriteLine("Showing Context Menu");
        ContextMenuStrip menu = GetContextMenu();
        menu.Show(_thisControl, new Point((int)pixel.X, (int)pixel.Y));
    }

    public void Reset()
    {
        Clear();
        ContextMenuItems.AddRange(StandardContextMenuItems());
    }

    public void Clear()
    {
        ContextMenuItems.Clear();
    }

    public void Add(string label, Action<IPlotControl> action)
    {
        ContextMenuItems.Add(new ContextMenuItem() { Label = label, OnInvoke = action });
    }
}