using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebAPI_2013
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            /* vu que les routes peuvent etes definioes au niveau methode et classe controller , null besoin du template ci-dessous...*/
            /*
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            */
        }
    }
}
