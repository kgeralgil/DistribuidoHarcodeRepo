using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Text;
using System.IO;
using System.Web.Script.Serialization;

namespace RESTqueueTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InsertarCola()
        {

            try
            {
                string postData = "{\"DNI\":\"12345678\",\"NOMBRE\":\"PEPE\"}"; //JSON

                byte[] data = Encoding.UTF8.GetBytes(postData);
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:28121/ServiceQueueCliente.svc/ClienteIn");

                req.Method = "POST";
                req.ContentLength = data.Length;
                req.ContentType = "application/json";

                var reqStream = req.GetRequestStream();
                reqStream.Write(data, 0, data.Length);

                var res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string bitacoraJson = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();

                Cliente coaCreada = js.Deserialize<Cliente>(bitacoraJson);
                Assert.AreEqual("22334455", coaCreada.DNI);
            }
            catch (WebException e)
            {
                HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                string message = ((HttpWebResponse)e.Response).StatusDescription;
                StreamReader reader = new StreamReader(e.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(error);
                Assert.AreEqual("No se inserto Cliente a la Cola", mensaje);
            }


        }




        [TestMethod]
        public void ObtenerCola()
        {
            
            try
            {
            HttpWebRequest req2 = (HttpWebRequest)WebRequest
              .Create("http://localhost:28121/ServiceQueueCliente.svc/Cliente/212");
            req2.Method = "GET";
            HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
            StreamReader reader2 = new StreamReader(res2.GetResponseStream());
            string clienteJson3 = reader2.ReadToEnd();
            JavaScriptSerializer js3 = new JavaScriptSerializer();
            Cliente clienteObtenido = js3.Deserialize<Cliente>(clienteJson3);
            Assert.AreEqual("212", clienteObtenido.DNI);
            }
            catch (WebException e)
            {
                HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                string message = ((HttpWebResponse)e.Response).StatusDescription;
                StreamReader reader = new StreamReader(e.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(error);
                Assert.AreEqual("No se encontraron Datos", mensaje);
            }                     



        }


        [TestMethod]
        public void EliminarCola()
        {

                HttpWebRequest req2 = (HttpWebRequest)WebRequest
                  .Create("http://localhost:28121/ServiceQueueCliente.svc/EliminarCola/12345678");
                req2.Method = "DELETE";
                HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
                StreamReader reader2 = new StreamReader(res2.GetResponseStream());
                string clienteJson3 = reader2.ReadToEnd();
                JavaScriptSerializer js3 = new JavaScriptSerializer();
                Cliente clienteObtenido = js3.Deserialize<Cliente>(clienteJson3);
                Assert.AreEqual(clienteObtenido, null);
         



        }


    }
}
