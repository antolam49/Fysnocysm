using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetSymfoCS.DAL;

namespace ProjetSymfoCS.Metier
{
    public class Soiree_Metier
    {
        public string Lieu { get; set; }
        public DateTime Date { get; set; }

        public Soiree_Metier(string lieu, DateTime date) => (Lieu, Date) = (lieu, date);

        public void InsertIntoBDD()
        {
            List<Personne_DAL> list = new List<Personne_DAL>();
            Console.WriteLine("Combien de personne a la soiree ? ");
            string entry = Console.ReadLine();
            int nb = Int32.Parse(entry);
            for (int i = 0; i < nb; i++)
            {
                Console.WriteLine("Entrez votre nom: ");
                string nom = Console.ReadLine();
                Console.WriteLine("Entrez votre prenom: ");
                string prenom = Console.ReadLine();

                Personne_DAL personne = new Personne_DAL(nom, prenom);
                list.Add(personne);
            }
            SoireeDepot_DAL soireeD = new SoireeDepot_DAL();
            Soiree_DAL soiree = new Soiree_DAL(Lieu, Date, list);
            soireeD.Insert(soiree);
        }
        public void GetAllD()
        {
            SoireeDepot_DAL soiree = new SoireeDepot_DAL();
            var listeSoiree = new List<Soiree_DAL>();
            listeSoiree = soiree.GetAll();
            foreach (var item in listeSoiree)
            {
                Console.WriteLine(item.ID + (", ") + item.Lieu + (", ") + item.Date);
            }
           
        }
        public int GetID()
        {
            SoireeDepot_DAL soireeD = new SoireeDepot_DAL();
            List<Soiree_DAL> listS = new List<Soiree_DAL>();
            listS = soireeD.GetAll();
            Console.WriteLine("Taper le nombre de l'ID de votre soiree: ");
            string choix = Console.ReadLine();
            int nb = Int32.Parse(choix);

            return listS[nb].ID;
        }
        
    }
}
