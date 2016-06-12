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
        Clientes oUsr = new Clientes();
        List<items> ListaSeleccion = new List<items>();
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
            string variablebusqueda = string.Empty;
            if (!string.IsNullOrEmpty(txtNombre.Text))
            {
                variablebusqueda += " and TITULAR like '%" + txtNombre.Text + "%'";
            }
            if (!string.IsNullOrEmpty(TxtDocumento.Text))
            {
                variablebusqueda += " and NRODOCUMENTOIDENTIDAD = '" + TxtDocumento.Text + "'";
            }
           
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
                txtAporte.Text = 
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
            cmbnivel1.ItemsSource = oUsr.CEDICSEM_LIST_NIVEL1().DefaultView;
            cmbnivel1.DisplayMemberPath = "descripcion";
            cmbnivel1.SelectedValuePath = "codigo";
            cmbnivel1.SelectedIndex = 0;
            cmbnivel2.ItemsSource = null;
            //cmbnivel3.ItemsSource = null;
            cmbnivel2.SelectedIndex = 0;
            //cmbnivel3.SelectedIndex = 0;
           
        }
        private void cmbnivel1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbnivel2.ItemsSource = null;
            //cmbnivel3.ItemsSource = null;
            if (oUsr.CEDICSEM_LIST_NIVEL2(cmbnivel1.SelectedValue.ToString()) != null)
                cmbnivel2.ItemsSource = oUsr.CEDICSEM_LIST_NIVEL2(cmbnivel1.SelectedValue.ToString()).DefaultView;

            cmbnivel2.DisplayMemberPath = "descripcion";
            cmbnivel2.SelectedValuePath = "codigo";
            cmbnivel2.SelectedIndex = 0;
            //cmbnivel3.SelectedIndex = 0;

        }

        private void cmbnivel2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbnivel2.SelectedValue != null)
            {



                lblobservaciones.Text = null;
                //cmbnivel3.ItemsSource = null;
                if (oUsr.CEDICSEM_LIST_NIVEL3(cmbnivel2.SelectedValue.ToString()) != null)
                {
                    DataTable data = oUsr.CEDICSEM_LIST_NIVEL3(cmbnivel2.SelectedValue.ToString());
                    if (data.Rows.Count > 0)
                    {
                        lblobservaciones.Text = data.Rows[0][1].ToString();
                    }
                    else
                    {

                        lblobservaciones.Text = null;

                    }
                }

            }
           
            
        }

        private void btnGuardar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Clientes oUsr = new Clientes();
            //Asignamos los valores correspondientes al objeto que hemos creado

            oUsr.txtNombre = txtNombre.Text;
            oUsr.TxtTelefono1 = TxtTelefono1.Text;
            oUsr.TxtTelefono2 = TxtTelefono2.Text;
            oUsr.TxtCelular = TxtCelular.Text;
            oUsr.TxtEmail = TxtEmail.Text;

            oUsr.TxtDocumento = TxtDocumento.Text;
            oUsr.txtNcontrato = txtNcontrato.Text;
            oUsr.txtVigencia = txtVigencia.Text;
            oUsr.txtCategorizacion = txtCategorizacion.Text;
            oUsr.txtNombre = txtNombre.Text;
            oUsr.txtAsignado = txtAsignadoA.Text;
            
            oUsr.txtNCuota = txtNCuota.Text;
            oUsr.txtEstadoCuota = txtEstadoCuota.Text;
            oUsr.txtFechaEmision = txtFechaEmision.Text;
            oUsr.txtFechaVencimiento = txtFechaVencimiento.Text;
            oUsr.txtBanco = txtBanco.Text;
            oUsr.txtAporte = txtAporte.Text;
           
            oUsr.txtFpago = txtFpago.Text;
            oUsr.txtdescuento = txtdescuento.Text;
            oUsr.txtEmpresa = txtEmpresa.Text;
            oUsr.txtcargo = txtcargo.Text;
            
            oUsr.txtCodigoAsesor = txtCodigoAsesor.Text;
            oUsr.txtNombreAsesor = txtNombreAsesor.Text;
            oUsr.txtPreexistencias = txtPreexistencias.Text;
            oUsr.txtRenovacion = txtRenovacion.Text;
            oUsr.cmbnivel2 = cmbnivel2.Text;
            oUsr.cmbnivel1 = cmbnivel1.Text;
            oUsr.FechaAccion = FechaAccion.SelectedDate.ToString();


            oUsr.GEN_EstadoTipificacion = "TIPIFICADA";

            string Motivos = "";
            foreach (items point in ListaSeleccion)
            {
                if (point == ListaSeleccion.Last())
                {
                    Motivos += point.NOMBRE + "";
                }
                else
                {
                    Motivos += point.NOMBRE + ",";
                }
            }
            oUsr.Motivo = Motivos;
            oUsr.Observaciones = txtmotivo.Text;

            if (oUsr.CEDICSEM_INSERTA_CLIENTE())
            {
                if (oUsr.CEDICSEM_INSERTA_TIPIFICACIONES())
                {

                    


                }


            }
            grdhistorias.ItemsSource = oUsr.CEDICSEM_HISTORIAL().DefaultView;
            //grdhistorias.Columns[0].Visibility = Visibility.Collapsed;
            
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

