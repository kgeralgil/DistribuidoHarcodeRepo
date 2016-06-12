using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFCliente.Dominio;

namespace WCFCliente
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceCliente" in both code and config file together.
    [ServiceContract]
    public interface IServiceCliente
    {
        [OperationContract]
        Cliente_SQL obtenerCliente(string dni);

        [OperationContract]
        Cliente_SQL insertarCliente(Cliente_SQL clienteInsertar);
        
    }
}
