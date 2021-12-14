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
            var personneB = depot.GetByID(personne.ID);


            Assert.NotNull(personneB);
            Assert.Equal("Jean", personneB.Nom);
            Assert.Equal("Test", personneB.Prenom);

            personne.Nom = "Petit";
            depot.Update(personne);
            personneB = depot.GetByID(personne.ID);

            Assert.NotNull(personneB);
            Assert.Equal("Petit", personneB.Nom);
            Assert.Equal("Test", personneB.Prenom);

            depot.Delete(personne);

            try
            {
                personneB = depot.GetByID(personne.ID);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        

    }
}
