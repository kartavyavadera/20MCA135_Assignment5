using _20MCA135_Assignment5.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace _20MCA135_Assignment5
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Filters.Add(new CustomExceptionFilter());
            //config.Filters.Add(new ExceptionFilter());

        }
    }
}
