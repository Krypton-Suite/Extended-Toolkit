#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;
using Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsParser;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsCompiler
{
    internal class ScriptRef
    {
        internal string _rule;

        internal string _sMethod;

        internal RuleMethodScript _method;

        internal int _idSymbol;

        internal ScriptRef(string rule, string sMethod, RuleMethodScript method)
        {
            _rule = rule;
            _sMethod = sMethod;
            _method = method;
        }

        internal void Serialize(StringBlob symbols, StreamMarshaler streamBuffer)
        {
            CfgScriptRef cfgScriptRef = default(CfgScriptRef);
            cfgScriptRef._idRule = symbols.Find(_rule);
            cfgScriptRef._method = _method;
            cfgScriptRef._idMethod = _idSymbol;
            streamBuffer.WriteStream(cfgScriptRef);
        }

        internal static string OnInitMethod(ScriptRef[] scriptRefs, string rule)
        {
            if (scriptRefs != null)
            {
                foreach (ScriptRef scriptRef in scriptRefs)
                {
                    if (scriptRef._rule == rule && scriptRef._method == RuleMethodScript.onInit)
                    {
                        return scriptRef._sMethod;
                    }
                }
            }
            return null;
        }
    }
}