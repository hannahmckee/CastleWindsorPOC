using System.Web.Http;
using Castle.Windsor;
using CastleWindsorPOC.DependencyResolution;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(CastleWindsorPOC.Startup))]

namespace CastleWindsorPOC
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var container = new WindsorContainer()
                .Install(
                    new ControllerInstaller(),
                    new ServiceInstaller());

            var httpDependencyResolver = new WindsorHttpDependencyResolver(container);

            var configuration = new HttpConfiguration();
            configuration.MapHttpAttributeRoutes();
            configuration.DependencyResolver = httpDependencyResolver;
            app.UseWebApi(configuration);
        }
    }
}
