using EasyScintilla;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.IO;
using System.Windows.Forms;
using Krypton.Toolkit.Suite.Extended.Base;

namespace Krypton.Toolkit.Suite.Extended.Palette.Selectors
{
    public class KryptonCustomPaletteXmlDialog : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private Dialogs.KryptonOKDialogButton kdbtnOk;
        private KryptonButton kbtnSave;
        private KryptonButton kbtnCreate;
        private KryptonButton kbtnLoadPalette;
        private System.Windows.Forms.Panel panel1;
        private EasyScintilla.SimpleEditor sePalette;
        private KryptonPanel kryptonPanel2;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KryptonCustomPaletteXmlDialog));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kdbtnOk = new Krypton.Toolkit.Suite.Extended.Dialogs.KryptonOKDialogButton();
            this.kbtnSave = new Krypton.Toolkit.KryptonButton();
            this.kbtnCreate = new Krypton.Toolkit.KryptonButton();
            this.kbtnLoadPalette = new Krypton.Toolkit.KryptonButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.sePalette = new EasyScintilla.SimpleEditor();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kdbtnOk);
            this.kryptonPanel1.Controls.Add(this.kbtnSave);
            this.kryptonPanel1.Controls.Add(this.kbtnCreate);
            this.kryptonPanel1.Controls.Add(this.kbtnLoadPalette);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 412);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(664, 42);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kdbtnOk
            // 
            this.kdbtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kdbtnOk.Location = new System.Drawing.Point(562, 5);
            this.kdbtnOk.Name = "kdbtnOk";
            this.kdbtnOk.ParentWindow = null;
            this.kdbtnOk.Size = new System.Drawing.Size(90, 25);
            this.kdbtnOk.TabIndex = 4;
            this.kdbtnOk.Values.Text = "&OK";
            this.kdbtnOk.Click += new System.EventHandler(this.kdbtnOk_Click);
            // 
            // kbtnSave
            // 
            this.kbtnSave.Enabled = false;
            this.kbtnSave.Location = new System.Drawing.Point(204, 5);
            this.kbtnSave.Name = "kbtnSave";
            this.kbtnSave.Size = new System.Drawing.Size(90, 25);
            this.kbtnSave.TabIndex = 2;
            this.kbtnSave.Values.Text = "S&ave";
            this.kbtnSave.Click += new System.EventHandler(this.kbtnSave_Click);
            // 
            // kbtnCreate
            // 
            this.kbtnCreate.Location = new System.Drawing.Point(108, 5);
            this.kbtnCreate.Name = "kbtnCreate";
            this.kbtnCreate.Size = new System.Drawing.Size(90, 25);
            this.kbtnCreate.TabIndex = 3;
            this.kbtnCreate.Values.Text = "Create &New...";
            // 
            // kbtnLoadPalette
            // 
            this.kbtnLoadPalette.Location = new System.Drawing.Point(12, 5);
            this.kbtnLoadPalette.Name = "kbtnLoadPalette";
            this.kbtnLoadPalette.Size = new System.Drawing.Size(90, 25);
            this.kbtnLoadPalette.TabIndex = 1;
            this.kbtnLoadPalette.Values.Text = "&Load";
            this.kbtnLoadPalette.Click += new System.EventHandler(this.kbtnLoadPalette_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 409);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(664, 3);
            this.panel1.TabIndex = 1;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.sePalette);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(664, 409);
            this.kryptonPanel2.TabIndex = 2;
            // 
            // sePalette
            // 
            this.sePalette.IndentationGuides = ScintillaNET.IndentView.LookBoth;
            this.sePalette.Lexer = ScintillaNET.Lexer.Xml;
            this.sePalette.Location = new System.Drawing.Point(12, 12);
            this.sePalette.Name = "sePalette";
            this.sePalette.Size = new System.Drawing.Size(640, 391);
            this.sePalette.Styler = null;
            this.sePalette.TabIndex = 3;
            // 
            // KryptonCustomPaletteXmlDialog
            // 
            this.AcceptButton = this.kdbtnOk;
            this.ClientSize = new System.Drawing.Size(664, 454);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonCustomPaletteXmlDialog";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public SimpleEditor PaletteEdit { get => sePalette; }

        public KryptonCustomPaletteXmlDialog()
        {
            InitializeComponent();
        }

        public KryptonCustomPaletteXmlDialog(FormStartPosition startPosition)
        {
            InitializeComponent();

            StartPosition = startPosition;
        }

        public KryptonCustomPaletteXmlDialog(FormStartPosition startPosition, string value)
        {
            InitializeComponent();

            StartPosition = startPosition;

            if (!string.IsNullOrEmpty(value))
            {
                PaletteEdit.Text = value;
            }
        }

        private void kbtnLoadPalette_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog cofd = new CommonOpenFileDialog();

            if (cofd.ShowDialog() == CommonFileDialogResult.Ok)
            {
                var path = cofd.FileName;

                PaletteEdit.Text = File.ReadAllText(path);
            }
            else
            {
                return;
            }
        }

        private void kbtnSave_Click(object sender, EventArgs e)
        {

        }

        private void kdbtnOk_Click(object sender, EventArgs e)
        {
            if (PaletteEdit.Modified)
            {
                DialogResult result = KryptonMessageBoxExtended.Show("There is a unsaved palette file. Do you want to save now?", "Unsaved File", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    kbtnSave.PerformClick();

                    Close();
                }
                else
                {
                    Close();
                }
            }
            else
            {
                Close();
            }
        }
    }
}