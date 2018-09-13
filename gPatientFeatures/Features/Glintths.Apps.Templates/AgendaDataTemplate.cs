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
    public class AgendaDataTemplate : ViewCell
    {
        private ITheme theme = VisualService.Instance.ThemeManager.Theme;

        public AgendaDataTemplate()
        {
            this.Height = theme.BiggestListItemHeight;

            BoxView lineSeparator = new BoxView
            {
                HeightRequest = 1,
                Color = theme.LineLight,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.EndAndExpand
            };

            var viewLayout = new StackLayout()
            {
                BackgroundColor = Color.Transparent,
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start,
                Padding = 0,
                Spacing = 0,
                Children = {
					BuildInfoRows (),
				}
            };
            if (Device.OS == TargetPlatform.Android)
                viewLayout.Children.Add(lineSeparator);

            View = viewLayout;

        }

        public StackLayout BuildInfoRows()
        {
            StackLayout template = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Spacing = 3,
                Padding = 5,
                Children = {
					BuildMedicalActRow (),
                    BuildSpecialtyRow(),
					BuildMedicRow (),
					BuildLocationRow ()
				}
            };


            return template;
        }

        public StackLayout BuildMedicalActRow()
        {
            var img_icon = new Image()
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HeightRequest = theme.IconSize,
                WidthRequest = theme.IconSize,
            };

            img_icon.SetBinding(Image.SourceProperty, new Binding("IconSource", BindingMode.Default, new ConvertStringToResource(), null));

            Label TitleLabel = new Label
            {
                TextColor = theme.FontMainColor,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Start,
                //WidthRequest = UI.ScreenSize.Width - 54,
                LineBreakMode = LineBreakMode.TailTruncation,
                Resources = theme.LabelStyleBig,
            };

            //TitleLabel.SetBinding(Label.TextColorProperty, new Binding("IconSource", BindingMode.Default, new ConvertIconToTitleColor(), null));
            TitleLabel.SetBinding(Label.TextProperty, "Title");

            Image arrowIcon = new Image
            {
                HorizontalOptions = LayoutOptions.EndAndExpand,
                Source = ImageSource.FromResource(theme.DoubleArrowIco),
                HeightRequest = theme.IconSize,
                WidthRequest = theme.IconSize,
            };

            return new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Padding = 0,
                Children = {
					img_icon,
					TitleLabel,
					arrowIcon
				}
            };
        }


        public StackLayout BuildSpecialtyRow()
        {
            var spaceFiller = new BoxView()
            {
                HeightRequest = 1,
                WidthRequest = 15,
                BackgroundColor = Color.Transparent,
            };

            Label specialtyName = new Label()
            {
                TextColor = theme.RowName,
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.Start,
                //WidthRequest = UI.ScreenSize.Width - 30,
                LineBreakMode = LineBreakMode.TailTruncation,
                Resources = theme.LabelStyleNormal,
            };
            specialtyName.SetBinding(Label.TextProperty, "Specialty");
            StackLayout sl = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = {
                    spaceFiller,
                    specialtyName
                }
            };
            //sl.SetBinding(StackLayout.IsVisibleProperty, new Binding("Specialty", BindingMode.Default, new ConvertSpecialityToVisible()));

            return sl;
        }

        public StackLayout BuildMedicRow()
        {
            var spaceFiller = new BoxView()
            {
                HeightRequest = 1,
                WidthRequest = 15,
                BackgroundColor = Color.Transparent,
            };

            Label dName = new Label()
            {
                TextColor = theme.RowName,
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.Start,
                //WidthRequest = UI.ScreenSize.Width - 30,
                LineBreakMode = LineBreakMode.TailTruncation,
                Resources = theme.LabelStyleNormal,
            };
            dName.SetBinding(Label.TextProperty, "DoctorName");

            return new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = {
					spaceFiller,
					dName
				}
            };
        }

        public StackLayout BuildLocationRow()
        {
            var spaceFiller = new BoxView()
            {
                HeightRequest = 1,
                WidthRequest = 15,
                BackgroundColor = Color.Transparent,
            };

            Label lbl_local = new Label()
            {
                TextColor = theme.RowLabel,
                HorizontalOptions = LayoutOptions.Start,
                //WidthRequest = UI.ScreenSize.Width - 80,
                LineBreakMode = LineBreakMode.TailTruncation,
                Resources = theme.LabelStyleNormal,
            };

            lbl_local.SetBinding(Label.TextProperty, "Local");

            Label lbl_time = new Label()
            {
                TextColor = theme.RowLabel,
                HorizontalOptions = LayoutOptions.EndAndExpand,
                LineBreakMode = LineBreakMode.TailTruncation,
                Resources = theme.LabelStyleNormal,
            };
            lbl_time.SetBinding(Label.TextProperty, "Time");

            return new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = {
					spaceFiller,
					lbl_local,
					lbl_time
				}
            };
        }
    }
}
