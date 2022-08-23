using System;
using System.Collections.Generic;

namespace Kennungsgeber.Languages
{
	public enum LngKeys
	{
		Invalid,


		ExistingAnswerbackCombs,
		TabHeader_PossibleCharacters,
		PossibleAnswerbackCombs,
		ExistingAnswerbackText,
		FavoriteAnswerbackText,
		PossibleAnswerbackText,
		ShowControlCharacters,
		LoadButton,
		SaveButton,
		GenerateButton,
		//CombsInsert,
		CombsInsert_ToolTip,
		//CombsDelete,
		CombsDelete_ToolTip,
		//CombsClear,
		CombsClear_ToolTip,
		CombsHorizMirror_ToolTip,
		CombsVertMirror_ToolTip,
		// CombsUp,
		CombsUp_ToolTip,
		// CombsDown,
		CombsDown_ToolTip,
		TabColumnCombs_ToolTip,
		TabColumnCode_ToolTip,
		TabColumnChr_ToolTip,
		TabColumnAlt_ToolTip,
		TabColumnPossibleCharacters_ToolTip,
		TabColumnReference_ToolTip,
		Help,
		Help_Explanation,
		Help_NormalCombs,
		Help_UnusedCombs,
		Help_MissingCombs,
		Help_ModifiedCombs,
		Load_Error,
		Save_Caption,
		Save_Message,
		Save_Error,
		DeleteAllCombs_Caption,
		DeleteAllCombs_Message,
		OverwriteAllCombs_Caption,
		OverwriteAllCombs_Message,
		LanguageButton,
		SaveTextCreatedWith,
		SaveTextExplanation,
		SaveTextExistingCombs,
		SaveTextFavoriteAnswerbackText,
		SaveTextPossibleAnswerbackText,
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
