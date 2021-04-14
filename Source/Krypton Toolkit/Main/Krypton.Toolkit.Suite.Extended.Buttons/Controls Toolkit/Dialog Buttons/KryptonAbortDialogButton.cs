using Krypton.Toolkit.Suite.Extended.Language.Model;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Buttons
{
    [Designer(typeof(KryptonAbortDialogButtonDesigner)), Description(""), ToolboxBitmap(typeof(KryptonButton))]
    public class KryptonAbortDialogButton : KryptonButton
    {
        #region Variables
        private ButtonLanguageController _languageController;

        private SelectedLanguage _selectedLanguage;

        private KryptonForm _parent;
        #endregion

        #region Properties
        public SelectedLanguage SelectedLanguage { get => _selectedLanguage; set { _selectedLanguage = value; Invalidate(); } }

        public KryptonForm ParentWindow { get => _parent; set { _parent = value; Invalidate(); } }
        #endregion 

        #region Constructor
        public KryptonAbortDialogButton()
        {
            DialogResult = DialogResult.Abort;

            ParentChanged += KryptonAbortDialogButton_ParentChanged;

            TextChanged += KryptonAbortDialogButton_TextChanged;
        }
        #endregion

        #region Methods
        private void UpdateButtonText(SelectedLanguage language)
        {
            try
            {
                ButtonLanguageController.AdaptButtonText(language, DialogButtonType.ABORT, this);
            }
            catch (Exception e)
            {

                throw;
            }
        }
        #endregion

        #region Event Handlers
        private void KryptonAbortDialogButton_TextChanged(object sender, EventArgs e)
        {

        }

        private void KryptonAbortDialogButton_ParentChanged(object sender, EventArgs e)
        {
            Control parent = Parent;

            while (!(Parent is KryptonForm) && !(parent == null))
            {
                parent = parent.Parent;
            }

            if (parent is KryptonForm)
            {
                KryptonForm form = (KryptonForm)parent;

                form.CancelButton = this;
            }
        }
        #endregion

        #region Overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            if (ParentWindow != null)
            {
                ParentWindow.CancelButton = this;
            }

            base.OnPaint(e);
        }
        #endregion

        #region Deconstructor
        ~KryptonAbortDialogButton()
        {
            GC.SuppressFinalize(this);

            ParentChanged -= KryptonAbortDialogButton_ParentChanged;
        }
        #endregion
    }
}