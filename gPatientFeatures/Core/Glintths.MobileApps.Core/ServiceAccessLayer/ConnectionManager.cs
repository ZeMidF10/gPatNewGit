using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.ServiceAccessLayer
{
	/// <summary>
	/// 
	/// </summary>
	public enum Connection_Type
	{
		ANY, WIFI, ROAMING
	}

	public interface IConnection
	{
		bool HasWebAccess(Connection_Type type=Connection_Type.ANY);
		void EnableWebAccess(Connection_Type type=Connection_Type.WIFI);
        bool HasServiceAccess();
        bool IsHostReachable(string host);
	}

	public class ConnectionManager
	{
		private static ConnectionManager _instance;
		private IConnection _connection;

		public IConnection Connection
		{
			get { return _connection; }
			set { _connection = value; }
		}

		protected ConnectionManager(){
		}

		public static ConnectionManager Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new ConnectionManager();
				}
				return _instance;
			}
		}

	}
}
