using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Kennungsgeber.Languages;

namespace Kennungsgeber
{
	public partial class KgListView : UserControl
	{
		public enum KgType { Org, New };

		public enum ItemType { Normal, OrgNotUsed, NewMissing }

		private Color ColorNormal = Color.Black;
		private Color ColorNotUsed = Color.LightGray;
		private Color ColorMissing = Color.Orange;
		private Color ColorRemove = Color.Red;

		private List<CodeItem> _codeList;

		public static Bitmap NibImageNormal;
		public static Bitmap NibImageUnused;
		public static Bitmap NibImageMissing;
		public static Bitmap NoNibImageNormal;
		public static Bitmap NoNibImageUnused;
		public static Bitmap NoNibImageRemove;
		public static Bitmap NoNibImageMissing;

		private int _kgSelectedIndex = -1;

		private KgType _kgType;

		public delegate void UpdateEventHandler(List<CodeItem> codeList);
		public event UpdateEventHandler Changed;

		private bool _showSwapButtons;
		public bool ShowSwapButtons
		{
			set
			{
				_showSwapButtons = value;
				if (_showSwapButtons)
				{
					SwapHorizBtn.Text = "\u2194";
					//SwapHorizBtn.Text = "\u2B64";
					SwapHorizBtn.Font = new Font("Arial Unicode MS", 12, FontStyle.Regular);
					SwapVertBtn.Text = "\u2195";
					SwapVertBtn.Font = new Font("Arial Unicode MS", 12, FontStyle.Regular);
				}
				else
				{
					SwapHorizBtn.Visible = false;
					SwapVertBtn.Visible = false; ;
				}
			}
		}

		public KgListView()
		{
			InitializeComponent();
		}

		public void Init(KgType kgType, bool showSwapButtons)
		{
			_kgType = kgType;

			ShowSwapButtons = showSwapButtons;

			InsBtn.Text = "\u227B\u2261";
			//InsBtn.Text = "\u2945";
			InsBtn.Font = new Font("Arial Unicode MS", 12, FontStyle.Regular);

			DelBtn.Text = "\u2BBD";
			DelBtn.Font = new Font("Arial Unicode MS", 12, FontStyle.Regular);

			ClearBtn.Text = "\u2BBD\u2BBD\u2BBD";
			ClearBtn.Font = new Font("Arial Unicode MS", 10, FontStyle.Regular);

			UpBtn.Text = "\u2191";
			UpBtn.Font = new Font("Arial Unicode MS", 12, FontStyle.Bold);

			DownBtn.Text = "\u2193";
			DownBtn.Font = new Font("Arial Unicode MS", 12, FontStyle.Bold);

			KgView.MultiSelect = false;
			KgView.BackgroundColor = Color.White;
			KgView.RowHeadersVisible = false;
			KgView.ScrollBars = ScrollBars.Vertical;
			//KgView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			KgView.AllowUserToAddRows = false;
			KgView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			KgView.ShowCellToolTips = true;

			var countCol = new DataGridViewTextBoxColumn
			{
				Name = "count",
				HeaderText = "#",
				Width = 25
			};
			KgView.Columns.Add(countCol);

			for (int i = 0; i < 5; i++)
			{
				var imgCol = new DataGridViewImageColumn();
				imgCol.Name = $"code{i + 1}";
				imgCol.HeaderText = $"{i + 1}";
				imgCol.Width = 20;
				KgView.Columns.Add(imgCol);
			}

			var codeCol = new DataGridViewTextBoxColumn
			{
				Name = "code",
				HeaderText = "Cod",
				Width = 30
			};
			KgView.Columns.Add(codeCol);

			var charCol = new DataGridViewTextBoxColumn
			{
				Name = "char",
				HeaderText = "Chr",
				Width = 34
			};
			KgView.Columns.Add(charCol);

			if (kgType == KgType.Org)
			{
				var altCharCol = new DataGridViewTextBoxColumn
				{
					Name = "altchar",
					HeaderText = "Alt",
					Width = 34
				};
				KgView.Columns.Add(altCharCol);

				var modCharCol = new DataGridViewTextBoxColumn
				{
					Name = "modchar",
					HeaderText = "possible Characters",
					Width = 174
				};
				KgView.Columns.Add(modCharCol);
				this.Width = 400;
			}
			else
			{
				var altCharCol = new DataGridViewTextBoxColumn
				{
					Name = "oldPos",
					HeaderText = "Ref",
					Width = 34
				};
				KgView.Columns.Add(altCharCol);

				this.Width = 225;

				ClearBtn.Visible = false;
				ClearBtn.Enabled = false;
			}

			_kgSelectedIndex = 0;

			LanguageManager.Instance.LanguageChanged += LanguageChanged;
			LanguageManager.Instance.ChangeLanguage(Constants.DEFAULT_LANGUAGE);

			NoNibImageNormal = GetImage(ColorNormal, false, false);
			NoNibImageUnused = GetImage(ColorNotUsed, false, false);
			NoNibImageMissing = GetImage(ColorMissing, false, false);
			NoNibImageRemove = GetImage(ColorRemove, true, true);
			NibImageNormal = GetImage(ColorNormal, true, false);
			NibImageUnused = GetImage(ColorNotUsed, true, false);
			NibImageMissing = GetImage(ColorMissing, true, false);
		}

