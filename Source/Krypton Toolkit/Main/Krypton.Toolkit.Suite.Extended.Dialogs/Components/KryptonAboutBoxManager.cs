using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    public class KryptonAboutBoxManager : Component
    {
        #region Variables
        private Assembly _assembly;

        private bool _showDescription, _showFrameworkVersion, _showSystemInformation;

        private Image _applicationIcon;

        private string _aboutText, _applicationText, _versionText, _copyrightText, _frameworkVersionText, _showSystemInformationText;
        #endregion

        #region Properties
        public Assembly Assembly { get => _assembly; set => _assembly = value; }

        public bool ShowDescription { get => _showDescription; set => _showDescription = value; }

        public bool ShowFrameworkVersion { get => _showFrameworkVersion; set => _showFrameworkVersion = value; }

        public bool ShowSystemInformation { get => _showSystemInformation; set => _showSystemInformation = value; }

        public Image ApplicationIcon { get => _applicationIcon; set => _applicationIcon = value; }

        public string AboutText { get => _aboutText; set => _aboutText = value; }

        public string ApplicationText { get => _applicationText; set => _applicationText = value; }

        public string CopyrightText { get => _copyrightText; set => _copyrightText = value; }

        public string FrameworkVersionText { get => _frameworkVersionText; set => _frameworkVersionText = value; }

        public string ShowSystemInformationText { get => _showSystemInformationText; set => _showSystemInformationText = value; }

        public string VersionText { get => _versionText; set => _versionText = value; }
        #endregion

        #region Constructor
        public KryptonAboutBoxManager()
        {
            _assembly = null;

            _showDescription = true;

            _showFrameworkVersion = true;

            _showSystemInformation = false;

            _applicationIcon = null;

            _applicationText = "Application";

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