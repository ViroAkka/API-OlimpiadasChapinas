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
        public IHttpActionResult ActualizarInscripcion(requestInscripcion model)
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

        [HttpGet]
        [Route("rest/api/ListarInscripcionPorID")]
        public IHttpActionResult ListarInscripcionPorID(int idEvento, int idParticipante, int idPago)
        {
            return Ok(new csInscripcion().ListarInscripcionPorID(idEvento, idParticipante, idPago));
        }

        [HttpGet]
        [Route("rest/api/ListarInscripcionPorEvento")]
        public IHttpActionResult ListarInscripcionPorEvento(int idEvento)
        {
            return Ok(new csInscripcion().ListarInscripcionPorEvento(idEvento));
        }

        [HttpGet]
        [Route("rest/api/ListarInscripcionPorParticipante")]
        public IHttpActionResult ListarInscripcionPorParticipante(int idParticipante)
        {
            return Ok(new csInscripcion().ListarInscripcionPorParticipante(idParticipante));
        }

        [HttpGet]
        [Route("rest/api/ListarInscripcionPorPago")]
        public IHttpActionResult ListarInscripcionPorPago(int idPago)
        {
            return Ok(new csInscripcion().ListarInscripcionPorPago(idPago));
        }

        [HttpGet]
        [Route("rest/api/ListarInscripcionPorEventoParticipante")]
        public IHttpActionResult ListarInscripcionPorEventoParticipante(int idEvento, int idParticipante)
        {
            return Ok(new csInscripcion().ListarInscripcionPorEventoParticipante(idEvento, idParticipante));
        }

        [HttpGet]
        [Route("rest/api/ListarInscripcionPorEventoPago")]
        public IHttpActionResult ListarInscripcionPorEventoPago(int idEvento, int idPago)
        {
            return Ok(new csInscripcion().ListarInscripcionPorEventoPago(idEvento, idPago));
        }

        [HttpGet]
        [Route("rest/api/ListarInscripcionPorParticipantePago")]
        public IHttpActionResult ListarInscripcionPorParticipantePago(int idParticipante, int idPago)
        {
            return Ok(new csInscripcion().ListarInscripcionPorParticipantePago(idParticipante, idPago));
        }
    }
}