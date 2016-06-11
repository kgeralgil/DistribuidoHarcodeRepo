using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Reflection;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using WpfApplication3.AREAS.CLASES_Y_UTILIDADES;

namespace WpfApplication3.AREAS.CEDICSEM
{
    public partial class CEDICSEM : UserControl
    {
        
        public static bool reload = false;
        public CEDICSEM()
        {
            InitializeComponent();
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
           
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            
        }




        private void IconButtonContractuales_Click(object sender, RoutedEventArgs e)
        {

           
            //traeInfoDatosContractuales(variablebusqueda);
        }


        private void tbx_observacion_TextChanged(object sender, TextChangedEventArgs e)
        {

        

        }
        void traeInfoDatosContractuales(string busqueda)
        {
            
        }

        void traeInfoDatosPersonales(string busqueda)
        {
            
        }
        private void IconButtondatos_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HttpWebRequest req2 = (HttpWebRequest)WebRequest
                  .Create("http://localhost:9805/Bitacora.svc/Bitacoras/"+TxtDocumento.Text);
                req2.Method = "GET";
                HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
                StreamReader reader2 = new StreamReader(res2.GetResponseStream());
                string clienteJson3 = reader2.ReadToEnd();
                JavaScriptSerializer js3 = new JavaScriptSerializer();
               /*Actualiza la lista de bitacora de llamadas*/
                List<Bitacoras> clienteObtenido = js3.Deserialize<List<Bitacoras>>(clienteJson3);
                /*WCF:  Actualiza datos del cliente*/

                ClienteWS.ServiceClienteClient proxy = new ClienteWS.ServiceClienteClient();
                ClienteWS.Cliente_SQL clienteCreado = proxy.obtenerCliente(TxtDocumento.Text);

                grdhistorias.ItemsSource = clienteObtenido;
                TxtCelular.Text = clienteCreado.CELULAR;
                TxtTelefono1.Text = clienteCreado.TELEFONO1;
                TxtTelefono2.Text = clienteCreado.TELEFONO2;
                txtEmpresa.Text = clienteCreado.EMPRESA;
                txtVigencia.Text = clienteCreado.INICIOVIGENCIA;
                txtmotivo.Text = clienteCreado.MOTIVO;
                txtNombre.Text = clienteCreado.TITULAR;
                txtNombreAsesor.Text = clienteCreado.NOMBREASESOR;
                txtNCuota.Text = clienteCreado.NROCUOTA;
                txtNcontrato.Text = clienteCreado.CONTRATO;
                TxtDocumento.Text = clienteCreado.NRODOCUMENTOIDENTIDAD;
                TxtEmail.Text = clienteCreado.EMAIL;
                txtFpago.Text = clienteCreado.FORMADEPAGO;
                txtCodigoAsesor.Text = clienteCreado.CODIGOASESOR;
                txtSecuencia.Text= clienteCreado.SECUENCIACONTRATO;
                txtAporte.Text= clienteCreado.APORTE;
                txtAsignadoA.Text= clienteCreado.APORTESINIGV;
                
            }
            catch (WebException ex)
            {
                HttpStatusCode code = ((HttpWebResponse)ex.Response).StatusCode;
                string message = ((HttpWebResponse)ex.Response).StatusDescription;
                StreamReader reader = new StreamReader(ex.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(error);
                MessageBox.Show(mensaje);
            }
                

        }

        private void cmbnivel1_Loaded(object sender, RoutedEventArgs e)
        {
           
        }
        private void cmbnivel1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
         

        }

        private void cmbnivel2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

           
            
        }

        private void btnGuardar_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            
        }

        private void btnVerContratos_Click(object sender, RoutedEventArgs e)
        {
            VerContrato aboutWindow = new VerContrato(TxtDocumento.Text);
            aboutWindow.Show();

        }

        private void btnVerCliente_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}

