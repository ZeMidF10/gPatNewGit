using Glintths.Apps.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Glintths.Apps.Templates
{
	/// <summary>
	/// Basic Menu Item with icon and label 
	/// </summary>
	public class MasterMenuItem : ViewCell
	{

		private ITheme theme = VisualService.Instance.ThemeManager.Theme;

		public MasterMenuItem()
		{

			var column = new StackLayout
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.Fill,
				Orientation = StackOrientation.Vertical
			};

			//var boxBottom = new BoxView()
			//{
			//	Color = ThemeConstants.Color_BoxBackgroundAlt3,
			//	HeightRequest = 2,
			//	HorizontalOptions = LayoutOptions.Fill
			//};

			var row = new StackLayout
			{
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = 10,
			};


			var icon = new Image
			{
				HeightRequest = 25,
				WidthRequest = 25,
				HorizontalOptions = LayoutOptions.Start
			};
			icon.SetBinding(Image.SourceProperty, "Icon");

			var optionName = new Label
			{
				YAlign = TextAlignment.Center,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				TextColor = ThemeConstants.Color_LabelTextAlt2,
				Font = Font.SystemFontOfSize(18),
				Resources = ThemeConstants.Style_AvenirRoman
			};
			optionName.SetBinding(Label.TextProperty, "Title");

			if (Device.OS == TargetPlatform.iOS)
				optionName.Font = Font.OfSize("Avenir-Roman", NamedSize.Medium);

			row.Children.Add(icon);
			row.Children.Add(optionName);

			column.Children.Add(row);
			//column.Children.Add(boxBottom);

			View = column;
		}

		public static readonly BindableProperty BackgroundColorProperty =
			BindableProperty.Create<MasterMenuItem, Color>(p => p.BackgroundColor, Color.Transparent);

		public Color BackgroundColor
		{
			get { return (Color)GetValue(BackgroundColorProperty); }
			set { SetValue(BackgroundColorProperty, value); }
		}

		public static readonly BindableProperty SeparatorColorProperty =
			BindableProperty.Create<MasterMenuItem, Color>(p => p.SeparatorColor, Color.FromRgba(199, 199, 204, 255));

		public Color SeparatorColor
		{
			get { return (Color)GetValue(SeparatorColorProperty); }
			set { SetValue(SeparatorColorProperty, value); }
		}

		public static readonly BindableProperty SeparatorPaddingProperty =
			BindableProperty.Create<MasterMenuItem, Thickness>(p => p.SeparatorPadding, default(Thickness));

		public Thickness SeparatorPadding
		{
			get { return (Thickness)GetValue(SeparatorPaddingProperty); }
			set { SetValue(SeparatorPaddingProperty, value); }
		}


		public static readonly BindableProperty ShowSeparatorProperty =
			BindableProperty.Create<MasterMenuItem, bool>(p => p.ShowSeparator, true);

		public bool ShowSeparator
		{
			get { return (bool)GetValue(ShowSeparatorProperty); }
			set { SetValue(ShowSeparatorProperty, value); }
		}


		public static readonly BindableProperty ShowDisclousureProperty =
			BindableProperty.Create<MasterMenuItem, bool>(p => p.ShowDisclousure, true);

		public bool ShowDisclousure
		{
			get { return (bool)GetValue(ShowDisclousureProperty); }
			set { SetValue(ShowDisclousureProperty, value); }
		}

		public static readonly BindableProperty DisclousureImageProperty =
			BindableProperty.Create<MasterMenuItem, string>(
				p => p.DisclousureImage, string.Empty);

		public string DisclousureImage
		{
			get { return (string)GetValue(DisclousureImageProperty); }
			set { SetValue(DisclousureImageProperty, value); }
		}
	}
}
