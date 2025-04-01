using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_OlimpiadasChapinas.Models.Participante
{
    public class csEstructuraParticipante
    {
        public class requestParticipante
        {
            public string idPais { get; set; }
            public int idUsuario { get; set; }
            public string fechaNacimiento { get; set; }
            public double altura { get; set; }
            public double peso { get; set; }
            public string genero { get; set; }
        }

        public class requestParticipanteByID
        {
            public int idParticipante { get; set; }
            public string idPais { get; set; }
            public int idUsuario { get; set; }
            public string fechaNacimiento { get; set; }
            public double altura { get; set; }
            public double peso { get; set; }
            public string genero { get; set; }
        }

        public class requestEliminarParticipante
        {
            public int idParticipante { get; set; }
        }

        public class responseParticipante
        {
            public int respuesta { get; set; }
            public string descripcionRespuesta { get; set; }
        }
    }
}