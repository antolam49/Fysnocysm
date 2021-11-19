using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProjetSymfoCS.DAL
{
    public class Prix_DAL
    {
        public int ID { get; set; }
        public float Montant { get; set; }
        public int IDPersonne { get; set;}
        public int IDSoiree { get; set; }

        SqlConnection connexion = new SqlConnection();
        public Prix_DAL(float montant, int idPersonne, int idSoiree) => (Montant, IDPersonne, IDSoiree)
            = (montant, idPersonne, idSoiree);
        public Prix_DAL(int id, float montant, int idPersonne, int idSoiree) => (ID, Montant, IDPersonne, IDSoiree)
            = (id, montant, idPersonne, idSoiree);

        public void Insert()
        {
            var chaineDeConnexion = "Data Source=localhost;Initial Catalog=Fysnocysm;Integrated Security=True";
            using (var connexion = new SqlConnection(chaineDeConnexion))
            {
                connexion.Open();
                using (var commande = new SqlCommand())
                {
                    commande.Connection = connexion;
                    commande.CommandText = "insert into Prix(montant, idPersonne, idSoiree)" + " values(@Montant, @idPersonne, @idSoiree)";

                    commande.Parameters.Add(new SqlParameter("@Montant", Montant));
                    commande.Parameters.Add(new SqlParameter("@idPersonne", IDPersonne));
                    commande.Parameters.Add(new SqlParameter("@idSoiree", IDSoiree));

                    


                }
                connexion.Close();
            }
        }
    }
}
