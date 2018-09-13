using Glintths.Apps.Themes.Helpers.Styles;
using Xamarin.Forms;

namespace Glintths.Apps.Themes
{
	//-----------------------------------------------------------------------
	//
	//			Please avoid changing the default values here
	//			Use a subclass of generic theme to override them
	//
	//-----------------------------------------------------------------------

	// ReSharper disable InconsistentNaming

	/// <summary>
	/// Theme definitions, the default values used are from The Checkin app prototype, override them
	/// as you see fit
	/// An example can be found on Helpers/Themes/CheckinTheme.cs
	/// </summary>
	public static class ThemeConstants
	{
		#region Colors Definitions

		/*
		 * Definitions for Colors, the alternatives take their parents values by default (waterfall)
		 * override this behaviour on your theme iniatialization method
		 *
		 */

		#region Navigation Bar Background #3

		private static Color _color_NavBarBackground = Color.FromHex("62CCCA");

		public static Color Color_NavBarBackground
		{
			get { return _color_NavBarBackground; }
			set { _color_NavBarBackground = value; }
		}

		private static Color _color_NavBarBackgroundAlt1;

		public static Color Color_NavBarBackgroundAlt1
		{
			get { return _color_NavBarBackgroundAlt1 == Color.Default ? _color_NavBarBackground : _color_NavBarBackgroundAlt1; }
			set { _color_NavBarBackgroundAlt1 = value; }
		}

		private static Color _color_NavBarBackgroundAlt2;

		public static Color Color_NavBarBackgroundAlt2
		{
			get { return _color_NavBarBackgroundAlt2 == Color.Default ? _color_NavBarBackgroundAlt1 : _color_NavBarBackgroundAlt2; }
			set { _color_NavBarBackgroundAlt2 = value; }
		}

		#endregion Navigation Bar Background #3

		#region Navigation Bar Text #3

		private static Color _color_NavBarText = Color.White;

		public static Color Color_NavBarText
		{
			get { return _color_NavBarText; }
			set { _color_NavBarText = value; }
		}

		private static Color _color_NavBarTextAlt1;

		public static Color Color_NavigationBarAlt1
		{
			get { return _color_NavBarTextAlt1 == Color.Default ? _color_NavBarText : _color_NavBarTextAlt1; }
			set { _color_NavBarTextAlt1 = value; }
		}

		private static Color _color_NavBarTextAlt2;

		public static Color Color_NavigationBarAlt2
		{
			get { return _color_NavBarTextAlt2 == Color.Default ? _color_NavBarTextAlt1 : _color_NavBarTextAlt2; }
			set { _color_NavBarTextAlt2 = value; }
		}

		#endregion Navigation Bar Text #3

		#region Page Background #3

		private static Color _color_PageBackground = Color.White;

		public static Color Color_PageBackground
		{
			get { return _color_PageBackground; }
			set { _color_PageBackground = value; }
		}

		private static Color _color_PageBackgroundAlt1;

		public static Color Color_PageBackgroundAlt1
		{
			get { return _color_PageBackgroundAlt1 == Color.Default ? _color_PageBackground : _color_PageBackgroundAlt1; }
			set { _color_PageBackgroundAlt1 = value; }
		}

		private static Color _color_PageBackgroundAlt2;

		public static Color Color_PageBackgroundAlt2
		{
			get { return _color_PageBackgroundAlt2 == Color.Default ? _color_PageBackgroundAlt1 : _color_PageBackgroundAlt2; }
			set { _color_PageBackgroundAlt2 = value; }
		}

		#endregion Page Background #3

		#region Label Text #7

		private static Color _color_LabelText = Color.FromHex("86D6D5");

		public static Color Color_LabelText
		{
			get { return _color_LabelText; }
			set { _color_LabelText = value; }
		}

		private static Color _color_LabelTextAlt1;

		public static Color Color_LabelTextAlt1
		{
			get { return _color_LabelTextAlt1 == Color.Default ? _color_LabelText : _color_LabelTextAlt1; }
			set { _color_LabelTextAlt1 = value; }
		}

		private static Color _color_LabelTextAlt2;

		public static Color Color_LabelTextAlt2
		{
			get { return _color_LabelTextAlt2 == Color.Default ? _color_LabelTextAlt1 : _color_LabelTextAlt2; }
			set { _color_LabelTextAlt2 = value; }
		}

		private static Color _color_LabelTextAlt3;

		public static Color Color_LabelTextAlt3
		{
			get { return _color_LabelTextAlt3 == Color.Default ? _color_LabelTextAlt2 : _color_LabelTextAlt3; }
			set { _color_LabelTextAlt3 = value; }
		}

