using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using DMProject.Mappings;

namespace DMProject.App_Start
{
    public class Bootstrapper
    {
        public static void Run()
        {
            AutofacWebapiConfig.Initialize(GlobalConfiguration.Configuration);
            //Configure AutoMapper
            AutoMapperConfiguration.Configure();
        }
    }
}