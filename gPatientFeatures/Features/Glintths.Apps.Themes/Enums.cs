using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glintths.Apps.Themes
{
	public class Enums
	{
        public enum CustomFontType
        {
            AvenirRoman,
            AvenirMedium,
            AvenirHeavy,
            AvenirBook,
            OpenSans,
            CenturyGothic,
            MinionPro,
            VistaSanAlt
        };

		public enum NotificationsType
		{
			Today,
			New,
			All
        };

		public enum AgendaTimesType
		{
			Today,
			Future,
			Previous
        };

        public enum AgendaReSchedulableStateType
        {
            Active,
            Inactive,
        };

        public enum NotesOrPreparationsType
        {
            Notes,
            Preparations,
        };

        public enum ExamsResultsEnum
		{
			Recent,
			All
        };

		public enum NotificationsEnum
		{
			Today,
			New,
			Old
        };

		public enum FacilitiesEnum
		{
			Near,
			All
        };

        public enum MonthOrder {
            PreviousMonth,
            CurrentMonth,
            NextMonth
        };

        public enum RequestedBookApsStates
        {
            Pending,
            Settle
        };


        public enum IconLabelStackImagePositions
        {
            Top,
            Bottom,
            Left,
            Right
        };

        public enum RegistoEntradasPdaTipo
        {
            Fatura,
            GuiaDeConsignacao,
            GuiaRemessaProvisoria,
            VendaACredito,
            Fax,
            GuiaDeTransporte,
            GuiaDeRemessa,
            VendaADinheiro,
            FaturaProforma
        };

        public enum RegistoEntradasLeituraProdutos
        {
            Leitura,
            Detalhe
        };
    }
}
