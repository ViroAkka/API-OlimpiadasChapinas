using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using api_OlimpiadasChapinas.Models.Pago;
using api_OlimpiadasChapinas.Models.Pais;
using static api_OlimpiadasChapinas.Models.Pago.csEstructuraPago;

namespace api_OlimpiadasChapinas.Controllers
{
    public class PagoController : ApiController
    {
        [HttpPost]
        [Route("rest/api/InsertarPago")]
        public IHttpActionResult InsertarPago(requestPago model)
        {
            return Ok(new csPago().InsertarPago(model.idFormaPago, model.montoPago, model.observaciones));
        }

        [HttpPost]
        [Route("rest/api/ActualizarPago")]
        public IHttpActionResult ActualizarPago(requestPagoByID model)
        {
            return Ok(new csPago().ActualizarPago(model.idPago, model.idFormaPago, model.montoPago, model.observaciones));
        }

        [HttpPost]
        [Route("rest/api/EliminarPago")]
        public IHttpActionResult EliminarPago(requestPagoByID model)
        {
            return Ok(new csPago().EliminarPago(model.idPago));
        }

        [HttpGet]
        [Route("rest/api/ListarPago")]
        public IHttpActionResult ListarPago()
        {
            return Ok(new csPago().ListarPago());
        }
    }
}