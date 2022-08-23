using Kennungsgeber.Languages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Kennungsgeber
{
	public partial class MainForm : Form
	{
		private const string TAG = nameof(MainForm);

		private List<CodeItem> _orgCodeList;
		private List<CodeItem> _newCodeList;
		private bool _changed;
		private bool _enterOrgKgByTest;

		public MainForm()
		{
			InitializeComponent();

			Logging.Instance.LogfilePath = Helper.GetExePath();

			this.Text = Helper.GetVersion();

			ToRightBtn.Visible = false;
			ToLeftBtn.Visible = false;

			OrgAnswerbackKgList.Init(KgListView.KgType.Org, true);
			PossibleAnswerbackKgList.Init(KgListView.KgType.New, false);

			OrgAnswerbackKgList.Changed += KgOrg_Changed;
			PossibleAnswerbackKgList.Changed += KgNew_Changed; ;

			LanguageManager.Instance.LanguageChanged += LanguageChanged;
			LanguageManager.Instance.ChangeLanguage(Constants.DEFAULT_LANGUAGE);

			//InitTestData();
			InitKgOrg();
			UpdateKgOrg();
			UpdateKgNew();

			_changed = false;
			_enterOrgKgByTest = false;
			OrgAnswerbackTextTb.Enabled = true;
			OrgAnswerbackTextTb.ReadOnly = true;

			SetExplanationPanel();

		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			ActiveControl = FavoriteAnswerbackTextTb;
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			//_log.Info(TAG, nameof(MainForm_FormClosing), $"close");
			if (_changed)
			{
				DialogResult result = MessageBox.Show(
					LngText(LngKeys.Save_Message),
					LngText(LngKeys.Save_Caption),
					MessageBoxButtons.YesNoCancel,
					MessageBoxIcon.Information,
					MessageBoxDefaultButton.Button3);

				//_log.Info(TAG, nameof(MainForm_FormClosing), $"save answer={result}");

				switch (result)
				{
					case DialogResult.Yes:
						if (!SaveFile())
						{
							e.Cancel = true;
						}
						break;
					case DialogResult.No:
						break;
					case DialogResult.Cancel:
						e.Cancel = true;
						break;
				}
			}

		}

		private void LoadFile(string fullName)
		{
			try
			{
				string fileContent = File.ReadAllText(fullName);
				SaveData saveData = Helper.Deserialize<SaveData>(fileContent);
				_orgCodeList = saveData.OrgCodeList;
				//_orgCodeList.Sort(new CodeItemPosComparer());
				_newCodeList = saveData.NewCodeList;
				FavoriteAnswerbackTextTb.Text = saveData.Wunschkennung;
				UpdateKgOrg();
				UpdateKgNew();
				_changed = false;
			}
			catch (Exception)
			{
				ShowError($"{LngText(LngKeys.Load_Error)} {fullName}");
			}

			//saveData.InvOrgCode();
		}

		private void SaveBtn_Click(object sender, EventArgs e)
		{
			SaveFile();
		}

		private bool SaveFile()
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "kg files (*.kg)|*.kg|All files (*.*)|*.*";
			saveFileDialog.FilterIndex = 1;
			saveFileDialog.RestoreDirectory = true;

			if (saveFileDialog.ShowDialog() != DialogResult.OK)
			{
				return false;
			}

			SaveData saveData = new SaveData();
			saveData.Wunschkennung = FavoriteAnswerbackTextTb.Text;
			saveData.OrgCodeList = _orgCodeList;
			saveData.NewCodeList = _newCodeList;

			try
			{
				string fileContent = Helper.SerializeObject(saveData);
				File.WriteAllText(saveFileDialog.FileName, fileContent);
				_changed = false;
				return true;
			}
			catch (Exception)
			{
				ShowError($"{LngText(LngKeys.Save_Error)} {saveFileDialog.FileName}");
				return false;
			}
		}

		private void GenerateBtn_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(FavoriteAnswerbackTextTb.Text)) return;
			FavoriteAnswerbackTextTb.Text = FindKennung.CleanCode(FavoriteAnswerbackTextTb.Text);
			_newCodeList = FindKennung.Find(FavoriteAnswerbackTextTb.Text, _orgCodeList);
			UpdateKgOrg();
			UpdateKgNew();
		}

		private void KgOrg_Changed(List<CodeItem> codeList)
		{
			_changed = true;
			_orgCodeList = codeList;
			SetOrgKennung();
		}

		private void KgNew_Changed(List<CodeItem> codeList)
		{
			_changed = true;
			_newCodeList = codeList;
			SetNewKennung();
		}

		private void FavoriteAnswerbackTextTb_TextChanged(object sender, EventArgs e)
		{
			_changed = true;
		}

		private void ShowControlCharactersCb_Click(object sender, EventArgs e)
		{
			SetOrgKennung();
			SetNewKennung();
		}

		private void InitKgOrg()
		{
			_orgCodeList = new List<CodeItem>();
			for (int i=0; i<20; i++)
			{
				_orgCodeList.Add(new CodeItem(0x00));
			}

			for (int i = 0; i < _orgCodeList.Count; i++)
			{
				_orgCodeList[i].OrgPositon = i;
			}
		}

		private void UpdateKgOrg()
		{
			if (_orgCodeList == null)
			{
				_orgCodeList = new List<CodeItem>();
			}
			OrgAnswerbackKgList.SetCodeList(_orgCodeList);
			SetOrgKennung();
		}

		private void UpdateKgNew()
		{
			if (_newCodeList == null)
			{
				_newCodeList = new List<CodeItem>();
			}
			PossibleAnswerbackKgList.SetCodeList(_newCodeList);
			SetNewKennung();
		}

		private void SetOrgKennung()
		{
			string kenn = "";
			ShiftState shiftState = ShiftState.Letters;
			for (int i = 0; i < _orgCodeList.Count; i++)
			{
				string chr = _orgCodeList[i].GetCharText(ref shiftState, ShowControlCharactersCb.Checked);
				kenn += chr;
			}
			OrgAnswerbackTextTb.Text = kenn;
		}

		private void SetNewKennung()
		{
			string kenn = "";
			ShiftState shiftState = ShiftState.Letters;
			for (int i = 0; i < _newCodeList.Count; i++)
			{
				if (_newCodeList[i].Reference != null)
				{
					string chr = _newCodeList[i].GetCharText(ref shiftState, ShowControlCharactersCb.Checked);
					kenn += chr;
				}
			}
			PossibleAnswerbackTextTb.Text = kenn;
		}

		private void LoadBtn_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			//openFileDialog.InitialDirectory = "c:\\";
			openFileDialog.Filter = "kg files (*.kg)|*.kg|All files (*.*)|*.*";
			openFileDialog.FilterIndex = 1;
			openFileDialog.RestoreDirectory = true;

			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				//Get the path of specified file
				LoadFile(openFileDialog.FileName);
			}
		}

		private void ShowError(string text)
		{
			MessageBox.Show(
				text,
				$"Error",
				MessageBoxButtons.OK,
				MessageBoxIcon.Error,
				MessageBoxDefaultButton.Button1);
		}

		private void ToRightBtn_Click(object sender, EventArgs e)
		{
		}

		public void SetExplanationPanel()
		{
			ExplanationGb.Controls.Clear();

			Label label = new Label();
			label.Text = LngText(LngKeys.Help_Explanation);
			label.Location = new Point(10, 20);
			label.AutoSize = false;
			label.Width = ExplanationGb.Width - 20;
			label.Height = 70;
			label.TextAlign = ContentAlignment.TopLeft;
			label.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			ExplanationGb.Controls.Add(label);

			int top = 100;
			ExplanationGb.Controls.Add(GetNibPanel(10, top, KgListView.NibImageNormal, LngText(LngKeys.Help_NormalCombs)));
			ExplanationGb.Controls.Add(GetNibPanel(10, top+20, KgListView.NibImageUnused, LngText(LngKeys.Help_UnusedCombs)));
			ExplanationGb.Controls.Add(GetNibPanel(10, top+40, KgListView.NibImageMissing, LngText(LngKeys.Help_MissingCombs)));
			ExplanationGb.Controls.Add(GetNibPanel(10, top+60, KgListView.NoNibImageRemove, LngText(LngKeys.Help_ModifiedCombs)));
		}

		public Panel GetNibPanel(int x, int y, Bitmap nibImg, string text)
		{
			Panel panel = new Panel();

			PictureBox pb = new PictureBox();
			pb.Image = new Bitmap(nibImg, new Size(15, 15));
			pb.Location = new Point(0, 0);
			pb.Width = pb.Image.Width;
			pb.Height = pb.Image.Height;
			panel.Controls.Add(pb);

			Label label = new Label();
			label.Text = text;
			label.Location = new Point(20, 0);
			label.AutoSize = true;
			label.Height = 13;
			label.TextAlign = ContentAlignment.MiddleLeft;
			panel.Controls.Add(label);

			panel.Location = new Point(x, y);
			panel.Height = 19;
			return panel;
		}

		private void LanguageChanged()
		{
			Logging.Instance.Log(LogTypes.Info, TAG, nameof(LanguageChanged), $"switch language to {LanguageManager.Instance.CurrentLanguage.Key}");

			OrgAnswerbackCombsLbl.Text = LngText(LngKeys.ExistingAnswerbackCombs) + ":";
			PossibleAnswerbackCombsLbl.Text = LngText(LngKeys.PossibleAnswerbackCombs) + ":";
			OrgAnswerbackTextLbl.Text = LngText(LngKeys.ExistingAnswerbackText) + ":";
			FavoriteAnswerbackTextLbl.Text = LngText(LngKeys.FavoriteAnswerbackText) + ":";
			PossibleAnswerbackTextLbl.Text = LngText(LngKeys.PossibleAnswerbackText) + ":";
			ShowControlCharactersCb.Text = LngText(LngKeys.ShowControlCharacters);
			LoadBtn.Text = LngText(LngKeys.LoadButton);
			SaveBtn.Text = LngText(LngKeys.SaveButton);
			GenerateBtn.Text = LngText(LngKeys.GenerateButton);
			ExplanationGb.Text = LngText(LngKeys.Help);
			LanguageBtn.Text = LngText(LngKeys.LanguageButton);

			SetExplanationPanel();
		}

		private string LngText(LngKeys key)
		{
			return LanguageManager.Instance.GetText(key);
		}

		private void LanguageBtn_Click(object sender, EventArgs e)
		{
			if (LanguageManager.Instance.CurrentLanguage.Key == "de")
			{
				LanguageManager.Instance.ChangeLanguage("en");
				LanguageBtn.Text = "Deutsch";
			}
			else
			{
				LanguageManager.Instance.ChangeLanguage("de");
				LanguageBtn.Text = "English";
			}
		}

		private void OrgAnswerbackTextTb_DoubleClick(object sender, EventArgs e)
		{
			if (_enterOrgKgByTest) return; // already active

			_enterOrgKgByTest = true;
			OrgAnswerbackTextTb.ReadOnly = false;
		}

		private void OrgAnswerbackTextTb_Leave(object sender, EventArgs e)
		{
			if (!_enterOrgKgByTest) return; // not active, can this happen?

			DialogResult result = MessageBox.Show(
				LngText(LngKeys.OverwriteAllCombs_Message),
				LngText(LngKeys.OverwriteAllCombs_Caption),
				MessageBoxButtons.OKCancel,
				MessageBoxIcon.Information,
				MessageBoxDefaultButton.Button2);

			if (result != DialogResult.OK)
			{
				SetOrgKennung();
			}
			else
			{
				// create original combs from answer back text
				OrgAnswerbackTextTb.Text = FindKennung.CleanCode(OrgAnswerbackTextTb.Text);
				_orgCodeList = FindKennung.ConvertToCodeList(OrgAnswerbackTextTb.Text);
				UpdateKgOrg();
				_changed = true;
			}

			_enterOrgKgByTest = false;
			OrgAnswerbackTextTb.ReadOnly = true;
		}

		private void SaveAsTextBtn_Click(object sender, EventArgs e)
		{
			string line = new string('-', 68);
			StringBuilder sb = new StringBuilder();
			sb.AppendLine(line);
			sb.AppendLine($"{LngText(LngKeys.SaveTextCreatedWith)} {Helper.GetVersion().ToLower()}");
			sb.AppendLine(line);
			sb.AppendLine("");
			sb.AppendLine(LngText(LngKeys.SaveTextExplanation));
			sb.AppendLine("");
			sb.AppendLine($"{LngText(LngKeys.SaveTextExistingCombs)}:");
			sb.AppendLine("");
			AddCodeListAsText(sb, _orgCodeList);
			sb.AppendLine("");
			sb.AppendLine(line);
			sb.AppendLine("");
			sb.AppendLine($"{LngText(LngKeys.SaveTextFavoriteAnswerbackText)}: {FavoriteAnswerbackTextTb.Text}");
			sb.AppendLine("");
			sb.AppendLine($"{LngText(LngKeys.SaveTextPossibleAnswerbackText)}: {PossibleAnswerbackTextTb.Text}");
			sb.AppendLine("");
			AddCodeListAsText(sb, _newCodeList);
			sb.AppendLine("");
			sb.AppendLine(line);

			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "text files (*.txt)|*.txt|All files (*.*)|*.*";
			saveFileDialog.FilterIndex = 1;
			saveFileDialog.RestoreDirectory = true;

			if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

			try
			{
				File.WriteAllText(saveFileDialog.FileName, sb.ToString());
			}
			catch(Exception ex)
			{
			}
		}

		private void AddCodeListAsText(StringBuilder sb, List<CodeItem> codeList)
		{
			sb.AppendLine("     1 2 3 4 5");
			int idx = 1;
			foreach (CodeItem codeItem in codeList)
			{
				sb.AppendLine($"  {idx:D02} {CodeItem.CodeToString(codeItem.CodeArray, "+", ".", " ")}");
				idx++;
			}
		}
	}
}
