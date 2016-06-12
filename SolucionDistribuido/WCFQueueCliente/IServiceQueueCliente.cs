using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCFQueueCliente.Dominio;

namespace WCFQueueCliente
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceQueueCliente" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceQueueCliente
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "ClienteIn", ResponseFormat = WebMessageFormat.Json)]
        Cliente InsertarCola(Cliente CliCola);


        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Cliente/{DNI}", ResponseFormat = WebMessageFormat.Json)]
        Cliente ObtenerClienteQueue(string DNI);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "EliminarCola/{DNI}", ResponseFormat = WebMessageFormat.Json)]
        Cliente EliminarCola(string DNI);
    }
}
