using Glintths.Apps.Themes;
using System.ComponentModel;
using Xamarin.Forms;

namespace Glintths.Apps.Templates
{
    public class TaskGroupTemplate : ViewCell
    {
        private ITheme theme = VisualService.Instance.ThemeManager.Theme;
        Label time, title;
        StackLayout v;

        public TaskGroupTemplate()
        {
            Height = 25;

            time = new Label
            {
                Resources = theme.LabelStyleNormal,
                Font = Font.SystemFontOfSize(15, FontAttributes.Bold)
            };
            time.SetBinding(Label.TextProperty, "Time");

            title = new Label
            {
                TextColor = theme.LabelTextDark,
                Font = Font.SystemFontOfSize(15, FontAttributes.Bold),
                Resources = theme.LabelStyleNormalBold,
            };
            title.SetBinding(Label.TextProperty, "Title");

            v = new StackLayout()
            {
                HeightRequest = 20,
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.StartAndExpand,
                Padding = new Thickness(10, 0, 0, 0),
                Spacing = 10,
                Children = { time, title },
            };

            View = v;
        }
    }
}

