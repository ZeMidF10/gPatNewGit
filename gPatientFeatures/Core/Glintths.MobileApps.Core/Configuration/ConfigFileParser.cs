using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core
{
	public abstract class ConfigFileParser
	{

        /// <summary>
        /// Parse and return config data in a dictionary
        ///  ###################################### PARA DESCONTINUAR!!!! ######################################
        /// </summary>
        /// <param name="data">The brute data</param>
        /// <returns></returns>
        public static Dictionary<int, string> ReadConfig(string data)
		{
			var result = new Dictionary<int, string>();
			var lineIndex = 0;
			foreach (var line in data.Split(new string[]{Environment.NewLine},StringSplitOptions.RemoveEmptyEntries))
			{
				lineIndex++;
				if(line.StartsWith("#")) continue;
				
				var pair = line.Split('=');
				if (pair.Length != 2)
				{
					Debug.WriteLine("Invalid line: {0}",lineIndex);
					continue;
				}

				try
				{
					var key = Convert.ToInt32(pair[0]);
					var value = pair[1];
					result.Add(key, value);
				}
				catch (Exception e)
				{
					Debug.WriteLine("Bad key value on line: {0}\nMsg: {1}",lineIndex,e.Message);
				}
				
			}

			return result;
		} 
	}
}
