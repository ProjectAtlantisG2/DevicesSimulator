using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ArduinoConnector
{
    public class Service
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string deviceEndpointUri = ConfigurationManager.AppSettings["DeviceEndpointUri"];
        /// <summary>
        /// Send data to the Device API of the Microsoft Platform
        /// </summary>
        /// <param name="telemetry">Metric that has to be sent</param>
        /// <param name="id">Id of the Sending Device</param>
        private static void PostData(string telemetry, string deviceId)
        {
            if(telemetry != null && deviceId != null)
                client.PostAsync(deviceEndpointUri + deviceId + "/telemetry", new StringContent(telemetry, Encoding.UTF8, "application/json"));
        }

        /// <summary>
        /// Process the data receive from the Arduino to make it clean to send to the Microsoft Platform
        /// </summary>
        /// <param name="data">Data that have been receive from the Arduino</param>
        public static void ProcessData(string data)
        {
            try
            {
                if (data == null) return;
                Telemetry tel = null;
                var text = data.Remove(data.Length - 2, 2);
                var id = "";
                if (data.Remove(1, data.Length - 1) == "T")
                {
                    tel = new Telemetry(DateTime.Now, DeviceType.temperatureSensor, text.Remove(0, 1));
                    id = "00:00:00:00:00";
                }
                else
                {
                    tel = new Telemetry(DateTime.Now, DeviceType.humiditySensor, text.Remove(0, 1));
                    id = "11:11:11:11:11";
                }

                var serializedResult = Newtonsoft.Json.JsonConvert.SerializeObject(tel);

                PostData(serializedResult, id);
            }catch{}
        }
    }
}
