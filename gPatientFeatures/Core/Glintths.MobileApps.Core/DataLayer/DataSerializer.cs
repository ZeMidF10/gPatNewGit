using System;

namespace Glintths.MobileApps.Core.DataLayer
{
	public interface IStream
	{
		void WriteTextToFile(string instName, string txt, bool external = false);
		void StoreFacImgFromUrl(string url, string prefix);
		void ObjSerialization(string filename, Object obj, bool encrypted = false, bool external = false);

		string ReadFromFile(string filename);

        string ReadTextFromFile(string filename, bool external = false);
        Object ReadObjectFromFile(string filename, bool encrypted = false, bool external = false);
		Object ReadObjectFromAssets(string filename, bool encrypted = false);

		string WriteStream(byte[] buffer, string folderPath, string fullPath);
        string WriteStream(Byte[] buffer, string module, string docType, string idDocument, string ext, string scn);
		string FileExists(String module, string docType, string idDocument, string ext, string scn);
		string FileExists(string path);
		string GetStorePath(string module);

		void RenameFile(string filename, string newFilename, bool external = false);

        string GetPersonalPath();
	}

	public sealed class DataSerializer
	{
		/// <summary>
		/// Number of pending tasks
		/// </summary>
		public static int Semaphore = 0;

		private static IStream _IObridge;

		public static IStream IObridge
		{
			get { 
				return _IObridge;
			}
			set { _IObridge = value; }
		}

		private DataSerializer() { }

		public static void UrlToFile(string imgUrl, string prefix)
		{
			_IObridge.StoreFacImgFromUrl(imgUrl, prefix);
		}

	}
}
