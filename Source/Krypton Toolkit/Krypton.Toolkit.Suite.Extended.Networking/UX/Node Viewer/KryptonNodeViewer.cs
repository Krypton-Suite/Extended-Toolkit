#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Networking;

/// <summary>
/// A simply test form that creates a new NetworkBrowser
/// object, and displays a list of the network computers
/// found by the NetworkBrowser
/// </summary>
public partial class KryptonNodeViewer : KryptonForm
{
    #region Instance Fields

    private FileDialogType _fileDialogType;

    #endregion

    #region Constructor
    /// <summary>Initializes a new instance of the <see cref="KryptonNodeViewer" /> class.</summary>
    /// <param name="fileDialogType">Type of the file dialog.</param>
    public KryptonNodeViewer(FileDialogType fileDialogType = FileDialogType.Standard)
    {
        InitializeComponent();

        _fileDialogType = fileDialogType;
    }
    #endregion

    #region Event Handlers
    private void NodeViewer_Load(object sender, EventArgs e)
    {
        //create a new NetworkNodeBrowser object, and get the
        //list of network computers it found, and add each
        //entry to the combo box on this form
        try
        {
            NetworkNodeBrowser nb = new NetworkNodeBrowser();

            foreach (string pc in nb.GetNetworkComputers())
            {
                kcmbNodeList.Items.Add(pc);
            }
        }
        catch (Exception ex)
        {
            DebugUtilities.NotImplemented(ex.ToString());
        }
    }

    private void kbtnExportNodeList_Click(object sender, EventArgs e)
    {
        try
        {
            // TODO: Integrate KryptonSaveFileDialog

            string defaultFileName = $"Network Node List - {DateTime.Now.ToShortDateString()}";

            switch (_fileDialogType)
            {
                case FileDialogType.Krypton:
                    KryptonSaveFileDialog ksfd = new()
                    {
                        Title = @"Save Network Node List",
                        Filter = @"Text Files|*.txt",
                        FileName = defaultFileName
                    };

                    if (ksfd.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = Path.GetFullPath(ksfd.FileName);

                        StreamWriter writer = new StreamWriter(filePath);

                        foreach (string node in kcmbNodeList.Items)
                        {
                            writer.WriteLine(node);
                        }

                        writer.Flush();

                        writer.Close();

                        writer.Dispose();
                    }
                    break;
                case FileDialogType.Standard:
                    SaveFileDialog sfd = new()
                    {
                        Title = @"Save Network Node List",
                        Filter = @"Text Files|*.txt",
                        FileName = defaultFileName
                    };

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = Path.GetFullPath(sfd.FileName);

                        StreamWriter writer = new StreamWriter(filePath);

                        foreach (string node in kcmbNodeList.Items)
                        {
                            writer.WriteLine(node);
                        }

                        writer.Flush();

                        writer.Close();

                        writer.Dispose();
                    }
                    break;
                case FileDialogType.WindowsAPICodePack:
                    CommonSaveFileDialog csfd = new();

                    csfd.Title = "Save Network Node List";
                    csfd.Filters.Add(new CommonFileDialogFilter("Text Files", "txt"));
                    csfd.DefaultFileName = defaultFileName;

                    if (csfd.ShowDialog() == CommonFileDialogResult.Ok)
                    {
                        if (csfd.FileName != null)
                        {
                            string filePath = Path.GetFullPath(csfd.FileName);

                            StreamWriter writer = new StreamWriter(filePath);

                            foreach (string node in kcmbNodeList.Items)
                            {
                                writer.WriteLine(node);
                            }

                            writer.Flush();

                            writer.Close();

                            writer.Dispose();
                        }
                    }
                    break;
            }
            kbtnExportNodeList.Enabled = false;
        }
        catch (Exception exc)
        {
            DebugUtilities.NotImplemented(exc.ToString());
        }
    }

    private void kbtnOk_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.OK;
    }

    private void kcmbNodeList_SelectedIndexChanged(object sender, EventArgs e)
    {
        kbtnExportNodeList.Enabled = true;
    }
    #endregion

    #region Methods
    public string GetSelectedNode() => kcmbNodeList.Text;
    #endregion
}