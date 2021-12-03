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
                    AjoutPersonne.AjouterPersonne();

                    break;
                case "2":

                    CreationSoiree.CreerSoiree();
                    
                    break;
                case "3":
                    CreationSoiree.GetAllMetier();
                    Console.WriteLine("Entrez le numero de votre soiree: ");
                    string num = Console.ReadLine();
                    int idSoiree = Int32.Parse(num);
                    AjoutPersonne.GetAll(idSoiree);
                    Console.WriteLine("Qui etes vous ? Entrez votre numero: ");
                    string numP = Console.ReadLine();
                    int idPersonne = Int32.Parse(numP);
                    AjoutPrix.AjoutPrixIntoBDD(idSoiree, idPersonne);

                    break;
                case "4":

                    CreationSoiree.GetAllMetier();
                    Console.WriteLine("Entrez le numero de votre soiree: ");
                    string entry = Console.ReadLine();
                    int IDSoiree = Int32.Parse(entry);
                    double depenseTotal = AjoutPrix.AfficherPrixByID(IDSoiree);
                    int nbParticipant = AjoutPersonne.GetNbParticipant(IDSoiree);
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
