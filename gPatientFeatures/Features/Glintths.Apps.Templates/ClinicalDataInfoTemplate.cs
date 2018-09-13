using Glintths.Apps.Themes;
using Glintths.Apps.ViewModels.ValueConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Glintths.Apps.Templates
{
    public class ClinicalDataInfoTemplate : ViewCell
    {
        private ITheme theme = VisualService.Instance.ThemeManager.Theme;

        public ClinicalDataInfoTemplate()
        {

            Label titleLabel = new Label
            {
                TextColor = theme.FontMainColor,
                Resources = theme.LabelStyleNormal,
                LineBreakMode = LineBreakMode.WordWrap,
                VerticalOptions = LayoutOptions.FillAndExpand

            };
            titleLabel.SetBinding(Label.TextProperty, "Title");

            Label descriptionLabel = new Label
            {
                TextColor = theme.EditTextText,
                Resources = theme.LabelStyleNormal,
                LineBreakMode = LineBreakMode.WordWrap,
                VerticalOptions = LayoutOptions.FillAndExpand

            };
            descriptionLabel.SetBinding(Label.TextProperty, "Description");

            Label dateLabel = new Label
            {
                TextColor = theme.SelectionColor,
                Resources = theme.LabelStyleSmall,
                LineBreakMode = LineBreakMode.WordWrap,
                VerticalOptions = LayoutOptions.FillAndExpand

            };
            dateLabel.SetBinding(Label.TextProperty, new Binding("Date", BindingMode.Default, new ConvertDateToString()));

            StackLayout wrapper = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Padding = 5,
                Spacing = 0,
                Children = 
                {
                    titleLabel,
                    descriptionLabel,   
                    dateLabel
				}
            };

            StackLayout mainLayout = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Transparent,
                Spacing = 0,
                
                Children = 
                {
                    wrapper                    
				}

            };

            if (Device.OS == TargetPlatform.Android)
            {
                BoxView lineSeparator = new BoxView
                {
                    HeightRequest = 1,
                    Color = theme.LineLight,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.EndAndExpand
                };
                mainLayout.Children.Add(lineSeparator);
            }

            View = mainLayout;
        }
    }
}
