#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;
using Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsCompiler;
using Krypton.Toolkit.Suite.Extended.Utilities.SystemInternal.Speech;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsGrammar
{
    public static class SrgsGrammarCompiler
    {
        public static void Compile(string inputPath, Stream outputStream)
        {
            Helpers.ThrowIfEmptyOrNull(inputPath, "inputPath");
            Helpers.ThrowIfNull(outputStream, "outputStream");
            using (XmlTextReader xmlTextReader = new XmlTextReader(new Uri(inputPath, UriKind.RelativeOrAbsolute).ToString()))
            {
                SrgsCompiler.SrgsCompiler.CompileStream(new XmlReader[1]
                {
                    xmlTextReader
                }, null, outputStream, true, null, null, null);
            }
        }

        public static void Compile(SrgsDocument srgsGrammar, Stream outputStream)
        {
            Helpers.ThrowIfNull(srgsGrammar, "srgsGrammar");
            Helpers.ThrowIfNull(outputStream, "outputStream");
            SrgsCompiler.SrgsCompiler.CompileStream(srgsGrammar, null, outputStream, true, null, null);
        }

        public static void Compile(XmlReader reader, Stream outputStream)
        {
            Helpers.ThrowIfNull(reader, "reader");
            Helpers.ThrowIfNull(outputStream, "outputStream");
            SrgsCompiler.SrgsCompiler.CompileStream(new XmlReader[1]
            {
                reader
            }, null, outputStream, true, null, null, null);
        }

        public static void CompileClassLibrary(string[] inputPaths, string outputPath, string[] referencedAssemblies, string keyFile)
        {
            Helpers.ThrowIfNull(inputPaths, "inputPaths");
            Helpers.ThrowIfEmptyOrNull(outputPath, "outputPath");
            XmlTextReader[] array = new XmlTextReader[inputPaths.Length];
            try
            {
                for (int i = 0; i < inputPaths.Length; i++)
                {
                    if (inputPaths[i] == null)
                    {
                        throw new ArgumentException(SR.Get(SRID.ArrayOfNullIllegal), "inputPaths");
                    }
                    array[i] = new XmlTextReader(new Uri(inputPaths[i], UriKind.RelativeOrAbsolute).ToString());
                }
                SrgsCompiler.SrgsCompiler.CompileStream(array, outputPath, null, false, null, referencedAssemblies, keyFile);
            }
            finally
            {
                for (int j = 0; j < array.Length; j++)
                {
                    ((IDisposable)array[j])?.Dispose();
                }
            }
        }

        public static void CompileClassLibrary(SrgsDocument srgsGrammar, string outputPath, string[] referencedAssemblies, string keyFile)
        {
            Helpers.ThrowIfNull(srgsGrammar, "srgsGrammar");
            Helpers.ThrowIfEmptyOrNull(outputPath, "outputPath");
            SrgsCompiler.SrgsCompiler.CompileStream(srgsGrammar, outputPath, null, false, referencedAssemblies, keyFile);
        }

        public static void CompileClassLibrary(XmlReader reader, string outputPath, string[] referencedAssemblies, string keyFile)
        {
            Helpers.ThrowIfNull(reader, "reader");
            Helpers.ThrowIfEmptyOrNull(outputPath, "outputPath");
            SrgsCompiler.SrgsCompiler.CompileStream(new XmlReader[1]
            {
                reader
            }, outputPath, null, false, null, referencedAssemblies, keyFile);
        }

        private static bool CheckIfCfg(Stream stream, out int cfgLength)
        {
            long position = stream.Position;
            bool result = CfgGrammar.CfgSerializedHeader.IsCfg(stream, out cfgLength);
            stream.Position = position;
            return result;
        }

        internal static void CompileXmlOrCopyCfg(Stream inputStream, Stream outputStream, Uri orginalUri)
        {
            SeekableReadStream seekableReadStream = new SeekableReadStream(inputStream);
            int cfgLength;
            bool flag = CheckIfCfg(seekableReadStream, out cfgLength);
            seekableReadStream.CacheDataForSeeking = false;
            if (flag)
            {
                Helpers.CopyStream(seekableReadStream, outputStream, cfgLength);
            }
            else
            {
                SrgsCompiler.SrgsCompiler.CompileStream(new XmlReader[1]
                {
                    new XmlTextReader(seekableReadStream)
                }, null, outputStream, true, orginalUri, null, null);
            }
        }
    }
}
