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

        public List<Personne_DAL> Personnes { get; set; }    
        SqlConnection connexion = new SqlConnection();
        public Soiree_DAL(int id, string lieu, DateTime date)
            => (ID, Lieu, Date) = (id, lieu, date);
        public Soiree_DAL(string lieu, DateTime date, IEnumerable<Personne_DAL> desPers) 
            => (Lieu, Date, Personnes) = (lieu, date, desPers.ToList());
        

        public Soiree_DAL(int id, string lieu, DateTime date, IEnumerable<Personne_DAL> desPers) 
            => (ID, Lieu, Date, Personnes) = (id, lieu, date, desPers.ToList());

        public void Insert()
        {
            var chaineDeConnexion = "Data Source=localhost;Initial Catalog=Fysnocysm;Integrated Security=True";
            using (var connexion = new SqlConnection(chaineDeConnexion))
            {
                
                using (var commande = new SqlCommand())
                {
                    commande.Connection = connexion;
                    commande.CommandText = "insert into Soiree(lieu, date)" + " values(@Lieu, @Date) ; SELECT SCOPE_IDENTITY()";
                    
                    commande.Parameters.Add(new SqlParameter("@Lieu", Lieu));
                    commande.Parameters.Add(new SqlParameter("@Date", Date));
                    ID = Convert.ToInt32((decimal)commande.ExecuteScalar());
                    
                }


                foreach (var item in Personnes)
                {
                    item.IDSoiree = ID;
                    item.Insert(connexion);

                }
                connexion.Close();
            }
        }
    }
}
