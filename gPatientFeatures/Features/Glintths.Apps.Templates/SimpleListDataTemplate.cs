using Glintths.Apps.Base.Interfaces;
using Glintths.Apps.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Glintths.MobileApps.enfermagem.Core.UI.DataTemplates
{
    public class SimpleListDataTemplate : ViewCell
    {
        private ITheme theme = VisualService.Instance.ThemeManager.Theme;

        //public string BindVariable = "Name";

        public virtual string BindVariable
        {
            get { return "Name"; }
        }

        public SimpleListDataTemplate()
        {

            Label text = new Label
            {
                Resources = theme.LabelStyleNormal,
                TextColor = theme.LabelTextDark,
                LineBreakMode = LineBreakMode.TailTruncation,
            };
            text.SetBinding(Label.TextProperty, BindVariable);

            StackLayout text_container = new StackLayout
            {
                Padding = new Thickness(10, 5, 10, 0),
                Children = { text },
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };

            StackLayout main = new StackLayout
            {
                Children = { text_container },
                Spacing = 5,
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

                main.Children.Add(lineSeparator);
            }

            View = main;
        }
    }

    public class SimpleListDataTemplate2 : SimpleListDataTemplate
    {
        public override string BindVariable
        {
            get { return "IdentifierLabel"; }
        }

        public SimpleListDataTemplate2() : base()
        {
            
        }
    }

   
}