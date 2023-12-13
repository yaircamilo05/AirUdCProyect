<<<<<<< Updated upstream
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
=======
using AirbnbUdC.Application.Contracts.Contracts.Parameters;
using AirbnbUdC.Application.Implementation.Implementation.Parameters;
using AirbnbUdC.Repository.Contracts.Contrats.Parameters;
using AirbnbUdC.Repository.Implementation.Implementations.Parameters;
using Autofac;
using Autofac.Integration.Mvc;
>>>>>>> Stashed changes
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AirUdC.GUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
