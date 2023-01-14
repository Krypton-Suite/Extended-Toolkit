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

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsGrammar
{
    [Serializable]
    public sealed class SrgsRulesCollection : KeyedCollection<string, SrgsRule>
    {
        public void Add(params SrgsRule[] rules)
        {
            Helpers.ThrowIfNull(rules, "rules");
            int num = 0;
            while (true)
            {
                if (num < rules.Length)
                {
                    if (rules[num] == null)
                    {
                        break;
                    }
                    base.Add(rules[num]);
                    num++;
                    continue;
                }
                return;
            }
            throw new ArgumentNullException("rules", SR.Get(SRID.ParamsEntryNullIllegal));
        }

        protected override string GetKeyForItem(SrgsRule rule)
        {
            if (rule == null)
            {
                throw new ArgumentNullException("rule");
            }
            return rule.Id;
        }
    }
}
