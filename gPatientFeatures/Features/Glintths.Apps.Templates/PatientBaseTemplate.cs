using Glintths.Apps.Base.Interfaces;
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
    public class PatientBaseTemplate : ViewCell
    {
        public ITheme theme = VisualService.Instance.ThemeManager.Theme;
        public Image PhotoImage;
        public Image ArrowImage;
        public Label NameLabel, IdentifierLabel, AgeLabel, RightTopLabel, RightBotLabel, BotLabel;

        public PatientBaseTemplate()
        {
            StackLayout minorContentLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Spacing = 0,
                Children = { PatientCoreInformation(), RightSide() },
            };

            StackLayout contentLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Spacing = 0,
                Children = { minorContentLayout, BottomInfo() },
            };

            StackLayout main = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Padding = 5,
                Children = { PhotoLayout(), contentLayout, Arrow() },
            };

            StackLayout mainLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Spacing = 0,
                Padding = 0,
                Children = { main },
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

                mainLayout.Children.Add(lineSeparator);
            }

            View = mainLayout;
        }

        private StackLayout PhotoLayout()
        {
            PhotoImage = new Image
            {
                Aspect = Aspect.AspectFit,
            };
            PhotoImage.SetBinding(Image.SourceProperty, new Binding("Photo", BindingMode.Default, new ConvertStringToResource()));

            StackLayout imgContainer = new StackLayout
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Start,
                WidthRequest = 80,
                HeightRequest = 80,
                Orientation = StackOrientation.Vertical,
                Children = { PhotoImage },
            };
            return imgContainer;
        }

        private StackLayout PatientCoreInformation()
        {
            NameLabel = new Label
            {
                TextColor = Color.Black,
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Font = Font.SystemFontOfSize(18, FontAttributes.Bold),
                LineBreakMode = LineBreakMode.TailTruncation,
            };

            IdentifierLabel = new Label
            {
                TextColor = Color.Black,
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Font = Font.SystemFontOfSize(16),
            };

            AgeLabel = new Label
            {
                TextColor = theme.RowLabel,
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Font = Font.SystemFontOfSize(16),
                Text = "24/10/1991 (23 anos)",
            };

            StackLayout main = new StackLayout
            {
                Spacing = 5,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = { NameLabel, IdentifierLabel, AgeLabel },
            };

            return main;
        }

        private StackLayout RightSide()
        {
            RightTopLabel = new Label
            {
                TextColor = Color.Silver,
                Resources = theme.LabelStyleTheBiggest,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };

            RightBotLabel = new Label
            {
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };

            StackLayout rightSide = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.EndAndExpand,
                Children = { RightTopLabel, RightBotLabel },
                Spacing = 0,
            };

            return rightSide;
        }

        private Label BottomInfo()
        {
            BotLabel = new Label
            {
                TextColor = Color.Silver,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Font = Font.SystemFontOfSize(16),
            };

            return BotLabel;
        }

        private StackLayout Arrow()
        {
            ArrowImage = new Image
            {
                HeightRequest = 15,
                WidthRequest = 15,
                HorizontalOptions = LayoutOptions.End,
                Source = DependencyService.Get<IGetResources>().GetImageSourceFromResourceId(theme.DoubleArrowIco)
            };
            StackLayout main = new StackLayout
            {
                Children = { ArrowImage },
            };
            return main;
        }
    }
}
