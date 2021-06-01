#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

global using System;
global using System.Collections.Generic;
global using System.Collections.ObjectModel;
global using System.ComponentModel;
global using System.ComponentModel.Design;
global using System.Diagnostics;
global using System.Diagnostics.CodeAnalysis;
global using System.Drawing;
global using System.Drawing.Design;
global using System.Drawing.Drawing2D;
global using System.Drawing.Imaging;
global using System.Globalization;
global using System.Reflection;
global using System.Runtime.InteropServices;
global using System.Runtime.InteropServices.ComTypes;
global using System.Security;
global using System.Security.Permissions;
global using System.Text;
global using System.Windows.Forms;
global using System.Windows.Forms.Design;
global using System.Windows.Forms.Design.Behavior;
global using System.Windows.Forms.VisualStyles;

global using Krypton.Toolkit.Suite.Extended.Global.Utilities;
global using Krypton.Toolkit.Suite.Extended.Wizard.Properties;

global using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

global using static Krypton.Toolkit.Suite.Extended.Wizard.NativeMethods;
