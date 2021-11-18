using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProjetSymfoCS.DAL
{
    internal class Prix_DAL
    {
        public int ID { get; set; }
        public float Montant { get; set; }
        public int IDPersonne { get; set;}
        public int IDSoiree { get; set; }

        public Prix_DAL(float montant, int idPersonne, int idSoiree) => (Montant, IDPersonne, IDSoiree)
            = (montant, idPersonne, idSoiree);
        public Prix_DAL(int id, float montant, int idPersonne, int idSoiree) => (ID, Montant, IDPersonne, IDSoiree)
            = (id, montant, idPersonne, idSoiree);

        internal void Insert(SqlConnection connexion)
        {
            using (var commande = new SqlCommand())
            {
                commande.Connection = connexion;
                commande.CommandText = "insert into Prix(montant, idPersonne, idSoiree)" + " values(@Montant, @idPersonne, @idSoiree)";

                commande.Parameters.Add(new SqlParameter("@Montant", Montant));
                commande.Parameters.Add(new SqlParameter("@idPersonne", IDPersonne));
                commande.Parameters.Add(new SqlParameter("@idSoiree", IDSoiree));

                commande.ExecuteNonQuery();
            }
        }
    }
}
