using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DMProject.App_Start;

namespace DMProject
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
          //  AreaRegistration.RegisterAllAreas();
           // GlobalConfiguration.Configure(WebApiConfig.Register);
      
           // RouteConfig.RegisterRoutes(RouteTable.Routes);
         //   BundleConfig.RegisterBundles(BundleTable.Bundles);


            var config = GlobalConfiguration.Configuration;

            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(config);
            Bootstrapper.Run();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalConfiguration.Configuration.EnsureInitialized();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }
    }
}