		private static Color _color_LabelTextAlt4;

		public static Color Color_LabelTextAlt4
		{
			get { return _color_LabelTextAlt4 == Color.Default ? _color_LabelTextAlt3 : _color_LabelTextAlt4; }
			set { _color_LabelTextAlt4 = value; }
		}

		private static Color _color_LabelTextAlt5;

		public static Color Color_LabelTextAlt5
		{
			get { return _color_LabelTextAlt5 == Color.Default ? _color_LabelTextAlt4 : _color_LabelTextAlt5; }
			set { _color_LabelTextAlt5 = value; }
		}

		private static Color _color_LabelTextAlt6;

		public static Color Color_LabelTextAlt6
		{
			get { return _color_LabelTextAlt6 == Color.Default ? _color_LabelTextAlt5 : _color_LabelTextAlt6; }
			set { _color_LabelTextAlt6 = value; }
		}

		private static Color _color_LabelTextAlt7;

		public static Color Color_LabelTextAlt7
		{
			get { return _color_LabelTextAlt7 == Color.Default ? _color_LabelTextAlt5 : _color_LabelTextAlt7; }
			set { _color_LabelTextAlt7 = value; }
		}

		#endregion Label Text #7

		#region Label Background #4

		private static Color _color_LabelBackground = Color.Black;

		public static Color Color_LabelBackground
		{
			get { return _color_LabelBackground; }
			set { _color_LabelBackground = value; }
		}

		private static Color _color_LabelBackgroundAlt1;

		public static Color Color_LabelBackgroundAlt1
		{
			get { return _color_LabelBackgroundAlt1 == Color.Default ? _color_LabelBackground : _color_LabelBackgroundAlt1; }
			set { _color_LabelBackgroundAlt1 = value; }
		}

		private static Color _color_LabelBackgroundAlt2;

		public static Color Color_LabelBackgroundAlt2
		{
			get { return _color_LabelBackgroundAlt2 == Color.Default ? _color_LabelBackgroundAlt1 : _color_LabelBackgroundAlt2; }
			set { _color_LabelBackgroundAlt2 = value; }
		}

		private static Color _color_LabelBackgroundAlt3;

		public static Color Color_LabelBackgroundAlt3
		{
			get { return _color_LabelBackgroundAlt3 == Color.Default ? _color_LabelBackgroundAlt2 : _color_LabelBackgroundAlt3; }
			set { _color_LabelBackgroundAlt3 = value; }
		}

		#endregion Label Background #4

		#region Button Text #4

		private static Color _color_ButtonText = Color.White;

		public static Color Color_ButtonText
		{
			get { return _color_ButtonText; }
			set { _color_ButtonText = value; }
		}

		private static Color _color_ButtonTextAlt1;

		public static Color Color_ButtonTextAlt1
		{
			get { return _color_ButtonTextAlt1 == Color.Default ? _color_ButtonText : _color_ButtonTextAlt1; }
			set { _color_ButtonTextAlt1 = value; }
		}

		private static Color _color_ButtonTextAlt2;

		public static Color Color_ButtonTextAlt2
		{
			get { return _color_ButtonTextAlt2 == Color.Default ? _color_ButtonTextAlt1 : _color_ButtonTextAlt2; }
			set { _color_ButtonTextAlt2 = value; }
		}

		private static Color _color_ButtonTextAlt3;

		public static Color Color_ButtonTextAlt3
		{
			get { return _color_ButtonTextAlt3 == Color.Default ? _color_ButtonTextAlt2 : _color_ButtonTextAlt3; }
			set { _color_ButtonTextAlt3 = value; }
		}

		#endregion Button Text #4

		#region Button Background #4

		private static Color _color_ButtonBackground = Color.FromHex("57595B");

		public static Color Color_ButtonBackground
		{
			get { return _color_ButtonBackground; }
			set { _color_ButtonBackground = value; }
		}

		private static Color _color_ButtonBackgroundAlt1;

		public static Color Color_ButtonBackgroundAlt1
		{
			get { return _color_ButtonBackgroundAlt1 == Color.Default ? _color_ButtonBackground : _color_ButtonBackgroundAlt1; }
			set { _color_ButtonBackgroundAlt1 = value; }
		}

		private static Color _color_ButtonBackgroundAlt2;

		public static Color Color_ButtonBackgroundAlt2
		{
			get { return _color_ButtonBackgroundAlt2 == Color.Default ? _color_ButtonBackgroundAlt1 : _color_ButtonBackgroundAlt2; }
			set { _color_ButtonBackgroundAlt2 = value; }
		}

		private static Color _color_ButtonBackgroundAlt3;

