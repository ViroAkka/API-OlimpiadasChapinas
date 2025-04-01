using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_OlimpiadasChapinas.Models.PuestoPremiacion
{
    public class csEstructuraPuestoPremiacion
    {
        public class requestPuestoPremiacion
        {
            public int idPuesto { get; set; }
            public string descripcion { get; set; }
        }

        public class responsePuestoPremiacion
        {
            public int respuesta { get; set; }
            public string descripcionRespuesta { get; set; }
        }
    }
}