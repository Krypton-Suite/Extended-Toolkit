using Krypton.Toolkit;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Cyotek.Windows.Forms.Colour.Picker
{
    [DefaultEvent("PreviewColourChanged")]
    [DefaultProperty("Colour")]
    public partial class ColorPickerDialog : KryptonForm
    {
        #region Design Code
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.okButton = new Krypton.Toolkit.KryptonButton();
            this.cancelButton = new Krypton.Toolkit.KryptonButton();
            this.previewPanel = new Krypton.Toolkit.KryptonPanel();
            this.loadPaletteButton = new Krypton.Toolkit.KryptonButton();
            this.savePaletteButton = new Krypton.Toolkit.KryptonButton();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.screenColorPicker = new ScreenColourPicker();
            this.colorWheel = new ColourWheel();
            this.colorEditor = new ColourEditor();
            this.colorGrid = new ColourGrid();
            this.colorEditorManager = new ColourEditorManager();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(453, 12);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(453, 41);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // previewPanel
            // 
            this.previewPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.previewPanel.Location = new System.Drawing.Point(453, 203);
            this.previewPanel.Name = "previewPanel";
            this.previewPanel.Size = new System.Drawing.Size(75, 47);
            this.previewPanel.TabIndex = 3;
            this.previewPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.previewPanel_Paint);
            // 
            // loadPaletteButton
            // 
            this.loadPaletteButton.Values.Image = global::Cyotek.Windows.Forms.Colour.Picker.Properties.Resources.palette_load;
            this.loadPaletteButton.Location = new System.Drawing.Point(12, 147);
            this.loadPaletteButton.Name = "loadPaletteButton";
            this.loadPaletteButton.Size = new System.Drawing.Size(23, 23);
            this.loadPaletteButton.TabIndex = 5;
            this.toolTip.SetToolTip(this.loadPaletteButton, "Load Palette");
            this.loadPaletteButton.Click += new System.EventHandler(this.loadPaletteButton_Click);
            // 
            // savePaletteButton
            // 
            this.savePaletteButton.Values.Image = global::Cyotek.Windows.Forms.Colour.Picker.Properties.Resources.palette_save;
            this.savePaletteButton.Location = new System.Drawing.Point(34, 147);
            this.savePaletteButton.Name = "savePaletteButton";
            this.savePaletteButton.Size = new System.Drawing.Size(23, 23);
            this.savePaletteButton.TabIndex = 6;
            this.toolTip.SetToolTip(this.savePaletteButton, "Save Palette");
            this.savePaletteButton.Click += new System.EventHandler(this.savePaletteButton_Click);
            // 
            // screenColorPicker
            // 
            this.screenColorPicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.screenColorPicker.Colour = System.Drawing.Color.Black;
            this.screenColorPicker.Image = global::Cyotek.Windows.Forms.Colour.Picker.Properties.Resources.eyedropper1;
            this.screenColorPicker.Location = new System.Drawing.Point(453, 83);
            this.screenColorPicker.Name = "screenColorPicker";
            this.screenColorPicker.Size = new System.Drawing.Size(73, 85);
            this.toolTip.SetToolTip(this.screenColorPicker, "Click and drag to select screen color");
            this.screenColorPicker.Zoom = 6;
            // 
            // colorWheel
            // 
            this.colorWheel.Colour = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colorWheel.Location = new System.Drawing.Point(12, 12);
            this.colorWheel.Name = "colorWheel";
            this.colorWheel.Size = new System.Drawing.Size(192, 147);
            this.colorWheel.TabIndex = 4;
            // 
            // colorEditor
            // 
            this.colorEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
            this.colorEditor.Colour = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colorEditor.Location = new System.Drawing.Point(210, 12);
            this.colorEditor.Name = "colorEditor";
            this.colorEditor.Size = new System.Drawing.Size(230, 238);
            this.colorEditor.TabIndex = 0;
            // 
            // colorGrid
            // 
            this.colorGrid.Location = new System.Drawing.Point(12, 176);
            this.colorGrid.Name = "colorGrid";
            this.colorGrid.Padding = new System.Windows.Forms.Padding(0);
            this.colorGrid.Palette = ColourPalette.Paint;
            this.colorGrid.SelectedCellStyle = ColourGridSelectedCellStyle.Standard;
            this.colorGrid.ShowCustomColours = false;
            this.colorGrid.Size = new System.Drawing.Size(192, 72);
            this.colorGrid.Spacing = new System.Drawing.Size(0, 0);
            this.colorGrid.TabIndex = 7;
            this.colorGrid.EditingColour += new System.EventHandler<EditColourCancelEventArgs>(this.colorGrid_EditingColor);
            // 
            // colorEditorManager
            // 
            this.colorEditorManager.ColourEditor = this.colorEditor;
            this.colorEditorManager.ColourGrid = this.colorGrid;
            this.colorEditorManager.ColourWheel = this.colorWheel;
            this.colorEditorManager.ScreenColourPicker = this.screenColorPicker;
            this.colorEditorManager.ColourChanged += new System.EventHandler(this.colorEditorManager_ColorChanged);
            // 
            // ColorPickerDialog
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(540, 262);
            this.Controls.Add(this.savePaletteButton);
            this.Controls.Add(this.loadPaletteButton);
            this.Controls.Add(this.previewPanel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.screenColorPicker);
            this.Controls.Add(this.colorWheel);
            this.Controls.Add(this.colorEditor);
            this.Controls.Add(this.colorGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColourPickerDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Colour Picker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ColourGrid colorGrid;
        private ColourEditor colorEditor;
        private ColourWheel colorWheel;
        private ColourEditorManager colorEditorManager;
        private ScreenColourPicker screenColorPicker;
        private Krypton.Toolkit.KryptonButton okButton;
        private Krypton.Toolkit.KryptonButton cancelButton;
        private Krypton.Toolkit.KryptonPanel previewPanel;
        private Krypton.Toolkit.KryptonButton loadPaletteButton;
        private Krypton.Toolkit.KryptonButton savePaletteButton;
        private System.Windows.Forms.ToolTip toolTip;
        #endregion

        #region Constants

        private static readonly object _eventPreviewColorChanged = new object();

        #endregion

        #region Fields

        private Brush _textureBrush;

        #endregion

        #region Constructors

        public ColorPickerDialog()
        {
            this.InitializeComponent();
            this.ShowAlphaChannel = true;
            this.Font = SystemFonts.DialogFont;
        }

        #endregion

        #region Events

        [Category("Property Changed")]
        public event EventHandler PreviewColourChanged
        {
            add { this.Events.AddHandler(_eventPreviewColorChanged, value); }
            remove { this.Events.RemoveHandler(_eventPreviewColorChanged, value); }
        }

        #endregion

        #region Properties

        public Color Colour
        {
            get { return colorEditorManager.Colour; }
            set { colorEditorManager.Colour = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowAlphaChannel { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.Load"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data. </param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            colorEditor.ShowAlphaChannel = this.ShowAlphaChannel;

            if (!this.ShowAlphaChannel)
            {
                for (int i = 0; i < colorGrid.Colours.Count; i++)
                {
                    Color color;

                    color = colorGrid.Colours[i];
                    if (color.A != 255)
                    {
                        colorGrid.Colours[i] = Color.FromArgb(255, color);
                    }
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="PreviewColourChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnPreviewColorChanged(EventArgs e)
        {
            EventHandler handler;

            handler = (EventHandler)this.Events[_eventPreviewColorChanged];

            handler?.Invoke(this, e);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void colorEditorManager_ColorChanged(object sender, EventArgs e)
        {
            previewPanel.Invalidate();

            this.OnPreviewColorChanged(e);
        }

        private void colorGrid_EditingColor(object sender, EditColourCancelEventArgs e)
        {
            e.Cancel = true;

            using (ColorDialog dialog = new ColorDialog
            {
                FullOpen = true,
                Color = e.Colour
            })
            {
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    colorGrid.Colours[e.ColourIndex] = dialog.Color;
                }
            }
        }

        private void loadPaletteButton_Click(object sender, EventArgs e)
        {
            using (FileDialog dialog = new OpenFileDialog
            {
                Filter = PaletteSerializer.DefaultOpenFilter,
                DefaultExt = "pal",
                Title = "Open Palette File"
            })
            {
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        IPaletteSerializer serializer;

                        serializer = PaletteSerializer.GetSerializer(dialog.FileName);
                        if (serializer != null)
                        {
                            ColourCollection palette;

                            if (!serializer.CanRead)
                            {
                                throw new InvalidOperationException("Serializer does not support reading palettes.");
                            }

                            using (FileStream file = File.OpenRead(dialog.FileName))
                            {
                                palette = serializer.Deserialize(file);
                            }

                            if (palette != null)
                            {
                                // we can only display 96 colors in the color grid due to it's size, so if there's more, bin them
                                while (palette.Count > 96)
                                {
                                    palette.RemoveAt(palette.Count - 1);
                                }

                                // or if we have less, fill in the blanks
                                while (palette.Count < 96)
                                {
                                    palette.Add(Color.White);
                                }

                                colorGrid.Colours = palette;
                            }
                        }
                        else
                        {
                            KryptonMessageBox.Show("Sorry, unable to open palette, the file format is not supported or is not recognized.", "Load Palette", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    catch (Exception ex)
                    {
                        KryptonMessageBox.Show(string.Format("Sorry, unable to open palette. {0}", ex.GetBaseException().Message), "Load Palette", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void previewPanel_Paint(object sender, PaintEventArgs e)
        {
            Rectangle region;

            region = previewPanel.ClientRectangle;

            if (this.Colour.A != 255)
            {
                if (_textureBrush == null)
                {
                    using (Bitmap background = new Bitmap(this.GetType().Assembly.GetManifestResourceStream(string.Concat(this.GetType().Namespace, ".Resources.cellbackground.png"))))
                    {
                        _textureBrush = new TextureBrush(background, WrapMode.Tile);
                    }
                }

                e.Graphics.FillRectangle(_textureBrush, region);
            }

            using (Brush brush = new SolidBrush(this.Colour))
            {
                e.Graphics.FillRectangle(brush, region);
            }

            e.Graphics.DrawRectangle(SystemPens.ControlText, region.Left, region.Top, region.Width - 1, region.Height - 1);
        }

        private void savePaletteButton_Click(object sender, EventArgs e)
        {
            using (FileDialog dialog = new SaveFileDialog
            {
                Filter = PaletteSerializer.DefaultSaveFilter,
                DefaultExt = "pal",
                Title = "Save Palette File As"
            })
            {
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    IPaletteSerializer serializer;

                    serializer = PaletteSerializer.AllSerializers.Where(s => s.CanWrite).ElementAt(dialog.FilterIndex - 1);
                    if (serializer != null)
                    {
                        if (!serializer.CanWrite)
                        {
                            throw new InvalidOperationException("Serializer does not support writing palettes.");
                        }

                        try
                        {
                            using (FileStream file = File.OpenWrite(dialog.FileName))
                            {
                                serializer.Serialize(file, colorGrid.Colours);
                            }
                        }
                        catch (Exception ex)
                        {
                            KryptonMessageBox.Show(string.Format("Sorry, unable to save palette. {0}", ex.GetBaseException().Message), "Save Palette", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        KryptonMessageBox.Show("Sorry, unable to save palette, the file format is not supported or is not recognized.", "Save Palette", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        #endregion
    }
}