		public static Color Color_ButtonBackgroundAlt3
		{
			get { return _color_ButtonBackgroundAlt3 == Color.Default ? _color_ButtonBackgroundAlt2 : _color_ButtonBackgroundAlt3; }
			set { _color_ButtonBackgroundAlt3 = value; }
		}

		#endregion Button Background #4

		#region Entry Text #3

		private static Color _color_EntryText = Color.Black;

		public static Color Color_EntryText
		{
			get { return _color_EntryText; }
			set { _color_EntryText = value; }
		}

		private static Color _color_EntryTextAlt1;

		public static Color Color_EntryTextAlt1
		{
			get { return _color_EntryTextAlt1 == Color.Default ? _color_EntryText : _color_EntryTextAlt1; }
			set { _color_EntryTextAlt1 = value; }
		}

		private static Color _color_EntryTextAlt2;

		public static Color Color_EntryTextAlt2
		{
			get { return _color_EntryTextAlt2 == Color.Default ? _color_EntryTextAlt1 : _color_EntryTextAlt2; }
			set { _color_EntryTextAlt2 = value; }
		}

		#endregion Entry Text #3

		#region Entry Placeholder #3

		private static Color _color_EntryPlaceholder = Color.FromRgb(235, 235, 235);

		public static Color Color_EntryPlaceholder
		{
			get { return _color_EntryPlaceholder; }
			set { _color_EntryPlaceholder = value; }
		}

		private static Color _color_EntryPlaceholderAlt1;

		public static Color Color_EntryPlaceholderAlt1
		{
			get { return _color_EntryPlaceholderAlt1 == Color.Default ? _color_EntryPlaceholder : _color_EntryPlaceholderAlt1; }
			set { _color_EntryPlaceholderAlt1 = value; }
		}

		private static Color _color_EntryPlaceholderAlt2;

		public static Color Color_EntryPlaceholderAlt2
		{
			get { return _color_EntryPlaceholderAlt2 == Color.Default ? _color_EntryPlaceholderAlt1 : _color_EntryPlaceholderAlt2; }
			set { _color_EntryPlaceholderAlt2 = value; }
		}

		#endregion Entry Placeholder #3

		#region Entry Background #3

		private static Color _color_EntryBackground = Color.FromHex("D8D8D8");

		public static Color Color_EntryBackground
		{
			get { return _color_EntryBackground; }
			set { _color_EntryBackground = value; }
		}

		private static Color _color_EntryBackgroundAlt1;

		public static Color Color_EntryBackgroundAlt1
		{
			get { return _color_EntryBackgroundAlt1 == Color.Default ? _color_EntryBackground : _color_EntryBackgroundAlt1; }
			set { _color_EntryBackgroundAlt1 = value; }
		}

		private static Color _color_EntryBackgroundAlt2;

		public static Color Color_EntryBackgroundAlt2
		{
			get { return _color_EntryBackgroundAlt2 == Color.Default ? _color_EntryBackgroundAlt1 : _color_EntryBackgroundAlt2; }
			set { _color_EntryBackgroundAlt2 = value; }
		}

		#endregion Entry Background #3

		#region Box Background #4

		private static Color _color_BoxBackground = Color.FromHex("D8D8D8");

		public static Color Color_BoxBackground
		{
			get { return _color_BoxBackground; }
			set { _color_BoxBackground = value; }
		}

		private static Color _color_BoxBackgroundAlt1;

		public static Color Color_BoxBackgroundAlt1
		{
			get { return _color_BoxBackgroundAlt1 == Color.Default ? _color_BoxBackground : _color_BoxBackgroundAlt1; }
			set { _color_BoxBackgroundAlt1 = value; }
		}

		private static Color _color_BoxBackgroundAlt2;

		public static Color Color_BoxBackgroundAlt2
		{
			get { return _color_BoxBackgroundAlt2 == Color.Default ? _color_BoxBackgroundAlt1 : _color_BoxBackgroundAlt2; }
			set { _color_BoxBackgroundAlt2 = value; }
		}

		private static Color _color_BoxBackgroundAlt3;

		public static Color Color_BoxBackgroundAlt3
		{
			get { return _color_BoxBackgroundAlt3 == Color.Default ? _color_BoxBackgroundAlt2 : _color_BoxBackgroundAlt3; }
			set { _color_BoxBackgroundAlt3 = value; }
		}

        private static Color _color_BoxBackgroundAlt4;

        public static Color Color_BoxBackgroundAlt4
        {
            get { return _color_BoxBackgroundAlt4 == Color.Default ? _color_BoxBackgroundAlt1 : _color_BoxBackgroundAlt4; }
            set { _color_BoxBackgroundAlt4 = value; }
        }

