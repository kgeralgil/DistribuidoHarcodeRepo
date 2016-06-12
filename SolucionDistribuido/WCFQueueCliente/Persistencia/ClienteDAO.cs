using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCFQueueCliente.Dominio;
using System.Messaging;

namespace WCFQueueCliente.Persistencia
{
    public class ClienteDAO
    {


        public Cliente InsertaCola(Cliente cli)
        {
            Cliente cliCreado = null;


            string rutaCola = @".\private$\" + cli.DNI;
            if (!MessageQueue.Exists(rutaCola))
                MessageQueue.Create(rutaCola);
            MessageQueue cola = new MessageQueue(rutaCola);
            Message mensaje = new Message();
            mensaje.Label = "Cliente  DNI : " + cli.NOMBRE;
            mensaje.Body = new Cliente() { DNI = cli.DNI, NOMBRE = cli.NOMBRE };
            cola.Send(mensaje);


            /*Message mensaje2 = new Message();
            mensaje.Label = "Cliente  DNI : " + cli.NOMBRE;
            mensaje2.Body = new Cliente() { DNI = cli.DNI, NOMBRE = cli.NOMBRE };
            cola.Send(mensaje2);*/



            cliCreado = ObtenerCola(cli.DNI);

            return cliCreado;

        }


        public Cliente ObtenerCola(string DNI)
        {
            Cliente objCliente = null;


            string rutaCola = @".\private$\"+ DNI;
            if (MessageQueue.Exists(rutaCola))//Si existe
            {
                //MessageQueue.Create(rutaCola);
                MessageQueue cola = new MessageQueue(rutaCola);
                //*****************************************

                System.Messaging.Message[] messages;
                messages = cola.GetAllMessages();


                System.Messaging.XmlMessageFormatter ClienteFormatter;
                ClienteFormatter = new System.Messaging.XmlMessageFormatter(
                   new Type[] { typeof(Cliente) });

                for (int index = 0; index < messages.Length; index++)
                {

                    messages[index].Formatter = ClienteFormatter;
                    //Console.WriteLine("Asunto: " + messages[index].Label.ToString());*/
                    objCliente = (Cliente)messages[index].Body;


                }
            }


            return objCliente;
        }


        public Cliente EliminarCola(string DNI)
        {
            Cliente objCliente = null;

            System.Messaging.MessageQueue MessageQueue1 = new System.Messaging.MessageQueue();
            MessageQueue1.Path = @".\private$\" + DNI;
            MessageQueue1.Purge();
            System.Messaging.MessageQueue.Delete(@".\private$\" + DNI);


            objCliente = ObtenerCola(DNI);


            return objCliente;
        }

    }
}