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
    public class BeerTests
    {

        Beer data = new Beer { Id = 1, Name = "Heineken", AlcoholByVolume = 5 };
        Beer data2 = new Beer { Id = 2, Name = "Gulddame", AlcoholByVolume = 5.6 };
        Beer data3NameShort = new Beer { Id = 3, Name = "PO", AlcoholByVolume = 7.5 };
        Beer data4NameNull = new Beer { Id = 4, Name = null, AlcoholByVolume = 5.5 };
        Beer data5AlcoholByVolumeMinus = new Beer { Id = 5, Name = "Tiger", AlcoholByVolume = -1 };
        Beer data6AlcoholByVolumeHigh = new Beer { Id = 6, Name = "Tiger Crystal", AlcoholByVolume = 70 };


        [TestMethod()]
        public void ToStringTest()
        {
            string str = data.ToString();
            Assert.AreEqual("1 Heineken 5", str);
        }

        [TestMethod()]
        public void ValidateNameTest()
        {
            data.ValidateName();
            Assert.ThrowsException<ArgumentNullException>(() => data4NameNull.ValidateName());
            Assert.ThrowsException<ArgumentException>(() => data3NameShort.ValidateName());
        }

        [TestMethod()]
        public void ValidateAlcoholByVolumeTest()
        {
            data.ValidateAlcoholByVolume();
            Assert.ThrowsException<ArgumentException>(() => data5AlcoholByVolumeMinus.ValidateAlcoholByVolume());
            Assert.ThrowsException<ArgumentException>(() => data6AlcoholByVolumeHigh.ValidateAlcoholByVolume());
        }

        [TestMethod()]
        public void ValidateTest()
        {
            Assert.ThrowsException<ArgumentNullException>(() => data4NameNull.Validate());
            Assert.ThrowsException<ArgumentException>(() => data3NameShort.Validate());
            Assert.ThrowsException<ArgumentException>(() => data5AlcoholByVolumeMinus.Validate());
            Assert.ThrowsException<ArgumentException>(() => data6AlcoholByVolumeHigh.Validate());
        }
    }
}