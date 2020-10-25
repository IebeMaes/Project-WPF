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
    class ReturnViewModel : BaseViewModel
    {
        public ReturnViewModel()
        {
            LeesUitleningen();
            koppelenCommands();
            LeesLocaties();


        }
            

        private ObservableCollection<Uitlening> uitleningen;
        public ObservableCollection<Uitlening> Uitleningen
        {
            get
            {
                return uitleningen;
            }

            set
            {
                uitleningen = value;
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


        private Uitlening currentUitlening;
        public Uitlening CurrentUitlening
        {
            get
            {
               
                    return currentUitlening;
                
            }

            set
            {
                currentUitlening = value;
                NotifyPropertyChanged();
            }
        }

        private void koppelenCommands()
        {
            
            BewerkenCommand = new BaseCommand(bewerkenUitlening);
            refresh = new BaseCommand(LeesUitleningen);
        }


        

        public ICommand BewerkenCommand { get; set; }
        private void bewerkenUitlening()
        {
            UitleningDataservice uitleningDS =
        new UitleningDataservice();
            uitleningDS.UpdateUitlening(currentUitlening);
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("Home");


            MessageBox.Show("Uw uitlening is succesvol teruggebracht.");


        }

        

        private void LeesUitleningen()
        {   
            //instantiëren dataservice
            UitleningDataservice uitleningDS =
               new UitleningDataservice();

            Uitleningen = new ObservableCollection<Uitlening>(uitleningDS.GetUitlening());
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

        public ICommand refresh { get; set; }
        private void LeesLocaties()
        {
            //instantiëren dataservice
            LocatieDataService locatieDS =
               new LocatieDataService();

            Locaties = new ObservableCollection<Locatie>(locatieDS.GetLocaties());
        }

        


    }
}
