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

        SqlConnection connexion = new SqlConnection();
        public Personne_DAL(string nom, string prenom) => (Nom, Prenom) = (nom, prenom);
        public Personne_DAL(int id, string nom, string prenom) => (ID, Nom, Prenom) = (id, nom, prenom);

        public void Insert()
        {
            var chaineDeConnexion = "Data Source=localhost;Initial Catalog=Fysnocysm;Integrated Security=True";
            using (var connexion = new SqlConnection(chaineDeConnexion))
            {
                connexion.Open();
                using (var commande = new SqlCommand())
                {
                    commande.Connection = connexion;
                    commande.CommandText = "insert into Personne(nom, prenom)" + " values(@Nom,@Prenom); SELECT SCOPE_IDENTITY()";

                    commande.Parameters.Add(new SqlParameter("@Nom", Nom));
                    commande.Parameters.Add(new SqlParameter("@Prenom", Prenom));

                    
                    commande.ExecuteNonQuery();

                    
                }
                connexion.Close();
            }
        }

    }
}