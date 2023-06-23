#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2023 - 2023 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    [Category(@"code")]
    [Description(@"")]
    [ToolboxItem(true)]
    public class AutoUpdaterLanguageManager : Component
    {
        #region Public

        public AutoUpdaterStrings AutoUpdaterStrings => UpdaterStrings;

        private bool ShouldSerializeAutoUpdaterStrings() => !UpdaterStrings.IsDefault;

        public void ResetAutoUpdaterStrings() => UpdaterStrings.Reset();

        public DownloadUpdateDialogStrings DownloadUpdateDialogStrings => UpdateDialogStrings;

        private bool ShouldSerializeDownloadUpdateDialogStrings() => !UpdateDialogStrings.IsDefault;

        public void ResetDownloadUpdateDialogStrings() => UpdateDialogStrings.Reset();

        public RemindLaterTimingStrings RemindLaterTimingStrings => TimingStrings;

        private bool ShouldSerializeRemindLaterTimingStrings() => !TimingStrings.IsDefault;

        public void ResetRemindLaterTimingStrings() => TimingStrings.Reset();

        public RemindLaterWindowStrings RemindLaterWindowStrings => LaterWindowStrings;

        private bool ShouldSerializeRemindLaterWindowStrings() => !LaterWindowStrings.IsDefault;

        public void ResetRemindLaterWindowStrings() => LaterWindowStrings.Reset();

        public UpdateWindowStrings UpdateWindowStrings => WindowStrings;

        private bool ShouldSerializeUpdateWindowStrings() => !WindowStrings.IsDefault;

        public void ResetUpdateWindowStrings() => WindowStrings.Reset();

        #endregion

        #region Static Strings

        public static AutoUpdaterStrings UpdaterStrings
        { get; } = new();

        public static DownloadUpdateDialogStrings UpdateDialogStrings { get; } = new();

        public static RemindLaterTimingStrings TimingStrings { get; } = new();

        public static RemindLaterWindowStrings LaterWindowStrings { get; } = new();

        public static UpdateWindowStrings WindowStrings { get; } = new();

        #endregion

        #region Identity

        public AutoUpdaterLanguageManager()
        {

        }

        #endregion

        #region Implementation

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsDefault => !(ShouldSerializeAutoUpdaterStrings());

        public void Reset()
        {
            ResetAutoUpdaterStrings();
        }

        #endregion
    }
}