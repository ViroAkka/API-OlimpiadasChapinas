using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_OlimpiadasChapinas.Models.Pais
{
    public class csEstructuraPais
    {
        public class requestPais
        {
            public string idPais { get; set; }
            public string nombre { get; set; }
        }

        public class responsePais 
        {
            public int respuesta { get; set; }
            public string descripcionRespuesta { get; set; }
        }
    }
}