using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WCFCliente.Dominio;

namespace WCFCliente.Persistencia
{
    public class ClienteDAO
    {
       
        DateTime moment = new DateTime(1999, 1, 13, 3, 57, 32, 11);
        private String cadenaConexion = "Data Source=.\\SQLEXPRESS; Initial Catalog=CN_C_EDICSEM; Integrated Security=SSPI;";

        public Cliente_SQL obtenerCliente(string DNI)
        {
            //METODO OBTENER CLIENTE DESARROLLADO POR JULIO TORRES Y MARIANO FIGUEROA
            
            Cliente_SQL clienteEncontrado = null;
            string sql = "SELECT * FROM [CN_C_EDICSEM].[dbo].[CEDICSEM_C_CLIENTE] WHERE CEDICSEM_C_TxtDocumento = @NRODOCUMENTO";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {

                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@NRODOCUMENTO", DNI));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            clienteEncontrado = new Cliente_SQL()
                            {

                                TITULAR = (string)resultado["CEDICSEM_C_txtNombre"],
                                TELEFONO1 = (string)resultado["CEDICSEM_C_TxtTelefono1"],
                                TELEFONO2 = (string)resultado["CEDICSEM_C_TxtTelefono2"],

                                INICIOVIGENCIA = (string)resultado["CEDICSEM_C_txtVigencia"],


                                SECUENCIACONTRATO = "10",
                                ESTADOCUOTA = (string)resultado["CEDICSEM_C_txtEstadoCuota"],
                                //ULTIMAMODIFICACIONSECUENCIA = (string)resultado["CEDICSEM_C_txtVigencia"],
                                CATEGORIA = (string)resultado["CEDICSEM_C_txtCategorizacion"],
                                ASIGNADOA = (string)resultado["CEDICSEM_C_txtAsignado"],
                                NROCUOTA = (string)resultado["CEDICSEM_C_txtNCuota"],
                                BANCO = (string)resultado["CEDICSEM_C_txtBanco"],
                                MONTO = (string)resultado["CEDICSEM_C_txtAporte"],
                                FORMADEPAGO = "PERSONAL",
                                TIPODESCUENTO = (string)resultado["CEDICSEM_C_txtdescuento"],
                                CARGOACUENTA = (string)resultado["CEDICSEM_C_txtcargo"],
                                NOMBREASESOR = (string)resultado["CEDICSEM_C_txtNombreAsesor"],
                                TIPODOCUMENTOIDENTIDAD  = "DNI",

                                CELULAR = (string)resultado["CEDICSEM_C_TxtCelular"],
                                NRODOCUMENTOIDENTIDAD = (string)resultado["CEDICSEM_C_TxtDocumento"],
                                CONTRATO = (string)resultado["CEDICSEM_C_txtNcontrato"],
                                FECHAEMISION = (string)resultado["CEDICSEM_C_txtFechaEmision"],
                                FECHAVENCIMIENTO = (string)resultado["CEDICSEM_C_txtFechaVencimiento"],
                                EMPRESA = (string)resultado["CEDICSEM_C_txtEmpresa"],
                                EMAIL = (string)resultado["CEDICSEM_C_TxtEmail"],
                                FECHAVENCIMIENTOTARJETA = (string)resultado["CEDICSEM_C_txtFpago"],
                                CODIGOASESOR = (string)resultado["CEDICSEM_C_txtCodigoAsesor"],
                                TIENEPREEXISTENCIAS = (string)resultado["CEDICSEM_C_txtPreexistencias"],
                                NRORENOVACION = (string)resultado["CEDICSEM_C_txtRenovacion"],
                                
                                //MOTIVO = (string)resultado["CEDICSEM_C_txtMotivo"],
                                
                            };
                        }
                    }
                }
                return clienteEncontrado;
            }
        }


        public Cliente_SQL Crear(Cliente_SQL clienteInsertar)
        {
            //METODO INSERTAR DESARROLLADO POR WALTER CAHUANA Y KAREN GIL
            bool estado = false;
            String nombreProcedimiento = "[XIUX_CEDICSEM_INSERTA_CLIENTE]";

            SqlParameter[] parameter = {
              new SqlParameter("@CEDICSEM_C_CONNID",moment.Millisecond.ToString()),
              new SqlParameter("@CEDICSEM_C_txtNombre",clienteInsertar.TITULAR),
              new SqlParameter("@CEDICSEM_C_TxtTelefono1",clienteInsertar.TELEFONO1),
              new SqlParameter("@CEDICSEM_C_TxtTelefono2",clienteInsertar.TELEFONO2),
              new SqlParameter("@CEDICSEM_C_TxtCelular",clienteInsertar.CELULAR),
              new SqlParameter("@CEDICSEM_C_TxtEmail",clienteInsertar.EMAIL),
              new SqlParameter("@CEDICSEM_C_TxtDocumento",clienteInsertar.NRODOCUMENTOIDENTIDAD),
              new SqlParameter("@CEDICSEM_C_txtNcontrato",clienteInsertar.CONTRATO),
              new SqlParameter("@CEDICSEM_C_txtVigencia",clienteInsertar.INICIOVIGENCIA),
              new SqlParameter("@CEDICSEM_C_txtCategorizacion",clienteInsertar.CATEGORIA),
              new SqlParameter("@CEDICSEM_C_txtAsignado",clienteInsertar.ASIGNADOA),
              new SqlParameter("@CEDICSEM_C_txtTramo",clienteInsertar.TRAMO),
              new SqlParameter("@CEDICSEM_C_txtNCuota",clienteInsertar.NROCUOTA),
              new SqlParameter("@CEDICSEM_C_txtEstadoCuota",clienteInsertar.ESTADOCUOTA),
              new SqlParameter("@CEDICSEM_C_txtFechaEmision",clienteInsertar.FECHAEMISION),
              new SqlParameter("@CEDICSEM_C_txtFechaVencimiento",clienteInsertar.FECHAVENCIMIENTO),
              new SqlParameter("@CEDICSEM_C_txtBanco",clienteInsertar.BANCO),
              new SqlParameter("@CEDICSEM_C_txtAporte",clienteInsertar.APORTE),
              new SqlParameter("@CEDICSEM_C_txtAporteIGV",clienteInsertar.APORTESINIGV),
              new SqlParameter("@CEDICSEM_C_txtFpago",clienteInsertar.FORMADEPAGO),
              new SqlParameter("@CEDICSEM_C_txtdescuento",clienteInsertar.TIPODESCUENTO),
              new SqlParameter("@CEDICSEM_C_txtEmpresa",clienteInsertar.EMPRESA),
              new SqlParameter("@CEDICSEM_C_txtcargo","PRESI"),
              new SqlParameter("@CEDICSEM_C_txtCodigoPlan",clienteInsertar.CODIGOPLAN),
              new SqlParameter("@CEDICSEM_C_txtNombrePlan",clienteInsertar.NOMBREDELPLAN),
              new SqlParameter("@CEDICSEM_C_txtCodigoAsesor",clienteInsertar.CODIGOASESOR),
              new SqlParameter("@CEDICSEM_C_txtNombreAsesor",clienteInsertar.NOMBREASESOR),
              new SqlParameter("@CEDICSEM_C_txtPreexistencias",clienteInsertar.TIENEPREEXISTENCIAS),
              new SqlParameter("@CEDICSEM_C_txtRenovacion",clienteInsertar.NRORENOVACION)
              
            };
            try
            {
                estado = SqlHelper.executeProcedure(nombreProcedimiento, parameter);
                return clienteInsertar;
            }
            catch (Exception error)
            {
                if (error.Source != null)
                    Console.WriteLine("IOException source: {0}", error.Source);
                return clienteInsertar;
                throw;
            }

        }
    }
}
