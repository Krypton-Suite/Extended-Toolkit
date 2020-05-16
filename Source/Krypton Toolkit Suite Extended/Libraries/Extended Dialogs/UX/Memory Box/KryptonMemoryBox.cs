using Krypton.Toolkit.Extended.Dialogs.Resources;
using System;
using System.Drawing;

namespace Krypton.Toolkit.Extended.Dialogs
{
    public class KryptonMemoryBox : KryptonForm
    {
        #region Designer Code
        private KryptonPanel kryptonPanel1;
        private KryptonLabel klblBody;
        private KryptonButton kbtnYesToAll;
        private KryptonButton kbtnNoToAll;
        private KryptonButton kbtnNo;
        private KryptonButton kbtnCancel;
        private KryptonButton kbtnYes;
        private System.Windows.Forms.PictureBox pbxIcon;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnYesToAll = new Krypton.Toolkit.KryptonButton();
            this.kbtnNoToAll = new Krypton.Toolkit.KryptonButton();
            this.kbtnNo = new Krypton.Toolkit.KryptonButton();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.kbtnYes = new Krypton.Toolkit.KryptonButton();
            this.klblBody = new Krypton.Toolkit.KryptonLabel();
            this.pbxIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnYesToAll);
            this.kryptonPanel1.Controls.Add(this.kbtnNoToAll);
            this.kryptonPanel1.Controls.Add(this.kbtnNo);
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Controls.Add(this.kbtnYes);
            this.kryptonPanel1.Controls.Add(this.klblBody);
            this.kryptonPanel1.Controls.Add(this.pbxIcon);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(501, 271);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnYesToAll
            // 
            this.kbtnYesToAll.Location = new System.Drawing.Point(108, 234);
            this.kbtnYesToAll.Name = "kbtnYesToAll";
            this.kbtnYesToAll.Size = new System.Drawing.Size(90, 25);
            this.kbtnYesToAll.TabIndex = 7;
            this.kbtnYesToAll.Values.Text = "Ye&s to All";
            // 
            // kbtnNoToAll
            // 
            this.kbtnNoToAll.Location = new System.Drawing.Point(300, 234);
            this.kbtnNoToAll.Name = "kbtnNoToAll";
            this.kbtnNoToAll.Size = new System.Drawing.Size(90, 25);
            this.kbtnNoToAll.TabIndex = 6;
            this.kbtnNoToAll.Values.Text = "N&o to All";
            // 
            // kbtnNo
            // 
            this.kbtnNo.Location = new System.Drawing.Point(204, 234);
            this.kbtnNo.Name = "kbtnNo";
            this.kbtnNo.Size = new System.Drawing.Size(90, 25);
            this.kbtnNo.TabIndex = 5;
            this.kbtnNo.Values.Text = "&No";
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.Location = new System.Drawing.Point(396, 234);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.TabIndex = 4;
            this.kbtnCancel.Values.Text = "&Cancel";
            // 
            // kbtnYes
            // 
            this.kbtnYes.Location = new System.Drawing.Point(12, 234);
            this.kbtnYes.Name = "kbtnYes";
            this.kbtnYes.Size = new System.Drawing.Size(90, 25);
            this.kbtnYes.TabIndex = 3;
            this.kbtnYes.Values.Text = "&Yes";
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
            kbtnYes.Text = yesText;

            kbtnYesToAll.Text = yesToAllText;

            kbtnNo.Text = noText;

            kbtnNoToAll.Text = noToAllText;

            kbtnCancel.Text = cancelText;
        }

        /// <summary>Sets the default dialog result.</summary>
        /// <param name="dialogResult">The dialog result.</param>
        private void SetDefaultDialogResult(KryptonMemoryBoxDialogResult dialogResult)
        {
            switch (dialogResult)
            {
                case KryptonMemoryBoxDialogResult.YES:
                    AcceptButton = kbtnYes;
                    break;
                case KryptonMemoryBoxDialogResult.YESTOALL:
                    AcceptButton = kbtnYesToAll;
                    break;
                case KryptonMemoryBoxDialogResult.NO:
                    AcceptButton = kbtnNo;
                    break;
                case KryptonMemoryBoxDialogResult.NOTOALL:
                    AcceptButton = kbtnNoToAll;
                    break;
                case KryptonMemoryBoxDialogResult.CANCEL:
                    AcceptButton = kbtnCancel;
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
        /// <returns></returns>
        public KryptonMemoryBoxDialogResult ShowKryptonMemoryBoxDialogResult(string title, string message, KryptonMemoryBoxIcon icon = KryptonMemoryBoxIcon.NONE, string iconPath = null)
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

            return ShowKryptonMemoryBoxDialogResult();
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
        #endregion

        private void KryptonMemoryBox_Load(object sender, EventArgs e)
        {

        }
    }
}