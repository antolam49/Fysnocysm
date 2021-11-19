using System;
using System.Collections.Generic;
using System.Linq;
using ProjetSymfoCS.Metier;

namespace ProjetSymfoCS_Console 
{
    public class Program
    {

        
        public static void Main(string[] args)
        {
            Console.WriteLine("Bonjour Bienvenue sur Fysnocysm !");
            Console.WriteLine("1- Ajouter Utilisateur \n 2- Creer Soiree \n 3- Entrer une depense \n");
            Console.WriteLine("Veuillez choisir un nombre : ");
            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    menuAjouterPersonne();

                    break;
                case "2":

                    menuCreerSoiree();
                    
                    break;
                case "3":

                    afficherSoirees();
                    Console.WriteLine("Entrez le numero de votre soiree: ");
                    string num = Console.ReadLine();
                    int idSoiree = Int32.Parse(num);
                    afficherPersonnes(idSoiree);
                    Console.WriteLine("Qui etes vous ? Entrez votre numero: ");
                    string numP = Console.ReadLine();
                    int idPersonne = Int32.Parse(numP);
                    menuEntrerPrix(idSoiree, idPersonne);

                    break;
                default:

                    Console.WriteLine("Vous n'avez choisis le bon nombre");
                    break;
            }
        }
        public static void menuAjouterPersonne()
        {

            AjoutPersonne.AjouterPersonne();
        }
        public static void menuCreerSoiree()
        {
            CreationSoiree.CreerSoiree();
        }
        public static void afficherSoirees()
        {
            CreationSoiree.GetAllMetier();
        }
        public static void afficherPersonnes(int id)
        {
            AjoutPersonne.GetAll(id);
        }
        
        public static void menuEntrerPrix(int idSoiree, int idPersonne)
        {
            AjoutPrix.AjoutPrixIntoBDD(idSoiree, idPersonne);
        }
    }
}
