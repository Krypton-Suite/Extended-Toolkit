using System.Drawing;

namespace Krypton.Toolkit.Extended.Dialogs
{
    public class KryptonTypefaceDialog : KryptonForm
    {
        #region Drsign Code
        private Suite.Extended.Standard.Controls.KryptonPanelExtended kryptonPanelExtended1;
        private KryptonOKDialogButton kryptonOKDialogButton1;
        private System.Windows.Forms.Panel panel1;
        private Suite.Extended.Standard.Controls.KryptonPanelExtended kryptonPanelExtended2;
        private Base.KryptonTypefaceExample kryptonTypefaceExample1;
        private KryptonCancelDialogButton kryptonCancelDialogButton1;

        private void InitializeComponent()
        {
            this.kryptonPanelExtended1 = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonPanelExtended();
            this.kryptonOKDialogButton1 = new Krypton.Toolkit.Extended.Dialogs.KryptonOKDialogButton();
            this.kryptonCancelDialogButton1 = new Krypton.Toolkit.Extended.Dialogs.KryptonCancelDialogButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanelExtended2 = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonPanelExtended();
            this.kryptonTypefaceExample1 = new Krypton.Toolkit.Extended.Base.KryptonTypefaceExample();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanelExtended1)).BeginInit();
            this.kryptonPanelExtended1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanelExtended2)).BeginInit();
            this.kryptonPanelExtended2.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanelExtended1
            // 
            this.kryptonPanelExtended1.Controls.Add(this.kryptonOKDialogButton1);
            this.kryptonPanelExtended1.Controls.Add(this.kryptonCancelDialogButton1);
            this.kryptonPanelExtended1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanelExtended1.Image = null;
            this.kryptonPanelExtended1.Location = new System.Drawing.Point(0, 373);
            this.kryptonPanelExtended1.Name = "kryptonPanelExtended1";
            this.kryptonPanelExtended1.Size = new System.Drawing.Size(551, 46);
            this.kryptonPanelExtended1.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonPanelExtended1.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonPanelExtended1.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonPanelExtended1.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonPanelExtended1.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonPanelExtended1.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonPanelExtended1.TabIndex = 0;
            // 
            // kryptonOKDialogButton1
            // 
            this.kryptonOKDialogButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kryptonOKDialogButton1.Location = new System.Drawing.Point(353, 9);
            this.kryptonOKDialogButton1.Name = "kryptonOKDialogButton1";
            this.kryptonOKDialogButton1.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.Size = new System.Drawing.Size(90, 25);
            this.kryptonOKDialogButton1.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.TabIndex = 1;
            this.kryptonOKDialogButton1.Values.Text = "&OK";
            // 
            // kryptonCancelDialogButton1
            // 
            this.kryptonCancelDialogButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kryptonCancelDialogButton1.Location = new System.Drawing.Point(449, 9);
            this.kryptonCancelDialogButton1.Name = "kryptonCancelDialogButton1";
            this.kryptonCancelDialogButton1.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.Size = new System.Drawing.Size(90, 25);
            this.kryptonCancelDialogButton1.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.TabIndex = 0;
            this.kryptonCancelDialogButton1.Values.Text = "C&ancel";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 370);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(551, 3);
            this.panel1.TabIndex = 1;
            // 
            // kryptonPanelExtended2
            // 
            this.kryptonPanelExtended2.Controls.Add(this.kryptonTypefaceExample1);
            this.kryptonPanelExtended2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanelExtended2.Image = null;
            this.kryptonPanelExtended2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanelExtended2.Name = "kryptonPanelExtended2";
            this.kryptonPanelExtended2.Size = new System.Drawing.Size(551, 370);
            this.kryptonPanelExtended2.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonPanelExtended2.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonPanelExtended2.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonPanelExtended2.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonPanelExtended2.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonPanelExtended2.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonPanelExtended2.TabIndex = 2;
            // 
            // kryptonTypefaceExample1
            // 
            this.kryptonTypefaceExample1.BackColor = System.Drawing.Color.Transparent;
            this.kryptonTypefaceExample1.HeaderText = "Sample Typeface";
            this.kryptonTypefaceExample1.Location = new System.Drawing.Point(280, 196);
            this.kryptonTypefaceExample1.Name = "kryptonTypefaceExample1";
            this.kryptonTypefaceExample1.SampleText = "AaBbCc123#+*-";
            this.kryptonTypefaceExample1.Size = new System.Drawing.Size(259, 168);
            this.kryptonTypefaceExample1.TabIndex = 3;
            // 
            // KryptonTypefaceDialog
            // 
            this.AcceptButton = this.kryptonOKDialogButton1;
            this.CancelButton = this.kryptonCancelDialogButton1;
            this.ClientSize = new System.Drawing.Size(551, 419);
            this.Controls.Add(this.kryptonPanelExtended2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanelExtended1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonTypefaceDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Typeface";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanelExtended1)).EndInit();
            this.kryptonPanelExtended1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanelExtended2)).EndInit();
            this.kryptonPanelExtended2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region Events
        public delegate void TypefaceChangedEventHandler(object sender, TypefaceChangedEventArgs e);

        public event TypefaceChangedEventHandler TypefaceChanged;

        protected virtual void OnTypefaceChanged(object sender, TypefaceChangedEventArgs e) => TypefaceChanged?.Invoke(sender, e);
        #endregion

        #region Variable
        private Font _typeface;
        #endregion

        #region Property
        public Font Typeface
        {
            get => _typeface;

            set
            {
                _typeface = value;

                TypefaceChangedEventArgs e = new TypefaceChangedEventArgs(value);

                OnTypefaceChanged(this, e);
            }
        }
        #endregion

        #region Constructors
        public KryptonTypefaceDialog()
        {
            InitializeComponent();
        }
        #endregion
    }
}