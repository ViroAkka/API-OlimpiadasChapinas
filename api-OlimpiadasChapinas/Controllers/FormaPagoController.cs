using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using api_OlimpiadasChapinas.Models.FormaPago;
using static api_OlimpiadasChapinas.Models.FormaPago.csEstructuraFormaPago;

namespace api_OlimpiadasChapinas.Controllers
{
    public class FormaPagoController : ApiController
    {
        [HttpPost]
        [Route("rest/api/InsertarFormaPago")]
        public IHttpActionResult InsertarFormaPago(requestFormaPago model)
        {
            return Ok(new csFormaPago().InsertarFormaPago(model.descripcion));
        }

        [HttpPost]
        [Route("rest/api/ActualizarFormaPago")]
        public IHttpActionResult ActualizarFormaPago(requestFormaPago model)
        {
            return Ok(new csFormaPago().ActualizarFormaPago(model.idFormaPago, model.descripcion));
        }

        [HttpPost]
        [Route("rest/api/EliminarFormaPago")]
        public IHttpActionResult EliminarFormaPago(requestFormaPago model)
        {
            return Ok(new csFormaPago().EliminarFormaPago(model.idFormaPago));
        }

        [HttpGet]
        [Route("rest/api/ListarFormaPago")]
        public IHttpActionResult ListarFormaPago()
        {
            return Ok(new csFormaPago().ListarFormaPago());
        }

        [HttpGet]
        [Route("rest/api/ListarFormaPagoPorID")]
        public IHttpActionResult ListarFormaPagoPorID(int idFormaPago)
        {
            return Ok(new csFormaPago().ListarFormaPagoPorID(idFormaPago));
        }
    }
}