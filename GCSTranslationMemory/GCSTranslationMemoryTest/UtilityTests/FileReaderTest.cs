using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GCSTranslationMemory;
using System.Text.RegularExpressions;

namespace GCSTranslationMemoryTest.UtilityTests
{
    [TestClass]
    public class FileReaderTest
    {
        [TestMethod]
        public void HasAYearTest()
        {
            string hasayear = "2015/1535";

            foreach (Match m in Regex.Matches(hasayear, @"([0-9]{1,4} ?[/] ?[0-9]{4}( ?[/] ?[a-zA-Z]{2})?)|([0-9]{4} ?[/] ?[0-9]{1,4}( ?[/] ?[a-zA-Z]{2})?)"));
            //FileReader.Has
            
           
        }
    }
}
