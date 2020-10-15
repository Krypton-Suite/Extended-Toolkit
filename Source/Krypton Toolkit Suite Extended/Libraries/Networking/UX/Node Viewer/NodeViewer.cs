using Krypton.Toolkit.Suite.Extended.Base;
using Krypton.Toolkit.Suite.Extended.Core;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.IO;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Networking
{
    /// <summary>
    /// A simply test form that creates a new NetworkBrowser
    /// object, and displays a list of the network computers
    /// found by the NetworkBrowser
    /// </summary>
    public class NodeViewer : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnExportNodeList;
        private KryptonButton kbtnOk;
        private System.Windows.Forms.Panel panel1;
        private KryptonPanel kryptonPanel2;
        private KryptonComboBox kcmbNodeList;
        private KryptonLabel kryptonLabel1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnOk = new Krypton.Toolkit.KryptonButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kcmbNodeList = new Krypton.Toolkit.KryptonComboBox();
            this.kbtnExportNodeList = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbNodeList)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnExportNodeList);
            this.kryptonPanel1.Controls.Add(this.kbtnOk);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 140);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(445, 45);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnOk
            // 
            this.kbtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnOk.Location = new System.Drawing.Point(343, 8);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.Size = new System.Drawing.Size(90, 25);
            this.kbtnOk.TabIndex = 1;
            this.kbtnOk.Values.Text = "O&k";
            this.kbtnOk.Click += new System.EventHandler(this.kbtnOk_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 137);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(445, 3);
            this.panel1.TabIndex = 1;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kcmbNodeList);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(445, 137);
            this.kryptonPanel2.TabIndex = 2;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(31, 31);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(148, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Available Network Nodes";
            // 
            // kcmbNodeList
            // 
            this.kcmbNodeList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.kcmbNodeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kcmbNodeList.DropDownWidth = 392;
            this.kcmbNodeList.IntegralHeight = false;
            this.kcmbNodeList.Location = new System.Drawing.Point(31, 58);
            this.kcmbNodeList.Name = "kcmbNodeList";
            this.kcmbNodeList.Size = new System.Drawing.Size(392, 21);
            this.kcmbNodeList.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbNodeList.TabIndex = 1;
            this.kcmbNodeList.SelectedIndexChanged += new System.EventHandler(this.kcmbNodeList_SelectedIndexChanged);
            // 
            // kbtnExportNodeList
            // 
            this.kbtnExportNodeList.Location = new System.Drawing.Point(13, 8);
            this.kbtnExportNodeList.Name = "kbtnExportNodeList";
            this.kbtnExportNodeList.Size = new System.Drawing.Size(166, 25);
            this.kbtnExportNodeList.TabIndex = 2;
            this.kbtnExportNodeList.Values.Text = "Export Node List to &File...";
            this.kbtnExportNodeList.Click += new System.EventHandler(this.kbtnExportNodeList_Click);
            // 
            // NodeViewer
            // 
            this.AcceptButton = this.kbtnOk;
            this.ClientSize = new System.Drawing.Size(445, 185);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "NodeViewer";
            this.Load += new System.EventHandler(this.NodeViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbNodeList)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Constructor
        public NodeViewer()
        {
            InitializeComponent();
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
                KryptonMessageBoxExtended.Show($"An error occurred trying to access the network computers.\n\n\n{ ex.Message }", "Error",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void kbtnExportNodeList_Click(object sender, EventArgs e)
        {
            try
            {
                string defaultFileName = $"Network Node List - { DateTime.Now.ToShortDateString() }";

                CommonSaveFileDialog csfd = new CommonSaveFileDialog();

                csfd.Title = "Save Network Node List";

                csfd.Filters.Add(new CommonFileDialogFilter("Text Files", "txt"));

                csfd.DefaultFileName = defaultFileName;

                if (csfd.ShowDialog() == CommonFileDialogResult.Ok)
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

                kbtnExportNodeList.Enabled = false;
            }
            catch (Exception exc)
            {
                ExceptionHandler.CaptureException(exc);
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
}