using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Xml.Linq;
using System.Web;


namespace WpfApplication3.AREAS.CLASES_Y_UTILIDADES
{
    public class Clientes
    {
        public bool RELOAD = false;
        //VARIABLES GENESYS 


        public String GEN_Connid { get; set; }
        public String GEN_Origen { get; set; }
        public String GEN_Destino { get; set; }
        public String GEN_Agente { get; set; }
        public String GEN_TipoInteraccion { get; set; }
        public String GEN_NombreCamp { get; set; }
        public String GEN_EstadoTipificacion { get; set; }
        public String GEN_EstadoInteraccion { get; set; }
        public String GEN_FechaInicioCall { get; set; }
        public String GEN_FechaTerminoCall { get; set; }
        public String GEN_DuracionCall { get; set; }
        public String GEN_canalEntrada { get; set; }
        public String GEN_OpcionIVR { get; set; }



        public String TxtTelefono1 { get; set; }
        public String TxtTelefono2 { get; set; }
        public String TxtCelular { get; set; }
        public String TxtEmail { get; set; }


        //Registros de Campana




        public String cmbnivel3 { get; set; }
        public String cmbnivel2 { get; set; }
        public String cmbnivel1 { get; set; }


        public String lblObservaciones { get; set; }


        // DEMOGRAFICOS
        public String txtNombre { get; set; }
        public String txtNcontrato { get; set; }
        public String TxtDocumento { get; set; }

        public String txtVigencia { get; set; }
        public String txtCategorizacion { get; set; }
        public String txtAsignado { get; set; }
        public String txtTramo { get; set; }
        public String txtNCuota { get; set; }
        public String txtEstadoCuota { get; set; }
        public String txtFechaEmision { get; set; }
        public String txtFechaVencimiento { get; set; }
        public String txtBanco { get; set; }
        public String txtAporte { get; set; }
        public String txtAporteIGV { get; set; }
        public String txtFpago { get; set; }
        public String txtdescuento { get; set; }
        public String txtEmpresa { get; set; }
        public String txtcargo { get; set; }
        public String txtCodigoPlan { get; set; }
        public String txtNombrePlan { get; set; }
        public String txtCodigoAsesor { get; set; }
        public String txtNombreAsesor { get; set; }
        public String txtPreexistencias { get; set; }
        public String txtRenovacion { get; set; }

        // TIPIFICACIONES

        public String Motivo { get; set; }
        public String Observaciones { get; set; }
        public String FechaAccion { get; set; }
        

        //  BUSQUEDAS
        public String dependienteBusqueda { get; set; }
        public String Busqueda { get; set; }



