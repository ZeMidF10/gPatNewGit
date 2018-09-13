using Glintths.Apps.Base.Interfaces;
using Glintths.Apps.Base.ViewModels;
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
    public class PatientHeaderTemplate : StackLayout
    {
        ITheme theme = VisualService.Instance.ThemeManager.Theme;

        public PatientHeaderTemplate()
        {

            this.BindingContext = ViewModelLocator.Instance.PatientDataInfoViewModel.SelectedPatient;
            StackLayout header = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = theme.LightBackground,
                Padding = 5,
                Spacing = 5,
            };

            header.Children.Add(BuildPhotoRisks());
            header.Children.Add(BuildSummary());

            this.Children.Add(header);
        }

        private StackLayout BuildPhotoRisks()
        {
            StackLayout photoRiskLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                WidthRequest = 70,
                //HeightRequest = 45,
                VerticalOptions = LayoutOptions.Center
            };

            Image img_avatar = new Image
            {
                Source = DependencyService.Get<IGetResources>().GetImageSourceFromResourceId(theme.GenericPhoto),
                //HeightRequest = 50,
                //WidthRequest = 70,
                //Aspect = Aspect.Fill
                Aspect = Aspect.AspectFit
            };

            //if (Device.OS == TargetPlatform.iOS)
            //    img_avatar.Aspect = Aspect.AspectFill;


            photoRiskLayout.Children.Add(img_avatar);
            //photoRiskLayout.Children.Add(BuildRiskLayout());

            return photoRiskLayout;
        }

        private StackLayout BuildSummary()
        {
            StackLayout summary = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Spacing = 0,
                Padding = 0,
            };

            
            Label lbl_identifier = new Label
            {
                //Font = Font.SystemFontOfSize(18, FontAttributes.Bold),
                //VerticalOptions = LayoutOptions.End,
                TextColor = theme.LabelTextMediumDark,
                Resources = theme.LabelStyleBigBold,
            };
            lbl_identifier.SetBinding(Label.TextProperty, "Identifier");

            StackLayout lblContainer = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Fill,
                MinimumHeightRequest = 20,
                Children =
                {
                    lbl_identifier,
                    BuildRiskLayout()
                }
            };

            Label lbl_patientName = new Label
            {
                //Font = Font.SystemFontOfSize(18),
                //VerticalOptions = LayoutOptions.End,
                TextColor = theme.LabelTextMediumDark,
                Resources = theme.LabelStyleBig,
            };
            lbl_patientName.SetBinding(Label.TextProperty, "Name");


            Label lbl_patientAge = new Label
            {
                //Font = Font.SystemFontOfSize(18),
                //VerticalOptions = LayoutOptions.End,
                TextColor = theme.LabelTextMediumDark,
                Resources = theme.LabelStyleBig,
            };
            lbl_patientAge.SetBinding(Label.TextProperty, "Idade");

            summary.Children.Add(lblContainer); // lbl_identifier
            summary.Children.Add(lbl_patientName);
            summary.Children.Add(lbl_patientAge);

            return summary;
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
            };
            riskSlot1.SetBinding(Image.SourceProperty, "Risk1", converter: new ConvertRiskStringsToIcons());


            StackLayout riskSlot2 = new StackLayout()
            {
                HeightRequest = 20,
                WidthRequest = 20,
            };
            riskSlot2.SetBinding(Image.SourceProperty, "Risk2", converter: new ConvertRiskStringsToIcons());

            RiskAttr.Children.Add(riskSlot1);
            RiskAttr.Children.Add(riskSlot2);

            return RiskAttr;
        }

    }
}
