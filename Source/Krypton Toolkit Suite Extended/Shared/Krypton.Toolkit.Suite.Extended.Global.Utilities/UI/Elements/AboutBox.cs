#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Global.Utilities
{
    /// <summary>
    /// Displays the application information.
    /// </summary>
    /// <seealso cref="Toolkit.KryptonForm" />
    /// <seealso cref="IAbout" />
    public partial class AboutBox : KryptonForm, IAbout
    {
        #region Designer Code
        /// <summary>
        /// Required designer variable.
        /// </summary
        private System.ComponentModel.IContainer components = null;


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBox));
            this.kryptonPanel1 = new Toolkit.KryptonPanel();
            this.kryptonManager1 = new Toolkit.KryptonManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(954, 659);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kryptonManager1
            // 
            this.kryptonManager1.GlobalPaletteMode = Toolkit.PaletteModeManager.Office2010Blue;
            // 
            // AboutBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 659);
            this.Controls.Add(this.kryptonPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AboutBox";
            this.Text = "AboutBox";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Toolkit.KryptonPanel kryptonPanel1;
        private Toolkit.KryptonManager kryptonManager1;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="AboutBox"/> class.
        /// </summary>
        public AboutBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets a value indicating whether [use icon].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [use icon]; otherwise, <c>false</c>.
        /// </value>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool UseIcon { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool ShowSystemInformationButton { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime CreationDateTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Version ApplicationVersion { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Version FrameworkVersion { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Icon ApplicationIcon { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Bitmap ApplicationIconImage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string AuthourName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string InstallLocation { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}