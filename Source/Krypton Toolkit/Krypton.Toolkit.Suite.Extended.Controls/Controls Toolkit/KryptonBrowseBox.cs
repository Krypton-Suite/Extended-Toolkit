#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Controls
{
    public class KryptonBrowseBox : KryptonTextBox
    {
        #region Instance Fields

        private readonly ButtonSpecAny _bsaBrowse;

        private readonly CommonFileDialogFilter _filter;

        private readonly KryptonCommand _kcBrowse;

        #endregion

        #region Identity

        public KryptonBrowseBox()
        {
            _bsaBrowse = new ButtonSpecAny();

            _kcBrowse = new KryptonCommand();

            _bsaBrowse.Text = "...";

            _bsaBrowse.KryptonCommand = _kcBrowse;

            _kcBrowse.Text = "...";
            
            _kcBrowse.Execute += Browse_Execute;

            ButtonSpecs.AddRange(new ButtonSpecAny[] { _bsaBrowse });
        }

        private void Browse_Execute(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                Text = Path.GetFullPath(dialog.FileName);
            }
        }

        #endregion
    }
}
