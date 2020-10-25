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
    class BevestigingViewModel : BaseViewModel
    {
        public BevestigingViewModel()
        {
            Messenger.Default.Register<Voertuig>(this, OnAutoReceived);
            LeesPersonen();
            koppelenCommands();
        }


        private Voertuig currentAuto;
        public Voertuig CurrentAuto
        {
            get
            {
                return currentAuto;
            }

            set
            {
                currentAuto = value;
                NotifyPropertyChanged();
            }
        }

        private Uitlening currentUitlening;
        public Uitlening CurrentUitlening
        {
            get
            {
                if (currentUitlening != null)
                {
                    if (CurrentAuto.Id != 0)
                    {
                        currentUitlening.Voertuigid = CurrentAuto.Id;
                    }
                    if (SelectedItem.Id != 0)
                    {
                        currentUitlening.Persoonid = SelectedItem.Id;
                    }
                    return currentUitlening;
                }
                else
                {
                    currentUitlening = new Uitlening();
                    return currentUitlening;
                }
                
            }
            set
            {
                currentUitlening = value;
                NotifyPropertyChanged();
            }
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

        private Persoon selectedItem;
        public Persoon SelectedItem
        {
            get
            {
                if (selectedItem != null)
                {
                    return selectedItem;
                }
                else
                {
                    selectedItem = new Persoon();
                    return selectedItem;
                }
            }

            set
            {
                selectedItem = value;
                NotifyPropertyChanged();
            }
        }

        public void koppelenCommands()
        {
            ToevoegenCommand = new BaseCommand(toevoegenUitlening);
        }
        
        public ICommand ToevoegenCommand { get; set; }
        private void toevoegenUitlening()
        {
            UitleningDataservice uitleningDS = new UitleningDataservice();
            uitleningDS.InsertUitlening(CurrentUitlening);

            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("Home");

            MessageBox.Show("De uitlening is geregistreerd. Uw uitlenings nummer is "+ CurrentUitlening.Persoonid + " bewaar dit nummer goed" );
            
        }

        private void LeesPersonen()
        {
            //instantiëren dataservice
            PersoonDataService persoonDS =
               new PersoonDataService();

            Personen = new ObservableCollection<Persoon>(persoonDS.GetPersoon());
        }

        private void OnAutoReceived(Voertuig voertuig)
        {
            CurrentAuto = voertuig;
        }
    }
}
