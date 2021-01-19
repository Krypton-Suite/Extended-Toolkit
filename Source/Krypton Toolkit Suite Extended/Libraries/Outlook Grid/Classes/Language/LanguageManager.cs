#region MS-PL License
/*
* Copyright (C) 2013 - 2018 JDH Software - <support@jdhsoftware.com>
*
* This program is provided to you under the terms of the Microsoft Public
* License (Ms-PL) as published at https://kryptonoutlookgrid.codeplex.com/license
*
* Visit http://www.jdhsoftware.com and follow @jdhsoftware on Twitter
*/
#endregion

using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Threading;

namespace Krypton.Toolkit.Suite.Extended.Outlook.Grid
{
    public class LanguageManager
    {
        #region Variables
        private static LanguageManager _manager = null;

        private static readonly object _myLock = new object();

        private ResourceManager _resourceManager;

        private CultureInfo _cultureInfo;

        private object _locker = new object();
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the P locker.
        /// </summary>
        /// <value>The P locker.</value>
        public object PLocker { get => _locker; set => _locker = value; }

        /// <summary>
        /// Gets the instance of the singleton.
        /// </summary>
        public static LanguageManager Instance
        {
            get
            {
                if (_manager == null)
                {
                    lock (_myLock)
                    {
                        if (_manager == null)
                        {
                            _manager = new LanguageManager();
                        }
                    }
                }

                return _manager;
            }
        }
        #endregion

        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="LanguageManager" /> class.</summary>
        public LanguageManager()
        {
            _resourceManager = new ResourceManager("Krypton.Toolkit.Suite.Extended.Outlook.Grid.Utilities.Language.Strings", Assembly.GetExecutingAssembly());

            _cultureInfo = Thread.CurrentThread.CurrentCulture;
        }
        #endregion

        #region Methods
        /// <summary>Gets the localised string.</summary>
        /// <param name="name">The name.</param>
        /// <returns>The localised string.</returns>
        public string GetLocalisedString(string name) => _resourceManager.GetString(name, _cultureInfo);
        #endregion
    }
}