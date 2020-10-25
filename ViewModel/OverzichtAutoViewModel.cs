using Project.Extensions;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Project.ViewModel
{
    class OverzichtAutoViewModel : BaseViewModel
    {
        public OverzichtAutoViewModel()
        {
            LeesVoertuigen();
            koppelenCommands();
            LeesLocaties();

            
        }


        private ObservableCollection<Voertuig> autos;
        public ObservableCollection<Voertuig> Autos
        {
            get
            {
                return autos;
            }

            set
            {
                autos = value;
                NotifyPropertyChanged();
            }
        }

        private Locatie selectedItem;
        public Locatie SelectedItem
        {
            get
            {
                if(selectedItem != null)
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


        private Voertuig currentAuto;
        public Voertuig CurrentAuto
        {
            get
            {
                if (currentAuto != null)
                {

                    if (SelectedItem.Id != 0) { 
                        currentAuto.Locatieid = SelectedItem.Id;
                    }
                    return currentAuto;
                }
                else
                {
                    currentAuto = new Voertuig();
                    return currentAuto;
                }
            }

            set
            {
                currentAuto = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand Leegmaken { get; set; }
        private void leegmaken()
        {
            CurrentAuto = null;   
        }
        

        private void koppelenCommands()
        {
            ToevoegenCommand = new BaseCommand(toevoegenAuto);
            VerwijderenCommand = new BaseCommand(verwijderenAuto);
            BewerkenCommand = new BaseCommand(bewerkenAuto);
            Leegmaken = new BaseCommand(leegmaken);
            doorsturenCommand = new BaseCommand(doorsturenVoertuig);
        }


        public ICommand ToevoegenCommand { get; set; }
        private void toevoegenAuto()
        {

            VoertuigDataService voertuigDS =
        new VoertuigDataService();
            voertuigDS.InsertAuto(CurrentAuto);

            LeesVoertuigen();

        }

        public ICommand BewerkenCommand { get; set; }
        private void bewerkenAuto()
        {
            VoertuigDataService voertuigDS =
        new VoertuigDataService();
            voertuigDS.UpdateAuto(currentAuto);

            LeesVoertuigen();
        }

        public ICommand VerwijderenCommand { get; set; }
        private void verwijderenAuto()
        {
            if (CurrentAuto != null)
            {
                VoertuigDataService voertuigDS =
                    new VoertuigDataService();
                voertuigDS.DeleteVoertuig(CurrentAuto);

                //Refresh
                LeesVoertuigen();
            }
        }

        private void LeesVoertuigen()
        {
            //instantiëren dataservice
            VoertuigDataService voertuigDS =
               new VoertuigDataService();

            Autos = new ObservableCollection<Voertuig>(voertuigDS.GetAuto());
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
            if(CurrentAuto != null)
            {
                Messenger.Default.Send<Voertuig>(CurrentAuto);
                PageNavigationService pageNavigationService = new PageNavigationService();
                pageNavigationService.Navigate("Bevestiging");
            }
            

        }

        
    }
}
