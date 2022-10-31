#region MIT License
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

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    public class KryptonAboutBoxManager : Component
    {
        #region Variables
        private Assembly _assembly;

        private Application _application;

        private bool _showDescription, _showFrameworkVersion, _showSystemInformation;

        private Image _applicationIcon;

        private string _aboutText, _applicationText, _applicationDescription, _versionText, _copyrightText, _frameworkVersionText, _showSystemInformationText;
        #endregion

        #region Properties
        public Assembly Assembly { get => _assembly; set => _assembly = value; }

        public Application Application { get => _application; set => _application = value; }

        public bool ShowDescription { get => _showDescription; set => _showDescription = value; }

        public bool ShowFrameworkVersion { get => _showFrameworkVersion; set => _showFrameworkVersion = value; }

        public bool ShowSystemInformation { get => _showSystemInformation; set => _showSystemInformation = value; }

        public Image ApplicationIcon { get => _applicationIcon; set => _applicationIcon = value; }

        public string AboutText { get => _aboutText; set => _aboutText = value; }

        public string ApplicationText { get => _applicationText; set => _applicationText = value; }

        public string ApplicationDescription { get => _applicationDescription; set => _applicationDescription = value; }

        public string CopyrightText { get => _copyrightText; set => _copyrightText = value; }

        public string FrameworkVersionText { get => _frameworkVersionText; set => _frameworkVersionText = value; }

        public string ShowSystemInformationText { get => _showSystemInformationText; set => _showSystemInformationText = value; }

        public string VersionText { get => _versionText; set => _versionText = value; }
        #endregion

        #region Constructor
        public KryptonAboutBoxManager()
        {
            _assembly = Assembly.GetExecutingAssembly();

            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(_assembly.Location);

            _showDescription = true;

            _showFrameworkVersion = true;

            _showSystemInformation = false;

            _applicationIcon = Icon.ExtractAssociatedIcon(Application.ExecutablePath).ToBitmap();

            _applicationText = "Application";

            _applicationDescription = fvi.FileDescription;

            _aboutText = "About";

            _copyrightText = "Copyright (c)";

            _frameworkVersionText = "Framework Version";

            _showSystemInformationText = "&Show System Information";

            _versionText = "Version";
        }
        #endregion

        #region Methods
       public void DisplayAboutBox()
        {
            KryptonAboutDialog aboutDialog = new KryptonAboutDialog(_applicationIcon, _assembly, _showDescription, _showFrameworkVersion,
                                                                    _showSystemInformation, _applicationText, _aboutText, _copyrightText,
                                                                    _frameworkVersionText, _showSystemInformationText, _versionText);

            aboutDialog.ShowDialog();
        }
        #endregion
    }
}