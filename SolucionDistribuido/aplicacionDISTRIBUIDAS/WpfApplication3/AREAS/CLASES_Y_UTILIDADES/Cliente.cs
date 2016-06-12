using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WpfApplication3.AREAS.CLASES_Y_UTILIDADES
{
    // KAREN GIL
    [DataContract]
    class Cliente
    {
        [DataMember]
        public string MONTO { get; set; }

        [DataMember]

        public string ANIOMES { get; set; }
        [DataMember]
        public string CONTRATO { get; set; }
        [DataMember]
        public string SECUENCIACONTRATO { get; set; }
        [DataMember]
        public string TITULAR { get; set; }
        [DataMember]
        public string TIPODOCUMENTOIDENTIDAD { get; set; }
        [DataMember]
        public string NRODOCUMENTOIDENTIDAD { get; set; }
        [DataMember]
        public string NROCUOTA { get; set; }
        [DataMember]
        public string APORTE { get; set; }
        [DataMember]
        public string APORTESINIGV { get; set; }
        [DataMember]
        public string CODIGOPLAN { get; set; }
        [DataMember]
        public string NOMBREDELPLAN { get; set; }
        [DataMember]
        public string CODIGOASESOR { get; set; }
        [DataMember]
        public string NOMBREASESOR { get; set; }
        [DataMember]
        public string CARGOACUENTA { get; set; }
        [DataMember]
        public string BANCO { get; set; }
        [DataMember]
        public string TIPOCARGOACUENTA { get; set; }
        [DataMember]
        public string ESTADOCARGOACUENTA { get; set; }
        [DataMember]
        public string EMPRESA { get; set; }
        [DataMember]
        public string FORMADEPAGO { get; set; }
        [DataMember]
        public string TIPODESCUENTO { get; set; }
        [DataMember]
        public string TELEFONO1 { get; set; }
        [DataMember]
        public string TELEFONO2 { get; set; }
        [DataMember]
        public string CELULAR { get; set; }
        [DataMember]
        public string EMAIL { get; set; }
        [DataMember]
        public string TIENEPREEXISTENCIAS { get; set; }
        [DataMember]
        public string ESTADOCUOTA { get; set; }
        [DataMember]
        public string ESTADOSECUENCIA { get; set; }
        [DataMember]
        public string NRORENOVACION { get; set; }
        [DataMember]
        public string ASIGNADOA { get; set; }
        [DataMember]
        public string CATEGORIA { get; set; }
        [DataMember]
        public string TRAMO { get; set; }
        [DataMember]
        public string EFECTIVIDAD { get; set; }
        [DataMember]
        public string ACCION { get; set; }
        [DataMember]
        public string CALENDARIO { get; set; }
        [DataMember]
        public string MOTIVO { get; set; }
        [DataMember]
        public string OBSERVACIONES { get; set; }
        [DataMember]
        public string INICIOVIGENCIA { get; set; }
        [DataMember]
        public string FECHAEMISION { get; set; }
        [DataMember]
        public string FECHAVENCIMIENTO { get; set; }
        [DataMember]
        public string FECHAVENCIMIENTOTARJETA { get; set; }
        [DataMember]
        public string ULTIMAMODIFICACIONSECUENCIA { get; set; }
        [DataMember]
        public string PERSONALIZADO_1 { get; set; }
        [DataMember]
        public string PERSONALIZADO_2 { get; set; }
        [DataMember]
        public string PERSONALIZADO_3 { get; set; }
        [DataMember]
        public string PERSONALIZADO_4 { get; set; }
        [DataMember]
        public string PERSONALIZADO_5 { get; set; }

    }
}