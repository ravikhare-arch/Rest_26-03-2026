using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace RestaurantApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_BeginRequest()
        {

            //Response.AddHeader("Access-Control-Allow-Origin", "*");
            //Response.AddHeader("Access-Control-Allow-Headers", "Content-Type");
            //Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, OPTIONS");

            //var origin = Request.Headers["Origin"];

            //if (!string.IsNullOrEmpty(origin) &&
            //    origin.Equals("https://redaanfinal.admirabletechno.com",
            //                  StringComparison.OrdinalIgnoreCase))
            //{
            //    Response.AddHeader("Access-Control-Allow-Origin", origin);
            //    Response.AddHeader("Access-Control-Allow-Headers", "Content-Type");
            //    Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, OPTIONS");
            //}

            // Handle preflight request
            if (Request.HttpMethod == "OPTIONS")
            {
                Response.AddHeader("Access-Control-Allow-Origin", "*");
                Response.AddHeader("Access-Control-Allow-Headers", "Content-Type");
                Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, PUT,DELETE,OPTIONS");

                Response.StatusCode = 200;
                Response.End();
            }
        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
