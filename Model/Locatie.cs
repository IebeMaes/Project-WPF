using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
   public class Locatie : BaseModel
    {
        private int id;
        private string straat;
        private int huisnummer;
        private string gemeente;
        private string postcode;
        private string adres;
        

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

        public string Straat
        {
            get
            {
                return straat;
            }
            set
            {
                straat = value;
                NotifyPropertyChanged();
            }
        }

        public int Huisnummer
        {
            get
            {
                return huisnummer;
            }
            set
            {
                huisnummer = value;
                NotifyPropertyChanged();
            }
        }

        public string Gemeente
        {
            get
            {
                return gemeente;
            }
            set
            {
                gemeente = value;
                NotifyPropertyChanged();
            }
        }

        public string Postcode
        {
            get
            {
                return postcode;
            }
            set
            {
                postcode = value;
                NotifyPropertyChanged();
            }
        }



        public string Adres
        {
            get
            {
                string adres = straat + ' ' + huisnummer + ' ' + gemeente;
                return adres;
            }
            set
            {
                Adres = value;
                NotifyPropertyChanged();
            }
        }
    }
}
