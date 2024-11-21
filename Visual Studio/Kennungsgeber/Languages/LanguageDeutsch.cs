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
				{ LngKeys.ExistingAnswerbackCombs, "Vorhandene Kämme (ändern mit Doppelklick auf die Zähne)" },
				{ LngKeys.PossibleAnswerbackCombs, "Mögliche Kennungsgeber-Kämme" },
				{ LngKeys.ExistingAnswerbackText, "Bestehender Kennungsgeber-Text" },
				{ LngKeys.FavoriteAnswerbackText, "Gewünschter Kennungsgeber-Text" },
				{ LngKeys.PossibleAnswerbackText, "Möglicher Kennungsgeber-Text aus vorhandenen Kämmen" },
				{ LngKeys.ShowControlCharacters, "Zeige Sonderzeichen" },
				{ LngKeys.LoadButton, "Laden" },
				{ LngKeys.SaveButton, "Speichern" },
				{ LngKeys.SaveAsTextButton, "Text speichern" },
				{ LngKeys.GenerateButton, "Erzeugen" },
				// { LngKeys.CombsInsert, "Einf." },
				{ LngKeys.CombsInsert_ToolTip, "Einen neuen Kamm einfügen" },
				// { LngKeys.CombsDelete, "Entf." },
				{ LngKeys.CombsDelete_ToolTip, "Einen Kamm entfernen" },
				// { LngKeys.CombsClear, "Clear" },
				{ LngKeys.CombsClear_ToolTip, "Alle Kämme löschen" },
				{ LngKeys.CombsHorizMirror_ToolTip, "Codes aller Kämme spiegeln" },
				{ LngKeys.CombsVertMirror_ToolTip, "Reihenfolge der Kämme spiegeln" },
				// { LngKeys.CombsUp, "Hoch" },
				{ LngKeys.CombsUp_ToolTip, "Kamm nach oben schieben" },
				// { LngKeys.CombsDown, "Runter" },
				{ LngKeys.CombsDown_ToolTip, "Kamm nach unten schieben" },
				{ LngKeys.TabColumnCombs_ToolTip, "Hier doppelklicken um den Kamm zu ändern" },
				{ LngKeys.TabColumnCode_ToolTip, "Baudot-Code" },
				{ LngKeys.TabColumnChr_ToolTip, "Baudot-Zeichen" },
				{ LngKeys.TabColumnAlt_ToolTip, "Alternatives Baudot-Zeichen" },
				{ LngKeys.TabHeader_PossibleCharacters, "Mögliche Zeichen" },
				{ LngKeys.TabColumnPossibleCharacters_ToolTip, "Alle durch Modifikationen dieses Kamms erzeugbaren Zeichen" },
				{ LngKeys.TabColumnReference_ToolTip, "Verweis auf den Original-Kamm auf der linken Seite" },
				{ LngKeys.Help, "Hilfe" },
				{ LngKeys.Help_Explanation, "Existierende Kämme auf der linken Seite eingeben, Wunschkennzeichen im Eingabefeld eingeben und auf Erzeugen klicken. Oder vorhandene Konfiguration laden.\r\n" +
					"Ändern der Kämme durch Doppelklick auf die Zähne."
				},
				{ LngKeys.Help_NormalCombs, "verwendete Kämme" },
				{ LngKeys.Help_UnusedCombs, "(noch) nicht verwendete Kämme" },
				{ LngKeys.Help_MissingCombs, "fehlende Kämme" },
				{ LngKeys.Help_ModifiedCombs, "geänderte Kämme" },
				{ LngKeys.Load_Error, "Fehler beim Laden von" },
				{ LngKeys.Save_Caption, "Speichern" },
				{ LngKeys.Save_Message, "Die letzten Änderungen wurden nicht gespeichert. Jetzt speichern?" },
				{ LngKeys.Save_Error, "Fehler beim Speichern von" },
				{ LngKeys.DeleteAllCombs_Caption, "Löschen" },
				{ LngKeys.DeleteAllCombs_Message, "Wirklich alle Kämme löschen?" },
				{ LngKeys.OverwriteAllCombs_Caption, "Überschreiben" },
				{ LngKeys.OverwriteAllCombs_Message, "Wirklich alle vorhandenen Kämme überschreiben?" },
				{ LngKeys.LanguageButton, "English" },

				{ LngKeys.SaveTextCreatedWith, "erzeugt mit" },
				{ LngKeys.SaveTextExplanation, "+ = kamm vorhanden, . = kamm entfernt" },
				{ LngKeys.SaveTextExistingCombs, "vorhandene kaemme" },
				{ LngKeys.SaveTextFavoriteAnswerbackText, "gewuenschter kennungsgeber-text" },
				{ LngKeys.SaveTextPossibleAnswerbackText, "moeglicher Kennungsgeber-Text" },
			};

			return lng;
		}
	}
}
