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
            Console.WriteLine("1- Ajouter Utilisateur \n 2- Creer Soiree \n 3- Entrer une depense \n 4- Afficher les Depenses");
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
                case "4":

                    afficherSoirees();
                    Console.WriteLine("Entrez le numero de votre soiree: ");
                    string entry = Console.ReadLine();
                    int IDSoiree = Int32.Parse(entry);
                    double depenseTotal = afficherPrix(IDSoiree);
                    int nbParticipant = afficherNbParticipant(IDSoiree);
                    List<double> balances = new List<double>();

                    int moyenne = Convert.ToInt32(depenseTotal) / nbParticipant;
                    for (int i = 0; i < nbParticipant; i++)
                    {
                        double bal = Balance(i, depenseTotal, nbParticipant, IDSoiree);

                        balances.Add(bal - moyenne);
                    }
                    List<string> noms = new List<string>();
                    noms = afficherNom(IDSoiree);
                    for (int j = 0; j < nbParticipant; j++)
                    {
                        Console.WriteLine(noms[j] + (" a une balance de ") + balances[j]);
                    }
                    Console.WriteLine("Appuyer sur Entree pour savoir qui doit quoi !");
                    Console.ReadLine();
                    List<int> vs = new List<int>();
                    for (int j = 0; j < nbParticipant; j++)
                    {
                        if (balances[j] < 0)
                        {
                            Console.WriteLine(noms[j] + (" doit donner ") + (balances[j] * (-1)));
                            int i = 1;
                            vs.Add(i);
                        }
                        else
                        {
                            Console.WriteLine(noms[j] + (" doit recevoir ") + balances[j]);
                            int i = 2;
                            vs.Add(i);
                        }
                    }
                    for (int i = 0; i < vs.Count(); i++)
                    {
                        if (vs[i] == 1)
                        {
                            for (int j = 0; j < vs.Count(); j++)
                            {
                                if (vs[j] == 2)
                                {
                                    if (balances[i] != 0)
                                    {
                                        if (balances[j] != 0)
                                        {
                                            if (balances[j] < (balances[i] * (-1)))
                                            {
                                                Console.WriteLine(noms[i] + (" doit donner ") + balances[j] + (" a ") + noms[j]);
                                                balances[i] = balances[i] + balances[j];
                                                balances[j] = 0;
                                            }
                                            else
                                            {
                                                Console.WriteLine(noms[i] + (" doit donner ") + (balances[i] * (-1)) + (" a ") + noms[j]);
                                                balances[j] = balances[j] - balances[i];
                                                balances[i] = 0;

                                            }
                                        }
                                    }  
                                }
                            }
                        }
                    }
                    


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
        public static double afficherPrix(int idSoiree)
        {
            return AjoutPrix.AfficherPrixByID(idSoiree);
        }
        public static int afficherNbParticipant(int idSoiree)
        {
            return AjoutPersonne.GetNbParticipant(idSoiree);
        }
        public static double Balance(int nb, double depense, int nbParticipant, int idSoiree)
        {
            return AjoutPrix.GetBalance(nb, depense, nbParticipant, idSoiree); 
        }
        public static List<string> afficherNom(int id)
        {
            return AjoutPersonne.GetNom(id);
        }
    }
}
