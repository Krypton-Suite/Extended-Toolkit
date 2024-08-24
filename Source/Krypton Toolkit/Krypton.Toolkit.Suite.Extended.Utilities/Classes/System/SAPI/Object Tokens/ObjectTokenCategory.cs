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

using IEnumSpObjectTokens = Krypton.Toolkit.Suite.Extended.Utilities.System.Recognition.IEnumSpObjectTokens;
using ISpObjectTokenCategory = Krypton.Toolkit.Suite.Extended.Utilities.System.Recognition.ISpObjectTokenCategory;
using SpObjectTokenCategory = Krypton.Toolkit.Suite.Extended.Utilities.System.Recognition.SpObjectTokenCategory;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.ObjectTokens
{
    internal class ObjectTokenCategory : RegistryDataKey, IEnumerable<ObjectToken>, IEnumerable
    {
        protected ObjectTokenCategory(string keyId, RegistryDataKey key)
            : base(keyId, key)
        {
        }

        internal static ObjectTokenCategory Create(string sCategoryId)
        {
            RegistryDataKey key = RegistryDataKey.Open(sCategoryId, true);
            return new ObjectTokenCategory(sCategoryId, key);
        }

        internal ObjectToken OpenToken(string keyName)
        {
            string text = keyName;
            if (!string.IsNullOrEmpty(text) && text.IndexOf("HKEY_", StringComparison.Ordinal) != 0)
            {
                text = string.Format(CultureInfo.InvariantCulture, "{0}\\Tokens\\{1}", new object[2]
                {
                    base.Id,
                    text
                });
            }
            return ObjectToken.Open(null, text, false);
        }

        internal IList<ObjectToken> FindMatchingTokens(string requiredAttributes, string optionalAttributes)
        {
            IList<ObjectToken> list = new List<ObjectToken>();
            ISpObjectTokenCategory spObjectTokenCategory = null;
            IEnumSpObjectTokens ppEnum = null;
            try
            {
                spObjectTokenCategory = (ISpObjectTokenCategory)new SpObjectTokenCategory();
                spObjectTokenCategory.SetId(_sKeyId, false);
                spObjectTokenCategory.EnumTokens(requiredAttributes, optionalAttributes, out ppEnum);
                uint pCount;
                ppEnum.GetCount(out pCount);
                for (uint num = 0u; num < pCount; num++)
                {
                    ISpObjectToken ppToken = null;
                    ppEnum.Item(num, out ppToken);
                    ObjectToken item = ObjectToken.Open(ppToken);
                    list.Add(item);
                }
                return list;
            }
            finally
            {
                if (ppEnum != null)
                {
                    Marshal.ReleaseComObject(ppEnum);
                }
                if (spObjectTokenCategory != null)
                {
                    Marshal.ReleaseComObject(spObjectTokenCategory);
                }
            }
        }

        IEnumerator<ObjectToken> IEnumerable<ObjectToken>.GetEnumerator()
        {
            IList<ObjectToken> list = FindMatchingTokens(null, null);
            foreach (ObjectToken item in list)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<ObjectToken>)this).GetEnumerator();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}