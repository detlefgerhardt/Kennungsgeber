using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kennungsgeber
{
	public partial class KgListView : UserControl
	{
		public enum KgType { Org, New };

		private List<CodeItem> _codeList;

		private Bitmap _leerSchrittBlack;
		private Bitmap _leerSchrittGray;
		private Bitmap _stromSchrittBlack;
		private Bitmap _stromSchrittGray;
		private Bitmap _stromSchrittRed;

		private int _kgSelectedIndex = -1;

		private KgType _kgType;

		public delegate void UpdateEventHandler(List<CodeItem> codeList);
		public event UpdateEventHandler Changed;

		private bool _swapButtons;
		public bool SwapButtons
		{
			set
			{
				_swapButtons = value;
				if (_swapButtons)
				{
					SwapHorizBtn.Text = "\u2194";
					SwapHorizBtn.Font = new Font("Arial Unicode MS", 10);
					//SwapHorizBtn.Padding = new Padding(2, -2, 2, 0);
					SwapVertBtn.Text = "\u2195";
					SwapVertBtn.Font = new Font("Arial Unicode MS", 10);
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

		public void Init(KgType kgType, bool swapButtons)
		{
			_kgType = kgType;
			SwapButtons = swapButtons;

			KgView.MultiSelect = false;
			KgView.BackgroundColor = Color.White;
			KgView.RowHeadersVisible = false;
			KgView.ScrollBars = ScrollBars.Vertical;
			//KgView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			KgView.AllowUserToAddRows = false;
			KgView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

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
					HeaderText = "Fr",
					Width = 25
				};
				KgView.Columns.Add(altCharCol);

				this.Width = 217;
			}

			_kgSelectedIndex = 0;
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

		private void AddBtn_Click(object sender, EventArgs e)
		{
			_codeList.Add(new CodeItem(0x1F));
			_kgSelectedIndex = _codeList.Count - 1;
			UpdateKg();
			Changed?.Invoke(_codeList);
		}

		private void InsBtn_Click(object sender, EventArgs e)
		{
			if (_kgSelectedIndex == -1)
				return;

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
			//DataGridViewRow row = KgView.Rows[rowIndex];
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

			_leerSchrittBlack = GetImage(0, false, false);
			_leerSchrittGray = GetImage(0, false, true);
			_stromSchrittBlack = GetImage(1, false, false);
			_stromSchrittGray = GetImage(1, false, true);
			_stromSchrittRed = GetImage(0, true, false);

			KgView.Rows.Clear();

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
				bool gray = kgType == KgType.New & codeList[i].Reference == null;
				Color blackGray = gray ? Color.DarkGray : Color.Black;

				row.Cells[0].Value = $"{i + 1:D02}";
				SetCellColor(row.Cells[0], blackGray);
				//row.Cells[6].Value = $"{codeList[i].Code:X02}";
				row.Cells[6].Value = $"{codeList[i].Code:D02}";
				SetCellColor(row.Cells[6], blackGray);
				row.Cells[7].Value = $"{codeList[i].GetChar(ref shiftState)}";
				SetCellColor(row.Cells[7], blackGray);
				if (_kgType == KgType.Org)
				{
					row.Cells[8].Value = $"{codeList[i].GetChar(ref invShiftState)}";
					SetCellColor(row.Cells[8], blackGray);
					row.Cells[9].Value = $"{codeList[i].GetModString(currentShiftState, true)}";
					SetCellColor(row.Cells[9], blackGray);
				}
				else
				{
					row.Cells[8].Value = $"{codeList[i].Reference + 1:D02}";
					SetCellColor(row.Cells[8], blackGray);
				}

				for (int c = 0; c < 5; c++)
				{
					DataGridViewImageCell imgCell = row.Cells[c + 1] as DataGridViewImageCell;

					byte? modBit = null;
					if (modCodeArr != null)
					{
						modBit = modCodeArr[c];
					}

					imgCell.Value = GetNibImage(codeArr[c], modBit, gray);

					imgCell.ImageLayout = DataGridViewImageCellLayout.Stretch;
				}


				rows.Add(row);
			}
			KgView.Rows.AddRange(rows.ToArray());

			if (_kgSelectedIndex != -1 && _kgSelectedIndex < KgView.Rows.Count)
			{
				KgView.Rows[_kgSelectedIndex].Selected = true;
			}
		}

		private Image GetNibImage(byte bit, byte? modBit, bool gray)
		{
			Image nibImage;

			Image stromSchritt = !gray ? _stromSchrittBlack : _stromSchrittGray;
			Image leerSchritt = !gray ? _leerSchrittBlack : _leerSchrittGray;

			if (bit == 0)
			{   // 0 = leerschritt
				nibImage = leerSchritt;
			}
			else
			{
				// 1 = stromschritt
				if (modBit == null || modBit == 1)
				{
					// old=1 show stromschritt
					nibImage = stromSchritt;
				}
				else
				{
					// old=0 show mod stromschritt
					nibImage = _stromSchrittRed;
				}
			}

			return nibImage;
		}

		private void SetCellColor(DataGridViewCell cell, Color color)
		{
			if (!(cell is DataGridViewTextBoxCell))
			{
				return;
			}

			DataGridViewCellStyle style = cell.Style;
			style.Font = new Font("Consolas", 10, FontStyle.Regular);
			style.ForeColor = color;
			//style.BackColor = rowAttr.BackColor;
			cell.Style.ApplyStyle(style);
		}

		private Bitmap GetImage(int schritt, bool mod, bool gray)
		{
			Bitmap bmp = new Bitmap(40, 40);
			Graphics g = Graphics.FromImage(bmp);
			Color blackGray = gray ? Color.DarkGray : Color.Black;
			Color nibColor = mod ? Color.Red : blackGray;
			Brush nibBrush = new SolidBrush(nibColor);
			Brush blackGrayBrush = new SolidBrush(blackGray);
			g.Clear(Color.White);
			g.FillRectangle(blackGrayBrush, 0, 32, 40, 6);
			if (schritt == 0)
			{   // leerschritt: draw nib
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
			{   // stromschritt: no nib
			}
			return bmp;
		}
	}
}
