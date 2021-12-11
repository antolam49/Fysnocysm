using ProjetSymfoCS.DAL;
using System;
using Xunit;

namespace ProjetSymfoCS_DAL_Tests
{
    public class PersonneDepot_DAL_Tests
    {
        [Fact]
        public void PersonneDepot_DAL_TesterGetAll()
        {
            var depot = new PersonneDepot_DAL();
            var personne = depot.GetAll();

            Assert.NotNull(personne);
        }

        [Fact]
        public void PersonneDepot_DAL_TesterGetByID()
        {
            var depot = new PersonneDepot_DAL();
            var personne = depot.GetByID(1);

            Assert.NotNull(personne);
            Assert.Equal(1, personne.ID);
            Assert.NotEmpty(personne.Nom);
            Assert.NotEmpty(personne.Prenom);
        }

        [Fact]
        public void PersonneDepot_DAL_TesterGetAllByIDSoiree()
        {
            var depot = new PersonneDepot_DAL();
            var listpersonne = depot.GetAllByIDSoiree(1);

            Assert.NotNull(listpersonne);

            foreach (var personne in listpersonne)
            {
                Assert.Equal(1, personne.IDSoiree);
            }
        }

        [Fact]
        public void PersonneDepot_DAL_TesterInsertUpdateDelete()
        {
            var depot = new PersonneDepot_DAL();
            var personne = new Personne_DAL("Jean", "Test");
            depot.Insert(personne);

            Assert.NotNull(personne);
            Assert.Equal("Jean", personne.Nom);
            Assert.Equal("Test", personne.Prenom);

            personne.Nom = "Petit";
            depot.Update(personne);

            Assert.NotNull(personne);
            Assert.Equal("Petit", personne.Nom);
            Assert.Equal("Test", personne.Prenom);

            depot.Delete(personne);

            Assert.Null(personne);
        }

        

    }
}
