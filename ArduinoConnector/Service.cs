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

        private static void PostData(string telemetry, string id)
        {
            if(telemetry != null && id != null)
                client.PostAsync(deviceEndpointUri + id + "PostData", new StringContent(telemetry, Encoding.UTF8, "application/json"));
        }

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
                    tel = new Telemetry(DateTime.Now, DeviceType.atmosphericPressureSensor, text.Remove(0, 1));
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
