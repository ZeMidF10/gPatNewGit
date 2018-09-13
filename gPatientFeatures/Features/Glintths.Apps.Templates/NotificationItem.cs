using Glintths.Apps.Base.Interfaces;
using Glintths.Apps.Themes;
using Glintths.Apps.ViewModels.ValueConverters;
using System;
using Xamarin.Forms;

namespace Glintths.Apps.Templates
{
	public class NotificationItem : BaseCellTemplate
	{

		public NotificationItem()
			: base()
		{
			Init();
			Draw();
			View = Root;
		}

		protected override void Draw()
		{
			foreach (var view in _views)
			{
				Root.Children.Add(view);
			}
		}

		protected override void Init()
		{
			InitRoot();
			_views.Add(InitTopStack());
			if (TargetPlatform.Android == Device.OS) _views.Add(InitLineSeparator());
		}

		protected override void InitRoot()
		{
			Root = new StackLayout()
			{
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};
		}

		protected override void HandleLanscapeChange()
		{
		}

		protected override void HandlePortraitChange()
		{
		}

		#region View by View Initializers

		/// <summary>
		/// Initializes the Top Stack as a StackLayout and adds its descendants'
		/// InitIconImage
		/// InitTitleDetailStack
		/// </summary>
		/// <returns></returns>
		protected virtual View InitTopStack()
		{
			var view = new StackLayout()
			{
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = 5,
				Spacing = 10,
				Children =
				{
					InitIconImage(),
					InitTitleDetailStack(),
				}
			};
			return view;
		}

		/// <summary>
		/// For Android only, draws a line (separator on list itens)
		/// </summary>
		/// <returns></returns>
		protected virtual View InitLineSeparator()
		{
			var view = new BoxView
			{
				HeightRequest = 1,
				BackgroundColor = _theme.LineLight,
				Color = _theme.LineLight,
				VerticalOptions = LayoutOptions.EndAndExpand
			};

			return view;
		}

		/// <summary>
		/// Initializes the TitleDetail Stack as a StackLayout and adds its descendants'
		/// InitTitleLabel
		/// InitDetailStack
		/// </summary>
		/// <returns></returns>
		protected virtual View InitTitleDetailStack()
		{
			var view = new StackLayout()
			{
                Spacing = 0,
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start,
				Children =
				{
					InitTitleLabel(),
					InitDetailStack()
				}
			};
			return view;
		}

		/// <summary>
		/// Initializes the Detail Stack as a StackLayout and adds its descendants'
		/// InitDetailLabel
		/// InitDateLabel
		/// </summary>
		/// <returns></returns>
		protected virtual View InitDetailStack()
		{
			var view = new StackLayout
			{
                Spacing = 0,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Orientation = StackOrientation.Vertical,
				Children =
				{
					InitDetailLabel(),
					InitDateLabel(),
				}
			};
			return view;
		}

		protected virtual StackLayout InitDateLabel()
		{
            Label date = new Label
			{
				Font = Font.SystemFontOfSize(15),
				TextColor = _theme.EditTextText,
				HorizontalOptions = LayoutOptions.StartAndExpand,
			};
            date.SetBinding(Label.TextProperty, "DateString");

            Label time = new Label
            {
                Font = Font.SystemFontOfSize(15),
                TextColor = _theme.EditTextText,
                HorizontalOptions = LayoutOptions.EndAndExpand,
            };
            time.SetBinding(Label.TextProperty, "TimeString");

            StackLayout dateTimeRow = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = { date, time },
            };

            return dateTimeRow;
		}

		protected virtual View InitDetailLabel()
		{
			var view = new Label
			{
				LineBreakMode = LineBreakMode.TailTruncation,
				Font = Font.SystemFontOfSize(15),
				TextColor = _theme.FontMainColor,
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};
			view.SetBinding(Label.TextProperty, "TextContent");
			return view;
		}

		protected virtual View InitTitleLabel()
		{
			var view = new Label()
			{
                TextColor = _theme.Accent,
				LineBreakMode = LineBreakMode.TailTruncation,
				HorizontalOptions = LayoutOptions.StartAndExpand,
                Resources = _theme.LabelStyleNormalBold
			};
			view.SetBinding(Label.TextProperty, "Title");

            Image arrow = new Image
            {
                HeightRequest = 15,
                WidthRequest = 15,
                VerticalOptions = LayoutOptions.EndAndExpand,
                Source = DependencyService.Get<IGetResources>().GetImageSourceFromResourceId(_theme.DoubleArrowIco)
            };

            StackLayout row = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = { view, arrow },
            };
			return row;
		}

		protected virtual View InitIconImage()
		{
            
			var view = new Image
			{
				HeightRequest = 17,
				WidthRequest = 17,
				VerticalOptions = LayoutOptions.Start

			};
            view.SetBinding(Image.SourceProperty, new Binding("Context", BindingMode.Default, new ConvertStringToResource(), null));

			return view;
		}

		#endregion View by View Initializers
	}
}