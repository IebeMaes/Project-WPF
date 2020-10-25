using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
  public class Voertuig : BaseModel
    {
        private int id;
        private string kleur;
        private string merk;
        private int aantalPersonen;
        private Soort soort;
        private Locatie locatie;
        private int locatieid;
        private string nummerplaat;

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
        public string Kleur
        {
            get
            {
                return kleur;
            }
            set
            {
                kleur = value;
                NotifyPropertyChanged();
            }
        }

        public int AantalPersonen
        {
            get
            {
                return aantalPersonen;
            }
            set
            {
                aantalPersonen = value;
                NotifyPropertyChanged();
            }
        }
        public string Merk
        {
            get
            {
                return merk;
            }
            set
            {
                merk = value;
                NotifyPropertyChanged();
            }
        }
        public Soort Soort  
        {
            get
            {
                return soort;
            }
            set
            {
                soort = value;
                NotifyPropertyChanged();
            }
        }
        public Locatie Locatie 
        {
            get
            {
                return locatie;
            }
            set
            {
                locatie = value;
                NotifyPropertyChanged();
            }
        }

        public string Nummerplaat
        {
            get
            {
                return nummerplaat;
            }
            set
            {
                nummerplaat = value;
                NotifyPropertyChanged();
            }
        }

        

        public int Locatieid
        {
            get
            {
                return locatieid;
            }
            set
            {
                locatieid = value;
                NotifyPropertyChanged();
            }
        }
    }
}
