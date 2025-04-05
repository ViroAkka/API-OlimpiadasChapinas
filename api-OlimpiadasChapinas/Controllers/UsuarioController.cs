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
        [Route("rest/api/InsertarUsuario")]

        public IHttpActionResult InsertarUsuario(requestUsuario model)
        {
            return Ok(new csUsuario().InsertarUsuario(model.nombre, model.apellido, model.email, model.contraseña_hash, model.telefono, model.DNI));
        }

        [HttpPost]
        [Route("rest/api/ActualizarUsuario")]
        public IHttpActionResult ActualizarUsuario(requestUsuario model)
        {
            return Ok(new csUsuario().ActualizarUsuario(model.nombre, model.apellido, model.email, model.contraseñaAlmacenada, model.contraseñaActualizada, model.telefono));
        }

        [HttpPost]
        [Route("rest/api/EliminarUsuario")]
        public IHttpActionResult EliminarUsuario(requestUsuario model)
        {
            return Ok(new csUsuario().EliminarUsuario(model.email));
        }

        [HttpGet]
        [Route("rest/api/ListarUsuario")]
        public IHttpActionResult ListarUsuario()
        {
            return Ok(new csUsuario().ListarUsuario());
        }

        [HttpGet]
        [Route("rest/api/ListarUsuarioPorID")]
        public IHttpActionResult ListarUsuarioPorID(int idUsuario)
        {
            return Ok(new csUsuario().ListarUsuarioPorID(idUsuario));
        }

        [HttpGet]
        [Route("rest/api/ListarUsuarioPorEmail")]
        public IHttpActionResult ListarUsuarioPorEmail(string email)
        {
            return Ok(new csUsuario().ListarUsuarioPorEmail(email));
        }
    }
}