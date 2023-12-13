using AirbnbUdC.Application.Contracts.Contracts.Parameters;
using AirbnbUdC.Application.Implementation.Implementation.Parameters;
using AirbnbUdC.Repository.Contracts.Contrats.Parameters;
using AirbnbUdC.Repository.Implementation.Implementations.Parameters;
using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

            //configuracion de la inyeccion de dependencias
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<CountryImplementationApplication>().As<ICountryApplication>();
            builder.RegisterType<CityImplementationApplication>().As<ICityApplication>();
            builder.RegisterType<CountryImplementationApplication>().As<ICountryApplication>();

            builder.RegisterType<CountryImplementationRepository>().As<ICountryRepository>();
            builder.RegisterType<CityImplementationRepository>().As<ICityRepository>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));


        }
    }
}
