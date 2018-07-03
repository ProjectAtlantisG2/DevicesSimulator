using System;
using System.Net.Http;
using System.Net;

namespace GatewayService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service : IService
    {
        /// <summary>
        /// Receive command from the Microsoft Platform
        /// </summary>
        /// <param name="command">Text command to execute</param>
        /// <param name="deviceId">Destination of the command</param>
        /// <returns></returns>
        public HttpResponseMessage PostCommand(string command, string deviceId)
        {
            if (command == null || command == "") return new HttpResponseMessage(HttpStatusCode.MethodNotAllowed);
            //Console.WriteLine("Executed Command"command);
            if (!ArduinoConnector.Program.SendCommandToDevice(command)) return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        

        public void PostIdentity()
        {
            throw new NotImplementedException();
        }
    }
}
