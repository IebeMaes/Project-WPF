using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
   public class Uitlening : BaseModel
    {
        private int id;
        private int voertuigid;
        private Voertuig voertuig;
        private int persoonid;
        private Persoon persoon;
        private string begindatum;
        private string einddatum;
        private string beginuur;
        private string einduur;

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
        public int Voertuigid
        {
            get
            {   
                return voertuigid;
            }
            set
            {
                voertuigid = value;
                NotifyPropertyChanged();
            }
        }
        public Voertuig Voertuig
        {
            get
            {
                return voertuig;
            }
            set
            {
                voertuig = value;
                NotifyPropertyChanged();
            }
        }
        public int Persoonid
        {
            get
            {
                return persoonid;
            }
            set
            {
                persoonid = value;
                NotifyPropertyChanged();
            }
        }
        public Persoon Persoon
        {
            get
            {
                return persoon;
            }
            set
            {
                persoon = value;    
                NotifyPropertyChanged();
            }
        }
        public string Begindatum
        {
            get
            {
                return begindatum;
            }
            set 
            {
                begindatum = value;
                NotifyPropertyChanged();
            }
        }
        public string Einddatum
        {
            get
            {
                return einddatum;
            }
            set
            {
                einddatum = value;
                NotifyPropertyChanged();
            }
        }
        public string Beginuur
        {
            get
            {
                return beginuur;
            }
            set
            {
                beginuur = value;
                NotifyPropertyChanged();
            }
        }
        public string Einduur
        {
            get
            {
                return einduur;
            }
            set
            {
                einduur = value;
                NotifyPropertyChanged();
            }
        }


    }
}
