using Glintths.Apps.Themes;
using System;
using Xamarin.Forms;

namespace Glintths.Apps.Templates
{
	/// <summary>
	/// Template for schedule cell with Label and switch
	/// On Android an aditional line on bottom is drawn
	/// </summary>
	public class ScheduleSlot : BaseCellTemplate
	{

		/// <summary>
		/// Event to be Triggered on slot switch toggle
		/// </summary>
		public static EventHandler<ToggledEventArgs> SlotToggleEvent
		{
			get;
			set;
		}

		public ScheduleSlot()
			: base()
		{
			Init();
			Draw();
			View = Root;
		}

		/// <summary>
		/// Draw elements on Root layout
		/// </summary>
		protected override void Draw()
		{
			foreach (var view in _views)
			{
				Root.Children.Add(view);
			}
		}

		/// <summary>
		/// Init Root and its descendant views
		/// TopStack
		/// LineSeparator (Android)
		/// </summary>
		protected override void Init()
		{
			InitRoot();

			_views.Add(InitTopStack());
			if (TargetPlatform.Android == Device.OS)
			{
				_views.Add(InitLineSeparator());
			}
		}

		/// <summary>
		/// Initializes Root as a StackLayout
		/// </summary>
		protected override void InitRoot()
		{
			Root = new StackLayout()
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Spacing = 5,
				Padding = new Thickness(10, 5)
			};
		}

		protected override void HandleLanscapeChange()
		{
		}

		protected override void HandlePortraitChange()
		{
		}

		#region View By View Initializers

		/// <summary>
		/// Initializes the Top Stack as a StackLayout and adds its descendants'
		/// SlotTextLabel
		/// Switch
		/// </summary>
		/// <returns></returns>
		protected virtual Xamarin.Forms.View InitTopStack()
		{
			var view = new StackLayout()
			{
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Spacing = 10,
			};
			view.Children.Add(InitSlotTextLabel());
			view.Children.Add(InitSwitch());
			return view;
		}

		protected virtual Xamarin.Forms.View InitSlotTextLabel()
		{
			var view = new Label()
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.Center,
				Resources = _theme.LabelStyleNormal
			};
			view.SetBinding(Label.TextProperty, "Text");
			return view;
		}

		protected virtual Xamarin.Forms.View InitSwitch()
		{
			var view = new Switch()
			{
				HorizontalOptions = LayoutOptions.End,
				VerticalOptions = LayoutOptions.Center,
				IsToggled = true
			};

			view.SetBinding(Switch.IsToggledProperty, "Toggle");
			view.SetBinding(Switch.ClassIdProperty, "Id");
			view.Toggled += SwitchToggleEvent;
			return view;
		}

		/// <summary>
		/// Event that is triggered on swicth state toggled
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SwitchToggleEvent(object sender, ToggledEventArgs e)
		{
			SlotToggleEvent.Invoke(sender, e);
		}

		protected virtual Xamarin.Forms.View InitLineSeparator()
		{
			var view = new BoxView
			{
				HeightRequest = 1,
				BackgroundColor = _theme.LineLight,
				Color = _theme.LineLight,
				VerticalOptions = LayoutOptions.Center
			};

			return view;
		}

		#endregion View By View Initializers
	}
}