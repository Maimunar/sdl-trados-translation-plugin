using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace GCSTranslationMemory
{
    // A utility class that provides html-based methods
    public static class HtmlUtility
    {
        // Takes an URL address and retrieves its html
        // The HTML is then encoded to UTF-8 to support more characters
        public static string GetHtml(string urlAddress)
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

        // Takes a celex number and a language and retrieves the requested document from the eur-lex webservice
        // Method mostly used to provide the template of the eur-lex websirvice's url
        public static string GetHTMLEurLex(string celex, string language)
        {
            return GetHtml($"https://eur-lex.europa.eu/legal-content/{language}/TXT/HTML/?uri=CELEX:{celex}");
        }

        // Extracts all paragraphs from given html code
        // Returns a list of the paragraphs' content, stripped of html tags
        public static List<string> GetParagraphs(string htmlCode)
        {
            List<string> paragraphs = new List<string>();
            // The regex deals with the<p> tags and the StripHTML method clears any other found tags
            // within that paragraph. 
            foreach (Match m in Regex.Matches(htmlCode, @"(?<=<p[^>]*>)\s*(.*?)\s*(?=<\/p>)"))
                paragraphs.Add(StripHTML(m.Value));
            return paragraphs;
        }

        // Receives an html input and strips it of any html tags it finds
        public static string StripHTML(string input) => Regex.Replace(input, "<.*?>", String.Empty);
    }
}