		private void LanguageChanged()
		{
			//Logging.Instance.Log(LogTypes.Info, TAG, nameof(LanguageChanged), $"switch language to {LanguageManager.Instance.CurrentLanguage.Key}");
			if (_kgType == KgType.Org)
			{
				KgView.Columns[9].HeaderText = LngText(LngKeys.TabHeader_PossibleCharacters);
			}
			else
			{
				//KgView.Columns[8].HeaderText = LngText(LngKeys.Possible_Characters);
			}

			//InsBtn.Text = LngText(LngKeys.CombsInsert);
			Helper.SetToolTip(InsBtn, LngText(LngKeys.CombsInsert_ToolTip));
			//DelBtn.Text = LngText(LngKeys.CombsDelete);
			Helper.SetToolTip(DelBtn, LngText(LngKeys.CombsDelete_ToolTip));
			//ClearBtn.Text = LngText(LngKeys.CombsClear);
			Helper.SetToolTip(ClearBtn, LngText(LngKeys.CombsClear_ToolTip));
			Helper.SetToolTip(SwapHorizBtn, LngText(LngKeys.CombsHorizMirror_ToolTip));
			Helper.SetToolTip(SwapVertBtn, LngText(LngKeys.CombsVertMirror_ToolTip));
			//UpBtn.Text = LngText(LngKeys.CombsUp);
			Helper.SetToolTip(UpBtn, LngText(LngKeys.CombsUp_ToolTip));
			//DownBtn.Text = LngText(LngKeys.CombsDown);
			Helper.SetToolTip(DownBtn, LngText(LngKeys.CombsDown_ToolTip));

			// update tooltips
			UpdateKg();
		}

		private string LngText(LngKeys key)
		{
			return LanguageManager.Instance.GetText(key);
		}

		public void SetCodeList(List<CodeItem> codeList)
		{
			_codeList = codeList;
			if (_codeList == null)
			{
				_codeList = new List<CodeItem>();
			}
			_kgSelectedIndex = 0;

			UpdateKg();
		}

		private void ClearBtn_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show(
				LngText(LngKeys.DeleteAllCombs_Message),
				LngText(LngKeys.DeleteAllCombs_Caption),
				MessageBoxButtons.OKCancel,
				MessageBoxIcon.Warning,
				MessageBoxDefaultButton.Button2);

			if (result != DialogResult.OK) return;

			_codeList.Clear();
			_kgSelectedIndex = -1;
			UpdateKg();
			Changed?.Invoke(_codeList);

			//_codeList.Add(new CodeItem(0x00));
			//_kgSelectedIndex = _codeList.Count - 1;
			//UpdateKg();
			//Changed?.Invoke(_codeList);
		}

		private void InsBtn_Click(object sender, EventArgs e)
		{
			if (_kgSelectedIndex == -1) _kgSelectedIndex = 0;

			_codeList.Insert(_kgSelectedIndex, new CodeItem(0x00));
			UpdateKg();
			Changed?.Invoke(_codeList);
		}

		private void DelBtn_Click(object sender, EventArgs e)
		{
			if (_kgSelectedIndex == -1 || _kgSelectedIndex >= KgView.Rows.Count)
			{
				return;
			}

			_codeList.RemoveAt(_kgSelectedIndex);
			if (_codeList.Count == 0)
			{
				_kgSelectedIndex = -1;
			}
			else if (_kgSelectedIndex >= _codeList.Count)
			{
				_kgSelectedIndex = _codeList.Count - 1;
			}
			UpdateKg();
			Changed?.Invoke(_codeList);
		}