        //inicializacion de variables . Esto ayuda a evitar problemas de null pointer, o referencia a objetos null al momento de convertir variable o llamar a un metodo.
        public Clientes()
        {
            //VARIABLES GENESYS 



            cmbnivel3 = string.Empty;
            cmbnivel2 = string.Empty;
            cmbnivel1 = string.Empty;

            lblObservaciones = string.Empty;



            GEN_Connid = string.Empty;
            GEN_Origen = string.Empty;
            GEN_Destino = string.Empty;
            GEN_Agente = string.Empty;
            GEN_TipoInteraccion = string.Empty;
            GEN_NombreCamp = string.Empty;
            GEN_EstadoTipificacion = string.Empty;
            GEN_EstadoInteraccion = string.Empty;
            GEN_FechaInicioCall = string.Empty;
            GEN_FechaTerminoCall = string.Empty;
            GEN_DuracionCall = string.Empty;
            GEN_canalEntrada = string.Empty;
            GEN_OpcionIVR = string.Empty;


            TxtTelefono1 = string.Empty;
            TxtTelefono2 = string.Empty;
            TxtCelular = string.Empty;
            TxtEmail = string.Empty;


            txtNombre = string.Empty;
            txtNcontrato = string.Empty;
            txtVigencia = string.Empty;
            txtCategorizacion = string.Empty;
            txtAsignado = string.Empty;
            txtTramo = string.Empty;
            txtNCuota = string.Empty;
            txtEstadoCuota = string.Empty;
            txtFechaEmision = string.Empty;
            txtFechaVencimiento = string.Empty;
            txtBanco = string.Empty;
            txtAporte = string.Empty;
            txtAporteIGV = string.Empty;
            txtFpago = string.Empty;
            txtdescuento = string.Empty;
            txtEmpresa = string.Empty;
            txtcargo = string.Empty;
            txtCodigoPlan = string.Empty;
            txtNombrePlan = string.Empty;
            txtCodigoAsesor = string.Empty;
            txtNombreAsesor = string.Empty;
            txtPreexistencias = string.Empty;
            txtRenovacion = string.Empty;
            TxtDocumento = string.Empty;







            // TIPIFICACIONES

            Motivo = string.Empty;
            Observaciones = string.Empty;
            FechaAccion = string.Empty;
            

            //  BUSQUEDAS
            dependienteBusqueda = string.Empty;
            Busqueda = string.Empty;

            //instancia a variables genesys tomadas desde libreria de clases.
            if (Application.Current.Properties.Contains("Connid")) { GEN_Connid = Application.Current.Properties["Connid"].ToString(); } else { GEN_Connid = ""; }
            if (Application.Current.Properties.Contains("origen")) { GEN_Origen = Application.Current.Properties["origen"].ToString(); } else { GEN_Origen = ""; }
            if (Application.Current.Properties.Contains("Agente")) { GEN_Agente = Application.Current.Properties["Agente"].ToString(); } else { GEN_Agente = ""; }
            if (Application.Current.Properties.Contains("Tipo")) { GEN_TipoInteraccion = Application.Current.Properties["Tipo"].ToString(); } else { GEN_TipoInteraccion = ""; }
            if (Application.Current.Properties.Contains("destino")) { GEN_Destino = Application.Current.Properties["destino"].ToString(); } else { GEN_Destino = ""; }
            if (Application.Current.Properties.Contains("EstadoTipificacion")) { GEN_EstadoTipificacion = Application.Current.Properties["EstadoTipificacion"].ToString(); } else { GEN_EstadoTipificacion = ""; }
            if (Application.Current.Properties.Contains("EstadoInteraccion")) { GEN_EstadoInteraccion = Application.Current.Properties["EstadoInteraccion"].ToString(); } else { GEN_EstadoInteraccion = ""; }

            if (Application.Current.Properties["Fecha"] != null) { GEN_FechaInicioCall = Application.Current.Properties["Fecha"].ToString(); } else { GEN_FechaInicioCall = ""; }
            if (Application.Current.Properties["FechaFinal"] != null) { GEN_FechaTerminoCall = Application.Current.Properties["FechaFinal"].ToString(); } else { GEN_FechaTerminoCall = ""; }
            if (Application.Current.Properties["Duracion"] != null) { GEN_DuracionCall = Application.Current.Properties["Duracion"].ToString(); } else { GEN_DuracionCall = ""; }
            if (Application.Current.Properties["CANALIVR"] != null) { GEN_canalEntrada = Application.Current.Properties["CANALIVR"].ToString(); } else { GEN_canalEntrada = ""; }
            if (Application.Current.Properties["OPCION"] != null) { GEN_OpcionIVR = Application.Current.Properties["OPCION"].ToString(); } else { GEN_OpcionIVR = ""; }


        }
        public DataTable CEDICSEM_LIST_EFECTIVIDAD()
        {
            String sql = "";
            DataTable datos;
            sql += "SELECT [CEDICSEM_D_ID],[CEDICSEM_D_DESCRIPCION] FROM [CN_C_EDICSEM].[dbo].[DICCIONARIO_DATOS] WHERE [CEDICSEM_D_TIPO]='EFECTIVIDAD' AND CEDICSEM_D_CLASIFICACION='ITEM'";

            try
            {
                SqlParameter[] parameter = {
               // new SqlParameter("RutCliente",Rut)
                };
                datos = SqlHelper.ExecuteDataTable(sql, parameter);

                //DataRow nuevaFila = datos.NewRow();
                //nuevaFila["MA_D_ID"] = "0";
                //nuevaFila["MA_D_DESCRIPCION"] = "SELECCIONE ESPECIFICACIÓN...";
                //datos.Rows.Add(nuevaFila);

                return datos;
            }
            catch (Exception error)
            {

                // Extract some information from this exception, and then 
                // throw it to the parent method.
                if (error.Source != null)
                    Console.WriteLine("IOException source: {0}", error.Source);
                return null;
                throw;

            }
        }
        //Metodo genérico que trae todos los subitems de un item determinado, segun el id de dependencia ( padre) en las tipificaciones
        public DataTable CEDICSEM_TRAE_DEPENDENCIAS(string dependencia = null)
        {
            String sql = "";
            DataTable datos;
            sql += "SELECT [CEDICSEM_D_ID],[CEDICSEM_D_DESCRIPCION] FROM [CN_C_EDICSEM].[dbo].[DICCIONARIO_DATOS] WHERE CEDICSEM_D_DEPENDIENTE='" + dependencia + "'";

            try
            {
                SqlParameter[] parameter = {
                   // new SqlParameter("RutCliente",Rut)
                    };
                datos = SqlHelper.ExecuteDataTable(sql, parameter);

                //DataRow nuevaFila = datos.NewRow();
                //nuevaFila["CEDICSEM_D_ID"] = "0";
                //nuevaFila["CEDICSEM_D_DESCRIPCION"] = "-SELECCIONE-";
                //datos.Rows.Add(nuevaFila);

                return datos;
            }
            catch (Exception error)
            {

                // Extract some information from this exception, and then 
                // throw it to the parent method.
                if (error.Source != null)
                    Console.WriteLine("IOException source: {0}", error.Message);
                return null;
                throw;

            }
        }

