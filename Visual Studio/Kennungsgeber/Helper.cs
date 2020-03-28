using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Kennungsgeber
{
	class Helper
	{

#if false
		public static string GetVersion()
		{
			//int? expireDays = ExpireDays();
			//string expireStr = expireDays != null ? $" expires in {expireDays} days" : "";
			string expireStr = "";
#if DEBUG
			// show date and time in debug version
			string buildTime = Properties.Resources.BuildDate.Trim(new char[] { '\n', '\r' }) + " Debug";
			//string buildTime = ConfigurationManager.AppSettings.Get("builddate") + " Debug";

#else
			// show only date in release version
			string buildTime = Properties.Resources.BuildDate.Trim(new char[] { '\n', '\r' });
			buildTime = buildTime.Substring(0, 10);
#endif
			return $"{Constants.PROGRAM_NAME}  V{Application.ProductVersion}  (Build={buildTime}) {expireStr}";
			//return $"{Constants.PROGRAM_NAME}  V{Application.ProductVersion}  (Build={buildTime}) - Special Carsten Version";
		}
#endif

		public static string SerializeObject<T>(T objectToSerialize)
		{
			using (var memoryStream = new MemoryStream())
			{
				using (var reader = new StreamReader(memoryStream))
				{
					DataContractSerializer serializer = new DataContractSerializer(typeof(T));
					serializer.WriteObject(memoryStream, objectToSerialize);
					memoryStream.Position = 0;
					var readToEnd = reader.ReadToEnd();
					return readToEnd;
				}
			}
		}

		public static T Deserialize<T>(string xml)
		{
			using (Stream stream = new MemoryStream())
			{
				byte[] data = System.Text.Encoding.UTF8.GetBytes(xml);
				stream.Write(data, 0, data.Length);
				stream.Position = 0;
				DataContractSerializer deserializer = new DataContractSerializer(typeof(T));
				return (T)deserializer.ReadObject(stream);
			}
		}
	}
}