		private void UpBtn_Click(object sender, EventArgs e)
		{
			if (_kgSelectedIndex < 1 || _kgSelectedIndex >= _codeList.Count)
			{
				return;
			}

			int index = _kgSelectedIndex;

			CodeItem codeItem = _codeList[_kgSelectedIndex];
			_codeList.RemoveAt(_kgSelectedIndex);
			_codeList.Insert(_kgSelectedIndex - 1, codeItem);
			if (_kgSelectedIndex > 0)
			{
				_kgSelectedIndex--;
			}
			UpdateKg();
			Changed?.Invoke(_codeList);
		}

		private void DownBtn_Click(object sender, EventArgs e)
		{
			if (_kgSelectedIndex == -1 || _kgSelectedIndex >= _codeList.Count - 1)
			{
				return;
			}
			CodeItem codeItem = _codeList[_kgSelectedIndex];
			_codeList.RemoveAt(_kgSelectedIndex);
			_codeList.Insert(_kgSelectedIndex + 1, codeItem);
			if (_kgSelectedIndex < _codeList.Count - 1)
			{
				_kgSelectedIndex++;
			}
			UpdateKg();
			Changed?.Invoke(_codeList);
		}

		private void SwapHorizBtn_Click(object sender, EventArgs e)
		{
			foreach (CodeItem item in _codeList)
			{
				item.Code = CodeItem.InvertCode(item.Code);
			}
			Changed?.Invoke(_codeList);
			UpdateKg();
		}

		private void SwapVertBtn_Click(object sender, EventArgs e)
		{
			List<CodeItem> invList = new List<CodeItem>();
			for (int i = _codeList.Count - 1; i >= 0; i--)
			{
				invList.Add(_codeList[i]);
			}
			_codeList = invList;
			UpdateKg();
			Changed?.Invoke(_codeList);
		}

		private void KgView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			int colIndex = e.ColumnIndex;
			if (colIndex < 1 || colIndex > 5)
			{
				return;
			}
			int index = colIndex - 1;

			int rowIndex = e.RowIndex;
			CodeItem codeItem = _codeList[rowIndex];
			codeItem.Code ^= (byte)(1 << index);

