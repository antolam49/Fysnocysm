using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProjetSymfoCS.DAL
{
    public class Soiree_DAL
    {
        public int ID { get; set; }
        public string Lieu{ get; set; }
        public DateTime Date { get; set; }
        SqlConnection connexion = new SqlConnection();
        public Soiree_DAL(string lieu, DateTime date) => (Lieu, Date) = (lieu, date);

        public Soiree_DAL(int id, string lieu, DateTime date) => (ID, Lieu, Date) = (id, lieu, date);

        public void Insert()
        {
            var chaineDeConnexion = "Data Source=localhost;Initial Catalog=Fysnocysm;Integrated Security=True";
            using (var connexion = new SqlConnection(chaineDeConnexion))
            {
                connexion.Open();
                using (var commande = new SqlCommand())
                {
                    commande.Connection = connexion;
                    commande.CommandText = "insert into Soiree(lieu, date)" + " values(@Lieu, @Date)";

                    commande.Parameters.Add(new SqlParameter("@Lieu", Lieu));
                    commande.Parameters.Add(new SqlParameter("@Date", Date));


                    commande.ExecuteNonQuery();


                }
                connexion.Close();
            }
        }
    }
}
