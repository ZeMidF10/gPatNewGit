using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Glintths.Apps.Base.Interfaces
{
    public interface IAppStyle
    {
        Style LoginButton { get; }
        Style GeneralButton{get;}
        Style ButtonDisable { get; }
        Style GeneralLabel { get; }
        Style GeneralEntry { get; }
        Style LabelTemplateTitle { get; }
        Style LabelTemplateDetails { get; }
        Style LabelTemplateMoreDetails { get; }
        Style LabelProfileTitle { get; }
        Style LabelProfileDetails { get; }
        Style LabelHeaderListView { get; }
        Style LabelInfoLayout { get; }
        Style ButtonNext { get; }
        Style GeneralLabelSuperSmall { get; }
        Style GeneralLabelSmall { get; }
        Style GeneralLabelBold { get; }
        Style GeneralLabelSuperBig { get; }
        Style LabelFinalizeAppointmentTitle { get; }
        Style LabelFinalizeAppointmentDetail { get; }
        Style LabelFacilitiesMoreDetails { get; }
        Style LabelRecover { get; }
        Style LabelError { get; }
        Style GeneralLabelBig { get; }
        Style GeneralLabelBigBold { get; }
        Style GeneralLabelBigAlt { get; }
        Style AccentLabel { get; }
        Style GeneralLabelSmallQuad { get; }
        Style BottomTabLabel { get; }
        Style YellowLabel { get; }
        Style CalendarNormal { get; }
        Style CalendarToday { get; }
        Style LabelHyperLink { get; }
        Style SearchBarLabel { get; }
        Style GeneralCenterLabel { get; }
        Style TabbedPageLabel { get; }
        Style NavigationPageLabel { get; }

        Style ContactRequestButton { get; }

        Style ContinueButton { get; }
    }
}
