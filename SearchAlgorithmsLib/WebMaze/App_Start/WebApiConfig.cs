using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebMaze
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApiUserLogin",
                routeTemplate: "api/UsersClassModels/5/{userName}"
            //defaults: new { controller = "UserClassModels" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApiUser",
                routeTemplate: "api/UsersClassModels/{userName}/{password}"
            //defaults: new { controller = "UserClassModels" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApiDummy",
                routeTemplate: "api/{controller}/{name}/{rows}/{cols}",
                defaults: new { controller = "MazeController" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
