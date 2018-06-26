using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devices_Generator
{
    public class Sensor : Device
    {
        private new SensorType Type { get; set; }
        public Sensor(string id, string name, string macAddress, SensorType type)
        {
            this.Id = id;
            this.Name = name;
            this.MacAddress = macAddress;
            this.Type = type;
        }
    }

    public enum SensorType
    {
        PresenceSensor,
        TemperatureSensor,
        LightSensor,
        PressureSensor,
        HumiditySensor,
        SoundSensor,
        GpsSensor,
        Co2Sensor
    }
}
