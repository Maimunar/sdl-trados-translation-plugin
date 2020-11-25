using System;
using System.Xml;
using System.Net;
using System.IO;

namespace GCSTranslationMemory
{
    public class SOAPRequestHandler
    {
        /// <summary>
        /// Create a soap webrequest to [Url]
        /// </summary>
        /// <returns></returns>
        public HttpWebRequest CreateWebRequest()
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@"https://eur-lex.europa.eu/EURLexWebService");
            webRequest.Headers.Add(@"SOAP:Action");
            webRequest.ContentType = "application/soap+xml;charset=\"utf-8\"";
            webRequest.Accept = "application/soap+xml";
            webRequest.Method = "POST";
            webRequest.MediaType = "application/soap+xml;charset=\"utf-8\"";
            return webRequest;
        }

        /// <summary>
        /// Create a empty XML document, then load the SOAP query into that document performing that request to the url from the CreateWebRequest() method.
        /// After the request is made to the specified url, the xml response is read into a string variable and that variable is loaded into a new empty xml doc.
        /// Finally, it is looped to get all items with the specific tag "ID_CELEX" from it, then returned to the main function.
        /// </summary>
        /// <param name="docYear"></param>
        /// <param name="docNumber"></param>
        public XmlNodeList Execute(int docYear,int docNumber)
        {
            HttpWebRequest request = CreateWebRequest();
            XmlDocument soapEnvelopeXml = new XmlDocument();
            soapEnvelopeXml.LoadXml($@"<?xml version=""1.0"" encoding=""utf-8""?>
            <soap:Envelope xmlns:soap=""http://www.w3.org/2003/05/soap-envelope"" xmlns:sear=""http://eur-lex.europa.eu/search"">
	        <soap:Header>
		        <wsse:Security xmlns:wsse=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"" soap:mustUnderstand= ""true"">
			        <wsse:UsernameToken xmlns:wsu=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"" wsu:Id= ""UsernameToken -1"">
                        <wsse:Username>n0057izu</wsse:Username>
				        <wsse:Password Type= ""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText"">dKtGt7JWj4g</wsse:Password>
                    </wsse:UsernameToken>
		        </wsse:Security>
	        </soap:Header>
	        <soap:Body>
		        <sear:searchRequest>
			        <sear:expertQuery><![CDATA[(DTA = { docYear } AND DTN = { docNumber } ) AND FM_CODED = DIR  AND VV = TRUE]]></sear:expertQuery>
                    <sear:page>1</sear:page>
			        <sear:pageSize>100</sear:pageSize>
			        <sear:searchLanguage>en</sear:searchLanguage>
		        </sear:searchRequest>
	        </soap:Body>
        </soap:Envelope>");

            using (Stream stream = request.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                {
                    string soapResult = rd.ReadToEnd();
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(soapResult);
                    XmlNodeList address = xmlDoc.GetElementsByTagName("ID_CELEX");

                    return address;

                }
            }
        }
    }
}

