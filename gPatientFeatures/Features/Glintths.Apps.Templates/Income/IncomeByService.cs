using System;
using Xamarin.Forms;
using Glintths.Apps.Controls;

namespace Glintths.Apps.Templates
{
	public class IncomeByServiceTemplate : BaseCellTemplate
	{
		public IncomeByServiceTemplate () : base ()
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
			_views.Add (InitSrvNameLabel ());
			_views.Add (InitValueControl ());
		}

		protected override void InitRoot ()
		{
			Root = new StackLayout () {
				Padding = new Thickness (5, 0),
				Orientation = StackOrientation.Horizontal,
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

		protected virtual View InitSrvNameLabel ()
		{
			var view = new Label () {
				Text = "[SERVICE NAME]",
				VerticalOptions = LayoutOptions.CenterAndExpand,
			};
			return view;
		}

		protected virtual View InitValueControl ()
		{
			var view = new ValueStack ();
			return view;
		}

		#endregion
	}
}

