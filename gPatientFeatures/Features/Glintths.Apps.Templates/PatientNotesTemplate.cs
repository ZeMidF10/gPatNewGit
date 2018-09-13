using Glintths.Apps.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Glintths.Apps.Templates
{
    public class PatientNotesTemplate : ViewCell
    {
        private ITheme theme = VisualService.Instance.ThemeManager.Theme;

        public PatientNotesTemplate()
        {
            Label title = new Label
            {
                HeightRequest = 20,
                TextColor = theme.LabelTextDark,
                //Font = theme.NormTitleListFont,
                //HorizontalOptions = LayoutOptions.FillAndExpand,
                LineBreakMode = LineBreakMode.TailTruncation,
                Resources = theme.LabelStyleNormal
            };

            if (Device.OS == TargetPlatform.Android)
                title.LineBreakMode = LineBreakMode.WordWrap;

            title.SetBinding(Label.TextProperty, "PatientNoteTitle");

            Label creatorTitleLbl = new Label
            {
                TextColor = Color.Black,
                Text = "Enf.:",
                HorizontalOptions = LayoutOptions.Start,
                Resources = theme.LabelStyleSmall
            };

            Label creator = new Label
            {
                TextColor = Color.Gray,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Resources = theme.LabelStyleSmall
            };
            creator.SetBinding(Label.TextProperty, "PatientNoteCreator");

            StackLayout creatorLayout = new StackLayout
            {
                HeightRequest = 20,
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    creatorTitleLbl,
                    creator
                }
            };

            Label dateLbl = new Label
            {
                HeightRequest = 20,
                TextColor = Color.Gray,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Resources = theme.LabelStyleSmall
            };
            dateLbl.SetBinding(Label.TextProperty, "PatientNoteDate");

            BoxView lineSeparator = new BoxView
            {
                HeightRequest = 1,
                Color = theme.LineLight,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.EndAndExpand,
            };

            StackLayout main = new StackLayout()
            {
                Padding = new Thickness(10, 5, 10, 0),
                Spacing = 0,
                HeightRequest = 80,
                MinimumHeightRequest = 80,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = { 
                    title,
                    creatorLayout,
                    dateLbl
                },
            };

            if (Device.OS == TargetPlatform.Android)
                main.Children.Add(lineSeparator);

            View = main;
        }
    }
}
