#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop;

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