using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using GeekHunter.Repositories;
using Autofac;
using Autofac.Integration.Mvc;

namespace GeekHunter
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<CandidateRepository>()
                .As<ICandidateRepository>()
                .InstancePerRequest();

            builder.RegisterType<SkillRepository>()
                .As<ISkillRepository>()
                .InstancePerRequest();

            // the class in Global.asax.)
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));


            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
