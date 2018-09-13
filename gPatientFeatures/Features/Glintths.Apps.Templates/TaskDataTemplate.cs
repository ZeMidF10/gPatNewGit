using Glintths.Apps.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Glintths.Apps.Templates
{
    public class TaskDataTemplate : ViewCell
    {
        private ITheme theme = VisualService.Instance.ThemeManager.Theme;

        public TaskDataTemplate()
        {
            this.Height = 60;

            BoxView lineSeparator = new BoxView
            {
                HeightRequest = 1,
                Color = theme.LineLight,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.EndAndExpand
            };

            StackLayout viewLayout = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start,
                Padding = new Thickness(60, 5, 5, 5),
                Spacing = 0,
                Children = { BuildFirstRow(), BuildSecondRow() }
            };

            StackLayout listviewWrap = new StackLayout()
            {
                Children = {
                viewLayout, 
            }
            };

            if (Device.OS == TargetPlatform.Android)
                listviewWrap.Children.Add(lineSeparator);

            View = listviewWrap;
        }

        public Label BuildFirstRow()
        {
            var dName = new Label()
            {
                TextColor = theme.LabelTextDark,
                VerticalOptions = LayoutOptions.Fill,
                //Font = Font.SystemFontOfSize(15),
                Resources = theme.LabelStyleNormal
            };
            dName.SetBinding(Label.TextProperty, "Patient");

            return dName;
        }

        public Label BuildSecondRow()
        {
            Label TitleLabel = new Label
            {
                TextColor = theme.LabelTextMedium,
                VerticalOptions = LayoutOptions.Center,
                Font = Font.SystemFontOfSize(15),
                Resources = theme.LabelStyleNormal
            };

            if (Device.OS == TargetPlatform.Android)
                TitleLabel.WidthRequest = 250;      // TODO: remover tamanho estatico, esta a ser usado para cortar a linha e evitar que saia do ecra

            TitleLabel.SetBinding(Label.TextProperty, "Description");

            return TitleLabel;
        }
    }
}