		#endregion Box Background #4

		#region ListItem Background #3

		private static Color _color_ListItemBackground = Color.White;

		public static Color Color_ListItemBackground
		{
			get { return _color_ListItemBackground; }
			set { _color_ListItemBackground = value; }
		}

		private static Color _color_ListItemBackgroundAlt1;

		public static Color Color_ListItemBackgroundAlt1
		{
			get { return _color_ListItemBackgroundAlt1 == Color.Default ? _color_ListItemBackground : _color_ListItemBackgroundAlt1; }
			set { _color_ListItemBackgroundAlt1 = value; }
		}

		private static Color _color_ListItemBackgroundAlt2;

		public static Color Color_ListItemBackgroundAlt2
		{
			get { return _color_ListItemBackgroundAlt2 == Color.Default ? _color_ListItemBackgroundAlt1 : _color_ListItemBackgroundAlt2; }
			set { _color_ListItemBackgroundAlt2 = value; }
		}

		#endregion ListItem Background #3

		#region ListItem Selected #3

		private static Color _color_ListItemSelected = Color.White;

		public static Color Color_ListItemSelected
		{
			get { return _color_ListItemSelected; }
			set { _color_ListItemSelected = value; }
		}

		private static Color _color_ListItemSelectedAlt1;

		public static Color Color_ListItemSelectedAlt1
		{
			get { return _color_ListItemSelectedAlt1 == Color.Default ? _color_ListItemSelected : _color_ListItemSelectedAlt1; }
			set { _color_ListItemSelectedAlt1 = value; }
		}

		private static Color _color_ListItemSelectedAlt2;

		public static Color Color_ListItemSelectedAlt2
		{
			get { return _color_ListItemSelectedAlt2 == Color.Default ? _color_ListItemSelectedAlt1 : _color_ListItemSelectedAlt2; }
			set { _color_ListItemSelectedAlt2 = value; }
		}

		#endregion ListItem Selected #3

		#region Lateral Menu Background

		private static Color _color_LateralMenuBackground = Color.Black;

		public static Color Color_LateralMenuBackground
		{
			get { return _color_LateralMenuBackground; }
			set { _color_LateralMenuBackground = value; }
		}

		#endregion Lateral Menu Background

		public static Color BlueGrayTransparent = Color.FromRgba(81, 79, 216, 0.2);

		#endregion Colors Definitions

		#region Sizes, widths and heights

		private static double _paddingLeft_Page = 40;

		public static double PaddingLeft_Page
		{
			get { return _paddingLeft_Page; }
			set { _paddingLeft_Page = value; }
		}

		private static double _paddingLeft_PageAlt1 = _paddingLeft_Page;

		public static double PaddingLeft_PageAlt1
		{
			get { return _paddingLeft_PageAlt1 == null ? _paddingLeft_Page : _paddingLeft_PageAlt1; }
			set { _paddingLeft_PageAlt1 = value; }
		}

		private static double _paddingRight_Page = 40;

		public static double PaddingRight_Page
		{
			get { return _paddingRight_Page; }
			set { _paddingRight_Page = value; }
		}

		private static double _paddingRight_PageAlt1 = _paddingRight_Page;

		public static double PaddingRight_PageAlt1
		{
			get { return _paddingRight_PageAlt1 == null ? _paddingRight_Page : _paddingRight_PageAlt1; }
			set { _paddingRight_PageAlt1 = value; }
		}

		private static double _heightRequest_entry = 35;

		public static double HeightRequest_Entry
		{
			get { return _heightRequest_entry; }
			set { _heightRequest_entry = value; }
		}

		#endregion Sizes, widths and heights

		#region Images

