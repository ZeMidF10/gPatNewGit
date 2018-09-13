using Glintths.Apps.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Glintths.Apps.Templates
{
	public abstract class BaseCellTemplate : ViewCell
	{

		protected readonly ITheme _theme = VisualService.Instance.ThemeManager.Theme;

		protected const string
			X = "X",
			Y = "Y",
			Width = "Width",
			Height = "Height";

		protected BaseCellTemplate()
		{
			NavigationPage.SetBackButtonTitle(this, "");
			_views = new List<View>();
		}

		protected Layout<View> Root;

		/// <summary>
		/// int -> VisualElement identifier
		/// </summary>
		protected List<View> _views;

		/// <summary>
		/// Draw Visual elements on Root container
		/// </summary>
		protected abstract void Draw();

		/// <summary>
		/// Initialize all visual elements and respective properties
		/// </summary>
		protected abstract void Init();

		/// <summary>
		/// The root element for the view
		/// </summary>
		protected abstract void InitRoot();

		/// <summary>
		/// Handle orientation change to lanscape
		/// </summary>
		protected abstract void HandleLanscapeChange();

		/// <summary>
		/// Handle orientation change to portrait
		/// </summary>
		protected abstract void HandlePortraitChange();
	}
}
