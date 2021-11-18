using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProjetSymfoCS.DAL
{
    internal class SoireeDepot_DAL : Depot_DAL<Soiree_DAL>
    {
        public override List<Soiree_DAL> GetAll()
        {
            CreerConnectionCommande();

            commande.CommandText = "select ID, lieu, date from Soiree";
            var reader = commande.ExecuteReader();

            var listeDeSoirees = new List<Soiree_DAL>();

            while (reader.Read())
            {
                var p = new Soiree_DAL(reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetDateTime(2));

                listeDeSoirees.Add(p);
            }

            DetruireConnexion();

            return listeDeSoirees;
        }

        public List<Soiree_DAL> GetAllByID(int ID)
        {
            CreerConnectionCommande();

            commande.CommandText = "select ID, lieu, date from Soiree where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));

            var reader = commande.ExecuteReader();

            var listeDeSoirees = new List<Soiree_DAL>();

            while (reader.Read())
            {
                var p = new Soiree_DAL(reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetDateTime(2));

                listeDeSoirees.Add(p);
            }

            DetruireConnexion();

            return listeDeSoirees;
        }

        public override Soiree_DAL GetByID(int ID)
        {
            CreerConnectionCommande();

            commande.CommandText = "select ID, lieu, date from Soiree where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            Soiree_DAL result;
            if (reader.Read())
            {
                result = new Soiree_DAL(reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetDateTime(2));
            }
            else
            {
                throw new Exception($"Aucune occurance à l'ID {ID} dans la table Soiree");
            }


            DetruireConnexion();

            return result;
        }

        public override Soiree_DAL Insert(Soiree_DAL Soiree)
        {
            CreerConnectionCommande();

            commande.CommandText = "insert into Soiree(lieu, date)" + " values (@Lieu, @Date); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@Lieu", Soiree.Lieu));
            commande.Parameters.Add(new SqlParameter("@Date", Soiree.Date));
            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            Soiree.ID = ID;

            DetruireConnexion();

            return Soiree;
        }
        public override Soiree_DAL Update(Soiree_DAL Soiree)
        {
            CreerConnectionCommande();

            commande.CommandText = "update Soiree SET lieu = @Lieu, date = @Date where ID = @ID";
            commande.Parameters.Add(new SqlParameter("@Lieu", Soiree.Lieu));
            commande.Parameters.Add(new SqlParameter("@Date", Soiree.Date));
            commande.Parameters.Add(new SqlParameter("@ID", Soiree.ID));

            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour le Soiree d'ID {Soiree.ID}");
            }


            DetruireConnexion();

            return Soiree;
        }


        public override void Delete(Soiree_DAL Soiree)
        {
            CreerConnectionCommande();
            commande.CommandText = "delete from Soiree where ID = @ID";
            commande.Parameters.Add(new SqlParameter("@ID", Soiree.ID));
            var reader = commande.ExecuteReader();


            if (commande.ExecuteNonQuery() == 0)
            {
                throw new Exception($"Aucune occurance à l'ID {Soiree.ID} dans la table Soiree");
            }
            DetruireConnexion();
        }
    }
}
