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


    }
}