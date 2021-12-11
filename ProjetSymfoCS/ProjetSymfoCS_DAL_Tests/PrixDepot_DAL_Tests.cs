using ProjetSymfoCS.DAL;
using System;
using Xunit;

namespace ProjetSymfoCS_DAL_Tests
{
    public class PrixDepot_DAL_Tests
    {
        [Fact]
        public void PrixDepot_DAL_TesterGetAll()
        {
            var depot = new PrixDepot_DAL();
            var prix = depot.GetAll();

            Assert.NotNull(prix);
        }

        [Fact]
        public void PrixDepot_DAL_TesterGetByID()
        {
            var depot = new PrixDepot_DAL();
            var prix = depot.GetByID(1);

            Assert.NotNull(prix);
            Assert.Equal(1, prix.ID);
            
            
        }

        [Fact]
        public void PrixDepot_DAL_TesterGetAllByIDSoiree()
        {
            var depot = new PersonneDepot_DAL();
            var listprix = depot.GetAllByIDSoiree(1);

            Assert.NotNull(listprix);

            foreach (var prix in listprix)
            {
                Assert.Equal(1, prix.IDSoiree);
            }
        }

        [Fact]
        public void PrixDepot_DAL_TesterInsertUpdateDelete()
        {
            var depot = new PrixDepot_DAL();
            var prix = new Prix_DAL(montant:14,1,1);
            depot.Insert(prix);

            Assert.NotNull(prix);
            Assert.Equal(14, prix.Montant);
            Assert.Equal(1, prix.IDPersonne);
            Assert.Equal(1, prix.IDSoiree);
            

            prix.Montant = 17;
            depot.Update(prix);

            Assert.NotNull(prix);
            Assert.Equal(17, prix.Montant);

            depot.Delete(prix);

            Assert.Null(prix);
        }

        

    }
}
