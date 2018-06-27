using System;
using ArduinoConnector;

namespace GatewayService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service : IService
    {
        public string PostCommand(string command)
        {
            Console.WriteLine(command);
            Program.SendCommandToDevice(command);
            return "done";
        }

        public void PostData()
        {
            throw new NotImplementedException();
        }

        public void PostIdentity()
        {
            throw new NotImplementedException();
        }
    }
}
