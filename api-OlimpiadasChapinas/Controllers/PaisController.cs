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
        [Route("rest/api/insertarPais")]
        public IHttpActionResult insertarPais(requestPais model)
        {
            return Ok(new csPais().insertarPais(model.idPais,model.nombre));
        }

        [HttpPost]
        [Route("rest/api/actualizarPais")]
        public IHttpActionResult actualizarPais(requestPais model) 
        {
            return Ok(new csPais().actualizarPais(model.idPais, model.nombre));
        }

        [HttpPost]
        [Route("rest/api/eliminarPais")]
        public IHttpActionResult eliminarPais(requestEliminarPais model)
        {
            return Ok(new csPais().eliminarPais(model.idPais));
        }

        [HttpGet]
        [Route("rest/api/listarPais")]
        public IHttpActionResult listarPais()
        {
            return Ok(new csPais().listarPais());
        }
    }
}