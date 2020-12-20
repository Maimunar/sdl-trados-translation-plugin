using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using System.Net;
using GCSTranslationMemory;

namespace GCSTranslationMemoryTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void WebRequestTest()
        {
            HttpWebRequest webRequestTest = (HttpWebRequest)WebRequest.Create(@"https://eur-lex.europa.eu/EURLexWebService");
            webRequestTest.Headers.Add(@"SOAP:Action");
            webRequestTest.ContentType = "application/soap+xml;charset=\"utf-8\"";
            webRequestTest.Accept = "application/soap+xml";
            webRequestTest.Method = "POST";
            webRequestTest.MediaType = "application/soap+xml;charset=\"utf-8\"";

            HttpWebRequest request = SOAPRequestHandler.CreateWebRequest();

            Assert.AreEqual(request.ToString(), webRequestTest.ToString());
        }

        [TestMethod]
        public void LoadCELEXTest()
        {
            XmlNodeList SOAPReqList = SOAPRequestHandler.Execute(2020, 1598);
            Assert.AreEqual("32020D1598", SOAPReqList[0].InnerText);
        }
    }
}