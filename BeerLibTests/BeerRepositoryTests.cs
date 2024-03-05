using Microsoft.VisualStudio.TestTools.UnitTesting;
using BeerLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerLib.Tests
{
    [TestClass()]
    public class BeerRepositoryTests
    {

        BeerRepository beerRepository = new BeerRepository();
        Beer data = new Beer { Id = 1, Name = "Elefant Øl", AlcoholByVolume = 8 };


        [TestMethod()]
        public void GetBeerTest()
        {
            var beers = beerRepository.GetBeer();
            Assert.AreEqual(5, beers.Count);

            var beersWithC = beerRepository.GetBeer("C");
            Assert.AreEqual(1, beersWithC.Count);

            var beersNameSorted = beerRepository.GetBeer(sortby: "Name");
            Assert.AreEqual("Blanc", beersNameSorted[0].Name);

            var beersNameSortedDesc = beerRepository.GetBeer(sortby: "Name_desc");
            Assert.AreEqual("Snake Venom", beersNameSortedDesc[0].Name);

            var beersAlcoholByVolumeSorted = beerRepository.GetBeer(sortby: "AlcoholByVolume");
            Assert.AreEqual(4.5, beersAlcoholByVolumeSorted[0].AlcoholByVolume);

            var beersAlcoholByVolumeSortedDesc = beerRepository.GetBeer(sortby: "AlcoholByVolume_desc");
            Assert.AreEqual(67, beersAlcoholByVolumeSortedDesc[0].AlcoholByVolume);
        }

        [TestMethod()]
        public void AddBeerTest()
        {
            beerRepository.AddBeer(data);
            //var beers = beerRepository.GetBeer();
            List<Beer> beers = beerRepository.GetBeer();
            Assert.AreEqual(6, beers.Count);
        }

        [TestMethod()]
        public void GetBeerByIdTest()
        {
            Beer? b = beerRepository.GetBeerById(1);
            Assert.IsNotNull(b);
            Assert.AreEqual("Corona", b.Name);
        }

        [TestMethod()]
        public void DeleteBeerTest()
        {
            beerRepository.DeleteBeer(1);
            List<Beer> beers = beerRepository.GetBeer();
            Assert.AreEqual(4, beers.Count);
        }

        [TestMethod()]
        public void UpdateBeerTest()
        {
            Beer b = beerRepository.UpdateBeer(1, data);
            Assert.IsNotNull(b);
            Assert.AreEqual("Elefant Øl", b.Name);
            Assert.AreEqual(8, b.AlcoholByVolume);

        }

        [TestMethod()]
        public void ToStringTest()
        {
            string str = beerRepository.ToString();

            Assert.IsTrue(str.Contains("Corona"));
        }
    }
}