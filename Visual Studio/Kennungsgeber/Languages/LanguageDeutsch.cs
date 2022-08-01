using System.Collections.Generic;

namespace Kennungsgeber.Languages
{
	class LanguageDeutsch
	{
		public static Language GetLng()
		{
			Language lng = new Language("de", "Deutsch");
			lng.Items = new Dictionary<LngKeys, string>
			{
				{ LngKeys.ExistingAnswerbackCombs, "Vorhandene Kämme" },
				{ LngKeys.Possible_Characters, "Mögliche Zeichen" },
				{ LngKeys.PossibleAnswerbackCombs, "Mögliche Kennungsgeber-Kämme" },
				{ LngKeys.ExistingAnswerbackText, "Bestehender Kennungsgeber-Text" },
				{ LngKeys.FavoriteAnswerbackText, "Gewünschter Kennungsgeber-Text" },
				{ LngKeys.PossibleAnswerbackText, "Möglicher Kennungsgeber-Text aus vorhandenen Kämmen" },
				{ LngKeys.ShowControlCharacters, "Zeige Sonderzeichen" },
				{ LngKeys.LoadButton, "Laden" },
				{ LngKeys.SaveButton, "Speichern" },
				{ LngKeys.GenerateButton, "Erzeugen" },
				{ LngKeys.CombsAdd, "Add" },
				{ LngKeys.CombsInsert, "Ins" },
				{ LngKeys.CombsDelete, "Del" },
				{ LngKeys.CombsUp, "Hoch" },
				{ LngKeys.CombsDown, "Runter" },
				{ LngKeys.Help, "Hilfe" },
				{ LngKeys.Help_Explanation, "Existierende Kämme auf der linken Seite eingeben (\"Add\"), Wunschkennzeichen im Eingabefeld eingeben und auf Erzeugen klicken. Oder vorhandene Konfiguration laden.\r\n" +
					"Ändern der Kämme durch Doppelklick auf die Laschen."
				},
				{ LngKeys.Help_NormalCombs, "verwendete Kämme" },
				{ LngKeys.Help_UnusedCombs, "nicht verwendete Kämme" },
				{ LngKeys.Help_MissingCombs, "fehlende Kämme" },
				{ LngKeys.Help_ModifiedCombs, "geänderte Kämme" },
				{ LngKeys.LanguageButton, "English" },
			};

			return lng;
		}
	}
}
