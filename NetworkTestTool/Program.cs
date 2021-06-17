using System;
using System.IO;
using System.Linq;
using System.Net;

namespace NetworkTestTool
{
    class Program
    {
        static void Main(string[] args)
         {
            try
            {
                Console.WriteLine("Domain name :  "+Environment.UserDomainName);
                Console.Write("User name : ");
                var userName = Console.ReadLine();
                Console.Write("Password : ");
                var pass = Console.ReadLine();
                Console.Write(@"Enter Shared Network Host to Connect : (sample = \\fsr3403)");
                var hostName = Console.ReadLine();
                Console.Write(@"Enter Serch Folder : (sample = \\fsr3403\Shared\CorporateFiles)");
                var sharedFolders = Console.ReadLine();

                NetworkCredential credential = new NetworkCredential()
                {
                    Domain = Environment.UserDomainName,
                    UserName = userName,
                    Password = pass,
                };

                Console.WriteLine("Connecting... ");
                Console.WriteLine("With Cridentials => Domaim : " + credential.Domain + " Username : " + credential.UserName + "  Password : " + pass);
                Console.WriteLine("Network Path : " + hostName);
                using (new NetworkConnection(hostName, credential))
                {
                    Console.WriteLine("Connection succed!");
                    Console.WriteLine(".log files searching.");
                    var files2 = Directory.EnumerateFiles(sharedFolders)
                    .Where(s => s.EndsWith(".log"));

                    Console.WriteLine("Found .log files count : " + files2.Count());

                    foreach (var item in files2)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occured : " + ex);
            }

            Console.WriteLine("Press enter to exit!");
            Console.ReadLine();
        }
    }
}
