using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Dapper;

namespace Project.Model
{
   public class VoertuigDataService
    {
        private static string connectionString =
        ConfigurationManager.ConnectionStrings["local"].ConnectionString;
        private static IDbConnection db = new SqlConnection(connectionString);

        

        public ObservableCollection<Voertuig> GetAuto()
        {

            
                string sql = "SELECT * from Voertuig v INNER JOIN Locatie l ON v.locatieid = l.Id where v.soortid = 1";
                var autos = db.Query<Voertuig, Locatie, Voertuig>(sql, (voertuig, locatie) =>
                {
                    voertuig.Locatie = locatie;
                    return voertuig;
                },
                splitOn: "Id");

                return new ObservableCollection<Voertuig>((List<Voertuig>)autos);

        }
        public ObservableCollection<Voertuig> GetFiets()
        {

                
            string sql = "SELECT * from Voertuig v INNER JOIN Locatie l ON v.locatieid = l.Id where v.soortid = 2";
            var fietsen = db.Query<Voertuig, Locatie, Voertuig>(sql, (voertuig, locatie) =>
            {
                voertuig.Locatie = locatie;
                return voertuig;
            },
            splitOn: "Id");

            return new ObservableCollection<Voertuig>((List<Voertuig>)fietsen);

        }

        public void UpdateAuto(Voertuig voertuig)
        {
            // SQL statement update 
            string sql = "Update Voertuig set kleur = @kleur, merk = @merk, aantalPersonen = @aantalPersonen, locatieid = @locatieid, nummerplaat = @nummerplaat where id = @Id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new
            {
                voertuig.Id,
                voertuig.Kleur,
                voertuig.Merk,
                voertuig.AantalPersonen,
                voertuig.Locatieid,
                voertuig.Nummerplaat

            });
        }

        public void UpdateStatus(Voertuig voertuig)
        {
            string sql = "Update Voertuig set";
        }

        public void UpdateFiets(Voertuig voertuig)
        {
            // SQL statement update 
            string sql = "Update Voertuig set kleur = @kleur, merk = @merk, aantalPersonen = @aantalPersonen, locatieid = @locatieid where id = @Id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new
            {
                voertuig.Id,
                voertuig.Kleur,
                voertuig.Merk,
                voertuig.AantalPersonen,
                voertuig.Locatieid

            });
        }


        public void InsertAuto(Voertuig voertuig)
        {
            // SQL statement insert
            string sql = "Insert into Voertuig (kleur, merk, aantalPersonen, nummerplaat, soortid, locatieid) values (@kleur, @merk, @aantalPersonen, @nummerplaat, 1, @locatieid)";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new
            {
                voertuig.Kleur,
                voertuig.Merk,
                voertuig.AantalPersonen,
                voertuig.Nummerplaat,
                voertuig.Locatieid
            });
        }

        public void InsertFiets(Voertuig voertuig)
        {
            // SQL statement insert
            string sql = "Insert into Voertuig (kleur, merk, aantalPersonen, soortid, locatieid) values (@kleur, @merk, @aantalPersonen, 2, @locatieid)";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new
            {
                voertuig.Kleur,
                voertuig.Merk,
                voertuig.AantalPersonen,
                voertuig.Locatieid
            });
        }


        public void DeleteVoertuig(Voertuig voertuig)
        {
            // SQL statement delete 
            string sql = "Delete Voertuig where id = @Id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { voertuig.Id });
        }

        



    }
}

