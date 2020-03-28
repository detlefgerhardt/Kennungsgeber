using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kennungsgeber
{
	class ModCheckItem
	{
		public string Char { get; set; }

		public int ModCount { get; set; }

		public ModCheckItem(string chr, int modCount)
		{
			Char = chr;
			ModCount = modCount;
		}

		public override string ToString()
		{
			return $"{Char} {ModCount}";
		}
	}

	class ModCheckItemComparer : IComparer<ModCheckItem>
	{
		public int Compare(ModCheckItem x, ModCheckItem y)
		{
			// sort ascending
			return x.ModCount.CompareTo(y.ModCount);
		}
	}
}
