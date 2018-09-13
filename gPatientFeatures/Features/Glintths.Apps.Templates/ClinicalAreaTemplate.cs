using Glintths.Apps.Base.Interfaces;
using Glintths.Apps.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Glintths.Apps.Templates
{
	public class ClinicalAreaTemplate : ViewCell
	{
		private ITheme theme = VisualService.Instance.ThemeManager.Theme;

		public ClinicalAreaTemplate()
		{
			Label titleLabel = new Label
			{
				Text = "vazio",
				TextColor = theme.FontMainColor,
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Resources = theme.LabelStyleBig,
				BackgroundColor = Color.Transparent
			};
			titleLabel.SetBinding(Label.TextProperty, "Key");

			BoxView lineSeparator = new BoxView
			{
				HeightRequest = 1,
				Color = theme.LineLight,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.End
			};

			Image arrow = new Image
			{
				HorizontalOptions = LayoutOptions.End,
                Source = DependencyService.Get<IGetResources>().GetImageSourceFromResourceId(theme.ArrowIco),
				HeightRequest = theme.IconSize,
				WidthRequest = theme.IconSize,
			};

			StackLayout mainLayout = new StackLayout()
			{
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				BackgroundColor = Color.Transparent,
				Spacing = 0,
				Padding = 0,
				Children = {
					new StackLayout(){
						Padding = 5,
						Orientation = StackOrientation.Horizontal,
						VerticalOptions = LayoutOptions.CenterAndExpand,
						HorizontalOptions = LayoutOptions.FillAndExpand,
						BackgroundColor = Color.Transparent,
						Children = {
							titleLabel,
							arrow,
						}
					}

				}
			};

			if (Device.OS == TargetPlatform.Android)
				mainLayout.Children.Add(lineSeparator);

			View = mainLayout;
		}
	}
}
