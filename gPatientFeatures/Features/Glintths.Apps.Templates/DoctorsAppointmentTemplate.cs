using Glintths.Apps.Base.Interfaces;
using Glintths.Apps.Themes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Glintths.Apps.Templates
{
    public class DoctorsAppointmentTemplate : ViewCell
    {
        private ITheme theme = VisualService.Instance.ThemeManager.Theme;

        public DoctorsAppointmentTemplate()
        {
            Label title = new Label() { 
                HorizontalOptions = LayoutOptions.Start, 
                LineBreakMode = LineBreakMode.TailTruncation, 
                Font = Font.OfSize("Helvetica", 16),
                TextColor = theme.SelectionColor,
            };
            title.SetBinding(Label.TextProperty, "TDoenteDoente");

            Label PatientName = new Label() { 
                HorizontalOptions = LayoutOptions.StartAndExpand, 
                Font = Font.OfSize("Helvetica", 12), 
                TextColor = Color.Black, 
            };
            PatientName.SetBinding(Label.TextProperty, "DoenteName");

            Label MedicalAct = new Label() { 
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Font = Font.OfSize("Helvetica", 12), 
                TextColor = Color.Silver,
            };
            MedicalAct.SetBinding(Label.TextProperty, "MedicalAct");

            StackLayout center = new StackLayout()
            {
                Spacing = 2,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = { title, PatientName, MedicalAct },
            };


            Label hour = new Label() {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Font = Font.OfSize("Helvetica", 16),
                TextColor = Color.Silver, 
            };
            hour.SetBinding(Label.TextProperty, new Binding(path: "Begin", stringFormat: "{0:HH:mm}"));

            Label duration = new Label() {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand, 
                Font = Font.OfSize("Helvetica", 20),
                TextColor = Color.Black,
            };
            duration.SetBinding(Label.TextProperty, "DurationInMinutes");

            Label min = new Label()
            {
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Font = Font.OfSize("Helvetica", 12),
                TextColor = Color.Black,
                Text = "min",
            };

            StackLayout durationMin = new StackLayout
            {
                Padding = 0,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Spacing = -6,
                Children = { duration, min },
            };

            StackLayout right = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.EndAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Spacing = 0,
                Children = { hour, durationMin },
            };

            Image img = new Image
            {
                Source = DependencyService.Get<IGetResources>().GetImageSourceFromResourceId(VisualService.Instance.ThemeManager.Theme.AtosMarcacaoIcon),
                HeightRequest = 15,
                WidthRequest = 15,
                VerticalOptions = LayoutOptions.StartAndExpand,
            };
            StackLayout imgLayout = new StackLayout
            {
                Padding = new Thickness(0, 7, 0, 0),
                Children = { img },
            };

            StackLayout row = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Spacing = 5,
                Padding = 5,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = { imgLayout, center, right },
            };

            BoxView lineSeparator = new BoxView
            {
                HeightRequest = 1,
                Color = VisualService.Instance.ThemeManager.Theme.LineLight,
                HorizontalOptions = LayoutOptions.FillAndExpand, // CenterAndExpand tem problemas
                VerticalOptions = LayoutOptions.End,
            };
            StackLayout content = new StackLayout
            {
                Spacing = 0,
                Children = {row, lineSeparator},
            };
            View = content;
        }
    }

    class ConvertMinutesToString : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is int)
            {
                try
                {
                    return value + " min";
                    //return ((DateTime)value).ToString("", CultureInfo.InvariantCulture);
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Error: Could not convert date");
                    throw new Exception("Could not convert date");
                }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
