#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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

global using System;
global using System.CodeDom.Compiler;
global using System.Collections;
global using System.Collections.Generic;
global using System.Collections.ObjectModel;
global using System.ComponentModel;
global using System.Diagnostics;
global using System.Globalization;
global using System.IO;
global using System.Net;
global using System.Reflection;
global using System.Runtime.CompilerServices;
global using System.Runtime.InteropServices;
global using System.Runtime.InteropServices.ComTypes;
global using System.Runtime.Serialization;
global using System.Runtime.Versioning;
global using System.Runtime.Remoting;
global using System.Resources;
global using System.Security;
global using System.Security.Permissions;
global using System.Security.Policy;
global using System.Text;
global using System.Threading;
global using System.Xml;
global using System.Xml.XPath;

global using Krypton.Toolkit.Suite.Extended.Utilities.System.AudioFormat;
global using Krypton.Toolkit.Suite.Extended.Utilities.System.GrammarBuilding;
global using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;
global using Krypton.Toolkit.Suite.Extended.Utilities.System.ObjectTokens;
global using Krypton.Toolkit.Suite.Extended.Utilities.System.Recognition;
global using Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop;
global using Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsCompiler;
global using Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsGrammar;
global using Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsParser;
global using Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis;
global using Krypton.Toolkit.Suite.Extended.Utilities.System.TTSEngine;
global using Krypton.Toolkit.Suite.Extended.Utilities.SystemInternal.IO;
global using Krypton.Toolkit.Suite.Extended.Utilities.SystemInternal.Speech;

global using Microsoft.CSharp;
global using Microsoft.VisualBasic;
global using Microsoft.Win32;
