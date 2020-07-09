using System.Collections.ObjectModel;
using System.Speech.Internal;

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
