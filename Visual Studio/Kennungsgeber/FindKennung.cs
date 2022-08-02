using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kennungsgeber
{
	static class FindKennung
	{
		public static List<CodeItem> Find(string wunschKennung, List<CodeItem> oldCodeList)
		{
			List<CodeItem> modCodeList = ConvertToCodeList(wunschKennung);

			int minModCount = oldCodeList.Count * 5;
			int fitIndex = 0;
			int modIndex = 0;
			int minFitIndex = -1;
			int minModIndex = -1;
			int maxFitCount = 0;
			bool minModOk = false;
			//bool fitVariantEnd;
			//bool modVariantEnd;
			int modCount;
			while (true)
			{
				ResetCodeList(oldCodeList);
				ResetCodeList(modCodeList);

				FindFitting(oldCodeList, modCodeList, fitIndex, out bool fitVariantEnd);

				if (fitVariantEnd)
				{
					Debug.WriteLine($"fitVariantEnd fitIndex={fitIndex}");
					fitIndex = 0;
					modIndex++;
					//continue;
				}

				bool modOk = FindModFitting(oldCodeList, modCodeList, modIndex, out modCount, out bool modVariantEnd);

				int fitCount = FitCount(modCodeList);

				if (modVariantEnd)
				{
					Debug.WriteLine($"modVariantEnd fitIndex={modIndex}");
					break;
				}

				//Debug.WriteLine($"{fitIndex}/{modIndex} {modOk}/{minModOk} {modCount}/{minModCount} {minFitIndex}/{minModIndex}");
				if (!minModOk && modOk)
				{
					// reset min/max values on first success
					minModCount = oldCodeList.Count * 5;
					maxFitCount = 0;
				}
				if (fitCount>= maxFitCount && modCount < minModCount)
				{
					maxFitCount = fitCount;
					minModCount = modCount;
					minFitIndex = fitIndex;
					minModIndex = modIndex;
					minModOk = modOk;
				}

				fitIndex++;
			}

			// repeat variant with lowest mod count
			ResetCodeList(oldCodeList);
			ResetCodeList(modCodeList);
			FindFitting(oldCodeList, modCodeList, minFitIndex, out _);
			FindModFitting(oldCodeList, modCodeList, minModIndex, out _, out _);

			List<CodeItem> newCodeList = Compact(oldCodeList, modCodeList);
			return newCodeList;
		}

		public static List<CodeItem> ConvertToCodeList(string wunschKennung)
		{
			List<CodeItem> newCodeList = new List<CodeItem>();

			ShiftState shiftState = ShiftState.Unknown;
			for (int i = 0; i < wunschKennung.Length; i++)
			{
				ShiftState ss;
				byte? code = CodeItem.CharToCode(wunschKennung[i].ToString(), out ss);
				if (code == null)
				{
					continue;
				}
			
				if (ss != ShiftState.Both && (ss != shiftState || shiftState==ShiftState.Unknown))
				{
					if (ss == ShiftState.Letters)
					{
						newCodeList.Add(new CodeItem(CodeItem.CODE_LTR));
					}
					else
					{
						newCodeList.Add(new CodeItem(CodeItem.CODE_FIG));
					}
					shiftState = ss;
				}
				newCodeList.Add(new CodeItem(code.Value));
			}

			// insert before LTR or FIG
			newCodeList.Insert(0, new CodeItem(CodeItem.CODE_WR));
			newCodeList.Insert(1, new CodeItem(CodeItem.CODE_ZL));

			return newCodeList;
		}

		private static void ResetCodeList(List<CodeItem> codeList)
		{
			foreach (CodeItem codeItem in codeList)
			{
				codeItem.Reference = null;
				codeItem.ModCode = null;
			}
		}

		private static int FitCount(List<CodeItem> codeList)
		{
			int fitCount1 = codeList.Count(x => x.Reference != null);
			int fitCount2 = 0;
			for (int i=0; i<5; i++)
			{
				if (codeList[i].Reference != null)
				{
					fitCount2++;
				}
			}

			return fitCount2 * 100 + fitCount1;
		}

		/// <summary>
		/// Markiert alle
		/// </summary>
		/// <param name="oldCodeList"></param>
		/// <param name="newCodeList"></param>
		/// <param name="variantIndex"></param>
		/// <param name="variantEnd"></param>
		/// <returns>true = exact fitting for all codes found</returns>
		private static bool FindFitting(List<CodeItem> oldCodeList, List<CodeItem> newCodeList, int variantIndex, out bool variantEnd)
		{
			int variantCount = 0;
			variantEnd = true;
			bool success = true;
			for (int n = 0; n < newCodeList.Count; n++)
			{
				for (int o = 0; o < oldCodeList.Count; o++)
				{
					if (oldCodeList[o].Reference == null && oldCodeList[o].Code == newCodeList[n].Code)
					{
						// exact fitting code found
						if (variantCount >= variantIndex)
						{
							variantEnd = false;
							oldCodeList[o].Reference = n;
							newCodeList[n].Reference = o;
							break;
						}
						else
						{
							variantCount++;
						}
					}
				}
				if (newCodeList[n].Reference == null)
				{
					// no exact fitting code found
					success = false;
				}
			}
			return success;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="oldCodeList"></param>
		/// <param name="newCodeList"></param>
		/// <param name="variantIndex"></param>
		/// <param name="totalModCount"></param>
		/// <param name="variantEnd"></param>
		/// <returns>true if mod fitting code found</returns>
		private static bool FindModFitting(List<CodeItem> oldCodeList, List<CodeItem> newCodeList, int variantIndex, out int totalModCount, out bool variantEnd)
		{
			int variantCount = 0;
			variantEnd = true;
			bool success = true;
			totalModCount = 0;
			for (int n = 0; n < newCodeList.Count; n++)
			{
				for (int o = 0; o < oldCodeList.Count; o++)
				{
					if (oldCodeList[o].Reference == null && newCodeList[n].Reference == null)
					{
						int modCount = CodeItem.ModIncluded(oldCodeList[o].Code, newCodeList[n].Code);
						if (modCount == 0)
						{
							// mod not possible
							continue;
						}
						// mode fitting code found
						if (variantCount >= variantIndex)
						{
							variantEnd = false;
							oldCodeList[o].Reference = n;
							newCodeList[n].Reference = o;
							newCodeList[n].ModCode = oldCodeList[o].Code;
							totalModCount += modCount;
							break;
						}
						else
						{
							variantCount++;
						}
					}
				}
				if (newCodeList[n].Reference == null)
				{
					// no mod fitting code found
					success = false;
				}
			}
			return success;
		}

		/// <summary>
		/// Compress new list and add unresolved codes at the end
		/// </summary>
		/// <param name="oldCodeList"></param>
		/// <param name="newCodeList"></param>
		/// <returns></returns>
		private static List<CodeItem> Compact(List<CodeItem> oldCodeList, List<CodeItem> modCodeList)
		{
			List<CodeItem> newCodeList = new List<CodeItem>();

			// add resolved codes
			for (int i = 0; i < modCodeList.Count; i++)
			{
				//if (modCodeList[i].Reference != null)
				//{
				//	newCodeList.Add(modCodeList[i]);
				//}
				modCodeList[i].Missing = modCodeList[i].Reference == null;
				newCodeList.Add(modCodeList[i]);
			}

			/*
			// add unresolved codes
			for (int i = 0; i < oldCodeList.Count; i++)
			{
				if (oldCodeList[i].Reference == null)
				{
					newCodeList.Add(oldCodeList[i]);
				}
			}
			*/
			return newCodeList;
		}

		public static int MatchingCount(List<CodeItem> codeList)
		{
			int count = 0;
			// count resolved codes
			for (int i = 0; i < codeList.Count; i++)
			{
				if (codeList[i].Reference != null)
				{
					count++;
				}
			}
			return count;
		}

		private const string CLEAN_CHARS = "abcdefghijklmnopqrstuvwxyz01234567890()/+-=?,.:' ";

		public static string CleanCode(string str)
		{
			string newStr = "";
			str = str.ToLower();
			foreach(char chr in str)
			{
				if (CLEAN_CHARS.Contains(chr)) newStr += chr;
			}
			return newStr;
		}
	}
}