        public DataTable CEDICSEM_LIST_NIVEL1()
        {
            String sql = "";
            DataTable datos = new DataTable();

            // sql += "SELECT [ID],[DESCRIPCION] FROM [CN_C_DISCOUNT].[dbo].[DICCIONARIO_DATOS_CDISCOUNT] WHERE [TIPO]='ITEM' AND CLASIFICACION='1'";
            sql += "SELECT codigo, descripcion FROM [CN_C_EDICSEM].[dbo].[CEDICSEM_T_DICCIONARIO_CMB] where nombre = 'nivel1' and tipo = 'CAMPANIA'";

            try
            {
                SqlParameter[] parameter = {
               // new SqlParameter("RutCliente",Rut)
                };
                datos = SqlHelper.ExecuteDataTable(sql, parameter);
                if (datos != null)
                {
                    DataRow nuevaFila = datos.NewRow();
                    nuevaFila["codigo"] = "0";
                    nuevaFila["descripcion"] = "--SELECCIONE--";
                    datos.Rows.InsertAt(nuevaFila, 0);
                }
                return datos;
            }
            catch (Exception error)
            {

                // Extract some information from this exception, and then 
                // throw it to the parent method.
                if (error.Source != null)
                    Console.WriteLine("IOException source: {0}", error.Source);
                return null;
                throw;

            }
        }

        public DataTable CEDICSEM_LIST_NIVEL2(string padre = null)
        {
            String sql = "";
            DataTable datos = new DataTable();

            sql += "SELECT codigo, descripcion FROM [CN_C_EDICSEM].[dbo].[CEDICSEM_T_DICCIONARIO_CMB] where nombre = 'nivel2' and tipo = 'CAMPANIA' and padre = '" + padre + "' ";
            //    MessageBox.Show(sql);
            try
            {
                SqlParameter[] parameter = {
               // new SqlParameter("RutCliente",Rut)
                };
                datos = SqlHelper.ExecuteDataTable(sql, parameter);
                if (datos != null)
                {
                    DataRow nuevaFila = datos.NewRow();
                    nuevaFila["codigo"] = "0";
                    nuevaFila["descripcion"] = "--SELECCIONE--";
                    datos.Rows.InsertAt(nuevaFila, 0);
                }

                return datos;
            }
            catch (Exception error)
            {

                // Extract some information from this exception, and then 
                // throw it to the parent method.
                if (error.Source != null)
                    Console.WriteLine("IOException source: {0}", error.Source);
                return null;
                throw;

            }
        }

