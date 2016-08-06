using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Headers;

namespace CarrierIntegrator
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            /* config.SuppressDefaultHostAuthentication();
             config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));*/

            config.Routes.MapHttpRoute(
              name: "DefaultApi",
              routeTemplate: "api/{controller}/{id}",
              defaults: new { id = RouteParameter.Optional }
          );

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
              name: "ApiRespuestas",
              routeTemplate: "api/{controller}/{id}/{respuesta}/{token}",
              defaults : new {id = RouteParameter.Optional, respuesta = RouteParameter.Optional, token = RouteParameter.Optional }
          );

            /*  config.Routes.MapHttpRoute(
                name: "ApiAccess",
                routeTemplate: "api/{controller}/{user}/{pass}"             
            );*/

           

        }
    }
}
