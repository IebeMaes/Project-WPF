using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Project.Extensions;

namespace Project.Model
{
   public class PersoonDataService
    {
        private static string connectionString =
        ConfigurationManager.ConnectionStrings["local"].ConnectionString;
        private static IDbConnection db = new SqlConnection(connectionString);


        public ObservableCollection<Persoon> GetPersoon()
        {
            string sql = "SELECT * from Persoon";

            ObservableCollection<Persoon> personen = db.Query<Persoon>(sql).ToObservableCollection();

            return personen;
        }

        public void InsertPersoon(Persoon persoon)
        {
            // SQL statement insert
            string sql = "Insert into Persoon (voornaam, achternaam, telefoonnummer, email) values (@voornaam, @achternaam, @telefoonnummer, @email)";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new
            {
                persoon.Voornaam,
                persoon.Achternaam,
                persoon.Telefoonnummer,
                persoon.Email
            });
        }

        public void UpdatePersoon(Persoon persoon)
        {
            string sql = "Update Persoon set voornaam = @voornaam, achternaam = @achternaam, telefoonnummer = @telefoonnummer, email = @email where id = @Id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new
            {
                persoon.Id,
                persoon.Voornaam,
                persoon.Achternaam,
                persoon.Telefoonnummer,
                persoon.Email

            });
        }
            
        public void DeletePersoon(Persoon persoon)
        {
            // SQL statement delete 
            string sql = "Delete Persoon where id = @Id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { persoon.Id });
        }












    }
}
