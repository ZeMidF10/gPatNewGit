using Glintths.Apps.Themes.Helpers;
using Glintths.MobileApps.Core;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Glintths.Apps.Themes
{

        public partial class VisualService
        {
            private static volatile VisualService instance;
            private static object syncRoot = new Object();
            public static UnityContainer Container { get; set; }

            public ThemeManager ThemeManager { get; set; }
            

            private VisualService()
            {
                String auxTheme = Configuration.Instance.GetConfig("APP_THEME");
                //String auxCliente = Configuration.Instance.GetConfig("CLIENT"); --> porque é que isto estava a ser usado JS?
                ClientEnum cliente;

                switch (auxTheme.ToUpperInvariant())
                {
                    case "GPATIENT_SCMP":
                        cliente = ClientEnum.gPatient_SCMP;
                        break;
                    case "GPATIENT_UNIMED":
                    case "GPATIENT":
                        cliente = ClientEnum.gPatient;
                        break;

                    case "DADOR_CHVNG":
                    case "GLOBALCARE":
                        cliente = ClientEnum.GlobalCare;
                        break;
                    case "LUSIADAS":
                        cliente = ClientEnum.Lusiadas;
                        break;

                    //else if (auxCliente == "MultiCare")
                    //    cliente = ClientEnum.MultiCare;

                    //case "CUF":
                    case "CHECKIN_CUF":
                        cliente = ClientEnum.Checkin_CUF;
                        break;

                    case "GDOCTOR":
                        cliente = ClientEnum.gDoctor;
                        break;

                    case "GDOCTOR_UNIMED":
                        cliente = ClientEnum.gDoctor;
                        break;

                    case ("GENF_UNIMED"):
                        cliente = ClientEnum.gEnfermagem;
                        break;

                    case "GENFERMAGEM":
                        cliente = ClientEnum.gEnfermagem;
                        break;

					case "GINCOME":
						cliente = ClientEnum.gIncome;
						break;

                    case "GINCOME_CUF":
                        cliente = ClientEnum.gIncome_CUF;
                        break;

                    case "GSIBAS":
                        cliente = ClientEnum.gSibas;
                        break;

                    case "GPATIENT_QUADRANTES":
                        cliente = ClientEnum.gPatient_Quadrantes;
                        break;

                    case "CHECKIN_HVFX":
                        cliente = ClientEnum.Checkin_HVFX;
                        break;
                    case "GPATIENT_HPA":
                        cliente = ClientEnum.gPatient_Hpa;
                        break;
                    case "GEASYHOSPITAL":
                        cliente = ClientEnum.gEasyHospital;
                        break;
                    case "GPDA":
                        cliente = ClientEnum.gPda;
                        break;
                    case "QUADRANTES":
                    cliente = ClientEnum.gPatient_Quadrantes;
                    break;

                default:
                        throw new NotImplementedException("Tema nao implementado: " + auxTheme.ToUpperInvariant());
                }




                ThemeManager = new ThemeManager(cliente);
            }
                
            public static VisualService Instance
            {
                get
                {
                    if (instance == null)
                    {
                        lock (syncRoot)
                        {
                            if (instance == null)
                            {
                                instance = new VisualService();
                            }
                        }
                    }
                    return instance;
                }
            }
        }
}
