#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;
using Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsGrammar;
using Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsParser;
using Krypton.Toolkit.Suite.Extended.Utilities.SystemInternal.Speech;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsCompiler
{
    internal static class SrgsCompiler
    {
        internal static void CompileStream(XmlReader[] xmlReaders, string filename, Stream stream, bool fOutputCfg, Uri originalUri, string[] referencedAssemblies, string keyFile)
        {
            int num = xmlReaders.Length;
            List<CustomGrammar.CfgResource> cfgResources = new List<CustomGrammar.CfgResource>();
            CustomGrammar customGrammar = new CustomGrammar();
            for (int i = 0; i < num; i++)
            {
                string srgsPath = null;
                Uri uri = originalUri;
                if (uri == null && xmlReaders[i].BaseURI != null && xmlReaders[i].BaseURI.Length > 0)
                {
                    uri = new Uri(xmlReaders[i].BaseURI);
                }
                if (uri != null && (!uri.IsAbsoluteUri || uri.IsFile))
                {
                    srgsPath = Path.GetDirectoryName(uri.IsAbsoluteUri ? uri.AbsolutePath : uri.OriginalString);
                }
                StringBuilder stringBuilder = new StringBuilder();
                ISrgsParser srgsParser = new XmlParser(xmlReaders[i], uri);
                CultureInfo culture;
                object obj = CompileStream(i + 1, srgsParser, srgsPath, filename, stream, fOutputCfg, stringBuilder, cfgResources, out culture, referencedAssemblies, keyFile);
                if (!fOutputCfg)
                {
                    customGrammar.Combine((CustomGrammar)obj, stringBuilder.ToString());
                }
            }
            if (!fOutputCfg)
            {
                customGrammar.CreateAssembly(filename, cfgResources);
            }
        }

        internal static void CompileStream(SrgsDocument srgsGrammar, string filename, Stream stream, bool fOutputCfg, string[] referencedAssemblies, string keyFile)
        {
            ISrgsParser srgsParser = new SrgsDocumentParser(srgsGrammar.Grammar);
            List<CustomGrammar.CfgResource> cfgResources = new List<CustomGrammar.CfgResource>();
            StringBuilder stringBuilder = new StringBuilder();
            srgsGrammar.Grammar.Validate();
            CultureInfo culture;
            object obj = CompileStream(1, srgsParser, null, filename, stream, fOutputCfg, stringBuilder, cfgResources, out culture, referencedAssemblies, keyFile);
            if (!fOutputCfg)
            {
                CustomGrammar customGrammar = new CustomGrammar();
                customGrammar.Combine((CustomGrammar)obj, stringBuilder.ToString());
                customGrammar.CreateAssembly(filename, cfgResources);
            }
        }

        private static object CompileStream(int iCfg, ISrgsParser srgsParser, string srgsPath, string filename, Stream stream, bool fOutputCfg, StringBuilder innerCode, object cfgResources, out CultureInfo culture, string[] referencedAssemblies, string keyFile)
        {
            Backend backend = new Backend();
            CustomGrammar customGrammar = new CustomGrammar();
            SrgsElementCompilerFactory srgsElementCompilerFactory = (SrgsElementCompilerFactory)(srgsParser.ElementFactory = new SrgsElementCompilerFactory(backend, customGrammar));
            srgsParser.Parse();
            backend.Optimize();
            culture = ((backend.LangId == 21514) ? new CultureInfo("es-us") : new CultureInfo(backend.LangId));
            if (customGrammar._codebehind.Count > 0 && !string.IsNullOrEmpty(srgsPath))
            {
                for (int i = 0; i < customGrammar._codebehind.Count; i++)
                {
                    if (!File.Exists(customGrammar._codebehind[i]))
                    {
                        customGrammar._codebehind[i] = srgsPath + "\\" + customGrammar._codebehind[i];
                    }
                }
            }
            if (referencedAssemblies != null)
            {
                foreach (string item in referencedAssemblies)
                {
                    customGrammar._assemblyReferences.Add(item);
                }
            }
            customGrammar._keyFile = keyFile;
            backend.ScriptRefs = customGrammar._scriptRefs;
            if (!fOutputCfg)
            {
                CustomGrammar.CfgResource cfgResource = new CustomGrammar.CfgResource();
                cfgResource.data = BuildCfg(backend).ToArray();
                cfgResource.name = iCfg.ToString(CultureInfo.InvariantCulture) + ".CFG";
                ((List<CustomGrammar.CfgResource>)cfgResources).Add(cfgResource);
                innerCode.Append(customGrammar.CreateAssembly(iCfg, filename, culture));
                return customGrammar;
            }
            if (customGrammar._scriptRefs.Count > 0 && !customGrammar.HasScript)
            {
                XmlParser.ThrowSrgsException(SRID.NoScriptsForRules);
            }
            CreateAssembly(backend, customGrammar);
            if (!string.IsNullOrEmpty(filename))
            {
                stream = new FileStream(filename, FileMode.Create, FileAccess.Write);
            }
            try
            {
                using (StreamMarshaler streamBuffer = new StreamMarshaler(stream))
                {
                    backend.Commit(streamBuffer);
                    return customGrammar;
                }
            }
            finally
            {
                if (!string.IsNullOrEmpty(filename))
                {
                    stream.Close();
                }
            }
        }

        private static MemoryStream BuildCfg(Backend backend)
        {
            MemoryStream memoryStream = new MemoryStream();
            using (StreamMarshaler streamBuffer = new StreamMarshaler(memoryStream))
            {
                backend.IL = null;
                backend.PDB = null;
                backend.Commit(streamBuffer);
                return memoryStream;
            }
        }

        private static void CreateAssembly(Backend backend, CustomGrammar cg)
        {
            if (cg.HasScript)
            {
                byte[] il;
                byte[] pdb;
                cg.CreateAssembly(out il, out pdb);
                backend.IL = il;
                backend.PDB = pdb;
            }
        }
    }
}