using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetSymfoCS.DAL;

namespace ProjetSymfoCS.Metier
{
    public class Prix_Metier
    {
        public float Montant { get; set; }
        public int IDSoiree { get; set; }
        public int IDPersonne { get; set; }

        public Prix_Metier(float montant, int idSoiree, int idPersonne )
            => (Montant, IDPersonne, IDSoiree) = (montant, idPersonne, idSoiree);

        public void InsertIntoBDD()
        {
            Prix_DAL prix = new Prix_DAL(Montant, IDPersonne, IDSoiree);
            PrixDepot_DAL prixD =  new DAL.PrixDepot_DAL();
            prixD.Insert(prix);
        }
        public double AfficherPrix(int idSoiree)
        {
            List<Prix_DAL> listP = new List<Prix_DAL>();
            PrixDepot_DAL prixD = new DAL.PrixDepot_DAL();
            listP = prixD.GetAllByIDSoiree(idSoiree);

            double prixTotal = 0;
            foreach (var item in listP)
            {
                prixTotal = prixTotal + item.Montant;
            }
            return prixTotal;
        }
        public List<double> AfficherPrixByParticipant(int idSoiree)
        {
            List<Prix_DAL> listP = new List<Prix_DAL>();
            PrixDepot_DAL prixD = new DAL.PrixDepot_DAL();
            listP = prixD.GetAllByIDSoiree(idSoiree);

            PersonneDepot_DAL personne = new PersonneDepot_DAL();
            var listePersonne = new List<Personne_DAL>();
            List<double> Depense = new List<double>();
            listePersonne = personne.GetAllByIDSoiree(idSoiree);
            int nb = 0;
            foreach (var item in listePersonne)
            {
                nb++;
            }
            for (int i = 0; i < nb; i++)
            {
                int nbDepense = 0;
                Depense.Add(nbDepense);
            }

            foreach (var item in listP)
            {
                for (int i = 0; i < listePersonne.Count; i++)
                {
                    if (item.IDPersonne == listePersonne[i].ID)
                    { 
                        Depense[i] +=  item.Montant; 
                    }
                } 
            }
            return Depense;
        }
    }
}
