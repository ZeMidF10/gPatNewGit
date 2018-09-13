using Glintths.MobileApps.Core;
using Microsoft.Practices.Unity;
using System;
using Xamarin.Forms;
using Glintths.MobileApps.Core;
using System.Diagnostics;

namespace Glintths.Apps.Themes
{
	public enum ClientEnum
	{
		GlobalCare,
		MultiCare,
		Lusiadas,
		gDoctor,
		gEnfermagem,
		gPatient,
        gPatient_Hpa,
        gPatient_SCMP,
		gIncome,
		gSibas,
		gPatient_Quadrantes,
        Checkin_HVFX,
        Checkin_CUF,
        gIncome_CUF,
        gEasyHospital,
        gPda
    }

	public enum TilePos
	{
		Start,
		Center,
		End,
	}

	public interface ITheme
	{
		#region NewFonts

		int SmallFontSize { get; set; }

		int NormalFontSize { get; set; }

		int LargeFontSize { get; set; }

		ResourceDictionary FontNormalSmall { get; set; }

		ResourceDictionary FontNormalMedium { get; set; }

		ResourceDictionary FontNormalLarge { get; set; }

		ResourceDictionary FontBoldSmall { get; set; }

		ResourceDictionary FontBoldMedium { get; set; }

		ResourceDictionary FontBoldLarge { get; set; }

		ResourceDictionary FontLightSmall { get; set; }

		ResourceDictionary FontLightMedium { get; set; }

		ResourceDictionary FontLightLarge { get; set; }

		ResourceDictionary FontItalicSmall { get; set; }

		ResourceDictionary FontItalicMedium { get; set; }

		ResourceDictionary FontItalicLarge { get; set; }

		#endregion NewFonts

        #region TEXT
        string CheckInText { get; set; }
        string SmsMsgText { get; set; }
        #endregion

        #region Images

        string YesFull { get; set; }

		string YesEmpty { get; set; }

		string NoFull { get; set; }

		string NoEmpty { get; set; }

		string BloodDrop { get; set; }

        string DoctorMonthIco { get; set; }

        string IncomeIco { get; set; }

        string PatientsIco { get; set; }
    

        string DoctorWeekIco { get; set; }

		string HamburgerIco
		{
			get;
			set;
		}

        string DeleteIco
        {
            get;
            set;
        }

        string listIco
		{
			get;
			set;
		}

		string CompHomologous
		{
			get;
			set;
		}

		string RequestHelp
		{
			get;
			set;
		}

		string GlinttLogo
		{
			get;
			set;
		}

		string PieChartIco
		{
			get;
			set;
		}

		string LastYearIco
		{
			get;
			set;
		}

		string LastMonthIco
		{
			get;
			set;
		}

        string MbWayLogo
        {
            get;
            set;
        }

        string MultiBancoLogo
        {
            get;
            set;
        }

        string VisaLogo
        {
            get;
            set;
        }

        string PayPalLogo
        {
            get;
            set;
        }

		#region Menu Principal

		String AgendaMainIco { get; set; }

		String NotificacoesMainIco { get; set; }

		String MarcacoesMainIco { get; set; }

		String ClientMainIco { get; set; }

		String DadosPessoaisMainIco { get; set; }

		String RotaMainIco { get; set; }

		String ContactMainIco { get; set; }

		String ResultadosExamesMainIco { get; set; }

        

		#endregion Menu Principal

		String WalkBtn { get; set; }

		String CarBtn { get; set; }

		String BusBtn { get; set; }

		String LoginBackgroundPhoto { get; set; }

		String MenuLogo { get; set; }

		String ImgLogo { get; set; }

		String ExamsIco { get; set; }

		String ImagiologiaIco { get; set; }

		String BillingIco { get; set; }

		String GastroIco { get; set; }

		String DoubleArrowIco { get; set; }

		String ArrowIco { get; set; }

        String ArrowIcoLogin { get; set; }

		String GpsIco { get; set; }

		String GpsIcoSelec { get; set; }

		String MobilePhoneIco { get; set; }

		String PhoneIco { get; set; }

		String PhoneSelectedIco { get; set; }

		String SexIco { get; set; }

		String BirthDayIco { get; set; }

		String MailIco { get; set; }

        String UploadBtnIco { get; set; }

		String GenericPhoto { get; set; }

