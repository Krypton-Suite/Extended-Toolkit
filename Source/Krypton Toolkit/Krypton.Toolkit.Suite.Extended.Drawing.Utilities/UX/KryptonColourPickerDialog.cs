#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using ExtendedMessageBoxButtons = Krypton.Toolkit.Suite.Extended.Messagebox.ExtendedMessageBoxButtons;

namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities
{
    [DefaultEvent("SelectedColourChanged"), DefaultProperty("Colour")]
    public class KryptonColourPickerDialog : CommonExtendedKryptonForm
    {
        #region Designer Code
        private KryptonPanel kryptonPanel2;
        private ColourWheelControl cwColour;
        private Krypton.Toolkit.Suite.Extended.Controls.CircularPictureBox cpbColour;
        private Cyotek.Windows.Forms.ColorGrid cgColour;
        private ScreenColourPickerControl scpColour;
        private ColourEditor ceColour;
        private ColourEditorManager cem;
        private Krypton.Toolkit.Suite.Extended.Buttons.KryptonOKDialogButton kdbtnOk;
        private Krypton.Toolkit.Suite.Extended.Buttons.KryptonCancelDialogButton kdbtnCancel;
        private KryptonButton kbtnSavePalette;
        private KryptonButton kbtnLoadPalette;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonPanel kryptonPanel1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kdbtnOk = new Krypton.Toolkit.Suite.Extended.Buttons.KryptonOKDialogButton();
            this.kdbtnCancel = new Krypton.Toolkit.Suite.Extended.Buttons.KryptonCancelDialogButton();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnSavePalette = new Krypton.Toolkit.KryptonButton();
            this.kbtnLoadPalette = new Krypton.Toolkit.KryptonButton();
            this.cgColour = new Cyotek.Windows.Forms.ColorGrid();
            this.ceColour = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.ColourEditor();
            this.cwColour = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.ColourWheelControl();
            this.cem = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.ColourEditorManager();
            this.cpbColour = new Krypton.Toolkit.Suite.Extended.Controls.CircularPictureBox();
            this.scpColour = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.ScreenColourPickerControl();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbColour)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Controls.Add(this.kdbtnOk);
            this.kryptonPanel1.Controls.Add(this.kdbtnCancel);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 411);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(644, 43);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kdbtnOk
            // 
            this.kdbtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kdbtnOk.Location = new System.Drawing.Point(446, 6);
            this.kdbtnOk.Name = "kdbtnOk";
            this.kdbtnOk.ParentWindow = null;
            this.kdbtnOk.Size = new System.Drawing.Size(90, 25);
            this.kdbtnOk.TabIndex = 3;
            this.kdbtnOk.Values.Text = "&OK";
            this.kdbtnOk.Click += new System.EventHandler(this.kdbtnOk_Click);
            // 
            // kdbtnCancel
            // 
            this.kdbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kdbtnCancel.Location = new System.Drawing.Point(542, 6);
            this.kdbtnCancel.Name = "kdbtnCancel";
            this.kdbtnCancel.ParentWindow = null;
            this.kdbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kdbtnCancel.TabIndex = 3;
            this.kdbtnCancel.Values.Text = "C&ancel";
            this.kdbtnCancel.Click += new System.EventHandler(this.kdbtnCancel_Click);
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kbtnSavePalette);
            this.kryptonPanel2.Controls.Add(this.kbtnLoadPalette);
            this.kryptonPanel2.Controls.Add(this.cpbColour);
            this.kryptonPanel2.Controls.Add(this.cgColour);
            this.kryptonPanel2.Controls.Add(this.scpColour);
            this.kryptonPanel2.Controls.Add(this.ceColour);
            this.kryptonPanel2.Controls.Add(this.cwColour);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(644, 411);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // kbtnSavePalette
            // 
            this.kbtnSavePalette.AutoSize = true;
            this.kbtnSavePalette.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnSavePalette.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnSavePalette.Location = new System.Drawing.Point(40, 203);
            this.kbtnSavePalette.Name = "kbtnSavePalette";
            this.kbtnSavePalette.Size = new System.Drawing.Size(22, 22);
            this.kbtnSavePalette.TabIndex = 4;
            this.kbtnSavePalette.ToolTipValues.Description = "Save a custom palette.";
            this.kbtnSavePalette.ToolTipValues.EnableToolTips = true;
            this.kbtnSavePalette.ToolTipValues.Heading = "Save Palette";
            this.kbtnSavePalette.ToolTipValues.Image = global::Krypton.Toolkit.Suite.Extended.Drawing.Utilities.Properties.Resources.palette_save;
            this.kbtnSavePalette.Values.Image = global::Krypton.Toolkit.Suite.Extended.Drawing.Utilities.Properties.Resources.palette_save;
            this.kbtnSavePalette.Values.Text = "";
            this.kbtnSavePalette.Click += new System.EventHandler(this.kbtnSavePalette_Click);
            // 
            // kbtnLoadPalette
            // 
            this.kbtnLoadPalette.AutoSize = true;
            this.kbtnLoadPalette.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnLoadPalette.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnLoadPalette.Location = new System.Drawing.Point(12, 203);
            this.kbtnLoadPalette.Name = "kbtnLoadPalette";
            this.kbtnLoadPalette.Size = new System.Drawing.Size(22, 22);
            this.kbtnLoadPalette.TabIndex = 3;
            this.kbtnLoadPalette.ToolTipValues.Description = "Load a custom palette.";
            this.kbtnLoadPalette.ToolTipValues.EnableToolTips = true;
            this.kbtnLoadPalette.ToolTipValues.Heading = "Load Palette";
            this.kbtnLoadPalette.ToolTipValues.Image = global::Krypton.Toolkit.Suite.Extended.Drawing.Utilities.Properties.Resources.palette_load;
            this.kbtnLoadPalette.Values.Image = global::Krypton.Toolkit.Suite.Extended.Drawing.Utilities.Properties.Resources.palette_load;
            this.kbtnLoadPalette.Values.Text = "";
            this.kbtnLoadPalette.Click += new System.EventHandler(this.kbtnLoadPalette_Click);
            // 
            // cgColour
            // 
            this.cgColour.BackColor = System.Drawing.Color.Transparent;
            this.cgColour.Location = new System.Drawing.Point(12, 231);
            this.cgColour.Name = "cgColour";
            this.cgColour.Size = new System.Drawing.Size(247, 165);
            this.cgColour.TabIndex = 3;
            this.cgColour.EditingColor += new System.EventHandler<Cyotek.Windows.Forms.EditColorCancelEventArgs>(this.cgColour_EditingColor);
            this.cgColour.ColorChanged += new System.EventHandler(this.cgColour_ColorChanged);
            // 
            // ceColour
            // 
            this.ceColour.BackColor = System.Drawing.Color.Transparent;
            this.ceColour.Location = new System.Drawing.Point(267, 12);
            this.ceColour.Name = "ceColour";
            this.ceColour.Size = new System.Drawing.Size(185, 243);
            this.ceColour.TabIndex = 3;
            // 
            // cwColour
            // 
            this.cwColour.BackColor = System.Drawing.Color.Transparent;
            this.cwColour.Location = new System.Drawing.Point(12, 12);
            this.cwColour.Name = "cwColour";
            this.cwColour.Size = new System.Drawing.Size(249, 183);
            this.cwColour.TabIndex = 0;
            this.cwColour.ColourChanged += new System.EventHandler(this.cwColour_ColourChanged);
            // 
            // cem
            // 
            this.cem.Color = System.Drawing.Color.Empty;
            this.cem.ColourEditor = this.ceColour;
            this.cem.ColourWheel = this.cwColour;
            this.cem.ColorChanged += new System.EventHandler(this.cem_ColorChanged);
            this.cem.ColourChanged += new System.EventHandler(this.cem_ColourChanged);
            // 
            // cpbColour
            // 
            this.cpbColour.BackColor = System.Drawing.Color.Transparent;
            this.cpbColour.Location = new System.Drawing.Point(458, 12);
            this.cpbColour.Name = "cpbColour";
            this.cpbColour.Size = new System.Drawing.Size(174, 167);
            this.cpbColour.TabIndex = 3;
            this.cpbColour.TabStop = false;
            // 
            // scpColour
            // 
            this.scpColour.Colour = System.Drawing.Color.Empty;
            this.scpColour.Image = global::Krypton.Toolkit.Suite.Extended.Drawing.Utilities.Properties.Resources.dropper;
            this.scpColour.Location = new System.Drawing.Point(267, 261);
            this.scpColour.Name = "scpColour";
            this.scpColour.Size = new System.Drawing.Size(185, 135);
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderPrimary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(644, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // KryptonColourPickerDialog
            // 
            this.AcceptButton = this.kdbtnOk;
            this.CancelButton = this.kdbtnCancel;
            this.ClientSize = new System.Drawing.Size(644, 454);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonColourPickerDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Select a Colour";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbColour)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private Color _colour;
        #endregion

        #region Properties
        public Color Colour { get => _colour; set { _colour = value; ColourChangedEventArgs e = new ColourChangedEventArgs(value); OnSelectedColourChanged(this, e); } }
        #endregion

        #region Custom Events
        public delegate void SelectedColourChangedEventHandler(object sender, ColourChangedEventArgs e);

        public event SelectedColourChangedEventHandler SelectedColourChanged;

        protected virtual void OnSelectedColourChanged(object sender, ColourChangedEventArgs e) => SelectedColourChanged?.Invoke(sender, e);
        #endregion

        #region Constructors
        /// <summary>Initializes a new instance of the <see cref="KryptonColourPickerDialog" /> class.</summary>
        public KryptonColourPickerDialog()
        {
            InitializeComponent();
        }

        /// <summary>Initializes a new instance of the <see cref="KryptonColourPickerDialog" /> class.</summary>
        /// <param name="colour">The colour.</param>
        public KryptonColourPickerDialog(Color colour)
        {
            InitializeComponent();

            Colour = colour;
        }
        #endregion

        #region Event Handlers
        private void kbtnLoadPalette_Click(object sender, EventArgs e)
        {
            using (FileDialog fd = new OpenFileDialog { Filter = Cyotek.Windows.Forms.PaletteSerializer.DefaultOpenFilter, DefaultExt = "pal", Title = "Open a custom palette file:" })
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
                            KryptonMessageBoxExtended.Show(
                                "Sorry, unable to open palette, the file format is not supported or is not recognized.",
                                "Unable to Load Palette",
                                ExtendedMessageBoxButtons.OK, ExtendedKryptonMessageBoxIcon.ERROR, null);
                        }
                    }
                    catch (Exception exc)
                    {
                        ExceptionCapture.CaptureException(exc);
                    }
                }
            }
        }

        private void kbtnSavePalette_Click(object sender, EventArgs e)
        {
            using (FileDialog fd = new SaveFileDialog { Filter = Cyotek.Windows.Forms.PaletteSerializer.DefaultSaveFilter, DefaultExt = "pal", Title = "Save custom palette as:" })
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
                        ExceptionCapture.CaptureException(exc);
                    }
                }
                else
                {
                    KryptonMessageBoxExtended.Show(
                        "Sorry, unable to save palette, the file format is not supported or is not recognised.",
                        "Unable to Save Palette", ExtendedMessageBoxButtons.OK,
                        ExtendedKryptonMessageBoxIcon.ERROR, null);
                }
            }
        }

        private void kdbtnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void kdbtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void cem_ColourChanged(object sender, EventArgs e)
        {
            Colour = cem.Colour;

            ViewColour(Colour);
        }

        private void cem_ColorChanged(object sender, EventArgs e) => SetColour(cem.Colour);

        private void cgColour_ColorChanged(object sender, EventArgs e) => cem.Colour = cgColour.Color;

        private void cgColour_EditingColor(object sender, EditColorCancelEventArgs e) => cem.Colour = e.Color;

        private void cwColour_ColourChanged(object sender, EventArgs e) => cem.Colour = cwColour.Colour;
        #endregion

        #region Setters/Getters
        /// <summary>Sets the colour.</summary>
        /// <param name="colour">The colour.</param>
        private void SetColour(Color colour) => Colour = colour;

        /// <summary>Gets the colour.</summary>
        /// <returns></returns>
        public Color GetColour() => Colour;
        #endregion

        #region Methods
        private void ViewColour(Color colour) => cpbColour.BackColor = colour;
        #endregion
    }
}