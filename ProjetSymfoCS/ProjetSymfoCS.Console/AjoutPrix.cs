using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetSymfoCS.Metier;

namespace ProjetSymfoCS_Console
{
    internal static class AjoutPrix
    {
        public static void AjoutPrixIntoBDD(int idSoiree, int idPersonne)
        {
            Console.WriteLine("Entrez le montant: ");
            string entry = Console.ReadLine();
            float montant = Int32.Parse(entry);

            Prix_Metier prix = new Prix_Metier(montant, idSoiree, idPersonne);
            prix.InsertIntoBDD();

            Console.ReadLine();

        }

        public static double AfficherPrixByID(int idSoiree)
        {
            float montant = 0.1F;
            int idPersonne = 0;
            Prix_Metier prix = new Prix_Metier(montant, idSoiree, idPersonne);
            return prix.AfficherPrix(idSoiree);
        }
    }
}
