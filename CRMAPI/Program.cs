using CRMAPI.APIService;
using System;

namespace CRMAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Adres serwera udostępniajacego API
             * http://192.168.1.188/hortimex/robocza61/api.php?wsdl
             */

            bs4intranetAPIPortTypeClient client = new bs4intranetAPIPortTypeClient();
            var sessionId = client.login("user", "password");

            GetVersion(client, sessionId);
            SendInstantMessage(client, sessionId);
            GetMailbox(client, sessionId);

            Console.WriteLine("Koniec programu");
            Console.ReadKey();
        }

        private static void GetMailbox(bs4intranetAPIPortTypeClient client, string sessionId)
        {
            /*
             * Funkcja findMailbox nie działa poprawnia. Drugi parametr o nazwie "mailbox" powinien być typem złożonym "Mailbox",
             * a nie stringiem, VisualStudio nie generuje tego poprawnie
             */

            var response = client.findMailbox(sessionId, "???");
        }

        private static void SendInstantMessage(bs4intranetAPIPortTypeClient client, string sessionId)
        {
            var receiverId = 1049;
            var message = "Treść komunikatu testowego";

            var response = client.sendIMToUser(sessionId, receiverId, message, true, "", "");
        }

        private static void GetVersion(bs4intranetAPIPortTypeClient client, string sessionId)
        {
            var result = client.getBs4Version(sessionId);
            Console.WriteLine($"Wersja systemu CRM: {result}");
        }
    }
}
