using System;
using Xamarin.Forms;

using System.Linq;
using Glintths.Apps.Themes;

namespace Glintths.Apps.Templates
{
    public class MedicScheduleCell : ViewCell
    {
        private ITheme theme = VisualService.Instance.ThemeManager.Theme;

        public MedicScheduleCell()
        {
            StackLayout row = new StackLayout ()
			{
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = 10,
			};

            Label ScheduleLbl = new Label
            {
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                TextColor = theme.LabelTextMedium,
                BackgroundColor = Color.Transparent,
                Resources = theme.LabelStyleNormal,
            };

            Image backgroundImg = new Image
            {
                Source = ImageSource.FromResource(theme.CornerArrowIcon),
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Aspect = Aspect.AspectFill,
                HeightRequest = 5,
                WidthRequest = 5
            };

            Label NameLbl = new Label
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                TextColor = theme.LabelTextDark,
                Resources = theme.LabelStyleNormal,
            };

            ScheduleLbl.SetBinding(Label.TextProperty, "Schedule");
            NameLbl.SetBinding(Label.TextProperty, "MedicName");

            row.Children.Add(ScheduleLbl);
            row.Children.Add(backgroundImg);
            row.Children.Add(NameLbl);

            View = row;
        }
    }
}
