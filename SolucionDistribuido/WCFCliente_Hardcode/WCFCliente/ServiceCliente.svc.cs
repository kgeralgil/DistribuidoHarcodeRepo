using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFCliente.Dominio;
using WCFCliente.Persistencia;

namespace WCFCliente
{
    //REFERENCIAS LLAMADAS POR WALTER CAHUANA
    public class ServiceCliente : IServiceCliente
    {
        private ClienteDAO clienteDAO = new ClienteDAO();
      
        public Dominio.Cliente_SQL obtenerCliente(string dni)
        {
            return clienteDAO.obtenerCliente(dni);
        }


        public Dominio.Cliente_SQL insertarCliente(Dominio.Cliente_SQL clienteInsertar)
        {
            return clienteDAO.Crear(clienteInsertar);
        }

        
    }
}
