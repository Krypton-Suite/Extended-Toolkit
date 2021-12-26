#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities
{
    public class ColourGridDialog : CommonExtendedKryptonForm
    {
        #region Designer Code
        private Krypton.Toolkit.Suite.Extended.Floating.Toolbars.ToolStripPanelExtened tspeColourGridActions;
        private Krypton.Toolkit.Suite.Extended.Floating.Toolbars.FloatableToolStrip ftsColourGridActions;
        private System.Windows.Forms.ToolStripButton tsbSavePalette;
        private System.Windows.Forms.ToolStripButton tsbLoadPalette;
        private KryptonPanel kryptonPanel1;
        private ColorGrid cgColour;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.cgColour = new Cyotek.Windows.Forms.ColorGrid();
            this.tspeColourGridActions = new Krypton.Toolkit.Suite.Extended.Floating.Toolbars.ToolStripPanelExtened();
            this.ftsColourGridActions = new Krypton.Toolkit.Suite.Extended.Floating.Toolbars.FloatableToolStrip();
            this.tsbSavePalette = new System.Windows.Forms.ToolStripButton();
            this.tsbLoadPalette = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.tspeColourGridActions.SuspendLayout();
            this.ftsColourGridActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.cgColour);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 25);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(247, 165);
            this.kryptonPanel1.TabIndex = 2;
            // 
            // cgColour
            // 
            this.cgColour.BackColor = System.Drawing.Color.Transparent;
            this.cgColour.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cgColour.Location = new System.Drawing.Point(0, 0);
            this.cgColour.Name = "cgColour";
            this.cgColour.Size = new System.Drawing.Size(247, 165);
            this.cgColour.TabIndex = 3;
            // 
            // tspeColourGridActions
            // 
            this.tspeColourGridActions.Controls.Add(this.ftsColourGridActions);
            this.tspeColourGridActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.tspeColourGridActions.Location = new System.Drawing.Point(0, 0);
            this.tspeColourGridActions.Name = "tspeColourGridActions";
            this.tspeColourGridActions.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.tspeColourGridActions.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.tspeColourGridActions.Size = new System.Drawing.Size(247, 25);
            // 
            // ftsColourGridActions
            // 
            this.ftsColourGridActions.Dock = System.Windows.Forms.DockStyle.None;
            this.ftsColourGridActions.FloatingToolBarWindowText = "Tool Bar";
            this.ftsColourGridActions.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ftsColourGridActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSavePalette,
            this.tsbLoadPalette});
            this.ftsColourGridActions.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.ftsColourGridActions.Location = new System.Drawing.Point(3, 0);
            this.ftsColourGridActions.Name = "ftsColourGridActions";
            this.ftsColourGridActions.Size = new System.Drawing.Size(58, 25);
            this.ftsColourGridActions.TabIndex = 0;
            // 
            // tsbSavePalette
            // 
            this.tsbSavePalette.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSavePalette.Image = global::Krypton.Toolkit.Suite.Extended.Drawing.Utilities.Properties.Resources.palette_save;
            this.tsbSavePalette.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSavePalette.Name = "tsbSavePalette";
            this.tsbSavePalette.Size = new System.Drawing.Size(23, 22);
            this.tsbSavePalette.Text = "Save Palette";
            this.tsbSavePalette.Click += new System.EventHandler(this.tsbSavePalette_Click);
            // 
            // tsbLoadPalette
            // 
            this.tsbLoadPalette.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLoadPalette.Image = global::Krypton.Toolkit.Suite.Extended.Drawing.Utilities.Properties.Resources.palette_load;
            this.tsbLoadPalette.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLoadPalette.Name = "tsbLoadPalette";
            this.tsbLoadPalette.Size = new System.Drawing.Size(23, 22);
            this.tsbLoadPalette.Text = "Load Palette";
            this.tsbLoadPalette.Click += new System.EventHandler(this.tsbLoadPalette_Click);
            // 
            // ColourGridDialog
            // 
            this.ClientSize = new System.Drawing.Size(247, 190);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.tspeColourGridActions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColourGridDialog";
            this.Text = "Colour Grid";
            this.Load += new System.EventHandler(this.ColourGridDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.tspeColourGridActions.ResumeLayout(false);
            this.tspeColourGridActions.PerformLayout();
            this.ftsColourGridActions.ResumeLayout(false);
            this.ftsColourGridActions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region Event
        public delegate void SelectedColourChangedEventHandler(object sender, ColourChangedEventArgs e);

        public event SelectedColourChangedEventHandler SelectedColourChanged;

        protected virtual void OnSelectedColourChanged(object sender, ColourChangedEventArgs e) => SelectedColourChanged?.Invoke(sender, e);
        #endregion

        #region Variables
        private bool _showToolbar;

        private Color _colour, _colourToAdd;

        private ColorGrid _grid;
        #endregion

        #region Properties
        public bool ShowToolbar { get => _showToolbar; set { _showToolbar = value; Invalidate(); } }

        public Color Colour { get => _colour; set { _colour = value; ColourChangedEventArgs colour = new ColourChangedEventArgs(value); OnSelectedColourChanged(this, colour); } }

        public Color ColourToAdd { get => _colourToAdd; set => _colourToAdd = value; }

        public ColorGrid ColourGrid { get => _grid; private set => _grid = value; }
        #endregion

        #region Constructors
        public ColourGridDialog()
        {
            InitializeComponent();

            ColourGrid = cgColour;
        }

        public ColourGridDialog(Color colour)
        {
            InitializeComponent();

            ColourGrid = cgColour;

            ColourToAdd = colour;

            ColourGrid.AddCustomColor(ColourToAdd);

            ColourGrid.Color = colour;
        }

        public ColourGridDialog(bool showToolbar)
        {
            InitializeComponent();

            ColourGrid = cgColour;

            tspeColourGridActions.Visible = showToolbar;
        }
        #endregion

        private void ColourGridDialog_Load(object sender, EventArgs e)
        {

        }

        private void cgColour_AutoAddColorsChanged(object sender, EventArgs e)
        {
            AdjustWindow();
        }

        private void AdjustWindow()
        {
            Width = ColourGrid.Width;

            Height = ColourGrid.Height;
        }

        private void tsbSavePalette_Click(object sender, EventArgs e)
        {
            using (FileDialog fd = new SaveFileDialog { Filter = PaletteSerializer.DefaultSaveFilter, DefaultExt = "pal", Title = "Save custom palette as:" })
            {
                if (fd.ShowDialog(this) == DialogResult.OK)
                {
                    Cyotek.Windows.Forms.IPaletteSerializer serializer;

                    serializer = Cyotek.Windows.Forms.PaletteSerializer.AllSerializers.Where(s => s.CanWrite).ElementAt(fd.FilterIndex - 1);

                    if (serializer != null)
                    {
                        if (!serializer.CanWrite) throw new InvalidOperationException("Serializer does not support writing palettes.");
                    }

                    try
                    {
                        using (FileStream fs = File.OpenWrite(fd.FileName))
                        {
                            serializer.Serialize(fs, cgColour.Colors);
                        }
                    }
                    catch (Exception exc)
                    {
                        KryptonMessageBox.Show($@"Sorry, unable to save palette. { exc.GetBaseException().Message }", "Save Palette", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    KryptonMessageBox.Show("Sorry, unable to save palette, the file format is not supported or is not recognised.", "Save Palette", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void tsbLoadPalette_Click(object sender, EventArgs e)
        {
            using (FileDialog fd = new OpenFileDialog { Filter = PaletteSerializer.DefaultOpenFilter, DefaultExt = "pal", Title = "Open a custom palette file:" })
            {
                if (fd.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        Cyotek.Windows.Forms.IPaletteSerializer serializer;

                        serializer = Cyotek.Windows.Forms.PaletteSerializer.GetSerializer(fd.FileName);

                        if (serializer != null)
                        {
                            ColorCollection colours;

                            if (!serializer.CanRead) throw new InvalidOperationException("Serializer does not support reading palettes.");

                            using (FileStream fs = File.OpenRead(fd.FileName))
                            {
                                colours = serializer.Deserialize(fs);
                            }

                            if (colours != null)
                            {
                                while (colours.Count > 96)
                                {
                                    colours.RemoveAt(colours.Count - 1);
                                }

                                while (colours.Count < 96)
                                {
                                    colours.Add(Color.White);
                                }

                                cgColour.Colors = colours;
                            }
                        }
                        else
                        {
                            KryptonMessageBox.Show("Sorry, unable to open palette, the file format is not supported or is not recognized.", "Load Palette", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    catch (Exception exc)
                    {
                        ExceptionCapture.CaptureException(exc);
                    }
                }
            }
        }

        private void cgColour_ColorChanged(object sender, EventArgs e)
        {
            Colour = ColourGrid.Color;
        }
    }
}