        String SmallGenericPhoto { get; set; }

        String GenericUserPhoto { get; set; }

		String PinIco { get; set; }

		String UnPinIco { get; set; }

		String IdIco { get; set; }

		String NifIco { get; set; }

		String MarcacaoIco { get; set; }

        String CheckinIco { get; set; }

		String Circle { get; set; }

		String UnidadeMarcacaoIcon { get; set; }

		String AtosMarcacaoIcon { get; set; }

		String ConfirmacaoMarcacaoIcon { get; set; }

		String UnidadeMarcacaoSelectedIcon { get; set; }

		String AtosMarcacaoSelectedIcon { get; set; }

		String ConfirmacaoMarcacaoSelectedIcon { get; set; }

		String AgendarMarcacaoIcon { get; set; }

		String AgendarMarcacaoSelectedIcon { get; set; }

		String ApartirIcon { get; set; }

		String DiasSemanaIcon { get; set; }

		String HorarioIcon { get; set; }

		String CornerArrowIcon { get; set; }

		String Clock { get; set; }

		String NewsIco { get; set; }

		String Transparent { get; set; }

		String MedicIcon { get; set; }

		String MedicSelectedIcon { get; set; }

		String CalHoje { get; set; }

		String CalProxDias { get; set; }

		String CalTodos { get; set; }

		String RiscoGenerico { get; set; }

		String Slogan { get; set; }

		String HelpIco { get; set; }

        string BottomBarLogo { get; set; }

		bool TileTitleToUpper { get; set; }

		#region Menu Lateral

		String HomeIco { get; set; }

		String PersonalIco { get; set; }

		String HistoryIco { get; set; }

		String ResultsIco { get; set; }

		String SchedulesIco { get; set; }

		String NotificationsIco { get; set; }

		String HospitalsIco { get; set; }

        String HarvestStationIco { get; set; }

        String GotaIcoSelec { get; set; }

		String SettingsIco { get; set; }

		String RotaIco { get; set; }

		String ContactIco { get; set; }

		String AboutIco { get; set; }

		String ExitIco { get; set; }

		#endregion Menu Lateral

        String ProfileAddress { get; set; }
        String ProfilePhone { get; set; }

		#endregion Images

		#region EditText

		Color EditTextBackground { get; set; }

		Color EditTextText { get; set; }

		#endregion EditText

		#region Button

		Color ButtonLogin { get; set; }

		#endregion Button

		#region Colors

		#region Menu Principal

		Color HistoricoMainColor { get; set; }

		Color AgendaMainColor { get; set; }

		Color ExamesMainColor { get; set; }

		Color MarcacaoMainColor { get; set; }

		Color DadosPessoaisMainColor { get; set; }

		Color NotificacoesMainColor { get; set; }

		Color FacilitiesMainColor { get; set; }

		Color ContactosMainColor { get; set; }

		Color RotaMainColor { get; set; }

		Color TileBorder { get; set; }

		Color FontMainColor { get; set; }

		Color NotificationNumColor { get; set; }

		Color SelectionColor { get; set; }

		Color CircleSelectionColor { get; set; }

        Color FormDetailColor { get; set; }

		#endregion Menu Principal

		Color InfoLabelColor { get; set; }

		Color LoginUrlColor { get; set; }

		Color LoginUrlPhraseColor { get; set; }

		Color TransparentBackground { get; set; }

		Color LoginBackground { get; set; }

		Color PageBackground { get; set; }

		Color NotificationBackground { get; set; }

		Color LateralMenuCell { get; set; }

		Color ActionBar { get; set; }

		Color LabelDetails { get; set; }

		Color TabBar { get; set; }

		Color LabelTextLight { get; set; }

		Color LabelTextMedium { get; set; }

		Color LabelTextMediumDark { get; set; }

		Color LabelTextDark { get; set; }

		Color LabelZipCode { get; set; }

		Color LineDark { get; set; }

        Color LinePda { get; set; }

        /// <summary>Cinzento claro</summary>
        Color LineLight { get; set; }

		Color EntryTextColor { get; set; }

		Color Shadow { get; set; }

		Color LightBackground { get; set; }

		Color Accent { get; set; }
        Color TitleAccent { get; set; }

		Color CompanyLogoColor { get; set; }

		Color UrlLabel { get; set; }

