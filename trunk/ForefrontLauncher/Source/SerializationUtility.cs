using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ForefrontLauncher {

	public static class SerializationUtility {

		public static void Save(object obj, string outputFile) {
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			Stream fileStream = new FileStream(outputFile, FileMode.Create, FileAccess.Write, FileShare.None);
			binaryFormatter.Serialize(fileStream, obj);
			fileStream.Close();
		}

		public static object Load(string file) {
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			Stream fileStream = File.OpenRead(file);
			return binaryFormatter.Deserialize(fileStream);
		}

		/// <summary>
		/// Method to convert a custom Object to XML string
		/// </summary>
		/// <remarks>
		/// Adapted from: http://www.dotnetjohn.com/articles.aspx?articleid=173
		/// </remarks>
		/// <param name="pObject">Object that is to be serialized to XML</param>
		/// <returns>XML string</returns>
		public static void SaveObjectToFile(object obj, string filename, params Type[] otherTypes) {
			MemoryStream memoryStream = new MemoryStream();
			XmlSerializer xs = new XmlSerializer(obj.GetType(), otherTypes);
			XmlTextWriter xmlTextWriter = new XmlTextWriter(filename, Encoding.Unicode);

			xs.Serialize(xmlTextWriter, obj);

			xmlTextWriter.Close();
		}

		/// <summary>
		/// Method to reconstruct an Object from XML string
		/// </summary>
		/// <remarks>
		/// Adapted from: http://www.dotnetjohn.com/articles.aspx?articleid=173
		/// </remarks>
		/// <param name="pXmlizedString"></param>
		/// <returns></returns>
		public static T DeserializeXmlObject<T>(string xmlFile) {
			XmlSerializer xs = new XmlSerializer(typeof(T));
			XmlTextReader reader = new XmlTextReader(File.OpenText(xmlFile).BaseStream);

			object obj = null;
			if ( xs.CanDeserialize(reader) ) {
				obj = xs.Deserialize(reader);
			}

			reader.Close();

			return (T)obj;
		}
	}
}
