#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;
using Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsParser;
using Krypton.Toolkit.Suite.Extended.Utilities.SystemInternal.IO;
using Krypton.Toolkit.Suite.Extended.Utilities.SystemInternal.Speech;
using Microsoft.CSharp;
using Microsoft.VisualBasic;

using System.CodeDom.Compiler;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsCompiler
{
    internal class CustomGrammar
    {
        internal class CfgResource
        {
            internal string name;

            internal byte[] data;
        }

        internal string _language = "C#";

        internal string _namespace;

        internal List<Rule> _rules = new List<Rule>();

        internal Collection<string> _codebehind = new Collection<string>();

        internal bool _fDebugScript;

        internal Collection<string> _assemblyReferences = new Collection<string>();

        internal Collection<string> _importNamespaces = new Collection<string>();

        internal string _keyFile;

        internal Collection<ScriptRef> _scriptRefs = new Collection<ScriptRef>();

        internal List<string> _types = new List<string>();

        internal StringBuilder _script = new StringBuilder();

        private const string _preambuleMarker = "<Does Not Exist>";

        internal bool HasScript
        {
            get
            {
                bool flag = _script.Length > 0 || _codebehind.Count > 0;
                if (!flag)
                {
                    foreach (Rule rule in _rules)
                    {
                        if (rule.Script.Length > 0)
                        {
                            return true;
                        }
                    }
                    return flag;
                }
                return flag;
            }
        }

        internal CustomGrammar()
        {
        }

        internal string CreateAssembly(int iCfg, string outputFile, CultureInfo culture)
        {
            string text = null;
            FileHelper.DeleteTemporaryFile(outputFile);
            try
            {
                CreateAssembly(outputFile, false, null);
                CheckValidAssembly(iCfg, ExtractCodeGenerated(outputFile));
                return GenerateCode(true, culture);
            }
            finally
            {
                FileHelper.DeleteTemporaryFile(outputFile);
            }
        }

        internal void CreateAssembly(out byte[] il, out byte[] pdb)
        {
            string filePath;
            using (FileHelper.CreateAndOpenTemporaryFile(out filePath, FileAccess.Write, FileOptions.DeleteOnClose, "dll"))
            {
            }
            try
            {
                CreateAssembly(filePath, _fDebugScript, null);
                il = ExtractCodeGenerated(filePath);
                pdb = null;
                if (_fDebugScript)
                {
                    string text = filePath.Substring(0, filePath.LastIndexOf('.')) + ".pdb";
                    pdb = ExtractCodeGenerated(text);
                    FileHelper.DeleteTemporaryFile(text);
                }
                CheckValidAssembly(0, il);
            }
            finally
            {
                FileHelper.DeleteTemporaryFile(filePath);
            }
        }

        internal void CreateAssembly(string path, List<CfgResource> cfgResources)
        {
            CreateAssembly(path, _fDebugScript, cfgResources);
        }

        internal void Combine(CustomGrammar cg, string innerCode)
        {
            if (_rules.Count == 0)
            {
                _language = cg._language;
            }
            else if (_language != cg._language)
            {
                XmlParser.ThrowSrgsException(SRID.IncompatibleLanguageProperties);
            }
            if (_namespace == null)
            {
                _namespace = cg._namespace;
            }
            else if (_namespace != cg._namespace)
            {
                XmlParser.ThrowSrgsException(SRID.IncompatibleNamespaceProperties);
            }
            _fDebugScript |= cg._fDebugScript;
            foreach (string item in cg._codebehind)
            {
                if (!_codebehind.Contains(item))
                {
                    _codebehind.Add(item);
                }
            }
            foreach (string assemblyReference in cg._assemblyReferences)
            {
                if (!_assemblyReferences.Contains(assemblyReference))
                {
                    _assemblyReferences.Add(assemblyReference);
                }
            }
            foreach (string importNamespace in cg._importNamespaces)
            {
                if (!_importNamespaces.Contains(importNamespace))
                {
                    _importNamespaces.Add(importNamespace);
                }
            }
            _keyFile = cg._keyFile;
            _types.AddRange(cg._types);
            foreach (Rule rule in cg._rules)
            {
                if (_types.Contains(rule.Name))
                {
                    XmlParser.ThrowSrgsException(SRID.RuleDefinedMultipleTimes2, rule.Name);
                }
            }
            _script.Append(innerCode);
        }

        private void CreateAssembly(string outputFile, bool debug, List<CfgResource> cfgResources)
        {
            if (_language == null)
            {
                XmlParser.ThrowSrgsException(SRID.NoLanguageSet);
            }
            string text = GenerateCode(false, null);
            string filePath = null;
            string[] array = null;
            try
            {
                if (_codebehind.Count > 0)
                {
                    int num = _codebehind.Count + ((text != null) ? 1 : 0);
                    array = new string[num];
                    for (int i = 0; i < _codebehind.Count; i++)
                    {
                        array[i] = _codebehind[i];
                    }
                    if (text != null)
                    {
                        using (FileStream stream = FileHelper.CreateAndOpenTemporaryFile(out filePath))
                        {
                            array[array.Length - 1] = filePath;
                            using (StreamWriter streamWriter = new StreamWriter(stream))
                            {
                                streamWriter.Write(text);
                            }
                        }
                    }
                }
                CompileScript(outputFile, debug, text, array, cfgResources);
            }
            finally
            {
                FileHelper.DeleteTemporaryFile(filePath);
            }
        }

        private void CompileScript(string outputFile, bool debug, string code, string[] codeFiles, List<CfgResource> cfgResouces)
        {
            using (CodeDomProvider codeDomProvider = CodeProvider())
            {
                CompilerParameters compilerParameters = GetCompilerParameters(outputFile, cfgResouces, debug, _assemblyReferences, _keyFile);
                CompilerResults compilerResults = (codeFiles == null) ? codeDomProvider.CompileAssemblyFromSource(compilerParameters, code) : codeDomProvider.CompileAssemblyFromFile(compilerParameters, codeFiles);
                if (compilerResults.Errors.Count > 0)
                {
                    ThrowCompilationErrors(compilerResults);
                }
                if (compilerResults.NativeCompilerReturnValue != 0)
                {
                    XmlParser.ThrowSrgsException(SRID.UnexpectedError, compilerResults.NativeCompilerReturnValue);
                }
            }
        }

        private CodeDomProvider CodeProvider()
        {
            CodeDomProvider result = null;
            string language = _language;
            if (!(language == "C#"))
            {
                if (language == "VB.Net")
                {
                    result = CreateVBCompiler();
                }
                else
                {
                    XmlParser.ThrowSrgsException(SRID.UnsupportedLanguage, _language);
                }
            }
            else
            {
                result = CreateCSharpCompiler();
            }
            return result;
        }

        private string GenerateCode(bool classDefinitionOnly, CultureInfo culture)
        {
            string result = string.Empty;
            string language = _language;
            if (!(language == "C#"))
            {
                if (language == "VB.Net")
                {
                    result = WrapScriptVB(classDefinitionOnly, culture);
                }
                else
                {
                    XmlParser.ThrowSrgsException(SRID.UnsupportedLanguage, _language);
                }
            }
            else
            {
                result = WrapScriptCSharp(classDefinitionOnly, culture);
            }
            return result;
        }

        private string WrapScriptCSharp(bool classDefinitionOnly, CultureInfo culture)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Rule rule in _rules)
            {
                if (rule.Script != null)
                {
                    WrapClassCSharp(stringBuilder, rule.Name, rule.BaseClass, culture, rule.Script.ToString(), rule.Constructors.ToString());
                }
            }
            if (_script.Length > 0)
            {
                stringBuilder.Append(_script);
            }
            if (stringBuilder.Length <= 0)
            {
                return null;
            }
            if (classDefinitionOnly)
            {
                return stringBuilder.ToString();
            }
            return WrapScriptOuterCSharp(stringBuilder.ToString());
        }

        private string WrapScriptVB(bool classDefinitionOnly, CultureInfo culture)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Rule rule in _rules)
            {
                if (rule.Script != null)
                {
                    WrapClassVB(stringBuilder, rule.Name, rule.BaseClass, culture, rule.Script.ToString(), rule.Constructors.ToString());
                }
            }
            if (_script.Length > 0)
            {
                stringBuilder.Append(_script);
            }
            if (stringBuilder.Length <= 0)
            {
                return null;
            }
            if (classDefinitionOnly)
            {
                return stringBuilder.ToString();
            }
            return WrapScriptOuterVB(stringBuilder.ToString());
        }

        private static CodeDomProvider CreateCSharpCompiler()
        {
            return new CSharpCodeProvider();
        }

        private string WrapScriptOuterCSharp(string innerCode)
        {
            if (!string.IsNullOrEmpty(innerCode))
            {
                int num = 0;
                foreach (string importNamespace in _importNamespaces)
                {
                    num += importNamespace.Length;
                }
                SRID sRID = SRID.ArrayOfNullIllegal;
                string @namespace = sRID.GetType().Namespace;
                string text = string.Format(CultureInfo.InvariantCulture, "#line 1 \"{0}\"\nusing System;\nusing System.Collections.Generic;\nusing System.Diagnostics;\nusing {1};\nusing {1}.Recognition;\nusing {1}.Recognition.SrgsGrammar;\n", new object[2]
                {
                    "<Does Not Exist>",
                    @namespace
                });
                StringBuilder stringBuilder = new StringBuilder(_script.Length + text.Length + 200);
                stringBuilder.Append(text);
                foreach (string importNamespace2 in _importNamespaces)
                {
                    stringBuilder.Append("using ");
                    stringBuilder.Append(importNamespace2);
                    stringBuilder.Append(";\n");
                }
                if (_namespace != null)
                {
                    stringBuilder.Append("namespace ");
                    stringBuilder.Append(_namespace);
                    stringBuilder.Append("\n{\n");
                }
                stringBuilder.Append(innerCode);
                if (_namespace != null)
                {
                    stringBuilder.Append("}\n");
                }
                return stringBuilder.ToString();
            }
            return null;
        }

        private static void WrapClassCSharp(StringBuilder sb, string classname, string baseclass, CultureInfo culture, string script, string constructor)
        {
            sb.Append("public partial class ");
            sb.Append(classname);
            sb.Append(" : ");
            sb.Append((!string.IsNullOrEmpty(baseclass)) ? baseclass : "Grammar");
            sb.Append(" \n {\n");
            if (culture != null)
            {
                sb.Append("[DebuggerBrowsable (DebuggerBrowsableState.Never)]public static string __cultureId = \"");
                sb.Append(culture.LCID.ToString(CultureInfo.InvariantCulture));
                sb.Append("\";\n");
            }
            sb.Append(constructor);
            sb.Append(script);
            sb.Append("override protected bool IsStg { get { return true; }}\n\n");
            sb.Append("\n}\n");
        }

        private static CodeDomProvider CreateVBCompiler()
        {
            return new VBCodeProvider();
        }

        private string WrapScriptOuterVB(string innerCode)
        {
            if (!string.IsNullOrEmpty(innerCode))
            {
                int num = 0;
                foreach (string importNamespace in _importNamespaces)
                {
                    num += importNamespace.Length;
                }
                SRID sRID = SRID.ArrayOfNullIllegal;
                string @namespace = sRID.GetType().Namespace;
                string text = string.Format(CultureInfo.InvariantCulture, "#ExternalSource (\"{0}\", 1)\nImports System\nImports System.Collections.Generic\nImports System.Diagnostics\nImports {1}\nImports {1}.Recognition\nImports {1}.Recognition.SrgsGrammar\n", new object[2]
                {
                    "<Does Not Exist>",
                    @namespace
                });
                StringBuilder stringBuilder = new StringBuilder(_script.Length + text.Length + 200);
                stringBuilder.Append(text);
                foreach (string importNamespace2 in _importNamespaces)
                {
                    stringBuilder.Append("Imports ");
                    stringBuilder.Append(importNamespace2);
                    stringBuilder.Append("\n");
                }
                if (_namespace != null)
                {
                    stringBuilder.Append("Namespace ");
                    stringBuilder.Append(_namespace);
                    stringBuilder.Append("\n");
                }
                stringBuilder.Append("#End ExternalSource\n");
                stringBuilder.Append(innerCode);
                if (_namespace != null)
                {
                    stringBuilder.Append("End Namespace\n");
                }
                return stringBuilder.ToString();
            }
            return null;
        }

        private static void WrapClassVB(StringBuilder sb, string classname, string baseclass, CultureInfo culture, string script, string constructor)
        {
            sb.Append("Public Partial class ");
            sb.Append(classname);
            sb.Append("\n Inherits ");
            sb.Append((!string.IsNullOrEmpty(baseclass)) ? baseclass : "Grammar");
            sb.Append(" \n");
            if (culture != null)
            {
                sb.Append("<DebuggerBrowsable (DebuggerBrowsableState.Never)>Public Shared __cultureId as String = \"");
                sb.Append(culture.LCID.ToString(CultureInfo.InvariantCulture));
                sb.Append("\"\n");
            }
            sb.Append(constructor);
            sb.Append(script);
            sb.Append("Protected Overrides ReadOnly Property IsStg() As Boolean\nGet\nReturn True\nEnd Get\nEnd Property\n");
            sb.Append("\nEnd Class\n");
        }

        private static void ThrowCompilationErrors(CompilerResults results)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (CompilerError error in results.Errors)
            {
                if (stringBuilder.Length > 0)
                {
                    stringBuilder.Append("\n");
                }
                if (error.FileName.IndexOf("<Does Not Exist>", StringComparison.Ordinal) == -1)
                {
                    stringBuilder.Append(error.FileName);
                    stringBuilder.Append("(");
                    stringBuilder.Append(error.Line);
                    stringBuilder.Append(",");
                    stringBuilder.Append(error.Column);
                    stringBuilder.Append("): ");
                }
                stringBuilder.Append("error ");
                stringBuilder.Append(error.ErrorNumber);
                stringBuilder.Append(": ");
                stringBuilder.Append(error.ErrorText);
            }
            XmlParser.ThrowSrgsException(SRID.GrammarCompilerError, stringBuilder.ToString());
        }

        private static CompilerParameters GetCompilerParameters(string outputFile, List<CfgResource> cfgResources, bool debug, Collection<string> assemblyReferences, string keyfile)
        {
            CompilerParameters compilerParameters = new CompilerParameters();
            StringBuilder stringBuilder = new StringBuilder();
            compilerParameters.GenerateInMemory = false;
            compilerParameters.OutputAssembly = outputFile;
            if (compilerParameters.IncludeDebugInformation = debug)
            {
                stringBuilder.Append("/define:DEBUG ");
            }
            if (keyfile != null)
            {
                stringBuilder.Append("/keyfile:");
                stringBuilder.Append(keyfile);
            }
            compilerParameters.CompilerOptions = stringBuilder.ToString();
            compilerParameters.ReferencedAssemblies.Add("System.dll");
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            compilerParameters.ReferencedAssemblies.Add(executingAssembly.Location);
            foreach (string assemblyReference in assemblyReferences)
            {
                compilerParameters.ReferencedAssemblies.Add(assemblyReference);
            }
            if (cfgResources != null)
            {
                foreach (CfgResource cfgResource in cfgResources)
                {
                    using (FileStream output = new FileStream(cfgResource.name, FileMode.Create, FileAccess.Write))
                    {
                        using (BinaryWriter binaryWriter = new BinaryWriter(output))
                        {
                            binaryWriter.Write(cfgResource.data, 0, cfgResource.data.Length);
                            compilerParameters.EmbeddedResources.Add(cfgResource.name);
                        }
                    }
                }
                return compilerParameters;
            }
            return compilerParameters;
        }

        private void CheckValidAssembly(int iCfg, byte[] il)
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            AppDomain appDomain = null;
            try
            {
                appDomain = AppDomain.CreateDomain("Loading Domain");
                AppDomainCompilerProxy appDomainCompilerProxy = (AppDomainCompilerProxy)appDomain.CreateInstanceFromAndUnwrap(executingAssembly.GetName().CodeBase, "System.Speech.Internal.SrgsCompiler.AppDomainCompilerProxy");
                int count = _scriptRefs.Count;
                string[] array = new string[count];
                string[] array2 = new string[count];
                int[] array3 = new int[count];
                for (int i = 0; i < count; i++)
                {
                    ScriptRef scriptRef = _scriptRefs[i];
                    array[i] = scriptRef._rule;
                    array2[i] = scriptRef._sMethod;
                    array3[i] = (int)scriptRef._method;
                }
                Exception ex = appDomainCompilerProxy.CheckAssembly(il, iCfg, _language, _namespace, array, array2, array3);
                if (ex != null)
                {
                    throw ex;
                }
                AssociateConstructorsWithRules(appDomainCompilerProxy, array, _rules, iCfg, _language);
            }
            finally
            {
                if (appDomain != null)
                {
                    AppDomain.Unload(appDomain);
                    appDomain = null;
                }
            }
        }

        private static void AssociateConstructorsWithRules(AppDomainCompilerProxy proxy, string[] names, List<Rule> rules, int iCfg, string language)
        {
            string[] array = proxy.Constructors();
            foreach (Rule rule in rules)
            {
                int num = 0;
                while (num < names.Length && (num = Array.IndexOf(names, rule.Name, num)) >= 0)
                {
                    if (array[num] != null)
                    {
                        rule.Constructors.Append(array[num]);
                    }
                    num++;
                }
                if (rule.Constructors.Length == 0)
                {
                    rule.Constructors.Append(proxy.GenerateConstructor(iCfg, new ParameterInfo[0], language, rule.Name));
                }
            }
        }

        private static byte[] ExtractCodeGenerated(string path)
        {
            byte[] result = null;
            if (!string.IsNullOrEmpty(path))
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    return Helpers.ReadStreamToByteArray(fileStream, (int)fileStream.Length);
                }
            }
            return result;
        }
    }
}