		public static string SmallBloodBag = ThemeManager.AssetsPath + "sibas_saco_sangue_peq.png";
		public static string BloodBag = ThemeManager.AssetsPath + "sibas_saco_sangue.png";
		public static string CloseIcon = ThemeManager.AssetsPath + "sibas_icon_close.png";
		public static string NotificationIcon = ThemeManager.AssetsPath + "sibas_icon_notification.png";
		public static string YesEmptyIcon = ThemeManager.AssetsPath + "sibas_icon_empty_yes.png";
		public static string YesFullIcon = ThemeManager.AssetsPath + "sibas_icon_full_yes.png";
		public static string NoEmptyIcon = ThemeManager.AssetsPath + "sibas_icon_empty_no.png";
		public static string NoFullIcon = ThemeManager.AssetsPath + "sibas_icon_full_no.png";
		public static string MailIcon = ThemeManager.AssetsPath + "sibas_icon_mail.png";
		public static string AlertIcon = ThemeManager.AssetsPath + "sibas_icon_alertas.png";
		public static string BloodDrop = ThemeManager.AssetsPath + "sibas_icon_blooddrop.png";
		public static string LoadingIcon = ThemeManager.AssetsPath + "sibas_icon_loading.png";
		public static string DadivaIcon = ThemeManager.AssetsPath + "sibas_icon_dadiva.png";
		public static string CalendarIcon = ThemeManager.AssetsPath + "sibas_icon_calendar.png";
		public static string SangueIcon = ThemeManager.AssetsPath + "sibas_icon_sangue.png";
		public static string PlaquetasIcon = ThemeManager.AssetsPath + "sibas_icon_plaquetas.png";
		public static string MedulaIcon = ThemeManager.AssetsPath + "sibas_icon_medula.png";
		public static string InfoIcon = ThemeManager.AssetsPath + "sibas_icon_info.png";
		public static string LocationIcon = ThemeManager.AssetsPath + "sibas_icon_location.png";
		public static string CancelIcon = ThemeManager.AssetsPath + "sibas_icon_cancel.png";
		public static string CheckIcon = ThemeManager.AssetsPath + "sibas_icon_check.png";
		public static string LogOff = ThemeManager.AssetsPath + "sibas_icon_on-off.png";
		public static string IconLogo = ThemeManager.AssetsPath + "sibas_icon_logo.png";
		public static string Image_PageBackground = "background_phone.png";

		public static string WalkBtn = ThemeManager.AssetsPath + "ape_comochegar.png";
		public static string CarBtn = ThemeManager.AssetsPath + "carro_comochegar.png";
		public static string BusBtn = ThemeManager.AssetsPath + "autocarro_comochegar.png";
        public static string GenericFacility = ThemeManager.AssetsPath + "banner_comochegar.png";
        public static string ImgLogo = ThemeManager.AssetsPath + "logoApp.png";
		public static string ExamsIco = ThemeManager.AssetsPath + "exames_notf.png";
		public static string ImagiologiaIco = ThemeManager.AssetsPath + "imagiologia_exames.png";
		public static string BillingIco = ThemeManager.AssetsPath + "fatura_notif.png";
		public static string GastroIco = ThemeManager.AssetsPath + "gastro_exames.png";
		public static string DoubleArrowIco = ThemeManager.AssetsPath + "setas_detalhe.png";
		public static string ArrowIco = ThemeManager.AssetsPath + "seta.png";
        public static string ArrowIcoLogin = ThemeManager.AssetsPath + "seta_entrar.png";
		public static string GpsIco = ThemeManager.AssetsPath + "gps_perfil.png";
		public static string GpsIcoSelec = ThemeManager.AssetsPath + "gps_perfil_selec.png";
		public static string MobilePhoneIco = ThemeManager.AssetsPath + "tel_2_perfil.png";
		public static string PhoneIco = ThemeManager.AssetsPath + "tel_perfil.png";
		public static string PhoneSelectedIco = ThemeManager.AssetsPath + "tel_perfil_selec.png";
		public static string WebSiteSelectedIco = ThemeManager.AssetsPath + "Website.png";
		public static string SexIco = ThemeManager.AssetsPath + "sexo_perfil.png";
		public static string BirthDayIco = ThemeManager.AssetsPath + "aniv_perfil.png";
		public static string MailIco = ThemeManager.AssetsPath + "email_perfil.png";
		public static string GenericPhoto = ThemeManager.AssetsPath + "genericPhoto.png";
		public static string PinIco = ThemeManager.AssetsPath + "pin.png";
		public static string UnPinIco = ThemeManager.AssetsPath + "unpin.png";
		public static string IdIco = ThemeManager.AssetsPath + "bi_perfil.png";
		public static string NifIco = ThemeManager.AssetsPath + "nif_perfil.png";
		public static string MarcacaoIco = ThemeManager.AssetsPath + "marcacao_notif.png";
		public static string Circle = ThemeManager.AssetsPath + "circle.png";
		public static string CornerArrowIcon = ThemeManager.AssetsPath + "cornerArrow.png";
		public static string Clock = ThemeManager.AssetsPath + "horario_cv_medico.png";
		public static string NewsIco = ThemeManager.AssetsPath + "noticias_notf.png";
		public static string Transparent = ThemeManager.AssetsPath + "transparent.png";
		public static string MedicIcon = ThemeManager.AssetsPath + "medicIco.png";
		public static string MedicSelectedIcon = ThemeManager.AssetsPath + "medicIco_selec.png";

		public static string NotificationsAll = ThemeManager.AssetsPath + "Notificacoes_all.png";
		public static string NotificationsNew = ThemeManager.AssetsPath + "Notificacoes_unread.png";

