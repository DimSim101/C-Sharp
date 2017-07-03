using System;
using System.Net.Mail;
using ScrapeLibrary;

namespace ScrapeClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // Example with my own Class Library reference assembly - Within same project.
            // This means when you add reference, its within the project tab already instead of manually browsing for it!
            // Solution Explorer -> References -> Add Reference -> Project Tab -> Tick assembly dll -> Win.

            string kingdavidUrl = "https://kingdavid.xyz";
            string beautyUrl = "https://beautyandtheast.com";
            string separator = new string('-', 50) + "\n";

            Scrape scraper = new Scrape();
            scraper.ScrapeWebPageToConsole(kingdavidUrl);

            Console.WriteLine(separator);

            string kingdavidContent = scraper.ScrapeWebPage(kingdavidUrl);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("KING DAVID CONSOLE...");
            Console.WriteLine(kingdavidContent);

            Console.WriteLine(separator);

            string beautyPageContent = scraper.ScrapeWebPage(beautyUrl);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("BEAUTY AND THE EAST STANDARD...");
            Console.WriteLine(beautyPageContent);

            Console.WriteLine(separator);

            string kingdavidContentFile = scraper.ScrapeWebPageToFile(kingdavidUrl, "/Users/Administrator/Documents/Visual Studio 2017/Projects/C#/Fundamentals-of-C#/ReferencesAndClassesTogether/kingdavid.txt");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("KING DAVID FILE...");
            Console.WriteLine(kingdavidContentFile);

            Console.WriteLine(separator);


            //-------------------------------------------------------------------------------------------------------------------

            // Example with some default reference assembly i.e. System.Net

            // We had to add the System.Net framework before we can make calls to it - i.e. create an email message
            // Right click References in Solution Explorer -> Add Reference -> Tick System.Net -> System.Net should appear in Solution Explorer / be available now.

            MailMessage email = new MailMessage();
            email.From = new MailAddress("dsaCoinCheck@gmail.com");
            email.To.Add(new MailAddress("dsaaron123@gmail.com"));

            email.Subject = "Test Email C# Fundamentals";
            email.Body = "Test Email from C# Fundamentals course! Checking Reference to System.Net is working :)";

            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.gmail.com";
            client.Credentials = new System.Net.NetworkCredential("dsaCoinCheck@gmail.com", @"c01/\/Check2017!");

            try
            {
                Console.WriteLine("Sending email now...");
                client.Send(email);
                Console.WriteLine("Email sent!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Email failed to send :(. Please check logs for errors");
            }

            Console.WriteLine("Hit<Enter> or Ctrl - C to exit.");
            Console.ReadLine();
        }
    }
}
