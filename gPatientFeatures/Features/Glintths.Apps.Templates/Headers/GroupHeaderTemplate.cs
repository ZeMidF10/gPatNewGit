using Glintths.Apps.Themes;
using Xamarin.Forms;

namespace Glintths.Apps.Templates
{
    public class GroupHeaderTemplate : ViewCell
    {
        private ITheme theme = VisualService.Instance.ThemeManager.Theme;

        public GroupHeaderTemplate()
        {
            Height = 35;

            Label titulo = new Label
            {
                TextColor = theme.LabelTextDark,
                Font = Font.SystemFontOfSize(15, FontAttributes.Bold),
                VerticalOptions = LayoutOptions.CenterAndExpand,
                YAlign = TextAlignment.Center
            };

            StackLayout titulo_layout = new StackLayout
            {
                BackgroundColor = Color.FromRgb(238, 238, 238),
                Padding = new Thickness(5, 5, 0, 5),
                Spacing = 0,
                Children = { titulo },
                VerticalOptions = LayoutOptions.FillAndExpand,
            };

            titulo.SetBinding(Label.TextProperty, "HeaderTitle");

            BoxView lineSeparator = new BoxView
            {
                HeightRequest = 1,
                Color = theme.LineLight,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                //VerticalOptions = LayoutOptions.EndAndExpand
            };

            StackLayout mainStack = new StackLayout()
            {

                //BackgroundColor = theme.LightBackground,
                //Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                //Padding = 5,
                Spacing = 0,
                Children = { titulo_layout },
            };

            View = mainStack;
        }

    }
}