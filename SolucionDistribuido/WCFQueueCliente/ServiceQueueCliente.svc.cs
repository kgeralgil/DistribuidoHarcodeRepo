using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCFQueueCliente.Dominio;
using WCFQueueCliente.Persistencia;

namespace WCFQueueCliente
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceQueueCliente" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceQueueCliente.svc o ServiceQueueCliente.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceQueueCliente : IServiceQueueCliente
    {

        private ClienteDAO cliDao = new ClienteDAO();
        public Cliente InsertarCola(Cliente CliCola)
        {


            Cliente resultado = cliDao.InsertaCola(CliCola);
            if (resultado == null)
            {

                throw new WebFaultException<string>("No se inserto Cliente a la Cola", HttpStatusCode.InternalServerError);
            }
            else
            {
                return resultado;
            }
        }





        public Cliente ObtenerClienteQueue(string DNI)
        {
            Cliente resultado = null;
            resultado = cliDao.ObtenerCola(DNI);
            if (resultado != null)
            {
                return resultado;
            }
            else
            {
                throw new WebFaultException<string>("No se encontraron Datos", HttpStatusCode.NotFound);
            }
        }


        public Cliente EliminarCola(string DNI)
        {
            Cliente resultado = null;
            resultado = cliDao.EliminarCola(DNI);
            
            return resultado;
        }
    }
}
