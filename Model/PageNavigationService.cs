using Project.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public class PageNavigationService
    {
        Home homepage = null;
        Keuze keuzepagina = null;
        OverzichtAuto overzichtautopagina = null;
        OverzichtFiets overzichtfietspagina = null;
        Bevestiging bevestigingpagina = null;
        BevestigingFiets bevestigingFietspagina = null;
        Return returnpagina = null;
        Profiel profielpagina = null;
        GiveLocation geeflocatie = null;
        public PageNavigationService()
        {

        }
            
        public void Navigate(string page)
        {
            switch (page)   
            {
                
                case "Home":
                    homepage = new Home();
                    ApplicationHelper.NavigationService.Navigate(homepage);
                    break;
                
                case "Keuze":
                    keuzepagina = new Keuze();
                    ApplicationHelper.NavigationService.Navigate(keuzepagina);
                    break;

                case "OverzichtAuto":
                    overzichtautopagina = new OverzichtAuto();
                    ApplicationHelper.NavigationService.Navigate(overzichtautopagina);
                    break;

                case "OverzichtFiets":
                    overzichtfietspagina = new OverzichtFiets();
                    ApplicationHelper.NavigationService.Navigate(overzichtfietspagina);
                    break;

                case "Bevestiging":
                    bevestigingpagina = new Bevestiging();
                    ApplicationHelper.NavigationService.Navigate(bevestigingpagina);
                    break;

                case "Locatie":
                    geeflocatie = new GiveLocation();
                    ApplicationHelper.NavigationService.Navigate(geeflocatie);
                    break;

                case "BevestigingFiets":
                    bevestigingFietspagina = new BevestigingFiets();
                    ApplicationHelper.NavigationService.Navigate(bevestigingFietspagina);
                    break;

                case "Profiel":
                    profielpagina = new Profiel();
                    ApplicationHelper.NavigationService.Navigate(profielpagina);
                    break;

                case "Return":
                    returnpagina = new Return();
                    ApplicationHelper.NavigationService.Navigate(returnpagina);
                    break;
                case "TERUG":
                    ApplicationHelper.NavigationService.GoBack();
                    break;
                default:
                    break;


            }
        }
    }
}
