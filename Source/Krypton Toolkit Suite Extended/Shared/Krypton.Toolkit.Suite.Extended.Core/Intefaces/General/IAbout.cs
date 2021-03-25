﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public interface IAboutStripped
    {
        string ApplicationName { get; set; }

        Icon ApplicationIcon { get; set; }

        Bitmap ApplicationIconImage { get; set; }

        string AuthourName { get; set; }

        Version ApplicationVersion { get; set; }

        string InstallLocation { get; set; }
    }
}