			UpdateKg();
			Changed?.Invoke(_codeList);
		}

		private void KgView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			int rowIndex = KgView.Rows[e.RowIndex].Index;
			DataGridViewCellCollection cells = KgView.Rows[e.RowIndex].Cells;
			if (rowIndex > cells.Count)
			{
				_kgSelectedIndex = rowIndex;
				return;
			}

			if (cells[e.ColumnIndex] != null && cells[e.ColumnIndex].Selected == true)
			{
				_kgSelectedIndex = rowIndex;
			}
		}

		private void UpdateKg()
		{
			PopulateKgView(_codeList, _kgType);
		}

		private void PopulateKgView(List<CodeItem> codeList, KgType kgType)
		{
			KgView.Rows.Clear();
			if (_codeList == null) return;

			List<DataGridViewRow> rows = new List<DataGridViewRow>();
			ShiftState shiftState = ShiftState.Letters;
			for (int i = 0; i < _codeList.Count; i++)
			{
				DataGridViewRow row = new DataGridViewRow();
				row.CreateCells(KgView);

				ShiftState invShiftState = CodeItem.InvertShiftState(shiftState);
				ShiftState currentShiftState = shiftState;

				byte[] codeArr = codeList[i].CodeArray;
				byte[] modCodeArr = codeList[i].ModCodeArray;

				ItemType itemType;
				if (kgType == KgType.Org)
				{
					itemType = codeList[i].Reference != null ? ItemType.Normal : ItemType.OrgNotUsed;
				}
				else
				{
					itemType = codeList[i].Reference != null ? ItemType.Normal : ItemType.NewMissing;
				}

				if (itemType == ItemType.NewMissing || itemType == ItemType.OrgNotUsed)
				{
					Debug.Write("");
				}

				Color itemCol;
				switch (itemType)
				{
					case ItemType.Normal:
					default:
						itemCol = ColorNormal;
						break;
					case ItemType.OrgNotUsed:
						itemCol = ColorNotUsed;
						break;
					case ItemType.NewMissing:
						itemCol = ColorMissing;
						break;
				}

				row.Cells[0].Value = $"{i + 1:D02}";
				SetCellColor(row.Cells[0], itemCol);

				row.Cells[6].Value = $"{codeList[i].Code:D02}";
				SetCellColor(row.Cells[6], itemCol);
				row.Cells[6].ToolTipText = LngText(LngKeys.TabColumnCode_ToolTip);

				row.Cells[7].Value = $"{codeList[i].GetChar(ref shiftState)}";
				SetCellColor(row.Cells[7], itemCol);
				row.Cells[7].ToolTipText = LngText(LngKeys.TabColumnChr_ToolTip);

				if (_kgType == KgType.Org)
				{
					row.Cells[8].Value = $"{codeList[i].GetChar(ref invShiftState)}";
					SetCellColor(row.Cells[8], itemCol);
					row.Cells[8].ToolTipText = LngText(LngKeys.TabColumnAlt_ToolTip);

					row.Cells[9].Value = $"{codeList[i].GetModString(currentShiftState, true)}";
					SetCellColor(row.Cells[9], itemCol);
					row.Cells[9].ToolTipText = LngText(LngKeys.TabColumnPossibleCharacters_ToolTip);
				}
				else
				{
					row.Cells[8].Value = $"{codeList[i].Reference + 1:D02}";
					SetCellColor(row.Cells[8], itemCol);
					row.Cells[8].ToolTipText = LngText(LngKeys.TabColumnReference_ToolTip);
				}

				for (int c = 0; c < 5; c++)
				{
					DataGridViewImageCell imgCell = row.Cells[c + 1] as DataGridViewImageCell;

					imgCell.Value = GetNibImage(codeArr[c], modCodeArr != null ? modCodeArr[c] : 1, itemType);
					imgCell.ImageLayout = DataGridViewImageCellLayout.Stretch;
					imgCell.ToolTipText = LngText(LngKeys.TabColumnCombs_ToolTip);
				}
				rows.Add(row);
			}
			KgView.Rows.AddRange(rows.ToArray());

			if (_kgSelectedIndex != -1 && _kgSelectedIndex < KgView.Rows.Count)
			{
				KgView.Rows[_kgSelectedIndex].Selected = true;
			}
		}

		/**
		 * Get image for display of one comb nibble
		 * bit: 0 = nibble, 1 = no nibble
		 * orgBit: 0 = orignal nibble exists, 1 = original nibble missing
		 * itemType: normal, unused or missing
		 */
		private Image GetNibImage(int bit, int orgBit, ItemType itemType)
		{
			Image noNibImage;
			Image nibImage;
			switch(itemType)
			{
				case ItemType.Normal:
				default:
					noNibImage = NoNibImageNormal;
					nibImage = NibImageNormal;
					break;
				case ItemType.OrgNotUsed:
					noNibImage = NoNibImageUnused;
					nibImage = NibImageUnused;
					orgBit = 1;
					break;
				case ItemType.NewMissing:
					noNibImage = NoNibImageMissing;
					nibImage = NibImageMissing;
					orgBit = 1;
					break;
			}

			Image bitImage;
			if (bit == 0)
			{
				bitImage = nibImage;
			}
			else
			{
				bitImage = orgBit == 1 ? noNibImage : NoNibImageRemove;
			}

			return bitImage;
		}

		private void SetCellColor(DataGridViewCell cell, Color color)
		{
			if (!(cell is DataGridViewTextBoxCell)) return;

			DataGridViewCellStyle style = cell.Style;
			style.Font = new Font("Consolas", 10, FontStyle.Regular);
			style.ForeColor = color;
			cell.Style.ApplyStyle(style);
		}

		private Bitmap GetImage(Color color, bool showNib, bool mod)
		{
			Bitmap bmp = new Bitmap(40, 40);
			Graphics g = Graphics.FromImage(bmp);
			Brush nibBrush = new SolidBrush(color);
			Brush blackGrayBrush = new SolidBrush(color);
			g.Clear(Color.White);
			g.FillRectangle(blackGrayBrush, 0, 32, 40, 6);
			if (showNib)
			{   // draw nibble
				g.FillRectangle(nibBrush, 6, 8, 28, 24);
				if (mod)
				{
					// draw white cross
					Pen whitePen = new Pen(Color.White, 2);
					g.DrawLine(whitePen, 6, 8, 34, 32);
					g.DrawLine(whitePen, 34, 8, 6, 32);
				}
			}
			else
			{   // no nib
			}
			return bmp;
		}

	}
}
