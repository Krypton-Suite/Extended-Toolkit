#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Controls;

/// <summary>A <see cref="KryptonTextBox"/> that uses the <see cref="SecureString"/> API to encrypt the input text more securely than native methods. Ideql for sensitive data.</summary>
[ToolboxBitmap(typeof(KryptonTextBox)), Description(@"A KryptonTextBox that uses the SecureString API to encrypt the input text more securely than native methods. Ideql for sensitive data.")]
public class KryptonSecureTextBox : KryptonTextBox
{
    #region Instance Fields

    private SecureString _secureString = new();

    #endregion

    #region Public

    public SecureString SecuredText { get => _secureString; set => _secureString = value; }

    public char[] CharacterData
    {
        get
        {
            char[] bytes = new char[_secureString.Length];

            IntPtr pszText = IntPtr.Zero;

            try
            {
                pszText = Marshal.SecureStringToGlobalAllocUnicode(_secureString);

                bytes = new char[_secureString.Length];

                Marshal.Copy(pszText, bytes, 0, _secureString.Length);
            }
            finally
            {
                if (pszText != IntPtr.Zero)
                {
                    Marshal.ZeroFreeGlobalAllocUnicode(pszText);
                }
            }

            return bytes;
        }
    }

    #endregion

    #region Identity

    /// <summary>Initializes a new instance of the <see cref="KryptonSecureTextBox" /> class.</summary>
    public KryptonSecureTextBox() : base()
    {
        UseSystemPasswordChar = true;
    }

    #endregion

    #region Overrides
    /// <summary>
    /// 
    /// </summary>
    /// <param name="m"></param>
    protected override void WndProc(ref Message m)
    {
        /* Deny cut, copy and paste */
        if (m.Msg == 0x0301) /* WM_COPY */
        {
            return;
        }

        if (m.Msg == 0x0300) /* WM_CUT */
        {
            return;
        }

        if (m.Msg == 0x0302) /* WM_PASTE */
        {
            return;
        }

        /* Remove the context menu (after all we can't cut/copy/paste, so it's not much good to us anyway!) */
        if (m.Msg == 0x007B) /* WM_CONTEXTMENU */
        {
            return;
        }

        base.WndProc(ref m);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="e"></param>
    protected override void OnKeyPress(KeyPressEventArgs e)
    {
        try
        {
            int startPos = SelectionStart;

            /* Handle backspace */
            if ((Keys)e.KeyChar == Keys.Back)
            {
                if (SelectionLength == 0 && startPos > 0 && startPos <= _secureString.Length)
                {
                    startPos--;
                    _secureString.RemoveAt(startPos);

                    Text = new string('*', _secureString.Length);
                    SelectionStart = startPos;
                }
                else if (SelectionLength > 0)
                {
                    for (int i = 0; i < SelectionLength; i++)
                    {
                        _secureString.RemoveAt(SelectionStart);
                    }

                    Text = new string('*', _secureString.Length);
                    SelectionStart = startPos;
                }

                e.Handled = true;
                return;
            }

            /* Give us some input, baby! */
            if (!char.IsControl(e.KeyChar) && !char.IsHighSurrogate(e.KeyChar) && !char.IsLowSurrogate(e.KeyChar))
            {
                if (IsInputChar(e.KeyChar))
                {
                    if (SelectionLength > 0)
                    {
                        for (int i = 0; i < SelectionLength; i++)
                        {
                            _secureString.RemoveAt(SelectionStart);
                        }
                    }

                    if (startPos == _secureString.Length)
                    {
                        _secureString.AppendChar(e.KeyChar);
                    }
                    else
                    {
                        _secureString.InsertAt(startPos, e.KeyChar);
                    }

                    Text = new string('*', _secureString.Length);
                    startPos++;

                    SelectionStart = startPos;
                    e.Handled = true;

                    return;
                }
            }
        }
        catch (ArgumentOutOfRangeException ex)
        {
            _HandleCritialFailure(ex);
        }

        base.OnKeyPress(e);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="keyData"></param>
    /// <returns></returns>
    protected override bool IsInputKey(Keys keyData)
    {
        try
        {
            /* Handle the delete key */
            bool allowedToDelete = (keyData & Keys.Delete) == Keys.Delete;

            if (allowedToDelete)
            {
                if (SelectionLength == _secureString.Length)
                {
                    _secureString.Clear();
                }
                else if (SelectionLength > 0)
                {
                    for (int i = 0; i < SelectionLength; i++)
                    {
                        _secureString.RemoveAt(SelectionStart);
                    }
                }
                else
                {
                    if ((keyData & Keys.Delete) == Keys.Delete && SelectionStart < Text.Length)
                    {
                        _secureString.RemoveAt(SelectionStart);
                    }
                }

                return true;
            }
        }
        catch (ArgumentOutOfRangeException ex)
        {
            _HandleCritialFailure(ex);
        }

        return base.IsInputKey(keyData);
    }
    #endregion

    #region Helpers
    /// <summary>
    /// 
    /// </summary>
    /// <param name="e"></param>
    private void _HandleCritialFailure(Exception e)
    {
        _secureString.Clear();
        Text = string.Empty;

        /* todo: resource strings */
        MessageBox.Show($"Secure password error: Reached critical endpoint: {e.Message}");
    }
    #endregion
}