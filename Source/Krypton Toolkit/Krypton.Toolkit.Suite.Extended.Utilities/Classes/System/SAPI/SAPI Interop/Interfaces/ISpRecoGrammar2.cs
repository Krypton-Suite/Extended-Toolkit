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

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    [ComImport, Guid("4B37BC9E-9ED6-44a3-93D3-18F022B79EC3"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ISpRecoGrammar2
    {
        void GetRules(out IntPtr ppCoMemRules, out uint puNumRules);

        void LoadCmdFromFile2([MarshalAs(UnmanagedType.LPWStr)] string pszFileName, SPLOADOPTIONS Options, [MarshalAs(UnmanagedType.LPWStr)] string pszSharingUri, [MarshalAs(UnmanagedType.LPWStr)] string pszBaseUri);

        void LoadCmdFromMemory2(IntPtr pGrammar, SPLOADOPTIONS Options, [MarshalAs(UnmanagedType.LPWStr)] string pszSharingUri, [MarshalAs(UnmanagedType.LPWStr)] string pszBaseUri);

        void SetRulePriority([MarshalAs(UnmanagedType.LPWStr)] string pszRuleName, uint ulRuleId, int nRulePriority);

        void SetRuleWeight([MarshalAs(UnmanagedType.LPWStr)] string pszRuleName, uint ulRuleId, float flWeight);

        void SetDictationWeight(float flWeight);

        void SetGrammarLoader(ISpGrammarResourceLoader pLoader);

        void Slot2();
    }
}