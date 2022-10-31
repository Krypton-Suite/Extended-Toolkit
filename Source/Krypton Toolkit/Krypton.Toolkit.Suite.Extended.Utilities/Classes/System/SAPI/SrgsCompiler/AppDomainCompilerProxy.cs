#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
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

using Krypton.Toolkit.Suite.Extended.Utilities.System.Recognition;
using Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsGrammar;
using Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsParser;
using Krypton.Toolkit.Suite.Extended.Utilities.SystemInternal.Speech;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsCompiler
{
    internal class AppDomainCompilerProxy : MarshalByRefObject
    {
        private class ScriptRefStruct
        {
            internal string _rule;

            internal RuleMethodScript _method;

            internal ScriptRefStruct(string rule, RuleMethodScript method)
            {
                _rule = rule;
                _method = method;
            }
        }

        internal string[] _constructors;

        internal Exception CheckAssembly(byte[] il, int iCfg, string language, string nameSpace, string[] ruleNames, string[] methodNames, int[] methodScripts)
        {
            try
            {
                Assembly assembly = Assembly.Load(il);
                _constructors = new string[ruleNames.Length];
                int i = 0;
                for (int num = ruleNames.Length; i < num; i++)
                {
                    string text = ruleNames[i];
                    string text2 = methodNames[i];
                    _constructors[i] = string.Empty;
                    string text3 = ((!string.IsNullOrEmpty(nameSpace)) ? (nameSpace + ".") : string.Empty) + text;
                    Type type = assembly.GetType(text3);
                    if (type == null)
                    {
                        XmlParser.ThrowSrgsException(SRID.CannotFindClass, text, nameSpace);
                    }
                    if (!type.IsSubclassOf(typeof(Grammar)))
                    {
                        XmlParser.ThrowSrgsException(SRID.StrongTypedGrammarNotAGrammar, text3, nameSpace);
                    }
                    MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                    ScriptRefStruct scriptRefStruct = new ScriptRefStruct(text, (RuleMethodScript)methodScripts[i]);
                    bool flag = false;
                    foreach (MethodInfo methodInfo in methods)
                    {
                        if (methodInfo.Name == text2)
                        {
                            ParameterInfo[] parameters = methodInfo.GetParameters();
                            Type right = null;
                            switch (scriptRefStruct._method)
                            {
                                case RuleMethodScript.onInit:
                                    _constructors[i] += GenerateConstructor(iCfg, parameters, language, text);
                                    right = typeof(SrgsRule[]);
                                    break;
                                case RuleMethodScript.onParse:
                                    ThrowIfMultipleOverloads(flag, text2);
                                    if (parameters.Length != 2 || parameters[0].ParameterType != typeof(SemanticValue) || parameters[1].ParameterType != typeof(RecognizedWordUnit[]))
                                    {
                                        XmlParser.ThrowSrgsException(SRID.RuleScriptInvalidParameters, text2, scriptRefStruct._rule);
                                    }
                                    right = typeof(object);
                                    break;
                                case RuleMethodScript.onRecognition:
                                    ThrowIfMultipleOverloads(flag, text2);
                                    if (parameters.Length != 1 || parameters[0].ParameterType != typeof(RecognitionResult))
                                    {
                                        XmlParser.ThrowSrgsException(SRID.RuleScriptInvalidParameters, text2, scriptRefStruct._rule);
                                    }
                                    right = typeof(object);
                                    break;
                                case RuleMethodScript.onError:
                                    ThrowIfMultipleOverloads(flag, text2);
                                    if (parameters.Length != 1 || parameters[0].ParameterType != typeof(Exception))
                                    {
                                        XmlParser.ThrowSrgsException(SRID.RuleScriptInvalidParameters, text2, scriptRefStruct._rule);
                                    }
                                    right = typeof(void);
                                    break;
                            }
                            if (methodInfo.ReturnType != right)
                            {
                                XmlParser.ThrowSrgsException(SRID.RuleScriptInvalidReturnType, text2, scriptRefStruct._rule);
                            }
                            flag = true;
                        }
                    }
                    if (!flag)
                    {
                        XmlParser.ThrowSrgsException(SRID.RuleScriptNotFound, text2, scriptRefStruct._rule, scriptRefStruct._method.ToString());
                    }
                    if (!type.IsPublic)
                    {
                        XmlParser.ThrowSrgsException(SRID.ClassNotPublic, text);
                    }
                }
            }
            catch (Exception result)
            {
                return result;
            }
            return null;
        }

        internal string[] Constructors()
        {
            return _constructors;
        }

        internal string GenerateConstructor(int iCfg, ParameterInfo[] parameters, string language, string classname)
        {
            string result = string.Empty;
            if (!(language == "C#"))
            {
                if (language == "VB.Net")
                {
                    result = WrapConstructorVB(iCfg, parameters, classname);
                }
                else
                {
                    XmlParser.ThrowSrgsException(SRID.UnsupportedLanguage, language);
                }
            }
            else
            {
                result = WrapConstructorCSharp(iCfg, parameters, classname);
            }
            return result;
        }

        private static void ThrowIfMultipleOverloads(bool found, string method)
        {
            if (found)
            {
                XmlParser.ThrowSrgsException(SRID.OverloadNotAllowed, method);
            }
        }

        private static string WrapConstructorCSharp(int iCfg, ParameterInfo[] parameters, string classname)
        {
            StringBuilder stringBuilder = new StringBuilder(200);
            stringBuilder.Append(" public ");
            stringBuilder.Append(classname);
            stringBuilder.Append(" (");
            if (parameters != null)
            {
                int num = 0;
                foreach (ParameterInfo parameterInfo in parameters)
                {
                    if (num++ > 0)
                    {
                        stringBuilder.Append(", ");
                    }
                    if (num == parameters.Length && parameterInfo.ParameterType.IsArray)
                    {
                        object[] customAttributes = parameterInfo.GetCustomAttributes(false);
                        object[] array = customAttributes;
                        foreach (object obj in array)
                        {
                            if (obj is ParamArrayAttribute)
                            {
                                stringBuilder.Append("params ");
                                break;
                            }
                        }
                    }
                    stringBuilder.Append(parameterInfo.ParameterType.FullName);
                    stringBuilder.Append(" ");
                    stringBuilder.Append(parameterInfo.Name);
                }
            }
            stringBuilder.Append(" )\n  {\n object [] onInitParams = new object [");
            stringBuilder.Append((parameters != null) ? parameters.Length : 0);
            stringBuilder.Append("];\n");
            int num2 = 0;
            while (parameters != null && num2 < parameters.Length)
            {
                stringBuilder.Append("onInitParams [");
                stringBuilder.Append(num2);
                stringBuilder.Append("] = ");
                stringBuilder.Append(parameters[num2].Name);
                stringBuilder.Append(";\n");
                num2++;
            }
            stringBuilder.Append("ResourceName = \"");
            stringBuilder.Append(iCfg.ToString(CultureInfo.InvariantCulture));
            stringBuilder.Append(".CFG\";\nStgInit (onInitParams);");
            stringBuilder.Append("\n  } \n");
            return stringBuilder.ToString();
        }

        private static string WrapConstructorVB(int iCfg, ParameterInfo[] parameters, string classname)
        {
            StringBuilder stringBuilder = new StringBuilder(200);
            stringBuilder.Append("Public Sub New");
            stringBuilder.Append(" (");
            if (parameters != null)
            {
                int num = 0;
                foreach (ParameterInfo parameterInfo in parameters)
                {
                    if (num++ > 0)
                    {
                        stringBuilder.Append(", ");
                    }
                    if (!parameterInfo.ParameterType.IsByRef)
                    {
                        stringBuilder.Append("ByVal ");
                    }
                    if (num == parameters.Length && parameterInfo.ParameterType.IsArray)
                    {
                        object[] customAttributes = parameterInfo.GetCustomAttributes(false);
                        object[] array = customAttributes;
                        foreach (object obj in array)
                        {
                            if (obj is ParamArrayAttribute)
                            {
                                stringBuilder.Append("ParamArray ");
                                break;
                            }
                        }
                    }
                    stringBuilder.Append(parameterInfo.Name);
                    if (parameterInfo.ParameterType.IsArray)
                    {
                        stringBuilder.Append("()");
                    }
                    stringBuilder.Append(" as ");
                    stringBuilder.Append(parameterInfo.ParameterType.Name);
                }
            }
            stringBuilder.Append(" )\n  Dim onInitParams () as Object = {");
            int num2 = 0;
            while (parameters != null && num2 < parameters.Length)
            {
                if (num2 > 0)
                {
                    stringBuilder.Append(", ");
                }
                stringBuilder.Append(parameters[num2].Name);
                num2++;
            }
            stringBuilder.Append("}\n");
            stringBuilder.Append("ResourceName = \"");
            stringBuilder.Append(iCfg.ToString(CultureInfo.InvariantCulture));
            stringBuilder.Append(".CFG\"\nStgInit (onInitParams)\n");
            stringBuilder.Append("\nEnd Sub \n");
            return stringBuilder.ToString();
        }
    }
}