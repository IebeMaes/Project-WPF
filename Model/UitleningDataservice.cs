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
   public class UitleningDataservice
    {
        private static string connectionString =
        ConfigurationManager.ConnectionStrings["local"].ConnectionString;
        private static IDbConnection db = new SqlConnection(connectionString);


        public void InsertUitlening(Uitlening uitlening)
        {
            // SQL statement insert
            string sql = "Insert into Uitlening (voertuigid, persoonid, begindatum, beginuur) values (@voertuigid, @persoonid, @begindatum, @beginuur)";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new
            {
                uitlening.Voertuigid,
                uitlening.Persoonid,
                uitlening.Begindatum,
                uitlening.Beginuur
            });
        }

        public ObservableCollection<Uitlening> GetUitlening()
        {
            string sql = "Select * from Uitlening where einddatum is null";

            ObservableCollection<Uitlening> uitleningen = db.Query<Uitlening>(sql).ToObservableCollection();

            return uitleningen;
        }

        public void UpdateUitlening(Uitlening uitlening)
        {
            string sql = "Update Uitlening set einddatum = @einddatum, einduur = @einduur where id = @Id";

            db.Execute(sql, new
            {
                uitlening.Id,
                uitlening.Einddatum,
                uitlening.Einduur
            });
        }
    }
}
