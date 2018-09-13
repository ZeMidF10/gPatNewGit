using System;
using Xamarin.Forms;
using Glintths.Apps.Base.Interfaces;
using Glintths.Apps.Controls;

namespace Glintths.Apps.Templates
{
	public class IncomeByCompanyTemplate : BaseCellTemplate
	{
		public IncomeByCompanyTemplate () : base ()
		{

			Init ();
			Draw ();
			View = Root;
		}

		#region implemented abstract members of BaseCellTemplate

		protected override void Draw ()
		{
			foreach (var view in _views) {
				Root.Children.Add (view);
			}
		}

		protected override void Init ()
		{
			InitRoot ();
			_views.Add (InitInstitutionLabel ());
			_views.Add (InitIncomeControl ());
			_views.Add (InitArrowImage ());
		}

		protected override void InitRoot ()
		{
			Root = new StackLayout () {
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness (5, 0)
			};
		}

		protected override void HandleLanscapeChange ()
		{
		}

		protected override void HandlePortraitChange ()
		{
		}

		#endregion

		#region View By View Initializers

		protected virtual View InitInstitutionLabel ()
		{
			var view = new Label () {
				Text = "[Institution Name]",
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.Start
			};
			view.SetBinding (Label.TextProperty, "Company.Name");
			return view;
		}


		protected virtual View InitIncomeControl ()
		{
			var view = new ValueStack ();
			return view;
		}

	
		protected virtual View InitArrowImage ()
		{
			var view = new Image () {
				Source = DependencyService.Get<IGetResources> ().GetImageSourceFromResourceId (_theme.ArrowIco),
				HorizontalOptions = LayoutOptions.End,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};
			return view;
		}


		#endregion
	}
}

