using System;
using System.Collections.Generic;
using System.IO;
using Glintths.MobileApps.Core.DataLayer;
using System.Diagnostics;

namespace Glintths.MobileApps.Core
{
    /// <summary>
    /// ###################################### PARA DESCONTINUAR!!!! ######################################
    /// </summary>

    public sealed class ConfigLoader
	{
		// ReSharper disable once InconsistentNaming
		private const string PROP_FILE_NAME = "inst_dic.properties";

		private string ConfFileName { get; set; }
		// ReSharper disable once InconsistentNaming
		public static readonly string CONF_FILE_EXTENSION = ".bin";

		private ConfigLoader ()
		{
			if (!Test)
				LoadConfFileDictionary ();
		}

		public ConfigLoader (int i)
		{
		}

		public Tuple<string, string> InstConfFile;

		private static ConfigLoader _instance;

		public static ConfigLoader Instance {
			get {
				if (_instance != null)
					return _instance;

				_instance = new ConfigLoader ();
				return _instance;
			}
		}

		private void LoadConfFileDictionary ()
		{
			string text = DataSerializer.IObridge.ReadFromFile (PROP_FILE_NAME);

			foreach (var str in text.Split('\n')) {
				var valuePair = str.Split ('=');
				InstConfFile = new Tuple<string, string> (valuePair [0], valuePair [1]);
			}
		}


		//		private void ReadConfFile(string inst_name)
		//		{
		//			try
		//			{
		//				var obj = DataSerializer.IObridge.ReadObjectFromFile(ConfFileName);
		//			}
		//			catch (FileNotFoundException ex)
		//			{
		//                Debug.WriteLine(ex.Message);
		//				//No file present
		//			}
		//
		//
		//		}


		public bool LoadConf ()
		{

			//Testing override
			if (Test)
				return true;

			ConfFileName = InstConfFile.Item1 + "_" + InstConfFile.Item2 + ".bin";
			if (InstConfFile.Item1 == null)
				return false;
			var obj = DataSerializer.IObridge.ReadObjectFromAssets (ConfFileName, true);
			if (obj == null)
				return false;
			Configuration.Instance.Configurations = (Dictionary<String, String>)obj;
			return true;
		}

		/// <summary>
		/// Test class workaround
		/// </summary>
		public static bool Test { get; set; }
	}
}
