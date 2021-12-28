#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

global using System;
global using System.Collections.Generic;
global using System.ComponentModel;
global using System.Diagnostics;
global using System.Drawing;
global using System.Globalization;
global using System.IO;
global using System.Linq;
global using System.Net;
global using System.Net.Http;
global using System.Net.Security;
global using System.Reflection;
global using System.Runtime.Serialization;
#if NETCOREAPP3_1_OR_GREATER
global using System.Runtime.InteropServices;
#endif
global using System.Security.Cryptography;
global using System.Security.Cryptography.X509Certificates;
global using System.Text;
global using System.Text.RegularExpressions;
global using System.Threading;
global using System.Threading.Tasks;
global using System.Windows.Forms;
global using System.Xml;
global using System.Xml.Linq;

global using Microsoft.Win32;

global using Krypton.Toolkit.Suite.Extended.Software.Updater.NetSparkle.Resources;
global using Krypton.Toolkit.Suite.Extended.Software.Updater.Properties;