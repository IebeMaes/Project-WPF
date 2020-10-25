using Project.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Project.ViewModel
{
    class PersoonViewModel : BaseViewModel
    {
        public PersoonViewModel()
        {
            LeesPersonen();
            koppelenCommands();
            


        }


        private ObservableCollection<Persoon> personen;
        public ObservableCollection<Persoon> Personen
        {
            get
            {
                return personen;
            }

            set
            {
                personen = value;
                NotifyPropertyChanged();
            }
        }

        private Persoon currentPersoon;
        public Persoon CurrentPersoon
        {
            get 
            {
                if (currentPersoon != null)
                {

                    
                    return currentPersoon;
                }
                else
                {
                    currentPersoon = new Persoon();
                    return currentPersoon;
                }
            }

            set
            {
                currentPersoon = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand Leegmaken { get; set; }
        private void leegmaken()
        {
            CurrentPersoon = null;
        }


        private void koppelenCommands()
        {
            ToevoegenCommand = new BaseCommand(toevoegenPersoon);
            VerwijderenCommand = new BaseCommand(verwijderenPersoon);
            BewerkenCommand = new BaseCommand(bewerkenPersoon);
            Leegmaken = new BaseCommand(leegmaken);
            
        }


        public ICommand ToevoegenCommand { get; set; }
        private void toevoegenPersoon()
        {
                
            PersoonDataService persoonDS =
        new PersoonDataService();
            persoonDS.InsertPersoon(CurrentPersoon);

            LeesPersonen();
            _ = MaterialDesignThemes.Wpf.DrawerHost.CloseDrawerCommand;
            MessageBox.Show("Het profiel van " + CurrentPersoon.Voornaam + " " + CurrentPersoon.Achternaam + " is aangemaakt.");
        }

        public ICommand BewerkenCommand { get; set; }
        private void bewerkenPersoon()
        {
            PersoonDataService voertuigDS =
        new PersoonDataService();
            voertuigDS.UpdatePersoon(CurrentPersoon);

            LeesPersonen();
            MessageBox.Show("Het profiel van " + CurrentPersoon.Voornaam + " " + CurrentPersoon.Achternaam + " is bijgewerkt.");
        }

        public ICommand VerwijderenCommand { get; set; }
        private void verwijderenPersoon()
        {
            if (CurrentPersoon != null)
            {
                var naam = CurrentPersoon.Voornaam + " " + CurrentPersoon.Achternaam;
                PersoonDataService persoonDS =
                    new PersoonDataService();
                persoonDS.DeletePersoon(CurrentPersoon);

                //Refresh
                LeesPersonen();
                MessageBox.Show("Het profiel van " + naam + " is verwijderd.");
            }
        }

        private void LeesPersonen() 
        {
            //instantiëren dataservice
            PersoonDataService persoonDS =
               new PersoonDataService();

            Personen = new ObservableCollection<Persoon>(persoonDS.GetPersoon());
        }
    }
}
