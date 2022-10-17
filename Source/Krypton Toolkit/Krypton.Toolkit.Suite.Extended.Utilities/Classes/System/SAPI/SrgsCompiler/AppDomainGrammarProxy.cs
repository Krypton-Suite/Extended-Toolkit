#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.Recognition;
using Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsGrammar;
using Krypton.Toolkit.Suite.Extended.Utilities.SystemInternal.Speech;

using System.Security.Policy;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsCompiler
{
    internal class AppDomainGrammarProxy : MarshalByRefObject
    {
        private struct NameValuePair
        {
            internal string _name;

            internal string _value;
        }

        private Grammar _grammar;

        private Assembly _assembly;

        private string _rule;

        private Type _grammarType;

        private PermissionSet _internetPermissionSet;

        internal SrgsRule[] OnInit(string method, object[] parameters, string onInitParameters, out Exception exceptionThrown)
        {
            exceptionThrown = null;
            try
            {
                if (!string.IsNullOrEmpty(onInitParameters))
                {
                    parameters = MatchInitParameters(method, onInitParameters, _rule, _rule);
                }
                Type[] array = new Type[(parameters != null) ? parameters.Length : 0];
                if (parameters != null)
                {
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        array[i] = parameters[i].GetType();
                    }
                }
                MethodInfo method2 = _grammarType.GetMethod(method, array);
                if (method2 == null)
                {
                    throw new InvalidOperationException(SR.Get(SRID.ArgumentMismatch));
                }
                SrgsRule[] result = null;
                if (method2 != null)
                {
                    _internetPermissionSet.PermitOnly();
                    result = (SrgsRule[])method2.Invoke(_grammar, parameters);
                }
                return result;
            }
            catch (Exception ex)
            {
                Exception ex2 = exceptionThrown = ex;
                return null;
            }
        }

        internal object OnRecognition(string method, object[] parameters, out Exception exceptionThrown)
        {
            exceptionThrown = null;
            try
            {
                MethodInfo method2 = _grammarType.GetMethod(method, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                _internetPermissionSet.PermitOnly();
                return method2.Invoke(_grammar, parameters);
            }
            catch (Exception ex)
            {
                Exception ex2 = exceptionThrown = ex;
            }
            return null;
        }

        internal object OnParse(string rule, string method, object[] parameters, out Exception exceptionThrown)
        {
            exceptionThrown = null;
            try
            {
                MethodInfo onParse;
                Grammar grammar;
                GetRuleInstance(rule, method, out onParse, out grammar);
                _internetPermissionSet.PermitOnly();
                return onParse.Invoke(grammar, parameters);
            }
            catch (Exception ex)
            {
                Exception ex2 = exceptionThrown = ex;
                return null;
            }
        }

        internal void OnError(string rule, string method, object[] parameters, out Exception exceptionThrown)
        {
            exceptionThrown = null;
            try
            {
                MethodInfo onParse;
                Grammar grammar;
                GetRuleInstance(rule, method, out onParse, out grammar);
                _internetPermissionSet.PermitOnly();
                onParse.Invoke(grammar, parameters);
            }
            catch (Exception ex)
            {
                Exception ex2 = exceptionThrown = ex;
            }
        }

        internal void Init(string rule, byte[] il, byte[] pdb)
        {
            _assembly = Assembly.Load(il, pdb);
            _grammarType = GetTypeForRule(_assembly, rule);
            if (_grammarType == null)
            {
                throw new FormatException(SR.Get(SRID.RecognizerRuleNotFoundStream, rule));
            }
            _rule = rule;
            try
            {
                _grammar = (Grammar)_assembly.CreateInstance(_grammarType.FullName);
            }
            catch (MissingMemberException)
            {
                throw new ArgumentException(SR.Get(SRID.RuleScriptInvalidParameters, _grammarType.FullName, rule), "rule");
            }
            _internetPermissionSet = PolicyLevel.CreateAppDomainLevel().GetNamedPermissionSet("Internet");
            _internetPermissionSet.AddPermission(new ReflectionPermission(PermissionState.Unrestricted));
        }

        private void GetRuleInstance(string rule, string method, out MethodInfo onParse, out Grammar grammar)
        {
            Type type = (rule == _rule) ? _grammarType : GetTypeForRule(_assembly, rule);
            if (type == null || !type.IsSubclassOf(typeof(Grammar)))
            {
                throw new FormatException(SR.Get(SRID.RecognizerInvalidBinaryGrammar));
            }
            try
            {
                grammar = ((type == _grammarType) ? _grammar : ((Grammar)_assembly.CreateInstance(type.FullName)));
            }
            catch (MissingMemberException)
            {
                throw new ArgumentException(SR.Get(SRID.RuleScriptInvalidParameters, type.FullName, rule), "rule");
            }
            onParse = grammar.MethodInfo(method);
        }

        private static Type GetTypeForRule(Assembly assembly, string rule)
        {
            Type[] types = assembly.GetTypes();
            foreach (Type type in types)
            {
                if (type.Name == rule && type.IsPublic && type.IsSubclassOf(typeof(Grammar)))
                {
                    return type;
                }
            }
            return null;
        }

        private object[] MatchInitParameters(string method, string onInitParameters, string grammar, string rule)
        {
            MethodInfo[] methods = _grammarType.GetMethods();
            NameValuePair[] array = ParseInitParams(onInitParameters);
            object[] array2 = new object[array.Length];
            bool flag = false;
            for (int i = 0; i < methods.Length; i++)
            {
                if (flag)
                {
                    break;
                }
                if (methods[i].Name != method)
                {
                    continue;
                }
                ParameterInfo[] parameters = methods[i].GetParameters();
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
                throw new FormatException(SR.Get(SRID.CantFindAConstructor, grammar, rule, FormatConstructorParameters(methods, method)));
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

        private static string FormatConstructorParameters(MethodInfo[] cis, string method)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < cis.Length; i++)
            {
                if (!(cis[i].Name == method))
                {
                    continue;
                }
                stringBuilder.Append((stringBuilder.Length > 0) ? " or sapi:parms=\"" : "sapi:parms=\"");
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
    }
}