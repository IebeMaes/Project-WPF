using Project.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Project.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public BaseViewModel()
        {
            KoppelenCommands();
        }

        private void KoppelenCommands()
        {
            ShutDownCommand = new BaseCommand(ShutDown);
            GoBackCommand = new BaseCommand(GaTerug);
            GoUitlenen = new BaseCommand(GaUitlenen);
            GoReturn = new BaseCommand(GaReturn);
            GoAuto = new BaseCommand(GaAuto);
            GoProfiel = new BaseCommand(GaProfiel);
            GoFiets = new BaseCommand(GaFiets);
            GoLocatie = new BaseCommand(GaLocatie);
        }
        public ICommand ShutDownCommand { get; set; }
        public ICommand GoBackCommand { get; set; }
        public ICommand GoUitlenen { get; set; }
        public ICommand GoReturn { get; set; }
        public ICommand GoAuto { get; set; }
        public ICommand GoProfiel { get; set; }
        public ICommand GoFiets { get; set; }
        public ICommand GoLocatie { get; set; }
            
        private void GaProfiel()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("Profiel");
        }
        private void ShutDown()
        {
            Application.Current.Shutdown();
        }

        private void GaFiets()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("OverzichtFiets");
        }

        private void GaTerug()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("TERUG");
        }

        private void GaUitlenen()
        {
            
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("Keuze");
        }

        private void GaReturn()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("Return");
        }

       
        private void GaAuto()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("OverzichtAuto");
        }

        private void GaLocatie()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("Locatie");
        }



    }
}
    