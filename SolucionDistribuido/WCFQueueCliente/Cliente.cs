using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFQueueCliente.Dominio
{
    [DataContract]
    public class Cliente
    {

        [DataMember]
        public string DNI { get; set; }

        [DataMember]
        public string NOMBRE { get; set; }


    }
}