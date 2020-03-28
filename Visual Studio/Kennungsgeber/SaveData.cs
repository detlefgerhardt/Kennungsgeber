using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Kennungsgeber
{
	[DataContract(Namespace = "")]
	class SaveData
	{
		[DataMember]
		public string Wunschkennung { get; set; }

		[DataMember]
		public List<CodeItem> OrgCodeList { get; set; }

		[DataMember]
		public List<CodeItem> NewCodeList { get; set; }

		public void InvOrgCode()
		{
			for (int i=0; i<OrgCodeList.Count; i++)
			{
				OrgCodeList[i].Code = CodeItem.InvertCode(OrgCodeList[i].Code);
			}
		}
	}
}
