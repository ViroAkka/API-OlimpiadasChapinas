using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_OlimpiadasChapinas.Models.FormaPago
{
    public class csEstructuraFormaPago
    {
        public class requestFormaPago
        {
            public string descripcion { get; set; }
        }
        public class requestFormaPagoByID
        {
            public int idFormaPago { get; set; }
            public string descripcion { get; set; }
        }
        public class responseFormaPago
        {
            public int respuesta { get; set; }
            public string descripcionRespuesta { get; set; }
        }
    }
}