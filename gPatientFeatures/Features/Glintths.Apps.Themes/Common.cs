using Glintths.Apps.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Glintths.Apps.Themes
{
	public static class Common
	{
		// usado nos viewmodels
		public const string LOADING_FINISHED = "LOADING_FINISHED";

		public static void Notification(string uiMessage)
		{
			Device.BeginInvokeOnMainThread (
				() => {
					try {
						DependencyService.Get<IHud>().ShowError(uiMessage);

					} catch (Exception e1) {
						Debug.WriteLine ("Error - " + e1.Message);
					}

				}
			);
		}
	}
}