		Color WarningLabel { get; set; }

		Color LateralMenuColor { get; set; }

		Color TilesLabelColor { get; set; }

		Color ShadowTextColor { get; set; }

        Color LoginBottomBar { get; set; }

        Color PdaBackground { get; set; }

        #endregion Colors

        #region Fonts

        Font CalNormalFont { get; set; }

		Font CalTodayFont { get; set; }

		Font CalArrowFont { get; set; }

		Font InfoFont { get; set; }

		Font NotificationFont { get; set; }

		Font LoginUrlFont { get; set; }

		Font GroupHeaderFont { get; set; }

		Font AgendaDetailsBoldFont { get; set; }

		Font AgendaDetailsFont { get; set; }

		Font ProfileFont { get; set; }

		Font ProfileHeaderFont { get; set; }

		Font ReadNotificationTitleFont { get; set; }

		Font UnreadNotificationTitleFont { get; set; }

		//Font ShadowTextBoldFont { get; set; }
		Font ShadowTextFont { get; set; }

		#endregion Fonts

		#region Rows

		Color RowBackground { get; set; }

		Color RowTitle { get; set; }

		Color RowName { get; set; }

		Color RowLabel { get; set; }

		#endregion Rows

		String HistoricoLbl { get; set; }

		String GetImageResource(string resourceName);

		Point TileSize { get; set; }

		Point TileWideSize { get; set; }

		int TileImageYTranslation { get; set; }

		Point TileImagePosition { get; }

		Point TileImageSize { get; }

		Point TileWideImageSize { get; }

		Point TileWideImagePosition { get; }

		TilePos TileLabelVPosition { get; set; }

		TextAlignment TileLabelHPosition { get; set; }

		StackOrientation TileOrientation { get; set; }

		int IconSpacing { get; set; }

		int TitleSpacing { get; set; }

		double TitleWidthPercentage { get; set; }

		bool ShowPins { get; set; }

		bool ShowFacilitiesAddress { get; set; }

		bool MenuProfilePhoto { get; set; }

		bool ChangeTileSelectionStyle { get; set; }

		LayoutOptions DataTemplateArrowAlignment { get; set; }

		Point LoginEntryPos { get; set; }

		Point NotificationNumbPos { get; set; }

		Rectangle TileLblLayoutPos { get; set; }

		double TileImageWideScale { get; set; }

		int TilePadding { get; set; }

		int TileBorderRadius { get; set; }

		int LoginBtnBorderRadius { get; set; }

		int LoginEntryPwdRadius { get; set; }

		int LoginEntryUserRadius { get; set; }

		#region tiles type

		//TileSizeEnum AgendaTileType { get; set; }
		//TileSizeEnum ExamesTileType { get; set; }
		//TileSizeEnum FacilitiesTileType { get; set; }
		//TileSizeEnum MarcacaoTileType { get; set; }
		//TileSizeEnum NotificacoesTileType { get; set; }
		//TileSizeEnum RotaTileType { get; set; }
		//TileSizeEnum PerfilTileType { get; set; }
		//TileSizeEnum ContactosTileType { get; set; }

		#endregion tiles type

		LayoutOptions TileLabelVOption { get; set; }

		#region Dictionary Styles

		ResourceDictionary EntryStyle { get; set; }

		ResourceDictionary ButtonStyle { get; set; }

		ResourceDictionary GroupHeaderStyle { get; set; }

		ResourceDictionary LabelStyleSuperSmall { get; set; }

		ResourceDictionary LabelStyleSuperSmallBold { get; set; }

		ResourceDictionary LabelStyleSmall { get; set; }

		ResourceDictionary LabelStyleSmallBold { get; set; }

		ResourceDictionary LabelStyleNormal { get; set; }

		ResourceDictionary LabelStyleNormalBold { get; set; }

		ResourceDictionary LabelStyleBig { get; set; }

		ResourceDictionary LabelStyleBigBold { get; set; }

		ResourceDictionary LabelStyleSuperBig { get; set; }

		ResourceDictionary LabelStyleSuperBigBold { get; set; }

		ResourceDictionary LabelStyleTheBiggest { get; set; }

		ResourceDictionary LabelStyleTheBiggestBold { get; set; }

		#endregion Dictionary Styles

		#region Sizes

		int EntryHeight { get; set; }

