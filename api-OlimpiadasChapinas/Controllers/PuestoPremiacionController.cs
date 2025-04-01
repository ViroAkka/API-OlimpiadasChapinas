using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using api_OlimpiadasChapinas.Models.PuestoPremiacion;
using static api_OlimpiadasChapinas.Models.PuestoPremiacion.csEstructuraPuestoPremiacion;

namespace api_OlimpiadasChapinas.Controllers
{
    public class PuestoPremiacionController : ApiController
    {
        [HttpPost]
        [Route("rest/api/InsertarPuestoPremiacion")]
        public IHttpActionResult InsertarPuestoPremiacion(requestPuestoPremiacion model)
        {
            return Ok(new csPuestoPremiacion().InsertarPuestoPremiacion(model.idPuesto, model.descripcion));
        }

        [HttpPost]
        [Route("rest/api/ActualizarPuestoPremiacion")]
        public IHttpActionResult ActualizarPuestoPremiacion(requestPuestoPremiacion model)
        {
            return Ok(new csPuestoPremiacion().ActualizarPuestoPremiacion(model.idPuesto, model.descripcion));
        }

        [HttpPost]
        [Route("rest/api/EliminarPuestoPremiacion")]
        public IHttpActionResult EliminarPuestoPremiacion(requestPuestoPremiacion model)
        {
            return Ok(new csPuestoPremiacion().EliminarPuestoPremiacion(model.idPuesto));
        }

        [HttpGet]
        [Route("rest/api/ListarPuestoPremiacion")]
        public IHttpActionResult ListarPuestoPremiacion()
        {
            return Ok(new csPuestoPremiacion().ListarPuestoPremiacion());
        }
    }
}