#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;
using Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsCompiler;
using Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsGrammar;
using Krypton.Toolkit.Suite.Extended.Utilities.SystemInternal.Speech;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Recognition
{
    [DebuggerDisplay("Grammar: {(_uri != null ? \"uri=\" + _uri.ToString () + \" \" : \"\") + \"rule=\" + _ruleName }")]
    public class Grammar
    {
        private struct NameValuePair
        {
            internal string _name;

            internal string _value;
        }

        internal GrammarOptions _semanticTag;

        internal AppDomain _appDomain;

        internal AppDomainGrammarProxy _proxy;

        internal ScriptRef[] _scripts;

        private byte[] _cfgData;

        private Stream _appStream;

        private bool _isSrgsDocument;

        private SrgsDocument _srgsDocument;

        private GrammarBuilder _grammarBuilder;

        private IRecognizerInternal _recognizer;

        private GrammarState _grammarState;

        private Exception _loadException;

        private Uri _uri;

        private Uri _baseUri;

        private string _ruleName;

        private string _resources;

        private object[] _parameters;

        private string _onInitParameters;

        private bool _enabled = true;

        private bool _isStg;

        private bool _sapi53Only;

        private uint _sapiGrammarId;

        private float _weight = 1f;

        private int _priority;

        private InternalGrammarData _internalData;

        private string _grammarName = string.Empty;

        private Collection<Grammar> _ruleRefs;

        private static ResourceLoader _resourceLoader = new ResourceLoader();

        public bool Enabled
        {
            get
            {
                return _enabled;
            }
            set
            {
                if (_grammarState != 0 && _enabled != value)
                {
                    _recognizer.SetGrammarState(this, value);
                }
                _enabled = value;
            }
        }

        public float Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                if ((double)value < 0.0 || (double)value > 1.0)
                {
                    throw new ArgumentOutOfRangeException("value", SR.Get(SRID.GrammarInvalidWeight));
                }
                if (_grammarState != 0 && !_weight.Equals(value))
                {
                    _recognizer.SetGrammarWeight(this, value);
                }
                _weight = value;
            }
        }

        public int Priority
        {
            get
            {
                return _priority;
            }
            set
            {
                if (value < -128 || value > 127)
                {
                    throw new ArgumentOutOfRangeException("value", SR.Get(SRID.GrammarInvalidPriority));
                }
                if (_grammarState != 0 && _priority != value)
                {
                    _recognizer.SetGrammarPriority(this, value);
                }
                _priority = value;
            }
        }

        public string Name
        {
            get
            {
                return _grammarName;
            }
            set
            {
                if (value == null)
                {
                    value = string.Empty;
                }
                _grammarName = value;
            }
        }

        public string RuleName => _ruleName;

        public bool Loaded => _grammarState == GrammarState.Loaded;

        internal Uri Uri => _uri;

        internal IRecognizerInternal Recognizer
        {
            get
            {
                return _recognizer;
            }
            set
            {
                _recognizer = value;
            }
        }

        internal GrammarState State
        {
            get
            {
                return _grammarState;
            }
            set
            {
                switch (value)
                {
                    case GrammarState.Unloaded:
                        _loadException = null;
                        _recognizer = null;
                        if (_appDomain != null)
                        {
                            AppDomain.Unload(_appDomain);
                            _appDomain = null;
                        }
                        break;
                    default:
                        {
                            int num = 3;
                            break;
                        }
                    case GrammarState.Loaded:
                        break;
                }
                _grammarState = value;
            }
        }

        internal Exception LoadException
        {
            get
            {
                return _loadException;
            }
            set
            {
                _loadException = value;
            }
        }

        internal byte[] CfgData => _cfgData;

        internal Uri BaseUri => _baseUri;

        internal bool Sapi53Only => _sapi53Only;

        internal uint SapiGrammarId
        {
            get
            {
                return _sapiGrammarId;
            }
            set
            {
                _sapiGrammarId = value;
            }
        }

        protected internal virtual bool IsStg => _isStg;

        internal bool IsSrgsDocument => _isSrgsDocument;

        internal InternalGrammarData InternalData
        {
            get
            {
                return _internalData;
            }
            set
            {
                _internalData = value;
            }
        }

        protected string ResourceName
        {
            get
            {
                return _resources;
            }
            set
            {
                Helpers.ThrowIfEmptyOrNull(value, "value");
                _resources = value;
            }
        }

        public event EventHandler<SpeechRecognizedEventArgs> SpeechRecognized;

        internal Grammar(Uri uri, string ruleName, object[] parameters)
        {
            Helpers.ThrowIfNull(uri, "uri");
            _uri = uri;
            InitialGrammarLoad(ruleName, parameters, false);
        }

        public Grammar(string path)
            : this(path, (string)null, (object[])null)
        {
        }

        public Grammar(string path, string ruleName)
            : this(path, ruleName, null)
        {
        }

        public Grammar(string path, string ruleName, object[] parameters)
        {
            try
            {
                _uri = new Uri(path, UriKind.Relative);
            }
            catch (UriFormatException innerException)
            {
                throw new ArgumentException(SR.Get(SRID.RecognizerGrammarNotFound), "path", innerException);
            }
            InitialGrammarLoad(ruleName, parameters, false);
        }

        public Grammar(SrgsDocument srgsDocument)
            : this(srgsDocument, null, null, null)
        {
        }

        public Grammar(SrgsDocument srgsDocument, string ruleName)
            : this(srgsDocument, ruleName, null, null)
        {
        }

        public Grammar(SrgsDocument srgsDocument, string ruleName, object[] parameters)
            : this(srgsDocument, ruleName, null, parameters)
        {
        }

        /// <filterpriority>1</filterpriority>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public Grammar(SrgsDocument srgsDocument, string ruleName, Uri baseUri)
            : this(srgsDocument, ruleName, baseUri, null)
        {
        }

        /// <filterpriority>1</filterpriority>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public Grammar(SrgsDocument srgsDocument, string ruleName, Uri baseUri, object[] parameters)
        {
            Helpers.ThrowIfNull(srgsDocument, "srgsDocument");
            _srgsDocument = srgsDocument;
            _isSrgsDocument = (srgsDocument != null);
            _baseUri = baseUri;
            InitialGrammarLoad(ruleName, parameters, false);
        }

        public Grammar(Stream stream)
            : this(stream, null, null, null)
        {
        }

        public Grammar(Stream stream, string ruleName)
            : this(stream, ruleName, null, null)
        {
        }

        public Grammar(Stream stream, string ruleName, object[] parameters)
            : this(stream, ruleName, null, parameters)
        {
        }

        /// <filterpriority>1</filterpriority>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public Grammar(Stream stream, string ruleName, Uri baseUri)
            : this(stream, ruleName, baseUri, null)
        {
        }

        /// <filterpriority>1</filterpriority>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public Grammar(Stream stream, string ruleName, Uri baseUri, object[] parameters)
        {
            Helpers.ThrowIfNull(stream, "stream");
            if (!stream.CanRead)
            {
                throw new ArgumentException(SR.Get(SRID.StreamMustBeReadable), "stream");
            }
            _appStream = stream;
            _baseUri = baseUri;
            InitialGrammarLoad(ruleName, parameters, false);
        }

        public Grammar(GrammarBuilder builder)
        {
            Helpers.ThrowIfNull(builder, "builder");
            _grammarBuilder = builder;
            InitialGrammarLoad(null, null, false);
        }

        private Grammar(string onInitParameters, Stream stream, string ruleName)
        {
            _appStream = stream;
            _onInitParameters = onInitParameters;
            InitialGrammarLoad(ruleName, null, true);
        }

        protected Grammar()
        {
        }

        protected void StgInit(object[] parameters)
        {
            _parameters = parameters;
            LoadAndCompileCfgData(false, true);
        }

        /// <filterpriority>2</filterpriority>
        public static Grammar LoadLocalizedGrammarFromType(Type type, params object[] onInitParameters)
        {
            Helpers.ThrowIfNull(type, "type");
            if (type == typeof(Grammar) || !type.IsSubclassOf(typeof(Grammar)))
            {
                throw new ArgumentException(SR.Get(SRID.StrongTypedGrammarNotAGrammar), "type");
            }
            Assembly assembly = Assembly.GetAssembly(type);
            Type[] types = assembly.GetTypes();
            foreach (Type type2 in types)
            {
                string s = null;
                if ((type2 == type || type2.IsSubclassOf(type)) && type2.GetField("__cultureId") != null)
                {
                    try
                    {
                        s = (string)type2.InvokeMember("__cultureId", BindingFlags.GetField, null, null, null, null);
                    }
                    catch (Exception ex)
                    {
                        if (!(ex is MissingFieldException))
                        {
                            throw;
                        }
                    }
                    if (Helpers.CompareInvariantCulture(new CultureInfo(int.Parse(s, CultureInfo.InvariantCulture)), CultureInfo.CurrentUICulture))
                    {
                        try
                        {
                            return (Grammar)assembly.CreateInstance(type2.FullName, false, BindingFlags.CreateInstance, null, onInitParameters, null, null);
                        }
                        catch (MissingMemberException)
                        {
                            throw new ArgumentException(SR.Get(SRID.RuleScriptInvalidParameters, type2.Name, type2.Name));
                        }
                    }
                }
            }
            return null;
        }

        internal static Grammar Create(string grammarName, string ruleName, string onInitParameter, out Uri redirectUri)
        {
            redirectUri = null;
            grammarName = grammarName.Trim();
            Uri result;
            bool flag = Uri.TryCreate(grammarName, UriKind.Absolute, out result);
            int num = grammarName.IndexOf(".dll", StringComparison.OrdinalIgnoreCase);
            if (!flag || (num > 0 && num == grammarName.Length - 4))
            {
                Assembly assembly;
                if (flag)
                {
                    if (!result.IsFile)
                    {
                        throw new InvalidOperationException();
                    }
                    assembly = Assembly.LoadFrom(result.LocalPath);
                }
                else
                {
                    assembly = Assembly.Load(grammarName);
                }
                return LoadGrammarFromAssembly(assembly, ruleName, onInitParameter);
            }
            try
            {
                string localPath;
                using (Stream stream = _resourceLoader.LoadFile(result, out localPath, out redirectUri))
                {
                    try
                    {
                        return new Grammar(onInitParameter, stream, ruleName);
                    }
                    finally
                    {
                        _resourceLoader.UnloadFile(localPath);
                    }
                }
            }
            catch
            {
                Assembly assembly2 = Assembly.LoadFrom(grammarName);
                return LoadGrammarFromAssembly(assembly2, ruleName, onInitParameter);
            }
        }

        internal void OnRecognitionInternal(SpeechRecognizedEventArgs eventArgs)
        {
            this.SpeechRecognized?.Invoke(this, eventArgs);
        }

        internal static bool IsDictationGrammar(Uri uri)
        {
            if (uri == null || !uri.IsAbsoluteUri || uri.Scheme != "grammar" || !string.IsNullOrEmpty(uri.Host) || !string.IsNullOrEmpty(uri.Authority) || !string.IsNullOrEmpty(uri.Query) || uri.PathAndQuery != "dictation")
            {
                return false;
            }
            return true;
        }

        internal bool IsDictation(Uri uri)
        {
            bool flag = IsDictationGrammar(uri);
            if (!flag && this is DictationGrammar)
            {
                throw new ArgumentException(SR.Get(SRID.DictationInvalidTopic), "uri");
            }
            return flag;
        }

        internal Grammar Find(long grammarId)
        {
            if (_ruleRefs != null)
            {
                foreach (Grammar ruleRef in _ruleRefs)
                {
                    if (grammarId == ruleRef._sapiGrammarId)
                    {
                        return ruleRef;
                    }
                    Grammar result;
                    if ((result = ruleRef.Find(grammarId)) != null)
                    {
                        return result;
                    }
                }
            }
            return null;
        }

        internal Grammar Find(string ruleName)
        {
            if (_ruleRefs != null)
            {
                foreach (Grammar ruleRef in _ruleRefs)
                {
                    if (ruleName == ruleRef.RuleName)
                    {
                        return ruleRef;
                    }
                    Grammar result;
                    if ((result = ruleRef.Find(ruleName)) != null)
                    {
                        return result;
                    }
                }
            }
            return null;
        }

        internal void AddRuleRef(Grammar ruleRef, uint grammarId)
        {
            if (_ruleRefs == null)
            {
                _ruleRefs = new Collection<Grammar>();
            }
            _ruleRefs.Add(ruleRef);
            _sapiGrammarId = grammarId;
        }

        internal MethodInfo MethodInfo(string method)
        {
            return GetType().GetMethod(method, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        }

        private void LoadAndCompileCfgData(bool isImportedGrammar, bool stgInit)
        {
            Stream stream = IsStg ? LoadCfgFromResource(stgInit) : LoadCfg(isImportedGrammar, stgInit);
            SrgsRule[] array = RunOnInit(IsStg);
            if (array != null)
            {
                MemoryStream memoryStream = CombineCfg(_ruleName, stream, array);
                stream.Close();
                stream = memoryStream;
            }
            _cfgData = Helpers.ReadStreamToByteArray(stream, (int)stream.Length);
            stream.Close();
            _srgsDocument = null;
            _appStream = null;
        }

        private MemoryStream LoadCfg(bool isImportedGrammar, bool stgInit)
        {
            Uri uri = Uri;
            MemoryStream memoryStream = new MemoryStream();
            if (uri != null)
            {
                string mimeType;
                string localPath;
                using (Stream stream = _resourceLoader.LoadFile(uri, out mimeType, out _baseUri, out localPath))
                {
                    stream.Position = 0L;
                    SrgsGrammarCompiler.CompileXmlOrCopyCfg(stream, memoryStream, uri);
                }
                _resourceLoader.UnloadFile(localPath);
            }
            else if (_srgsDocument != null)
            {
                SrgsGrammarCompiler.Compile(_srgsDocument, memoryStream);
                if (_baseUri == null && _srgsDocument.BaseUri != null)
                {
                    _baseUri = _srgsDocument.BaseUri;
                }
            }
            else if (_grammarBuilder != null)
            {
                _grammarBuilder.Compile(memoryStream);
            }
            else
            {
                SrgsGrammarCompiler.CompileXmlOrCopyCfg(_appStream, memoryStream, null);
            }
            memoryStream.Position = 0L;
            _ruleName = CheckRuleName(memoryStream, _ruleName, isImportedGrammar, stgInit, out _sapi53Only, out _semanticTag);
            CreateSandbox(memoryStream);
            memoryStream.Position = 0L;
            return memoryStream;
        }

        private static Grammar LoadGrammarFromAssembly(Assembly assembly, string ruleName, string onInitParameters)
        {
            Type typeFromHandle = typeof(Grammar);
            Type type = null;
            Type[] types = assembly.GetTypes();
            foreach (Type type2 in types)
            {
                if (!type2.IsSubclassOf(typeFromHandle))
                {
                    continue;
                }
                string s = null;
                if (type2.Name == ruleName)
                {
                    type = type2;
                }
                if ((type2 == type || (type != null && type2.IsSubclassOf(type))) && type2.GetField("__cultureId") != null)
                {
                    try
                    {
                        s = (string)type2.InvokeMember("__cultureId", BindingFlags.GetField, null, null, null, null);
                    }
                    catch (Exception ex)
                    {
                        if (!(ex is MissingFieldException))
                        {
                            throw;
                        }
                    }
                    if (Helpers.CompareInvariantCulture(new CultureInfo(int.Parse(s, CultureInfo.InvariantCulture)), CultureInfo.CurrentUICulture))
                    {
                        try
                        {
                            object[] args = MatchInitParameters(type2, onInitParameters, assembly.GetName().Name, ruleName);
                            return (Grammar)assembly.CreateInstance(type2.FullName, false, BindingFlags.CreateInstance, null, args, null, null);
                        }
                        catch (MissingMemberException)
                        {
                            throw new ArgumentException(SR.Get(SRID.RuleScriptInvalidParameters, type2.Name, type2.Name));
                        }
                    }
                }
            }
            return null;
        }

        private static object[] MatchInitParameters(Type type, string onInitParameters, string grammar, string rule)
        {
            ConstructorInfo[] constructors = type.GetConstructors();
            NameValuePair[] array = ParseInitParams(onInitParameters);
            object[] array2 = new object[array.Length];
            bool flag = false;
            for (int i = 0; i < constructors.Length; i++)
            {
                if (flag)
                {
                    break;
                }
                ParameterInfo[] parameters = constructors[i].GetParameters();
                if (parameters.Length > array.Length)
                {
                    continue;
                }
                flag = true;
                for (int j = 0; j < array.Length && flag; j++)
                {
                    NameValuePair nameValuePair = array[j];
                    if (nameValuePair._name == null)
                    {
                        array2[j] = nameValuePair._value;
                        continue;
                    }
                    bool flag2 = false;
                    for (int k = 0; k < parameters.Length; k++)
                    {
                        if (parameters[k].Name == nameValuePair._name)
                        {
                            array2[k] = ParseValue(parameters[k].ParameterType, nameValuePair._value);
                            flag2 = true;
                            break;
                        }
                    }
                    if (!flag2)
                    {
                        flag = false;
                    }
                }
            }
            if (!flag)
            {
                throw new FormatException(SR.Get(SRID.CantFindAConstructor, grammar, rule, FormatConstructorParameters(constructors)));
            }
            return array2;
        }

        private static object ParseValue(Type type, string value)
        {
            if (type == typeof(string))
            {
                return value;
            }
            return type.InvokeMember("Parse", BindingFlags.InvokeMethod, null, null, new object[1]
            {
                value
            }, CultureInfo.InvariantCulture);
        }

        private static string FormatConstructorParameters(ConstructorInfo[] cis)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < cis.Length; i++)
            {
                stringBuilder.Append((i > 0) ? " or sapi:parms=\"" : "sapi:parms=\"");
                ParameterInfo[] parameters = cis[i].GetParameters();
                for (int j = 0; j < parameters.Length; j++)
                {
                    if (j > 0)
                    {
                        stringBuilder.Append(';');
                    }
                    ParameterInfo parameterInfo = parameters[j];
                    stringBuilder.Append(parameterInfo.Name);
                    stringBuilder.Append(':');
                    stringBuilder.Append(parameterInfo.ParameterType.Name);
                }
                stringBuilder.Append("\"");
            }
            return stringBuilder.ToString();
        }

        private static NameValuePair[] ParseInitParams(string initParameters)
        {
            if (string.IsNullOrEmpty(initParameters))
            {
                return new NameValuePair[0];
            }
            string[] array = initParameters.Split(new char[1]
            {
                ';'
            }, StringSplitOptions.None);
            NameValuePair[] array2 = new NameValuePair[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                string text = array[i];
                int num = text.IndexOf(':');
                if (num >= 0)
                {
                    array2[i]._name = text.Substring(0, num);
                    array2[i]._value = text.Substring(num + 1);
                }
                else
                {
                    array2[i]._value = text;
                }
            }
            return array2;
        }

        private void InitialGrammarLoad(string ruleName, object[] parameters, bool isImportedGrammar)
        {
            _ruleName = ruleName;
            _parameters = parameters;
            if (!IsDictation(_uri))
            {
                LoadAndCompileCfgData(isImportedGrammar, false);
            }
        }

        private void CreateSandbox(MemoryStream stream)
        {
            stream.Position = 0L;
            byte[] assemblyContent;
            byte[] assemblyDebugSymbols;
            ScriptRef[] scripts;
            if (CfgGrammar.LoadIL(stream, out assemblyContent, out assemblyDebugSymbols, out scripts))
            {
                Assembly executingAssembly = Assembly.GetExecutingAssembly();
                _appDomain = AppDomain.CreateDomain("sandbox");
                _proxy = (AppDomainGrammarProxy)_appDomain.CreateInstanceFromAndUnwrap(executingAssembly.GetName().CodeBase, "System.Speech.Internal.SrgsCompiler.AppDomainGrammarProxy");
                _proxy.Init(_ruleName, assemblyContent, assemblyDebugSymbols);
                _scripts = scripts;
            }
        }

        private Stream LoadCfgFromResource(bool stgInit)
        {
            Type t = typeof(SR);
            Assembly assembly = t.Assembly;

            Stream manifestResourceStream = assembly.GetManifestResourceStream(t.Namespace + "." + this.ResourceName);

            if (manifestResourceStream == null)
            {
                throw new FormatException(SR.Get(SRID.RecognizerInvalidBinaryGrammar));
            }
            try
            {
                ScriptRef[] array = CfgGrammar.LoadIL(manifestResourceStream);
                if (array == null)
                {
                    throw new ArgumentException(SR.Get(SRID.CannotLoadDotNetSemanticCode));
                }
                _scripts = array;
            }
            catch (Exception innerException)
            {
                throw new ArgumentException(SR.Get(SRID.CannotLoadDotNetSemanticCode), innerException);
            }
            manifestResourceStream.Position = 0L;
            _ruleName = CheckRuleName(manifestResourceStream, GetType().Name, false, stgInit, out _sapi53Only, out _semanticTag);
            _isStg = true;
            return manifestResourceStream;
        }

        private static MemoryStream CombineCfg(string rule, Stream stream, SrgsRule[] extraRules)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                SrgsDocument srgsDocument = new SrgsDocument();
                srgsDocument.TagFormat = SrgsTagFormat.KeyValuePairs;
                foreach (SrgsRule srgsRule in extraRules)
                {
                    srgsDocument.Rules.Add(srgsRule);
                }
                SrgsGrammarCompiler.Compile(srgsDocument, memoryStream);
                using (StreamMarshaler streamHelper = new StreamMarshaler(stream))
                {
                    long position = stream.Position;
                    Backend org = new Backend(streamHelper);
                    stream.Position = position;
                    memoryStream.Position = 0L;
                    MemoryStream memoryStream2 = new MemoryStream();
                    using (StreamMarshaler streamHelper2 = new StreamMarshaler(memoryStream))
                    {
                        Backend extra = new Backend(streamHelper2);
                        Backend backend = Backend.CombineGrammar(rule, org, extra);
                        using (StreamMarshaler streamBuffer = new StreamMarshaler(memoryStream2))
                        {
                            backend.Commit(streamBuffer);
                            memoryStream2.Position = 0L;
                            return memoryStream2;
                        }
                    }
                }
            }
        }

        private SrgsRule[] RunOnInit(bool stg)
        {
            SrgsRule[] result = null;
            bool flag = false;
            string text = ScriptRef.OnInitMethod(_scripts, _ruleName);
            if (text != null)
            {
                if (_proxy != null)
                {
                    Exception exceptionThrown;
                    result = _proxy.OnInit(text, _parameters, _onInitParameters, out exceptionThrown);
                    flag = true;
                    if (exceptionThrown != null)
                    {
                        throw exceptionThrown;
                    }
                }
                else
                {
                    Type[] array = new Type[_parameters.Length];
                    for (int i = 0; i < _parameters.Length; i++)
                    {
                        array[i] = _parameters[i].GetType();
                    }
                    MethodInfo method = GetType().GetMethod(text, array);
                    if (!(method != null))
                    {
                        throw new ArgumentException(SR.Get(SRID.RuleScriptInvalidParameters, _ruleName, _ruleName));
                    }
                    result = (SrgsRule[])method.Invoke(this, _parameters);
                    flag = true;
                }
            }
            if (!stg && !flag && _parameters != null)
            {
                throw new ArgumentException(SR.Get(SRID.RuleScriptInvalidParameters, _ruleName, _ruleName));
            }
            return result;
        }

        private static string CheckRuleName(Stream stream, string rulename, bool isImportedGrammar, bool stgInit, out bool sapi53Only, out GrammarOptions grammarOptions)
        {
            sapi53Only = false;
            long position = stream.Position;
            using (StreamMarshaler streamHelper = new StreamMarshaler(stream))
            {
                CfgGrammar.CfgSerializedHeader cfgSerializedHeader = null;
                CfgGrammar.CfgHeader cfgHeader = CfgGrammar.ConvertCfgHeader(streamHelper, false, true, out cfgSerializedHeader);
                StringBlob pszSymbols = cfgHeader.pszSymbols;
                string text = (cfgHeader.ulRootRuleIndex != uint.MaxValue && cfgHeader.ulRootRuleIndex < cfgHeader.rules.Length) ? pszSymbols.FromOffset(cfgHeader.rules[cfgHeader.ulRootRuleIndex]._nameOffset) : null;
                sapi53Only = ((cfgHeader.GrammarOptions & (GrammarOptions.MssV1 | GrammarOptions.IpaPhoneme | GrammarOptions.W3cV1 | GrammarOptions.STG)) != 0);
                if (text == null && string.IsNullOrEmpty(rulename))
                {
                    throw new ArgumentException(SR.Get(SRID.SapiErrorNoRulesToActivate));
                }
                if (!string.IsNullOrEmpty(rulename))
                {
                    bool flag = false;
                    CfgRule[] rules = cfgHeader.rules;
                    for (int i = 0; i < rules.Length; i++)
                    {
                        CfgRule cfgRule = rules[i];
                        if (pszSymbols.FromOffset(cfgRule._nameOffset) == rulename)
                        {
                            flag = (cfgRule.Export || stgInit || (!isImportedGrammar && (cfgRule.TopLevel || rulename == text)));
                            break;
                        }
                    }
                    if (!flag)
                    {
                        throw new ArgumentException(SR.Get(SRID.RecognizerRuleNotFoundStream, rulename));
                    }
                }
                else
                {
                    rulename = text;
                }
                grammarOptions = (cfgHeader.GrammarOptions & GrammarOptions.TagFormat);
            }
            stream.Position = position;
            return rulename;
        }
    }
}
