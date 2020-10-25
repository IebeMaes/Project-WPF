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
    class GiveLocationViewModel : BaseViewModel
    {
        public GiveLocationViewModel()
        {
            LeesLocaties();
            koppelenCommands();



        }


        private ObservableCollection<Locatie> locaties;
        public ObservableCollection<Locatie> Locaties
        {
            get
            {
                return locaties;
            }

            set
            {
                locaties = value;
                NotifyPropertyChanged();
            }
        }

        private Locatie currentLocatie;
        public Locatie CurrentLocatie
        {
            get
            {
                if (currentLocatie != null)
                {


                    return currentLocatie;
                }
                else
                {
                    currentLocatie = new Locatie();
                    return currentLocatie;
                }
            }

            set
            {
                currentLocatie = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand Leegmaken { get; set; }
        private void leegmaken()
        {
            CurrentLocatie = null;
        }


        private void koppelenCommands()
        {
            ToevoegenCommand = new BaseCommand(toevoegenLocatie);
            VerwijderenCommand = new BaseCommand(verwijderenLocatie);
            BewerkenCommand = new BaseCommand(bewerkenLocatie);
            Leegmaken = new BaseCommand(leegmaken);
            ToevoegenReturnCommand = new BaseCommand(toevoegenReturnLocatie);

        }


        public ICommand ToevoegenCommand { get; set; }
        private void toevoegenLocatie()
        {

            LocatieDataService locatieDS =
        new LocatieDataService();
            locatieDS.InsertLocatie(CurrentLocatie);

            LeesLocaties();

            MessageBox.Show("De locatie is aangemaakt.");

            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("Keuze");
        }

        public ICommand ToevoegenReturnCommand { get; set; }
        private void toevoegenReturnLocatie()
        {   

            LocatieDataService locatieDS =
        new LocatieDataService();
            locatieDS.InsertLocatie(CurrentLocatie);

            LeesLocaties();

            MessageBox.Show("De locatie is aangemaakt.");

            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("Return");
        }

        public ICommand BewerkenCommand { get; set; }
        private void bewerkenLocatie()
        {
            LocatieDataService locatieDS =
        new LocatieDataService();
            locatieDS.UpdateLocatie(CurrentLocatie);

            LeesLocaties();
            MessageBox.Show("De locatie is bijgewerkt.");
        }

        public ICommand VerwijderenCommand { get; set; }
        private void verwijderenLocatie()
        {
            if (CurrentLocatie != null)
            {
                
                LocatieDataService locatieDS =
                    new LocatieDataService();
                locatieDS.DeleteLocatie(CurrentLocatie);

                //Refresh
                LeesLocaties();
                MessageBox.Show("De locatie is verwijderd.");
            }
        }

        private void LeesLocaties()
        {
            //instantiëren dataservice
            LocatieDataService locatieDS =
               new LocatieDataService();

            Locaties = new ObservableCollection<Locatie>(locatieDS.GetLocaties());
        }
    }
}
