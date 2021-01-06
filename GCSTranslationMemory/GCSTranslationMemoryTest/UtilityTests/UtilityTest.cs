using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GCSTranslationMemory;
using System.Linq;



namespace GCSTranslationMemoryTest.UtilityTests
{
    [TestClass]
    class UtilityTest
    {
        private static Random random = new Random();

        [TestMethod]
        public void RandomStringTest()
        {
            string random = Utility.RandomString(20);
            string randomTest = Utility.RandomString(20);

            Assert.AreNotEqual(random, randomTest);
            
        }
    }
}
