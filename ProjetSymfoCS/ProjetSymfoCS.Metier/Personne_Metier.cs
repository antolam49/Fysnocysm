using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ProjetSymfoCS.DAL;

namespace ProjetSymfoCS.Metier
{
    public class Personne_Metier
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }

        public Personne_Metier(string nom, string prenom) => (Nom, Prenom) = (nom, prenom);

        
        public void GetAll()
        {
            PersonneDepot_DAL personne = new PersonneDepot_DAL();
            personne.GetAll();
        }
    }
   
}