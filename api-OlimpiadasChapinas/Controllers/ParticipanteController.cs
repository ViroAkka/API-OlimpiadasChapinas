using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using api_OlimpiadasChapinas.Models.Participante;
using static api_OlimpiadasChapinas.Models.Participante.csEstructuraParticipante;

namespace api_OlimpiadasChapinas.Controllers
{
    public class ParticipanteController : ApiController
    {
        [HttpPost]
        [Route("rest/api/InsertarParticipante")]
        public IHttpActionResult InsertarParticipante(requestParticipante model)
        {
            return Ok(new csParticipante().InsertarParticipante(model.idPais, model.idUsuario, model.fechaNacimiento, model.altura, model.peso, model.genero));
        }

        [HttpPost]
        [Route("rest/api/ActualizarParticipante")]
        public IHttpActionResult ActualizarParticipante(requestParticipante model)
        {
            return Ok(new csParticipante().ActualizarParticipante(model.idParticipante, model.idPais, model.idUsuario, model.fechaNacimiento, model.altura, model.peso, model.genero));
        }

        [HttpPost]
        [Route("rest/api/EliminarParticipante")]
        public IHttpActionResult EliminarParticipante(requestParticipante model)
        {
            return Ok(new csParticipante().EliminarParticipante(model.idParticipante));
        }

        [HttpGet]
        [Route("rest/api/ListarParticipante")]
        public IHttpActionResult ListarParticipante()
        {
            return Ok(new csParticipante().ListarParticipante());
        }

        [HttpGet]
        [Route("rest/api/ListarParticipantePorID")]
        public IHttpActionResult ListarParticipantePorID(int idParticipante)
        {
            return Ok(new csParticipante().ListarParticipantePorID(idParticipante));
        }
    }
}