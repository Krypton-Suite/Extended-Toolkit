using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.Developer.Utilities;
using Krypton.Toolkit.Suite.Extended.IO;

namespace TestApp
{
    public partial class ToolStripItems : KryptonForm
    {
        #region Instance Fields

        private MostRecentlyUsedFileManager _mruManager = null;

        private string _fileName = null;

        #endregion

        public ToolStripItems()
        {
            InitializeComponent();
        }

        private void ssZoomSlider_ValueChanged(Krypton.Toolkit.Suite.Extended.Tool.Strip.Items.KryptonToolbarSlider sender, Krypton.Toolkit.Suite.Extended.Tool.Strip.Items.KryptonToolbarSlider.SliderEventArgs eventArgs)
        {
            kryptonRichTextBox1.ZoomFactor = (float) ssZoomSlider.Value;
        }

        private void kryptonTrackBarToolStripMenuItem2_KryptonTrackBarControl_ValueChanged(object sender, EventArgs e)
        {
            tspbTest.Value = kryptonTrackBarToolStripMenuItem1.Value;
        }

        private void ktbProgressBarValue_ValueChanged(object sender, EventArgs e)
        {
            tspbTest.Value = ktbProgressBarValue.Value;
        }

        private void ToolStripItems_Load(object sender, EventArgs e)
        {
            _mruManager = new MostRecentlyUsedFileManager(recentDocumentsToolStripMenuItem, "Krypton Toolkit Extended Test Application", MyOwnRecentFileGotClicked_Handler, MyOwnRecentFilesGotCleared_Handler);
        }

        private void MyOwnRecentFileGotClicked_Handler(object sender, EventArgs e)
        {
            string fileName = (sender as ToolStripItem).Text;

            if (!File.Exists(fileName))
            {
                if (KryptonMessageBox.Show($"{fileName} doesn't exist. Remove from recent workspaces?", "File not found", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _mruManager.RemoveRecentFile(fileName);
                }
                else
                {
                    return;
                }
            }

            OpenFile(fileName);
        }

        private void MyOwnRecentFilesGotCleared_Handler(object sender, EventArgs e)
        {

        }

        private void OpenFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                //rtbTextPad.LoadFile(filePath);

                StreamReader reader = new StreamReader(filePath);

                kryptonRichTextBox1.Text = reader.ReadToEnd();

                _fileName = filePath;

                _mruManager.AddRecentFile(filePath);
            }
            else
            {
                KryptonMessageBox.Show($"Error: file '{filePath}' could not be found!");
            }
        }

        private void SaveFile(string fileName, bool saveAs = false)
        {
            try
            {
                if (saveAs)
                {
                    SaveFileDialog sfd = new SaveFileDialog()
                    {
                        Title = "Save file as:",
                        Filter = "Normal Text Files (*.txt)|*.txt",
                        InitialDirectory = Environment.CurrentDirectory,
                        FileName = fileName
                    };

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        StreamWriter writer = new StreamWriter(sfd.FileName);

                        writer.Write(kryptonRichTextBox1.Text);

                        writer.Close();

                        writer.Dispose();

                        _fileName = sfd.FileName;

                        _mruManager.AddRecentFile(Path.GetFullPath(sfd.FileName));
                    }
                }
                else
                {
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog
                           {
                               Title = "Save file as:",
                               Filter = "Normal Text Files (*.txt)|*.txt",
                               InitialDirectory = Environment.CurrentDirectory,
                               FileName = fileName
                           })
                    {
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            StreamWriter writer = new StreamWriter(saveFileDialog.FileName);

                            writer.Write(kryptonRichTextBox1.Text);

                            writer.Close();

                            writer.Dispose();

                            _fileName = saveFileDialog.FileName;

                            _mruManager.AddRecentFile(Path.GetFullPath(saveFileDialog.FileName));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionCapture.CaptureException(e);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileDialog openFileDlg = new OpenFileDialog();

            openFileDlg.InitialDirectory = Environment.CurrentDirectory;


            if (openFileDlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string openedFile = openFileDlg.FileName;

            OpenFile(openedFile);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile(_fileName, false);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile(_fileName, true);
        }

        private void ktbPBValue_ValueChanged(object sender, EventArgs e)
        {
            tspbTest.Value = ktbPBValue.Value;
        }

        private void kryptonColourButtonToolStripMenuItem1_KryptonColourButtonControl_SelectedColorChanged(object sender, ColorEventArgs e)
        {
            //kryptonRichTextBox1.StateCommon.Back.Color1 = kryptonColourButtonToolStripMenuItem1.KryptonColourButtonControl.SelectedColor;
        }

        private void kryptonColourButtonToolStripMenuItem1_SelectedColorChanged(object sender, ColorEventArgs e)
        {
            kryptonRichTextBox1.StateCommon.Back.Color1 = kryptonColourButtonToolStripMenuItem1.KryptonColourButtonControl.SelectedColor;
        }
    }
}
