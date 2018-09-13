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
    public class NewSearchListPatientTemplate : ViewCell
    {
        private ITheme theme = VisualService.Instance.ThemeManager.Theme;

        public NewSearchListPatientTemplate()
        {
            Height = 80;

            Image PhotoImage = new Image
            {
                Aspect = Aspect.AspectFit,
            };
            PhotoImage.SetBinding(Image.SourceProperty, new Binding("Photo", BindingMode.Default, new ConvertStringToResource(), null));

            StackLayout imgContainer = new StackLayout
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                //HeightRequest = 80,
                WidthRequest = 80,
                Orientation = StackOrientation.Vertical,
                Children = { PhotoImage },
            };

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

            Image arrow = new Image
            {
                HeightRequest = 15,
                WidthRequest = 15,
                HorizontalOptions = LayoutOptions.End,
                Source = DependencyService.Get<IGetResources>().GetImageSourceFromResourceId(theme.DoubleArrowIco),
            };

            StackLayout firstRow = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { NameLabel, arrow },
            };

            Label IdentifierLabel = new Label
            {
                TextColor = Color.Black,
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.Fill,
                Font = Font.SystemFontOfSize(16),
                //Resources = theme.LabelStyleNormalBold,
            };
            IdentifierLabel.SetBinding(Label.TextProperty, "Identifier");

            Label AgeLabel = new Label
            {
                TextColor = theme.RowLabel,
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Font = Font.SystemFontOfSize(16),
                //Resources = theme.LabelStyleSuperSmall,
            };
            AgeLabel.SetBinding(Label.TextProperty, new Binding("DataNasc", BindingMode.Default, new ConvertDateTimeToAge()));

            StackLayout thirdRow = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { AgeLabel },
            };

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
                            imgContainer,
					        new StackLayout(){
						        Orientation = StackOrientation.Vertical,
						        HorizontalOptions = LayoutOptions.FillAndExpand,
                                VerticalOptions = LayoutOptions.FillAndExpand,
						        BackgroundColor = Color.Transparent,
                                Padding = 0,
                                Spacing = 0,
						        Children = {
							        firstRow,
                                    IdentifierLabel,
                                    thirdRow,
						        }
                            },
                        },
					},
				}
            };

            if (Device.OS == TargetPlatform.Android)
                mainLayout.Children.Add(lineSeparator);

            View = mainLayout;
        }
    }
}
