using System;
using System.Net;
using System.IO;

namespace ScrapeLibrary
{
    public class Scrape
    {
        WebClient client;

        public Scrape()
        {
            client = new WebClient();
        }

        public string ScrapeWebPage(string url)
        {
            return getWebPage(url);
        }

        public string ScrapeWebPageToFile(string url, string filePath)
        {
            string response = getWebPage(url);
            File.WriteAllText(filePath, response);
            return response;
        }

        public void ScrapeWebPageToConsole(string url)
        {
            Console.WriteLine(getWebPage(url));
        }

        private string getWebPage(string url)
        {
            return client.DownloadString(url);
        }
    }
}
