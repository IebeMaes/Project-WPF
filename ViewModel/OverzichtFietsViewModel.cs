using Project.Extensions;
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
    class OverzichtFietsViewModel : BaseViewModel
    {
        public OverzichtFietsViewModel()
        {
            LeesFietsen();
            LeesLocaties();
            koppelenCommands();
        }

        private ObservableCollection<Voertuig> fietsen;
        public ObservableCollection<Voertuig> Fietsen
        {
            get
            {
                return fietsen;
            }

            set
            {
                fietsen = value;
                NotifyPropertyChanged();
            }
        }

        private Locatie selectedItem;
        public Locatie SelectedItem
        {
            get
            {
                if (selectedItem != null)
                {
                    return selectedItem;
                }
                else
                {
                    selectedItem = new Locatie();
                    return selectedItem;
                }
            }

            set
            {
                selectedItem = value;
                NotifyPropertyChanged();
            }
        }


        private Voertuig currentFiets;
        public Voertuig CurrentFiets
        {
            get
            {
                if (currentFiets != null)
                {

                    if (SelectedItem.Id != 0)
                    {
                        currentFiets.Locatieid = SelectedItem.Id;
                    }
                    return currentFiets;
                }
                else
                {
                    currentFiets = new Voertuig();
                    return currentFiets;
                }
            }

            set
            {
                currentFiets = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand Leegmaken { get; set; }
        private void leegmaken()
        {
            CurrentFiets = null;
        }


        private void koppelenCommands()
        {
            ToevoegenFietsCommand = new BaseCommand(toevoegenFiets);
            VerwijderenFietsCommand = new BaseCommand(verwijderenFiets);
            BewerkenFietsCommand = new BaseCommand(bewerkenFiets);
            Leegmaken = new BaseCommand(leegmaken);
            doorsturenCommand = new BaseCommand(doorsturenVoertuig);
        }


        public ICommand ToevoegenFietsCommand { get; set; }
        private void toevoegenFiets()
        {

            VoertuigDataService voertuigDS =
        new VoertuigDataService();
            voertuigDS.InsertFiets(CurrentFiets);

            LeesFietsen();
            MessageBox.Show("De fiets van het merk " + CurrentFiets.Merk + " en de kleur " + CurrentFiets.Kleur + " is toegevoegd.");
        }

        public ICommand BewerkenFietsCommand { get; set; }
        private void bewerkenFiets()
        {
            VoertuigDataService voertuigDS =
        new VoertuigDataService();
            voertuigDS.UpdateFiets(CurrentFiets);

            LeesFietsen();
            MessageBox.Show("De fiets van het merk " + CurrentFiets.Merk + " en de kleur " + CurrentFiets.Kleur + " is toegevoegd.");
        }

        public ICommand VerwijderenFietsCommand { get; set; }
        private void verwijderenFiets()
        {
            if (CurrentFiets != null)
            {
                var merk = CurrentFiets.Merk;
                var kleur = CurrentFiets.Kleur;
                VoertuigDataService voertuigDS =
                    new VoertuigDataService();
                voertuigDS.DeleteVoertuig(CurrentFiets);

                //Refresh
                LeesFietsen();
                MessageBox.Show("De fiets van het merk " + merk + " en de kleur " + kleur + " is toegevoegd.");
            }
        }

        private void LeesFietsen()
        {
            //instantiëren dataservice
            VoertuigDataService voertuigDS =
               new VoertuigDataService();

            Fietsen = new ObservableCollection<Voertuig>(voertuigDS.GetFiets());
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

        private void LeesLocaties()
        {
            //instantiëren dataservice
            LocatieDataService locatieDS =
               new LocatieDataService();

            Locaties = new ObservableCollection<Locatie>(locatieDS.GetLocaties());
        }

        public ICommand doorsturenCommand { get; set; }
        private void doorsturenVoertuig()
        {
            if (CurrentFiets != null)
            {
                Messenger.Default.Send<Voertuig>(CurrentFiets);
                PageNavigationService pageNavigationService = new PageNavigationService();
                pageNavigationService.Navigate("BevestigingFiets");
            }


        }
    
    }
}
