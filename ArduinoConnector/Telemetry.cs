using System;
using System.Collections.Generic;
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
        private DateTime metricDate { get; set; }
        [DataMember]
        private DeviceType deviceType { get; set; }
        [DataMember]
        private string metricValue { get; set; }
        
        public Telemetry(DateTime? metricDate = null, DeviceType? deviceType = null, string metricValue = null)
        {
            if(metricDate!=null) this.metricDate = (DateTime)metricDate;
            if (deviceType != null) this.deviceType = (DeviceType)deviceType;
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
