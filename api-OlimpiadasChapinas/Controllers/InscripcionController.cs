using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using api_OlimpiadasChapinas.Models.Inscripcion;
using api_OlimpiadasChapinas.Models.Premiacion;
using static api_OlimpiadasChapinas.Models.Inscripcion.csEstructuraInscripcion;

namespace api_OlimpiadasChapinas.Controllers
{
    public class InscripcionController : ApiController
    {
        [HttpPost]
        [Route("rest/api/InsertarInscripcion")]
        public IHttpActionResult InsertarInscripcion(requestInscripcion model)
        {
            return Ok(new csInscripcion().InsertarInscripcion(model.idEvento, model.idParticipante, model.idPago, model.fuentePublicidad));
        }

        [HttpPost]
        [Route("rest/api/ActualizarInscripcion")]
        public IHttpActionResult ActualizarInscripcion(requestActualizarInscripcion model)
        {
            return Ok(new csInscripcion().ActualizarInscripcion(model.idEvento, model.idParticipante, model.idPago, model.fuentePublicidad, model.idEventoActualizado, model.idParticipanteActualizado, model.idPagoActualizado));
        }

        [HttpPost]
        [Route("rest/api/EliminarInscripcion")]
        public IHttpActionResult EliminarInscripcion(requestInscripcion model)
        {
            return Ok(new csInscripcion().EliminarInscripcion(model.idEvento, model.idParticipante, model.idPago));
        }

        [HttpGet]
        [Route("rest/api/ListarInscripcion")]
        public IHttpActionResult ListarInscripcion()
        {
            return Ok(new csInscripcion().ListarInscripcion());
        }
    }
}