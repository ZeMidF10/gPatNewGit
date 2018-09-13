using Glintths.Apps.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Glintths.Apps.Themes.Styles
{
    public class StyleBase : IAppStyle
    {
        public virtual Style GeneralButton
        {
            get
            {
                return new Style(typeof(Button))
                {
                    Setters = {
                        new Setter {Property = Button.BackgroundColorProperty, Value = Color.FromHex("221f1f")},
                        new Setter {Property = Button.TextColorProperty, Value = Color.White},
                        new Setter {Property = Button.BorderRadiusProperty, Value = 0},
                        new Setter {Property = Button.HeightRequestProperty, Value = 42}
                    }
                };
            }
        }

        public virtual Style LoginButton
        {
            get
            {
                return new Style(typeof(Button))
                {
                    Setters = {
                                new Setter {Property = Button.BackgroundColorProperty, Value =  Color.FromHex("57595B")},
                                new Setter {Property = Button.BorderRadiusProperty, Value = 0},
                                new Setter {Property = Button.HeightRequestProperty, Value = 42}

                    }
                };
            }
        }

        public virtual Style ContactRequestButton
        {
            get
            {
                return new Style(typeof(Button))
                {
                    Setters = {
                                new Setter {Property = Button.BackgroundColorProperty, Value =  Color.FromHex("57595B")},
                                new Setter {Property = Button.BorderRadiusProperty, Value = 0},
                                new Setter {Property = Button.HeightRequestProperty, Value = 42}

                    }
                };
            }
        }

        public virtual Style ContinueButton
        {
            get
            {
                return new Style(typeof(Button))
                {
                    Setters = {
                                new Setter {Property = Button.BackgroundColorProperty, Value =  Color.FromHex("57595B")},
                                new Setter {Property = Button.BorderRadiusProperty, Value = 0},
                                new Setter {Property = Button.HeightRequestProperty, Value = 42}

                    }
                };
            }
        }

        public virtual Style GeneralLabel
        {
            get
            {
                return new Style(typeof(Label))
                {
                    Setters = {
                                new Setter {Property = Label.TextColorProperty , Value = Color.White},
                                new Setter {Property = Label.HeightRequestProperty, Value = 42}
                    }
                };
            }
        }

        public virtual Style GeneralCenterLabel
        {
            get
            {
                return new Style(typeof(Label))
                {
                    Setters = {
                        new Setter {Property = Label.TextColorProperty , Value = Color.White},
                        new Setter {Property = Label.HeightRequestProperty, Value = 42},
                        new Setter { Property = Label.HorizontalTextAlignmentProperty, Value= TextAlignment.Center },
                        new Setter { Property = Label.VerticalTextAlignmentProperty, Value= TextAlignment.Center }
                    }
                };
            }
        }


        public virtual Style GeneralLabelBold
        {
            get
            {
                return new Style(typeof(Label))
                {
                    Setters = {
                                new Setter {Property = Label.TextColorProperty , Value = Color.White},
                                new Setter {Property = Label.HeightRequestProperty, Value = 42},
                                new Setter{Property = Label.FontAttributesProperty, Value = FontAttributes.Bold}
                    }
                };
            }
        }

        public virtual Style GeneralEntry
        {
            get
            {
                return new Style(typeof(Entry))
                {
                    Setters =
                    {
                        new Setter {Property = Label.BackgroundColorProperty, Value = Color.FromHex("eeeeee")},
                    }
                };
            }
        }

        public virtual Style LabelTemplateTitle 
        {
            get
            {
                return new Style(typeof(Label))
                {
                    Setters = {
                                new Setter {Property = Label.TextColorProperty , Value = Color.White},
                                new Setter {Property = Label.HeightRequestProperty, Value = 42}
                    }
                };
            }
        }


        public virtual Style LabelProfileTitle
        {
            get
            {
                return new Style(typeof(Label))
                {
                    Setters = {
                                new Setter {Property = Label.TextColorProperty , Value = Color.White},
                                new Setter {Property = Label.HeightRequestProperty, Value = 42}
                    }
                };
            }
        }

        public virtual Style LabelProfileDetails
        {
            get
            {
                return new Style(typeof(Label))
                {
                    Setters = {
                                new Setter {Property = Label.TextColorProperty , Value = Color.Black},
                                new Setter {Property = Label.HeightRequestProperty, Value = 42}
                    }
                };
            }
        }

        public virtual Style LabelHeaderListView
        {
            get
            {
                return new Style(typeof(Label))
                {
                    Setters = {
                                new Setter {Property = Label.TextColorProperty , Value = Color.Black},
                                new Setter {Property = Label.FontSizeProperty, Value = 14}
                    }
                };
            }
        }

        public virtual Style LabelInfoLayout
        {
            get
            {
                return new Style(typeof(Label))
                    {
                        Setters = {
                                new Setter {Property = Label.TextColorProperty , Value = Color.Black},
                                new Setter {Property = Label.FontSizeProperty, Value = 14}
                    }
                    };
            }
        }


        public virtual Style LabelTemplateDetails
        {
            get
            {
                return new Style(typeof(Label))
                {
                    Setters = {
                                new Setter {Property = Label.TextColorProperty , Value = Color.Gray},
                                new Setter {Property = Label.HeightRequestProperty, Value = 42}
                    }
                };
            }
        }

        public virtual Style LabelTemplateMoreDetails
        {
            get
            {
                return new Style(typeof(Label))
                {
                    Setters = {
                                new Setter {Property = Label.TextColorProperty , Value = Color.Gray},
                                new Setter {Property = Label.HeightRequestProperty, Value = 42}
                    }
                };
            }
        }

        public virtual Style ButtonNext
        {
            get
            {
                return new Style(typeof(Button))
                {
                    BasedOn = GeneralButton,
                    Setters = {
                                new Setter {Property = Button.TextColorProperty , Value = Color.Gray},
                                new Setter {Property = Button.HeightRequestProperty, Value = 42}
                    }
                };
            }
        }

        public virtual Style GeneralLabelSuperBig
        {
            get {
                return new Style(typeof(Label))
                {
                    BasedOn = GeneralLabel,
                    Setters =
                    {
                        new Setter{Property = Label.FontSizeProperty, Value = 26}
                    }
                };
            }
        }

        public virtual Style GeneralLabelSmall
        {
            get
            {
                return new Style(typeof(Label))
                {
                    BasedOn = GeneralLabel,
                    Setters =
                    {
                        new Setter{Property = Label.FontSizeProperty, Value = 14}
                    }
                };
            }
        }

        public virtual Style GeneralLabelSuperSmall
        {
            get
            {
                return new Style(typeof(Label))
                {
                    BasedOn = GeneralLabel,
                    Setters =
                    {
                        new Setter{Property = Label.FontSizeProperty, Value = 10}
                    }
                };
            }
        }

        public virtual Style LabelFinalizeAppointmentTitle
        {
            get
            {
                return new Style(typeof(Label))
                {
                    BasedOn = GeneralLabel,
                    Setters =
                    {
                        new Setter{Property = Label.FontSizeProperty, Value = 20},
                        new Setter{Property = Label.TextColorProperty, Value = Color.FromHex("8E8E93")},
                    }
                };
            }
        }

        public virtual Style LabelFinalizeAppointmentDetail
        {
            get
            {
                return new Style(typeof(Label))
                {
                    BasedOn = GeneralLabel,
                    Setters =
                    {
                        new Setter{Property = Label.FontSizeProperty, Value = 16},
                        new Setter{Property = Label.TextColorProperty, Value = Color.FromHex("000000")},
                    }
                };
            }
        }

        public virtual Style LabelFacilitiesMoreDetails
        {
            get
            {
                return new Style(typeof(Label))
                {
                    BasedOn = GeneralLabel,
                    Setters =
                    {
                        new Setter{Property = Label.FontSizeProperty, Value = 16},
                        new Setter{Property = Label.TextColorProperty, Value = Color.FromHex("000000")},
                        new Setter{Property = Label.FontAttributesProperty, Value = FontAttributes.Bold}
                    }
                };
            }
        }

        public virtual Style LabelRecover
        {
            get
            {
                return new Style(typeof(Label))
                {
                    BasedOn = GeneralLabel,
                    Setters =
                    {
                        new Setter{Property = Label.FontSizeProperty, Value = 16},
                        new Setter{Property = Label.TextColorProperty, Value = Color.FromHex("000000")},
                    }
                };
            }
        }

        public virtual Style LabelError
        {
            get
            {
                return new Style(typeof(Label))
                {
                    BasedOn = LabelRecover,
                    Setters =
                    {
                        new Setter{Property = Label.FontSizeProperty, Value = 16},
                        new Setter{Property = Label.TextColorProperty, Value = Color.Red},
                    }
                };
            }
        }

        public virtual Style GeneralLabelBig
        {
            get
            {
                return new Style(typeof(Label))
                {
                    Setters = {
                                new Setter {Property = Label.TextColorProperty , Value = Color.White},
                                new Setter {Property = Label.HeightRequestProperty, Value = 42}
                    }
                };
            }
        }

        public virtual Style GeneralLabelBigBold
        {
            get
            {
                return new Style(typeof(Label))
                {
                    Setters = {
                    //new Setter {Property = Label.FontFamilyProperty, Value = Enums.CustomFontType.OpenSans.ToString()},
                    new Setter {Property = Label.FontSizeProperty, Value = 18},
                    new Setter {Property = Label.FontAttributesProperty, Value = FontAttributes.Bold}
                }
                };
            }
        }

        public virtual Style GeneralLabelBigAlt
        {
            get
            {
                return new Style(typeof(Label))
                {
                    Setters = {
                                new Setter {Property = Label.TextColorProperty , Value = Color.Gray},
                                new Setter {Property = Label.HeightRequestProperty, Value = 42}
                    }
                };
            }
        }

        public virtual Style ButtonDisable
        {
            get
            {
                return new Style(typeof(Button))
                {
                    Setters = {
                        new Setter {Property = Button.BackgroundColorProperty, Value = Color.FromHex("e1e1e1")},
                        new Setter {Property = Button.TextColorProperty, Value = Color.FromHex("8E8E93")},
                        new Setter {Property = Button.BorderRadiusProperty, Value = 0},
                        new Setter {Property = Button.HeightRequestProperty, Value = 42}
                    }
                };
            }
        }

        public virtual Style AccentLabel
        {
            get
            {
                return new Style(typeof(Label))
                {
                    BasedOn = StyleManager.Instance.Style.GeneralLabel,
                    Setters =
                    {
                        new Setter{Property = Label.FontFamilyProperty, Value = Enums.CustomFontType.OpenSans.ToString()},
                        new Setter{Property = Label.FontSizeProperty, Value = 16},
                        new Setter{Property = Label.TextColorProperty, Value = VisualService.Instance.ThemeManager.Theme.Accent},
                    }
                };
            }
        }

        public virtual Style GeneralLabelSmallQuad
        {
            get
            {
                return new Style(typeof(Label))
                {
                    BasedOn = GeneralLabel,
                    Setters =
                    {
                        new Setter {Property = Label.FontFamilyProperty, Value = Enums.CustomFontType.CenturyGothic.ToString()},
                        new Setter {Property = Label.FontSizeProperty, Value = 14},
                        new Setter {Property = Label.TextColorProperty, Value = Color.FromHex("929292")},
                        new Setter {Property = Label.FontAttributesProperty, Value = FontAttributes.None},
                    }
                };
            }
        }

        public virtual Style BottomTabLabel
        {
            get
            {
                return new Style(typeof(Label))
                {
                    Setters =
                    {
                        new Setter {Property = Label.TextColorProperty, Value = Color.White},
                        new Setter {Property = Label.FontSizeProperty, Value = 14},
                        new Setter {Property = Label.FontAttributesProperty, Value = FontAttributes.None},
                    }
                };
            }
        }

        public virtual Style YellowLabel
        {
            get
            {
                return new Style(typeof(Label))
                {
                    Setters =
                    {
                        new Setter {Property = Label.TextColorProperty, Value = Color.Yellow},
                        new Setter {Property = Label.FontSizeProperty, Value = 14},
                        new Setter {Property = Label.FontAttributesProperty, Value = FontAttributes.None},
                    }
                };
            }
        }

        public virtual Style CalendarNormal
        {
            get
            {
                return new Style(typeof(Label))
                {
                    Setters =
                    {
                        new Setter {Property = Label.FontSizeProperty, Value = 18}
                    }
                };
            }
        }

        public virtual Style CalendarToday
        {
            get
            {
                return new Style(typeof(Label))
                {
                    Setters =
                    {
                        new Setter {Property = Label.FontSizeProperty, Value = 20},
                        new Setter {Property = Label.FontAttributesProperty, Value = FontAttributes.Bold},
                    }
                };
            }
        }

        public virtual Style LabelHyperLink
        {
            get
            {
                return new Style(typeof(Label))
                {
                    Setters = {
                        new Setter {Property = Label.FontFamilyProperty, Value = Enums.CustomFontType.OpenSans.ToString()}
                    }
                };
            }
        }

        public virtual Style SearchBarLabel
        {
            get
            {
                return new Style(typeof(SearchBar))
                {
                    Setters = {
                        new Setter {Property = SearchBar.FontFamilyProperty, Value = Enums.CustomFontType.OpenSans.ToString()},
                        new Setter {Property = SearchBar.FontAttributesProperty, Value = FontAttributes.None }
                    }
                };
            }
        }

        public virtual Style TabbedPageLabel
        {
            get
            {
                return
                     new Style(typeof(Label))
                     {
                         Setters = {

                        }
                     };
            }
        }

        public virtual Style NavigationPageLabel
        {
            get
            {
                return
                     new Style(typeof(Label))
                     {
                         Setters = {

                        }
                     };
            }
        }
    }
}