		public static string CalHoje = ThemeManager.AssetsPath + "calendario_hoje.png";
		public static string CalProxDias = ThemeManager.AssetsPath + "calendario_proximos_dias.png";
		public static string CalTodos = ThemeManager.AssetsPath + "calendario_todos.png";

		public static string Image_LegendEstimatedTime = ThemeManager.AssetsPath + "icon_relogio_legenda.png";
		public static string Image_LegendPeopleWaiting = ThemeManager.AssetsPath + "icon_senha_legenda.png";
		public static string Image_LegendAccepted = ThemeManager.AssetsPath + "visto_senha_legenda.png";
		public static string Image_Pin = ThemeManager.AssetsPath + "Pin_Inativo.png";
		public static string Image_PassQRcode = ThemeManager.AssetsPath + "icon_qrcode.png";
		public static string Image_ReadQRcode = ThemeManager.AssetsPath + "icon_leituraqrcode.png";
		public static string Image_PassQRcodeSmallIcon = ThemeManager.AssetsPath + "Passagem_Simbolo.png";
		public static string Image_GeneratedQRcode = ThemeManager.AssetsPath + "Passagem_Inativo.png";
		public static string Image_BirthDate = ThemeManager.AssetsPath + "aniv_perfil.png";
		public static string Image_Phone = ThemeManager.AssetsPath + "tel_2_perfil.png";
		public static string Image_Sex = ThemeManager.AssetsPath + "sexo_perfil.png";
		public static string Image_NIF = ThemeManager.AssetsPath + "nif_perfil.png";
		public static string Image_Pin_Selected = ThemeManager.AssetsPath + "Pin_Ativo.png";
		public static string Image_PassQRcode_Selected = ThemeManager.AssetsPath + "icon_qrcode_press.png";
		public static string Image_ReadQRcode_Selected = ThemeManager.AssetsPath + "icon_leituraqrcode_press.png";
		public static string Image_ReadQRCodeBackground = ThemeManager.AssetsPath + "desenho_leituraqrcode.png";
		public static string Image_PinSymbol = ThemeManager.AssetsPath + "Pin_Simbolo.png";
		public static string Image_GenQRnCode = ThemeManager.AssetsPath + "gen_qrcode.png";

		public static string Image_CheckIn = ThemeManager.AssetsPath + "Check_ico.png";
		public static string Image_LoginCheckIn = ThemeManager.AssetsPath + "LoginCheck_ico.png";
		public static string Image_Register = ThemeManager.AssetsPath + "registar_ico.png";
		public static string Image_Register_White = ThemeManager.AssetsPath + "registar_ico_white.png";
		public static string Image_MyCufLogo = ThemeManager.AssetsPath + "myCuf.png";
		public static string Image_LoginBackground = ThemeManager.AssetsPath + "Fundo_Login.png";
        public static string Image_CufBottomBar = ThemeManager.AssetsPath + "LOGO_CUF_BRC.png";
        public static string Image_BottomBarLogo = ThemeManager.AssetsPath + "gPatient_Quadrantes.logo.png";

		public static string Background_LoginPage = "Fundo_Login.png";

        public static string MbWayLogo = ThemeManager.AssetsPath +  "mbway.png";
        public static string VisaLogo = ThemeManager.AssetsPath + "visaLogo.png";

		#region Menu Lateral

		public static string HomeIco = ThemeManager.AssetsPath + "MenuLateral.inicioIcon.png";
        
		public static string PersonalIco = ThemeManager.AssetsPath + "MenuLateral.pessoaisIcon.png";
		public static string HistoryIco = ThemeManager.AssetsPath + "MenuLateral.historicoIcon.png";
		public static string ResultsIco = ThemeManager.AssetsPath + "MenuLateral.resultadosIcon.png";
		public static string SchedulesIco = ThemeManager.AssetsPath + "MenuLateral.marcacoesIcon.png";
		public static string NotificationsIco = ThemeManager.AssetsPath + "MenuLateral.notificacoesIcon.png";
		public static string HospitalsIco = ThemeManager.AssetsPath + "MenuLateral.hospitaisIcon.png";
		public static string SettingsIco = ThemeManager.AssetsPath + "MenuLateral.settings.png";
		public static string RecoverIco = ThemeManager.AssetsPath + "MenuLateral.recover.png";
		public static string LoginIcon = ThemeManager.AssetsPath + "MenuLateral.login.png";
		public static string ChangePasswordIco = ThemeManager.AssetsPath + "MenuLateral.changepassword.png";
		public static string AboutIco = ThemeManager.AssetsPath + "MenuLateral.about.png";
		public static string ExitIco = ThemeManager.AssetsPath + "MenuLateral.sairIcon.png";
		public static string PatientsIco = ThemeManager.AssetsPath + "MenuLateral.meusDoentes.png";
		public static string NormsIco = ThemeManager.AssetsPath + "MenuLateral.normasProcedimentos.png";
        public static string CheckInIco = ThemeManager.AssetsPath + "MenuLateral.checkinIcon.png";
        public static string HarvestIco = ThemeManager.AssetsPath + "MenuLateral.harvestIcon.png";
        public static string IncomeIco = ThemeManager.AssetsPath + "MenuLateral.honorarios.png";

