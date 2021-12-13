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
        // Variable locale pour stocker une référence vers l'instance
        private static LanguageManager mInstance = null;

        private static readonly object mylock = new object();
        private ResourceManager rm;

        private CultureInfo ci;
        //Used for blocking critical sections on updates
        private object locker = new object();

        // Le constructeur est Private
        private LanguageManager()
        {
            rm = new ResourceManager("Krypton.Toolkit.Suite.Extended.Outlook.Grid.Language.Strings.en-US", Assembly.GetExecutingAssembly());
            ci = Thread.CurrentThread.CurrentCulture; //CultureInfo.CurrentCulture;
        }

        /// <summary>
        /// Gets or sets the P locker.
        /// </summary>
        /// <value>The P locker.</value>
        public object PLocker
        {
            get { return this.locker; }
            set { this.locker = value; }
        }

        /// <summary>
        /// Gets the instance of the singleton.
        /// </summary>
        public static LanguageManager Instance
        {
            get
            {
                if (mInstance == null)
                {
                    lock (mylock)
                    {
                        if (mInstance == null)
                        {
                            mInstance = new LanguageManager();
                        }
                    }
                }

                return mInstance;
            }
        }

        /// <summary>
        /// Get localized string
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string GetString(string name)
        {
            return rm.GetString(name, ci);
        }
    }
}
