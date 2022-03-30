using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TestApplication.Model.Common;
using TestApplication.Repository;
using TestApplication.Repository.Common;
using TestApplication.Service;
using TestApplication.Service.Common;
using TestApplicationModel;

namespace TestApplication.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();

            var config = GlobalConfiguration.Configuration;

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<Developer>().As<IDeveloper>();
            builder.RegisterType<Project>().As<IProject>();

            builder.RegisterType<DeveloperService>().As<IDeveloperService>();
            builder.RegisterType<ProjectService>().As<IProjectService>();

            builder.RegisterType<DeveloperRepository>().As<IDeveloperRepository>();
            builder.RegisterType<ProjectRepository>().As<IProjectRepository>();


            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);


            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
