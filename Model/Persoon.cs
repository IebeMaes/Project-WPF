using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
   public class Persoon : BaseModel
    {
        private int id;
        private string voornaam;
        private string achternaam;
        private string telefoonnummer;
        private string email;

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                NotifyPropertyChanged();
            }
        }

        public string Voornaam
        {
            get
            {
                return voornaam;
            }
            set
            {
                voornaam = value;
                NotifyPropertyChanged();
            }
        }

        public string Achternaam
        {
            get
            {
                return achternaam;
            }
            set
            {
                achternaam = value;
                NotifyPropertyChanged();
            }
        }

        public string Telefoonnummer
        {
            get
            {
                return telefoonnummer;
            }
            set
            {
                telefoonnummer = value;
                NotifyPropertyChanged();
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                NotifyPropertyChanged();
            }
        }
    }
}
