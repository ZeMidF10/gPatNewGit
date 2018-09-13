using Xamarin.Forms;

namespace Glintths.Apps.Controls
{
	public class ValueStack : StackLayout
	{
		public ValueStack () : base ()
		{
			Init ();
		}

		protected virtual void Init ()
		{
			Spacing = 5;
			VerticalOptions = LayoutOptions.FillAndExpand;
			HorizontalOptions = LayoutOptions.EndAndExpand;
			Orientation = StackOrientation.Vertical;
			Children.Add (InitValueStack ());
			Children.Add (InitPercentageLabel ());
		}


		#region View By View Initializers

		#region ValueStack

		protected virtual View InitValueStack ()
		{
			var view = new StackLayout () {
				Orientation = StackOrientation.Horizontal,
				Children = {
					InitValueLabel (),
					InitCurrencyLabel (),
				}
			};
			return view;
		}

		protected virtual View  InitValueLabel ()
		{
			var view = new Label () {
				Text = "[Value]",
				XAlign = TextAlignment.Center,
				YAlign = TextAlignment.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			view.SetBinding(Label.TextProperty, "Value");
			return view;
		}

		protected virtual View InitCurrencyLabel ()
		{
			var view = new Label () {
				Text = "[€]",
			};
			return view;
		}


		#endregion

		protected virtual View  InitPercentageLabel ()
		{
			var view = new Label () {
				Text = "[%]",
				XAlign = TextAlignment.Center,
				YAlign = TextAlignment.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};
			view.SetBinding (Label.TextProperty, "FactorStr");
			return view;
		}

		#endregion

	}
}

