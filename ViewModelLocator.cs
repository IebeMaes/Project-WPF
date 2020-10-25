using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class ViewModelLocator
    {
        private static OverzichtAutoViewModel overzichtAutoViewModel = new OverzichtAutoViewModel();
        private static BevestigingViewModel bevestigingViewModel = new BevestigingViewModel();
        private static BevestigingFietsViewModel bevestigingFietsViewModel = new BevestigingFietsViewModel();
        private static PersoonViewModel persoonViewModel = new PersoonViewModel();
        private static OverzichtFietsViewModel overzichtFietsViewModel = new OverzichtFietsViewModel();
        private static GiveLocationViewModel giveLocationViewModel = new GiveLocationViewModel();
        private static ReturnViewModel returnViewModel = new ReturnViewModel();

        public static OverzichtAutoViewModel OverzichtAutoViewModel
        {
            get
            {
                return overzichtAutoViewModel;
            }
        }

        public static ReturnViewModel ReturnViewModel
        {
            get
            {
                return returnViewModel;
            }
        }

        public static GiveLocationViewModel GiveLocationViewModel
        {
            get
            {
                return giveLocationViewModel;
            }
        }

        public static BevestigingViewModel BevestigingViewModel
        {
            get
            {
                return bevestigingViewModel;
            }
        }

        public static PersoonViewModel PersoonViewModel
        {
            get
            {
                return persoonViewModel;
            }
        }
        public static OverzichtFietsViewModel OverzichtFietsViewModel
        {
            get
            {
                return overzichtFietsViewModel;
            }
        }

        public static BevestigingFietsViewModel BevestigingFietsViewModel
        {
            get
            {
                return bevestigingFietsViewModel;
            }
        }
    }
}
