using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProjetSymfoCS.DAL
{
    internal class PrixDepot_DAL : Depot_DAL<Prix_DAL>
    {
        public override List<Prix_DAL> GetAll()
        {
            CreerConnectionCommande();

            commande.CommandText = "select ID, motant, idPersonne, idSoiree from Prix";
            var reader = commande.ExecuteReader();

            var listeDePrixs = new List<Prix_DAL>();

            while (reader.Read())
            {
                var p = new Prix_DAL(reader.GetInt32(0),
                                        reader.GetFloat(1),
                                        reader.GetInt32(2),
                                        reader.GetInt32(3));

                listeDePrixs.Add(p);
            }

            DetruireConnexion();

            return listeDePrixs;
        }

        public List<Prix_DAL> GetAllByID(int ID)
        {
            CreerConnectionCommande();

            commande.CommandText = "select ID, motant, idPersonne, idSoiree from Prix where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));

            var reader = commande.ExecuteReader();

            var listeDePrixs = new List<Prix_DAL>();

            while (reader.Read())
            {
                var p = new Prix_DAL(reader.GetInt32(0),
                                        reader.GetFloat(1),
                                        reader.GetInt32(2),
                                        reader.GetInt32(3));

                listeDePrixs.Add(p);
            }

            DetruireConnexion();

            return listeDePrixs;
        }

        public override Prix_DAL GetByID(int ID)
        {
            CreerConnectionCommande();

            commande.CommandText = "select ID, motant, idPersonne, idSoiree from Prix where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            Prix_DAL result;
            if (reader.Read())
            {
                result = new Prix_DAL(reader.GetInt32(0),
                                        reader.GetFloat(1),
                                        reader.GetInt32(2),
                                        reader.GetInt32(3));
            }
            else
            {
                throw new Exception($"Aucune occurance à l'ID {ID} dans la table Prix");
            }


            DetruireConnexion();

            return result;
        }

        public override Prix_DAL Insert(Prix_DAL Prix)
        {
            CreerConnectionCommande();

            commande.CommandText = "insert into Prix(montant, idPersonne, idSoiree)" + " values (@Montant, @IDPersonne, @IDSoiree); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@Montant", Prix.Montant));
            commande.Parameters.Add(new SqlParameter("@IDPersonne", Prix.IDPersonne));
            commande.Parameters.Add(new SqlParameter("@IDSoiree", Prix.IDSoiree));
            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            Prix.ID = ID;

            DetruireConnexion();

            return Prix;
        }
        public override Prix_DAL Update(Prix_DAL Prix)
        {
            CreerConnectionCommande();

            commande.CommandText = "update Prix SET montant = @Montant, idPersonne = @IDPersonne, idSoiree = @IDSoiree where ID = @ID";
            commande.Parameters.Add(new SqlParameter("@Montant", Prix.Montant));
            commande.Parameters.Add(new SqlParameter("@IDPersonne", Prix.IDPersonne));
            commande.Parameters.Add(new SqlParameter("@IDSoiree", Prix.IDSoiree));
            commande.Parameters.Add(new SqlParameter("@ID", Prix.ID));

            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour le Prix d'ID {Prix.ID}");
            }


            DetruireConnexion();

            return Prix;
        }


        public override void Delete(Prix_DAL Prix)
        {
            CreerConnectionCommande();
            commande.CommandText = "delete from Prix where ID = @ID";
            commande.Parameters.Add(new SqlParameter("@ID", Prix.ID));
            var reader = commande.ExecuteReader();


            if (commande.ExecuteNonQuery() == 0)
            {
                throw new Exception($"Aucune occurance à l'ID {Prix.ID} dans la table Prix");
            }
            DetruireConnexion();
        }
    }
}
