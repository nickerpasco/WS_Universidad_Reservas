using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WS_Universidad
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services


            // Configurar CORS
            

            // Otras configuraciones de Web API 

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
