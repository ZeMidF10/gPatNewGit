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
    public class PatientTemplate : ViewCell
    {
        public Label IdentifierLabel, NameLabel, IdadeLabel, NotesLabel;
        private ITheme theme = VisualService.Instance.ThemeManager.Theme;

        public PatientTemplate()
        {
            Height = Device.OnPlatform(100, 100, 100);

            #region Build layout           

            Image PhotoImage = new Image
            {
                //HeightRequest = 50,
                //WidthRequest = 50,
                //Aspect = Aspect.Fill
                Aspect = Aspect.AspectFit
                //Aspect = Aspect.AspectFill,
            }; // FIll estica, aspectfit mantem o racio

            //if (Device.OS == TargetPlatform.iOS)
            //    PhotoImage.Aspect = Aspect.AspectFill;

            PhotoImage.SetBinding(Image.SourceProperty, new Binding("Photo", BindingMode.Default, new ConvertStringToResource(), null));


            StackLayout imgContainer = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand, //LayoutOptions.Start,
                //HeightRequest = 80,
                WidthRequest = 80,
                Orientation = StackOrientation.Vertical,
                Children =
                {
                    PhotoImage,
                    //BuildRiskLayout(),
                }
            };


            IdentifierLabel = new Label
            {
                TextColor = theme.Accent, //Color.Black,
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.Fill,
                Resources = theme.LabelStyleNormalBold,
            };
            IdentifierLabel.SetBinding(Label.TextProperty, "Identifier");


            StackLayout identifierContainer = new StackLayout
            {
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.Fill,
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    IdentifierLabel,
                    BuildRiskLayout()
                }
            };

            NameLabel = new Label
            {
                TextColor = theme.Accent, //Color.Black,
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.Fill,
                Font = Font.SystemFontOfSize(Device.OnPlatform(14, 15, 16)),
                LineBreakMode = LineBreakMode.TailTruncation,
                Resources = theme.LabelStyleSuperSmall,
            };
            NameLabel.SetBinding(Label.TextProperty, "Name");


            IdadeLabel = new Label
            {
                TextColor = theme.RowLabel,
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.Fill,
                Font = Font.SystemFontOfSize(Device.OnPlatform(14, 15, 16)),
                Resources = theme.LabelStyleSuperSmall,
            };
            IdadeLabel.SetBinding(Label.TextProperty, "Idade");

            NotesLabel = new Label
            {
                TextColor = theme.RowLabel,
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.Fill,
                Font = Font.SystemFontOfSize(Device.OnPlatform(14, 15, 16)),
                LineBreakMode = LineBreakMode.TailTruncation,
                Resources = theme.LabelStyleSuperSmall,
            };
            NotesLabel.SetBinding(Label.TextProperty, new Binding("Alertas",
               BindingMode.Default,
               new ConvertListToString()));

            Label EnfLabel = new Label
            {
                TextColor = Color.Black,
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.Fill,
                Font = Font.SystemFontOfSize(Device.OnPlatform(14, 15, 16)),
                Resources = theme.LabelStyleSuperSmall,
            };
            EnfLabel.SetBinding(Label.TextProperty, "ResponsibleNurse");

            Image arrow = new Image
            {
                HeightRequest = 15,
                WidthRequest = 15,
                VerticalOptions = LayoutOptions.Start,
                Source = DependencyService.Get<IGetResources>().GetImageSourceFromResourceId(theme.DoubleArrowIco)
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
                //VerticalOptions = LayoutOptions.FillAndExpand,
                Spacing = 0,
                Padding = 0,
                Children = {
                    new StackLayout(){
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        //VerticalOptions = LayoutOptions.FillAndExpand,
                        Spacing = 10,
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
							        identifierContainer,// IdentifierLabel,
                                    NameLabel,
                                    IdadeLabel,
                                    EnfLabel,
                                    NotesLabel,
						        }
                            },
                            arrow
                        },
					},
				}
            };

            if (Device.OS == TargetPlatform.Android)
                mainLayout.Children.Add(lineSeparator);

            View = mainLayout;

            #endregion
        }


        private StackLayout BuildRiskLayout()
        {
            StackLayout RiskAttr = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Horizontal,
                HeightRequest = 20,
                WidthRequest = 50,
                Padding = 0,
                Spacing = 10,
            };

            Image riskSlot1 = new Image()
            {
                HeightRequest = 20,
                WidthRequest = 20,
                Source = null
            };
            riskSlot1.SetBinding(Image.SourceProperty, "Risk1", converter: new ConvertRiskStringsToIcons());
            riskSlot1.SetBinding(Image.IsVisibleProperty, "Risk1", converter: new ConvertHasStringToBool());

            Image riskSlot2 = new Image()
            {
                HeightRequest = 20,
                WidthRequest = 20,
                Source = null
            };
            riskSlot2.SetBinding(Image.SourceProperty, "Risk2", converter: new ConvertRiskStringsToIcons());
            riskSlot2.SetBinding(Image.IsVisibleProperty, "Risk2", converter: new ConvertHasStringToBool());

            RiskAttr.Children.Add(riskSlot1);
            //RiskAttr.Children.Add(riskSlot2);

            return RiskAttr;
        }
    }
}


        

