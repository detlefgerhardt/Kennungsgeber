using System;
using System.Collections.Generic;

namespace Kennungsgeber.Languages
{
	public enum LngKeys
	{
		Invalid,


		ExistingAnswerbackCombs,
		Possible_Characters,
		PossibleAnswerbackCombs,
		ExistingAnswerbackText,
		FavoriteAnswerbackText,
		PossibleAnswerbackText,
		ShowControlCharacters,
		LoadButton,
		SaveButton,
		GenerateButton,
		CombsAdd,
		CombsInsert,
		CombsDelete,
		CombsUp,
		CombsDown,
		Help,
		Help_Explanation,
		Help_NormalCombs,
		Help_UnusedCombs,
		Help_MissingCombs,
		Help_ModifiedCombs,
		LanguageButton,
	}

	class Language
	{
		public string Key { get; set; }

		public string Version { get; set; }

		public string DisplayName { get; set; }

		public Dictionary<LngKeys, string> Items { get; set; }

		public Language()
		{
			Items = new Dictionary<LngKeys, string>();
		}

		public Language(string key, string displayName)
		{
			Key = key;
			DisplayName = displayName;
			Items = new Dictionary<LngKeys, string>();
		}

		public static LngKeys StringToLngKey(string keyStr)
		{
			if (Enum.TryParse(keyStr, true, out LngKeys lngKey))
			{
				return lngKey;
			}
			else
			{
				return LngKeys.Invalid;
			}
		}

		public override string ToString()
		{
			return $"{Key} {DisplayName} {Items?.Count}";
		}
	}
}
