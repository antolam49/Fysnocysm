using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetSymfoCS.DAL
{
    public class Personne_DAL
    {
       public int ID { get; set; }
       public string Nom { get; set; }
       public string Prenom { get; set; }

        public Personne_DAL(string nom, string prenom) => (Nom, Prenom) = (nom, prenom);
        public Personne_DAL(int id, string nom, string prenom) => (ID, Nom, Prenom) = (id, nom, prenom);

        internal void Insert(SqlConnection connexion)
        {
            using (var commande = new SqlCommand())
            {
                commande.Connection = connexion;
                commande.CommandText = "insert into Personne(nom, prenom)" + " values(@Nom,@Prenom)";

                commande.Parameters.Add(new SqlParameter("@Nom", Nom));
                commande.Parameters.Add(new SqlParameter("@Prenom", Prenom));

                commande.ExecuteNonQuery();
            }
        }

    }
}