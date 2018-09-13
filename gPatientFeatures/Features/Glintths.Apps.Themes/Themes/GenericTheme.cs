using Glintths.Apps.Base.Internationalization;
using Glintths.Apps.Base.Internationalization.Resx;
using Glintths.Apps.Themes.Helpers;
using Glintths.Apps.Themes.Helpers.Styles;
using Glintths.MobileApps.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Glintths.Apps.Themes.Helpers
{
	public abstract class GenericTheme : ITheme, INotifyPropertyChanged
	{
        
		public GenericTheme ()
        {

            #region New Fonts
            SmallFontSize = 14;
            NormalFontSize = 20;
            LargeFontSize = 26;

            /*FontNormalSmall = new ResourceDictionary {
				{ ResourceType.CustomFont.ToString (), "" },
				{ ResourceType.FontSize.ToString (), SmallFontSize },
			};

            FontNormalMedium = new ResourceDictionary {
				{ ResourceType.CustomFont.ToString (), "" },
				{ ResourceType.FontSize.ToString (), NormalFontSize },
			};

            FontNormalLarge = new ResourceDictionary {
				{ ResourceType.CustomFont.ToString (), "" },
				{ ResourceType.FontSize.ToString (), LargeFontSize },
			};*/

            #endregion

            #region TEXT
            CheckInText = "";
            //SmsMsgText = translater.GetString(StringCodes.WillReceiveSmsWithCode);
            SmsMsgText = AppResources.WillReceiveSmsWithCode;

            #endregion

            #region Colors

            Accent = Color.FromHex("fcbe00");

            #region Menu Principal
            HistoricoMainColor = Color.FromHex ("F88E00");
			AgendaMainColor = Color.FromHex ("68C6C5");
			ExamesMainColor = Color.FromHex ("9E101D");
			MarcacaoMainColor = Color.FromHex ("217EA8");
			DadosPessoaisMainColor = Accent;
			NotificacoesMainColor = Color.FromHex ("868686");
			FacilitiesMainColor = Accent;
			ContactosMainColor = Accent;
			RotaMainColor = Accent;

			NotificationNumColor = Color.White;
			FontMainColor = Color.Black;
			TileBorder = Color.Transparent;

			SelectionColor = Color.Transparent;
			CircleSelectionColor = Accent;
            FormDetailColor = Color.Gray;
			#endregion


			LoginUrlColor = Color.Blue;
			LoginUrlPhraseColor = Color.White;
			TransparentBackground = Color.Transparent;
			LoginBackground = Accent; //Verde Agua
			PageBackground = Color.White;
			NotificationBackground = Color.Red;
			EditTextBackground = Color.White;
			EditTextText = Color.Gray;
			ButtonLogin = Color.FromHex ("57595B"); // cinzento escuro/preto
			LabelDetails = Color.FromHex ("57595B"); // cinzento escuro/preto
			ActionBar = Color.Yellow; // azul claro
            LoginBottomBar = Color.FromRgba(1, 1, 1, 0.3);
			TabBar = Color.Yellow;
            PdaBackground = Color.FromHex("F4F4F4");
			
            TitleAccent = Accent;
			LabelTextLight = Color.White;
			LabelTextMedium = Color.FromHex ("C8C7CC"); // cinzento claro
			LabelTextMediumDark = Color.Gray;
			LabelTextDark = Color.Black;
			InfoLabelColor = LabelTextDark;
			RowTitle = Color.Black;
			RowName = Color.Black;
			RowLabel = Color.Gray;
			RowBackground = Color.Transparent;
			LabelZipCode = Color.Black;
			LineDark = Color.FromHex ("57595B"); // cinzento escuro/preto
			LineLight = Color.FromHex ("C8C7CC"); // cinzento claro
			LightBackground = Color.FromHex ("EBEBEB"); // cinzento muito claro
			EntryTextColor = Color.White;
			Shadow = Color.FromHsla (0, 0, 0.0f, 0.4f);
			LateralMenuColor = Color.FromHex ("333333");
			LateralMenuCell = Color.FromHex ("333333"); // cinzento escuro
			UrlLabel = Color.Blue;
			WarningLabel = Color.FromHex ("fb4d4d"); // vermelho claro
			TilesLabelColor = Color.White;
			ShadowTextColor = Color.White;
            LinePda = Color.FromHex("00897B");
            #endregion

            #region Images
            HamburgerIco = "settings.png";
			YesFull = ThemeManager.AssetsPath + "yes_full.png";
			YesEmpty = ThemeManager.AssetsPath + "yes_empty.png";
			NoFull = ThemeManager.AssetsPath + "no_full.png";
			NoEmpty = ThemeManager.AssetsPath + "no_empty.png";
			BloodDrop = ThemeManager.AssetsPath + "sibas_icon_gota.png";
			listIco = ThemeManager.AssetsPath + "lista.png";
			PieChartIco = ThemeManager.AssetsPath + "piechart.png";
			LastMonthIco = ThemeManager.AssetsPath + "mes_anterior.png";
			LastYearIco = ThemeManager.AssetsPath + "ano_anterior.png";
			GlinttLogo = ThemeManager.AssetsPath + "company_logo.png";
			WalkBtn = ThemeManager.AssetsPath + "ape_comochegar.png";
			CarBtn = ThemeManager.AssetsPath + "carro_comochegar.png";
			BusBtn = ThemeManager.AssetsPath + "autocarro_comochegar.png";
			MenuLogo = ThemeManager.AssetsPath + "menulogo.png";
            DeleteIco = ThemeManager.AssetsPath + "delete.png";
            
            LoginBackgroundPhoto = "";
			HelpIco = "";
            CompHomologous = ThemeManager.AssetsPath + "icons.comphomologa.png";
            RequestHelp = ThemeManager.AssetsPath + "icons.enviar.png";
            DoctorMonthIco = "marcacoesIcon.png"; // nativo
            DoctorWeekIco = "marcacoesIcon.png"; // nativo


            #region tiles
            ResultadosExamesMainIco = ThemeManager.AssetsPath + "resultados.png";
			AgendaMainIco = ThemeManager.AssetsPath + "agenda.png";
			NotificacoesMainIco = ThemeManager.AssetsPath + "notificacoes.png";
			MarcacoesMainIco = ThemeManager.AssetsPath + "marcacoes_menuPrinc.png";
			ClientMainIco = ThemeManager.AssetsPath + "globalcare.png";
			DadosPessoaisMainIco = ThemeManager.AssetsPath + "resultados.png";
			RotaMainIco = ThemeManager.AssetsPath + "resultados.png";
			ContactMainIco = ThemeManager.AssetsPath + "resultados.png";
            
            #endregion


            ImgLogo = ThemeManager.AssetsPath + "logoApp.png";
			ExamsIco = ThemeManager.AssetsPath + "exames_notf.png";
			ImagiologiaIco = ThemeManager.AssetsPath + "imagiologia_exames.png";
			BillingIco = ThemeManager.AssetsPath + "fatura_notif.png";
			GastroIco = ThemeManager.AssetsPath + "gastro_exames.png";
            DoubleArrowIco = ThemeManager.AssetsPath + "seta.png"; // nao queremos setas duplas agora "setas_detalhe.png";
			ArrowIco = ThemeManager.AssetsPath + "seta.png";
            ArrowIcoLogin = ThemeManager.AssetsPath + "seta_entrar.png";
			GpsIco = ThemeManager.AssetsPath + "gps_perfil.png";
			GpsIcoSelec = ThemeManager.AssetsPath + "gps_perfil_selec.png";
           
			MobilePhoneIco = ThemeManager.AssetsPath + "tel_2_perfil.png";
			PhoneIco = ThemeManager.AssetsPath + "tel_perfil.png";
			PhoneSelectedIco = ThemeManager.AssetsPath + "tel_perfil_selec.png";
			SexIco = ThemeManager.AssetsPath + "sexo_perfil.png";
			BirthDayIco = ThemeManager.AssetsPath + "aniv_perfil.png";
			MailIco = ThemeManager.AssetsPath + "email_perfil.png";
			GenericPhoto = ThemeManager.AssetsPath + "genericPhoto.png";
            SmallGenericPhoto = ThemeManager.AssetsPath + "smallGenericPhoto.png";
            GenericUserPhoto = ThemeManager.AssetsPath + "genericPhoto.png";
			PinIco = ThemeManager.AssetsPath + "pin.png";
			UnPinIco = ThemeManager.AssetsPath + "unpin.png";
			IdIco = ThemeManager.AssetsPath + "bi_perfil.png";
			NifIco = ThemeManager.AssetsPath + "nif_perfil.png";
			MarcacaoIco = ThemeManager.AssetsPath + "marcacao_notif.png";
			Circle = ThemeManager.AssetsPath + "circle.png";
			CornerArrowIcon = ThemeManager.AssetsPath + "cornerArrow.png";
			Clock = ThemeManager.AssetsPath + "horario_cv_medico.png";
			NewsIco = ThemeManager.AssetsPath + "noticias_notf.png";
			Transparent = ThemeManager.AssetsPath + "transparent.png";
			MedicIcon = ThemeManager.AssetsPath + "medicIco.png";
			MedicSelectedIcon = ThemeManager.AssetsPath + "medicIco_selec.png";

			CalHoje = ThemeManager.AssetsPath + "calendario_hoje.png";
			CalProxDias = ThemeManager.AssetsPath + "calendario_proximos_dias.png";
			CalTodos = ThemeManager.AssetsPath + "calendario_todos.png";

			RiscoGenerico = ThemeManager.AssetsPath + "Risco_Queda-Ulcera.png";

            UploadBtnIco = ThemeManager.AssetsPath + "Icone_Upload.png";

            MbWayLogo = ThemeManager.AssetsPath + "mbway.png";
            MultiBancoLogo = ThemeManager.AssetsPath + "multibancoLogo.png";
            VisaLogo = ThemeManager.AssetsPath + "visaLogo.png";
            PayPalLogo = ThemeManager.AssetsPath + "paypalLogo.png";

			#region Menu Lateral
			HomeIco = ThemeManager.AssetsPath + "MenuLateral.inicioIcon.png";
			PersonalIco = ThemeManager.AssetsPath + "MenuLateral.pessoaisIcon.png";
			HistoryIco = ThemeManager.AssetsPath + "MenuLateral.historicoIcon.png";
			ResultsIco = ThemeManager.AssetsPath + "MenuLateral.resultadosIcon.png";
			SchedulesIco = ThemeManager.AssetsPath + "MenuLateral.marcacoesIcon.png";
			NotificationsIco = ThemeManager.AssetsPath + "MenuLateral.notificacoesIcon.png";
			HospitalsIco = ThemeManager.AssetsPath + "MenuLateral.hospitaisIcon.png";
			SettingsIco = ThemeManager.AssetsPath + "MenuLateral.definicoesIcon.png";
			RotaIco = ThemeManager.AssetsPath + "MenuLateral.definicoesIcon.png";
			ContactIco = ThemeManager.AssetsPath + "MenuLateral.definicoesIcon.png";
			AboutIco = ThemeManager.AssetsPath + "MenuLateral.definicoesIcon.png";
			ExitIco = ThemeManager.AssetsPath + "MenuLateral.sairIcon.png";
            HarvestStationIco = ThemeManager.AssetsPath + "MenuLateral.harvestIcon.png";
            CheckinIco = ThemeManager.AssetsPath + "MenuLateral.checkinIcon.png";
            IncomeIco = ThemeManager.AssetsPath + "MenuLateral.honorarios.png";
            PatientsIco = ThemeManager.AssetsPath + "MenuLateral.meusDoentes.png";

            //HarvestStationIco = ThemeManager.AssetsPath + "Icone_Gota.png";
            GotaIcoSelec = ThemeManager.AssetsPath + "Icone_Gota_selec.png";
			#endregion

			//View de Marcações
			UnidadeMarcacaoIcon = ThemeManager.AssetsPath + "unidade_Marcacao.png";
			AtosMarcacaoIcon = ThemeManager.AssetsPath + "atos_marcacao.png";
			AgendarMarcacaoIcon = ThemeManager.AssetsPath + "agendar_menu.png";
			ConfirmacaoMarcacaoIcon = ThemeManager.AssetsPath + "confirmacao_menu.png";

			UnidadeMarcacaoSelectedIcon = ThemeManager.AssetsPath + "unidade_Marcacao_selec.png";
			AtosMarcacaoSelectedIcon = ThemeManager.AssetsPath + "atos_marcacao_selec.png";
			AgendarMarcacaoSelectedIcon = ThemeManager.AssetsPath + "agendar_menu_selec.png";
			ConfirmacaoMarcacaoSelectedIcon = ThemeManager.AssetsPath + "confirmacao_menu_selec.png";

			ApartirIcon = ThemeManager.AssetsPath + "apartirde.png";
			DiasSemanaIcon = ThemeManager.AssetsPath + "diassemana.png";
			HorarioIcon = ThemeManager.AssetsPath + "horario.png";

            BottomBarLogo = ThemeManager.AssetsPath + "logo.png";

			#endregion

			#region Fonts
			CalNormalFont = Font.SystemFontOfSize (18);
			CalTodayFont = Font.SystemFontOfSize (20, FontAttributes.Bold);
			CalArrowFont = Font.SystemFontOfSize (22);
			InfoFont = Font.SystemFontOfSize (16);
			LoginUrlFont = Font.SystemFontOfSize (Device.OnPlatform (14, 14, 14));
			GroupHeaderFont = Font.SystemFontOfSize (16, FontAttributes.Bold);
			AgendaDetailsBoldFont = Font.SystemFontOfSize (18, FontAttributes.Bold);
			AgendaDetailsFont = Font.SystemFontOfSize (15);
			ProfileFont = Font.SystemFontOfSize (12);
			ProfileHeaderFont = Font.SystemFontOfSize (24, FontAttributes.Bold);
			UnreadNotificationTitleFont = Font.SystemFontOfSize (16);
			ReadNotificationTitleFont = Font.SystemFontOfSize (16, FontAttributes.Bold);
			ShadowTextBoldFont = Font.SystemFontOfSize (16, FontAttributes.Bold);
			ShadowTextFont = Font.SystemFontOfSize (16);
			#endregion

			#region Other
			TileSize = new Point (125, 100);
            
			TileLabelVPosition = TilePos.Start;
			TileLabelHPosition = TextAlignment.Start;

			TitleSpacing = 30;
			IconSpacing = 10;
			TitleWidthPercentage = 0.85;


			TileOrientation = StackOrientation.Horizontal;

			HistoricoLbl = "Agenda";

			ShowPins = true;
			ShowFacilitiesAddress = true;

			MenuProfilePhoto = false;
			ChangeTileSelectionStyle = false;
			DataTemplateArrowAlignment = LayoutOptions.Start;

			LoginEntryPos = new Point (0, 200); // ignorado porque tem imagem logo no login

			NotificationFont = Font.SystemFontOfSize ((TileSize.Y * 50) / 100, FontAttributes.None);

			TileImageWideScale = 1.25;
			TilePadding = 5;
			TileBorderRadius = 2;

			LoginBtnBorderRadius = 2;
			LoginEntryPwdRadius = 2;
			LoginEntryUserRadius = 2;

			Slogan = "";
			TileTitleToUpper = false;

			NotificationNumbPos = new Point (10, _tileSize.Y * 0.40);
			#endregion

			#region tileString
			TileLabelVOption = LayoutOptions.Start;
			TileLblLayoutPos = new Rectangle (0, 0, 1, 1);
			#endregion

			#region Dictionary Styles
			EntryStyle = new ResourceDictionary { 
				{ ResourceType.XAlign.ToString (), TextAlignment.Center }, 
				{ ResourceType.YAlign.ToString (), TextAlignment.Center },
				{ ResourceType.CustomFont.ToString (), "Helvetica-Light" },
				{ ResourceType.FontSize.ToString (), 16 },
			};
			ButtonStyle = new ResourceDictionary { 
				{ ResourceType.XAlign.ToString (), TextAlignment.Center }, 
				{ ResourceType.YAlign.ToString (), TextAlignment.Center },
				{ ResourceType.CustomFont.ToString (), "Helvetica-Light" },
			};
			GroupHeaderStyle = new ResourceDictionary { 
				{ ResourceType.YAlign.ToString (), TextAlignment.Center },
				{ ResourceType.CustomFont.ToString (), "Helvetica-Light" },
			};
			LabelStyleSuperSmall = new ResourceDictionary {
				{ ResourceType.CustomFont.ToString (), "Helvetica-Light" },
				{ ResourceType.FontSize.ToString (), 12 },
			};
			LabelStyleSuperSmallBold = new ResourceDictionary {
				{ ResourceType.CustomFont.ToString (), "Helvetica-Black" },
				{ ResourceType.FontSize.ToString (), 12 },
			};
			LabelStyleSmall = new ResourceDictionary {
				{ ResourceType.CustomFont.ToString (), "Helvetica-Light" },
				{ ResourceType.FontSize.ToString (), 14 },
			};
			LabelStyleSmallBold = new ResourceDictionary {
				{ ResourceType.CustomFont.ToString (), "Helvetica-Black" },
				{ ResourceType.FontSize.ToString (), 14 },
			};
			LabelStyleNormal = new ResourceDictionary {
				{ ResourceType.CustomFont.ToString (), "Helvetica-Light" },
				{ ResourceType.FontSize.ToString (), 16 },
			};
			LabelStyleNormalBold = new ResourceDictionary {
				{ ResourceType.CustomFont.ToString (), "Helvetica-Black" },
				{ ResourceType.FontSize.ToString (), 16 },
			};
			LabelStyleBig = new ResourceDictionary {
				{ ResourceType.CustomFont.ToString (), "Helvetica-Light" },
				{ ResourceType.FontSize.ToString (), 18 },
			};
			LabelStyleBigBold = new ResourceDictionary {
				{ ResourceType.CustomFont.ToString (), "Helvetica-Black" },
				{ ResourceType.FontSize.ToString (), 18 },
			};
			LabelStyleSuperBig = new ResourceDictionary {
				{ ResourceType.CustomFont.ToString (), "Helvetica-Light" },
				{ ResourceType.FontSize.ToString (), 20 },
			};
			LabelStyleSuperBigBold = new ResourceDictionary {
				{ ResourceType.CustomFont.ToString (), "Helvetica-Black" },
				{ ResourceType.FontSize.ToString (), 20 },
			};
			LabelStyleTheBiggest = new ResourceDictionary {
				{ ResourceType.CustomFont.ToString (), "Helvetica-Light" },
				{ ResourceType.FontSize.ToString (), 24 },
			};
			if (Device.OS == TargetPlatform.Android) {
				LabelStyleTheBiggestBold = new ResourceDictionary {
					{ ResourceType.CustomFont.ToString (), "Helvetica-Black" },
					{ ResourceType.FontSize.ToString (), 24 },
				};
			} else if (Device.OS == TargetPlatform.iOS) {
				LabelStyleTheBiggestBold = new ResourceDictionary {
					{ ResourceType.CustomFont.ToString (), "Helvetica-Black" },
					{ ResourceType.FontSize.ToString (), 36 },
				};
			}
			#endregion

			#region Sizes
			EntryHeight = 40;
			ButtonHeight = 40;
			GroupHeaderHeight = 40;
			LabelHeight = 40;
			IconSize = 15;
			IconBigSize = 25;
			SmallListItemHeight = 40;
			ListItemHeight = 65;
			BigListItemHeight = 90;
			BiggestListItemHeight = 105;
			ImageSize = 85;
			SearchBarHeight = 20;
			CalendarArrowButtonHeight = 45;
			CalendarArrowButtonWidth = 35;
            StepsHeaderHeight = 50;
			StepsHeaderImageSize = 30;
            ImagePdaSize = 81;
			#endregion

			#region LoginPage
			LoginFormPercent = 0.65;
			LoginFormSpacing_1 = 5;
			LoginFormSpacing_2 = 10;
			LoginSloganSpacing = 5;
			LoginSloganPadding = 0;
			LoginSloganTextSizePercent = 0.085;
			#endregion

			#region MainMenuPage
			TileImageYTranslation = 0;
			#endregion

			#region ProfilePage
			ProfileImageHeightPercent = 0.25f;
            ProfileAddress = ThemeManager.AssetsPath + "gps_perfil_selec.png";
            ProfilePhone = ThemeManager.AssetsPath + "tel_perfil_selec.png";
			#endregion

			#region AgendaPage
			AppointmentAgendaTitleColor = Color.FromHex ("002D74");
			MedicalActAgendaTitleColor = Color.FromHex ("002D74");
			OtherAgendaTitleColor = Color.FromHex ("002D74");
			#endregion

			#region Popup
			PopupHeightPercent = 0.6;
			PopupWidthPercent = 0.8;
			PopupButtonHeight = 50;
            #endregion

            MainFont = "Century Gothic";

        }

		public String GetImageResource (string resourceName)
		{
			switch (resourceName) {
                #region comochegar
				case "RESOURCE_GPS":
					return this.GpsIco;
				case "RESOURCE_CAR":
					return this.CarBtn;
				case "RESOURCE_WALK":
					return this.WalkBtn;
				case "RESOURCE_BUS":
					return this.BusBtn;

                #endregion

				case "RESOURCE_AGENDA":
					return this.SchedulesIco;
                #region menuLateral
				case "RESOURCE_INICIO":
					return this.HomeIco;
				case "RESOURCE_DADOS":
					return this.PersonalIco;
				case "RESOURCE_HISTORICO":
					return this.HistoryIco;
				case "RESOURCE_RESULTADOS":
					return this.ResultsIco;
				case "RESOURCE_MARCACOES":
					return this.SchedulesIco;
				case "RESOURCE_NOTIFICACOES":
					return this.NotificationsIco;
				case "RESOURCE_HOSPITALS":
					return this.HospitalsIco;
				case "RESOURCE_DEFINICOES":
					return this.SettingsIco;
				case "RESOURCE_SAIR":
					return this.ExitIco;
				case "RESOURCE_ABOUT":
					return this.AboutIco;
				case "RESOURCE_ROTA":
					return this.RotaIco;
				case "RESOURCE_CONTACTO":
					return this.ContactIco;
				case "BILLING":
					return this.BillingIco;
				case "AGENDA":
					return this.MarcacaoIco;
				case "MARKETING":
					return this.NewsIco;
				case "RESULTS":
					return this.ExamsIco;
				case "OTHER":
					return this.NotificationsIco;
                    
                #endregion

                #region Notificacoes
				case "RESOURCE_EXAMES":
					return this.ExamsIco;
				case "RESOURCE_NOTICIAS":
					return this.NewsIco;
				case "RESOURCE_FATURA":
					return this.BillingIco;
                #endregion

                #region Agenda
				case "RESOURCE_ACT_APPOINTMENT":
					return this.AtosMarcacaoIcon;
				case "RESOURCE_ACT_EXAM":
					return this.ExamsIco;
                #endregion

				case "GENERIC_PHOTO":
					return this.GenericPhoto;
                case "FAIL":
                    return this.ExitIco;
				default:
					{
						Debug.WriteLine ("No Resource found: " + resourceName);
						return "no resource found";
					}
			}
                 
		}

		#region Fonts

        public int SmallFontSize { get; set; }
        public int NormalFontSize { get; set; }
        public int LargeFontSize { get; set; }

        public ResourceDictionary FontNormalSmall { get; set; }
        public ResourceDictionary FontNormalMedium { get; set; }
        public ResourceDictionary FontNormalLarge { get; set; }

        public ResourceDictionary FontBoldSmall { get; set; }
        public ResourceDictionary FontBoldMedium { get; set; }
        public ResourceDictionary FontBoldLarge { get; set; }

        public ResourceDictionary FontLightSmall { get; set; }
        public ResourceDictionary FontLightMedium { get; set; }
        public ResourceDictionary FontLightLarge { get; set; }

        public ResourceDictionary FontItalicSmall { get; set; }
        public ResourceDictionary FontItalicMedium { get; set; }
        public ResourceDictionary FontItalicLarge { get; set; }


		public Font CalNormalFont { get; set; }

		public Font CalTodayFont { get; set; }

		public Font CalArrowFont { get; set; }

		public Font InfoFont { get; set; }

		public Font LoginUrlFont { get; set; }

		public Font GroupHeaderFont { get; set; }

		public Font AgendaDetailsBoldFont { get; set; }

		public Font AgendaDetailsFont { get; set; }

		public Font ProfileFont { get; set; }

		public Font ProfileHeaderFont { get; set; }

		public Font ReadNotificationTitleFont { get; set; }

		public Font UnreadNotificationTitleFont { get; set; }

		public Font ShadowTextBoldFont { get; set; }

		public Font ShadowTextFont { get; set; }

		#endregion

		#region Dictionary Styles

		public ResourceDictionary EntryStyle { get; set; }

		public ResourceDictionary ButtonStyle { get; set; }

		public ResourceDictionary GroupHeaderStyle { get; set; }

		public ResourceDictionary LabelStyleSuperSmall { get; set; }

		public ResourceDictionary LabelStyleSuperSmallBold { get; set; }

		public ResourceDictionary LabelStyleSmall { get; set; }

		public ResourceDictionary LabelStyleSmallBold { get; set; }

		public ResourceDictionary LabelStyleNormal { get; set; }

		public ResourceDictionary LabelStyleNormalBold { get; set; }

		public ResourceDictionary LabelStyleBig { get; set; }

		public ResourceDictionary LabelStyleBigBold { get; set; }

		public ResourceDictionary LabelStyleSuperBig { get; set; }

		public ResourceDictionary LabelStyleSuperBigBold { get; set; }

		public ResourceDictionary LabelStyleTheBiggest { get; set; }

		public ResourceDictionary LabelStyleTheBiggestBold { get; set; }

		#endregion

		#region Sizes

		public int EntryHeight { get; set; }

		public int ButtonHeight { get; set; }

		public int GroupHeaderHeight { get; set; }

		public int LabelHeight { get; set; }

		public int EntryWidth { get; set; }

		public int ButtonWidth { get; set; }

		public int GroupHeaderWidth { get; set; }

		public int LabelWidth { get; set; }

		public int IconSize { get; set; }

		public int IconBigSize { get; set; }

		public int SmallListItemHeight { get; set; }

		public int ListItemHeight { get; set; }

		public int BigListItemHeight { get; set; }

		public int BiggestListItemHeight { get; set; }

		public int ImageSize { get; set; }

		public int SearchBarHeight { get; set; }

		public int CalendarArrowButtonHeight { get; set; }

		public int CalendarArrowButtonWidth { get; set; }

		public int StepsHeaderHeight { get; set; }

		public int StepsHeaderImageSize { get; set; }

        public int ImagePdaSize { get; set; }

        #endregion

        #region Colors

        #region Menu Principal

        public Color HistoricoMainColor { get; set; }

		public Color AgendaMainColor { get; set; }

		public Color ExamesMainColor { get; set; }

		public Color MarcacaoMainColor { get; set; }

		public Color DadosPessoaisMainColor { get; set; }

		public Color NotificacoesMainColor { get; set; }

		public Color FacilitiesMainColor { get; set; }

		public Color ContactosMainColor { get; set; }

		public Color RotaMainColor { get; set; }

		public Color TileBorder { get; set; }

		public Color SelectionColor { get; set; }

        public Color FormDetailColor { get; set; }

		public Color CircleSelectionColor { get; set; }

		#endregion

		public Color InfoLabelColor { get; set; }

		public Color TransparentBackground { get; set; }

		public Color LoginUrlPhraseColor { get; set; }

		public Color LoginUrlColor { get; set; }

		public Color NotificationNumColor { get; set; }

		public Color FontMainColor { get; set; }

		public Color LateralMenuColor { get; set; }

		public Color LateralMenuCell { get; set; }

		public Color Shadow { get; set; }

		public Color RowTitle { get; set; }

		public Color RowLabel { get; set; }

		public Color RowName { get; set; }

		public Color RowBackground { get; set; }

		public Color LabelTextLight { get; set; }

		public Color LabelTextMedium { get; set; }

		public Color LabelTextDark { get; set; }

		public Color MainMenuBackground { get; set; }

		public Color LoginBackground { get; set; }

		public Color PageBackground { get; set; }

		public Color NotificationBackground { get; set; }

		public Color EditTextBackground { get; set; }

		public Color EditTextText { get; set; }

		public Color ButtonLogin { get; set; }

		public Color ActionBar { get; set; }

		public Color TabBar { get; set; }

		public Color LabelDetails { get; set; }

		public Color LabelZipCode { get; set; }

		public Color LineDark { get; set; }

		public Color LineLight { get; set; }

		public Color EntryTextColor { get; set; }

		public Color LightBackground { get; set; }

		public Color Accent { get; set; }
        public Color TitleAccent { get; set; }

		public Color CompanyLogoColor { get; set; }

		public Color UrlLabel { get; set; }

		public Color LabelTextMediumDark { get; set; }

		public Color WarningLabel { get; set; }

		public Color TilesLabelColor { get; set; }

		public Color ShadowTextColor { get; set; }

        public Color LoginBottomBar { get; set; }

        public Color PdaBackground { get; set; }

        public Color LinePda { get; set; }

        #endregion

        #region Images

        #region Tiles

        public String AgendaMainIco { get; set; }

		public String NotificacoesMainIco { get; set; }

        public string HamburgerIco
        {
            get;
            set;
        }

		public string listIco {
			get ;
			set ;
		}

        public String UploadBtnIco { get; set; }

		public String MarcacoesMainIco { get; set; }

		public String ClientMainIco { get; set; }

		public String DadosPessoaisMainIco { get; set; }

		public String ResultadosExamesMainIco { get; set; }
		//public String DadosPessoaisMainIco { get; set; }
		//public String ResultadosExamesMainIco { get; set; }
		public String RotaMainIco { get; set; }

		public String ContactMainIco { get; set; }

        public string DeleteIco
        {
            get;
            set;
        }
        #endregion

        public string YesFull { get; set; }

		public string YesEmpty { get; set; }

		public string NoFull { get; set; }

		public string NoEmpty { get; set; }

		public string CompHomologous {
			get;
			set;
		}

		public string RequestHelp {
			get;
			set;
		}

		public string PieChartIco { get; set; }

		public string LastMonthIco { get; set; }

		public string LastYearIco { get; set; }

		public string BloodDrop { get; set; }

		public String GlinttLogo { get; set; }

		public String LoginBackgroundPhoto { get; set; }

		public String ExamsIco { get; set; }

		public String Circle { get; set; }

		public String ImagiologiaIco { get; set; }

		public String BillingIco { get; set; }

		public String GastroIco { get; set; }

		public String ArrowIco { get; set; }

        public String ArrowIcoLogin { get; set; }

		public String DoubleArrowIco { get; set; }

		public String GpsIco { get; set; }

        public String GenericFacility { get; set; }

        public String PatientsIco { get; set; }


        public String GpsIcoSelec { get; set; }

		public String MobilePhoneIco { get; set; }

		public String PhoneIco { get; set; }

		public String PhoneSelectedIco { get; set; }

		public String SexIco { get; set; }

		public String BirthDayIco { get; set; }

		public String MailIco { get; set; }

		public String ImgLogo { get; set; }

        public String MbWayLogo { get; set; }

        public string PayPalLogo { get; set; }

        public String VisaLogo { get; set; }

        public String MultiBancoLogo { get; set; }

		public String MenuLogo { get; set; }

		public String WalkBtn { get; set; }

		public String CarBtn { get; set; }

		public String BusBtn { get; set; }

		public String GenericPhoto { get; set; }

        public String SmallGenericPhoto { get; set; }

        public String GenericUserPhoto { get; set; }

		public String PinIco { get; set; }

		public String UnPinIco { get; set; }

		public String IdIco { get; set; }

		public String NifIco { get; set; }

		public String MarcacaoIco { get; set; }

		public String Clock { get; set; }

		public String NewsIco { get; set; }

		public String Transparent { get; set; }

		public String MedicIcon { get; set; }

		public String MedicSelectedIcon { get; set; }

		public String CalHoje { get; set; }

		public String CalProxDias { get; set; }

		public String CalTodos { get; set; }

		public String RiscoGenerico { get; set; }

        public String BottomBarLogo { get; set; }

		#region falta descritivo da separacao

		public String UnidadeMarcacaoIcon { get; set; }

        public String HarvestStationIco { get; set; }

		public String AtosMarcacaoIcon { get; set; }

		public String AgendarMarcacaoIcon { get; set; }

		public String AgendarMarcacaoSelectedIcon { get; set; }

		public String ConfirmacaoMarcacaoIcon { get; set; }

		public String UnidadeMarcacaoSelectedIcon { get; set; }

		public String AtosMarcacaoSelectedIcon { get; set; }

		public String ConfirmacaoMarcacaoSelectedIcon { get; set; }

		#endregion

		public String AboutIco { get; set; }

        public String CheckinIco { get; set; }

        public String IncomeIco { get; set; }


        public String HelpIco { get; set; }

		#region falta descritivo da separacao ( temporal?)

		public String ApartirIcon { get; set; }

		public String DiasSemanaIcon { get; set; }

		public String HorarioIcon { get; set; }

		public String CornerArrowIcon { get; set; }

		#endregion

		#region Menu Lateral

		public String HomeIco { get; set; }

		public String PersonalIco { get; set; }

		public String HistoryIco { get; set; }

		public String ResultsIco { get; set; }

		public String SchedulesIco { get; set; }

		public String NotificationsIco { get; set; }

		public String HospitalsIco { get; set; }

		public String SettingsIco { get; set; }

		public String RotaIco { get; set; }

		public String ContactIco { get; set; }

		public String ExitIco { get; set; }

		#endregion

		#endregion

        #region TEXT
        public string CheckInText { get; set; }
        public string SmsMsgText { get; set; }
       #endregion
       

		#region Other

		public static Point _tileSize;

		public virtual Point TileSize {
			get { return _tileSize; }
			set {
				if (value != _tileSize) {
					_tileSize = value;
					NotifyPropertyChanged ();
					NotifyPropertyChanged ("TileImagePosition");
					NotifyPropertyChanged ("TileWideImagePosition");
					NotifyPropertyChanged ("TileImageSize");
				}
			}
		}

		public Rectangle _tileLblLayoutPos;

		public virtual Rectangle TileLblLayoutPos {
			get {
				_tileLblLayoutPos = new Rectangle (0, 0, 1, 1);
				return _tileLblLayoutPos;
			}
			set {
				if (value != _tileLblLayoutPos) {
					_tileLblLayoutPos = value;
					NotifyPropertyChanged ("TileLblLayoutPos");
				}
			}
		}

		public Point _notificationNumbPos;

		public virtual Point NotificationNumbPos {
			get {
				_notificationNumbPos = new Point (10, _tileSize.Y * 0.40);
				return _notificationNumbPos;
			}
			set {
				if (value != _notificationNumbPos) {
					_notificationNumbPos = value;
					NotifyPropertyChanged ("NotificationNumbPos");
				}
			}
		}

		public Point _tileWideSize;

		public virtual Point TileWideSize {
			get { return _tileWideSize; }
			set {
				if (value != this._tileWideSize) {
					this._tileWideSize = value;
					NotifyPropertyChanged ();
					NotifyPropertyChanged ("TileImagePosition");
					NotifyPropertyChanged ("TileWideImagePosition");
					NotifyPropertyChanged ("TileImageSize");
				}
			}
		}


		public int IconSpacing { get; set; }

		public int TitleSpacing { get; set; }

		public double TitleWidthPercentage { get; set; }


		public virtual Point TileImagePosition {
			get {
				return new Point (_tileSize.X - TileImageSize.X, _tileSize.Y - TileImageSize.Y);
			}
		}

		public virtual Point TileWideImagePosition {
			get {
				return new Point (_tileSize.X * 2 - TileImageSize.X, _tileSize.Y - TileImageSize.Y);
			}
		}

		public TilePos TileLabelVPosition { get; set; }

		public TextAlignment TileLabelHPosition { get; set; }

		public StackOrientation TileOrientation { get; set; }

		public String HistoricoLbl { get; set; }

		public String Slogan { get; set; }

		public bool ShowPins { get; set; }

		public bool MenuProfilePhoto { get; set; }

		public bool ChangeTileSelectionStyle { get; set; }

		public bool TileTitleToUpper { get; set; }

		public bool ShowFacilitiesAddress { get; set; }

		public LayoutOptions DataTemplateArrowAlignment { get; set; }

		public Point LoginEntryPos { get; set; }

		public Font NotificationFont { get; set; }


		public virtual Point TileImageSize {
			get {
				// TODO: wide ou nao
				return new Point (_tileSize.X * 0.50, _tileSize.Y * 0.50);
			}
		}


		public virtual Point TileWideImageSize {
			get {
				// TODO: wide ou nao
				return new Point (_tileSize.X * 0.50 * TileImageWideScale, _tileSize.Y * 0.50 * TileImageWideScale);
			}
		}

		public double TileImageWideScale { get; set; }

		public int TilePadding { get; set; }

		public int TileBorderRadius { get; set; }

		public LayoutOptions TileLabelVOption { get; set; }

		public int LoginBtnBorderRadius { get; set; }

		public int LoginEntryPwdRadius { get; set; }

		public int LoginEntryUserRadius { get; set; }

		#endregion

		#region LoginPage

		public double LoginFormPercent { get; set; }

		public double LoginFormSpacing_1 { get; set; }

		public double LoginFormSpacing_2 { get; set; }

		public double LoginSloganSpacing { get; set; }

		public double LoginSloganPadding { get; set; }

		public double LoginSloganTextSizePercent { get; set; }

		#endregion

		#region ProfilePage

		public float ProfileImageHeightPercent { get; set; }
        public string ProfileAddress { get; set; }
        public string ProfilePhone { get; set; }
		#endregion

		#region AgendaPage

		public Color AppointmentAgendaTitleColor { get; set; }

		public Color MedicalActAgendaTitleColor { get; set; }

		public Color OtherAgendaTitleColor { get; set; }

		#endregion

		#region Popup

		public double PopupHeightPercent { get; set; }

		public double PopupWidthPercent { get; set; }

		public int PopupButtonHeight { get; set; }

		#endregion

		public int TileImageYTranslation { get; set; }

		#region MainMenuPage

		#endregion

		public event PropertyChangedEventHandler PropertyChanged;
		

		public void NotifyPropertyChanged ([CallerMemberName] String propertyName = "")
		{
			if (PropertyChanged != null) {
				PropertyChanged (this, new PropertyChangedEventArgs (propertyName));
			}
		}


        public string DoctorMonthIco { get; set; }

        public string DoctorWeekIco { get; set; }
            
        public string MainFont { get; set; }

        public string GotaIcoSelec
        {
            get;
            set;
        }
        
    }
}
