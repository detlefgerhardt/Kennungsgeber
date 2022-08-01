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
				{ LngKeys.Possible_Characters, "Possible characters" },
				{ LngKeys.PossibleAnswerbackCombs, "Possible answerback combs" },
				{ LngKeys.ExistingAnswerbackText, "Existing answerback text" },
				{ LngKeys.FavoriteAnswerbackText, "Favorite answerback text" },
				{ LngKeys.PossibleAnswerbackText, "Possible answerback text from existing combs" },
				{ LngKeys.ShowControlCharacters, "Show control characters" },
				{ LngKeys.LoadButton, "Load" },
				{ LngKeys.SaveButton, "Save" },
				{ LngKeys.GenerateButton, "Generate" },
				{ LngKeys.CombsAdd, "Add" },
				{ LngKeys.CombsInsert, "Ins" },
				{ LngKeys.CombsDelete, "Del" },
				{ LngKeys.CombsUp, "Up" },
				{ LngKeys.CombsDown, "Down" },
				{ LngKeys.Help, "Help" },
				{ LngKeys.Help_Explanation, "Enter existing combs on the left side, enter your favorite answerback into the input field and press Generate. Or load existing answerback configuration." },
				{ LngKeys.Help_NormalCombs, "used combs" },
				{ LngKeys.Help_UnusedCombs, "not used combs" },
				{ LngKeys.Help_MissingCombs, "missing combs" },
				{ LngKeys.Help_ModifiedCombs, "modified combs" },
				{ LngKeys.LanguageButton, "Deutsch" },
			};

			return lng;
		}
	}
}
