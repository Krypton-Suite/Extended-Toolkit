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

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsGrammar;

public static class SrgsGrammarCompiler
{
    public static void Compile(string inputPath, Stream outputStream)
    {
        Helpers.ThrowIfEmptyOrNull(inputPath, "inputPath");
        Helpers.ThrowIfNull(outputStream, "outputStream");
        using (XmlTextReader xmlTextReader = new XmlTextReader(new Uri(inputPath, UriKind.RelativeOrAbsolute).ToString()))
        {
            SrgsCompiler.SrgsCompiler.CompileStream([
                xmlTextReader
            ], null, outputStream, true, null, null, null);
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
        SrgsCompiler.SrgsCompiler.CompileStream([
            reader
        ], null, outputStream, true, null, null, null);
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
        SrgsCompiler.SrgsCompiler.CompileStream([
            reader
        ], outputPath, null, false, null, referencedAssemblies, keyFile);
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
            SrgsCompiler.SrgsCompiler.CompileStream([
                new XmlTextReader(seekableReadStream)
            ], null, outputStream, true, orginalUri, null, null);
        }
    }
}