        public DataTable CEDICSEM_LIST_NIVEL3(string padre = null)
        {
            String sql = "";
            DataTable datos = new DataTable();

            sql += "SELECT codigo, descripcion FROM [CN_C_EDICSEM].[dbo].[CEDICSEM_T_DICCIONARIO_CMB] where nombre = 'nivel3' and tipo = 'Label'  and padre = '" + padre + "' ";

            try
            {
                SqlParameter[] parameter = {
               // new SqlParameter("RutCliente",Rut)
                };
                datos = SqlHelper.ExecuteDataTable(sql, parameter);
                //if (datos != null)
                //{
                //    DataRow nuevaFila = datos.NewRow();
                //    nuevaFila["codigo"] = "0";
                //    nuevaFila["descripcion"] = "--SELECCIONE--";
                //    datos.Rows.InsertAt(nuevaFila, 0);
                //}
                return datos;
            }
            catch (Exception error)
            {

                // Extract some information from this exception, and then 
                // throw it to the parent method.
                if (error.Source != null)
                    Console.WriteLine("IOException source: {0}", error.Source);
                return null;
                throw;

            }
        }
        //Metodo genérco de insercion de clientes. Con esto generamos un mantenedor de clientes (reutilizacion de codigo) ,y no caemos en redundancia de datos
        public bool CEDICSEM_INSERTA_CLIENTE()
        {
            bool estado = false;
            String nombreProcedimiento = "[XIUX_CEDICSEM_INSERTA_CLIENTE]";

            SqlParameter[] parameter = {
              new SqlParameter("@CEDICSEM_C_CONNID",GEN_Connid.ToUpper()),
              new SqlParameter("@CEDICSEM_C_txtNombre",txtNombre.ToUpper()),
              new SqlParameter("@CEDICSEM_C_TxtTelefono1",TxtTelefono1.ToUpper()),
              new SqlParameter("@CEDICSEM_C_TxtTelefono2",TxtTelefono2.ToUpper()),
              new SqlParameter("@CEDICSEM_C_TxtCelular",TxtCelular.ToUpper()),
              new SqlParameter("@CEDICSEM_C_TxtEmail",TxtEmail.ToUpper()),
              new SqlParameter("@CEDICSEM_C_TxtDocumento",TxtDocumento.ToUpper()),
              new SqlParameter("@CEDICSEM_C_txtNcontrato",txtNcontrato.ToUpper()),
              new SqlParameter("@CEDICSEM_C_txtVigencia",txtVigencia.ToUpper()),
              new SqlParameter("@CEDICSEM_C_txtCategorizacion",txtCategorizacion.ToUpper()),
              new SqlParameter("@CEDICSEM_C_txtAsignado",txtAsignado.ToUpper()),
              new SqlParameter("@CEDICSEM_C_txtTramo",txtTramo.ToUpper()),
              new SqlParameter("@CEDICSEM_C_txtNCuota",txtNCuota.ToUpper()),
              new SqlParameter("@CEDICSEM_C_txtEstadoCuota",txtEstadoCuota.ToUpper()),
              new SqlParameter("@CEDICSEM_C_txtFechaEmision",txtFechaEmision.ToUpper()),
              new SqlParameter("@CEDICSEM_C_txtFechaVencimiento",txtFechaVencimiento.ToUpper()),
              new SqlParameter("@CEDICSEM_C_txtBanco",txtBanco.ToUpper()),
              new SqlParameter("@CEDICSEM_C_txtAporte",txtAporte.ToUpper()),
              new SqlParameter("@CEDICSEM_C_txtAporteIGV",txtAporteIGV.ToUpper()),
              new SqlParameter("@CEDICSEM_C_txtFpago",txtFpago.ToUpper()),
              new SqlParameter("@CEDICSEM_C_txtdescuento",txtdescuento.ToUpper()),
              new SqlParameter("@CEDICSEM_C_txtEmpresa",txtEmpresa.ToUpper()),
              new SqlParameter("@CEDICSEM_C_txtcargo",txtcargo.ToUpper()),
              new SqlParameter("@CEDICSEM_C_txtCodigoPlan",txtCodigoPlan.ToUpper()),
              new SqlParameter("@CEDICSEM_C_txtNombrePlan",txtNombrePlan.ToUpper()),
              new SqlParameter("@CEDICSEM_C_txtCodigoAsesor",txtCodigoAsesor.ToUpper()),
              new SqlParameter("@CEDICSEM_C_txtNombreAsesor",txtNombreAsesor.ToUpper()),
              new SqlParameter("@CEDICSEM_C_txtPreexistencias",txtPreexistencias.ToUpper()),
              new SqlParameter("@CEDICSEM_C_txtRenovacion",txtRenovacion.ToUpper())
              
            };
            try
            {
                estado = SqlHelper.executeProcedure(nombreProcedimiento, parameter);
                return estado;
            }
            catch (Exception error)
            {

                // Extract some information from this exception, and then 
                // throw it to the parent method.
                if (error.Source != null)
                    Console.WriteLine("IOException source: {0}", error.Source);
                return estado;
                throw;

            }
        }
        //Metodo genérico de insercion de tipificaciones , independientemente del área.
        public bool CEDICSEM_INSERTA_TIPIFICACIONES()
        {
            bool estado = false;
            String nombreProcedimiento = "[XIUX_CEDICSEM_INSERTA_TIPIFICACION]";

            SqlParameter[] parameter = {
              new SqlParameter("@CEDICSEM_T_CONNID",GEN_Connid.ToUpper()),
              new SqlParameter("@CEDICSEM_T_ANI",GEN_Origen.ToUpper()),
              new SqlParameter("@CEDICSEM_T_DNIS",GEN_Destino.ToUpper()),
              new SqlParameter("@CEDICSEM_T_HORA_IN_LLAMADA",GEN_FechaInicioCall.ToUpper()),
              new SqlParameter("@CEDICSEM_T_HORA_OUT_LLAMADA",GEN_FechaTerminoCall.ToUpper()),
              new SqlParameter("@CEDICSEM_T_DURACION_LLAMADA",GEN_DuracionCall.ToUpper()),
              new SqlParameter("@CEDICSEM_T_AGENTE",GEN_Agente.ToUpper()),
              new SqlParameter("@CEDICSEM_T_TIPO_INTERACCION",GEN_TipoInteraccion.ToUpper()),
              new SqlParameter("@CEDICSEM_T_NOMBRE_CAMP",GEN_NombreCamp.ToUpper()),
              new SqlParameter("@CEDICSEM_T_cmbEfectividad",cmbnivel1.ToUpper()),
              new SqlParameter("@CEDICSEM_T_cmbAccion",cmbnivel2.ToUpper()),
              new SqlParameter("@CEDICSEM_T_cmbMotivos",cmbnivel3.ToUpper()),
              new SqlParameter("@CEDICSEM_T_OBSERVACIONES",Observaciones.ToUpper()),
              new SqlParameter("@CEDICSEM_T_ESTADOINTERACCION",GEN_EstadoInteraccion.ToUpper()),
              new SqlParameter("@CEDICSEM_T_ESTADOTIPIFICACION",GEN_EstadoTipificacion.ToUpper()),  
              new SqlParameter("@CEDICSEM_T_FECHAACCION",FechaAccion.ToUpper())
                                       };
            try
            {
                estado = SqlHelper.executeProcedure(nombreProcedimiento, parameter);
                return estado;
            }
            catch (Exception error)
            {

                // Extract some information from this exception, and then 
                // throw it to the parent method.
                if (error.Source != null)
                    Console.WriteLine("IOException source: {0}", error.Source);
                return estado;
                throw;

            }
        }

