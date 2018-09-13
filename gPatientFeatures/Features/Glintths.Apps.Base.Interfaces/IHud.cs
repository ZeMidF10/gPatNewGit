using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Glintths.Apps.Base.Interfaces
{
	public interface IHud
	{
		bool Enabled { get; set; }

		void Dismiss();
		/// <summary>
		/// 
		/// </summary>
		/// <param name="status"></param>
		/// <param name="progress"></param>
		/// <param name="maskType"></param>
		/// <param name="timeout">default 2 seconds</param>
		/// <param name="clickCallback">iOS and Android</param>
		/// <param name="centered"></param>
		/// <param name="cancelCallback">Android</param>
		void Show(string status = null, float progress = -1, int maskType = 0, double millis = 30000, Action clickCallback = null, bool centered = true, Action cancelCallback = null);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="status"></param>
		/// <param name="maskType">Android</param>
		/// <param name="millis"></param>
		/// <param name="clickCallback">Android</param>
		/// <param name="cancelCallback">Android</param>
		void ShowError(string status = null, int maskType = 0, double millis = 2000, Action clickCallback = null, Action cancelCallback = null);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="status"></param>
		/// <param name="maskType">Android</param>
		/// <param name="millis"></param>
		/// <param name="clickCallback">Android</param>
		/// <param name="cancelCallback">Android</param>
		void ShowErrorWithStatus(string status, int maskType = 0, double millis = 2000, Action clickCallback = null, Action cancelCallback = null);
		void ShowImage(object image, string status = null, int maskType = 0, double millis = 2000, Action clickCallback = null, Action cancelCallback = null);
		void ShowImage(int drawableResourceId, string status = null, int maskType = 0, double millis = 2000, Action clickCallback = null, Action cancelCallback = null);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="status"></param>
		/// <param name="maskType">Android</param>
		/// <param name="millis"></param>
		/// <param name="clickCallback">Android</param>
		/// <param name="cancelCallback">Android</param>
		void ShowSuccess(string status = null, int maskType = 0, double millis = 2000, Action clickCallback = null, Action cancelCallback = null);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="status"></param>
		/// <param name="maskType">Android</param>
		/// <param name="millis"></param>
		/// <param name="clickCallback">Android</param>
		/// <param name="cancelCallback">Android</param>
		void ShowSuccessWithStatus(string status, int maskType = 0, double millis = 2000, Action clickCallback = null, Action cancelCallback = null);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="status"></param>
		/// <param name="maskType"></param>
		/// <param name="millis"></param>
		/// <param name="centered"></param>
		/// <param name="clickCallback">Android</param>
		/// <param name="cancelCallback">Android</param>
		void ShowToast(string status, int maskType = 0, double millis = 2000, bool centered = true, Action clickCallback = null, Action cancelCallback = null);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="status"></param>
		/// <param name="maskType"></param>
		/// <param name="centered"></param>
		/// <param name="clickCallback"></param>
		/// <param name="cancelCallback"></param>
		Task<int> ShowConfirmationDialog(string status, int maskType = 0, bool centered = true, Action clickCallback = null, Action cancelCallback = null, string title = "Pretende continuar?", int btnNumb = 2);

        /// <summary>
		/// 
		/// </summary>
		/// <param name="status"></param>
		/// <param name="maskType"></param>
		/// <param name="centered"></param>
		/// <param name="clickCallback"></param>
		/// <param name="cancelCallback"></param>
		Task<int> ShowYesNoDialog(string status, int maskType = 0, bool centered = true, Action clickCallback = null, Action cancelCallback = null, string title = "Pretende continuar?", int btnNumb = 2, string firstBtnText = "Sim", string secondBtnText = "Não");
    }
}
