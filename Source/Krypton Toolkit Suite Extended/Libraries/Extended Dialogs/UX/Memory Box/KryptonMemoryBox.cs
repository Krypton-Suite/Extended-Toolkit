using Krypton.Toolkit.Suite.Extended.Dialogs.Resources;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    public class KryptonMemoryBox : KryptonForm
    {
        #region Designer Code
        private KryptonPanel kryptonPanel1;
        private KryptonLabel klblBody;
        private KryptonButton kbtnButtonTwo;
        private KryptonButton kbtnButtonFour;
        private KryptonButton kbtnButtonThree;
        private KryptonButton kbtnButtonFive;
        private KryptonButton kbtnButtonOne;
        private System.Windows.Forms.PictureBox pbxIcon;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnButtonTwo = new Krypton.Toolkit.KryptonButton();
            this.kbtnButtonFour = new Krypton.Toolkit.KryptonButton();
            this.kbtnButtonThree = new Krypton.Toolkit.KryptonButton();
            this.kbtnButtonFive = new Krypton.Toolkit.KryptonButton();
            this.kbtnButtonOne = new Krypton.Toolkit.KryptonButton();
            this.klblBody = new Krypton.Toolkit.KryptonLabel();
            this.pbxIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnButtonTwo);
            this.kryptonPanel1.Controls.Add(this.kbtnButtonFour);
            this.kryptonPanel1.Controls.Add(this.kbtnButtonThree);
            this.kryptonPanel1.Controls.Add(this.kbtnButtonFive);
            this.kryptonPanel1.Controls.Add(this.kbtnButtonOne);
            this.kryptonPanel1.Controls.Add(this.klblBody);
            this.kryptonPanel1.Controls.Add(this.pbxIcon);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(501, 271);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnButtonTwo
            // 
            this.kbtnButtonTwo.Location = new System.Drawing.Point(108, 234);
            this.kbtnButtonTwo.Name = "kbtnButtonTwo";
            this.kbtnButtonTwo.Size = new System.Drawing.Size(90, 25);
            this.kbtnButtonTwo.TabIndex = 7;
            this.kbtnButtonTwo.Values.Text = "Ye&s to All";
            this.kbtnButtonTwo.Click += new System.EventHandler(this.kbtnButtonTwo_Click);
            // 
            // kbtnButtonFour
            // 
            this.kbtnButtonFour.Location = new System.Drawing.Point(300, 234);
            this.kbtnButtonFour.Name = "kbtnButtonFour";
            this.kbtnButtonFour.Size = new System.Drawing.Size(90, 25);
            this.kbtnButtonFour.TabIndex = 6;
            this.kbtnButtonFour.Values.Text = "N&o to All";
            this.kbtnButtonFour.Click += new System.EventHandler(this.kbtnButtonFour_Click);
            // 
            // kbtnButtonThree
            // 
            this.kbtnButtonThree.Location = new System.Drawing.Point(204, 234);
            this.kbtnButtonThree.Name = "kbtnButtonThree";
            this.kbtnButtonThree.Size = new System.Drawing.Size(90, 25);
            this.kbtnButtonThree.TabIndex = 5;
            this.kbtnButtonThree.Values.Text = "&No";
            this.kbtnButtonThree.Click += new System.EventHandler(this.kbtnButtonThree_Click);
            // 
            // kbtnButtonFive
            // 
            this.kbtnButtonFive.Location = new System.Drawing.Point(396, 234);
            this.kbtnButtonFive.Name = "kbtnButtonFive";
            this.kbtnButtonFive.Size = new System.Drawing.Size(90, 25);
            this.kbtnButtonFive.TabIndex = 4;
            this.kbtnButtonFive.Values.Text = "&Cancel";
            this.kbtnButtonFive.Click += new System.EventHandler(this.kbtnButtonFive_Click);
            // 
            // kbtnButtonOne
            // 
            this.kbtnButtonOne.Location = new System.Drawing.Point(12, 234);
            this.kbtnButtonOne.Name = "kbtnButtonOne";
            this.kbtnButtonOne.Size = new System.Drawing.Size(90, 25);
            this.kbtnButtonOne.TabIndex = 3;
            this.kbtnButtonOne.Values.Text = "&Yes";
            this.kbtnButtonOne.Click += new System.EventHandler(this.kbtnButtonOne_Click);
            // 
            // klblBody
            // 
            this.klblBody.AutoSize = false;
            this.klblBody.Location = new System.Drawing.Point(82, 13);
            this.klblBody.Name = "klblBody";
            this.klblBody.Size = new System.Drawing.Size(404, 211);
            this.klblBody.TabIndex = 2;
            this.klblBody.Values.Text = null;
            // 
            // pbxIcon
            // 
            this.pbxIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbxIcon.Location = new System.Drawing.Point(12, 12);
            this.pbxIcon.Name = "pbxIcon";
            this.pbxIcon.Size = new System.Drawing.Size(64, 64);
            this.pbxIcon.TabIndex = 1;
            this.pbxIcon.TabStop = false;
            // 
            // KryptonMemoryBox
            // 
            this.ClientSize = new System.Drawing.Size(501, 271);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonMemoryBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.KryptonMemoryBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
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

            klblBody.Text = message;

            switch (icon)
            {
                case KryptonMemoryBoxIcon.CUSTOM:
                    pbxIcon.Image = new Bitmap(iconPath);
                    break;
                case KryptonMemoryBoxIcon.OK:
                    pbxIcon.Image = InputBoxResources.Input_Box_Ok_64_x_64;
                    break;
                case KryptonMemoryBoxIcon.ERROR:
                    pbxIcon.Image = InputBoxResources.Input_Box_Critical_64_x_64;
                    break;
                case KryptonMemoryBoxIcon.EXCLAMATION:
                    pbxIcon.Image = InputBoxResources.Input_Box_Warning_64_x_58;
                    break;
                case KryptonMemoryBoxIcon.INFORMATION:
                    pbxIcon.Image = InputBoxResources.Input_Box_Information_64_x_64;
                    break;
                case KryptonMemoryBoxIcon.QUESTION:
                    pbxIcon.Image = InputBoxResources.Input_Box_Question_64_x_64;
                    break;
                case KryptonMemoryBoxIcon.NONE:
                    pbxIcon.Image = null;

                    UpdateUI();
                    break;
                case KryptonMemoryBoxIcon.STOP:
                    pbxIcon.Image = InputBoxResources.Input_Box_Stop_64_x_64;
                    break;
                case KryptonMemoryBoxIcon.HAND:
                    pbxIcon.Image = InputBoxResources.Input_Box_Hand_64_x_64;
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

                klblBody.Size = new Size(404, 211);
            }
            else
            {
                pbxIcon.Visible = false;

                klblBody.Size = new Size(474, 211);
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
        #endregion

        private void kbtnButtonOne_Click(object sender, EventArgs e)
        {
            _defaultDialogResult = KryptonMemoryBoxDialogResult.YES;

            _lastResult = KryptonMemoryBoxDialogResult.YES;

            DialogResult = DialogResult.Yes;
        }

        private void kbtnButtonTwo_Click(object sender, EventArgs e)
        {
            _defaultDialogResult = KryptonMemoryBoxDialogResult.YESTOALL;

            _lastResult = KryptonMemoryBoxDialogResult.YESTOALL;

            DialogResult = DialogResult.Yes;
        }

        private void kbtnButtonThree_Click(object sender, EventArgs e)
        {
            _defaultDialogResult = KryptonMemoryBoxDialogResult.NO;

            _lastResult = KryptonMemoryBoxDialogResult.NO;

            DialogResult = DialogResult.No;
        }

        private void kbtnButtonFour_Click(object sender, EventArgs e)
        {
            _defaultDialogResult = KryptonMemoryBoxDialogResult.NOTOALL;

            _lastResult = KryptonMemoryBoxDialogResult.NOTOALL;

            DialogResult = DialogResult.No;
        }

        private void kbtnButtonFive_Click(object sender, EventArgs e)
        {
            _defaultDialogResult = KryptonMemoryBoxDialogResult.CANCEL;

            _lastResult = KryptonMemoryBoxDialogResult.CANCEL;

            DialogResult = DialogResult.Cancel;
        }

        private void KryptonMemoryBox_Load(object sender, EventArgs e)
        {

        }
    }
}