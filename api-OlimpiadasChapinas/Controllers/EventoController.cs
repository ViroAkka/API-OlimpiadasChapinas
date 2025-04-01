using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using api_OlimpiadasChapinas.Models.Evento;
using static api_OlimpiadasChapinas.Models.Evento.csEstructuraEvento;

namespace api_OlimpiadasChapinas.Controllers
{
    public class EventoController : ApiController
    {
        [HttpPost]
        [Route("rest/api/InsertarEvento")]
        public IHttpActionResult InsertarEvento(requestEvento model)
        {
            if (model.idEventoPadre != 0)
            {
                return Ok(new csEvento().InsertarEvento(model.idDeporte, model.idEventoPadre, model.nombre, model.fechaInicio, model.fechaFin, model.cantidadParticipantes, model.montoInscripcion));
            } else
            {
                return Ok(new csEvento().InsertarEvento(model.idDeporte, model.nombre, model.fechaInicio, model.fechaFin, model.cantidadParticipantes, model.montoInscripcion));
            }
        }

        [HttpPost]
        [Route("rest/api/ActualizarEvento")]
        public IHttpActionResult ActualizarEvento(requestEventoByID model)
        {
            if (model.idEventoPadre != 0)
            {
                return Ok(new csEvento().ActualizarEvento(model.idEvento, model.idDeporte, model.idEventoPadre, model.nombre, model.fechaInicio, model.fechaFin, model.cantidadParticipantes, model.montoInscripcion));
            } else
            {
                return Ok(new csEvento().ActualizarEvento(model.idEvento, model.idDeporte, model.nombre, model.fechaInicio, model.fechaFin, model.cantidadParticipantes, model.montoInscripcion));
            }
        }

        [HttpPost]
        [Route("rest/api/EliminarEvento")]
        public IHttpActionResult EliminarEvento(requestEventoByID model)
        {
            return Ok(new csEvento().EliminarEvento(model.idEvento));
        }

        [HttpGet]
        [Route("rest/api/ListarEvento")]
        public IHttpActionResult ListarEvento()
        {
            return Ok(new csEvento().ListarEvento());
        }
    }
}