        #endregion Menu Lateral

        //View de Marcações
        public static string UnidadeMarcacaoIcon = ThemeManager.AssetsPath + "unidade_Marcacao.png";

		public static string AtosMarcacaoIcon = ThemeManager.AssetsPath + "atos_marcacao.png";
		public static string AgendarMarcacaoIcon = ThemeManager.AssetsPath + "agendar_menu.png";
		public static string ConfirmacaoMarcacaoIcon = ThemeManager.AssetsPath + "confirmacao_menu.png";

		public static string UnidadeMarcacaoSelectedIcon = ThemeManager.AssetsPath + "unidade_Marcacao_selec.png";
		public static string AtosMarcacaoSelectedIcon = ThemeManager.AssetsPath + "atos_marcacao_selec.png";
		public static string AgendarMarcacaoSelectedIcon = ThemeManager.AssetsPath + "agendar_menu_selec.png";
		public static string ConfirmacaoMarcacaoSelectedIcon = ThemeManager.AssetsPath + "confirmacao_menu_selec.png";

		public static string ApartirIcon = ThemeManager.AssetsPath + "apartirde.png";
		public static string DiasSemanaIcon = ThemeManager.AssetsPath + "diassemana.png";
		public static string HorarioIcon = ThemeManager.AssetsPath + "horario.png";

		#endregion Images

		#region Fonts

		public static string RegularFont;
		public static string ItalicFont;
		public static string BoldFont;
		public static string BoldItalicFont;
		public static Font CalNormalFontSize = Font.SystemFontOfSize(18);
		public static Font CalTodayFontSize = Font.SystemFontOfSize(20, FontAttributes.Bold);
		public static Font CalArrowFontSize = Font.SystemFontOfSize(22);
		public static Font RegisterNameLabel = Font.SystemFontOfSize(22);
		public static Font RegisterLabelForEntry = Font.SystemFontOfSize(18);
		public static Font InfoFontSize = Font.SystemFontOfSize(16);
		public static Font BoldSmallFont = Font.SystemFontOfSize(12, FontAttributes.Bold);
		public static Font ListItemTitle = Font.SystemFontOfSize(20, FontAttributes.Bold);
		public static Font SettingsItemTitle = Font.SystemFontOfSize(20, FontAttributes.Bold);
		public static Font SettingsItemDescription = Font.SystemFontOfSize(12);

		public static ResourceDictionary Style_AvenirHeavy = new ResourceDictionary()
		{
			{ResourceType.CustomFont.ToString(), Enums.CustomFontType.AvenirHeavy},
		};

		public static ResourceDictionary Style_AvenirRoman = new ResourceDictionary()
		{
			{ResourceType.CustomFont.ToString(), Enums.CustomFontType.AvenirRoman},
		};

		public static ResourceDictionary Style_AvenirRomanSmall = new ResourceDictionary()
		{
			{ResourceType.CustomFont.ToString(), Enums.CustomFontType.AvenirRoman},
			{ResourceType.FontSize.ToString(), 14}
		};

		public static ResourceDictionary Style_AvenirRomanFontSize17 = new ResourceDictionary()
		{
			{ResourceType.CustomFont.ToString(), Enums.CustomFontType.AvenirRoman},
			{ResourceType.FontSize.ToString(), 17}
		};

		public static ResourceDictionary Style_AvenirRomanMedium = new ResourceDictionary()
		{
			{ResourceType.CustomFont.ToString(), Enums.CustomFontType.AvenirRoman},
			{ResourceType.FontSize.ToString(), 20}
		};

        public static ResourceDictionary Style_AvenirRomanMediumYCenter = new ResourceDictionary()
        {
            {ResourceType.CustomFont.ToString(), Enums.CustomFontType.AvenirRoman},
            {ResourceType.FontSize.ToString(), 20},
            {ResourceType.YAlign.ToString(), TextAlignment.Center}
        };

