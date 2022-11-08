#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Memory.Box
{
    public class KryptonMemoryBox : CommonExtendedKryptonForm
    {
        #region Designer Code
        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnButtonFive;
        private KryptonButton kbtnButtonFour;
        private KryptonButton kbtnButtonThree;
        private KryptonButton kbtnButtonTwo;
        private KryptonButton kbtnButtonOne;
        private KryptonBorderEdge kryptonBorderEdge1;
        private PictureBox pbxIcon;
        private KryptonWrapLabel kwlBody;
        private KryptonPanel kryptonPanel2;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnButtonOne = new Krypton.Toolkit.KryptonButton();
            this.kbtnButtonTwo = new Krypton.Toolkit.KryptonButton();
            this.kbtnButtonThree = new Krypton.Toolkit.KryptonButton();
            this.kbtnButtonFour = new Krypton.Toolkit.KryptonButton();
            this.kbtnButtonFive = new Krypton.Toolkit.KryptonButton();
            this.kwlBody = new Krypton.Toolkit.KryptonWrapLabel();
            this.pbxIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnButtonFive);
            this.kryptonPanel1.Controls.Add(this.kbtnButtonFour);
            this.kryptonPanel1.Controls.Add(this.kbtnButtonThree);
            this.kryptonPanel1.Controls.Add(this.kbtnButtonTwo);
            this.kryptonPanel1.Controls.Add(this.kbtnButtonOne);
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 225);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(505, 50);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderSecondary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(505, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.pbxIcon);
            this.kryptonPanel2.Controls.Add(this.kwlBody);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(505, 225);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // kbtnButtonOne
            // 
            this.kbtnButtonOne.Location = new System.Drawing.Point(12, 13);
            this.kbtnButtonOne.Name = "kbtnButtonOne";
            this.kbtnButtonOne.Size = new System.Drawing.Size(90, 25);
            this.kbtnButtonOne.TabIndex = 1;
            this.kbtnButtonOne.Values.Text = "&Yes";
            this.kbtnButtonOne.Click += new System.EventHandler(this.kbtnButtonOne_Click);
            // 
            // kbtnButtonTwo
            // 
            this.kbtnButtonTwo.Location = new System.Drawing.Point(109, 13);
            this.kbtnButtonTwo.Name = "kbtnButtonTwo";
            this.kbtnButtonTwo.Size = new System.Drawing.Size(90, 25);
            this.kbtnButtonTwo.TabIndex = 2;
            this.kbtnButtonTwo.Values.Text = "Ye&s to All";
            this.kbtnButtonTwo.Click += new System.EventHandler(this.kbtnButtonTwo_Click);
            // 
            // kbtnButtonThree
            // 
            this.kbtnButtonThree.Location = new System.Drawing.Point(206, 13);
            this.kbtnButtonThree.Name = "kbtnButtonThree";
            this.kbtnButtonThree.Size = new System.Drawing.Size(90, 25);
            this.kbtnButtonThree.TabIndex = 3;
            this.kbtnButtonThree.Values.Text = "&No";
            this.kbtnButtonThree.Click += new System.EventHandler(this.kbtnButtonThree_Click);
            // 
            // kbtnButtonFour
            // 
            this.kbtnButtonFour.Location = new System.Drawing.Point(303, 13);
            this.kbtnButtonFour.Name = "kbtnButtonFour";
            this.kbtnButtonFour.Size = new System.Drawing.Size(90, 25);
            this.kbtnButtonFour.TabIndex = 4;
            this.kbtnButtonFour.Values.Text = "N&o to All";
            this.kbtnButtonFour.Click += new System.EventHandler(this.kbtnButtonFour_Click);
            // 
            // kbtnButtonFive
            // 
            this.kbtnButtonFive.Location = new System.Drawing.Point(400, 13);
            this.kbtnButtonFive.Name = "kbtnButtonFive";
            this.kbtnButtonFive.Size = new System.Drawing.Size(90, 25);
            this.kbtnButtonFive.TabIndex = 5;
            this.kbtnButtonFive.Values.Text = "&Cancel";
            this.kbtnButtonFive.Click += new System.EventHandler(this.kbtnButtonFive_Click);
            // 
            // kwlBody
            // 
            this.kwlBody.AutoSize = false;
            this.kwlBody.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kwlBody.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlBody.Location = new System.Drawing.Point(83, 13);
            this.kwlBody.Name = "kwlBody";
            this.kwlBody.Size = new System.Drawing.Size(410, 199);
            this.kwlBody.Text = "kryptonWrapLabel1";
            this.kwlBody.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbxIcon
            // 
            this.pbxIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbxIcon.Location = new System.Drawing.Point(13, 13);
            this.pbxIcon.Name = "pbxIcon";
            this.pbxIcon.Size = new System.Drawing.Size(64, 64);
            this.pbxIcon.TabIndex = 1;
            this.pbxIcon.TabStop = false;
            // 
            // KryptonMemoryBox
            // 
            this.ClientSize = new System.Drawing.Size(505, 275);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonMemoryBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private KryptonMemoryBoxDialogResult _defaultDialogResult, _lastResult;
        #endregion

        #region Property
        public KryptonMemoryBoxDialogResult DefaultDialogResult { get => _defaultDialogResult; set => _defaultDialogResult = value; }
        #endregion

        #region Constructors
        public KryptonMemoryBox()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods
        /// <summary>Sets the button text.</summary>
        /// <param name="yesText">The yes text.</param>
        /// <param name="yesToAllText">The yes to all text.</param>
        /// <param name="noText">The no text.</param>
        /// <param name="noToAllText">The no to all text.</param>
        /// <param name="cancelText">The cancel text.</param>
        private void SetButtonText(string yesText, string yesToAllText, string noText, string noToAllText, string cancelText)
        {
            kbtnButtonOne.Text = yesText;

            kbtnButtonTwo.Text = yesToAllText;

            kbtnButtonThree.Text = noText;

            kbtnButtonFour.Text = noToAllText;

            kbtnButtonFive.Text = cancelText;
        }

        /// <summary>Sets the default dialog result.</summary>
        /// <param name="dialogResult">The dialog result.</param>
        private void SetDefaultDialogResult(KryptonMemoryBoxDialogResult dialogResult)
        {
            switch (dialogResult)
            {
                case KryptonMemoryBoxDialogResult.YES:
                    AcceptButton = kbtnButtonOne;
                    break;
                case KryptonMemoryBoxDialogResult.YESTOALL:
                    AcceptButton = kbtnButtonTwo;
                    break;
                case KryptonMemoryBoxDialogResult.NO:
                    AcceptButton = kbtnButtonThree;
                    break;
                case KryptonMemoryBoxDialogResult.NOTOALL:
                    AcceptButton = kbtnButtonFour;
                    break;
                case KryptonMemoryBoxDialogResult.CANCEL:
                    AcceptButton = kbtnButtonFive;
                    break;
            }
        }

        /// <summary>Shows the krypton memory box dialog result.</summary>
        /// <returns></returns>
        private KryptonMemoryBoxDialogResult ShowKryptonMemoryBoxDialogResult()
        {
            _defaultDialogResult = KryptonMemoryBoxDialogResult.CANCEL;

            if (_lastResult == KryptonMemoryBoxDialogResult.NOTOALL)
            {
                _defaultDialogResult = KryptonMemoryBoxDialogResult.NO;
            }
            else if (_lastResult == KryptonMemoryBoxDialogResult.YESTOALL)
            {
                _defaultDialogResult = KryptonMemoryBoxDialogResult.YES;
            }
            else
            {
                base.ShowDialog();
            }

            return _defaultDialogResult;
        }

        /// <summary>Shows the krypton memory box dialog result.</summary>
        /// <param name="title">The title.</param>
        /// <param name="message">The message.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="iconPath">The icon path.</param>
        /// <param name="defaultButton">The default button.</param>
        /// <param name="defaultDialogResult">The default dialog result.</param>
        /// <returns></returns>
        private KryptonMemoryBoxDialogResult ShowKryptonMemoryBoxDialogResult(string title, string message, KryptonMemoryBoxIcon icon = KryptonMemoryBoxIcon.NONE, string iconPath = null, KryptonMemoryBoxDefaultButton defaultButton = KryptonMemoryBoxDefaultButton.BUTTONONE, KryptonMemoryBoxDialogResult defaultDialogResult = KryptonMemoryBoxDialogResult.CANCEL)
        {
            Text = title;

            kwlBody.Text = message;

            switch (icon)
            {
                case KryptonMemoryBoxIcon.CUSTOM:
                    pbxIcon.Image = new Bitmap(iconPath);
                    break;
                case KryptonMemoryBoxIcon.OK:
                    pbxIcon.Image = Properties.Resources.Input_Box_Ok_64_x_64;
                    break;
                case KryptonMemoryBoxIcon.ERROR:
                    pbxIcon.Image = Properties.Resources.Input_Box_Critical_64_x_64;
                    break;
                case KryptonMemoryBoxIcon.EXCLAMATION:
                    pbxIcon.Image = Properties.Resources.Input_Box_Warning_64_x_58;
                    break;
                case KryptonMemoryBoxIcon.INFORMATION:
                    pbxIcon.Image = Properties.Resources.Input_Box_Information_64_x_64;
                    break;
                case KryptonMemoryBoxIcon.QUESTION:
                    pbxIcon.Image = Properties.Resources.Input_Box_Question_64_x_64;
                    break;
                case KryptonMemoryBoxIcon.NONE:
                    pbxIcon.Image = null;

                    UpdateUI();
                    break;
                case KryptonMemoryBoxIcon.STOP:
                    pbxIcon.Image = Properties.Resources.Input_Box_Stop_64_x_64;
                    break;
                case KryptonMemoryBoxIcon.HAND:
                    pbxIcon.Image = Properties.Resources.Input_Box_Hand_64_x_64;
                    break;
            }

            SetDefaultButton(defaultButton);

            SetDefaultDialogResult(defaultDialogResult);

            return ShowKryptonMemoryBoxDialogResult();
        }

        /// <summary>Shows the specified title.</summary>
        /// <param name="title">The title.</param>
        /// <param name="message">The message.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="iconPath">The icon path.</param>
        /// <param name="defaultButton">The default button.</param>
        /// <param name="defaultDialogResult">The default dialog result.</param>
        /// <returns></returns>
        public static KryptonMemoryBoxDialogResult Show(string title, string message, KryptonMemoryBoxIcon icon = KryptonMemoryBoxIcon.NONE, string iconPath = null, KryptonMemoryBoxDefaultButton defaultButton = KryptonMemoryBoxDefaultButton.BUTTONONE, KryptonMemoryBoxDialogResult defaultDialogResult = KryptonMemoryBoxDialogResult.CANCEL)
        {
            KryptonMemoryBox memoryBox = new KryptonMemoryBox();

            return memoryBox.ShowKryptonMemoryBoxDialogResult(title, message, icon, iconPath, defaultButton, defaultDialogResult);
        }

        private void UpdateUI()
        {
            if (pbxIcon.Image != null)
            {
                pbxIcon.Visible = true;

                kwlBody.Size = new Size(404, 211);
            }
            else
            {
                pbxIcon.Visible = false;

                kwlBody.Size = new Size(474, 211);
            }
        }

        /*
        private DialogResult ConvertKryptonMemoryBoxDialogResult(KryptonMemoryBoxDialogResult dialogResult)
        {
            DialogResult result;

            if (dialogResult == KryptonMemoryBoxDialogResult.CANCEL)
            {
                result = DialogResult.Cancel;
            }

            return result;
        }
        */

        private DialogResult ReturnDialogResult(DialogResult result) => result;

        private void SetAcceptButton(KryptonButton button) => AcceptButton = button;

        private void SetDefaultButton(KryptonMemoryBoxDefaultButton defaultButton)
        {
            switch (defaultButton)
            {
                case KryptonMemoryBoxDefaultButton.BUTTONONE:
                    SetAcceptButton(kbtnButtonOne);
                    break;
                case KryptonMemoryBoxDefaultButton.BUTTONTWO:
                    SetAcceptButton(kbtnButtonTwo);
                    break;
                case KryptonMemoryBoxDefaultButton.BUTTONTHREE:
                    SetAcceptButton(kbtnButtonThree);
                    break;
                case KryptonMemoryBoxDefaultButton.BUTTONFOUR:
                    SetAcceptButton(kbtnButtonFour);
                    break;
                case KryptonMemoryBoxDefaultButton.BUTTONFIVE:
                    SetAcceptButton(kbtnButtonFive);
                    break;
                default:
                    SetAcceptButton(kbtnButtonOne);
                    break;
            }
        }

        private void SetDialogResult(KryptonMemoryBoxDialogResult memoryBoxDialogResult, DialogResult dialogResult)
        {
            _defaultDialogResult = memoryBoxDialogResult;

            _lastResult = memoryBoxDialogResult;

            DialogResult = dialogResult;
        }
        #endregion

        private void kbtnButtonOne_Click(object sender, EventArgs e)
        {
            SetDialogResult(KryptonMemoryBoxDialogResult.YES, DialogResult.Yes);
        }

        private void kbtnButtonTwo_Click(object sender, EventArgs e)
        {
            SetDialogResult(KryptonMemoryBoxDialogResult.YESTOALL, DialogResult.Yes);
        }

        private void kbtnButtonThree_Click(object sender, EventArgs e)
        {
            SetDialogResult(KryptonMemoryBoxDialogResult.NO, DialogResult.No);
        }

        private void kbtnButtonFour_Click(object sender, EventArgs e)
        {
            SetDialogResult(KryptonMemoryBoxDialogResult.NOTOALL, DialogResult.No);
        }

        private void kbtnButtonFive_Click(object sender, EventArgs e)
        {
            SetDialogResult(KryptonMemoryBoxDialogResult.CANCEL, DialogResult.Cancel);
        }
    }
}