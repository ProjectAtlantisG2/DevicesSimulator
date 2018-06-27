using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace GatewayService
{
    [DataContract]
    public class Command
    {
        [DataMember]
        public string Value { get; set; }
    }
}