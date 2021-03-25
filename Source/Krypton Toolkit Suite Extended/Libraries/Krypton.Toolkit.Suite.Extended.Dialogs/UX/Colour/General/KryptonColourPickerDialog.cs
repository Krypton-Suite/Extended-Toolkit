#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Cyotek.Windows.Forms;
using Krypton.Toolkit.Suite.Extended.Base;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    [DefaultEvent("PreviewColourChanged"), DefaultProperty("Colour")]
    public class KryptonColourPickerDialog : KryptonForm
    {
        #region Designer Code
        private IContainer components = null;
        private KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.Suite.Extended.Drawing.Suite.ColourWheelControl cwColour;
        private Krypton.Toolkit.Suite.Extended.Drawing.Suite.ColourEditorManager cem;
        private Krypton.Toolkit.Suite.Extended.Drawing.Suite.ScreenColourPickerControl scp;
        private Cyotek.Windows.Forms.ColorGrid cgColours;
        private CircularPictureBox cpbColourPreview;
        private KryptonButton kbtnSavePalette;
        private KryptonButton kbtnLoadPalette;
        private KryptonPanel kryptonPanel2;
        private KryptonOKDialogButton kryptonOKDialogButton1;
        private KryptonCancelDialogButton kryptonCancelDialogButton1;
        private Panel panel1;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KryptonColourPickerDialog));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnSavePalette = new Krypton.Toolkit.KryptonButton();
            this.kbtnLoadPalette = new Krypton.Toolkit.KryptonButton();
            this.cgColours = new Cyotek.Windows.Forms.ColorGrid();
            this.cpbColourPreview = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonCancelDialogButton1 = new Krypton.Toolkit.Suite.Extended.Dialogs.KryptonCancelDialogButton();
            this.kryptonOKDialogButton1 = new Krypton.Toolkit.Suite.Extended.Dialogs.KryptonOKDialogButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbColourPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnSavePalette);
            this.kryptonPanel1.Controls.Add(this.kbtnLoadPalette);
            this.kryptonPanel1.Controls.Add(this.cgColours);
            this.kryptonPanel1.Controls.Add(this.cpbColourPreview);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(574, 491);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnSavePalette
            // 
            this.kbtnSavePalette.AutoSize = true;
            this.kbtnSavePalette.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnSavePalette.Location = new System.Drawing.Point(40, 252);
            this.kbtnSavePalette.Name = "kbtnSavePalette";
            this.kbtnSavePalette.Size = new System.Drawing.Size(22, 22);
            this.kbtnSavePalette.TabIndex = 4;
            this.kbtnSavePalette.ToolTipValues.Description = "Save current custom palette for futre use.";
            this.kbtnSavePalette.Values.Image = global::Krypton.Toolkit.Suite.Extended.Dialogs.Properties.Resources.palette_save;
            this.kbtnSavePalette.Values.Text = "";
            this.kbtnSavePalette.Click += new System.EventHandler(this.kbtnSavePalette_Click);
            // 
            // kbtnLoadPalette
            // 
            this.kbtnLoadPalette.AutoSize = true;
            this.kbtnLoadPalette.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnLoadPalette.Location = new System.Drawing.Point(12, 252);
            this.kbtnLoadPalette.Name = "kbtnLoadPalette";
            this.kbtnLoadPalette.Size = new System.Drawing.Size(22, 22);
            this.kbtnLoadPalette.TabIndex = 1;
            this.kbtnLoadPalette.ToolTipValues.Description = "Load a custom palette.";
            this.kbtnLoadPalette.ToolTipValues.Heading = "Load Custom Palette";
            this.kbtnLoadPalette.ToolTipValues.Image = global::Krypton.Toolkit.Suite.Extended.Dialogs.Properties.Resources.palette_load;
            this.kbtnLoadPalette.Values.Image = global::Krypton.Toolkit.Suite.Extended.Dialogs.Properties.Resources.palette_load;
            this.kbtnLoadPalette.Values.Text = "";
            this.kbtnLoadPalette.Click += new System.EventHandler(this.kbtnLoadPalette_Click);
            // 
            // cgColours
            // 
            this.cgColours.BackColor = System.Drawing.Color.Transparent;
            this.cgColours.Location = new System.Drawing.Point(12, 280);
            this.cgColours.Name = "cgColours";
            this.cgColours.Size = new System.Drawing.Size(247, 165);
            this.cgColours.TabIndex = 3;
            this.cgColours.EditingColor += new System.EventHandler<Cyotek.Windows.Forms.EditColorCancelEventArgs>(this.cgColours_EditingColor);
            // 
            // cpbColourPreview
            // 
            this.cpbColourPreview.BackColor = System.Drawing.SystemColors.Control;
            this.cpbColourPreview.Location = new System.Drawing.Point(443, 252);
            this.cpbColourPreview.Name = "cpbColourPreview";
            this.cpbColourPreview.Size = new System.Drawing.Size(119, 119);
            this.cpbColourPreview.TabIndex = 2;
            this.cpbColourPreview.TabStop = false;
            this.cpbColourPreview.Paint += new System.Windows.Forms.PaintEventHandler(this.cpbColourPreview_Paint);
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kryptonOKDialogButton1);
            this.kryptonPanel2.Controls.Add(this.kryptonCancelDialogButton1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 454);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(574, 37);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 451);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(574, 3);
            this.panel1.TabIndex = 2;
            // 
            // kryptonCancelDialogButton1
            // 
            this.kryptonCancelDialogButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kryptonCancelDialogButton1.Location = new System.Drawing.Point(472, 6);
            this.kryptonCancelDialogButton1.Name = "kryptonCancelDialogButton1";
            this.kryptonCancelDialogButton1.ParentWindow = this;
            this.kryptonCancelDialogButton1.Size = new System.Drawing.Size(90, 25);
            this.kryptonCancelDialogButton1.TabIndex = 0;
            this.kryptonCancelDialogButton1.Values.Text = "C&ancel";
            // 
            // kryptonOKDialogButton1
            // 
            this.kryptonOKDialogButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kryptonOKDialogButton1.Location = new System.Drawing.Point(376, 6);
            this.kryptonOKDialogButton1.Name = "kryptonOKDialogButton1";
            this.kryptonOKDialogButton1.ParentWindow = this;
            this.kryptonOKDialogButton1.Size = new System.Drawing.Size(90, 25);
            this.kryptonOKDialogButton1.TabIndex = 3;
            this.kryptonOKDialogButton1.Values.Text = "&OK";
            // 
            // KryptonColourPickerDialog
            // 
            this.ClientSize = new System.Drawing.Size(574, 491);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonColourPickerDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Colour Picker";
            this.Load += new System.EventHandler(this.KryptonColourPickerDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbColourPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region Constants
        private static readonly object _eventPreviewColourChanged = new object();
        #endregion

        #region Fields
        private Brush _textureBrush;
        #endregion

        #region Events
        [Category("Property Changed")]
        public event EventHandler PreviewColourChanged
        {
            add { Events.AddHandler(_eventPreviewColourChanged, value); }
            remove { Events.RemoveHandler(_eventPreviewColourChanged, value); }
        }
        #endregion

        #region Properties
        //public Color Colour { get => cem.Colour; set => cem.Colour = value; }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowAlphaChannel { get; set; }
        #endregion

        #region Constructors
        public KryptonColourPickerDialog()
        {
            InitializeComponent();

            ShowAlphaChannel = true;

            Font = SystemFonts.DialogFont;
        }
        #endregion

        #region Overrides
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }

                if (_textureBrush != null)
                {
                    _textureBrush.Dispose();

                    _textureBrush = null;
                }
            }

            base.Dispose(disposing);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //ceColours.ShowAlphaChannel = ShowAlphaChannel;

            if (!ShowAlphaChannel)
            {
                for (int i = 0; i < cgColours.Colors.Count; i++)
                {
                    Color colour;

                    colour = cgColours.Colors[i];

                    if (colour.A != 255)
                    {
                        cgColours.Colors[i] = Color.FromArgb(255, colour);
                    }
                }
            }
        }
        #endregion

        #region Virtual
        protected virtual void OnPreviewColourChanged(EventArgs e)
        {
            EventHandler handler;

            handler = (EventHandler)Events[_eventPreviewColourChanged];

            handler?.Invoke(this, e);
        }
        #endregion

        private void KryptonColourPickerDialog_Load(object sender, EventArgs e)
        {

        }

        private void cwColour_ColourChanged(object sender, EventArgs e)
        {

        }

        private void kbtnLoadPalette_Click(object sender, EventArgs e)
        {
            using (FileDialog fd = new OpenFileDialog { Filter = PaletteSerializer.DefaultOpenFilter, DefaultExt = "pal", Title = "Open a custom palette file:" })
            {
                if (fd.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        IPaletteSerializer serializer;

                        serializer = PaletteSerializer.GetSerializer(fd.FileName);

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

                                cgColours.Colors = colours;
                            }
                        }
                        else
                        {
                            KryptonMessageBox.Show("Sorry, unable to open palette, the file format is not supported or is not recognized.", "Load Palette", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    catch (Exception exc)
                    {
                        KryptonMessageBox.Show($@"Sorry, unable to open palette. { exc.GetBaseException().Message }", "Load Palette", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void cem_ColourChanged(object sender, EventArgs e)
        {
            cpbColourPreview.Invalidate();

            OnPreviewColourChanged(e);
        }

        private void kbtnSavePalette_Click(object sender, EventArgs e)
        {
            using (FileDialog fd = new SaveFileDialog { Filter = PaletteSerializer.DefaultSaveFilter, DefaultExt = "pal", Title = "Save custom palette as:" })
            {
                if (fd.ShowDialog(this) == DialogResult.OK)
                {
                    IPaletteSerializer serializer;

                    serializer = PaletteSerializer.AllSerializers.Where(s => s.CanWrite).ElementAt(fd.FilterIndex - 1);

                    if (serializer != null)
                    {
                        if (!serializer.CanWrite) throw new InvalidOperationException("Serializer does not support writing palettes.");
                    }

                    try
                    {
                        using (FileStream fs = File.OpenWrite(fd.FileName))
                        {
                            serializer.Serialize(fs, cgColours.Colors);
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

        private void kbtnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void kbtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void scp_ColourChanged(object sender, EventArgs e)
        {
            //Colour = scp.Colour;

            OnPreviewColourChanged(e);
        }

        private void cgColours_EditingColor(object sender, EditColorCancelEventArgs e)
        {
            e.Cancel = true;

            // TODO: Use Krypton
            using (ColorDialog cd = new ColorDialog { FullOpen = true, Color = e.Color })
            {
                if (cd.ShowDialog(this) == DialogResult.OK) cgColours.Colors[e.ColorIndex] = cd.Color;
            }
        }

        private void cpbColourPreview_Paint(object sender, PaintEventArgs e)
        {
            Rectangle region;

            region = cpbColourPreview.ClientRectangle;

            //if (Colour.A != 255)
            //{
            //    if (_textureBrush == null)
            //    {
            //        using (Bitmap bg = new Bitmap(GetType().Assembly.GetManifestResourceStream(string.Concat(GetType().Namespace, ".Resources.cellbackground.png"))))
            //        {
            //            _textureBrush = new TextureBrush(bg, WrapMode.Tile);
            //        }
            //    }

            //    e.Graphics.FillRectangle(_textureBrush, region);
            //}

            //using (Brush brush = new SolidBrush(this.Colour))
            //{
            //    e.Graphics.FillRectangle(brush, region);
            //}

            e.Graphics.DrawRectangle(SystemPens.ControlText, region.Left, region.Top, region.Width - 1, region.Height - 1);
        }
    }
}