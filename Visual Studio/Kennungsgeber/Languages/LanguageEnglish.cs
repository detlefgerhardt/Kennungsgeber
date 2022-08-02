using System.Collections.Generic;

namespace Kennungsgeber.Languages
{
	class LanguageEnglish
	{
		public static Language GetLng()
		{
			Language lng = new Language("en", "English");
			lng.Items = new Dictionary<LngKeys, string>
			{
				{ LngKeys.ExistingAnswerbackCombs, "Existing combs" },
				{ LngKeys.PossibleAnswerbackCombs, "Possible answerback combs" },
				{ LngKeys.ExistingAnswerbackText, "Existing answerback text" },
				{ LngKeys.FavoriteAnswerbackText, "Favorite answerback text" },
				{ LngKeys.PossibleAnswerbackText, "Possible answerback text from existing combs" },
				{ LngKeys.ShowControlCharacters, "Show control characters" },
				{ LngKeys.LoadButton, "Load" },
				{ LngKeys.SaveButton, "Save" },
				{ LngKeys.GenerateButton, "Generate" },
				// { LngKeys.CombsInsert, "Ins" },
				{ LngKeys.CombsInsert_ToolTip, "Insert a new comb" },
				// { LngKeys.CombsDelete, "Del" },
				{ LngKeys.CombsDelete_ToolTip, "Delete a comb" },
				// { LngKeys.CombsClear, "Clear" },
				{ LngKeys.CombsClear_ToolTip, "Delete all combs" },
				{ LngKeys.CombsHorizMirror_ToolTip, "Invert codes of all combs" },
				{ LngKeys.CombsVertMirror_ToolTip, "Invert order of combs" },
				// { LngKeys.CombsUp, "Up" },
				{ LngKeys.CombsUp_ToolTip, "Move comb up" },
				// { LngKeys.CombsDown, "Down" },
				{ LngKeys.CombsDown_ToolTip, "Move comb down" },
				{ LngKeys.TabColumnCombs_ToolTip, "Double click her to modify the comb" },
				{ LngKeys.TabColumnCode_ToolTip, "Baudot code" },
				{ LngKeys.TabColumnChr_ToolTip, "Baudot character" },
				{ LngKeys.TabColumnAlt_ToolTip, "Alternative baudot character" },
				{ LngKeys.TabHeader_PossibleCharacters, "Possible characters" },
				{ LngKeys.TabColumnPossibleCharacters_ToolTip, "All characters that can be created by modifying this comb" },
				{ LngKeys.TabColumnReference_ToolTip, "Reference to the original comb on the left side" },
				{ LngKeys.Help, "Help" },
				{ LngKeys.Help_Explanation, "Enter existing combs on the left side, enter your favorite answerback into the input field and press Generate. Or load existing answerback configuration." },
				{ LngKeys.Help_NormalCombs, "used combs" },
				{ LngKeys.Help_UnusedCombs, "not used combs" },
				{ LngKeys.Help_MissingCombs, "missing combs" },
				{ LngKeys.Help_ModifiedCombs, "modified combs" },
				{ LngKeys.Load_Error, "Error loading" },
				{ LngKeys.Save_Caption, "Save" },
				{ LngKeys.Save_Message, "Last changes were not saved. Save now?" },
				{ LngKeys.Save_Error, "Error saving" },
				{ LngKeys.DeleteAllCombs_Caption, "Delete" },
				{ LngKeys.DeleteAllCombs_Message, "Do you really want to delete all combs?" },
				{ LngKeys.OverwriteAllCombs_Caption, "overwrite" },
				{ LngKeys.OverwriteAllCombs_Message, "Do you really want to overwrite all existing combs?" },
				{ LngKeys.LanguageButton, "Deutsch" },
			};

			return lng;
		}
	}
}
