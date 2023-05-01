﻿#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Buttons
{
    /// <summary>
    /// A KryptonCommandLink button.
    /// Boilerplate code from (https://blogs.msdn.microsoft.com/knom/2007/03/12/vista-command-link-control-with-c-windows-forms/)
    /// </summary>
    /// <remarks>
    /// If used on Windows Vista or higher, the button will be a CommandLink: Basically the same functionality as a Button but looks different.
    /// </remarks>
    [DesignerCategory("Code"), DisplayName("Krypton Command Link"),
     Description("A Krypton Command Link Button."), ToolboxItem(true),
     ToolboxBitmap(typeof(KryptonButton))]
    public class KryptonCommandLinkVersion2 : KryptonButton
    {
        #region Variables
        private bool _useAsUACElevatedButton;
        private Image _originalImage;
        private Size _uacShieldSize;
        private string _processToElevate;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the shield icon visibility of the command link.
        /// </summary>
        [Category("Command Link"), Description("Gets or sets the shield icon visibility of the command link."), DefaultValue(false)]
        public bool UseAsUACElevatedButton
        {
            get => _useAsUACElevatedButton;

            set
            {
                _useAsUACElevatedButton = value;

                // Note: Store the original icon

                Values.Image = SystemIcons.Shield.ToBitmap();
            }
        }

        public Image OriginalImage { get => _originalImage; private set => _originalImage = value; }

        /// <summary>Gets or sets the size of the UAC shield.</summary>
        /// <value>The size of the UAC shield.</value>
        [Category("Command Link"), Description("Gets or sets the shield icon size of the command link."), DefaultValue(typeof(Size), "15, 15")]
        public Size UACShieldSize
        {
            get => _uacShieldSize;

            set
            {
                _uacShieldSize = value;

                if (_useAsUACElevatedButton)
                {
                    Values.Image = UACUtilityMethods.ResizeImage(SystemIcons.Shield.ToBitmap(), _uacShieldSize.Width, _uacShieldSize.Height);
                }
            }
        }

        /// <summary>
        /// Gets or sets the note text of the command link.
        /// </summary>
        [Category("Command Link"), Description("Gets or sets the note text of the command link."), DefaultValue("")]
        public string NoteText
        {
            get => GetNoteText();

            set => SetNoteText(value);
        }

        /// <summary>Gets or sets the process path to elevate.</summary>
        /// <value>The process to elevate.</value>
        [Category("Command Link"), Description("Gets or sets the process path to elevate."), DefaultValue("")]
        public string ProcessToElevate { get => _processToElevate; set => _processToElevate = value; }
        #endregion

        #region Custom Events
        /// <summary></summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ExecuteProcessAsAdministratorEventArgs"/> instance containing the event data.</param>
        public delegate void ExecuteProcessAsAdministratorEventHandler(object sender, ExecuteProcessAsAdministratorEventArgs e);

        /// <summary>The execute process as administrator</summary>
        public event ExecuteProcessAsAdministratorEventHandler ExecuteProcessAsAdministrator;

        /// <summary>Executes the process as an administrator.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ExecuteProcessAsAdministratorEventArgs" /> instance containing the event data.</param>
        protected virtual void OnExecuteProcessAsAdministrator(object sender, ExecuteProcessAsAdministratorEventArgs e) => ExecuteProcessAsAdministrator?.Invoke(sender, e);
        #endregion

        #region WIN32 Calls
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        static extern int SendMessage(HandleRef hWnd, UInt32 msg, ref int wParam, StringBuilder lParam);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        static extern int SendMessage(HandleRef hWnd, UInt32 msg, IntPtr wParam, string lParam);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        static extern int SendMessage(HandleRef hWnd, UInt32 msg, IntPtr wParam, bool lParam);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        static extern int SendMessage(HandleRef hWnd, UInt32 msg, IntPtr wParam, IntPtr lParam);
        #endregion

        #region Constants
        const int BS_COMMANDLINK = 0x0000000E, BCM_SETNOTE = 0x00001609, BCM_GETNOTE = 0x0000160A, BCM_GETNOTELENGTH = 0x0000160B, BCM_SETSHIELD = 0x0000160C;
        #endregion

        #region Constructor
        /// <summary>
        /// Initialises a new instance of the <see cref="KryptonCommandLinkVersion2"/> class.
        /// </summary>
        public KryptonCommandLinkVersion2()
        {

        }
        #endregion

        #region Overrides
        protected override Size DefaultSize => new(160, 60);

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;

                createParams.Style |= BS_COMMANDLINK;

                return createParams;
            }
        }

        protected override void OnClick(EventArgs e)
        {
            if (_useAsUACElevatedButton)
            {
                if (_processToElevate != null)
                {
                    try
                    {
                        ExecuteProcessAsAdministratorEventArgs executeProcessAsAdministrator = new(_processToElevate);

                        executeProcessAsAdministrator.ElevateProcessWithAdministrativeRights(_processToElevate);
                    }
                    catch (Exception exc)
                    {
                        ExceptionCapture.CaptureException(exc);
                    }
                }
            }

            base.OnClick(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
        #endregion

        #region Setter and Getter Methods
        /// <summary>
        /// Sets the NoteText to the value of value.
        /// </summary>
        /// <param name="value">The desired value of NoteText.</param>
        private void SetNoteText(string value)
        {
            SendMessage(new(this, this.Handle), BCM_SETNOTE, IntPtr.Zero, value);
        }

        /// <summary>
        /// Returns the value of the NoteText.
        /// </summary>
        /// <returns>The value of the NoteText.</returns>
        private string GetNoteText()
        {
            int _length = SendMessage(new(this, this.Handle), BCM_GETNOTELENGTH, IntPtr.Zero, IntPtr.Zero) + 1;

            StringBuilder stringBuilder = new(_length);

            SendMessage(new(this, this.Handle), BCM_GETNOTE, ref _length, stringBuilder);

            return stringBuilder.ToString();
        }
        #endregion
    }
}