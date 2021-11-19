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
        public int IDSoiree { get; set; }

        SqlConnection connexion = new SqlConnection();
        public Personne_DAL(string nom, string prenom) => (Nom, Prenom) = (nom, prenom);
        public Personne_DAL(int id, string nom, string prenom, int idSoiree) 
            => (ID, Nom, Prenom, IDSoiree) = (id, nom, prenom, idSoiree);

        public void Insert(SqlConnection connexion)
        {
                
                using (var commande = new SqlCommand())
                {
                    commande.Connection = connexion;
                    commande.CommandText = "insert into Personne(nom, prenom, idSoiree)" + " values(@Nom,@Prenom, @idSoiree); SELECT SCOPE_IDENTITY()";

                    commande.Parameters.Add(new SqlParameter("@Nom", Nom));
                    commande.Parameters.Add(new SqlParameter("@Prenom", Prenom));
                    commande.Parameters.Add(new SqlParameter("@idSoiree", IDSoiree));

                    ID = Convert.ToInt32((decimal)commande.ExecuteScalar());
                     



                }
                connexion.Close();
            }
        }

    }
