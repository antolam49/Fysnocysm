using ProjetSymfoCS.DAL;
using System;
using Xunit;

namespace ProjetSymfoCS_DAL_Tests
{
    public class SoireeDepot_DAL_Tests
    {
        [Fact]
        public void SoireeDepot_DAL_TesterGetAll()
        {
            var depot = new SoireeDepot_DAL();
            var Soiree = depot.GetAll();

            Assert.NotNull(Soiree);
        }

        [Fact]
        public void SoireeDepot_DAL_TesterGetByID()
        {
            var depot = new SoireeDepot_DAL();
            var Soiree = depot.GetByID(1);

            Assert.NotNull(Soiree);
            Assert.Equal(1, Soiree.ID);
            Assert.NotEmpty(Soiree.Lieu);
            
        }

        [Fact]
        public void SoireeDepot_DAL_TesterGetAllByID()
        {
            var depot = new SoireeDepot_DAL();
            var listSoiree = depot.GetAllByID(1);

            Assert.NotNull(listSoiree);

            foreach (var Soiree in listSoiree)
            {
                Assert.Equal(1, Soiree.ID);
            }
        }

        [Fact]
        public void SoireeDepot_DAL_TesterInsertUpdateDelete()
        {
            var depot = new SoireeDepot_DAL();
            var Soiree = new Soiree_DAL(1,"Test",DateTime.Now);
            depot.Insert(Soiree);
            var SoireeB = depot.GetByID(Soiree.ID);

            Assert.NotNull(SoireeB);
            Assert.Equal(DateTime.Now, SoireeB.Date);
            Assert.Equal("Test", SoireeB.Lieu);

            Soiree.Lieu = "SecondTest";
            depot.Update(Soiree);
            SoireeB = depot.GetByID(Soiree.ID);

            Assert.NotNull(SoireeB);
            Assert.Equal("SecondTest", SoireeB.Lieu);

            depot.Delete(Soiree);
            try
            {
                SoireeB = depot.GetByID(Soiree.ID);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           
        }

        

    }
}
