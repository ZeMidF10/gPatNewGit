using Glintths.MobileApps.Core.BusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.MobileApps.Core.ServiceAccessLayer
{
	public delegate void PositionChanged (GeoCoordinate newPosition);

	public interface ILocator
	{

		event PositionChanged PositionChanged;
		Task<GeoCoordinate> GetCurrentPositionAsync();
        void StopListeningUserLocation();
	}

	public class LocationManager
	{
		private static volatile LocationManager instance;
		private static object syncRoot = new Object();

		private ILocator _locator;
		public ILocator Locator
		{
			get {
				return _locator;

			}
			set {
				_locator = value;
				_locator.PositionChanged += _locator_PositionChanged;
                _locator.GetCurrentPositionAsync();
			}
		}

		void _locator_PositionChanged(GeoCoordinate newPosition)
		{
			Debug.WriteLine("Novas Coordenadas - " + newPosition.lat + "," + newPosition.lon);
			LastKnownPosition = newPosition;
            _locator.StopListeningUserLocation();
		}

		private LocationManager()
		{
            
		}

		public static LocationManager Instance
		{
			get
			{
				if(instance == null)
				{
					lock (syncRoot) {
						if (instance == null) {
							instance = new LocationManager();
						}
					}
				}
				return instance;
			}
		}

		public GeoCoordinate LastKnownPosition
		{
			get;
			set;
		}
	}
}