        public bool LLENA_DATOS()
        {
            bool estado = false;

            try
            {
                DataTable dt = TRAE_DATOS_LISTA_RECORD(Application.Current.Properties["RecordID"].ToString());

                foreach (DataRow itm in dt.Rows)
                {
                    Application.Current.Properties["CONTRATO"] = itm.ItemArray[1].ToString();
                    Application.Current.Properties["NROCUOTA"] = itm.ItemArray[6].ToString();
                    Application.Current.Properties.Add("SECUENCIACONTRATO", itm.ItemArray[2].ToString());
                    Application.Current.Properties.Add("INICIOVIGENCIA", itm.ItemArray[36].ToString());
                    Application.Current.Properties.Add("FECHAEMISION", itm.ItemArray[37].ToString());
                    Application.Current.Properties.Add("TITULAR", itm.ItemArray[3].ToString());
                    Application.Current.Properties.Add("NRODOCUMENTOIDENTIDAD", itm.ItemArray[5].ToString());
                    Application.Current.Properties.Add("FECHAVENCIMIENTO", itm.ItemArray[38].ToString());
                    Application.Current.Properties.Add("APORTE", itm.ItemArray[7].ToString());
                    Application.Current.Properties.Add("APORTESINIGV", itm.ItemArray[8].ToString());
                    Application.Current.Properties.Add("CODIGOPLAN", itm.ItemArray[9].ToString());
                    Application.Current.Properties.Add("NOMBREDELPLAN", itm.ItemArray[10].ToString());
                    Application.Current.Properties.Add("CODIGOASESOR", itm.ItemArray[11].ToString());
                    Application.Current.Properties.Add("NOMBREASESOR", itm.ItemArray[12].ToString());
                    Application.Current.Properties.Add("CARGOACUENTA", itm.ItemArray[13].ToString());
                    Application.Current.Properties.Add("BANCO", itm.ItemArray[14].ToString());
                    Application.Current.Properties.Add("EMPRESA", itm.ItemArray[17].ToString());
                    Application.Current.Properties.Add("FORMADEPAGO", itm.ItemArray[18].ToString());
                    Application.Current.Properties.Add("TIPODESCUENTO", itm.ItemArray[19].ToString());
                    Application.Current.Properties.Add("TELEFONO1", itm.ItemArray[20].ToString());
                    Application.Current.Properties.Add("TELEFONO2", itm.ItemArray[21].ToString());
                    Application.Current.Properties.Add("CELULAR", itm.ItemArray[22].ToString());
                    Application.Current.Properties.Add("EMAIL", itm.ItemArray[23].ToString());
                    Application.Current.Properties.Add("TIENEPREEXISTENCIAS", itm.ItemArray[24].ToString());
                    Application.Current.Properties.Add("ESTADOCUOTA", itm.ItemArray[25].ToString());
                    Application.Current.Properties.Add("ESTADOSECUENCIA", itm.ItemArray[26].ToString());
                    Application.Current.Properties.Add("ULTIMAMODIFICACIONSECUENCIA", itm.ItemArray[40].ToString());
                    Application.Current.Properties.Add("NRORENOVACION", itm.ItemArray[27].ToString());
                    Application.Current.Properties.Add("ASIGNADOA", itm.ItemArray[28].ToString());
                    Application.Current.Properties.Add("CATEGORIA", itm.ItemArray[29].ToString());
                    Application.Current.Properties.Add("TRAMO", itm.ItemArray[30].ToString());
                    Application.Current.Properties.Add("OBSERVACIONES", itm.ItemArray[29].ToString());
                }
                return true;
            }
            catch (Exception error)
            {

                // Extract some information from this exception, and then 
                // throw it to the parent method.
                if (error.Source != null)
                    Console.WriteLine("IOException source: {0}", error.Source);
                return false;
                throw;

            }
        }

