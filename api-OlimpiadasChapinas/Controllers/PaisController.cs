using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using api_OlimpiadasChapinas.Models.Pais;
using static api_OlimpiadasChapinas.Models.Pais.csEstructuraPais;

namespace api_OlimpiadasChapinas.Controllers
{
    public class PaisController : ApiController
    {
        [HttpPost]
        [Route("rest/api/InsertarPais")]
        public IHttpActionResult InsertarPais(requestPais model)
        {
            return Ok(new csPais().InsertarPais(model.idPais,model.nombre));
        }

        [HttpPost]
        [Route("rest/apiAactualizarPais")]
        public IHttpActionResult ActualizarPais(requestPais model) 
        {
            return Ok(new csPais().ActualizarPais(model.idPais, model.nombre));
        }

        [HttpPost]
        [Route("rest/api/EliminarPais")]
        public IHttpActionResult EliminarPais(requestPais model)
        {
            return Ok(new csPais().EliminarPais(model.idPais));
        }

        [HttpGet]
        [Route("rest/api/ListarPais")]
        public IHttpActionResult ListarPais()
        {
            return Ok(new csPais().ListarPais());
        }

        [HttpGet]
        [Route("rest/api/ListarPaisPorID")]
        public IHttpActionResult ListarPaisPorID(string idPais)
        {
            return Ok(new csPais().ListarPaisPorID(idPais));
        }
    }
}