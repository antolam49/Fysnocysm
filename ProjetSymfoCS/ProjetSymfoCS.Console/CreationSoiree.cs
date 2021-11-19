using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetSymfoCS.Metier;

namespace ProjetSymfoCS_Console
{
    internal class CreationSoiree
    {
        public static void CreerSoiree()
        {
            Console.WriteLine("Entrez le lieu de la soiree: ");
            string lieu = Console.ReadLine();
            Console.WriteLine("Entrez la date: ");
            string date = Console.ReadLine();
            var cultureInfo = new CultureInfo("fr-FR");
            var dateSoiree = DateTime.Parse(date, cultureInfo);

            Soiree_Metier soiree = new Soiree_Metier(lieu, dateSoiree);
            soiree.InsertIntoBDD();

            Console.ReadLine();

        }
        public static void GetAllMetier()
        {
            string lieu = "Quelque part";
            string date = "21 Nov 2021";
            var cultureInfo = new CultureInfo("fr-FR");
            var dateSoiree = DateTime.Parse(date, cultureInfo);
            Soiree_Metier soiree = new Soiree_Metier(lieu, dateSoiree);
            soiree.GetAllD();      

        }
        
    }
}
