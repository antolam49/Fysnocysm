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

            Soiree_DAL soiree = new Soiree_DAL(Lieu, Date);
            soiree.Insert();
        }
        public List<Soiree_DAL> GetAllD()
        {
            SoireeDepot_DAL soiree = new SoireeDepot_DAL();
            var listeSoiree = new List<Soiree_DAL>();
            listeSoiree = soiree.GetAll();
            return listeSoiree;
        }
        public Soiree_Metier GetList()
        {
            Soiree_Metier soiree = new Soiree_Metier();
            var liste = soiree.GetAllD().ToList<SoireeDepot_DAL>;
            return liste;
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
