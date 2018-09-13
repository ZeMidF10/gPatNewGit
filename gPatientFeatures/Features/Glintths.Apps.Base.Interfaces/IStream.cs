using System;

namespace Glintths.Apps.Base.Interfaces
{
    /// <summary>
    /// Isto está duplicado com o dataserializer... dar preferencia ao dataserializar
    /// </summary>
	public interface IStream
	{
		void WriteTextToFile(string instName, string txt, bool external = false);

		void StoreFacImgFromUrl(string url, string prefix);

		void ObjSerialization(string filename, Object obj, bool encrypted = false, bool external = false);

		/// <summary>
		/// Reads all contents from file on filePath into a string
		/// </summary>
		/// <param name="filename">Path to file</param>
		/// <returns>String with all the file contents</returns>
		string ReadFromFile(string filePath);

		Object ReadObjectFromFile(string filename, bool encrypted = false, bool external = false);

		Object ReadObjectFromAssets(string filename, bool encrypted = false);

        string GetPersonalPath();
	}
}