        // metodo que devuelve el historial del agente
        public DataTable CEDICSEM_TRAE_HISTORIAL()
        {
            String sql = "";
            DataTable datos;
            sql += "exec [SXXX_CEDICSEM_HISTORIAL_TIPIFICACION] @nombre";

            try
            {
                SqlParameter[] parameter = {
                new SqlParameter("@nombre",txtNombre),
              //  new SqlParameter("@area",area)
                };
                datos = SqlHelper.ExecuteDataTable(sql, parameter);

                return datos;
            }
            catch (Exception error)
            {

                // Extract some information from this exception, and then 
                // throw it to the parent method.
                if (error.Source != null)
                    Console.WriteLine("IOException source: {0}", error.Source);
                return null;
                throw;

            }
        }
        //mETODO QUE devuelve registros en base a la busqueda avanzada.



        //lista de gestiones o de items principales en las tipificaciones(NOCLIENTE).
        public DataTable PRO_LIST_TIPIFICACIONES_NOCLIENTE()
        {
            String sql = "";
            DataTable datos = new DataTable();

            sql += "SELECT [PRO_D_ID],[PRO_D_DESCRIPCION] FROM [CN_PROVIDA].[dbo].[PRO_D_DICCIONARIO_DATOS] WHERE [PRO_D_TIPO]='NOCLIENTE' AND PRO_D_CLASIFICACION='ITEM'";

            try
            {
                SqlParameter[] parameter = {
                // new SqlParameter("RutCliente",Rut)
                };
                datos = SqlHelper.ExecuteDataTable(sql, parameter);


                return datos;
            }
            catch (Exception error)
            {

                // Extract some information from this exception, and then 
                // throw it to the parent method.
                if (error.Source != null)
                    Console.WriteLine("IOException source: {0}", error.Source);
                return null;
                throw;

            }
        }