        public static ResourceDictionary Style_AvenirRomanMediumXCenter = new ResourceDictionary()
        {
            {ResourceType.CustomFont.ToString(), Enums.CustomFontType.AvenirRoman},
            {ResourceType.FontSize.ToString(), 20},
            {ResourceType.XAlign.ToString (),TextAlignment.Center },
        };

        public static ResourceDictionary Style_LoginUsernameEntry = new ResourceDictionary()
        {
            {ResourceType.YAlign.ToString(), TextAlignment.Center},
			{ ResourceType.XAlign.ToString (),TextAlignment.Center }
            //{ ResourceType.BackgroundColor.ToString (), Color.White },
            //{ ResourceType.CustomFont.ToString (), Enums.CustomFontType.AvenirRoman }
        };

        public static ResourceDictionary Style_ContactRequestEntry = new ResourceDictionary()
        {
            {ResourceType.YAlign.ToString(), TextAlignment.Center},
            { ResourceType.XAlign.ToString (),TextAlignment.Start }
        };

        public static ResourceDictionary Style_LoginPasswordEntry = new ResourceDictionary()
        {
            {ResourceType.YAlign.ToString(), TextAlignment.Center},
			{ ResourceType.XAlign.ToString (),TextAlignment.Center }
            //{ ResourceType.BackgroundColor.ToString (), Color.White },
            //{ ResourceType.CustomFont.ToString (), Enums.CustomFontType.AvenirRoman }
        };

        public static ResourceDictionary Style_LoginEntryCuf = new ResourceDictionary()
        {
            {ResourceType.YAlign.ToString(), TextAlignment.Center},
			{ ResourceType.XAlign.ToString (),TextAlignment.Center },
			{ ResourceType.BackgroundColor.ToString (), Color.White },
			{ ResourceType.CustomFont.ToString (), Enums.CustomFontType.AvenirRoman }
        };

        public static ResourceDictionary Style_AvenirRomanMediumXYCenter = new ResourceDictionary()
        {
            {ResourceType.CustomFont.ToString(), Enums.CustomFontType.AvenirRoman},
            {ResourceType.FontSize.ToString(), 20},
            {ResourceType.YAlign.ToString(), TextAlignment.Center},
            {ResourceType.XAlign.ToString (),TextAlignment.Center }
        };

		public static ResourceDictionary Style_AvenirRomanLarge = new ResourceDictionary()
		{
			{ResourceType.CustomFont.ToString(), Enums.CustomFontType.AvenirRoman},
			{ResourceType.FontSize.ToString(), 26}
		};

		public static ResourceDictionary Style_AvenirRomanHeavyLarge = new ResourceDictionary()
		{
			{ResourceType.CustomFont.ToString(), Enums.CustomFontType.AvenirHeavy},
			{ResourceType.FontSize.ToString(), 26}
		};

		public static ResourceDictionary Style_AvenirRomanHeavyMedium = new ResourceDictionary()
		{
			{ResourceType.CustomFont.ToString(), Enums.CustomFontType.AvenirHeavy},
			{ResourceType.FontSize.ToString(), 20}
		};

		public static ResourceDictionary Style_AvenirRomanHeavySmall = new ResourceDictionary()
		{
			{ResourceType.CustomFont.ToString(), Enums.CustomFontType.AvenirHeavy},
			{ResourceType.FontSize.ToString(), 14}
		};

		public static ResourceDictionary Style_AvenirRoman_Center = new ResourceDictionary()
		{
			{ResourceType.CustomFont.ToString(), Enums.CustomFontType.AvenirRoman},
			{ResourceType.XAlign.ToString(),TextAlignment.Center}
		};

		public static ResourceDictionary Style_AvenirBook = new ResourceDictionary()
		{
			{ResourceType.CustomFont.ToString(), Enums.CustomFontType.AvenirBook},
		};

		public static ResourceDictionary Style_AvenirBookSmall = new ResourceDictionary()
		{
			{ResourceType.CustomFont.ToString(), Enums.CustomFontType.AvenirBook},
			{ResourceType.FontSize.ToString(), 14}
		};

		public static ResourceDictionary Style_AvenirBookMedium = new ResourceDictionary()
		{
			{ResourceType.CustomFont.ToString(), Enums.CustomFontType.AvenirBook},
			{ResourceType.FontSize.ToString(), 20}
		};

		public static ResourceDictionary Style_AvenirBookLarge = new ResourceDictionary()
		{
			{ResourceType.CustomFont.ToString(), Enums.CustomFontType.AvenirBook},
			{ResourceType.FontSize.ToString(), 26}
		};

		#endregion Fonts


        //Resource
		public static string Page_HeaderGradient = "LinearGrad";
	}
}