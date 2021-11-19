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
            => (Montant, IDSoiree, IDPersonne) = (montant, idSoiree, idPersonne);

        public void InsertIntoBDD()
        {
            Prix_DAL prix = new Prix_DAL(Montant, IDSoiree, IDPersonne);
            PrixDepot_DAL prixD =  new DAL.PrixDepot_DAL();
            prixD.Insert(prix);
        }
    }
}
