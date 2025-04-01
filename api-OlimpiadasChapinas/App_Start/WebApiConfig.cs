using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace api_OlimpiadasChapinas
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de Web API

            // Rutas de Web API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Forzar la respuesta a JSON
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("application/json"));
            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
        }
    }
}
