using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using api_OlimpiadasChapinas.Models.Deporte;
using Newtonsoft.Json;
using static api_OlimpiadasChapinas.Models.Deporte.csDeporteEstructura;

namespace api_OlimpiadasChapinas.Controllers
{
    public class DeporteController : ApiController
    {
        [HttpPost]
        [Route("rest/api/InsertarDeporte")]
        public IHttpActionResult InsertarDeporte(requestDeporte model)
        {
            return Ok(new csDeporte().InsertarDeporte(model.nombre, model.categoria, model.descripcion, model.cantidadJugadores));
        }

        [HttpPost]
        [Route("rest/api/ActualizarDeporte")]
        public IHttpActionResult ActualizarDeporte(requestDeporte model)
        {
            return Ok(new csDeporte().ActualizarDeporte(model.idDeporte, model.nombre, model.categoria, model.descripcion, model.cantidadJugadores));
        }

        [HttpPost]
        [Route("rest/api/EliminarDeporte")]
        public IHttpActionResult EliminarDeporte(requestDeporte model)
        {
            return Ok(new csDeporte().EliminarDeporte(model.idDeporte));
        }

        [HttpGet]
        [Route("rest/api/ListarDeporte")]
        public IHttpActionResult ListarDeporte()
        {
            return Ok(new csDeporte().ListarDeporte());
        }

        [HttpGet]
        [Route("rest/api/ListarDeportePorID")]
        public IHttpActionResult ListarDeportePorID(string idDeporte)
        {
            return Ok(new csDeporte().ListarDeportePorID(idDeporte));
        }
    }
}