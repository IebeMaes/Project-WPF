using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Project.Model
{
   public class LocatieDataService
    {
        private static string connectionString =
        ConfigurationManager.ConnectionStrings["local"].ConnectionString;
        private static IDbConnection db = new SqlConnection(connectionString);


        public List<Locatie> GetLocaties()
        {
            string sql = "select * from Locatie";
            return (List<Locatie>)db.Query<Locatie>(sql);

        }
        public void InsertLocatie(Locatie locatie)
        {
            // SQL statement insert
            string sql = "Insert into Locatie (straat, huisnummer, gemeente, postcode) values (@straat, @huisnummer, @gemeente, @postcode)";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new
            {
                locatie.Straat,
                locatie.Huisnummer,
                locatie.Gemeente,
                locatie.Postcode
            });
        }

        public void UpdateLocatie(Locatie locatie)
        {
            string sql = "Update Locatie set straat = @straat, huisnummer = @huisnummer, gemeente = @gemeente, postcode = @postcode where id = @Id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new
            {
                locatie.Id,
                locatie.Straat,
                locatie.Huisnummer,
                locatie.Gemeente,
                locatie.Postcode

            });
        }

        public void DeleteLocatie(Locatie locatie)
        {
            // SQL statement delete 
            string sql = "Delete Locatie where id = @Id";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { locatie.Id });
        }
    }
}
