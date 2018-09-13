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
    public class NewPatientTemplate : ViewCell
    {
        private ITheme theme = VisualService.Instance.ThemeManager.Theme;

        public NewPatientTemplate()
        {
            Height = 80;

            BoxView lineSeparator = new BoxView
            {
                HeightRequest = 1,
                Color = theme.LineLight,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            StackLayout mainLayout = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Spacing = 0,
                Padding = 0,
                Children = {
                    new StackLayout(){
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Spacing = 0,
				        Padding = 5,
                        Children = {
                            PhotoLayout(),
                            PatientCoreInformation(),
                            RightSide(),
                            Arrow(),
                        },
					},
				}
            };

            if (Device.OS == TargetPlatform.Android)
                mainLayout.Children.Add(lineSeparator);

            View = mainLayout;
        }

        private StackLayout PatientCoreInformation()
        {
            Label NameLabel = new Label
            {
                TextColor = Color.Black,
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Font = Font.SystemFontOfSize(18, FontAttributes.Bold),
                LineBreakMode = LineBreakMode.TailTruncation,
                //Resources = theme.LabelStyleSuperSmall,
            };
            NameLabel.SetBinding(Label.TextProperty, "Name");

            Label IdentifierLabel = new Label
            {
                TextColor = Color.Black,
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Font = Font.SystemFontOfSize(12),
                //Resources = theme.LabelStyleNormalBold,
            };
            IdentifierLabel.SetBinding(Label.TextProperty, "Identifier");

            Label AgeLabel = new Label
            {
                TextColor = theme.RowLabel,
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Font = Font.SystemFontOfSize(12),
                //Resources = theme.LabelStyleSuperSmall,
            };
            AgeLabel.SetBinding(Label.TextProperty, new Binding("DataNasc", BindingMode.Default, new ConvertDateTimeToAge()));

            StackLayout main = new StackLayout
            {
                Spacing = 5,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Children = { NameLabel, IdentifierLabel, AgeLabel },
            };

            return main;
        }

        private StackLayout RightSide()
        {
            Label info = new Label
            {
                TextColor = Color.Black,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Font = Font.SystemFontOfSize(16),
            };
            info.SetBinding(Label.TextProperty, new Binding("ActiveEpisodeType", BindingMode.Default, new ConvertEpisodeTypeToAbr()));

            Label TimeLabel = new Label
            {
                TextColor = theme.RowLabel,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Font = Font.SystemFontOfSize(14),
            };
            TimeLabel.SetBinding(Label.TextProperty, "ActiveEpisodeTime");

            StackLayout main = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = { info, TimeLabel },
                MinimumWidthRequest = 60,
            };

            return main;
        }

        private StackLayout Arrow()
        {
            Image arrow = new Image
            {
                HeightRequest = 15,
                WidthRequest = 15,
                HorizontalOptions = LayoutOptions.End,
                Source = DependencyService.Get<IGetResources>().GetImageSourceFromResourceId(theme.DoubleArrowIco)
            };
            StackLayout main = new StackLayout
            {
                Children = { arrow },
            };
            return main;
        }

        private StackLayout PhotoLayout()
        {
            Image PhotoImage = new Image
            {
                Aspect = Aspect.AspectFit,
            };
            PhotoImage.SetBinding(Image.SourceProperty, new Binding("Photo", BindingMode.Default, new ConvertStringToResource(), null));

            StackLayout imgContainer = new StackLayout
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                WidthRequest = 80,
                Orientation = StackOrientation.Vertical,
                Children = { PhotoImage },
            };
            return imgContainer;
        }
    }
}
