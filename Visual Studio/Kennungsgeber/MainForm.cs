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

		public MainForm()
		{
			InitializeComponent();

			this.Text = Helper.GetVersion();

			KgOrg.Init(KgListView.KgType.Org, true);
			KgNew.Init(KgListView.KgType.New, false);

			KgOrg.Update += KgOrg_Update;

			Load(@"d:\t68_3.kg");
			//InitTestData();
			UpdateKgOrg();
			UpdateKgNew();
		}

		private void KgOrg_Update(List<CodeItem> codeList)
		{
			_orgCodeList = codeList;
			UpdateKgOrg();
		}

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

		/*
		private void SetCodeList(List<CodeItem> codeList)
		{
			if (codeList!=null)
			{
				_codeList = codeList;
			}
			else
			{
				_codeList = new List<CodeItem>();
			}
		}
		*/

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
				Load(openFileDialog.FileName);

				/*
				string filePath = openFileDialog.FileName;
				string fileContent = File.ReadAllText(filePath);
				SaveData saveData = Helper.Deserialize<SaveData>(fileContent);

				//saveData.InvOrgCode();

				_orgCodeList = saveData.OrgCodeList;
				//_orgCodeList.Sort(new CodeItemPosComparer());
				_newCodeList = saveData.NewCodeList;
				WunschKennungTb.Text = saveData.Wunschkennung;
				UpdateKgOrg();
				UpdateKgNew();
				*/
			}
		}

		private void Load(string fullName)
		{
			string fileContent = File.ReadAllText(fullName);
			SaveData saveData = Helper.Deserialize<SaveData>(fileContent);

			//saveData.InvOrgCode();

			_orgCodeList = saveData.OrgCodeList;
			//_orgCodeList.Sort(new CodeItemPosComparer());
			_newCodeList = saveData.NewCodeList;
			WunschKennungTb.Text = saveData.Wunschkennung;
			UpdateKgOrg();
			UpdateKgNew();
		}

		private void SaveBtn_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();

			saveFileDialog.Filter = "kg files (*.kg)|*.kg|All files (*.*)|*.*";
			saveFileDialog.FilterIndex = 1;
			saveFileDialog.RestoreDirectory = true;

			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				SaveData saveData = new SaveData();
				saveData.Wunschkennung = WunschKennungTb.Text;
				saveData.OrgCodeList = _orgCodeList;
				saveData.NewCodeList = _newCodeList;
				string fileContent = Helper.SerializeObject(saveData);
				File.WriteAllText(saveFileDialog.FileName, fileContent);
			}
		}

		private void IstKennungLbl_Click(object sender, EventArgs e)
		{

		}
	}
}
