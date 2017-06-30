using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using WebMaze.Controllers;
using WebMaze.Models;

namespace WebMaze
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer<WebMazeContext>(null);
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
