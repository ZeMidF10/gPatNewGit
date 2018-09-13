using Glintths.Apps.Themes;
using Xamarin.Forms;

namespace Glintths.Apps.Templates
{
	public class Step2DataTemplate : ViewCell
	{
		private ITheme theme = VisualService.Instance.ThemeManager.Theme;

		public Step2DataTemplate ()
		{
			Label titulo = new Label {
				TextColor = theme.FontMainColor,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
                Resources = theme.LabelStyleNormal,
			};
			titulo.SetBinding (Label.TextProperty, "MenuOption");

			Label detail = new Label {
				TextColor = theme.SelectionColor,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
                Resources = theme.LabelStyleNormal,
			};
			detail.SetBinding (Label.TextProperty, "MenuOptionDetail");

			StackLayout childLayout = new StackLayout () {
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Padding = 5,
				Spacing = 0,
				Children = {
					titulo,
					detail,
				},
			};

			//list.GroupDisplayBinding = new Binding("HeaderTitle");
			StackLayout mainLayout = new StackLayout () {
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Padding = 0,
				Spacing = 0,
				Children = {
					childLayout
				},
			};

			if (Device.OS == TargetPlatform.Android) {
				BoxView horizontalLine = new BoxView {
					HeightRequest = 1,
					Color = theme.LineLight,
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.End
				};
				mainLayout.Children.Add (horizontalLine);
			}

			View = mainLayout;

		}
	}
}
