using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devices_Generator
{
    public class Receiver : Device
    {
        private new ReceiverType Type { get; set; }
        public Receiver(string id, string name, string macAddress, ReceiverType type)
        {
            this.Id = id;
            this.Name = name;
            this.MacAddress = macAddress;
            this.Type = type;
        }

    }

    public enum ReceiverType
    {
        LedDevice,
        BeeperDevice
    }
}
