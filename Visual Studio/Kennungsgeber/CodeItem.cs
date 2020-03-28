using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Kennungsgeber
{
	public enum ShiftState { Letters, Figures, Both, Unknown };

	[DataContract(Namespace = "")]
	public class CodeItem
	{
		[DataMember]
		public int OrgPositon { get; set; }

		[DataMember]
		public byte Code { get; set; }

		/// <summary>
		/// Old code
		/// </summary>
		[DataMember]
		public byte? ModCode { get; set; }

		[DataMember]
		public int? Reference { get; set; }

		public CodeItem(byte code)
		{
			OrgPositon = 0;
			Code = code;
			ModCode = null;
		}

		public byte[] CodeArray => CodeToArray(Code);

		public string CodeArrayString => CodeToArrayStr(Code);

		public byte[] ModCodeArray => CodeToArray(ModCode);

		public string ModCodeArrayString => CodeToArrayStr(ModCode);

		//public ShiftState? Shift { get; set; }

		//public bool Used { get; set; } = false;

		public string GetChar(ShiftState shift)
		{
			return CodeToChar(Code, shift);
		}

		public string GetChar(ref ShiftState shiftState)
		{
			string chr = CodeToChar(Code, shiftState);
			shiftState = CheckShiftState(Code, shiftState);
			return chr != "X" ? chr : "";
		}

		public string GetCharText(ref ShiftState shiftState)
		{
			string chr = GetCharText(shiftState);
			shiftState = CheckShiftState(Code, shiftState);
			return chr;
		}


		public string GetCharText(ShiftState shift)
		{
			string chr = CodeToChar(Code, shift);
			switch(chr)
			{
				case "ZWR":
					chr = " ";
					break;
				case "WR":
					//chr = "<";
					chr = "[WR]";
					break;
				case "ZL":
					//chr = "\u2261";
					chr = "[ZL]";
					break;
				case "NUL":
					chr = "_";
					break;
				default:
					if (chr.Length>1)
					{
						chr = "[" + chr + "]";
					}
					break;
			}

			return chr;
		}

		/// <summary>
		/// Return the alternate shift state character, if available
		/// </summary>
		/// <param name="shiftState"></param>
		/// <returns></returns>
		public string GetAltChar(ShiftState shiftState)
		{
			if (Code==0 || Code==2 || Code==4 || Code==8 || Code==27 || Code==31)
			{
				// not alt shift char
				return "";
			}
			// invers shift state
			if (shiftState == ShiftState.Letters)
			{
				shiftState = ShiftState.Figures;
			}
			else
			{
				shiftState = ShiftState.Letters;
			}
			return CodeToChar(Code, shiftState);
		}

		/// <summary>
		/// Returns a string with all character that can be created by removing nib 
		/// </summary>
		/// <returns></returns>
		public string GetModString(ShiftState ss, bool omitBu)
		{
			return string.Join(" ", GetModArray(ss, omitBu));
		}

		/// <summary>
		/// Returns a list of all character that can be created by removing nib
		/// </summary>
		/// <param name="shift"></param>
		/// <returns></returns>
		public string[] GetModArray(ShiftState ss, bool omitBu)
		{
			if (Code == 0)
			{
				return new string[0];
			}

			List<ModCheckItem> modList = new List<ModCheckItem>();
			// altChar will be removed afterwards

			for (int shift = 0; shift < 2; shift++)
			{
				for (int i = 0; i < 32; i++)
				{
					if (i == Code || omitBu && i == 31)
					{
						continue;
					}
					int? modCount = CheckModCode(Code, (byte)i);
					if (modCount != null)
					{
						ShiftState shiftState = shift == 0 ? ShiftState.Letters : ShiftState.Figures;
						string chr = CodeToChar((byte)i, shiftState);
						if (!ModListContainsChar(modList, chr))
						{
							modList.Add(new ModCheckItem(chr, modCount.Value));
						}
					}
				}
			}

			// sort modList by modCount
			modList.Sort(new ModCheckItemComparer());

			return (from m in modList select m.Char).ToArray();
		}

		private bool ModListContainsChar(List<ModCheckItem> modList, string chr)
		{
			return (from m in modList where string.Compare(m.Char, chr, true) == 0 select m).Any();
		}

		/// <summary>
		// Code Check Result
		//   0    0     0
		//   0    1     0
		//   1    0     1  -> mod not possible
		//   1    1     0
		/// </summary>
		/// <param name="code"></param>
		/// <param name="modCode"></param>
		/// <returns>number of modifications, null=not possible</returns>
		private int? CheckModCode(byte code, byte modCode)
		{
			int modCount = 0;
			byte[] codeArr = CodeArray;
			for (int p = 0; p < 5; p++)
			{
				int modBit = (modCode & (1 << p)) == 0 ? 0 : 1;
				if (codeArr[p] == modBit)
				{
					continue;
				}
				if (codeArr[p]==0 && modBit==1)
				{
					modCount++;
					continue;
				}
				return null;
			}
			return modCount;
		}

		public static int ModIncluded(byte oldCode, byte newCode)
		{
			byte[] oldArray = CodeToArray(oldCode);
			byte[] newArray = CodeToArray(newCode);
			int modCount = 0;
			for (int i = 0; i < 5; i++)
			{
				if (oldArray[i] == 1 && newArray[i] == 0)
				{
					// mod not possible
					return 0;
				}
				// mod possible
				if (oldArray[i]!=newArray[i])
				{
					modCount++;
				}
			}
			return modCount;
		}

		public static string CodeToChar(byte code, ShiftState shiftState)
		{
			if (code > 31)
			{
				return "???";
			}

			//code = InvertCode(code);

			int shift = shiftState == ShiftState.Letters ? 0 : 1;
			return CodeTab[shift, code];
		}

		public static byte? CharToCode(string chr, out ShiftState shiftState)
		{
			shiftState = ShiftState.Both;
			switch (chr)
			{
				case "<":
				case "WR":
					return CODE_WR;
				case "\u2261":
				case "ZL":
					return CODE_ZL;
				case " ":
					return CODE_ZWR;
			}

			for (int s = 0; s < 2; s++)
			{
				shiftState = s == 0 ? ShiftState.Letters : ShiftState.Figures;
				for (int c = 0; c < 32; c++)
				{
					if (CodeTab[s,c]==chr)
					{
						//return InvertCode((byte)c);
						return (byte)c;
					}
				}
			}
			shiftState = ShiftState.Both;
			return null;
		}

		public static byte[] CodeToArray(byte? code)
		{
			if (code == null)
			{
				return null;
			}

			byte[] arr = new byte[5];
			int pos = 1;
			for (int i = 0; i < 5; i++)
			{
				arr[i] = (byte)((code & pos) != 0 ? 1 : 0);
				pos <<= 1;
			}
			return arr;
		}

		public static string CodeToArrayStr(byte? code)
		{
			if (code == null)
			{
				return "";
			}

			string str = "";
			byte[] arr = CodeToArray(code);
			for (int i = 0; i < 5; i++)
			{
				str += arr[i].ToString();
			}
			return str;
		}

		public CodeItem GetCodeItemFromChr(char chr)
		{
			for (int i=0; i<31; i++)
			{
				
			}


			return null;
		}

		public static ShiftState CheckShiftState(int code, ShiftState shiftState)
		{
			if (code == 0x1F)
			{
				shiftState = ShiftState.Letters;
			}
			else if (code == 0x1B)
			{
				shiftState = ShiftState.Figures;
			}
			return shiftState;
		}

		public static ShiftState InvertShiftState(ShiftState shiftState)
		{
			switch(shiftState)
			{
				case ShiftState.Both:
				default:
					return shiftState;
				case ShiftState.Letters:
					return ShiftState.Figures;
				case ShiftState.Figures:
					return ShiftState.Letters;
			}
		}

		public const byte CODE_NUL = 0x00;
		public const byte CODE_ZL = 0x02;
		public const byte CODE_ZWR = 0x04;
		public const byte CODE_WR = 0x08;
		public const byte CODE_FIG = 0x1B;
		public const byte CODE_LTR = 0x1F;

		private static string[,] CodeTab =
		{
			// letters
			{
				"NUL",		// 00
				"e",		// 01
				"ZL",		// 02 line feed
				"a",		// 03
				"ZW",		// 04 space
				"s",		// 05
				"i",		// 06
				"u",		// 07
				"WR",		// 08 carriage return
				"d",		// 09
				"r",		// 0A
				"j",		// 0B
				"n",		// 0C
				"f",		// 0D
				"c",		// 0E
				"k",		// 0F
				"t",		// 10
				"z",		// 11
				"l",		// 12
				"w",		// 13
				"h",		// 14
				"y",		// 15
				"p",		// 16
				"q",		// 17
				"o",		// 18
				"b",		// 19
				"g",		// 1A
				"Zi",		// 1B figures
				"m",		// 1C
				"x",		// 1D
				"v",		// 1E
				"Bu"		// 1F letters
			},

			// figures
			{
				"NUL",		// 00
				"3",		// 01
				"ZL",		// 02 carriage return
				"-",		// 03
				"ZW",		// 04 space
				"'",		// 05 
				"8",		// 06
				"7",		// 07
				"WR",		// 08 new line
				"WRU",		// 09 who are you
				"4",		// 0A
				"KL",		// 0B bell
				",",		// 0C
				"X",		// 0D
				":",		// 0E
				"(",		// 0F
				"5",		// 10
				"+",		// 11
				")",		// 12
				"2",		// 13
				"X",		// 14 
				"6",		// 15
				"0",		// 16 
				"1",		// 17
				"9",		// 18
				"?",		// 19
				"X",		// 1A
				"Zi",		// 1B figures
				".",		// 1C
				"/",		// 1D
				"=",		// 1E
				"Bu"		// 1F letters
			}
		};

		public static byte InvertCode(byte code)
		{
			byte inv = 0;
			for (int i=0; i<5; i++)
			{
				if ((code & (1<<i))!=0)
				{
					inv = (byte)(inv | (1 << (4 - i)));
				}
			}
			return inv;
		}

		public override string ToString()
		{
			return $"{Code:X2} {CodeArrayString} '{GetChar(ShiftState.Letters)}' '{GetChar(ShiftState.Figures)}' {Reference}";
		}

	}

	class CodeItemPosComparer : IComparer<CodeItem>
	{
		public int Compare(CodeItem x, CodeItem y)
		{
			// sort ascending
			return x.OrgPositon.CompareTo(y.OrgPositon);
		}
	}
}
