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
    class BevestigingFietsViewModel : BaseViewModel
    {
        public BevestigingFietsViewModel()
        {
            Messenger.Default.Register<Voertuig>(this, OnFietsReceived);
            LeesPersonen();
            koppelenCommands();
        }


        private Voertuig currentFiets;
        public Voertuig CurrentFiets
        {
            get
            {
                return currentFiets;
            }

            set
            {
                currentFiets = value;
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
                    if (CurrentFiets.Id != 0)
                    {
                        currentUitlening.Voertuigid = CurrentFiets.Id;
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


            MessageBox.Show("De uitlening is geregistreerd.");
        }

        private void LeesPersonen()
        {
            //instantiëren dataservice
            PersoonDataService persoonDS =
               new PersoonDataService();

            Personen = new ObservableCollection<Persoon>(persoonDS.GetPersoon());
        }

        private void OnFietsReceived(Voertuig voertuig)
        {
            CurrentFiets = voertuig;
        }
    }
}
