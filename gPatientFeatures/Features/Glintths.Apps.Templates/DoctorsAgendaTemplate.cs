using Glintths.Apps.Base.ValueConverters;
using Glintths.Apps.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Glintths.Apps.Templates
{
    public class DoctorsAgendaTemplate: ViewCell
    {
        private ITheme theme = VisualService.Instance.ThemeManager.Theme;

        public DoctorsAgendaTemplate()
        {
            StackLayout row = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = 0,
                Spacing = 0
                // HeightRequest = 60,
            };

            Label ScheduleLbl = new Label
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                TextColor = theme.LabelTextDark,
                WidthRequest = 50,
                Resources = theme.LabelStyleNormal,
            };
            ScheduleLbl.SetBinding(Label.TextProperty, new Binding(path: "Begin", stringFormat: "{0:HH:mm}"));

            StackLayout schArea = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Spacing = 0,
                VerticalOptions = LayoutOptions.Fill,
                Padding = 0
            };
            schArea.SetBinding(StackLayout.BackgroundColorProperty,
                new Binding("hasSchedules",
                BindingMode.Default,
                new ConvertBoolToColor()));

            BoxView lineSeparator = new BoxView
            {
                HeightRequest = 1,
                Color = theme.LineLight,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.End
            };

            row.Children.Add(ScheduleLbl);
            row.Children.Add(schArea);

            StackLayout mainLayout = new StackLayout()
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Padding = 0,
                Spacing = 0,
                Children =
                {
                    row,
                },
            };

            if (Device.OS == TargetPlatform.Android)
                mainLayout.Children.Add(lineSeparator);

            View = mainLayout;
        }
    }
}
