using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ProjetSymfoCS.DAL
{
    public class PersonneDepot_DAL : Depot_DAL<Personne_DAL>
    {
        public override List<Personne_DAL> GetAll()
        {
            CreerConnectionCommande();

            commande.CommandText = "select ID, nom, prenom, idSoiree from Personne";
            var reader = commande.ExecuteReader();

            var listeDePersonnes = new List<Personne_DAL>();

            while (reader.Read())
            {
                var p = new Personne_DAL(reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetString(2),
                                        reader.GetInt32(3));

                listeDePersonnes.Add(p);
            }

            DetruireConnexion();

            return listeDePersonnes;
        }

        public List<Personne_DAL> GetAllByIDSoiree(int ID)
        {
            CreerConnectionCommande();

            commande.CommandText = "select ID, nom, prenom, idSoiree from Personne where idSoiree=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));

            var reader = commande.ExecuteReader();

            var listeDePersonnes = new List<Personne_DAL>();

            while (reader.Read())
            {
                var p = new Personne_DAL(reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetString(2),
                                        reader.GetInt32(3));

                listeDePersonnes.Add(p);
            }

            DetruireConnexion();

            return listeDePersonnes;
        }

        public override Personne_DAL GetByID(int ID)
        {
            CreerConnectionCommande();

            commande.CommandText = "select ID, nom, prenom, idSoiree from Personne where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            Personne_DAL result;
            if (reader.Read())
            {
                result = new Personne_DAL(reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetString(2),
                                        reader.GetInt32(3));
            }
            else
            {
                throw new Exception($"Aucune occurance à l'ID {ID} dans la table Personne");
            }


            DetruireConnexion();

            return result;
        }

        public override Personne_DAL Insert(Personne_DAL Personne)
        {
            CreerConnectionCommande();

            commande.CommandText = "insert into Personne(nom, prenom, idSoiree)" + " values (@Nom, @Prenom, @idSoiree); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@Nom", Personne.Nom));
            commande.Parameters.Add(new SqlParameter("@Prenom", Personne.Prenom));
            commande.Parameters.Add(new SqlParameter("@idSoiree", Personne.IDSoiree));
            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            Personne.ID = ID;

            DetruireConnexion();

            return Personne;
        }
        public override Personne_DAL Update(Personne_DAL Personne)
        {
            CreerConnectionCommande();

            commande.CommandText = "update Personne SET nom = @Nom, prenom = @Prenom where ID = @ID";
            commande.Parameters.Add(new SqlParameter("@Nom", Personne.Nom));
            commande.Parameters.Add(new SqlParameter("@Prenom", Personne.Prenom));
            commande.Parameters.Add(new SqlParameter("@ID", Personne.ID));

            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour le Personne d'ID {Personne.ID}");
            }


            DetruireConnexion();

            return Personne;
        }


        public override void Delete(Personne_DAL Personne)
        {
            CreerConnectionCommande();
            commande.CommandText = "delete from Personne where ID = @ID";
            commande.Parameters.Add(new SqlParameter("@ID", Personne.ID));
            var reader = commande.ExecuteReader();


            if (commande.ExecuteNonQuery() == 0)
            {
                throw new Exception($"Aucune occurance à l'ID {Personne.ID} dans la table Personne");
            }
            DetruireConnexion();
        }
    }
}