        public DataTable TRAE_DATOS_LISTA_RECORD(string record_id)
        {
            String sql = "";
            DataTable datos = new DataTable();

            sql += "SELECT ANIOMES,CONTRATO,SECUENCIACONTRATO,TITULAR,TIPODOCUMENTOIDENTIDAD,NRODOCUMENTOIDENTIDAD,NROCUOTA,APORTE,APORTESINIGV,CODIGOPLAN,NOMBREDELPLAN,CODIGOASESOR,NOMBREASESOR,CARGOACUENTA,BANCO,TIPOCARGOACUENTA,ESTADOCARGOACUENTA,EMPRESA,FORMADEPAGO,TIPODESCUENTO,TELEFONO1,TELEFONO2,CELULAR,EMAIL,TIENEPREEXISTENCIAS,ESTADOCUOTA,ESTADOSECUENCIA,NRORENOVACION,ASIGNADOA,CATEGORIA,TRAMO,EFECTIVIDAD,ACCION,CALENDARIO,MOTIVO,OBSERVACIONES,INICIOVIGENCIA,FECHAEMISION,FECHAVENCIMIENTO,FECHAVENCIMIENTOTARJETA,ULTIMAMODIFICACIONSECUENCIA  FROM COBRANZA_PLAN_FAMILIAR where record_id='" + record_id + "'";

            try
            {
                SqlParameter[] parameter = {
                // new SqlParameter("RutCliente",Rut)
                };
                datos = SqlHelper_2.ExecuteDataTable(sql, parameter);


                return datos;
            }
            catch (Exception error)
            {

                // Extract some information from this exception, and then 
                // throw it to the parent method.
                if (error.Source != null)
                    Console.WriteLine("IOException source: {0}", error.Source);
                return null;
                throw;

            }
        }



        public DataTable CEDICSEM_TRAE_NOMBRE(string busqueda)
        {
            String sql = "";
            DataTable datos;
            sql += "exec [SXXX_DEM_HISTORIAL] @rut";

            try
            {
                SqlParameter[] parameter = {
                new SqlParameter("@rut",txtNombre)
                };
                datos = SqlHelper.ExecuteDataTable(sql, parameter);
                return datos;
            }
            catch (Exception error)
            {

                // Extract some information from this exception, and then 
                // throw it to the parent method.
                if (error.Source != null)
                    Console.WriteLine("IOException source: {0}", error.Source);
                return null;
                throw;

            }
        }

        public DataTable CEDICSEM_TRAE_CONTRATOS()
        {
            String sql = "";
            DataTable datos;
            sql += "exec [SXXX_CEDICSEM_TRAE_CONTRATOS] @Documento";

            try
            {
                SqlParameter[] parameter = {
                new SqlParameter("@Documento",TxtDocumento)
                };
                datos = SqlHelper_2.ExecuteDataTable(sql, parameter);
                return datos;
            }
            catch (Exception error)
            {

                // Extract some information from this exception, and then 
                // throw it to the parent method.
                if (error.Source != null)
                    Console.WriteLine("IOException source: {0}", error.Source);
                return null;
                throw;

            }
        }

        public DataTable CEDICSEM_HISTORIAL()
        {
            String sql = "";
            DataTable datos;
            sql += "exec [SXXX_CEDICSEM_HISTORIAL] @Documento";

            try
            {
                SqlParameter[] parameter = {
                new SqlParameter("@Documento",TxtDocumento)
                };
                datos = SqlHelper.ExecuteDataTable(sql, parameter);
                return datos;
            }
            catch (Exception error)
            {

                // Extract some information from this exception, and then 
                // throw it to the parent method.
                if (error.Source != null)
                    Console.WriteLine("IOException source: {0}", error.Source);
                return null;
                throw;

            }
        }

    }
    public class items
    {
        public string VALUE { get; set; }
        public string NOMBRE { get; set; }
        public string DEPENDIENTE { get; set; }
        public string PADRE { get; set; }
        public items(string value, string nombre, string dependiente = "", string padrePrincipal = "")
        {
            this.VALUE = value;
            this.NOMBRE = nombre;
            this.DEPENDIENTE = dependiente;
            this.PADRE = padrePrincipal;
        }
    }
}



