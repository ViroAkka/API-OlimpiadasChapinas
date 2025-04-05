using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using api_OlimpiadasChapinas.Models.Premiacion;
using static api_OlimpiadasChapinas.Models.Premiacion.csEstructuraPremiacion;

namespace api_OlimpiadasChapinas.Controllers
{
    public class PremiacionController : ApiController
    {
        [HttpPost]
        [Route("rest/api/InsertarPremiacion")]
        public IHttpActionResult InsertarPremiacion(requestPremiacion model)
        {
            return Ok(new csPremiacion().InsertarPremiacion(model.idEvento, model.idPuesto, model.idParticipante));
        }

        [HttpPost]
        [Route("rest/api/ActualizarPremiacion")]
        public IHttpActionResult ActualizarPremiacion(requestPremiacion model)
        {
            return Ok(new csPremiacion().ActualizarPremiacion(model.idPremiacion, model.idEvento, model.idPuesto, model.idParticipante));
        }

        [HttpPost]
        [Route("rest/api/EliminarPremiacion")]
        public IHttpActionResult EliminarPremiacion(requestPremiacion model)
        {
            return Ok(new csPremiacion().EliminarPremiacion(model.idPremiacion));
        }

        [HttpGet]
        [Route("rest/api/ListarPremiacion")]
        public IHttpActionResult ListarPremiacion()
        {
            return Ok(new csPremiacion().ListarPremiacion());
        }

        [HttpGet]
        [Route("rest/api/ListarPremiacionPorID")]
        public IHttpActionResult ListarPremiacionPorID(int idPremiacion)
        {
            return Ok(new csPremiacion().ListarPremiacionPorID(idPremiacion));
        }
    }
}