using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using api_OlimpiadasChapinas.Models.Usuario;
using static api_OlimpiadasChapinas.Models.Usuario.csEstructuraUsuario;

namespace api_OlimpiadasChapinas.Controllers
{
    public class UsuarioController : ApiController
    {
        [HttpPost]
        [Route("rest/api/insertarUsuario")]

        public IHttpActionResult insertarUsuario(requestUsuario model)
        {
            return Ok(new csUsuario().insertarUsuario(model.nombre, model.apellido, model.email, model.contraseña_hash, model.telefono, model.DNI));
        }

        [HttpPost]
        [Route("rest/api/actualizarUsuario")]
        public IHttpActionResult actualizarUsuario(requestActualizarUsuario model)
        {
            return Ok(new csUsuario().actualizarUsuario(model.nombre, model.apellido, model.email, model.contraseñaAlmacenada, model.contraseñaActualizada, model.telefono));
        }

        [HttpPost]
        [Route("rest/api/eliminarUsuario")]
        public IHttpActionResult eliminarUsuario(requestEliminarUsuario model)
        {
            return Ok(new csUsuario().eliminarUsuario(model.email));
        }

        [HttpGet]
        [Route("rest/api/listarUsuario")]
        public IHttpActionResult listarUsuario()
        {
            return Ok(new csUsuario().listarUsuario());
        }
    }
}