		int ButtonHeight { get; set; }

		int GroupHeaderHeight { get; set; }

		int LabelHeight { get; set; }

		int EntryWidth { get; set; }

		int ButtonWidth { get; set; }

		int GroupHeaderWidth { get; set; }

		int LabelWidth { get; set; }

		int IconSize { get; set; }

		int IconBigSize { get; set; }

		int SmallListItemHeight { get; set; }

		int ListItemHeight { get; set; }

		int BigListItemHeight { get; set; }

		int BiggestListItemHeight { get; set; }

		int ImageSize { get; set; }

        int ImagePdaSize { get; set; }

        int SearchBarHeight { get; set; }

		int CalendarArrowButtonHeight { get; set; }

		int CalendarArrowButtonWidth { get; set; }

		int StepsHeaderHeight { get; set; }

		int StepsHeaderImageSize { get; set; }

		#endregion Sizes

		#region LoginPage

		double LoginFormPercent { get; set; }

		double LoginFormSpacing_1 { get; set; }

		double LoginFormSpacing_2 { get; set; }

		double LoginSloganSpacing { get; set; }

		double LoginSloganPadding { get; set; }

		double LoginSloganTextSizePercent { get; set; }

		#endregion LoginPage

		#region ProfilePage

		float ProfileImageHeightPercent { get; set; }

		#endregion ProfilePage

		#region AgendaPage

		Color AppointmentAgendaTitleColor { get; set; }

		Color MedicalActAgendaTitleColor { get; set; }

		Color OtherAgendaTitleColor { get; set; }

		#endregion AgendaPage

		#region Popup

		double PopupHeightPercent { get; set; }

		double PopupWidthPercent { get; set; }

		int PopupButtonHeight { get; set; }

        #endregion Popup

        string MainFont { get; set; }

    }

	public class ThemeManager
	{
		private ClientEnum _client;
		private ITheme _theme;
		public static String AssetsPath = "";
		public static String ClientPath = "";

		public ITheme Theme { get { return _theme; } set { _theme = value; } }

		public ThemeManager(ClientEnum client)
		{
			Client = client;
		}

		public ClientEnum Client
		{
			get { return _client; }
			set
            {

				_client = value;
				
				AssetsPath = GetNameSpace() + ".Assets.";
                ClientPath = _client.ToString() + ".";
                _theme = ThemeResolver.Instance.Container.Resolve<ITheme>(Configuration.Instance.GetConfig("APP_THEME"));
			}
		}

		/// <summary>
		/// Mapeia a app para o namespace certo
		/// este metodo é usado porque está a tirar partido da CONFIG["APPNAME"]
		/// se o appname tivesse o nome do namespace nao era preciso este metodo
		/// </summary>
		/// <returns></returns>
		private string GetNameSpace()
		{
			var app_name = Configuration.Instance.GetConfig("APP_NAME");
            Debug.WriteLine(app_name);

            switch (app_name)
			{
                case "GPatient_SCMP":
                    return "gPatientSCMP";

                case "gDoctor":
					return "gDoctor";

                case "gDoctorHpa":
                    return "HPA.gDoctor";

				case "Enfermagem":
					return "gEnfermagem";

				case "GPatient":
					return "gPatientFeatures";

                case "GPatient_Quadrantes":
                    return "gPatientQuadrantes";

                case "gEnfermagem_Unimed":
                    return "Unimed.gEnfermagem";

                case "GDoctor_Unimed":
                    return "Unimed.gDoctor";

                case "GPatient_Unimed":
                    return "Unimed.gPatient";

                case "gIncome":
					return "gIncome";

                case "gIncome_CUF":
                    return "JMS.PRO.gIncome";

				case "gSibas":
					return "gSibas";

				case "Checkin":
					return "JMS.CheckInCUF";

                case "Checkin_GlobalCare":
                    return "Glintt.CheckIn";

                case "Dador_CHVNG":
                    return "DadorCHVNG";

                case "Checkin_HVFX":
                    return "HVFX.CheckIn";

                case "GPatient_HPA":
                    return "gPatientHpa";

                case "gEasyHospital":
                    return "gEasyHospital";
                case "gPda":
                    return "gPda";
            }

			throw new NotImplementedException("GetNameSpace para esta app não foi mapeado");
		}
	}
}