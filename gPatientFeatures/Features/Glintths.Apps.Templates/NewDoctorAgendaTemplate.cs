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
    public class NewDoctorAgendaTemplate : ViewCell
    {
        private ITheme theme = VisualService.Instance.ThemeManager.Theme;

        public NewDoctorAgendaTemplate()
        {
            Height = 200;

            StackLayout minorContentLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                //VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Spacing = 0,
                //Padding = new Thickness(5, 0),
                Children = { PatientCoreInformation(), RightSide() },
            };

            StackLayout contentLayout = new StackLayout
            {
                //VerticalOptions = LayoutOptions.EndAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Spacing = 0,
                Children = { minorContentLayout, BottomInfo() },
            };

            StackLayout main = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start,
                Children = {PhotoLayout(), contentLayout},
            };

            StackLayout mainLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = 150,
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
            Image PhotoImage = new Image
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
            Label NameLabel = new Label
            {
                TextColor = Color.Black,
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Font = Font.SystemFontOfSize(14, FontAttributes.Bold),
                LineBreakMode = LineBreakMode.TailTruncation,
                //Resources = theme.LabelStyleSuperSmall,
            };
            NameLabel.SetBinding(Label.TextProperty, "DoenteName");

            Label IdentifierLabel = new Label
            {
                TextColor = Color.Black,
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Font = Font.SystemFontOfSize(12),
                //Resources = theme.LabelStyleNormalBold,
            };
            IdentifierLabel.SetBinding(Label.TextProperty, "TDoenteDoente");

            Label AgeLabel = new Label
            {
                TextColor = theme.RowLabel,
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Font = Font.SystemFontOfSize(12),
                Text = "24/10/1991 (23 anos)",
                //Resources = theme.LabelStyleSuperSmall,
            };
            //AgeLabel.SetBinding(Label.TextProperty, new Binding("DataNasc", BindingMode.Default, new ConvertDateTimeToAge()));

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
            Label BeginDay = new Label
            {
                TextColor = Color.Silver,
                Resources = theme.LabelStyleTheBiggest,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            BeginDay.SetBinding(Label.TextProperty, "BeginDay");

            Label BeginHour = new Label
            {
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            BeginHour.SetBinding(Label.TextProperty, "BeginHour");

            StackLayout rightSide = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.EndAndExpand,
                Children = { BeginDay, BeginHour },
                Spacing = 0,
            };

            return rightSide;
        }

        private Label BottomInfo()
        {
            Label MedicalAct = new Label
            {
                TextColor = Color.Silver,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            MedicalAct.SetBinding(Label.TextProperty, "Title");

            return MedicalAct;
        }
    }
}
