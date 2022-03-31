#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */

//--------------------------------------------------------------------------------
// Copyright (C) 2013-2021 JDH Software - <support@jdhsoftware.com>
//
// This program is provided to you under the terms of the Microsoft Public
// License (Ms-PL) as published at https://github.com/Cocotteseb/Krypton-OutlookGrid/blob/master/LICENSE.md
//
// Visit https://www.jdhsoftware.com and follow @jdhsoftware on Twitter
//
//--------------------------------------------------------------------------------
#endregion

namespace Krypton.Toolkit.Suite.Extended.Outlook.Grid
{
    /// <summary>
    /// Handle localization (singleton)
    /// </summary>
    public class LanguageManager
    {        
        private static LanguageManager _mInstance = null;

        private static readonly object _mylock = new object();
        private ResourceManager _rm;

        private CultureInfo _ci;
        //Used for blocking critical sections on updates
        private object _locker = new object();

        private LanguageManager()
        {
            _rm = new ResourceManager("Krypton.Toolkit.Suite.Extended.Outlook.Grid.Resources.Language.Strings.en-Neutral", Assembly.GetExecutingAssembly());
            _ci = Thread.CurrentThread.CurrentCulture; //CultureInfo.CurrentCulture;
        }

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
                if (_mInstance == null)
                {
                    lock (_mylock)
                    {
                        if (_mInstance == null)
                        {
                            _mInstance = new LanguageManager();
                        }
                    }
                }

                return _mInstance;
            }
        }

        /// <summary>
        /// Get localized string
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string GetString(string name) => _rm.GetString(name, _ci);
    }
}
