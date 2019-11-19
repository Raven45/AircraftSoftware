using Microsoft.Security.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Aircraft.Service
{
    [DataContract]
    public class AircraftView
    {
        [DataMember]
        internal int ID { get; set; }

        [DataMember]
        internal string Model { get; set; }

        [DataMember]
        internal string SerialNumber { get; set; }
    }
}