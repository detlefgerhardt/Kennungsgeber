using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Kennungsgeber
{
	public partial class MainForm : Form
	{
		private List<CodeItem> _orgCodeList;
		private List<CodeItem> _newCodeList;
		private bool _changed;

		public MainForm()
		{
			InitializeComponent();

			this.Text = Helper.GetVersion();

			KgOrg.Init(KgListView.KgType.Org, true);
			KgNew.Init(KgListView.KgType.New, false);

			KgOrg.Changed += KgOrg_Changed;
			KgNew.Changed += KgNew_Changed; ;

			//InitTestData();
			UpdateKgOrg();
			UpdateKgNew();

			_changed = false;
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			//_log.Info(TAG, nameof(MainForm_FormClosing), $"close");
			if (_changed)
			{
				DialogResult result = MessageBox.Show(
					"Last changeds were not saved. Save now?",
					$"Save",
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

		private void GenWunschKennungBtn_Click(object sender, EventArgs e)
		{
			string wk = WunschKennungTb.Text;
			if (string.IsNullOrWhiteSpace(wk))
			{
				return;
			}

			FindKennung find = new FindKennung();
			_newCodeList = find.Find(wk, _orgCodeList);
			UpdateKgNew();
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
				WunschKennungTb.Text = saveData.Wunschkennung;
				UpdateKgOrg();
				UpdateKgNew();
				_changed = false;
			}
			catch (Exception)
			{
				ShowError($"Error reading {fullName}");
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
			saveData.Wunschkennung = WunschKennungTb.Text;
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
				ShowError($"Error writing {saveFileDialog.FileName}");
				return false;
			}
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

		private void WunschKennungTb_TextChanged(object sender, EventArgs e)
		{
			_changed = true;
		}

		/*
		private void InitTestData()
		{
			_orgCodeList = new List<CodeItem>();

			_orgCodeList.Add(new CodeItem(0x1F));
			_orgCodeList.Add(new CodeItem(0x08));
			_orgCodeList.Add(new CodeItem(0x02));
			_orgCodeList.Add(new CodeItem(0x08));
			_orgCodeList.Add(new CodeItem(0x13));
			_orgCodeList.Add(new CodeItem(0x0A));
			_orgCodeList.Add(new CodeItem(0x0A));
			_orgCodeList.Add(new CodeItem(0x02));
			_orgCodeList.Add(new CodeItem(0x16));
			_orgCodeList.Add(new CodeItem(0x04));
			_orgCodeList.Add(new CodeItem(0x1F));
			_orgCodeList.Add(new CodeItem(0x0D));
			_orgCodeList.Add(new CodeItem(0x03));
			_orgCodeList.Add(new CodeItem(0x0E));
			_orgCodeList.Add(new CodeItem(0x0A));
			_orgCodeList.Add(new CodeItem(0x00));
			_orgCodeList.Add(new CodeItem(0x08));
			_orgCodeList.Add(new CodeItem(0x0F));
			_orgCodeList.Add(new CodeItem(0x1F));
			_orgCodeList.Add(new CodeItem(0x00));
			_orgCodeList.Add(new CodeItem(0x1F));

			for (int i = 0; i < _orgCodeList.Count; i++)
			{
				_orgCodeList[i].OrgPositon = i;
			}
		}
		*/

		private void UpdateKgOrg()
		{
			if (_orgCodeList == null)
			{
				_orgCodeList = new List<CodeItem>();
			}
			KgOrg.SetCodeList(_orgCodeList);
			SetOrgKennung();
		}

		private void UpdateKgNew()
		{
			if (_newCodeList == null)
			{
				_newCodeList = new List<CodeItem>();
			}
			KgNew.SetCodeList(_newCodeList);
			SetNewKennung();
		}

		private void SetOrgKennung()
		{
			string kenn = "";
			ShiftState shiftState = ShiftState.Letters;
			for (int i = 0; i < _orgCodeList.Count; i++)
			{
				string chr = _orgCodeList[i].GetCharText(ref shiftState);
				kenn += chr;
			}
			OrgKennungTb.Text = kenn;
		}

		private void SetNewKennung()
		{
			string kenn = "";
			ShiftState shiftState = ShiftState.Letters;
			for (int i = 0; i < _newCodeList.Count; i++)
			{
				if (_newCodeList[i].Reference != null)
				{
					string chr = _newCodeList[i].GetCharText(ref shiftState);
					kenn += chr;
				}
			}
			NewKennungTb.Text = kenn;
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

	}
}
