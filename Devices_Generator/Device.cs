using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devices_Generator
{
    public abstract class Device
    {
        protected string Id { get; set; }

        protected string Name { get; set; }

        protected string MacAddress { get; set; }

        protected string Type { get; set; }

    }

}
