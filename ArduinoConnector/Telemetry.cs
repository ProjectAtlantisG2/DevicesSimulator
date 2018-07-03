using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoConnector
{
    [DataContract]
    public class Telemetry
    {
        [DataMember]
        private string metricDate { get; set; }
        [DataMember]
        private string deviceType { get; set; }
        [DataMember]
        private string metricValue { get; set; }
        
        public Telemetry(string metricDate = null, DeviceType? deviceType = null, string metricValue = null)
        {
            if (metricDate != null) this.metricDate = metricDate;
            if (deviceType != null) this.deviceType = deviceType.ToString();
            this.metricValue = metricValue;
        }
    }

    public enum DeviceType
    {
        presenceSensor,
        temperatureSensor,
        brightnessSensor,
        atmosphericPressureSensor,
        humiditySensor,
        soundLevelSensor,
        gpsSensor,
        co2Sensor,
        ledDevice,
        beeperDevice
    }
}
