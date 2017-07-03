
using System.Net.Mail;
using System;

namespace References
{
    class Program
    {
        static void Main(string[] args)
        {
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
            } catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Email failed to send :(. Please check logs for errors");
            }

            Console.WriteLine("Hit<Enter> or Ctrl - C to exit.");
            Console.ReadLine();
        }
    }
}
