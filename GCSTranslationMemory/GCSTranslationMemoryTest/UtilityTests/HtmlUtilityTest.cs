using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GCSTranslationMemory;
using System.Net;

namespace GCSTranslationMemoryTest.UtilityTests
{
    [TestClass]
    public class HtmlUtilityTest
    {
        [TestMethod]
        public void GetHtmlTest()
        {
            // recreating the function
            string GetHtmlTestFunc(string urlAddress)
            {
                string html;
                using (WebClient client = new WebClient())
                {
                    html = client.DownloadString(urlAddress);
                    byte[] bytes = Encoding.Default.GetBytes(html);
                    html = Encoding.UTF8.GetString(bytes);
                }
                return html;
            }
            // checks if it is correctly getting the html from a page
            Assert.AreEqual(GetHtmlTestFunc("http://corndog.io/"), HtmlUtility.GetHtml("http://corndog.io//"));

        }
        [TestMethod]
        public void GetParagraphsTest()
        {
            //checks if when receiving html with at least one paragraph tag in it, that paragraph is added to the list
            Assert.IsTrue(HtmlUtility.GetParagraphs("<p> abc </p>").Count == 1);

            //checks if when receiving html with no paragraphs the list is empty
            Assert.IsTrue(HtmlUtility.GetParagraphs(" Sample text ").Count == 0);
        }

        [TestMethod]
        public void StripHTMLTest()
        {
            // checks if 
            string input = "<p>abc</p>";
            string stripped = "abc";
            input = HtmlUtility.StripHTML(input);
            Assert.AreEqual(stripped,input );
        }
    }
}
