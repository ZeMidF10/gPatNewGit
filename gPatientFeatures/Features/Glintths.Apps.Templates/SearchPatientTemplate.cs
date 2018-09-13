using Glintths.Apps.Base.Interfaces;
using Glintths.Apps.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Glintths.Apps.Controls;
using Glintths.Apps.Base.ViewModels;

namespace Glintths.Apps.Templates
{

    public class SearchPatientTemplate : ViewCell
    {
        private ITheme theme = VisualService.Instance.ThemeManager.Theme;

        public SearchPatientTemplate()
        {

            StackLayout identifierContainer = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Start,
                WidthRequest = 100,
                MinimumWidthRequest = 100,
            };

            Label identifier = new Label
            {
                Resources = theme.LabelStyleNormal,
                TextColor = theme.Accent,
                XAlign = TextAlignment.End,
                LineBreakMode = LineBreakMode.TailTruncation,
            };
            identifier.SetBinding(Label.TextProperty, "Identifier");
            identifierContainer.Children.Add(identifier);

            StackLayout nameContainer = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            Label text = new Label
            {
                Resources = theme.LabelStyleNormal,
                TextColor = theme.LabelTextDark,
                LineBreakMode = LineBreakMode.TailTruncation,
            };
            text.SetBinding(Label.TextProperty, "Name");
            nameContainer.Children.Add(text);

            Image arrow = new Image
            {
                HeightRequest = 15,
                WidthRequest = 15,
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.End,
                Source = DependencyService.Get<IGetResources>().GetImageSourceFromResourceId(theme.DoubleArrowIco)
            };


            StackLayout text_container = new StackLayout
            {
                Padding = new Thickness(10, 5, 10, 0),
                Children = { identifierContainer, nameContainer, arrow },
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Horizontal
            };



            StackLayout main = new StackLayout
            {
                Children = { text_container },
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Spacing = 5,
            };

            if (Device.OS == TargetPlatform.Android)
            {
                BoxView lineSeparator = new BoxView
                {
                    HeightRequest = 1,
                    Color = theme.LineLight,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.End,
                };

                main.Children.Add(lineSeparator);
            }

            View = main;

        }
    }
}
