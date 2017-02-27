using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using CastleWindsorPOC.Domain;
using CastleWindsorPOC.Domain.Interfaces;

namespace CastleWindsorPOC.DependencyResolution
{
    internal sealed class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IWatchService>()
                    .ImplementedBy<WatchService>()
                    .LifestylePerWebRequest());
        }
    }
}